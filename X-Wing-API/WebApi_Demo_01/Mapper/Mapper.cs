using System;
using DAL.Entities;
using DalXwing.Models;
using WebApi_Demo_01.Models;
using WebApiXwing.Models;
using WebApi_Demo_01.ViewModels;
using DAL.ViewModels;

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
                vaisseau = UM.Vaisseau,
                XIDVaisseau = UM.XIDVaisseau
            };
        }

        public static Actions MapToEntity(this actions UM)
        {
            return new Actions
            {
                Nom = UM.Nom,
                Id = UM.Id,
                Vaisseau = UM.vaisseau,
                XIDVaisseau = UM.XIDVaisseau
            };
        }

        public static actions MapToEntityToView(this ViewModelAction UM)
        {
            return new actions
            {
                Nom = UM.Nom,
                Id = UM.Id,
            };
        }

        public static ViewModelAction MapToEntityToView(this actions UM)
        {
            return new ViewModelAction
            {
                Nom = UM.Nom,
                Id = UM.Id,
            };
        }

        public static ViewAction MapToEntityToViewModel(this ViewModelAction UM)
        {
            return new ViewAction
            {
                Nom = UM.Nom,
                Id = UM.Id
            };
        }

        public static ViewModelAction MapToEntityToViewModel(this ViewAction UM)
        {
            return new ViewModelAction
            {
                Nom = UM.Nom,
                Id = UM.Id
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

        public static ameliorations MapToEntityToView(this ViewModelAmelioration UM)
        {
            return new ameliorations
            {
                Nom = UM.Nom,
                Id = UM.Id,
                Quantite = UM.Quantite
            };
        }

        public static ViewModelAmelioration MapToEntityToView(this ameliorations UM)
        {
            return new ViewModelAmelioration
            {
                Nom = UM.Nom,
                Id = UM.Id,
                Quantite = UM.Quantite
            };
        }

        public static ViewAmelioration MapToEntityToViewModel(this ViewModelAmelioration UM)
        {
            return new ViewAmelioration
            {
                Nom = UM.Nom,
                Id = UM.Id,
                Quantite = UM.Quantite
            };
        }

        public static ViewModelAmelioration MapToEntityToViewModel(this ViewAmelioration UM)
        {
            return new ViewModelAmelioration
            {
                Nom = UM.Nom,
                Id = UM.Id,
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
                Type = UM.Type,
                Amelioration = UM.Amelioration
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
                Type = UM.Type,
                Amelioration = UM.Amelioration
            };
        }

        public static camps MapToEntityToView(this ViewModelCamp UM)
        {
            return new camps
            {
                Nom = UM.Nom,
                Id = UM.Id,
            };
        }

        public static ViewModelCamp MapToEntityToView(this camps UM)
        {
            return new ViewModelCamp
            {
                Nom = UM.Nom,
                Id = UM.Id,
            };
        }

        public static ViewCamp MapToEntityToViewModel(this ViewModelCamp UM)
        {
            return new ViewCamp
            {
                Nom = UM.Nom,
                Id = UM.Id
            };
        }

        public static ViewModelCamp MapToEntityToViewModel(this ViewCamp UM)
        {
            return new ViewModelCamp
            {
                Nom = UM.Nom,
                Id = UM.Id
            };
        }

        public static ViewCamp MapToEntityToViewModel(this Camp UM)
        {
            return new ViewCamp
            {
                Nom = UM.Nom,
                Id = UM.Id
            };
        }

        public static Camp MapToEntityToView(this ViewCamp UM)
        {
            return new Camp
            {
                Nom = UM.Nom,
                Id = UM.Id
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
                Vaisseau = UM.Vaisseau,
                Users = UM.Users,
                XIDUser = UM.XIDUser,
                XIDAmelioration = UM.XIDAmelioration,
                XIDPilote = UM.XIDPilote,
                XIDVaisseau = UM.XIDVaisseau,
                Camp = UM.Camp,
                XIDCamp = UM.XIDCamp,
                XIDEscadron = UM.XIDEscadron,
                Escdrons = UM.Escdrons
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
                Vaisseau = UM.Vaisseau,
                Users = UM.Users,
                XIDUser = UM.XIDUser,
                XIDAmelioration = UM.XIDAmelioration,
                XIDPilote = UM.XIDPilote,
                XIDVaisseau = UM.XIDVaisseau,
                Camp = UM.Camp,
                XIDCamp = UM.XIDCamp,
                XIDEscadron = UM.XIDEscadron,
                Escdrons = UM.Escdrons
            };
        }

        public static collections MapToEntityToView(this ViewModelCollection UM)
        {
            return new collections
            {
                Nom = UM.Nom,
                Id = UM.Id,
            };
        }

        public static ViewModelCollection MapToEntityToView(this collections UM)
        {
            return new ViewModelCollection
            {
                Nom = UM.Nom,
                Id = UM.Id,
            };
        }

        public static ViewCollection MapToEntityToViewModel(this ViewModelCollection UM)
        {
            return new ViewCollection
            {
                Nom = UM.Nom,
                Id = UM.Id
            };
        }

        public static ViewModelCollection MapToEntityToViewModel(this ViewCollection UM)
        {
            return new ViewModelCollection
            {
                Nom = UM.Nom,
                Id = UM.Id
            };
        }

        public static TypeAmelioration MapToEntity(this typeAmeliorations UM)
        {
            return new TypeAmelioration
            {
                Nom = UM.Nom,
                Id = UM.Id,
                Amelioration = UM.Amelioration,
                XIDPilote = UM.XIDPilote
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

        public static typeAmeliorations MapToEntityToView(this ViewModelType UM)
        {
            return new typeAmeliorations
            {
                Nom = UM.Nom,
                Id = UM.Id,
            };
        }

        public static ViewModelType MapToEntityToView(this typeAmeliorations UM)
        {
            return new ViewModelType
            {
                Nom = UM.Nom,
                Id = UM.Id,
            };
        }

        public static ViewType MapToEntityToViewModel(this ViewModelType UM)
        {
            return new ViewType
            {
                Nom = UM.Nom,
                Id = UM.Id
            };
        }

        public static ViewModelType MapToEntityToViewModel(this ViewType UM)
        {
            return new ViewModelType
            {
                Nom = UM.Nom,
                Id = UM.Id
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
                Type = UM.Type,
                Camp = UM.Camp,
                XIDCamp = UM.XIDCamp,
                XIDVaisseau = UM.XIDVaisseau,
                XIDType = UM.XIDType,
                Quantite = UM.Quantite
            };
        }

        public static pilotes MapToEntityToView(this ViewModelPilote UM)
        {
            return new pilotes
            {
                Nom = UM.Nom,
                Id = UM.Id,
                Quantite = UM.Quantite
            };
        }

        public static ViewModelPilote MapToEntityToView(this pilotes UM)
        {
            return new ViewModelPilote
            {
                Nom = UM.Nom,
                Id = UM.Id,
                Quantite = UM.Quantite
            };
        }

        public static ViewPilote MapToEntityToViewModel(this ViewModelPilote UM)
        {
            return new ViewPilote
            {
                Nom = UM.Nom,
                Id = UM.Id,
                Quantite = UM.Quantite
            };
        }

        public static ViewModelPilote MapToEntityToViewModel(this ViewPilote UM)
        {
            return new ViewModelPilote
            {
                Nom = UM.Nom,
                Id = UM.Id,
                Quantite = UM.Quantite
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
                Camp = UM.Camp,
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
                Camp = UM.Camp,
                Pilote = UM.Pilote,
                XIDAction = UM.XIDAction,
                Quantite = UM.Quantite
            };
        }

        public static vaisseaux MapToEntityToView(this ViewModelVaisseau UM)
        {
            return new vaisseaux
            {
                Nom = UM.Nom,
                Id = UM.Id,
                Quantite = UM.Quantite
            };
        }

        public static ViewModelVaisseau MapToEntityToView(this vaisseaux UM)
        {
            return new ViewModelVaisseau
            {
                Nom = UM.Nom,
                Id = UM.Id,
                Quantite = UM.Quantite
            };
        }

        public static Vaisseaux MapToEntityTo(this ViewModelVaisseau UM)
        {
            return new Vaisseaux
            {
                Nom = UM.Nom,
                Id = UM.Id,
                Quantite = UM.Quantite
            };
        }

        public static ViewModelVaisseau MapToEntityTo(this Vaisseaux UM)
        {
            return new ViewModelVaisseau
            {
                Nom = UM.Nom,
                Id = UM.Id,
                Quantite = UM.Quantite
            };
        }

        public static ViewVaisseau MapToEntityToViewModel(this ViewModelVaisseau UM)
        {
            return new ViewVaisseau
            {
                Nom = UM.Nom,
                Id = UM.Id,
                Quantite = UM.Quantite
            };
        }

        public static ViewModelVaisseau MapToEntityToViewModel(this ViewVaisseau UM)
        {
            return new ViewModelVaisseau
            {
                Nom = UM.Nom,
                Id = UM.Id,
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

        public static Users MapToEntityToView(this ViewUserModel UM)
        {
            return new Users
            {
                Nom = UM.Nom,
                Id = UM.Id
            };
        }

        public static ViewUserModel MapToEntityToView(this Users UM)
        {
            return new ViewUserModel
            {
                Nom = UM.Nom,
                Id = UM.Id
            };
        }

        public static ViewUser MapToEntityToViewModel(this ViewUserModel UM)
        {
            return new ViewUser
            {
                Nom = UM.Nom,
                Id = UM.Id
            };
        }

        public static ViewUserModel MapToEntityToViewModel(this ViewUser UM)
        {
            return new ViewUserModel
            {
                Nom = UM.Nom,
                Id = UM.Id
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
                Amelioration = UM.Amelioration,
                Camp = UM.Camp,
                Collection = UM.Collection,
                Pilote = UM.Pilote,
                Vaisseau = UM.Vaisseau,
                XIDCamp = UM.XIDCamp,
                XIDColllection = UM.XIDColllection,
                XIDAmelioration = UM.XIDAmelioration,
                XIDPilote = UM.XIDPilote,
                XIDVaisseau = UM.XIDVaisseau,
                Quantite = UM.Quantite
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
                Amelioration = UM.Amelioration,
                Camp = UM.Camp,
                Collection = UM.Collection,
                Pilote = UM.Pilote,
                Vaisseau = UM.Vaisseau,
                XIDCamp = UM.XIDCamp,
                XIDColllection = UM.XIDColllection,
                XIDAmelioration = UM.XIDAmelioration,
                XIDPilote = UM.XIDPilote,
                XIDVaisseau = UM.XIDVaisseau,
                Quantite = UM.Quantite
            };
        }

        public static escadrons MapToEntityToView(this ViewModelEscadron UM)
        {
            return new escadrons
            {
                Nom = UM.Nom,
                Id = UM.Id
            };
        }

        public static ViewModelEscadron MapToEntityToView(this escadrons UM)
        {
            return new ViewModelEscadron
            {
                Nom = UM.Nom,
                Id = UM.Id
            };
        }

        public static ViewEscadron MapToEntityToViewModel(this ViewModelEscadron UM)
        {
            return new ViewEscadron
            {
                Nom = UM.Nom,
                Id = UM.Id
            };
        }

        public static ViewModelEscadron MapToEntityToViewModel(this ViewEscadron UM)
        {
            return new ViewModelEscadron
            {
                Nom = UM.Nom,
                Id = UM.Id
            };
        }
    }
}