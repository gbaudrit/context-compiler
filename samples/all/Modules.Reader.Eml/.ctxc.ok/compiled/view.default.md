## Evidence

### E-5383db70f55b

CR - Atelier

_Source: `C:\Users\g.baudrit\source\repos\gbaudrit\context-compiler\samples\all\Modules.Reader.Eml\inputs/CR - Atelier .eml` (subject/subject)_

### E-e488fd59b5a5

PAZP264MB2957033E6741CFE24FDF8F24932F2@PAZP264MB2957.FRAP264.PROD.OUTLOOK.COM

_Source: `C:\Users\g.baudrit\source\repos\gbaudrit\context-compiler\samples\all\Modules.Reader.Eml\inputs/CR - Atelier .eml` (message-id/message-id)_

### E-af4db0d7c5f4

2026-04-20T11:06:20.0000000+00:00

_Source: `C:\Users\g.baudrit\source\repos\gbaudrit\context-compiler\samples\all\Modules.Reader.Eml\inputs/CR - Atelier .eml` (date/date)_

### E-a3f2f3f35fe1

Guillaume BAUDRIT

_Source: `C:\Users\g.baudrit\source\repos\gbaudrit\context-compiler\samples\all\Modules.Reader.Eml\inputs/CR - Atelier .eml` (from:0:name/from:0:name)_

### E-14aca3057cfb

g.baudrit@groupeonepoint.com

_Source: `C:\Users\g.baudrit\source\repos\gbaudrit\context-compiler\samples\all\Modules.Reader.Eml\inputs/CR - Atelier .eml` (from:0:email/from:0:email)_

### E-14d3675d54be

Guillaume BAUDRIT

_Source: `C:\Users\g.baudrit\source\repos\gbaudrit\context-compiler\samples\all\Modules.Reader.Eml\inputs/CR - Atelier .eml` (to:0:name/to:0:name)_

### E-e8e98ab6b426

g.baudrit@groupeonepoint.com

_Source: `C:\Users\g.baudrit\source\repos\gbaudrit\context-compiler\samples\all\Modules.Reader.Eml\inputs/CR - Atelier .eml` (to:0:email/to:0:email)_

### E-ff64b2d93aaa

Cédric NAEL

_Source: `C:\Users\g.baudrit\source\repos\gbaudrit\context-compiler\samples\all\Modules.Reader.Eml\inputs/CR - Atelier .eml` (cc:0:name/cc:0:name)_

### E-fe7789cf4733

c.nael@groupeonepoint.com

_Source: `C:\Users\g.baudrit\source\repos\gbaudrit\context-compiler\samples\all\Modules.Reader.Eml\inputs/CR - Atelier .eml` (cc:0:email/cc:0:email)_

### E-d3adadee7f7b

Objet : CR – Atelier
Absents / Non présent :  Stéphane, Vincent, Elodie

Objectifs

  *
OBJ1 : Fournir la procédure décrivant comment ajouter des champs dans SAPHIR au niveau base de données
  *
OBJ2 : Fournir la procédure décrivant comment gérer l'impact de l'ajout de champs sur les données existantes
  *
OBJ3 : Décrire comment la liaison entre la base de données et le code C# de Saphir est effectué
  *
OBJ4 : Fournir la procédure décrivant comment ajouter des champs dans SAPHIR au niveau IHM
  *
OBJ5 : Déterminer le processus de validation de l'ajout des champs (qui valide)
Bonus : Voir dans KSL c'est mappé

Points abordés


Type
Sujet
Synthèse
Technique
OBJ1

  *
Aujourd'hui des dev MAPPEUR (Georges + Vincent) qui font l'ajout
  *
Utilisation d'un outil pour générer les classes opa en se basant sur SaphirOPA.xml (Fait par DEV mappeur)
  *
Le mappeur va coté SQL (Projet SaphirSQL) pour modifier le schéma  (script sql)

Technique
OBJ2

  *
Le mappeur va coté SQL (Projet SaphirSQL) dans le script scInitDataValues.sql pour mettre à jour les données en base via requête
  *
Mise à jour de la base de REF pour la mettre Iso Prod (fait au moment de la mise en prod, hors scope)

Technique
OBJ3

  *
Nomenclature de nom de classe
     *
O0 classe données -> champs persistants
     *
F0 classe fonctions
  *
On peut partir de l'exemple aSRFacO0FactureProduit -> au niveau code, pas de règle strict
  *
Projet SaphirOPA = DAL (aSRFacO0FactureProduit_opa)
     *
1 champ = 2h de temps, 10 champs = ½ journée (abaque temps pour Georges)

Technique
OBJ4
Décaler dans l'atelier du Vendredi 28/11
Process
OBJ5

  *
Faire une demande groupé à Vincent pour l'ajout de champ il valide le nommage
  *
Modifier le code  Appli (dev classique)
  *
Transfert au dev MAPPEUR pour modification DAL + SQl mise a jour des données actuelles + ajout des champs en base
  *
Code review
  *
Tests de non régression fait par une équipe de Tests (Equipe Bonito)

Bonus KSL

  *
aSRDocO0FluxFactureProduit -> classe de flux




Georges : Stéphane reste la bibliothèque qui aura la réponse à toutes les problématiques

Décisions

  *
Validées : -
  *
Annulées / Non validées : -
  *
À arbitrer  :
     *
Préconisation de Création d'une branche de développement Onepoint / DEV : A valider Stéphane / Vincent
     *
Pour OBJ1/OBJ5 :  Valider si OP modifie la DAL (SaphirOPA) ou si on reste sur le process de dev MAPPEUR interne SAUR  (Georges et Vincent exclusivement)
        *
Hypothèse 1 : Si OP modifie la DAL : Code review coté SAUR niveau DAL (Georges ou VIncent)
        *
Hypothèse 2 : Si Saur modifie la DAL : vous rester maître de votre process

Actions


 Action
 Responsable
 Criticité
 Echéance
 Commentaires
Doc dev référence entre les champs
Georges

27/11
aRefTo, ....
Doc des règles de nommage
Georges

27/11







Criticité = Bloquant, Normal, Basse
Risques / Points de vigilance

  *
Attention à la modélisation de la table TVA qu'il va falloir rapidement vérifier (vigilance Nadir)

Documents

  *
-

Prochaines étapes

  *
Prochain atelier : -
  *
Préparation attendue : Actions effectuées pour les responsables d'actions



Guillaume BAUDRIT

Associate

www.groupeonepoint.com

[Multi-Alliances]

_Source: `C:\Users\g.baudrit\source\repos\gbaudrit\context-compiler\samples\all\Modules.Reader.Eml\inputs/CR - Atelier .eml` (text-body/text-body)_

### E-b032d7aae011

