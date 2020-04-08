import { Pilote } from './pilote';
import { Vaisseau } from './vaisseau';

export class Camp {
    Id:number;
    Nom:string;
    Pilote:Pilote[];
    Vaisseaux:Vaisseau[]
}
