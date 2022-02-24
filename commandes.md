

# Créer un nouveau projet 
Exécuter la commande dans un répertoire qui ne contient pas déjà de projet.

Pour obtenir la liste des projets:
``` bash
pulumi new 
``` 

Pour créer un projet à partir d'un template spécifique:
``` bash
pulumi new azure-csharp -y
``` 

`-y` permet de confirmer la création.


# Effectuer un déploiement (ici sur Azure)
``` bash
az login 

pulumi up
``` 


# Lister les stack
``` bash
pulumi stack ls 
``` 


# Créer une stack
On va créer la stack `staging`:
``` bash
pulumi stack init staging
``` 


# Changer la stack active
On va utiliser la stack `dev` comme stack active:
``` bash
pulumi stack select dev 
``` 


# Prévisualiser les changements avant un déploiement 
Sur la stack active:
``` bash
pulumi preview 
``` 

Sur une stack donnée (ici `staging`):
``` bash
pulumi preview --stack staging
``` 


# Visualiser les configuration d'une stack
Pour la stack active
``` bash
pulumi config 
``` 

Pour une stack donnée (ici `staging`):
``` bash
pulumi config --stack staging
``` 


# Détruire le déploiement de la stack active
``` bash
pulumi destroy 
``` 


# Détruire le déploiement d'une stack donnée
On va détruire le déploiement de la stack `staging`:
``` bash
pulumi destroy --stack staging
``` 


# Supprimer une stack
On va supprimer la stack `staging`:
``` bash
pulumi stack rm staging
``` 
