import { Pilote } from './pilote';
import { Vaisseau } from './vaisseau';
import { Amelioration } from './amelioration';
import { User } from './user';
import { Escadron } from './escadron';
import { Camp } from './camp';

export class Collection {
    Id:number;
    Nom:string;
    Pilote:Pilote[];
    Vaisseau:Vaisseau[];
    Amelioration:Amelioration[];
    Escadron:Escadron[];
    Users:User[];
    Camp:Camp;
}
