import { Pilote } from './pilote';
import { Vaisseau } from './vaisseau';
import { type } from './type';
import { Amelioration } from './amelioration';

export class Camp {
    Id:number;
    Nom:string;
    Pilote:Pilote[];
    Vaisseau:Vaisseau[];
    Amelioration:Amelioration[];
}
