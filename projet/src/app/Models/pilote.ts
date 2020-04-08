import { Camp } from './camp';
import { type } from './type';
import { Vaisseau } from './vaisseau';

export class Pilote {
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