<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8">
<style type="text/css" style="display:none;"> P {margin-top:0;margin-bottom:0;} </style>
</head>
<body dir="ltr">
<div class="elementToProof" style="text-align: left; text-indent: 0px; background-color: rgb(255, 255, 255); margin: 1em 0px; font-family: Aptos, Aptos_EmbeddedFont, Aptos_MSFontService, Calibri, Helvetica, sans-serif; font-size: 12pt; color: rgb(0, 0, 0);">
<b>Objet : CR – Atelier</b></div>
<div class="elementToProof" style="text-align: left; text-indent: 0px; background-color: rgb(255, 255, 255); margin: 0px; font-family: Aptos, Aptos_EmbeddedFont, Aptos_MSFontService, Calibri, Helvetica, sans-serif; font-size: 12pt; color: rgb(0, 0, 0);">
<b>Absents / Non présent </b>:&nbsp; Stéphane, Vincent, Elodie</div>
<div class="elementToProof" style="text-align: left; text-indent: 0px; background-color: rgb(255, 255, 255); margin: 0px; font-family: Aptos, Aptos_EmbeddedFont, Aptos_MSFontService, Calibri, Helvetica, sans-serif; font-size: 12pt; color: rgb(0, 0, 0);">
<b><br>
</b></div>
<div class="elementToProof" style="text-align: left; text-indent: 0px; background-color: rgb(255, 255, 255); margin: 0px; font-family: Aptos, Aptos_EmbeddedFont, Aptos_MSFontService, Calibri, Helvetica, sans-serif; font-size: 12pt; color: rgb(0, 0, 0);">
<b>Objectifs</b></div>
<ul data-start="406" data-end="437" style="text-align: left; background-color: rgb(255, 255, 255);">
<li style="font-family: Aptos, Aptos_EmbeddedFont, Aptos_MSFontService, Calibri, Helvetica, sans-serif; font-size: 12pt; color: rgb(0, 0, 0);">
<div class="elementToProof" role="presentation" style="margin: 1em 0px;">OBJ1 : Fournir la procédure décrivant comment ajouter des champs dans SAPHIR au niveau base de données</div>
</li><li style="font-family: Aptos, Aptos_EmbeddedFont, Aptos_MSFontService, Calibri, Helvetica, sans-serif; font-size: 12pt; color: rgb(0, 0, 0);">
<div class="elementToProof" role="presentation" style="margin: 1em 0px;">OBJ2&nbsp;: Fournir la procédure décrivant comment gérer l'impact de l'ajout de champs sur les données existantes</div>
</li><li style="font-family: Aptos, Aptos_EmbeddedFont, Aptos_MSFontService, Calibri, Helvetica, sans-serif; font-size: 12pt; color: rgb(0, 0, 0);">
<div class="elementToProof" role="presentation" style="margin: 1em 0px;">OBJ3&nbsp;: Décrire comment la liaison entre la base de données et le code C# de Saphir est effectué</div>
</li><li style="font-family: Aptos, Aptos_EmbeddedFont, Aptos_MSFontService, Calibri, Helvetica, sans-serif; font-size: 12pt; color: rgb(0, 0, 0);">
<div class="elementToProof" role="presentation" style="margin: 1em 0px;">OBJ4&nbsp;: Fournir la procédure décrivant comment ajouter des champs dans SAPHIR au niveau IHM</div>
</li><li style="font-family: Aptos, Aptos_EmbeddedFont, Aptos_MSFontService, Calibri, Helvetica, sans-serif; font-size: 12pt; color: rgb(0, 0, 0);">
<div class="elementToProof" role="presentation" style="margin: 1em 0px;">OBJ5&nbsp;: Déterminer le processus de validation de l'ajout des champs (qui valide)</div>
<div class="elementToProof" role="presentation" style="margin: 1em 0px;">Bonus : Voir dans KSL c'est mappé</div>
</li></ul>
<div class="elementToProof" style="text-align: left; text-indent: 0px; background-color: rgb(255, 255, 255); margin: 0px; font-family: Aptos, Aptos_EmbeddedFont, Aptos_MSFontService, Calibri, Helvetica, sans-serif; font-size: 12pt; color: rgb(0, 0, 0);">
<b><br>
</b></div>
<div class="elementToProof" style="text-align: left; text-indent: 0px; background-color: rgb(255, 255, 255); margin: 0px; font-family: Aptos, Aptos_EmbeddedFont, Aptos_MSFontService, Calibri, Helvetica, sans-serif; font-size: 12pt; color: rgb(0, 0, 0);">
<b>Points abordés</b></div>
<div class="elementToProof" style="text-align: left; text-indent: 0px; background-color: rgb(255, 255, 255); margin: 0px; font-family: Aptos, Aptos_EmbeddedFont, Aptos_MSFontService, Calibri, Helvetica, sans-serif; font-size: 12pt; color: rgb(0, 0, 0);">
<b><br>
</b></div>
<div style="background-color: rgb(255, 255, 255); margin: 0px;">
<div class="elementToProof" style="text-align: left; text-indent: 0px; margin: 0px; font-family: FluentSystemIcons; font-size: 20px; color: currentcolor;">
<span style="background-color: rgb(66, 66, 66); line-height: 1em;"></span></div>
<table id="x_table_0" data-editing-info="{&quot;topBorderColor&quot;:&quot;#000000&quot;,&quot;bottomBorderColor&quot;:&quot;#000000&quot;,&quot;verticalBorderColor&quot;:&quot;#000000&quot;,&quot;hasHeaderRow&quot;:false,&quot;hasFirstColumn&quot;:false,&quot;hasBandedRows&quot;:true,&quot;hasBandedColumns&quot;:false,&quot;bgColorEven&quot;:null,&quot;bgColorOdd&quot;:&quot;#CCCCCC&quot;,&quot;headerRowColor&quot;:&quot;#000000&quot;,&quot;tableBorderFormat&quot;:0,&quot;verticalAlign&quot;:null}" style="text-align: left; text-indent: 0px; box-sizing: border-box; border-collapse: collapse; border-spacing: 0px;">
<tbody>
<tr>
<td data-editing-info="{&quot;vAlignOverride&quot;:true}" style="text-align: left; text-indent: 0px; border-width: 1px; border-style: solid; border-color: rgb(0, 0, 0); vertical-align: top; width: 120.013px; height: 22px; box-sizing: border-box;">
<div class="skipProofing" style="text-align: left; text-indent: 0px; margin: 0px; font-family: Aptos, Aptos_EmbeddedFont, Aptos_MSFontService, Calibri, Helvetica, sans-serif; font-size: 12pt; color: rgb(0, 0, 0);">
<b>Type</b></div>
</td>
<td data-editing-info="{&quot;vAlignOverride&quot;:true}" style="text-align: left; text-indent: 0px; border-width: 1px; border-style: solid; border-color: rgb(0, 0, 0); vertical-align: top; width: 288.2px; height: 22px; box-sizing: border-box;">
<div class="skipProofing" style="text-align: left; text-indent: 0px; margin: 0px; font-family: Aptos, Aptos_EmbeddedFont, Aptos_MSFontService, Calibri, Helvetica, sans-serif; font-size: 12pt; color: rgb(0, 0, 0);">
<b>Sujet</b></div>
</td>
<td data-editing-info="{&quot;vAlignOverride&quot;:true}" style="text-align: left; text-indent: 0px; border-width: 1px; border-style: solid; border-color: rgb(0, 0, 0); vertical-align: top; width: 1076.39px; height: 22px; box-sizing: border-box;">
<div class="skipProofing" style="text-align: left; text-indent: 0px; margin: 0px; font-family: Aptos, Aptos_EmbeddedFont, Aptos_MSFontService, Calibri, Helvetica, sans-serif; font-size: 12pt; color: rgb(0, 0, 0);">
<b>Synthèse</b></div>
</td>
</tr>
<tr>
<td data-editing-info="{&quot;vAlignOverride&quot;:true}" style="text-align: left; text-indent: 0px; border-width: 1px; border-style: solid; border-color: rgb(0, 0, 0); background-color: rgb(204, 204, 204); vertical-align: top; width: 120.013px; height: 22px; box-sizing: border-box;">
<div class="skipProofing" style="text-align: left; text-indent: 0px; margin: 0px; font-family: Aptos, Aptos_EmbeddedFont, Aptos_MSFontService, Calibri, Helvetica, sans-serif; font-size: 12pt; color: rgb(0, 0, 0);">
Technique</div>
</td>
<td data-editing-info="{&quot;vAlignOverride&quot;:true}" style="text-align: left; text-indent: 0px; border-width: 1px; border-style: solid; border-color: rgb(0, 0, 0); background-color: rgb(204, 204, 204); vertical-align: top; width: 288.2px; height: 22px; box-sizing: border-box;">
<div class="skipProofing" style="text-align: left; text-indent: 0px; margin: 0px; font-family: Aptos, Aptos_EmbeddedFont, Aptos_MSFontService, Calibri, Helvetica, sans-serif; font-size: 12pt; color: rgb(0, 0, 0);">
OBJ1</div>
</td>
<td data-editing-info="{&quot;vAlignOverride&quot;:true}" style="text-align: left; text-indent: 0px; border-width: 1px; border-style: solid; border-color: rgb(0, 0, 0); background-color: rgb(204, 204, 204); vertical-align: top; width: 1076.39px; height: 22px; box-sizing: border-box;">
<ul data-editing-info="{&quot;applyListStyleFromLevel&quot;:false,&quot;unorderedStyleType&quot;:2}" style="text-align: left; margin-top: 0px; margin-bottom: 0px; flex-direction: column; display: flex;">
<li style="font-family: Aptos, Aptos_EmbeddedFont, Aptos_MSFontService, Calibri, Helvetica, sans-serif; font-size: 12pt; color: rgb(0, 0, 0); align-self: start; list-style-type: &quot;- &quot;;">
<div class="skipProofing" role="presentation" style="text-align: left; text-indent: 0px; margin: 0px;">
<b>Aujourd'hui des dev MAPPEUR (Georges + Vincent) qui font l'ajout</b></div>
</li><li style="font-family: Aptos, Aptos_EmbeddedFont, Aptos_MSFontService, Calibri, Helvetica, sans-serif; font-size: 12pt; color: rgb(0, 0, 0); align-self: start; list-style-type: &quot;- &quot;;">
<div class="skipProofing" role="presentation" style="text-align: left; text-indent: 0px; margin: 0px;">
<b>Utilisation d'un outil pour générer les classes opa en se basant sur SaphirOPA.xml (Fait par DEV mappeur)</b></div>
</li><li style="font-family: Aptos, Aptos_EmbeddedFont, Aptos_MSFontService, Calibri, Helvetica, sans-serif; font-size: 12pt; color: rgb(0, 0, 0); align-self: start; list-style-type: &quot;- &quot;;">
<div class="skipProofing" role="presentation" style="text-align: left; text-indent: 0px; margin: 0px;">
<b>Le mappeur va coté SQL (Projet SaphirSQL) pour modifier le schéma&nbsp; (script sql)</b></div>
</li></ul>
</td>
</tr>
<tr>
<td data-editing-info="{&quot;vAlignOverride&quot;:true}" style="text-align: left; text-indent: 0px; border-width: 1px; border-style: solid; border-color: rgb(0, 0, 0); vertical-align: top; width: 120.013px; height: 22px; box-sizing: border-box;">
<div class="skipProofing" style="text-align: left; text-indent: 0px; margin: 0px; font-family: Aptos, Aptos_EmbeddedFont, Aptos_MSFontService, Calibri, Helvetica, sans-serif; font-size: 12pt; color: rgb(0, 0, 0);">
Technique</div>
</td>
<td data-editing-info="{&quot;vAlignOverride&quot;:true}" style="text-align: left; text-indent: 0px; border-width: 1px; border-style: solid; border-color: rgb(0, 0, 0); vertical-align: top; width: 288.2px; height: 22px; box-sizing: border-box;">
<div class="skipProofing" style="text-align: left; text-indent: 0px; margin: 0px; font-family: Aptos, Aptos_EmbeddedFont, Aptos_MSFontService, Calibri, Helvetica, sans-serif; font-size: 12pt; color: rgb(0, 0, 0);">
OBJ2</div>
</td>
<td data-editing-info="{&quot;vAlignOverride&quot;:true}" style="text-align: left; text-indent: 0px; border-width: 1px; border-style: solid; border-color: rgb(0, 0, 0); vertical-align: top; width: 1076.39px; height: 22px; box-sizing: border-box;">
<ul data-editing-info="{&quot;applyListStyleFromLevel&quot;:false,&quot;unorderedStyleType&quot;:2}" style="text-align: left; margin-top: 0px; margin-bottom: 0px; flex-direction: column; display: flex;">
<li style="font-family: Aptos, Aptos_EmbeddedFont, Aptos_MSFontService, Calibri, Helvetica, sans-serif; font-size: 12pt; color: rgb(0, 0, 0); align-self: start; list-style-type: &quot;- &quot;;">
<div class="skipProofing" role="presentation" style="text-align: left; text-indent: 0px; margin: 0px;">
<b>Le mappeur va coté SQL (Projet SaphirSQL) dans le script scInitDataValues.sql pour mettre à jour les données en base via requête</b></div>
</li><li style="font-family: Aptos, Aptos_EmbeddedFont, Aptos_MSFontService, Calibri, Helvetica, sans-serif; font-size: 12pt; color: rgb(0, 0, 0); align-self: start; list-style-type: &quot;- &quot;;">
<div class="skipProofing" role="presentation" style="text-align: left; text-indent: 0px; margin: 0px;">
<b>Mise à jour de la base de REF pour la mettre Iso Prod (fait au moment de la mise en prod, hors scope)</b></div>
</li></ul>
</td>
</tr>
<tr>
<td data-editing-info="{&quot;vAlignOverride&quot;:true}" style="text-align: left; text-indent: 0px; border-width: 1px; border-style: solid; border-color: rgb(0, 0, 0); background-color: rgb(204, 204, 204); vertical-align: top; width: 120.013px; height: 22px; box-sizing: border-box;">
<div class="skipProofing" style="text-align: left; text-indent: 0px; margin: 0px; font-family: Aptos, Aptos_EmbeddedFont, Aptos_MSFontService, Calibri, Helvetica, sans-serif; font-size: 12pt; color: rgb(0, 0, 0);">
Technique</div>
</td>
<td data-editing-info="{&quot;vAlignOverride&quot;:true}" style="text-align: left; text-indent: 0px; border-width: 1px; border-style: solid; border-color: rgb(0, 0, 0); background-color: rgb(204, 204, 204); vertical-align: top; width: 288.2px; height: 22px; box-sizing: border-box;">
<div class="skipProofing" style="text-align: left; text-indent: 0px; margin: 0px; font-family: Aptos, Aptos_EmbeddedFont, Aptos_MSFontService, Calibri, Helvetica, sans-serif; font-size: 12pt; color: rgb(0, 0, 0);">
OBJ3</div>
</td>
<td data-editing-info="{&quot;vAlignOverride&quot;:true}" style="text-align: left; text-indent: 0px; border-width: 1px; border-style: solid; border-color: rgb(0, 0, 0); background-color: rgb(204, 204, 204); vertical-align: top; width: 1076.39px; height: 22px; box-sizing: border-box;">
<ul data-editing-info="{&quot;applyListStyleFromLevel&quot;:false,&quot;unorderedStyleType&quot;:2}" style="text-align: left; margin-top: 0px; margin-bottom: 0px; flex-direction: column; display: flex;">
<li style="font-family: Aptos, Aptos_EmbeddedFont, Aptos_MSFontService, Calibri, Helvetica, sans-serif; font-size: 12pt; color: rgb(0, 0, 0); align-self: start; list-style-type: &quot;- &quot;;">
<div class="skipProofing" role="presentation" style="text-align: left; text-indent: 0px; margin: 0px;">
<b>Nomenclature de nom de classe</b></div>
</li><ul data-editing-info="{&quot;applyListStyleFromLevel&quot;:true}" style="text-align: left; margin-top: 0px; margin-bottom: 0px; list-style-type: circle; flex-direction: column; display: flex;">
<li style="font-family: Aptos, Aptos_EmbeddedFont, Aptos_MSFontService, Calibri, Helvetica, sans-serif; font-size: 12pt; color: rgb(0, 0, 0); align-self: start;">
<div class="skipProofing" role="presentation" style="text-align: left; text-indent: 0px; margin: 0px;">
<b>O0 classe données -&gt; champs persistants</b></div>
</li><li style="font-family: Aptos, Aptos_EmbeddedFont, Aptos_MSFontService, Calibri, Helvetica, sans-serif; font-size: 12pt; color: rgb(0, 0, 0); align-self: start;">
<div class="skipProofing" role="presentation" style="text-align: left; text-indent: 0px; margin: 0px;">
<b>F0 classe fonctions</b></div>
</li></ul>
<li style="font-family: Aptos, Aptos_EmbeddedFont, Aptos_MSFontService, Calibri, Helvetica, sans-serif; font-size: 12pt; color: rgb(0, 0, 0); align-self: start; list-style-type: &quot;- &quot;;">
<div class="skipProofing" role="presentation" style="text-align: left; text-indent: 0px; margin: 0px;">
<b>On peut partir de l'exemple aSRFacO0FactureProduit -&gt; au niveau code, pas de règle strict</b></div>
</li><li style="font-family: Aptos, Aptos_EmbeddedFont, Aptos_MSFontService, Calibri, Helvetica, sans-serif; font-size: 12pt; color: rgb(0, 0, 0); align-self: start; list-style-type: &quot;- &quot;;">
<div class="skipProofing" role="presentation" style="text-align: left; text-indent: 0px; margin: 0px;">
<b>Projet SaphirOPA = DAL (aSRFacO0FactureProduit_opa)</b></div>
</li><ul data-editing-info="{&quot;applyListStyleFromLevel&quot;:true}" style="text-align: left; margin-top: 0px; margin-bottom: 0px; list-style-type: circle; flex-direction: column; display: flex;">
<li style="font-family: Aptos, Aptos_EmbeddedFont, Aptos_MSFontService, Calibri, Helvetica, sans-serif; font-size: 12pt; color: rgb(0, 0, 0); align-self: start;">
<div class="skipProofing" role="presentation" style="text-align: left; text-indent: 0px; margin: 0px;">
<b>1 champ = 2h de temps, 10 champs = ½ journée (abaque temps pour Georges)</b></div>
</li></ul>
</ul>
</td>
</tr>
<tr>
<td data-editing-info="{&quot;vAlignOverride&quot;:true}" style="text-align: left; text-indent: 0px; border-width: 1px; border-style: solid; border-color: rgb(0, 0, 0); vertical-align: top; width: 120.013px; height: 22px; box-sizing: border-box;">
<div class="skipProofing" style="text-align: left; text-indent: 0px; margin: 0px; font-family: Aptos, Aptos_EmbeddedFont, Aptos_MSFontService, Calibri, Helvetica, sans-serif; font-size: 12pt; color: rgb(0, 0, 0);">
Technique</div>
</td>
<td data-editing-info="{&quot;vAlignOverride&quot;:true}" style="text-align: left; text-indent: 0px; border-width: 1px; border-style: solid; border-color: rgb(0, 0, 0); vertical-align: top; width: 288.2px; height: 22px; box-sizing: border-box;">
<div class="skipProofing" style="text-align: left; text-indent: 0px; margin: 0px; font-family: Aptos, Aptos_EmbeddedFont, Aptos_MSFontService, Calibri, Helvetica, sans-serif; font-size: 12pt; color: rgb(0, 0, 0);">
OBJ4</div>
</td>
<td data-editing-info="{&quot;vAlignOverride&quot;:true}" style="text-align: left; text-indent: 0px; border-width: 1px; border-style: solid; border-color: rgb(0, 0, 0); vertical-align: top; width: 1076.39px; height: 22px; box-sizing: border-box;">
<div class="skipProofing" style="text-align: left; text-indent: 0px; margin: 0px; font-family: Aptos, Aptos_EmbeddedFont, Aptos_MSFontService, Calibri, Helvetica, sans-serif; font-size: 12pt; color: rgb(0, 0, 0);">
Décaler dans l'atelier du Vendredi 28/11</div>
</td>
</tr>
<tr>
<td data-editing-info="{&quot;vAlignOverride&quot;:true}" style="text-align: left; text-indent: 0px; border-width: 1px; border-style: solid; border-color: rgb(0, 0, 0); background-color: rgb(204, 204, 204); vertical-align: top; width: 120.013px; height: 22px; box-sizing: border-box;">
<div class="skipProofing" style="text-align: left; text-indent: 0px; margin: 0px; font-family: Aptos, Aptos_EmbeddedFont, Aptos_MSFontService, Calibri, Helvetica, sans-serif; font-size: 12pt; color: rgb(0, 0, 0);">
Process</div>
</td>
<td data-editing-info="{&quot;vAlignOverride&quot;:true}" style="text-align: left; text-indent: 0px; border-width: 1px; border-style: solid; border-color: rgb(0, 0, 0); background-color: rgb(204, 204, 204); vertical-align: top; width: 288.2px; height: 22px; box-sizing: border-box;">
<div class="skipProofing" style="text-align: left; text-indent: 0px; margin: 0px; font-family: Aptos, Aptos_EmbeddedFont, Aptos_MSFontService, Calibri, Helvetica, sans-serif; font-size: 12pt; color: rgb(0, 0, 0);">
OBJ5</div>
</td>
<td data-editing-info="{&quot;vAlignOverride&quot;:true}" style="text-align: left; text-indent: 0px; border-width: 1px; border-style: solid; border-color: rgb(0, 0, 0); background-color: rgb(204, 204, 204); vertical-align: top; width: 1076.39px; height: 22px; box-sizing: border-box;">
<ul data-editing-info="{&quot;applyListStyleFromLevel&quot;:false,&quot;unorderedStyleType&quot;:2}" style="text-align: left; margin-top: 0px; margin-bottom: 0px; flex-direction: column; display: flex;">
<li style="font-family: Aptos, Aptos_EmbeddedFont, Aptos_MSFontService, Calibri, Helvetica, sans-serif; font-size: 12pt; color: rgb(0, 0, 0); align-self: start; list-style-type: &quot;- &quot;;">
<div class="skipProofing" role="presentation" style="text-align: left; text-indent: 0px; margin: 0px;">
<b>Faire une demande groupé à Vincent pour l'ajout de champ il valide le nommage</b></div>
</li><li style="font-family: Aptos, Aptos_EmbeddedFont, Aptos_MSFontService, Calibri, Helvetica, sans-serif; font-size: 12pt; color: rgb(0, 0, 0); align-self: start; list-style-type: &quot;- &quot;;">
<div class="skipProofing" role="presentation" style="text-align: left; text-indent: 0px; margin: 0px;">
<b>Modifier le code&nbsp; Appli (dev classique)</b></div>
</li><li style="font-family: Aptos, Aptos_EmbeddedFont, Aptos_MSFontService, Calibri, Helvetica, sans-serif; font-size: 12pt; color: rgb(0, 0, 0); align-self: start; list-style-type: &quot;- &quot;;">
<div class="skipProofing" role="presentation" style="text-align: left; text-indent: 0px; margin: 0px;">
<b>Transfert au dev MAPPEUR pour modification DAL + SQl mise a jour des données actuelles + ajout des champs en base</b></div>
</li><li style="font-family: Aptos, Aptos_EmbeddedFont, Aptos_MSFontService, Calibri, Helvetica, sans-serif; font-size: 12pt; color: rgb(0, 0, 0); align-self: start; list-style-type: &quot;- &quot;;">
<div class="skipProofing" role="presentation" style="text-align: left; text-indent: 0px; margin: 0px;">
<b>Code review</b></div>
</li><li style="font-family: Aptos, Aptos_EmbeddedFont, Aptos_MSFontService, Calibri, Helvetica, sans-serif; font-size: 12pt; color: rgb(0, 0, 0); align-self: start; list-style-type: &quot;- &quot;;">
<div class="skipProofing" role="presentation" style="text-align: left; text-indent: 0px; margin: 0px;">
<b>Tests de non régression fait par une équipe de Tests (Equipe Bonito)</b></div>
</li></ul>
</td>
</tr>
<tr>
<td data-editing-info="{&quot;vAlignOverride&quot;:true}" style="text-align: left; text-indent: 0px; border-width: 1px; border-style: solid; border-color: rgb(0, 0, 0); vertical-align: top; width: 120.013px; height: 22px; box-sizing: border-box;">
<div class="skipProofing" style="text-align: left; text-indent: 0px; margin: 0px; font-family: Aptos, Aptos_EmbeddedFont, Aptos_MSFontService, Calibri, Helvetica, sans-serif; font-size: 12pt; color: rgb(0, 0, 0);">
<br>
</div>
</td>
<td data-editing-info="{&quot;vAlignOverride&quot;:true}" style="text-align: left; text-indent: 0px; border-width: 1px; border-style: solid; border-color: rgb(0, 0, 0); vertical-align: top; width: 288.2px; height: 22px; box-sizing: border-box;">
<div class="skipProofing" style="text-align: left; text-indent: 0px; margin: 0px; font-family: Aptos, Aptos_EmbeddedFont, Aptos_MSFontService, Calibri, Helvetica, sans-serif; font-size: 12pt; color: rgb(0, 0, 0);">
Bonus KSL</div>
</td>
<td data-editing-info="{&quot;vAlignOverride&quot;:true}" style="text-align: left; text-indent: 0px; border-width: 1px; border-style: solid; border-color: rgb(0, 0, 0); vertical-align: top; width: 1076.39px; height: 22px; box-sizing: border-box;">
<ul data-editing-info="{&quot;applyListStyleFromLevel&quot;:false,&quot;unorderedStyleType&quot;:2}" style="text-align: left; margin-top: 0px; margin-bottom: 0px; flex-direction: column; display: flex;">
<li style="font-family: Aptos, Aptos_EmbeddedFont, Aptos_MSFontService, Calibri, Helvetica, sans-serif; font-size: 12pt; color: rgb(0, 0, 0); align-self: start; list-style-type: &quot;- &quot;;">
<div class="skipProofing" role="presentation" style="text-align: left; text-indent: 0px; margin: 0px;">
<b>aSRDocO0FluxFactureProduit -&gt; classe de flux</b></div>
</li></ul>
</td>
</tr>
<tr>
<td data-editing-info="{&quot;vAlignOverride&quot;:true}" style="text-align: left; text-indent: 0px; border-width: 1px; border-style: solid; border-color: rgb(0, 0, 0); background-color: rgb(204, 204, 204); vertical-align: top; width: 120.013px; height: 22px; box-sizing: border-box;">
<div class="skipProofing" style="text-align: left; text-indent: 0px; margin: 0px; font-family: Aptos, Aptos_EmbeddedFont, Aptos_MSFontService, Calibri, Helvetica, sans-serif; font-size: 12pt; color: rgb(36, 36, 36);">
<br>
</div>
</td>
<td data-editing-info="{&quot;vAlignOverride&quot;:true}" style="text-align: left; text-indent: 0px; border-width: 1px; border-style: solid; border-color: rgb(0, 0, 0); background-color: rgb(204, 204, 204); vertical-align: top; width: 288.2px; height: 22px; box-sizing: border-box;">
<div class="skipProofing" style="text-align: left; text-indent: 0px; margin: 0px; font-family: Aptos, Aptos_EmbeddedFont, Aptos_MSFontService, Calibri, Helvetica, sans-serif; font-size: 12pt; color: rgb(36, 36, 36);">
<br>
</div>
</td>
<td data-editing-info="{&quot;vAlignOverride&quot;:true}" style="text-align: left; text-indent: 0px; border-width: 1px; border-style: solid; border-color: rgb(0, 0, 0); background-color: rgb(204, 204, 204); vertical-align: top; width: 1076.39px; height: 22px; box-sizing: border-box;">
<div class="skipProofing" style="text-align: left; text-indent: 0px; margin: 0px; font-family: Aptos, Aptos_EmbeddedFont, Aptos_MSFontService, Calibri, Helvetica, sans-serif; font-size: 12pt; color: rgb(36, 36, 36);">
<br>
</div>
</td>
</tr>
</tbody>
</table>
</div>
<div class="elementToProof" style="text-align: left; text-indent: 0px; background-color: rgb(255, 255, 255); margin: 0px; font-family: Aptos, Aptos_EmbeddedFont, Aptos_MSFontService, Calibri, Helvetica, sans-serif; font-size: 12pt; color: rgb(0, 0, 0);">
<b><br>
</b></div>
<div class="elementToProof" style="text-align: left; text-indent: 0px; background-color: rgb(255, 255, 255); margin: 0px; font-family: Aptos, Aptos_EmbeddedFont, Aptos_MSFontService, Calibri, Helvetica, sans-serif; font-size: 12pt; color: rgb(0, 0, 0);">
Georges : Stéphane reste la bibliothèque qui aura la réponse à toutes les problématiques</div>
<div class="elementToProof" style="text-align: left; text-indent: 0px; background-color: rgb(255, 255, 255); margin: 0px; font-family: Aptos, Aptos_EmbeddedFont, Aptos_MSFontService, Calibri, Helvetica, sans-serif; font-size: 12pt; color: rgb(0, 0, 0);">
<br>
</div>
<div class="elementToProof" style="text-align: left; text-indent: 0px; background-color: rgb(255, 255, 255); margin: 0px; font-family: Aptos, Aptos_EmbeddedFont, Aptos_MSFontService, Calibri, Helvetica, sans-serif; font-size: 12pt; color: rgb(0, 0, 0);">
<b>Décisions</b></div>
<ul data-start="921" data-end="1095" data-editing-info="{&quot;unorderedStyleType&quot;:2,&quot;applyListStyleFromLevel&quot;:false}" style="text-align: left; background-color: rgb(255, 255, 255);">
<li style="font-family: Aptos, Aptos_EmbeddedFont, Aptos_MSFontService, Calibri, Helvetica, sans-serif; font-size: 12pt; color: rgb(0, 0, 0); list-style-type: &quot;- &quot;;">
<div class="elementToProof" role="presentation" style="margin: 1em 0px;"><b>Validées : -</b></div>
</li><li style="font-family: Aptos, Aptos_EmbeddedFont, Aptos_MSFontService, Calibri, Helvetica, sans-serif; font-size: 12pt; color: rgb(0, 0, 0); list-style-type: &quot;- &quot;;">
<div class="elementToProof" role="presentation" style="margin: 1em 0px;"><b>Annulées / Non validées : -</b></div>
</li><li style="font-family: Aptos, Aptos_EmbeddedFont, Aptos_MSFontService, Calibri, Helvetica, sans-serif; font-size: 12pt; color: rgb(200, 38, 19); list-style-type: &quot;- &quot;;">
<div class="elementToProof" role="presentation" style="margin: 1em 0px;"><b>À arbitrer &nbsp;:</b></div>
</li><ul data-editing-info="{&quot;applyListStyleFromLevel&quot;:true}" data-start="1038" data-end="1095" style="list-style-type: circle;">
<li style="font-family: Aptos, Aptos_EmbeddedFont, Aptos_MSFontService, Calibri, Helvetica, sans-serif; font-size: 12pt; color: rgb(200, 38, 19);">
<div class="elementToProof" role="presentation" style="margin: 1em 0px;">Préconisation de Création d'une branche de développement Onepoint / DEV : A valider Stéphane / Vincent</div>
</li></ul>
<ul data-start="1038" data-end="1095">
<li style="font-family: Aptos, Aptos_EmbeddedFont, Aptos_MSFontService, Calibri, Helvetica, sans-serif; font-size: 12pt; color: rgb(200, 38, 19);">
<div class="elementToProof" role="presentation" style="margin: 1em 0px;">Pour OBJ1/OBJ5 :&nbsp; Valider si OP modifie la DAL (SaphirOPA) ou si on reste sur le process de dev MAPPEUR interne SAUR &nbsp;(Georges et Vincent exclusivement)</div>
</li><ul data-editing-info="{&quot;applyListStyleFromLevel&quot;:true}" style="list-style-type: square;">
<li style="font-family: Aptos, Aptos_EmbeddedFont, Aptos_MSFontService, Calibri, Helvetica, sans-serif; font-size: 12pt; color: rgb(200, 38, 19);">
<div class="elementToProof" role="presentation" style="margin: 1em 0px;">Hypothèse 1 : Si OP modifie la DAL : Code review coté SAUR niveau DAL (Georges ou VIncent)</div>
</li><li style="font-family: Aptos, Aptos_EmbeddedFont, Aptos_MSFontService, Calibri, Helvetica, sans-serif; font-size: 12pt; color: rgb(200, 38, 19);">
<div class="elementToProof" role="presentation" style="margin: 1em 0px;">Hypothèse 2 : Si Saur modifie la DAL : vous rester maître de votre process</div>
</li></ul>
</ul>
</ul>
<div class="elementToProof" style="text-align: left; text-indent: 0px; background-color: rgb(255, 255, 255); margin: 0px; font-family: Aptos, Aptos_EmbeddedFont, Aptos_MSFontService, Calibri, Helvetica, sans-serif; font-size: 12pt; color: rgb(0, 0, 0);">
<b>Actions</b></div>
<div class="elementToProof" style="text-align: left; text-indent: 0px; background-color: rgb(255, 255, 255); margin: 0px; font-family: Aptos, Aptos_EmbeddedFont, Aptos_MSFontService, Calibri, Helvetica, sans-serif; font-size: 12pt; color: rgb(0, 0, 0);">
<b><br>
</b></div>
<div style="background-color: rgb(255, 255, 255); margin: 0px;">
<div class="elementToProof" style="text-align: left; text-indent: 0px; margin: 0px; font-family: FluentSystemIcons; font-size: 20px; color: currentcolor;">
<span style="background-color: rgb(66, 66, 66); line-height: 1em;"></span></div>
<table id="x_table_0_0" data-editing-info="{&quot;topBorderColor&quot;:&quot;#000000&quot;,&quot;bottomBorderColor&quot;:&quot;#000000&quot;,&quot;verticalBorderColor&quot;:&quot;#000000&quot;,&quot;hasHeaderRow&quot;:false,&quot;hasFirstColumn&quot;:false,&quot;hasBandedRows&quot;:true,&quot;hasBandedColumns&quot;:false,&quot;bgColorEven&quot;:null,&quot;bgColorOdd&quot;:&quot;#CCCCCC&quot;,&quot;headerRowColor&quot;:&quot;#000000&quot;,&quot;tableBorderFormat&quot;:0,&quot;verticalAlign&quot;:null}" style="text-align: left; text-indent: 0px; box-sizing: border-box; border-collapse: collapse; border-spacing: 0px;">
<tbody>
<tr>
<td style="text-align: left; text-indent: 0px; border-width: 1px; border-style: solid; border-color: rgb(0, 0, 0); width: 189.5px; height: 22px; box-sizing: border-box;">
<div class="skipProofing" style="text-align: left; text-indent: 0px; margin: 0px; font-family: Aptos, Aptos_EmbeddedFont, Aptos_MSFontService, Calibri, Helvetica, sans-serif; font-size: 12pt; color: rgb(0, 0, 0);">
<b>&nbsp;Action</b></div>
</td>
<td style="text-align: left; text-indent: 0px; border-width: 1px; border-style: solid; border-color: rgb(0, 0, 0); width: 44.55px; height: 22px; box-sizing: border-box;">
<div class="skipProofing" style="text-align: left; text-indent: 0px; margin: 0px; font-family: Aptos, Aptos_EmbeddedFont, Aptos_MSFontService, Calibri, Helvetica, sans-serif; font-size: 12pt; color: rgb(0, 0, 0);">
<b>&nbsp;Responsable</b></div>
</td>
<td style="text-align: left; text-indent: 0px; border-width: 1px; border-style: solid; border-color: rgb(0, 0, 0); width: 119.062px; height: 22px; box-sizing: border-box;">
<div class="skipProofing" style="text-align: left; text-indent: 0px; margin: 0px; font-family: Aptos, Aptos_EmbeddedFont, Aptos_MSFontService, Calibri, Helvetica, sans-serif; font-size: 12pt; color: rgb(0, 0, 0);">
<b>&nbsp;Criticité</b></div>
</td>
<td style="text-align: left; text-indent: 0px; border-width: 1px; border-style: solid; border-color: rgb(0, 0, 0); width: 112.438px; height: 22px; box-sizing: border-box;">
<div class="skipProofing" style="text-align: left; text-indent: 0px; margin: 0px; font-family: Aptos, Aptos_EmbeddedFont, Aptos_MSFontService, Calibri, Helvetica, sans-serif; font-size: 12pt; color: rgb(0, 0, 0);">
<b>&nbsp;Echéance</b></div>
</td>
<td style="text-align: left; text-indent: 0px; border-width: 1px; border-style: solid; border-color: rgb(0, 0, 0); width: 1019.05px; height: 22px; box-sizing: border-box;">
<div class="skipProofing" style="text-align: left; text-indent: 0px; margin: 0px; font-family: Aptos, Aptos_EmbeddedFont, Aptos_MSFontService, Calibri, Helvetica, sans-serif; font-size: 12pt; color: rgb(0, 0, 0);">
<b>&nbsp;Commentaires</b></div>
</td>
</tr>
<tr>
<td style="text-align: left; text-indent: 0px; border-width: 1px; border-style: solid; border-color: rgb(0, 0, 0); background-color: rgb(204, 204, 204); width: 189.5px; height: 22px; box-sizing: border-box;">
<div class="skipProofing" style="text-align: left; text-indent: 0px; margin: 0px; font-family: Aptos, Aptos_EmbeddedFont, Aptos_MSFontService, Calibri, Helvetica, sans-serif; font-size: 12pt; color: rgb(0, 0, 0);">
<b>Doc dev référence entre les champs</b></div>
</td>
<td style="text-align: left; text-indent: 0px; border-width: 1px; border-style: solid; border-color: rgb(0, 0, 0); background-color: rgb(204, 204, 204); width: 44.55px; height: 22px; box-sizing: border-box;">
<div class="skipProofing" style="text-align: left; text-indent: 0px; margin: 0px; font-family: Aptos, Aptos_EmbeddedFont, Aptos_MSFontService, Calibri, Helvetica, sans-serif; font-size: 12pt; color: rgb(0, 0, 0);">
<b>Georges</b></div>
</td>
<td style="text-align: left; text-indent: 0px; border-width: 1px; border-style: solid; border-color: rgb(0, 0, 0); background-color: rgb(204, 204, 204); width: 119.062px; height: 22px; box-sizing: border-box;">
<div class="skipProofing" style="text-align: left; text-indent: 0px; margin: 0px; font-family: Aptos, Aptos_EmbeddedFont, Aptos_MSFontService, Calibri, Helvetica, sans-serif; font-size: 12pt; color: rgb(36, 36, 36);">
<br>
</div>
</td>
<td style="text-align: left; text-indent: 0px; border-width: 1px; border-style: solid; border-color: rgb(0, 0, 0); background-color: rgb(204, 204, 204); width: 112.438px; height: 22px; box-sizing: border-box;">
<div class="skipProofing" style="text-align: left; text-indent: 0px; margin: 0px; font-family: Aptos, Aptos_EmbeddedFont, Aptos_MSFontService, Calibri, Helvetica, sans-serif; font-size: 12pt; color: rgb(0, 0, 0);">
<b>27/11</b></div>
</td>
<td style="text-align: left; text-indent: 0px; border-width: 1px; border-style: solid; border-color: rgb(0, 0, 0); background-color: rgb(204, 204, 204); width: 1019.05px; height: 22px; box-sizing: border-box;">
<div class="skipProofing" style="text-align: left; text-indent: 0px; margin: 0px; font-family: Aptos, Aptos_EmbeddedFont, Aptos_MSFontService, Calibri, Helvetica, sans-serif; font-size: 12pt; color: rgb(0, 0, 0);">
<b>aRefTo, ....</b></div>
</td>
</tr>
<tr>
<td style="text-align: left; text-indent: 0px; border-width: 1px; border-style: solid; border-color: rgb(0, 0, 0); width: 189.5px; height: 22px; box-sizing: border-box;">
<div class="skipProofing" style="text-align: left; text-indent: 0px; margin: 0px; font-family: Aptos, Aptos_EmbeddedFont, Aptos_MSFontService, Calibri, Helvetica, sans-serif; font-size: 12pt; color: rgb(0, 0, 0);">
<b>Doc des règles de nommage</b></div>
</td>
<td style="text-align: left; text-indent: 0px; border-width: 1px; border-style: solid; border-color: rgb(0, 0, 0); width: 44.55px; height: 22px; box-sizing: border-box;">
<div class="skipProofing" style="text-align: left; text-indent: 0px; margin: 0px; font-family: Aptos, Aptos_EmbeddedFont, Aptos_MSFontService, Calibri, Helvetica, sans-serif; font-size: 12pt; color: rgb(0, 0, 0);">
<b>Georges</b></div>
</td>
<td style="text-align: left; text-indent: 0px; border-width: 1px; border-style: solid; border-color: rgb(0, 0, 0); width: 119.062px; height: 22px; box-sizing: border-box;">
<div class="skipProofing" style="text-align: left; text-indent: 0px; margin: 0px; font-family: Aptos, Aptos_EmbeddedFont, Aptos_MSFontService, Calibri, Helvetica, sans-serif; font-size: 12pt; color: rgb(36, 36, 36);">
<br>
</div>
</td>
<td style="text-align: left; text-indent: 0px; border-width: 1px; border-style: solid; border-color: rgb(0, 0, 0); width: 112.438px; height: 22px; box-sizing: border-box;">
<div class="skipProofing" style="text-align: left; text-indent: 0px; margin: 0px; font-family: Aptos, Aptos_EmbeddedFont, Aptos_MSFontService, Calibri, Helvetica, sans-serif; font-size: 12pt; color: rgb(0, 0, 0);">
<b>27/11</b></div>
</td>
<td style="text-align: left; text-indent: 0px; border-width: 1px; border-style: solid; border-color: rgb(0, 0, 0); width: 1019.05px; height: 22px; box-sizing: border-box;">
<div class="skipProofing" style="text-align: left; text-indent: 0px; margin: 0px; font-family: Aptos, Aptos_EmbeddedFont, Aptos_MSFontService, Calibri, Helvetica, sans-serif; font-size: 12pt; color: rgb(36, 36, 36);">
<br>
</div>
</td>
</tr>
<tr>
<td style="text-align: left; text-indent: 0px; border-width: 1px; border-style: solid; border-color: rgb(0, 0, 0); background-color: rgb(204, 204, 204); width: 189.5px; height: 22px; box-sizing: border-box;">
<div class="skipProofing" style="text-align: left; text-indent: 0px; margin: 0px; font-family: Aptos, Aptos_EmbeddedFont, Aptos_MSFontService, Calibri, Helvetica, sans-serif; font-size: 12pt; color: rgb(0, 0, 0);">
<br>
</div>
</td>
<td style="text-align: left; text-indent: 0px; border-width: 1px; border-style: solid; border-color: rgb(0, 0, 0); background-color: rgb(204, 204, 204); width: 44.55px; height: 22px; box-sizing: border-box;">
<div class="skipProofing" style="text-align: left; text-indent: 0px; margin: 0px; font-family: Aptos, Aptos_EmbeddedFont, Aptos_MSFontService, Calibri, Helvetica, sans-serif; font-size: 12pt; color: rgb(0, 0, 0);">
<br>
</div>
</td>
<td style="text-align: left; text-indent: 0px; border-width: 1px; border-style: solid; border-color: rgb(0, 0, 0); background-color: rgb(204, 204, 204); width: 119.062px; height: 22px; box-sizing: border-box;">
<div class="skipProofing" style="text-align: left; text-indent: 0px; margin: 0px; font-family: Aptos, Aptos_EmbeddedFont, Aptos_MSFontService, Calibri, Helvetica, sans-serif; font-size: 12pt; color: rgb(0, 0, 0);">
<br>
</div>
</td>
<td style="text-align: left; text-indent: 0px; border-width: 1px; border-style: solid; border-color: rgb(0, 0, 0); background-color: rgb(204, 204, 204); width: 112.438px; height: 22px; box-sizing: border-box;">
<div class="skipProofing" style="text-align: left; text-indent: 0px; margin: 0px; font-family: Aptos, Aptos_EmbeddedFont, Aptos_MSFontService, Calibri, Helvetica, sans-serif; font-size: 12pt; color: rgb(0, 0, 0);">
<br>
</div>
</td>
<td style="text-align: left; text-indent: 0px; border-width: 1px; border-style: solid; border-color: rgb(0, 0, 0); background-color: rgb(204, 204, 204); width: 1019.05px; height: 22px; box-sizing: border-box;">
<div class="skipProofing" style="text-align: left; text-indent: 0px; margin: 0px; font-family: Aptos, Aptos_EmbeddedFont, Aptos_MSFontService, Calibri, Helvetica, sans-serif; font-size: 12pt; color: rgb(0, 0, 0);">
<br>
</div>
</td>
</tr>
</tbody>
</table>
</div>
<div class="elementToProof" style="text-align: left; text-indent: 0px; background-color: rgb(255, 255, 255); margin: 0px; font-family: Aptos, Aptos_EmbeddedFont, Aptos_MSFontService, Calibri, Helvetica, sans-serif; font-size: 12pt; color: rgb(0, 0, 0);">
<b><br>
</b></div>
<blockquote class="elementToProof" style="background-color: rgb(255, 255, 255);">
<div class="elementToProof" style="text-align: left; text-indent: 0px; margin: 1em 0px; font-family: Aptos, Aptos_EmbeddedFont, Aptos_MSFontService, Calibri, Helvetica, sans-serif; font-size: 12pt; color: rgb(0, 0, 0);">
<i>Criticité = Bloquant, Normal, Basse</i></div>
</blockquote>
<div class="elementToProof" style="text-align: left; text-indent: 0px; background-color: rgb(255, 255, 255); margin: 0px; font-family: Aptos, Aptos_EmbeddedFont, Aptos_MSFontService, Calibri, Helvetica, sans-serif; font-size: 12pt; color: rgb(0, 0, 0);">
<b>Risques / Points de vigilance</b></div>
<ul data-start="1624" data-end="1744" style="text-align: left; background-color: rgb(255, 255, 255);">
<li style="font-family: Aptos, Aptos_EmbeddedFont, Aptos_MSFontService, Calibri, Helvetica, sans-serif; font-size: 12pt; color: rgb(0, 0, 0);">
<div class="elementToProof" role="presentation" style="margin: 1em 0px;">Attention à la modélisation de la table TVA qu'il va falloir rapidement vérifier (vigilance Nadir)</div>
</li></ul>
<div class="elementToProof" style="text-align: left; text-indent: 0px; background-color: rgb(255, 255, 255); margin: 0px; font-family: Aptos, Aptos_EmbeddedFont, Aptos_MSFontService, Calibri, Helvetica, sans-serif; font-size: 12pt; color: rgb(0, 0, 0);">
<b>Documents&nbsp;</b></div>
<ul data-start="1789" data-end="1886" style="text-align: left; background-color: rgb(255, 255, 255);">
<li style="font-family: Aptos, Aptos_EmbeddedFont, Aptos_MSFontService, Calibri, Helvetica, sans-serif; font-size: 12pt; color: rgb(0, 0, 0);">
<div class="elementToProof" role="presentation" style="margin: 1em 0px;">-</div>
</li></ul>
<div class="elementToProof" style="text-align: left; text-indent: 0px; background-color: rgb(255, 255, 255); margin: 0px; font-family: Aptos, Aptos_EmbeddedFont, Aptos_MSFontService, Calibri, Helvetica, sans-serif; font-size: 12pt; color: rgb(0, 0, 0);">
<b>Prochaines étapes</b></div>
<ul data-start="1918" data-end="2024" style="text-align: left; background-color: rgb(255, 255, 255);">
<li style="font-family: Aptos, Aptos_EmbeddedFont, Aptos_MSFontService, Calibri, Helvetica, sans-serif; font-size: 12pt; color: rgb(0, 0, 0);">
<div class="elementToProof" role="presentation" style="margin: 1em 0px;">Prochain atelier : -</div>
</li><li style="font-family: Aptos, Aptos_EmbeddedFont, Aptos_MSFontService, Calibri, Helvetica, sans-serif; font-size: 12pt; color: rgb(0, 0, 0);">
<div class="elementToProof" role="presentation" style="margin: 1em 0px;">Préparation attendue : Actions effectuées pour les responsables d'actions</div>
</li></ul>
<div class="elementToProof" style="font-family: Aptos, Aptos_EmbeddedFont, Aptos_MSFontService, Calibri, Helvetica, sans-serif; font-size: 12pt; color: rgb(0, 0, 0);">
<br>
</div>
<div style="font-family: Aptos, Aptos_EmbeddedFont, Aptos_MSFontService, Calibri, Helvetica, sans-serif; font-size: 12pt; color: rgb(0, 0, 0);">
<br>
</div>
<div id="Signature">
<table>
<tbody>
<tr>
<td>
<table cellspacing="0" cellpadding="0" style="line-height: 1.2; display: inline-table; color: rgb(0, 0, 0);">
<tbody>
<tr>
<td style="line-height: 1.2;">
<table cellspacing="0" cellpadding="0" style="line-height: 1.2; width: 100%; color: rgb(0, 0, 0); border-collapse: separate; border-spacing: 0px; box-sizing: border-box;">
<tbody>
<tr>
<td style="text-align: left; line-height: 1.2;">
<table cellspacing="0" cellpadding="0" style="text-align: left; line-height: 1.2; width: 100%; height: 100%; color: rgb(0, 0, 0); border-collapse: separate; border-spacing: 0px; box-sizing: border-box;">
<tbody>
<tr>
<td style="text-align: left; line-height: 1.2; width: 485px;">
<p style="text-align: left; line-height: 1.2; margin: 0px;"><span style="font-family: Arial; font-size: 15px; color: rgb(0, 0, 0);">Guillaume BAUDRIT</span></p>
</td>
</tr>
<tr>
<td style="text-align: left; line-height: 1.2; width: 485px;">
<p style="text-align: left; line-height: 1.2; margin: 0px;"><span style="font-family: Arial; font-size: 13px; color: rgb(74, 144, 226);">Associate</span></p>
</td>
</tr>
<tr>
<td style="text-align: left; line-height: 1.2; width: 485px;"></td>
</tr>
<tr>
<td style="text-align: left; line-height: 1.2; width: 485px;">
<p style="text-align: left; line-height: 1.2; margin: 0px;"><span style="font-family: Arial; font-size: 13px; color: rgb(0, 0, 0);"><u>www.groupeonepoint.com</u></span></p>
</td>
</tr>
</tbody>
</table>
</td>
</tr>
<tr>
<td style="text-align: left; line-height: 1.2; width: 485px; height: 50px;">
<div style="text-align: left; line-height: 1.2; font-family: Arial; font-size: 13px;">
<img alt="Multi-Alliances" width="210" height="76" style="width: 210px; height: 76.86px;" src="https://img.signitic.app/uploads/dee962ce8994e37024a91fa4e5f62f55.png"></div>
</td>
</tr>
</tbody>
</table>
</td>
</tr>
</tbody>
</table>
</td>
</tr>
</tbody>
</table>
</div>
</body>
</html>

_Source: `C:\Users\g.baudrit\source\repos\gbaudrit\context-compiler\samples\all\Modules.Reader.Eml\inputs/CR - Atelier .eml` (html-body/html-body)_

