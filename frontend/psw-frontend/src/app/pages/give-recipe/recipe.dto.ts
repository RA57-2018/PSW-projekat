export class RecipeDto {
    Medicine: String;
    Quantity: String;
    Instructions: String;

    constructor(){
        this.Medicine = "",
        this.Quantity = "",
        this.Instructions = ""
    }
}