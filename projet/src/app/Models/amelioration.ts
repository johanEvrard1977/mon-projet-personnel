import { type } from './type';

export class Amelioration {
    Id:number;
    Nom:string;
    Cout:number;
    Description:string;
    TailleMax:number;
    TailleMin:number;
    UnParVaisseau:boolean;
    Unique:boolean;
    Type:type[];
    Quantite:number;
}
