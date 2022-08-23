export class CommentDTO{
    Name: string;
    Content: string;
    Date: Date;
    constructor(){
        this.Name = "",
        this.Content = "",
        this.Date = new Date()
    }
}