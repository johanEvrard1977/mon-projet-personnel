import { Pilote } from './pilote';
import { Vaisseau } from './vaisseau';
import { type } from './type';

export class Camp {
    Id:number;
    Nom:string;
    Pilote:Pilote[];
    Vaisseau:Vaisseau[];
    Type:type[];
}
