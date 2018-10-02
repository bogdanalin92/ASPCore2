import * as ko from "knockout";

class WebMailViewModel {
    // Data
    folders: string[] = ["Inbox", "Archive", "Sent", "Spam"];
    chosenFolderId: KnockoutObservable<string> = ko.observable();
    chosenFolderData: KnockoutObservable<Folder> = ko.observable();
    chosenMailData: KnockoutObservable<Mail> = ko.observable();
    goToFolder: (folder: string) => void;
    goToMail: (mail: Mail) => void;


    constructor() {
        // Behaviours
        // Load mail for folder
        this.goToFolder = (folder) => {
            this.chosenFolderId(folder);
            this.chosenMailData(null); // Stop showing a single mail
            fetch(`/api/mail/getfolder?folder=${folder}`)
                .then(function (response) {
                    return response.json();
                }).then(this.chosenFolderData);
        };

        // Load individual mail 
        this.goToMail = (mail) => {
            this.chosenFolderId(mail.folder);
            this.chosenFolderData(null); // Stop showing a folder
            fetch(`/api/mail/getmail?mailId=${mail.id}`)
                .then(function (response) {
                    return response.json();
                }).then(this.chosenMailData)
        };

        // Show inbox by default
        this.goToFolder("Inbox");
    }
}

class Mail {
    id: number;
    folder: string;
}

class Folder {
    id: string;
    mails: Array<Mail>;
}

ko.applyBindings(new WebMailViewModel());