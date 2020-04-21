using System;
using DAL.Entities;
using DalXwing.Models;
using WebApi_Demo_01.Models;
using WebApiXwing.Models;

namespace WebApi_Demo_01.Mapper
{
    public static class Mapper
    {
        public static actions MapToEntity(this Actions UM)
        {
            return new actions
            {
                Nom = UM.Nom,
                Id = UM.Id,
                vaisseau = UM.Vaisseau
            };
        }

        public static Actions MapToEntity(this actions UM)
        {
            return new Actions
            {
                Nom = UM.Nom,
                Id = UM.Id,
                Vaisseau = UM.vaisseau
            };
        }

        public static ameliorations MapToEntity(this Amelioration UM)
        {
            return new ameliorations
            {
                Nom = UM.Nom,
                Id = UM.Id,
                Cout = UM.Cout,
                Description = UM.Description,
                TailleMax = UM.TailleMax,
                TailleMin = UM.TailleMin,
                Unique = UM.Unique,
                UnParVaisseau = UM.UnParVaisseau,
                Type = UM.Type,
                XIDType = UM.XIDType,
                Quantite = UM.Quantite
            };
        }

        public static Amelioration MapToEntity(this ameliorations UM)
        {
            return new Amelioration
            {
                Nom = UM.Nom,
                Id = UM.Id,
                Cout = UM.Cout,
                Description = UM.Description,
                TailleMax = UM.TailleMax,
                TailleMin = UM.TailleMin,
                Unique = UM.Unique,
                UnParVaisseau = UM.UnParVaisseau,
                Type = UM.Type,
                XIDType = UM.XIDType,
                Quantite = UM.Quantite
            };
        }

        public static Camp MapToEntity(this camps UM)
        {
            return new Camp
            {
                Nom = UM.Nom,
                Id = UM.Id,
                Pilote = UM.Pilote,
                Vaisseau = UM.Vaisseau,
                Amelioration = UM.Amelioration,
                Type = UM.Type
            };
        }

        public static camps MapToEntity(this Camp UM)
        {
            return new camps
            {
                Nom = UM.Nom,
                Id = UM.Id,
                Pilote = UM.Pilote,
                Vaisseau = UM.Vaisseau,
                Amelioration = UM.Amelioration,
                Type = UM.Type
            };
        }

        public static Collection MapToEntity(this collections UM)
        {
            return new Collection
            {
                Nom = UM.Nom,
                Id = UM.Id,
                Amelioration = UM.Amelioration,
                Pilote = UM.Pilote,
                Escadrons = UM.Escadrons,
                Vaisseau = UM.Vaisseau,
                Users = UM.Users,
                Camp = UM.Camp,
                XIDAmelioration = UM.XIDAmelioration,
                XIDCamp = UM.XIDCamp,
                XIDCollection = UM.XIDCollection,
                XIDEscadron = UM.XIDEscadron,
                XIDPilote = UM.XIDPilote,
                XIDUser = UM.XIDUser,
                XIDVaisseau = UM.XIDVaisseau
            };
        }

        public static collections MapToEntity(this Collection UM)
        {
            return new collections
            {
                Nom = UM.Nom,
                Id = UM.Id,
                Amelioration = UM.Amelioration,
                Pilote = UM.Pilote,
                Escadrons = UM.Escadrons,
                Vaisseau = UM.Vaisseau,
                Users = UM.Users,
                Camp = UM.Camp,
                XIDAmelioration = UM.XIDAmelioration,
                XIDCamp = UM.XIDCamp,
                XIDCollection = UM.XIDCollection,
                XIDEscadron = UM.XIDEscadron,
                XIDPilote = UM.XIDPilote,
                XIDUser = UM.XIDUser,
                XIDVaisseau = UM.XIDVaisseau
            };
        }

        public static TypeAmelioration MapToEntity(this typeAmeliorations UM)
        {
            return new TypeAmelioration
            {
                Nom = UM.Nom,
                Id = UM.Id,
                Amelioration = UM.Amelioration,
                XIDPilote = UM.XIDPilote,
            };
        }

        public static typeAmeliorations MapToEntity(this TypeAmelioration UM)
        {
            return new typeAmeliorations
            {
                Nom = UM.Nom,
                Id = UM.Id,
                Amelioration = UM.Amelioration,
                XIDPilote = UM.XIDPilote
            };
        }

        public static Pilote MapToEntity(this pilotes UM)
        {
            return new Pilote
            {
                Nom = UM.Nom,
                Unique = UM.Unique,
                Cout = UM.Cout,
                ValeurPilotage = UM.ValeurPilotage,
                Commentaires = UM.Commentaires,
                Id = UM.Id,
                Vaisseaux = UM.Vaisseaux,
                Type = UM.Type,
                Camp = UM.Camp,
                XIDCamp = UM.XIDCamp,
                XIDVaisseau = UM.XIDVaisseau,
                XIDType = UM.XIDType,
                Quantite = UM.Quantite
            };
        }

