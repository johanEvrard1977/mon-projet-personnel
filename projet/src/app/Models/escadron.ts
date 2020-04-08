import { Pilote } from './pilote';
import { Vaisseau } from './vaisseau';
import { Amelioration } from './amelioration';
import { Camp } from './camp';
import { Collection } from './collection';

export class Escadron {
    Id:number;
    Nom:string;
    Visible:boolean;
    Points:number;
    Description:string;
    Pilote:Pilote[];
    Vaisseau:Vaisseau[];
    Amelioration:Amelioration[];
    Camp:Camp[];
    Collection:Collection[];
}
