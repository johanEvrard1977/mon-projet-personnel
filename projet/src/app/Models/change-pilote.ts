import { type } from './type';
import { Vaisseau } from './vaisseau';
import { Camp } from './camp';

export class ChangePilote {
    Id:number;
    Nom:string;
    Commentaires:string;
    Cout:number;
    Unique:boolean;
    ValeurPilotage:number;
    Type:type[];
    Vaisseaux:Vaisseau[];
    Camp:Camp[];
}