        public static pilotes MapToEntity(this Pilote UM)
        {
            return new pilotes
            {
                Nom = UM.Nom,
                Unique = UM.Unique,
                Cout = UM.Cout,
                ValeurPilotage = UM.ValeurPilotage,
                Commentaires = UM.Commentaires,
                Id = UM.Id,
                Vaisseaux = UM.Vaisseaux,
                Quantite = UM.Quantite,
                Type = UM.Type,
                Camp = UM.Camp,
                XIDCamp = UM.XIDCamp,
                XIDVaisseau = UM.XIDVaisseau,
                XIDType = UM.XIDType

            };
        }

        public static vaisseaux MapToEntity(this Vaisseaux UM)
        {
            return new vaisseaux
            {
                Nom = UM.Nom,
                ValeurAgilite = UM.ValeurAgilite,
                ValeurArmePrincipale = UM.ValeurArmePrincipale,
                Bouclier = UM.Bouclier,
                Structure = UM.Structure,
                Energie = UM.Energie,
                Taille = UM.Taille,
                Capacite = UM.Capacite,
                Id = UM.Id,
                Action = UM.Action,
                camps = UM.camps,
                Pilote = UM.Pilote,
                XIDAction = UM.XIDAction,
                Quantite = UM.Quantite
            };
        }

        public static Vaisseaux MapToEntity(this vaisseaux UM)
        {
            return new Vaisseaux
            {
                Nom = UM.Nom,
                ValeurAgilite = UM.ValeurAgilite,
                ValeurArmePrincipale = UM.ValeurArmePrincipale,
                Bouclier = UM.Bouclier,
                Structure = UM.Structure,
                Energie = UM.Energie,
                Taille = UM.Taille,
                Capacite = UM.Capacite,
                Id = UM.Id,
                Action = UM.Action,
                camps = UM.camps,
                Pilote = UM.Pilote,
                XIDAction = UM.XIDAction,
                Quantite = UM.Quantite
            };
        }

        public static adresses MapToEntity(this Adresses UM)
        {
            return new adresses
            {
                Rue = UM.Rue,
                Numero = UM.Numero,
                Cp = UM.Cp,
                Ville = UM.Ville,
                Pays = UM.Pays,
                Id = UM.Id
            };
        }

        public static Adresses MapToEntity(this adresses UM)
        {
            return new Adresses
            {
                Rue = UM.Rue,
                Numero = UM.Numero,
                Cp = UM.Cp,
                Ville = UM.Ville,
                Pays = UM.Pays,
                Id = UM.Id
            };
        }

        public static Users MapToEntity(this User UM)
        {
            return new Users
            {
                Nom = UM.Nom,
                Mail = UM.Mail,
                Password = UM.Password,
                Prenom = UM.Prenom,
                Role = UM.Role,
                Id = UM.ID,
                UserName = UM.UserName,
                Collection = UM.Collection
            };
        }

        public static User MapToEntity(this Users UM)
        {
            return new User
            {
                Nom = UM.Nom,
                Mail = UM.Mail,
                Password = UM.Password,
                Prenom = UM.Prenom,
                Role = UM.Role,
                ID = UM.Id,
                UserName = UM.UserName,
                Collection = UM.Collection
            };
        }

        public static escadrons MapToEntity(this Escadron UM)
        {
            return new escadrons
            {
                Nom = UM.Nom,
                Id = UM.Id,
                Visible = UM.Visible,
                Points = UM.Points,
                Description = UM.Description,
                Camp = UM.Camp,
                Collection = UM.Collection,
                Pilote = UM.Pilote,
                Vaisseau = UM.Vaisseau,
                Amelioration = UM.Amelioration,
                Quantite = UM.Quantite,
                XIDVaisseau = UM.XIDVaisseau,
                XIDPilote = UM.XIDPilote,
                XIDAmelioration = UM.XIDAmelioration,
                XIDCamp = UM.XIDCamp,
                XIDCollection = UM.XIDCollection,
                XIDEscadron = UM.XIDEscadron
                
            };
        }

        public static Escadron MapToEntity(this escadrons UM)
        {
            return new Escadron
            {
                Nom = UM.Nom,
                Id = UM.Id,
                Visible = UM.Visible,
                Points = UM.Points,
                Description = UM.Description,
                Camp = UM.Camp,
                Collection = UM.Collection,
                Pilote = UM.Pilote,
                Vaisseau = UM.Vaisseau,
                Amelioration = UM.Amelioration,
                Quantite = UM.Quantite,
                XIDVaisseau = UM.XIDVaisseau,
                XIDPilote = UM.XIDPilote,
                XIDAmelioration = UM.XIDAmelioration,
                XIDCamp = UM.XIDCamp,
                XIDCollection = UM.XIDCollection,
                XIDEscadron = UM.XIDEscadron
            };
        }
    }
}