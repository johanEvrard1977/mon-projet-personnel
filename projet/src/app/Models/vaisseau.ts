import { Pilote } from './pilote';
import { Camp } from './camp';
import { actions } from './actions';

export class Vaisseau {
    Id:number;
    Nom:string;
    Bouclier:number;
    Capacite:string;
    Energie:number;
    Structure:number;
    Taille:string;
    ValeurAgilite:number;
    ValeurArmePrincipale:number;
    Pilote:Pilote;
    Camp:Camp;
    Action:actions;
}
