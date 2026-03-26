## Evidence

### E-8ad333757aec

   Agence pour l’informatique
financière de l’État 

31/10/2025 

Dossier de spécifications externes 
de la facturation électronique 

Document général

Historique 

DATE DIFFUSION SUIVI DES MODIFICATIONS

18/12/2024 Publication v3.0 

30/10/2025 Publication v3.1 Modification des chapitres suivants : 
• Objectifs du document (1.1)
• Contenu du document (1.2)
• Rappel de l’existant en matière de dématérialisation des factures Le
contexte et les objectifs de la réforme de dématérialisation des factures
(2.2)
• L’obligation de facturation électronique (e-invoicing) et de transmission des
données de facture (2.3.1)
• L’obligation de transmission de données de transaction et de paiement (e-
reporting) (2.3.2)
• La typologie des acteurs (2.3.4)
• La mise en conformité progressive des assujettis à la TVA (2.3.5)
• Le circuit de transmission des factures entre assujettis (B2B) (2.3.6)
• Le circuit de transmission des factures B2G (2.3.7)
• Le rôle des plateformes agréées (PA) (2.3.8)
• L’immatriculation des plateformes agréées (PA) (2.3.9)
• L’interopérabilité des acteurs de la réforme (2.3.10)
• La cartographie des flux échangés (3.2)
• Les principes directeurs (3.3.1)
• Le raccordement en EDI (3.3.2)
• Le raccordement en API (3.3.3)
• La création d’un raccordement (3.3.4)
• La modification d’un raccordement (3.3.5)
• Le cycle de vie d’un flux (3.4.4)
• Le nommage des flux (3.4.6)
• Les principes directeurs (3.5.1)
• La cartographie des flux (3.5.2)
• L’initialisation de l’annuaire (3.5.3)
• La consultation de l’annuaire (3.5.4)
• L’actualisation de l’annuaire (3.5.5)
• La cartographie des flux (3.6.2)
• Les données réglementaires d’une facture (3.6.3)
• Les statuts obligatoires d’une facture (3.6.4) 

_Source: `c:\Users\g.baudrit\source\repos\gbaudrit\conf-aimer-votre-llm\demo\ctxc-sample-spec\with-ctxc\spec/dgfip/0- Dossier de specifications externes FE - Dossier général.pdf` (page:1/page:1)_

### E-ed90deb02e34

2 
DATE DIFFUSION SUIVI DES MODIFICATIONS
• Les contrôles fonctionnels des données réglementaires et des statuts
obligatoires (3.6.6)
• Le cycle de vie des objets métiers du type données réglementaires et
statuts obligatoires (3.6.7)
• Les motifs de rejet des objets métiers du type données réglementaires
(3.6.8)
• Les motifs de rejet des objets métiers du type statuts obligatoires (3.6.9)
• La bulle e-reporting (3.7)
• Les principes directeurs (3.7.1)
• La cartographie des flux (3.7.2)
• Les modalités de transmission (3.7.7)
• Le cycle de vie des données de transaction et de paiement (3.7.9)
• Les motifs de rejet des objets métiers du type données de transaction et de
paiement (3.7.10)
• Table des figures (4)
• Glossaire (5)
• Textes de référence (6)
• Contacts (7) 

Ajout des chapitres suivants : 
• Simplifications et tolérances (2.3.3)
• Délai de transmission des flux de cycle de vie de statuts obligatoires (3.6.5) 

Modification des figures suivantes :
• Figure 1 - Le circuit B2B
• Figure 2 - Le circuit B2G, avec Chorus Pro comme plateforme de réception
• Figure 3 - Le circuit B2G, avec raccordement direct du fournisseur à Chorus
Pro
• Figure 4 – Cartographie des flux échangés entre les acteurs de l'écosystème
• Figure 5 – Cinématique d’un flux entrant par protocole SFTP
• Figure 6 – Cinématique d’un flux sortant par protocole SFTP
• Figure 7 – Cinématique d’un flux entrant par protocole AS/2
• Figure 8 – Cinématique d’un flux sortant par protocole AS/2
• Figure 9 – Cinématique d’un flux entrant par protocole AS/4
• Figure 10 – Cinématique d’un flux sortant par protocole AS/4
• Figure 16 – Cinématique des flux F1
• Figure 17 – Cinématique des flux F6
• Figure 18 – Cinématique des flux F10
• Figure 19 – Cinématique des flux F13
• Figure 20 – Cinématique des flux F14
• Figure 21 – La cartographie des flux Annuaire échangés
• Figure 22 – Les sources d'initialisation de l'annuaire
• Figure 24 – La consultation de l'annuaire pour l'adressage et le routage de
facture
• Figure 27 – L'actualisation de l'annuaire par le référentiel des occurrences
fiscales
• Figure 28 – La création d’une ligne d'annuaire pour une entreprise
nouvellement assujettie
• Figure 29 – L'actualisation des lignes en vigueur à la suite du retrait du
caractère assujetti et/ou la cessation d’activité
• Figure 30 – Le masquage de lignes non entrées en vigueur à la suite du
retrait du caractère assujetti et/ou la cessation d’activité
• Figure 31 – L'actualisation de l'annuaire par le service d'immatriculation
• Figure 32 – L'actualisation de lignes en vigueur à la suite d'une perte
d'immatriculation
• Figure 33 – Le masquage de lignes non entrées en vigueur suite à une perte
d'immatriculation
• Figure 34 – L'actualisation de l'annuaire par le portail de services Chorus Pro 

_Source: `c:\Users\g.baudrit\source\repos\gbaudrit\conf-aimer-votre-llm\demo\ctxc-sample-spec\with-ctxc\spec/dgfip/0- Dossier de specifications externes FE - Dossier général.pdf` (page:2/page:2)_

### E-bdc7cd6d7f81

3 
DATE DIFFUSION SUIVI DES MODIFICATIONS
• Figure 35 – La création d'une ligne d'annuaire pour un nouveau service
• Figure 36 – L'actualisation de lignes à la suite d’une réduction du rôle d'une
structure publique à la maîtrise d'ouvrage (MOA)
• Figure 38 – L’actualisation de l’annuaire par une nouvelle PA
• Figure 39 – L'actualisation des lignes suite de la réduction du rôle d'une
structure publique à la maitrise d'ouvrage (MOA)
• Figure 40 – La création de services et des lignes d'annuaire correspondantes
• Figure 41 – La création de lignes à la suite de la mise en place d'une nouvelle
maille d'adressage
• Figure 42 – La création d'une nouvelle maille d'adressage
• Figure 43 – L'actualisation des lignes à la suite de la mise en place d'une
nouvelle maille d'adressage
• Figure 45 – La cartographie des flux e-invoicing et Cycle de vie échangés en
B2B
• Figure 46 – La cartographie des flux e-invoicing et Cycle de vie échangés en
B2G, si Chorus Pro est la plateforme de réception
• Figure 47 – La cartographie des flux e-invoicing et Cycle de vie échangés en
B2G, si Chorus Pro est la plateforme d'émission et réception
• Figure 48 – Le cycle de vie nominal d'une facture
• Figure 49 – Le cycle de vie d’un objet métier
• Figure 50 – La cartographie des flux e-reporting et Cycle de vie échangés
• Figure 52 – Le traitement des données de transaction et de paiement par
une PA en fonction de son offre de services
• Figure 55 – Les modalités de transmission au titre d’une période
• Figure 56 – Transmission distinctes des données de facture et transaction
des données de paiement
• Figure 57 – Les modalités de rectification d'une transmission au titre d’une
période révolue 

Ajout des figures suivantes : 
• Figure 15 – Recommandation de composition de l'identifiant d'un flux
• Figure 25 – Page d'accueil du portail Annuaire ( https://facturation.chorus-
pro.gouv.fr/annuaire/#/ )
• Figure 26 – Exemple d'écran de consultation du portail Annuaire
• Figure 37 – Exemple d'accord formel de choix de plateforme agréée   

_Source: `c:\Users\g.baudrit\source\repos\gbaudrit\conf-aimer-votre-llm\demo\ctxc-sample-spec\with-ctxc\spec/dgfip/0- Dossier de specifications externes FE - Dossier général.pdf` (page:3/page:3)_

### E-2d0c0d6c7e2d

4 
SOMMAIRE 

1 Propos liminaires .................................................................................................................................................. 6

1.1 Objectifs du document ......................................................................................................................... 6

1.2 Contenu du document .......................................................................................................................... 6

2 Introduction .......................................................................................................................................................... 7

2.1 Rappel de l’existant en matière de dématérialisation des factures ............................................. 7

2.2 Rappel de l’existant en matière de dématérialisation des factures : le contexte et les
objectifs de la réforme de dématérialisation des factures.............................................................................. 7

2.3 Le périmètre de la réforme................................................................................................................... 7

2.3.1. L’obligation de facturation électronique (e-invoicing) et de transmission des données de
facture …………………………………………………………………………………………………………………………………………………………………..8

2.3.2. L’obligation de transmission de données de transaction et de paiement (e-reporting) .......... 8

2.3.3. Simplifications et tolérances ................................................................................................................ 9

2.3.4. La typologie des acteurs ...................................................................................................................... 11

2.3.5. La mise en conformité progressive des assujettis à la TVA ..........................................................12

2.3.6. Le circuit de transmission des factures entre assujettis (B2B) ......................................................13

2.3.7. Le circuit de transmission des factures B2G ....................................................................................13

2.3.8. Le rôle des plateformes agréées (PA) ................................................................................................15

2.3.9. L’immatriculation des plateformes agréées (PA) ............................................................................15

2.3.10. L’interopérabilité des acteurs de la réforme ..............................................................................16

3 Présentation du portail public de facturation (PPF) .....................................................................................16

3.1 Les principes directeurs du portail public de facturation (PPF) ...................................................16

3.2 La cartographie des flux échangés .....................................................................................................16

3.3 Le raccordement au portail public de facturation (PPF) ...............................................................21

3.3.1. Les principes directeurs .......................................................................................................................21

3.3.2. Le raccordement en EDI ..................................................................................................................... 22

3.3.3. Le raccordement en API ...................................................................................................................... 26

3.3.4. La création d’un raccordement ......................................................................................................... 27

3.3.5. La modification d’un raccordement ................................................................................................. 28

3.3.6. La consultation d’un raccordement ................................................................................................. 28

3.4 Le système d’échanges ........................................................................................................................ 28

3.4.1. Les principes directeurs ...................................................................................................................... 28

3.4.2. Les contrôles techniques .................................................................................................................... 29

3.4.3. Les contrôles applicatifs ..................................................................................................................... 29

3.4.4. Le cycle de vie d’un flux ...................................................................................................................... 29

3.4.5. Les motifs d’irrecevabilité d’un flux .................................................................................................. 30

3.4.6. Le nommage des flux ........................................................................................................................... 32

3.5 L’annuaire ............................................................................................................................................... 36

3.5.1. Les principes directeurs ...................................................................................................................... 36 

_Source: `c:\Users\g.baudrit\source\repos\gbaudrit\conf-aimer-votre-llm\demo\ctxc-sample-spec\with-ctxc\spec/dgfip/0- Dossier de specifications externes FE - Dossier général.pdf` (page:4/page:4)_

### E-6ad4d4e01d64

5 
3.5.2. La cartographie des flux ...................................................................................................................... 36

3.5.3. L’initialisation de l’annuaire ................................................................................................................ 37

3.5.4. La consultation de l’annuaire ............................................................................................................. 40

3.5.5. L’actualisation de l’annuaire ............................................................................................................... 42

3.5.6. Les contrôles fonctionnels des objets métiers du type ligne d’annuaire .................................. 52

3.5.7. Le cycle de vie des objets métiers du type ligne d’annuaire ....................................................... 52

3.5.8. Les motifs de rejet des objets métiers du type ligne d’annuaire ................................................ 53

3.6 La bulle e-invoicing ............................................................................................................................... 53

3.6.1. Les principes directeurs ...................................................................................................................... 53

3.6.2. La cartographie des flux ...................................................................................................................... 53

3.6.3. Les données réglementaires d’une facture ..................................................................................... 56

3.6.4. Les statuts obligatoires d’une facture .............................................................................................. 57

3.6.5. Délai de transmission des flux de cycle de vie de statuts obligatoires ..................................... 59

3.6.6. Les contrôles fonctionnels des données réglementaires et des statuts obligatoires ............. 59

3.6.7. Le cycle de vie des objets métiers du type données réglementaires et statuts obligatoires 59

3.6.8. Les motifs de rejet des objets métiers du type données réglementaires ................................. 60

3.6.9. Les motifs de rejet des objets métiers du type statuts obligatoires ...........................................61

3.7 La bulle e-reporting ............................................................................................................................... 62

3.7.1. Les principes directeurs ...................................................................................................................... 62

3.7.2. La cartographie des flux ...................................................................................................................... 62

3.7.3. Les données de facture d’opérations internationales .................................................................. 64

3.7.4. Les données de paiement des factures des opérations internationales ................................... 64

3.7.5. Les données des opérations avec des non-assujettis .................................................................... 65

3.7.6. Les données de paiement des opérations avec des non-assujettis ............................................ 65

3.7.7. Les modalités de transmission ........................................................................................................... 65

3.7.8. Les contrôles fonctionnels des données de transaction et de paiement ................................. 68

3.7.9. Le cycle de vie des données de transaction et de paiement ...................................................... 69

3.7.10. Les motifs de rejet des objets métiers du type données de transaction et de paiement 69

4 Table des figures ..................................................................................................................................................71

5 Glossaire ............................................................................................................................................................... 72

6 Textes de référence ........................................................................................................................................... 75

7 Documentation applicable .............................................................................................................................. 76

8 Contacts ............................................................................................................................................................... 77  

_Source: `c:\Users\g.baudrit\source\repos\gbaudrit\conf-aimer-votre-llm\demo\ctxc-sample-spec\with-ctxc\spec/dgfip/0- Dossier de specifications externes FE - Dossier général.pdf` (page:5/page:5)_

### E-8c800c2ace24

6 
1 Propos liminaires

1.1 Objectifs du document

Le dossier des spécifications externes regroupe l’ensemble des documents décrivant les formats
d’échange avec le portail public de facturation1 (PPF) dans le cadre de la généralisation de la facturation
électronique entre assujettis à la TVA et de la transmission de données à l’administration, telle qu’elle
résulte de l’article 26 de la loi n°2022-1157 du 16 août 2022 de finances rectificative pour 2022, modifiée
par l’article 91 de la loi n°2023-1322 de finances pour 20242.

Ce document s’organise en plusieurs parties afin de présenter le contexte et les objectifs de la
facturation électronique, son cadre réglementaire, et décrire fonctionnellement la solution « portail
public de facturation » mise en place. 
Les spécifications externes entrent dans le cadre de l’organisation, du développement et de la gestion
des systèmes d’informations des acteurs impactés par ce projet. 

Ce document s’adresse directement aux plateformes agréées ainsi qu’à l’ensemble des acteurs suivants
:
• les entreprises françaises émettrices ou destinataires de factures ;
• les personnes morales de droit public françaises émettrices ou destinataires de factures ;
• les éditeurs de solutions logicielles ;
• les tiers de télétransmission (solutions compatibles) ;
• les prestataires informatiques en charge de la gestion des plateformes ; 
• les mandataires intervenants pour le compte des émetteurs ou destinataires des factures.

1.2 Contenu du document 

Ce document décrit, d’un point de vue fonctionnel et applicatif, les services proposés par le portail
public de facturation (PPF) et les modalités d’échanges avec les plateformes agréées (PA). 

Ce document n’est pas un guide utilisateur. 

1 Ce document ne décrit pas les formats d’échanges de factures entre les acteurs et leurs plateformes agréées ou entre
plateformes agréées. Ces formats et leurs modalités d’utilisation sont décrits dans les normes AFNOR XP Z12-012 et Z12-014. 
2 Le cadre légal devrait être modifié dans le cadre du projet de loi de finances pour 2026 (article 28 du projet déposé le 14
octobre 2025). 

_Source: `c:\Users\g.baudrit\source\repos\gbaudrit\conf-aimer-votre-llm\demo\ctxc-sample-spec\with-ctxc\spec/dgfip/0- Dossier de specifications externes FE - Dossier général.pdf` (page:6/page:6)_

### E-2af786c802be

7 
2 Introduction

2.1 Rappel de l’existant en matière de dématérialisation des factures 

La loi de modernisation de l’économie (LME) du 4 août 2008 donnait déjà l’obligation à l’État d’accepter
les factures émises par ses fournisseurs sous forme dématérialisée à compter du 1er janvier 2012. Dès
cette date, l’État a mis en place la solution « Chorus Factures » destinée aux fournisseurs des entités
publiques (relations B2G3). Via cette plateforme, les fournisseurs des entités publiques pouvaient, s’ils le
souhaitaient, envoyer leurs factures au format électronique (PDF, saisie en ligne ou EDI).   

C’est avec l’ordonnance n° 2014-697 du 26 juin 2014 (abrogée), transposant la directive européenne
2014/55/UE, que cette obligation a été généralisée à toute la sphère publique à compter du 1er janvier
2017. Cette ordonnance définit également un calendrier de mise en œuvre progressive d’une obligation
d’émettre les factures à destination des entités publiques de manière électronique. La solution « Chorus
Factures » a donc été remplacée par « Chorus Pro » au 1er janvier 2017, dont l’obligation d’utilisation
s’est appliquée progressivement aux différents fournisseurs de la sphère publique, selon leur taille. Le
cadre juridique de la facturation électronique en B2G est désormais codifié au code de la commande
publique.

2.2 Rappel de l’existant en matière de dématérialisation des factures : le contexte et les
objectifs de la réforme de dématérialisation des factures  

Depuis une dizaine d’années, les États européens et la Commission européenne poursuivent un objectif
de déploiement de la dématérialisation des factures pour faciliter les relations interentreprises. La
France accompagne et devance ces initiatives en mettant en œuvre des réformes juridiques et en
proposant des dispositifs facilitant cette modernisation des échanges. 

Un nouveau dispositif de facturation électronique vise les factures des transactions entre assujettis à la
taxe sur la valeur ajoutée émises sous forme électronique et il est prévu que les données y figurant soient
transmises à l’administration pour leur exploitation à des fins, notamment, de modernisation de la
collecte et des modalités de contrôle de la taxe sur la valeur ajoutée. 

Cette réforme poursuit quatre objectifs :  
• simplifier la vie des entreprises et renforcer leur compétitivité grâce à l’allègement de la charge
administrative, à la diminution des délais de paiement et aux gains de productivité résultant de
la dématérialisation ;
• faciliter leurs obligations déclaratives en matière de TVA grâce à un pré-remplissage des
déclarations. Elle ouvrira la voie à une nouvelle offre de services de l’administration, en
particulier au profit des plus petites entreprises ; 
• lutter contre la fraude fiscale et diminuer l’écart de TVA au moyen de recoupements
automatisés ;
• améliorer la connaissance en temps réel de l’activité des entreprises afin de favoriser un pilotage
fin des actions du Gouvernement en matière de politique économique.

2.3 Le périmètre de la réforme 

La réforme s’inscrit dans le prolongement de l’obligation de facturation électronique pour l’ensemble
des relations commerciales avec la sphère publique (en B2G). 

3 Business to Government, le terme « B2G » est utilisé pour caractériser des opérations commerciales impliquant le secteur
privé et le secteur public. 

_Source: `c:\Users\g.baudrit\source\repos\gbaudrit\conf-aimer-votre-llm\demo\ctxc-sample-spec\with-ctxc\spec/dgfip/0- Dossier de specifications externes FE - Dossier général.pdf` (page:7/page:7)_

### E-ec84c0e9c049

8 
Le cadre juridique4 de la facturation électronique est défini par l’article 26 de la loi n°2022-1157 de
finances rectificatives pour 2022 adoptée le 16 août 2022, modifié par l’article 91 de la loi n° 2023-1322
du 29 décembre 2023. Les textes réglementaires publiés au Journal Officiel le 9 octobre 2022 viennent
compléter ce cadre juridique :
• le décret n° 2022-1299 du 7 octobre 2022 relatif à la généralisation de la facturation
électronique dans les transactions entre assujettis à la taxe sur la valeur ajoutée et à la
transmission des données de transaction, modifié par le décret n° 2024-266 du 25 mars 2024 ;
• l’arrêté du 7 octobre 2022 relatif à la généralisation de la facturation électronique dans les
transactions entre assujettis à la taxe sur la valeur ajoutée et à la transmission des données
de transaction. 

Le dispositif de facturation électronique reposait à la fois sur un portail public de facturation (PPF)
offrant un service minimum gratuit, et des opérateurs privés, les plateformes agréées.
Le 15 octobre 20245, l’État a fait le choix de privilégier la construction d’un annuaire des destinataires,
indispensable aux échanges entre les plateformes, et d’un concentrateur des données permettant leur
transmission à l’administration fiscale. L’administration accompagne cette transition dans une
démarche continue de concertation avec les grands acteurs du projet : les plateformes agréées, les
fédérations professionnelles, les solutions compatibles et les éditeurs de logiciels. Le gouvernement
réaffirme son engagement à accompagner et à déployer la facturation électronique dans les relations
entre entreprises. 

Dans ce contexte, le projet de loi de finances pour 2026 (PLF 2026) comporte un article 286 qui prévoit
notamment d’adapter le cadre légal du dispositif à cette réorientation du projet. Le cadre réglementaire
sera également modifié ultérieurement. 

2.3.1.  L’obligation de facturation électronique (e-invoicing) et de transmission des données de facture 

Les textes susmentionnés rendent obligatoire l’échange électronique de factures pour les transactions
domestiques entre assujettis à la TVA établis, domiciliés ou ayant leur résidence habituelle en France. 

Le code général des impôts (CGI) prévoit une obligation de facturation électronique7 (e-invoicing), à
savoir l’émission, la transmission et la réception des factures selon des normes définies par arrêté. Il
prévoit en outre la communication à l’administration fiscale de certaines données de factures8. 

2.3.2. L’obligation de transmission de données de transaction et de paiement (e-reporting) 

Pour répondre pleinement aux objectifs de la réforme, les articles 290 et 290 A prévoient des obligations
complémentaires de transmission de données. 

L’article 290 du CGI prévoit l’obligation de e-reporting, à savoir la transmission à l’administration de
données relatives aux opérations9 :
• interentreprises non domestiques, appelées B2B International (Business-to-Business
international) ; 

4 Ces textes devront faire l’objet de modifications pour prendre en compte la réorientation de la réforme annoncée dans le
communiqué de presse du 15 octobre 2024.
5 Cf. Chapitre 7 - Documentation applicable : Communiqué de presse du 15 octobre 2024.
6 Cf. Chapitre 7 - Documentation applicable : Article 28 du projet de loi de finances 2026.
7 Art. 289 bis. – I.
8 Art. 289 bis. – II du CGI (l’article 28 du projet de loi de finances pour 2026 prévoit que le transfert de ces dispositions dans
un nouvel article 290-0 du CGI) et art. 41 septies D de l’annexe IV au CGI.
9 L’article 290 décrit les opérations (livraisons de biens et prestations de services) devant faire l’objet d’un e-reporting et de
leur communication à l’administration fiscale sous forme électronique selon des normes de transmission définies par arrêté
du ministre chargé du budget. 

_Source: `c:\Users\g.baudrit\source\repos\gbaudrit\conf-aimer-votre-llm\demo\ctxc-sample-spec\with-ctxc\spec/dgfip/0- Dossier de specifications externes FE - Dossier général.pdf` (page:8/page:8)_

### E-83af806c8174

9 
• entre les entreprises et un non-assujetti en France appelées B2C10 (Business-to-Consumer). 

L’article 290 A du CGI prévoit l’obligation en complément de l’obligation de facturation électronique,
transmission des données de facture et de transaction, de transmettre certaines données de paiement
à l’administration. Cette obligation ne vise que les prestations de service, dès lors que l’entreprise n’a
pas opté pour le paiement de la TVA sur les débits ou doit autoliquider la TVA. 

L’article 28 du PLF 2026 prévoit d’étendre le champ du e-reporting des données de paiement à toutes
les opérations pour lesquelles la TVA est exigible à l’encaissement (factures d’acompte et opérations
agricoles).   

2.3.3. Simplifications et tolérances 

La Direction Générale des Finances Publiques (DGFiP) et l'Agence pour l'informatique financière de l'Etat
(AIFE) ont mené, depuis janvier 2025, des travaux soutenus de concertation lors d'une soixantaine de
réunions organisées avec plus de 250 participants, notamment sous l'égide de l’Association Française de
normalisation (AFNOR). 
Cette concertation a permis diverses évolutions du dispositif de la facturation électronique, telles que
la mise en œuvre d'un accord formel de désignation des plateformes de réception, le renforcement de
l'audit des plateformes et des contraintes de sécurisation des données, ainsi que l'encadrement de la
portabilité. Ces éléments, qui permettent à l'Etat de jouer pleinement son rôle de garant et de
régulateur, sont présentés dans le projet de loi de finances pour 2026.
Cette phase d’écoute et d’analyse a également permis de définir des mesures concrètes de
simplification et de tolérance, validées par un courrier en date du 29 août 2025 de la ministre chargée
des comptes publics et de la ministre déléguée chargé du commerce, de l’artisanat, des petites et
moyennes entreprises et de l’économie sociale et solidaire aux principales organisations professionnelles
représentatives visant à alléger les contraintes, à clarifier les obligations et à faciliter l’adoption du
dispositif. Les simplifications et tolérances seront progressivement explicitées et intégrées dans le cadre
réglementaire de la réforme, soit au niveau législatif, soit au niveau réglementaire, soit au niveau
doctrinal pour une mise en application au 1er septembre 2026. 
Aussi, dans l’attente de l’adoption de ces dispositions, elles sont d’ores et déjà présentées dans ce
document afin de permettre aux entreprises et aux éditeurs de réaliser les développements en
conséquence. 

Simplifications : 

Suppression de l'obligation de fournir le détail ligne par ligne dans l’e-reporting relatif aux données de
factures d’opérations internationales entrantes 

Cette simplification permet d'adapter le dispositif français à la réalité des pratiques commerciales
internationales et des flux internationaux, au sein desquels les factures échangées sont souvent peu ou
pas structurées. Cette mesure permet de limiter les obligations déclaratives, en l'absence de formats
normalisés, et les coûts pesant sur les entreprises.
L’ensemble des balises concernées dans le flux 10.1 pour les données de factures d’opérations
internationales entrantes seront facultatives. 

Suppression de l'obligation de transmettre le nombre de transactions dans le e-reporting de données
des opérations avec des non-assujettis (B2C11). 

10 Business to Consumer, le terme « B2C » est utilisé pour caractériser des opérations commerciales impliquant des
entreprises et des clients individuels particuliers.
11 Business to Consumer, le terme « B2C » est utilisé pour caractériser des opérations commerciales impliquant des
entreprises et des clients individuels particuliers. 

_Source: `c:\Users\g.baudrit\source\repos\gbaudrit\conf-aimer-votre-llm\demo\ctxc-sample-spec\with-ctxc\spec/dgfip/0- Dossier de specifications externes FE - Dossier général.pdf` (page:9/page:9)_

### E-958199ea9624

10 
Cette simplification allège significativement les flux déclaratifs pour les entreprises, en supprimant une
donnée difficile à consolider dans certaines configurations comptables.
La balise concernée (nombre de transactions) dans le flux 10.3 relatif de données des opérations avec
des non-assujettis sera facultative. 

Absence d'obligation d'effectuer un « e-reporting à blanc » 

Cette simplification clarifie le périmètre de l'obligation de l’e-reporting. Elle évite aux entreprises de
devoir transmettre à l'administration un e-reporting à vide, c'est-à-dire sans donnée, lorsqu'elles n'ont
pas réalisé d'opération taxable à la taxe sur la valeur ajoutée (TVA). Elle réduit la charge administrative
pesant sur les entreprises. 

Abandon de l'ajout de données nouvelles à transmettre à l'administration pendant la phase de
déploiement de la réforme 

Cette simplification allège les obligations pesant sur les entreprises et les plateformes agréées s'agissant
de certains blocs de données devant initialement être transmis à l'administration. Cette mesure préserve
les calendriers de développement des solutions informatiques pour les entreprises et les plateformes. 

Exclusion de l’e-reporting aux opérations hors union européenne réalisées entre assujettis en France 

Certaines opérations entre assujettis français hors UE peuvent relever d’une TVA étrangère, facturée par
l’assujetti français. La transmission des données de TVA étrangère peut être difficile à effectuer dans
certaines configurations et nécessiter des développements spécifiques : code et mention de la TVA
applicable selon des attendus franco-français alors que l’opération peut être soumise à une TVA
étrangère. 

Cette simplification s’applique également pour les autres opérations relevant d’une TVA étrangère,
facturée par l’assujetti français. Par exemple, les entreprises installées en France qui réalisent des
opérations dans des pays étrangers se trouvent parfois amenées à facturer une TVA autre que la TVA
française, au motif que les législations étrangères les en rendent redevables au titre de ces opérations.
Dans de tels cas, afin d'éviter tout risque de confusion entre l'application des dispositions françaises et
celles d'une législation étrangère, les entreprises concernées doivent préciser très clairement sur leurs
factures que la TVA facturée est la TVA de tel ou tel pays étranger. (BOI-TVA-DECLA-30-20-20-10 §360). 

Cette simplification allège ainsi significativement les flux déclaratifs. Elle est prise en compte à deux
niveaux : 

• dans le projet de loi de finances pour 2026 en stipulant que l’article 289 bis ne s’appliquera pas
aux opérations mentionnées au 2° du II de l’article 289-0 ou au 1° du I de l’article 262 ter ;
• pour l’e-reporting et le flux 1012 : dans la situation où une TVA autre que française est facturée et
que l’article 290, dans sa nouvelle écriture, continue d’imposer la réalisation d’un e-reporting sur
cette opération : l’exclusion visée dans la simplification consiste à ne demander qu’un e-reporting
du montant HT. Pour remplir la ligne de TVA dans l’e-reporting en flux 10, il sera demandé
d’utiliser un code S et un taux à 0 pour signifier l’absence de TVA française. 

Cette exclusion ne vise donc pas les opérations intracommunautaires classiques ou les exportations qui
relèvent d’exonération, mais uniquement le cas particulier des opérations relevant d’une TVA étrangère. 

12 F10 : Flux de transmission de données de transaction et de paiement relevant d’opérations interentreprises internationales
(B2Bi, Bi2B, Bi2G et Bi2Bi) ou auprès de non-assujettis (B2C, G2C). 

_Source: `c:\Users\g.baudrit\source\repos\gbaudrit\conf-aimer-votre-llm\demo\ctxc-sample-spec\with-ctxc\spec/dgfip/0- Dossier de specifications externes FE - Dossier général.pdf` (page:10/page:10)_

### E-e9a0a623965a

11 
Tolérances : 

Méthode de calcul simplifiée autorisée pour l’e-reporting de la TVA sur la marge en B2C 

Pour les opérations réalisées entre un assujetti et un particulier relevant du régime de la TVA sur la marge,
une méthode simplifiée de calcul est admise dans le cadre du e-reporting : elle consiste à autoriser les
entreprises qui ne peuvent pas calculer leur marge en temps réel à indiquer une marge basée sur un taux
de marge moyen propre à leur entreprise. Ce dispositif permet de réduire la complexité des calculs à la
charge des entreprises, tout en leur laissant la possibilité de régulariser ultérieurement via leur
déclaration de TVA.
Cette méthode simplifiée de calcul est décrite dans la norme de facturation électronique AFNOR. 

Exclusion des entités sans numéro SIREN du régime de sanction 

Les entités ne disposant pas de numéro SIREN, et donc ne pouvant pas être intégrées dans l’annuaire
des destinataires de factures, ne pourront pas faire l’objet de sanction.
Les fournisseurs de ces entités ne seront pas non plus sanctionnés s’ils n’émettent pas de facture
électronique à destination des entités sans numéro SIREN. Ils devront procéder à un e-reporting comme
s’ils facturaient un non-assujetti. 

Tolérance pour les entités possédant un numéro SIREN non encore intégrées dans l’annuaire 

Une tolérance sera mise en œuvre dans l’application du dispositif de sanction lorsqu’une entité
possédant un numéro SIREN n’est pas encore intégrée dans l’annuaire des destinataires en raison de
circuits de validation propres à l’administration ou de difficultés techniques imputables à
l’administration.
Les fournisseurs de ces entités ne seront pas non plus sanctionnés s’ils n’émettent pas de facture
électronique à destination des entités non encore intégrées dans l’annuaire. Ils devront procéder à un
e-reporting comme s’ils facturaient un non-assujetti. 

Report au 01/09/2027 pour les assujettis non établis pour l’e-reporting d’acquisition : opération en
France et opération intracommunautaire. 

Pour les opérations soumises à e-reporting d’acquisition pour les assujettis non établis, l’obligation
d’effectuer cet e reporting ne s’appliquera qu’à compter du 01/09/2027.
Pour les autres opérations (flux sortant), le calendrier est maintenu. 

2.3.4.  La typologie des acteurs 

Les principaux types d’acteurs qui participent à la réforme :
• les entreprises : les fournisseurs, acheteurs ou leurs mandataires de facturation équipés ou non
d’une solution de dématérialisation en interne ou en externe (prestataire) ; 
• les plateformes agréées (PA) : les prestataires offrant des services de dématérialisation des
factures immatriculés par l’administration (ex plateformes de dématérialisation partenaires).
Seules les plateformes agréées peuvent transmettre directement les factures électroniques à
leurs destinataires et transmettre des données au portail public de facturation ;
• les solutions compatibles (SC) : les opérateurs offrant des services de dématérialisation (ex
opérateurs de dématérialisation) des factures mais qui ne sont pas immatriculés par
l’administration. Ces opérateurs ne peuvent pas transmettre directement les factures
électroniques à leurs destinataires ni transmettre de données au portail public de facturation, 

_Source: `c:\Users\g.baudrit\source\repos\gbaudrit\conf-aimer-votre-llm\demo\ctxc-sample-spec\with-ctxc\spec/dgfip/0- Dossier de specifications externes FE - Dossier général.pdf` (page:11/page:11)_

### E-2b64ec8f4f24

12 
mais peuvent agir au nom et pour le compte de l’entreprise auprès des plateformes de leur choix
(y compris Chorus Pro) ;
• le portail public de facturation (PPF) : l’opérateur public qui administre l’annuaire central13,
concentre les données de facturation, de transaction et de paiement ainsi que des informations
relatives aux statuts de traitement des factures (cycle de vie)14 et les transmet ces données à
l’administration fiscale ;
• Chorus Pro : la plateforme unique de réception des factures destinées à l’État, aux collectivités
locales et aux établissements publics (Chorus Pro - obligation codifiée au code de la commande
publique), également plateforme unique d’émission des factures de l’ensemble des entités
publiques ;
• l’administration fiscale : l’administration qui reçoit les données de facturation, de transaction et
paiement, puis les exploite à des fins, notamment, de modernisation de la collecte et des
modalités de contrôle de la taxe sur la valeur ajoutée. 

2.3.5. La mise en conformité progressive des assujettis à la TVA 

Conformément à l’article 91 de la loi de finances pour 2024 n° 2023-1322 du 29 décembre 2023, toutes
les entreprises, quelle que soit leur taille et quelle que soit leur forme juridique, devront être en capacité,
au 1er septembre 2026, de recevoir des factures sous format électronique dès lors que certaines
entreprises15 seront tenues d’émettre leurs factures au format électronique à compter de cette date.   

Afin de tenir compte des caractéristiques des entreprises et de leur capacité à adapter leurs processus
de facturation, les obligations d’émission de factures électroniques (e-invoicing) et de transmission des
données de transaction et paiement (e-reporting)16 s’appliqueront de manière progressive, en deux
vagues : 
• à compter du 1er septembre 2026 pour tous les assujettis, hors microentreprises, très petites,
petites et moyennes entreprises qui ne sont pas membres d’un assujetti unique au sens de
l’article 256 C du CGI ; 
• à compter du 1er septembre 2027 pour tous les assujettis. 

La taille d’une entreprise est appréciée selon les critères suivants17 : 
• une microentreprise est une entreprise dont l'effectif est inférieur à 10 personnes et dont le
chiffre d'affaires ou le total du bilan annuel n'excède pas 2 millions d'euros ;  
• une PME est une entreprise dont l’effectif est inférieur à 250 personnes et dont le chiffre
d’affaires annuel n’excède pas 50 millions d'euros ou dont le total de bilan n'excède pas 43
millions d'euros ;
• une ETI, entreprise de taille intermédiaire, est une entreprise qui n'appartient pas à la catégorie
des PME, dont l’effectif est inférieur à 5000 personnes et dont le chiffre d'affaires annuel
n'excède pas 1 500 millions d’euros ou dont le total de bilan n'excède pas 2 000 millions d'euros ;
• une grande entreprise est une entreprise dont l’effectif est supérieur à 5000 personnes ou, si son
effectif est inférieur à 5000 personnes, dont le chiffre d’affaires annuel est supérieur à 1 500
millions d’euros et le total de bilan est supérieur à 2 000 millions d’euros.   

13  III de l’article 289 bis du CGI.
14 Arrêté du ministre chargé du budget du 7octobre 2022.
15 Grandes entreprises, entreprises de taille intermédiaire et entités membres d’un assujetti unique. 
16 Le calendrier prévu par l’article 26 de la loi n°2022-1157 du 16 août 2022 de finances rectificative pour 2022 tel que
modifié par l’article 91 de la loi n°2023-1322 du 29 décembre 2023 de finances pour 2024.
17  Article 51 de la loi n°2008-776 du 4 août 2008 de modernisation de l’économie. 

_Source: `c:\Users\g.baudrit\source\repos\gbaudrit\conf-aimer-votre-llm\demo\ctxc-sample-spec\with-ctxc\spec/dgfip/0- Dossier de specifications externes FE - Dossier général.pdf` (page:12/page:12)_

### E-2cb95fd3894f

13 
La taille de l’entreprise est déterminée au niveau de chaque entité légale au 1er janvier 2025 à partir des
éléments issus de la déclaration de résultats du dernier exercice clos avant cette date. A défaut, elle
s’apprécie au niveau des éléments de la déclaration du premier exercice clos à compter de cette date. 

2.3.6. Le circuit de transmission des factures entre assujettis (B2B18) 

Dans le dispositif, « l’émission, la transmission et la réception des factures électroniques s’effectuent, (…)
en recourant à une plateforme agréée. (…) Les données des factures électroniques émises (…) sont
transmises à l’administration par la plateforme agréée choisie par l’assujetti. » 19 

Le schéma découlant de ces dispositions, et représentant la relation entre les différents acteurs de
l’écosystème, correspond au schéma dit « en Y » : 

Figure 1 - Le circuit B2B

Cette architecture est conçue pour s’insérer de manière fluide dans les pratiques existantes. La mise en
place du modèle en Y est privilégiée dans la mesure où elle répond aux attentes des entreprises et des
opérateurs qui, dans leur grande majorité, ont marqué leur préférence pour ce schéma. En effet, toutes
les entreprises recourant d’ores et déjà à des opérateurs privés y voient le moyen de limiter les coûts
d’adaptation et les coûts d’entrée dans cette réforme. 

Le dispositif retenu repose sur la conciliation entre : 
• la liberté laissée à chaque entreprise d’utiliser la plateforme agréée de son choix pour l’émission
ou la réception des factures ; 
• l’obligation de déclarer les données de facturation, de transactions et de paiement à
l’administration fiscale. 

2.3.7. Le circuit de transmission des factures B2G 

Dans le dispositif, la solution Chorus Pro reste la plateforme de réception unique des acheteurs publics
(circuit B2G). 

18 « Business to business » désigne les relations commerciales interentreprises (notamment dans le cadre d’une relation
entre une entreprise et son fournisseur).
19 Ces dispositions sont prévues à l’article 289 bis du CGI. L’article 28 du PLF 2026 modifie cet article et prévoit notamment
le transfert des dispositions du II dans un nouvel article 290-0 du CGI.  

_Source: `c:\Users\g.baudrit\source\repos\gbaudrit\conf-aimer-votre-llm\demo\ctxc-sample-spec\with-ctxc\spec/dgfip/0- Dossier de specifications externes FE - Dossier général.pdf` (page:13/page:13)_

### E-0a3c4c1ea466

14 
Figure 2 - Le circuit B2G, avec Chorus Pro comme plateforme de réception 

Les fournisseurs déjà raccordés à la solution Chorus Pro, directement ou indirectement, pourront
conserver leurs raccordements et leurs usages, pour transmettre les factures B2G. Chorus Pro assumera
alors dans ce cadre les obligations portant sur la plateforme d’émission (transmission des données
réglementaires au PPF) . 

Figure 3 - Le circuit B2G, avec raccordement direct du fournisseur à Chorus Pro   

_Source: `c:\Users\g.baudrit\source\repos\gbaudrit\conf-aimer-votre-llm\demo\ctxc-sample-spec\with-ctxc\spec/dgfip/0- Dossier de specifications externes FE - Dossier général.pdf` (page:14/page:14)_

### E-f214a17c7cd0

15 
2.3.8. Le rôle des plateformes agréées (PA) 

Le schéma en « Y » s’applique aussi bien pour la facturation électronique que pour la transmission des
données de facturation et de transactions : 
• dans le cadre de la facturation électronique, les plateformes agréées (PA) doivent assurer le
dépôt, la transmission et le suivi des factures B2B domestique et B2G. Les factures émises par
une entreprise (ou l’entité mandatée par cette dernière) devront être transmises à la plateforme
de son choix, et celle-ci aura à charge de transmettre la facture à son destinataire ;
• les plateformes agréées (PA) auront la responsabilité d’extraire les données des factures à
transmettre sous format structuré au portail public de facturation (PPF) ; 
• dans le cadre du e-reporting, les plateformes agréées (PA) assurent la transmission des données
de transactions (relatives aux opérations B2B international et B2C) et de paiement au portail
public de facturation (PPF). 

Une plateforme agréée (PA) est un prestataire de services qui aura les obligations suivantes20 :
• en tant que plateforme d’émission agissant pour le compte du fournisseur, elle sera chargée
d’émettre la facture sous format dématérialisé vers la plateforme du destinataire de la facture
référencée dans l’annuaire et de permettre son suivi (cycle de vie de la facture) ; 
• en tant que plateforme de réception (agissant pour le compte du destinataire de la facture), elle
aura la responsabilité de mettre à jour les informations relatives à son utilisateur client contenues
dans l’annuaire central. Elle réceptionnera la facture électronique pour le compte de son
utilisateur. Selon le contrat avec son utilisateur, elle lui transmettra ou non la facture. Elle aura
l’obligation, si son client lui demande, de transformer le format de la facture établie par le
fournisseur dans un autre des formats du socle (ou un autre format selon son offre de services)21. 

Une plateforme agréée (PA) aura la responsabilité d’extraire et transmettre les données réglementaires
des factures et de leur cycle de vie (e-invoicing), ainsi que les données de transactions et de paiement (e-
reporting) au portail public de facturation (PPF). Ce dernier, en tant que concentrateur, les transmettra
à l’administration fiscale. 

Ces obligations doivent être opérées de manière à garantir :
• le correct routage et adressage des factures ; 
• la qualité, l’intégrité, l’authenticité, l’exhaustivité des données, ainsi que leur conformité aux
règles fiscales ; 
• le respect des méthodes de sécurisation ;
• la transparence de l’information auprès des utilisateurs sur les traitements et services réalisés. 

2.3.9. L’immatriculation des plateformes agréées (PA) 

L’article 290 B du CGI prévoit une procédure d’immatriculation22 des plateformes agréées23. 

La délivrance du numéro d’immatriculation est effectuée pour une durée de trois ans. Afin d’obtenir un
numéro d’immatriculation, une plateforme candidate doit fournir des renseignements et une
documentation, de nature à démontrer sa capacité à remplir les fonctionnalités qui lui incombent, dans
le respect d’un niveau d’exigence élevé en termes de sécurité. Elle doit notamment s’engager à remettre
un audit de conformité à l’administration avant la fin de la première année qui suit la prise d’effet du
numéro d’immatriculation, soit après la délivrance de l’immatriculation définitive. 

20 Articles 289 bis, 290 et 290 A du CGI. L’article 28 du PLF 2026 prévoit le transfert de l’obligation de transmission des
données des factures électroniques de l’article 289 bis vers un nouvel article 290-0 du CGI.
21 Cette transformation doit garantir l’intégrité des données entre le format d’origine et le format converti.
22 Article 290 B. du CGI.
23 Article 242 nonies B de l’annexe II au CGI. 

_Source: `c:\Users\g.baudrit\source\repos\gbaudrit\conf-aimer-votre-llm\demo\ctxc-sample-spec\with-ctxc\spec/dgfip/0- Dossier de specifications externes FE - Dossier général.pdf` (page:15/page:15)_

### E-0f913ad54ff4

16 
Le renouvellement est soumis aux mêmes conditions24 que pour l’obtention du numéro
d’immatriculation. 

2.3.10. L’interopérabilité des acteurs de la réforme 

Le principe d’interopérabilité désigne la capacité d’un réseau, ici l’écosystème de la facturation
électronique (portail public de facturation, plateforme agréée), à permettre à tous les systèmes
impliqués de communiquer entre eux.   

L’interopérabilité des acteurs du circuit de facturation électronique repose ainsi sur l’engagement des
plateformes agréées à respecter les éléments suivants : 
• la mise en place d’un annuaire central géré par le portail public de facturation (PPF), mis à la
disposition des plateformes, contenant les informations nécessaires au routage et à l’adressage
des factures à destination des entreprises et organisations ;
• le raccordement de chaque plateforme agréée (PA) immatriculée au portail public de facturation
(PPF) et à au moins une autre plateforme agréée (PA) immatriculée25. Ces raccordements doivent
être réalisés de manière à respecter l’ensemble des règles posées et garantir ainsi le respect du
dispositif ;
• le respect du socle minimum de formats reposant sur des standards sémantiques et syntaxiques
respectant la norme européenne EN16931 pour faciliter les échanges : UBL, CII et Factur-X ;
• la diversité des canaux d’échanges (EDI, API et portail), et les protocoles d’échanges (SFTP26,
AS/227, AS/428) ;
• l’intégration du réseau Peppol comme infrastructure d’interopérabilité complémentaire,
permettant des échanges sécurisés et standardisés entre les plateformes agréées (PA), en
conformité avec les spécifications européennes et françaises. 

3 Présentation du portail public de facturation (PPF)

3.1 Les principes directeurs du portail public de facturation (PPF) 

Le portail public de facturation (PPF) est l’opérateur public qui :
• administre l’annuaire central29 ;
• concentre les données de facturation, de transaction et de paiement ainsi que des informations
relatives aux statuts de traitement des factures (cycle de vie)30 et transmet ces données à
l’administration fiscale.

3.2 La cartographie des flux échangés 

Il existe quatre types de flux échangés entre les acteurs de l’écosystème : 

24 Les conditions d’immatriculations sont décrites à l’article 242 nonies B de l’annexe II au CGI modifié par le décret n° 2024-
266 du 25 mars 2024. 
25 Le raccordement peut se faire via une convention bilatérale entre plateformes ou dans le cadre d’une adhésion à un
protocole d’échange d’informations en réseau (exemple, le réseau Peppol).
26 Secure File Transfert Protocol.
27 Protocole Applicable Statement 2 (AS/2).
28 Protocole Applicable Statement 4 (AS/4).
29 Article 289 bis III. du CGI.
30 Arrêté du ministre chargé du budget du 7 octobre 2022. 

_Source: `c:\Users\g.baudrit\source\repos\gbaudrit\conf-aimer-votre-llm\demo\ctxc-sample-spec\with-ctxc\spec/dgfip/0- Dossier de specifications externes FE - Dossier général.pdf` (page:16/page:16)_

### E-041b7e594a64

17 
• les flux e-invoicing ; 
• les flux de cycle de vie ;
• es flux e-reporting ; 
• les flux annuaire. 

Figure 4 - Cartographie des flux échangés entre les acteurs de l'écosystème   

_Source: `c:\Users\g.baudrit\source\repos\gbaudrit\conf-aimer-votre-llm\demo\ctxc-sample-spec\with-ctxc\spec/dgfip/0- Dossier de specifications externes FE - Dossier général.pdf` (page:17/page:17)_

### E-098550d37830

18 
N° de flux Acteurs  Description 

PAE

PPF
Administration
fiscale
F1 : Flux de données réglementaires de facture31, au format
syntaxique UBL ou CII. 

Toute plateforme d’émission (PA ou Chorus Pro) a l’obligation
d’assurer l’extraction de ces données réglementaires à partir
des flux de factures (F2 et/ou F3, cf. infra) qu’elle émet pour le
compte de ses clients, et de transmettre le flux correspondant
au portail public de facturation (PPF). Le PPF contrôle puis
transmet ce flux à l’administration fiscale. 

Fournisseur
PAE

PAR

Acheteur
F2 : Flux de factures électroniques relevant des transactions
domestiques entre entreprises ou avec la sphère publique (B2B
ou B2G ou G2B), dans l’un des 3 formats syntaxiques du socle
(UBL, CII, Factur-X), en fonction de l’offre de services des
plateformes (PAE, PAR ou Chorus Pro).   

Ces factures doivent contenir a minima l’ensemble des données
réglementaires car elles sont exploitées par la PAE pour générer
le flux de données réglementaires (F1) avant sa transmission au
PPF. Ce flux de factures (F2) n’est pas transmis au PPF. 

Le flux de factures (F2) est transmis par le fournisseur à la PAE.
Sur la base des informations d’adressage et de routage
contenues dans l’annuaire, la PAE transmet la facture à la PAR de
l’acheteur. Selon les souhaits de l’acheteur, la PAR peut convertir
la facture au format syntaxique UBL, CII, Factur-X ou autre
format (F3, cf. infra) en fonction de son offre de services, avant
de lui mettre à disposition. 

Fournisseur
PAE

PAR

Acheteur
F3 : Flux de factures électroniques relevant des transactions
domestiques entre entreprises ou avec la sphère publique (B2B
ou B2G ou G2B), dans un format syntaxique autre que l’un des
3 formats du socle (UBL, CII, Factur-X), en fonction de l’offre de
services des plateformes (PAE, PAR ou Chorus Pro). 

Ces factures doivent contenir a minima l’ensemble des données
réglementaires pour permettre leur exploitation par la PAE pour
générer le flux de données réglementaires (F1) avant sa
transmission au PPF. Ce flux de factures (F3) n’est pas transmis
au PPF. 

Le flux de factures est transmis par le fournisseur à la PAE. Sur la
base des informations d’adressage et de routage contenues
dans l’annuaire, la PAE transmet la facture à la PAR de l’acheteur,
si cette dernière est en mesure de l’accepter. Selon les souhaits
de l’acheteur, la PAR peut convertir la facture au format
syntaxique UBL, CII, Factur-X ou autre format (F3) en fonction
de son offre de services, avant de lui mettre à disposition. 

31 Les mentions obligatoires d’une facture sont définies à l’article 242 nonies A de l’annexe II au CGI, et les données
réglementaires sont définies à l’article 41 septies D de l’annexe IV au CGI.  

_Source: `c:\Users\g.baudrit\source\repos\gbaudrit\conf-aimer-votre-llm\demo\ctxc-sample-spec\with-ctxc\spec/dgfip/0- Dossier de specifications externes FE - Dossier général.pdf` (page:18/page:18)_

### E-967e654a3496

19 
Fournisseur 
PAE

PAR

Acheteur
PPF
Administration
fiscale
F6 : Flux de cycle de vie, au format syntaxique CDAR32.
Le cycle de vie véhicule les statuts des objets métiers,
nécessaires à tous les acteurs de la chaîne de facturation pour
connaître l’évolution des traitements.   

En fonction des cas, ce flux peut être :
- transmis par le fournisseur à la PAE ; 
- transmis par l’acheteur à la PAR ;
- généré par les plateformes (PAE ou PAR). 

Toute plateforme (PAE ou PAR) a l’obligation de transmettre au
PPF les statuts obligatoires véhiculés par ce flux de cycle de vie.
Le PPF contrôle puis transmet ce flux à l’administration fiscale. 

Le PPF émet également des cycles de vie pour tous les objets
métiers qu’il reçoit des plateformes : flux, données
réglementaires de factures (F1), données de cycle de vie (F6)
et/ou annuaire (F13). 

Fournisseur 
PAE

PAR

Acheteur
F7 : Flux de cycle de vie, dans un autre format syntaxique que le
CDAR, en fonction de l’offre de services des plateformes (PAE

et PAR). Le cycle de vie véhicule les statuts des objets métiers,
nécessaires à tous les acteurs de la chaîne de facturation pour
connaître l’évolution des traitements. 

Ces flux de cycles de vie doivent véhiculer a minima l’ensemble
des données relatives aux statuts obligatoires de factures pour
permettre leur exploitation par les plateformes (PAE et PAR)
pour générer le flux de cycle de vie (F6) avant sa transmission au
PPF. Ce flux de cycle de vie (F7) n’est pas transmis au PPF. 

En fonction des cas, ce flux peut être :
- transmis par le fournisseur à la PAE ;
- transmis par l’acheteur à la PAR ;
- généré par les plateformes (PAE ou PAR). 

Fournisseur 
PAE

PAR

Acheteur 
F8 : Flux de factures électroniques relevant des opérations
interentreprises internationales (B2Bi, Bi2B et Bi2Bi), au format
syntaxique UBL, CII, Factur-X ou autre format en fonction de
l’offre de services de la PAE du fournisseur et/ou de la PAR de
l’acheteur. 

En fonction de leur offre de services, les PAE et PAR peuvent
accepter et s’échanger ce type de facture, et les traiter de
manière analogue (réception, contrôle, traitement,
transmission) aux factures électroniques des opérations 

32 Le format CDAR supporté par le portail public de facturation (PPF) est UN/CEFACT SCRDM CI Cross Domain Application
Response message. 

_Source: `c:\Users\g.baudrit\source\repos\gbaudrit\conf-aimer-votre-llm\demo\ctxc-sample-spec\with-ctxc\spec/dgfip/0- Dossier de specifications externes FE - Dossier général.pdf` (page:19/page:19)_

### E-5ed69af2a8cc

20 
interentreprises domestiques (B2B)33 selon les règles posées par
la norme AFNOR pour ces factures. 

Ce flux est transmis par le fournisseur à sa PAE, ou par l’acheteur
à sa PAR, qui le convertit en flux de données de transmission
(flux 10), pour traitement des données et transmission au PPF34. 

Fournisseur 
PAE 
F9 : Flux de factures électroniques relevant des opérations
auprès de non-assujettis (B2C), au format syntaxique UBL, CII,
Factur-X ou autre format en fonction de l’offre de services de la
PAE du fournisseur. 

En fonction de leur offre de services, les PAE peuvent accepter
ce type de facture, et les traiter de manière analogue
(réception, contrôle, traitement, transmission) aux factures
électroniques des opérations interentreprises domestiques
(B2B)35 selon les règles posées par la norme AFNOR pour ces
factures. 

Il est transmis par le fournisseur à sa PAE, qui le convertit en flux
de données de transmission (flux 10), pour traitements des
données et transmission au PPF36. 

Fournisseur 
PAE

PAR

Acheteur 
F10 : Flux de transmission de données de transaction et de
paiement relevant d’opérations interentreprises internationales
(B2Bi, Bi2B, Bi2G et Bi2Bi) ou auprès de non-assujettis (B2C,
G2C). 

En fonction des cas, ce flux peut être :
- transmis par le déclarant assujetti (le fournisseur ou l’acheteur
en fonction des cas) à sa plateforme de déclaration ;
- généré par la plateforme du déclarant assujetti à partir de flux
de factures électroniques (flux 8 et 9). 

A l’issue de la période de déclaration (définie par le régime fiscal
du déclarant assujetti), la plateforme de déclaration agrège
l’ensemble des flux 10, transmis ou générés au titre de la
période. 

Le flux de transmission de données de transaction et de
paiement doit être transmis par la plateforme (PAE et PAR) de
manière agrégée au PPF. Le PPF contrôle puis transmet ce flux à
l’administration fiscale. 

33 Ces factures ne doivent pas faire l’objet de production d’un flux 1 ni de transmission des cycles de vie (flux 6) au
PPF.

34 Modalités de traitement et de transmission des données de transaction et de paiement décrits dans les articles 41
septies L à P de l’annexe IV au CGI.
35 Ces factures ne doivent pas faire l’objet de production d’un flux 1 ni de transmission des cycles de vie (flux 6) au
PPF.

36 Modalités de traitement et de transmission des données de transaction et de paiement décrits dans les articles 41 septies
L à P de l’annexe IV au CGI. 

_Source: `c:\Users\g.baudrit\source\repos\gbaudrit\conf-aimer-votre-llm\demo\ctxc-sample-spec\with-ctxc\spec/dgfip/0- Dossier de specifications externes FE - Dossier général.pdf` (page:20/page:20)_

### E-79703533d233

21 
Fournisseur 
PAE

PAR

Acheteur 
F11 : Flux de consultation de l’annuaire transmis, en fonction de
son offre de services, par une plateforme (PAE ou PAR) à ses
utilisateurs (fournisseur ou acheteur). En fonction des cas, ce
flux permet à :
• un fournisseur d’obtenir les informations d’adressage
nécessaires à l’émission d’une facture vers un acheteur ;
• un acheteur de vérifier que ses informations d’adressage
sont correctes et à jour. 

Acheteur
PAR 
F12 : Flux d’actualisation de l’annuaire transmis par un acheteur
vers sa PAR, en fonction de son offre de services. Ce flux permet
à un acheteur de corriger ou mettre à jour ses informations
d’adressage de factures. 

PAR

PPF
F13 : Flux d’actualisation de l’annuaire transmis par une PAR au
PPF. Ce flux permet à une plateforme de corriger ou mettre à
jour, pour le compte de ses utilisateurs, leurs informations
d’adressage de factures. 

PAE

PAR

PPF
F14 : Flux de consultation de l’annuaire transmis par le PPF aux
plateformes (PAE ou PAR). En fonction des abonnements choisis
par les plateformes, elles peuvent recevoir à une fréquence
régulière, un export complet de l’annuaire (flux « full ») ou
seulement les mises à jour de l’annuaire réalisées au cours d’une
période définie (flux « différentiel »). 

Les flux échangés directement avec le portail public de facturation (PPF), et les données qu’ils
contiennent, sont décrits dans les annexes 1 à 6 de ce présent document.

3.3 Le raccordement au portail public de facturation (PPF) 

3.3.1.  Les principes directeurs 

Un raccordement matérialise l’interconnexion entre un partenaire37 et le portail public de facturation
(PPF) pour les échanges depuis l’une de ses applications :

• un raccordement EDI est associé aux éléments suivants : le code application du partenaire, le
protocole technique d’échange, le certificat du partenaire, ses abonnements ;

• un raccordement API est associé aux éléments suivants : une application déclarée dans le compte
du partenaire ouvert dans l’application PISTE38, un code application du partenaire et un compte
technique. 

Le portail public de facturation (PPF) assure la gestion des raccordements en EDI et en API des
partenaires : 

• la création des raccordements, la mise à jour et la désactivation des raccordements ;

• la consultation des informations relatives à un raccordement.

Ces fonctionnalités seront accessibles aux partenaires habilités39 depuis le portail de services Chorus
Pro. 

37 On désigne « partenaire » tout système d’information (SI) raccordé au PPF.
38 PISTE : plateforme d’intermédiation des services pour la transformation de l’Etat.
39 Les partenaires habilités ont un compte sur le portail de service (en qualification et en production), sont rattachés à une
structure de type « PA » et ont le profil dédié « Raccordements modification ». 

_Source: `c:\Users\g.baudrit\source\repos\gbaudrit\conf-aimer-votre-llm\demo\ctxc-sample-spec\with-ctxc\spec/dgfip/0- Dossier de specifications externes FE - Dossier général.pdf` (page:21/page:21)_

### E-6683cb0f44b6

22 
3.3.2. Le raccordement en EDI

Les raccordements EDI avec le portail public de facturation (PPF) ont vocation à permettre l’échange de
flux volumineux afin d’en assurer un traitement en masse. Le portail public de facturation met à
disposition des partenaires raccordés en EDI, les protocoles d’échanges SFTP, AS/2 et AS/4 (cf. infra).

Un partenaire40  ne peut utiliser qu’un seul de ces protocoles par raccordement. 

3.3.2.1. Le protocole SFTP 

Le Secure File Transfert Protocol (ou SSH File Transfert Protocol) est un protocole permettant le
transfert de fichiers entre un serveur (le PPF) et un partenaire (aussi appelé « client »), en assurant le
cryptage de l’intégralité de la connexion, y compris des mots de passe et du contenu des transferts. Il
constitue une variante du protocole FTP qui sécurise la session au travers d’une connexion Secure Shell
(SSH). 

Pour requérir une connexion au système d’échange du portail public de facturation (PPF) à travers le
protocole SFTP, les partenaires doivent : 

• disposer d’un client SFTP ;

• disposer d’un utilitaire d’affectation de numéro de séquence ;

• définir une procédure d’émission et de réception. 

L’authentification du partenaire se fait via l’utilisation de sa clé41 publique. Cette clé doit être
communiquée42 à l’AIFE lors de la phase de raccordement, conformément aux modalités en cours pour
les flux TLS. 

La sécurité du protocole doit au préalable être assurée par : 

• la clé publique du serveur AIFE mise à disposition43 du partenaire ; 

• les algorithmes de chiffrement44 dont le support par le partenaire doit être assuré ; 

• les paires de clés RSA utilisées pour l’authentification du partenaire. 

Chaque partenaire dispose de son SAS de dépôt et récupération des fichiers : 

• le partenaire doit déposer sur le serveur SFTP dédié les fichiers qu’il souhaite remettre au portail
public de facturation (PPF) ; 
• le partenaire doit retirer sur le serveur SFTP dédié les fichiers qui lui sont mis à disposition par le
portail public de facturation (PPF) dans le respect du délai de retrait45. Un fichier mis à disposition
ne peut être récupéré qu’une seule fois. 

40 On désigne « partenaire » tout SI raccordé au PPF.
41 Bi-clé RSA.
42 Le certificat SFTP de la norme X509v3 du partenaire contenant la clé RSA publique et d’autres informations comme
l’identité du partenaire, l’autorité de certification (AC) qui a émis le certificat, ainsi que la période de validité du certificat.
43 Via des URL, sur les principes d’échanges TLS.
44 AES128_CBC et AES256_CBC. 
45 Le délai de retrait des fichiers est fixé à une durée d’une semaine (7 jours). Passé ce délai, les fichiers sont
automatiquement purgés et ne sont par conséquent plus disponibles.  

_Source: `c:\Users\g.baudrit\source\repos\gbaudrit\conf-aimer-votre-llm\demo\ctxc-sample-spec\with-ctxc\spec/dgfip/0- Dossier de specifications externes FE - Dossier général.pdf` (page:22/page:22)_

### E-ae51d289b8c1

23 
Pour ce faire, le partenaire est autorisé à utiliser des automates (scripts ou utilitaires) effectuant le dépôt
ou la récupération de fichiers. 

Chaque partenaire transmet des fichiers dont le nommage doit respecter les règles décrites46 dans le
présent document. 

Toute manipulation de fichier mis à disposition (hors récupération) ou du répertoire de récupération
(hors listage) est interdite. 

La cinématique d’un transfert SFTP est la suivante : 

Figure 5 – Cinématique d’un flux entrant par protocole SFTP 

Figure 6 – Cinématique d’un flux sortant par protocole SFTP 

3.3.2.2. Le protocole AS/2 

Le protocole Applicable Statement 2 (AS/2) est un protocole de transfert de fichiers fonctionnant en
mode « push », permettant au partenaire d’envoyer directement et de sa propre initiative un fichier au
destinataire. L’AS/2 spécifie le mode de connexion, de livraison, de validation et d'acquittement des
données. Ce protocole a la particularité d’intégrer un système d’acquittement protocolaire appelé
MDN. 

Pour requérir une connexion au système d’échange du portail public de facturation (PPF) à travers le
protocole AS/2, les partenaires doivent : 

• disposer d’un serveur AS/2 pour la réception des messages ; 

• disposer d’un client AS/2 pour l’émission ;

• disposer de serveurs en mesure de gérer les MDN synchrones ; 

• disposer d’un utilitaire d’affectation de numéro de séquence ; 

46 Cf. chapitre dédié 3.4.6.Le nommage des flux 

_Source: `c:\Users\g.baudrit\source\repos\gbaudrit\conf-aimer-votre-llm\demo\ctxc-sample-spec\with-ctxc\spec/dgfip/0- Dossier de specifications externes FE - Dossier général.pdf` (page:23/page:23)_

### E-c40769823269

24 
• définir une procédure d’émission et de réception. 

L’authentification du partenaire se fait via l’utilisation du mécanisme de signature électronique fourni
par le protocole AS/2. Ce certificat47 doit être communiquée à l’AIFE lors de la phase de raccordement. 

La sécurité du protocole48 doit au préalable être assurée par : 

• un utilitaire d’affectation de numéro de séquence ; 

• une procédure d’émission et de réception définie ;

• Un certificat pour les opérations d’authentification, signature49 et chiffrement50. 

Chaque partenaire transmet : 

• le fichier encapsulé dans la requête AS/2, sous forme de pièce jointe51, dont le nommage doit
respecter les règles décrites52 dans le présent document ;

• l’enveloppe de données est ensuite envoyée par Internet en utilisant les protocoles standards ; 

• les données sont transmises par le protocole http, en requête POST, à un nom de domaine
complètement qualifié (FQDN) ; 

• des acquittements (MDN) sont générés en mode synchrone53 pour signifier au client le succès
(OK) ou l’échec (NOK) du transfert. En cas d’échec (NOK), le transfert doit être rejoué. 

La cinématique d’un transfert AS/2 est la suivante : 

Figure 7 - Cinématique d’un flux entrant par protocole AS/2 

47 X509v3.
48 La couche de transport ne nécessite pas de TLS. 

49 SHA-2.
50 AES 256.
51 SMIME.
52 Cf. chapitre dédié 3.4.6.Le nommage des flux
53 L’AS/2 n’inclut pas de mécanisme de reprise automatique. En cas de non-réception des acquittements de transferts, il est
nécessaire de contacter le correspondant technique support du portail public de facturation (PPF). 

_Source: `c:\Users\g.baudrit\source\repos\gbaudrit\conf-aimer-votre-llm\demo\ctxc-sample-spec\with-ctxc\spec/dgfip/0- Dossier de specifications externes FE - Dossier général.pdf` (page:24/page:24)_

### E-998917c109b1

25 
Figure 8 - Cinématique d’un flux sortant par protocole AS/2 

3.3.2.3. Le protocole AS/4 

Le protocole Applicable Statement 4 (AS/4) est un protocole de transfert de fichiers fonctionnant en
mode « push » ou « pull ». Le protocole AS/4 spécifie le mode de connexion, de livraison, de validation
et d'acquittement des données. Ce protocole a la particularité d’intégrer un système d’acquittement
protocolaire appelé MDN. 

Pour requérir une connexion au système d’échange du portail public de facturation (PPF) à travers le
protocole AS/4, les utilisateurs doivent : 

• disposer d’un serveur AS/4 pour la réception des messages ; 
• disposer d’un client AS/4 pour l’émission ;
• disposer de serveurs en mesure de gérer les messages signaux d’acquittement (SOAP) signés ; 
• disposer d’un utilitaire d’affectation de numéro de séquence ; 
• définir une procédure d’émission et de réception. 

L’authentification du partenaire se fait via l’utilisation du mécanisme de signature électronique fourni
par le protocole AS/4. Ce certificat54 doit être communiquée à l’AIFE lors de la phase de raccordement. 

La sécurité du protocole55 doit au préalable être assurée par : 

• un utilitaire d’affectation de numéro de séquence ; 

• une procédure d’émission et de réception définie ;

• un certificat pour les opérations d’authentification, signature56 et chiffrement57. 

Chaque partenaire transmet : 

• le fichier encapsulé dans la requête AS/4, sous forme de pièce jointe58, dont le nommage doit
respecter les règles décrites59 dans le présent document ;

• l’enveloppe de données est ensuite envoyée par Internet en utilisant les protocoles standards ; 

• les données sont transmises par le protocole http, en requête POST, à un nom de domaine
complètement qualifié (FQDN) ; 

54 X509v3.
55 La couche de transport ne nécessite pas de TLS. 
56 SHA-2.
57 AES 256.
58 PJ SOAP (attachment).
59 Cf. chapitre dédié 3.4.6.Le nommage des flux 

_Source: `c:\Users\g.baudrit\source\repos\gbaudrit\conf-aimer-votre-llm\demo\ctxc-sample-spec\with-ctxc\spec/dgfip/0- Dossier de specifications externes FE - Dossier général.pdf` (page:25/page:25)_

### E-923c12bce129

26 
• des acquittements (SOAP) sont générés en mode synchrone60 et signés pour signifier au client le
succès (OK) ou l’échec (NOK) du transfert. En cas d’échec (NOK), le transfert doit être rejoué. 

La cinématique d’un transfert AS/4 est la suivante :   

Figure 9 - Cinématique d’un flux entrant par protocole AS/4 

Figure 10 - Cinématique d’un flux sortant par protocole AS/4

3.3.3. Le raccordement en API

Les raccordements API avec le portail public de facturation (PPF) ont vocation à permettre l’échange de
données avec un partenaire. L’un des avantages du mode API est de capitaliser sur les outils
informatiques déjà déployés au sein de la structure du partenaire, en y intégrant des données
additionnelles et/ou complémentaires. Les services API du portail public de facturation (PPF) sont
exposés via la plateforme d’intermédiation des services pour la transformation de l’Etat61 (PISTE).

Les services API proposés par le portail public de facturation (PPF) sont caractérisés par : 
• un mode d’authentification OAuth2 ;
• des principes architecturaux de type REST ; 
• l’envoi de requête de données réalisé via le protocole HTTP; 
• des messages au format JSON ou XML ou un code retour HTTP ; 
• des appels synchrones (i.e. la connexion est maintenue après chaque appel jusqu’à obtention de
la réponse) ;
• l’utilisation des verbes GET, POST, PUT et DELETE ;
• l’utilisation d’URL pour le versionnage des API62 ; 

60 L’AS/4 n’inclut pas de mécanisme de reprise automatique. En cas de non-réception des acquittements de transferts, il est
nécessaire de contacter le correspondant technique support du portail public de facturation (PPF).
61 Cf. Chapitre 7 - Documentation applicable : Présentation de la plateforme PISTE.
62 En cas d’évolutions, au-moins deux versions de chaque API seront maintenues afin de faciliter l’adaptation des clients. 

_Source: `c:\Users\g.baudrit\source\repos\gbaudrit\conf-aimer-votre-llm\demo\ctxc-sample-spec\with-ctxc\spec/dgfip/0- Dossier de specifications externes FE - Dossier général.pdf` (page:26/page:26)_

### E-bf012003855e

27 
• une gestion multi-langue63.

À la suite de l’appel d’une API par un partenaire, le serveur retourne des données (JSON ou XML) ou un
code retour HTTP. Dans le cas d’un code retour de type erreur, ce retour détaille l’erreur rencontrée
dans le corps du message. 

Les erreurs techniques peuvent être de 2 types :
• une erreur client est associée au code d’erreur 40x ;
• une erreur serveur est associée au code d’erreur 50x. 

Les principaux codes retours HTTP sont : 

Code retour  Libellé – Commentaire

200 Ok
201 Ok, une nouvelle ressource a été créée
204 Ok, la ressource a été supprimée
206 La requête est traitée sans erreur, mais le volume d’information renvoyée a été réduit
400 La requête est invalide ou ne peut pas aboutir
401 La requête n’est pas autorisée et nécessite l’authentification de l’utilisateur
403 La requête est refusée ou l’accès n’est pas autorisé
404 Il n’y a pas de ressource correspondante à l’URL donnée
408 Le délai maximal de la requête est atteint 
422 Erreur de validation des données
429 Le nombre maximal d’appels dans un délai donné est atteint
500 Une erreur interne au serveur est survenue
501 La ressource n’est pas implémentée
503 Le service est actuellement indisponible

Tableau 1 - Liste des codes retours HTTPS 

Les principaux services API64 proposés par le portail public de facturation (PPF) relèvent du périmètre de
l’annuaire PPF65. 

3.3.4. La création d’un raccordement 

Chaque plateforme agréée (PA) devra mettre en place a minima un raccordement EDI, en suivant la
procédure dédiée66 et dans le respect des exigences de sécurité définies par l’AIFE. Elle pourra choisir,
via un système d’abonnement, les flux (interfaces) qu’elle souhaite transmettre et recevoir.  

Ces raccordements devront être testés depuis la plateforme de qualification67 prévue à cet effet. 

Pour créer un raccordement EDI, le partenaire doit :

• choisir le protocole d’échange ; 
• fournir un certificat RGS 1* (minimum) qui doit être unique et valide ;
• choisir ses abonnements aux interfaces (émission et/ou réception) ; 

63 Un paramètre d’entrée de langue sera positionné au niveau des paramètres d’appel API de façon à recevoir les messages
de retour API (techniques ou fonctionnels) en français (FR). Le choix de la langue anglaise (EN) sera proposé ultérieurement.
64 Ces API sont décrites dans la documentation technique relative à l’annuaire (swagger publié sur PISTE).
65 Cf. chapitre dédié 3.5.L’annuaire
66 Cf. Chapitre 7 – Documentation applicable : Spécifications externes initiales B2G/G2G de Chorus Pro – Annexe EDI. 
67 La plateforme de qualification est accessible depuis le 03/02/2025. 

_Source: `c:\Users\g.baudrit\source\repos\gbaudrit\conf-aimer-votre-llm\demo\ctxc-sample-spec\with-ctxc\spec/dgfip/0- Dossier de specifications externes FE - Dossier général.pdf` (page:27/page:27)_

### E-cf4da1585931

28 
• fournir les caractéristiques techniques (information réseaux) ;
• fournir un contact facilitant les échanges. 

Pour créer un raccordement API, le partenaire doit :

• déclarer le nom de l’application PISTE qui doit être unique ;
• fournir un contact facilitant les échanges. 

Figure 2 - La mise en place d’un raccordement au portail public de facturation (PPF) 

3.3.5. La modification d’un raccordement 

Un partenaire peut modifier son raccordement EDI pour :

• mettre à jour son certificat ;
• mettre à jour ses abonnements aux interfaces (ajout, suppression) ;
• mettre à jour la date de fin de son raccordement qui permet de désactiver le raccordement à
une date fixée par le partenaire ;
• modifier le contact technique. 

Un partenaire peut modifier un raccordement API pour :

• mettre à jour le nom de l’application PISTE ;
• désactiver le raccordement API ;
• modifier le contact technique. 

3.3.6. La consultation d’un raccordement 

Un partenaire peut consulter tous les raccordements API et EDI liés à ses structures, via une IHM dédiée.
Toutes les informations du raccordement sont restituées, ainsi que le statut courant du raccordement
et la date d’expiration du certificat pour un raccordement EDI. 

3.4 Le système d’échanges 

3.4.1.  Les principes directeurs 

Le système d’échanges (SE) assure la gestion des transferts entre les systèmes d’informations (SI)
partenaires et le SI du portail public de facturation (PPF). 

_Source: `c:\Users\g.baudrit\source\repos\gbaudrit\conf-aimer-votre-llm\demo\ctxc-sample-spec\with-ctxc\spec/dgfip/0- Dossier de specifications externes FE - Dossier général.pdf` (page:28/page:28)_

### E-8570e88c630c

29 
L’authentification du partenaire est réalisée via son code application, défini lors de la création de son
raccordement. A partir du code application, le système d’échanges contrôle les informations suivantes : 
• l’existence et la validité, d’un raccordement pour ce code application partenaire ;
• la typologie de flux associée à l’abonnement de ce raccordement ;
• le protocole technique d’échange à utiliser. 

Seuls les partenaires raccordés sont autorisés à transmettre des flux au système d’échange, en fonction
de la typologie de flux à laquelle ils sont abonnés en émission et/ou en réception, ainsi que le protocole
d’échange qu’ils ont choisi à cet effet.   

3.4.2. Les contrôles techniques 

Tout flux entrant, émis par un partenaire raccordé et habilité, est contrôlé. Les contrôles techniques
suivants sont réalisés sur le flux et les fichiers qu’il contient68 : 

• contrôle antivirus ;
• contrôle du contenu (non vide) ; 
• contrôle d’extension69 ;
• contrôle de taille du flux et du nombre de fichiers contenus dans le flux 70 ;
• contrôle d’enveloppe et d’unicité. 

3.4.3. Les contrôles applicatifs 

Si les contrôles techniques ne retournent aucune anomalie sur le flux, alors des contrôles applicatifs sont
réalisés sur chaque fichier pour s’assurer que : 
• chaque fichier est exploitable ;
• chaque fichier est conforme aux dispositions réglementaires et/ou syntaxiques71. 

3.4.4. Le cycle de vie d’un flux 

Tout flux reçu par le portail public de facturation (PPF) - hors cycle de vie de flux - fera l’objet d’un cycle
de vie72 transmis au partenaire émetteur, afin d’informer ce dernier de l’état de traitement de ce flux
par le PPF. 

Objet Code Libellé Caractère Définition
Flux 500 Recevable Obligatoire Le flux est contrôlé et conforme.

Flux 501 Irrecevable Obligatoire Le flux est contrôlé mais non
conforme.

Tableau 2 - Les statuts possibles d'un flux

Un flux est irrecevable si : 

68 L’ensemble des fichiers contenus dans un flux sont de même nature et de même format.
69 Les extensions autorisées sont tar.gz et xml.
70 La taille maximale autorisée pour un flux est de 1Go, et chaque fichier contenu dans le flux ne doit pas dépasser une taille
maximale de 120 Mo. 
71 Ces contrôles sont décrits au travers de XSD.
72 Tous les fichiers générés par le PPF sont encodés en UTF-8 et tous les fichiers xml reçus doivent être encodés en UTF-8. 

_Source: `c:\Users\g.baudrit\source\repos\gbaudrit\conf-aimer-votre-llm\demo\ctxc-sample-spec\with-ctxc\spec/dgfip/0- Dossier de specifications externes FE - Dossier général.pdf` (page:29/page:29)_

### E-d5b55c273dad

30 
• le résultat d’un ou plusieurs contrôles techniques est en échec ;
• le résultat d’un ou plusieurs contrôles applicatifs est en échec. 

Figure 12 - L'irrecevabilité d'un flux en cas d'échec aux contrôles applicatifs

3.4.5. Les motifs d’irrecevabilité d’un flux 

L’irrecevabilité d’un flux est associée à un ou plusieurs motifs, et la source des anomalies73 est indiquée,
afin de permettre au partenaire de réaliser les actions correctives adaptées. 

Les motifs d’irrecevabilité d’un flux sont :   

73 L’identifiant du flux et/ou des fichiers contrôlés comme non conformes. 

_Source: `c:\Users\g.baudrit\source\repos\gbaudrit\conf-aimer-votre-llm\demo\ctxc-sample-spec\with-ctxc\spec/dgfip/0- Dossier de specifications externes FE - Dossier général.pdf` (page:30/page:30)_

### E-8b5a83ab2348

31 
Code Libellé Description

IRR_TAILLE Contrôle de taille du
flux Le flux dépasse la taille limite autorisée.

IRR_TAILLE_F  Contrôle de taille des
fichiers
L’un ou plusieurs fichiers contenus dans le flux
dépassent la taille limite autorisée.

IRR_TAILLE_PJ Contrôle de taille des
pièces jointes
L’une ou plusieurs pièces jointes dépassent la taille
limite autorisée.

IRR_UNCITE Contrôle d’unicité Le flux a déjà été envoyé et réceptionné.

IRR_VIDE Contrôle de flux non
vide Le flux est vide.

IRR_VIDE_F Contrôle des fichiers
non vides
L’un ou plusieurs fichiers contenus dans le flux sont
vides.

IRR_VID_PJ Contrôle des pièces
jointes non vides L’une ou plusieurs pièces jointes sont vides.

IRR_FORM Contrôle du nom de
l'enveloppe du flux
Le nom du flux ne respecte pas les règles de
nommage.

IRR_NOM_F Contrôle du nom des
fichiers
Le nom d’un ou plusieurs fichiers ne respecte pas les
règles de nommage74.

IRR_NOM_PJ Contrôle du nom des
pièces jointes
Le nom d’une ou plusieurs pièces jointes ne respecte
pas les règles de nommage.

IRR_TYPE Contrôle de type et
extension du flux 
Le type et/ou l’extension du flux ne sont pas
conformes.

IRR_TYPE_F Contrôle de type et
extension des fichiers 
Le type et/ou l’extension des fichiers contenus dans le
flux ne sont pas conformes.

IRR_EXT_DOC
Contrôle de type et
extension des pièces
jointes 
Le type et/ou l’extension des pièces jointes dans le flux
ne sont pas conformes.

IRR_ANTIVIRUS Contrôle anti-virus Le flux ne respecte pas les conditions de sécurité.

IRR_CODE_INTER Code interface
inconnu Le code interface du flux n’est pas connu du système.

IRR_EXTRAC Extraction de l’archive L'archive du flux déposé n'a pas pu être extraite.

IRR_CODE_APP Contrôle du code
application
Aucun raccordement n'existe pour le code application
du flux.

IRR_SYNTAX Contrôle syntaxique
des fichiers
Le format syntaxique de l’un ou plusieurs fichiers n’est
pas correct.

Tableau 3 - Liste des motifs d'irrecevabilité

Si les contrôles techniques et applicatifs ne retournent aucune anomalie alors le flux (ainsi que chaque
fichier qu’il contient) est recevable. 

74 Une règle de nommage pour les fichiers F1 impose le format suivant : <profil>_<nom_de_fichier>.xml. Le <profil> permet
de traiter efficacement ces flux en fonction de la trajectoire des données réglementaires (cf. chapitre dédié 3.6.3Les
données réglementaires d’une facture), et peut prendre les deux valeurs « Base » et « Full ». Des fichiers de profils
différents peuvent être présents au sein d’un même flux.  

_Source: `c:\Users\g.baudrit\source\repos\gbaudrit\conf-aimer-votre-llm\demo\ctxc-sample-spec\with-ctxc\spec/dgfip/0- Dossier de specifications externes FE - Dossier général.pdf` (page:31/page:31)_

### E-dc3475dc35f2

32 
Figure 13 - La recevabilité d'un flux en cas de succès des contrôles techniques et applicatifs 

Dans un cas de recevabilité comme d’irrecevabilité, le système d’échanges va allotir les objets cycles de
vie nécessaires75 à la constitution d’un flux76. Une fois constitué, le système d’échanges adresse le flux au
partenaire, via le protocole technique d’échange que ce dernier a choisi lors de la création de son
raccordement. 

3.4.6. Le nommage des flux 

L’enveloppe d’un flux est composée de :
• un code interface qui permet d’identifier la nature du flux et son format ;
• un code application partenaire de l’émetteur destinataire du flux77 ; 
• un identifiant de flux (25 caractères) construit à partir du code application de l’émetteur du flux
(6 premiers caractères) et d’un numéro de séquence (19 caractères : chiffres ou lettres
majuscules). 

Figure 14 - La composition de l'enveloppe d'un flux

Recommandation AIFE :
Il est recommandé de construire l’identifiant du flux comme suit :
- code application (CCCCCC) : 6 caractères alphanumériques
- code interface (IIII) : 4 chiffres
- identifiant du flux (XXXXXXXXXXXXXXX) : 15 chiffres définis par l’émetteur. 

75 Les critères d’allotissement sont : le code application partenaire, la nature du flux, le format du flux, la taille maximale
d’un flux, le nombre maximal de fichiers contenus dans un flux et le délai maximal de mise à disposition des informations.
76 De type archive « tar.gz ».
77 Lorsque le flux est émis par un partenaire au PPF (flux entrant) alors le code application du partenaire émetteur du flux
est à renseigner. Lorsque le flux est émis par le PPF (flux sortant) à un partenaire alors le code application du partenaire
destinataire du flux est renseigné. 

_Source: `c:\Users\g.baudrit\source\repos\gbaudrit\conf-aimer-votre-llm\demo\ctxc-sample-spec\with-ctxc\spec/dgfip/0- Dossier de specifications externes FE - Dossier général.pdf` (page:32/page:32)_

### E-f2bf5409e58f

33 
Figure 15 – Recommandation de composition de l'identifiant d'un flux 

Exemple :
Dépôt d’un flux de données réglementaires (F1) au format UBL avec le code interface FFE0111A et le code
application partenaire AAA123 : FFE0111A_AAA123_AAA1230111000000000000001. 

Les codes interfaces attendus pour chaque type de flux sont : 

N° de flux Description Format (syntaxe)
du flux Code interface

F6
Cycle de vie de flux  CDAR CFE + IIIIV (issus du code
interface initial)78

Cycle de vie de factures CDAR FFE0614A

Cycle de vie de données
réglementaires79 CDAR FFE0604A

Cycle de vie de statuts obligatoires CDAR FFE0654A

Cycle de vie de données de
transaction et de paiement CDAR FFE0624A

Cycle de vie d’actualisation de
l’annuaire  CDAR FFE0634A

F1 Données réglementaires
UBL FFE0111A

CII FFE0112A

F10 Données de transaction et de
paiement Format spécifique FFE1025A

F13 Actualisation de l’annuaire Format spécifique FFE1235A

F14 Export de l’annuaire Format spécifique FFE1435A

Tableau 4 - Liste des codes interfaces par type de flux 

Exemples : 
• Une plateforme agréée d’émission (code application : AAA123) transmet un flux de données
obligatoire - F1 au format UBL (numéro de séquence : 0111000000123456789) au portail public de
facturation (code application : PPF001) : 

78 Le code interface d’un flux cycle de vie se rapportant à un objet de type flux est constitué à partir de l’enveloppe de ce
flux d’origine, en changement uniquement la première lettre F par C.
79 Ce cycle de vie sera transmis exclusivement par le portail public de facturation (PPF). 

_Source: `c:\Users\g.baudrit\source\repos\gbaudrit\conf-aimer-votre-llm\demo\ctxc-sample-spec\with-ctxc\spec/dgfip/0- Dossier de specifications externes FE - Dossier général.pdf` (page:33/page:33)_

### E-fb6b80687556

34 
Figure 16 - Cinématique des flux F1 

• Une plateforme agréée d’émission (code application : AAA123) transmet un flux de statuts
réglementaires - F6 (numéro de séquence : 0614000000123456789) au portail public de facturation
(code application : PPF001) : 

Figure 17 - Cinématique des flux F6

A noter : le PPF n’émet de cycle de vie (statuts réglementaires) – F6 que dans le cas où les statuts
réglementaires transmis par la plateforme sont rejetés (i.e. : une anomalie a été détectée à l’issue des
contrôles fonctionnels). 

• Une plateforme agréée d’émission (code application : AAA123) transmet un flux de transmission -
F10 (numéro de séquence : 1025000000123456789) au portail public de facturation (code
application : PPF001) : 

_Source: `c:\Users\g.baudrit\source\repos\gbaudrit\conf-aimer-votre-llm\demo\ctxc-sample-spec\with-ctxc\spec/dgfip/0- Dossier de specifications externes FE - Dossier général.pdf` (page:34/page:34)_

### E-925543716134

35 
Figure 18 - Cinématique des flux F10 

• Une plateforme agréée de réception (code application : BBB123) transmet un flux d’actualisation
de l’annuaire - F13 (numéro de séquence : 1235000000123456789) au portail public de facturation
(code application : PPF001) : 

Figure 3 - Cinématique des flux F13 

• Le portail public de facturation émet un flux de consultation - F14 (numéro de séquence :
1435000000123456789) à une plateforme agréée (code application : AAA123) : 

Figure 4 - Cinématique des flux F14 

A noter : la plateforme agréée n’émet pas de cycle de vie (ligne d’annuaire) – F6 au portail public de
facturation.  

_Source: `c:\Users\g.baudrit\source\repos\gbaudrit\conf-aimer-votre-llm\demo\ctxc-sample-spec\with-ctxc\spec/dgfip/0- Dossier de specifications externes FE - Dossier général.pdf` (page:35/page:35)_

### E-46bb7953280d

36 
3.5 L’annuaire

3.5.1.  Les principes directeurs 

Le dispositif de facturation en Y choisi dans le cadre de la réforme nécessite la mise en place d’un
annuaire permettant aux différentes plateformes agréées immatriculées d’échanger des factures
électroniques pour le compte d’entreprises assujetties. Le portail public de facturation (PPF) assure
l’administration centralisée de cet annuaire et sa mise à disposition aux plateformes et aux entreprises.

L’annuaire référence toutes les structures possédant un SIREN, qui sont identifiées comme assujetties à
la TVA par l’administration fiscale, ainsi que l’ensemble des entités publiques assujetties ou non. Il
contient les informations d’identification de ces structures et de leurs plateformes de réception. 

Ainsi, l’annuaire est : 

• une ressource clef du portail public de facturation mise à disposition des entreprises pour
adresser les factures et leurs statuts au bon destinataire ;

• un service proposé par le portail public de facturation (PPF) aux plateformes agréées pour assurer
le routage des factures.    

L’annuaire centralisé s’appuie sur plusieurs principes directeurs permettant de fiabiliser les échanges
dématérialisés prévus dans le cadre de l’obligation de la facturation électronique : 

• la centralisation : l’annuaire rassemble l’ensemble des acteurs concernés par la réforme
(assujettis et acheteurs publics) dans un référentiel unique ;
• l’interopérabilité : l’annuaire est accessible à tout utilisateur habilité ;
• la précision : l’annuaire garantit un niveau d’information exhaustif et actualisé permettant le bon
adressage des factures et de leurs statuts, ainsi que leur routage ;
• la sécurité : l’annuaire garantit la sécurité et la traçabilité des mises à jour des données. 

3.5.2. La cartographie des flux 

Plusieurs types de flux sont impliqués dans les interactions avec l’annuaire : 

• les flux d’actualisation et de consultation de l’annuaire ;
• les flux de cycle de vie (flux80 et annuaire81) ; 

80 Cf. le chapitre dédié 3.4.4.Le cycle de vie d’un flux

81 Cf. le chapitre dédié 3.5.7.Le cycle de vie des objets métiers du type ligne d’annuaire 

_Source: `c:\Users\g.baudrit\source\repos\gbaudrit\conf-aimer-votre-llm\demo\ctxc-sample-spec\with-ctxc\spec/dgfip/0- Dossier de specifications externes FE - Dossier général.pdf` (page:36/page:36)_

### E-1dc476b37743

37 
Figure 5 - La cartographie des flux Annuaire échangés 

3.5.3. L’initialisation de l’annuaire 

L’annuaire est alimenté par des informations issues du registre des structures privées, des structures
publiques, des assujettis à la TVA et des plateformes immatriculées :

• le registre des entreprises privées, extrait du répertoire des entreprises de l’INSEE, contenant les
SIREN (unités légales) et SIRET (établissements) des entreprises privées établies en France et
actives ; 
• le registre des structures publiques, issu du portail de services Chorus Pro, contenant les SIRET
(établissements) et les services (code routage) des structures publiques destinataires de factures
B2G/G2G ;
• le registre des assujettis à la TVA française, issu des référentiels de l’administration fiscale ; 
• le registre des plateformes agréées immatriculées par le service dédié de l’administration.    

_Source: `c:\Users\g.baudrit\source\repos\gbaudrit\conf-aimer-votre-llm\demo\ctxc-sample-spec\with-ctxc\spec/dgfip/0- Dossier de specifications externes FE - Dossier général.pdf` (page:37/page:37)_

### E-90d89e329744

38 
Figure 6 - Les sources d'initialisation de l'annuaire 

A partir de ces informations, le portail public de facturation (PPF) constitue des lignes d’annuaire à la
maille SIREN. Une ligne d’annuaire est unique et contient toutes les informations nécessaires à
l’adressage et au routage d’une facture : 

• les informations d’identification de l’entreprise destinataire de la facture ;
• les informations d’identification de la plateforme de réception à qui transmettre la facture ;
• la période durant laquelle ces informations sont en vigueur.   

Figure 23 - La structure d'une ligne d'annuaire 

La nature d’une ligne d’annuaire permet : 

• dans le cas d’une ligne de « définition », de constituer une ligne d’annuaire qui porte l’ensemble
des informations nécessaire à l’adressage et au routage de factures ;
• dans le cas d’une ligne de « masquage », d’annuler la prise d’effet d’une ligne d’annuaire, telle
qu’elle a été définie au préalable. 

La période de validité d’une ligne d’annuaire est composée : 

• d’une date de début d’effet, soit la date à laquelle la ligne entre en vigueur ;
• d’une date de fin d’effet, soit la date à laquelle la ligne ne devrait plus être en vigueur ;
• d’une date de fin effective, soit la date à laquelle la ligne n’est plus en vigueur.  

_Source: `c:\Users\g.baudrit\source\repos\gbaudrit\conf-aimer-votre-llm\demo\ctxc-sample-spec\with-ctxc\spec/dgfip/0- Dossier de specifications externes FE - Dossier général.pdf` (page:38/page:38)_

### E-15aeb012c40c

39 
Dans le cas nominal, la date de fin effective d’une ligne d’annuaire est égale à sa date de fin d’effet.
Néanmoins certains évènements exogènes82 ont pour conséquence de raccourcir la période durant
laquelle une ligne d’annuaire est en vigueur. Dans ce cas, la date de fin effective correspond à la date
d’occurrence de cet évènement, et est antérieure à la date de fin d’effet initialement prévue. Toute ligne
d’annuaire dont la date de fin d’effet est échue n’est plus adressable ni consultable. 

Les informations d’identification de l’entreprise peuvent être organisées en différentes mailles
d’adressage :

• La maille d’une unité légale (SIREN) 

• La maille d’un établissement (SIRET) 

• La maille d’un code routage 

• La maille d’un suffixe 

Ces mailles d’adressage offrent la possibilité aux entreprises d’adapter les modalités de réception de
leurs factures à leur fonctionnement de gestion administrative et comptable interne. En effet, une
entreprise peut souhaiter recevoir et traiter ses factures de manière centralisée (exemple : à son siège
social), ou de manière décentralisée (exemple : au sein de ses différents points de vente, ou de ses
services de comptabilité et de gestion de paie, etc.). 

Lors de l’initialisation de l’annuaire, des lignes d’annuaire par défaut sont créées par le portail public de
facturation (PPF) :
• pour les entreprises privées, à la maille de l’unité légale (SIREN). Une plateforme « fictive » est
attribuée par défaut à ces lignes d’annuaire ; 

82 Par exemple, la perte du caractère assujetti d’une entreprise, la perte d’immatriculation d’une PA. 

_Source: `c:\Users\g.baudrit\source\repos\gbaudrit\conf-aimer-votre-llm\demo\ctxc-sample-spec\with-ctxc\spec/dgfip/0- Dossier de specifications externes FE - Dossier général.pdf` (page:39/page:39)_

### E-e2866fdcdb18

40 
• pour les structures publiques83,à la maille de l’établissement (SIRET) et à la maille code routage.
Chorus Pro est attribuée par défaut comme plateforme de réception à ces lignes d’annuaire. 

Les plateformes agréées de réception (PAR) auront la possibilité d’actualiser les lignes d’annuaire des
entreprises privées créées lors de l’initialisation, et d’en ajouter d’autres de manière à paramétrer la
maille de réception de factures des entreprises pour le compte desquelles elles agissent. 

3.5.4. La consultation de l’annuaire 

La création de la facture par un fournisseur - depuis son système d’information, via une solution
compatible (SC) ou sa plateforme agréée d’émission (PAE) - nécessite la consultation de l’annuaire pour
confirmer les informations d’adressage de l’acheteur à indiquer dans la facture. 

Afin de transmettre la facture à son destinataire (acheteur), la consultation de l’annuaire par la
plateforme d’émission du fournisseur est nécessaire pour obtenir les informations de routage de la
plateforme de réception choisie et associée aux données d’adressages référencées dans la facture. 

Figure 7 - La consultation de l'annuaire pour l'adressage et le routage de facture 

L’annuaire est consultable via : 

• Le canal EDI par les partenaires habilités, raccordés et abonnés :

o un flux différentiel est émis par le portail public de facturation (PPF) toutes les 24h, et
contient une extraction de l’annuaire (fichier au format spécifique XML) retraçant
l’ensemble des modifications réalisées sur cette durée ; 

o un flux complet est émis par le portail public de facturation (PPF) à une fréquence
hebdomadaire, et le flux complet est produit dans la nuit du dimanche au lundi, sur la
base des données présentes dans l’annuaire le dimanche. Lors de la mise en place de
l’abonnement à ce type de flux, une extraction de l’annuaire (fichier au format spécifique
XML défini dans l’annexe 3 des spécifications externes) référençant l’ensemble des 

83 Une ligne d’annuaire à la maille code routage peut également être créée, si l’organisation de la structure publique est
renseignée comme telle dans le portail de services Chorus Pro. 

_Source: `c:\Users\g.baudrit\source\repos\gbaudrit\conf-aimer-votre-llm\demo\ctxc-sample-spec\with-ctxc\spec/dgfip/0- Dossier de specifications externes FE - Dossier général.pdf` (page:40/page:40)_

### E-3fec1aa9be6b

41 
informations en vigueur à la date de constitution du flux est mis à disposition du
partenaire raccordé. 

Ces flux84 s’adressent en particulier aux partenaires qui souhaitent importer les données de l’annuaire
dans leurs systèmes d’informations et/ou les intégrer dans leurs outils de gestion. 

• Le canal API par les partenaires habilités et raccordés. Les ressources Unité légale (SIREN),
Établissement (SIRET), Code routage, Plateforme et Ligne d’annuaire, ainsi que les informations
qu’elles contiennent, sont : 

o disponibles en service de recherche (méthode POST). Les résultats de la recherche
répondant à des critères, sont paginés et retournés au format souhaité (champs, tri) ;

o disponibles en service de consultation (méthode GET). L’ensemble des attributs de la
ressource sont restitués. 

• Le canal Portail pour tout autre utilisateur, sans nécessité d’authentification et habilitation. Une
IHM expose une vision consolidée des informations d’adressage, en cours de vigueur à la date de
la consultation, et des informations d’adressage futures, relatives aux entreprises destinataires
de factures, qu’elles soient privées ou publiques. Les informations de routage relatives aux
plateformes de réception (matricules) ne sont pas exposées. 

Figure 8 - Page d'accueil du Portail Annuaire ( https://facturation.chorus-pro.gouv.fr/annuaire/#/ ) 

84 La structure de ces flux d’actualisation (F14), et les données qu’ils contiennent, sont décrites dans l’annexe 3 des
spécifications externes. 

_Source: `c:\Users\g.baudrit\source\repos\gbaudrit\conf-aimer-votre-llm\demo\ctxc-sample-spec\with-ctxc\spec/dgfip/0- Dossier de specifications externes FE - Dossier général.pdf` (page:41/page:41)_

### E-642fbe5fbb89

42 
Figure 9 - Exemple d'écran de consultation du Portail Annuaire

3.5.5. L’actualisation de l’annuaire 

L‘annuaire est actualisé avec :

• des informations issues du répertoire des entreprises de l’INSEE ;
• des informations issues du registre des assujettis à la TVA française de l’administration fiscale ;
• des informations issues du service dédié à l’immatriculation des plateformes agrées (PA) ;
• des informations issues du portail de services Chorus Pro ;
• des informations actualisées par les plateformes agréées immatriculées. 

3.5.5.1. L’actualisation de l’annuaire depuis le répertoire des entreprises 

L’annuaire est actualisé quotidiennement par interrogation du répertoire des entreprises de l’INSEE, afin
d’obtenir tous les changements apportés aux entreprises présentes dans l’annuaire. 

Cette actualisation quotidienne permet ainsi de maintenir à jour les informations d’identification des
entreprises (raison sociale, adresse postale, état administratif, statut de diffusion) et de leurs
établissements (dénomination, adresse postale, état administratif, statut de diffusion). Les
établissements secondaires créés seront également ajoutés à l’annuaire lors de cette actualisation pour
permettre aux plateformes agréées de créer des lignes d’annuaire correspondantes. 

3.5.5.2. L’actualisation de l’annuaire par le registre des assujettis à la TVA française de
l’administration fiscale 

Un flux quotidien provenant du registre des assujettis à la TVA française de l’administration fiscale à
destination du portail public de facturation (PPF) est prévu de manière à transmettre toutes les mises à
jour de ce registre et actualiser les informations de l’annuaire en conséquence lorsque : 
• une entreprise est nouvellement assujettie à la TVA française ;
• une entreprise n’a plus le caractère d’assujetti.  

_Source: `c:\Users\g.baudrit\source\repos\gbaudrit\conf-aimer-votre-llm\demo\ctxc-sample-spec\with-ctxc\spec/dgfip/0- Dossier de specifications externes FE - Dossier général.pdf` (page:42/page:42)_

### E-f7e476b4695b

43 
Figure 10 - L'actualisation de l'annuaire par le référentiel des occurrences fiscales 

Dans le cas d’une entreprise nouvellement assujettie :

• les données de l‘entreprise85, obtenues auprès du répertoire des entreprise de l’INSEE, sont
ajoutées à l’annuaire ;

• les données des établissements de cette entreprise en activité au moment de son insertion dans
l’annuaire (obtenues auprès de l’INSEE) sont ajoutées à l’annuaire ;

• une ligne d’annuaire à la maille de l’entité légale (SIREN) est créée par défaut, et une plateforme
« fictive » de matricule 9998 est attribuée à cette ligne.   

Figure 11 - La création d’une ligne d'annuaire pour une entreprise nouvellement assujettie

Dans le cas d’une entreprise n’ayant plus le caractère d‘assujetti, les lignes d’annuaire existantes pour
cette entreprise sont actualisées : 

• une date de fin effective est attribuée automatiquement à chaque ligne d’annuaire en cours de
vigueur ;
• une ligne d’annuaire de type « masquage » est générée automatiquement pour chaque ligne
d’annuaire dont la date de début d’effet est postérieure au retrait du caractère assujetti. 

Figure 12 - L'actualisation des lignes en vigueur à la suite du retrait du caractère assujetti et/ou la cessation d’activité 

85 Si l’entreprise est déjà connue de l’annuaire (assujettissement faisant suite à une perte d’assujettissement précédente),
les données sont actualisées. 

_Source: `c:\Users\g.baudrit\source\repos\gbaudrit\conf-aimer-votre-llm\demo\ctxc-sample-spec\with-ctxc\spec/dgfip/0- Dossier de specifications externes FE - Dossier général.pdf` (page:43/page:43)_

### E-bed5a0e937ae

44 
Figure 13 - Le masquage de lignes non entrées en vigueur à la suite du retrait du caractère assujetti et/ou la cessation d’activité 

3.5.5.3. L’actualisation de l’annuaire par le service d’immatriculation 

L’administration du registre des plateformes agréées (PA) immatriculées est réalisée par le service dédié
de l’administration fiscale. Des services sont prévus de manière à transmettre toutes les mises à jour de
ce registre et actualiser les informations de l’annuaire en conséquence lorsque : 

• une plateforme est nouvellement immatriculée ;
• une plateforme perd son immatriculation. 

Figure 14 - L'actualisation de l'annuaire par le service d'immatriculation 

Dans le cas d’une plateforme nouvellement immatriculée, aucune actualisation de l’annuaire ne sera
réalisée. Néanmoins, une fois cette plateforme raccordée et habilitée, elle pourra actualiser l’annuaire.

Dans le cas d’une plateforme ayant perdu son immatriculation et/ou ayant cessé son activité, les lignes
d’annuaire existantes attribuées à cette plateforme sont actualisées : 

• une date de fin effective est attribuée à chaque ligne d’annuaire en vigueur, correspondant à la
date de la perte d’immatriculation ;
• une ligne d’annuaire de type « masquage » est générée automatiquement pour chaque ligne
d’annuaire dont la date de début d’effet est postérieure à la perte d’immatriculation ou à la
cessation d’activité. 

Figure 15 - L'actualisation de lignes en vigueur à la suite d’une perte d'immatriculation  

_Source: `c:\Users\g.baudrit\source\repos\gbaudrit\conf-aimer-votre-llm\demo\ctxc-sample-spec\with-ctxc\spec/dgfip/0- Dossier de specifications externes FE - Dossier général.pdf` (page:44/page:44)_

### E-3ac89fc5e9b0

45 
Figure 16 - Le masquage de lignes non entrées en vigueur à la suite d’une perte d'immatriculation 

3.5.5.4. L’actualisation de l’annuaire par le portail de services Chorus Pro 

L’administration du registre des structures publiques est réalisée par le portail de services Chorus Pro.
Des services sont prévus de manière à transmettre toutes les mises à jour de ce registre et actualiser les
informations de l’annuaire en conséquence lorsque : 

• une structure publique modifie son organisation (création ou suppression de services) ;
• une structure publique réduit son rôle à la maîtrise d’ouvrage (MOA uniquement), et ne peut
alors recevoir que des factures de travaux. 

Figure 17 - L'actualisation de l'annuaire par le portail de services Chorus Pro 

Dans le cas d’une modification de l’organisation au sein d’une structure publique (exemple : la création
d’un service), une ligne d’annuaire à la maille adaptée est créée, et Chorus Pro est attribuée comme
plateforme de réception à cette ligne. 

Figure 18 - La création d'une ligne d'annuaire pour un nouveau service  

Dans le cas d’une structure publique réduisant son rôle à la maîtrise d’ouvrage (MOA), les lignes
d’annuaire existantes pour cette structure publique sont actualisées : 

• une date de fin effective est attribuée à chaque ligne d’annuaire en vigueur ; 

_Source: `c:\Users\g.baudrit\source\repos\gbaudrit\conf-aimer-votre-llm\demo\ctxc-sample-spec\with-ctxc\spec/dgfip/0- Dossier de specifications externes FE - Dossier général.pdf` (page:45/page:45)_

### E-f7b8f591b9d1

46 
• une ligne d’annuaire de type « masquage » est générée automatiquement pour chaque ligne
d’annuaire dont la date de début d’effet est postérieure à la réduction du rôle à la maîtrise
d’ouvrage (MOA). 

Figure 19 - L'actualisation de lignes à la suite d’une réduction du rôle d'une structure publique à la maîtrise d'ouvrage (MOA) 

3.5.5.5. L’actualisation de l’annuaire par les plateformes agréées (PA) 

L’article 28 du PLF 2026 vient préciser les modalités d’actualisation de l’annuaire par les plateformes
agréées en proposant de modifier le III de l’article 289 bis du CGI comme suit :

« iii) Au dernier alinéa, après les mots : « d’identifier », la fin de l’alinéa est remplacée par les dispositions
suivantes : « les plateformes agréées intéressées, ainsi que les modalités de recueil, auprès des assujettis
destinataires des factures, et de transmission de ces informations. Il précise également les modalités de
changement de plateforme agréée ainsi que la nature et la durée, qui ne peut être inférieure à six mois, des
services minimums devant être fournis par l’ancienne plateforme agréée lorsqu’un tel changement
intervient. »

Sous réserve de son adoption, le dispositif sera précisé par voie réglementaire.  Le contenu du dispositif
a, d’ores et déjà, été partagé avec l’ensemble des plateformes agréées et les organisations
professionnelles représentatives, incluant notamment la nécessité de disposer de l’accord formel de
l’assujetti destinataire des factures et les modalités pour changer de plateforme agréée.

Le recueil du consentement de l’assujetti pour désigner la plateforme de réception et les informations
d’adressage choisies peut se faire au-travers de la complétion d’un « accord formel » sur le modèle
suivant (exemple de formulaire), signé par l’entreprise manuellement ou électroniquement :  

_Source: `c:\Users\g.baudrit\source\repos\gbaudrit\conf-aimer-votre-llm\demo\ctxc-sample-spec\with-ctxc\spec/dgfip/0- Dossier de specifications externes FE - Dossier général.pdf` (page:46/page:46)_

### E-56f6ac3ba3e5

47 
Figure 20 - Exemple d'accord formel de choix de plateforme agréée

L’article 28 du PLF 2026 précise également, sous réserve de son adoption, les conséquences en cas de
non-respect du dispositif en complétant le I de l’article 1788 E du CGI de l’alinéa suivant :

« 3° Lorsque l’administration a constaté le non-respect par la plateforme agréée de ses obligations relatives
à l’actualisation, dans l’annuaire central prévu au III de l’article 289 bis, des informations nécessaires à
l’adressage des factures à recevoir, au changement de plateforme agréée de réception des factures, ainsi
qu’aux services minimums devant être fournis par l’ancienne plateforme agréée en cas de changement, et
que, l’administration l’ayant mise en demeure de se conformer à ses obligations dans un délai de quinze
jours ouvrés, cette plateforme agréée ne lui a pas communiqué dans ce délai tout élément de preuve de
nature à établir qu’elle s’est conformée à ses obligations ou qu’elle a pris les mesures nécessaires pour
assurer sa mise en conformité dans un délai raisonnable. » . 

_Source: `c:\Users\g.baudrit\source\repos\gbaudrit\conf-aimer-votre-llm\demo\ctxc-sample-spec\with-ctxc\spec/dgfip/0- Dossier de specifications externes FE - Dossier général.pdf` (page:47/page:47)_

### E-ba78f8c2812c

48 
Les plateformes agréées de réception (PAR) ont la responsabilité de mettre à jour les informations
d’adressage et de routage des entreprises privées destinataires de factures pour lesquelles elles agissent.
Pour cela, une plateforme agréée de réception (PAR) peut : 

• actualiser des lignes d’annuaire existantes86, quelle que soit leur maille, et les attribuer à son
matricule 
• ajouter des lignes d’annuaire ; 
o à la maille établissement (SIRET) pour tout établissement actif de l’entreprise ajouté à
l’annuaire dans le cadre de l’initialisation ou de la mise à jour depuis le répertoire des
entreprises,
o à la maille code routage, pour s’adapter au plan d’adressage de l’entreprise en créant les
codes routage nécessaires au préalable, 
o à la maille suffixe87, pour exploiter des adresses réseau ou codes d’adressages spécifiques. 
• créer des codes routages ;
• mettre fin à des lignes d’annuaire en vigueur et masquer des lignes d’annuaire qui devaient entrer
en vigueur88. 

Toute plateforme agréée de réception (PAR) habilitée et raccordée peut actualiser l’annuaire via : 

• le canal EDI en adressant un flux d’actualisation89 contenant l’ensemble des modifications qu’elle
souhaite apporter aux lignes d’annuaire des entreprises pour lesquelles elle agit. Si aucune
anomalie ou non-conformité n’est détectée par les contrôles techniques et fonctionnels, le flux
est intégré et l’annuaire actualisé en conséquence ; 

• le canal API en utilisant les ressources : 

o code routage (méthode POST, PUT et PATCH) ; 

o ligne d’annuaire (méthode POST, PUT, PATCH et DELETE). 

Toute actualisation de l’annuaire, quel que soit le canal utilisé, sera consultable dès le lendemain (J+1). 

Exemple : Une entreprise (SIRET : 123 456 789 000001) a contractualisé avec une plateforme agréée
(Matricule : 0005) depuis le 01/02/2027, et possède une ligne d’annuaire à la maille SIREN et une ligne
d’annuaire à la maille SIRET.  Le 31/03/2027, l’entreprise met fin à ce contrat, et contractualise avec une
nouvelle plateforme agréée (Matricule : 9997) jusqu’au 31/12/2027. 

86 Seule une PA qui a formellement contractualisé avec un client privé est autorisée à remplacer la ligne d’annuaire par défaut
à la maille SIREN par une ligne d’annuaire portant son matricule de plateforme de réception.
87 Il est fortement recommandé de créer des suffixes à la signification claire qui permettent de facilement distinguer leur
utilisation prévue pour les utilisateurs habilités du PPF. Il est également fortement recommandé de veiller à ne pas nommer
un suffixe avec un numéro SIRET.
88 Par exemple, en cas d’une rupture précipitée de contrat entre un client et sa PA. Il est alors conseillé à la PA de clôturer
les lignes d’annuaire en vigueur qui lui sont attribuées pour ce client (et le cas échéant, de masquer les lignes d’annuaire
dont la date d’entrée en vigueur n’était pas encore échue), puis de créer une ligne d’annuaire pour ce client, à la maille
SIREN, attribué au matricule de la plateforme fictive.
89 La structure du flux d’actualisation (F13), et les données qu’il contient, sont décrites dans l’annexe 3. Il est recommandé
que les modifications soient véhiculées via un unique fichier, et qu’un bloc code routage (DG-5) ou un bloc ligne d’annuaire
(DG-7) soit renseigné a minima. 

_Source: `c:\Users\g.baudrit\source\repos\gbaudrit\conf-aimer-votre-llm\demo\ctxc-sample-spec\with-ctxc\spec/dgfip/0- Dossier de specifications externes FE - Dossier général.pdf` (page:48/page:48)_

### E-0373cebf2d15

49 
Figure 21 - L’actualisation de l’annuaire par une nouvelle PA 

La nouvelle plateforme agréée de réception actualise donc les lignes d’annuaire de l’entreprise pour : 

• clôturer les lignes d’annuaire en vigueur attribuées à la précédente plateforme agréée de réception ;

• s’attribuer les lignes d’annuaire. 

Figure 22 - L’actualisation des lignes à la suite de la réduction du rôle d'une structure publique à la maitrise d'ouvrage (MOA) 

L’entreprise se réorganise et souhaite adapter la maille d’adressage de ses factures en fonction : 

• à partir du jour 15/04/2027 l’ensemble de ses factures sont traitées par le service A ;

• à compter du 01/09/2027, les factures de prestations de services seront traitées par le service B et
les achats de marchandises seront traitées par le service C. 

_Source: `c:\Users\g.baudrit\source\repos\gbaudrit\conf-aimer-votre-llm\demo\ctxc-sample-spec\with-ctxc\spec/dgfip/0- Dossier de specifications externes FE - Dossier général.pdf` (page:49/page:49)_

### E-a25faa9e5028

50 
Figure 23 - La création de services et des lignes d'annuaire correspondantes 

La plateforme agréée de réception actualise donc les lignes d’annuaire de l’entreprise pour : 

• créer les services A, B et C ;

• créer les lignes d’annuaire correspondantes. 

Figure 24 - La création de lignes à la suite de la mise en place d'une nouvelle maille d'adressage 

Le 02/06/2027, l’entreprise adapte son projet d’organisation et souhaite finalement que ses factures soient
adressées à une ligne d’annuaire à la maille suffixe (suffixe : ABCD01) :  

_Source: `c:\Users\g.baudrit\source\repos\gbaudrit\conf-aimer-votre-llm\demo\ctxc-sample-spec\with-ctxc\spec/dgfip/0- Dossier de specifications externes FE - Dossier général.pdf` (page:50/page:50)_

### E-affa2156b075

51 
Figure 25 - La création d'une nouvelle maille d'adressage 

La plateforme agréée de réception actualise donc les lignes d’annuaire de l’entreprise pour : 

• apposer une date de fin d’effet à chaque ligne d’annuaire en vigueur (la ligne d’annuaire du service
A) ;

• créer une ligne d’annuaire de type « masquage » pour chaque ligne d’annuaire dont la date de
début d’effet est postérieure à la date de réorganisation (la ligne d’annuaire des services B et C) ;

• créer une ligne d’annuaire de type « définition » à la maille suffixe qui rentrera en vigueur à la date
souhaitée.

La plateforme agréée de réception peut également, si c’est le souhait de l’entreprise, inactiver les services
A, B et C. 

Figure 26 - L'actualisation des lignes à la suite de la mise en place d'une nouvelle maille d'adressage  

_Source: `c:\Users\g.baudrit\source\repos\gbaudrit\conf-aimer-votre-llm\demo\ctxc-sample-spec\with-ctxc\spec/dgfip/0- Dossier de specifications externes FE - Dossier général.pdf` (page:51/page:51)_

### E-fc594b8bce4a

52 
3.5.6. Les contrôles fonctionnels des objets métiers du type ligne d’annuaire 

Si les contrôles techniques et applicatifs ne retournent aucune anomalie sur le flux (et les fichiers qu’il
contient), alors la bulle métier annuaire réalise des contrôles fonctionnels90 sur chaque fichier : 

• des contrôles sémantiques ;
• des contrôles de structure de données ; 
• des contrôles de cohérence de données ; 
• des contrôles d’unicité. 

3.5.7. Le cycle de vie des objets métiers du type ligne d’annuaire 

Le résultat des contrôles fonctionnels détermine le statut de chaque objet métier91 : 

• dès lors que le résultat des contrôles fonctionnels est en échec, alors l’objet métier est rejeté et
ne sera pas intégré ; 
• si les contrôles fonctionnels ne relèvent aucune anomalie, l’objet métier est accepté et intégré.   

Figure 27 - L'actualisation des lignes à la suite de la mise en place d'une nouvelle maille d'adressage 

Tout partenaire, raccordé en EDI, est informé via un cycle de vie du caractère accepté ou rejeté des
objets métiers qu’il a transmis. 

90 Ces contrôles sont décrits au travers de schematrons.

91 En l’occurrence, pour chaque actualisation de ligne d’annuaire. 

_Source: `c:\Users\g.baudrit\source\repos\gbaudrit\conf-aimer-votre-llm\demo\ctxc-sample-spec\with-ctxc\spec/dgfip/0- Dossier de specifications externes FE - Dossier général.pdf` (page:52/page:52)_

### E-cc2165320e97

53 
Objet Code Libellé Caractère Définition

Ligne d’annuaire 400 Acceptée Obligatoire  La ligne d’annuaire est contrôlée comme
conforme et intégrée.

Ligne d’annuaire 401 Rejetée Obligatoire  La ligne d’annuaire est contrôlée comme
non conforme et n’est pas intégrée.

Tableau 5 - Liste des statuts d'une ligne d’annuaire 

3.5.8. Les motifs de rejet des objets métiers du type ligne d’annuaire 

Le rejet d’un objet métier est associé à un ou plusieurs motifs, et la source des anomalies est indiquée,
afin de permettre au partenaire de réaliser les actions correctives adaptées.  Les motifs de rejet d’un
objet métier de type ligne d’annuaire sont :   

Code Libellé Description

REJ_RG Contrôle des règles de
gestion
L’une ou plusieurs règles de gestion ne sont pas
respectées.

REJ_HAB Contrôle des droits et
habilitations
L’une des requêtes n’est pas autorisée et/ou requiert
une habilitation.

REJ_COH
Contrôle de
cohérence des
données
L’une ou plusieurs données sont incohérentes.

REJ_VAL_INC Contrôle des valeurs
autorisées
L’une ou plusieurs valeurs sont incorrectes ou non
autorisées.

Tableau 6 – Liste des motifs de rejet d'une ligne d'annuaire 

3.6 La bulle e-invoicing

3.6.1.  Les principes directeurs 

Le dispositif de facturation en Y choisi dans le cadre de la réforme permet aux plateformes de
transmettre à l’administration fiscale, par l’intermédiaire du portail public de facturation, les données
réglementaires92 et les statuts obligatoires93 de factures électroniques pour les transactions domestiques
entre assujettis à la TVA établis, domiciliés ou ayant leur résidence habituelle en France. 

Le portail public de facturation assure le contrôle de ces données réglementaires et les statuts
obligatoires associés, puis les transmet à l’administration fiscale. 

3.6.2. La cartographie des flux 

Il existe différents types de flux qui interviennent lors de la transmission des données réglementaires et
des statuts obligatoires de facture à l’administration fiscale : 

92 Les mentions obligatoires d’une facture sont définies à l’article 242 nonies A de l’annexe II au CGI, et les données de
facture à transmettre à l’administration sont énumérées à l’article 41 septies D de l’annexe IV au CGI.
93 Le format sémantique du cycle de vie est décrit dans l’annexe 2. 

_Source: `c:\Users\g.baudrit\source\repos\gbaudrit\conf-aimer-votre-llm\demo\ctxc-sample-spec\with-ctxc\spec/dgfip/0- Dossier de specifications externes FE - Dossier général.pdf` (page:53/page:53)_

### E-d7ccbc4a0d5e

54 
• les flux e-invoicing (facture94, données réglementaires95) ;
• les flux de cycle de vie (flux96, données réglementaires et statuts obligatoires97). 

Figure 28 - La cartographie des flux e-invoicing et Cycle de vie échangés en B2B 

94 Le flux de factures électroniques (F2, F3) n’est pas transmis au PPF.
95 Les formats sémantiques des données obligatoires sont décrits dans l’annexe 1 des spécifications externes.
96 Cf. chapitre dédié 3.4.4.Le cycle de vie d’un flux
97 Cf. chapitre dédié 3.6.7.Le cycle de vie des objets métiers du type données réglementaires et statuts obligatoires
PPF
PAE
Fournisseur

PAR

Administration
fiscale
Acheteur

1 

Données Cycle de vie
Données E invoicing
Légende
1 

Proposé selon l offre de
services PA
2  7 2 2  7

7 7

_Source: `c:\Users\g.baudrit\source\repos\gbaudrit\conf-aimer-votre-llm\demo\ctxc-sample-spec\with-ctxc\spec/dgfip/0- Dossier de specifications externes FE - Dossier général.pdf` (page:54/page:54)_

### E-22b60236ff88

55 
Figure 29 - La cartographie des flux e-invoicing et Cycle de vie échangés en B2G, si Chorus Pro est la plateforme de réception  

_Source: `c:\Users\g.baudrit\source\repos\gbaudrit\conf-aimer-votre-llm\demo\ctxc-sample-spec\with-ctxc\spec/dgfip/0- Dossier de specifications externes FE - Dossier général.pdf` (page:55/page:55)_

### E-5e99699b1d36

56 
Figure 30 - La cartographie des flux e-invoicing et Cycle de vie échangés en B2G, si Chorus Pro est la plateforme d'émission et
réception 

3.6.3. Les données réglementaires d’une facture 

Les données réglementaires d’une facture soumise au champ d’application de la TVA respectent le
format sémantique de la norme EN16931, complété par des règles de gestion spécifiques à la législation
française98. De plus, pour couvrir l’ensemble des cas de gestion, des extensions à la norme EN16931 sont
prévues99. 

En raison de la mise en conformité progressive100 avec la réforme de facturation électronique, un socle
de données réglementaires de facture est exigé dès le démarrage101, et sera complété au moment de la
généralisation du dispositif. 

Ces données doivent être transmises à l’administration fiscale dans une archive tar.gz dans l’un des
formats structurés suivants : 
• UBL102 ;
• CII103. 

98 Le format sémantique des données réglementaires est décrit dans l’annexe 1.
99 Les extensions à la norme EN16931 sont identifiées dans l’annexe 1 par un libellé EXT-FR-FE-XXX.
100 Cf. le chapitre dédié 2.3.5.La mise en conformité progressive des assujettis à la TVA
101 A compter du 1er septembre 2026.
102 Le format UBL supporté par le portail public de facturation (PPF) est conforme à la norme OASIS U.B.L. 2.1.
103 Le format CII supporté par le portail public de facturation (PPF) est conforme à la norme UN/CEFACT CCTS 3.0. La version
de langage retenue dans le cadre de la réforme est le CII D22B. 

_Source: `c:\Users\g.baudrit\source\repos\gbaudrit\conf-aimer-votre-llm\demo\ctxc-sample-spec\with-ctxc\spec/dgfip/0- Dossier de specifications externes FE - Dossier général.pdf` (page:56/page:56)_

### E-d338a7a968ea

57 
3.6.4. Les statuts obligatoires d’une facture 

La transmission et la mise à jour du statut des factures tout au long de son cycle de vie sont essentielles
pour répondre aux enjeux et atteindre les objectifs fixés par la réforme. Le cycle de vie104 d’une facture
permet à chacun des acteurs impliqués (fournisseurs, acheteurs, plateformes agréées, portail public de
facturation et administration fiscale) de suivre l’avancement du traitement des factures dans le circuit
de facturation, du dépôt de la facture jusqu’à son encaissement. Ces données sont transmises à
l’administration fiscale dans le format structuré CDAR105. 

Le cycle de vie répond aux principes fondateurs suivants :   

• offrir une vision partagée du traitement de la facture pour l’ensemble des acteurs intéressés
(émetteur, récepteur, administration et tous les tiers référencés dans la facture) ; 
• déterminer une liste et un format d’échange des statuts permettant d’assurer l’interopérabilité
entre les acteurs (entreprises, plateformes agréées, portail public de facturation) ; 
• favoriser une qualité de service pour assurer le respect de la chronologie du traitement d’une
facture ; 
• définir des règles strictes et faciliter le pré-remplissage de la déclaration de la TVA. 

Le cycle de vie repose sur deux périmètres imbriqués : 

• un socle de statuts obligatoires106 nécessaires à l’administration et à tous les acteurs de la chaîne
de facturation ; 
• un socle de statuts facultatifs qui ne doivent pas être transmis à l’administration fiscale, mais qui
sont recommandés pour assurer le bon déroulé des échanges acteurs de la chaîne de facturation. 

Figure 31 - Le cycle de vie nominal d'une facture 

Les statuts possibles d’un cycle de vie sont :   

104 Le format sémantique du cycle de vie est décrit dans l’annexe 2 des spécifications externes.
105 Le format CDAR supporté par le portail public de facturation (PPF) est UN/CEFACT SCRDM CI Cross Domain Application
Response message.
106 Lorsqu’ils sont apposés par l’un des acteurs du circuit de facturation.  

_Source: `c:\Users\g.baudrit\source\repos\gbaudrit\conf-aimer-votre-llm\demo\ctxc-sample-spec\with-ctxc\spec/dgfip/0- Dossier de specifications externes FE - Dossier général.pdf` (page:57/page:57)_

### E-432db0f85a9a

[{"extraction_method":"lattice","top":773.569838,"left":48.531429,"width":495.95210299999997,"height":654.344879,"right":544.483532,"bottom":119.224959,"data":[[{"top":773.569838,"left":48.531429,"width":91.88685699999999,"height":6.765838000000031,"text":""},{"top":773.569838,"left":140.418286,"width":49.59061199999999,"height":6.765838000000031,"text":""},{"top":773.569838,"left":190.008898,"width":78.001102,"height":6.765838000000031,"text":""},{"top":773.569838,"left":268.01,"width":63.85583700000001,"height":6.765838000000031,"text":""},{"top":773.569838,"left":331.865837,"width":212.61769499999997,"height":6.765838000000031,"text":""}],[{"top":766.804,"left":48.531429,"width":91.88685699999999,"height":13.823999999999955,"text":"Objet"},{"top":766.804,"left":140.418286,"width":49.59061199999999,"height":13.823999999999955,"text":"Code"},{"top":766.804,"left":190.008898,"width":78.001102,"height":13.823999999999955,"text":"Libellé"},{"top":766.804,"left":268.01,"width":63.85583700000001,"height":13.823999999999955,"text":"Caractère"},{"top":766.804,"left":331.865837,"width":212.61769499999997,"height":13.823999999999955,"text":"Définition"}],[{"top":752.98,"left":48.531429,"width":91.88685699999999,"height":6.689231000000063,"text":""},{"top":752.98,"left":140.418286,"width":49.59061199999999,"height":6.689231000000063,"text":""},{"top":752.98,"left":190.008898,"width":78.001102,"height":6.689231000000063,"text":""},{"top":752.98,"left":268.01,"width":63.85583700000001,"height":6.689231000000063,"text":""},{"top":752.98,"left":331.865837,"width":212.61769499999997,"height":6.689231000000063,"text":""}],[{"top":746.290769,"left":48.531429,"width":91.88685699999999,"height":56.07076899999993,"text":"Facture"},{"top":746.290769,"left":140.418286,"width":49.59061199999999,"height":56.07076899999993,"text":"200"},{"top":746.290769,"left":190.008898,"width":78.001102,"height":56.07076899999993,"text":"Déposée"},{"top":746.290769,"left":268.01,"width":63.85583700000001,"height":56.07076899999993,"text":"Obligatoire"},{"top":746.290769,"left":331.865837,"width":212.61769499999997,"height":56.07076899999993,"text":"La facture du fournisseur est transmise à\rsa plateforme agréée d’émission (PAE), qui\rattestequelafactureestcontrôléeet\rconforme."}],[{"top":690.22,"left":48.531429,"width":91.88685699999999,"height":55.92005000000006,"text":"Facture"},{"top":690.22,"left":140.418286,"width":49.59061199999999,"height":55.92005000000006,"text":"201"},{"top":690.22,"left":190.008898,"width":78.001102,"height":55.92005000000006,"text":"Emise par la\rplateforme"},{"top":690.22,"left":268.01,"width":63.85583700000001,"height":55.92005000000006,"text":"Facultatif"},{"top":690.22,"left":331.865837,"width":212.61769499999997,"height":55.92005000000006,"text":"Laplateformeagrééed’émission(PAE)\rinformeavoirtransmislafactureàla\rplateforme agréée de réception (PAR) du\rdestinataire."}],[{"top":634.29995,"left":48.531429,"width":91.88685699999999,"height":42.12100899999996,"text":"Facture"},{"top":634.29995,"left":140.418286,"width":49.59061199999999,"height":42.12100899999996,"text":"202"},{"top":634.29995,"left":190.008898,"width":78.001102,"height":42.12100899999996,"text":"Reçue par la\rplateforme"},{"top":634.29995,"left":268.01,"width":63.85583700000001,"height":42.12100899999996,"text":"Facultatif"},{"top":634.29995,"left":331.865837,"width":212.61769499999997,"height":42.12100899999996,"text":"La plateforme agréée de réception (PAR)\rinforme avoir reçu la facture de la part de\rla plateforme agréée d’émission (PAE)."}],[{"top":592.178941,"left":48.531429,"width":91.88685699999999,"height":42.148972999999955,"text":"Facture"},{"top":592.178941,"left":140.418286,"width":49.59061199999999,"height":42.148972999999955,"text":"203"},{"top":592.178941,"left":190.008898,"width":78.001102,"height":42.148972999999955,"text":"Mise à\rdisposition"},{"top":592.178941,"left":268.01,"width":63.85583700000001,"height":42.148972999999955,"text":"Facultatif"},{"top":592.178941,"left":331.865837,"width":212.61769499999997,"height":42.148972999999955,"text":"La plateforme agréée de réception (PAR)\rinforme avoir mis à disposition la facture\rà son destinataire."}],[{"top":550.029968,"left":48.531429,"width":91.88685699999999,"height":33.0,"text":"Facture"},{"top":550.029968,"left":140.418286,"width":49.59061199999999,"height":33.0,"text":"204"},{"top":550.029968,"left":190.008898,"width":78.001102,"height":33.0,"text":"Prise en charge"},{"top":550.029968,"left":268.01,"width":63.85583700000001,"height":33.0,"text":"Facultatif"},{"top":550.029968,"left":331.865837,"width":212.61769499999997,"height":33.0,"text":"Ledestinataireaccuseréceptiondela\rfacture."}],[{"top":517.029968,"left":48.531429,"width":91.88685699999999,"height":32.88000000000005,"text":"Facture"},{"top":517.029968,"left":140.418286,"width":49.59061199999999,"height":32.88000000000005,"text":"205"},{"top":517.029968,"left":190.008898,"width":78.001102,"height":32.88000000000005,"text":"Approuvée"},{"top":517.029968,"left":268.01,"width":63.85583700000001,"height":32.88000000000005,"text":"Facultatif"},{"top":517.029968,"left":331.865837,"width":212.61769499999997,"height":32.88000000000005,"text":"Le destinataire acceptelafacture dans\rson intégralité."}],[{"top":484.149968,"left":48.531429,"width":91.88685699999999,"height":33.0,"text":"Facture"},{"top":484.149968,"left":140.418286,"width":49.59061199999999,"height":33.0,"text":"206"},{"top":484.149968,"left":190.008898,"width":78.001102,"height":33.0,"text":"Approuvée\rpartiellement"},{"top":484.149968,"left":268.01,"width":63.85583700000001,"height":33.0,"text":"Facultatif"},{"top":484.149968,"left":331.865837,"width":212.61769499999997,"height":33.0,"text":"Ledestinatairen’accepteque\rpartiellement la facture."}],[{"top":451.149968,"left":48.531429,"width":91.88685699999999,"height":32.99929400000002,"text":"Facture"},{"top":451.149968,"left":140.418286,"width":49.59061199999999,"height":32.99929400000002,"text":"207"},{"top":451.149968,"left":190.008898,"width":78.001102,"height":32.99929400000002,"text":"En litige"},{"top":451.149968,"left":268.01,"width":63.85583700000001,"height":32.99929400000002,"text":"Facultatif"},{"top":451.149968,"left":331.865837,"width":212.61769499999997,"height":32.99929400000002,"text":"Le destinataire est en désaccord avec tout\rou partie de la facture."}],[{"top":418.150674,"left":48.531429,"width":91.88685699999999,"height":55.94072399999999,"text":"Facture"},{"top":418.150674,"left":140.418286,"width":49.59061199999999,"height":55.94072399999999,"text":"208"},{"top":418.150674,"left":190.008898,"width":78.001102,"height":55.94072399999999,"text":"Suspendue"},{"top":418.150674,"left":268.01,"width":63.85583700000001,"height":55.94072399999999,"text":"Facultatif"},{"top":418.150674,"left":331.865837,"width":212.61769499999997,"height":55.94072399999999,"text":"Ledestinatairesouhaiteobtenirdes\rpièces justificatives complémentaires et\rsuspendletraitementdelafacture\rjusqu’à leur réception."}],[{"top":362.20995,"left":48.531429,"width":91.88685699999999,"height":42.11996799999997,"text":"Facture"},{"top":362.20995,"left":140.418286,"width":49.59061199999999,"height":42.11996799999997,"text":"209"},{"top":362.20995,"left":190.008898,"width":78.001102,"height":42.11996799999997,"text":"Complétée"},{"top":362.20995,"left":268.01,"width":63.85583700000001,"height":42.11996799999997,"text":"Facultatif"},{"top":362.20995,"left":331.865837,"width":212.61769499999997,"height":42.11996799999997,"text":"Lefournisseurfournitdespièces\rjustificatives complémentaires attendues\rpar le destinataire de la facture."}],[{"top":320.089982,"left":48.531429,"width":91.88685699999999,"height":32.999982000000045,"text":"Facture"},{"top":320.089982,"left":140.418286,"width":49.59061199999999,"height":32.999982000000045,"text":"210"},{"top":320.089982,"left":190.008898,"width":78.001102,"height":32.999982000000045,"text":"Refusée"},{"top":320.089982,"left":268.01,"width":63.85583700000001,"height":32.999982000000045,"text":"Obligatoire"},{"top":320.089982,"left":331.865837,"width":212.61769499999997,"height":32.999982000000045,"text":"Le destinataire refuse la facture dans son\rintégralité."}],[{"top":287.09,"left":48.531429,"width":91.88685699999999,"height":55.92109099999996,"text":"Facture"},{"top":287.09,"left":140.418286,"width":49.59061199999999,"height":55.92109099999996,"text":"211"},{"top":287.09,"left":190.008898,"width":78.001102,"height":55.92109099999996,"text":"Paiement\rtransmis"},{"top":287.09,"left":268.01,"width":63.85583700000001,"height":55.92109099999996,"text":"Facultatif"},{"top":287.09,"left":331.865837,"width":212.61769499999997,"height":55.92109099999996,"text":"Ledestinataireinformeavoirréaliséle\rpaiement de la facture, ou le fournisseur\rinforme avoir réalisé le remboursement\rde la facture."}],[{"top":231.168909,"left":48.531429,"width":91.88685699999999,"height":56.06890900000002,"text":"Facture"},{"top":231.168909,"left":140.418286,"width":49.59061199999999,"height":56.06890900000002,"text":"212"},{"top":231.168909,"left":190.008898,"width":78.001102,"height":56.06890900000002,"text":"Encaissée"},{"top":231.168909,"left":268.01,"width":63.85583700000001,"height":56.06890900000002,"text":"Obligatoire"},{"top":231.168909,"left":331.865837,"width":212.61769499999997,"height":56.06890900000002,"text":"Selon les conditions définies par l’article\r290 A du CGI, le fournisseur informe avoir\rperçu un paiement partiel ou total de la\rfacture."}],[{"top":175.1,"left":48.531429,"width":91.88685699999999,"height":55.875040999999996,"text":"Facture"},{"top":175.1,"left":140.418286,"width":49.59061199999999,"height":55.875040999999996,"text":"213"},{"top":175.1,"left":190.008898,"width":78.001102,"height":55.875040999999996,"text":"Rejetée"},{"top":175.1,"left":268.01,"width":63.85583700000001,"height":55.875040999999996,"text":"Obligatoire"},{"top":175.1,"left":331.865837,"width":212.61769499999997,"height":55.875040999999996,"text":"L’undescontrôlesfonctionnelsréalisés\rpar la plateforme agréée d’émission (PAE)\rouderéception(PAR)adétectéune\ranomalie sur la facture."}]]}]


_Source: `c:\Users\g.baudrit\source\repos\gbaudrit\conf-aimer-votre-llm\demo\ctxc-sample-spec\with-ctxc\spec/dgfip/0- Dossier de specifications externes FE - Dossier général.pdf` (page:58/page:58)_

### E-14d66b71fada

59 
Tableau 7 - Les statuts d'une facture

Dans les cas des statuts « Refusée » ou « Rejetée », le fournisseur doit procéder à une annulation
comptable (avoir interne). Cette opération ne doit pas générer de flux de données réglementaires (F1)
au PPF. 

3.6.5. Délai de transmission des flux de cycle de vie de statuts obligatoires 

Afin de faciliter l’intégration des flux de cycle de vie (statuts obligatoires) dans le portail public de
facturation (PPF) et leur prise en compte par l’administration fiscale, les plateformes agréées (PAE ou PAR)
les adressent au portail public de facturation (PPF) dans un délai de 24h à compter de l’horodatage du
statut. 

3.6.6. Les contrôles fonctionnels des données réglementaires et des statuts obligatoires 

Si les contrôles techniques et applicatifs ne retournent aucune anomalie sur le flux (et les fichiers qu’il
contient), alors la bulle métier e-invoicing va réaliser des contrôles fonctionnels107 sur chaque fichier108 :
• des contrôles sémantiques109 ;
• des contrôles de structure de données 110 ;
• des contrôles de cohérence de données 111 ;
• des contrôles d’unicité112. 

3.6.7. Le cycle de vie des objets métiers du type données réglementaires et statuts obligatoires 

Le résultat des contrôles fonctionnels détermine le statut de chaque objet métier113 :

• dès lors que le résultat des contrôles fonctionnels est en échec, alors l’objet métier est rejeté et
ne sera pas intégré ; 
• si les contrôles fonctionnels ne relèvent aucune anomalie, l’objet métier est accepté et intégré.   

107 Ces contrôles sont décrits au travers de schematrons.
108 Chaque fichier est « mono-objet », c’est à dire qu’il ne contient qu’un objet métier.
109 Contrôles des règles de gestion de la norme européenne (EN16931) et celles spécifiques à la réforme française de
facturation électronique.
110 Contrôles des longueurs maximales.
111 Contrôles de cohérences avec les valeurs des référentiels mentionnées dans l’annexe 7 des spécifications externes.
112 Le contrôle de l’unicité est réalisé uniquement sur les données réglementaires de facture. L’unicité est déterminée à partir
du numéro de facture, de l’identifiant du fournisseur (SIREN) et de l’année de production de la facture.
113 En l’occurrence, pour chaque donnée réglementaire et chaque donnée de cycle de vie. 

_Source: `c:\Users\g.baudrit\source\repos\gbaudrit\conf-aimer-votre-llm\demo\ctxc-sample-spec\with-ctxc\spec/dgfip/0- Dossier de specifications externes FE - Dossier général.pdf` (page:59/page:59)_

### E-bb3f406e6a1d

60 
Figure 32- Le cycle de vie d’un objet métier 

Tout partenaire est informé via un cycle de vie, du caractère accepté ou rejeté des objets métiers qu’il
a transmis. 

Objet Code Libellé Caractère Définition

Données
réglementaires 250 Déposée Obligatoire 
Les données réglementaires sont
contrôlées comme conformes et
transmises à l’administration fiscale.

Données
réglementaires 251 Rejetée Obligatoire
Les données réglementaires sont
contrôlées comme non conformes,
elles ne sont pas intégrées et ne sont
pas transmises à l’administration
fiscale114.

Tableau 8 - Liste des statuts de données réglementaires 

Objet Code Libellé Caractère Définition

Statuts
obligatoires 601 Rejeté Obligatoire
Les statuts obligatoires sont contrôlés
comme non conformes et ne sont pas
intégrés.

Tableau 9 - Liste des statuts des données de cycle de vie d'une facture 

3.6.8. Les motifs de rejet des objets métiers du type données réglementaires 

114 Seule l’information du rejet avec le numéro de facture, l’année d’émission de la facture et le SIREN du vendeur sont
transmises à l’administration fiscale. 

_Source: `c:\Users\g.baudrit\source\repos\gbaudrit\conf-aimer-votre-llm\demo\ctxc-sample-spec\with-ctxc\spec/dgfip/0- Dossier de specifications externes FE - Dossier général.pdf` (page:60/page:60)_

### E-2dc711d84524

61 
À la suite de la transmission de données réglementaires d’une plateforme au PPF, celui-ci peut les rejeter
en définissant un ou plusieurs motifs. La source des anomalies est indiquée, afin de permettre au
partenaire de réaliser les actions correctives adaptées. 

Les motifs de rejet des données réglementaires sont :   

Code Libellé Description

REJ_SEMAN Contrôle du format
sémantique
Le format sémantique d’une ou plusieurs données
n’est pas conforme.

REJ_UNI Contrôle d’unicité Les données réglementaires ont déjà été transmises et
traitées.

REJ_COH
Contrôle de
cohérence des
données
L’une ou plusieurs données sont incohérentes.

Tableau 10 - Liste des motifs de rejet de données réglementaires 

Plusieurs facteurs peuvent expliquer le rejet de données réglementaires : 

• Premier cas : le rejet relève d’anomalies lors de la constitution du fichier de données
réglementaires à partir d’une facture conforme.

La plateforme agréée d’émission peut alors générer à nouveau le fichier de données
réglementaires corrigé (portant alors le même numéro de facture) pour transmission au PPF. 

• Deuxième cas : le rejet relève d’anomalies fonctionnelles au niveau des données de la facture
(F2) dont les données sont issues. L’entreprise doit être informée de ce rejet, avec les motifs
fonctionnels associés, et doit effectuer une analyse de ce rejet afin de prendre les mesures
nécessaires (mise en œuvre d’une génération de numéro de facture conforme, correction des
anomalies au niveau du système d’information facturier, …). 

3.6.9. Les motifs de rejet des objets métiers du type statuts obligatoires 

Le rejet de statuts obligatoires est associé à un ou plusieurs motifs, et l’emplacement des anomalies est
indiqué, afin de permettre au partenaire de réaliser les actions correctives adaptées. Les motifs de rejet
des statuts obligatoires sont :   

Code Libellé Description

REJ_INC Contrôle de
cohérence des statuts L’un ou plusieurs statuts sont incohérents. 

REJ_INEX Contrôle de
conformité des statuts
L’un ou plusieurs statuts sont incorrects ou non
autorisés.

REJ_RG  Contrôle des règles de
gestion
L’une ou plusieurs règles de gestion ne sont pas
respectées.

REJ_HAB Contrôle des droits et
habilitations
L’une des requêtes n’est pas autorisée et/ou requiert
une habilitation.

REJ_ENCAISSEMENT Contrôle des
encaissements
L’un ou plusieurs montants encaissés ne sont pas
conformes à la répartition par taux de TVA déclarée.
Tableau 11 - Liste des motifs de rejet de statuts obligatoires   

_Source: `c:\Users\g.baudrit\source\repos\gbaudrit\conf-aimer-votre-llm\demo\ctxc-sample-spec\with-ctxc\spec/dgfip/0- Dossier de specifications externes FE - Dossier général.pdf` (page:61/page:61)_

### E-1926c302ac13

62 
3.7 La bulle e-reporting

3.7.1.  Les principes directeurs 

Le dispositif prévoit que les plateformes agréées (PAE et PAR) transmettent à l’administration fiscale les
données réglementaires115 des opérations internationales entre entreprises116 (B2Bi, Bi2B et Bi2Bi) et/ou
d’opérations avec particulier ou d’une personne morale privée non assujettie117 (B2C). Il est en outre
prévu que les plateformes transmettent les données de paiement118 attendues. Le portail public de
facturation (PPF) assure le contrôle de ces données réglementaires, puis les transmet à l’administration
fiscale. 

3.7.2. La cartographie des flux 

Il existe différents types de flux qui interviennent lors de la transmission des données réglementaires et
des statuts obligatoires de facture à l’administration fiscale : 

• les flux e-reporting (données de transaction et de paiement, factures et statuts obligatoires) ;

• les flux de cycle de vie (flux119, données de transaction et de paiement120). 

Figure 33 - La cartographie des flux e-reporting et Cycle de vie échangés 

115 Les données réglementaires sont définies à l’article 290 du CGI. 
116 Les opérations concernées sont celles effectuées à destination ou en provenance d’une personne morale assujettie non
établie en France (liste définie à l’article 290-I du CGI), ainsi que les opérations entre assujettis non établis en France qui
sont soumises à la TVA en France (article 290-II du CGI).
117 Par exemple, une association.
118 Les données réglementaires sont définies à l’article 290 A du CGI. 
119 Cf. chapitre dédié 3.4.4.Le cycle de vie d’un flux
120 Cf. chapitre dédié 3.7.9. 

_Source: `c:\Users\g.baudrit\source\repos\gbaudrit\conf-aimer-votre-llm\demo\ctxc-sample-spec\with-ctxc\spec/dgfip/0- Dossier de specifications externes FE - Dossier général.pdf` (page:62/page:62)_

### E-bb1894e12cd7

63 
Le flux de transmission des données de transaction et de paiement (F10) est le format121 conçu pour
assurer les échanges entre les plateformes agréées (PAE et PAR), le portail public de facturation  et
l’administration fiscale. 

Le flux de transmission (F10) est composé de 4 blocs, qui permettent de véhiculer différents types de
données. 

Figure 34 - La structure d'un flux de transmission (F10) 

En fonction de leur offre de services, les plateformes agréées peuvent accepter et s’échanger des flux
de factures électroniques et leurs statuts, relevant d’opérations interentreprises internationales (B2Bi,
Bi2B et Bi2Bi) et/ou d’opérations auprès de non-assujettis (B2C), et les traiter de manière analogue aux
factures électroniques des opérations interentreprises domestiques (B2B). 

Figure 35 - La structure d'un flux de transmission (F10) 

121 Fichier au format XML. 

_Source: `c:\Users\g.baudrit\source\repos\gbaudrit\conf-aimer-votre-llm\demo\ctxc-sample-spec\with-ctxc\spec/dgfip/0- Dossier de specifications externes FE - Dossier général.pdf` (page:63/page:63)_

### E-5b276d260dd2

64 
Dans ce cas, les plateformes agréées ont l’obligation d’exploiter les flux (F8, F9 et F6) pour constituer le
flux de transmission de données de transaction et de paiement (F10), en amont de leur émission au
portail public de facturation (PPF). 

Figure 36 - Exploitation des flux de factures (B2Bi, Bi2B et Bi2Bi) et leurs statuts pour constituer un flux de transmission 

Figure 37 - Exploitation des flux de factures (B2C) et leurs statuts pour constituer un flux de transmission 

3.7.3. Les données de facture d’opérations internationales 

Le bloc de données de facture (10.1) permet de transmettre à l’administration les données des
opérations internationales entre entreprises122 (B2Bi, Bi2B et Bi2Bi) ayant donné lieu à une facture (F8).
Chaque occurrence du bloc de données de facture (10.1) correspond à une unique facture. 

3.7.4. Les données de paiement des factures des opérations internationales 

Le bloc de données de paiement de facture (10.2) permet de transmettre à l’administration les données
de paiement (statut « Encaissée » - F6) d’opérations123 internationales entre entreprises (B2Bi, Bi2B et
Bi2Bi) ayant donné lieu à une facture124. Chaque occurrence du bloc de données de facture (10.2)
correspond à l’encaissement d’une unique facture. 

122 Les opérations auprès de non-assujettis (B2C) doivent être transmises via le bloc de données de transaction (10.3),
qu’elles aient fait l’objet d’une facture (F9) ou non.
123 Les données de paiement ne doivent être transmises qu’en cas de prestations de services, hors opérations donnant lieu
à autoliquidation de la TVA et option de TVA sur les débits.
124 Les opérations avec des non-assujettis (B2C) doivent être transmises via le bloc de données de transaction (10.3), qu’elles
aient fait l’objet d’une facture électronique (F9) ou non. 

_Source: `c:\Users\g.baudrit\source\repos\gbaudrit\conf-aimer-votre-llm\demo\ctxc-sample-spec\with-ctxc\spec/dgfip/0- Dossier de specifications externes FE - Dossier général.pdf` (page:64/page:64)_

### E-bccf81b26d8e

65 
3.7.5. Les données des opérations avec des non-assujettis   

Le bloc de données de transaction (10.3) permet de transmettre à l’administration les données des
opérations auprès de non-assujettis (B2C) qu’elles aient fait l’objet d’une facture électronique (de type
F9) ou non. 

Chaque occurrence du bloc de données de transaction (10.3) correspond à un jour d’activité, une devise
et un type de transaction. En effet, le bloc de données de transaction (10.3) permet de transmettre les
données agrégées de l’ensemble des transactions quotidiennes réalisées125, et éventuellement les
compléter des données de transaction relevant d’opération auprès de non-assujettis (B2C) ayant fait
l’objet de factures (de type F9) émises le même jour. 

3.7.6. Les données de paiement des opérations avec des non-assujettis   

Le bloc de données de paiement de transaction (10.4) permet de transmettre à l’administration les
données à l’encaissement des opérations avec des non-assujettis (B2C), qu’elles aient fait l’objet d’une
facture (de type F9) ou non. Chaque occurrence du bloc de données de transaction (10.4) correspond à
un jour d’activité. En effet, le bloc de données de paiement de transaction (10.4) permet de transmettre
l’ensemble des encaissements perçus126 au titre d’une journée. 

3.7.7. Les modalités de transmission 

Les plateformes agréées doivent transmettre au portail public de facturation (PPF) les données de
transaction et de paiement (F10) agrégées :
• par déclarant127, à la maille SIREN et selon son rôle dans l’opération ;
• par période de transmission, déterminée à partir du régime de TVA du déclarant128 et en fonction
de la date de l’opération129. 

125 Peut correspondre aux données d’un récapitulatif journalier édité par un système de caisse, dit « ticket Z » ou « Z de
caisse »
126 Le bloc de données de paiement peut être utilisé pour déclarer un paiement perçu en amont de son rapprochement avec
la facture correspondante. Lorsque ce rapprochement est réalisé, alors la déclaration des encaissements perçus doit être
rectifiée (10.4), et le paiement de la facture doit être transmis via un cycle de vie de factures (F6), ou via le bloc de données
de paiement de facture (10.3) s’il s’agit d’une facture relevant d’opérations interentreprises internationales (B2Bi, Bi2B,
Bi2Bi).
127 Le déclarant est l’acteur de l’opération qui est assujetti à la TVA française. En fonction des cas, le déclarant peut être le
fournisseur (B2Bi, Bi2Bi, B2C) ou l’acheteur (Bi2B).
128 Les délais et fréquences de transmission des données de transactions et de paiement ont été précisés dans les textes
réglementaires en date du 7 octobre 2022 publiés le 9 octobre 2022 (impots.gouv.fr)
129 Le fait générateur de la transmission des données de transaction est la date de réalisation de l’opération, et celui de la
transmission des données de paiement est la date d’encaissement du paiement (hors paiement par chèque bancaire et autres
cas prévus dans la doctrine administrative BOI TVA BASE 20 20).  

_Source: `c:\Users\g.baudrit\source\repos\gbaudrit\conf-aimer-votre-llm\demo\ctxc-sample-spec\with-ctxc\spec/dgfip/0- Dossier de specifications externes FE - Dossier général.pdf` (page:65/page:65)_

### E-f9d47a74679c

66 
Figure 38 - Exploitation des flux de factures (B2C) et leurs statuts pour constituer un flux de transmission 

Données de facture et de transaction Données de paiement 

Période Délai
Date limite de
transmission à
l’administration
fiscale
Période Délai
Date limite de
transmission à
l’administration
fiscale

Régime réel
normal mensuel
Décade :
- du 1 au 10 du
mois
- du 11 au 20
du mois
- du 21 à la fin
du mois
10 jours après
la fin de la
période :
- le 20 du mois
- la fin du mois
- le 10 du mois
suivant
- 1ère décade : le 21
du mois à 8h00
- 2ème décade : le
1er du mois suivant
à 8h00
- 3ème décade : le
11 du mois suivant à
8h00
Mensuelle  Le 10 du mois
suivant
Le 11 du mois
suivant à 8h00 

Régime réel
normal
trimestriel
Mensuelle  Le 10 du mois
suivant
Le 11 du mois
suivant à 8h00 Mensuelle  Le 10 du mois
suivant
Le 11 du mois
suivant à 8h00

Régime simplifié
d’imposition
TVA
Mensuelle
Entre le 25 et
30 du mois
suivant
Le 1er du deuxième
mois à venir, à 8h00 Mensuelle
Entre le 25 et
30 du mois
suivant
Le 1er du
deuxième mois
à venir, à 8h00

Régime de 
de TVA
Bimestrielle
(tous les
bimestres
civils)130
Entre le 25 et
30 du mois
suivant
Le 1er du deuxième
mois à venir, à 8h00
Bimestrielle
(tous les
bimestres
civils)
Entre le 25 et
30 du mois
suivant
Le 1er du
deuxième mois
à venir, à 8h00

Tableau 12 - Les périodes de transmission par régime de TVA 

130 Les bimestres civils commencent à l’une des dates suivantes : 1er janvier, 1er mars, 1er mai, 1er juillet, 1er septembre et
1er novembre.  

_Source: `c:\Users\g.baudrit\source\repos\gbaudrit\conf-aimer-votre-llm\demo\ctxc-sample-spec\with-ctxc\spec/dgfip/0- Dossier de specifications externes FE - Dossier général.pdf` (page:66/page:66)_

### E-c00194e9d818

67 
Pour certains régimes de TVA, les périodes de transmission des données de transaction sont différentes
des périodes de transmission des données de paiement. De ce fait, les plateformes agréées doivent
transmettre au portail public de facturation (PPF) les données de transaction et de paiement (F10) de
manière distincte, à l’issue des périodes correspondantes à chaque type de données. 

Figure 39 - Transmission distinctes des données de facture et transaction des données de paiement 

En cas d’erreur sur des données de transaction ou de paiement transmises au titre d’une période, la
plateforme agréée peut transmettre un flux de transmission rectificatif (type RE) au portail public de
facturation (PPF). Ce flux de transmission rectificatif annule et remplace l’ensemble des données
agrégées131 et précédemment transmises au titre de cette période. 

131 Distinguées par type de données et en fonction du rôle du déclarant. 

_Source: `c:\Users\g.baudrit\source\repos\gbaudrit\conf-aimer-votre-llm\demo\ctxc-sample-spec\with-ctxc\spec/dgfip/0- Dossier de specifications externes FE - Dossier général.pdf` (page:67/page:67)_

### E-0f65dfb16e03

68 
Figure 40 - Les modalités de rectification d'une transmission au titre d’une période révolue 

Afin de faciliter l’intégration des flux de transmission dans le portail public de facturation (PPF) et leur
prise en compte par l’administration fiscale, les plateformes agréées les adressent au portail public de
facturation (PPF) dans un délai de 8h à l’issue du dernier jour du délai de dépôt au titre de la période. 

3.7.8. Les contrôles fonctionnels des données de transaction et de paiement 

Si les contrôles techniques et applicatifs ne retournent aucune anomalie sur le flux (et les fichiers qu’il
contient), alors la bulle métier e-reporting va réaliser des contrôles fonctionnels132 sur chaque fichier133 : 

• des contrôles sémantiques134 ;
• des contrôles de structure de données ; 
• des contrôles de cohérence de données ; 
• des contrôles d’unicité135. 

132 Ces contrôles sont décrits au travers de schematrons
133 Chaque fichier est « mono-objet », c’est à dire qu’il ne contient qu’un objet métier.
134 Contrôles des règles de gestion de la norme européenne (EN16931) et celles spécifiques à la réforme française de
facturation électronique.
135 L’unicité est déterminée à partir du numéro de transmission, de l’identifiant du déclarant (SIREN) et de la période de la
transmission. 

_Source: `c:\Users\g.baudrit\source\repos\gbaudrit\conf-aimer-votre-llm\demo\ctxc-sample-spec\with-ctxc\spec/dgfip/0- Dossier de specifications externes FE - Dossier général.pdf` (page:68/page:68)_

### E-6e8868f0c846

69 
3.7.9. Le cycle de vie des données de transaction et de paiement 

Le résultat des contrôles fonctionnels détermine le statut de chaque objet métier136 :

• dès lors que le résultat des contrôles fonctionnels est en échec, alors l’objet métier est rejeté et
ne sera pas intégré ; 
• si les contrôles fonctionnels ne relèvent aucune anomalie, l’objet métier est accepté et intégré.   

Figure 41 - Le cycle de vie d’un objet métier 

Toute plateforme est informée via un cycle de vie, du caractère accepté ou rejeté des objets métiers
qu’elle a transmis. 

Objet Code Libellé Caractère Définition
Données de
transaction et
paiement
300 Déposée Obligatoire 
Les données sont contrôlées comme
conformes par le PPF et transmises à
l’administration fiscale.
Données de
transaction et
paiement
301 Rejetée Obligatoire
Les données sont contrôlées comme
non conformes par le PPF et ne sont pas
transmises à l’administration fiscale.

Tableau 13 - Liste des statuts de données de transaction et de paiement 

3.7.10. Les motifs de rejet des objets métiers du type données de transaction et de paiement 

Le rejet de données de transaction et de paiement est associé à un ou plusieurs motifs, et la source des
anomalies est indiquée, afin de permettre à la plateforme agréée de réaliser les actions correctives
adaptées.     

136 En l’occurrence, pour chaque transmission de données de transaction et de paiement. 

_Source: `c:\Users\g.baudrit\source\repos\gbaudrit\conf-aimer-votre-llm\demo\ctxc-sample-spec\with-ctxc\spec/dgfip/0- Dossier de specifications externes FE - Dossier général.pdf` (page:69/page:69)_

### E-6f7247da093d

70 
Les motifs de rejet des données de transaction et de paiement sont :   

Code Libellé Description

REJ_SEMAN Contrôle du format
sémantique
Le format sémantique d’une ou plusieurs données
n’est pas conforme.

REJ_UNI Contrôle d’unicité Les données ont déjà été transmises et traitées.

REJ_COH
Contrôle de
cohérence des
données
L’une ou plusieurs données sont incohérentes.

REJ_PER Contrôle de période La date de la transmission de données n’est pas
cohérente avec la période déclarée.

Tableau 14 - Liste des motifs de rejet de données de transaction et de paiement  

_Source: `c:\Users\g.baudrit\source\repos\gbaudrit\conf-aimer-votre-llm\demo\ctxc-sample-spec\with-ctxc\spec/dgfip/0- Dossier de specifications externes FE - Dossier général.pdf` (page:70/page:70)_

### E-5e64a9d5f0cb

71 
4 Table des figures

Figure 1 - Le circuit B2B .......................................................................................................................... 13
Figure 2 - La mise en place d’un raccordement au portail public de facturation (PPF) ........................................ 28
Figure 3 - Cinématique des flux F13 .......................................................................................................... 35
Figure 4 - Cinématique des flux F14 .......................................................................................................... 35
Figure 5 - La cartographie des flux Annuaire échangés ................................................................................. 37
Figure 6 - Les sources d'initialisation de l'annuaire ...................................................................................... 38
Figure 7 - La consultation de l'annuaire pour l'adressage et le routage de facture ............................................ 40
Figure 8 - Page d'accueil du Portail Annuaire ( https://facturation.chorus-pro.gouv.fr/annuaire/#/ ) ................... 41
Figure 9 - Exemple d'écran de consultation du Portail Annuaire ..................................................................... 42
Figure 10 - L'actualisation de l'annuaire par le référentiel des occurrences fiscales ........................................... 43
Figure 11 - La création d’une ligne d'annuaire pour une entreprise nouvellement assujettie ............................... 43
Figure 12 - L'actualisation des lignes en vigueur à la suite du retrait du caractère assujetti et/ou la cessation
d’activité ............................................................................................................................................... 43
Figure 13 - Le masquage de lignes non entrées en vigueur à la suite du retrait du caractère assujetti et/ou la
cessation d’activité ................................................................................................................................. 44
Figure 14 - L'actualisation de l'annuaire par le service d'immatriculation ......................................................... 44
Figure 15 - L'actualisation de lignes en vigueur à la suite d’une perte d'immatriculation .................................... 44
Figure 16 - Le masquage de lignes non entrées en vigueur à la suite d’une perte d'immatriculation .................... 45
Figure 17 - L'actualisation de l'annuaire par le portail de services Chorus Pro .................................................. 45
Figure 18 - La création d'une ligne d'annuaire pour un nouveau service .......................................................... 45
Figure 19 - L'actualisation de lignes à la suite d’une réduction du rôle d'une structure publique à la maîtrise
d'ouvrage (MOA) .................................................................................................................................... 46
Figure 20 - Exemple d'accord formel de choix de plateforme agréée .............................................................. 47
Figure 21 - L’actualisation de l’annuaire par une nouvelle PA ........................................................................ 49
Figure 22 - L’actualisation des lignes à la suite de la réduction du rôle d'une structure publique à la maitrise
d'ouvrage (MOA) .................................................................................................................................... 49
Figure 23 - La création de services et des lignes d'annuaire correspondantes .................................................. 50
Figure 24 - La création de lignes à la suite de la mise en place d'une nouvelle maille d'adressage ...................... 50
Figure 25 - La création d'une nouvelle maille d'adressage ............................................................................. 51
Figure 26 - L'actualisation des lignes à la suite de la mise en place d'une nouvelle maille d'adressage ................. 51
Figure 27 - L'actualisation des lignes à la suite de la mise en place d'une nouvelle maille d'adressage ................. 52
Figure 28 - La cartographie des flux e-invoicing et Cycle de vie échangés en B2B ............................................ 54
Figure 29 - La cartographie des flux e-invoicing et Cycle de vie échangés en B2G, si Chorus Pro est la plateforme de
réception .............................................................................................................................................. 55
Figure 30 - La cartographie des flux e-invoicing et Cycle de vie échangés en B2G, si Chorus Pro est la plateforme
d'émission et réception ........................................................................................................................... 56
Figure 31 - Le cycle de vie nominal d'une facture ........................................................................................ 57
Figure 32- Le cycle de vie d’un objet métier ............................................................................................... 60
Figure 33 - La cartographie des flux e-reporting et Cycle de vie échangés ....................................................... 62
Figure 34 - La structure d'un flux de transmission (F10) ............................................................................... 63
Figure 35 - La structure d'un flux de transmission (F10) ............................................................................... 63
Figure 36 - Exploitation des flux de factures (B2Bi, Bi2B et Bi2Bi) et leurs statuts pour constituer un flux de
transmission .......................................................................................................................................... 64
Figure 37 - Exploitation des flux de factures (B2C) et leurs statuts pour constituer un flux de transmission.......... 64
Figure 38 - Exploitation des flux de factures (B2C) et leurs statuts pour constituer un flux de transmission.......... 66
Figure 39 - Transmission distinctes des données de facture et transaction des données de paiement .................. 67
Figure 40 - Les modalités de rectification d'une transmission au titre d’une période révolue .............................. 68
Figure 41 - Le cycle de vie d’un objet métier .............................................................................................. 69  

_Source: `c:\Users\g.baudrit\source\repos\gbaudrit\conf-aimer-votre-llm\demo\ctxc-sample-spec\with-ctxc\spec/dgfip/0- Dossier de specifications externes FE - Dossier général.pdf` (page:71/page:71)_

### E-d04381b85d4b

72 
5 Glossaire 

Abréviation Libellé complet Définition

AIFE Agence pour l’informatique
financière de l’Etat
Service à compétence nationale chargé de concevoir,
développer et gérer le système d’information financière de
l’Etat, et de proposer des solutions de dématérialisation au
profit de l’ensemble des personnes publiques et des
entreprises, notamment le portail public de facturation et
Chorus Pro.

API Application Programming
Interface
Ensemble normalisé de fonctions qui sert de façade par
laquelle un logiciel offre des services à d'autres logiciels.
Solution informatique permettant à des applications d’être
mises en relation et de communiquer via un langage commun.

AS/2 Applicable Statement /2
Protocole de transfert de fichiers fonctionnant en mode « push
», permettant au partenaire d’envoyer directement et de sa
propre initiative un fichier au destinataire.

AS/4 Applicable Statement /4 L’Applicability Statement (AS) 4 est une évolution de l’AS/2
intégrant des services web.

B2B Business to Business
Désigne les relations commerciales interentreprises
(notamment dans le cadre d’une relation entre une entreprise
et son fournisseur).

Bi2B Business international to
Business
Désigne les relations commerciales entre une entreprise
étrangère et une entreprise domestique.

B2C Business to Consumer Désigne les relations commerciales entre une entreprise et un
non assujetti.

B2G Business to Government Désigne les relations commerciales entre une entreprise et les
pouvoirs publics (l’administration).

Bi2G Business international to
Government
Désigne les relations commerciales entre une entreprise
étrangère et les pouvoirs publics (l’administration)

BOI Bulletin officiel des impôts
Le bulletin officiel des finances publiques - impôts (BOFiP-
Impôts), anciennement bulletin officiel des impôts (BOI)
regroupe dans une base unique et consolidée, l'ensemble de la
doctrine fiscale opposable par le contribuable à
l’administration.

CGI Code général des impôts Ensemble des dispositions législatives et réglementaires
relatives à l’assiette et au recouvrement des impôts en France.
CII Cross Industry Invoice Norme de structuration de données de factures.

CPRO Chorus Pro
Opérateur public de dématérialisation des factures destinées à
l’État, aux collectivités locales et aux établissements publics
(obligation codifiée au code de la commande publique).

DGFIP Direction Générale des Finances
Publiques
Service public dont les missions permettent à la fois de
contribuer à la solidité financière des institutions publiques et
de favoriser un environnement de confiance dans la société,
l’économie et les territoires.

EDI Échange de données
informatisé
Échange informatique respectant un format standardisé (les
données sont structurées selon des normes techniques
internationales de référence), et remplaçant les échanges
physiques de documents.

E-invoicing Facturation électronique Obligation pour les entreprises d’émettre des factures sous
format électronique.

EN 16931 Norme européenne 16931 Norme qui définit un modèle sémantique de données pour les
éléments essentiels d'une facture électronique.

E-reporting
Transmission sous format
structuré des données de
transactions
Obligation pour les entreprises de transmettre à
l’administration fiscale des données de transactions (opérations
B2B international et B2C) sous format électronique. 

_Source: `c:\Users\g.baudrit\source\repos\gbaudrit\conf-aimer-votre-llm\demo\ctxc-sample-spec\with-ctxc\spec/dgfip/0- Dossier de specifications externes FE - Dossier général.pdf` (page:72/page:72)_

### E-18768678a007

73 
Abréviation Libellé complet Définition

ETI Entreprise de taille
intermédiaire
Entreprise dont l’effectif est inférieur à 5 000 personnes et dont
le chiffre d’affaires annuel n’excède pas 1 500 millions d’euros
ou dont le total de bilan n’excède pas 2 000 millions d’euros.

GE Grande entreprise
Entreprise qui vérifie au moins une des deux conditions
suivantes : avoir au moins 5 000 salariés ; avoir plus de 1,5
milliard d'euros de chiffre d'affaires et plus de 2 milliards
d'euros de total de bilan.

G2B Government to Business Désigne les relations commerciales entre les pouvoirs publics
(l’administration) et une entreprise.

INSEE
Institut National de la
Statistique et des Etudes
Economiques
Direction générale du ministère de l'Économie et des Finances
ayant pour mission de collecter, analyser et diffuser des
informations sur l'économie et la société française sur
l'ensemble de son territoire.

MOA Maîtrise d’ouvrage
Entité porteuse d'un besoin, définissant l'objectif d'un projet,
son calendrier et le budget consacré à ce projet. Le résultat
attendu du projet est la réalisation d'un produit, appelé
ouvrage.

SC Solution compatible
Opérateurs offrant des services de dématérialisation des
factures mais qui ne sont pas immatriculés par l’administration.
Ces opérateurs ne peuvent pas transmettre directement les
factures électroniques à leurs destinataires ni transmettre de
données au portail public de facturation, mais peuvent agir au
nom et pour le compte de l’entreprise auprès des plateformes
de leur choix (y compris Chorus Pro).

PA Plateforme agréée
Prestataires offrant des services de dématérialisation des
factures immatriculés par l’administration. Seules les
plateformes agréées peuvent transmettre directement les
factures électroniques à leurs destinataires et transmettre des
données au portail public de facturation.

PEPPOL Pan-European Public
Procurement OnLine
Projet européen lancé en 2007 pour normaliser et simplifier les
échanges électroniques entre le public et le privé.

PME Petite et moyenne entreprise
Entreprise dont l’effectif est inférieur à 250 personnes et dont
le chiffre d’affaires annuel n’excède pas 50 millions d’euros ou
dont le total de bilan n’excède pas 43 millions d’euros.

PPF Portail public de facturation
Opérateur public qui administre l’annuaire central, concentre
les données de facturation, de transaction et de paiement ainsi
que des informations relatives aux statuts de traitement des
factures (cycle de vie) et les transmet ces données à
l’administration fiscale.

SFTP Secure File Transfert Protocol
(ou SSH File Transfert Protocol)
Protocole de transfert de fichiers, type client/serveur,
permettant un cryptage de l’intégralité de la connexion, y
compris des mots de passe et du contenu des transferts.

SIREN Système d’identification du
répertoire des entreprises
Numéro de registre de 9 chiffres servant à identifier
l’entreprise.

SIRET Système d’identification du
répertoire des établissements
Numéro de registre de 14 chiffres (dont les 9 premiers sont
ceux du numéro SIREN) identifiant chaque établissement de
l’entreprise. La seconde partie, habituellement appelée NIC
(Numéro Interne de Classement), se compose d'un numéro
d'ordre à quatre chiffres, attribué à l'établissement et d'un
chiffre de contrôle, qui permet de vérifier la validité de
l'ensemble du numéro SIRET.

TPE Très petite entreprise
Désigne les microentreprises dont le chiffre d’affaires hors taxe
annuel ne dépasse pas 176 200 € si l’activité principale est la
vente de biens, ou 72 600 € en cas de prestation de services.

TVA Taxe sur la valeur ajoutée La taxe sur la valeur ajoutée est un impôt sur la consommation.
Il s’agit d’un impôt indirect, c’est-à-dire qu’il n’est pas collecté 

_Source: `c:\Users\g.baudrit\source\repos\gbaudrit\conf-aimer-votre-llm\demo\ctxc-sample-spec\with-ctxc\spec/dgfip/0- Dossier de specifications externes FE - Dossier général.pdf` (page:73/page:73)_

### E-e934c6f80f59

74 
Abréviation Libellé complet Définition
directement par l’État mais par le vendeur qui le collecte et le
reverse à l’État.

UBL Invoice Universal Business Language
Invoice Norme de structuration de données de factures.

UN/CEFACT
United Nations Centre for
Trade Facilitation and
Electronic Business
Organisme des Nations Unies qui encourage une étroite
collaboration entre les gouvernements et les entreprises afin
d'assurer l'interopérabilité des échanges d'information entre les
secteurs public et privé.

XML Extensible markup language
Langage informatique personnalisable permettant de
transmettre des données à l’aide de balises (c’est-à-dire à l’aide
d’étiquettes qualifiant les données).   

_Source: `c:\Users\g.baudrit\source\repos\gbaudrit\conf-aimer-votre-llm\demo\ctxc-sample-spec\with-ctxc\spec/dgfip/0- Dossier de specifications externes FE - Dossier général.pdf` (page:74/page:74)_

### E-5d44dcb80baf

75 
6 Textes de référence 

Support législatif ou
règlementaire Libellé du texte de référence Lien

Arrêté Arrêté du 7 octobre 2022 Lien vers l’arrêté du 7 octobre
2022

Bulletin officiel des impôts /
bulletin officiel des finances
publics
BOI-TVA-CHAMP-10-10-40-40  Lien vers le BOI

BOI BIC CHAMP 80 30  Lien vers le BOI

BOI-TVA-LIQ-30-20-90-20  Lien vers le BOI

BOI-TVA – BASE-20-40  Lien vers le BOI

BOI TVA BASE 20 20  Lien vers le BOI

Code civil Article 1590  Lien vers l’article 1590

Code de la commande publique Article L. 2192-5  Lien vers l’article L. 2192-5

Article L.2193-10  Lien vers l’article L.2193-10

Code du commerce
Article R. 123-224  Lien vers l’article R. 123-224

Article A123-96  Lien vers l’article A123-96

Article L.123-22  Lien vers l’article L.123-22

Article R 123-221  Lien vers l’article R 123-221

Code de l’environnement Article L.541-10  Lien vers l’article L.541-10

Code général des impôts (CGI)
Article 289 bis  Lien vers l’article 289 bis

Article 289  Lien vers l’article 289

Article 290  Lien vers l’article 290

Article 290 A.  Lien vers l’article 290 A.

Article 290 B.  Lien vers l’article 290 B.

Article 286 ter  Lien vers l’article 286 ter

Article 258 A  Lien vers l’article 258 A

Article 259 B  Lien vers l’article 259 B

Article 266  Lien vers l’article 266

Article 268  Lien vers l’article 268

Article 297 A  Lien vers l’article 297 A

Article 256 C  Lien vers l’article 256 C

Article 293 B  Lien vers l’article 293 B

Article 269  Lien vers l’article 269

Article 256 C  Lien vers l’article 256 C

Article 257 ter  Lien vers l’article 257 ter

Article 242 nonies A de l’annexe II  Lien vers l’article 242 nonies A

Article 41 septies D de l’annexe IV  Lien vers l'article 41 septies D

Code monétaire et financier Article L.313-1  Lien vers l’article L.313-1

Décret
Décret n° 2022-1299 du 7 octobre 2022  Lien vers le décret n° 2022-
1299

Décret n°2014-928 du 19 août 2014  Lien vers le décret n°2014-928

Décret n°2024-266 du 25 mars 2024  Lien vers le décret n°2024-266

Livre des procédures fiscales Article L.102B  Lien vers l’article L.102B 

_Source: `c:\Users\g.baudrit\source\repos\gbaudrit\conf-aimer-votre-llm\demo\ctxc-sample-spec\with-ctxc\spec/dgfip/0- Dossier de specifications externes FE - Dossier général.pdf` (page:75/page:75)_

### E-bdfde449eeb0

76 
Support législatif ou
règlementaire Libellé du texte de référence Lien

Loi n°75-1334 du 31 décembre
1975 Article 14  Lien vers l’article 14

Loi n°2008-776 du 4 août 2008 Article 51  Lien vers l’article 51

Loi n°2022-1157 du 16 août 2022 Article 26  Lien vers l’article 26

Loi n°2023-13122 du 29 décembre
2023 Article 91  Lien vers l’article 91

Projet de loi de finances pour 2026
déposé le 14 octobre 2025 Article 28 Lien vers le PLF 2026

Ordonnance (abrogée, cf. code de
la commande publique supra)
Ordonnance n° 2014-697 du 26 juin 2014
(transposition de la directive européenne
2014/55/UE)
-

7 Documentation applicable 

Le tableau ci-dessous liste l’ensemble des documents externes applicables vers lesquels les présentes
spécifications du PPF renvoient :  

# Document Accès (lien)

1
Spécifications externes de Chorus Pro en
application de la réforme de la facturation
électronique
Spécifications externes : facturation à destination
du secteur public | portail.chorus-pro.gouv.fr

2 Spécifications externes initiales B2G/G2G de
Chorus Pro – Annexe EDI
Portail de documentation Chorus Pro |
portail.chorus-pro.gouv.fr

3 Spécifications externes du portail public de
facturation Spécifications externes FE | impots.gouv.fr

4
Norme AFNOR XP Z12_012

Spécifications externes FE | impots.gouv.fr Norme AFNOR XP Z12-012 - Annexe A

Norme AFNOR XP Z12-012 - Annexe B

5
Norme AFNOR XP Z12-014

Spécifications externes FE | impot.gouv.fr  Norme AFNOR XP Z12-014 - Annexe A 

Norme AFNOR XP Z12-014 - Annexe B

6 Communiqué de presse du 15 octobre 2024
https://presse.economie.gouv.fr/letat-accompagnera-
la-generalisation-de-la-facturation-electronique-
entre-entreprises/

7 Article 28 du projet de loi de finances 2026 https://www.assemblee-
nationale.fr/dyn/17/textes/l17b1906_projet-loi#

8 Présentation de la plateforme PISTE https://communaute.chorus-
pro.gouv.fr/documentation/presentation-de-piste/  

_Source: `c:\Users\g.baudrit\source\repos\gbaudrit\conf-aimer-votre-llm\demo\ctxc-sample-spec\with-ctxc\spec/dgfip/0- Dossier de specifications externes FE - Dossier général.pdf` (page:76/page:76)_

### E-d2b4fae7924c

77 
8 Contacts 

Pour adresser vos questions concernant la facturation électronique et les spécifications externes, un
formulaire de contact est accessible sur le site aife.economie.gouv.fr/formulaire-de-contact-ppf. 

_Source: `c:\Users\g.baudrit\source\repos\gbaudrit\conf-aimer-votre-llm\demo\ctxc-sample-spec\with-ctxc\spec/dgfip/0- Dossier de specifications externes FE - Dossier général.pdf` (page:77/page:77)_

### E-ed908605abc7

XP Z12-012

FÉVRIER 2026

En tant que titulaire des droits d’auteurs sur ce document, ayant-droit ou distributeur
autorisé de ce document, AFNOR autorise la consultation et le téléchargement
selon les droits qui vous sont alloués pour votre abonnement ou votre achat.
Tous autres droits relatifs à ces documents sont réservés.
AFNOR s’oppose expressément à toute intégration, transmission ou absorption totale
ou partielle du présent document par des moteurs ou algorithmes d’Intelligence Artificielle (IA).
AFNOR s’oppose également à toute fouille de textes et de données ou création dérivée
produite par une IA et basée sur le présent document. 

As the copyright holder of this document or authorized distributor, AFNOR authorizes
the consultation and downloading of the document as per the rights allowed
for your subscription or purchase.
All other rights related to these documents are reserved.
AFNOR, as copyright holder or authorized distributor, expressly objects to any
integration, transmission or absorption, in whole or in part, of the present document by
Artificial Intelligence (AI) engines or algorithms. AFNOR is also opposed to any text
and data mining or derivative creation produced by an AI and based on the present document.

AFNOR

Le : 03/03/2026 à 10:49

_Source: `c:\Users\g.baudrit\source\repos\gbaudrit\conf-aimer-votre-llm\demo\ctxc-sample-spec\with-ctxc\spec/afnor/XP_Z12-012/XP_Z12-012.pdf` (page:1/page:1)_

### E-8ff132e73de4



_Source: `c:\Users\g.baudrit\source\repos\gbaudrit\conf-aimer-votre-llm\demo\ctxc-sample-spec\with-ctxc\spec/afnor/XP_Z12-012/XP_Z12-012.pdf` (page:2/page:2)_

### E-03889cfbb9b3

ISSN 0335-3931

AFNOR / FE : Facture électronique

Normalisation française
Norme française expérimentale publiée par AFNOR

XP Z12-012

Formats et Profils des messages Factures et Statuts de cycle de vie,
constitutifs du socle minimal applicable à la Réforme Facture
Electronique en France

Date de publication : février 2026

« En tant que titulaire des droits d’auteurs sur ce document, AFNOR autorise la consultation et le
téléchargement.

Tous autres droits relatifs à ces documents sont réservés.

AFNOR s’oppose expressément à toute intégration, transmission ou absorption totale ou partielle
du présent document par des moteurs ou algorithmes d’Intelligence Artificielle (IA).

AFNOR s’oppose également à toute fouille de textes et de données ou création dérivée produite
par une IA et basée sur le présent document. »

Éditée et diffusée par l’Association Française de Normalisation (AFNOR) - 11, rue Francis de Pressensé - 

93571 La Plaine Saint-Denis Cedex Tél.: + 33 (0)1 41 62 80 00 - Fax : +  33  (0)1 49  17  90  00  - www.afnor.org

© AFNOR — Tous droits réservés Version 1
AFNOR XP Z12-0122026-02

_Source: `c:\Users\g.baudrit\source\repos\gbaudrit\conf-aimer-votre-llm\demo\ctxc-sample-spec\with-ctxc\spec/afnor/XP_Z12-012/XP_Z12-012.pdf` (page:3/page:3)_

### E-5b618ce5b019

XP Z12-012 – Formats et Profils des messages Factures et Statuts de cycle de vie, constitutifs du socle
minimal applicable à la Réforme Facture Électronique en France

2
Sommaire

Avant-propos.......................................................................................................................................................................... 4

Gestion de versions .............................................................................................................................................................. 5

Introduction ........................................................................................................................................................................... 8

1 Domaine d'application .................................................................................................................................................. 9

2 Références normatives ................................................................................................................................................. 9

3 Termes et définitions .................................................................................................................................................... 9

4 Formats et profils de facture électronique du socle minimum ................................................................... 12
4.1 Norme Sémantique Européenne EN16931 .......................................................................................................... 12
4.2 Implémentations des 2 profils EN 16931 et EXTENDED-CTC-FR ................................................................. 16
4.2.1 La nécessité de proposer plusieurs profils sémantiques dans le socle minimum ................................ 16
4.2.2 L’implémentation dans les syntaxes UBL et UN/CEFACT CII exige une description spécifique .... 17
4.3 Description sommaire de la structure sémantique des données des 2 profils ...................................... 18
4.3.1 Le profil EN 16931 ........................................................................................................................................................... 18
4.3.2 Le profil EXTENDED-CTC-FR ....................................................................................................................................... 21
4.3.3 Évolution de la Norme .................................................................................................................................................... 24
4.3.4 Évolution du profil EXTENDED-CTC-FR et Profil EXTENDED de Factur-X .............................................. 25
4.4 Points d’attention particuliers ................................................................................................................................. 26
4.4.1 Types de données ............................................................................................................................................................. 26
4.4.2 Gestion des données de profils et cadre de facturation ................................................................................... 27
4.4.3 Gestion des Notes .............................................................................................................................................................. 27
4.4.4 Gestion des avoirs ............................................................................................................................................................. 28
4.4.5 Règle de calcul .................................................................................................................................................................... 29
4.4.6 Règle d’arrondi dans les calculs .................................................................................................................................. 30
4.4.7 Gestion de la TVA .............................................................................................................................................................. 30
4.4.8 Gestion des taxes autres que la TVA, cas de l’éco-contribution DEEE ....................................................... 31
4.4.9 Gestion des remises et charges ................................................................................................................................... 31
4.4.10 Gestion des Codes ............................................................................................................................................................. 32
4.4.11 Gestion des sous-lignes en profil EXTENDED-CTC-FR (et EXTENDED de Factur-X) ........................... 32
4.4.12 Factures multi-vendeurs ................................................................................................................................................ 35
4.4.12.1 Modalités de création d’une facture Multi-Vendeurs .............................................................................. 35
4.4.12.2 Numéro de facture unitaire : ............................................................................................................................ 39
4.4.12.3 Les Charges et Remises : ..................................................................................................................................... 39
4.4.12.4 Les règles de gestion ............................................................................................................................................. 39
4.4.12.5 Constitution du flux 1 ou 10.1, sur la base des factures unitaires. ..................................................... 39
4.5 Règles de gestion spécifiques ................................................................................................................................... 40
4.5.1 Les règles de contrôle additionnelles pour le respect de la réglementation en France ..................... 41
4.5.2 Les règles de mapping pour constituer les flux 1 et 10.1 ................................................................................ 48
4.5.3 Les règles de contrôle CPRO pour les factures B2G à destination du secteur public .......................... 52
4.5.4 Règles de gestion spécifiques pour les factures multi-vendeurs ................................................................. 58
4.6 Règle de constitution d’une représentation lisible d’une facture électronique de la présente
Norme. ............................................................................................................................................................................... 60
4.6.1 Construire un modèle de représentation lisible .................................................................................................. 61
4.6.2 Comment représenter les données sous forme de codes ................................................................................ 61
4.6.3 Factur-X et Facture structurée avec une présentation lisible attachée ..................................................... 61
4.6.4 Exemples ............................................................................................................................................................................... 62
4.7 Conversions entre formats du socle ....................................................................................................................... 64
4.8 Présentation du fichier annexe de description des formats de facture du socle minimal ................ 64
4.8.1 Feuille « FE EN16931 + EXTENDED » ...................................................................................................................... 66
4.8.2 Feuille « BR-France CTC » ............................................................................................................................................. 67
4.8.3 Feuille « BR-France-CTC-CPRO » ................................................................................................................................ 67
AFNOR XP Z12-0122026-02

_Source: `c:\Users\g.baudrit\source\repos\gbaudrit\conf-aimer-votre-llm\demo\ctxc-sample-spec\with-ctxc\spec/afnor/XP_Z12-012/XP_Z12-012.pdf` (page:4/page:4)_

### E-3489a215019a

XP Z12-012 – Formats et Profils des messages Factures et Statuts de cycle de vie, constitutifs du socle
minimal applicable à la Réforme Facture Électronique en France

3
4.8.4 Feuille « BR EN16931 + EXT FR et FX » .................................................................................................................. 67
4.8.5 Feuille « Codelists for XML Fx - 15 11 25 » ............................................................................................................ 69
4.8.6 Feuille « Flux 2 UBL EN16931 FR » et « Flux 2 UBL EXT-CTC-FR » ............................................................ 69
4.8.7 Feuilles « FACTUR-X BASIC WL FR », « CII D22B & FX EN16931 FR » et « CII D22B & FX EXT-CTC-
FR) ........................................................................................................................................................................................... 70
4.8.8 Feuilles « FE - Flux 1 », « Flux 1 UBL » et « Flux 1 CII » .................................................................................... 74
4.8.9 Feuille « E-REPORTING - Flux 10 » ........................................................................................................................... 75
4.8.10 Feuille « Flux F11 – Annuaire »................................................................................................................................... 75
4.8.11 Feuille « Règles de gestion 3.1 » ................................................................................................................................. 75

5 Le message de Cycle de Vie – CDAR ........................................................................................................................ 75
5.1 Description de la structure du message CDAR à utiliser ................................................................................ 75
5.2 Règles de gestion applicables ................................................................................................................................... 83
5.3 Motifs des statuts de cycle de vie. ............................................................................................................................ 87
5.4 Présentation du fichier annexe pour les feuilles CDAR .................................................................................. 87
5.4.1 Feuille « CDV FE – CDAR » ............................................................................................................................................ 87
5.4.2 Feuille « BR-FR-CDV pour factures » ........................................................................................................................ 88
5.4.3 Feuille « Acteurs CDV » .................................................................................................................................................. 88
5.4.4 Feuille « Codes Action » ................................................................................................................................................. 88
5.4.5 Feuille « Tableau des motifs de STATUTS » .......................................................................................................... 88 

(normative)  Description Excel des formats et profils ..................................................................... 89 

(normative)  Exemples de factures (flux 2) et de messages CDAR de cycle de vie ................. 90

Bibliographie ....................................................................................................................................................................... 91  
AFNOR XP Z12-0122026-02

_Source: `c:\Users\g.baudrit\source\repos\gbaudrit\conf-aimer-votre-llm\demo\ctxc-sample-spec\with-ctxc\spec/afnor/XP_Z12-012/XP_Z12-012.pdf` (page:5/page:5)_

### E-09ad910bc8b5

XP Z12-012 – Formats et Profils des messages Factures et Statuts de cycle de vie, constitutifs du socle
minimal applicable à la Réforme Facture Électronique en France

4
Avant-propos

Le présent document est destiné à tous les organismes qui souhaitent échanger des factures électroniques
dans le contexte de la réglementation française (Réforme de la Facture Électronique telle que décrite aux
article 289, 289BIS, 290 et 290A du Code Générale des Impôts), mais aussi plus largement dans le respect des
dispositions de la Directive 2006-112-CE, modifiée par le Directive UE 2025/516 dite ViDA (VAT in the Digital
Age).

Le présent document traite des formats et des profils des messages Factures et Statuts de cycle de vie,
constitutifs du socle minimal applicable à la Réforme Facture Électronique en France.

Le présent document n’a pas pour objet de détailler les cas d’usage qui feront l’objet d’une publication séparée/

Ce Document décrit les formats et profils applicables dans le cadre de la réforme facture électronique en
France :

⎯ D’une part, s’agissant du message facture, en conformité avec la Norme Sémantique Européenne de la
facture électronique EN 16931

⎯ D’autre part, s’agissant du message de statut de cycle de vie implémenté à partir du message UN/CEFACT
Cross Domain Aknowledgement and Response (CDAR)

La connaissance des normes EN 16931, ainsi que des syntaxes d’implémentation UBL, UN/CEFACT CII et
UN/CEFACT CDAR, est un prérequis essentiel à la lecture du présent document.

A ce document est annexé un fichier Excel de description détaillée des formats et profils, ainsi que leurs
implémentations dans les syntaxes UBL, UN/CEFACT CII et UN/CEFACT CDAR, les règles de gestion associées
et les listes de codes applicables.

Ce document a vocation à évoluer, notamment dans la description du profil EXTENDED-CTC-FR du message
Facture et dans celle du message de statuts de cycle de vie, en fonction des travaux de la Commission AFNOR
et en accompagnement du déploiement opérationnel de la Réforme Facture Électronique en France, et de la
mise en œuvre de la généralisation de la facture électronique en Union Européenne et au-delà.

Note préalable

Au sein de la réforme, l’expression « Plateforme de Dématérialisation Partenaire (PDP) » a été remplacée par
« Plateforme Agréée (PA) ».  
AFNOR XP Z12-0122026-02

_Source: `c:\Users\g.baudrit\source\repos\gbaudrit\conf-aimer-votre-llm\demo\ctxc-sample-spec\with-ctxc\spec/afnor/XP_Z12-012/XP_Z12-012.pdf` (page:6/page:6)_

### E-3236892d0fff

XP Z12-012 – Formats et Profils des messages Factures et Statuts de cycle de vie, constitutifs du socle
minimal applicable à la Réforme Facture Électronique en France

5
Gestion de versions

N° de Version Date de Version Description des évolutions

V1.0 2025 05 07 Version initiale

V1.1 2025 07 31
Quelques corrections éditoriales dans l’avant-propos, l’introduction, la
définition 3.6 du « e-reporting ».

Chapitre 4.2 : ajout de paragraphes pour mieux expliquer les formats
et profils et préciser l’utilisation des profils de Factur-x.

Chapitre 4.3 : ajout de rappels au textes réglementaires pour le « Livré
à » et le « Bon de commande ¬/ Précisions sur l’utilisation de la BT-8.

Chapitre 4.4.3 : ajout du code DCL (BT-21) comme objet de note pour
la mention « facture établie par A au nom et pour le compte de B » (en
cas de mandat de facturation).

Chapitre 4.4.8 . ajout d’un paragraphe sur la gestion des taxes
parafiscales s’appuyant sur une nomenclature GS1 (GTIN)/

Règle BR-FR-02 : suppression de «  «  l’espace comme caractère accepté
dans un identifiant de facture (BT-1).

Règles BR-FR-12 et BR-FR-13 : clarification et ajout des règles BR-FR-
21 et BR-FR-22 pour décrire des règles additionnelles de contrôle de
forme des adresses électroniques en fonction de la présence d’une note
avec code sujet BAR permettant de qualifier le type de traitement
attendu (e-invoicing, e-reporting, hors réforme, 0)/

Règle BR-FR-17 . ajout d’une valeur de type de Pièce Jointe
(RECAPITULATIF_COTRAITANCE).

Ajout des règles BR-FR-23 à BR-FR-26 pour contrôler la taille des
adresses électroniques et des Code_Routage, ainsi que les caractères
autorisés pour les Code_Routage et les adresses électroniques en
schemeID 0225.

Règles BR-FR-DEC-02 : correction éditoriale (pour une quantité, et pas
un montant).

Règle BR-FR-MAP-01 . ajout d’un exemple/

Règle BR-FR-MAP-02 : correction éditoriale (« référence de contrat » et
non « numéro de contrat »).

Règle BR-FR-MAP-06 : correction éditoriale « 0 dans la BT-22 du flux
1. »

Règle BR-FR-MAP-08 : reformulation.

Règle BR-FR-MAP-13 : ajout de la liste des champs concernés.

Règles BR-FR-MAP-17 à BR-FR-MAP-22 : reformulation pour être plus
précis.

Ajout de la Règle BR-FR-MAP-23 sur le format des dates dans le flux
10.1 (règle de mapping en cas de facture en UBL).

Chapitre 4.6.1 : mise à jour des colonnes suite à la modification de
l’annexe A sur la feuille « FE EN16931 + EXTENDED » (une colonne par
AFNOR XP Z12-0122026-02

_Source: `c:\Users\g.baudrit\source\repos\gbaudrit\conf-aimer-votre-llm\demo\ctxc-sample-spec\with-ctxc\spec/afnor/XP_Z12-012/XP_Z12-012.pdf` (page:7/page:7)_

### E-c521c3dd079f

XP Z12-012 – Formats et Profils des messages Factures et Statuts de cycle de vie, constitutifs du socle
minimal applicable à la Réforme Facture Électronique en France

6
N° de Version Date de Version Description des évolutions

profil pour identifier les données appartenant à chaque profil).

Chapitre 5.2 : Règle BR-FR-CDV-CL-08 : MDT-158 (et non MDT-132)

Correction de l’annexe A : voir Feuille « VERSIONS » : mise à jour des
règles de gestion, correction de quelques Xpath de l’implémentation
UBL du profil EXTENDED-CTC-FR, revue de la feuille « Acteurs CDV »,
ajout de motifs pour le statut « IRRECEVABLE ».

V1.2 2025 10 31
Prise en compte du changement de vocabulaire : Plateforme agréée et
Solution Compatible.

Quelques corrections, précisions, notamment s‘agissant de
l’ADRESSÉ À.

Ajout de données au profil EXTENDED-CTC-FR :

• Conditions de livraison (Incoterms).

• Code qualifiant le type d’attribut et valeur avec mesure (par
exemple pour permettre de signifier des g de CO2.

• Raison d’exemption TVA (ou d’information TVA) en ligne, en
texte et en code.

• Données permettant de gérer des sous-lignes.

• Données nécessaires à la gestion des factures multi-vendeurs.

Le changement de cardinalité de l’identifiant d’objet facture à 0//n 
(BT-18, BT-128).

L’ajout des règles de gestion additionnelles pour les factures B2G à
destination de CHORUS PRO.

La gestion de sous-lignes.

La gestion de factures multi-vendeurs.

La mise à jour des règles de gestion et de mapping.

La gestion du LISIBLE.

La gestion des conversions entre formats et profils de la présente
Norme.

La correction de certaines règles de gestion du message de statuts de
cycle de vie (pour gérer les factures irrecevables notamment).

L’ajout du motif « NON_TRANSMISE » au statut « Déposée » (en cas de
destinataire non équipé d’une Plateforme Agréée pour la réception de
ses factures.

V1.3 2026 02 26
Ajout de la définition du flux 11, complément sur celle du flux 10.

Profil EXTENDED-CTC-FR : 

• Ajout des motifs d’exemption en texte et en code pour les
remises et charges de niveau document (EXT-FR-FE-187, EXT-
FR-FE-188, EXT-FR-FE-189, EXT-FR-FE-190).

• Ajout de la quantité dans UNE unité de la ligne Parent (en cas
AFNOR XP Z12-0122026-02

_Source: `c:\Users\g.baudrit\source\repos\gbaudrit\conf-aimer-votre-llm\demo\ctxc-sample-spec\with-ctxc\spec/afnor/XP_Z12-012/XP_Z12-012.pdf` (page:8/page:8)_

### E-2bd91da9de7d

XP Z12-012 – Formats et Profils des messages Factures et Statuts de cycle de vie, constitutifs du socle
minimal applicable à la Réforme Facture Électronique en France

7
N° de Version Date de Version Description des évolutions

de sous-ligne). Mise à jour des illustrations.

Chapitre 4.3.3 : révision de la Norme EN16931

Chapitre 4.3.4 : Profil EXTENDED-CTC-FR

Chapitre 4.4.4 : gestion des avoirs . pas d’avoirs négatifs/

Chapitre 4.4.7 : gestion des codes VATEX, précisions pour les ventes de
service UE ou hors UE.

Chapitre 4.4.9 : gestion des remises et charges, précision sur le rabais
et le prix Brut.

Chapitre 4.4.11 : gestion des sous-lignes, mise à jour des schémas en
ajoutant la donnée quantité d’UNE unité de la ligne Parent.

Chapitre 4.4.12 : factures multi-vendeurs : exemple

Chapitre 4.8 : ajout de la feuille « Flux 11 – Annuaire ¬ dans l’Annexe A

Chapitre 5.2 : BR-FR-CDV-07 : correction (aucune MDT-59 = DFH)

Annexe A : voir feuille Versions, et en particulier

• Les règles de gestion du profil EXTENDED BR-FREXT-S-08 et
autres BR-FREXT-XX-08 (prise en compte des motifs
d’exemption en pied en profil EXTENDED-CTC-FR.

• Flux 10 : réintégration du bloc TG-2, TT-5 et TT-6 permettant
des envois de flux 10 complémentaires et correctifs (CO / MO)
entre l’assujetti et sa Plateforme Agréée uniquement/

• Feuille « Flux 11 – Annuaire ».  
AFNOR XP Z12-0122026-02

_Source: `c:\Users\g.baudrit\source\repos\gbaudrit\conf-aimer-votre-llm\demo\ctxc-sample-spec\with-ctxc\spec/afnor/XP_Z12-012/XP_Z12-012.pdf` (page:9/page:9)_

### E-f9e7ae82b97c

XP Z12-012 – Formats et Profils des messages Factures et Statuts de cycle de vie, constitutifs du socle
minimal applicable à la Réforme Facture Électronique en France

8
Introduction

Dans le cadre de la Réforme Facture Électronique en France, régie par les articles 289bis, 290, 290 A du Code
Général des Impôts, applicable à compter de septembre 2026, la Commission AFNOR Facture Électronique
s’est constituée pour prendre en charge la description des formats et profils de facture et de statuts de cycle
de vie constitutifs du socle minimum que les Plateformes Agréées (PA) (ex Plateformes de Dématérialisation
Partenaires, ou PDP) devront supporter, permettant à toute entité soumise à la réforme (assujettie à la TVA
en France) utilisant ces mêmes formats de pouvoir les échanger avec leurs contreparties dans le respect des
exigences de la réforme.

Ces travaux s’inscrivent dans la normalisation européenne en matière de facture électronique, qui a conduit à
la publication par l’AFNOR de la Norme Sémantique de facture électronique structurée EN16931, et à son
implémentation dans les syntaxes UBL et UN/CEFACT CII/ Ces travaux s’appuient aussi sur la publication de
Factur-X, standard franco-allemand de facture mixte (ou hybride) composée d’une part d’une représentation
lisible sous standard PDF/A-3 (ISO 19005-3) à laquelle est joint d’autre part une représentation structurée
des données de la facture sous syntaxe UN/CEFACT CII de la Norme EN 16931.

Pour satisfaire tous les besoins des entreprises, et comme la Norme EN 16931 le prévoit, un profil « Étendu »,
dénommé « EXTENDED-CTC-FR » a aussi été défini, intégrant des données de facturation additionnelles et
modifiant quelques règles de gestion ou cardinalité de certaines données du modèle EN 16931.

A ceci ont été ajoutées des Règles de Gestion nécessaires au respect des exigences de la Réforme Facture
Électronique.

Enfin, s’agissant des statuts de cycle de vie, les travaux de la Commission AFNOR se sont appuyés sur le
message standard UN/CEFACT Cross Domain Acknowledgement and Response (CDAR), et la description de
son utilisation dans le cadre de la réforme entre les Plateformes Agréées (PA) et le Concentrateur de Données
du PPF (Portail Public de Facturation). Toutefois, il restait nécessaire de définir et décrire dans ce document
et son annexe l’utilisation de ce message CDAR pour les échanges entre entités soumises à la réforme entre
elles au travers de leurs Plateformes Agréées respectives, et avec ces dernières.

Ce document a pour vocation à rappeler les grands principes de la Norme EN 16931 et de son application, puis
d’introduire la description technique et fonctionnelle détaillée des formats et profils de facture et de statut de
cycle de vie jointe en annexe, qui comporte plusieurs composantes :

⎯ une spécification sémantique des deux profils EN 16931 et EXTENDED-CTC-FR, avec les Règles de
Gestion spécifiques à l’application de la Réforme Facture Électronique en France et applicable sur toute
facture dans le périmètre de la réforme.

⎯ Un rappel des règles de gestion de la Norme EN 16931 auxquelles ont été rajoutées quelques règles de
gestion additionnelles applicables pour le profil EXTENDED-CTC-FR.

⎯ Une description syntaxique de l’implémentation des deux profils sémantiques EN 16931 et EXTENDED-
CTC-FR dans les syntaxes XML UBL 2.1 et UN/CEFACT CII D22B, à laquelle a été ajouté la description du
profil BASIC WL de Factur-X (Facture mixte sans données de lignes sous forme structurée).

⎯ Une description de l’utilisation du message UN/CEFACT CDAR de statuts de cycle de vie relatif aux
échanges de factures électroniques entre assujettis soumis à la réforme au travers de leurs Plateformes
Agréées respectives.  
AFNOR XP Z12-0122026-02

_Source: `c:\Users\g.baudrit\source\repos\gbaudrit\conf-aimer-votre-llm\demo\ctxc-sample-spec\with-ctxc\spec/afnor/XP_Z12-012/XP_Z12-012.pdf` (page:10/page:10)_

### E-f9b3403977a8

XP Z12-012 – Formats et Profils des messages Factures et Statuts de cycle de vie, constitutifs du socle
minimal applicable à la Réforme Facture Électronique en France

9
1 Domaine d'application

Le présent document vise à décrire les formats et profils des messages Facture et Statuts de Cycle de vie
appliqués aux échanges de factures électroniques, constitutifs du socle minimal de la réforme Facture
Électronique en France.

Il décrit ainsi ce que les entités soumises à la réforme doivent respecter s’agissant des factures électroniques
et des statuts de cycle de vie, ainsi que les contrôles et transformations que les Plateformes Agréées doivent
appliquer pour respecter les obligations réglementaires qui leur incombent.

2 Références normatives

Les documents de référence suivants sont indispensables pour l'application du présent document. Pour les
références datées, seule l'édition citée s'applique. Pour les références non datées, la dernière édition du
document de référence s'applique (y compris les éventuels amendements).

NF EN 16931-1+A1, Facturation électronique – Partie 1 : Modèle sémantique de données des éléments essentiels
d’une facture électronique, publiée en novembre 2019.

CEN/TS 16931-2:2017, Facturation électronique — Partie 2 : Liste de syntaxes conformes à l'EN 16931-1

CEN/TS 16931-3-1:2017, Facturation électronique — Partie 3-1 : Méthodologie applicable aux correspondances
syntaxiques des éléments essentiels d'une facture électronique

CEN/TS 16931-3-2:2017, Facturation électronique — Partie 3-2 : Correspondance syntaxique pour la syntaxe
ISO/IEC 19845 (UBL 2;1) ― Schéma UBL 2;1 Invoice et Credit Note, publiée en juin 2020.

CEN/TS 16931-3-3:2017, Facturation électronique — Partie 3-3 : Correspondance syntaxique pour la syntaxe
Cross Industry Invoice (facture intersectorielle) ― Schéma XML D16B UN/CEFACT, publiée en juin 2020.

CEN/TR 16931-4 :2017, Facturation électronique — Partie 4 : Lignes directrices relatives à l'interopérabilité
des factures électroniques au niveau de la transmission

CEN/TR 16931-5 :2017, Facturation électronique — Partie 5 : Lignes directrices relatives à l'utilisation
d’extensions sectorielles ou nationales en complément de l'EN 16931-1, reposant sur une méthodologie à
appliquer dans l'environnement réel

CEN/TR 16931-6, Facturation électronique — Partie 6 : Résultat des tests de l’EN 16931-1 en ce qui concerne
son application pratique pour un utilisateur final — Méthodologie de test

La documentation Factur-X, libre de droits et disponible auprès de FNFE-MPE et du FeRD, respectivement
Forums Nationaux de la Facture Électronique français et allemand, dernière Version 1.07.3 publiée le 7 mai
2025 sur le site www.fnfe-mpe.org.

3 Termes et définitions

Pour les besoins du présent document, les termes et définitions donnés dans ce document ainsi que les termes
et définitions suivants s'appliquent.

3.1

Annuaire PPF

Annuaire des assujettis soumis à la Réforme Facture Électronique et destinataires de factures électroniques
dans le cadre défini par cette dernière/ L’annuaire des destinataires est mis en œuvre par le PPF pour les
besoins de la réforme.

3.2

CIUS

« Core Invoice Usage Spécifiation » . Spécification d‘usage du message électronique de facture
AFNOR XP Z12-0122026-02

_Source: `c:\Users\g.baudrit\source\repos\gbaudrit\conf-aimer-votre-llm\demo\ctxc-sample-spec\with-ctxc\spec/afnor/XP_Z12-012/XP_Z12-012.pdf` (page:11/page:11)_

### E-a0bf0416299b

XP Z12-012 – Formats et Profils des messages Factures et Statuts de cycle de vie, constitutifs du socle
minimal applicable à la Réforme Facture Électronique en France

10
3.3

Concentrateur des Données

Service du PPF en charge de la concentration des données de e-invoicing (factures B2B domestique et cycle
de vie de ces factures) et de e-reporting (données de factures, transactions et de paiement hors e-invoicing),
à destination de l’Administration fiscale/

3.4

« e-invoicing »

Désigne le périmètre de la Réforme Facture Électronique relatif aux échanges de factures électroniques entre
assujettis à la TVA en France, pour l’échange de Flux 1, Flux 2 et Flux 6/

3.5

EN 16931

Norme sémantique Européenne des données essentielles d’une facture électronique

3.6

« e-reporting »

Désigne le périmètre de la Réforme Facture Électronique relatif aux ventes, acquisitions et opérations qui
n’entrent pas dans le périmètre « e-invoicing » et qui sont listés dans les articles 290 et 290A du Code Général
des Impôts (Ventes B2B internationales, Acquisitions B2B internationales, Ventes B2C, paiement pour les
ventes pour lesquelles la TVA est due à l’encaissement)/ Ce volet donne lieu à la transmission d’un Flux 10 et
de Flux 6 s’agissant du statut d’encaissement des factures pour laquelle la TVA est due à l’encaissement/

3.7

EXTENSION

Extension du profil EN 16931 du fait de l’ajout de données ou groupes de données, de l’augmentation de la
cardinalité de certains données ou groupe du modèle EN 16931 ou de l’ajout de nouvelles valeurs de codes
applicables à certains champs.

3.8

Flux 1, Flux 2, Flux 3, Flux 6, Flux 8, Flux 9, Flux 10, Flux 11

Les Flux nomment les différents types de messages échangés dans le cadre de la réforme :

⎯ Flux 1 : correspond au message de type Facture contenant uniquement les données requises par
l’Administration fiscale pour les factures relevant du périmètre « e-invoicing » (factures électroniques
entre assujettis à la TVA)

⎯ Flux 2 : correspond au message facture échangé entre les entités soumises à la réforme et devant être
transmis par l’intermédiaire de Plateformes Agréées, et conforme aux dispositions du présent document.

⎯ Flux 3 : correspond au message facture échangé entre les entités soumises à la réforme et devant être
transmis par l’intermédiaire de Plateformes Agréées, MAIS qui est dans un format tiers convenu entre
l’émetteur et le destinataire et contient toutes les informations requises par l’Administration fiscale sous
forme structurée et permet une extraction conforme des données pour la constitution du Flux 1 ou du
Flux 10.

⎯ Flux 6 : correspond au message de statuts de cycle de vie relatif aux échanges de factures électroniques,
implémenté en UN/CFACT CII.

⎯ Flux 8 : correspond au message facture échangé entre une entité soumise à la réforme et une entité
internationale conforme aux dispositions du présent document.

⎯ Flux 9 : correspond au message facture échangé entre une entité soumise à la réforme un non assujetti
établi en France (principalement un Particulier), conforme aux dispositions du présent document.
AFNOR XP Z12-0122026-02

_Source: `c:\Users\g.baudrit\source\repos\gbaudrit\conf-aimer-votre-llm\demo\ctxc-sample-spec\with-ctxc\spec/afnor/XP_Z12-012/XP_Z12-012.pdf` (page:12/page:12)_

### E-9fcced72e20f

XP Z12-012 – Formats et Profils des messages Factures et Statuts de cycle de vie, constitutifs du socle
minimal applicable à la Réforme Facture Électronique en France

11
⎯ Flux 10 : correspond au message de « e-reporting » que les entités soumises à la Réforme Facture
Électronique doivent transmettre au Concentrateur de Données par le biais de leur Plateforme Agréée.
Une version complétée du flux 10 est décrite, permettant aux entreprises soumises à la réforme de
transmettre les données de e-reporting à leur Plateforme Agrée en plusieurs fois, charge à cette dernière
de constituer (service optionnel) le flux 10 final à transmettre au Concentrateur de Données.

⎯ Flux 11 : correspond au message permettant aux Plateformes Agréées de transmettre les données
diffusibles de l’annuaire PPF aux utilisateurs/

Les Flux 2 / Flux 8 / Flux 9 et Flux 6 constituent les formats et profils du socle minimum, objets du présent
document.

3.9

Formats et profils du socle minimum

Les formats et profils du socle sont les formats de données structurées ou mixtes qui doivent être supportés
dans le cadre de la Réforme Facture Électronique, qui implémentent la Norme EN 16931.

D’une part, trois formats constituent ce socle pour le message Facture, et implémentent chacun 2 profils de
données :

⎯ Profil EN 16931, qui une CIUS pour la France de l’implémentation de la Norme EN 16931

⎯ Profil EXTENDED-CTC-FR, qui est une EXTENSION pour la France de l’implémentation de la Norme EN
16931

Ces 2 profils sont implémentés dans 2 syntaxes (UBL et UN/CEFACT CII) et dans le format mixte Factur-X, plus
précisément :

⎯ Syntaxe XML ISO/IEC 19845 (UBL 2.1) : le format UBL (Universal Business Language) est conforme à la
norme OASIS U.B.L. 2.1.

⎯ Syntaxe UN/CEFACT CII. Le format CII (Cross Industry Invoice) est conforme à la norme UN/CEFACT
SCRDM CII (Supply Chain Reference Data Model – Cross Industry Invoice). La version de langage retenue
dans le cadre de la réforme est UN/CEFACT CII D22B.

⎯ Factur-X. Factur-X est un format de facture électronique hybride (ou mixte), combinant un fichier PDF
conforme à la Norme ISO-19005-3 PDF/A-3 constituant la représentation LISIBLE de la facture dans
lequel est attaché une représentation de données structurée factur-x.xml dans la syntaxe UN/CEFACT CII.
Factur-X dispose de profils additionnels (MINIMUM, BASIC WL, BASIC et EXTENDED).

D’autre part le format de statuts de cycle de vie est implémenté dans la syntaxe UN/CEFACT CDAR (Cross
Domain Acknowledgement and Response), et fait aussi partie des formats et profils du socle minimum.

3.10

Réforme Facture Électronique

Réforme facture électronique applicable en France à compter du 1er septembre 2026, telle que décrite aux
articles 289, 289bis, 290 et 290A du Code Général des Impôts.

3.11

Plateforme Agréée ou PA

Plateforme Agréée (ex-PDP) : Plateforme de facturation électronique au travers de laquelle les factures
électroniques entre assujettis à la TVA et relevant du périmètre « e-invoicing » de la Réforme Facture
Électronique doivent être échangées, ainsi que les données de « e-reporting » de factures B2B internationales
hors import de biens, de transaction et de paiement
AFNOR XP Z12-0122026-02

_Source: `c:\Users\g.baudrit\source\repos\gbaudrit\conf-aimer-votre-llm\demo\ctxc-sample-spec\with-ctxc\spec/afnor/XP_Z12-012/XP_Z12-012.pdf` (page:13/page:13)_

### E-877c9caba866

XP Z12-012 – Formats et Profils des messages Factures et Statuts de cycle de vie, constitutifs du socle
minimal applicable à la Réforme Facture Électronique en France

12
3.12

PPF

Portail Public de Facturation, plateforme de l’administration proposant les services d’Annuaire des
destinataires et de Concentrateur de Données

3.13

Solution Compatible ou SC

Les Solutions Compatibles sont des solutions de gestion utilisées par les entreprises en amont ou en aval de
l’échange de facture qui revendiquent leur compatibilité avec les exigences de la réforme facture électronique
en France, à savoir leur capacité à créer, intégrer, contrôler la conformité des factures électroniques dans un
des formats du socle minimum décrit dans la présente Norme, ainsi que dans la création, le contrôle et le
traitement des messages de statuts de cycle de vie tels que décrits dans la présente Norme.

Ceci correspond au concept d’Opérateur de Dématérialisation (OD), initialement décrit dans les spécifications
externes du PPF, avec une notion de compatibilité aux exigences réglementaires et normatifs auxquels ils
participent partiellement. Les Solutions Compatibles sont connectées à une ou plusieurs Plateforme(s)
Agréée(s) pour émettre ou recevoir des factures électroniques et des messages de statut de cycle de vie.

4 Formats et profils de facture électronique du socle minimum

4.1 Norme Sémantique Européenne EN 16931

La Norme Sémantique Européenne a été construite comme une norme de données essentielles de facture.
L’objectif était de rendre obligatoire la réception de factures électroniques structurées implémentant cette
norme dans les syntaxes UBL et UN/CEFACT CII pour toute entité du secteur public en Union Européenne.

Cette Norme Sémantique EN 16931 est donc constituée (version publiée en novembre 2019) :

• d’un ensemble de données métiers (164), identifiées par un code de la forme BT-XXX (de BT-1 à BT-
165, BT-4 n’existant pas), organisées par type (Texte, Code, Identifiant, Montant, Prix Unitaire,
Quantité, 0), organisées en groupes métiers, nommés BG-XX de BG-1 à BG-31, associés à une
cardinalité, c’est-à-dire une règle de présence facultative ou obligatoire ainsi qu’une possibilité
d’occurrence multiple/

• d’un ensemble de règles de gestion : 

✓ 96 règles de gestion liées à la TVA, 

✓ 126 règles de gestion liées à la présence spécifique d'une donnée métier, ou bien liées à des calculs
ou à des règles conditionnelles (si une donnée métier est égale à xxx, alors une autre donnée
métier doit être présente), ou bien exprimant des nombres de décimales pour certains types de
données, des listes de valeurs autorisées (codes) pour certains champs.

• de listes de codes à utiliser pour certaines données et permettant de normaliser les valeurs de certains
champs. Tous ces codes sont hérités des pratiques EDI déployées depuis plus de 30 ans. Par exemple,
le type de facture est défini par un code : 380 signifie « Facture Commerciale », 381 signifie « Avoir »,
384 signifie « Facture Rectificative ¬, 0 De même, les devises sont codifiées par des trigrammes (3
lettres), 0

Cette Norme n’a pas été conçue pour adresser tous les besoins des entreprises, mais leur très grande majorité/
Ainsi, la Norme EN 16931 a été conçue sous hypothèse qu’une facture adresse une seule commande et une
seule livraison. De façon à faire face à des contraintes locales et à des besoins additionnels, la Norme EN
16931 a prévu 2 dispositions complémentaires :

• La capacité à créer des « Spécifications d’Usage » (CIUS pour « Core Invoice Usage Specification »), qui
permettent de resserrer les contraintes de la Norme, par exemple en supprimant des données
facultatives, en renommant certaines données, en réduisant la cardinalité, en restreignant les listes de
AFNOR XP Z12-0122026-02

_Source: `c:\Users\g.baudrit\source\repos\gbaudrit\conf-aimer-votre-llm\demo\ctxc-sample-spec\with-ctxc\spec/afnor/XP_Z12-012/XP_Z12-012.pdf` (page:14/page:14)_

### E-d5e7b6df8e09

XP Z12-012 – Formats et Profils des messages Factures et Statuts de cycle de vie, constitutifs du socle
minimal applicable à la Réforme Facture Électronique en France

13
codes. Ces CIUS restent totalement conformes à la Norme EN 16931 puisqu’elles en respectent toutes
les règles de gestion et la structure de données.

• La capacité à créer des EXTENSIONS, en ajoutant des données ou des groupes de données, en
augmentant la cardinalité, en assouplissant certaines règles de gestion, en ajoutant des valeurs de
listes de codes.

Les exigences réglementaires de la réforme et l’obligation de couvrir tous les cas d’usage des entreprises
nécessitent ainsi de définir 2 profils :

• Un profil intégrant des règles de gestion additionnelles à la Norme EN 16931, ce qui en fait une CIUS.
Il s’agit du profil EN 16931.

• Un profil intégrant des données additionnelles, identifiées par des codes de la forme EXT-FR-FE-XXX,
organisées aussi par groupes identifiés EXT-FR-FE-BG-ZZZ, et quelques modifications de certaines
règles de gestion/ Il s’agit du profil EXTENDED-CTC-FR.

Ces profils sémantiques décrivent donc chacun un arbre de données, en le parcourant branche par branche,
sous-branche par sous-branche jusqu’à atteindre les feuilles qui sont les données/ Le parcours est guidé par
l’indication d’un niveau dans la structure (1 ou N1 : premiers embranchements, 2 ou N2 : seconds
embranchements, etc 0)/

A chaque branche et feuille est associée une cardinalité qui indique si la présence est facultative ou obligatoire,
et si elle est répétable. La codification se fait sous la forme de 2 chiffres séparés de « .. », le premier indiquant
l’occurrence minimale et le second l’occurrence maximale, « n » signifiant « autant d’occurrences que l’on
veut ». Ainsi :

• 0..1 signifie « facultatif et non répétable ; 0..n signifie facultatif et répétable

• 1..1 signifie « obligatoire et une seule fois », 1..n signifie obligatoire et répétable

A la suite de l’adoption de la Directive ViDA, un travail de révision de la Norme EN 16931 est en cours,
conduisant principalement à ajouter des données et à corriger certaines règles de gestion pour adresser un
plus grand nombre de cas d’usage/ Certaines de ces évolutions sont d’ores et déjà présentes dans le profil
EXTENDED-CTC-FR, qui a vocation à accueillir en anticipation le plus possible de ces évolutions de façon à
permettre aux utilisateurs de les utiliser avant que la révision soit effective et déployée, entre 2027 et 2030.
En effet, la Directive ViDA rend obligatoire la facture électronique au format structuré pour toutes les
transactions B2B intracommunautaires, à compter du 1er juillet 2030.

Les deux schémas suivants présentent la structure sémantique des deux profils :

• Profil de la Norme Sémantique EN 16931 . seuls les blocs d’adresse postale ne sont pas détaillés.
Chaque donnée a son identifiant (fond rouge et fond vert pour les données de ligne) et sa cardinalité
(fond bleu marine). La flèche rouge décrit le corps de la structure avec tous les éléments de niveau 1
(en fond gris).

• Profil EXTENDED-CTC-FR : les lignes en marron / violet correspondent aux données ou blocs ajoutés.
En jaune les changements de cardinalité. BG-26, BG-27 et BG-28 sont comme dans le profil EN 16931
(pas détaillées ici). Les nouvelles Parties (EXT-FR-FE-BG-01, à 05) et BG-10 ont la même structure de
données chacune. 
AFNOR XP Z12-0122026-02

_Source: `c:\Users\g.baudrit\source\repos\gbaudrit\conf-aimer-votre-llm\demo\ctxc-sample-spec\with-ctxc\spec/afnor/XP_Z12-012/XP_Z12-012.pdf` (page:15/page:15)_

### E-393f27637659

XP Z12-012 – Formats et Profils des messages Factures et Statuts de cycle de vie, constitutifs du socle minimal applicable à la Réforme Facture Électronique
en France

14   AFNOR
XP Z12-0122026-02

_Source: `c:\Users\g.baudrit\source\repos\gbaudrit\conf-aimer-votre-llm\demo\ctxc-sample-spec\with-ctxc\spec/afnor/XP_Z12-012/XP_Z12-012.pdf` (page:16/page:16)_

### E-cfa1b72a8a8d

XP Z12-012 – Formats et Profils des messages Factures et Statuts de cycle de vie, constitutifs du socle minimal applicable à la Réforme Facture Électronique
en France

15     AFNOR
XP Z12-0122026-02

_Source: `c:\Users\g.baudrit\source\repos\gbaudrit\conf-aimer-votre-llm\demo\ctxc-sample-spec\with-ctxc\spec/afnor/XP_Z12-012/XP_Z12-012.pdf` (page:17/page:17)_

### E-38082b37b236

XP Z12-012 – Formats et Profils des messages Factures et Statuts de cycle de vie, constitutifs du socle
minimal applicable à la Réforme Facture Électronique en France

16
4.2 Implémentations des 2 profils EN 16931 et EXTENDED-CTC-FR

4.2.1 La nécessité de proposer plusieurs profils sémantiques dans le socle minimum

La Norme EN 16931 est une description sémantique. Elle autorise de créer différents profils :

• D’une part des spécifications d’usage (appelée CIUS pour Core Invoice Usage Specification), qui
permettent des restrictions (des données optionnelles supprimées, des cardinalités réduites), mais
qui doivent passer toutes les règles de gestion de la Norme EN 16931.

• D’autre part des EXTENSIONS, qui intègrent des données additionnelles, peuvent étendre la
cardinalité de certaines données, voire assouplir certaines règles de gestion, en supprimer certaines,
en ajouter d’autres, de façon limitée.

Il convient ensuite d’implémenter ces profils dans un format informatique exploitable automatiquement. Les
syntaxes choisies sont les deux syntaxes XML retenues pour l’implémentation de la norme EN 16931 pour le
secteur public en Union Européenne : XML UBL et XML UN/CEFACT CII.

Pour information, une spécification d’implémentation dans la syntaxe EDIFACT a aussi été produite dans les
publications de « Syntax Binding » de la Norme EN 16931, mais est utilisable uniquement sur la base du
volontariat et avec accord bilatéral des 2 parties (Vendeur et Acheteur).

Une autre implémentation a été documentée avec le format mixte Factur-X qui se présente sous la forme
d’une représentation lisible PDF/A-3 à laquelle est joint un fichier de données de facture au format structuré
XML UN/CEFACT CII nommé « factur-x.xml ». Ces données doivent être toutes présentes dans la
représentation lisible. Mais ce format accepte que certaines informations ne soient présentes que dans
le lisible, ce qui donne une plus grande souplesse, notamment pour les informations de facture qui ne sont
pas des mentions obligatoires exigées par l’Administration fiscale ou sur lesquelles aucune règle de gestion et
de contrôle ne s’applique, et qui n’ont donc pas d’utilité pour automatiser le traitement de la facture et ne
remette pas en jeu sa conformité au modèle de données utilisé. Ce format se décline en 5 profils, dont 3
principaux (en gras) :

• Un profil EN 16931 : qui correspond strictement à la Norme EN 16931. Toutes les données présentes
dans le fichier structuré doivent respecter la Norme EN 16931 (et donc toutes les règles de gestion).

• Un profil BASIC : qui est un sous-ensemble du profil EN 16931, contenant toutes les mentions
obligatoires et toutes les règles de gestion de la Norme. Ce profil a été construit pour indiquer aux
entreprises quelles données il faut savoir gérer en priorité. Toute facture conforme au profil BASIC est
aussi conforme au profil EN 16931. Par conséquent, toute facture construite sur la base du profil BASIC
peut se déclarer conforme au profil EN 16931, et il est fortement recommandé de la déclarer en profil
EN 16931. Ce profil n’est donc pas retenu dans le cadre de la réforme facture électronique en
France.

• Un profil BASIC WL : qui est le profil BASIC, mais sans les données de ligne et de charges et remises
de niveau Document/ Ce profil sera autorisé au démarrage de la réforme (jusqu’en septembre 2027, à
confirmer dans la mise à jour des textes)/ Il n’est pas strictement conforme à la Norme EN 16931
puisqu’il manque les lignes qui sont des mentions obligatoires. Toutes les règles de gestion qui
s’appliquent à des données de ligne ou qui les impliquent (les calculs de pied de sommes de lignes et
de charges et remises documents) sont donc exclues pour ce profil.

• Un profil MINIMUM contenant un minimum de données (le strict nécessaire pour être accepté sur
CHORUSPRO). Ce profil ne peut pas être utilisé dans le cadre de la réforme, car il ne contient pas
assez de données sous forme structurée.

• Un profil EXTENDED : qui contient un grand nombre de données additionnelles, comme des Parties
tierces à la transaction commerciale (un Facturant, un Agent d‘Acheteur, un tiers Payeur, un Agent de
Vendeur, 0), de nombreuses données additionnelles, notamment à la ligne/ Ce profil autorise les
factures multi-commande, multi-livraison notamment, avec plus de 700 champs de données, qui sont
identifiées par une nomenclature propre (sous la forme BT-X-ZZZ, BT-X étant fixe pour exprimer
« donnée d’extension »). Quelques règles de gestion ont aussi été ajoutées, en remplacement de celles
AFNOR XP Z12-0122026-02

_Source: `c:\Users\g.baudrit\source\repos\gbaudrit\conf-aimer-votre-llm\demo\ctxc-sample-spec\with-ctxc\spec/afnor/XP_Z12-012/XP_Z12-012.pdf` (page:18/page:18)_

### E-914b05c1dc60

XP Z12-012 – Formats et Profils des messages Factures et Statuts de cycle de vie, constitutifs du socle
minimal applicable à la Réforme Facture Électronique en France

17
de la Norme EN 16931, notamment pour introduire une tolérance dans les règles de calcul pour faire
face à certaines difficultés d’arrondis ou pour gérer des factures construites sur la base de Prix
Unitaires en TTC, mais aussi pour rester compatible avec certains outils logiciels qui calculent la TVA
à la ligne plutôt qu’en pied de facture/

Ceci étant présenté, les profils de données du socle minimum sont les suivants :

• Profil EN 16931 qui correspond à la Norme EN 16931, auquel des règles de gestion additionnelles ont
été ajoutées pour les besoins de conformité aux exigences réglementaires de la réforme facture
électronique en France

• Profil EXTENDED-CTC-FR qui est une extension du modèle sémantique EN 16931, avec un ajout de
données libellées sous la nomenclature EXT-FR-FE-ZZZ, et de groupes libellés EXT-FR-FE-BG-ZZ, ainsi
qu’un ajout de certaines règles de gestion, dont certaines en remplacement de règles de la Norme EN
16931 (pour apporter des tolérances dans les calculs nécessaires pour certains cas d’usage)/

S’agissant de Factur-X, les profils utilisés dans le socle minimum sont les suivants :

• BASIC WL . uniquement jusqu’au 1er septembre 2027/

• EN 16931 : auquel il faut ajouter les règles de gestion additionnelles France décrites au chapitre 4.5.

• EXTENDED : qui contient le profil EXTENDED-CTC-FR et auquel il faut ajouter les règles de gestion
additionnelles France décrites au chapitre 4.5.

En effet, le profil EXTENDED-CTC-FR est en pratique un sous-ensemble (un subset) du profil EXTENDED de
Factur-X. qui d’ailleurs constitue un réservoir de composants d’extension pour enrichir le cas échéant le profil
EXTENDED-CTC-FR quand ceci s’avèrera nécessaire pour adresser certains cas d’usage/ La documentation
Factur-X intègre la correspondance entre ses propres données d’extension et la nomenclature du profil
EXTENDED-CTC-FR (EXT-FR-FE-ZZZ) décrite dans ce document et l’annexe Excel/

Comme toutes les données présentes dans le fichier structuré de Factur-X (factur-x.xml) EXTENDED sont
présentes dans la représentation lisible PDF qui sert d’enveloppe à la facture, le destinataire peut utiliser ou
pas les données additionnelles présentes au-delà du profil EXTENDED-CTC-FR puisqu’il en dispose de toute
façon sous forme lisible, si nécessaire.

4.2.2 L’implémentation dans les syntaxes UBL et UN/CEFACT CII exige une description spécifique

Les syntaxes UBL et UN/CEFACT CII ont leur propre sémantique. Elles sont un ensemble de données, bien plus
riche que la Norme EN 16931, organisées aussi par groupes et sous-groupes de données, avec leurs propres
cardinalités.

La conséquence est que l’implémentation des 2 profils EN 16931 et EXTENDED-CTC-FR en UBL et en
UN/CEFACT CII est le résultat d’un mapping devant faire face à certains écarts sémantiques/ C’est pourquoi la
correspondance d’un XPATH à chaque donnée du modèle sémantique n’est pas suffisante pour décrire
l’implémentation en XML/

Il est donc aussi nécessaire de décrire l’implémentation des 2 profils dans chacune des deux syntaxes, et de
surcroît par profil, puisque la structure des données peut différer au niveau des cardinalités d’un profil à
l’autre/

Ces écarts sémantiques ont conduit à choisir la version D22B pour l’UN/CEFACT CII au lieu de la version D16B
initialement utilisée lors de la publication de la Norme EN 16931 en 2017, parce que la version D16B ne
permettait pas de respecter la cardinalité 0..n du BG-3 (bloc de référence à une facture antérieure), nécessaire
en cas d’avoir se référant à plusieurs factures/
AFNOR XP Z12-0122026-02

_Source: `c:\Users\g.baudrit\source\repos\gbaudrit\conf-aimer-votre-llm\demo\ctxc-sample-spec\with-ctxc\spec/afnor/XP_Z12-012/XP_Z12-012.pdf` (page:19/page:19)_

### E-63ff489af953

XP Z12-012 – Formats et Profils des messages Factures et Statuts de cycle de vie, constitutifs du socle
minimal applicable à la Réforme Facture Électronique en France

18
4.3 Description sommaire de la structure sémantique des données des 2 profils

4.3.1 Le profil EN 16931

Le profil EN 16931 est tout d’abord construit sous hypothèse d’une facture mono commande et mono
livraison.

Les Parties potentiellement en présence sont les suivantes, au nombre de 5 uniquement :

• Un VENDEUR (BG-4), présence obligatoire une fois (cardinalité 1..1), qui est l’émetteur de la facture
(ou celui pour le compte de qui la facture est émise, ceci incluant l’autofacturation)/ C’est surtout la
Partie qui inscrit la transaction en Produits dans ses comptes et qui en général collecte la TVA présente
dans la facture.

• Un ACHETEUR (BG-7), présence obligatoire une fois (cardinalité 1..1), qui est en général le destinataire
de la facture, mais surtout celui qui porte la charge dans ses comptes et peut déduire la TVA présente
dans la facture.

• Un « Livré à » (BG-13), adresse de livraison, optionnelle présente une fois maximum (cardinalité 0..1),
qui permet de désigner où les biens sont livrés ou bien où les services sont exécutés. En cas d’absence
l’adresse de livraison est l’adresse de l’ACHETEUR/ Pour rappel, en France, l’adresse de livraison de
biens est obligatoire si elle est différente de l’adresse de l’ACHETEUR (article 242 nonies A 7bis de
l’annexe II du CGI)/

• Un BÉNÉFICIAIRE (BG-10), optionnel et présent une fois maximum (cardinalité 0..1), qui est celui à
qui la facture est censée être payée/ Ce BÉNÉFICIAIRE est renseigné UNIQUEMENT s’il est différent du
VENDEUR (ce qui se repère par leurs identifiants légaux respectifs)/ D’ailleurs, ce BÉNÉFICIAIRE n’est
désigné que par son nom, son Identifiant légal et un identifiant privé.

• Un REPRÉSENTANT FISCAL DU VENDEUR (BG-11), optionnel et présent une fois maximum
(cardinalité 0..1), qui est obligatoire si le VENDEUR est représenté fiscalement/ A NOTER qu’en cas de
VENDEUR faisant partie d’un groupement d’ASSUJETTI UNIQUE, l’Assujetti Unique, tête de pont du
groupement, doit être identifié dans ce bloc de données (et donc sa dénomination sociale, son numéro
de TVA intracommunautaire et son adresse postale). Par ailleurs, son numéro de SIREN doit être
renseigné en utilisant l’identifiant privé du Vendeur (BT-29), avec le qualifiant 0231.

L’ACHETEUR et le VENDEUR disposent de nombreuses informations pour les définir, à savoir :

• Dénomination sociale et Nom commercial

• Identifiant légal, Numéro de TVA intracommunautaire

• Identifiant privé, qualifié car se rapportant à un référentiel. Par exemple un GLN est un identifiant
qualifié avec le code 0188. Pour ceux qui souhaitent ajouter un numéro de SIRET, le qualifiant est 0009.
Pour un Code_Routage, le qualifiant est 0224/ Pour le numéro de SIREN de l’assujetti unique, le code
est 0231.

• Une adresse postale

• Un bloc de données de contact

• UNE ADRESSE ÉLECTRONIQUE NORMALISÉE, qui pour le destinataire (l’ACHETEUR en général) est
l’adresse électronique à laquelle il souhaite recevoir sa facture (adresse sous la forme SIREN_XXX
référencée dans l’Annuaire PPF)/ Pour l’émetteur (le VENDEUR en général), c’est l’adresse
électronique à laquelle il souhaite recevoir ses statuts de cycle de vie. Ces adresses électroniques sont
les données nécessaires à l’échange des factures au travers d’un réseau de Plateformes Agréées
interopérées. Elles sont donc obligatoires dans les factures (règle de gestion BR-FR-12 et BR-FR-
13) et doivent donc être intégrés dans les référentiels clients / fournisseurs des solutions de gestion
des entreprises au même titre que l’identifiant légal, la dénomination sociale, l’adresse postale, 0
AFNOR XP Z12-0122026-02

_Source: `c:\Users\g.baudrit\source\repos\gbaudrit\conf-aimer-votre-llm\demo\ctxc-sample-spec\with-ctxc\spec/afnor/XP_Z12-012/XP_Z12-012.pdf` (page:20/page:20)_

### E-a54750386c82

XP Z12-012 – Formats et Profils des messages Factures et Statuts de cycle de vie, constitutifs du socle
minimal applicable à la Réforme Facture Électronique en France

19
Il existe ensuite de nombreuses références, de niveau document, qui permettent de faire face déjà à un grand
nombre de situations :

• Une référence acheteur (BT-10) . à la main de l’ACHETEUR, et qui lui sert normalement à orienter les
factures dans son organisation interne/ C’est donc souvent un numéro de Business Unit, une référence
de service, une boîte postale interne, 0

• Une référence de Bon de Commande générée par l’ACHETEUR (BT-13) : donnée souvent exigée pour
tous les processus d’achat qui passe par la génération d’un Bon de Commande (Purchase Order),
transmis au moment de la commande, et pas après la livraison ou la facturation. Pour rappel, en
vertu de l'article L. 441-9 du Code de commerce, la facture doit mentionner le numéro du bon de
commande lorsqu'il a été préalablement établi par l'acheteur.

• Une référence de Contrat (BT-12) : nécessaire en particulier pour les services récurrents gérés sans
numéro de bon de commande (fluides, téléphonie, 0)/

• Une référence à la ou les factures antérieures (BG-3, BT-25), essentiellement pour les AVOIRS ou les
factures rectificatives. Cette donnée peut aussi être utile en cas de facture finale après facture
d’acompte (nécessitant une donnée additionnelle, cf profil EXTENDED-CTC-FR).

• Une référence d’Avis d’Expédition (BT-16) : qui annonce la livraison et sert souvent de Bon de
Livraison.

• Une référence de Bon de Réception (BT-15) : qui peut être utile dans des processus de chaine
d’approvisionnement très intégrés/

• Une référence de Bon de Vente (BT-14) . parfois confondue avec le Bon de Commande/ C’est la
référence de commande générée par le VENDEUR, qui lui permet de suivre la transaction/ C’est une
donnée très souvent utilisée en achat auprès de fournisseurs de frais généraux, ou d’achat en ligne/

• Une référence d’Objet facturé (BT-18) . qui est une donnée où le type d’objet facturé est codifié dans
une liste qu’il faut respecter/ Ceci peut être utile pour gérer des références propres à certaines activités
(un numéro de plaque d’immatriculation, un numéro de compteur, un numéro de téléphone facturé,
une référence interne de client ou de dossier, 0)/

• Une référence de Projet (BT-11) : peut être utilisée par exemple pour identifier un chantier dans le
secteur de la construction.

• Une référence d’Appel d’Offres ou de numéro de Lot (BT-17).

• Une référence comptable de l’ACHETEUR (BT-19), par exemple pour permettre une affectation en
comptabilité analytique/ Cette donnée doit donc être fournie par l’ACHETEUR/

• Une période de facturation (BG-14), utile notamment pour tous les services d’abonnements ou pour
les remises de fin d'année pour lesquels il est nécessaire de préciser une période de référence.

Ensuite, ce profil contient les informations classiques d’une facture :

• Numéro (BT-1), Date (BT-2), Type (BT-3) : un code permettant de qualifier le type de facture (facture
commerciale, avoir, facture rectificative, facture d’acompte, facture autofacturée, 0)

• Devise (BT-5) . a priori la devise de facture s’applique à tous les prix et montants/ La seule exception
est le montant total de TVA qui peut aussi être présenté dans une autre Devise : la Devise de
comptabilité (BT-6)/ C’est pourquoi il existe 2 données pour le montant total de TVA (l’objectif étant
que l’une des 2 soit l’EURO car l’Administration fiscale exige le montant de TVA en EURO) :

✓ Le Montant Total de TVA dans la Devise de la facture : BT-110 (devise égale à BT-5).

✓ Le Montant Total de TVA dans la Devise de comptabilisation : BT-111 (devise égale à BT-6).

• Date d’échéance (BT-9), sachant qu’il est aussi possible de donner des informations relatives aux
conditions de paiement en BT-20, via un texte libre qui peut donc contenir par exemple « Paiement 30
jours net ».
AFNOR XP Z12-0122026-02

_Source: `c:\Users\g.baudrit\source\repos\gbaudrit\conf-aimer-votre-llm\demo\ctxc-sample-spec\with-ctxc\spec/afnor/XP_Z12-012/XP_Z12-012.pdf` (page:21/page:21)_

### E-2fb007062d54

XP Z12-012 – Formats et Profils des messages Factures et Statuts de cycle de vie, constitutifs du socle
minimal applicable à la Réforme Facture Électronique en France

20
• Date d’exigibilité de la TVA (BT-7), qui n’est pas utilisée comme ceci en France, mais sous la forme d’un
évènement en BT-8, pour indiquer si la TVA est exigible à la date de facture ou la date de livraison
(TVA au débit) ou bien à la date de paiement (TVA à l’encaissement)/ La BT-8 est obligatoire
uniquement pour les factures de services pour lesquelles le VENDEUR a opté pour les débits. Sinon,
elle peut être présente ou non.

• Les instructions de paiement (BG-16), qui permettent d’abord d’indiquer le moyen de paiement
souhaité et la référence de paiement attendue, puis de renseigner un ou plusieurs comptes bancaires
à payer par virement, mais aussi des informations relatives à un prélèvement (la facture faisant office
de notification), et enfin à des informations de carte bancaire si ce moyen est utilisé, uniquement à des
fins de rapprochement (seule une partie du numéro de carte seulement est fournie).

• Et enfin une Note (BG-1), répétable, constituée d’un code sujet pour qualifier son utilisation, et d’un
texte libre. Ceci permet de compléter de données annexes, souvent peu exploitables (car sous forme
de texte tout juste qualifié et pas codifié). Ceci permet de loger tout ce qui ne rentre pas dans la Norme
EN16931, mais avec le risque d’une lisibilité beaucoup moins pertinente que la représentation lisible
habituelle en papier ou en PDF/ C’est en particulier pour cela que le format Factur-X a été conçu : allier
lisibilité habituelle et données structurées minimum réglementaire utiles.

Le profil est complété ensuite par des données de lignes et des données de remises et charges de niveau
Document (qui peuvent être vues comme des lignes particulières). 

Tout d’abord les lignes, qui sont un ensemble de données assez réduites :

• Numéro de ligne (BT-126) et Note de ligne (BT-127)

• Identifiant d‘Objet Facturé (BT-128), référence d’entête aussi utilisable en ligne/

• Référence de la ligne du Bon de commande auquel se rapporte la ligne de facturation (BT-132). Donc
il n’y a pas de référence à la ligne de la réception ou de la livraison par exemple, qui est utile pour le
rapprochement dit « 3 points ».

• Référence comptable de l’ACHETEUR (BT-133), qui peut donc être fournie à la ligne.

• Identification de l’article : 

✓ Nom (BT-153), Description (BT-154)

✓ Codes articles du VENDEUR (BT-155), de l’ACHETEUR (BT-156), voire identifiant standard à
qualifier (BT-157), par exemple un numéro GTIN.

✓ Un ou plusieurs identifiants de classification de l’article (référentiel UNSPSC par exemple), avec
une liste de référentiels disponible (cf liste de codes UNTDID 7143).

✓ Pays d’origine (BT-159)

✓ Attributs (BG-32), répétable, bloc de 2 données à savoir une qualification de la donnée, puis sa
valeur. Par exemple COULEUR - ROUGE/ C’est une façon de renseigner à peu près n’importe quoi,
mais sous forme de texte libre « nature de l’information / valeur de l’information ». Ce bloc
attribut peut s’enrichir en profil EXTENDED de Factur-X d’un code qualifiant la donnée de façon
plus standardisée.

• Détermination du Prix Unitaire HT :

✓ Prix Unitaire Brut (BT-148), Rabais (BT-147) sur Prix Unitaire Brut

✓ Prix Unitaire Net (BT-146) qui est celui qui est obligatoire pour la Norme EN16931

✓ Quantité de base du Prix Unitaire (BT-149), parce qu’il est possible de définir des Prix Unitaires
pour des quantités données (par exemple un Prix pour 1 000 vis). Cette quantité est associée à
une unité de mesure de la quantité (BT-150 . pièce, kg, litre, kw, 0 la liste des unités est normée
et très longue)/ Ceci permet notamment de gérer des sujets d’arrondis quand les prix unitaires
sont très faibles ou nécessitent beaucoup de décimales (un prix pour 1 000 permet de gagner en
précision : par exemple 2 euros pour 1 000 vis plutôt que 0,002€ par vis)/
AFNOR XP Z12-0122026-02

_Source: `c:\Users\g.baudrit\source\repos\gbaudrit\conf-aimer-votre-llm\demo\ctxc-sample-spec\with-ctxc\spec/afnor/XP_Z12-012/XP_Z12-012.pdf` (page:22/page:22)_

### E-1ce77fb6a0fb

XP Z12-012 – Formats et Profils des messages Factures et Statuts de cycle de vie, constitutifs du socle
minimal applicable à la Réforme Facture Électronique en France

21
• Quantité facturée (BT-129) et son unité (BT-130)

• Remises et charges de lignes qui sont 2 blocs distincts, répétables et constitués chacun :

✓ Du montant de la Remise / Charge (BT-136 / BT-141)

✓ D’une assiette (base) et d‘un taux, donnée facultative

✓ D’un motif en code ou en texte, l’un des deux étant obligatoire/

• D’un montant total HT de ligne (BT-131)

• D’un code TVA et taux/ La TVA est en effet encodée avec un code de catégorie (Standard, Exemption,
Autoliquidation, 0 cf chapitre dédié ci-dessous), et d‘un taux en pourcentage/

A ceci s’ajoutent donc des Remises et Charges de niveau document, qui sont définies de façon semblable :

• Un montant de Remises ou Charges (BT-92 / BT-99)

• Une base et un taux (données facultatives)

• Un Motif en code et / ou en texte (l’un des deux au moins étant obligatoire).

• Une catégorie et un taux de TVA

Ces Remises ou Charges de niveau document peuvent être vues comme des lignes particulières (surtout les
charges)/ Leur somme est d’ailleurs suivie de façon distincte en pied de facture/

Le profil est complété par les données pied de facture et pied de TVA dont les règles de calcul sont décrites
dans la suite de ce document :

• Le pied de TVA contient par catégorie et taux de TVA 

✓ la base HT sur laquelle le taux va s’appliquer (BT-116),

✓ le taux de TVA applicable (0 si pas de TVA), (BT-119),

✓ le montant de TVA (BT-117) dans la devise de la facture (BT-5),

✓ En cas d’exonération, le motif d’exonération sous forme de texte ou de code (les codes VATEX
gérés par la Commission Européenne).

• Les totaux de la facture :

✓ A commencer par des sous-totaux : Total HT des lignes (BT-106), Total HT des Remises de
Document (BT-107), Total HT des Charges de Documents (BT-108)

✓ Puis les totaux permettant d’arriver au TTC : Total HT de la facture (BT-109), Total TVA (BT-110,
en devise de facture et BT-111 en devise de comptabilisation BT-6), Total TTC (BT-112).

✓ S’ajoutent ensuite des données permettant de définir le Montant à payer : Montant déjà payé (BT-
113), par exemple pour des acomptes, Montant arrondi (BT-114) car il arrive qu’on arrondisse à
l’euro au-dessus, et enfin le Montant NET à PAYER (BT-115).

Le profil permet enfin de joindre des Documents Justificatifs additionnels (BG-24), constitué d’un identifiant,
d’une description, puis d’un fichier, soit en donnant un lien d’accès (URL), soit joint, en général encodé en
base64.

4.3.2 Le profil EXTENDED-CTC-FR

L’étude des cas d’usage montre que la Norme EN16931 ne permet pas d’adresser tout l’existant en matière
d’information apparaissant dans les factures, puisque qu’elle a été conçue pour adresser les besoins essentiels.

Il est donc apparu nécessaire de définir un profil étendu, dénommé EXTENDED-CTC-FR. Ce profil a vocation à
vivre et se maintenir, sous contrainte forte de compatibilité ascendante de façon que l’évolution du profil
n’oblige pas ceux qui n’ont pas besoin des évolutions à modifier leurs chaines de traitements/
AFNOR XP Z12-0122026-02

_Source: `c:\Users\g.baudrit\source\repos\gbaudrit\conf-aimer-votre-llm\demo\ctxc-sample-spec\with-ctxc\spec/afnor/XP_Z12-012/XP_Z12-012.pdf` (page:23/page:23)_

### E-91fe0a109134

XP Z12-012 – Formats et Profils des messages Factures et Statuts de cycle de vie, constitutifs du socle
minimal applicable à la Réforme Facture Électronique en France

22
Pour ce faire, les Plateformes Agréées et les Solutions Compatibles des entreprises intégrant des
fonctionnalités de validation de facture DOIVENT utiliser la dernière version des outils de validation publiés
pour chacun des profils.

Ce profil EXTENDED-CTC-FR a ajouté quelques nouveaux acteurs qui jouent un rôle dans la transaction
commerciale et le traitement des factures, ce qui rend parfois nécessaire leur désignation dans les factures. Il
s’agit de :

• L’AGENT d’ACHETEUR (EXT-FR-FE-BG-01), qui peut agir pour le compte de l’ACHETEUR, souvent
dans la phase de commande, et donc de validation ou pré-validation (« Visée ») des factures.

• Le PAYEUR (EXT-FR-FE-BG-02), qui peut être un tiers différent de l’ACHETEUR/ Ce peut être une filiale
ou la société mère d’un groupe, mais aussi un client final en cas de sous-traitance avec paiement direct.

• L’AGENT de VENDEUR (EXT-FR-FE-BG-03), qui peut agir pour le compte du vendeur (un distributeur
par exemple), et peut jouer un rôle dans le processus de création et de validation des factures à
émettre, voire dans le suivi des statuts de cycle de vie.

• « L’ADRESSÉ À » (EXT-FR-FE-BG-04), qui est plus justement nommé dans les standards le « Facturé à »
est la Partie à qui la facture est transmise parce qu’il est en charge de son traitement pour le compte
de l’ACHETEUR/ Toutefois, l’utilisation de plusieurs adresses de facturation électroniques pour la
réception de factures permet de ne pas utiliser cette capacité à transmettre les factures à un tiers, mais
juste de permettre à ce tiers de traiter les factures adressées à l’ACHETEUR sur une adresse de
facturation électronique (une boîte aux lettres de réception des factures) dont la gestion est confiée à
ce tiers par l’ACHETEUR/ Toutefois, lorsque l’ADRESSÉ [ est nommé dans la facture, cela permet à la
PA-R (de réception) de gérer des droits de délégation de façon plus ciblée pour lui permettre d’avoir
accès à la facture et aux actions de traitement pour lesquelles il lui a été donné délégation. Ce tiers peut
aussi permettre de satisfaire aux exigences de l’article 441-9 du Code du Commerce qui impose que
l’adresse postale de l’entité qui reçoit et traite la facture pour le compte de l’ACHETEUR soit renseigné
(adresse de facturation si différente de l’adresse du client (ACHETEUR), qu’il faut interpréter comme
adresse postale de facturation).

• Le FACTURANT (EXT-FR-FE-BG-05), qui est le tiers qui crée et émet la facture pour le compte du
VENDEUR, sous mandat de facturation.

Pour tous ces nouveaux acteurs, la structure des données de description est la même et proche de celles du
VENDEUR et de l’ACHETEUR, sauf que seule la Raison Sociale est obligatoire (pas l’adresse postale), et qu’il a
été ajouté un « CodeRole ¬ permettant de mieux qualifier le rôle du tiers/ C’est en particulier nécessaire pour
le BÉNÉFICIAIRE, qui a été aligné sur ces acteurs en termes de données disponibles. Le code Rôle « DL »
permet ainsi d’indiquer que le BÉNÉFICIAIRE est un Affactureur/

De façon à permettre l’utilisation de factures multi-commandes et multi-livraisons, la plupart des références
de niveau Document ont été ajoutées à la ligne :

• Numéro de Bon de commande (EXT-FR-FE-135)

• Référence à la facture antérieure (une par ligne), avec la possibilité d’ajouter le type de facture
antérieure, ce qui permet de faire des reprises d’acompte en ligne et d‘indiquer qu’il s‘agit d’une
reprise d’acompte pour permettre une juste comptabilisation automatique/

• Adresse et date de livraison à la ligne

• Avis d’expédition, Bon de réception, Bon de Vente à la ligne, avec à chaque fois la possibilité de
renseigner le numéro de ligne de ces documents qui correspond à la ligne de facturation.

• Un code sujet à la note de ligne, associée à un changement de cardinalité (0..1) permettant l’utilisation
de plusieurs notes de ligne de facture.
AFNOR XP Z12-0122026-02

_Source: `c:\Users\g.baudrit\source\repos\gbaudrit\conf-aimer-votre-llm\demo\ctxc-sample-spec\with-ctxc\spec/afnor/XP_Z12-012/XP_Z12-012.pdf` (page:24/page:24)_

### E-f341adefde1e

XP Z12-012 – Formats et Profils des messages Factures et Statuts de cycle de vie, constitutifs du socle
minimal applicable à la Réforme Facture Électronique en France

23
Il a aussi été ajouté quelques données, notamment du fait de leur utilité pour le secteur public, ou pour
respecter les exigences de la réforme :

• Une donnée de type de contrat (EXT-FR-FE-01), venant compléter le numéro de contrat (BT-12)

• Un changement de cardinalité de la BT-46 (0..n au lieu de 0..1) . identifiant privé de l’ACHETEUR,
permettant de renseigner l’identifiant privé habituel, mais aussi un numéro de SIRET, un
Code_Routage.

• Un codetype de la facture antérieure (BG-3), (EXT-FR-FE-02).

• Le changement de cardinalité de l’identifiant d’objet facturé en ligne (BT-128) et au niveau Document
(BT-18), permettant de disposer de plusieurs références nécessaires dans certains cas d’usage/

Pour satisfaire certaines exigences opérationnelles et certains cas d’usage, les données suivantes ont aussi été
ajoutée :

• Pour permettre l’établissement de factures avec différentes raisons d’exemption, plus généralement
de distinction plus détaillée de la ventilation de TVA :

✓ Une raison d’exemption de TVA en texte (EXT-FR-FE-178) et en code (EXT-FR-FE-179), qui pourra
être utilisée pour préciser un contexte TVA à reprendre en ventilation de TVA/ Il s’agit d’une
anticipation de la révision de la Norme nécessaire dès aujourd’hui/

✓ De même, une raison d’exemption en texte (EXT-FR-FE-187) et en code (EXT-FR-FE-188) des
remises de niveau document, en charges de niveau document (EXT-FR-FE-189 / EXT-FR-FE-190).

✓ La suppression des règles BR-S-10 et BR-Z-10 pour ce profil EXTENDED-CTC-FR, de façon à
permettre l’utilisation de ces données en ligne et des données correspondantes en ventilation de
TVA (BT-120 et BT-121)

✓ La mise à jour des règles de calcul de ventilation de TVA (règles de TVA BR-S-8, BR-Z-8, 0)
supprimées du profil EXTENDED-CTC-FR avec ajout de règles modifiées applicables uniquement
sur le profil EXTENDED-CTC-FR. Ces règles anticipent un changement important de la révision de
la Norme EN16931 qui consiste à ce que le détail TVA tienne compte des motifs d’exemption en
texte (BT-120) et en code (BT-121) tels que présents dans les lignes, les charges et remises de
niveau document. Pour accompagner la transition qui impose aussi de renseigner les motifs
d’exemption en lignes et charges et remises document, les contrôles avec et sans raison
d’exemption sont exécutés et si l’un d’eux suffit pour un contrôle passant, l’autre étant en
« warning » pour information et rappel.

• Pour la gestion des transactions internationales : les conditions de livraison (EXT-FR-FE-BG-14) que
sont 

✓ les codes INCOTERMS (EXT-FR-FE-185).

✓ et le nom du lieu où se matérialise le transfert de propriété (EXT-FR-FE-186).

• Pour mieux qualifier les attributs d’articles deux données ont été ajoutées (aussi présentes dans la
révision de la Norme EN16931) :

✓ Un code permettant de qualifier le type d’attribut à la place ou en complément de sa dénomination
(EXT-FR-FE-159), à choisir dans la liste 6313.

✓ Une Valeur d’attribut (EXT-FR-FE-160) associée à une unité de mesure (EXT-FR-FE-161), en lieu
et place d’une valeur en texte (BT-161).

✓ Par exemple, ceci permet de codifier un attribut de « 25 g de CO2 » : 

➢ Code (EXT-FR-FE-159) : BRL (Dioxyde de Carbone)

➢ Une Valeur mesurée (EXT-FR-FE-160) : 25

➢ Une unité de mesure EXT-FR-FE-161) : GRM (gramme)
AFNOR XP Z12-0122026-02

_Source: `c:\Users\g.baudrit\source\repos\gbaudrit\conf-aimer-votre-llm\demo\ctxc-sample-spec\with-ctxc\spec/afnor/XP_Z12-012/XP_Z12-012.pdf` (page:25/page:25)_

### E-00c9b776f1de

XP Z12-012 – Formats et Profils des messages Factures et Statuts de cycle de vie, constitutifs du socle
minimal applicable à la Réforme Facture Électronique en France

24
• Pour la gestion des articles composites (par exemple un livre-jouet), des kits, des besoins de sous-
totaux ou de regroupement d’information de ligne, une possibilité de gérer des sous-lignes :

✓ Un identifiant de ligne Parent (EXT-FR-FE-162) permettant de lier une ligne de facture à une autre
pour indiquer leur dépendance (notion de sous-ligne)

✓ Un sous-type de ligne (EXT-FR-FE-163), permettant de distinguer des lignes d’information ou de
regroupement, dont les données ne sont pas reprises dans les calculs de totaux de factures, avec
des lignes dites de « Détail ¬ qui sont, avec les lignes n’utilisant pas ce qualifiant, les lignes de
facturation intervenant dans les calculs et transmis au PPF (flux 1 et flux 10.1).

✓ Une quantité dans une unité de la ligne Parent (EXT-FR-FE-191), servant à donner le détail de
composition d’une unité d’une ligne GROUP avec ses lignes DETAIL.

✓ La création de règles de gestion pour tenir compte de cette possibilité de sous-ligne dans les
totaux.

✓ L’utilisation de sous-lignes est précisée en chapitre 4.4.

• Pour la gestion des factures multi-vendeurs, créés par ou pour le compte d’intermédiaires transparent
agissant pour le compte de plusieurs Vendeurs, à destination d’un ACHETEUR unique :

✓ Un Vendeur en ligne (EXT-FR-FE-BG-12), contenant les mêmes types d’information que le
VENDEUR (BG-4), sauf le bloc d’information de contact/

✓ Un Montant de TVA à la ligne (EXT-FR-FE-181) dans la devise de la facture (BT-5)

✓ Un Montant de TVA à la ligne (EXT-FR-FE-182) dans la devise de comptabilisation (BT-6)

✓ Un total TTC de ligne (EXT-FR-FE-184)

✓ Un code d’exigibilité de TVA (EXT-FR-FE-185, Débits / Encaissements), équivalent de la BT-8 au
niveau de la facture.

✓ L’implémentation des factures multi-vendeurs est précisée en chapitre 4.4.

L’autre ajout de ce profil est la modification de certaines règles de gestion :

• pour permettre une tolérance de 0,01 centime par ligne ou remise ou charge de niveau Document dans
les calculs de sommes en pied de facture ou en pied de TVA,

• pour permettre une facture réunissant des lignes hors scope (Catégorie TVA = O) et d’autres lignes (ce
que la Norme EN16931 interdit pour l’instant), les règles BR-O-2, BR-O-3, BR-O-4, BR-O-11, BR-O-12,
BR-O-13, BR-O-14 ont été supprimées pour le profil EXTENDED-CTC-FR.

Toutes les évolutions, tous les ajouts de données, remplacement / suppression de règles de gestion du profil
EXTENDED-CTC-FR sont aussi répliqués de la même façon dans le profil EXTENDED de Factur-X.

4.3.3 Évolution de la Norme

Dans le cadre des travaux européens du CEN TC434, la Norme EN16931 fait l’objet d’une révision. Celle-ci
aura pour conséquence essentielle d’intégrer les évolutions du profil EXTENDED-CTC-FR dans la norme sauf
l’ajout des Parties additionnelles qui restera du domaine des Extensions/

Le modèle sémantique de la Norme EN 16931 Révisée a été approuvé mi-février et sera publié dans les
semaines suivantes. Son implémentation dans les syntaxes UBL et CII (et aussi EDIFACT) est en cours (vote
prévu sur le second trimestre 2026).

Quand elle sera publiée et opérationnelle, les profils décrits dans ce document seront amenés à évoluer. En
attendant, les évolutions qui s’avèrent nécessaires pour la mise en œuvre opérationnelle de la réforme facture
électronique en France seront ajoutées progressivement à chaque nouvelle version dans le profil EXTENDED-
CTC-FR (et EXTENDED de Factur-x). L’objectif est de permettre à ceux qui ont besoin des données
additionnelles de les utiliser, mais aussi à se préparer à la mise en œuvre de la révision de la norme EN16931/
AFNOR XP Z12-0122026-02

_Source: `c:\Users\g.baudrit\source\repos\gbaudrit\conf-aimer-votre-llm\demo\ctxc-sample-spec\with-ctxc\spec/afnor/XP_Z12-012/XP_Z12-012.pdf` (page:26/page:26)_

### E-1b035c294475

XP Z12-012 – Formats et Profils des messages Factures et Statuts de cycle de vie, constitutifs du socle
minimal applicable à la Réforme Facture Électronique en France

25
Un des impacts de la révision de la Norme est de permettre des factures intégrant plusieurs motifs
d’exemption de TVA, qui peuvent être portés dans les lignes de factures ainsi que dans les remises et charges
de niveau document, nécessitant d’en tenir compte dans les contrôles de pied de TVA/

Il est aussi rendu possible d’utiliser ces raisons d’exemption pour les catégories TVA « S » et « Z » pour
apporter des informations nécessaires au suivi de la TVA dans la facture.

Ceci a été intégré dans cette version pour le profil EXTENDED-CTC-FR :

• d’abord, en ajoutant les raisons d’exemption en ligne (version précédente) et en remise et charge de
niveau document,

• ensuite, en adaptant les règles de contrôle en pied de TVA qui pour l’instant supporte la prise en
compte des motifs d’exemption (BT-120 / BT-121) ou pas, en indiquant la règle qui n’est
éventuellement pas respectée, pour information (en « warning »). Ceci permet de préparer les
utilisateurs à renseigner les motifs d’exemption aussi en ligne et remises et charges de niveau
document, sans que ceci ne soit bloquant pour l’instant/

Cette possibilité est aussi essentielle pour la gestion des factures multi-vendeur dans la mesure ou le motif
d’exemption en texte est utilisé pour identifier les différentes sous-factures et produire ainsi un pied de TVA
par sous-facture.

La tolérance de non prise en compte des motifs d’exemption en ligne et remise et charge de niveau document
pour le profil EXTENDED-CTC-FR se poursuivra jusqu’à l’été 2026 au minimum/

4.3.4 Évolution du profil EXTENDED-CTC-FR et Profil EXTENDED de Factur-X

Le profil EXTENDED de factur-X met à disposition un très grand nombre de données additionnelles. Il a été
conçu par le FNFE-MPE en collaboration avec le FeRD (Forum Allemand), et s’appuie sur les pratiques des
entreprises en matière d’échange EDI (EDIFACT notamment)/

Pour son utilisation, il faut se procurer la documentation Factur-X, qui intègre les composants de validation.
Ce profil permettra aux équipes de maintenance du profil EXTENDED-CTC-FR de trouver les éléments
nécessaires pour adresser certains besoins spécifiques relevés dans le cadre de l’inventaire des cas d’usage.

Le profil EXTENDED-CTC-FR intègre désormais les motifs d’exemption TVA en ligne et remise et charge de
niveau document, ainsi que dans les contrôles de ventilation de TVA (BG-23). Il est important que toutes les
factures qui relèvent du profil EXTENDED-CTC-FR renseignent les motifs d’exemption de TVA en ligne, remise
et charge de niveau document dès lors que la catégorie TVA est différente de « S » et « Z ». Pour les catégories
différentes de « E », le code VATEX utilisable est normalement prédéterminé simplement :

• O (Hors scope) : VATX-EU-O

• G (Export) : VATEX-EU-G

• K (Livraison intracommunautaire) : VATEX-EU-IC

• AE (autoliquidation) : VATEX-EU-AE (pour toute autoliquidation, y compris des ventes de services en
UE) ou VATEX-FR-AE (possible pour indiquer une autoliquidation domestique)

En cas de Catégorie TVA égale à « E », il faut renseigner soit le code VATEX dans la liste autorisée (Liste
VATEX), soit un motif en texte, soit les deux, mais strictement de la même façon que ce qui est renseigné en
pied de TVA.

Cette évolution est aussi essentielle pour la gestion des factures multi-vendeur dans la mesure ou le motif
d’exemption en texte est utilisé pour identifier les différentes sous-factures et produire ainsi un pied de TVA
par sous-facture.

La tolérance de non prise en compte des motifs d’exemption en ligne et remise et charge de niveau document
pour le profil EXTENDED-CTC-FR se poursuivra jusqu’à l’été 2026 au minimum/
AFNOR XP Z12-0122026-02

_Source: `c:\Users\g.baudrit\source\repos\gbaudrit\conf-aimer-votre-llm\demo\ctxc-sample-spec\with-ctxc\spec/afnor/XP_Z12-012/XP_Z12-012.pdf` (page:27/page:27)_

### E-8e344d05ffc4

XP Z12-012 – Formats et Profils des messages Factures et Statuts de cycle de vie, constitutifs du socle
minimal applicable à la Réforme Facture Électronique en France

26
4.4 Points d’attention particuliers

4.4.1 Types de données

Chaque donnée du modèle sémantique correspond à un type de données qui en détermine le format, lui-même
basé sur un des quatre types primitifs suivants : Binary (binaire), Date, Décimal, String (texte).

Les types de données sont alors les suivants (pour plus de détails, voir chapitre 6.5 de la Norme Sémantique
EN 16931-1:2019 (E)) :

• Montant (Amount) : il s’agit d’un type « Décimal » avec 2 chiffres après la virgule maximum, sans
séparateur de millier, et avec le « . ¬ comme séparateur décimal/ Il peut être complété d’un attribut
« Devise », si différent de la devise en entête/ L’UBL exige toujours la Devise, le CII ne l’exige que
lorsqu’un montant peut être exprimé dans une autre devise que celle de la facture (le montant de TVA
BT-111 en devise de comptabilisation (BT-6) si différente de la devise de la facture (BT-5)). Exemple
10000.34

• Montant de prix unitaire : il s’agit d’un type « Décimal » sans séparateur de millier, et avec le « . »
comme séparateur décimal. Il peut être complété d’un attribut « Devise », si différent de la devise en
entête. Exemple 1000.3454/ Il n’y a pas de règle de nombre de décimales, mais l’usage et surtout la
révision de la Norme EN16931 limitent les prix unitaires à 4 décimales.

• Quantité (Quantity) : il s’agit d’un type « Décimal » sans séparateur de millier, et avec le « . » comme
séparateur décimal. Exemple 10000.85476/ Il n’y a pas de règle de nombre de décimales, mais l’usage
et surtout la révision de la Norme EN16931 limite les quantités à 4 décimales. 

• Pourcentage (Percentage) : il s’agit d’un type « Décimal » sans séparateur de millier, et avec le « . »
comme séparateur décimal. Pour appliquer ce pourcentage au montant auquel il s’applique, il
convient, dans les calculs, de diviser la valeur du pourcentage indiqué par 100. Pour un taux de TVA à
20%, la valeur est donc de 20. Exemple 24.1234 pour un pourcentage de 24,1234 %. Il n’y a pas de
règle de nombre de décimales, mais l’usage et surtout la révision de la Norme EN16931 limitent les
pourcentages à 2 décimales.

• Identifiant (Identifier) : il s’agit d’un type potentiellement composé de 3 champs texte (décrits dans
la documentation détaillée) :

✓ La valeur de l’identifiant (texte)/ Par exemple FR13456789321 pour un n° de TVA
intracommunautaire

✓ Un Schéma d’identification (Scheme Identifier), donnée obligatoire si plusieurs Schémas
d’Identification sont possibles permettant de qualifier le référentiel de l’identifiant/ Par exemple,
le qualifiant « VA ¬ permet de préciser que l’identifiant est un numéro de TVA
intracommunautaire en CII. En UBL, il faut utiliser « VAT ».

✓ Une version du Schéma d’identification (Scheme version Identifier), donnée facultative en texte

• Référence de Document (Document Reference) : il s’agit d’une donnée de type texte

• Date : les dates sont représentées sous la forme AAAAMMJJ en UN/CEFACT CII et AAAA-MM-JJ en UBL

• Texte : texte libre, en type texte

• Code : il s’agit d’un code en type texte, qui est accompagné d’un attribut identifiant la liste dont il
provient, et potentiellement de la version de la liste et de l’identifiant de l’agence publiant la liste.

• Objet Binaire (Binary Object) : il s’agit d’un type potentiellement composé de 3 champs :

✓ Le contenu, obligatoire, en donnée binaire,

✓ Le type de fichier (Mime Code), en texte, à prendre dans une liste prédéfinie,

✓ Le nom du fichier (Filename), en texte.
AFNOR XP Z12-0122026-02

_Source: `c:\Users\g.baudrit\source\repos\gbaudrit\conf-aimer-votre-llm\demo\ctxc-sample-spec\with-ctxc\spec/afnor/XP_Z12-012/XP_Z12-012.pdf` (page:28/page:28)_

### E-5b6ea53f33b0

XP Z12-012 – Formats et Profils des messages Factures et Statuts de cycle de vie, constitutifs du socle
minimal applicable à la Réforme Facture Électronique en France

27
4.4.2 Gestion des données de profils et cadre de facturation

De façon à organiser le traitement des factures, il est nécessaire qu’elles contiennent des informations
identifiant le profil et le processus transactionnel sous-jacent.

Ceci est réalisé au travers de 2 données essentielles :

• BT-24 : type de profil, qui identifie le profil du message, à distinguer entre profils EN 16931,
EXTENDED-CTC-FR et les profils de Factur-X :

✓ Profil EN 16931 : urn:cen.eu:en 16931:2017

✓ Profil EXTENDED-CTC-FR : 
urn:cen.eu:en 16931:2017#conformant#urn.cpro.gouv.fr:1p0:extended-ctc-fr

✓ Pour Factur-x :

➢ Pour le profil BASIC WL : urn:factur-x.eu:1p0:basicwl

➢ Pour le profil BASIC :  urn:cen.eu:en 16931:2017#compliant#urn:factur-x.eu:1p0:basic

➢ Pour le Profil EN 16931 : urn:cen.eu:en 16931:2017

➢ Pour le Profil EXTENDED :  
urn:cen.eu:en 16931:2017#conformant#urn:factur-x.eu:1p0:extended

• BT-23 : indique le processus sous-jacent et est utilisé en France pour codifier à la fois certains
processus et le fait que la facture soit une facture de Biens, de Services, ou Mixte c’est-à-dire composée
de lignes de ventes de Biens et de lignes de vente de Services indépendantes, les unes n’étant pas
accessoire aux autres. Cette caractéristique est codifiée respectivement par la première lettre du Cadre
de facturation B, S, M. La règle BR-FR-08 indique les valeurs possibles de ce cadre de facturation.

Il est aussi nécessaire de déterminer si une facture relève d’un traitement « e-invoicing » ou e-reporting de
Vente B2B internationale, ou e-reporting B2C ou hors réforme, 0 En effet, il n’existe pas de règle simple
permettant de déterminer de façon certaine qu’une facture relève du « e-invoicing ».

Cette indication peut être codifiée dans le canal de transmission des factures entre l’émetteur et sa Plateforme
Agréée, mais peut aussi l’être dans la facture elle-même. Dans ce cas, la règle à respecter est la BR-FR-20 qui
utilise une note avec le code sujet « BAR » et des valeurs codifiées à renseigner.

4.4.3 Gestion des Notes

Un certain nombre de mentions obligatoires ou conditionnellement obligatoires n’ont pas d’existence propre
dans le modèle EN 16931 et sont alors codifiées au travers d’une Note (texte en BT-22), avec un code sujet
dédié (en BT-21). Il en est de même pour les notes de ligne (Contenu : BT-127, code sujet : EXT-FR-FE-183).
Les règles BR-FR-05, BR-FR-06, BR-FR-07 indiquent la codification attendue.

Parmi l’ensemble des codes sujets, la liste ci-dessous détaille ceux à utiliser en fonction des sujets les plus
courants :

• AAB . Mention d’escompte/

• AAI : Information générale : des éléments en général en fond de page des factures papier.

• ABL : Information légale : par exemple N° registre des métiers, RCS.

• ACC : Clause de subrogation factoring.

• ADN . permet d’indiquer le fait que la facture relève des obligation B2G en France (valeur B2G, cf règle
BR-FR-CPRO-00).

• BAR . permet d’indiquer la nature du traitement attendu, cf Règle BR-FR-20.

• BLU : "Eco-participation (L. 541-10 du code de l'environnement)" ou "Eco-contribution DEEE". Peut
servir aussi à d'autres taxes dont l'écotaxe CUS : Information douanière.
AFNOR XP Z12-0122026-02

_Source: `c:\Users\g.baudrit\source\repos\gbaudrit\conf-aimer-votre-llm\demo\ctxc-sample-spec\with-ctxc\spec/afnor/XP_Z12-012/XP_Z12-012.pdf` (page:29/page:29)_

### E-215a2eb5712a

XP Z12-012 – Formats et Profils des messages Factures et Statuts de cycle de vie, constitutifs du socle
minimal applicable à la Réforme Facture Électronique en France

28
• DCL : déclaration du créateur de la facture, en cas de mandat de facturation : « facture établie par A au
nom et pour le compte de B ».

• PMT . Mention de l’indemnité forfaitaire de 40 € pour frais de recouvrement/

• PMD : Mention pénalités de retard.

• SUR : Remarques fournisseur.

• TXD . Mention de Membre d’Assujetti Unique/

4.4.4 Gestion des avoirs

Il y a 2 façons de gérer des avoirs :

• « Facture négative » : Il s’agit d’une facture dont le total TTC est négatif, 

✓ soit parce que la facture contient des lignes négatives dont la somme est supérieure en valeur
absolue à la somme des lignes positives (cas notamment des factures finales avec reprise sur
acompte ou estimation comme les factures d’énergie, pour lesquelles il peut aussi arriver qu’une
facture n’ait que des lignes de reprises négatives),

✓ soit parce qu’elle ne contient que des lignes négatives et annule en général ainsi une facture (sauf
cas exceptionnel où il n’y a pas de lignes positives comme indiqué ci-dessus)/ Il s’agit donc d’un
avoir, qui doit faire référence à la facture ou à la période à laquelle il se rattache. Au niveau des
lignes, le prix unitaire est positif et ce sont les quantités qui sont négatives. Les règles de calcul
restent les mêmes et conduisent à avoir des lignes négatives, puis des totaux négatifs (y compris
le détail de TVA sur les bases HT et les montants de taxe). Dans ce cas, les montants des remises
et charges sont aussi inversés (donc négatifs). Les types de document (donnée BT-3) qui peuvent
ainsi faire l’objet de ce procédé sont ceux correspondant à des factures (il n’est donc pas autorisé
de construire des avoirs négatifs pour faire des factures).

• « Avoir » : ceci correspond aux documents « typés avoirs ¬ (comme 381, 261, 0)/ Dans ce cas,
l’ensemble des montants totaux de lignes ou de pieds de page sont du même signe que la facture que
l’avoir annule, ce qui n’empêche pas d’avoir des lignes dont le montant total est négatif, comme c’est
possible sur une facture/ Il n’est en revanche pas possible (autorisé suivant la norme sémantique)
d’avoir des avoirs négatifs, c’est-à-dire d’utiliser un avoir négatif pour annuler un avoir précédent
positif/ Dans ce cas, il faut créer une facture référençant l’avoir/ Il n’est pas autorisé non plus d’avoir
des Avoirs avec un total TTC négatif dès lors qu’il est le résultat de lignes positives et de lignes
négatives, ce qui pourrait se produire en particulier pour les avoirs annulant des factures négatives du
fait de lignes négatives l’emportant sur les lignes positives. Dans ce cas, il est préférable de faire des
factures rectificatives qui annulent et remplacent les factures négatives erronées.

En France, la pratique la plus répandue est de codifier un avoir qui annule une facture par le type « avoir ».
Ainsi, l’ensemble des données de l’avoir est le même que celui de la facture qu’il annule/ Les seules
modifications sont le numéro de facture d’avoir (qui doit suivre la séquence chronologique, comme les
factures), la date de l’avoir, et le numéro de facture que l’avoir annule, ainsi que la date d’échéance
potentiellement.

La représentation « facture négative ¬ est utilisée lorsqu’elle résulte d’un calcul de facturation qui conduit à ce
résultat, du fait de reprises sur factures antérieures (estimation, acomptes, consignes, palettes, 0)/

Toutefois, il existe des pays en Europe qui pratiquent exclusivement la facture négative (même pour des avoirs
annulant uniquement une facture).
AFNOR XP Z12-0122026-02

_Source: `c:\Users\g.baudrit\source\repos\gbaudrit\conf-aimer-votre-llm\demo\ctxc-sample-spec\with-ctxc\spec/afnor/XP_Z12-012/XP_Z12-012.pdf` (page:30/page:30)_

### E-1987d416c029

XP Z12-012 – Formats et Profils des messages Factures et Statuts de cycle de vie, constitutifs du socle
minimal applicable à la Réforme Facture Électronique en France

29
4.4.5 Règle de calcul

La règle de calcul des factures (hors factures B2C dans lesquelles le Prix Unitaire est souvent indiqué en TTC)
est la suivante :

• Au niveau de chaque ligne, le montant net de ligne (BT-131) est égal :

✓  au prix unitaire net (positif, BT-146), le cas échéant divisé par la quantité de base du prix BT-149
qui indique la quantité de chaque lot de produit vendu, multiplié par la quantité facturée (positive
ou négative, BT-129), arrondi à 2 décimales.

✓ diminué des montants de remises de ligne (BT-136), qui est déjà arrondi à 2 décimales,

✓ augmenté des montants de charges ou frais de ligne (BT-141), qui est déjà arrondi à 2 décimales.

✓ Cette règle de calcul n'est pas régie par une règle « schematron » car elle n'est pas requise par la
norme EN 16931 pour l’instant. Elle sera ajoutée dans la révision de la Norme avec une tolérance
pour gérer les problématiques d’arrondi/

✓ Il convient de noter aussi que l’unité de mesure de la quantité de base du Prix unitaire (BT-149)
DOIT être égale à l’unité de la quantité facturée (BT-130), pour que le calcul soit juste. En effet, si
le prix unitaire est par gramme et que la quantité mesurée en kilogramme, le calcul ci-dessus
serait faux d’un facteur 1 000.

• Ensuite, les totaux au niveau document s’organisent de la façon suivante, et sont vérifiés dans le cadre
des règles de gestion de la Norme EN 16931 (BR-XX) :

✓ La Somme des montants nets de ligne (BT-106), égale à la somme des montants nets de lignes
calculés ci-dessus (BT-131),

✓ La Somme des remises au niveau du document (BT-107), égale à la somme des montants des
remises au niveau du document (BT-92), voir BR-CO-11.

✓ Somme des charges ou frais au niveau du document (BT-108) égale à la somme des montants de
charges ou frais au niveau du document (BT-99), voir BR-CO-12.

✓ Le total hors taxes de la facture (BT-109), est égal (BR-CO-13) :

➢ au total des montants nets de ligne (BT-106),

➢ diminué du total des Remises au niveau document (BT-107),

➢ augmenté du total des Charges ou frais au niveau document (BT-108),

✓ Le total du montant de TVA (BT-110) est égal à la somme des montants de TVA (BT-117) par taux
et type de TVA, voir BR-CO-14.

✓ Le type de TVA permet de distinguer les différents cas où la TVA n’est pas applicable notamment/
Le montant de TVA par taux correspond à la base hors taxes de chaque taux de TVA multiplié par
le taux de TVA, divisé par 100 et arrondi à 2 décimales. La base hors taxe de chaque taux de TVA
est égale à la somme des montants nets de ligne (BT-131) qui relèvent de ces mêmes taux et type
de TVA, augmentée de la somme des montants nets de Charges ou frais de document (BT-108) qui
relèvent de ces mêmes taux et type de TVA, diminuée de la somme des montants nets de Remises
de document (BT-107) qui relèvent de ces mêmes taux et type de TVA.

Pour le profil EXTENDED-CTC-FR (et la révision de la Norme à venir) ce calcul s’enrichit de
critères additionnels :

➢ d’abord sur les raisons d’exemption en texte (EXT-FR-FE-178) et en code (EXT-FR-FE-179) en ligne,
ainsi qu’en remises et charges de niveau document (EXT-FR-FE-187, EXT-FR-FE-188, EXT-FR-FE-189,
EXT-FR-FE-190), en cohérence avec le couple BT-120 / B-121 en ventilation de TVA (BG-23),

➢ ensuite pour la prise en compte uniquement des lignes sans sous-type de ligne (EXT-FR-FE-163) ou
avec un sous-type de ligne égal à « DETAIL ».
AFNOR XP Z12-0122026-02

_Source: `c:\Users\g.baudrit\source\repos\gbaudrit\conf-aimer-votre-llm\demo\ctxc-sample-spec\with-ctxc\spec/afnor/XP_Z12-012/XP_Z12-012.pdf` (page:31/page:31)_

### E-2b0c48064763

XP Z12-012 – Formats et Profils des messages Factures et Statuts de cycle de vie, constitutifs du socle
minimal applicable à la Réforme Facture Électronique en France

30
✓ Le montant total TTC (BT-112) de la facture est égal à la somme du montant total hors taxes (BT-
109) et du montant total de TVA (BT-110), voir règle BR-CO-15.

✓ Le montant d’acompte (BT-113) est égal au montant déjà payé avant établissement de la facture
ou payé par ailleurs ou par un tiers et qui viendra en déduction du montant TTC pour établir le
Net à payer par l’ACHETEUR au VENDEUR ou au BÉNÉFICIAIRE.

✓ Dans certains cas, il peut exister un montant d’arrondi (BT-114) à ajouter pour déterminer le
montant net à payer.

✓ Le montant net à payer (BT-115) est égal au montant total TTC (BT-112) diminué du montant
d’acompte (BT-113), et le cas échéant augmenté du montant d’arrondi (BT-114), voir règle BR-CO-
16.

Comme ces règles de calcul peuvent ne pas être respectées en cas de calcul de la TVA au niveau de la ligne ou
pour les factures dont les prix sont définis en TTC, TVA comprise (en particulier pour les factures B2C), le
profil EXTENDED-CTC-FR (et EXTENDED de Factur-X) introduit une tolérance de 0,01 € par ligne et par remise
charge ou frais au niveau du document dans les différentes sommes de calcul impliquées.

4.4.6 Règle d’arrondi dans les calculs

Les règles de calcul d’une facture nécessitent un calcul d’arrondi à certaines étapes (dès qu’il y a multiplication
ou division)/ La méthode d’arrondi est celle de la valeur la plus proche, avec la règle pour la détermination de
la fraction résiduelle à 0,5 suivante :

• Pour les nombres positifs : arrondi à la valeur supérieure. Par exemple, 13,455 arrondi à 2 chiffres
donne 13,46.

• Pour les nombres négatifs . arrondi à la valeur inférieure (de façon à ce qu’un arrondi de 2 nombres
strictement opposés donne des nombres arrondis strictement opposés). Par exemple, -13,455 donne
-13,46.

4.4.7 Gestion de la TVA

Pour chaque ligne de facture, il est nécessaire de qualifier la TVA applicable. Il existe plusieurs raisons qui
conduisent à une absence de TVA ou une TVA ramenée à 0 dans la facture. Ainsi la codification des différentes
catégories de TVA est la suivante :

• S : Taux de TVA standard, dont il faut ensuite indiquer le taux.

• Z : taux de TVA égal à 0/ Ce cas ne s’applique pas en France pour l’instant/

• E : Exempté de TVA. A utiliser si aucun autre des cas d’absence de TVA ne s’applique/ Dans ce cas il
est obligatoire d’indiquer dans le détail de TVA en pied la raison de l’exemption en faisant référence à
la disposition fiscale qui s’applique/

• AE : Autoliquidation de TVA. Dans ce cas, la TVA est due par le client qui doit la déclarer et la régler
directement à l’administration fiscale (en général, il procède simultanément à la déductibilité de la
même TVA)/ La raison d’absence de TVA qu’il faut indiquer dans le détail de TVA en pied est
« Autoliquidation ». Le Code VATEX à utiliser est VATEX-EU-AE ou le cas échéant VATEX-FR-AE en cas
d’Autoliquidation de TVA sur facture domestique, VATEX-EU-AE étant aussi utilisable de préférence.

• K : Autoliquidation pour cause de livraison intracommunautaire. Il s’agit du mécanisme
d’autoliquidation, mais qui s’applique du fait d’une livraison intra-communautaire de biens. Par
conséquent, c’est ce code « K ¬ qu’il faut alors utiliser au lieu du code « AE ¬/ La raison d’absence de
TVA qu’il faut indiquer dans le détail de TVA en pied est « Livraison intracommunautaire ». Le Code
VATEX à utiliser est VATEX-EU-IC.

• Cas des ventes de services en UE : les ventes de services en UE sont des ventes soumises à
l’autoliquidation de la TVA par le preneur et ne sont pas des livraisons intracommunautaires de biens.
Bien que le code catégorie K signifie « Exemption de TVA pour vente intracommunautaire de biens ou
de services », la règle fiscale conduit à utiliser le code catégorie AE et le code VATEX-EU-FR pour ces
AFNOR XP Z12-0122026-02

_Source: `c:\Users\g.baudrit\source\repos\gbaudrit\conf-aimer-votre-llm\demo\ctxc-sample-spec\with-ctxc\spec/afnor/XP_Z12-012/XP_Z12-012.pdf` (page:32/page:32)_

### E-fe48530e408c

XP Z12-012 – Formats et Profils des messages Factures et Statuts de cycle de vie, constitutifs du socle
minimal applicable à la Réforme Facture Électronique en France

31
ventes de service en UE/ Une confirmation d’application de cette règle de façon uniforme en UE est en
cours d’instruction/

• G : Exempté de TVA pour Export hors Union Européenne, le Code VATEX à utiliser est VATEX-EU-G.
Les ventes de service hors UE utilisent aussi le même code catégorie G et le même code VATEX-EU-G,
en attendant une solution plus précise à l’échelle européenne en cours d’instruction/

• O : Hors du périmètre d'application de la TVA. Dans ce cas, il ne peut pas y avoir d’autres catégories
de TVA dans la facture (règle BR-O-11 de la Norme EN 16931). Le Code VATEX à utiliser est VATEX-
EU-O. Par contre, le profil EXTENDED-CTC-FR (et EXTENDED de Factur-X) a supprimé la règle BR-O-
11, ce qui permet de faire des factures avec des lignes en catégorie O et d‘autres lignes sur d’autres
catégories de TVA. 

• L (IGIC) et M (IPSI) : non applicable en France et en Allemagne puisqu’il s’agit de régimes de TVA
respectivement pour les Iles Canaries et Ceuta / Melilla.

En pied de facture, chaque catégorie de TVA présente dans les lignes doit être présente dans la ventilation de
TVA, avec la base Hors Taxes égale à la somme des montants hors taxes des lignes de la catégorie de TVA, le
code de catégorie de TVA, le taux de TVA (égal à 0 en cas d’exemption et non présent en cas « hors périmètre :
O), le montant de TVA (nul si pas de TVA), et dans tous les cas sauf « S », la raison de TVA nulle.

4.4.8 Gestion des taxes autres que la TVA, cas de l’éco-contribution DEEE

Lorsque des biens ou services sont soumis à des taxes autre que la TVA, deux situations se présentent :

• La taxe est soumise à la TVA au même taux que le produit ou service auquel elle s’applique : dans ce
cas, la taxe est gérée comme une charge sur la ligne de facture. Une raison (BT-144) ou un code de
raison (BT-145) permet d’identifier qu’il s’agit d’une taxe/

✓ Dans le cadre de la révision de la Norme EN 16931, une liste de codes dédiée pour qualifier le type
de taxe sera ajoutée. Elle sera prise en compte dans les profils EXTENDED-CTC-FR / EXTENDED
dans une version ultérieure de la présente Norme.

• La taxe n’est pas soumise à la TVA ou est soumise à un taux de TVA différent de celui du bien ou service
auquel elle se réfère : dans ce cas, la taxe est codifiée comme une ligne de service additionnelle.

Comme il peut exister un grand nombre de taxes parafiscales, une pratique assez largement utilisée est de
s’appuyer sur des lignes articles spécifiques en utilisant une codification proposée par GS1 au travers de GTIN
(identifiants d’articles à positionner en BT-157 avec SchemeID en BT-157-1 égal à 160) listés sur ce lien :
https://www.gs1.fr/publication/liste-taxes-assimilees.

De même, lorsqu’une taxe s’applique à l’ensemble de la facture (au niveau document), elle peut être traitée
comme une charge au niveau document, pour laquelle on peut indiquer une raison (BT-104) ou un code de
raison (BT-105), puis définir la TVA qui s’applique (ou pas) en BT-102 et BT-103.

En particulier, l’information sur l’éco-contribution DEEE doit figurer dans les factures. Elle est généralement
intégrée au prix unitaire et est donnée comme information (« dont xx,xx € éco-contribution ») dans une note
de ligne (BT-127) et / ou dans une note de Document (BT-21 = « BLU », BT-22)/ Elle n’a aucune utilité pour
l’intégration de la facture par l’acheteur.

4.4.9 Gestion des remises et charges

La gestion des remises et charges est gérée à 3 niveaux :

• Au niveau du document, pour des remises ou des charges globales sur la facture. Ces remises et charges
sont proches de lignes additionnelles. Elles ont par exemple leur propre TVA. Elles sont présentes sur
l’ensemble des profils/ Elles font l’objet d’une somme dédiée dans le bloc de « Totaux de Document »
BG-22 (respectivement BT-108 et BT-107).

• Au niveau de la ligne, relative à la ligne facture, ayant le même taux de TVA que la ligne (sinon elles
doivent être insérées de façon indépendante comme une ligne positive pour des charges et négative
pour une remise). Elles sont intégrées au montant net de ligne BT-131 (qui est donc égal à la quantité
AFNOR XP Z12-0122026-02

_Source: `c:\Users\g.baudrit\source\repos\gbaudrit\conf-aimer-votre-llm\demo\ctxc-sample-spec\with-ctxc\spec/afnor/XP_Z12-012/XP_Z12-012.pdf` (page:33/page:33)_

### E-8aaa0deead13

XP Z12-012 – Formats et Profils des messages Factures et Statuts de cycle de vie, constitutifs du socle
minimal applicable à la Réforme Facture Électronique en France

32
multipliée par le prix net augmenté de la somme des charges et diminué de la somme des remises de
la ligne).

• Au niveau du prix unitaire, uniquement pour un rabais (BT-147) qui permet de passer d’un prix
unitaire brut (BT-148), qui contient donc d’éventuelles charges ou taxes (comme par exemple
l’écotaxe), à un prix unitaire net (BT-146). 

Dans la syntaxe XML UN/CEFACT CII D22B, les remises et charges sont codifiées avec le même objet
« SpecifiedTradeAllowanceCharge » en CII et « cac :AllowanceCharge » en UBL, qui doit donc être qualifié par
l’indicateur « ChargeIndicator » qui doit être égal (udt:Indicator en CII, cbc :Chargeindicator en UBL) à « false »
pour une remise et à « true » pour une charge. Il en est de même en UBL.

Les montants de remise et charge sont tous les deux positifs (sauf s’il est nécessaire de signifier une reprise
de remise ou charge, par exemple dans le cas d’un avoir exprimé sous forme de facture négative)/

Dans la description, ce bloc est donc répété d’une part pour les remises, puis d’autre part pour les charges,
pour une meilleure compréhension.

Ces remises et charges sont des blocs optionnels et répétables (cardinalité 0..n).

Le bloc « SpecifiedTradeAllowanceCharge » en UN/CEFACT CII et « cac :AllowanceCharge » en UBL, est
également utilisé uniquement pour l’application d’une remise correspondant à un rabais (BT-147) sur le prix
brut (BT-148) pour constituer le prix net (BT-146), sachant, pour rappel, que le prix brut est facultatif dans la
Norme EN 16931 contrairement au prix net qui est une donnée obligatoire. Toutefois, le prix unitaire brut
peut être obligatoire, comme c'est le cas en France, s'il diffère du prix unitaire net. 

4.4.10 Gestion des Codes

Un certain nombre de champs de données doivent être choisis dans des listes de codes. Ceux-ci font partie des
spécifications de la Norme EN 16931 et mis à jour tous les six mois, applicable les 15 mai et 15 novembre de
chaque année/ Il s‘agit en général d’un enrichissement, c’est-à-dire de nouveaux codes. Il peut arriver de façon
très exceptionnelle que certains codes soient déréférencés/ C’est la seule source de non-compatibilité
ascendante, qui reste très anecdotique. Il convient donc de suivre les évolutions de ces listes de codes pour en
mesurer les éventuels impacts/ Ils sont publiés plus d’un mois avant leur mise en application.

4.4.11 Gestion des sous-lignes en profil EXTENDED-CTC-FR (et EXTENDED de Factur-X)

Pour certains cas d’usage, il est nécessaire de fournir :

• des sous-totaux regroupant des lignes de facturation,

• ou bien de fournir des informations de sous-articles composant un article principal vendu (par
exemple un kit de boite à outil regroupant une boîte et différents outils),

• ou bien de décomposer un article en articles élémentaire qui ont leurs propres taux de TVA, comme
par exemple un livre-jouet qui est l’article acheté et livré, mais qui est composé d’un livre avec TVA à
10% et d’un jouet avec TVA à 20%,

• ou de regrouper des lignes par transaction, comme une ligne de transport, avec ses sous-lignes de
complément et d’option (supplément Gasoil, supplément week-end, 0),

• ou d’avoir des lignes avec des sous-totaux, par exemple par livraison, par commande, 0

Et bien sûr, ceci peut se construire à plusieurs niveaux, par exemple une ligne GROUP pour détailler une
livraison parmi d’autres, avec des sous-lignes d’articles composites, qui ont eux-mêmes des sous-lignes de
DETAIL, et ainsi de suite.

Pour gérer tous ces cas d’usage, il est nécessaire d’abord de permettre un regroupement de ligne de façon
hiérarchique en utilisant la donnée « Identifiant de ligne Parent » (EXT-FR-FE-162), qui indique le numéro de
ligne à laquelle une ligne est attachée.

Ensuite, de façon à ne pas additionner plusieurs fois la même chose (par exemple en additionnant des
montants de ligne et des sous-totaux), une qualification des lignes est nécessaire de façon à distinguer d’abord
AFNOR XP Z12-0122026-02

_Source: `c:\Users\g.baudrit\source\repos\gbaudrit\conf-aimer-votre-llm\demo\ctxc-sample-spec\with-ctxc\spec/afnor/XP_Z12-012/XP_Z12-012.pdf` (page:34/page:34)_

### E-09c35ded2d97

XP Z12-012 – Formats et Profils des messages Factures et Statuts de cycle de vie, constitutifs du socle
minimal applicable à la Réforme Facture Électronique en France

33
les lignes de facture à prendre en compte dans les calculs des totaux et pied de TVA, puis ensuite à distinguer
des lignes de regroupement et de sous-total de simples lignes d’information/

Pour ce faire la donnée « sous-type de ligne » (EXT-FR-FE-163) doit alors être utilisée avec les valeurs :

• DETAIL : est une ligne entrant dans les calculs de totaux et de TVA, avec les lignes « standard » sans
qualifiant de sous-type de ligne. Ce sont aussi les lignes qui DOIVENT faire l’objet des extractions de
données pour la constitution des flux 1 et 10.1 (cf règle BR-FR-MAP-24).

• INFORMATION . est une ligne donnant des informations additionnelles, pour lesquelles l’ensemble des
données d’une ligne peut être utilisé ou pas. Ceci conduit à ce que la présence obligatoire du prix
Unitaire Net (BT-146), de la quantité facturée (BT-129) et son unité de mesure (BT-130), les
informations de TVA (BG-30) et du total HT de ligne (BT-131) deviennent optionnelles (règles BR-
FREXT-09). En cas de présence du montant HT de ligne (BT-131), celui-ci n’est pas pris en compte
dans les calculs de totaux et de pied de TVA, cf règles de gestion TVA BR-FREXT-ZZZ)

• GROUP, qui peut être vue comme une ligne INFORMATION particulière, avec données optionnelles,
mais pour lesquelles la présence du montant HT de ligne (BT-131) impose que celui-ci soit alors égal
aux montants HT des sous-lignes qui lui sont directement attachées et ont un sous-type de ligne égal
à DETAIL ou GROUP (cf BR-FREXT-08). Par conséquent, dès lors qu’une ligne de type GROUP dispose
d’un montant HT de ligne, alors les lignes GROUP qui ui sont rattachées DOIVENT avoir aussi un
montant HT de ligne.

Exemple d’utilisation 1 : Utiliser les lignes « INFORMATION » pour compléter la description de l’article : La
vente de 2 kits « Boite à outil », contenant chacun 3 pinces et 5 marteaux et 1 tournevis (et donc 6 pinces et 10
marteaux et 2 tournevis en tout). Le prix est fixé au niveau du KIT, les lignes « INFORMATION » donnent le
détail. Les lignes en bleu sont groupées. La ligne 1 aurait pu être qualifiée « DETAIL » aussi. La lignes 2 est une
ligne d’information additionnelle indépendante/ La ligne 3 est une ligne classique/ 

Exemple d’utilisation 2 : des articles composites multi-taux de TVA : Livre jouet. Les totaux et la TVA se
calculent sur les lignes DETAIL (50 et 75)/ La ligne GROUP ne donne pas d’information TVA car elle n’aurait
aucun sens/ Elle n’est pas transmise en flux 1 ou 10/1.
AFNOR XP Z12-0122026-02

_Source: `c:\Users\g.baudrit\source\repos\gbaudrit\conf-aimer-votre-llm\demo\ctxc-sample-spec\with-ctxc\spec/afnor/XP_Z12-012/XP_Z12-012.pdf` (page:35/page:35)_

### E-da60bbf2fa12

XP Z12-012 – Formats et Profils des messages Factures et Statuts de cycle de vie, constitutifs du socle
minimal applicable à la Réforme Facture Électronique en France

34 
A NOTER : le numéro de ligne n’a pas besoin de répliquer la structure (1.1, 1.2). L’identifiant de ligne Parent
suffit à le faire.

Exemple d‘utilisation 3 : des sous-lignes pour les lier à une ligne principale : une prestation de transport,
avec une ligne principale, qui peut contenir plusieurs données et des références (ici Objet facturé pour un
numéro de colis, mais il peut y avoir aussi l’adresse de prise en charge, l’adresse de livraison, des références
clients, 0) qu’il n’est pas nécessaire de répéter à chaque sous-ligne de complément de prestation (suppléments
divers). 

Exemple d‘utilisation 4 : plusieurs niveaux de sous-lignes : la vente de 2 présentoirs composés chacun de 3
paquets de Kenya Roast, 6 paquets de Dark Roast, et 3 Bundle eux-mêmes composés de 3 paquets de Columbia
Roast et 3 MUG, avec potentiellement des taux de TVA applicable différents (pour l’exemple)/ Ceci illustre le
fait que l’organisation des lignes peut se faire à plusieurs niveaux/ Là encore seules les lignes DETAIL comptent
dans les calculs de totaux et de ventilation de TVA, et sont transmises dans les flux 1 et 10.1.
AFNOR XP Z12-0122026-02

_Source: `c:\Users\g.baudrit\source\repos\gbaudrit\conf-aimer-votre-llm\demo\ctxc-sample-spec\with-ctxc\spec/afnor/XP_Z12-012/XP_Z12-012.pdf` (page:36/page:36)_

### E-e7868b3c8c38

XP Z12-012 – Formats et Profils des messages Factures et Statuts de cycle de vie, constitutifs du socle
minimal applicable à la Réforme Facture Électronique en France

35 
4.4.12 Factures multi-vendeurs

De nombreux cas d’usage mettent en jeu un intermédiaire transparent qui facturent un ACHETEUR unique
pour le compte de plusieurs vendeurs, mais dans une facture consolidée unique. Par exemple les factures de
fournitures d’eau regroupent aussi des prestations d’assainissement vendues par d’autres vendeurs. Des
sociétés de réservation de taxi facturent mensuellement des clients professionnels pour le compte de chaque
taxi, 0

Pour permettre une continuité de pratique, une extension spécifique a été ajoutée au profil EXTENDED-CTC-
FR/ L’objectif est de permettre un regroupement de plusieurs factures unitaires de plusieurs VENDEURS
dans une facture unique pour l’ACHETEUR, qui la traite comme une facture classique. Cependant, la création
des flux 1 et 10.1 DOIT être faite par facture unitaire.

4.4.12.1 Modalités de création d’une facture Multi-Vendeurs

A priori, la facture Multi-Vendeurs contient une facture unitaire par Vendeur, mais il est envisageable d’avoir
plusieurs factures différentes d’un même Vendeur/

Cependant, toutes les factures unitaires DOIVENT avoir la même Date de facture (BT-2) et le même type
de facture (BT-3).

Pour identifier ces factures particulières, le Cadre de facturation (BT-23) DOIT être choisi parmi les 3 valeurs
suivantes : B8 (facture de Biens) ; S8 (facture de Services) ; M8 (facture mixte avec des lignes de Biens et des
lignes de service), à utiliser dès lors que cette facture regroupe des factures unitaires qui ne sont pas toutes
soit de Biens soit de Services.

La facture multi-Vendeurs fait appel à la gestion des sous-lignes, en créant pour chaque facture unitaire, une
ligne (BG-25) de type « GROUP » non attachée à une autre ligne (donc avec un sous-type de ligne (EXT-FR-FE-
163) égal à « GROUP » et sans Identifiant de ligne Parent (EXT-FR-FE-162)), dans laquelle seront présentes
toutes les informations spécifiques à la facture unitaire, à savoir :

• le Vendeur en ligne (EXT-FR-FE-BG-12), correspondant au bloc BG-4 de la facture unitaire, dont :

✓ la dénomination sociale (EXT-FR-FE-164),

✓ l’identifiant légal du Vendeur en ligne (EXT-FR-FE-167),

✓ Le numéro de TVA intracommunautaire (EXT-FR-FE-168), correspondant au BT-31 de la facture
unitaire, et le cas échéant l’identifiant fiscal (EXT-FR-FE-169), correspondant au BT-32 (utilisé par
exemple par un Franchisé en Base n’ayant pas de n° de TVA),
AFNOR XP Z12-0122026-02

_Source: `c:\Users\g.baudrit\source\repos\gbaudrit\conf-aimer-votre-llm\demo\ctxc-sample-spec\with-ctxc\spec/afnor/XP_Z12-012/XP_Z12-012.pdf` (page:37/page:37)_

### E-efde18552405

XP Z12-012 – Formats et Profils des messages Factures et Statuts de cycle de vie, constitutifs du socle
minimal applicable à la Réforme Facture Électronique en France

36
✓ le pays de l’adresse du Vendeur en ligne,

• le numéro de facture unitaire, codifié avec l’Identifiant d’objet facturé à la ligne (BT-128), avec le
qualifiant (BT-128-1) égal à AFL, correspondant à la BT-1 de la facture unitaire,

• le cadre de facturation codifié avec l’Identifiant d’objet facturé à la ligne (BT-128), avec le qualifiant
(BT-128-1) égal à AVV, correspondant à la BT-23 de la facture unitaire,

• le code d’exigibilité de TVA (EXT-FR-FE-180), correspondant au BT-8 de la facture unitaire (car il est
possible que certaines factures unitaires soient au débit et d‘autres à l’encaissement,

• le Montant de TVA à la ligne (EXT-FR-FE-181) dans la devise de la facture (BT-5), qui permettra de
fournir le montant total TVA de facture unitaire en devise de facture (BT-110),

• le Montant de TVA à la ligne (EXT-FR-FE-182) dans la devise de comptabilisation (BT-6), qui permettra
de fournir le montant total TVA de facture unitaire en devise de comptabilisation (BT-111),

• le Montant total TTC de ligne (EXT-FR-FE-184), qui permettra de fournir le montant total TTC de
facture unitaire (BT-112).

• Il n’est pas nécessaire de renseigner les informations de catégorie TVA, de taux et de raison
d’exemption en texte ou code (elles ne seront pas utilisées dans les calculs).

Ensuite, les lignes de chaque facture unitaire DOIVENT respecter les règles suivantes :

• Contenir le numéro de facture unitaire (codifié avec l’Identifiant d’objet facturé à la ligne (BT-128, avec
le qualifiant (BT-128-1) égal à AFL).

• Contenir l’identifiant légal du Vendeur en ligne (EXT-FR-FE-167).

• Pour permettre une ventilation de TVA par facture unitaire, la raison d’exemption en texte de ligne
(EXT-FR-FE-178) DOIT commencer par le numéro de facture entre # suivi du texte d’exemption si
applicable.
AFNOR XP Z12-0122026-02

_Source: `c:\Users\g.baudrit\source\repos\gbaudrit\conf-aimer-votre-llm\demo\ctxc-sample-spec\with-ctxc\spec/afnor/XP_Z12-012/XP_Z12-012.pdf` (page:38/page:38)_

### E-b506b7b9ed2e

XP Z12-012 – Formats et Profils des messages Factures et Statuts de cycle de vie, constitutifs du socle minimal applicable à la Réforme Facture Électronique
en France

37  AFNOR
XP Z12-0122026-02

_Source: `c:\Users\g.baudrit\source\repos\gbaudrit\conf-aimer-votre-llm\demo\ctxc-sample-spec\with-ctxc\spec/afnor/XP_Z12-012/XP_Z12-012.pdf` (page:39/page:39)_

### E-1da16d780020

XP Z12-012 – Formats et Profils des messages Factures et Statuts de cycle de vie, constitutifs du socle
minimal applicable à la Réforme Facture Électronique en France

38  
AFNOR XP Z12-0122026-02

_Source: `c:\Users\g.baudrit\source\repos\gbaudrit\conf-aimer-votre-llm\demo\ctxc-sample-spec\with-ctxc\spec/afnor/XP_Z12-012/XP_Z12-012.pdf` (page:40/page:40)_

### E-9dc123a9a10a

XP Z12-012 – Formats et Profils des messages Factures et Statuts de cycle de vie, constitutifs du socle
minimal applicable à la Réforme Facture Électronique en France

39
La ventilation de TVA se calcule dans le respect des règles du profil EXTENDED-CTC-FR, avec pour clé de
somme partielle la Catégorie TVA (BT-118), le taux de TVA (BT-119), la raison d’exemption en texte (BT-120)
et en code (BT-121) utilisables aussi pour les catégories S et Z, et uniquement pour les lignes « DETAIL » ou
sans sous-type de ligne, ainsi que les remises ou charges de niveau document.

4.4.12.2 Numéro de facture unitaire :

De façon à garantir son unicité, il convient de le préfixer ou suffixer avec un élément qui garantit une unicité
de numéro au sein des différentes factures unitaires et chez chaque Vendeur. Une pratique consiste à le
préfixer avec un identifiant du Vendeur (par exemple son identifiant légal), le cas échéant enrichi d’un
identifiant du Vendeur principal facturant, constituant ainsi une série unique de facturation par Vendeur (qui
aura donc des trous de numérotation car chaque Vendeur ne sera pas présent dans chaque facture multi-
vendeurs générée par le facturant (intermédiaire transparent).

La meilleure pratique est de générer des numéros de factures par sous-vendeur en respectant une chronologie
et par facture unitaire, préfixés par l’identifiant légal du Vendeur et celui du Facturant :

• 123456782_321654879_F20250025 pour le Vendeur X de l’exemple ci-dessus,

• 123456782_254136987_F20250012 pour le Vendeur 00 de l’exemple ci-dessus qui aurait été présent
dans moins de factures multi-vendeurs que le VENDEUR X (12 au lieu de 25).

4.4.12.3 Les Charges et Remises :

D’une façon générale, il est préférable de se passer des charges et lignes de niveau document dans une facture
Multi-Vendeur.

Les Charges et Remises de niveau Document sont affectées uniquement à la facture principale, donc au
Vendeur principal identifié en bloc BG-4 de la facture Multi-Vendeurs. Pour que le pied de TVA soit juste il
convient donc de renseigner les motifs d’exemption de TVA des remises et charges comme les motifs
d’exemption des lignes (et en particulier, le motif en texte commençant par le numéro de sous-factures
(unitaires) entre #).

En cas de besoin pour les factures unitaires, il convient d‘utiliser les lignes pour ajouter des charges/ De même
des remises globales peuvent être traitées sur des lignes, avec un prix unitaire nul, une quantité égale à 1 et
l’utilisation de la remise de ligne.

4.4.12.4 Les règles de gestion

Les règles de gestion des factures Multi-Vendeurs sont décrites au chapitre 4.5.4.

4.4.12.5 Constitution du flux 1 ou 10.1, sur la base des factures unitaires.

Le traitement d’un facture Multi-Vendeurs nécessite de recomposer les factures unitaires, servant de pièce
comptable pour chaque Vendeur et de base pour créer le flux 1 ou 10.1 exigé.

Pour ce faire, les factures unitaires se créent par extraction et mapping décrits dans les règles de mapping des
factures multi-vendeurs (chapitre 4.5.5).

Il s’agit de composer les factures unitaires n’ayant pas le même numéro de facture que la facture multi-
vendeurs :

• En ne conservant que les lignes correspondant à chaque facture unitaire (au travers de la valeur de
BT-128 avec BT-128-1 = AFL), pour les lignes DETAIL seulement.

• En supprimant les charges et remises de niveau Document (si elles existent dans la facture).

• En ne conservant que les lignes de ventilation de TVA (BG-23) pour lesquelles la raison d’exemption
en texte (BT-120) commence par le numéro de facture unitaire (BT-128, avec le qualifiant (BT-128-1)
égal à AFL de la ligne GROUP) entre #

• En utilisant les données de la ligne « GROUP » pour :
AFNOR XP Z12-0122026-02

_Source: `c:\Users\g.baudrit\source\repos\gbaudrit\conf-aimer-votre-llm\demo\ctxc-sample-spec\with-ctxc\spec/afnor/XP_Z12-012/XP_Z12-012.pdf` (page:41/page:41)_

### E-a58ca3d21211

XP Z12-012 – Formats et Profils des messages Factures et Statuts de cycle de vie, constitutifs du socle
minimal applicable à la Réforme Facture Électronique en France

40
✓ Remplacer les informations du VENDEUR par celle du Vendeur en ligne (dans la ligne « GROUP »)

✓ Remplacer le numéro de facture (BT-1) par le numéro de facture unitaire (BT-128, avec le
qualifiant (BT-128-1) égal à AFL)

✓ Remplacer le cadre de facturation (BT-23) par le cadre de facturation en ligne (BT-128, avec le
qualifiant (BT-128-1) égal à AVV).

✓ Remplacer le code d’exigibilité de TVA (BT-8) par le code d’exigibilité en ligne (EXT-FR-FE-180).

✓ Remplacer la Somme des montants en ligne (BT-106) et le total HT (BT-109) par le total HT de
ligne « GROUP » (BT-131)

✓ Remplacer les montants totaux TVA BT-110 et BT-111 par ceux renseignés en EXT-FR-FE-181 et
EXT-FR-FE-182 (si existe).

✓ Remplacer le montant total TTC (BT-112) par celui renseigné en EXT-FR-FE-185, s’il existe, sinon
le calculer comme le montant HT BT-109 et le montant de TVA dans la devise de facture (BT-110).

✓ Renseigner le montant déjà payé (BT-113) par celui renseigné en EXT-FR-FE-185, car la facture
doit être payée à l’intermédiaire transparent Facturant et Bénéficiaire.

✓ Renseigner le montant Net à Payer (BT-115) comme étant égal à BT-112 – BT-113, donc égal à 0.

• Potentiellement, si le Bénéficiaire n’est pas présent dans la facture multi-vente, il peut être rajouté
dans la facture unitaire avec les données du VENDEUR de la facture multi-vendeur (BG-4).

Pour la facture unitaire du Vendeur principal, même traitement, sauf que :

• Les lignes de Charges et Remise de niveau Document sont conservées (et sont donc uniquement
attachées au Vendeur principal).

• Le total HT (BT-109) doit être égal à BT-106 - BT-107 + BT-108.

• Si la facture multi-vendeurs ne contient pas de remises et charges de niveau document, la conversion
en facture unitaire est la même que pour toutes les factures unitaires.

Une fois les factures unitaires constituées, les contrôles standards peuvent être effectués et les flux 1 ou 10.1
constitués sur cette base/ Les factures unitaires font l’objet du statut « Déposée » mais ne sont pas transmises
à l’ACHETEUR/ Seule la facture multi-vendeurs est transmise.

En cas de rejet d’une des factures unitaires, toutes les factures unitaires doivent être rejetées et la facture
multi-vendeur doit être générée à nouveau.

Les factures unitaires peuvent être transmises à chaque Vendeur concerné pour sa comptabilisation. Il peut
aussi exister des solutions en place qui organisent ces transferts d’informations comptables (reddition de
compte).

4.5 Règles de gestion spécifiques

Les exigences de la réforme Facture Électronique en France ont conduit à définir des règles de gestion
additionnelles à celles de la Norme EN 16931, induites des règles de gestion sur les éléments de e-reporting à
l’Administration fiscale (Flux 1, Flux 10/1)/

Ces règles de gestion sont de plusieurs types :

• Des règles de gestion qui sont constitutives de contrôles additionnels à opérer, sur le contenu des
factures et parfois avec des référentiels externes (par exemple l’existence de SIREN ACHETEUR ou
VENDEUR dans l’Annuaire PPF)/ On parle alors de contrôle métier/

• Des règles de mapping entre les données des factures et les fichiers attendus par l’Administration
fiscale (flux 1 et flux 10.1).

• Des règles « CHORUS PRO » applicables pour les factures B2G à destination du secteur public.

• Des règles additionnelles spécifiques pour le cas des factures multi-vendeurs :
AFNOR XP Z12-0122026-02

_Source: `c:\Users\g.baudrit\source\repos\gbaudrit\conf-aimer-votre-llm\demo\ctxc-sample-spec\with-ctxc\spec/afnor/XP_Z12-012/XP_Z12-012.pdf` (page:42/page:42)_

### E-b7d12bd0d37c

XP Z12-012 – Formats et Profils des messages Factures et Statuts de cycle de vie, constitutifs du socle
minimal applicable à la Réforme Facture Électronique en France

41
✓ Règles de gestion additionnelles.

✓ Règles de mapping spécifiques pour constituer des factures unitaires et des flux 1 ou 10.1
unitaires.

Ces règles sont décrites dans l’annexe Excel, et en particulier affectées à chaque ligne de description d’une
donnée de facture dès lors qu’elle est concernée par l’une de ces règles/

4.5.1 Les règles de contrôle additionnelles pour le respect de la réglementation en France

Le Tableau ci-dessous indique les règles de gestion de contrôle :

CODE BR Titre Description S'applique à

BR-FR-01 ID de facture 35
Caractères L'identifiant de facture DOIT ÊTRE limité à 35 caractères BT-1, BT-25, EXT-FR-FE-136

BR-FR-02
ID de facture
caractères
autorisés
L'Identifiant de facture (BT-1) est composé de caractères alphanumériques (A-Z,
a-z, 0-9). Les caractères spéciaux suivants sont autorisés :
- tiret ("-")
- signe "+"
- tiret bas (underscore : "_")
- barre oblique (slash : "/")
BT-1, BT-25, EXT-FR-FE-136

BR-FR-03 Date entre 2000
et 2099 L'année d'une date DOIT ETRE comprise entre 2000 et 2099 Tout type DATE

BR-FR-04 Codes types
documents
Les codes types de documents pour une facture sont les suivants:
Factures simples :
- Facture commerciale (380)
- Facture auto-facturée (389)
- Facture affacturée (393)
- Facture auto-facturée affacturée (501) 

Factures d'acompte :
- Facture d'acompte (386)
- Facture d’acompte auto-facturée (500) 

Factures rectificatives :
- Facture rectificative (384)
- Facture rectificative auto-facturée ( 471) 
- Facture rectificative affacturée (472) 
- Facture rectificative auto-facturée affacturée ( 473) 

Avoirs :
- Avoir auto-facturé (261)
- Avoir pour Remise Globale (262)
- Avoir (381)
- Avoir affacturé (396)
- Avoir auto-facturé affacturé (502) 
- Avoir de facture d'acompte (503) 

Les autres types de factures définis dans la norme (UNTDID 1001) ne doivent
pas être utilisés.
BT-3, EXT-FR-FE-02, EXT-
FR-FE-137

BR-FR-05 Note
Toute facture DOIT comporter au moins 3 notes (BG-1) avec les codes suivants :
- BT-21 = PMT, pour la mention de pénalité de 40 EUROS forfaitaire pour frais de
recouvrement (en BT-22)
- BT-21 = PMD, Mention de pénalités qui correspond aux conditions de paiement
propres à chaque entreprise (en BT-22).
- BT21 = AAB, mention d'escompte ou d'absence d'escompte (en BT-22)
BT-22, BT-21

BR-FR-06 Note Parmi les notes (BG-3), les codes sujets (BT-21) PMD, PMT, AAB et TXD ne
DOIVENT être présents qu'UNE SEULE FOIS CHACUN BT-22, BT-21
AFNOR XP Z12-0122026-02

_Source: `c:\Users\g.baudrit\source\repos\gbaudrit\conf-aimer-votre-llm\demo\ctxc-sample-spec\with-ctxc\spec/afnor/XP_Z12-012/XP_Z12-012.pdf` (page:43/page:43)_

### E-1e896d633d6d

XP Z12-012 – Formats et Profils des messages Factures et Statuts de cycle de vie, constitutifs du socle
minimal applicable à la Réforme Facture Électronique en France

42
CODE BR Titre Description S'applique à

BR-FR-07 Note
Pour signifier les informations ci-dessous dans des notes (BT-22) les codes
sujets correspondants (BT-21) doivent être les suivants : 

- ACC : Clause de subrogation factoring
- AAI : Information générale : des éléments en général en fond de page des
factures papier
-ADN : indique si la facture relève du B2G en France (règles additionnelles CPRO
- SUR : Remarques fournisseur
- ABL : Information légale : par exemple N° registre des métiers, RCS
- CUS : Information douanière
- BLU : "Eco-participation (L. 541-10 du code de l'environnement)" ou "Eco-
contribution DEEE"
- BAR : type de traitement attendu (e-invoicing, e-reporting, hors réforme, ...)
BT-22, BT-21

BR-FR-08 Cadre de
facturation
Les valeurs autorisées pour le Cadre (Mode de Facturation) sont:
B1 : Dépôt d'une facture de bien
S1 : Dépôt d'une facture de prestation de service
M1 : Dépôt d'une facture double (livraison de biens et services qui ne sont pas
accessoires l'une de l'autre)
B2 : Dépôt d'une facture de bien déjà payée
S2 : Dépôt d'une facture de prestation de service déjà payée
M2 : Dépôt d'une facture double déjà payée
S3 : Dépôt d'une demande de paiement de sous-traitance avec paiement direct
(uniquement B2G, restriction non vérifiable) 

B4 : Dépôt d'une facture définitive (après acompte) de bien
S4 : Dépôt d'une facture définitive (après acompte) de service
M4 : Dépôt d'une facture définitive (après acompte) double
S5 : Dépôt par un sous-traitant d’une facture de prestation de service
S6 . Dépôt par un cotraitant d’une facture de prestation de service
B7 : Dépôt d'une facture de bien ayant fait l'objet d'un e-reporting (TVA déjà
collectée)
S7 : Dépôt d'une facture de prestation de service ayant fait l'objet d'un e-
reporting (TVA déjà collectée)
B8 : Dépôt d'une facture multi-vendeurs de bien
S8 : Dépôt d'une facture multi-vendeurs de service
M8 : Dépôt d'une facture multi-vendeurs double, contenant des facrtures
unitaires qui ne sont pas toutes Sx ou Bx.
BT-23

BR-FR-09 Cohérence
SIRET SIREN
Dans une Partie, si le SIRET est renseigné (ID Privé, 0009), Les 9 premiers
chiffres du SIRET doivent correspondre au SIREN renseigné en ID légal
(schemeID 0002) et le SIRET doit faire 14 chiffres
BT-29, BT-46, BT-60, EXT-
FR-FE-06, EXT-FR-FE-46,
EXT-FR-FE-69, EXT-FR-FE-
92, EXT-FR-FE-115, BT-71,
EXT-FR-FE-146

BR-FR-10 Gestion du
SIREN
Le SIREN du Vendeur est Obligatoire, et doit être présent et actif dans l'annuaire
PPF BT-30

BR-FR-11 Gestion du
SIREN
Pour les factures relevant du périmètre "e-invoicing", le SIREN de l'Acheteur est
Obligatoire, et DOIT être présent et actif dans l'annuaire PPF

Règle à exécuter si la facture fait l'objet d'un traitement B2B ou si elle contient
une note (BG-1) avec un code sujet (BT-21) = BAR et un contenu (BT-22) = B2B :

L'identifiant légal de l'Acheteur (BT-47) DOIT être présent.
BT-47
AFNOR XP Z12-0122026-02

_Source: `c:\Users\g.baudrit\source\repos\gbaudrit\conf-aimer-votre-llm\demo\ctxc-sample-spec\with-ctxc\spec/afnor/XP_Z12-012/XP_Z12-012.pdf` (page:44/page:44)_

### E-350b795615e7

XP Z12-012 – Formats et Profils des messages Factures et Statuts de cycle de vie, constitutifs du socle
minimal applicable à la Réforme Facture Électronique en France

43
CODE BR Titre Description S'applique à

BR-FR-12
Adresse
électronique de
l'acheteur
Dès lors que la facture électronique doit être transmise et attend des statuts de
cycle de vie en retour, l'adresse électronique de l'Acheteur (BT-49) est
OBLIGATOIRE. C'est l'adresse électronique à laquelle la facture est transmise
(hors autofactures), ainsi que les statuts de cycle de vie à destination de
l'ACHETEUR. 

Pour information (géré par d'autres règles) : 
Pour les factures hors auto-facturation relevant du périmètre "e-invoicing", cette
adresse électronique DOIT être de la forme "SIREN" ou "SIREN_XXX", le SIREN
étant celui de l'Acheteur renseigné en BT-47, avec un schemeId (BT-49-1) =
0225. 

Pour les factures hors périmètre "e-invoicing" ou dans le périmètre "e-invoicing"
en auto-facturation émises par l'Acheteur, l'adresse électronique de l'Acheteur
DOIT être dans un des schemesID de la liste de codes EAS (y compris un email,
avec schemeID (BT-49-1) = EM). 

Pour les factures mises à disposition sur un portail, une adresse email (schemeID
(BT-49-1) = EM) de type "noreply@domaineduvendeur" peut être utilisée pour
signifier l'absence d'adresse électronique de l'Acheteur.
BT-49, BT-49-1

BR-FR-13
Adresse
électronique du
Vendeur
Dès lors que la facture électronique doit être transmise et attend des statuts de
cycle de vie en retour, l'adresse électronique du Vendeur (BT-34) est
OBLIGATOIRE. C'est l'adresse électronique à laquelle la facture en auto-
facturation est transmise, ainsi que les statuts de cycle de vie à destination du
Vendeur. 

Pour information (géré par d'autres règles) : 
Pour les factures en auto-facturation relevant du périmètre "e-invoicing", cette
adresse électronique DOIT être de la forme "SIREN" ou "SIREN_XXX", le SIREN
étant celui du Vendeur renseigné en BT-30, avec un schemeId (BT-34-1) = 0225. 

Pour les factures hors périmètre "e-invoicing" ou dans le périmètre "e-invoicing"
mais pas en auto-facturation, l'adresse électronique du Vendeur DOIT être dans
un des schemesID de la liste de codes EAS (y compris un email, avec schemeID
(BT-34-1) = EM). 

Pour les factures mises à disposition sur un portail, une adresse email de type
"noreply@domaineduvendeur" peut être utilisée pour signifier l'absence
d'adresse électronique du Vendeur.
BT-34, BT-34-1

BR-FR-14 Adresse de
Livraison
Certaines données liées à l'adresse de livraison BG-15 sont obligatoires si
l’adresse est différente de l`adresse de facturation (Acheteur - Bloc BG-8) et
seulement à partir du 01/09/2027. Les données obligatoires sont les suivantes :
• Adresse de livraison - Ligne 1 (BT-75)
• Localité Adresse de livraison (BT-77)
• Code postal Adresse de livraison (BT-78)
• Code Pays Adresse de livraison (BT-80)
Ces informations peuvent également être transmises à la ligne (si différent de
l'entête : Bloc EXT-FR-FE-BG-10 ). 

Ces données ne sont pas à transmettre pour les prestations de service  

Règle de gestion métier mais ne peut pas être contrôlée d’un point de vue
applicatif  

BR-FR-15 Code Catégorie
de TVA
Seuls les codes de catégorie de TVA suivants seront acceptés :
S = Taux de TVA standard
E = Exonéré de TVA
AE = Autoliquidation de TVA
K = Exonération pour cause de livraison intracommunautaire
G = Exonération de TVA pour Export hors UE
O = Hors du périmètre d'application de la TVA
Z = Taux de TVA égal à 0 (cf. G1.47) 

Les codes de catégorie de TVA suivants ne sont pas pertinents en France :
L = Iles Canaries
M = Ceuta et Mellila
BT-95, BT-102, BT-118, BT-
151
AFNOR XP Z12-0122026-02

_Source: `c:\Users\g.baudrit\source\repos\gbaudrit\conf-aimer-votre-llm\demo\ctxc-sample-spec\with-ctxc\spec/afnor/XP_Z12-012/XP_Z12-012.pdf` (page:45/page:45)_

### E-b1dffd74f365

XP Z12-012 – Formats et Profils des messages Factures et Statuts de cycle de vie, constitutifs du socle
minimal applicable à la Réforme Facture Électronique en France

44
CODE BR Titre Description S'applique à

BR-FR-16 Taux de TVA
autorisé
Le taux de la TVA applicable est conforme à la liste suivante :
Taux
0, 0.0, 0.00
10, 10.0, 10.00
13, 13.0, 13.00
20, 20.0, 20.00
8.5, 8.50
19.6, 19.60
2.1, 2.10
5.5, 5.50
7, 7.0, 7.00
20.6, 20.60
1.05
0.9, 0.90
1.75
9.2, 9.20
9.6, 9.60 

Le taux est exprimé en pourcentage et non en coefficient (exemple : 20). Le
symbole « % ¬ n’est pas à indiquer/
Le séparateur (« . ») n'est pas comptabilisé dans les 5 caractères.
BT-96, BT-103, BT-119, BT-
152

BR-FR-17 Document
Justificatif
Pour qualifier les Pièces jointes, les codes suivants peuvent être utilisés :
RIB : pour un RIB (qui contient l'IBAN / N° de compte + nom de Titulaire)
LISIBLE : pour LA REPRÉSENTATION LISIBLE COMPLÈTE DE LA FACTURE.
FEUILLE_DE_STYLE : pour le feuille de style permettant de créer une
représentation lisible
PJA : pour une pièce jointe additionnelle
BORDEREAU_SUIVI : pour un bordereau de suivi
DOCUMENT_ANNEXE : pour un document annexe
BON_LIVRAISON :  un bon de livraison
BON_COMMANDE: pour un Bon de Commande
BORDEREAU_SUIVI_VALIDATION : pour un bordereau de suivi et validation
ETAT_ACOMPTE : pour un Etat d'acompte
FACTURE_PAIEMENT_DIRECT : pour une facture de sous-traitant à payer en
direct
RECAPITULATIF_COTRAITANCE : pour lister l'ensemble des factures de co-
traitance à traiter ensemble. 
BT-123

BR-FR-18 Document
Justificatif
Il ne peut pas y avoir deux Documents additionnels (BG-24) pour lesquels la
description BT-123 est égale à LISIBLE BT-123

BR-FR-19 Limite 100 MO
Toutes les factures de moins de 100 MO doivent pourvoir être traitées par les
OD/SC (Solution Compatible) / Plateformes Agréées (PJ incluses).
C'est une règle métier qui autorise à poser un statut IRRECEVABLE sur un fichier
de facture de plus de 100 MO
Un fichier facture à traiter

BR-FR-20
Qualification du
type de
traitement
attendu
Qualification du traitement attendu : Il est possible d'utiliser une Note pour
indiquer quel traitement est attendu sur la facture. Le code sujet DOIT être BAR
et les valeurs attendues, pour être signifiantes, DOIVENT être dans la liste ci-
dessous, avec leurs significations :
. B2B : signifie "relève du e-invoicing"
. B2BINT : signifie "relève du e-reporting des ventes B2Bint"
. B2C : signifie "relève du e-reporting B2C Ventes"
. OUTOFSCOPE : signifie "hors réforme"
. ARCHIVEONLY : signifie qu'il s'agit d'un AVOIR interne créé pour annuler une
facture REJETÉE ou REFUSÉE, et NE DOIT PAS faire l'objet d'un traitement e-
invoicing (pas de flux 1, pas de transmission au destinataire)
BG-1, BT-21, BT-22

BR-FR-21
Adresse
électronique de
l'acheteur
Règle à exécuter si la facture fait l'objet d'un traitement B2B ou si elle contient
une note (BG-1) avec un code sujet (BT-21) = BAR et un contenu (BT-22) = B2B : 

Si la facture n'est pas auto-facturée (BT-3 pas dans liste ('389', '501', '500', '471',
'473', '261', '502') 

ALORS l'adresse de facturation électronique de l'ACHETEUR (BT-49) doit
commencer par le N° SIREN de l'ACHETEUR (BT-47) ET le schemeID de l'adresse
(BT-49-1) DOIT être égal à 0225
BT-49, BT-49-1
AFNOR XP Z12-0122026-02

_Source: `c:\Users\g.baudrit\source\repos\gbaudrit\conf-aimer-votre-llm\demo\ctxc-sample-spec\with-ctxc\spec/afnor/XP_Z12-012/XP_Z12-012.pdf` (page:46/page:46)_

### E-8cff8fcfabd6

XP Z12-012 – Formats et Profils des messages Factures et Statuts de cycle de vie, constitutifs du socle
minimal applicable à la Réforme Facture Électronique en France

45
CODE BR Titre Description S'applique à

BR-FR-22
Adresse
électronique du
Vendeur
Règle à exécuter si la facture fait l'objet d'un traitement B2B ou si elle contient
une note (BG-1) avec un code sujet (BT-21) = BAR et un contenu (BT-22) = B2B : 

Si la facture est auto-facturée (BT-3 dans liste ('389', '501', '500', '471', '473',
'261', '502') 

ALORS l'adresse de facturation électronique du VENDEUR (BT-34) doit
commencer par le N° SIREN du VENDEUR (BT-30) ET le schemeID de l'adresse
(BT-30-1) DOIT être égal à 0225
BT-34, BT-34-1

BR-FR-23
Adresse
électronique en
0225
Toute adresse électronique avec schemeID = 0225 est composé de caractères
alphanumériques (A-Z, a-z, 0-9). Les caractères spéciaux suivants sont autorisés :
- tiret ("-")
- tiret bas (underscore : "_")
- pont (".")
BT-34 / BT-34-1, BT-49 /
BT-49-1
EXT-FR-FE-12 / EXT-FR-FE-
13, EXT-FR-FE-29 / EXT-FR-
FE-30, EXT-FR-FE-52 / EXT-
FR-FE-53, EXT-FR-FE-75 /
EXT-FR-FE-76, EXT-FR-FE-
98 /EXT-FR-FE-99, EXT-FR-
FE-121 / EXT-FR-FE-122

BR-FR-24 Code_Routage
Toute IDprivé d'une partie avec schemeID = 0224 est composé de caractères
alphanumériques (A-Z, a-z, 0-9). Les caractères spéciaux suivants sont autorisés :
- tiret ("-")
- tiret bas (underscore : "_")
- pont (".")
BT-29 / BT-29-1, BT-46 /
BT-46-1

BR-FR-25 Adresse
électronique Toute adresse électronique ne doit pas dépasser 125 caractères
BT-34, BT-49
EXT-FR-FE-12, EXT-FR-FE-
29 , EXT-FR-FE-52, EXT-FR-
FE-75, EXT-FR-FE-98, EXT-
FR-FE-121

BR-FR-26 Code_Routage Toute IDprivé d'une partie avec schemeID = 0224 ne doit pas dépasser 100
caractères
BT-29 / BT-29-1, BT-46 /
BT-46-1

BR-FR-27
Code et Nom
d'attribut
d'article
Un groupe Attribut d'article (BG-32) DOIT contenir soit un nom d'attribut
d'article (BT-160), soit un Code d'attribut d'article (EXT-FR-FE-159)
BG-32, BT-160, EXT-FR-FE-
159

BR-FR-28
Valeur
d'attribut et
Valeur
d'attribut avec
unité de mesure
Un groupe Attribut d'article (BG-32) DOIT contenir soit une valeur d'attribut
(BT-161), soit une valeur d'attribut avec unité de mesure (EXT-FR-FE-160), et
son unité de mesure (EXT-FR-FE-161)
BT-161, EXT-FR-FE-160,
EXT-FR-FE-161

BR-FR-29 Identifiant
d'objet facturé
Parmi Identifiants d'Objets facturés (BT-18), les schémas d'identification (BT-
18-1) "AFL" et "AVV" ne DOIVENT être présents qu'UNE SEULE FOIS CHACUN BT-18, BT-18-1

BR-FR-30
Identifiant
d'objet facturé à
la ligne
Parmi Identifiants d'Objets facturés à la ligne (BT-128), les schémas
d'identification (BT-128-1) "AFL" et "AVV" ne DOIVENT être présents qu'UNE
SEULE FOIS CHACUN
BT-128, BT-128-1

BR-FR-31 Note avec code
sujet BAR
En cas de multiplicité de notes (BG-1) ayant un code sujet (BT-21) = BAR, une
seule des valeurs suivantes peuvent être présentes dans le contenu (BT-22) : 
. B2B
. B2BINT
. B2C
. OUTOFSCOPE
. ARCHIVEONLY
BG-1, BT-21, BT-22

BR-FR-CO-01 Pas d'antidatage
dans l'avenir
La date de facture BT-2 DOIT ETRE antérieure ou égale à date d'application du
contrôle de conformité BT-2
AFNOR XP Z12-0122026-02

_Source: `c:\Users\g.baudrit\source\repos\gbaudrit\conf-aimer-votre-llm\demo\ctxc-sample-spec\with-ctxc\spec/afnor/XP_Z12-012/XP_Z12-012.pdf` (page:47/page:47)_

### E-dda2c7ec8009

XP Z12-012 – Formats et Profils des messages Factures et Statuts de cycle de vie, constitutifs du socle
minimal applicable à la Réforme Facture Électronique en France

46
CODE BR Titre Description S'applique à

BR-FR-CO-02 Unicité de la
facture
L'identifiant unique de facture doit être composé des éléments suivants :
- Numéro de facture (BT-1)
- Année de production de la facture (Issue de la date d'émission de la facture
(BT-2))
- Identifiant légal du Vendeur : numéro SIREN (BT-30) 

L’unicité de la facture vise à éviter les erreurs de facturation (double facturation
notamment). Une facture présentant des informations similaires
cumulativement sur ces trois données par rapport à une facture précédemment
envoyée fera l’objet d’un rejet par les plateformes/
Le contrôle d’unicité est systématiquement bloquant/ 

En cas de mandat de facturation, le numéro de facture doit comporter une racine
propre au mandataire pour éviter les doublons de facture avec celles de son
mandant. 

Le numéro de facture doit respecter la règlementation du BOFIP suivante:
BOI-TVA-DECLA-30-20-20-10 du 18/10/2023
Section : A. La numérotation des factures
BT-1, BT-2, BT-30

BR-FR-CO-03 Codestypes
documents
Si le codetype de la facture (BT-3) est égal à 262 (Avoir Remise Globale), alors :
- Le numéro de contrat (BT-12) DOIT être présent
- La période de facturation (BG-14) DOIT être présente
BT-3, BT-12, BG-14

BR-FR-CO-04 Codestypes
documents
Si le codetype de la facture (BT-3) est dans la liste suivante : 

Factures rectificatives :
- Facture rectificative (384)
- Facture rectificative auto-facturée (471) (*)
- Facture rectificative affacturée (472) (*)
- Facture rectificative auto-facturée affacturée (473)  (*) 

Alors UNE ET UNE SEULE Référence à une facture antérieure (BT-25) DOIT être
présente, ainsi que sa Date (BT-26)
BT-3, BT-25, BT-26

BR-FR-CO-05 Codestypes
documents
Si le codetype de la facture (BT-3) est dans la liste suivante : 

Avoirs :
- Avoir auto-facturé (261)
- Avoir (381)
- Avoir affacturé (396)
- Avoir auto-facturé affacturé (502) (*)
- Avoir de facture d'acompte (503) (*) 

Alors AU MOINS une Référence à une facture antérieure (BT-25) DOIT être
présente ainsi que sa Date (BT-26) OU BIEN une Référence à une facture
antérieure en ligne (EXT-FR-FE-136) DOIT être présente DANS CHAQUE ligne
(BG-25), ainsi que sa date (EXT-FR-FE-138)
BT-3, BT-25, EXT-FR-FE-
136, EXT-FR-FE-138

BR-FR-CO-06
Date de
versement de
l'acompte
Si le codetype de facture (BT-3) est:
- Facture d'acompte (386)
- Facture d’acompte auto-facturé (500) (*)
- Avoir de facture d'acompte (503) (*)
et si la date de versement de l'acompte est déterminée / connue et qu'elle est
différente de la date d`émission alors la date de versement de l’acompte doit être
obligatoirement complétée en BT-9 

Règle de gestion métier mais ne peut pas être contrôlée d’un point de vue
applicatif
BT-9
AFNOR XP Z12-0122026-02

_Source: `c:\Users\g.baudrit\source\repos\gbaudrit\conf-aimer-votre-llm\demo\ctxc-sample-spec\with-ctxc\spec/afnor/XP_Z12-012/XP_Z12-012.pdf` (page:48/page:48)_

### E-d8379f38a3a2

XP Z12-012 – Formats et Profils des messages Factures et Statuts de cycle de vie, constitutifs du socle
minimal applicable à la Réforme Facture Électronique en France

47
CODE BR Titre Description S'applique à

BR-FR-CO-07
Date de
versement de
l'acompte
La Date d'échéance (BT-9), si présente, DOIT être postérieure ou égale à la Date
de facture (BT-2),
SAUF SI la facture est de type acompte (BT-3) :
- Facture d'acompte (386)
- Facture d’acompte auto-facturé (500) (*)
- Avoir de facture d'acompte (503) (*) 

OU SAUF SI le Cadre de facturation (BT-23) est égal à :
- B2 : Dépôt d'une facture de bien déjà payée
- S2 : Dépôt d'une facture de prestation de service déjà payée
- M2 : Dépôt d'une facture double déjà payée
BT-9, BT-3, BT-2, BT-23

BR-FR-CO-08
Cadre de
facturation
Facture
définitive
Si le cadre de facturation (BT-23) est :
- B4 : Factures définitives (après acompte) de bien
- S4 : Factures définitives (après acompte) de prestation de service
- M4 : Factures définitives (après acompte) double 

ALORS le type de facture ne peut pas être :
- Facture d'acompte (386)
- Facture d’acompte auto-facturée (500)
- Avoir de facture d'acompte (503)
BT-23, BT-3

BR-FR-CO-09
Cadre de
facturation Déjà
payé
Si le cadre de facturation (BT-23) est :
- B2 : Dépôt d'une facture de bien déjà payée
- S2 : Dépôt d'une facture de prestation de service déjà payée
- M2 : Dépôt d'une facture double déjà payée 

ALORS
- Le montant déjà payé (BT-113) est égal Montant total de la Facture avec la TVA
(BT-112)
- le Net à payer (BT-115) est égal à 0
- la Date d'échéance (BT-9) DOIT indiquer la date à laquelle la facture a été payée
BT-23, BT-9, BT-112, BT-
113, BT-115

BR-FR-CO-10 ID privés des
parties
Lorsque les Identifiants privés des acteurs sont multiples (par exemple BT-29),
ils doivent être qualifiés par un identifiant du schéma (BT-29-1), il ne peut y
avoir 2 identifiants privés avec le même identifiant du schéma
BT-29, BT-46, BT-60, EXT-
FR-FE-06, EXT-FR-FE-46,
EXT-FR-FE-69, EXT-FR-FE-
92, EXT-FR-FE-115, BT-71,
EXT-FR-FE-146

BR-FR-CO-11 ID privés des
parties
Les identifiants privés des parties permettent de fournir des identifiants
spécifiques, qualifiés par l'identifiant du schema (codelist ICD). Ainsi :
- un SIRET (identifiant du schema = 0009)
- un CODE_ROUTAGE (identifiant du schema = 0224)
- Le SIREN de l'assujetti unique du Vendeur (identifiant du schema : 0231),
uniquement en BT-29
BT-29, BT-46, BT-60, EXT-
FR-FE-06, EXT-FR-FE-46,
EXT-FR-FE-69, EXT-FR-FE-
92, EXT-FR-FE-115, BT-71,
EXT-FR-FE-146

BR-FR-CO-12 Montant de TVA
en EURO
Si la Devise de facture (BT-5) est différente de EUR, alors
- la devise de comptabilité BT-6 DOIT être présente et égale à EUR
- Le montant de TVA en devise de comptabilité (et donc en EURO BT-111 DOIT
être présente, et BT-111-1 DOIT être égal à EUR
BT-5, BT-6, BT-110, BT-111

BR-FR-CO-13 Assujetti Unique
Vendeur
S'il existe une occurrence de BT-29 avec un schéma d'identification BT-29-1 =
0231, alors le Vendeur est Membre d'un Assujetti Unique (AU), et le numéro de
SIREN de l'Assujetti Unique en BT-29 avec le schéma d'identification (BT-29-1) =
0231 DOIT être présent dans l'Annuaire PPF
BT-29, BT-29-1

BR-FR-CO-14 Assujetti Unique
Vendeur
S'il existe une occurrence de BT-29 avec un schéma d'identification BT-29-1 =
0231, alors le Vendeur est Membre d'un Assujetti Unique (AU), et un bloc BG-1
DOIT être présent avec pour Code sujet (BT-21) = "TXD" ET un texte de note
(BT-22) = "MEMBRE_ASSUJETTI_UNIQUE".
BT-29, BT-29-1, BT-21, BT-
22

BR-FR-CO-15 Assujetti Unique
Vendeur
S'il existe une occurrence de BT-29 avec un schéma d'identification BT-29-1 =
0231, alors le Vendeur est Membre d'un Assujetti Unique (AU) et le Bloc du
Représentant fiscal du Vendeur (BG-11) DOIT être présent et contient les
informations de l'Assujetti Unique (et en particulier son n° de TVA en BT-63)
BT-29, BT-29-1, BG-11, BT-
63
AFNOR XP Z12-0122026-02

_Source: `c:\Users\g.baudrit\source\repos\gbaudrit\conf-aimer-votre-llm\demo\ctxc-sample-spec\with-ctxc\spec/afnor/XP_Z12-012/XP_Z12-012.pdf` (page:49/page:49)_

### E-ab431e041e33

XP Z12-012 – Formats et Profils des messages Factures et Statuts de cycle de vie, constitutifs du socle
minimal applicable à la Réforme Facture Électronique en France

48
CODE BR Titre Description S'applique à

BR-FR-CO-16 Franchise en
base
Les factures en franchise en base de TVA comportent un bloc de détail TVA avec
une BT-118 = "E" ET une raison d'exemption en CODE BT-121 = "VATEX-FR-
FRANCHISE". Si le Vendeur n'a pas de n° de TVA, il doit répéter son n° de SIREN
en BT-32
BT-118, BT-121, BT-120

BR-FR-CO-17 Date de
Livraison
Donnée à fournir dans la mesure où elle est déterminée et différente de la date
d'émission de la facture (art. 242 nonies A 10°). Dans une facture, peut être
renseignée :
- la date de livraison ou la date de fin d'exécution de la prestation (BT-72)
- ou la date de livraison à la ligne, en cas de multi-livraisons (EXT-FR-FE-BG-11)
- ou une période de facturation en cas de facture périodique ou récapitulative
(article 289 - I.3 du CGI) (BG-26) 

Règle de gestion métier mais ne peut pas être contrôlée d’un point de vue
applicatif
BT-72, BG-14, EXT-FR-FE-
BG-11

BR-FR-DEC-
01 Montant 19,2
Le montant dans une facture est exprimé par un nombre sur 19 positions, et ne
peut comporter plus de 2 décimales.
Le séparateur entre le nombre entier et les décimales est un point (« . »).
Le signe « - » devant le montant compte comme un caractère.
Si le nombre total de chiffres du nombre (partie entière et partie décimale
comprises) dépasse 19 caractères, le montant sera rejeté. Le séparateur (« . »)
n'est pas comptabilisé dans les 19 caractères.
BT-92, BT-93, BT-99, BT-
100, BT-106, BT-107, BT-
108, BT-109, BT-110, BT-
111, BT-112, BT-113, BT-
114, BT-115, BT-116, BT-
117, BT-131, BT-136, BT-
137, BT-141, BT-142

BR-FR-DEC-
02 Quantité 19,4
La quantité facturée dans une facture est exprimé par un nombre sur 19
positions, et ne peut comporter plus de 4 décimales.
Le séparateur entre le nombre entier et les décimales est un point (« . »).
Le signe « - » devant le montant compte comme un caractère.
Si le nombre total de chiffres du nombre (partie entière et partie décimale
comprises) dépasse 19 caractères, le montant sera rejeté. Le séparateur (« . »)
n'est pas comptabilisé dans les 19 caractères.
BT-129, BT-149

BR-FR-DEC-
03
Prix Unitaire
19,6
Le montant dans une facture est exprimé par un nombre sur 19 positions, et ne
peut comporter plus de 6 décimales.
Le séparateur entre le nombre entier et les décimales est un point (« . »).
Il n'y a pas de signe (toujours positif)
Si le nombre total de chiffres du nombre (partie entière et partie décimale
comprises) dépasse 19 caractères, le montant sera rejeté. Le séparateur (« . »)
n'est pas comptabilisé dans les 19 caractères.
BT-146, BT-147, BT-148

BR-FR-DEC-
04
Pourcentage
Taux TVA 4.2
Le taux de TVA dans une facture est exprimé par un nombre sur 4 positions, et
ne peut comporter plus de 2 décimales.
Le séparateur entre le nombre entier et les décimales est un point (« . »).
Il n'y a pas de signe (toujours positif)
Si le nombre total de chiffres du nombre (partie entière et partie décimale
comprises) dépasse 4 caractères, le montant sera rejeté. Le séparateur (« . »)
n'est pas comptabilisé dans les 4 caractères.
BT-96, BT-103, BT-119, BT-
152

4.5.2 Les règles de mapping pour constituer les flux 1 et 10.1

Le tableau ci-dessous détaille les règles de mapping à partir des données de factures de vente à émettre ou
émises pour créer les flux 1 ou flux 10.1

CODE BR Titre Description S'applique à

BR-FR-MAP-01
ID de facture
caractères
autorisés
Pour la constitution du flux 1 ou 10.1, flux 6 pour le PPF, l'identifiant de
facture est réduit à 20 caractères s'il en contient plus de 20, de la façon
suivante :
- Troncature à 19 caractères à droite
- ajout d'un "T" à gauche pour signifier la troncature 

Exemple : 987654321-123456782-F202500125 
donne T23456782-F202500125
BT-1, BT-25, EXT-FR-FE-136
AFNOR XP Z12-0122026-02

_Source: `c:\Users\g.baudrit\source\repos\gbaudrit\conf-aimer-votre-llm\demo\ctxc-sample-spec\with-ctxc\spec/afnor/XP_Z12-012/XP_Z12-012.pdf` (page:50/page:50)_

### E-2aa90f8a82d4

XP Z12-012 – Formats et Profils des messages Factures et Statuts de cycle de vie, constitutifs du socle
minimal applicable à la Réforme Facture Électronique en France

49
CODE BR Titre Description S'applique à

BR-FR-MAP-02 Code type
documents
Si le code type de la facture (BT-3) est égal à 262 (Avoir pour Remise
Globale), alors :
Pour le flux 1 :
- le code type de la facture (BT-3 = 262) DOIT être mappé en 381 dans le flux
1 (BT-3)
- la référence de Contrat (BT-12) de la facture doit être mappée dans la
Référence à une facture antérieure (BT-25) du Flux 1, et la Date de début de
période de facturation (BT-73)  DOIT être mappée dans la Date de facture
antérieure (BT-26). 

Pour le flux 10.1 :
- le code type de la facture (BT-3 = 262) DOIT être mappé en 381 dans le flux
10.1 (TT-21)
- la référence de Contrat (BT-12) de la facture DOIT être mappée dans la
Référence à une facture antérieure (TT-30) et la Date de début de période de
facturation (BT-73)  DOIT être mappée dans la Date de facture antérieure
(TT-31)
BT-3, BT-12, BG-14

BR-FR-MAP-03 TVA sur les
débits
Il est rappelé que l'option de TVA sur les débits est générale et l'emporte sur
l'ensemble des factures émises. En cas de prestations de services et d'option
pour la TVA sur les débits, l'exigibilité de la TVA est due au moment de
l'inscription de la somme correspondante au débit du compte « client ». En
pratique, le débit coïncide le plus souvent avec la facturation. Il est souligné
que l'option d'acquitter la taxe d'après les débits ne peut avoir pour effet de
retarder l'exigibilité de la taxe. 

L'indication de l'exigibilité de la TVA pour les débits est indiquée en BT-8
avec les valeurs 5 en CII et 3 en UBL.
BT-8 est obligatoire pour les factures de service dès lors que l'assujetti
Vendeur a opté pour les débits.
Dans le flux 10.1 la valeur de BT-8 est mappée en TT-24
BT-8

BR-FR-MAP-04 Note mapping
Seules les notes (BG-3) avec les codes sujets (BT-21) égaux à PMT, PMD,
AAB, BLU et TXD DOIVENT être transmises dans le Flux 1 ou le flux 10.1 (TT-
26 = BT-21, TT-27 = BT-22). 

Les notes avec d’autres codes sujet peuvent être transmises, ou pas en flux
10 ou 10.1
BT-22, BT-21, TT-26, TT-27

BR-FR-MAP-05 TVA en EURO
dans le flux 10.1
Si la Devise de facture (BT-5) est EUR, alors TT-52 est égal à BT-110, sinon,
TT-52 est égal à BT-111
BT-5, BT-6, BT-110, BT-111,
TT-52

BR-FR-MAP-06 Assujetti Unique
Vendeur
S'il existe une occurrence du bloc Note (BG-1) avec pour Code sujet (BT-21)
= "TXD" ET un texte de note (BT-22) = "MEMBRE_ASSUJETTI_UNIQUE", alors
il faut transcoder "MEMBRE_ASSUJETTI_UNIQUE" en "Membre d'un assujetti
unique" dans la BT-22 du flux 1
BT-21, BT-22

BR-FR-MAP-07 Assujetti Unique
Vendeur
S'il existe une occurrence du bloc Note (BG-1) avec pour Code sujet (BT-21)
= "TXD" ET un texte de note (BT-22) = "MEMBRE_ASSUJETTI_UNIQUE", alors
il faut transcoder "MEMBRE_ASSUJETTI_UNIQUE" en "Membre d'un assujetti
unique" dans la TT-27 du flux 10.1
BT-21, BT-22, TT-27

BR-FR-MAP-08 Franchise en
base
Si une facture contient un bloc de détail TVA (BG-23) contenant un code
Catégorie BT-118 = "E" ET un code VATEX BT-121 = "VATEX-FR-
FRANCHISE", ALORS
l'action à opérer dans le flux 1 est la suivante : 
- transcoder la BT-118 en "Z"
- supprimer VATEX BT-121 et la raison en texte BT-120, si présentes
BT-118, BT-121, BT-120

BR-FR-MAP-09 Franchise en
base
Si une facture contient un bloc de détail TVA (BG-23) contenant un code
Catégorie BT-118 = "E" ET un code VATEX BT-121 = "VATEX-FR-
FRANCHISE", alors il faut transcoder la BT-118 en "Z" et ne pas transmettre
le code VATEX BT-121, ni la raison en texte BT-120, si présente, dans le flux
10.1 (TT-56)
BT-118, BT-121, BT-120
AFNOR XP Z12-0122026-02

_Source: `c:\Users\g.baudrit\source\repos\gbaudrit\conf-aimer-votre-llm\demo\ctxc-sample-spec\with-ctxc\spec/afnor/XP_Z12-012/XP_Z12-012.pdf` (page:51/page:51)_

### E-a0a3222beebc

XP Z12-012 – Formats et Profils des messages Factures et Statuts de cycle de vie, constitutifs du socle
minimal applicable à la Réforme Facture Électronique en France

50
CODE BR Titre Description S'applique à

BR-FR-MAP-10 Adresse de
Livraison
Si BT-80 est présent, il y a une Adresse de Livraison et il faut renseigner tous
les champs présents du groupe Adresse de Livraison (BG-15) en flux 1 ou
10.1, et en cas d'absence de la Ligne 1 (BT-75), du Code postal (BT-78) ou
Localité (BT-77), fournir la donnée "-" à la place.
BG-15, BT-75, BT-77, BT-78,
BT-80

BR-FR-MAP-11 Adresse de
Livraison
Si EXT-FR-FE-157 est présent, il y a une Adresse de Livraison en ligne et il
faut renseigner tous les champs présents du groupe Adresse de Livraison
(EXT-FR-FE-BG-10) sauf l'identifiant global du lieu (EXT-FR-FE-146, EXT-
FR-FE-148) en flux 1 ou 10.1, et en cas d'absence de la Ligne 1 (EXT-FR-FE-
151), du Code postal (EXT-FR-FE-154) ou Localité (EXT-FR-FE-155), fournir
la donnée "-" à la place.
EXT-FR-FE-BG-10, EXT-FR-
FE-151, EXT-FR-FE-154,
EXT-FR-FE-155, EXT-FR-FE-
157

BR-FR-MAP-12 Taux de TVA
autorisé
Le taux de la TVA applicable doit être mappé vers les données suivantes :
Taux
0
10
13
20
8.5
19.6
2.1
5.5
7
20.6
1.05
0.9
1.75
9.2
9.6 

Le taux est exprimé en pourcentage et non en coefficient (exemple : 20). Le
symbole « % ¬ n’est pas à indiquer/
Le séparateur (« . ») n'est pas comptabilisé dans les 5 caractères.
BT-96, BT-103, BT-119, BT-
152

BR-FR-MAP-13 Donnée Flux 1,
10.1 CIBLE
Cette donnée n'est pas exigée au DEMARRAGE de la réforme dans les flux 1
et 10.1, mais en CIBLE (01/09/2027)
BT-26, BG-15, BT-75, BT-76,
BT-165, BT-77, BT-78, BT-
79, BT-80, BG-20, BT-92, BT-
95, BT-96, BG-25, BT-127-
00, EXT-FR-FE-183, BT-127,
BT-129, BT-130, EXT-FR-FE-
BG-06, EXT-FR-FE-138, EXT-
FR-FE-BG-10, EXT-FR-FE-
149, EXT-FR-FE-150, EXT-
FR-FE-151, EXT-FR-FE-152,
EXT-FR-FE-153, EXT-FR-FE-
154, EXT-FR-FE-155, EXT-
FR-FE-156, EXT-FR-FE-157,
EXT-FR-FE-BG-11, EXT-FR-
FE-158, BG-26, BT-134, BT-
135, BG-27, BT-136, BG-28,
BT-141, BG-29, BT-146, BT-
147, BT-148, BG-31, BT-153

BR-FR-MAP-14 Code Pays
Les Codes Pays des DOM/COM ci-dessous doivent être remplacés par FR
dans les flux 1 et 10 

Guyane française (la ) => GF
Terres australes françaises (les) TF
Guadeloupe (la) => GP
Guyana (le) => GY
Martinique (la) =>MQ
Mayotte => YT
Réunion (La) =>RE
Saint-Barthélemy => BL
Saint-Martin (partie française) => MF
Saint-Pierre-et-Miquelon => PM
BT-40, BT-55, BT-80, EXT-
FR-FE-157
AFNOR XP Z12-0122026-02

_Source: `c:\Users\g.baudrit\source\repos\gbaudrit\conf-aimer-votre-llm\demo\ctxc-sample-spec\with-ctxc\spec/afnor/XP_Z12-012/XP_Z12-012.pdf` (page:52/page:52)_

### E-2da0d84c54f7

XP Z12-012 – Formats et Profils des messages Factures et Statuts de cycle de vie, constitutifs du socle
minimal applicable à la Réforme Facture Électronique en France

51
CODE BR Titre Description S'applique à

BR-FR-MAP-15 MAPPING BT-24
Pour le flux 1, BT-24 doit être égal à :
urn.cpro.gouv.fr:1p0:einvoicingextract#Base pour le profil DEMARRAGE,
sans les lignes
urn.cpro.gouv.fr:1p0:einvoicingextract#Full pour le profil complet (CIBLE)
BT-24

BR-FR-MAP-16
Identifiant du
Vendeur et de
l'Acheteur en
flux 10
L'identifiant du Vendeur (TT-33-1) renseigné est défini par le qualifiant :
- "0002" --> SIREN sur 9 caractères
- "0223" --> UE_HORS_FRANCE (correspond à l'identifiant de TVA
intracommunautaire) sur 18 caractères
- "0227" --> HORS_UE (dont Wallis et Futuna) (correspond au code Pays et
aux 16 premiers caractères de la raison sociale) sur 18 caractères
- "0228" --> RIDET sur  9 ou 10 caractères
- "0229" --> TAHITI sur  9 caractères 

L'identifiant de l'Acheteur (TT-37) renseigné est défini par le qualifiant :
- "0002" --> SIREN sur 9 caractères
- "0223" --> UE_HORS_FRANCE (correspond à l'identifiant de TVA
intracommunautaire) sur 18 caractères
- "0227" --> HORS_UE (dont Wallis et Futuna) (correspond au code Pays et
aux 16 premiers caractères de la raison sociale) sur  18 caractères
- "0228" --> RIDET sur  9 ou 10 caractères
- "0229" --> TAHITI sur  9 caractères
BT-30

BR-FR-MAP-17 TRONQUER A
255 Caractères
Si la longueur de la donnée fait plus de 255 caractères 
ALORS pour la même donnée à reporter dans le flux 1 
Il ne faut conserver que les 255 premiers caractères à gauche et supprimer
au-delà
BT-75, BT-76, BT-165, BT-
77, BT-79, EXT-FR-FE-151,
EXT-FR-FE-152, EXT-FR-FE-
153, EXT-FR-FE-154, EXT-
FR-FE-156, BT-153

BR-FR-MAP-18 TRONQUER A
1024 Caractères
Si la longueur de la donnée fait plus de1024 caractères 
ALORS pour la même donnée à reporter dans le flux 1 
Il ne faut conserver que les 1024 premiers caractères à gauche et supprimer
au-delà
BT-22, BT-120, BT-127

BR-FR-MAP-19 TRONQUER A
10 Caractères
Si la longueur de la donnée fait plus de 10 caractères 
ALORS pour la même donnée à reporter dans le flux 1 
Il ne faut conserver que les 10 premiers caractères à gauche et supprimer
au-delà
BT-78, EXT-FR-FE-155

BR-FR-MAP-20 TRONQUER A
100 Caractères
Si la longueur de la donnée fait plus de 100 caractères 
ALORS pour la même donnée à reporter dans le flux 1 
Il ne faut conserver que les 100 premiers caractères à gauche et supprimer
au-delà
EXT-FR-FE-149

BR-FR-MAP-21 Prix Brut
En cas d'absence du Prix Unitaire Brut (BT-148) dans la facture, 
ALORS, pour la création du flux 1 :
il faut indiquer le PU Net (BT-146) dans le PU Brut (BT-148)
BT-148

BR-FR-MAP-22 Prix Brut
En cas d'absence du Prix Unitaire Brut (BT-148) dans la facture, 
ALORS, pour la création du flux 10.1 :
il faut indiquer le PU Net (BT-146) dans le PU Brut (TT-71)
BT-148

BR-FR-MAP-23 Format Date
Dans le flux 10.0, les dates sont au format AAAMMJJ
DONC, pour les flux 2, 8, et 9 sous syntaxe UBL, il faut supprimer les "-"
EXEMPLE : 2025-02-12 devient 20250212
BT-2/TT-20, BT-9/TT-201,
BT-26//TT-31, BT-72/TT-
41, BT-73/TT-42, BT-74/TT-
43, EXT-FR-FE-138/TT-301,
BT-134/TT-65, BT-135/TT-
66

BR-FR-MAP-24
Exclusion des
lignes GROUP et
INFORMATION
Seules les lignes (BG-25) sans sous-type de ligne (EXT-FR-FE-163) ou avec
une valeur de sous-type de ligne égale à "DETAIL", DOIVENT être prises en
compte pour la création des flux 1 ou flux 10.1.
EXT-FR-FE-163

BR-FR-MAP-25
Raison
d'exemption en
code et en texte
dans les flux 1 et
10.1
Dans une ligne de ventilation de TVA (BG-23), si la raison d'exemption en
code (BT-121) est présente, et que la raison d'exemption en texte (BT-120)
est absente, alors il faut indiquer dans la valeur d'exemption en texte (BT-
120) du flux 1 le texte correspondant au code VATEX présent en BT-121, tel
que listé dans la liste de codes VATEX
BT-120
AFNOR XP Z12-0122026-02

_Source: `c:\Users\g.baudrit\source\repos\gbaudrit\conf-aimer-votre-llm\demo\ctxc-sample-spec\with-ctxc\spec/afnor/XP_Z12-012/XP_Z12-012.pdf` (page:53/page:53)_

### E-24490704e989

XP Z12-012 – Formats et Profils des messages Factures et Statuts de cycle de vie, constitutifs du socle
minimal applicable à la Réforme Facture Électronique en France

52
CODE BR Titre Description S'applique à

BR-FR-MAP-26
Raison
d'exemption en
code et en texte
dans les flux 1 et
10.1
Dans une ligne de ventilation de TVA (BG-23), si la raison d'exemption en
code (BT-121) est présente, et que la raison d'exemption en texte (BT-120)
est absente, alors il faut indiquer dans la valeur d'exemption en texte (TT-
58) du flux 10.1 le texte correspondant au code VATEX présent en BT-121
(et à renseigner en TT-59), tel que listé dans la liste de codes VATEX
TT-58

BR-FR-MAP-27
Raison
d'exemption en
code et en texte
dans les flux 1 et
10.1
Dans une ligne de ventilation de TVA (BG-23), si la raison d'exemption en
texte (BT-120) est présente, et que la raison d'exemption en code (BT-121)
est absente, alors il faut indiquer dans le champ d'exemption en code (BT-
121) du flux 1 la valeur "NR"
BT-121

BR-FR-MAP-28
Raison
d'exemption en
code et en texte
dans les flux 1 et
10.1
Dans une ligne de ventilation de TVA (BG-23), si la raison d'exemption en
texte (BT-120) est présente, et que la raison d'exemption en code (BT-121)
est absente, alors il faut indiquer dans le champ d'exemption en code (TT-
59) du flux 10.1 la valeur "NR"
TT-59

BR-FR-MAP-29
Code exigibilité
TVA, Option
pour les débits
L'exigibilité de la TVA sur les Débits peut correspondre à la date de facture
(code 5 en CII ou 3 en UBL), ou à la date de livraison (29 en CII ou 35 en
UBL). Mais le PPF attend uniquement 5 (CII) ou 3 (UBL). 

Si BT-8 est égal à 29 en CII ou 35 en UBL, alors dans le flux 1 ou le flux 10.1
(TT-24), il faut renseigner respectivement 5 (CII) ou 3 (UBL). 
BT-8, TT-24

4.5.3 Les règles de contrôle CPRO pour les factures B2G à destination du secteur public

L'ensemble des règles ci-dessous s'applique si la facture est dans le périmètre B2G. Ceci peut être déterminé
du fait d'une indication dans la facture (au travers d’une Note avec Code sujet ADN et contenu B2G), ou bien
du fait d'une indication dans le canal de transmission entre l’émetteur de la facture et sa PA-E (Plateforme
Agréée d’Émission) et / ou suite à la consultation de l'annuaire par la PA-E permettant de déterminer que
l'Acheteur est un acteur public.

Ceci se traduit par une condition générale pour appliquer l’ensemble des contrôles additionnels exigés pour
les factures B2G et listés ci-dessous :

• S’il existe une note (BG-1), avec un code sujet (BT-21) égal à ADN et le contenu (BT-22) est égal à B2G
ou si le traitement identifie qu'il s’agit d'une facture B2G.

Le Tableau ci-dessous liste les règles de gestion « CHORUS PRO » applicables aux factures B2G :

CODE BR Titre Description S'applique à

BR-FR-CPRO-01
Qualification
d'un
contrat/marché
Cette règle de gestion est applicable uniquement pour le B2G :
Les valeurs possibles sont :
MARCHE
CONTRAT 

Si le type de contrat (EXT-FR-FE-01) est présent alors les seules valeurs possibles sont
CONTRAT ou MARCHE
EXT-FR-FE-01

BR-FR-CPRO-02 ID de facture
Règle de gestion applicable pour le B2G : 

L'identifiant de facture DOIT ÊTRE limité à 20 caractères 

Le nombre de caractères des numéros de facture (BT-1), de facture antérieure (BT-25),
de facture antérieure en ligne (EXT-FR-FE-136), DOIVENT être inférieurs ou égal à 20.
BT-1, BT-25, EXT-
FR-FE-136
AFNOR XP Z12-0122026-02

_Source: `c:\Users\g.baudrit\source\repos\gbaudrit\conf-aimer-votre-llm\demo\ctxc-sample-spec\with-ctxc\spec/afnor/XP_Z12-012/XP_Z12-012.pdf` (page:54/page:54)_

### E-29797f6da69e

XP Z12-012 – Formats et Profils des messages Factures et Statuts de cycle de vie, constitutifs du socle
minimal applicable à la Réforme Facture Électronique en France

53
CODE BR Titre Description S'applique à

BR-FR-CPRO-03 ID privés des
parties
Règle de gestion est applicable uniquement pour le B2G : 

L'ID privé du Vendeur (BT-29) DOIT être présent, avec un schemeId (BT-29-1) égal à
0009, 0223, 0226, 0227, 0228 ou 0229. 

Pour information, l'identifiant doit être valorisé avec l'une des valeurs ci-dessous et
respecter la longueur : 
- SIRET sur  14 caractères (identifiant de schéma : 0009) 
- UE_HORS_FRANCE (correspond à l'identifiant de TVA intracommunautaire) sur 18
caractères (identifiant de schéma : 0223) 
- HORS_UE (dont Wallis et Futuna) (correspond au code Pays et les 16 premiers
caractères de la raison sociale) sur  18 caractères (identifiant de schéma : 0227) 
- RIDET sur  9 ou 10 caractères (identifiant de schéma : 0228) 
- TAHITI sur  9 caractères (identifiant de schéma : 0229) 
- PARTICULIER sur 80 caractères (identifiant de schéma : 0226) 
L'identifiant de type 0226 est spécifique au B2G (Le destinataire de la facture (BG-7)
doit être exclusivement une structure publique). A ne pas utiliser en B2B, B2B
international ou B2C)/ L’identifiant est constitué de 80 caractères maximum respectant
cet ordre précis :
• Caractère n°1 . le genre, représenté par 1 chiffre (1 pour un homme et 2 pour une
femme) ;
• Caractères n°2 et n°3 . l’année de naissance, représentée par ses 2 derniers chiffres -
• Caractères n°4 et n°5 . le mois de naissance, représenté par 2 chiffres ;
• Caractères n°6 à n°10 . le lieu de naissance, représenté par 5 chiffres/
• Caractères n°11 à 80 .  
- Les 35 premiers caractères du nom de famille (suppression des espaces)  
- Les 35 premiers caractères du prénom (suppression des espaces)
BT-29

BR-FR-CPRO-04 ID privés des
parties
Si le schéma d'identification de l'ID privé du Vendeur (BT-29-1) est égal à 0223, alors le
nombre de caractère DOIT être inférieur à 18 

Il doit correspondre au n° de TVA du Vendeur (aussi présent en BT-31)
BT-29

BR-FR-CPRO-05 ID privés des
parties
Si le schéma d'identification de l'ID privé du Vendeur (BT-29-1) est égal à 0227, alors le
nombre de caractère DOIT être inférieur à 18. 

Il doit correspondre au code pays sur 2 caractères suivi des 16 premiers caractères de
la raison sociale telle que renseignée dans le référentiel ChorusPro
BT-29

BR-FR-CPRO-06 ID privés des
parties
Si le schéma d'identification de l'ID privé du Vendeur (BT-29-1) est égal à 0228, alors le
nombre de caractère DOIT être compris entre 9 et 10 

Il doit correspondre au RIDET
BT-29

BR-FR-CPRO-07 ID privés des
parties
Si le schéma d'identification de l'ID privé du Vendeur (BT-29-1) est égal à 0229, alors le
nombre de caractère DOIT être compris entre 9 et 10 

Il doit correspondre à un Identifiant TAHITI
BT-29

BR-FR-CPRO-08 ID privés des
parties
Si le schéma d'identification de l'ID privé du Vendeur (BT-29-1) est égal à 0226, alors
les 10 premiers caractères DOIVENT être des chiffres et les 70 autres des caractères. 

Il doit correspondre à un Identifiant de PARTICULIER
BT-29

BR-FR-CPRO-09 Identifiant du
vendeur
Règle de gestion est applicable uniquement pour le B2G : 

Si un identifiant de type SIREN pour le vendeur est renseigné en BT-30, la balise BT-29
doit être renseignée avec le SIRET (identifiant de schéma 0009) du vendeur. 

Si BT-30 est présent et que BT-30-1 = 0002, alors BT-29 DOIT être présent avec un
schemedID BT-29-1 = 0009 

Cet identifiant SIRET doit exister et être actif dans l'Annuaire. Cette règle ne peut pas
être vérifiée de façon automatique
BT-29, BT-29-1, BT-
30, BT-30-1
AFNOR XP Z12-0122026-02

_Source: `c:\Users\g.baudrit\source\repos\gbaudrit\conf-aimer-votre-llm\demo\ctxc-sample-spec\with-ctxc\spec/afnor/XP_Z12-012/XP_Z12-012.pdf` (page:55/page:55)_

### E-a87a31153792

XP Z12-012 – Formats et Profils des messages Factures et Statuts de cycle de vie, constitutifs du socle
minimal applicable à la Réforme Facture Électronique en France

54
CODE BR Titre Description S'applique à

BR-FR-CPRO-10 Identifiant de
l'acheteur
Cette règle de gestion est applicable uniquement pour le B2G : 

L'ID privé de l'ACHETEUR (BT-46) DOIT être renseigné avec le SIRET de l'Acheteur. 

Un ID privé de l'Acheteur (BT-46) avec un schemedID (BT-46-1) égal à 0009 DOIT être
présent.
BT-46, BT-46-1

BR-FR-CPRO-11 Identifiant de
l'acheteur
Cette règle de gestion est applicable uniquement pour le B2G : 

Si l'Annuaire indique que l'Acheteur identifié par le N° de SIRET (BT-46, avec BT-46-1
égal à 0009) exige un Code Service (DT-4-13-2 = true), alors un ID privé (BT-46) avec
schemeID 0224 (code_routage) DOIT être renseigné avec un Code Service 

Si l'enregistrement de l'Annuaire DT-4-13-2 pour le SIRET (DT-4-3) de l'Acheteur est
égal à "true", alors un ID privé de l'Acheteur (BT-46) avec un schemedID (BT-46-1) égal
à 0224 DOIT être présent et correspondre à l'un des Code Service renseigné dans
l'annuaire pour ce SIRET.
BT-46, BT-46-1

BR-FR-CPRO-12
Bon de
commande /
numéro
d'engagement
Règle de gestion applicable uniquement pour le B2G : 

Pour les débiteurs ayant rendu le numéro d'engagement obligatoire (voir l'annuaire des
destinataires), la balise BT-13 dot être renseignée.
Le cas échéant, le numéro du marché exécutable sous-jacent peut se substituer à la
référence d'engagement (et est donc présent en BT-13) 

Si l'enregistrement de l'Annuaire DT-4-13-1 pour le SIRET (DT-4-3) de l'Acheteur est
égal à "true", alors le numéro de commande (BT-13) DOIT être présent.
BT-13

BR-FR-CPRO-13
Bon de
commande /
numéro
d'engagement
Règle de gestion applicable uniquement pour le B2G : 

Pour les débiteurs ayant rendu le numéro d'engagement ou le code Service Exécutant
obligatoire (voir l'annuaire des destinataires), la balise BT-13 ou l'ID privé BT-46 avec
schemeD 0224 doit être renseigné. 

Si l'enregistrement de l'Annuaire DT-4-13-3 pour le SIRET (DT-4-3) de l'Acheteur est
égal à "true", alors le numéro de commande (BT-13) ou le Code Service Exécutant (BT-
46 avec shemeID = 0224) DOIT être présent.
BT-13

BR-FR-CPRO-14 Référence du
contrat
Règle de gestion applicable uniquement pour le B2G : 

La référence du contrat comporte 50 caractères maximum 

Le nombre de caractères du numéro de contrat (BT-12) est inférieur ou égal à 50
caractères.
BT-12

BR-FR-CPRO-15
Bon de
commande /
numéro
d'engagement
Règle de gestion applicable uniquement pour le B2G : 

La référence à l’engagement comporte 50 caractères maximum 

Le nombre de caractères du numéro de commande (BT-13) est inférieur ou égal à 50
caractères.
BT-13

BR-FR-CPRO-16 Identification
des tiers
Règle de gestion applicable uniquement pour le B2G : 

Les blocs "ADRESSÉE À" (EXT-FR-FE-BG-04) et "AGENT D'ACHETEUR" (EXT-FR-FE-BG-
01) ne doivent pas être renseignés. 

Si ces blocs sont renseignés, ils seront ignorés. 

Règle non vérifiable
EXT-FR-FE-BG-01,
EXT-FR-FE-BG-04
AFNOR XP Z12-0122026-02

_Source: `c:\Users\g.baudrit\source\repos\gbaudrit\conf-aimer-votre-llm\demo\ctxc-sample-spec\with-ctxc\spec/afnor/XP_Z12-012/XP_Z12-012.pdf` (page:56/page:56)_

### E-076064b34864

XP Z12-012 – Formats et Profils des messages Factures et Statuts de cycle de vie, constitutifs du socle
minimal applicable à la Réforme Facture Électronique en France

55
CODE BR Titre Description S'applique à

BR-FR-CPRO-17 ID privés des
tiers
Règle de gestion applicable uniquement pour le B2G : 

Si un bénéficiaire doit être mentionné dans la facture alors il faut renseigner un
identifiant de type SIRET (identifiant de schéma 0009) en BT-60 si le tiers a un SIREN
en BT-61  (bénéficiaire) ou un autre identifiant parmi la liste suivante s'il n'y a pas de
SIREN en BT-61 : UE_HORS FRANCE ("0223"), HORS_UE ("0227"), RIDET ("0228"),
TAHITI ("0229"), PARTICULIER ("0226") 

Si BG-10 est présent alors :
. Si BT-61 est présent avec shemeID = 0002 (SIREN) alors BT-60 DOIT être présente
avec schemeId 0009 et être le SIRET (9 premiers chiffres identiques au SIREN)
. SINON, BT-60 doit être présent, avec qualifiant (BT-60-1) égal à 0223, 0226, 0227,
0228 ou 0229
BG-10, BT-60, BT-
61

BR-FR-CPRO-18 ID privés des
tiers
Règle de gestion applicable uniquement pour le B2G : 

Si un agent de vendeur doit être mentionné dans la facture alors il faut renseigner un
identifiant de type SIRET (identifiant de schéma 0009) en EXT-FR-FE-69 si le tiers a un
SIREN en EXT-FR-FE-71  ou un autre identifiant parmi la liste suivante s'il n'y a pas de
SIREN en EXT-FR-FE-71 : UE_HORS FRANCE ("0223"), HORS_UE ("0227"), RIDET
("0228"), TAHITI ("0229"), PARTICULIER ("0226") 

Si un Agent de Vendeur (EXT-FR-FE-BG-03) est présent alors :
. Si EXT-FR-FE-69 est présent avec shemeID = 0002 (SIREN) alors le n° de SIRET (EXT-
FR-FE-71) DOIT être présent avec schemeId 0009 (EXT-FR-FE-72) et être le SIRET (9
premiers chiffres identiques au SIREN)
. SINON, EXT-FR-FE-71 doit être présent, avec qualifiant (EXT-FR-FE-72) égal à 0223,
0226, 0227, 0228 ou 0229
EXT-FR-FE-BG-03,
EXT-FR-FE-69, EXT-
FR-FE-71

BR-FR-CPRO-19 Lignes de
facturation
Règle de gestion applicable uniquement pour le B2G : 

Le numéro de ligne (BT-126) est une séquence numérique limitée à 6 caractères (1-
999999).
Les numéros de ligne ne sont pas contrôlés mais leur nombre ne doit pas dépasser la
limite maximale donnée 

Le nombre de lignes d'une facture B2G (BG-25) DOIT être strictement inférieur à 1 000
000
BT-126

BR-FR-CPRO-20
Référence à la
facture
antérieure
Règle de gestion applicable uniquement pour le B2G : 

Une seule référence de facture antérieure est autorisée. 

Le groupe BG-3 Facture antérieure DOIT avoir une seule occurrence
BG-3

BR-FR-CPRO-21
Sous-
traitance/co-
traitance B2G
Règle de gestion applicable uniquement pour le B2G : 

Si le cadre de facturation (BT-23) est S3 ou S6 (Cas de gestion de la sous-traitance/co-
traitance B2G), le groupe AGENT DE VENDEUR (EXT-FR-FE-BG-03) DOIT être présent
afin de renseigner le titulaire/Mandataire, ainsi que son numéro de SIREN (EXT-FR-FE-
71) et son n° de SIRET (EXT-FR-FE-69 avec schemeID EXT-FR-FE-70 = 0009).
BT-23, EXT-FR-FE-
BG-03, EXT-FR-FE-
71

BR-FR-CPRO-22 ID privés des
tiers
Règle de gestion applicable uniquement pour le B2G : 

Si le bloc AGENT DE VENDEUR (EXT-FR-FE-BG-03) est présent et contient un
Identifiant privé (EXT-FR-FE-69) avec un identifiant de schema (EXT-FR-FE-70) égal à
0009 (de type SIRET), alors l'Agent de vendeur doit être connu du portail de service
Chorus PRO (présent dans l'annuaire des destinataires). 

Règle métier non vérifiable automatiquement
EXT-FR-FE-BG-03,
EXT-FR-FE-69, EXT-
FR-FE-70

BR-FR-CPRO-23
Sous-
traitance/co-
traitance B2G
Règle de gestion applicable uniquement pour le B2G : 

Si le cadre de facturation (BT-23) est « S3 » (Dépôt d'une facture de service de sous-
traitance avec paiement direct), le destinataire de la facture identifié en BG-7
(Acheteur) DOIT être une entité publique identifiée comme telle dans l'Annuaire 

Règle métier non vérifiable automatiquement
BT-23
AFNOR XP Z12-0122026-02

_Source: `c:\Users\g.baudrit\source\repos\gbaudrit\conf-aimer-votre-llm\demo\ctxc-sample-spec\with-ctxc\spec/afnor/XP_Z12-012/XP_Z12-012.pdf` (page:57/page:57)_

### E-e5edc7f69d21

XP Z12-012 – Formats et Profils des messages Factures et Statuts de cycle de vie, constitutifs du socle
minimal applicable à la Réforme Facture Électronique en France

56
CODE BR Titre Description S'applique à

BR-FR-CPRO-24 Cadre de
facturation
Règle de gestion applicable uniquement pour le B2G : 

Le Cadre de Facturation (BT-23) ne DOIT PAS être égal à S5 (Dépôt par un sous-traitant
d’une facture de prestation de service)/
BT-23

BR-FR-CPRO-25 Condition de
paiement
Règle de gestion applicable uniquement pour le B2G : 

Une seule condition de paiement est autorisée. 

BT-20 a une seule occurrence.
BT-20

BR-FR-CPRO-26 Contact vendeur
Règle de gestion applicable uniquement pour le B2G : 

Un seul contact du vendeur est autorisé. 

BG-6 a une seule occurrence
BG-6

BR-FR-CPRO-27 Contact
acheteur
Règle de gestion applicable uniquement pour le B2G : 

Un seul contact de l'acheteur est autorisé. 

BG-9 a une seule occurrence
BG-9

BR-FR-CPRO-28 Contact agent
de vendeur
Règle de gestion applicable uniquement pour le B2G : 

Un seul contact de l'agent de vendeur est autorisé. 

EXT-FR-FE-85 a une seule occurrence
EXT-FR-FE-85

BR-FR-CPRO-29
Motif
d'exonération
de la TVA
Règle de gestion applicable uniquement pour le B2G : 

La longueur de la donnée "Motif d'exonération de la TVA" est limitée à 1024 caractères. 

Le nombre de caractères du Motif d'exonération en texte du bloc Ventilation de TVA
(BT-120) DOIT être inférieur ou égal à 1024
BT-120

BR-FR-CPRO-30
Référence de
document
justificatif
Règle de gestion applicable uniquement pour le B2G : 

La longueur de la donnée "Référence de document justificatif" est limitée à 50
caractères. 

Le nombre de caractères de la Référence de document justificatif (BT-122 de BG-24)
DOIT être inférieure ou égale à 50.
BT-122

BR-FR-CPRO-31 Description de
l'article
Règle de gestion applicable uniquement pour le B2G : 

La longueur de la donnée "Description de l'article" est limitée à 1024 caractères. 

Le nombre de caractères de la Description de l'article (BT-154) DOIT être inférieur ou
égal à 1024.
BT-154

BR-FR-CPRO-32
Adresse du
vendeur - Ligne
1
Règle de gestion applicable uniquement pour le B2G : 

La longueur de la donnée "Adresse du vendeur - Ligne 1" est limitée à 400 caractères. 

Le nombre de caractères de l'adresse du Vendeur - ligne 1 (BT-35) DOIT être inférieur
ou égal à 400.
BT-35

BR-FR-CPRO-33 Localité du
vendeur
Règle de gestion applicable uniquement pour le B2G : 

La longueur de la donnée "Localité du vendeur" est limitée à 400 caractères. 

Le nombre de caractères de la localité du Vendeur (BT-37) DOIT être inférieur ou égal à
400.
BT-37
AFNOR XP Z12-0122026-02

_Source: `c:\Users\g.baudrit\source\repos\gbaudrit\conf-aimer-votre-llm\demo\ctxc-sample-spec\with-ctxc\spec/afnor/XP_Z12-012/XP_Z12-012.pdf` (page:58/page:58)_

### E-bc007415b397

XP Z12-012 – Formats et Profils des messages Factures et Statuts de cycle de vie, constitutifs du socle
minimal applicable à la Réforme Facture Électronique en France

57
CODE BR Titre Description S'applique à

BR-FR-CPRO-34
Appellation
commerciale de
l'acheteur
Règle de gestion applicable uniquement pour le B2G : 

La longueur de la donnée "Appellation commerciale de l'acheteur" est limitée à 99
caractères. 

Le nombre de caractères de l'Appellation commerciale de l'acheteur (BT-45) DOIT être
inférieur ou égal à 99.
BT-45

BR-FR-CPRO-35 Conditions de
paiement
Règle de gestion applicable uniquement pour le B2G : 

La longueur de la donnée "Conditions de paiement" est limitée à 1024 caractères. 

Le nombre de caractères des Conditions de paiement (BT-20) DOIT être inférieur ou
égal à 1024.
BT-20

BR-FR-CPRO-36
Appellation
commerciale du
vendeur
Règle de gestion applicable uniquement pour le B2G : 

La longueur de la donnée "Appellation commerciale du vendeur" est limitée à 99
caractères. 

Le nombre de caractères de l'Appellation commerciale du Vendeur (BT-28) DOIT être
inférieur ou égal à 99.
BT-28

BR-FR-CPRO-37 Nom du
bénéficiaire
Règle de gestion applicable uniquement pour le B2G : 

La longueur de la donnée "Nom du bénéficiaire" est limitée à 99 caractères. 

Le nombre de caractères du Nom du bénéficiaire (BT-59) DOIT être inférieur ou égal à
99.
BT-59

BR-FR-CPRO-38
Identifiant de
l'établissement
de livraison
Règle de gestion applicable uniquement pour le B2G : 

La longueur de la donnée "Identifiant de l'établissement de livraison" est limitée à 20
caractères. 

Le nombre de caractères de l'Identifiant de l'établissement de livraison (BT-71) DOIT
être inférieur ou égal à 20.
BT-71

BR-FR-CPRO-39
Identifiant de
compte de
paiement
Règle de gestion applicable uniquement pour le B2G : 

La longueur de la donnée "Identifiant de compte de paiement" est limitée à 27
caractères. 

Le nombre de caractères de l'Identifiant de compte de paiement (BT-84) DOIT être
inférieur ou égal à 84.
BT-84

BR-FR-CPRO-40
Identifiant
global du lieu de
livraison à la
ligne
Règle de gestion applicable uniquement pour le B2G : 

La longueur de la donnée "Identifiant global du lieu de livraison à la ligne" est limitée à
20 caractères. 

Le nombre de caractères de l'Identifiant global du lieu de livraison à la ligne (EXT-FR-
FE-146) DOIT être inférieur ou égal à 20.
EXT-FR-FE-146

BR-FR-CPRO-41
Nom de fichier
du document
joint
Règle de gestion applicable uniquement pour le B2G : 

La longueur de la donnée "Nom de fichier du document joint" est limitée à 50
caractères. 

Le nombre de caractères du Nom de fichier du document joint (BT-125-2) DOIT être
inférieur ou égal à 50.
BT-125-2

BR-FR-CPRO-42 Note de facture
Règle de gestion applicable uniquement pour le B2G : 

La longueur de la donnée "Note de facture" est limitée à 1024 caractères. 

Le nombre de caractères du contenu de la Note de facture (BT-22) DOIT être inférieur
ou égal à 1024.
BT-22
AFNOR XP Z12-0122026-02

_Source: `c:\Users\g.baudrit\source\repos\gbaudrit\conf-aimer-votre-llm\demo\ctxc-sample-spec\with-ctxc\spec/afnor/XP_Z12-012/XP_Z12-012.pdf` (page:59/page:59)_

### E-35bae1ba5ea5

XP Z12-012 – Formats et Profils des messages Factures et Statuts de cycle de vie, constitutifs du socle
minimal applicable à la Réforme Facture Électronique en France

58
CODE BR Titre Description S'applique à

BR-FR-CPRO-43 Raison sociale
du vendeur
Règle de gestion applicable uniquement pour le B2G : 

La longueur de la donnée "Raison sociale du vendeur" est limitée à 99 caractères. 

Le nombre de caractères de la Raison sociale du vendeur (BT-27) DOIT être inférieur
ou égal à 99.
BT-27

BR-FR-CPRO-44 Raison sociale
de l'acheteur
Règle de gestion applicable uniquement pour le B2G : 

La longueur de la donnée "Raison sociale de l'acheteur" est limitée à 99 caractères. 

Le nombre de caractères de la Raison sociale de l'acheteur (BT-44) DOIT être inférieur
ou égal à 99.
BT-44

4.5.4 Règles de gestion spécifiques pour les factures multi-vendeurs

Pour signifier qu’une facture est multi-vendeurs, il faut utiliser un cadre de facturation B8, S8 ou M8 en BT-
23, sachant que le cadre de facturation des factures unitaires peut varier d’un VENDEUR à l’autre et est alors
indiqué en ligne de facture (celle qualifiée GROUP a minima)/ C’est pourquoi toutes les règles de gestion ci-
dessous ne s’applique que si le cadre de facturation (BT-23) est égal à B8, S8 ou M8.

La Tableau ci-dessous liste les règles spécifiques à la gestion des factures multi-vendeurs

CODE BR Titre Description S'applique à

BR-FR-MV-01
Facture multi-
vendeurs
Cadre de
facturation 8
Si le Cadre de facturation (BT-23) est égal à S8, B8 ou M8 alors : 

Toutes les lignes (BG-25) DOIVENT contenir un sous-type de ligne (EXT-FR-FE-163).
EXT-FR-FE-163

BR-FR-MV-02
Facture multi-
vendeurs
Ligne GROUP
par sous-
vendeur
Si le Cadre de facturation (BT-23) est égal à S8, B8 ou M8 alors : 

La facture DOIT contenir au moins 1 ligne (BG-25) avec le sous-type de ligne (EXT-FR-
FE-163) égal à "GROUP" et sans identifiant de ligne Parent (EXT-FR-FE-162)
EXT-FR-FE-163

BR-FR-MV-03
Facture multi-
vendeurs
Mentions
Obligatoires du
Vendeur en
ligne
Si le Cadre de facturation (BT-23) est égal à S8, B8 ou M8 alors : 

Pour chaque ligne (BG-25) avec un sous-type de ligne (EXT-FR-FE-163) égal à "GROUP"
et sans identifiant de ligne Parent (EXT-FR-FE-162), les données suivantes DOIVENT
être présentes :
. Un nom de vendeur à la ligne (EXT-FR-FE-164)
. Un identifiant de vendeur à la ligne (EXT-FR-FE-167)
. Un code pays de vendeur à la ligne (EXT-FR-FE-177)
. Une valeur d'objet facturé (BT-128) avec identifiant de schéma (BT-128-1) = AFL
(numéro de facture par vendeur)
. Une valeur d'objet facturé (BT-128) avec identifiant de schéma (BT-128-1) = AVV
(cadre de facturation par vendeur), différent de M8/S8/B8
.Un montant total avec TVA à la ligne (EXT-FR-FE-184) en devise de facture
EXT-FR-FE-164,
EXT-FR-FE-167,
EXT-FR-FE-177, BT-
128, BT-128-1

BR-FR-MV-04
Facture multi-
vendeurs
Identifiant TVA
du Vendeur en
ligne
Si le Cadre de facturation (BT-23) est égal à S8, B8 ou M8 alors : 

Pour chaque ligne (BG-25) avec un sous-type de ligne (EXT-FR-FE-163) égal à "GROUP"
et sans identifiant de ligne Parent (EXT-FR-FE-162), si le Vendeur de ligne est assujetti
à la TVA et dispose d'un Identifiant de TVA, alors, l'identifiant TVA à la ligne (EXT-FR-
FE-168) DOIT être présent.
EXT-FR-FE-168

BR-FR-MV-05
Facture multi-
vendeurs
Règle de calcul
du Total HT par
Vendeur
Si le Cadre de facturation (BT-23) est égal à S8, B8 ou M8 alors : 

Le total HT de ligne (BT-131) des lignes (BG-25) avec un sous-type de ligne (EXT-FR-
FE-163) égal à "GROUP" et sans identifiant de ligne Parent (EXT-FR-FE-162) DOIT être
égal à la somme des totaux de ligne (BT-131) des lignes pour lesquelles l'identifiant de
ligne Parent (EXT-FR-FE-162) est égal à l'identifiant de ligne (BT-126) de la ligne
"GROUP".
EXT-FR-FE-BG-12,
BT-128, EXT-FR-FE-
162
AFNOR XP Z12-0122026-02

_Source: `c:\Users\g.baudrit\source\repos\gbaudrit\conf-aimer-votre-llm\demo\ctxc-sample-spec\with-ctxc\spec/afnor/XP_Z12-012/XP_Z12-012.pdf` (page:60/page:60)_

### E-70cc79be22a5

XP Z12-012 – Formats et Profils des messages Factures et Statuts de cycle de vie, constitutifs du socle
minimal applicable à la Réforme Facture Électronique en France

59
CODE BR Titre Description S'applique à

BR-FR-MV-06
Facture multi-
vendeurs
Identifiant legal
de Vendeur à la
ligne
Si le Cadre de facturation (BT-23) est égal à S8, B8 ou M8 alors : 

Toutes les lignes de factures (BG-25) DOIVENT contenir un identifiant légal de vendeur
à la ligne (EXT-FR-FE-167), identique à celui de la ligne (BG-25) dont l'identifiant de
ligne (BT-126) est égal à l'identifiant de ligne Parent (EXT-FR-FE-162), si présent.
EXT-FR-FE-167

BR-FR-MV-07
Facture multi-
vendeurs
numéro de
facture à la ligne
Si le Cadre de facturation (BT-23) est égal à S8, B8 ou M8 alors : 

Toutes les lignes de factures (BG-25) DOIVENT contenir un numéro de facture de ligne,
codifié avec l'objet facturé (BT-128 avec BT-128-1 = AFL) identique à celui de la ligne
(BG-25)  dont l'identifiant de ligne (BT-126) est égal à l'identifiant de ligne Parent
(EXT-FR-FE-162), si présent.
BT-128, BT-128-1

BR-FR-MV-08
Facture multi-
vendeurs
raison
d'exemption à la
ligne
Si le Cadre de facturation (BT-23) est égal à S8, B8 ou M8 alors : 

Toutes les lignes de factures (BG-25) DOIVENT contenir une raison d'exemption TVA en
texte commençant par le numéro de facture en ligne (EXT-FR-FE-178) entre # (exemple
#F2025003#)
BT-128, BT-128-1,
EXT-FR-FE-178

BR-FR-MV-09
Facture multi-
vendeurs
Montant TVA
par Vendeur de
ligne "GROUP"
Si le Cadre de facturation (BT-23) est égal à S8, B8 ou M8 alors : 

Le montant total TVA à la ligne (EXT-FR-FE-181) des lignes (BG-25) avec un sous-type
de ligne (EXT-FR-FE-163) égal à "GROUP" et sans identifiant de ligne Parent (EXT-FR-
FE-162) DOIT être égal à la somme des Montants de TVA de la ventilation de TVA (BT-
117) pour lesquelles la raison d'exemption (BT-120) commence par le numéro de
facture à la ligne (BT-128 avec BT-128-1 = AFL) entre # 
EXT-FR-FE-181

BR-FR-MV-10
Facture multi-
vendeurs
Montant total
avec TVA par
Vendeur de
ligne "GROUP"
Si le Cadre de facturation (BT-23) est égal à S8, B8 ou M8 alors : 

Si le montant total avec TVA en ligne (EXT-FR-FE-184) d'une ligne (BG-25) avec un
sous-type de ligne (EXT-FR-FE-163) égal à "GROUP" et sans identifiant de ligne Parent
(EXT-FR-FE-162) est présent, alors : 

La valeur absolue du (montant total avec TVA (EXT-FR-FE-184) - le montant HT total de
ligne (BT-131) - le montant total de TVA de ligne (EXT-FR-FE-181)) <= 0,01 * nbre de
sous-ligne avec sous-type de ligne (EXT-FR-FE-163) égal à "DETAIL".
EXT-FR-FE-184,
EXT-FR-FE-181, BT-
131

BR-FR-MV-11
Numéro de
factures de ligne
pour le Vendeur
principal
Si le Cadre de facturation (BT-23) est égal à S8, B8 ou M8 alors : 

Si le Vendeur principal identifié dans le bloc Vendeur (BG-4) de la facture au travers de
son identifiant légal (BT-27) dispose d'un groupe de lignes de facturation, alors
l'identifiant de facture à la ligne ((BT-128) avec scheme ID = AFL (BT-128-1) ), quand
présent (au minimum sur la ligne "GROUP"), DOIT être égal au numéro de facture (BT-
1).
BT-128, BT-128-1

BR-FR-MV-12
Numéro de
factures
unitaires de
ligne uniques
Si le Cadre de facturation (BT-23) est égal à S8, B8 ou M8 alors : 

Les numéros de facture à la ligne (Valeur de BT-128 avec BT-128-1 = AFL) pour les
lignes (BG-25) avec sous-type de ligne (EXT-FR-FE-163) = "GROUP" et sans identifiant
de ligne Parent (EXT-FR-FE-162) DOIVENT être uniques (une seule occurrence). 

Voir recommandations pour créer des numéros de factures unitaires distincts et
conformes aux exigences réglementaires, chapitre 4.4.12.2.
BT-128, BT-128-1

BR-FR-MV-13
Codes types des
factures Multi
Vendeur (pas
d'auto-facture)
Si le Cadre de facturation (BT-23) est égal à S8, B8 ou M8 alors : 

le code type de facture (BT-3) est différent de : 

- Facture auto-facturée (389)
- Avoir auto-facturé (261)
- Facture auto-facturée affacturée (501)
- Facture d’acompte auto-facturée (500)
- Avoir auto-facturé affacturé (502)
- Facture rectificative auto-facturée (471)
- Facture rectificative auto-facturée affacturée ( 473)
BT-3
AFNOR XP Z12-0122026-02

_Source: `c:\Users\g.baudrit\source\repos\gbaudrit\conf-aimer-votre-llm\demo\ctxc-sample-spec\with-ctxc\spec/afnor/XP_Z12-012/XP_Z12-012.pdf` (page:61/page:61)_

### E-bd494331c66d

XP Z12-012 – Formats et Profils des messages Factures et Statuts de cycle de vie, constitutifs du socle
minimal applicable à la Réforme Facture Électronique en France

60
Ci-dessous le tableau des règles de mapping pour créer les factures unitaires pour chaque VENDEUR, puis
l’extraction des flux 1 / 10/1 unitaires aussi :

CODE BR Titre Description S'applique à

BR-FR-MVMAP-
01
Facture unitaire
par Vendeur en
cas de facture
multi-vendeurs
Si le Cadre de facturation (BT-23) est égal à S8, B8 ou M8 alors la Plateforme Agréée
d'émission qui supporte la gestion des factures Multi-vendeurs DOIT créer autant de
flux 1 que de numéro de facture en ligne présents dans la facture. Pour ce faire, une
première étape consiste à créer des factures unitaires par numéro de facture en ligne
en suivant les règles ci-dessous sur la base des informations fournies dans la ligne (BG-
25) avec un sous-type de ligne (EXT-FR-FE-163) égal à "GROUP" et sans identifiant de
ligne Parent (EXT-FR-FE-162) :
. Remplacer les informations du Vendeur (BG-4) par celles du Vendeur en ligne (EXT-
FR-FE-BG-12)
. Remplacer le numéro de facture (BT-1) par le numéro de facture en ligne (BT-128,
avec BT-128-1 = AFL)
. Remplacer le Cadre de facturation (BT-23) par le cadre de facturation en ligne (BT-128
avec BT-128-1 = AVV).
. Remplacer le code de date d'exigibilité TVA (option sur les débits, BT-8) par celui
indiqué en ligne (EXT-FR-FE-180)
. Remplacer le total TVA dans la devise de la facture (BT-110) par le montant TVA en
devise de facture en ligne (EXT-FR-FE-181).
. Si présent, remplacer le total TVA dans la devise de comptabilisation (BT-111) par le
montant TVA en devise de comptabilisation en ligne (EXT-FR-FE-182).
.Remplacer le montant total avec TVA (BT-112), par le montant total avec TVA en ligne
(EXT-FR-FE-184).
. Porter le montant déjà payé (BT-113) au montant total avec TVA ci-dessus.
. Porter le montant Net à payer (BT-115) à 0 (par conséquent).
. Conserver uniquement les lignes pour lesquelles le numéro de facture en ligne est
celui la facture unitaire (BT-128, avec BT-128-1 = AFL).
. Conserver uniquement les lignes de ventilation de TVA (BG-23) pour lesquelles la
raison d'exemption en texte (BT-120) commence par le numéro de facture en ligne (BT-
128, avec BT-128-1 = AFL) entre #
EXT-FR-FE-BG-12,
BT-128, BT-128-1,
EXT-FR-FE-180,
EXT-FR-FE-181,
EXT-FR-FE-182,
EXT-FR-FE-184

BR-FR-MVMAP-
02
Constitution du
flux 1 ou 10.1
Si le Cadre de facturation (BT-23) est égal à S8, B8 ou M8 alors la Plateforme Agréée
d'émission qui supporte la gestion des factures Multi-vendeurs DOIT créer autant de
flux 1 que de factures unitaires (numéros de facture en ligne). 
Pour ce faire, la seconde étape consiste à extraire le flux 1 ou 10.1 à partir de la facture
unitaire, ce qui revient à utiliser les informations fournies dans la ligne (BG-25) avec un
sous-type de ligne (EXT-FR-FE-163) égal à "GROUP" et sans identifiant de ligne Parent
(EXT-FR-FE-162), identifiant les données spécifiques à chaque Vendeur, de la façon
suivante :
. Utiliser les informations du Vendeur en ligne (EXT-FR-FE-BG-12) au lieu de celles du
Vendeur (BG-4)
. Utiliser le numéro de facture en ligne (BT-128, avec BT-128-1 = AFL) au lieu du
numéro de facture (BT-1)
. Utiliser le Cadre de facturation en ligne (BT-128 avec BT-128-1 = AVV) au lieu du
Cadre de facturation (BT-23)
. Utiliser le code de date d'exigibilité TVA (option sur les débits, EXT-FR-FE-180) au lieu
de celui de la facture (BT-8)
. Utiliser le total TVA dans la devise de la facture en ligne (EXT-FR-FE-181) au lieu de
celui de la facture (BT-110), si présent
. Si présent, utiliser le total TVA dans la devise de la facture en ligne (EXT-FR-FE-182)
au lieu de celui de la facture (BT-111).
. Utiliser uniquement les lignes pour lesquelles pour lesquelles le numéro de facture en
ligne est celui la facture unitaire (BT-128, avec BT-128-1 = AFL), et pour lesquelles le
sous-type de ligne (EXT-FR-FE-163) est égal à "DETAIL".
. Utiliser uniquement les lignes de ventilation de TVA (BG-23) pour lesquelles la raison
d'exemption en texte (BT-120) commence par le numéro de facture en ligne (BT-128,
avec BT-128-1 = AFL) entre #
EXT-FR-FE-BG-12,
BT-128, BT-128-1,
EXT-FR-FE-180,
EXT-FR-FE-181,
EXT-FR-FE-182

4.6 Règle de constitution d’une représentation lisible d’une facture électronique de la
présente Norme.

La réglementation européenne et sa transposition en réglementation française imposent aux entreprises de
fournir une représentation lisible des factures électroniques.

En droit français, cette obligation est précisée comme devant s’appliquer sur l’intégralité des informations
présentes dans la facture électronique, qu’elles soient obligatoires ou facultatives/
AFNOR XP Z12-0122026-02

_Source: `c:\Users\g.baudrit\source\repos\gbaudrit\conf-aimer-votre-llm\demo\ctxc-sample-spec\with-ctxc\spec/afnor/XP_Z12-012/XP_Z12-012.pdf` (page:62/page:62)_

### E-1a0e8ed79e02

XP Z12-012 – Formats et Profils des messages Factures et Statuts de cycle de vie, constitutifs du socle
minimal applicable à la Réforme Facture Électronique en France

61
Une facture électronique structurée (ici en UBL ou UN/CEFACT CII) est un ensemble de données associées à
une structure syntaxique et sémantique portant le sens de chaque donnée.

4.6.1 Construire un modèle de représentation lisible

La représentation lisible doit donc fournir à la fois les données mais aussi leur sens sémantique, et pour les
données encodées (listes de codes), la signification en texte.

Elle doit donc s’organiser de la façon suivante :

• Tout d’abord, il convient de définir un modèle de présentation, qui se présente en général en 3 parties
communément admis par les usages commerciaux :

✓ Les données d’entête, présentant les parties (Nom, adresse électronique, adresse postale,
identifiants, contact) et les références (dont la date, le numéro de facture, et le cas échéant un
numéro de bon de commande, 0)

✓ Les données de pied qui regroupent la ventilation de TVA, les totaux, les informations relatives au
paiement, les mentions réglementaires

✓ Les données de lignes, en général organisées en colonnes pour fournir toutes les informations de
ligne.

Chaque donnée doit pouvoir être comprise sans ambiguïté, ce qui impose de les nommer pour en donner le
sens. Par un exemple, une date toute seule ne signifie rien/ Il faut préciser s’il s’agit de la date de facture, la
date de livraison, la date d’échéance 0

4.6.2 Comment représenter les données sous forme de codes

Un certain nombre de données sont en pratique des codes, comme par exemple les codes « type de facture »
(BT-3 . 380 pour facture, 381 pour avoir, 386 pour les factures d’acompte, 0)/ La présentation lisible doit alors
présenter la signification en texte qui est donnée dans les listes de codes/ Lorsqu’elles sont en anglais, il
convient d’en donner la traduction française/ Ainsi, on va présenter le code type 380 en écrivant « Facture »,
381 en écrivant « AVOIR ». 

Il n’est alors pas nécessaire de fournir la valeur du code, mais il est aussi possible de la présenter (par exemple
entre parenthèse).

Par exemple, les adresses électroniques ont un schéma d’identification qui peut s’intégrer à l’adresse :

• Pour une adresse présente dans l’annuaire, une présentation 0225.SIREN_SUFFIXE est suffisamment
claire

• Pour un email, la structure xxx@zzz.tt suffit à comprendre.

Pour les notes (BG-1), le code sujet (BT-21) peut aussi servir à les positionner dans la représentation lisible
(note de pénalités, note de condition d’escompte, note de type de traitement, notes d’informations
complémentaires, 0) 

4.6.3 Factur-X et Facture structurée avec une présentation lisible attachée

Il est complexe de créer un modèle universel de présentation de tous les champs possibles d’une facture, car
il y en a beaucoup, ce que ferait une solution en réception. En particulier, la présentation des lignes oblige
alors à compléter une présentation en colonne de listes de données à organiser à chaque ligne.

Il est plus aisé de créer un modèle de présentation pour l’émetteur dans la mesure où il connait les données
qu’il utilise et peut ainsi mieux les présenter/

Le format Factur-X est composé d’une représentation lisible intégrale de la facture à laquelle est attaché un
fichier de données de factures (factur-x.xml) qui doit être conforme aux exigences décrites dans la présente
Norme et qui ne doit contenir que des informations présentes dans la présentation lisible, la liberté étant
laissée à ce que certaines informations complémentaires soient uniquement présentes dans la présentation
lisible.
AFNOR XP Z12-0122026-02

_Source: `c:\Users\g.baudrit\source\repos\gbaudrit\conf-aimer-votre-llm\demo\ctxc-sample-spec\with-ctxc\spec/afnor/XP_Z12-012/XP_Z12-012.pdf` (page:63/page:63)_

### E-9b344c0d5a64

XP Z12-012 – Formats et Profils des messages Factures et Statuts de cycle de vie, constitutifs du socle
minimal applicable à la Réforme Facture Électronique en France

62
Factur-X contient donc une représentation lisible conforme par construction, ce qui implique que les solutions
qui le créent s’attachent à garantir que toutes les informations présentes dans le fichier structuré soient bien
présentes dans la présentation PDF.

Pour ce faire, il est important que la présentation lisible soit créée à partir du fichier structuré, le cas échéant
en ajoutant des informations complémentaires, soit qui ne rentrent pas dans le modèle de données, soit dont
l’émetteur ne dispose pas de façon structurée (tel que des informations générales, des graphes, des logos, voire
des informations promotionnelles ou d’ordre opérationnelles 0)/

Il est aussi possible pour l’émetteur de créer sa propre représentation lisible de sa facture UBL ou UN/CEFACT
CII, dans le respect des règles décrites ci-dessus. Cette représentation lisible devra alors être jointe dans le
fichier structuré en UBL ou UN/CEFAT CII, dans le groupe BG-24, en BT-125 (en général encodé en Base64),
avec une description BT-123 de document égale à « LISIBLE ».

Il est alors toléré que cette représentation LISIBLE contienne des informations additionnelles à celles
présentes dans le fichier structuré, dans la mesure où ces informations n’ont pas leur place dans la structure
sémantique du format du socle minimum utilisé.

Cette présentation LISIBLE peut alors être utilisé par le destinataire de la facture pour ses propres besoins. Il
conserve toutefois l’obligation de présenter sous forme lisible le fichier structuré de facture sur demande de
l’administration dans l’éventualité où celle transmis par l’émetteur ne serait pas conforme/ Des outils de
présentation standard de chaque profil peuvent alors servir à cet effet, même si la présentation sera nettement
moins adaptée aux besoins de visualisation opérationnels à des fins de validation par exemple.

La création de LISIBLE peut aussi être faite à partir d’une feuille de style qui peut être mise à disposition par
l’émetteur ou en son nom/ Il convient toutefois que chaque partie qui souhaite utiliser cette feuille de style se
préoccupe da sa conservation intègre et de sa capacité à l‘utiliser pendant la période de conservation/ La
responsabilité de production du lisible incombe à chaque partie, et donc au destinataire, qui ne pourra pas
dégager sa responsabilité en cas de défaut de la feuille de style ou de sa non-applicabilité.

4.6.4 Exemples

Il est complexe de créer un modèle universel de présentation de tous les champs possibles d’une facture, car
il y en a beaucoup, ce que ferait une solution en réception. En particulier, la présentation des lignes oblige
alors à compléter une présentation en colonne de listes de données à organiser à chaque ligne.

Il est plus aisé de créer un modèle de présentation pour l’émetteur dans la mesure où il connait les données
qu’il utilise et peut ainsi mieux les présenter/

Ci-dessous un exemple de présentation d’une facture fictive contenant la quasi-intégralité des données
présentes dans le profil EN 16931.
AFNOR XP Z12-0122026-02

_Source: `c:\Users\g.baudrit\source\repos\gbaudrit\conf-aimer-votre-llm\demo\ctxc-sample-spec\with-ctxc\spec/afnor/XP_Z12-012/XP_Z12-012.pdf` (page:64/page:64)_

### E-9f515a323ce6

XP Z12-012 – Formats et Profils des messages Factures et Statuts de cycle de vie, constitutifs du socle
minimal applicable à la Réforme Facture Électronique en France

63 
AFNOR XP Z12-0122026-02

_Source: `c:\Users\g.baudrit\source\repos\gbaudrit\conf-aimer-votre-llm\demo\ctxc-sample-spec\with-ctxc\spec/afnor/XP_Z12-012/XP_Z12-012.pdf` (page:65/page:65)_

### E-d7974b0d088a

XP Z12-012 – Formats et Profils des messages Factures et Statuts de cycle de vie, constitutifs du socle
minimal applicable à la Réforme Facture Électronique en France

64
4.7 Conversions entre formats du socle

La réforme impose une obligation de conversion entre les formats et profils de facture du socle minimum,
objet du présent document.

Il existe plusieurs situations de conversion :

• La conversion entre une facture UBL et une facture UN/CEFACT du même profil . c’est le plus simple
puisque le modèle sémantique se décline dans les deux syntaxes. Chaque donnée présente dans une
des deux syntaxes à une place équivalente dans l’autre syntaxe/ Si une présentation LISIBLE est jointe
dans le fichier avant conversion, elle peut être jointe de la même façon dans le fichier converti.

• La conversion d’un profil EN16931 vers un profil EXTENDED/ Il en est de même puisque le profil
EXTENDED contient toutes les données du profil EN 16931.

• La conversion d‘un profil EXTENDED-CTC-FR vers un profil EN 16931 . l’ensemble des données
communes peuvent se convertir. Mais les données présentes dans le profil EXTENDED-CTC-FR qui ne
sont pas dans le profil EN 16931 ne peuvent pas être converties/ Pour ne pas perdre d’information, il
est alors nécessaire de joindre un LISIBLE, soit en prenant celui qui a été fourni, si c’est le cas, soit en
créant un LISIBLE sur la base de toutes les informations présentes dans le profil EXTENDED-CTC-FR
avant conversion. Le LISIBLE DOIT alors être joint au fichier de facture converti. 
Toutefois, étant donné que le profil EXTENDED-CTC-FR contient des tolérances dans certaines règles
de calcul, la conversion vers le profil EN 16931 peut rendre le résultat non conforme aux règles plus
strictes.

• La conversion d’une facture structurée UBL ou UN/CEFAT CII vers Factur-X : se passe comme une
conversion entre formats et profils structurés, sauf que la création d’un LISIBLE est obligatoire, soit en
utilisant celui joint au fichier de facture source, soit en le créant à partir du fichier de données. Les
éventuelles pièces jointes présentes en BG-24 de la facture structurée peuvent être joints directement
comme fichier attaché du PDF/A-3, à côté du factur-x.xml.

• La conversion d’une facture Factur-X profil EN 16931 ou EXTENDED en format structuré (UBL ou
UN/CEFACT CII) consiste d’abord à convertir le fichier structuré factur-x.xml vers le format cible
(uniquement pour les données qui ont leur place dans le profil cible), puis à joindre le lisible en BG-24,
ainsi que toutes les pièces jointes éventuelles du Factur-X.

• Le dernier cas, qui ne sera admis que jusqu’au 1er septembre 2027, est la conversion d’un Factur-X au
profil BASIC WL (sans lignes) vers un format structuré qui doit contenir des lignes. Dans ce cas, la
conversion doit en plus créer des lignes de factures reprenant les informations de ventilation de TVA,
de façon à satisfaire les contrôles de la Norme EN 16931.

4.8 Présentation du fichier annexe de description des formats de facture du socle minimal

La description des formats de facture du socle minimal est réalisée au travers d’un fichier Excel comportant
différentes feuilles :

Nom de la feuille Description

FE EN16931 + EXTENDED
Description sémantique de la facture pour les 2 profils (EN16931 et EXTENDED-CTC-FR), le profil EXTENDED-
CTC-FR intègre toutes les données dont l'ID commence par EXT. La cardinalité peut être augmentée dans le profil
EXTENDED-CTC-FR par rapport à EN16931
. Colonne C : cardinalité sémantique EN16931
. Colonne D : Cardinalité sémantique profil EN16931 France (CIUS)
. Colonne E : cardinalité sémantique EXTENDED-CTC-FR
AFNOR XP Z12-0122026-02

_Source: `c:\Users\g.baudrit\source\repos\gbaudrit\conf-aimer-votre-llm\demo\ctxc-sample-spec\with-ctxc\spec/afnor/XP_Z12-012/XP_Z12-012.pdf` (page:66/page:66)_

### E-f1108aeea2f1

XP Z12-012 – Formats et Profils des messages Factures et Statuts de cycle de vie, constitutifs du socle
minimal applicable à la Réforme Facture Électronique en France

65
Nom de la feuille Description

BR-France CTC
Règles de gestion spécifiques France, par catégories :
. BR-FR : règle de gestion sur une donnée
. BR-FR-CO : règle de gestion conditionnelle
. BR-FR-DEC : règle de nombre de décimales
. BR-FR-MAP : règle de mapping pour créer le flux 1 ou 10.1
. BR-FR-MV : règles de gestion pour les factures multi-vendeurs
. BR-FR-MVMAP : règles de mapping pour les factures multi-vendeurs

BR-France-CTC-CPRO BR-FR-CPRO : règles de gestion pour les factures B2G (Chorus Pro)

BR EN16931 + EXT FR et FX
Règles de gestion de la Norme EN16931, + Règle alternative pour le profil EXTENDED-CTC-FR (tolérance dans les
calculs en pied de 0,01 par ligne).
L'application des règles est ensuite indiquée aussi pour les profils additionnels Factur-x (BASIC, BASIC WL,
MINIMUM, EXTENDED). Des règles de gestion additionnelles sont aussi indiquées pour Factur-X EXTENDED :
. BR-FREXT-XXXX : règle pour le profil EXTENDED-CTC-FR
. BR-FXEXT- XXX : Règle profil EXTENDED Factur-x

Codelists for XML Fx - 15 11
25
Liste de codes applicables sur les profils EN16931 (éventuellement réduite du fait des règles de gestion France),
et le profil EXTENDED de Factur-X, applicable à compter du 15 novembre 2025

Flux 2 UBL EN16931 FR Description du format de Facture en UBL, pour le profil EN16931. Il s'agit de l'implémentation syntaxique de la
Norme EN16931, avec prise en compte des règles de gestion spécifiques France

Flux 2 UBL EXT-CTC-FR Description du format de Facture en UBL, pour le profil EXTENDED-CTC-FR. Il s'agit de l'implémentation
syntaxique du profil Sémantique EN16931, avec prise en compte des règles de gestion spécifiques France

CII D22B & FX EN16931 FR
Description du format de Facture en UN/CEFACT CII D22B, pour le profil EN16931 (et donc aussi Factur-X
EN16931). Il s'agit de l'implémentation syntaxique de la Norme EN16931, avec prise en compte des règles de
gestion spécifiques France

CII D22B & FX EXT-CTC-FR
Description du format de Facture en UN/CEFACT CII D22B, pour le profil EXTENDED-CTC-FR (et donc aussi
Factur-X EXTENDED-CTC-FR qui est un subset du profil EXTENDED de Factur-X). Il s'agit de l'implémentation
syntaxique du profil Sémantique EN16931, avec prise en compte des règles de gestion spécifiques France

FACTUR-X BASIC WL FR
Description du format des données Factur-X en UN/CEFACT CII D22B, pour le profil BASIC WL. Il s'agit de
l'implémentation syntaxique de la Norme EN16931, avec prise en compte des règles de gestion spécifiques
France

FE - Flux 1 Description sémantique du Flux 1, telle que publiée dans les spécifications externes de l'AIFE 3.0, annexe 1.

Flux 1 UBL Implémentation du Flux 1 en UBL Construit à partir du Flux 2 en UBL.

Flux 1 CII Implémentation du Flux 1 en UN/CEFACT construit à partir du Flux 2 an CII.

E-REPORTING - Flux 10 Description sémantique et syntaxique du Flux 10, telle que publiée dans les spécifications externes de l'AIFE,
avec correspondance des champs du 10.1 avec le flux 2.

Règles de gestion 3.1 Règles de gestion applicable pour les échanges entre Plateformes Agréées et le PPF (annexe 7 des spécifications
externes 3.1)

CDV FE - CDAR
Description sémantique et syntaxique du Flux 6 (CDV) en CDAR, d'une part pour son utilisation entre
Plateformes Agréées et le PPF (cf spécifications externes AIFE), d'autre part entre Plateformes Agréées entre
elles et avec leurs clients respectifs (objet de cette publication)

BR-FR-CDV pour factures Règles de gestion pour les CDV (CDAR) relatifs à des Factures (Flux 2, 3)
AFNOR XP Z12-0122026-02

_Source: `c:\Users\g.baudrit\source\repos\gbaudrit\conf-aimer-votre-llm\demo\ctxc-sample-spec\with-ctxc\spec/afnor/XP_Z12-012/XP_Z12-012.pdf` (page:67/page:67)_

### E-d339456a6fc1

XP Z12-012 – Formats et Profils des messages Factures et Statuts de cycle de vie, constitutifs du socle
minimal applicable à la Réforme Facture Électronique en France

66
Nom de la feuille Description

Acteurs CDV Cycle de vie : dans le cadre des échanges de Cycle de vie, quels sont les acteurs référencés dans le CDAR (pour
conserver une confidentialité des Plateformes Agréées entre utilisateurs finaux)

Codes Action Codes "Action attendue" utilisables dans les messages de statut de cycle de vie

Tableau des motifs de
STATUTS Motifs possibles pour chaque statut, en B2B, à utiliser et contrôler dans le CDAR (Codes Motifs)

Flux F11 - Annuaire Description du flux 11, données de l’Annuaire PPF transmissibles aux entreprises via les Plateformes Agrées.

4.8.1 Feuille « FE EN16931 + EXTENDED »

Cette feuille décrit le modèle sémantique des 2 profils/ En pratique c’est l’intégralité du profil EXTENDED-CTC-
FR qui est décrit, avec sa cardinalité (Colonne E). Mais en filtrant sur la colonne A des ID en excluant tous les
ID commençant par « EXT », on obtient la description du profil EN16931, avec la cardinalité en colonne D.

Pour une bonne compréhension, les colonnes sont organisées de la façon suivante :

• A : ID de chaque donnée ou groupe de données. 

• B : présence de la donnée en flux 1 ou 10.1.

• C, D, E : cardinalités de la Norme EN 16931, du profil EN 16931 (identiques sauf pour BT-29 et BT-46,
car la description du profil EN 16931 a artificiellement répliqué cette donnée pour en expliquer
l’utilisation pour renseigner SIRET, CODE_ROUTAGE et SIREN de l’Assujetti Unique (pour le
VENDEUR)), et du profil EXTENDED-CTC-FR (en E).

• F à J : le nom des données.

• K à M : les Xpath en UBL et CII (pour information, colonnes masquées).

• N : type logique des données

• O et P : longueur de champs telle qu’exigée pour le flux 1, et pour les flux 2, 8 et 9 c’est-à-dire la facture
objet du présent document.

• Q : liste de code à utiliser quand le champ doit trouver sa valeur dans une liste.

• R . indication d’implémentation.

• S et T : description et note d’usage du champ (repris de EN 16931).

• U : règle de gestion des flux 1 et 10.1 applicable.

• V à Z : Règles de gestion spécifiques France applicables aux factures dans les formats du socle
minimum (Flux 2, 8 et 9, par type de règle).

• AA : règles applicables pour le B2G en France

• AB et AC : règles de la Norme EN 16931 applicable et Règle du profil EXTENDED-CTC-FR.

• AD : commentaires éventuels.

• AF à AJ : indique les modifications à chaque version

• AL : Indique si la donnée est exigée au DEMARRAGE ou en CIBLE (flux 1 ou 10.1).

• AN à AP : indique la présence de la donnée dans chaque profil.

• AR à BB : règles de gestion applicables, fournies en texte.
AFNOR XP Z12-0122026-02

_Source: `c:\Users\g.baudrit\source\repos\gbaudrit\conf-aimer-votre-llm\demo\ctxc-sample-spec\with-ctxc\spec/afnor/XP_Z12-012/XP_Z12-012.pdf` (page:68/page:68)_

### E-8e52e31a9ff8

XP Z12-012 – Formats et Profils des messages Factures et Statuts de cycle de vie, constitutifs du socle
minimal applicable à la Réforme Facture Électronique en France

67
• BD à BJ : règle de gestion applicable sur flux 1 ou 10.1 (colonne U) en texte.

4.8.2 Feuille « BR-France CTC »

Cette feuille décrit les Règles de Gestion, en référençant celles qui s’applique sur le flux 1 dont elles peuvent
être issues, sur quelles données elles s’appliquent et sur quels types de factures ou bien en mapping pour flux
1 ou flux 10. Elle contient aussi des règles de gestion additionnelles et de mapping flux 1 pour les factures
multi-vendeurs.

Les colonnes sont organisées de la façon suivante :

• Colonne A : Nom de la règle

• Colonne B : Code de la règle Flux 1 ou Flux 10 correspondante (si existe)

• Colonne C : Titre de la règle

• Colonne D : Description de la règle

• Colonne E : Champs concernés par la règle

• Colonnes F à N . comment s‘applique la règle, sur quels types de factures 

✓ Flux 2 : e-invoicing

✓ Flux 8 sortant : Ventes B2B internationales

✓ Flux 8 entrants : acquisitions B2B internationales, sur lesquelles les règles spécifiques France ne
s’appliquent pas en général (car on ne peut pas imposer des règles aux factures émises par des
sociétés non françaises)

✓ Flux 9 : Ventes B2C

✓ Map Flux 1 ou Map flux 10 : règle de mapping pour construire le Flux 1 ou le Flux 10 à partir de la
facture.

✓ Règle métier : si la règle exige des données autre que celles de la facture (par exemple de vérifier
la présence du SIREN dans l’annuaire)/

✓ Règle non vérifiable : règle donnée pour rappel, mais non vérifiable par un traitement schematron
ou même métier.

✓ Règle présente dans le schematron

• Colonnes P-W : suivi des modifications par version

4.8.3 Feuille « BR-France-CTC-CPRO »

Cette feuille présente les règles spécifiques additionnelles applicables aux factures B2G, à destination du
secteur public et de la plateforme CHORUSPRO.

L’organisation des colonnes est la même que pour la feuille « BR-France CTC ».

4.8.4 Feuille « BR EN 16931 + EXT FR et FX »

Cette feuille présente les règles de la Norme EN 16931, et les règles des profils EXTENDED-CTC-FR et
EXTENDED de Factur-x qui remplacent certaines des règles de la Norme sur ces profils.

Pour chaque règle, il est précisé sur quel(s) profil(s) elle s’applique (y compris les profils de Factur-x
MINIMUM, BASIC WL, BASIC et EXTENDED).

Les Factures doivent donc d’abord être conformes à ces ensembles de règles, puis en complément, aux règles
spécifiques France présentées au chapitre précédent.
AFNOR XP Z12-0122026-02

_Source: `c:\Users\g.baudrit\source\repos\gbaudrit\conf-aimer-votre-llm\demo\ctxc-sample-spec\with-ctxc\spec/afnor/XP_Z12-012/XP_Z12-012.pdf` (page:69/page:69)_

### E-99ab7690fe37

XP Z12-012 – Formats et Profils des messages Factures et Statuts de cycle de vie, constitutifs du socle
minimal applicable à la Réforme Facture Électronique en France

68
La feuille s’organise de la façon suivante : avec 2 tables

• Tableau des règles TVA, par catégorie de TVA

✓ Colonne B : indicateur de correction par version

✓ Colonne C : Nom des règles

✓ Colonnes D et E description des règles en français et en anglais

✓ Colonnes G à L : Applicabilité par profil

✓ Colonnes N et O : applicables sur flux 1, profils Base et Full

✓ Ensuite par blocs de lignes, correspondant à chaque catégorie de TVA

➢ Lignes 5 à 19 : pour Catégorie TVA « S ¬, avec en gris (ligne 16 et 17), les règles qui s’appliquent au
profil EXTENDED-CTC-FR au lieu des règles BR-S-8 et BR-S-9 pour apporter une tolérance dans les
calculs de sommes, et en vert, les règles qui s’appliquent au profil EXTENDED de Factur-x (les mêmes
règles mais prenant en compte une donnée en plus dans les sommes : montant des frais de service
logistiques).

➢ Lignes 20 à 32 : idem pour catégorie « Z », taux à Zéro

➢ Lignes 33 à 45 : idem pour catégorie « E », Exempté

➢ Lignes 46 à 58 : idem pour catégorie « AE », autoliquidation

➢ Lignes 59 à 73 : idem pour catégorie « K », livraisons intracommunautaires

➢ Lignes 74 à 86 : idem pour catégorie « G », Exports

➢ Lignes 87 à 103 : idem pour catégorie « O », Hors scope

➢ Lignes 104 à 129 : idem pour catégorie « L » (IGIC) et « M » (IPSI), non applicable en France

• Tableau des autres règles :

✓ Colonne Q : Nom des règles

✓ Colonnes R et U : description en français et en anglais

✓ Colonnes S et V : contexte en français et en anglais

✓ Colonnes T et W : sur quels champs

✓ Colonnes Y à AD : application par profil

✓ Colonnes AF et AG : application sur Flux 1, profils Base et Full

✓ Colonne AI et au-delà : modifications de cette table par version

✓ Les règles sont ensuite par catégories :

➢ Règles BR : règles de gestion applicable sur un champ

➢ Règles BR-CO : règles conditionnelles transverses

➢ Règles BR-DEC : règles sur le nombre de décimales

➢ Règles BR-CL : règles relatives aux valeurs de code à choisir dans une liste

➢ Règles BR-B : règles de « split payment ¬ non applicables en France (pour l’Italie)

➢ Règles-FXEXT . Règles d’extension Factur-X sur des données d’extension du profil EXTENDED

➢ Les règles BR-CO-10, 11, 12, 13 et 15 sont remplacées par des règles BR-FREXT-CO-10, 11, 12, 13 et 15
pour le profil EXTENDED-CTC-FR et BR-FXEXT-CO-10, 11, 12, 13 et 15 pour le profil EXTENDED de
Factur-X (tolérance de calculs de sommes).
AFNOR XP Z12-0122026-02

_Source: `c:\Users\g.baudrit\source\repos\gbaudrit\conf-aimer-votre-llm\demo\ctxc-sample-spec\with-ctxc\spec/afnor/XP_Z12-012/XP_Z12-012.pdf` (page:70/page:70)_

### E-395daf1dd30f

XP Z12-012 – Formats et Profils des messages Factures et Statuts de cycle de vie, constitutifs du socle
minimal applicable à la Réforme Facture Électronique en France

69
4.8.5 Feuille « Codelists for XML Fx - 15 11 25 »

Cette feuille donne les différentes listes de codes applicables à compter du 15 novembre 2025, y compris celles
qui s’appliquent sur certains champs d’extension essentiellement sur données du profil Factur-X EXTENDED
en UN/CEFACT CII.

Les listes sont organisées par groupes de colonnes, avec en titre les champs sur lesquels elles s’appliquent et
le lien avec la liste correspondante.

En particulier, les codes VATEX (raisons d’exemption de TVA) sont en colonnes AX à BA, avec tous les codes
dédiés à la réglementation française en bas de liste.

Attention, lorsque les codes s’appliquent à des extensions, c’est la codification des champs du profil
EXTENDED en CII de Factur-X qui est utilisée, car préexistante (cf Feuille CII D22B & FX EXT-CTC-FR) et parce
que ces champs ne sont pas intégrés dans le profil EXTENDED-CTC-FR.

4.8.6 Feuille « Flux 2 UBL EN 16931 FR » et « Flux 2 UBL EXT-CTC-FR »

Ces feuilles décrivent respectivement les deux profils EN 16931 et EXTENDED-CTC-FR en UBL, c’est-à-dire en
décrivant la structure de l’UBL restreinte aux champs nécessaires pour implémenter les deux profils, dans
l’ordre du message (puisque les données doivent être présentées suivant un arbre strictement défini, y
compris dans l’ordre des données d’un même niveau)/

Ces feuilles décrivent le message Facture : INVOICE (colonnes B à AT), puis le message AVOIR : CREDIT NOTE
(Colonnes (AV à CN)/ Certaines lignes sont en orange de part et d‘autres pour recaler les structures INVOICE
et CREDIT NOTE qui sont très proches, mais pas identiques.

Les colonnes s’organisent de la façon suivante pour le message INVOICE (et de façon équivalente ensuite pour
le message CREDIT NOTE) :

• Colonne B . ID des données de l’implémentation du profil en UBL (avec quelques ID de structure liés à
l’implémentation UBL)/

• Colonne C : ID de la donnée, dans le modèle sémantique français (cf feuille « FE EN 16931 +
EXTENDED »).

• Colonne F . niveau d’arborescence en UBL (différent de celui de la Norme EN 16931, car l’arborescence
de l’UBL n’est pas la même que celle de la norme EN 16931)/ C’est ce qui permet de matérialiser l’arbre
de données de l’UBL, avec la cardinalité en colonne G/

• Colonne G : cardinalité de la donnée pour le profil (correspondant au profil de chaque feuille), ce qui
inclut implicitement une règle de gestion quand elle est différente de la cardinalité du message UBL
complet présente en colonne AR. Par exemple si la cardinalité UBL est 0..n (colonne AR) et que celle
de la colonne G est 1//1, cela signifie que la donnée n’est plus optionnelle et répétable, mais obligatoire
et présente une fois seulement/ Ceci peut soit s’implémenter est créant un xsd dédié, soit au travers
d’une règle de gestion décrite dans un schematron (qui dira que la donnée DOIT être présente une fois
et une seule).

• Colonne H : Nom de la donnée reprise du modèle sémantique de la feuille « FE EN 16931 +
EXTENDED ».

• Colonne I : Xpath UBL.

• Colonnes J à AB : reprennent les informations des colonnes M à AC de la description sémantique
(feuille « FE EN 16931 + EXTENDED ».

• Colonnes AD et AE : appartenance de la ligne au Flux 1 (permet ensuite un filtrage), profils Base et Full.

• Colonnes AG à AT : description du mapping UBL :

✓ Colonne AG : nom du terme du champ de la Norme.

✓ Colonne AH : description de la donnée (Norme EN 16931).
AFNOR XP Z12-0122026-02

_Source: `c:\Users\g.baudrit\source\repos\gbaudrit\conf-aimer-votre-llm\demo\ctxc-sample-spec\with-ctxc\spec/afnor/XP_Z12-012/XP_Z12-012.pdf` (page:71/page:71)_

### E-b637becf57d2

XP Z12-012 – Formats et Profils des messages Factures et Statuts de cycle de vie, constitutifs du socle
minimal applicable à la Réforme Facture Électronique en France

70
✓ Colonne AI . Note d’usage de la donnée (Norme EN 16931).

✓ Colonne AJ : règles de CIUS ChorusPro (pour rappel, et info).

✓ Colonne AK : règles de la Norme EN 16931 applicable, ainsi que quelques règles PEPPOLBIS 3.0,
pour info.

✓ Colonne AL : type de la donnée.

✓ Colonne AM : cardinalité du modèle UBL du profil EN16931 (source de la colonne G pour le profil
EN 16931).

✓ Colonne AN : cardinalité du modèle UBL du profil EXTENDED-CTC-FR (source de la colonne G
pour le profil EXTENDED-CTC-FR).

✓ Colonne AO et AP = Xpath, en présentation déployée ou en ligne.

✓ Colonne AR . Cardinalité du message UBL complet (indique le cas échéant le potentiel d’évolution
pour le profil).

✓ Colonnes AS et AT : informations de mapping de la Norme.

En UBL, il y a un message pour les factures (INVOICE) et un autre pour les avoirs (CREDIT NOTE). La
description se poursuit donc sur les autres colonnes de la même façon pour le message CREDIT NOTE.

Les colonnes CR et suivantes indique les modifications faites par les différentes versions.

Cette description pourrait conduire à la création d’un xsd dédié à chaque profil, restreignant l’arbre de
données au strict nécessaire/ En pratique, la restriction se fait au travers du schematron d’application de la
Norme EN 16931 pour ce profil/ Ceci implique l’ajout d’un grand nombre de règles qui viennent s’ajouter au
schématron, nommées « UBL-CR-XXX »

Les schematrons correspondants pour le profil EN 16931 se trouvent sur CE LIEN. La lecture du fichier « EN
16931-UBL-validation-preprocessed.sch ¬ permet de voir l’ensemble de ces règles syntaxiques, qui d’ailleurs,
pour la plupart, consistent à désactiver certaines branches ou feuilles de l’arbre de données UBL INVOICE,
n’empêchent pas la facture de pouvoir être considérée comme valide, lorsque ces règles sont en « warning »
et non en « fatal ».

4.8.7 Feuilles « FACTUR-X BASIC WL FR », « CII D22B & FX EN 16931 FR » et « CII D22B & FX EXT-
CTC-FR)

Ces feuilles décrivent respectivement les trois profils BASIC WL (uniquement pour Factur-X), EN 16931 et
EXTENDED-CTC-FR en UN/CEFACT CII, que ce soit en fichier de facture structuré ou comme composante du
Factur-X (fichier attaché factur-x.xml). Ceci décrit la structure du message UN/CEFACT CII restreint aux
champs nécessaires pour implémenter les trois profils, dans l’ordre du message (puisque les données doivent
être présentées suivant un arbre strictement défini, y compris dans l’ordre des données d’un même niveau)/

Ces feuilles décrivent le message Facture : CII (signifiant Cross Industry Invoice), sachant qu’en UN/CEFACT
CII les AVOIRS et tous types de factures se codifient suivant ce message CII (pas de message CREDIT NOTE
dédié comme en UBL).

La structure du message est commune à l’ensemble des messages supply chain du modèle UN/CEFACT SCRDM
(Supply Chain Reference Data Model) dont le CII est un des messages (avec le CIO pour le message ORDER par
exemple).
AFNOR XP Z12-0122026-02

_Source: `c:\Users\g.baudrit\source\repos\gbaudrit\conf-aimer-votre-llm\demo\ctxc-sample-spec\with-ctxc\spec/afnor/XP_Z12-012/XP_Z12-012.pdf` (page:72/page:72)_

### E-9521d6e6daf1

XP Z12-012 – Formats et Profils des messages Factures et Statuts de cycle de vie, constitutifs du socle
minimal applicable à la Réforme Facture Électronique en France

71
Il s’organise de la façon suivante (version réduite, puis plus déployée) : 
AFNOR XP Z12-0122026-02

_Source: `c:\Users\g.baudrit\source\repos\gbaudrit\conf-aimer-votre-llm\demo\ctxc-sample-spec\with-ctxc\spec/afnor/XP_Z12-012/XP_Z12-012.pdf` (page:73/page:73)_

### E-7a037009b011

XP Z12-012 – Formats et Profils des messages Factures et Statuts de cycle de vie, constitutifs du socle
minimal applicable à la Réforme Facture Électronique en France

72 
AFNOR XP Z12-0122026-02

_Source: `c:\Users\g.baudrit\source\repos\gbaudrit\conf-aimer-votre-llm\demo\ctxc-sample-spec\with-ctxc\spec/afnor/XP_Z12-012/XP_Z12-012.pdf` (page:74/page:74)_

### E-ec55fc4a17ff

XP Z12-012 – Formats et Profils des messages Factures et Statuts de cycle de vie, constitutifs du socle
minimal applicable à la Réforme Facture Électronique en France

73
Ce qui donne la structure suivante, plus arborescente que la Norme EN 16931 et l’UBL :

• rsm:ExchangedDocumentContext : Bloc d’identification (Contexte) du message, qui contient les
informations définissant le processus sous-jacent (BT-23), puis le profil du message (BT-24), par
exemple urn:cen.eu:en 16931:2017 pour le profil EN 16931

• rsm:ExchangedDocument : Bloc d’entête du message, qui contient des informations sur le message
lui-même avec le Numéro de facture (BT-1), puis son codetype (BT-3), puis sa date d’émission (BT-2),
puis les notes (BG-1).

• rsm:SupplyChainTradeTransaction : Bloc des informations de la transaction commerciale, corps de
la facture, lui-même composée de :

✓ ram:IncludedSupplyChainTradeLineItem : Bloc des lignes, qui donne toutes les informations
de lignes, elles-mêmes regroupées par sous-groupes structurés comme le corps du message.

✓ ram:ApplicableHeaderTradeAgreement : Bloc d’identification des Parties et des références à
la transaction, qui contient toutes les références et les Parties de l’échange, sauf celles relatives à
la facturation elle-même et au paiement.

✓ ram:ApplicableHeaderTradeDelivery : Bloc d’identification des informations de livraison

✓ ram:ApplicableHeaderTradeSettlement : Bloc d’information des termes de l’accord, c’est-à-
dire les acteurs de la facturation et du paiement (Facturant, Facturé à / Adressé à, Bénéficiaire,
Payeur), ainsi que les Remises et charges de niveau Document, le pied de TVA, les données de
paiement et les totaux.

Le fichier Excel présente le message en décrivant l’arbre en partant du haut et en descendant, branches par
branches, feuilles par feuilles. Les colonnes de la présentation Excel s’organisent de la façon suivante pour le
message UN/CEFACT CII :

• Colonne B : Codes de blocs CII, qui permettent de montrer la structure générale du message (cf -ci-
dessus), des codes couleurs permettent d’illustrer la structure du message

• Colonne C . ID des données de l’implémentation du profil en UN/CEFACT CII/ On retrouve les ID de la
Norme sémantique, avec quelques ajouts suffixés pour identifier les éléments de structure
complémentaires/ Pour les données d’extension, c’est la nomenclature du profil EXTENDED de Factur-
X qui est utilisée (car préexistante).

• Colonne D : ID de la donnée, dans le modèle sémantique français, avec la nomenclature des données
d’extension correspondante (cf feuille « FE EN 16931 + EXTENDED »).

• Colonne E . niveau d’arborescence en UN/CEFACT CII (différent de celui de la Norme EN 16931, car
l’arborescence du CII n’est pas la même que celle de la norme EN 16931)/ C’est ce qui permet de
matérialiser l’arbre de données UN/CEFACT CII, avec la cardinalité en colonne F, G et AS/

• Colonne F et G : cardinalités de la donnée pour les profils BASIC WL et EN 16931 (colonne F) et
EXTENDED-CTC-FR et EXTENDED de Factur-X (Colonne G), ce qui inclut implicitement une règle de
gestion quand elle est différente de la cardinalité du message UN/CEFACT CII complet présente en
colonne AS. Par exemple si la cardinalité UN/CEFACT CII est 0..n (colonne AS) et que celle de la colonne
G est 1..1, cela signifie que la donnée n’est plus optionnelle et répétable, mais obligatoire et présente
une fois seulement/ Ceci peut soit s’implémenter est créant un xsd dédié, soit au travers d’une règle de
gestion décrite dans un schematron (qui dira que la donnée DOIT être présente une fois et une seule).

• Colonne H : Nom de la donnée reprise du modèle sémantique de la feuille « FE EN 16931 +
EXTENDED ».

• Colonne I : Xpath UN/CEFACT CII.

• Colonnes J à AB : reprennent les informations des colonnes M à AC de la description sémantique
(feuille « FE EN 16931 + EXTENDED ».

• Colonnes AD et AE : appartenance de la ligne au Flux 1 (permet ensuite un filtrage), profils Base et Full.
AFNOR XP Z12-0122026-02

_Source: `c:\Users\g.baudrit\source\repos\gbaudrit\conf-aimer-votre-llm\demo\ctxc-sample-spec\with-ctxc\spec/afnor/XP_Z12-012/XP_Z12-012.pdf` (page:75/page:75)_

### E-4626c71d0bef

XP Z12-012 – Formats et Profils des messages Factures et Statuts de cycle de vie, constitutifs du socle
minimal applicable à la Réforme Facture Électronique en France

74
• Colonnes AG à AU : description du mapping UN/CEFACT CII :

✓ Colonne AG : nom du terme du champ de la Norme.

✓ Colonne AH : description de la donnée (Norme EN 16931).

✓ Colonne AI . Note d’usage de la donnée (Norme EN 16931).

✓ Colonne AJ : règles de CIUS ChorusPro (pour rappel, et info).

✓ Colonne AK : règles de la Norme EN16931 applicable, ainsi que quelques règles PEPPOLBIS 3.0,
pour info.

✓ Colonne AL : type de la donnée.

✓ Colonne AM : cardinalité du modèle UN/CEFACT CII des profils BASIC WL (Factur-X) et EN 16931,
source de la colonne F pour ces profils.

✓ Colonne AN : cardinalité du modèle UN/CEFACT CII des profils EXTENDED-CTC-FR et EXTENDED
(Factur-X), source de la colonne G pour le profil EXTENDED-CTC-FR.

✓ Colonne AO et AP = Xpath, en présentation déployée ou en ligne.

✓ Colonne AS : Cardinalité du message UN/CEFACT CII complet (indique le cas échéant le potentiel
d’évolution pour le profil).

✓ Colonnes AT et AU : informations de mapping de la Norme.

• Colonnes AX à BC . indique quelles lignes de description appartient à quel profil, ce qui permet d’avoir
une vision de chaque profil par simple filtrage.

• Colonnes BE et BF : donne le profil de Factur-x, qui est organisé en poupées gigognes : MINIMUM, puis
BASIC WL, puis BASIC, puis EN 16931, puis EXTENDED. La colonne BF donne un détail plus fin du
profil EXTENDED en intercalant le profil EXTENDED-CTC-FR.

• Colonnes BL à CP : exactement les mêmes que les colonnes AG à BF, mais en anglais.

• Colonnes CR et suivantes : indique(nt) les modifications faites par les différentes versions.

Cette description peut conduire à la création d’un xsd dédié à chaque profil, restreignant l’arbre de données
au strict nécessaire/ C’est ce qui est fait pour chaque profil de Factur-X (voir cette page pour disposer de la
dernière version de la documentation et des description xsd et schematrons associés).

Pour la mise en œuvre du profil de la Norme EN 16931 seule, les outils proposés par la Commission
Européenne s’appuie sur le message UN/CEFACT CII D16B complet, sur lequel s’applique un schematron
d’application/ Ceci implique l’ajout d’un grand nombre de règles qui viennent s’ajouter au schematron,
nommées « CII-SR-XXX » ou « CII-DT-XXX ».

Les schematrons correspondants pour le profil EN 16931 se trouvent sur CE LIEN. La lecture du fichier « EN
16931-CII-validation-preprocessed.sch¬ permet de voir l’ensemble de ces règles syntaxiques, qui d’ailleurs,
pour la plupart, consistent à désactiver certaines branches ou feuilles de l’arbre de données UN/CEFACT CII,
n’empêchent pas la facture de pouvoir être considérée comme valide, lorsque ces règles sont en « warning »
et non en « fatal ».

Dans cette description, les lignes en rose correspondent à des données du profil EXTENDED-CTC-FR (et donc
aussi EXTENDED de Factur-X). Les lignes en gris plus ou moins foncé matérialisent le niveau de la structure
UN/CEFACT CII (plus la couleur est foncée, plus le niveau est proche de la racine).

4.8.8 Feuilles « FE - Flux 1 », « Flux 1 UBL » et « Flux 1 CII »

Ces feuilles décrivent le flux 1 de 3 façons :

• Feuille « FE - Flux 1 » : la description du Flux 1 en modèle sémantique, telle que publiée dans la version
3.1 des spécifications externes. En colonnes W à AC les règles de gestion applicables des spécifications
externes 3.1 sont fournies en texte sur chaque ligne.
AFNOR XP Z12-0122026-02

_Source: `c:\Users\g.baudrit\source\repos\gbaudrit\conf-aimer-votre-llm\demo\ctxc-sample-spec\with-ctxc\spec/afnor/XP_Z12-012/XP_Z12-012.pdf` (page:76/page:76)_

### E-3b25b0b234da

XP Z12-012 – Formats et Profils des messages Factures et Statuts de cycle de vie, constitutifs du socle
minimal applicable à la Réforme Facture Électronique en France

75
• Feuille « Flux 1 UBL » : la description du Flux 1 en UBL faite à partir du filtrage de la feuille « CII D22B
& FX EXT-CTC-FR » sur les données Flux 1 CIBLE (colonne AE), à laquelle les charges de niveau
Document ont été ajoutés (car ils le seront).

• Feuille « Flux 1 CII » : la description du Flux 1 en UN/CEFACT faite à partir du filtrage de la feuille
« Flux 2 UBL EXT-CTC-FR » sur les données Flux 1 CIBLE (colonne AF), à laquelle les charges de niveau
Document ont été ajoutés (car ils le seront).

4.8.9 Feuille « E-REPORTING - Flux 10 »

Il s’agit de la feuille de description du flux 10 publiée dans les spécifications externes 3/1, complétée de la
correspondance avec les données du modèle sémantique pour le flux 10.1, fournie en colonne S.

Cette version a été enrichie du bloc TG-2 (TT-5 et TT-6), disponible uniquement pour les échanges entre les
assujettis et leur Plateforme Agréée, et autorisant la transmission des flux 10 complémentaires ou correctifs,
permettant à la Plateforme Agréée de constituer un flux 10 agrégés tel que le Concentrateur des Données du
PPF l’attend/

4.8.10 Feuille « Flux F11 – Annuaire »

Il s’agit d‘une feuille de description d’un message XML visant à ce qu’une Plateforme Agréée puisse transmettre
les données diffusibles de l’Annuaire PPF à ses clients assujettis et concernés par la Réforme Facture
Électronique en France/ Ceci peut aussi être réalisé de façon plus ciblée au travers de l’utilisation de l’API
Annuaire décrite dans la norme XP Z12-013.

4.8.11 Feuille « Règles de gestion 3.1 »

Rappel des règles de gestion (Annexe 7), publiées dans les spécifications externes 3.1.

5 Le message de Cycle de Vie – CDAR

Le message de cycle de vie est implémenté en UN/CEFACT CDAR (Cross Domain Application and Response).
Il permet transmettre des informations sur un ou plusieurs messages reçus, à la fois pour renseigner sur la
bonne transmission mais aussi sur le bon traitement ou pas. Dans les échanges entre les Plateformes Agréées
et le PPF, il est utilisé pour tous les types de flux ou d’objet métier échangés/

Le présent Document décrit son utilisation uniquement pour échanger des informations du cycle de vie sur le
message facture entre Plateformes Agréées et avec les utilisateurs finaux. Cette utilisation peut différer de
celle exigée par le PPF, y compris pour les messages de statuts obligatoires (essentiellement sur la gestion de
l’entête du message)/

5.1 Description de la structure du message CDAR à utiliser

Le message CDAR D22B est disponible dans son intégralité 

• sur le lien  
https://unece.org/trade/documents/2024/12/standards/cross-domain-acknowledgement-and-
response-d22b 
pour sa description xsd

• et sur le lien 
https://unece.org/trade/documents/2020/06/standards/cross-domain-application-error-and-
acknowledgement-process-brs
pour avoir le document de description en anglais de l’utilisation de ce message.

La gestion du cycle de vie entre VENDEUR et ACHETEUR est décomposée en 2 phases :

• La phase de transmission qui vise à suivre le cheminement de la facture de son émission à sa réception
par le destinataire. Dans cette phase les statuts sont créés par les Plateformes Agréées à destination
de leur client et de la Plateforme Agréée de leur contrepartie (et pour les statuts dit « Obligatoires »,
ils sont aussi transmis au PPF).
AFNOR XP Z12-0122026-02

_Source: `c:\Users\g.baudrit\source\repos\gbaudrit\conf-aimer-votre-llm\demo\ctxc-sample-spec\with-ctxc\spec/afnor/XP_Z12-012/XP_Z12-012.pdf` (page:77/page:77)_

### E-dd1a8bf042fc

XP Z12-012 – Formats et Profils des messages Factures et Statuts de cycle de vie, constitutifs du socle
minimal applicable à la Réforme Facture Électronique en France

76
• La phase de Traitement, qui vise à ce que le VENDEUR et l’ACHETEUR s’échangent des statuts sur le
cycle de vie des factures/ Ces statuts sont alors créés par le VENDEUR ou l’ACHETEUR et ont vocation
à être acheminés à la contrepartie au travers des Plateformes Agréées, sans être modifié (comme les
factures).

Il n’est pas prévu ou exigé de faire des messages de statuts sur la bonne réception des messages de statuts/

Il sera cependant nécessaire de qualifier si le message de statut relève de la phase de transmission ou de
traitement, notamment car ceci aura un impact sur la création de l’entête du message/

En effet, d’une façon générale, l’identité des Plateformes Agréées utilisées par une entreprise n’a pas à être
révélée aux tiers. Ainsi, les Plateformes Agréées n’ont pas à être identifiées dans les messages de cycle de vie
qui ont vocation à être partagés de bout en bout.

Le schéma ci-dessous illustre le cycle de vie et les différents types de statuts : 

Les messages de statuts de cycles de vie ont vocation à être utilisés pour trois fonction distinctes :

• Informer sur le statut de transmission et de traitement, en indiquant le cas échéant des erreurs
constatées et des actions attendues.

• Agir sur le processus ou cas d’usage en indiquant des changements de situation, par exemple
l’affacturage d’une facture, la nécessité de payer sur un autre compte bancaire que celui indiqué dans
la facture, le cas échéant fournir une information complémentaire oubliée ou exigée, nécessaire au
traitement0

• Communiquer des informations relatives au paiement ou à l’encaissement, à l’exécution d’un
escompte, une approbation partielle, bref à indiquer différents montants pour des situations diverses.

Pour ce faire, le message de cycle de vie est illustré par le schéma ci-dessous, qui illustre la structure utile du
message dans son entête (certaines données du message complet non utilisées ont été exclues pour en
simplifier la lecture). Les traits forts indiquent une cardinalité obligatoire (1..1 minimum), et en cas de
répétabilité, une cardinalité 0//∞ ou 1//∞/ est indiquée/
AFNOR XP Z12-0122026-02

_Source: `c:\Users\g.baudrit\source\repos\gbaudrit\conf-aimer-votre-llm\demo\ctxc-sample-spec\with-ctxc\spec/afnor/XP_Z12-012/XP_Z12-012.pdf` (page:78/page:78)_

### E-0db31b190b60

XP Z12-012 – Formats et Profils des messages Factures et Statuts de cycle de vie, constitutifs du socle
minimal applicable à la Réforme Facture Électronique en France

77 
Sa structure se présente donc de la façon suivante :

• Un bloc d’entête « Exhange Document Context », qui contient le profil du message CDAR.

• Un bloc d’entête « Exchange Document », identifiant essentiellement les Parties : qui crée, qui
transmet, pour qui est-ce destiné ?

• Un bloc « Aknowledgement », obligatoire et répétable (cardinalité 0//n), mais qui ne sera utilisé qu’une
fois seulement par message CDAR.  
Ce bloc contient lui-même un bloc « Document » (ci-dessous), obligatoire et répétable, permettant de
faire un message CDAR commun à plusieurs Documents, ce qui ne sera pas mis en œuvre en général.
Ce bloc « Aknowledgement », contient donc (cf description ci-dessous pour voir la suite de la structure
en schéma :

✓ Un bloc « Document », qui correspond à la facture objet du message de cycle de vie, qui contient
lui-même :

➢ Un bloc de « détail de statut », optionnel et répétable (cardinalité 0..n), permettant d’expliquer des
erreurs constatées, ou de fournir des informations complémentaires, et qui contient pour ce faire :

▪ Un bloc « Characteristic », optionnel et répétable (cardinalité 0..n), dédié à renseigner des
données à modifier ou en erreur, à e-reporter, à qualifier certains statuts (montant approuvé ou
payé par exemple).

On retrouve ainsi la structure habituelle des messages UN/CEFACT, à savoir (les codes sont ceux de la
description de l’annexe Cycle de Vie des spécifications externes 3/0) :

• Un bloc de contexte (MDB-1), qui permet d’identifier un profil de message auquel se rattachera un xsd
et un schematron pour les règles de gestion spécifiques éventuelles (l’équivalent des BT-23 et BT-24
pour les factures).

• Un bloc d’entête de message (MDB-2) composé de :

✓ MDT-4 (ID) : un Identifiant de message (numéro du message de cycle de vie).
AFNOR XP Z12-0122026-02

_Source: `c:\Users\g.baudrit\source\repos\gbaudrit\conf-aimer-votre-llm\demo\ctxc-sample-spec\with-ctxc\spec/afnor/XP_Z12-012/XP_Z12-012.pdf` (page:79/page:79)_

### E-f00650cb96d8

XP Z12-012 – Formats et Profils des messages Factures et Statuts de cycle de vie, constitutifs du socle
minimal applicable à la Réforme Facture Électronique en France

78
✓ MDT-5 (Name) : un nom de message.

✓ MDG-4 (IssueDateTime) : une date et heure de création du message de cycle de vie.

✓ MDT-9 (LanguageID) : une langue du message (français ou anglais).

✓ MDG-9 (SenderTradeParty) : une Partie en charge de la transmission du message (« Sender ») :
dans notre contexte : 

➢ Pour la phase de transmission, il s’agit des Plateformes Agréées, qui ne seront qualifiés que par le code
rôle (« WK ») en MDT-21.

➢ Pour la phase de traitement, il s’agira des utilisateurs (ACHETEUR ou VENDEUR, ou certains tiers)/

✓ MDG-16 (IssuerTradeParty) : une Partie à l’origine du message (donc à sa création : « Issuer ») :
dans notre contexte : 

➢ Pour la phase de transmission, il s’agit des Plateformes Agréées, qui ne seront qualifiés que par le code
rôle (« WK »), en MDT-40.

➢ Pour la phase de traitement, il s’agira des utilisateurs (ACHETEUR ou VENDEUR, ou certains tiers).

✓ MDG-23 (Recipient) : une ou plusieurs Partie(s) destinataires du message de statut
(« Recipient ») : ce sont les utilisateurs finaux.

• Un bloc « Acknowledgement » (MDB-03), qui peut être multiple en CDAR D22B, mais qui sera utilisé
en cardinalité 1..1, composé des éléments suivants :

✓ MDT-74 (MultipleReferencesIndicator) : un indicateur permettant de dire si le bloc est pour
plusieurs Documents ou un seul. Par défaut, les messages de statuts seront pour un seul document.
Il pourra y avoir des exceptions pour certains cas d’usage nécessitant d’avoir un statut pour 2
factures ou plus, liées, de façon exceptionnelle.

✓ MDT-75 (ID) : un Numéro, si nécessaire.

✓ MDT-77 (TypeCode) : un code type, qui va permettre de distinguer un statut de la phase
transmission (305) d’un statut de la phase traitement (23).

✓ MDT-75 (Name) : un nom.

✓ MDG-31 (IssueDateTime) : une date et heure de création de l’évènement objet du statut/

✓ MDG-32 (ReferenceReferencedDocument) : le document objet du statut : ici la facture. 
AFNOR XP Z12-0122026-02

_Source: `c:\Users\g.baudrit\source\repos\gbaudrit\conf-aimer-votre-llm\demo\ctxc-sample-spec\with-ctxc\spec/afnor/XP_Z12-012/XP_Z12-012.pdf` (page:80/page:80)_

### E-5c8fdb16a527

XP Z12-012 – Formats et Profils des messages Factures et Statuts de cycle de vie, constitutifs du socle
minimal applicable à la Réforme Facture Électronique en France

79
Ensuite, le bloc Document (MDG-32) est composé des éléments suivants :

• MDT-87 : le numéro de facture.

• MDT-88 (StatusCode). un code statut standard, c’est-à-dire venant d’une liste standard UNTDID 1373,
les valeurs sont détaillées dans l’Excel et dans les règles de gestion/ C’est un statut facultatif, mais à
utiliser notamment pour les factures internationales, et en cohérence avec le code statut spécifique de
la réforme (en MDT-105).

• MDT-91 (Typecode). code type de la facture (380, 381, 0)/

• MDT-94 : nom de la facture (s’il existe)/

• MDG-34 . date et heure de réception de la facture/ Pour les statuts de transmission, c’est la date et
heure à laquelle la Plateforme Agréée créateur du message a enregistré la facture (en émission ou en
réception respectivement). Pour les statuts de traitement, c’est la date et heure à laquelle la facture a
été reçue pour le destinataire ou a fait l’objet d’un statut « Déposée ¬ pour l’émetteur/ 

• MDT-96 : pièce jointe, utile quand il faut compléter une facture avec un document additionnel, et dans
certains cas d’usage, ceci permet de joindre aussi des factures (par exemple une demande de paiement
direct dans un cas de sous-traitance avec paiement direct).

• MDT-97 (ReferenceTypeCode) : Code type qualifiant de référence, à choisir dans la liste UNTDID 1153
(a priori sans utilité)

• MDG-35 (FormattedIssueDateTime) . date de la facture (permet d’identifier la facture de façon
unique)

• MDT-104 (Status) : libellé du statut fournit en code en MDT-88.

• MDT-105 (ProcessConditionCode) : code statut tel que défini par la réforme (200 à 213 pour les
factures pour l’instant)/

• MDT-106 (ProcessCondition) : statut en texte correspondant au code en MDT-105.
AFNOR XP Z12-0122026-02

_Source: `c:\Users\g.baudrit\source\repos\gbaudrit\conf-aimer-votre-llm\demo\ctxc-sample-spec\with-ctxc\spec/afnor/XP_Z12-012/XP_Z12-012.pdf` (page:81/page:81)_

### E-b0e028cf7c99

XP Z12-012 – Formats et Profils des messages Factures et Statuts de cycle de vie, constitutifs du socle
minimal applicable à la Réforme Facture Électronique en France

80 
• MDG-40 (IssuerTradeParty) : identifie TOUJOURS le VENDEUR, ce qui permet d’identifier la facture
de façon unique (numéro, date et n° de SIREN du Vendeur)

• MDG-41 (RecipientTradeParty) : par convention, permet de nommer un nouveau Bénéficiaire en cas
d’Affacturage/

• MDG-42 (SenderTradeParty) : sans utilité

• MDG-37 (SpecifiedDocumentStatus) : Bloc permettant de donner des détails sur le statut (et
potentiellement plusieurs puisque c’est une cardinalité 0//n)/
AFNOR XP Z12-0122026-02

_Source: `c:\Users\g.baudrit\source\repos\gbaudrit\conf-aimer-votre-llm\demo\ctxc-sample-spec\with-ctxc\spec/afnor/XP_Z12-012/XP_Z12-012.pdf` (page:82/page:82)_

### E-eb881e525fb9

XP Z12-012 – Formats et Profils des messages Factures et Statuts de cycle de vie, constitutifs du socle
minimal applicable à la Réforme Facture Électronique en France

81
On peut alors détailler le bloc de détail de statut (MDG-37) :

• MDG-38 : date et heure du statut. A utiliser en cas de Message Cycle de Vie transmettant un historique
des statuts de cycle de vie. Sinon, la date et heure du statut est déjà fournie en MDG-31.

• MDT-111 (ConditionCode) : A utiliser en cas de Message Cycle de Vie transmettant un historique des
statuts de cycle de vie, correspond au code statut standard fourni en MDT-88. 

• MDT-113 (ReasonCode) : permet de renseigner le motif du statut en code, à choisir dans une liste.

• MDT-114 (Reason) : permet de renseigner le motif en texte.

• MDT-112 (Condition) : libellé du statut renseigné en MDT-111, uniquement en cas de fourniture d’un
historique de statuts.

• MDT-115 (ProcessConditionCode) : A utiliser en cas de Message Cycle de Vie transmettant un
historique des statuts de cycle de vie, correspond au code statut de la réforme (comme le MDT-105)

• MDT-116 (ProcessCondition) : A utiliser en cas de Message Cycle de Vie transmettant un historique
des statuts de cycle de vie, correspond à MDT-115, en texte.

• MDT-121 (RequestedActionCode) . Action demandée en code (par exemple en attente d’un AVOIR)/

• MDT-122 (RequestedAction) : Action attendue en texte.
AFNOR XP Z12-0122026-02

_Source: `c:\Users\g.baudrit\source\repos\gbaudrit\conf-aimer-votre-llm\demo\ctxc-sample-spec\with-ctxc\spec/afnor/XP_Z12-012/XP_Z12-012.pdf` (page:83/page:83)_

### E-d140140b52a6

XP Z12-012 – Formats et Profils des messages Factures et Statuts de cycle de vie, constitutifs du socle
minimal applicable à la Réforme Facture Électronique en France

82
• MDT-124-2 (SequenceNumeric) : Permet de donner un numéro à chaque enregistrement de Détail de
statut.

• MDG-39 (IncludedNote) : Note, avec un code sujet et un texte. Permet de donner un texte libre pour
commentaire.

• MDG-43 (SpecifiedDocumentCharacteristic) : Bloc d’information répétable permettant de fournir des
données nécessaires pour le statut, composé des éléments suivants : 

✓ MDT-206 (ID) : code de la donnée sur laquelle le détail de statut porte (BT-84 pour un IBAN par
exemple).

✓ MDT-207 (TypeCode) : Code permettant de qualifier comment le bloc va être utilisé, cf règle BR-
FR-CDV-CL-11.

✓ MDT-208 (ValueChangeIndicator) : permet d’indiquer s’il s’agit de proposer ou de demander une
modification de valeur (par exemple numéro d’IBAN suite à affacturage).
AFNOR XP Z12-0122026-02

_Source: `c:\Users\g.baudrit\source\repos\gbaudrit\conf-aimer-votre-llm\demo\ctxc-sample-spec\with-ctxc\spec/afnor/XP_Z12-012/XP_Z12-012.pdf` (page:84/page:84)_

### E-45a63135c6c7

XP Z12-012 – Formats et Profils des messages Factures et Statuts de cycle de vie, constitutifs du socle
minimal applicable à la Réforme Facture Électronique en France

83
✓ MDT-211 (Name) : Nom de la donnée référencée en MDT-206 (par exemple IBAN).

✓ MDT-212 (Description) : Description de la donnée (si nécessaire).

✓ MDT-213 (Location) : Xpath de la donnée concernée dans le message facture.

✓ MDT-214 (Value) : Nouvelle valeur à prendre en compte, s’il s’agit d’une donnée de type Texte/

✓ MDT-215 (ValueAmount) : Valeur de montant quand il faut référencer un montant. En particulier
pour un montant à e-reporter - un montant de paiement, un montant d’approbation de facture, 0

✓ MDT-217 (ValueMesure) : permet de signifier une Valeur de type unité de mesure attendue.

✓ MDT-218 (ValueDateTime) : permet de signifier une Valeur de type Date et / ou heure attendue.

✓ MDT-221 (ValueCode) : permet de signifier une Valeur de type Code attendue.

✓ MDT-222 (ValueQuantity) : permet de signifier une Valeur de type Quantité attendue.

✓ MDT-223 (ValueNumeric) : permet de signifier une Valeur de type Numeric attendue.

✓ MDT-224 (ValuePercent) : permet de signifier une Valeur de type Pourcentage attendue, et en cas
d’utilisation pour e-reporting d’encaissement, le taux de TVA applicable au montant encaissé
s’exprime ici/

5.2 Règles de gestion applicables

Le tableau ci-dessous liste les règles de gestion applicables au message CDAR pour l’échange de statuts de
Cycle de Vie de factures/ Il s’agit principalement de règles qui rendent obligatoire une donnée facultative dans
le message CDAR ou de règle de liste de codes à respecter, en fonction du type de message (phase traitement
ou transmission).

CODE BR Titre Description S'applique à

BR-FR-04 CodeType de la
facture
Les code types de documents pour une facture sont les suivants:
Factures simples :
- Facture commerciale (380)
- Facture auto-facturée (389)
- Facture affacturée (393)
- Facture auto-facturée affacturée (501) (*) 

Factures d'acompte :
- Facture d'acompte (386)
- Facture d’acompte auto-facturée (500) (*) 

Factures rectificatives :
- Facture rectificative (384)
- Facture rectificative auto-facturée ( 471) (*)
- Facture rectificative affacturée (472) (*)
- Facture rectificative auto-facturée affacturée ( 473)  (*) 

Avoirs :
- Avoir auto-facturé (261)
- Avoir pour Remise Global (262)
- Avoir (381)
- Avoir affacturé (396)
- Avoir auto-facturé affacturé (502) (*)
- Avoir de facture d'acompte (503) (*) 

Les autres types de factures définis dans la norme (UNTDID 1001) ne
doivent pas être utilisés.
/!\ : (*) En attente de l'intégration des codes par la maintenance
EN16931
MDT-91

BR-FR-CDV-01 Donnée Obligatoire MDT-3 (et donc MDG-3)est obligatoire MDG-3

BR-FR-CDV-02 Donnée Obligatoire MDT-3 doit être égal à urn.cpro.gouv.fr:1p0:CDV:invoice MDT-3
AFNOR XP Z12-0122026-02

_Source: `c:\Users\g.baudrit\source\repos\gbaudrit\conf-aimer-votre-llm\demo\ctxc-sample-spec\with-ctxc\spec/afnor/XP_Z12-012/XP_Z12-012.pdf` (page:85/page:85)_

### E-8b524f6371e3

XP Z12-012 – Formats et Profils des messages Factures et Statuts de cycle de vie, constitutifs du socle
minimal applicable à la Réforme Facture Électronique en France

84
CODE BR Titre Description S'applique à

Pour le CDV transmis au PPF, cette donnée doit être égale à
urn.cpro.gouv.fr:1p0:CDV:einvoicingF2

BR-FR-CDV-03 Donnée Obligatoire MDT-4 est obligatoire MDT-4

BR-FR-CDV-04 Donnée Obligatoire MDG-4 est obligatoire MDG-4

BR-FR-CDV-05 Donnée Obligatoire MDG-9 est obligatoire MDG-9

BR-FR-CDV-06 Donnée Obligatoire MDT-21 est obligatoire MDT-21

BR-FR-CDV-07 ID légal du
Destinataire du CDV
SI MDT-77 est égal à 23 ALORS MDT-38 est obligatoire
C'est un ID (légal, privé) de celui qui pose le statut
SI MDT-77 est égal à 305 et aucune MDT-59 = DFH ALORS MDT-38 n'est
pas renseignée
MDT-38

BR-FR-CDV-08
Adresse électronique
du Destinataire du
CDV
si MDT-59 EST DIFFERENT de WK ou DFH, MDT-73 est Obligatoire MDT-73

BR-FR-CDV-09 CDV Transmission ou
Traitement MDT-77 est OBLIGATOIRE et doit être égal à 23 ou 305 MDT-77

BR-FR-CDV-10 Identifiant unique de
facture : ID de Facture
MDT-87 (Identifiant du document objet du CDV) est OBLIGATOIRE 

En cas de statut IRRECEVABLE (MDT-105 = 501), MDT-87 est le nom du
fichier irrecevable
MDT-87

BR-FR-CDV-11
Identifiant unique de
facture : Date de
facture
MDG-35 est OBLIGATOIRE sauf si MDT-105 = 501 (IRRECEVABLE) MDG-35

BR-FR-CDV-12 Donnée Obligatoire MDT-105 est OBLIGATOIRE MDT-105

BR-FR-CDV-13 Donnée Obligatoire MDT-129 est OBLIGATOIRE sauf si MDT-105 = 501 (IRRECEVABLE) MDT-129

BR-FR-CDV-14 Statut Encaissé
Si le statut est "Encaissé" (MDT-105 = 212), ALORS il doit y avoir au
moins 1 Bloc MDG-43 avec une valeur de MDT-207 = MEN et une valeur
MDT-215 présente
MDT-207

BR-FR-CDV-CL-01 Donnée listée
MDT-2 est dans la liste ci-dessous :
- REGULATED
- NON_REGULATED
- B2C
- B2BINT
- OUTOFSCOPE 

Cette donnée n'est pas transmise dans les CDV à destination du PPF
(pour les statuts obligatoires "Déposée", "Rejetée", "Refusée",
"Encaissée"), puisque seul les flux régulés (e-invoicing) font l'objet de
CDV vers le PPF. 

à compléter le cas échéant
MDT-2
AFNOR XP Z12-0122026-02

_Source: `c:\Users\g.baudrit\source\repos\gbaudrit\conf-aimer-votre-llm\demo\ctxc-sample-spec\with-ctxc\spec/afnor/XP_Z12-012/XP_Z12-012.pdf` (page:86/page:86)_

### E-429b3f1acbb6

XP Z12-012 – Formats et Profils des messages Factures et Statuts de cycle de vie, constitutifs du socle
minimal applicable à la Réforme Facture Électronique en France

85
CODE BR Titre Description S'applique à

BR-FR-CDV-CL-02
CodeRole de
l'émetteur (Sender) du
CDV
Si le statut (MDT-77) est égal à 305, alors MDT-21 DOIT être égal à WK. 
Si le statut (MDT-77) est égal à 23, alors MDT-21 DOIT être dans la liste
suivante : 

(extrait de UNCL 3035): 

BY : Acheteur ;
AB : Représentant de l'acheteur pour la vente. 
DL : Affactureur (Factor) 
SE : Vendeur
AB : Agent d'acheteur
SR : Agent de Vendeur
WK : Plateforme ou opérateur de dématérialisation (du
fournisseur/vendeur ou de l'acheteur) => Plateforme Agréée ou autre
PE : Bénéficiaire (Payee) 
PR : Payeur 

II : INVOICER (Invoice issuer)
IV : INVOICEE
MDT-21

BR-FR-CDV-CL-03 CodeRole du Créateur
(Issuer) du CDV
Si le statut (MDT-77) est égal à 305, alors MDT-40 DOIT être égal à WK
Si le statut (MDT-77) est égal à 23, alors MDT-40 est dans la liste
suivante : 

(extrait de UNCL 3035) 

BY : Acheteur ;
AB : Représentant de l'acheteur pour la vente. 
DL : Affactureur (Factor) 
SE : Vendeur
AB : Agent d'acheteur
SR : Agent de Vendeur
PE : Bénéficiaire (Payee) 
PR : Payeur 

II : INVOICER (Facturant)
IV : INVOICEE (Facturé à, adressé à)
MDT-40

BR-FR-CDV-CL-04 CodeRole du
Destinataire du CDV
MDT-59 DOIT ETRE dans la liste suivante : 

(Extrait de UNCL 3035) 

BY : Acheteur ;
AB : Représentant de l'acheteur pour la vente.
DL : Affactureur (Factor)
SE : Vendeur
AB : Agent d'acheteur
SR : Agent de Vendeur
PE : Bénéficiaire (Payee)
PR : Payeur 

II : INVOICER (Facturant)
IV : INVOICEE (Facturé à, adressé à) 

WK : Plateforme ou opérateur de dématérialisation (du
fournisseur/vendeur ou de l'acheteur)
MDT-59
AFNOR XP Z12-0122026-02

_Source: `c:\Users\g.baudrit\source\repos\gbaudrit\conf-aimer-votre-llm\demo\ctxc-sample-spec\with-ctxc\spec/afnor/XP_Z12-012/XP_Z12-012.pdf` (page:87/page:87)_

### E-e1b7aab088a1

XP Z12-012 – Formats et Profils des messages Factures et Statuts de cycle de vie, constitutifs du socle
minimal applicable à la Réforme Facture Électronique en France

86
CODE BR Titre Description S'applique à

BR-FR-CDV-CL-05 Code Statut Standard
(UNTDID 1373)
MDT-88 DOIT ETRE dans la liste UNTDID 1373, avec les
correspondances suivantes pour les statuts MDT-105 

Phase Transmission : MDT-77 = 305
•10 (Document valid) . Déposée
•51 . Emise
•43 . Reçue
•8 . Rejetée
•48 . Acknowledge = Mise à Disposition 

Phase Traitement : MDT-77 = 23
• 45 (In Process) = Prise en charge
• 39 (on hold) = Suspendue
• 37 (Complete) = Complétée
• 50 (Refjected / Refused) = Refusée (by C4)
• 49 (Conditionnaly accepted) = Approuvée Partiellement
• 47 (Paid) = Paiement Transmis ET Encaissée
• 46 (Under Query) = En litige
• 1 (accepted) = Approuvée
MDT-88

BR-FR-CDV-CL-06 Code Statut Reforme MDT-105 et MDT-115 sont dans la liste des Codes statuts de Facture MDT-105, MDT-115

BR-FR-CDV-CL-07 Code Type du Vendeur MDT-132 DOIT ETRE égal à SE : Vendeur MDT-132

BR-FR-CDV-CL-08
CodeRole du
Destinataire de la
facture (Nouveau
Bénéficiaire)
MDT-158 DOIT ETRE dans la liste ci-dessous : 

(Extrait de UNCL 3035) 

BY : Acheteur ;
AB : Représentant de l'acheteur pour la vente.
DL : Affactureur (Factor)
SE : Vendeur
AB : Agent d'acheteur
SR : Agent de Vendeur
WK : Plateforme ou opérateur de dématérialisation (du
fournisseur/vendeur ou de l'acheteur) ;
DFH : Pour le PPF
PE : Bénéficiaire (Payee)
PR : Payeur 

II : INVOICER
IV : INVOICEE
MDT-158

BR-FR-CDV-CL-09 Code MOTIFS de
Statuts MDT-113 est dans la liste des Codes motifs de statuts MDT-113

BR-FR-CDV-CL-10 Code ACTION requise MDT-121 est dans la liste des Codes actions de Facture MDT-121
AFNOR XP Z12-0122026-02

_Source: `c:\Users\g.baudrit\source\repos\gbaudrit\conf-aimer-votre-llm\demo\ctxc-sample-spec\with-ctxc\spec/afnor/XP_Z12-012/XP_Z12-012.pdf` (page:88/page:88)_

### E-a42131e60681

XP Z12-012 – Formats et Profils des messages Factures et Statuts de cycle de vie, constitutifs du socle
minimal applicable à la Réforme Facture Électronique en France

87
CODE BR Titre Description S'applique à

BR-FR-CDV-CL-11 Code objet MDG-43
MDT-207 est dans la liste suivante (à compléter) : 

- MEN : Montant encaissé (TTC)
- MPA : Montant payé
- RAP : Reste à payer (en cas de paiement partiel); 

- ESC : Escompte accordé ;
- RAB : Rabais accordé ;
- REM : Remise accordée.
- MAP : Montant HT Approuvé
- MAPTTC : Montant TTC Approuvé
- MNA : Montant HT NON Approuvé
- MNATTC : Montant TTC Non Approuvé 

- CBB : Coordonnées Bancaires Bénéficiaire à modifier
- DIV : Donnée INVALIDE
- DVA : Donnée VALIDE attendue
- MAJ : Donnée à prendre en compte à la place de celle présente dans la
facture pour le traitement (Statut "Complétée" ou "Complément")
MDT-207

5.3 Motifs des statuts de cycle de vie.

Certains statuts ont des listes restreintes de motifs, et notamment ceux qui ont comme conséquence
l’annulation automatique des factures : statuts « Rejetée à l’émission », « Rejetée en réception » et « Refusée ».

La liste de ces statuts est fournie dans la feuille « Tableau des motifs de STATUTS », avec leur description.

Un motif « NON_TRANSMISE » a été ajouté pour le statut « Déposée » pour le cas où une facture a pu être
traitée en émission, et donc faire l’objet d’un statut « Déposée » qu’une transmission soit effectivement
possible du fait d’absence de choix de Plateforme Agréée de réception par le destinataire (c’est-à-dire parce
que le destinataire est bien présent dans l’annuaire mais ne dispose d’aucune ligne d’adressage associée à une
plateforme différente de la plateforme par défaut – matricule 9998).

5.4 Présentation du fichier annexe pour les feuilles CDAR

Le fichier Excel annexe au présent document décrit aussi l’implémentation du message Cycle de Vie appliquée
aux échanges de factures B2B au travers des Plateformes Agréées.

5.4.1 Feuille « CDV FE – CDAR »

Il s’agit de la feuille de description du message Cycle de Vie (CDAR : Cross Domain Aknowledgement &
Response)/ La source est l’annexe 2 des spécifications externes 3/0, à laquelle certaines colonnes ont été
ajoutées :

• Colonne A . ID de la donnée (celle de l’annexe 2 des spécifications externes 3/0)

• Colonne B : le niveau dans la structure XML (0 racine, 1, premier bloc, ..)

• Colonne C : Cardinalité dans le message CDAR

• Colonne D (masquée) . cardinalité corrigée pour le PPF dans l’annexe 2 des spécifications externes 3/0/
Ceci sera géré par des règles de schematron et pas par une modification de cardinalité xsd.

• Colonnes F à I : description des données, par niveau.

• Colonne J (et K, masquée) : Xpath en présentation dépliée (la présentation en une ligne est en colonne
K, masquée)

• Colonne L : règle de présence des données : R (Requise), O (Optionnelle), I (informatif, en pratique non
utilisée), pour les échanges entre Plateformes Agréées et PPF, pour information seulement.
AFNOR XP Z12-0122026-02

_Source: `c:\Users\g.baudrit\source\repos\gbaudrit\conf-aimer-votre-llm\demo\ctxc-sample-spec\with-ctxc\spec/afnor/XP_Z12-012/XP_Z12-012.pdf` (page:89/page:89)_

### E-f94dfc1209af

XP Z12-012 – Formats et Profils des messages Factures et Statuts de cycle de vie, constitutifs du socle
minimal applicable à la Réforme Facture Électronique en France

88
• Colonne M : règle de présence des données : R (Requise), O (Optionnelle), I (informatif, en pratique
non utilisée) pour les échanges entre Plateformes Agréées. C’est cette colonne qui doit être prise en
compte pour la description du format CDV. Pour simplifier la lecture, la feuille a été filtrée de façon à
ne pas montrer les lignes « I ».

• Colonnes N à R : description des types logiques, longueur exigée par le PPF, listes applicables,
définition métier et commentaire reprises de l’Annexe 2 des spécifications externes 3.0

• Colonnes S à U (masquées) : règles de gestion à appliquer sur le message CDV pour les échanges PPF
 Plateformes Agréées.

• Colonne V . Règle de gestion à appliquer pour l’utilisation du message CDV entre Plateformes Agréées,
objet du présent document.

• Colonne W : texte des règles de gestion de la colonne V

• Colonne X : filtrage pour exclure les lignes du message qui n’ont pas à être utilisées/

• Colonne Y : commentaires et suivi des modifications.

5.4.2 Feuille « BR-FR-CDV pour factures »

Cette feuille reprend l’ensemble des règles de gestion applicables sur le message Cycle de Vie pour les
échanges de factures via les Plateformes Agréées. Base de construction du schématron à appliquer :

• Colonne B : Code de la règle de gestion

• Colonne C : Titre de la règle de gestion

• Colonne D : Description de la règle de gestion

• Colonne E : sur quelle(s) données du message la règle s’applique-t-elle.

• Colonnes G et après : indiquent les modifications apportées à chaque version.

5.4.3 Feuille « Acteurs CDV »

Cette feuille décrit, pour chaque statut, comment renseigner l’entête du message CDV, de façon à ne pas
nommer les Plateformes Agréées dans les messages. Il exprime aussi qui peut émettre le message (rôle) et
quels sont les destinataires.

5.4.4 Feuille « Codes Action »

Cette feuille présente les codes « Action » attendue, précédemment présents en feuille « Acteurs CDV ».

5.4.5 Feuille « Tableau des motifs de STATUTS »

Cette feuille présente les motifs applicables aux statuts :

• Colonne A : Code MOTIF

• Colonne B : Libellé du Motif

• Colonne C : Description du MOTIF et de quand il peut être utilisé

• Colonnes I à Q : Pour quels statuts le Motif peut être utilisé/ Par filtrage, ceci permet d’avoir la liste des
motifs applicables par statut.

• Colonnes T et suivantes : indiquent les modifications apportées à chaque version.
AFNOR XP Z12-0122026-02

_Source: `c:\Users\g.baudrit\source\repos\gbaudrit\conf-aimer-votre-llm\demo\ctxc-sample-spec\with-ctxc\spec/afnor/XP_Z12-012/XP_Z12-012.pdf` (page:90/page:90)_

### E-46e7fd7a5885

XP Z12-012 – Formats et Profils des messages Factures et Statuts de cycle de vie, constitutifs du socle
minimal applicable à la Réforme Facture Électronique en France

89 
(normative) 

Description Excel des formats et profils

XP_Z12-012_Annexe_A_V1.3.xls
AFNOR XP Z12-0122026-02

_Source: `c:\Users\g.baudrit\source\repos\gbaudrit\conf-aimer-votre-llm\demo\ctxc-sample-spec\with-ctxc\spec/afnor/XP_Z12-012/XP_Z12-012.pdf` (page:91/page:91)_

### E-cf8ded641500

XP Z12-012 – Formats et Profils des messages Factures et Statuts de cycle de vie, constitutifs du socle
minimal applicable à la Réforme Facture Électronique en France

90 
(normative) 

Exemples de factures (flux 2) et de messages CDAR de cycle de vie

XP_Z12-012_Annexe_B_V1.3.zip
AFNOR XP Z12-0122026-02

_Source: `c:\Users\g.baudrit\source\repos\gbaudrit\conf-aimer-votre-llm\demo\ctxc-sample-spec\with-ctxc\spec/afnor/XP_Z12-012/XP_Z12-012.pdf` (page:92/page:92)_

### E-543001d4ce88

XP Z12-012 – Formats et Profils des messages Factures et Statuts de cycle de vie, constitutifs du socle
minimal applicable à la Réforme Facture Électronique en France

91
Bibliographie

[1] Dossier de spécifications externes de la Facture électronique 3.1 - Dossier général - Agence
pour l’informatique financière de l’État/
[2] Documentation du format Factur-X, publié par le FNFE-MPE et le FeRD, mis à jour tous les 6
mois, les 15 mai et 15 novembre de chaque année sur le site www.fnfe-mpe.org.
[3] Norme AFNOR XP-Z12-014 : Cas d’usage B2B applicables dans le cadre la Réforme Facture
Électronique en France.
[4] Norme XP Z12-013 : API pour interfacer les systèmes d’informations des entreprises avec les
Plateformes Agréées (API SI/SC/OD  PA).
AFNOR XP Z12-0122026-02

_Source: `c:\Users\g.baudrit\source\repos\gbaudrit\conf-aimer-votre-llm\demo\ctxc-sample-spec\with-ctxc\spec/afnor/XP_Z12-012/XP_Z12-012.pdf` (page:93/page:93)_

### E-66c107379c3b

XP Z12-012

NOVEMBRE 2025

En tant que titulaire des droits d’auteurs sur ce document, ayant-droit ou distributeur
autorisé de ce document, AFNOR autorise la consultation et le téléchargement
selon les droits qui vous sont alloués pour votre abonnement ou votre achat.
Tous autres droits relatifs à ces documents sont réservés.
AFNOR s’oppose expressément à toute intégration, transmission ou absorption totale
ou partielle du présent document par des moteurs ou algorithmes d’Intelligence Artificielle (IA).
AFNOR s’oppose également à toute fouille de textes et de données ou création dérivée
produite par une IA et basée sur le présent document. 

As the copyright holder of this document or authorized distributor, AFNOR authorizes
the consultation and downloading of the document as per the rights allowed
for your subscription or purchase.
All other rights related to these documents are reserved.
AFNOR, as copyright holder or authorized distributor, expressly objects to any
integration, transmission or absorption, in whole or in part, of the present document by
Artificial Intelligence (AI) engines or algorithms. AFNOR is also opposed to any text
and data mining or derivative creation produced by an AI and based on the present document.

AFNOR

Le : 10/01/2026 à 15:38

_Source: `c:\Users\g.baudrit\source\repos\gbaudrit\conf-aimer-votre-llm\demo\ctxc-sample-spec\with-ctxc\spec/afnor 1.2/XP_Z12-012/XP_Z12-012.pdf` (page:1/page:1)_

### E-55924590626b



_Source: `c:\Users\g.baudrit\source\repos\gbaudrit\conf-aimer-votre-llm\demo\ctxc-sample-spec\with-ctxc\spec/afnor 1.2/XP_Z12-012/XP_Z12-012.pdf` (page:2/page:2)_

### E-d9498b131b22

  En tant que titulaire des droits d’auteurs sur ce document, AFNOR en autorise la consultation et le téléchargement.
Tous autres droits relatifs à ces documents sont réservés.
AFNOR s’oppose expressément b toute intégration, transmission ou absorption totale ou partielle du présent document 
par des moteurs ou algorithmes d’Intelligence artificielle (IA).
AFNOR s’oppose également à toute fouille de textes et de données ou création dérivée produite par une IA et basée sur
le présent document.

Éditée et diffusée par l’!ssociation Française de Normalisation (!FNOR) - 11, rue Francis de Pressensé -

93571 La Plaine Saint-Denis Cedex Tél.: + 33 (0)1 41 62 80 00 - Fax : +  33  (0)1 49  17  90  00  - www.afnor.org

© AFNOR — Tous droits réservés Version 1
ISSN 0335-3931 

AFNOR FE : Facture électronique

Norme expérimentale publiée par AFNOR 

XP Z12-012 

Formats et Profils des messages Factures et Statuts de cycle de vie,
constitutifs du socle minimal applicable à la Réforme Facture
Electronique en France     

Date de publication : novembre 2025
AFNOR XP Z12-0122025-11

_Source: `c:\Users\g.baudrit\source\repos\gbaudrit\conf-aimer-votre-llm\demo\ctxc-sample-spec\with-ctxc\spec/afnor 1.2/XP_Z12-012/XP_Z12-012.pdf` (page:3/page:3)_

### E-ad7b1a133151

XP Z12-012 – Formats et Profils des messages Factures et Statuts de cycle de vie,
constitutifs du socle minimal applicable à la Réforme Facture Électronique en France

2 
Sommaire

Avant-propos ........................................................................................................................................................... 4

Gestion de versions ................................................................................................................................................ 5

Introduction ............................................................................................................................................................ 7

1 Domaine d'application ..................................................................................................................................... 8

2 Références normatives .................................................................................................................................... 8

3 Termes et définitions ....................................................................................................................................... 9

4 Formats et profils de facture électronique du socle minimum .............................................................. 12
4.1 Norme Sémantique Européenne EN16931 ................................................................................................. 12
4.2 Implémentations des 2 profils EN16931 et EXTENDED-CTC-FR ............................................................. 16
4.2.1 La nécessité de proposer plusieurs profils sémantiques dans le socle minimum ........................... 16
4.2.2 L’implémentation dans les syntaxes UBL et UN/CEFACT CII exige une description spécifique ..... 17
4.3 Description sommaire de la structure sémantique des données des 2 profils .................................... 18
4.3.1 Le profil EN16931 ................................................................................................................................ 18
4.3.2 Le profil EXTENDED-CTC-FR............................................................................................................... 21
4.3.3 Évolution de la Norme ......................................................................................................................... 24
4.3.4 Profil EXTENDED de Factur-X, et Évolution du profil EXTENDED-CTC-FR ..................................... 24
4.4 Points d’attention particuliers ...................................................................................................................... 25
4.4.1 Types de données ................................................................................................................................. 25
4.4.2 Gestion des données de profils et cadre de facturation ..................................................................... 26
4.4.3 Gestion des Notes ................................................................................................................................. 26
4.4.4 Gestion des avoirs ................................................................................................................................ 27
4.4.5 Règle de calcul ...................................................................................................................................... 28
4.4.6 Règle d’arrondi dans les calculs .......................................................................................................... 29
4.4.7 Gestion de la TVA ................................................................................................................................. 29
4.4.8 Gestion des taxes autres que la TVA, cas de l’éco-contribution DEEE .............................................. 30
4.4.9 Gestion des remises et charges ........................................................................................................... 30
4.4.10 Gestion des Codes ................................................................................................................................ 31
4.4.11 Gestion des sous-lignes en profil EXTENDED-CTC-FR (et EXTENDED de Factur-X) ....................... 31
4.4.12 Factures multi-vendeurs...................................................................................................................... 33
4.4.12.1 Modalités de création d’une facture Multi-Vendeurs ................................................................ 34
4.4.12.2 Numéro de facture unitaire ....................................................................................................... 36
4.4.12.3 Les Charges et Remises .............................................................................................................. 36
4.4.12.4 Les règles de gestion .................................................................................................................. 36
4.4.12.5 Constitution du flux 1 ou 10.1, sur la base des factures unitaires ............................................ 36
4.5 Règles de gestion spécifiques ........................................................................................................................ 37
4.5.1 Les règles de contrôle additionnelles pour le respect de la réglementation en France .................. 38
4.5.2 Les règles de mapping pour constituer les flux 1 et 10.1 .................................................................. 45
4.5.3 Les règles de contrôle CPRO pour les factures B2G à destination du secteur public ...................... 49
4.5.4 Règles de gestion spécifiques pour les factures multi-vendeurs ...................................................... 55
4.6 Règle de constitution d’une représentation lisible d’une facture électronique de la présente
Norme. ............................................................................................................................................................... 58
4.6.1 Construire un modèle de représentation lisible ................................................................................ 58
4.6.2 Comment représenter les données sous forme de codes .................................................................. 59
4.6.3 Factur-X et Facture structurée avec une présentation lisible attachée ............................................ 59
4.6.4 Exemples ............................................................................................................................................... 60
4.7 Conversions entre formats du socle ............................................................................................................ 62
4.8 Présentation du fichier annexe de description des formats de facture du socle minimal ................ 62
4.8.1 Feuille « FE EN16931 + EXTENDED » ................................................................................................. 64
4.8.2 Feuille « BR-France CTC » .................................................................................................................... 65
4.8.3 Feuille « BR-France-CTC-CPRO » ........................................................................................................ 65
AFNOR XP Z12-0122025-11

_Source: `c:\Users\g.baudrit\source\repos\gbaudrit\conf-aimer-votre-llm\demo\ctxc-sample-spec\with-ctxc\spec/afnor 1.2/XP_Z12-012/XP_Z12-012.pdf` (page:4/page:4)_

### E-9e57b45177c2

XP Z12-012 – Formats et Profils des messages Factures et Statuts de cycle de vie,
constitutifs du socle minimal applicable à la Réforme Facture Électronique en France

3 
4.8.4 Feuille « BR EN16931 + EXT FR et FX » ...............................................................................................65
4.8.5 Feuille « Codelists for XML Fx - 15 11 25 »..........................................................................................67
4.8.6 Feuille « Flux 2 UBL EN16931 FR » et « Flux 2 UBL EXT-CTC-FR » ...................................................67
4.8.7 Feuilles « FACTUR-X BASIC WL FR », « CII D22B & FX EN16931 FR » et « CII D22B & FX EXT-CTC-
FR) ..........................................................................................................................................................68
4.8.8 Feuilles « FE - Flux 1 », « Flux 1 UBL » et « Flux 1 CII » ......................................................................73
4.8.9 Feuille « E-REPORTING - Flux 10 » ......................................................................................................73
4.8.10 Feuille « Règles de gestion 3.1 » ...........................................................................................................73

5 Le message de Cycle de Vie – CDAR .............................................................................................................. 74
5.1 Description de la structure du message CDAR à utiliser ......................................................................... 74
5.2 Règles de gestion applicables ....................................................................................................................... 82
5.3 Motifs des statuts de cycle de vie ................................................................................................................. 86
5.4 Présentation du fichier annexe pour les feuilles CDAR ........................................................................... 86
5.4.1 Feuille « CDV FE – CDAR » ....................................................................................................................86
5.4.2 Feuille « BR-FR-CDV pour factures » ...................................................................................................87
5.4.3 Feuille « Acteurs CDV » .........................................................................................................................87
5.4.4 Feuille « Codes Action » ........................................................................................................................87
5.4.5 Feuille « Tableau des motifs de STATUTS » ........................................................................................87 

(normative) Description Excel des formats et profils ................................................................ 88 

(normative) Exemples de factures (flux 2) et de messages CDAR de cycle de vie ................ 89
Bibliographie ........................................................................................................................................................ 90
AFNOR XP Z12-0122025-11

_Source: `c:\Users\g.baudrit\source\repos\gbaudrit\conf-aimer-votre-llm\demo\ctxc-sample-spec\with-ctxc\spec/afnor 1.2/XP_Z12-012/XP_Z12-012.pdf` (page:5/page:5)_

### E-6b401450f2f4

XP Z12-012 – Formats et Profils des messages Factures et Statuts de cycle de vie,
constitutifs du socle minimal applicable à la Réforme Facture Électronique en France

4 
Avant-propos

Le présent document est destiné à tous les organismes qui souhaitent échanger des factures électroniques
dans le contexte de la réglementation française (Réforme de la Facture Électronique telle que décrite aux
article 289, 289BIS, 290 et 290A du Code Générale des Impôts), mais aussi plus largement dans le respect des
dispositions de la Directive 2006-112-CE, modifiée par le Directive UE 2025/516 dite ViDA (VAT in the Digital
Age).

Le présent document traite des formats et des profils des messages Factures et Statuts de cycle de vie,
constitutifs du socle minimal applicable à la Réforme Facture Électronique en France.

Le présent document n’a pas pour objet de détailler les cas d’usage qui feront l’objet d’une publication séparée.

Ce Document décrit les formats et profils applicables dans le cadre de la réforme facture électronique en
France :

⎯ D’une part, s’agissant du message facture, en conformité avec la Norme Sémantique Européenne de la
facture électronique EN 16931

⎯ D’autre part, s’agissant du message de statut de cycle de vie implémenté à partir du message UN/CEFACT
Cross Domain Aknowledgement and Response (CDAR)

La connaissance des normes EN 16931, ainsi que des syntaxes d’implémentation UBL, UN/CEFACT CII et
UN/CEFACT CDAR, est un prérequis essentiel à la lecture du présent document.

A ce document est annexé un fichier Excel de description détaillée des formats et profils, ainsi que leurs
implémentations dans les syntaxes UBL, UN/CEFACT CII et UN/CEFACT CDAR, les règles de gestion associées
et les listes de codes applicables.

Ce document a vocation à évoluer, notamment dans la description du profil EXTENDED-CTC-FR du message
Facture et dans celle du message de statuts de cycle de vie, en fonction des travaux de la Commission AFNOR
et en accompagnement du déploiement opérationnel de la Réforme Facture Électronique en France, et de la
mise en œuvre de la généralisation de la facture électronique en Union Européenne et au-delà.

Note préalable

Au sein de la réforme, l’expression « Plateforme de Dématérialisation Partenaire (PDP) » a été remplacée par
« Plateforme Agréée (PA) ».
AFNOR XP Z12-0122025-11

_Source: `c:\Users\g.baudrit\source\repos\gbaudrit\conf-aimer-votre-llm\demo\ctxc-sample-spec\with-ctxc\spec/afnor 1.2/XP_Z12-012/XP_Z12-012.pdf` (page:6/page:6)_

### E-4cbcd1fe4ac1

XP Z12-012 – Formats et Profils des messages Factures et Statuts de cycle de vie,
constitutifs du socle minimal applicable à la Réforme Facture Électronique en France

5 
Gestion de versions 

N° de Version Date de Version Description des évolutions

V1.0 2025 05 07 Version initiale 

V1.1  2025 07 31
Quelques corrections éditoriales dans l’avant-propos, l’introduction, la
définition 3.6 du « e-reporting ».

Chapitre 4.2 : ajout de paragraphes pour mieux expliquer les formats
et profils et préciser l’utilisation des profils de Factur-x.

Chapitre 4.3 : ajout de rappels au textes réglementaires pour le « Livré
à ¬ et le « Bon de commande ¬/ Précisions sur l’utilisation de la BT-8.

Chapitre 4.4.3 : ajout du code DCL (BT-21) comme objet de note pour
la mention « facture établie par A au nom et pour le compte de B » (en
cas de mandat de facturation).

Chapitre 4.4.8 : ajout d’un paragraphe sur la gestion des taxes
parafiscales s’appuyant sur une nomenclature GS1 (GTIN);

Règle BR-FR-02 : suppression de « « l’espace comme caractère accepté
dans un identifiant de facture (BT-1).

Règles BR-FR-12 et BR-FR-13 : clarification et ajout des règles BR-FR-
21 et BR-FR-22 pour décrire des règles additionnelles de contrôle de
forme des adresses électroniques en fonction de la présence d’une note
avec code sujet BAR permettant de qualifier le type de traitement
attendu (e-invoicing, e-reporting, hors réforme, <);

Règle BR-FR-17 : ajout d’une valeur de type de Pièce Jointe
(RECAPITULATIF_COTRAITANCE).

Ajout des règles BR-FR-23 à BR-FR-26 pour contrôler la taille des
adresses électroniques et des Code_Routage, ainsi que les caractères
autorisés pour les Code_Routage et les adresses électroniques en
schemeID 0225.

Règles BR-FR-DEC-02 : correction éditoriale (pour une quantité, et pas
un montant).

Règle BR-FR-MAP-01 : ajout d’un exemple.

Règle BR-FR-MAP-02 : correction éditoriale (« référence de contrat » et
non « numéro de contrat »).

Règle BR-FR-MAP-06 : correction éditoriale « < dans la BT-22 du flux
1. »

Règle BR-FR-MAP-08 : reformulation.

Règle BR-FR-MAP-13 : ajout de la liste des champs concernés.

Règles BR-FR-MAP-17 à BR-FR-MAP-22 : reformulation pour être plus
précis.

Ajout de la Règle BR-FR-MAP-23 sur le format des dates dans le flux
10.1 (règle de mapping en cas de facture en UBL).
Chapitre 4.6.1 : mise à jour des colonnes suite à la modification de
l’annexe A sur la feuille « FE EN16931 + EXTENDED » (une colonne par
AFNOR XP Z12-0122025-11

_Source: `c:\Users\g.baudrit\source\repos\gbaudrit\conf-aimer-votre-llm\demo\ctxc-sample-spec\with-ctxc\spec/afnor 1.2/XP_Z12-012/XP_Z12-012.pdf` (page:7/page:7)_

### E-d0f3d8b3e580

XP Z12-012 – Formats et Profils des messages Factures et Statuts de cycle de vie,
constitutifs du socle minimal applicable à la Réforme Facture Électronique en France

6  
N° de Version Date de Version Description des évolutions  

profil pour identifier les données appartenant à chaque profil).
Chapitre 5.2 : Règle BR-FR-CDV-CL-08 : MDT-158 (et non MDT-132)

Correction de l’annexe A : voir Feuille « VERSIONS » : mise à jour des
règles de gestion, correction de quelques Xpath de l’implémentation
UBL du profil EXTENDED-CTC-FR, revue de la feuille « Acteurs CDV »,
ajout de motifs pour le statut « IRRECEVABLE ». 

V1.2  2025 10 31
Prise en compte du changement de vocabulaire : Plateforme agréée et
Solution Compatible.

Quelques corrections, précisions, notamment s‘agissant de
l’ADRESSÉ À.

Ajout de données au profil EXTENDED-CTC-FR :

• Conditions de livraison (Incoterms).

• Code qualifiant le type d’attribut et valeur avec mesure (par
exemple pour permettre de signifier des g de CO2.

• Raison d’exemption TVA (ou d’information TVA) en ligne, en
texte et en code.

• Données permettant de gérer des sous-lignes.

• Données nécessaires à la gestion des factures multi-vendeurs.

Le changement de cardinalité de l’identifiant d’objet facture à 0..n
(BT-18, BT-128).

L’ajout des règles de gestion additionnelles pour les factures B2G à
destination de CHORUS PRO.

La gestion de sous-lignes.

La gestion de factures multi-vendeurs.

La mise à jour des règles de gestion et de mapping.

La gestion du LISIBLE.

La gestion des conversions entre formats et profils de la présente
Norme.

La correction de certaines règles de gestion du message de statuts de
cycle de vie (pour gérer les factures irrecevables notamment).

L’ajout du motif « NON_TRANSMISE » au statut « Déposée » (en cas de
destinataire non équipé d’une Plateforme Agréée pour la réception de
ses factures.
AFNOR XP Z12-0122025-11

_Source: `c:\Users\g.baudrit\source\repos\gbaudrit\conf-aimer-votre-llm\demo\ctxc-sample-spec\with-ctxc\spec/afnor 1.2/XP_Z12-012/XP_Z12-012.pdf` (page:8/page:8)_

### E-0c29c1cea306

XP Z12-012 – Formats et Profils des messages Factures et Statuts de cycle de vie,
constitutifs du socle minimal applicable à la Réforme Facture Électronique en France

7 
Introduction

Dans le cadre de la Réforme Facture Électronique en France, régie par les articles 289bis, 290, 290 A du Code
Général des Impôts, applicable à compter de septembre 2026, la Commission AFNOR Facture Électronique
s’est constituée pour prendre en charge la description des formats et profils de facture et de statuts de cycle
de vie constitutifs du socle minimum que les Plateformes Agréées (PA) (ex Plateformes de Dématérialisation
Partenaires, ou PDP) devront supporter, permettant à toute entité soumise à la réforme (assujettie à la TVA
en France) utilisant ces mêmes formats de pouvoir les échanger avec leurs contreparties dans le respect des
exigences de la réforme.

Ces travaux s’inscrivent dans la normalisation européenne en matière de facture électronique, qui a conduit à
la publication par l’AFNOR de la Norme Sémantique de facture électronique structurée EN 16931, et à son
implémentation dans les syntaxes UBL et UN/CEFACT CII; Ces travaux s’appuient aussi sur la publication de
Factur-X, standard franco-allemand de facture mixte (ou hybride) composée d’une part d’une représentation
lisible sous standard PDF/A-3 (ISO 19005-3) à laquelle est joint d’autre part une représentation structurée
des données de la facture sous syntaxe UN/CEFACT CII de la Norme EN 16931.

Pour satisfaire tous les besoins des entreprises, et comme la Norme EN 16931 le prévoit, un profil « Étendu »,
dénommé « EXTENDED-CTC-FR » a aussi été défini, intégrant des données de facturation additionnelles et
modifiant quelques règles de gestion ou cardinalité de certaines données du modèle EN 16931.

A ceci ont été ajoutées des Règles de Gestion nécessaires au respect des exigences de la Réforme Facture
Électronique.

Enfin, s’agissant des statuts de cycle de vie, les travaux de la Commission AFNOR se sont appuyés sur le
message standard UN/CEFACT Cross Domain Acknowledgement and Response (CDAR), et la description de
son utilisation dans le cadre de la réforme entre les Plateformes Agréées (PA) et le Concentrateur de Données
du PPF (Portail Public de Facturation). Toutefois, il restait nécessaire de définir et décrire dans ce document
et son annexe l’utilisation de ce message CDAR pour les échanges entre entités soumises à la réforme entre
elles au travers de leurs Plateformes Agréées respectives, et avec ces dernières.

Ce document a pour vocation à rappeler les grands principes de la Norme EN 16931 et de son application,
puis d’introduire la description technique et fonctionnelle détaillée des formats et profils de facture et de
statut de cycle de vie jointe en annexe, qui comporte plusieurs composantes :

⎯ une spécification sémantique des deux profils EN 16931 et EXTENDED-CTC-FR, avec les Règles de
Gestion spécifiques à l’application de la Réforme Facture Électronique en France et applicable sur toute
facture dans le périmètre de la réforme.

⎯ Un rappel des règles de gestion de la Norme EN 16931 auxquelles ont été rajoutées quelques règles de
gestion additionnelles applicables pour le profil EXTENDED-CTC-FR.

⎯ Une description syntaxique de l’implémentation des deux profils sémantiques EN 16931 et
EXTENDED- CTC-FR dans les syntaxes XML UBL 2.1 et UN/CEFACT CII D22B, à laquelle a été ajouté la
description du profil BASIC WL de Factur-X (Facture mixte sans données de lignes sous forme
structurée).

⎯ Une description de l’utilisation du message UN/CEFACT CDAR de statuts de cycle de vie relatif aux
échanges de factures électroniques entre assujettis soumis à la réforme au travers de leurs Plateformes
Agréées respectives.
AFNOR XP Z12-0122025-11

_Source: `c:\Users\g.baudrit\source\repos\gbaudrit\conf-aimer-votre-llm\demo\ctxc-sample-spec\with-ctxc\spec/afnor 1.2/XP_Z12-012/XP_Z12-012.pdf` (page:9/page:9)_

### E-616010f523a3

XP Z12-012 – Formats et Profils des messages Factures et Statuts de cycle de vie,
constitutifs du socle minimal applicable à la Réforme Facture Électronique en France

8 
1 Domaine d'application

Le présent document vise à décrire les formats et profils des messages Facture et Statuts de Cycle de vie
appliqués aux échanges de factures électroniques, constitutifs du socle minimal de la réforme Facture
Électronique en France.

Il décrit ainsi ce que les entités soumises à la réforme doivent respecter s’agissant des factures électroniques
et des statuts de cycle de vie, ainsi que les contrôles et transformations que les Plateformes Agréées doivent
appliquer pour respecter les obligations réglementaires qui leur incombent.

2 Références normatives

Les documents de référence suivants sont indispensables pour l'application du présent document. Pour les
références datées, seule l'édition citée s'applique. Pour les références non datées, la dernière édition du
document de référence s'applique (y compris les éventuels amendements).

⎯ NF EN 16931-1+A1, Facturation électronique – Partie 1 : Modèle sémantique de données des éléments
essentiels d’une facture électronique, publiée en novembre 2019.

⎯ CEN/TS 16931-2:2017, Facturation électronique — Partie 2 : Liste de syntaxes conformes à l'EN 16931-
1

⎯ CEN/TS 16931-3-1:2017, Facturation électronique — Partie 3-1 : Méthodologie applicable aux
correspondances syntaxiques des éléments essentiels d'une facture électronique

⎯ CEN/TS 16931-3-2:2017, Facturation électronique — Partie 3-2 : Correspondance syntaxique pour la
syntaxe ISO/IEC 19845 (UBL 2;1) ― Schéma UBL 2;1 Invoice et Credit Note, publiée en juin 2020;

⎯ CEN/TS 16931-3-3:2017, Facturation électronique — Partie 3-3 : Correspondance syntaxique pour la
syntaxe Cross Industry Invoice (facture intersectorielle) ― Schéma XML D16B UN/CEFACT, publiée en
juin 2020.

⎯ CEN/TR 16931-4 :2017, Facturation électronique — Partie 4 : Lignes directrices relatives à
l'interopérabilité des factures électroniques au niveau de la transmission

⎯ CEN/TR 16931-5 :2017, Facturation électronique — Partie 5 : Lignes directrices relatives à l'utilisation
d’extensions sectorielles ou nationales en complément de l`EN 16931-1, reposant sur une méthodologie
à appliquer dans l'environnement réel

⎯ CEN/TR 16931-6, Facturation électronique — Partie 6 : Résultat des tests de l’EN 16931-1 en ce qui
concerne son application pratique pour un utilisateur final — Méthodologie de test

⎯ La documentation Factur-X, libre de droits et disponible auprès de FNFE-MPE et du FeRD, respectivement
Forums Nationaux de la Facture Électronique français et allemand, dernière Version 1.07.3 publiée le 7
mai 2025 sur le site www.fnfe-mpe.org.
AFNOR XP Z12-0122025-11

_Source: `c:\Users\g.baudrit\source\repos\gbaudrit\conf-aimer-votre-llm\demo\ctxc-sample-spec\with-ctxc\spec/afnor 1.2/XP_Z12-012/XP_Z12-012.pdf` (page:10/page:10)_

### E-5c53fe711426

XP Z12-012 – Formats et Profils des messages Factures et Statuts de cycle de vie,
constitutifs du socle minimal applicable à la Réforme Facture Électronique en France

9 
3 Termes et définitions

Pour les besoins du présent document, les termes et définitions donnés dans ce document ainsi que les termes
et définitions suivants s'appliquent. 

3.1

Annuaire PPF

Annuaire des assujettis soumis à la Réforme Facture Électronique et destinataires de factures électroniques
dans le cadre défini par cette dernière; L’annuaire des destinataires est mis en œuvre par le PPF pour les
besoins de la réforme. 

3.2

CIUS

« Core Invoice Usage Spécifiation » : Spécification d‘usage du message électronique de facture 

3.3

Concentrateur des Données

Service du PPF en charge de la concentration des données de e-invoicing (factures B2B domestique et cycle
de vie de ces factures) et de e-reporting (données de factures, transactions et de paiement hors e-invoicing),
à destination de l’Administration fiscale; 

3.4

« e-invoicing »

Désigne le périmètre de la Réforme Facture Électronique relatif aux échanges de factures électroniques entre
assujettis à la TVA en France, pour l’échange de Flux 1, Flux 2 et Flux 6. 

3.5

EN16931

Norme sémantique Européenne des données essentielles d’une facture électronique 

3.6

« e-reporting »

Désigne le périmètre de la Réforme Facture Électronique relatif aux ventes, acquisitions et opérations qui
n’entrent pas dans le périmètre « e-invoicing » et qui sont listés dans les articles 290 et 290A du Code Général
des Impôts (Ventes B2B internationales, Acquisitions B2B internationales, Ventes B2C, paiement pour les
ventes pour lesquelles la TVA est due à l’encaissement); Ce volet donne lieu à la transmission d’un Flux 10 et
de Flux 6 s’agissant du statut d’encaissement des factures pour laquelle la TVA est due à l’encaissement; 

3.7

EXTENSION

Extension du profil EN16931 du fait de l’ajout de données ou groupes de données, de l’augmentation de la
cardinalité de certains données ou groupe du modèle EN16931 ou de l’ajout de nouvelles valeurs de codes
applicables à certains champs.
AFNOR XP Z12-0122025-11

_Source: `c:\Users\g.baudrit\source\repos\gbaudrit\conf-aimer-votre-llm\demo\ctxc-sample-spec\with-ctxc\spec/afnor 1.2/XP_Z12-012/XP_Z12-012.pdf` (page:11/page:11)_

### E-12b7f2860372

XP Z12-012 – Formats et Profils des messages Factures et Statuts de cycle de vie,
constitutifs du socle minimal applicable à la Réforme Facture Électronique en France

10 
3.8

Flux 1, Flux 2, Flux 3, Flux 6, Flux 8, Flux 9, Flux 10

Les Flux nomment les différents types de messages échangés dans le cadre de la réforme :

⎯ Flux 1 : correspond au message de type Facture contenant uniquement les données requises par
l’Administration fiscale pour les factures relevant du périmètre « e-invoicing » (factures électroniques
entre assujettis à la TVA)

⎯ Flux 2 : correspond au message facture échangé entre les entités soumises à la réforme et devant être
transmis par l’intermédiaire de Plateformes Agréées, et conforme aux dispositions du présent document.

⎯ Flux 3 : correspond au message facture échangé entre les entités soumises à la réforme et devant être
transmis par l’intermédiaire de Plateformes Agréées, MAIS qui est dans un format tiers convenu entre
l’émetteur et le destinataire et contient toutes les informations requises par l’Administration fiscale sous
forme structurée et permet une extraction conforme des données pour la constitution du Flux 1 ou du
Flux 10.

⎯ Flux 6 : correspond au message de statuts de cycle de vie relatif aux échanges de factures électroniques,
implémenté en UN/CFACT CII.

⎯ Flux 8 : correspond au message facture échangé entre une entité soumise à la réforme et une entité
internationale conforme aux dispositions du présent document.

⎯ Flux 9 : correspond au message facture échangé entre une entité soumise à la réforme un non assujetti
établi en France (principalement un Particulier), conforme aux dispositions du présent document.

⎯ Flux 10 : correspond au message de « e-reporting » que les entités soumises à la Réforme Facture
Électronique doivent transmettre au Concentrateur de Données par le biais de leur Plateforme Agréée.

Les Flux 2 / Flux 8 / Flux 9 et Flux 6 constituent les formats et profils du socle minimum, objets du présent
document. 

3.9

Formats et profils du socle minimum

Les formats et profils du socle sont les formats de données structurées ou mixtes qui doivent être supportés
dans le cadre de la Réforme Facture Électronique, qui implémentent la Norme EN16931.

D’une part, trois formats constituent ce socle pour le message Facture, et implémentent chacun 2 profils de
données :

⎯ Profil EN16931, qui une CIUS pour la France de l’implémentation de la Norme EN16931

⎯ Profil EXTENDED-CTC-FR, qui est une EXTENSION pour la France de l’implémentation de la Norme
EN16931

Ces 2 profils sont implémentés dans 2 syntaxes (UBL et UN/CEFACT CII) et dans le format mixte Factur-X, plus
précisément :

⎯ Syntaxe XML ISO/IEC 19845 (UBL 2.1) : le format UBL (Universal Business Language) est conforme à la
norme OASIS U.B.L. 2.1.

⎯ Syntaxe UN/CEFACT CII. Le format CII (Cross Industry Invoice) est conforme à la norme UN/CEFACT
SCRDM CII (Supply Chain Reference Data Model – Cross Industry Invoice). La version de langage retenue
dans le cadre de la réforme est UN/CEFACT CII D22B.

⎯ Factur-X. Factur-X est un format de facture électronique hybride (ou mixte), combinant un fichier PDF
conforme à la Norme ISO-19005-3 PDF/A-3 constituant la représentation LISIBLE de la facture dans
lequel est attaché une représentation de données structurée factur-x.xml dans la syntaxe UN/CEFACT CII.
Factur-X dispose de profils additionnels (MINIMUM, BASIC WL, BASIC et EXTENDED).
AFNOR XP Z12-0122025-11

_Source: `c:\Users\g.baudrit\source\repos\gbaudrit\conf-aimer-votre-llm\demo\ctxc-sample-spec\with-ctxc\spec/afnor 1.2/XP_Z12-012/XP_Z12-012.pdf` (page:12/page:12)_

### E-ae002d5e5910

XP Z12-012 – Formats et Profils des messages Factures et Statuts de cycle de vie,
constitutifs du socle minimal applicable à la Réforme Facture Électronique en France

11 
D’autre part le format de statuts de cycle de vie est implémenté dans la syntaxe UN/CEFACT CDAR (Cross
Domain Acknowledgement and Response), et fait aussi partie des formats et profils du socle minimum. 

3.10

Réforme Facture Électronique

Réforme facture électronique applicable en France à compter du 1er septembre 2026, telle que décrite aux
articles 289, 289bis, 290 et 290A du Code Général des Impôts. 

3.11

Plateforme Agréée ou PA

Plateforme Agréée (ex-PDP) : Plateforme de facturation électronique au travers de laquelle les factures
électroniques entre assujettis à la TVA et relevant du périmètre « e-invoicing » de la Réforme Facture
Électronique doivent être échangées, ainsi que les données de « e-reporting » de factures B2B internationales
hors import de biens, de transaction et de paiement. 

3.12

PPF

Portail Public de Facturation, plateforme de l’administration proposant les services d’Annuaire des
destinataires et de Concentrateur de Données 

3.13

Solution Compatible ou SC

Les Solutions Compatibles sont des solutions de gestion utilisées par les entreprises en amont ou en aval de
l’échange de facture qui revendiquent leur compatibilité avec les exigences de la réforme facture électronique
en France, à savoir leur capacité à créer, intégrer, contrôler la conformité des factures électroniques dans un
des formats du socle minimum décrit dans la présente Norme, ainsi que dans la création, le contrôle et le
traitement des messages de statuts de cycle de vie tels que décrits dans la présente Norme.

Ceci correspond au concept d’Opérateur de Dématérialisation (OD), initialement décrit dans les spécifications
externes du PPF, avec une notion de compatibilité aux exigences réglementaires et normatifs auxquels ils
participent partiellement. Les Solutions Compatibles sont connectées à une ou plusieurs Plateforme(s)
Agréée(s) pour émettre ou recevoir des factures électroniques et des messages de statut de cycle de vie.
AFNOR XP Z12-0122025-11

_Source: `c:\Users\g.baudrit\source\repos\gbaudrit\conf-aimer-votre-llm\demo\ctxc-sample-spec\with-ctxc\spec/afnor 1.2/XP_Z12-012/XP_Z12-012.pdf` (page:13/page:13)_

### E-e4dcca0ec0cf

XP Z12-012 – Formats et Profils des messages Factures et Statuts de cycle de vie,
constitutifs du socle minimal applicable à la Réforme Facture Électronique en France

12 
4 Formats et profils de facture électronique du socle minimum

4.1 Norme Sémantique Européenne EN 16931

La Norme Sémantique Européenne a été construite comme une norme de données essentielles de facture.
L’objectif était de rendre obligatoire la réception de factures électroniques structurées implémentant cette
norme dans les syntaxes UBL et UN/CEFACT CII pour toute entité du secteur public en Union Européenne.

Cette Norme Sémantique EN 16931 est donc constituée (version publiée en novembre 2019) :

• d’un ensemble de données métiers (164), identifiées par un code de la forme BT-XXX (de BT-1 à BT-
165, BT-4 n’existant pas), organisées par type (Texte, Code, Identifiant, Montant, Prix Unitaire,
Quantité, <), organisées en groupes métiers, nommés BG-XX de BG-1 à BG-31, associés à une
cardinalité, c’est-à-dire une règle de présence facultative ou obligatoire ainsi qu’une possibilité
d’occurrence multiple;

• d’un ensemble de règles de gestion :

✓ 96 règles de gestion liées à la TVA,

✓ 126 règles de gestion liées à la présence spécifique d'une donnée métier, ou bien liées à des calculs
ou à des règles conditionnelles (si une donnée métier est égale à xxx, alors une autre donnée
métier doit être présente), ou bien exprimant des nombres de décimales pour certains types de
données, des listes de valeurs autorisées (codes) pour certains champs.

• de listes de codes à utiliser pour certaines données et permettant de normaliser les valeurs de certains
champs. Tous ces codes sont hérités des pratiques EDI déployées depuis plus de 30 ans. Par exemple,
le type de facture est défini par un code : 380 signifie « Facture Commerciale », 381 signifie « Avoir »,
384 signifie « Facture Rectificative ¬, < De même, les devises sont codifiées par des trigrammes (3
lettres), <

Cette Norme n’a pas été conçue pour adresser tous les besoins des entreprises, mais leur très grande majorité.
Ainsi, la Norme EN 16931 a été conçue sous hypothèse qu’une facture adresse une seule commande et une
seule livraison. De façon à faire face à des contraintes locales et à des besoins additionnels, la Norme EN
16931 a prévu 2 dispositions complémentaires :

• La capacité à créer des « Spécifications d’Usage » (CIUS pour « Core Invoice Usage Specification »), qui
permettent de resserrer les contraintes de la Norme, par exemple en supprimant des données
facultatives, en renommant certaines données, en réduisant la cardinalité, en restreignant les listes de
codes. Ces CIUS restent totalement conformes à la Norme EN 16931 puisqu’elles en respectent toutes
les règles de gestion et la structure de données.

• La capacité à créer des EXTENSIONS, en ajoutant des données ou des groupes de données, en
augmentant la cardinalité, en assouplissant certaines règles de gestion, en ajoutant des valeurs de
listes de codes.

Les exigences réglementaires de la réforme et l’obligation de couvrir tous les cas d’usage des entreprises
nécessitent ainsi de définir 2 profils :

• Un profil intégrant des règles de gestion additionnelles à la Norme EN 16931, ce qui en fait une CIUS. Il
s’agit du profil EN 16931.

• Un profil intégrant des données additionnelles, identifiées par des codes de la forme EXT-FR-FE-XXX,
organisées aussi par groupes identifiés EXT-FR-FE-BG-ZZZ, et quelques modifications de certaines
règles de gestion; Il s’agit du profil EXTENDED-CTC-FR.

Ces profils sémantiques décrivent donc chacun un arbre de données, en le parcourant branche par branche,
sous-branche par sous-branche jusqu’à atteindre les feuilles qui sont les données; Le parcours est guidé par
l’indication d’un niveau dans la structure (1 ou N1 : premiers embranchements, 2 ou N2 : seconds
embranchements, etc <);
AFNOR XP Z12-0122025-11

_Source: `c:\Users\g.baudrit\source\repos\gbaudrit\conf-aimer-votre-llm\demo\ctxc-sample-spec\with-ctxc\spec/afnor 1.2/XP_Z12-012/XP_Z12-012.pdf` (page:14/page:14)_

### E-c8a5261849c9

XP Z12-012 – Formats et Profils des messages Factures et Statuts de cycle de vie,
constitutifs du socle minimal applicable à la Réforme Facture Électronique en France

13 
A chaque branche et feuille est associée une cardinalité qui indique si la présence est facultative ou obligatoire,
et si elle est répétable. La codification se fait sous la forme de 2 chiffres séparés de « .. », le premier indiquant
l’occurrence minimale et le second l’occurrence maximale, « n » signifiant « autant d’occurrences que l’on
veut ». Ainsi :

• 0..1 signifie « facultatif et non répétable ; 0..n signifie facultatif et répétable

• 1..1 signifie « obligatoire et une seule fois », 1..n signifie obligatoire et répétable

A la suite de l’adoption de la Directive ViDA, un travail de révision de la Norme EN 16931 est en cours,
conduisant principalement à ajouter des données et à corriger certaines règles de gestion pour adresser un
plus grand nombre de cas d’usage; Certaines de ces évolutions sont d’ores et déjà présentes dans le profil
EXTENDED-CTC-FR, qui a vocation à accueillir en anticipation le plus possible de ces évolutions de façon à
permettre aux utilisateurs de les utiliser avant que la révision soit effective et déployée, entre 2027 et 2030.
En effet, la Directive ViDA rend obligatoire la facture électronique au format structuré pour toutes les
transactions B2B intracommunautaires, à compter du 1er juillet 2030.

Les deux schémas suivants présentent la structure sémantique des deux profils :

• Profil de la Norme Sémantique EN 16931 : seuls les blocs d’adresse postale ne sont pas détaillés;
Chaque donnée a son identifiant (fond rouge et fond vert pour les données de ligne) et sa cardinalité
(fond bleu marine). La flèche rouge décrit le corps de la structure avec tous les éléments de niveau 1
(en fond gris).

• Profil EXTENDED-CTC-FR : les lignes en marron / violet correspondent aux données ou blocs ajoutés.
En jaune les changements de cardinalité. BG-26, BG-27 et BG-28 sont comme dans le profil EN16931
(pas détaillées ici). Les nouvelles Parties (EXT-FR-FE-BG-01, à 05) et BG-10 ont la même structure de
données chacune.
AFNOR XP Z12-0122025-11

_Source: `c:\Users\g.baudrit\source\repos\gbaudrit\conf-aimer-votre-llm\demo\ctxc-sample-spec\with-ctxc\spec/afnor 1.2/XP_Z12-012/XP_Z12-012.pdf` (page:15/page:15)_

### E-25b61376e50a

14 
BG-29 
XP Z12-012 – Formats et Profils des messages Factures et Statuts de cycle de vie, constitutifs du socle minimal applicable à la Réforme
Facture Électronique en France 

BT-73
BT-74 
Date de début de période
Date de fin de période 
0..1
0..1
BT-21
BT-22 

BT-44
BT-45
BT-46
BT-47
BT-48
BT-49

BG-8

BG-9

BT-62
BT-63
BG-12 

BT-70
BT-71
BT-72
Code Sujet (liste)
Note (texte) 

Adresse Postale de l’!CHETEUR

Contact de l’!CHETEUR

Nom du BÉNÉFICIAIRE
Identifiant privé
Identifiant légal 

Dénomination du Livré
Identifiant du Livré à
Date de livraison
0..1
1..1 

1..1

0..1

1..1
0..1
0..1 

1..1
0..1
0..1
1..1
BT-27
BT-28
BT-29
BT-30
BT-31
BT-32
BT-33
BT-34 

BT-134
BT-135
Raison sociale VENDEUR
Nom commercial
Identifiant privé (avec qualifiant)
Identifiant légal
Identifiant à la TVA
Identifiant fiscal
Forme juridique
Adresse électronique 

Date de début de période
Date de fin de période
1..1
0..1
0..n
0..1
0..1
0..1
0..1
0..1 

0..1
0..1 

BT-106
BT-107
BT-108
BT-109
BT-110
BT-111
BT-112 
Somme des HT de ligne
Somme des Remises Document
Somme des Charges Document
Total HT
Total TVA en devise de facture BT-5
Total TVA en Devise BT-6
Total TTC 
1..1
0..1
0..1
1..1
0..1
0..1
1..1
BT-92
BT-93
BT-94
BT-95
BT-96
BT-97
BT-98
BT-99
BT-100
BT-101
BT-102
BT-103
BT-104
BT-105
Montant de la Remise / Charge
Assiette de la Remise / Charge
Pourcentage Remise / Charge
Codetype TVA (S, E, K, AE, O,..)
Taux de TVA Applicable
Motif en texte Remise / Charge
Motif en code Remise / Charge 
0..1
0..1
1..1
0..1
0..1
0..1 

BT-148  Prix Unitaire Brut  0..1
BT-113
BT-114
BT-115
Montant déjà Payé (à déduire)
Arrondi
Net à payer
0..1
0..1
1..1
BG-26  Période de facturation ligne 0..1 BT-149
BT-150
Quantité de base du PU
Unité de quantité de base (Code)
0..1
0..1 

BT-122
BT-123
BT-124
BT-125
Référence du Document
Description du Document
Emplacement externe (URL)
Document joint (encodé)
1..1
0..1
0..1
0..1

Structure de la Norme Sémantique EN16931
BG-17
BG-18
BG-1

BG-2

BG-3

BG-4

BG-7

BG-11

BG-13

BG-19

BG-27

BT-116 Base HT de TVA 1..1
BT-117 Montant de TVA 1..1
BT-118 Codetype de TVA (S, E, K, AE, O,..) 1..1
BT-119 Taux de TVA applicable 0..1
BT-120 Motif d’exonération (texte) 0..1
BT-121 Motif d’exonération (code) 0..1
BG-25 BG-28               

BG-31
BG-30
BG-14
Nom du représentant
Identifiant TVA du représentant
Adresse Postale du représentant
BT-62
BT-63
BG-12
0..1
BT-1 Numéro de facture 1..1
BT-2 Date d’émission 1..1
BT-3 Code type de facture (380, 381, …) 1..1
BT-5 Code Devise de la facture 1..1
BT-6 Code Devise de comptabilisation de la TVA 0..1
BT-7 Date d’exigibilité de la TVA 0..1
BT-8 Code d’exigibilité de la TVA (Débit / Encaissement) 0..1
BT-9 Date d’échéance 0..1
BT-10 Référence acheteur (BU, Service en charge) 0..1
BT-11 Référence de projet 0..1
BT-12 Référence de contrat 0..1
BT-13 Référence de Bon de Commande (de l’!cheteur) 0..1
BT-14 Numéro d’Ordre de Vente (du Vendeur) 0..1
BT-15 Référence d’avis de réception (Bon de réception) 0..1
BT-16 Référence d’avis d’expédition (Bon de livraison) 0..1
BT-17 Référence d’appel d’offres ou de lot 0..1
BT-18 Identifiant d‘Objet facturé 0..1
BT-19 Référence comptable de l’acheteur 0..1
BT-20 Conditions de paiement (en texte) 0..1
BT-23 Cadre de Facturation 0..1
BT-24 Profil (EN16931, EXTENDED, …) 1..1

BT-25 Numéro de facture antérieure 0..1
BT-26 Date de facture antérieure 0..1

BG-5 Adresse Postale du VENDEUR 0..1

BG-6 Contact du VENDEUR 0..1

BG-15 Adresse de livraison 0..1   

BG-16 Instructions de paiement 0..1

BG-20 Remises au niveau Document 0..1

BG-21 Charges au niveau Document 0..1

BG-22 Totaux du document 1..1

BG-23 Ventilation de TVA 1..n

BG-24 Doc justificatifs additionnels 0..n

BT-153 Nom de l’article 0..1
BT-154 Description de l’article 0..1
BT-155 Code article du VENDEUR 0..1
BT-156 Code article de l’!CHETEUR 0..1
BT-157 Identifiant standard d’article 0..1
BT-158 Identifiant de classification 0..n
BT-159 Pays d’origine (code) 0..1

BG-32 Attributs de l’article 0..n

BT-160 Nom d’attribut d’article 1..1
BT-161 Valeur de l’attribut d’article 1..1
BT-136
BT-137
Montant de la Remise
Assiette de la Remise
1..1
0..1
BT-138 Pourcentage Remise 0..1
BT-139 Motif en texte Remise 0..1
BT-140 Motif en code Remise 0..1   

BT-141 Montant de la Charge 1..1
BT-142 Assiette de la Chargee 0..1
BT-143 Pourcentage Charge 0..1
BT-144 Motif en texte Charge 0..1
BT-145 Motif en code Charge 0..1   

BT-146 Prix Unitaire NET 1..1
BT-147 Rabais sur PU BRUT 0..1

BT-126 Numéro de ligne 1..1
BT-127 Note de ligne 0..1
BT-128 Identifiant d’objet facturé 0..1
BT-129 Quantité facturée 0..1
BT-130 Unité de quantité 0..1
BT-131 Montant HT de ligne 1..1
BT-132 Référence à la ligne de BC 0..1
BT-133 Réf comptable acheteur ligne 0..1

AFNOR
XP Z12-0122025-11

_Source: `c:\Users\g.baudrit\source\repos\gbaudrit\conf-aimer-votre-llm\demo\ctxc-sample-spec\with-ctxc\spec/afnor 1.2/XP_Z12-012/XP_Z12-012.pdf` (page:16/page:16)_

### E-9d9d6f3477e7

15 
XP Z12-012 – Formats et Profils des messages Factures et Statuts de cycle de vie, constitutifs du socle minimal applicable à la Réforme
Facture Électronique en France 

BT-1
BT-2
BT-3
BT-5
BT-6
BT-7
BT-8
BT-9
BT-10
BT-11
BT-12
BT-13
EXT-FR-FE-01
BT-14
BT-15
BT-16
BT-17
BT-18
BT-19
BT-20
Numéro de facture
Date d’émission
Code type de facture (380, 381, …)
Code Devise de la facture
Code Devise de comptabilisation de la TVA
Date d’exigibilité de la TV!
Code d’exigibilité de la TV! (Débit / Encaissement)
Date d’échéance
Référence acheteur (BU, Service en charge)
Référence de projet
Référence de contrat
Référence de Bon de Commande (de l’!cheteur)
Type de contrat
Numéro d’Ordre de Vente (du Vendeur)
Référence d’avis de réception (Bon de réception)
Référence d’avis d’expédition (Bon de livraison)
Référence d’appel d’offres ou de lot
Identifiant d‘Objet facturé
Référence comptable de l’acheteur
Conditions de paiement (en texte)
1..1
1..1
1..1
1..1
0..1
0..1
0..1
0..1
0..1
0..1
0..1
0..1
0..1
0..1
0..1
0..1
0..1
0..n
0..1
0..1 
BG-3 

BG-11

BG-13

BG-14 
Référence à facture antérieure 

Représentant fiscal du VENDEUR

Information de livraison

Période de facturation 
BT-21 Code Sujet (liste) 0..1
BT-22 Note (texte) 1..1
BT-23 Cadre de Facturation 0..1
BT-24 Profil (EN16931, EXTENDED, …) 1..1

1..1 

0..1

0..1

0..1 

Structure sémantique du profil EXTENDED-CTC-FR
0..1 EXT-FR-FE-BG-12 Vendeur à la ligne
1..1 Informations sur l’article
1..1 Information TVA (Code, %)
0..n Détail du Prix
0..n Charges de ligne
0..n Remises de ligne
0..1 Période de facturation ligne
0..1 EXT-FR-FE-BG-10 Adresse de livraison à la ligne
0..1 EXT-FR-FE-BG-09 Bon de Vente à la ligne
0..1 EXT-FR-FE-BG-08 Bon de réception à la ligne
0..1 EXT-FR-FE-BG-07 Avis d’expédition (BL) à la ligne
0..1 EXT-FR-FE-BG-06 Réf Facture antérieure à la ligne
Instructions de paiement BG-16
Contrôle de processus BG-2
Note de facture BG-1

BG-31
BG-30
BG-29
BG-28
BG-27
BG-26
1..n Lignes de facture BG-25
0..1
1..1
1..1 BT-27 Raison sociale VENDEUR 1..1
BT-28 Nom commercial 0..1
BT-29 Identifiant privé (avec qualifiant) 0..n
BT-30 Identifiant légal 0..1
BT-31 Identifiant à la TVA 0..1
BT-32 Identifiant fiscal 0..1
BT-33 Forme juridique 0..1
BT-34 Adresse électronique 0..1
BG-5 Adresse Postale du VENDEUR 0..1
BG-6 Contact du VENDEUR 0..1
BT-25 Numéro de facture antérieure 0..1
BT-26 Date de facture antérieure 0..1
EXT-FR-FE-02 Codetype de la facture antérieure 0..1
BG-4 VENDEUR 1..1   

BG-7 ACHETEUR 1..1 BT-44 Raison sociale ACHETEUR 1..1
BT-45 Nom commercial 0..1
BT-46 Identifiant privé (avec qualifiant) 0..n
BT-47 Identifiant légal 0..1
BT-48 Identifiant à la TVA 0..1
BT-49 Adresse électronique de l’acheteur 0..1
EXT-FR-FE-BG-01 AGENT d’!CHETEUR 0..1 

BG-10 BÉNÉFICIAIRE (du paiement) 0..1 

EXT-FR-FE-BG-02 PAYEUR 0..1 

EXT-FR-FE-BG-03 AGENT de VENDEUR 0..1 

EXT-FR-FE-BG-04 ADRESSÉ À 0..1 

EXT-FR-FE-BG-05 FACTURANT 0..1 
EXT-FR-FE-xxx Raison sociale 1..1
EXT-FR-FE-xxx Code Rôle (liste) 0..1
EXT-FR-FE-xxx Nom commercial 0..1
EXT-FR-FE-xxx Identifiant privé (avec qualifiant) 0..n
EXT-FR-FE-xxx Identifiant légal 0..1
EXT-FR-FE-xxx Identifiant à la TVA 0..1
EXT-FR-FE-xxx Adresse électronique 0..1
EXT-FR-FE-xxx Adresse postale 0..1
EXT-FR-FE-xxx Contact 0..1
BG-8 Adresse Postale de l’!CHETEUR 1..1
BG-9 Contact de l’!CHETEUR 0..1

BT-62 Nom du représentant 1..1
BT-63 Identifiant TVA du représentant 1..1
BG-12 Adresse Postale du représentant 1..1
BT-70 Dénomination du Livré 1..1
BT-71 Identifiant du Livré à 0..1
BT-72 Date de livraison 0..1
EXT-FR-FE-185 INCOTERMS 0..1
EXT-FR-FE-186 Lieu de livraison 0..1
BT-92 BT-99 Montant de la Remise / Charge
Assiette de la Remise / Charge
Pourcentage Remise / Charge
Codetype TVA (S, E, K, AE, O,..)
Taux de TVA Applicable
Motif en texte Remise / Charge
Motif en code Remise / Charge
1..1
BT-93 BT-100 0..1
BT-94 BT-101 0..1
BT-95 BT-102 1..1
BT-96 BT-103 0..1
BT-97 BT-104 0..1
BT-98 BT-105 0..1
EXT-FR-FE-136 Numéro de facture antérieure 0..1
EXT-FR-FE-137 Codetype de la facture antérieure 0..1
EXT-FR-FE-138 Date de facture antérieure 0..1
EXT-FR-FE-139 Numéro de ligne facture antérieure 0..1
BT-73 Date de début de période 0..1
BT-74 Date de fin de période 0..1

BG-17 Virement (compte à payer) 0..n
BG-18 Information carte de paiement 0..1
BG-19 Prélèvement 0..1
EXT-FR-FE-XX Identifiant BL / BR / BV 0..1
EXT-FR-FE-XX Numéro de ligne dans BL / BR / BV 0..1 BG-15 Adresse de livraison 0..1  

EXT-FR-FE-BG-14 INCOTERMS (Cond. Livraison) 0..1 EXT-FR-FE-149 Nom du Livré à (à la ligne) 0..1
EXT-FR-FE-146 Identifiant du Livré à (à la ligne) 0..1
EXT-FR-FE-150 Adresse de livraison (à la ligne) 0..1
EXT-FR-FE-158 Date de livraison (à la ligne) 0..1
BT-106 Somme des HT de ligne 1..1
BT-107 Somme des Remises Document 0..1
BT-108 Somme des Charges Document 0..1
BT-109 Total HT 1..1
BT-110 Total TVA en devise de facture BT-5 0..1
BT-111 Total TVA en Devise BT-6 0..1
BT-112 Total TTC 1..1
BT-113 Montant déjà Payé (à déduire) 0..1
BT-114 Arrondi 0..1
BT-115 Net à payer 1..1
BG-20 Remises au niveau Document 0..1

BG-21 Charges au niveau Document 0..1

BG-22 Totaux du document 1..1   

BG-23 Ventilation de TVA 1..n

BG-24 Doc justificatifs additionnels 0..n
BT-146 Prix Unitaire NET 1..1
BT-147 Rabais sur PU BRUT 0..1
BT-148 Prix Unitaire Brut 0..1
BT-149 Quantité de base du PU 0..1
BT-150 Unité de quantité de base (Code) 0..1

BT-151 Catégorie TVA (S, K, AE, ..) 0..1
BT-152 Taux de TVA 0..1
EXT-FR-FE-178 Raison d’exemption en texte 0..1
EXT-FR-FE-179 Raison d’exemption en code 0..1
EXT-FR-FE-180 Code d’exigibilité de la TVA en ligne 0..1
BT-116 Base HT de TVA 1..1
BT-117 Montant de TVA 1..1
BT-118 Codetype de TVA (S, E, K, AE, O,..) 1..1
BT-119 Taux de TVA applicable 0..1
BT-120 Motif d’exonération (texte) 0..1
BT-121 Motif d’exonération (code) 0..1
BT-126 Numéro de ligne 1..1
EXT-FR-FE-162 Identifiant de ligne Parent 0..1
EXT-FR-FE-163 Sous type de ligne 0..1
BT-127 Note de ligne 0..n EXT-FR-FE-183 Code sujet de note de ligne
BT-128 Identifiant d’objet facturé 0..n BT-128-1 Type d’identifiant
BT-129 Quantité facturée 0..1
BT-130 Unité de quantité 0..1
BT-131 Montant HT de ligne 1..1
EXT-FR-FE-181 TVA à la ligne devise facture 0..1
EXT-FR-FE-182 TVA à la lige devise compta 0..1
EXT-FR-FE-184 Montant TTC à la ligne  0..1
EXT-FR-FE-135 Référence BC à la ligne 0..1
BT-132 Référence à la ligne de BC 0..1
BT-133 Réf comptable acheteur ligne 0..1
BT-153 Nom de l’article 0..1
BT-154 Description de l’article 0..1
BT-155 Code article du VENDEUR 0..1
BT-156 Code article de l’!CHETEUR 0..1
BT-157 Identifiant standard d’article 0..1
BT-158 Identifiant de classification 0..n
BT-159 Pays d’origine (code) 0..1

BG-32 Attributs de l’article 0..n
BT-122 Référence du Document 1..1
BT-123 Description du Document 0..1
BT-124 Emplacement externe (URL) 0..1
BT-125 Document joint (encodé) 0..1

EXT-FR-FE-164 Raison sociale  0..1
EXT-FR-FE-165 Nom commercial  0..1
EXT-FR-FE-166 Identifiant privé   0..n
EXT-FR-FE-167 Identifiant légal  0..1
EXT-FR-FE-168/169 Identifiant à la TVA / fiscal  0..1
EXT-FR-FE-170 Adresse électronique  0..1
EXT-FR-FE-BG-13 Adresse postale  0..1
EXT-FR-FE-159 Code de type d’attribut 0..1
BT-160 Nom d’attribut d’article  0..1
0..1  BT-161 Valeur de l’attribut d’article  
EXT-FR-FE-160 Valeur de l’attribut avec unité 0..1 EXT-FR-FE-161 Unité de mesure

AFNOR
XP Z12-0122025-11

_Source: `c:\Users\g.baudrit\source\repos\gbaudrit\conf-aimer-votre-llm\demo\ctxc-sample-spec\with-ctxc\spec/afnor 1.2/XP_Z12-012/XP_Z12-012.pdf` (page:17/page:17)_

### E-80632409d651

XP Z12-012 – Formats et Profils des messages Factures et Statuts de cycle de vie,
constitutifs du socle minimal applicable à la Réforme Facture Électronique en France

16 
4.2 Implémentations des 2 profils EN16931 et EXTENDED-CTC-FR

4.2.1 La nécessité de proposer plusieurs profils sémantiques dans le socle minimum

La Norme EN 16931 est une description sémantique. Elle autorise de créer différents profils :

• D’une part des spécifications d’usage (appelée CIUS pour Core Invoice Usage Specification), qui
permettent des restrictions (des données optionnelles supprimées, des cardinalités réduites), mais
qui doivent passer toutes les règles de gestion de la Norme EN 16931.

• D’autre part des EXTENSIONS, qui intègrent des données additionnelles, peuvent étendre la
cardinalité de certaines données, voire assouplir certaines règles de gestion, en supprimer certaines,
en ajouter d’autres, de façon limitée.

Il convient ensuite d’implémenter ces profils dans un format informatique exploitable automatiquement; Les
syntaxes choisies sont les deux syntaxes XML retenues pour l’implémentation de la norme EN 16931 pour le
secteur public en Union Européenne : XML UBL et XML UN/CEFACT CII.

Pour information, une spécification d’implémentation dans la syntaxe EDIFACT a aussi été produite dans les
publications de « Syntax Binding » de la Norme EN 16931, mais est utilisable uniquement sur la base du
volontariat et avec accord bilatéral des 2 parties (Vendeur et Acheteur).

Une autre implémentation a été documentée avec le format mixte Factur-X qui se présente sous la forme
d’une représentation lisible PDF/A-3 à laquelle est joint un fichier de données de facture au format structuré
XML UN/CEFACT CII nommé « factur-x.xml ». Ces données doivent être toutes présentes dans la
représentation lisible. Mais ce format accepte que certaines informations ne soient présentes que dans
le lisible, ce qui donne une plus grande souplesse, notamment pour les informations de facture qui ne sont
pas des mentions obligatoires exigées par l’Administration fiscale ou sur lesquelles aucune règle de gestion et
de contrôle ne s’applique, et qui n’ont donc pas d’utilité pour automatiser le traitement de la facture et ne
remette pas en jeu sa conformité au modèle de données utilisé. Ce format se décline en 5 profils, dont 3
principaux (en gras) :

• Un profil EN 16931 : qui correspond strictement à la Norme EN 16931. Toutes les données
présentes dans le fichier structuré doivent respecter la Norme EN 16931 (et donc toutes les règles de
gestion).

• Un profil BASIC : qui est un sous-ensemble du profil EN 16931, contenant toutes les mentions
obligatoires et toutes les règles de gestion de la Norme. Ce profil a été construit pour indiquer aux
entreprises quelles données il faut savoir gérer en priorité. Toute facture conforme au profil BASIC est
aussi conforme au profil EN 16931. Par conséquent, toute facture construite sur la base du profil
BASIC peut se déclarer conforme au profil EN 16931, et il est fortement recommandé de la déclarer
en profil EN 16931. Ce profil n’est donc pas retenu dans le cadre de la réforme facture
électronique en France.

• Un profil BASIC WL : qui est le profil BASIC, mais sans les données de ligne et de charges et remises
de niveau Document. Ce profil sera autorisé au démarrage de la réforme (jusqu’en septembre 2027, à
confirmer dans la mise à jour des textes); Il n’est pas strictement conforme à la Norme EN 16931
puisqu’il manque les lignes qui sont des mentions obligatoires. Toutes les règles de gestion qui
s’appliquent à des données de ligne ou qui les impliquent (les calculs de pied de sommes de lignes et
de charges et remises documents) sont donc exclues pour ce profil.

• Un profil MINIMUM contenant un minimum de données (le strict nécessaire pour être accepté sur
CHORUSPRO). Ce profil ne peut pas être utilisé dans le cadre de la réforme, car il ne contient pas
assez de données sous forme structurée.

• Un profil EXTENDED : qui contient un grand nombre de données additionnelles, comme des Parties
tierces à la transaction commerciale (un Facturant, un Agent d‘Acheteur, un tiers Payeur, un Agent de
Vendeur, <), de nombreuses données additionnelles, notamment à la ligne. Ce profil autorise les
AFNOR XP Z12-0122025-11

_Source: `c:\Users\g.baudrit\source\repos\gbaudrit\conf-aimer-votre-llm\demo\ctxc-sample-spec\with-ctxc\spec/afnor 1.2/XP_Z12-012/XP_Z12-012.pdf` (page:18/page:18)_

### E-d35f426c72d2

XP Z12-012 – Formats et Profils des messages Factures et Statuts de cycle de vie,
constitutifs du socle minimal applicable à la Réforme Facture Électronique en France

17 
factures multi-commande, multi-livraison notamment, avec plus de 700 champs de données, qui sont
identifiées par une nomenclature propre (sous la forme BT-X-ZZZ, BT-X étant fixe pour exprimer
« donnée d’extension »). Quelques règles de gestion ont aussi été ajoutées, en remplacement de celles
de la Norme EN 16931, notamment pour introduire une tolérance dans les règles de calcul pour faire
face à certaines difficultés d’arrondis ou pour gérer des factures construites sur la base de Prix
Unitaires en TTC, mais aussi pour rester compatible avec certains outils logiciels qui calculent la TVA
à la ligne plutôt qu’en pied de facture;

Ceci étant présenté, les profils de données du socle minimum sont les suivants :

• Profil EN 16931 qui correspond à la Norme EN 16931, auquel des règles de gestion additionnelles
ont été ajoutées pour les besoins de conformité aux exigences réglementaires de la réforme facture
électronique en France

• Profil EXTENDED-CTC-FR qui est une extension du modèle sémantique EN 16931, avec un ajout de
données libellées sous la nomenclature EXT-FR-FE-ZZZ, et de groupes libellés EXT-FR-FE-BG-ZZ, ainsi
qu’un ajout de certaines règles de gestion, dont certaines en remplacement de règles de la Norme EN
16931 (pour apporter des tolérances dans les calculs nécessaires pour certains cas d’usage);

S’agissant de Factur-X, les profils utilisés dans le socle minimum sont les suivants :

• BASIC WL : uniquement jusqu’au 1er septembre 2027.

• EN 16931 : auquel il faut ajouter les règles de gestion additionnelles France décrites au chapitre 4.5.

• EXTENDED : qui contient le profil EXTENDED-CTC-FR et auquel il faut ajouter les règles de gestion
additionnelles France décrites au chapitre 4.5.

En effet, le profil EXTENDED-CTC-FR est en pratique un sous-ensemble (un subset) du profil EXTENDED de
Factur-X. qui d’ailleurs constitue un réservoir de composants d’extension pour enrichir le cas échéant le profil
EXTENDED-CTC-FR quand ceci s’avèrera nécessaire pour adresser certains cas d’usage; La documentation
Factur-X intègre la correspondance entre ses propres données d’extension et la nomenclature du profil
EXTENDED-CTC-FR (EXT-FR-FE-ZZZ) décrite dans ce document et l’annexe Excel;

Comme toutes les données présentes dans le fichier structuré de Factur-X (factur-x.xml) EXTENDED sont
présentes dans la représentation lisible PDF qui sert d’enveloppe à la facture, le destinataire peut utiliser ou
pas les données additionnelles présentes au-delà du profil EXTENDED-CTC-FR puisqu’il en dispose de toute
façon sous forme lisible, si nécessaire.

4.2.2 L’implémentation dans les syntaxes UBL et UN/CEFACT CII exige une description spécifique

Les syntaxes UBL et UN/CEFACT CII ont leur propre sémantique. Elles sont un ensemble de données, bien plus
riche que la Norme EN 16931, organisées aussi par groupes et sous-groupes de données, avec leurs propres
cardinalités.

La conséquence est que l’implémentation des 2 profils EN 16931 et EXTENDED-CTC-FR en UBL et en
UN/CEFACT CII est le résultat d’un mapping devant faire face à certains écarts sémantiques. C’est pourquoi la
correspondance d’un XPATH à chaque donnée du modèle sémantique n’est pas suffisante pour décrire
l’implémentation en XML;

Il est donc aussi nécessaire de décrire l’implémentation des 2 profils dans chacune des deux syntaxes, et de
surcroît par profil, puisque la structure des données peut différer au niveau des cardinalités d’un profil à
l’autre;

Ces écarts sémantiques ont conduit à choisir la version D22B pour l’UN/CEFACT CII au lieu de la version D16B
initialement utilisée lors de la publication de la Norme EN 16931 en 2017, parce que la version D16B ne
permettait pas de respecter la cardinalité 0..n du BG-3 (bloc de référence à une facture antérieure), nécessaire
en cas d’avoir se référant à plusieurs factures;
AFNOR XP Z12-0122025-11

_Source: `c:\Users\g.baudrit\source\repos\gbaudrit\conf-aimer-votre-llm\demo\ctxc-sample-spec\with-ctxc\spec/afnor 1.2/XP_Z12-012/XP_Z12-012.pdf` (page:19/page:19)_

### E-79f0e6b48b36

XP Z12-012 – Formats et Profils des messages Factures et Statuts de cycle de vie,
constitutifs du socle minimal applicable à la Réforme Facture Électronique en France

18 
4.3 Description sommaire de la structure sémantique des données des 2 profils

4.3.1 Le profil EN 16931

Le profil EN 16931 est tout d’abord construit sous hypothèse d’une facture mono commande et mono
livraison.

Les Parties potentiellement en présence sont les suivantes, au nombre de 5 uniquement :

• Un VENDEUR (BG-4), présence obligatoire une fois (cardinalité 1;;1), qui est l’émetteur de la facture
(ou celui pour le compte de qui la facture est émise, ceci incluant l’autofacturation); C’est surtout la
Partie qui inscrit la transaction en Produits dans ses comptes et qui en général collecte la TVA présente
dans la facture.

• Un ACHETEUR (BG-7), présence obligatoire une fois (cardinalité 1..1), qui est en général le destinataire
de la facture, mais surtout celui qui porte la charge dans ses comptes et peut déduire la TVA présente
dans la facture.

• Un « Livré à » (BG-13), adresse de livraison, optionnelle présente une fois maximum (cardinalité 0..1),
qui permet de désigner où les biens sont livrés ou bien où les services sont exécutés. En cas d’absence
l’adresse de livraison est l’adresse de l’ACHETEUR; Pour rappel, en France, l’adresse de livraison de
biens est obligatoire si elle est différente de l’adresse de l’ACHETEUR (article 242 nonies A 7bis de
l’annexe II du CGI);

• Un BÉNÉFICIAIRE (BG-10), optionnel et présent une fois maximum (cardinalité 0..1), qui est celui à
qui la facture est censée être payée. Ce BÉNÉFICIAIRE est renseigné UNIQUEMENT s’il est différent du
VENDEUR (ce qui se repère par leurs identifiants légaux respectifs). D’ailleurs, ce BÉNÉFICIAIRE n’est
désigné que par son nom, son Identifiant légal et un identifiant privé.

• Un REPRÉSENTANT FISCAL DU VENDEUR (BG-11), optionnel et présent une fois maximum
(cardinalité 0..1), qui est obligatoire si le VENDEUR est représenté fiscalement. A NOTER qu’en cas de
VENDEUR faisant partie d’un groupement d’ASSUJETTI UNIQUE, l’Assujetti Unique, tête de pont du
groupement, doit être identifié dans ce bloc de données (et donc sa dénomination sociale, son numéro
de TVA intracommunautaire et son adresse postale). Par ailleurs, son numéro de SIREN doit être
renseigné en utilisant l’identifiant privé du Vendeur (BT-29), avec le qualifiant 0231.

L’ACHETEUR et le VENDEUR disposent de nombreuses informations pour les définir, à savoir :

• Dénomination sociale et Nom commercial

• Identifiant légal, Numéro de TVA intracommunautaire

• Identifiant privé, qualifié car se rapportant à un référentiel. Par exemple un GLN est un identifiant
qualifié avec le code 0188. Pour ceux qui souhaitent ajouter un numéro de SIRET, le qualifiant est 0009.
Pour un Code_Routage, le qualifiant est 0224; Pour le numéro de SIREN de l’assujetti unique, le code
est 0231.

• Une adresse postale

• Un bloc de données de contact

• UNE ADRESSE ÉLECTRONIQUE NORMALISÉE, qui pour le destinataire (l’ACHETEUR en général) est
l’adresse électronique à laquelle il souhaite recevoir sa facture (adresse sous la forme SIREN_XXX
référencée dans l’Annuaire PPF); Pour l’émetteur (le VENDEUR en général), c’est l’adresse
électronique à laquelle il souhaite recevoir ses statuts de cycle de vie. Ces adresses électroniques sont
les données nécessaires à l’échange des factures au travers d’un réseau de Plateformes Agréées
interopérées. Elles sont donc obligatoires dans les factures (règle de gestion BR-FR-12 et BR-FR-
13) et doivent donc être intégrés dans les référentiels clients / fournisseurs des solutions de gestion
des entreprises au même titre que l’identifiant légal, la dénomination sociale, l’adresse postale, <
AFNOR XP Z12-0122025-11

_Source: `c:\Users\g.baudrit\source\repos\gbaudrit\conf-aimer-votre-llm\demo\ctxc-sample-spec\with-ctxc\spec/afnor 1.2/XP_Z12-012/XP_Z12-012.pdf` (page:20/page:20)_

### E-2d2a5ed63c9e

XP Z12-012 – Formats et Profils des messages Factures et Statuts de cycle de vie,
constitutifs du socle minimal applicable à la Réforme Facture Électronique en France

19 
Il existe ensuite de nombreuses références, de niveau document, qui permettent de faire face déjà à un grand
nombre de situations :

• Une référence acheteur (BT-10) : à la main de l’ACHETEUR, et qui lui sert normalement à orienter les
factures dans son organisation interne. C’est donc souvent un numéro de Business Unit, une référence
de service, une boîte postale interne, <

• Une référence de Bon de Commande générée par l’ACHETEUR (BT-13) : donnée souvent exigée pour
tous les processus d’achat qui passe par la génération d’un Bon de Commande (Purchase Order),
transmis au moment de la commande, et pas après la livraison ou la facturation. Pour rappel, en
vertu de l'article L. 441-9 du Code de commerce, la facture doit mentionner le numéro du bon de
commande lorsqu'il a été préalablement établi par l'acheteur.

• Une référence de Contrat (BT-12) : nécessaire en particulier pour les services récurrents gérés sans
numéro de bon de commande (fluides, téléphonie, <);

• Une référence à la ou les factures antérieures (BG-3, BT-25), essentiellement pour les AVOIRS ou les
factures rectificatives. Cette donnée peut aussi être utile en cas de facture finale après facture
d’acompte (nécessitant une donnée additionnelle, cf profil EXTENDED-CTC-FR).

• Une référence d’Avis d’Expédition (BT-16) : qui annonce la livraison et sert souvent de Bon de
Livraison.

• Une référence de Bon de Réception (BT-15) : qui peut être utile dans des processus de chaine
d’approvisionnement très intégrés;

• Une référence de Bon de Vente (BT-14) : parfois confondue avec le Bon de Commande; C’est la
référence de commande générée par le VENDEUR, qui lui permet de suivre la transaction; C’est une
donnée très souvent utilisée en achat auprès de fournisseurs de frais généraux, ou d’achat en ligne;

• Une référence d’Objet facturé (BT-18) : qui est une donnée où le type d’objet facturé est codifié dans
une liste qu’il faut respecter. Ceci peut être utile pour gérer des références propres à certaines activités
(un numéro de plaque d’immatriculation, un numéro de compteur, un numéro de téléphone facturé,
une référence interne de client ou de dossier, <);

• Une référence de Projet (BT-11) : peut être utilisée par exemple pour identifier un chantier dans le
secteur de la construction.

• Une référence d’Appel d’Offres ou de numéro de Lot (BT-17).

• Une référence comptable de l’ACHETEUR (BT-19), par exemple pour permettre une affectation en
comptabilité analytique; Cette donnée doit donc être fournie par l’ACHETEUR;

• Une période de facturation (BG-14), utile notamment pour tous les services d’abonnements ou pour
les remises de fin d'année pour lesquels il est nécessaire de préciser une période de référence.

Ensuite, ce profil contient les informations classiques d’une facture :

• Numéro (BT-1), Date (BT-2), Type (BT-3) : un code permettant de qualifier le type de facture (facture
commerciale, avoir, facture rectificative, facture d’acompte, facture autofacturée, <)

• Devise (BT-5) : a priori la devise de facture s’applique à tous les prix et montants; La seule exception
est le montant total de TVA qui peut aussi être présenté dans une autre Devise : la Devise de
comptabilité (BT-6); C’est pourquoi il existe 2 données pour le montant total de TVA (l’objectif étant
que l’une des 2 soit l’EURO car l’Administration fiscale exige le montant de TVA en EURO) :

✓ Le Montant Total de TVA dans la Devise de la facture : BT-110 (devise égale à BT-5).

✓ Le Montant Total de TVA dans la Devise de comptabilisation : BT-111 (devise égale à BT-6).

• Date d’échéance (BT-9), sachant qu’il est aussi possible de donner des informations relatives aux
conditions de paiement en BT-20, via un texte libre qui peut donc contenir par exemple « Paiement 30
jours net ».
AFNOR XP Z12-0122025-11

_Source: `c:\Users\g.baudrit\source\repos\gbaudrit\conf-aimer-votre-llm\demo\ctxc-sample-spec\with-ctxc\spec/afnor 1.2/XP_Z12-012/XP_Z12-012.pdf` (page:21/page:21)_

### E-9d11ae910281

XP Z12-012 – Formats et Profils des messages Factures et Statuts de cycle de vie,
constitutifs du socle minimal applicable à la Réforme Facture Électronique en France

20 
• Date d’exigibilité de la TVA (BT-7), qui n’est pas utilisée comme ceci en France, mais sous la forme d’un
évènement en BT-8, pour indiquer si la TVA est exigible à la date de facture ou la date de livraison
(TVA au débit) ou bien à la date de paiement (TVA à l’encaissement); La BT-8 est obligatoire
uniquement pour les factures de services pour lesquelles le VENDEUR a opté pour les débits. Sinon,
elle peut être présente ou non.

• Les instructions de paiement (BG-16), qui permettent d’abord d’indiquer le moyen de paiement
souhaité et la référence de paiement attendue, puis de renseigner un ou plusieurs comptes bancaires
à payer par virement, mais aussi des informations relatives à un prélèvement (la facture faisant office
de notification), et enfin à des informations de carte bancaire si ce moyen est utilisé, uniquement à des
fins de rapprochement (seule une partie du numéro de carte seulement est fournie).

• Et enfin une Note (BG-1), répétable, constituée d’un code sujet pour qualifier son utilisation, et d’un
texte libre. Ceci permet de compléter de données annexes, souvent peu exploitables (car sous forme
de texte tout juste qualifié et pas codifié). Ceci permet de loger tout ce qui ne rentre pas dans la Norme
EN16931, mais avec le risque d’une lisibilité beaucoup moins pertinente que la représentation lisible
habituelle en papier ou en PDF. C’est en particulier pour cela que le format Factur-X a été conçu : allier
lisibilité habituelle et données structurées minimum réglementaire utiles.

Le profil est complété ensuite par des données de lignes et des données de remises et charges de niveau
Document (qui peuvent être vues comme des lignes particulières).

Tout d’abord les lignes, qui sont un ensemble de données assez réduites :

• Numéro de ligne (BT-126) et Note de ligne (BT-127)

• Identifiant d‘Objet Facturé (BT-128), référence d’entête aussi utilisable en ligne.

• Référence de la ligne du Bon de commande auquel se rapporte la ligne de facturation (BT-132). Donc
il n’y a pas de référence à la ligne de la réception ou de la livraison par exemple, qui est utile pour le
rapprochement dit « 3 points ».

• Référence comptable de l’ACHETEUR (BT-133), qui peut donc être fournie à la ligne.

• Identification de l’article :

✓ Nom (BT-153), Description (BT-154)

✓ Codes articles du VENDEUR (BT-155), de l’ACHETEUR (BT-156), voire identifiant standard à
qualifier (BT-157), par exemple un numéro GTIN.

✓ Un ou plusieurs identifiants de classification de l’article (référentiel UNSPSC par exemple), avec
une liste de référentiels disponible (cf liste de codes UNTDID 7143).

✓ Pays d’origine (BT-159)

✓ Attributs (BG-32), répétable, bloc de 2 données à savoir une qualification de la donnée, puis sa
valeur. Par exemple COULEUR ; ROUGE; C’est une façon de renseigner à peu près n’importe quoi,
mais sous forme de texte libre « nature de l’information / valeur de l’information ». Ce bloc
attribut peut s’enrichir en profil EXTENDED de Factur-X d’un code qualifiant la donnée de façon
plus standardisée.

• Détermination du Prix Unitaire HT :

✓ Prix Unitaire Brut (BT-148), Rabais (BT-147) sur Prix Unitaire Brut

✓ Prix Unitaire Net (BT-146) qui est celui qui est obligatoire pour la Norme EN16931

✓ Quantité de base du Prix Unitaire (BT-149), parce qu’il est possible de définir des Prix Unitaires
pour des quantités données (par exemple un Prix pour 1 000 vis). Cette quantité est associée à
une unité de mesure de la quantité (BT-150 : pièce, kg, litre, kw, < la liste des unités est normée
et très longue). Ceci permet notamment de gérer des sujets d’arrondis quand les prix unitaires
sont très faibles ou nécessitent beaucoup de décimales (un prix pour 1 000 permet de gagner en
précision : par exemple 2 euros pour 1 000 vis plutôt que 0,002€ par vis);
AFNOR XP Z12-0122025-11

_Source: `c:\Users\g.baudrit\source\repos\gbaudrit\conf-aimer-votre-llm\demo\ctxc-sample-spec\with-ctxc\spec/afnor 1.2/XP_Z12-012/XP_Z12-012.pdf` (page:22/page:22)_

### E-100760e2d4d5

XP Z12-012 – Formats et Profils des messages Factures et Statuts de cycle de vie,
constitutifs du socle minimal applicable à la Réforme Facture Électronique en France

21 
• Quantité facturée (BT-129) et son unité (BT-130)

• Remises et charges de lignes qui sont 2 blocs distincts, répétables et constitués chacun :

✓ Du montant de la Remise / Charge (BT-136 / BT-141)

✓ D’une assiette (base) et d‘un taux, donnée facultative

✓ D’un motif en code ou en texte, l’un des deux étant obligatoire.

• D’un montant total HT de ligne (BT-131)

• D’un code TVA et taux; La TVA est en effet encodée avec un code de catégorie (Standard, Exemption,
Autoliquidation, < cf chapitre dédié ci-dessous), et d‘un taux en pourcentage.

A ceci s’ajoutent donc des Remises et Charges de niveau document, qui sont définies de façon semblable :

• Un montant de Remises ou Charges (BT-92 / BT-99)

• Une base et un taux (données facultatives)

• Un Motif en code et / ou en texte (l’un des deux au moins étant obligatoire).

• Une catégorie et un taux de TVA

Ces Remises ou Charges de niveau document peuvent être vues comme des lignes particulières (surtout les
charges); Leur somme est d’ailleurs suivie de façon distincte en pied de facture;

Le profil est complété par les données pied de facture et pied de TVA dont les règles de calcul sont décrites
dans la suite de ce document :

• Le pied de TVA contient par catégorie et taux de TVA

✓ la base HT sur laquelle le taux va s’appliquer (BT-116),

✓ le taux de TVA applicable (0 si pas de TVA), (BT-119),

✓ le montant de TVA (BT-117) dans la devise de la facture (BT-5),

✓ En cas d’exonération, le motif d’exonération sous forme de texte ou de code (les codes VATEX
gérés par la Commission Européenne).

• Les totaux de la facture :

✓ A commencer par des sous-totaux : Total HT des lignes (BT-106), Total HT des Remises de
Document (BT-107), Total HT des Charges de Documents (BT-108)

✓ Puis les totaux permettant d’arriver au TTC : Total HT de la facture (BT-109), Total TVA (BT-110,
en devise de facture et BT-111 en devise de comptabilisation BT-6), Total TTC (BT-112).

✓ S’ajoutent ensuite des données permettant de définir le Montant à payer : Montant déjà payé (BT-
113), par exemple pour des acomptes, Montant arrondi (BT-114) car il arrive qu’on arrondisse à
l’euro au-dessus, et enfin le Montant NET à PAYER (BT-115).

Le profil permet enfin de joindre des Documents Justificatifs additionnels (BG-24), constitué d’un identifiant,
d’une description, puis d’un fichier, soit en donnant un lien d’accès (URL), soit joint, en général encodé en
base64.

4.3.2 Le profil EXTENDED-CTC-FR

L’étude des cas d’usage montre que la Norme EN 16931 ne permet pas d’adresser tout l’existant en matière
d’information apparaissant dans les factures, puisque qu’elle a été conçue pour adresser les besoins essentiels.

Il est donc apparu nécessaire de définir un profil étendu, dénommé EXTENDED-CTC-FR. Ce profil a vocation à
vivre et se maintenir, sous contrainte forte de compatibilité ascendante de façon que l’évolution du profil
n’oblige pas ceux qui n’ont pas besoin des évolutions à modifier leurs chaines de traitements;
AFNOR XP Z12-0122025-11

_Source: `c:\Users\g.baudrit\source\repos\gbaudrit\conf-aimer-votre-llm\demo\ctxc-sample-spec\with-ctxc\spec/afnor 1.2/XP_Z12-012/XP_Z12-012.pdf` (page:23/page:23)_

### E-a2e2685bf320

XP Z12-012 – Formats et Profils des messages Factures et Statuts de cycle de vie,
constitutifs du socle minimal applicable à la Réforme Facture Électronique en France

22 
Pour ce faire, les Plateformes Agréées et les Solutions Compatibles des entreprises intégrant des
fonctionnalités de validation de facture DOIVENT utiliser la dernière version des outils de validation publiés
pour chacun des profils.

Ce profil EXTENDED-CTC-FR a ajouté quelques nouveaux acteurs qui jouent un rôle dans la transaction
commerciale et le traitement des factures, ce qui rend parfois nécessaire leur désignation dans les factures. Il
s’agit de :

• L’AGENT d’ACHETEUR (EXT-FR-FE-BG-01), qui peut agir pour le compte de l’ACHETEUR, souvent
dans la phase de commande, et donc de validation ou pré-validation (« Visée ») des factures.

• Le PAYEUR (EXT-FR-FE-BG-02), qui peut être un tiers différent de l’ACHETEUR; Ce peut être une filiale
ou la société mère d’un groupe, mais aussi un client final en cas de sous-traitance avec paiement direct.

• L’AGENT de VENDEUR (EXT-FR-FE-BG-03), qui peut agir pour le compte du vendeur (un distributeur
par exemple), et peut jouer un rôle dans le processus de création et de validation des factures à
émettre, voire dans le suivi des statuts de cycle de vie.

• « L’ADRESSÉ À » (EXT-FR-FE-BG-04), qui est plus justement nommé dans les standards le « Facturé à »
est la Partie à qui la facture est transmise parce qu’il est en charge de son traitement pour le compte
de l’ACHETEUR; Toutefois, l’utilisation de plusieurs adresses de facturation électroniques pour la
réception de factures permet de ne pas utiliser cette capacité à transmettre les factures à un tiers, mais
juste de permettre à ce tiers de traiter les factures adressées à l’ACHETEUR sur une adresse de
facturation électronique (une boîte aux lettres de réception des factures) dont la gestion est confiée à
ce tiers par l’ACHETEUR; Toutefois, lorsque l’ADRESSÉ [ est nommé dans la facture, cela permet à la
PA-R (de réception) de gérer des droits de délégation de façon plus ciblée pour lui permettre d’avoir
accès à la facture et aux actions de traitement pour lesquelles il lui a été donné délégation. Ce tiers peut
aussi permettre de satisfaire aux exigences de l’article 441-9 du Code du Commerce qui impose que
l’adresse postale de l’entité qui reçoit et traite la facture pour le compte de l’ACHETEUR soit renseigné
(adresse de facturation si différente de l’adresse du client (ACHETEUR), qu’il faut interpréter comme
adresse postale de facturation).

• Le FACTURANT (EXT-FR-FE-BG-05), qui est le tiers qui crée et émet la facture pour le compte du
VENDEUR, sous mandat de facturation.

Pour tous ces nouveaux acteurs, la structure des données de description est la même et proche de celles du
VENDEUR et de l’ACHETEUR, sauf que seule la Raison Sociale est obligatoire (pas l’adresse postale), et qu’il a
été ajouté un « CodeRole ¬ permettant de mieux qualifier le rôle du tiers; C’est en particulier nécessaire pour
le BÉNÉFICIAIRE, qui a été aligné sur ces acteurs en termes de données disponibles. Le code Rôle « DL »
permet ainsi d’indiquer que le BÉNÉFICIAIRE est un Affactureur.

De façon à permettre l’utilisation de factures multi-commandes et multi-livraisons, la plupart des références
de niveau Document ont été ajoutées à la ligne :

• Numéro de Bon de commande (EXT-FR-FE-135)

• Référence à la facture antérieure (une par ligne), avec la possibilité d’ajouter le type de facture
antérieure, ce qui permet de faire des reprises d’acompte en ligne et d‘indiquer qu’il s‘agit d’une
reprise d’acompte pour permettre une juste comptabilisation automatique;

• Adresse et date de livraison à la ligne

• Avis d’expédition, Bon de réception, Bon de Vente à la ligne, avec à chaque fois la possibilité de
renseigner le numéro de ligne de ces documents qui correspond à la ligne de facturation.

• Un code sujet à la note de ligne, associée à un changement de cardinalité (0..1) permettant l’utilisation
de plusieurs notes de ligne de facture.
AFNOR XP Z12-0122025-11

_Source: `c:\Users\g.baudrit\source\repos\gbaudrit\conf-aimer-votre-llm\demo\ctxc-sample-spec\with-ctxc\spec/afnor 1.2/XP_Z12-012/XP_Z12-012.pdf` (page:24/page:24)_

### E-d8c58ef3d49d

XP Z12-012 – Formats et Profils des messages Factures et Statuts de cycle de vie,
constitutifs du socle minimal applicable à la Réforme Facture Électronique en France

23 
Il a aussi été ajouté quelques données, notamment du fait de leur utilité pour le secteur public, ou pour
respecter les exigences de la réforme :

• Une donnée de type de contrat (EXT-FR-FE-01), venant compléter le numéro de contrat (BT-12)

• Un changement de cardinalité de la BT-46 (0..n au lieu de 0..1) : identifiant privé de l’ACHETEUR,
permettant de renseigner l’identifiant privé habituel, mais aussi un numéro de SIRET, un
Code_Routage.

• Un codetype de la facture antérieure (BG-3), (EXT-FR-FE-02).

• Le changement de cardinalité de l’identifiant d’objet facturé en ligne (BT-128) et au niveau Document
(BT-18), permettant de disposer de plusieurs références nécessaires dans certains cas d’usage;

Pour satisfaire certaines exigences opérationnelles et certains cas d’usage, les données suivantes ont aussi été
ajoutée :

• Pour permettre l’établissement de factures avec différentes raisons d’exemption, plus généralement
de distinction plus détaillée de la ventilation de TVA :

✓ Une raison d’exemption de TVA en texte (EXT-FR-FE-178) et en code (EXT-FR-FE-179), qui pourra
être utilisée pour préciser un contexte TVA à reprendre en ventilation de TVA; Il s’agit d’une
anticipation de la révision de la Norme nécessaire dès aujourd’hui;

✓ La suppression des règles BR-S-10 et BR-Z-10 pour ce profil EXTENDED-CTC-FR, de façon à
permettre l’utilisation de ces données en ligne et des données correspondantes en ventilation de
TVA (BT-120 et BT-121)

✓ La mise à jour des règles de calcul de ventilation de TVA (règles de TVA BR-S-8, BR-Z-8, <)
supprimées du profil EXTENDED-CTC-FR avec ajout de règles modifiées applicables uniquement
sur le profil EXTENDED-CTC-FR.

• Pour la gestion des transactions internationales : les conditions de livraison (EXT-FR-FE-BG-14) que
sont

✓ les codes INCOTERMS (EXT-FR-FE-185).

✓ et le nom du lieu où se matérialise le transfert de propriété (EXT-FR-FE-186).

• Pour mieux qualifier les attributs d’articles deux données ont été ajoutées (aussi présentes dans la
révision de la Norme EN 16931) :

✓ Un code permettant de qualifier le type d’attribut à la place ou en complément de sa dénomination
(EXT-FR-FE-159), à choisir dans la liste 6313.

✓ Une Valeur d’attribut (EXT-FR-FE-160) associée à une unité de mesure (EXT-FR-FE-161), en lieu
et place d’une valeur en texte (BT-161).

✓ Par exemple, ceci permet de codifier un attribut de « 25 g de CO2 » :

➢ Code (EXT-FR-FE-159) : BRL (Dioxyde de Carbone)

➢ Une Valeur mesurée (EXT-FR-FE-160) : 25

➢ Une unité de mesure EXT-FR-FE-161) : GRM (gramme)

• Pour la gestion des articles composites (par exemple un livre-jouet), des kits, des besoins de sous-
totaux ou de regroupement d’information de ligne, une possibilité de gérer des sous-lignes :

✓ Un identifiant de ligne Parent (EXT-FR-FE-162) permettant de lier une ligne de facture à une autre
pour indiquer leur dépendance (notion de sous-ligne)

✓ Un sous-type de ligne (EXT-FR-FE-163), permettant de distinguer des lignes d’information ou de
regroupement, dont les données ne sont pas reprises dans les calculs de totaux de factures, avec
des lignes dites de « Détail ¬ qui sont, avec les lignes n’utilisant pas ce qualifiant, les lignes de
facturation intervenant dans les calculs et transmis au PPF (flux 1 et flux 10.1).
AFNOR XP Z12-0122025-11

_Source: `c:\Users\g.baudrit\source\repos\gbaudrit\conf-aimer-votre-llm\demo\ctxc-sample-spec\with-ctxc\spec/afnor 1.2/XP_Z12-012/XP_Z12-012.pdf` (page:25/page:25)_

### E-851b0bfcb92e

XP Z12-012 – Formats et Profils des messages Factures et Statuts de cycle de vie,
constitutifs du socle minimal applicable à la Réforme Facture Électronique en France

24 
✓ La création de règles de gestion pour tenir compte de cette possibilité de sous-ligne dans les
totaux.

✓ L’utilisation de sous-lignes est précisée en chapitre 4.4.

• Pour la gestion des factures multi-vendeurs, créés par ou pour le compte d’intermédiaires transparent
agissant pour le compte de plusieurs Vendeurs, à destination d’un ACHETEUR unique :

✓ Un Vendeur en ligne (EXT-FR-FE-BG-12), contenant les mêmes types d’information que le
VENDEUR (BG-4), sauf le bloc d’information de contact;

✓ Un Montant de TVA à la ligne (EXT-FR-FE-181) dans la devise de la facture (BT-5)

✓ Un Montant de TVA à la ligne (EXT-FR-FE-182) dans la devise de comptabilisation (BT-6)

✓ Un total TTC de ligne (EXT-FR-FE-184)

✓ Un code d’exigibilité de TVA (EXT-FR-FE-185, Débits / Encaissements), équivalent de la BT-8 au
niveau de la facture.

✓ L’implémentation des factures multi-vendeurs est précisée en chapitre 4.4.

L’autre ajout de ce profil est la modification de certaines règles de gestion :

• pour permettre une tolérance de 0,01 centime par ligne ou remise ou charge de niveau Document dans
les calculs de sommes en pied de facture ou en pied de TVA,

• pour permettre une facture réunissant des lignes hors scope (Catégorie TVA = O) et d’autres lignes (ce
que la Norme EN 16931 interdit pour l’instant), les règles BR-O-2, BR-O-3, BR-O-4, BR-O-11, BR-O-
12, BR-O-13, BR-O-14 ont été supprimées pour le profil EXTENDED-CTC-FR.

Toutes les évolutions, tous les ajouts de données, remplacement / suppression de règles de gestion du profil
EXTENDED-CTC-FR sont aussi répliqués de la même façon dans le profil EXTENDED de Factur-X.

4.3.3 Évolution de la Norme

Dans le cadre des travaux européens du CEN TC434, la Norme EN 16931 va faire l’objet d’une évolution.
Celle- ci aura pour conséquence essentielle d’intégrer les évolutions du profil EXTENDED-CTC-FR dans la
norme sauf l’ajout des Parties additionnelles qui restera du domaine des Extensions;

Quand elle sera publiée et opérationnelle, les profils décrits dans ce document seront amenés à évoluer. En
attendant, les évolutions qui s’avèrent nécessaire pour la mise en œuvre opérationnelle de la réforme facture
électronique en France seront ajoutées dans les prochaines versions dans le profil EXTENDED-CTC-FR (et
EXTENDED de factur-x).

4.3.4 Profil EXTENDED de Factur-X, et Évolution du profil EXTENDED-CTC-FR

Le profil EXTENDED de factur-X met à disposition un très grand nombre de données additionnelles. Il a été
conçu par le FNFE-MPE en collaboration avec le FeRD (Forum Allemand), et s’appuie sur les pratiques des
entreprises en matière d’échange EDI (EDIFACT notamment).

Pour son utilisation, il faut se procurer la documentation Factur-X, qui intègre les composants de validation.
Ce profil permettra aux équipes de maintenance du profil EXTENDED-CTC-FR de trouver les éléments
nécessaires pour adresser certains besoins spécifiques relevés dans le cadre de l’inventaire des cas d’usage;
AFNOR XP Z12-0122025-11

_Source: `c:\Users\g.baudrit\source\repos\gbaudrit\conf-aimer-votre-llm\demo\ctxc-sample-spec\with-ctxc\spec/afnor 1.2/XP_Z12-012/XP_Z12-012.pdf` (page:26/page:26)_

### E-eed7a8be6b2b

XP Z12-012 – Formats et Profils des messages Factures et Statuts de cycle de vie,
constitutifs du socle minimal applicable à la Réforme Facture Électronique en France

25 
4.4 Points d’attention particuliers

4.4.1 Types de données

Chaque donnée du modèle sémantique correspond à un type de données qui en détermine le format, lui-même
basé sur un des quatre types primitifs suivants : Binary (binaire), Date, Décimal, String (texte).

Les types de données sont alors les suivants (pour plus de détails, voir chapitre 6.5 de la Norme Sémantique
EN 16931-1:2019 (E)) :

• Montant (Amount) : il s’agit d’un type « Décimal » avec 2 chiffres après la virgule maximum, sans
séparateur de millier, et avec le « . » comme séparateur décimal. Il peut être complété d’un attribut
« Devise ¬, si différent de la devise en entête; L’UBL exige toujours la Devise, le CII ne l’exige que
lorsqu’un montant peut être exprimé dans une autre devise que celle de la facture (le montant de TVA
BT-111 en devise de comptabilisation (BT-6) si différente de la devise de la facture (BT-5)). Exemple
10000.34

• Montant de prix unitaire : il s’agit d’un type « Décimal » sans séparateur de millier, et avec le « . »
comme séparateur décimal; Il peut être complété d’un attribut « Devise », si différent de la devise en
entête; Exemple 1000;3454; Il n’y a pas de règle de nombre de décimales, mais l’usage et surtout la
révision de la Norme EN 16931 limitent les prix unitaires à 4 décimales.

• Quantité (Quantity) : il s’agit d’un type « Décimal » sans séparateur de millier, et avec le « . » comme
séparateur décimal. Exemple 10000.85476. Il n’y a pas de règle de nombre de décimales, mais l’usage
et surtout la révision de la Norme EN 16931 limitnt les quantités à 4 décimales.

• Pourcentage (Percentage) : il s’agit d’un type « Décimal » sans séparateur de millier, et avec le « . »
comme séparateur décimal. Pour appliquer ce pourcentage au montant auquel il s’applique, il
convient, dans les calculs, de diviser la valeur du pourcentage indiqué par 100. Pour un taux de TVA à
20%, la valeur est donc de 20; Exemple 24;1234 pour un pourcentage de 24,1234 %; Il n’y a pas de
règle de nombre de décimales, mais l’usage et surtout la révision de la Norme EN 16931 limitent les
pourcentages à 2 décimales.

• Identifiant (Identifier) : il s’agit d’un type potentiellement composé de 3 champs texte (décrits dans
la documentation détaillée) :

✓ La valeur de l’identifiant (texte); Par exemple FR13456789321 pour un n° de TVA
intracommunautaire

✓ Un Schéma d’identification (Scheme Identifier), donnée obligatoire si plusieurs Schémas
d’Identification sont possibles permettant de qualifier le référentiel de l’identifiant; Par exemple,
le qualifiant « VA ¬ permet de préciser que l’identifiant est un numéro de TVA
intracommunautaire en CII. En UBL, il faut utiliser « VAT ».

✓ Une version du Schéma d’identification (Scheme version Identifier), donnée facultative en texte

• Référence de Document (Document Reference) : il s’agit d’une donnée de type texte

• Date : les dates sont représentées sous la forme AAAAMMJJ en UN/CEFACT CII et AAAA-MM-JJ en UBL

• Texte : texte libre, en type texte

• Code : il s’agit d’un code en type texte, qui est accompagné d’un attribut identifiant la liste dont il
provient, et potentiellement de la version de la liste et de l’identifiant de l’agence publiant la liste;

• Objet Binaire (Binary Object) : il s’agit d’un type potentiellement composé de 3 champs :

✓ Le contenu, obligatoire, en donnée binaire,

✓ Le type de fichier (Mime Code), en texte, à prendre dans une liste prédéfinie,

✓ Le nom du fichier (Filename), en texte.
AFNOR XP Z12-0122025-11

_Source: `c:\Users\g.baudrit\source\repos\gbaudrit\conf-aimer-votre-llm\demo\ctxc-sample-spec\with-ctxc\spec/afnor 1.2/XP_Z12-012/XP_Z12-012.pdf` (page:27/page:27)_

### E-6f182011f79c

XP Z12-012 – Formats et Profils des messages Factures et Statuts de cycle de vie,
constitutifs du socle minimal applicable à la Réforme Facture Électronique en France

26 
4.4.2 Gestion des données de profils et cadre de facturation

De façon à organiser le traitement des factures, il est nécessaire qu’elles contiennent des informations
identifiant le profil et le processus transactionnel sous-jacent.

Ceci est réalisé au travers de 2 données essentielles :

• BT-24 : type de profil, qui identifie le profil du message, à distinguer entre profils EN
16931, EXTENDED-CTC-FR et les profils de Factur-X :

✓ Profil EN16931 : urn:cen.eu:en16931:2017

✓ Profil EXTENDED-CTC-FR :
urn:cen.eu:en16931:2017#conformant#urn.cpro.gouv.fr:1p0:extended-ctc-fr

✓ Pour Factur-x :

➢ Pour le profil BASIC WL : urn:factur-x.eu:1p0:basicwl

➢ Pour le profil BASIC : urn:cen.eu:en16931:2017#compliant#urn:factur-x.eu:1p0:basic

➢ Pour le Profil EN 16931 : urn:cen.eu:en16931:2017

➢ Pour le Profil EXTENDED :
urn:cen.eu:en16931:2017#conformant#urn:factur-x.eu:1p0:extended

• BT-23 : indique le processus sous-jacent et est utilisé en France pour codifier à la fois certains
processus et le fait que la facture soit une facture de Biens, de Services, ou Mixte c’est-à-dire composée
de lignes de ventes de Biens et de lignes de vente de Services indépendantes, les unes n’étant pas
accessoire aux autres. Cette caractéristique est codifiée respectivement par la première lettre du Cadre
de facturation B, S, M. La règle BR-FR-08 indique les valeurs possibles de ce cadre de facturation.

Il est aussi nécessaire de déterminer si une facture relève d’un traitement « e-invoicing » ou e-reporting de
Vente B2B internationale, ou e-reporting B2C ou hors réforme, < En effet, il n’existe pas de règle simple
permettant de déterminer de façon certaine qu’une facture relève du « e-invoicing ».

Cette indication peut être codifiée dans le canal de transmission des factures entre l’émetteur et sa Plateforme
Agréée, mais peut aussi l’être dans la facture elle-même. Dans ce cas, la règle à respecter est la BR-FR-20 qui
utilise une note avec le code sujet « BAR » et des valeurs codifiées à renseigner.

4.4.3 Gestion des Notes

Un certain nombre de mentions obligatoires ou conditionnellement obligatoires n’ont pas d’existence propre
dans le modèle EN 16931 et sont alors codifiées au travers d’une Note (texte en BT-22), avec un code sujet
dédié (en BT-21). Il en est de même pour les notes de ligne (Contenu : BT-127, code sujet : EXT-FR-FE-183).
Les règles BR-FR-05, BR-FR-06, BR-FR-07 indiquent la codification attendue.

Parmi l’ensemble des codes sujets, la liste ci-dessous détaille ceux à utiliser en fonction des sujets les plus
courants :

• AAB : Mention d’escompte;

• AAI : Information générale : des éléments en général en fond de page des factures papier.

• ABL : Information légale : par exemple N° registre des métiers, RCS.

• ACC : Clause de subrogation factoring.

• ADN : permet d’indiquer le fait que la facture relève des obligation B2G en France (valeur B2G, cf règle
BR-FR-CPRO-00).

• BAR : permet d’indiquer la nature du traitement attendu, cf Règle BR-FR-20.

• BLU : "Eco-participation (L. 541-10 du code de l'environnement)" ou "Eco-contribution DEEE". Peut
servir aussi à d'autres taxes dont l'écotaxe CUS : Information douanière.
AFNOR XP Z12-0122025-11

_Source: `c:\Users\g.baudrit\source\repos\gbaudrit\conf-aimer-votre-llm\demo\ctxc-sample-spec\with-ctxc\spec/afnor 1.2/XP_Z12-012/XP_Z12-012.pdf` (page:28/page:28)_

### E-ef9142c93653

XP Z12-012 – Formats et Profils des messages Factures et Statuts de cycle de vie,
constitutifs du socle minimal applicable à la Réforme Facture Électronique en France

27 
• DCL : déclaration du créateur de la facture, en cas de mandat de facturation : « facture établie par A au
nom et pour le compte de B ».

• PMT : Mention de l’indemnité forfaitaire de 40 € pour frais de recouvrement.

• PMD : Mention pénalités de retard.

• SUR : Remarques fournisseur.

• TXD : Mention de Membre d’Assujetti Unique.

4.4.4 Gestion des avoirs

Il y a 2 façons de gérer des avoirs :

• « Facture négative » : Il s’agit d’une facture dont le total TTC est négatif,

✓ soit parce que la facture contient des lignes négatives dont la somme est supérieure en valeur
absolue à la somme des lignes positives (cas notamment des factures finales avec reprise sur
acompte ou estimation comme les factures d’énergie, pour lesquelles il peut aussi arriver qu’une
facture n’ait que des lignes de reprises négatives),

✓ soit parce qu’elle ne contient que des lignes négatives et annule en général ainsi une facture (sauf
cas exceptionnel où il n’y a pas de lignes positives comme indiqué ci-dessus); Il s’agit donc d’un
avoir, qui doit faire référence à la facture ou à la période à laquelle il se rattache. Au niveau des
lignes, le prix unitaire est positif et ce sont les quantités qui sont négatives. Les règles de calcul
restent les mêmes et conduisent à avoir des lignes négatives, puis des totaux négatifs (y compris
le détail de TVA sur les bases HT et les montants de taxe). Dans ce cas, les montants des remises
et charges sont aussi inversés (donc négatifs). Les types de document (donnée BT-3) qui peuvent
ainsi faire l’objet de ce procédé sont ceux correspondant à des factures (il n’est donc pas autorisé
de construire des avoirs négatifs pour faire des factures).

• « Avoir » : ceci correspond aux documents « typés avoirs ¬ (comme 381, 261, <); Dans ce cas,
l’ensemble des montants totaux de lignes ou de pieds de page sont du même signe que la facture que
l’avoir annule, ce qui n’empêche pas d’avoir des lignes dont le montant total est négatif, comme c’est
possible sur une facture; Il n’est en revanche pas possible (autorisé suivant la norme sémantique)
d’avoir des avoirs négatifs, c’est-à-dire d’utiliser un avoir négatif pour annuler un avoir précédent
positif; Dans ce cas, il faut créer une facture référençant l’avoir; En revanche, il reste possible d’avoir
des Avoirs avec un total TTC négatif dès lors qu’il est le résultat de lignes positives et de lignes
négatives, ce qui se produit en particulier pour les avoirs annulant des factures négatives du fait de
lignes négatives l’emportant sur les lignes positives;

En France, la pratique la plus répandue est de codifier un avoir qui annule une facture par le type « avoir ».
Ainsi, l’ensemble des données de l’avoir est le même que celui de la facture qu’il annule; Les seules
modifications sont le numéro de facture d’avoir (qui doit suivre la séquence chronologique, comme les
factures), la date de l’avoir, et le numéro de facture que l’avoir annulé qui doit être renseigné, et la date
d’échéance potentiellement;

La représentation « facture négative » est utilisée lorsqu’elle résulte d’un calcul de facturation qui conduit à ce
résultat, du fait de reprises sur factures antérieures (estimation, acomptes, consignes, palettes, <);

Toutefois, il existe des pays en Europe qui pratiquent exclusivement la facture négative (même pour des avoirs
annulant uniquement une facture).
AFNOR XP Z12-0122025-11

_Source: `c:\Users\g.baudrit\source\repos\gbaudrit\conf-aimer-votre-llm\demo\ctxc-sample-spec\with-ctxc\spec/afnor 1.2/XP_Z12-012/XP_Z12-012.pdf` (page:29/page:29)_

### E-65f940d0b75b

XP Z12-012 – Formats et Profils des messages Factures et Statuts de cycle de vie,
constitutifs du socle minimal applicable à la Réforme Facture Électronique en France

28 
4.4.5 Règle de calcul

La règle de calcul des factures (hors factures B2C dans lesquelles le Prix Unitaire est souvent indiqué en TTC)
est la suivante :

• Au niveau de chaque ligne, le montant net de ligne (BT-131) est égal :

✓ au prix unitaire net (positif, BT-146), le cas échéant divisé par la quantité de base du prix BT-149
qui indique la quantité de chaque lot de produit vendu, multiplié par la quantité facturée (positive
ou négative, BT-129), arrondi à 2 décimales.

✓ diminué des montants de remises de ligne (BT-136), qui est déjà arrondi à 2 décimales,

✓ augmenté des montants de charges ou frais de ligne (BT-141), qui est déjà arrondi à 2 décimales.

✓ Cette règle de calcul n'est pas régie par une règle schematron car elle n'est pas requise par la
norme EN 16931 pour l’instant; Elle sera ajoutée dans la révision de la Norme avec une tolérance
pour gérer les problématiques d’arrondi;

✓ Il convient de noter aussi que l’unité de mesure de la quantité de base du Prix unitaire (BT-149)
DOIT être égale à l’unité de la quantité facturée (BT-130), pour que le calcul soit juste. En effet, si
le prix unitaire est par gramme et que la quantité mesurée en kilogramme, le calcul ci-dessus
serait faux d’un facteur 1 000;

• Ensuite, les totaux au niveau document s’organisent de la façon suivante, et sont vérifiés dans le cadre
des règles de gestion de la Norme EN 16931 (BR-XX) :

✓ La Somme des montants nets de ligne (BT-106), égale à la somme des montants nets de lignes
calculés ci-dessus (BT-131),

✓ La Somme des remises au niveau du document (BT-107), égale à la somme des montants des
remises au niveau du document (BT-92), voir BR-CO-11.

✓ Somme des charges ou frais au niveau du document (BT-108) égale à la somme des montants de
charges ou frais au niveau du document (BT-99), voir BR-CO-12.

✓ Le total hors taxes de la facture (BT-109), est égal (BR-CO-13) :

➢ au total des montants nets de ligne (BT-106),

➢ diminué du total des Remises au niveau document (BT-107),

➢ augmenté du total des Charges ou frais au niveau document (BT-108),

✓ Le total du montant de TVA (BT-110) est égal à la somme des montants de TVA (BT-117) par taux
et type de TVA, voir BR-CO-14.

✓ Le type de TVA permet de distinguer les différents cas où la TVA n’est pas applicable notamment.
Le montant de TVA par taux correspond à la base hors taxes de chaque taux de TVA multiplié par
le taux de TVA, divisé par 100 et arrondi à 2 décimales. La base hors taxe de chaque taux de TVA
est égale à la somme des montants nets de ligne (BT-131) qui relèvent de ces mêmes taux et type
de TVA, augmentée de la somme des montants nets de Charges ou frais de document (BT-108) qui
relèvent de ces mêmes taux et type de TVA, diminuée de la somme des montants nets de Remises
de document (BT-107) qui relèvent de ces mêmes taux et type de TVA.

➢ Pour le profil EXTENDED-CTC-FR (et la révision de la Norme à venir) ce calcul s’enrichit de critères
additionnels

➢ d’abord sur les raisons d’exemption en texte (EXT-FR-FE-178) et en code (EXT-FR-FE-179), en
cohérence avec le couple BT-120 / B-121 en ventilation de TVA,

➢ ensuite pour la prise en compte uniquement des lignes sans sous-type de ligne (EXT-FR-FE-163) ou
avec un sous-type de ligne égal à « DETAIL ».

✓ Le montant total TTC (BT-112) de la facture est égal à la somme du montant total hors taxes (BT-
109) et du montant total de TVA (BT-110), voir règle BR-CO-15.
AFNOR XP Z12-0122025-11

_Source: `c:\Users\g.baudrit\source\repos\gbaudrit\conf-aimer-votre-llm\demo\ctxc-sample-spec\with-ctxc\spec/afnor 1.2/XP_Z12-012/XP_Z12-012.pdf` (page:30/page:30)_

### E-f7a26ee23564

XP Z12-012 – Formats et Profils des messages Factures et Statuts de cycle de vie,
constitutifs du socle minimal applicable à la Réforme Facture Électronique en France

29 
✓ Le montant d’acompte (BT-113) est égal au montant déjà payé avant établissement de la facture
ou payé par ailleurs ou par un tiers et qui viendra en déduction du montant TTC pour établir le
Net à payer par l’ACHETEUR au VENDEUR ou au BÉNÉFICIAIRE;

✓ Dans certains cas, il peut exister un montant d’arrondi (BT-114) à ajouter pour déterminer le
montant net à payer.

✓ Le montant net à payer (BT-115) est égal au montant total TTC (BT-112) diminué du montant
d’acompte (BT-113), et le cas échéant augmenté du montant d’arrondi (BT-114), voir règle BR-CO-
16.

Comme ces règles de calcul peuvent ne pas être respectées en cas de calcul de la TVA au niveau de la ligne ou
pour les factures dont les prix sont définis en TTC, TVA comprise (en particulier pour les factures B2C), le
profil EXTENDED-CTC-FR (et EXTENDED de Factur-X) introduit une tolérance de 0,01 € par ligne et par remise
charge ou frais au niveau du document dans les différentes sommes de calcul impliquées.

4.4.6 Règle d’arrondi dans les calculs

Les règles de calcul d’une facture nécessitent un calcul d’arrondi à certaines étapes (dès qu’il y a multiplication
ou division). La méthode d’arrondi est celle de la valeur la plus proche, avec la règle pour la détermination de
la fraction résiduelle à 0,5 suivante :

• Pour les nombres positifs : arrondi à la valeur supérieure. Par exemple, 13,455 arrondi à 2 chiffres
donne 13,46.

• Pour les nombres négatifs : arrondi à la valeur inférieure (de façon à ce qu’un arrondi de 2 nombres
strictement opposés donne des nombres arrondis strictement opposés). Par exemple, -13,455 donne
-13,46.

4.4.7 Gestion de la TVA

Pour chaque ligne de facture, il est nécessaire de qualifier la TVA applicable. Il existe plusieurs raisons qui
conduisent à une absence de TVA ou une TVA ramenée à 0 dans la facture. Ainsi la codification des différentes
catégories de TVA est la suivante :

• S : Taux de TVA standard, dont il faut ensuite indiquer le taux.

• Z : taux de TVA égal à 0. Ce cas ne s’applique pas en France pour l’instant;

• E : Exempté de TVA. A utiliser si aucun autre des cas d’absence de TVA ne s’applique; Dans ce cas il
est obligatoire d’indiquer dans le détail de TVA en pied la raison de l’exemption en faisant référence à
la disposition fiscale qui s’applique;

• AE : Autoliquidation de TVA. Dans ce cas, la TVA est due par le client qui doit la déclarer et la régler
directement à l’administration fiscale (en général, il procède simultanément à la déductibilité de la
même TVA). La raison d’absence de TVA qu’il faut indiquer dans le détail de TVA en pied est
« Autoliquidation ». Le Code VATEX à utiliser est VATEX-EU-AE ou VATEX-FR-AE en cas
d’Autoliquidation de TVA sur facture domestique;

• K : Autoliquidation pour cause de livraison intracommunautaire. Il s’agit du mécanisme
d’autoliquidation, mais qui s’applique du fait d’une livraison intra-communautaire. Par conséquent,
c’est ce code « K ¬ qu’il faut alors utiliser au lieu du code « AE ¬; La raison d’absence de TVA qu’il faut
indiquer dans le détail de TVA en pied est « Livraison intracommunautaire ». Le Code VATEX à utiliser
est VATEX-EU-IC.

• G : Exempté de TVA pour Export hors Union Européenne, le Code VATEX à utiliser est VATEX-EU-G.

• O : Hors du périmètre d'application de la TVA. Dans ce cas, il ne peut pas y avoir d’autres catégories
de TVA dans la facture (règle BR-O-11 de la Norme EN 16931). Le Code VATEX à utiliser est VATEX-
EU-O. Par contre, le profil EXTENDED-CTC-FR (et EXTENDED de Factur-X) a supprimé la règle BR-O-
AFNOR XP Z12-0122025-11

_Source: `c:\Users\g.baudrit\source\repos\gbaudrit\conf-aimer-votre-llm\demo\ctxc-sample-spec\with-ctxc\spec/afnor 1.2/XP_Z12-012/XP_Z12-012.pdf` (page:31/page:31)_

### E-369a43af77c6

XP Z12-012 – Formats et Profils des messages Factures et Statuts de cycle de vie,
constitutifs du socle minimal applicable à la Réforme Facture Électronique en France

30 
11, ce qui permet de faire des factures avec des lignes en catégorie O et d‘autres lignes sur d’autres
catégories de TVA.

• L (IGIC) et M (IPSI) : non applicable en France et en Allemagne puisqu’il s’agit de régimes de TVA
respectivement pour les Iles Canaries et Ceuta / Melilla.

En pied de facture, chaque catégorie de TVA présente dans les lignes doit être présente dans la ventilation de
TVA, avec la base Hors Taxes égale à la somme des montants hors taxes des lignes de la catégorie de TVA, le
code de catégorie de TVA, le taux de TVA (égal à 0 en cas d’exemption et non présent en cas « hors périmètre :
O), le montant de TVA (nul si pas de TVA), et dans tous les cas sauf « S », la raison de TVA nulle.

4.4.8 Gestion des taxes autres que la TVA, cas de l’éco-contribution DEEE

Lorsque des biens ou services sont soumis à des taxes autre que la TVA, deux situations se présentent :

• La taxe est soumise à la TVA au même taux que le produit ou service auquel elle s’applique : dans ce
cas, la taxe est gérée comme une charge sur la ligne de facture. Une raison (BT-144) ou un code de
raison (BT-145) permet d’identifier qu’il s’agit d’une taxe;

✓ Dans le cadre de la révision de la Norme EN 16931, une liste de codes dédiée pour qualifier le
type de taxe sera ajoutée. Elle sera prise en compte dans les profils EXTENDED-CTC-FR /
EXTENDED dans une version ultérieure de la présente Norme.

• La taxe n’est pas soumise à la TVA ou est soumise à un taux de TVA différent de celui du bien ou service
auquel elle se réfère : dans ce cas, la taxe est codifiée comme une ligne de service additionnelle.

Comme il peut exister un grand nombre de taxes parafiscales, une pratique assez largement utilisée est de
s’appuyer sur des lignes articles spécifiques en utilisant une codification proposée par GS1 au travers de GTIN
(identifiants d’articles à positionner en BT-157 avec SchemeID en BT-157-1 égal à 160) listés sur ce lien :
https://www.gs1.fr/publication/liste-taxes-assimilees.

De même, lorsqu’une taxe s’applique à l’ensemble de la facture (au niveau document), elle peut être traitée
comme une charge au niveau document, pour laquelle on peut indiquer une raison (BT-104) ou un code de
raison (BT-105), puis définir la TVA qui s’applique (ou pas) en BT-102 et BT-103.

En particulier, l’information sur l’éco-contribution DEEE doit figurer dans les factures. Elle est généralement
intégrée au prix unitaire et est donnée comme information (« dont xx,xx € éco-contribution ») dans une note
de ligne (BT-127) et / ou dans une note de Document (BT-21 = « BLU », BT-22); Elle n’a aucune utilité pour
l’intégration de la facture par l’acheteur;

4.4.9 Gestion des remises et charges

La gestion des remises et charges est gérée à 2 niveaux :

• Au niveau du document, pour des remises ou des charges globales sur la facture. Ces remises et charges
sont proches de lignes additionnelles. Elles ont par exemple leur propre TVA. Elles sont présentes sur
l’ensemble des profils; Elles font l’objet d’une somme dédiée dans le bloc de « Totaux de Document »
BG-22 (respectivement BT-108 et BT-107).

• Au niveau de la ligne, relative à la ligne facture, ayant le même taux de TVA que la ligne (sinon elles
doivent être insérées de façon indépendante comme une ligne positive pour des charges et négative
pour une remise). Elles sont intégrées au montant net de ligne BT-131 (qui est donc égal à la quantité
multipliée par le prix net augmenté de la somme des charges et diminué de la somme des remises de
la ligne).

Dans la syntaxe XML UN/CEFACT CII D22B, les remises et charges sont codifiées avec le même objet
« SpecifiedTradeAllowanceCharge » en CII et « cac :AllowanceCharge » en UBL, qui doit donc être qualifié par
l’indicateur « ChargeIndicator » qui doit être égal (udt:Indicator en CII, cbc :Chargeindicator en UBL) à « false »
pour une remise et à « true » pour une charge. Il en est de même en UBL.
AFNOR XP Z12-0122025-11

_Source: `c:\Users\g.baudrit\source\repos\gbaudrit\conf-aimer-votre-llm\demo\ctxc-sample-spec\with-ctxc\spec/afnor 1.2/XP_Z12-012/XP_Z12-012.pdf` (page:32/page:32)_

### E-df57285d381c

XP Z12-012 – Formats et Profils des messages Factures et Statuts de cycle de vie,
constitutifs du socle minimal applicable à la Réforme Facture Électronique en France

31 
Les montants de remise et charge sont tous les deux positifs (sauf s’il est nécessaire de signifier une reprise
de remise ou charge, par exemple dans le cas d’un avoir exprimé sous forme de facture négative);

Dans la description, ce bloc est donc répété d’une part pour les remises, puis d’autre part pour les charges,
pour une meilleure compréhension.

Ces remises et charges sont des blocs optionnels et répétables (cardinalité 0..n).

Enfin, il existe une dernière utilisation du bloc « SpecifiedTradeAllowanceCharge » en UN/CEFACT CII et
« cac :AllowanceCharge ¬ en UBL, uniquement pour l’application d’une remise correspondant à un rabais sur
le prix brut pour constituer le prix net (BT-147), sachant, pour rappel, que le prix brut est facultatif
contrairement au prix net qui est une donnée obligatoire. Toutefois, le prix unitaire brut peut être obligatoire,
comme c'est le cas en France, s'il diffère du prix unitaire net.

4.4.10 Gestion des Codes

Un certain nombre de champs de données doivent être choisis dans des listes de codes. Ceux-ci font partie des
spécifications de la Norme EN16931 et mis à jour tous les six mois, applicable les 15 mai et 15 novembre de
chaque année. Il s‘agit en général d’un enrichissement, c’est-à-dire de nouveaux codes. Il peut arriver de façon
très exceptionnelle que certains codes soient déréférencés; C’est la seule source de non-compatibilité
ascendante, qui reste très anecdotique. Il convient donc de suivre les évolutions de ces listes de codes pour en
mesurer les éventuels impacts; Ils sont publiés plus d’un mois avant leur mise en application;

4.4.11 Gestion des sous-lignes en profil EXTENDED-CTC-FR (et EXTENDED de Factur-X)

Pour certains cas d’usage, il est nécessaire de fournir :

• des sous-totaux regroupant des lignes de facturation,

• ou bien de fournir des informations de sous-articles composant un article principal vendu (par
exemple un kit de boite à outil regroupant une boîte et différents outils),

• ou bien de décomposer un article en articles élémentaire qui ont leurs propres taux de TVA, comme
par exemple un livre-jouet qui est l’article acheté et livré, mais qui est composé d’un livre avec TVA à
10% et d’un jouet avec TVA à 20%,

• ou de regrouper des lignes par transaction, comme une ligne de transport, avec ses sous-lignes de
complément et d’option (supplément Gasoil, supplément week-end, <),

• ou d’avoir des lignes avec des sous-totaux, par exemple par livraison, par commande, <

Et bien sûr, ceci peut se construire à plusieurs niveaux, par exemple une ligne GROUP pour détailler une
livraison parmi d’autres, avec des sous-lignes d’articles composites, qui ont eux-mêmes des sous-lignes de
DETAIL, et ainsi de suite.

Pour gérer tous ces cas d’usage, il est nécessaire d’abord de permettre un regroupement de ligne de façon
hiérarchique en utilisant la donnée « Identifiant de ligne Parent » (EXT-FR-FE-162), qui indique le numéro de
ligne à laquelle une ligne est attachée.

Ensuite, de façon à ne pas additionner plusieurs fois la même chose (par exemple en additionnant des
montants de ligne et des sous-totaux), une qualification des lignes est nécessaire de façon à distinguer d’abord
les lignes de facture à prendre en compte dans les calculs des totaux et pied de TVA, puis ensuite à distinguer
des lignes de regroupement et de sous-total de simples lignes d’information;

Pour ce faire la donnée « sous-type de ligne » (EXT-FR-FE-163) doit alors être utilisée avec les valeurs :

• DETAIL : est une ligne entrant dans les calculs de totaux et de TVA, avec les lignes « standard » sans
qualifiant de sous-type de ligne; Ce sont aussi les lignes qui DOIVENT faire l’objet des extractions de
données pour la constitution des flux 1 et 10.1 (cf règle BR-FR-MAP-24).
AFNOR XP Z12-0122025-11

_Source: `c:\Users\g.baudrit\source\repos\gbaudrit\conf-aimer-votre-llm\demo\ctxc-sample-spec\with-ctxc\spec/afnor 1.2/XP_Z12-012/XP_Z12-012.pdf` (page:33/page:33)_

### E-c28a20807ce5

XP Z12-012 – Formats et Profils des messages Factures et Statuts de cycle de vie,
constitutifs du socle minimal applicable à la Réforme Facture Électronique en France

32 
• INFORMATION : est une ligne donnant des informations additionnelles, pour lesquelles l’ensemble des
données d’une ligne peut être utilisé ou pas; Ceci conduit à ce que la présence obligatoire du prix
Unitaire Net (BT-146), de la quantité facturée (BT-129) et son unité de mesure (BT-130), les
informations de TVA (BG-30) et du total HT de ligne (BT-131) deviennent optionnelles (règles BR-
FREXT-09). En cas de présence du montant HT de ligne (BT-131), celui-ci n’est pas pris en compte
dans les calculs de totaux et de pied de TVA, cf règles de gestion TVA BR-FREXT-ZZZ)

• GROUP, qui peut être vue comme une ligne INFORMATION particulière, avec données optionnelles,
mais pour lesquelles la présence du montant HT de ligne (BT-131) impose que celui-ci soit alors égal
aux montants HT des sous-lignes qui lui sont directement attachées et ont un sous-type de ligne égal
à DETAIL ou GROUP (cf BR-FREXT-08); Par conséquent, dès lors qu’une ligne de type GROUP dispose
d’un montant HT de ligne, alors les lignes GROUP qui ui sont rattachées DOIVENT avoir aussi un
montant HT de ligne.

Exemple d’utilisation 1 : Utiliser les lignes « INFORMATION ¬ pour compléter la description de l’article : La
vente de 2 kits « Boite à outil », contenant chacun 3 pinces et 5 marteaux et 1 tournevis (et donc 6 pinces et 10
marteaux et 2 tournevis en tout). Le prix est fixé au niveau du KIT, les lignes « INFORMATION » donnent le
détail. Les lignes en bleu sont groupées. La ligne 1 aurait pu être qualifiée « DETAIL » aussi. La lignes 2 est une
ligne d’information additionnelle indépendante; La ligne 3 est une ligne classique; 

Lignes

Numéro de
Ligne
Identifiantd e
ligne Paretnt Sous-type de ligne Nom de l'article Quantité
facturée Unité de mesure PU Net Categorie
TVA Taux de TVA Total HT de ligne

BT-126 EXT-FR-FE-162 EXT-FR-FE-163 BT-153 BT-129 BT-130 BT-146 BT-151 BT-152 BT-131
1   Kit Boite outil 2 C62 (pièce) 199,00 S 20% 398,00
1.1 1 INFORMATION Pinces 6 C62 (pièce)    0,00
1.2 1 INFORMATION Marteau 10 C62 (pièce)    0,00
1.3 1 INFORMATION Tourne vis 2 C62 (pièce)    0,00
2  INFORMATION Sac Gratuit 1 C62 (pièce)    0,00
3   Clous 500 C62 (pièce) 0,02 S 20% 10,00           

Ventilation de TVA

Base Categorie de
TVA Taux TVA Montant TVA Totaux

BT-115 BT-118 BT-119 BT-117  Total HT (BT-109) 408,00

408,00 S 20% 81,60 Total TVA (BT-110) 81,60

0,00 S 10% 0,00 TTC (BT-112) 489,60

Exemple d’utilisation 2 : des articles composites multi-taux de TVA : Livre jouet. Les totaux et la TVA se
calculent sur les lignes DETAIL (50 et 75); La ligne GROUP ne donne pas d’information TVA car elle n’aurait
aucun sens; Elle n’est pas transmise en flux 1 ou 10;1; 

Lignes

Numéro de
Ligne
Identifiantd e
ligne Paretnt Sous-type de ligne Nom de l'article Quantité
facturée Unité de mesure PU Net Categorie
TVA Taux de TVA Total HT de ligne

BT-126 EXT-FR-FE-162 EXT-FR-FE-163 BT-153 BT-129 BT-130 BT-146 BT-151 BT-152 BT-131
1  GROUP Livre-jouet 5 C62 (pièce) 25,00   125,00
2 1 DETAIL Livre 5 C62 (pièce) 10,00 S 10% 50,00
3 1 DETAIL Jouet 5 C62 (pièce) 15,00 S 20% 75,00           

Ventilation de TVA

Base Categorie de
TVA Taux TVA Montant TVA Totaux

BT-115 BT-118 BT-119 BT-117  Total HT (BT-109) 125,00

75,00 S 20% 15,00 Total TVA (BT-110) 20,00

50,00 S 10% 5,00 TTC (BT-112) 145,00

A NOTER : le numéro de ligne n’a pas besoin de répliquer la structure (1;1, 1;2); L’identifiant de ligne Parent
suffit à le faire.
AFNOR XP Z12-0122025-11

_Source: `c:\Users\g.baudrit\source\repos\gbaudrit\conf-aimer-votre-llm\demo\ctxc-sample-spec\with-ctxc\spec/afnor 1.2/XP_Z12-012/XP_Z12-012.pdf` (page:34/page:34)_

### E-4ae57fc5a20c

XP Z12-012 – Formats et Profils des messages Factures et Statuts de cycle de vie,
constitutifs du socle minimal applicable à la Réforme Facture Électronique en France

33 
Exemple d‘utilisation 3 : des sous-lignes pour les lier à une ligne principale : une prestation de transport,
avec une ligne principale, qui peut contenir plusieurs données et des références (ici Objet facturé pour un
numéro de colis, mais il peut y avoir aussi l’adresse de prise en charge, l’adresse de livraison, des références
clients, <) qu’il n’est pas nécessaire de répéter à chaque sous-ligne de complément de prestation (suppléments
divers). 

Lignes

Numéro de
Ligne
Identifiantd e
ligne Paretnt Sous-type de ligne Nom de l'article Identifiant d'Objet
Facturé
Quantité
facturée
Unité de
mesure PU Net Categorie
TVA Taux de TVA Total HT de ligne

BT-126 EXT-FR-FE-162 EXT-FR-FE-163 BT-153 BT-128 BT-129 BT-130 BT-146 BT-151 BT-152 BT-131
1   Livraison Numéro de colis 1 C62 (pièce) 25,00 S 20% 25,00
2 1 DETAIL Supplément Gasoil  1 C62 (pièce) 3,00 S 20% 3,00
3 1 DETAIL Supplément week end  1 C62 (pièce) 5,00 S 20% 5,00           

Ventilation de TVA

Base Categorie de
TVA Taux TVA Montant TVA Totaux

BT-115 BT-118 BT-119 BT-117  Total HT (BT-109) 33,00

33,00 S 20% 6,60 Total TVA (BT-110) 6,60

0,00 S 10% 0,00 TTC (BT-112) 39,60

Exemple d‘utilisation 4 : plusieurs niveaux de sous-lignes : la vente de 2 présentoirs composés chacun de 3
paquets de Kenya Roast, 6 paquets de Dark Roast, et 3 Bundle eux-mêmes composés de 3 paquets de Columbia
Roast et 3 MUG, avec potentiellement des taux de TVA applicable différents (pour l’exemple); Ceci illustre le
fait que l’organisation des lignes peut se faire à plusieurs niveaux. Là encore seules les lignes DETAIL comptent
dans les calculs de totaux et de ventilation de TVA, et sont transmises dans les flux 1 et 10.1. 

Lignes

Numéro de
Ligne
Identifiantd e
ligne Paretnt Sous-type de ligne Nom de l'article Quantité
facturée Unité de mesure PU Net Categorie
TVA Taux de TVA Total HT de ligne

BT-126 EXT-FR-FE-162 EXT-FR-FE-163 BT-153 BT-129 BT-130 BT-146 BT-151 BT-152 BT-131
1  GROUP Présentoir de Caffé 2 C62 (pièce)    216,00
1.1 1 DETAIL Kenya Roast 6 C62 (pièce) 5,00 S 10% 30,00
1.2 1 DETAIL Dark Roast 12 C62 (pièce) 5,00 S 10% 60,00
1.3 1 GROUP Colombia Bundle 6 C62 (pièce)    126,00
1.3.1 1.3 DETAIL Colombia Roast 18 C62 (pièce) 5,00 S 10% 90,00
1.3.2 1.3 DETAIL Mug 18 C62 (pièce) 2,00 S 20% 36,00           

Ventilation de TVA

Base Categorie de
TVA Taux TVA Montant TVA Totaux

BT-115 BT-118 BT-119 BT-117  Total HT (BT-109) 216,00

36,00 S 20% 7,20 Total TVA (BT-110) 25,20

180,00 S 10% 18,00 TTC (BT-112) 241,20

4.4.12 Factures multi-vendeurs

De nombreux cas d’usage mettent en jeu un intermédiaire transparent qui facturent un ACHETEUR unique
pour le compte de plusieurs vendeurs, mais dans une facture consolidée unique. Par exemple les factures de
fournitures d’eau regroupent aussi des prestations d’assainissement vendues par d’autres vendeurs; Des
sociétés de réservation de taxi facturent mensuellement des clients professionnels pour le compte de chaque
taxi, <

Pour permettre une continuité de pratique, une extension spécifique a été ajoutée au profil EXTENDED-CTC-
FR; L’objectif est de permettre un regroupement de plusieurs factures unitaires de plusieurs VENDEURS
dans une facture unique pour l’ACHETEUR, qui la traite comme une facture classique; Cependant, la création
des flux 1 et 10.1 DOIT être faite par facture unitaire.
AFNOR XP Z12-0122025-11

_Source: `c:\Users\g.baudrit\source\repos\gbaudrit\conf-aimer-votre-llm\demo\ctxc-sample-spec\with-ctxc\spec/afnor 1.2/XP_Z12-012/XP_Z12-012.pdf` (page:35/page:35)_

### E-2d23328dfc62

XP Z12-012 – Formats et Profils des messages Factures et Statuts de cycle de vie,
constitutifs du socle minimal applicable à la Réforme Facture Électronique en France

34 
4.4.12.1 Modalités de création d’une facture Multi-Vendeurs

A priori, la facture Multi-Vendeurs contient une facture unitaire par Vendeur, mais il est envisageable d’avoir
plusieurs factures différentes d’un même Vendeur;

Cependant, toutes les factures unitaires DOIVENT avoir la même Date de facture (BT-2) et le même type
de facture (BT-3).

Pour identifier ces factures particulières, le Cadre de facturation (BT-23) DOIT être choisi parmi les 3 valeurs
suivantes : B8 (facture de Biens) ; S8 (facture de Services) ; M8 (facture mixte avec des lignes de Biens et des
lignes de service), à utiliser dès lors que cette facture regroupe des factures unitaires qui ne sont pas toutes
soit de Biens soit de Services.

La facture multi-Vendeurs fait appel à la gestion des sous-lignes, en créant pour chaque facture unitaire, une
ligne (BG-25) de type « GROUP » non attachée à une autre ligne (donc avec un sous-type de ligne (EXT-FR-FE-
163) égal à « GROUP » et sans Identifiant de ligne Parent (EXT-FR-FE-162)), dans laquelle seront présentes
toutes les informations spécifiques à la facture unitaire, à savoir :

• le Vendeur en ligne (EXT-FR-FE-BG-12), correspondant au bloc BG-4 de la facture unitaire, dont :

✓ la dénomination sociale (EXT-FR-FE-164),

✓ l’identifiant légal du Vendeur en ligne (EXT-FR-FE-167),

✓ Le numéro de TVA intracommunautaire (EXT-FR-FE-168), correspondant au BT-31 de la facture
unitaire, et le cas échéant l’identifiant fiscal (EXT-FR-FE-169), correspondant au BT-32 (utilisé par
exemple par un Franchisé en Base n’ayant pas de n° de TVA),

✓ le pays de l’adresse du Vendeur en ligne,

• le numéro de facture unitaire, codifié avec l’Identifiant d’objet facturé à la ligne (BT-128), avec le
qualifiant (BT-128-1) égal à AFL, correspondant à la BT-1 de la facture unitaire,

• le cadre de facturation codifié avec l’Identifiant d’objet facturé à la ligne (BT-128), avec le qualifiant
(BT-128-1) égal à AVV, correspondant à la BT-23 de la facture unitaire,

• le code d’exigibilité de TVA (EXT-FR-FE-180), correspondant au BT-8 de la facture unitaire (car il est
possible que certaines factures unitaires soient au débit et d‘autres à l’encaissement,

• le Montant de TVA à la ligne (EXT-FR-FE-181) dans la devise de la facture (BT-5), qui permettra de
fournir le montant total TVA de facture unitaire en devise de facture (BT-110),

• le Montant de TVA à la ligne (EXT-FR-FE-182) dans la devise de comptabilisation (BT-6), qui permettra
de fournir le montant total TVA de facture unitaire en devise de comptabilisation (BT-111),

• le Montant total TTC de ligne (EXT-FR-FE-184), qui permettra de fournir le montant total TTC de
facture unitaire (BT-112).

• Il n’est pas nécessaire de renseigner les informations de catégorie TVA, de taux et de raison
d’exemption en texte ou code (elles ne seront pas utilisées dans les calculs);

Ensuite, les lignes de chaque facture unitaire DOIVENT respecter les règles suivantes :

• Contenir le numéro de facture unitaire (codifié avec l’Identifiant d’objet facturé à la ligne (BT-128, avec
le qualifiant (BT-128-1) égal à AFL).

• Contenir l’identifiant légal du Vendeur en ligne (EXT-FR-FE-167).

• Pour permettre une ventilation de TVA par facture unitaire, la raison d’exemption en texte de ligne
(EXT-FR-FE-178) DOIT commencer par le numéro de facture entre # suivi du texte d’exemption si
applicable.
AFNOR XP Z12-0122025-11

_Source: `c:\Users\g.baudrit\source\repos\gbaudrit\conf-aimer-votre-llm\demo\ctxc-sample-spec\with-ctxc\spec/afnor 1.2/XP_Z12-012/XP_Z12-012.pdf` (page:36/page:36)_

### E-6e7ecfac8c1c

35 
XP Z12-012 – Formats et Profils des messages Factures et Statuts de cycle de vie, constitutifs du socle minimal applicable à la Réforme
Facture Électronique en France 

Situation 3 Vendeurs
Vendeur : Vendeur A
Facturant : Vendeur A
EXEMPLE DE FACTURE MULTI-VENDEURS  F20250025
01/10/2025

380

Le vendeur A émet une facture comportant 3 groupes de lignes, par vendeur final (y compris le vendeur A). 5

Processus métier (Cadre de facturation) S8/B8/M8 signifie « Facture
Facture Multi-Vendeurs 

Name  Code  Cadre de
S8 multi-vendeurs ». Le processus métier (cadre de facturation) des factures
unitaires se trouve dans BT-128, SchemeID = AVV.

N° ligne N° ligne Parent CODE Type ligne d'article Description Prix Unitaire Quantité N° de facture unitaire Exigibiité TVA
(~BT-8)
facturation pour
la facture unitaire
HT de ligne Code TVA Taux TVA VATEX en code VATEX en texte TVA de ligne TTC de ligne

BT-126 EXT-FR-FE-162 EXT-FR-FE-163 (BT-X-8) BT-153 (BT-X-304) BT-154 BT-146 BT-129 EXT-FR-FE-164 EXT-FR-FE-167 EXT-FR-FE-168 EXT-FR-FE-177 BT-128 BT-128-1 EXT-FR-FE-180 BT-128 BT-128-1 BT-131 BT-151 BT-152 EXT-FR-FE-179 EXT-FR-FE-178 EXT-FR-FE-181 EXT-FR-FE-184 

1 GROUP 

2 1 DETAIL
Facture
unitaire
VENDEUR A

Service A  ceci  1 000,00  1,00 
VENDEUR A  123456782 

123456782 
FRxx123456782 FR F20250025

F20250025 
AFL  5 S1  AVV  2 500,00 

1 000,00 S  20,00%  #F20250025# 
350,00  2 850,00

3 1 DETAIL 

4 GROUP 

5 4 DETAIL 

6 4 DETAIL 

7 GROUP 

8 7 DETAIL 

9 7 DETAIL
Service B

Facture
unitaire
VENDEUR X

Service X 

Service Z

Facture
unitaire
VENDEUR 00

Service 25 

Service 32
cela 

ceci

cela 

ceci

cela
500,00 

300,00 

1 000,00 

12,00 

25,00
3,00 

5,00 

4,00 

50,00 

10,00 
VENDEUR X 

VENDEUR 00
123456782 

321654879 

321654879 

321654879 

254136987 

254136987 

254136987 
FRxx321654879 FR 

FRxx254136987 FR
F20250025 

123456782_321654879
_F20250025

123456782_321654879
_F20250025
123456782_321654879
_F20250025

123456782_254136987
_F20250025

123456782_254136987
_F20250025
123456782_254136987
_F20250025 
AFL 

AFL 
72 S1 

72 S1 
AVV 

AVV
1 500,00 S 

5 500,00 

1 500,00 S 

4 000,00 S 

850,00 

600,00 S 

250,00 S
10,00% 

20,00% 

20,00% 

20,00% 

20,00%
#F20250025# 

#123456782_321654879
_F20250025#
#123456782_321654879
_F20250025# 

#123456782_254136987
_F20250025#
#123456782_254136987
_F20250025# 
1 100,00 6 600,00 

170,00 1 020,00 

Base TVA VATEX Code VATEX Texte Code TVA Taux de TVA Montant TVA

BT-116 BT-121 BT-120 BT-118 BT-119 BT-117  TOTAUX

1 000,00 #F20250025# 

1 500,00 #F20250025#

5 500,00 #123456782_321654879
_F20250025#

0,00 #123456782_321654879
_F20250025#

850,00 #123456782_254136987
_F20250025#

0,00 #123456782_254136987
_F20250025#
S 20,00% 200,00 

S 10,00% 150,00 

S 20,00% 1 100,00 

S 10,00% 0,00 

S 20,00% 170,00 

S 10,00% 0,00
BT-109

BT-110

BT-112

BT-113 

BT-115
Total HT 8 850,00 

TVA 1 620,00 

Total TTC 10 470,00 

Déjà payé 0,00 

Net à Payer 10 470,00
BT-1
BT-2

BT-3

BT-8

BT-23

Raison Sciale ID légal N° TVA Intra Code Pays
VENDEUR VENDEUR VENDEUR VENDEUR

AFNOR
XP Z12-0122025-11

_Source: `c:\Users\g.baudrit\source\repos\gbaudrit\conf-aimer-votre-llm\demo\ctxc-sample-spec\with-ctxc\spec/afnor 1.2/XP_Z12-012/XP_Z12-012.pdf` (page:37/page:37)_

### E-9be06bffc5b6

36
XP Z12-012 – Formats et Profils des messages Factures et Statuts de cycle de vie,
constitutifs du socle minimal applicable à la Réforme Facture Électronique en France 

La ventilation de TVA se calcule dans le respect des règles du profil EXTENDED-CTC-FR, avec pour clé de
somme partielle la Catégorie TVA (BT-118), le taux de TVA (BT-119), la raison d’exemption en texte (BT-120)
et en code (BT-121) utilisables aussi pour les catégories S et Z, et uniquement les lignes « DETAIL » ou sans
sous-type de ligne.

4.4.12.2 Numéro de facture unitaire :

De façon à garantir son unicité, il convient de le préfixer ou suffixer avec un élément qui garantit une unicité
de numéro au sein des différentes factures unitaires et chez chaque Vendeur. Une pratique consiste à le
préfixer avec un identifiant du Vendeur (par exemple son identifiant légal), le cas échéant enrichi d’un
identifiant du Vendeur principal facturant, constituant ainsi une série unique de facturation par Vendeur (qui
aura donc des trous de numérotation car chaque Vendeur ne sera pas présent dans chaque facture multi-
vendeurs générée par le facturant (intermédiaire transparent).

La meilleure pratique est de générer des numéros de factures par sous-vendeur en respectant une chronologie
et par facture unitaire, préfixés par l’identifiant légal du Vendeur et celui du Facturant :

• 123456782_321654879_F20250025 pour le Vendeur X de l’exemple ci-dessus,

• 123456782_254136987_F20250012 pour le Vendeur 00 de l’exemple ci-dessus qui aurait été présent
dans moins de factures multi-vendeurs que le VENDEUR X (12 au lieu de 25).

4.4.12.3 Les Charges et Remises :

Les Charges et Remises de niveau Document sont affectées uniquement à la facture principale, donc au
Vendeur principal identifié en bloc BG-4 de la facture Multi-Vendeurs.

En cas de besoin pour les factures unitaires, il convient d‘utiliser les lignes pour ajouter des charges. De même
des remises globales peuvent être traitées sur des lignes, avec un prix unitaire nul, une quantité égale à 1 et
l’utilisation de la remise de ligne;

4.4.12.4 Les règles de gestion

Les règles de gestion des factures Multi-Vendeurs sont décrites au chapitre 4.5.4.

4.4.12.5 Constitution du flux 1 ou 10.1, sur la base des factures unitaires.

Le traitement d’un facture Multi-Vendeurs nécessite de recomposer les factures unitaires, servant de pièce
comptable pour chaque Vendeur et de base pour créer le flux 1 ou 10.1 exigé.

Pour ce faire, les factures unitaires se créent par extraction et mapping décrits dans les règles de mapping des
factures multi-vendeurs (chapitre 4.5.5).

Il s’agit de composer les factures unitaires n’ayant pas le même numéro de facture que la facture multi-
vendeurs :

• En ne conservant que les lignes correspondant à chaque facture unitaire (au travers de la valeur de
BT-128 avec BT-128-1 = AFL), pour les lignes DETAIL seulement.

• En supprimant les charges et remises de niveau Document (si elles existent dans la facture).

• En ne conservant que les lignes de ventilation de TVA (BG-23) pour lesquelles la raison d’exemption
en texte (BT-120) commence par le numéro de facture unitaire (BT-128, avec le qualifiant (BT-128-1)
égal à AFL de la ligne GROUP) entre #

• En utilisant les données de la ligne « GROUP » pour :

✓ Remplacer les informations du VENDEUR par celle du Vendeur en ligne (dans la ligne « GROUP »)
AFNOR XP Z12-0122025-11

_Source: `c:\Users\g.baudrit\source\repos\gbaudrit\conf-aimer-votre-llm\demo\ctxc-sample-spec\with-ctxc\spec/afnor 1.2/XP_Z12-012/XP_Z12-012.pdf` (page:38/page:38)_

### E-517ea158e42f

XP Z12-012 – Formats et Profils des messages Factures et Statuts de cycle de vie,
constitutifs du socle minimal applicable à la Réforme Facture Électronique en France

37 
✓ Remplacer le numéro de facture (BT-1) par le numéro de facture unitaire (BT-128, avec le
qualifiant (BT-128-1) égal à AFL)

✓ Remplacer le cadre de facturation (BT-23) par le cadre de facturation en ligne (BT-128, avec le
qualifiant (BT-128-1) égal à AVV).

✓ Remplacer le code d’exigibilité de TVA (BT-8) par le code d’exigibilité en ligne (EXT-FR-FE-180).

✓ Remplacer la Somme des montants en ligne (BT-106) et le total HT (BT-109) par le total HT de
ligne « GROUP » (BT-131)

✓ Remplacer les montants totaux TVA BT-110 et BT-111 par ceux renseignés en EXT-FR-FE-181 et
EXT-FR-FE-182 (si existe).

✓ Remplacer le montant total TTC (BT-112) par celui renseigné en EXT-FR-FE-185.

✓ Renseigner le montant déjà payé (BT-113) par celui renseigné en EXT-FR-FE-185, car la facture
doit être payée à l’intermédiaire transparent Facturant et Bénéficiaire.

✓ Renseigner le montant Net à Payer (BT-115) comme étant égal à BT-112 – BT-113, donc égal à 0.

• Potentiellement, si le Bénéficiaire n’est pas présent dans la facture multi-vente, il peut être rajouté
dans la facture unitaire avec les données du VENDEUR de la facture multi-vendeur (BG-4).

Pour la facture unitaire du Vendeur principal, même traitement, sauf que :

• Les lignes de Charges et Remise de niveau Document sont conservées (et sont donc uniquement
attachées au Vendeur principal)

• Le total HT (BT-109) doit être égal à BT-106 - BT-107 + BT-108

• Si la facture multi-vendeurs ne contient pas de remises et charges de niveau document, la conversion
en facture unitaire est la même que pour toutes les factures unitaires.

Une fois les factures unitaires constituées, les contrôles standards peuvent être effectués et les flux 1 ou 10.1
constitués sur cette base. Les factures unitaires font l’objet du statut « Déposée » mais ne sont pas transmises
à l’ACHETEUR; Seule la facture multi-vendeurs est transmise.

En cas de rejet d’une des factures unitaires, toutes les factures unitaires doivent être rejetées et la facture
multi-vendeur doit être générée à nouveau.

Les factures unitaires peuvent être transmises à chaque Vendeur concerné pour sa comptabilisation. Il peut
aussi exister des solutions en place qui organisent ces transferts d’information comptables;

4.5 Règles de gestion spécifiques

Les exigences de la réforme Facture Électronique en France ont conduit à définir des règles de gestion
additionnelles à celles de la Norme EN 16931, induites des règles de gestion sur les éléments de e-reporting
à l’Administration fiscale (Flux 1, Flux 10;1);

Ces règles de gestion sont de plusieurs types :

• Des règles de gestion qui sont constitutives de contrôles additionnels à opérer, sur le contenu des
factures et parfois avec des référentiels externes (par exemple l’existence de SIREN ACHETEUR ou
VENDEUR dans l’Annuaire PPF); On parle alors de contrôle métier;

• Des règles de mapping entre les données des factures et les fichiers attendus par l’Administration
fiscale (flux 1 et flux 10.1).

• Des règles « CHORUS PRO » applicables pour les factures B2G à destination du secteur public.

• Des règles additionnelles spécifiques pour le cas des factures multi-vendeurs :

✓ Règles de gestion additionnelles.
AFNOR XP Z12-0122025-11

_Source: `c:\Users\g.baudrit\source\repos\gbaudrit\conf-aimer-votre-llm\demo\ctxc-sample-spec\with-ctxc\spec/afnor 1.2/XP_Z12-012/XP_Z12-012.pdf` (page:39/page:39)_

### E-f60ce6726add

XP Z12-012 – Formats et Profils des messages Factures et Statuts de cycle de vie,
constitutifs du socle minimal applicable à la Réforme Facture Électronique en France

38 
✓ Règles de mapping spécifiques pour constituer des factures unitaires et des flux 1 ou 10.1
unitaires.

Ces règles sont décrites dans l’annexe Excel, et en particulier affectées à chaque ligne de description d’une
donnée de facture dès lors qu’elle est concernée par l’une de ces règles;

4.5.1 Les règles de contrôle additionnelles pour le respect de la réglementation en France

Le Tableau ci-dessous indique les règles de gestion de contrôle : 

CODE BR  Titre  Description  S'applique à 

BR-FR-01  ID de facture 35
Caractères  L'identifiant de facture DOIT ÊTRE limité à 35 caractères  BT-1, BT-25, EXT-FR-FE-136 

BR-FR-02 
ID de facture
caractères
autorisés
L'Identifiant de facture (BT-1) est composé de caractères alphanumériques (A-Z,
a-z, 0-9). Les caractères spéciaux suivants sont autorisés :
- tiret ("-")
- signe "+"
- tiret bas (underscore : "_")
- barre oblique (slash : "/") 
BT-1, BT-25, EXT-FR-FE-136 

BR-FR-03  Date entre 2000
et 2099  L'année d'une date DOIT ETRE comprise entre 2000 et 2099  Tout type DATE 

BR-FR-04  Codes types
documents
Les codes types de documents pour une facture sont les suivants:
Factures simples :
- Facture commerciale (380)
- Facture auto-facturée (389)
- Facture affacturée (393)
- Facture auto-facturée affacturée (501)

Factures d'acompte :
- Facture d'acompte (386)
- Facture d’acompte auto-facturée (500)

Factures rectificatives :
- Facture rectificative (384)
- Facture rectificative auto-facturée ( 471)
- Facture rectificative affacturée (472)
- Facture rectificative auto-facturée affacturée ( 473)

Avoirs :
- Avoir auto-facturé (261)
- Avoir pour Remise Globale (262)
- Avoir (381)
- Avoir affacturé (396)
- Avoir auto-facturé affacturé (502)
- Avoir de facture d'acompte (503)

Les autres types de factures définis dans la norme (UNTDID 1001) ne doivent
pas être utilisés. 
BT-3, EXT-FR-FE-02, EXT-
FR-FE-137 

BR-FR-05  Note
Toute facture DOIT comporter au moins 3 notes (BG-1) avec les codes suivants :
- BT-21 = PMT, pour la mention de pénalité de 40 EUROS forfaitaire pour frais de
recouvrement (en BT-22)
- BT-21 = PMD, Mention de pénalités qui correspond aux conditions de paiement
propres à chaque entreprise (en BT-22).
- BT21 = AAB, mention d'escompte ou d'absence d'escompte (en BT-22) 
BT-22, BT-21 

BR-FR-06  Note  Parmi les notes (BG-3), les codes sujets (BT-21) PMD, PMT, AAB et TXD ne
DOIVENT être présents qu'UNE SEULE FOIS CHACUN  BT-22, BT-21
AFNOR XP Z12-0122025-11

_Source: `c:\Users\g.baudrit\source\repos\gbaudrit\conf-aimer-votre-llm\demo\ctxc-sample-spec\with-ctxc\spec/afnor 1.2/XP_Z12-012/XP_Z12-012.pdf` (page:40/page:40)_

### E-52dcd3f692ef

XP Z12-012 – Formats et Profils des messages Factures et Statuts de cycle de vie,
constitutifs du socle minimal applicable à la Réforme Facture Électronique en France

39 
CODE BR  Titre  Description  S'applique à 

BR-FR-07  Note
Pour signifier les informations ci-dessous dans des notes (BT-22) les codes
sujets correspondants (BT-21) doivent être les suivants : 

- ACC : Clause de subrogation factoring
- AAI : Information générale : des éléments en général en fond de page des
factures papier
-ADN : indique si la facture relève du B2G en France (règles additionnelles CPRO
- SUR : Remarques fournisseur
- ABL : Information légale : par exemple N° registre des métiers, RCS
- CUS : Information douanière
- BLU : "Eco-participation (L. 541-10 du code de l'environnement)" ou "Eco-
contribution DEEE"
- BAR : type de traitement attendu (e-invoicing, e-reporting, hors réforme, ...) 
BT-22, BT-21 

BR-FR-08  Cadre de
facturation
Les valeurs autorisées pour le Cadre (Mode de Facturation) sont:
B1 : Dépôt d'une facture de bien
S1 : Dépôt d'une facture de prestation de service
M1 : Dépôt d'une facture double (livraison de biens et services qui ne sont pas
accessoires l'une de l'autre)
B2 : Dépôt d'une facture de bien déjà payée
S2 : Dépôt d'une facture de prestation de service déjà payée
M2 : Dépôt d'une facture double déjà payée
S3 : Dépôt d'une demande de paiement de sous-traitance avec paiement direct
(uniquement B2G, restriction non vérifiable)

B4 : Dépôt d'une facture définitive (après acompte) de bien
S4 : Dépôt d'une facture définitive (après acompte) de service
M4 : Dépôt d'une facture définitive (après acompte) double
S5 : Dépôt par un sous-traitant d’une facture de prestation de service
S6 : Dépôt par un cotraitant d’une facture de prestation de service
B7 : Dépôt d'une facture de bien ayant fait l'objet d'un e-reporting (TVA déjà
collectée)
S7 : Dépôt d'une facture de prestation de service ayant fait l'objet d'un e-
reporting (TVA déjà collectée)
B8 : Dépôt d'une facture multi-vendeurs de bien
S8 : Dépôt d'une facture multi-vendeurs de service
M8 : Dépôt d'une facture multi-vendeurs double, contenant des facrtures
unitaires qui ne sont pas toutes Sx ou Bx. 
BT-23 

BR-FR-09  Cohérence
SIRET SIREN 
Dans une Partie, si le SIRET est renseigné (ID Privé, 0009), Les 9 premiers
chiffres du SIRET doivent correspondre au SIREN renseigné en ID légal
(schemeID 0002) et le SIRET doit faire 14 chiffres
BT-29, BT-46, BT-60, EXT-
FR-FE-06, EXT-FR-FE-46,
EXT-FR-FE-69, EXT-FR-FE-
92, EXT-FR-FE-115, BT-71,
EXT-FR-FE-146 

BR-FR-10  Gestion du
SIREN 
Le SIREN du Vendeur est Obligatoire, et doit être présent et actif dans l'annuaire
PPF  BT-30 

BR-FR-11  Gestion du
SIREN
Pour les factures relevant du périmètre "e-invoicing", le SIREN de l'Acheteur est
Obligatoire, et DOIT être présent et actif dans l'annuaire PPF

Règle à exécuter si la facture fait l'objet d'un traitement B2B ou si elle contient
une note (BG-1) avec un code sujet (BT-21) = BAR et un contenu (BT-22) = B2B :

L'identifiant légal de l'Acheteur (BT-47) DOIT être présent. 
BT-47
AFNOR XP Z12-0122025-11

_Source: `c:\Users\g.baudrit\source\repos\gbaudrit\conf-aimer-votre-llm\demo\ctxc-sample-spec\with-ctxc\spec/afnor 1.2/XP_Z12-012/XP_Z12-012.pdf` (page:41/page:41)_

### E-6a0deb5394d9

XP Z12-012 – Formats et Profils des messages Factures et Statuts de cycle de vie,
constitutifs du socle minimal applicable à la Réforme Facture Électronique en France

40 
CODE BR  Titre  Description  S'applique à 

BR-FR-12 
Adresse
électronique de
l'acheteur
Dès lors que la facture électronique doit être transmise et attend des statuts de
cycle de vie en retour, l'adresse électronique de l'Acheteur (BT-49) est
OBLIGATOIRE. C'est l'adresse électronique à laquelle la facture est transmise
(hors autofactures), ainsi que les statuts de cycle de vie à destination de
l'ACHETEUR. 

Pour information (géré par d'autres règles) :
Pour les factures hors auto-facturation relevant du périmètre "e-invoicing", cette
adresse électronique DOIT être de la forme "SIREN" ou "SIREN_XXX", le SIREN
étant celui de l'Acheteur renseigné en BT-47, avec un schemeId (BT-49-1) =
0225.

Pour les factures hors périmètre "e-invoicing" ou dans le périmètre "e-invoicing"
en auto-facturation émises par l'Acheteur, l'adresse électronique de l'Acheteur
DOIT être dans un des schemesID de la liste de codes EAS (y compris un email,
avec schemeID (BT-49-1) = EM).

Pour les factures mises à disposition sur un portail, une adresse email (schemeID
(BT-49-1) = EM) de type "noreply@domaineduvendeur" peut être utilisée pour
signifier l'absence d'adresse électronique de l'Acheteur. 
BT-49, BT-49-1 

BR-FR-13 
Adresse
électronique du
Vendeur
Dès lors que la facture électronique doit être transmise et attend des statuts de
cycle de vie en retour, l'adresse électronique du Vendeur (BT-34) est
OBLIGATOIRE. C'est l'adresse électronique à laquelle la facture en auto-
facturation est transmise, ainsi que les statuts de cycle de vie à destination du
Vendeur.

Pour information (géré par d'autres règles) :
Pour les factures en auto-facturation relevant du périmètre "e-invoicing", cette
adresse électronique DOIT être de la forme "SIREN" ou "SIREN_XXX", le SIREN
étant celui du Vendeur renseigné en BT-30, avec un schemeId (BT-34-1) = 0225. 

Pour les factures hors périmètre "e-invoicing" ou dans le périmètre "e-invoicing"
mais pas en auto-facturation, l'adresse électronique du Vendeur DOIT être dans
un des schemesID de la liste de codes EAS (y compris un email, avec schemeID
(BT-34-1) = EM).

Pour les factures mises à disposition sur un portail, une adresse email de type
"noreply@domaineduvendeur" peut être utilisée pour signifier l'absence
d'adresse électronique du Vendeur. 
BT-34, BT-34-1 

BR-FR-14  Adresse de
Livraison
Certaines données liées à l'adresse de livraison BG-15 sont obligatoires si
l’adresse est différente de l`adresse de facturation (Acheteur - Bloc BG-8) et
seulement à partir du 01/09/2027. Les données obligatoires sont les suivantes :
• Adresse de livraison - Ligne 1 (BT-75)
• Localité Adresse de livraison (BT-77)
• Code postal Adresse de livraison (BT-78)
• Code Pays Adresse de livraison (BT-80)
Ces informations peuvent également être transmises à la ligne (si différent de
l'entête : Bloc EXT-FR-FE-BG-10 ). 

Ces données ne sont pas à transmettre pour les prestations de service

Règle de gestion métier mais ne peut pas être contrôlée d’un point de vue
applicatif 

BR-FR-15  Code Catégorie
de TVA
Seuls les codes de catégorie de TVA suivants seront acceptés :
S = Taux de TVA standard
E = Exonéré de TVA
AE = Autoliquidation de TVA
K = Exonération pour cause de livraison intracommunautaire
G = Exonération de TVA pour Export hors UE
O = Hors du périmètre d'application de la TVA
Z = Taux de TVA égal à 0 (cf. G1.47) 

Les codes de catégorie de TVA suivants ne sont pas pertinents en France :
L = Iles Canaries
M = Ceuta et Mellila 
BT-95, BT-102, BT-118, BT-
151
AFNOR XP Z12-0122025-11

_Source: `c:\Users\g.baudrit\source\repos\gbaudrit\conf-aimer-votre-llm\demo\ctxc-sample-spec\with-ctxc\spec/afnor 1.2/XP_Z12-012/XP_Z12-012.pdf` (page:42/page:42)_

### E-865a5e5b58e8

XP Z12-012 – Formats et Profils des messages Factures et Statuts de cycle de vie,
constitutifs du socle minimal applicable à la Réforme Facture Électronique en France

41 
CODE BR  Titre  Description  S'applique à 

BR-FR-16  Taux de TVA
autorisé
Le taux de la TVA applicable est conforme à la liste suivante :
Taux
0, 0.0, 0.00
10, 10.0, 10.00
13, 13.0, 13.00
20, 20.0, 20.00
8.5, 8.50
19.6, 19.60
2.1, 2.10
5.5, 5.50
7, 7.0, 7.00
20.6, 20.60
1.05
0.9, 0.90
1.75
9.2, 9.20
9.6, 9.60

Le taux est exprimé en pourcentage et non en coefficient (exemple : 20). Le
symbole « % ¬ n’est pas à indiquer;
Le séparateur (« . ») n'est pas comptabilisé dans les 5 caractères. 
BT-96, BT-103, BT-119, BT-
152 

BR-FR-17  Document
Justificatif
Pour qualifier les Pièces jointes, les codes suivants peuvent être utilisés :
RIB : pour un RIB (qui contient l'IBAN / N° de compte + nom de Titulaire)
LISIBLE : pour LA REPRÉSENTATION LISIBLE COMPLÈTE DE LA FACTURE.
FEUILLE_DE_STYLE : pour le feuille de style permettant de créer une
représentation lisible
PJA : pour une pièce jointe additionnelle
BORDEREAU_SUIVI : pour un bordereau de suivi
DOCUMENT_ANNEXE : pour un document annexe
BON_LIVRAISON : un bon de livraison
BON_COMMANDE: pour un Bon de Commande
BORDEREAU_SUIVI_VALIDATION : pour un bordereau de suivi et validation
ETAT_ACOMPTE : pour un Etat d'acompte
FACTURE_PAIEMENT_DIRECT : pour une facture de sous-traitant à payer en
direct
RECAPITULATIF_COTRAITANCE : pour lister l'ensemble des factures de co-
traitance à traiter ensemble. 
BT-123 

BR-FR-18  Document
Justificatif 
Il ne peut pas y avoir deux Documents additionnels (BG-24) pour lesquels la
description BT-123 est égale à LISIBLE  BT-123 

BR-FR-19  Limite 100 MO
Toutes les factures de moins de 100 MO doivent pourvoir être traitées par les
OD/SC (Solution Compatible) / Plateformes Agréées (PJ incluses).
C'est une règle métier qui autorise à poser un statut IRRECEVABLE sur un fichier
de facture de plus de 100 MO 
Un fichier facture à traiter 

BR-FR-20 
Qualification du
type de
traitement
attendu
Qualification du traitement attendu : Il est possible d'utiliser une Note pour
indiquer quel traitement est attendu sur la facture. Le code sujet DOIT être BAR
et les valeurs attendues, pour être signifiantes, DOIVENT être dans la liste ci-
dessous, avec leurs significations :
. B2B : signifie "relève du e-invoicing"
. B2BINT : signifie "relève du e-reporting des ventes B2Bint"
. B2C : signifie "relève du e-reporting B2C Ventes"
. OUTOFSCOPE : signifie "hors réforme"
. ARCHIVEONLY : signifie qu'il s'agit d'un AVOIR interne créé pour annuler une
facture REJETÉE ou REFUSÉE, et NE DOIT PAS faire l'objet d'un traitement e-
invoicing (pas de flux 1, pas de transmission au destinataire) 
BG-1, BT-21, BT-22 

BR-FR-21 
Adresse
électronique de
l'acheteur
Règle à exécuter si la facture fait l'objet d'un traitement B2B ou si elle contient
une note (BG-1) avec un code sujet (BT-21) = BAR et un contenu (BT-22) = B2B :

Si la facture n'est pas auto-facturée (BT-3 pas dans liste ('389', '501', '500', '471',
'473', '261', '502')

ALORS l'adresse de facturation électronique de l'ACHETEUR (BT-49) doit
commencer par le N° SIREN de l'ACHETEUR (BT-47) ET le schemeID de l'adresse
(BT-49-1) DOIT être égal à 0225 
BT-49, BT-49-1
AFNOR XP Z12-0122025-11

_Source: `c:\Users\g.baudrit\source\repos\gbaudrit\conf-aimer-votre-llm\demo\ctxc-sample-spec\with-ctxc\spec/afnor 1.2/XP_Z12-012/XP_Z12-012.pdf` (page:43/page:43)_

### E-b959868349f0

XP Z12-012 – Formats et Profils des messages Factures et Statuts de cycle de vie,
constitutifs du socle minimal applicable à la Réforme Facture Électronique en France

42 
CODE BR  Titre  Description  S'applique à 

BR-FR-22 
Adresse
électronique du
Vendeur
Règle à exécuter si la facture fait l'objet d'un traitement B2B ou si elle contient
une note (BG-1) avec un code sujet (BT-21) = BAR et un contenu (BT-22) = B2B :

Si la facture est auto-facturée (BT-3 dans liste ('389', '501', '500', '471', '473',
'261', '502')

ALORS l'adresse de facturation électronique du VENDEUR (BT-34) doit
commencer par le N° SIREN du VENDEUR (BT-30) ET le schemeID de l'adresse
(BT-30-1) DOIT être égal à 0225 
BT-34, BT-34-1 

BR-FR-23 
Adresse
électronique en
0225 
Toute adresse électronique avec schemeID = 0225 est composé de caractères
alphanumériques (A-Z, a-z, 0-9). Les caractères spéciaux suivants sont autorisés :
- tiret ("-")
- tiret bas (underscore : "_")
- pont (".")
BT-34 / BT-34-1, BT-49 /
BT-49-1
EXT-FR-FE-12 / EXT-FR-FE-
13, EXT-FR-FE-29 / EXT-FR-
FE-30, EXT-FR-FE-52 / EXT-
FR-FE-53, EXT-FR-FE-75 /
EXT-FR-FE-76, EXT-FR-FE-
98 /EXT-FR-FE-99, EXT-FR-
FE-121 / EXT-FR-FE-122 

BR-FR-24  Code_Routage
Toute IDprivé d'une partie avec schemeID = 0224 est composé de caractères
alphanumériques (A-Z, a-z, 0-9). Les caractères spéciaux suivants sont autorisés :
- tiret ("-")
- tiret bas (underscore : "_")
- pont (".") 
BT-29 / BT-29-1, BT-46 /
BT-46-1 

BR-FR-25  Adresse
électronique  Toute adresse électronique ne doit pas dépasser 125 caractères
BT-34, BT-49
EXT-FR-FE-12, EXT-FR-FE-
29 , EXT-FR-FE-52, EXT-FR-
FE-75, EXT-FR-FE-98, EXT-
FR-FE-121 

BR-FR-26  Code_Routage  Toute IDprivé d'une partie avec schemeID = 0224 ne doit pas dépasser 100
caractères 
BT-29 / BT-29-1, BT-46 /
BT-46-1 

BR-FR-27
Code et Nom
d'attribut
d'article 
Un groupe Attribut d'article (BG-32) DOIT contenir soit un nom d'attribut
d'article (BT-160), soit un Code d'attribut d'article (EXT-FR-FE-159) 
BG-32, BT-160, EXT-FR-FE-
159 

BR-FR-28
Valeur
d'attribut et
Valeur
d'attribut avec
unité de mesure 
Un groupe Attribut d'article (BG-32) DOIT contenir soit une valeur d'attribut
(BT-161), soit une valeur d'attribut avec unité de mesure (EXT-FR-FE-160), et
son unité de mesure (EXT-FR-FE-161) 
BT-161, EXT-FR-FE-160,
EXT-FR-FE-161 

BR-FR-29  Identifiant
d'objet facturé 
Parmi Identifiants d'Objets facturés (BT-18), les schémas d'identification (BT-
18-1) "AFL" et "AVV" ne DOIVENT être présents qu'UNE SEULE FOIS CHACUN  BT-18, BT-18-1 

BR-FR-30
Identifiant
d'objet facturé à
la ligne
Parmi Identifiants d'Objets facturés à la ligne (BT-128), les schémas
d'identification (BT-128-1) "AFL" et "AVV" ne DOIVENT être présents qu'UNE
SEULE FOIS CHACUN 
BT-128, BT-128-1 

BR-FR-31  Note avec code
sujet BAR
En cas de multiplicité de notes (BG-1) ayant un code sujet (BT-21) = BAR, une
seule des valeurs suivantes peuvent être présentes dans le contenu (BT-22) :
. B2B
. B2BINT
. B2C
. OUTOFSCOPE
. ARCHIVEONLY 
BG-1, BT-21, BT-22 

BR-FR-CO-01  Pas d'antidatage
dans l'avenir 
La date de facture BT-2 DOIT ETRE antérieure ou égale à date d'application du
contrôle de conformité  BT-2
AFNOR XP Z12-0122025-11

_Source: `c:\Users\g.baudrit\source\repos\gbaudrit\conf-aimer-votre-llm\demo\ctxc-sample-spec\with-ctxc\spec/afnor 1.2/XP_Z12-012/XP_Z12-012.pdf` (page:44/page:44)_

### E-7aa21cca073c

XP Z12-012 – Formats et Profils des messages Factures et Statuts de cycle de vie,
constitutifs du socle minimal applicable à la Réforme Facture Électronique en France

43 
CODE BR  Titre  Description  S'applique à 

BR-FR-CO-02  Unicité de la
facture
L'identifiant unique de facture doit être composé des éléments suivants :
- Numéro de facture (BT-1)
- Année de production de la facture (Issue de la date d'émission de la facture
(BT-2))
- Identifiant légal du Vendeur : numéro SIREN (BT-30)

L’unicité de la facture vise à éviter les erreurs de facturation (double facturation
notamment). Une facture présentant des informations similaires
cumulativement sur ces trois données par rapport à une facture précédemment
envoyée fera l’objet d’un rejet par les plateformes;
Le contrôle d’unicité est systématiquement bloquant.

En cas de mandat de facturation, le numéro de facture doit comporter une racine
propre au mandataire pour éviter les doublons de facture avec celles de son
mandant. 

Le numéro de facture doit respecter la règlementation du BOFIP suivante:
BOI-TVA-DECLA-30-20-20-10 du 18/10/2023
Section : A. La numérotation des factures 
BT-1, BT-2, BT-30 

BR-FR-CO-03  Codestypes
documents
Si le codetype de la facture (BT-3) est égal à 262 (Avoir Remise Globale), alors :
- Le numéro de contrat (BT-12) DOIT être présent
- La période de facturation (BG-14) DOIT être présente 
BT-3, BT-12, BG-14 

BR-FR-CO-04  Codestypes
documents
Si le codetype de la facture (BT-3) est dans la liste suivante :

Factures rectificatives :
- Facture rectificative (384)
- Facture rectificative auto-facturée (471) (*)
- Facture rectificative affacturée (472) (*)
- Facture rectificative auto-facturée affacturée (473) (*)

Alors UNE ET UNE SEULE Référence à une facture antérieure (BT-25) DOIT être
présente, ainsi que sa Date (BT-26) 
BT-3, BT-25, BT-26 

BR-FR-CO-05  Codestypes
documents
Si le codetype de la facture (BT-3) est dans la liste suivante :

Avoirs :
- Avoir auto-facturé (261)
- Avoir (381)
- Avoir affacturé (396)
- Avoir auto-facturé affacturé (502) (*)
- Avoir de facture d'acompte (503) (*)

Alors AU MOINS une Référence à une facture antérieure (BT-25) DOIT être
présente ainsi que sa Date (BT-26) OU BIEN une Référence à une facture
antérieure en ligne (EXT-FR-FE-136) DOIT être présente DANS CHAQUE ligne
(BG-25), ainsi que sa date (EXT-FR-FE-138) 
BT-3, BT-25, EXT-FR-FE-
136, EXT-FR-FE-138 

BR-FR-CO-06 
Date de
versement de
l'acompte
Si le codetype de facture (BT-3) est:
- Facture d'acompte (386)
- Facture d’acompte auto-facturé (500) (*)
- Avoir de facture d'acompte (503) (*)
et si la date de versement de l'acompte est déterminée / connue et qu'elle est
différente de la date d'émission alors la date de versement de l’acompte doit être
obligatoirement complétée en BT-9 

Règle de gestion métier mais ne peut pas être contrôlée d’un point de vue
applicatif 
BT-9
AFNOR XP Z12-0122025-11

_Source: `c:\Users\g.baudrit\source\repos\gbaudrit\conf-aimer-votre-llm\demo\ctxc-sample-spec\with-ctxc\spec/afnor 1.2/XP_Z12-012/XP_Z12-012.pdf` (page:45/page:45)_

### E-0f3fba03dfce

XP Z12-012 – Formats et Profils des messages Factures et Statuts de cycle de vie,
constitutifs du socle minimal applicable à la Réforme Facture Électronique en France

44 
CODE BR  Titre  Description  S'applique à 

BR-FR-CO-07 
Date de
versement de
l'acompte
La Date d'échéance (BT-9), si présente, DOIT être postérieure ou égale à la Date
de facture (BT-2),
SAUF SI la facture est de type acompte (BT-3) :
- Facture d'acompte (386)
- Facture d’acompte auto-facturé (500) (*)
- Avoir de facture d'acompte (503) (*)

OU SAUF SI le Cadre de facturation (BT-23) est égal à :
- B2 : Dépôt d'une facture de bien déjà payée
- S2 : Dépôt d'une facture de prestation de service déjà payée
- M2 : Dépôt d'une facture double déjà payée 
BT-9, BT-3, BT-2, BT-23 

BR-FR-CO-08 
Cadre de
facturation
Facture
définitive
Si le cadre de facturation (BT-23) est :
- B4 : Factures définitives (après acompte) de bien
- S4 : Factures définitives (après acompte) de prestation de service
- M4 : Factures définitives (après acompte) double

ALORS le type de facture ne peut pas être :
- Facture d'acompte (386)
- Facture d’acompte auto-facturée (500)
- Avoir de facture d'acompte (503) 
BT-23, BT-3 

BR-FR-CO-09 
Cadre de
facturation Déjà
payé
Si le cadre de facturation (BT-23) est :
- B2 : Dépôt d'une facture de bien déjà payée
- S2 : Dépôt d'une facture de prestation de service déjà payée
- M2 : Dépôt d'une facture double déjà payée

ALORS
- Le montant déjà payé (BT-113) est égal Montant total de la Facture avec la TVA
(BT-112)
- le Net à payer (BT-115) est égal à 0
- la Date d'échéance (BT-9) DOIT indiquer la date à laquelle la facture a été payée 
BT-23, BT-9, BT-112, BT-
113, BT-115 

BR-FR-CO-10  ID privés des
parties 
Lorsque les Identifiants privés des acteurs sont multiples (par exemple BT-29),
ils doivent être qualifiés par un identifiant du schéma (BT-29-1), il ne peut y
avoir 2 identifiants privés avec le même identifiant du schéma
BT-29, BT-46, BT-60, EXT-
FR-FE-06, EXT-FR-FE-46,
EXT-FR-FE-69, EXT-FR-FE-
92, EXT-FR-FE-115, BT-71,
EXT-FR-FE-146 

BR-FR-CO-11  ID privés des
parties
Les identifiants privés des parties permettent de fournir des identifiants
spécifiques, qualifiés par l'identifiant du schema (codelist ICD). Ainsi :
- un SIRET (identifiant du schema = 0009)
- un CODE_ROUTAGE (identifiant du schema = 0224)
- Le SIREN de l'assujetti unique du Vendeur (identifiant du schema : 0231),
uniquement en BT-29 
BT-29, BT-46, BT-60, EXT-
FR-FE-06, EXT-FR-FE-46,
EXT-FR-FE-69, EXT-FR-FE-
92, EXT-FR-FE-115, BT-71,
EXT-FR-FE-146 

BR-FR-CO-12  Montant de TVA
en EURO
Si la Devise de facture (BT-5) est différente de EUR, alors
- la devise de comptabilité BT-6 DOIT être présente et égale à EUR
- Le montant de TVA en devise de comptabilité (et donc en EURO BT-111 DOIT
être présente, et BT-111-1 DOIT être égal à EUR 
BT-5, BT-6, BT-110, BT-111 

BR-FR-CO-13  Assujetti Unique
Vendeur
S'il existe une occurrence de BT-29 avec un schéma d'identification BT-29-1 =
0231, alors le Vendeur est Membre d'un Assujetti Unique (AU), et le numéro de
SIREN de l'Assujetti Unique en BT-29 avec le schéma d'identification (BT-29-1) =
0231 DOIT être présent dans l'Annuaire PPF 
BT-29, BT-29-1 

BR-FR-CO-14  Assujetti Unique
Vendeur
S'il existe une occurrence de BT-29 avec un schéma d'identification BT-29-1 =
0231, alors le Vendeur est Membre d'un Assujetti Unique (AU), et un bloc BG-1
DOIT être présent avec pour Code sujet (BT-21) = "TXD" ET un texte de note
(BT-22) = "MEMBRE_ASSUJETTI_UNIQUE". 
BT-29, BT-29-1, BT-21, BT-
22 

BR-FR-CO-15  Assujetti Unique
Vendeur
S'il existe une occurrence de BT-29 avec un schéma d'identification BT-29-1 =
0231, alors le Vendeur est Membre d'un Assujetti Unique (AU) et le Bloc du
Représentant fiscal du Vendeur (BG-11) DOIT être présent et contient les
informations de l'Assujetti Unique (et en particulier son n° de TVA en BT-63) 
BT-29, BT-29-1, BG-11, BT-
63
AFNOR XP Z12-0122025-11

_Source: `c:\Users\g.baudrit\source\repos\gbaudrit\conf-aimer-votre-llm\demo\ctxc-sample-spec\with-ctxc\spec/afnor 1.2/XP_Z12-012/XP_Z12-012.pdf` (page:46/page:46)_

### E-146bdb4c118c

XP Z12-012 – Formats et Profils des messages Factures et Statuts de cycle de vie,
constitutifs du socle minimal applicable à la Réforme Facture Électronique en France

45 
CODE BR  Titre  Description  S'applique à 

BR-FR-CO-16  Franchise en
base
Les factures en franchise en base de TVA comportent un bloc de détail TVA avec
une BT-118 = "E" ET une raison d'exemption en CODE BT-121 = "VATEX-FR-
FRANCHISE". Si le Vendeur n'a pas de n° de TVA, il doit répéter son n° de SIREN
en BT-32 
BT-118, BT-121, BT-120 

BR-FR-CO-17  Date de
Livraison
Donnée à fournir dans la mesure où elle est déterminée et différente de la date
d'émission de la facture (art. 242 nonies A 10°). Dans une facture, peut être
renseignée :
- la date de livraison ou la date de fin d'exécution de la prestation (BT-72)
- ou la date de livraison à la ligne, en cas de multi-livraisons (EXT-FR-FE-BG-11)
- ou une période de facturation en cas de facture périodique ou récapitulative
(article 289 - I.3 du CGI) (BG-26)

Règle de gestion métier mais ne peut pas être contrôlée d’un point de vue
applicatif 
BT-72, BG-14, EXT-FR-FE-
BG-11 

BR-FR-DEC-
01  Montant 19,2
Le montant dans une facture est exprimé par un nombre sur 19 positions, et ne
peut comporter plus de 2 décimales.
Le séparateur entre le nombre entier et les décimales est un point (« . »).
Le signe « - » devant le montant compte comme un caractère.
Si le nombre total de chiffres du nombre (partie entière et partie décimale
comprises) dépasse 19 caractères, le montant sera rejeté. Le séparateur (« . »)
n'est pas comptabilisé dans les 19 caractères.
BT-92, BT-93, BT-99, BT-
100, BT-106, BT-107, BT-
108, BT-109, BT-110, BT-
111, BT-112, BT-113, BT-
114, BT-115, BT-116, BT-
117, BT-131, BT-136, BT-
137, BT-141, BT-142 

BR-FR-DEC-
02  Quantité 19,4
La quantité facturée dans une facture est exprimé par un nombre sur 19
positions, et ne peut comporter plus de 4 décimales.
Le séparateur entre le nombre entier et les décimales est un point (« . »).
Le signe « - » devant le montant compte comme un caractère.
Si le nombre total de chiffres du nombre (partie entière et partie décimale
comprises) dépasse 19 caractères, le montant sera rejeté. Le séparateur (« . »)
n'est pas comptabilisé dans les 19 caractères. 
BT-129, BT-149 

BR-FR-DEC-
03 
Prix Unitaire
19,6
Le montant dans une facture est exprimé par un nombre sur 19 positions, et ne
peut comporter plus de 6 décimales.
Le séparateur entre le nombre entier et les décimales est un point (« . »).
Il n'y a pas de signe (toujours positif)
Si le nombre total de chiffres du nombre (partie entière et partie décimale
comprises) dépasse 19 caractères, le montant sera rejeté. Le séparateur (« . »)
n'est pas comptabilisé dans les 19 caractères. 
BT-146, BT-147, BT-148 

BR-FR-DEC-
04 
Pourcentage
Taux TVA 4.2
Le taux de TVA dans une facture est exprimé par un nombre sur 4 positions, et
ne peut comporter plus de 2 décimales.
Le séparateur entre le nombre entier et les décimales est un point (« . »).
Il n'y a pas de signe (toujours positif)
Si le nombre total de chiffres du nombre (partie entière et partie décimale
comprises) dépasse 4 caractères, le montant sera rejeté. Le séparateur (« . »)
n'est pas comptabilisé dans les 4 caractères. 
BT-96, BT-103, BT-119, BT-
152

4.5.2 Les règles de mapping pour constituer les flux 1 et 10.1

Le Tableau ci-dessous détaille les règles de mapping à partir des données de factures de vente à émettre ou
émises pour créer les flux 1 ou flux 10.1
AFNOR XP Z12-0122025-11

_Source: `c:\Users\g.baudrit\source\repos\gbaudrit\conf-aimer-votre-llm\demo\ctxc-sample-spec\with-ctxc\spec/afnor 1.2/XP_Z12-012/XP_Z12-012.pdf` (page:47/page:47)_

### E-a775b8d51181

XP Z12-012 – Formats et Profils des messages Factures et Statuts de cycle de vie,
constitutifs du socle minimal applicable à la Réforme Facture Électronique en France

46 
CODE BR  Titre  Description  S'applique à 

BR-FR-MAP-01 
ID de facture
caractères
autorisés
Pour la constitution du flux 1 ou 10.1, flux 6 pour le PPF, l'identifiant de
facture est réduit à 20 caractères s'il en contient plus de 20, de la façon
suivante :
- Troncature à 19 caractères à droite
- ajout d'un "T" à gauche pour signifier la troncature

Exemple : 987654321-123456782-F202500125
donne T23456782-F202500125 
BT-1, BT-25, EXT-FR-FE-136 

BR-FR-MAP-02  Code type
documents
Si le code type de la facture (BT-3) est égal à 262 (Avoir pour Remise
Globale), alors :
Pour le flux 1 :
- le code type de la facture (BT-3 = 262) DOIT être mappé en 381 dans le flux
1 (BT-3)
- la référence de Contrat (BT-12) de la facture doit être mappée dans la
Référence à une facture antérieure (BT-25) du Flux 1, et la Date de début de
période de facturation (BT-73) DOIT être mappée dans la Date de facture
antérieure (BT-26).

Pour le flux 10.1 :
- le code type de la facture (BT-3 = 262) DOIT être mappé en 381 dans le flux
10.1 (TT-21)
- la référence de Contrat (BT-12) de la facture DOIT être mappée dans la
Référence à une facture antérieure (TT-30) et la Date de début de période de
facturation (BT-73) DOIT être mappée dans la Date de facture antérieure
(TT-31) 
BT-3, BT-12, BG-14 

BR-FR-MAP-03  TVA sur les
débits
Il est rappelé que l'option de TVA sur les débits est générale et l'emporte sur
l'ensemble des factures émises. En cas de prestations de services et d'option
pour la TVA sur les débits, l'exigibilité de la TVA est due au moment de
l'inscription de la somme correspondante au débit du compte « client ». En
pratique, le débit coïncide le plus souvent avec la facturation. Il est souligné
que l'option d'acquitter la taxe d'après les débits ne peut avoir pour effet de
retarder l'exigibilité de la taxe.

L'indication de l'exigibilité de la TVA pour les débits est indiquée en BT-8
avec les valeurs 5 en CII et 3 en UBL.
BT-8 est obligatoire pour les factures de service dès lors que l'assujetti
Vendeur a opté pour les débits.
Dans le flux 10.1 la valeur de BT-8 est mappée en TT-24 
BT-8 

BR-FR-MAP-04  Note mapping
Seules les notes (BG-3) avec les codes sujets (BT-21) égaux à AAB, BLU et
TXD DOIVENT être transmises dans le Flux 1 ou le flux 10.1 (TT-26 = BT-21,
TT-27 = BT-22).

Les notes avec d’autres codes sujet peuvent être transmises, ou pas en flux
10 ou 10.1 
BT-22, BT-21, TT-26, TT-27 

BR-FR-MAP-05  TVA en EURO
dans le flux 10.1 
Si la Devise de facture (BT-5) est EUR, alors TT-52 est égal à BT-110, sinon,
TT-52 est égal à BT-111 
BT-5, BT-6, BT-110, BT-111,
TT-52 

BR-FR-MAP-06  Assujetti Unique
Vendeur
S'il existe une occurrence du bloc Note (BG-1) avec pour Code sujet (BT-21)
= "TXD" ET un texte de note (BT-22) = "MEMBRE_ASSUJETTI_UNIQUE", alors
il faut transcoder "MEMBRE_ASSUJETTI_UNIQUE" en "Membre d'un assujetti
unique" dans la BT-22 du flux 1 
BT-21, BT-22 

BR-FR-MAP-07  Assujetti Unique
Vendeur
S'il existe une occurrence du bloc Note (BG-1) avec pour Code sujet (BT-21)
= "TXD" ET un texte de note (BT-22) = "MEMBRE_ASSUJETTI_UNIQUE", alors
il faut transcoder "MEMBRE_ASSUJETTI_UNIQUE" en "Membre d'un assujetti
unique" dans la TT-27 du flux 10.1 
BT-21, BT-22, TT-27 

BR-FR-MAP-08  Franchise en
base
Si une facture contient un bloc de détail TVA (BG-23) contenant un code
Catégorie BT-118 = "E" ET un code VATEX BT-121 = "VATEX-FR-
FRANCHISE", ALORS
l'action à opérer dans le flux 1 est la suivante :
- transcoder la BT-118 en "Z"
- supprimer VATEX BT-121 et la raison en texte BT-120, si présentes 
BT-118, BT-121, BT-120
AFNOR XP Z12-0122025-11

_Source: `c:\Users\g.baudrit\source\repos\gbaudrit\conf-aimer-votre-llm\demo\ctxc-sample-spec\with-ctxc\spec/afnor 1.2/XP_Z12-012/XP_Z12-012.pdf` (page:48/page:48)_

### E-bea9272f5f69

XP Z12-012 – Formats et Profils des messages Factures et Statuts de cycle de vie,
constitutifs du socle minimal applicable à la Réforme Facture Électronique en France

47 
CODE BR  Titre  Description  S'applique à 

BR-FR-MAP-09  Franchise en
base
Si une facture contient un bloc de détail TVA (BG-23) contenant un code
Catégorie BT-118 = "E" ET un code VATEX BT-121 = "VATEX-FR-
FRANCHISE", alors il faut transcoder la BT-118 en "Z" et ne pas transmettre
le code VATEX BT-121, ni la raison en texte BT-120, si présente, dans le flux
10.1 (TT-56) 
BT-118, BT-121, BT-120 

BR-FR-MAP-10  Adresse de
Livraison
Si BT-80 est présent, il y a une Adresse de Livraison et il faut renseigner tous
les champs présents du groupe Adresse de Livraison (BG-15) en flux 1 ou
10.1, et en cas d'absence de la Ligne 1 (BT-75), du Code postal (BT-78) ou
Localité (BT-77), fournir la donnée "-" à la place. 
BG-15, BT-75, BT-77, BT-78,
BT-80 

BR-FR-MAP-11  Adresse de
Livraison
Si EXT-FR-FE-157 est présent, il y a une Adresse de Livraison en ligne et il
faut renseigner tous les champs présents du groupe Adresse de Livraison
(EXT-FR-FE-BG-10) sauf l'identifiant global du lieu (EXT-FR-FE-146, EXT-
FR-FE-148) en flux 1 ou 10.1, et en cas d'absence de la Ligne 1 (EXT-FR-FE-
151), du Code postal (EXT-FR-FE-154) ou Localité (EXT-FR-FE-155), fournir
la donnée "-" à la place. 
EXT-FR-FE-BG-10, EXT-FR-
FE-151, EXT-FR-FE-154,
EXT-FR-FE-155, EXT-FR-FE-
157 

BR-FR-MAP-12  Taux de TVA
autorisé
Le taux de la TVA applicable doit être mappé vers les données suivantes :
Taux
0
10
13
20
8.5
19.6
2.1
5.5
7
20.6
1.05
0.9
1.75
9.2
9.6

Le taux est exprimé en pourcentage et non en coefficient (exemple : 20). Le
symbole « % ¬ n’est pas à indiquer;
Le séparateur (« . ») n'est pas comptabilisé dans les 5 caractères. 
BT-96, BT-103, BT-119, BT-
152 

BR-FR-MAP-13  Donnée Flux 1,
10.1 CIBLE 
Cette donnée n'est pas exigée au DEMARRAGE de la réforme dans les flux 1
et 10.1, mais en CIBLE (01/09/2027)
BT-26, BG-15, BT-75, BT-76,
BT-165, BT-77, BT-78, BT-
79, BT-80, BG-20, BT-92, BT-
95, BT-96, BG-25, BT-127-
00, EXT-FR-FE-183, BT-127,
BT-129, BT-130, EXT-FR-FE-
BG-06, EXT-FR-FE-138, EXT-
FR-FE-BG-10, EXT-FR-FE-
149, EXT-FR-FE-150, EXT-
FR-FE-151, EXT-FR-FE-152,
EXT-FR-FE-153, EXT-FR-FE-
154, EXT-FR-FE-155, EXT-
FR-FE-156, EXT-FR-FE-157,
EXT-FR-FE-BG-11, EXT-FR-
FE-158, BG-26, BT-134, BT-
135, BG-27, BT-136, BG-28,
BT-141, BG-29, BT-146, BT-
147, BT-148, BG-31, BT-153
AFNOR XP Z12-0122025-11

_Source: `c:\Users\g.baudrit\source\repos\gbaudrit\conf-aimer-votre-llm\demo\ctxc-sample-spec\with-ctxc\spec/afnor 1.2/XP_Z12-012/XP_Z12-012.pdf` (page:49/page:49)_

### E-1c91c6e5f5a4

XP Z12-012 – Formats et Profils des messages Factures et Statuts de cycle de vie,
constitutifs du socle minimal applicable à la Réforme Facture Électronique en France

48 
CODE BR  Titre  Description  S'applique à 

BR-FR-MAP-14  Code Pays
Les Codes Pays des DOM/COM ci-dessous doivent être remplacés par FR
dans les flux 1 et 10 

Guyane française (la ) => GF
Terres australes françaises (les) TF
Guadeloupe (la) => GP
Guyana (le) => GY
Martinique (la) =>MQ
Mayotte => YT
Réunion (La) =>RE
Saint-Barthélemy => BL
Saint-Martin (partie française) => MF
Saint-Pierre-et-Miquelon => PM 
BT-40, BT-55, BT-80, EXT-
FR-FE-157 

BR-FR-MAP-15  MAPPING BT-24
Pour le flux 1, BT-24 doit être égal à :
urn.cpro.gouv.fr:1p0:einvoicingextract#Base pour le profil DEMARRAGE,
sans les lignes
urn.cpro.gouv.fr:1p0:einvoicingextract#Full pour le profil complet (CIBLE) 
BT-24 

BR-FR-MAP-16 
Identifiant du
Vendeur et de
l'Acheteur en
flux 10
L'identifiant du Vendeur (TT-33-1) renseigné est défini par le qualifiant :
- "0002" --> SIREN sur 9 caractères
- "0223" --> UE_HORS_FRANCE (correspond à l'identifiant de TVA
intracommunautaire) sur 18 caractères
- "0227" --> HORS_UE (dont Wallis et Futuna) (correspond au code Pays et
aux 16 premiers caractères de la raison sociale) sur 18 caractères
- "0228" --> RIDET sur 9 ou 10 caractères
- "0229" --> TAHITI sur 9 caractères

L'identifiant de l'Acheteur (TT-37) renseigné est défini par le qualifiant :
- "0002" --> SIREN sur 9 caractères
- "0223" --> UE_HORS_FRANCE (correspond à l'identifiant de TVA
intracommunautaire) sur 18 caractères
- "0227" --> HORS_UE (dont Wallis et Futuna) (correspond au code Pays et
aux 16 premiers caractères de la raison sociale) sur 18 caractères
- "0228" --> RIDET sur 9 ou 10 caractères
- "0229" --> TAHITI sur 9 caractères 
BT-30 

BR-FR-MAP-17  TRONQUER A
255 Caractères 
Si la longueur de la donnée fait plus de 255 caractères
ALORS pour la même donnée à reporter dans le flux 1
Il ne faut conserver que les 255 premiers caractères à gauche et supprimer
au-delà
BT-75, BT-76, BT-165, BT-
77, BT-79, EXT-FR-FE-151,
EXT-FR-FE-152, EXT-FR-FE-
153, EXT-FR-FE-154, EXT-
FR-FE-156, BT-153 

BR-FR-MAP-18  TRONQUER A
1024 Caractères
Si la longueur de la donnée fait plus de1024 caractères
ALORS pour la même donnée à reporter dans le flux 1
Il ne faut conserver que les 1024 premiers caractères à gauche et supprimer
au-delà 
BT-22, BT-120, BT-127 

BR-FR-MAP-19  TRONQUER A
10 Caractères
Si la longueur de la donnée fait plus de 10 caractères
ALORS pour la même donnée à reporter dans le flux 1
Il ne faut conserver que les 10 premiers caractères à gauche et supprimer
au-delà 
BT-78, EXT-FR-FE-155 

BR-FR-MAP-20  TRONQUER A
100 Caractères
Si la longueur de la donnée fait plus de 100 caractères
ALORS pour la même donnée à reporter dans le flux 1
Il ne faut conserver que les 100 premiers caractères à gauche et supprimer
au-delà 
EXT-FR-FE-149 

BR-FR-MAP-21  Prix Brut
En cas d'absence du Prix Unitaire Brut (BT-148) dans la facture,
ALORS, pour la création du flux 1 :
il faut indiquer le PU Net (BT-146) dans le PU Brut (BT-148) 
BT-148 

BR-FR-MAP-22  Prix Brut
En cas d'absence du Prix Unitaire Brut (BT-148) dans la facture,
ALORS, pour la création du flux 10.1 :
il faut indiquer le PU Net (BT-146) dans le PU Brut (TT-71) 
BT-148
AFNOR XP Z12-0122025-11

_Source: `c:\Users\g.baudrit\source\repos\gbaudrit\conf-aimer-votre-llm\demo\ctxc-sample-spec\with-ctxc\spec/afnor 1.2/XP_Z12-012/XP_Z12-012.pdf` (page:50/page:50)_

### E-0d4c4d4dbcfb

XP Z12-012 – Formats et Profils des messages Factures et Statuts de cycle de vie,
constitutifs du socle minimal applicable à la Réforme Facture Électronique en France

49 
CODE BR  Titre  Description  S'applique à 

BR-FR-MAP-23  Format Date 
Dans le flux 10.0, les dates sont au format AAAMMJJ
DONC, pour les flux 2, 8, et 9 sous syntaxe UBL, il faut supprimer les "-"
EXEMPLE : 2025-02-12 devient 20250212
BT-2/TT-20, BT-9/TT-201,
BT-26//TT-31, BT-72/TT-
41, BT-73/TT-42, BT-74/TT-
43, EXT-FR-FE-138/TT-301,
BT-134/TT-65, BT-135/TT-
66 

BR-FR-MAP-24
Exclusion des
lignes GROUP et
INFORMATION
Seules les lignes (BG-25) sans sous-type de ligne (EXT-FR-FE-163) ou avec
une valeur de sous-type de ligne égale à "DETAIL", DOIVENT être prises en
compte pour la création des flux 1 ou flux 10.1. 
EXT-FR-FE-163 

BR-FR-MAP-25
Raison
d'exemption en
code et en texte
dans les flux 1 et
10.1
Dans une ligne de ventilation de TVA (BG-23), si la raison d'exemption en
code (BT-121) est présente, et que la raison d'exemption en texte (BT-120)
est absente, alors il faut indiquer dans la valeur d'exemption en texte (BT-
120) du flux 1 le texte correspondant au code VATEX présent en BT-121, tel
que listé dans la liste de codes VATEX 
BT-120 

BR-FR-MAP-26
Raison
d'exemption en
code et en texte
dans les flux 1 et
10.1
Dans une ligne de ventilation de TVA (BG-23), si la raison d'exemption en
code (BT-121) est présente, et que la raison d'exemption en texte (BT-120)
est absente, alors il faut indiquer dans la valeur d'exemption en texte (TT-
58) du flux 10.1 le texte correspondant au code VATEX présent en BT-121
(et à renseigner en TT-59), tel que listé dans la liste de codes VATEX 
TT-58 

BR-FR-MAP-27
Raison
d'exemption en
code et en texte
dans les flux 1 et
10.1 
Dans une ligne de ventilation de TVA (BG-23), si la raison d'exemption en
texte (BT-120) est présente, et que la raison d'exemption en code (BT-121)
est absente, alors il faut indiquer dans le champ d'exemption en code (BT-
121) du flux 1 la valeur "NR" 
BT-121 

BR-FR-MAP-28
Raison
d'exemption en
code et en texte
dans les flux 1 et
10.1 
Dans une ligne de ventilation de TVA (BG-23), si la raison d'exemption en
texte (BT-120) est présente, et que la raison d'exemption en code (BT-121)
est absente, alors il faut indiquer dans le champ d'exemption en code (TT-
59) du flux 10.1 la valeur "NR" 
TT-59 

BR-FR-MAP-29 
Code exigibilité
TVA, Option
pour les débits
L'exigibilité de la TVA sur les Débits peut correspondre à la date de facture
(code 5 en CII ou 3 en UBL), ou à la date de livraison (29 en CII ou 35 en
UBL). Mais le PPF attend uniquement 5 (CII) ou 3 (UBL).

Si BT-8 est égal à 29 en CII ou 35 en UBL, alors dans le flux 1 ou le flux 10.1
(TT-24), il faut renseigner respectivement 5 (CII) ou 3 (UBL). 
BT-8, TT-24

4.5.3 Les règles de contrôle CPRO pour les factures B2G à destination du secteur public

L'ensemble des règles ci-dessous s'applique si la facture est dans le périmètre B2G. Ceci peut être déterminé
du fait d`une indication dans la facture (au travers d’une Note avec Code sujet ADN et contenu B2G), ou bien
du fait d`une indication dans le canal de transmission entre l’émetteur de la facture et sa PA-E (Plateforme
Agréée d’Émission) et / ou suite à la consultation de l`annuaire par la PA-E permettant de déterminer que
l'Acheteur est un acteur public.

Ceci se traduit par une condition générale pour appliquer l’ensemble des contrôles additionnels exigés pour
les factures B2G et listés ci-dessous :

• S’il existe une note (BG-1), avec un code sujet (BT-21) égal à ADN et le contenu (BT-22) est égal à B2G
ou si le traitement identifie qu`il s’agit d`une facture B2G;
AFNOR XP Z12-0122025-11

_Source: `c:\Users\g.baudrit\source\repos\gbaudrit\conf-aimer-votre-llm\demo\ctxc-sample-spec\with-ctxc\spec/afnor 1.2/XP_Z12-012/XP_Z12-012.pdf` (page:51/page:51)_

### E-368e3eca8bb5

XP Z12-012 – Formats et Profils des messages Factures et Statuts de cycle de vie,
constitutifs du socle minimal applicable à la Réforme Facture Électronique en France

50 
Le tableau ci-dessous liste les règles de gestion « CHORUS PRO » applicables aux factures B2G : 

CODE BR  Titre  Description  S'applique à 

BR-FR-CPRO-01 
Qualification
d'un
contrat/marché
Cette règle de gestion est applicable uniquement pour le B2G :
Les valeurs possibles sont :
MARCHE
CONTRAT 

Si le type de contrat (EXT-FR-FE-01) est présent alors les seules valeurs possibles sont
CONTRAT ou MARCHE 
EXT-FR-FE-01 

BR-FR-CPRO-02  ID de facture
Règle de gestion applicable pour le B2G :

L'identifiant de facture DOIT ÊTRE limité à 20 caractères 

Le nombre de caractères des numéros de facture (BT-1), de facture antérieure (BT-25),
de facture antérieure en ligne (EXT-FR-FE-136), DOIVENT être inférieurs ou égal à 20. 
BT-1, BT-25, EXT-
FR-FE-136 

BR-FR-CPRO-03  ID privés des
parties
Règle de gestion est applicable uniquement pour le B2G :

L'ID privé du Vendeur (BT-29) DOIT être présent, avec un schemeId (BT-29-1) égal à
0009, 0223, 0226, 0227, 0228 ou 0229.

Pour information, l'identifiant doit être valorisé avec l'une des valeurs ci-dessous et
respecter la longueur :
- SIRET sur 14 caractères (identifiant de schéma : 0009)
- UE_HORS_FRANCE (correspond à l'identifiant de TVA intracommunautaire) sur 18
caractères (identifiant de schéma : 0223)
- HORS_UE (dont Wallis et Futuna) (correspond au code Pays et les 16 premiers
caractères de la raison sociale) sur 18 caractères (identifiant de schéma : 0227)
- RIDET sur 9 ou 10 caractères (identifiant de schéma : 0228)
- TAHITI sur 9 caractères (identifiant de schéma : 0229)
- PARTICULIER sur 80 caractères (identifiant de schéma : 0226)
L'identifiant de type 0226 est spécifique au B2G (Le destinataire de la facture (BG-7)
doit être exclusivement une structure publique). A ne pas utiliser en B2B, B2B
international ou B2C). L’identifiant est constitué de 80 caractères maximum respectant
cet ordre précis :
• Caractère n°1 : le genre, représenté par 1 chiffre (1 pour un homme et 2 pour une
femme) ;
• Caractères n°2 et n°3 : l’année de naissance, représentée par ses 2 derniers chiffres ;
• Caractères n°4 et n°5 : le mois de naissance, représenté par 2 chiffres ;
• Caractères n°6 à n°10 : le lieu de naissance, représenté par 5 chiffres.
• Caractères n°11 à 80 :
- Les 35 premiers caractères du nom de famille (suppression des espaces)
- Les 35 premiers caractères du prénom (suppression des espaces) 
BT-29 

BR-FR-CPRO-04  ID privés des
parties
Si le schéma d'identification de l'ID privé du Vendeur (BT-29-1) est égal à 0223, alors le
nombre de caractère DOIT être inférieur à 18

Il doit correspondre au n° de TVA du Vendeur (aussi présent en BT-31) 
BT-29 

BR-FR-CPRO-05  ID privés des
parties
Si le schéma d'identification de l'ID privé du Vendeur (BT-29-1) est égal à 0227, alors le
nombre de caractère DOIT être inférieur à 18.

Il doit correspondre au code pays sur 2 caractères suivi des 16 premiers caractères de
la raison sociale telle que renseignée dans le référentiel ChorusPro 
BT-29 

BR-FR-CPRO-06  ID privés des
parties
Si le schéma d'identification de l'ID privé du Vendeur (BT-29-1) est égal à 0228, alors le
nombre de caractère DOIT être compris entre 9 et 10

Il doit correspondre au RIDET 
BT-29 

BR-FR-CPRO-07  ID privés des
parties
Si le schéma d'identification de l'ID privé du Vendeur (BT-29-1) est égal à 0229, alors le
nombre de caractère DOIT être compris entre 9 et 10 

Il doit correspondre à un Identifiant TAHITI 
BT-29
AFNOR XP Z12-0122025-11

_Source: `c:\Users\g.baudrit\source\repos\gbaudrit\conf-aimer-votre-llm\demo\ctxc-sample-spec\with-ctxc\spec/afnor 1.2/XP_Z12-012/XP_Z12-012.pdf` (page:52/page:52)_

### E-d4921518d653

XP Z12-012 – Formats et Profils des messages Factures et Statuts de cycle de vie,
constitutifs du socle minimal applicable à la Réforme Facture Électronique en France

51 
CODE BR  Titre  Description  S'applique à 

BR-FR-CPRO-08  ID privés des
parties
Si le schéma d'identification de l'ID privé du Vendeur (BT-29-1) est égal à 0226, alors
les 10 premiers caractères DOIVENT être des chiffres et les 70 autres des caractères.

Il doit correspondre à un Identifiant de PARTICULIER 
BT-29 

BR-FR-CPRO-09  Identifiant du
vendeur
Règle de gestion est applicable uniquement pour le B2G :

Si un identifiant de type SIREN pour le vendeur est renseigné en BT-30, la balise BT-29
doit être renseignée avec le SIRET (identifiant de schéma 0009) du vendeur.

Si BT-30 est présent et que BT-30-1 = 0002, alors BT-29 DOIT être présent avec un
schemedID BT-29-1 = 0009

Cet identifiant SIRET doit exister et être actif dans l'Annuaire. Cette règle ne peut pas
être vérifiée de façon automatique 
BT-29, BT-29-1, BT-
30, BT-30-1 

BR-FR-CPRO-10  Identifiant de
l'acheteur
Cette règle de gestion est applicable uniquement pour le B2G :

L'ID privé de l'ACHETEUR (BT-46) DOIT être renseigné avec le SIRET de l'Acheteur. 

Un ID privé de l'Acheteur (BT-46) avec un schemedID (BT-46-1) égal à 0009 DOIT être
présent. 
BT-46, BT-46-1 

BR-FR-CPRO-11  Identifiant de
l'acheteur
Cette règle de gestion est applicable uniquement pour le B2G :

Si l'Annuaire indique que l'Acheteur identifié par le N° de SIRET (BT-46, avec BT-46-1
égal à 0009) exige un Code Service (DT-4-13-2 = true), alors un ID privé (BT-46) avec
schemeID 0224 (code_routage) DOIT être renseigné avec un Code Service

Si l'enregistrement de l'Annuaire DT-4-13-2 pour le SIRET (DT-4-3) de l'Acheteur est
égal à "true", alors un ID privé de l'Acheteur (BT-46) avec un schemedID (BT-46-1) égal
à 0224 DOIT être présent et correspondre à l'un des Code Service renseigné dans
l'annuaire pour ce SIRET. 
BT-46, BT-46-1 

BR-FR-CPRO-12 
Bon de
commande /
numéro
d'engagement
Règle de gestion applicable uniquement pour le B2G :

Pour les débiteurs ayant rendu le numéro d'engagement obligatoire (voir l'annuaire des
destinataires), la balise BT-13 dot être renseignée.
Le cas échéant, le numéro du marché exécutable sous-jacent peut se substituer à la
référence d'engagement (et est donc présent en BT-13)

Si l'enregistrement de l'Annuaire DT-4-13-1 pour le SIRET (DT-4-3) de l'Acheteur est
égal à "true", alors le numéro de commande (BT-13) DOIT être présent. 
BT-13 

BR-FR-CPRO-13 
Bon de
commande /
numéro
d'engagement
Règle de gestion applicable uniquement pour le B2G :

Pour les débiteurs ayant rendu le numéro d'engagement ou le code Service Exécutant
obligatoire (voir l'annuaire des destinataires), la balise BT-13 ou l'ID privé BT-46 avec
schemeD 0224 doit être renseigné.

Si l'enregistrement de l'Annuaire DT-4-13-3 pour le SIRET (DT-4-3) de l'Acheteur est
égal à "true", alors le numéro de commande (BT-13) ou le Code Service Exécutant (BT-
46 avec shemeID = 0224) DOIT être présent. 
BT-13 

BR-FR-CPRO-14  Référence du
contrat
Règle de gestion applicable uniquement pour le B2G :

La référence du contrat comporte 50 caractères maximum 

Le nombre de caractères du numéro de contrat (BT-12) est inférieur ou égal à 50
caractères. 
BT-12 

BR-FR-CPRO-15 
Bon de
commande /
numéro
d'engagement
Règle de gestion applicable uniquement pour le B2G :

La référence à l’engagement comporte 50 caractères maximum 

Le nombre de caractères du numéro de commande (BT-13) est inférieur ou égal à 50
caractères. 
BT-13
AFNOR XP Z12-0122025-11

_Source: `c:\Users\g.baudrit\source\repos\gbaudrit\conf-aimer-votre-llm\demo\ctxc-sample-spec\with-ctxc\spec/afnor 1.2/XP_Z12-012/XP_Z12-012.pdf` (page:53/page:53)_

### E-0b363a495c9d

XP Z12-012 – Formats et Profils des messages Factures et Statuts de cycle de vie,
constitutifs du socle minimal applicable à la Réforme Facture Électronique en France

52 
CODE BR  Titre  Description  S'applique à 

BR-FR-CPRO-16  Identification
des tiers
Règle de gestion applicable uniquement pour le B2G : 

Les blocs "ADRESSÉE À" (EXT-FR-FE-BG-04) et "AGENT D'ACHETEUR" (EXT-FR-FE-BG-
01) ne doivent pas être renseignés.

Si ces blocs sont renseignés, ils seront ignorés.

Règle non vérifiable 
EXT-FR-FE-BG-01,
EXT-FR-FE-BG-04 

BR-FR-CPRO-17  ID privés des
tiers
Règle de gestion applicable uniquement pour le B2G :

Si un bénéficiaire doit être mentionné dans la facture alors il faut renseigner un
identifiant de type SIRET (identifiant de schéma 0009) en BT-60 si le tiers a un SIREN
en BT-61 (bénéficiaire) ou un autre identifiant parmi la liste suivante s'il n'y a pas de
SIREN en BT-61 : UE_HORS FRANCE ("0223"), HORS_UE ("0227"), RIDET ("0228"),
TAHITI ("0229"), PARTICULIER ("0226") 

Si BG-10 est présent alors :
. Si BT-61 est présent avec shemeID = 0002 (SIREN) alors BT-60 DOIT être présente
avec schemeId 0009 et être le SIRET (9 premiers chiffres identiques au SIREN)
. SINON, BT-60 doit être présent, avec qualifiant (BT-60-1) égal à 0223, 0226, 0227,
0228 ou 0229 
BG-10, BT-60, BT-
61 

BR-FR-CPRO-18  ID privés des
tiers
Règle de gestion applicable uniquement pour le B2G :

Si un agent de vendeur doit être mentionné dans la facture alors il faut renseigner un
identifiant de type SIRET (identifiant de schéma 0009) en EXT-FR-FE-69 si le tiers a un
SIREN en EXT-FR-FE-71 ou un autre identifiant parmi la liste suivante s'il n'y a pas de
SIREN en EXT-FR-FE-71 : UE_HORS FRANCE ("0223"), HORS_UE ("0227"), RIDET
("0228"), TAHITI ("0229"), PARTICULIER ("0226")

Si un Agent de Vendeur (EXT-FR-FE-BG-03) est présent alors :
. Si EXT-FR-FE-69 est présent avec shemeID = 0002 (SIREN) alors le n° de SIRET (EXT-
FR-FE-71) DOIT être présent avec schemeId 0009 (EXT-FR-FE-72) et être le SIRET (9
premiers chiffres identiques au SIREN)
. SINON, EXT-FR-FE-71 doit être présent, avec qualifiant (EXT-FR-FE-72) égal à 0223,
0226, 0227, 0228 ou 0229 
EXT-FR-FE-BG-03,
EXT-FR-FE-69, EXT-
FR-FE-71 

BR-FR-CPRO-19  Lignes de
facturation
Règle de gestion applicable uniquement pour le B2G :

Le numéro de ligne (BT-126) est une séquence numérique limitée à 6 caractères (1-
999999).
Les numéros de ligne ne sont pas contrôlés mais leur nombre ne doit pas dépasser la
limite maximale donnée

Le nombre de lignes d'une facture B2G (BG-25) DOIT être strictement inférieur à 1 000
000 
BT-126 

BR-FR-CPRO-20 
Référence à la
facture
antérieure
Règle de gestion applicable uniquement pour le B2G :

Une seule référence de facture antérieure est autorisée.

Le groupe BG-3 Facture antérieure DOIT avoir une seule occurrence 
BG-3 

BR-FR-CPRO-21 
Sous-
traitance/co-
traitance B2G
Règle de gestion applicable uniquement pour le B2G : 

Si le cadre de facturation (BT-23) est S3 ou S6 (Cas de gestion de la sous-traitance/co-
traitance B2G), le groupe AGENT DE VENDEUR (EXT-FR-FE-BG-03) DOIT être présent
afin de renseigner le titulaire/Mandataire, ainsi que son numéro de SIREN (EXT-FR-FE-
71) et son n° de SIRET (EXT-FR-FE-69 avec schemeID EXT-FR-FE-70 = 0009). 
BT-23, EXT-FR-FE-
BG-03, EXT-FR-FE-
71
AFNOR XP Z12-0122025-11

_Source: `c:\Users\g.baudrit\source\repos\gbaudrit\conf-aimer-votre-llm\demo\ctxc-sample-spec\with-ctxc\spec/afnor 1.2/XP_Z12-012/XP_Z12-012.pdf` (page:54/page:54)_

### E-c675e653d280

XP Z12-012 – Formats et Profils des messages Factures et Statuts de cycle de vie,
constitutifs du socle minimal applicable à la Réforme Facture Électronique en France

53 
CODE BR  Titre  Description  S'applique à 

BR-FR-CPRO-22  ID privés des
tiers
Règle de gestion applicable uniquement pour le B2G : 

Si le bloc AGENT DE VENDEUR (EXT-FR-FE-BG-03) est présent et contient un
Identifiant privé (EXT-FR-FE-69) avec un identifiant de schema (EXT-FR-FE-70) égal à
0009 (de type SIRET), alors l'Agent de vendeur doit être connu du portail de service
Chorus PRO (présent dans l'annuaire des destinataires).

Règle métier non vérifiable automatiquement 
EXT-FR-FE-BG-03,
EXT-FR-FE-69, EXT-
FR-FE-70 

BR-FR-CPRO-23 
Sous-
traitance/co-
traitance B2G
Règle de gestion applicable uniquement pour le B2G :

Si le cadre de facturation (BT-23) est « S3 » (Dépôt d'une facture de service de sous-
traitance avec paiement direct), le destinataire de la facture identifié en BG-7
(Acheteur) DOIT être une entité publique identifiée comme telle dans l'Annuaire

Règle métier non vérifiable automatiquement 
BT-23 

BR-FR-CPRO-24  Cadre de
facturation
Règle de gestion applicable uniquement pour le B2G :

Le Cadre de Facturation (BT-23) ne DOIT PAS être égal à S5 (Dépôt par un sous-traitant
d’une facture de prestation de service); 
BT-23 

BR-FR-CPRO-25  Condition de
paiement
Règle de gestion applicable uniquement pour le B2G :

Une seule condition de paiement est autorisée.

BT-20 a une seule occurrence. 
BT-20 

BR-FR-CPRO-26  Contact vendeur
Règle de gestion applicable uniquement pour le B2G :

Un seul contact du vendeur est autorisé.

BG-6 a une seule occurrence 
BG-6 

BR-FR-CPRO-27  Contact
acheteur
Règle de gestion applicable uniquement pour le B2G :

Un seul contact de l'acheteur est autorisé.

BG-9 a une seule occurrence 
BG-9 

BR-FR-CPRO-28  Contact agent
de vendeur
Règle de gestion applicable uniquement pour le B2G :

Un seul contact de l'agent de vendeur est autorisé.

EXT-FR-FE-85 a une seule occurrence 
EXT-FR-FE-85 

BR-FR-CPRO-29 
Motif
d'exonération
de la TVA
Règle de gestion applicable uniquement pour le B2G : 

La longueur de la donnée "Motif d'exonération de la TVA" est limitée à 1024 caractères.

Le nombre de caractères du Motif d'exonération en texte du bloc Ventilation de TVA
(BT-120) DOIT être inférieur ou égal à 1024 
BT-120 

BR-FR-CPRO-30 
Référence de
document
justificatif
Règle de gestion applicable uniquement pour le B2G :

La longueur de la donnée "Référence de document justificatif" est limitée à 50
caractères.

Le nombre de caractères de la Référence de document justificatif (BT-122 de BG-24)
DOIT être inférieure ou égale à 50. 
BT-122 

BR-FR-CPRO-31  Description de
l'article
Règle de gestion applicable uniquement pour le B2G :

La longueur de la donnée "Description de l'article" est limitée à 1024 caractères. 

Le nombre de caractères de la Description de l'article (BT-154) DOIT être inférieur ou
égal à 1024. 
BT-154
AFNOR XP Z12-0122025-11

_Source: `c:\Users\g.baudrit\source\repos\gbaudrit\conf-aimer-votre-llm\demo\ctxc-sample-spec\with-ctxc\spec/afnor 1.2/XP_Z12-012/XP_Z12-012.pdf` (page:55/page:55)_

### E-78e211eb51b1

XP Z12-012 – Formats et Profils des messages Factures et Statuts de cycle de vie,
constitutifs du socle minimal applicable à la Réforme Facture Électronique en France

54 
CODE BR  Titre  Description  S'applique à 

BR-FR-CPRO-32 
Adresse du
vendeur - Ligne
1
Règle de gestion applicable uniquement pour le B2G : 

La longueur de la donnée "Adresse du vendeur - Ligne 1" est limitée à 400 caractères.

Le nombre de caractères de l'adresse du Vendeur - ligne 1 (BT-35) DOIT être inférieur
ou égal à 400. 
BT-35 

BR-FR-CPRO-33  Localité du
vendeur
Règle de gestion applicable uniquement pour le B2G :

La longueur de la donnée "Localité du vendeur" est limitée à 400 caractères. 

Le nombre de caractères de la localité du Vendeur (BT-37) DOIT être inférieur ou égal à
400. 
BT-37 

BR-FR-CPRO-34 
Appellation
commerciale de
l'acheteur
Règle de gestion applicable uniquement pour le B2G :

La longueur de la donnée "Appellation commerciale de l'acheteur" est limitée à 99
caractères.

Le nombre de caractères de l'Appellation commerciale de l'acheteur (BT-45) DOIT être
inférieur ou égal à 99. 
BT-45 

BR-FR-CPRO-35  Conditions de
paiement
Règle de gestion applicable uniquement pour le B2G : 

La longueur de la donnée "Conditions de paiement" est limitée à 1024 caractères.

Le nombre de caractères des Conditions de paiement (BT-20) DOIT être inférieur ou
égal à 1024. 
BT-20 

BR-FR-CPRO-36 
Appellation
commerciale du
vendeur
Règle de gestion applicable uniquement pour le B2G :

La longueur de la donnée "Appellation commerciale du vendeur" est limitée à 99
caractères.

Le nombre de caractères de l'Appellation commerciale du Vendeur (BT-28) DOIT être
inférieur ou égal à 99. 
BT-28 

BR-FR-CPRO-37  Nom du
bénéficiaire
Règle de gestion applicable uniquement pour le B2G :

La longueur de la donnée "Nom du bénéficiaire" est limitée à 99 caractères. 

Le nombre de caractères du Nom du bénéficiaire (BT-59) DOIT être inférieur ou égal à
99. 
BT-59 

BR-FR-CPRO-38 
Identifiant de
l'établissement
de livraison
Règle de gestion applicable uniquement pour le B2G : 

La longueur de la donnée "Identifiant de l'établissement de livraison" est limitée à 20
caractères.

Le nombre de caractères de l'Identifiant de l'établissement de livraison (BT-71) DOIT
être inférieur ou égal à 20. 
BT-71 

BR-FR-CPRO-39 
Identifiant de
compte de
paiement
Règle de gestion applicable uniquement pour le B2G :

La longueur de la donnée "Identifiant de compte de paiement" est limitée à 27
caractères.

Le nombre de caractères de l'Identifiant de compte de paiement (BT-84) DOIT être
inférieur ou égal à 84. 
BT-84 

BR-FR-CPRO-40 
Identifiant
global du lieu de
livraison à la
ligne
Règle de gestion applicable uniquement pour le B2G :

La longueur de la donnée "Identifiant global du lieu de livraison à la ligne" est limitée à
20 caractères. 

Le nombre de caractères de l'Identifiant global du lieu de livraison à la ligne (EXT-FR-
FE-146) DOIT être inférieur ou égal à 20. 
EXT-FR-FE-146
AFNOR XP Z12-0122025-11

_Source: `c:\Users\g.baudrit\source\repos\gbaudrit\conf-aimer-votre-llm\demo\ctxc-sample-spec\with-ctxc\spec/afnor 1.2/XP_Z12-012/XP_Z12-012.pdf` (page:56/page:56)_

### E-87d1182ea8af

XP Z12-012 – Formats et Profils des messages Factures et Statuts de cycle de vie,
constitutifs du socle minimal applicable à la Réforme Facture Électronique en France

55 
CODE BR  Titre  Description  S'applique à 

BR-FR-CPRO-41 
Nom de fichier
du document
joint
Règle de gestion applicable uniquement pour le B2G : 

La longueur de la donnée "Nom de fichier du document joint" est limitée à 50
caractères.

Le nombre de caractères du Nom de fichier du document joint (BT-125-2) DOIT être
inférieur ou égal à 50. 
BT-125-2 

BR-FR-CPRO-42  Note de facture
Règle de gestion applicable uniquement pour le B2G :

La longueur de la donnée "Note de facture" est limitée à 1024 caractères. 

Le nombre de caractères du contenu de la Note de facture (BT-22) DOIT être inférieur
ou égal à 1024. 
BT-22 

BR-FR-CPRO-43  Raison sociale
du vendeur
Règle de gestion applicable uniquement pour le B2G :

La longueur de la donnée "Raison sociale du vendeur" est limitée à 99 caractères. 

Le nombre de caractères de la Raison sociale du vendeur (BT-27) DOIT être inférieur
ou égal à 99. 
BT-27 

BR-FR-CPRO-44  Raison sociale
de l'acheteur
Règle de gestion applicable uniquement pour le B2G : 

La longueur de la donnée "Raison sociale de l'acheteur" est limitée à 99 caractères.

Le nombre de caractères de la Raison sociale de l'acheteur (BT-44) DOIT être inférieur
ou égal à 99. 
BT-44

4.5.4 Règles de gestion spécifiques pour les factures multi-vendeurs

Pour signifier qu’une facture est multi-vendeurs, il faut utiliser un cadre de facturation B8, S8 ou M8 en BT-
23, sachant que le cadre de facturation des factures unitaires peut varier d’un VENDEUR à l’autre et est alors
indiqué en ligne de facture (celle qualifiée GROUP a minima); C’est pourquoi toutes les règles de gestion ci-
dessous ne s’applique que si le cadre de facturation (BT-23) est égal à B8, S8 ou M8.

La Tableau ci-dessous liste les règles spécifiques à la gestion des factures multi-vendeurs 

CODE BR  Titre  Description  S'applique à 

BR-FR-MV-01
Facture multi-
vendeurs
Cadre de
facturation 8 
Si le Cadre de facturation (BT-23) est égal à S8, B8 ou M8 alors : 

Toutes les lignes (BG-25) DOIVENT contenir un sous-type de ligne (EXT-FR-FE-163). 
EXT-FR-FE-163 

BR-FR-MV-02
Facture multi-
vendeurs
Ligne GROUP
par sous-
vendeur 
Si le Cadre de facturation (BT-23) est égal à S8, B8 ou M8 alors :

La facture DOIT contenir au moins 1 ligne (BG-25) avec le sous-type de ligne (EXT-FR-
FE-163) égal à "GROUP" et sans identifiant de ligne Parent (EXT-FR-FE-162) 
EXT-FR-FE-163
AFNOR XP Z12-0122025-11

_Source: `c:\Users\g.baudrit\source\repos\gbaudrit\conf-aimer-votre-llm\demo\ctxc-sample-spec\with-ctxc\spec/afnor 1.2/XP_Z12-012/XP_Z12-012.pdf` (page:57/page:57)_

### E-d549255ef3f5

XP Z12-012 – Formats et Profils des messages Factures et Statuts de cycle de vie,
constitutifs du socle minimal applicable à la Réforme Facture Électronique en France

56 
CODE BR  Titre  Description  S'applique à 

BR-FR-MV-03 
Facture multi-
vendeurs
Mentions
Obligatoires du
Vendeur en
ligne
Si le Cadre de facturation (BT-23) est égal à S8, B8 ou M8 alors : 

Pour chaque ligne (BG-25) avec un sous-type de ligne (EXT-FR-FE-163) égal à "GROUP"
et sans identifiant de ligne Parent (EXT-FR-FE-162), les données suivantes DOIVENT
être présentes :
. Un nom de vendeur à la ligne (EXT-FR-FE-164)
. Un identifiant de vendeur à la ligne (EXT-FR-FE-167)
. Un code pays de vendeur à la ligne (EXT-FR-FE-177)
. Une valeur d'objet facturé (BT-128) avec identifiant de schéma (BT-128-1) = AFL
(numéro de facture par vendeur)
. Une valeur d'objet facturé (BT-128) avec identifiant de schéma (BT-128-1) = AVV
(cadre de facturation par vendeur), différent de M8/S8/B8
.Un montant total avec TVA à la ligne (EXT-FR-FE-184) en devise de facture 
EXT-FR-FE-164,
EXT-FR-FE-167,
EXT-FR-FE-177, BT-
128, BT-128-1 

BR-FR-MV-04 
Facture multi-
vendeurs
Identifiant TVA
du Vendeur en
ligne
Si le Cadre de facturation (BT-23) est égal à S8, B8 ou M8 alors :

Pour chaque ligne (BG-25) avec un sous-type de ligne (EXT-FR-FE-163) égal à "GROUP"
et sans identifiant de ligne Parent (EXT-FR-FE-162), si le Vendeur de ligne est assujetti
à la TVA et dispose d'un Identifiant de TVA, alors, l'identifiant TVA à la ligne (EXT-FR-
FE-168) DOIT être présent. 
EXT-FR-FE-168 

BR-FR-MV-05 
Facture multi-
vendeurs
Règle de calcul
du Total HT par
Vendeur
Si le Cadre de facturation (BT-23) est égal à S8, B8 ou M8 alors :

Le total HT de ligne (BT-131) des lignes (BG-25) avec un sous-type de ligne (EXT-FR-
FE-163) égal à "GROUP" et sans identifiant de ligne Parent (EXT-FR-FE-162) DOIT être
égal à la somme des totaux de ligne (BT-131) des lignes pour lesquelles l'identifiant de
ligne Parent (EXT-FR-FE-162) est égal à l'identifiant de ligne (BT-126) de la ligne
"GROUP". 
EXT-FR-FE-BG-12,
BT-128, EXT-FR-FE-
162 

BR-FR-MV-06
Facture multi-
vendeurs
Identifiant legal
de Vendeur à la
ligne
Si le Cadre de facturation (BT-23) est égal à S8, B8 ou M8 alors :

Toutes les lignes de factures (BG-25) DOIVENT contenir un identifiant légal de vendeur
à la ligne (EXT-FR-FE-167), identique à celui de la ligne (BG-25) dont l'identifiant de
ligne (BT-126) est égal à l'identifiant de ligne Parent (EXT-FR-FE-162), si présent. 
EXT-FR-FE-167 

BR-FR-MV-07 
Facture multi-
vendeurs
numéro de
facture à la ligne
Si le Cadre de facturation (BT-23) est égal à S8, B8 ou M8 alors :

Toutes les lignes de factures (BG-25) DOIVENT contenir un numéro de facture de ligne,
codifié avec l'objet facturé (BT-128 avec BT-128-1 = AFL) identique à celui de la ligne
(BG-25) dont l'identifiant de ligne (BT-126) est égal à l'identifiant de ligne Parent
(EXT-FR-FE-162), si présent. 
BT-128, BT-128-1 

BR-FR-MV-08
Facture multi-
vendeurs
raison
d'exemption à la
ligne
Si le Cadre de facturation (BT-23) est égal à S8, B8 ou M8 alors :

Toutes les lignes de factures (BG-25) DOIVENT contenir une raison d'exemption TVA en
texte commençant par le numéro de facture en ligne (EXT-FR-FE-178) entre # (exemple
#F2025003#) 
BT-128, BT-128-1,
EXT-FR-FE-178 

BR-FR-MV-09 
Facture multi-
vendeurs
Montant TVA
par Vendeur de
ligne "GROUP"
Si le Cadre de facturation (BT-23) est égal à S8, B8 ou M8 alors :

Le montant total TVA à la ligne (EXT-FR-FE-181) des lignes (BG-25) avec un sous-type
de ligne (EXT-FR-FE-163) égal à "GROUP" et sans identifiant de ligne Parent (EXT-FR-
FE-162) DOIT être égal à la somme des Montants de TVA de la ventilation de TVA (BT-
117) pour lesquelles la raison d'exemption (BT-120) commence par le numéro de
facture à la ligne (BT-128 avec BT-128-1 = AFL) entre # 
EXT-FR-FE-181 

BR-FR-MV-10 
Facture multi-
vendeurs
Montant total
avec TVA par
Vendeur de
ligne "GROUP"
Si le Cadre de facturation (BT-23) est égal à S8, B8 ou M8 alors :

Si le montant total avec TVA en ligne (EXT-FR-FE-184) d'une ligne (BG-25) avec un
sous-type de ligne (EXT-FR-FE-163) égal à "GROUP" et sans identifiant de ligne Parent
(EXT-FR-FE-162) est présent, alors : 

La valeur absolue du (montant total avec TVA (EXT-FR-FE-184) - le montant HT total de
ligne (BT-131) - le montant total de TVA de ligne (EXT-FR-FE-181)) <= 0,01 * nbre de
sous-ligne avec sous-type de ligne (EXT-FR-FE-163) égal à "DETAIL". 
EXT-FR-FE-184,
EXT-FR-FE-181, BT-
131
AFNOR XP Z12-0122025-11

_Source: `c:\Users\g.baudrit\source\repos\gbaudrit\conf-aimer-votre-llm\demo\ctxc-sample-spec\with-ctxc\spec/afnor 1.2/XP_Z12-012/XP_Z12-012.pdf` (page:58/page:58)_

### E-1bd699a4e02d

XP Z12-012 – Formats et Profils des messages Factures et Statuts de cycle de vie,
constitutifs du socle minimal applicable à la Réforme Facture Électronique en France

57 
CODE BR  Titre  Description  S'applique à 

BR-FR-MV-11 
Numéro de
factures de ligne
pour le Vendeur
principal
Si le Cadre de facturation (BT-23) est égal à S8, B8 ou M8 alors : 

Si le Vendeur principal identifié dans le bloc Vendeur (BG-4) de la facture au travers de
son identifiant légal (BT-27) dispose d'un groupe de lignes de facturation, alors
l'identifiant de facture à la ligne ((BT-128) avec scheme ID = AFL (BT-128-1) ), quand
présent (au minimum sur la ligne "GROUP"), DOIT être égal au numéro de facture (BT-
1). 
BT-128, BT-128-1 

BR-FR-MV-12 
Numéro de
factures
unitaires de
ligne uniques
Si le Cadre de facturation (BT-23) est égal à S8, B8 ou M8 alors :

Les numéros de facture à la ligne (Valeur de BT-128 avec BT-128-1 = AFL) pour les
lignes (BG-25) avec sous-type de ligne (EXT-FR-FE-163) = "GROUP" et sans identifiant
de ligne Parent (EXT-FR-FE-162) DOIVENT être uniques (une seule occurrence).

Voir recommandations pour créer des numéros de factures unitaires distincts et
conformes aux exigences réglementaires, chapitre 4.4.12.2. 
BT-128, BT-128-1 

BR-FR-MV-13 
Codes types des
factures Multi
Vendeur (pas
d'auto-facture)
Si le Cadre de facturation (BT-23) est égal à S8, B8 ou M8 alors :

le code type de facture (BT-3) est différent de :

- Facture auto-facturée (389)
- Avoir auto-facturé (261)
- Facture auto-facturée affacturée (501)
- Facture d’acompte auto-facturée (500)
- Avoir auto-facturé affacturé (502)
- Facture rectificative auto-facturée (471)
- Facture rectificative auto-facturée affacturée ( 473) 
BT-3

Ci-dessous le tableau des règles de mapping pour créer les factures unitaires pour chaque VENDEUR, puis
l’extraction des flux 1 / 10;1 unitaires aussi : 

CODE BR  Titre  Description  S'applique à 

BR-FR-MVMAP-
01 
Facture unitaire
par Vendeur en
cas de facture
multi-vendeurs
Si le Cadre de facturation (BT-23) est égal à S8, B8 ou M8 alors la Plateforme Agréée
d'émission qui supporte la gestion des factures Multi-vendeurs DOIT créer autant de
flux 1 que de numéro de facture en ligne présents dans la facture. Pour ce faire, une
première étape consiste à créer des factures unitaires par numéro de facture en ligne
en suivant les règles ci-dessous sur la base des informations fournies dans la ligne (BG-
25) avec un sous-type de ligne (EXT-FR-FE-163) égal à "GROUP" et sans identifiant de
ligne Parent (EXT-FR-FE-162) :
. Remplacer les informations du Vendeur (BG-4) par celles du Vendeur en ligne (EXT-
FR-FE-BG-12)
. Remplacer le numéro de facture (BT-1) par le numéro de facture en ligne (BT-128,
avec BT-128-1 = AFL)
. Remplacer le Cadre de facturation (BT-23) par le cadre de facturation en ligne (BT-128
avec BT-128-1 = AVV).
. Remplacer le code de date d'exigibilité TVA (option sur les débits, BT-8) par celui
indiqué en ligne (EXT-FR-FE-180)
. Remplacer le total TVA dans la devise de la facture (BT-110) par le montant TVA en
devise de facture en ligne (EXT-FR-FE-181).
. Si présent, remplacer le total TVA dans la devise de comptabilisation (BT-111) par le
montant TVA en devise de comptabilisation en ligne (EXT-FR-FE-182).
.Remplacer le montant total avec TVA (BT-112), par le montant total avec TVA en ligne
(EXT-FR-FE-184).
. Porter le montant déjà payé (BT-113) au montant total avec TVA ci-dessus.
. Porter le montant Net à payer (BT-115) à 0 (par conséquent).
. Conserver uniquement les lignes pour lesquelles le numéro de facture en ligne est
celui la facture unitaire (BT-128, avec BT-128-1 = AFL).
. Conserver uniquement les lignes de ventilation de TVA (BG-23) pour lesquelles la
raison d'exemption en texte (BT-120) commence par le numéro de facture en ligne (BT-
128, avec BT-128-1 = AFL) entre # 
EXT-FR-FE-BG-12,
BT-128, BT-128-1,
EXT-FR-FE-180,
EXT-FR-FE-181,
EXT-FR-FE-182,
EXT-FR-FE-184
AFNOR XP Z12-0122025-11

_Source: `c:\Users\g.baudrit\source\repos\gbaudrit\conf-aimer-votre-llm\demo\ctxc-sample-spec\with-ctxc\spec/afnor 1.2/XP_Z12-012/XP_Z12-012.pdf` (page:59/page:59)_

### E-55caab608194

XP Z12-012 – Formats et Profils des messages Factures et Statuts de cycle de vie,
constitutifs du socle minimal applicable à la Réforme Facture Électronique en France

58 
CODE BR  Titre  Description  S'applique à 

BR-FR-MVMAP-
02 
Constitution du
flux 1 ou 10.1
Si le Cadre de facturation (BT-23) est égal à S8, B8 ou M8 alors la Plateforme Agréée
d'émission qui supporte la gestion des factures Multi-vendeurs DOIT créer autant de
flux 1 que de factures unitaires (numéros de facture en ligne).
Pour ce faire, la seconde étape consiste à extraire le flux 1 ou 10.1 à partir de la facture
unitaire, ce qui revient à utiliser les informations fournies dans la ligne (BG-25) avec un
sous-type de ligne (EXT-FR-FE-163) égal à "GROUP" et sans identifiant de ligne Parent
(EXT-FR-FE-162), identifiant les données spécifiques à chaque Vendeur, de la façon
suivante :
. Utiliser les informations du Vendeur en ligne (EXT-FR-FE-BG-12) au lieu de celles du
Vendeur (BG-4)
. Utiliser le numéro de facture en ligne (BT-128, avec BT-128-1 = AFL) au lieu du
numéro de facture (BT-1)
. Utiliser le Cadre de facturation en ligne (BT-128 avec BT-128-1 = AVV) au lieu du
Cadre de facturation (BT-23)
. Utiliser le code de date d'exigibilité TVA (option sur les débits, EXT-FR-FE-180) au lieu
de celui de la facture (BT-8)
. Utiliser le total TVA dans la devise de la facture en ligne (EXT-FR-FE-181) au lieu de
celui de la facture (BT-110), si présent
. Si présent, utiliser le total TVA dans la devise de la facture en ligne (EXT-FR-FE-182)
au lieu de celui de la facture (BT-111).
. Utiliser uniquement les lignes pour lesquelles pour lesquelles le numéro de facture en
ligne est celui la facture unitaire (BT-128, avec BT-128-1 = AFL), et pour lesquelles le
sous-type de ligne (EXT-FR-FE-163) est égal à "DETAIL".
. Utiliser uniquement les lignes de ventilation de TVA (BG-23) pour lesquelles la raison
d'exemption en texte (BT-120) commence par le numéro de facture en ligne (BT-128,
avec BT-128-1 = AFL) entre # 
EXT-FR-FE-BG-12,
BT-128, BT-128-1,
EXT-FR-FE-180,
EXT-FR-FE-181,
EXT-FR-FE-182

4.6 Règle de constitution d’une représentation lisible d’une facture électronique de la
présente Norme.

La réglementation européenne et sa transposition en réglementation française imposent aux entreprises de
fournir une représentation lisible des factures électroniques.

En droit français, cette obligation est précisée comme devant s’appliquer sur l’intégralité des informations
présentes dans la facture électronique, qu’elles soient obligatoires ou facultatives;

Une facture électronique structurée (ici en UBL ou UN/CEFACT CII) est un ensemble de données associées à
une structure syntaxique et sémantique portant le sens de chaque donnée.

4.6.1 Construire un modèle de représentation lisible

La représentation lisible doit donc fournir à la fois les données mais aussi leur sens sémantique, et pour les
données encodées (listes de codes), la signification en texte.

Elle doit donc s’organiser de la façon suivante :

• Tout d’abord, il convient de définir un modèle de présentation, qui se présente en général en 3 parties
communément admis par les usages commerciaux :

✓ Les données d’entête, présentant les parties (Nom, adresse électronique, adresse postale,
identifiants, contact) et les références (dont la date, le numéro de facture, et le cas échéant un
numéro de bon de commande, <)

✓ Les données de pied qui regroupent la ventilation de TVA, les totaux, les informations relatives au
paiement, les mentions réglementaires

✓ Les données de lignes, en général organisées en colonnes pour fournir toutes les informations de
ligne.
AFNOR XP Z12-0122025-11

_Source: `c:\Users\g.baudrit\source\repos\gbaudrit\conf-aimer-votre-llm\demo\ctxc-sample-spec\with-ctxc\spec/afnor 1.2/XP_Z12-012/XP_Z12-012.pdf` (page:60/page:60)_

### E-525b78d2e7a4

XP Z12-012 – Formats et Profils des messages Factures et Statuts de cycle de vie,
constitutifs du socle minimal applicable à la Réforme Facture Électronique en France

59 
Chaque donnée doit pouvoir être comprise sans ambiguïté, ce qui impose de les nommer pour en donner le
sens; Par une exemple, une date toute seule ne signifie rien; Il faut préciser s’il s’agit de la date de facture, la
date de livraison, la date d’échéance <

4.6.2 Comment représenter les données sous forme de codes

Un certain nombre de données sont en pratique des codes, comme par exemple les codes « type de facture »
(BT-3 : 380 pour facture, 381 pour avoir, 386 pour les factures d’acompte, <); La présentation lisible doit alors
présenter la signification en texte qui est donnée dans les listes de codes; Lorsqu’elles sont en anglais, il
convient d’en donner la traduction française; Ainsi, on va présenter le code type 380 en écrivant « Facture »,
381 en écrivant « AVOIR ».

Il n’est alors pas nécessaire de fournir la valeur du code, mais il est aussi possible de la présenter (par exemple
entre parenthèse).

Par exemple, les adresses électroniques ont un schéma d’identification qui peut s’intégrer à l’adresse :

• Pour une adresse présente dans l’annuaire, une présentation 0225:SIREN_SUFFIXE est suffisamment
claire

• Pour un email, la structure xxx@zzz.tt suffit à comprendre.

Pour les notes (BG-1), le code sujet (BT-21) peut aussi servir à les positionner dans la représentation lisible
(note de pénalités, note de condition d’escompte, note de type de traitement, notes d’informations
complémentaires, <)

4.6.3 Factur-X et Facture structurée avec une présentation lisible attachée

Il est complexe de créer un modèle universel de présentation de tous les champs possibles d’une facture, car
il y en a beaucoup, ce que ferait une solution en réception. En particulier, la présentation des lignes oblige
alors à compléter une présentation en colonne de listes de données à organiser à chaque ligne.

Il est plus aisé de créer un modèle de présentation pour l’émetteur dans la mesure où il connait les données
qu’il utilise et peut ainsi mieux les présenter;

Le format Factur-X est composé d’une représentation lisible intégrale de la facture à laquelle est attaché un
fichier de données de factures (factur-x.xml) qui doit être conforme aux exigences décrites dans la présente
Norme et qui ne doit contenir que des informations présentes dans la présentation lisible, la liberté étant
laissée à ce que certaines informations complémentaires soient uniquement présentes dans la présentation
lisible.

Factur-X contient donc une représentation lisible conforme par construction, ce qui implique que les solutions
qui le créent s’attachent à garantir que toutes les informations présentes dans le fichier structuré soient bien
présentes dans la présentation PDF.

Pour ce faire, il est important que la présentation lisible soit créée à partir du fichier structuré, le cas échéant
en ajoutant des informations complémentaires, soit qui ne rentrent pas dans le modèle de données, soit dont
l’émetteur ne dispose pas de façon structurée (tel que des informations générales, des graphes, des logos, voire
des informations promotionnelles ou d’ordre opérationnelles <);

Il est aussi possible pour l’émetteur de créer sa propre représentation lisible de sa facture UBL ou UN/CEFACT
CII, dans le respect des règles décrites ci-dessus. Cette représentation lisible devra alors être jointe dans le
fichier structuré en UBL ou UN/CEFAT CII, dans le groupe BG-24, en BT-125 (en général encodé en Base64),
avec une description BT-123 de document égale à « LISIBLE ».

Il est alors toléré que cette représentation LISIBLE contienne des informations additionnelles à celles
présentes dans le fichier structuré, dans la mesure où ces informations n’ont pas leur place dans la structure
sémantique du format du socle minimum utilisé.
AFNOR XP Z12-0122025-11

_Source: `c:\Users\g.baudrit\source\repos\gbaudrit\conf-aimer-votre-llm\demo\ctxc-sample-spec\with-ctxc\spec/afnor 1.2/XP_Z12-012/XP_Z12-012.pdf` (page:61/page:61)_

### E-3ba18ed7a506

XP Z12-012 – Formats et Profils des messages Factures et Statuts de cycle de vie,
constitutifs du socle minimal applicable à la Réforme Facture Électronique en France

60 
Cette présentation LISIBLE peut alors être utilisé par le destinataire de la facture pour ses propres besoins. Il
conserve toutefois l’obligation de présenter sous forme lisible le fichier structuré de facture sur demande de
l’administration dans l’éventualité où celle transmis par l’émetteur ne serait pas conforme. Des outils de
présentation standard de chaque profil peuvent alors servir à cet effet, même si la présentation sera nettement
moins adaptée aux besoins de visualisation opérationnels à des fins de validation par exemple.

La création de LISIBLE peut aussi être faite à partir d’une feuille de style qui peut être mise à disposition par
l’émetteur ou en son nom. Il convient toutefois que chaque partie qui souhaite utiliser cette feuille de style se
préoccupe da sa conservation intègre et de sa capacité à l‘utiliser pendant la période de conservation; La
responsabilité de production du lisible incombe à chaque partie, et donc au destinataire, qui ne pourra pas
dégager sa responsabilité en cas de défaut de la feuille de style ou de sa non applicabilité.

4.6.4 Exemples

Il est complexe de créer un modèle universel de présentation de tous les champs possibles d’une facture, car
il y en a beaucoup, ce que ferait une solution en réception. En particulier, la présentation des lignes oblige
alors à compléter une présentation en colonne de listes de données à organiser à chaque ligne.

Il est plus aisé de créer un modèle de présentation pour l’émetteur dans la mesure où il connait les données
qu’il utilise et peut ainsi mieux les présenter;

Ci-dessous un exemple de présentation d’une facture fictive contenant la quasi-intégralité des données
présentes dans le profil EN 16931.
AFNOR XP Z12-0122025-11

_Source: `c:\Users\g.baudrit\source\repos\gbaudrit\conf-aimer-votre-llm\demo\ctxc-sample-spec\with-ctxc\spec/afnor 1.2/XP_Z12-012/XP_Z12-012.pdf` (page:62/page:62)_

### E-031eb642d121

XP Z12-012 – Formats et Profils des messages Factures et Statuts de cycle de vie,
constitutifs du socle minimal applicable à la Réforme Facture Électronique en France

61 
Nos références
N° DE CLIENT : REF_CLIENT2514
N° BON DE VENTE : BON VENTE REF 2547
Vos identifiants
ID : privateID - GLN : 3654789851
SIRET : 20000000800025
CODE_ROUTAGE : CDROUT1
SIREN : 200 000 008
N° TVA : FR 37 200 000 008 
Représentant Fiscal
ASSUJETTI UNIQUE VENDEUR
75 rue labas, Assujetti Unique ligne 2
75007 PARIS, FR
N° TVA Intra : FR 78 500 000 005 

DEVISE : EURO (EUR) 

#
Ligne
FACT
# ligne BC
CODE ARTICLE,
REFERENCE
NOM & DESIGNATION, Période
Objet, Classification
Attributs
Note 
P.U. HT (EUR)  UNITÉ
pour P.U.  Qté
Remise (-)
Charge (+)
(EUR) 
TOTAL HT
(EUR)  TVA 

1 # ligne BC: 1
REF:BUY_ACC_REF 
REMBOURSEMENT - Description du remboursement
Période de 01/01/2025 au 31/01/2025 
(Brut: 60,00)
(Net): 60,00  PCE  1,00    60,00  0,00% 

2
# ligne BC: 4
GTIN:598785412598745
C_FO: ART_1254
C_ACH: REF5487
REF:BUY_ACC_REF1
ORIGINE:FR
COMPOSANT - Description de l'article
Période de 01/01/2025 au 31/01/2025
Tariff number (AFG): TARIF_2022 - SKU (Stock keeping
unit) (SK): SKU2578
(ATT) CO2(g) : 12
(BLU): DONT 0,50 EUR de DEEE 
(Brut: 0,80)
(Rabais: 0,10)
(Net): 0,70 
PCE  30,00  -1,00 (RE)
1,00 (CH)  21,00  20,00% 

3
# ligne BC: 3
GTIN:598785414325437
C_FO: ART_9874
C_ACH: REF9854
REF:BUY_ACC_REF2 
FOURNITURES MOULE - Description du moule
Période de 01/01/2025 au 31/01/2025
(ATT) COULEUR : BLANC - CO2(g) : 30 
(Brut: 30,00)
(Net): 30,00  3 PCE  1,00    10,00  10,00% 

4 # ligne BC: 2
REF:BUY_ACC_REF3 
SUPPORT TEL - Description de la prestation de support
associée
Période de 01/01/2025 au 31/01/2025 
(Brut: 10,00)
(Rabais: 3,00)
(Net): 7,00 
HEURE  2,00    14,00  20,00% 

95 REMISE : REMISE COMMERCIALE_1 5,00% sur 100,00 EUR -5,00 20,00% 
100 REMISE : REMISE COMMERCIALE_2 1,00% sur 100,00 EUR -1,00 20,00% 
100 REMISE : REMISE COMMERCIALE_3 1,00% sur 100,00 EUR -1,00 20,00%  
REMISE : REMISE COMMERCIALE_4 2,00% sur 100,00 EUR -2,00 10,00% 
FC CHARGE : FRAIS DEPLACEMENT_1 10,00% sur 100,00 EUR 10,00 20,00% 
ADR CHARGE : AUTRE CHARGE 1,00% sur 100,00 EUR 1,00 20,00% 
FC CHARGE : FRAIS DEPLACEMENT_2  2,00 (K) 0,00% 
FC CHARGE : FRAIS DEPLACEMENT_3  1,00 10,00% 

Détail TVA (motif si exonération, code E, O, K, AE) Code Taux Base TVA Montant TVA  

S
E
S
K
20,00% 39,00 7,80
VATEX-EU-79-C REMBOURSEMENT 0,00% 60,00 0,00  
10,00% 9,00 0,90
VATEX-EU-IC LIVRAISON INTRACOMMUNAUTAIRE 0,00% 2,00 0,00

TVA acquittée sur les débits
Tout retard de paiement engendre une pénalité exigible à compter de la date d'échéance, calculée sur la base de trois fois le taux
d'intérêt légal.
Indemnité forfaitaire pour frais de recouvrement en cas de retard de paiement : 40 €.
Les réglements reçus avant la date d'échéance ne donneront pas lieu à escompte.
CONDITIONS DE PAIEMENT : PAIEMENT 30 JOURS NET
MEMBRE_ASSUJETTI_UNIQUE Montant déjà payé :
(ou à payer par un tiers)  0,00 

Bénéficiaire MOYEN DE PAIEMENT : VIREMENT
NOM : TIERS Bénéficiaire COMPTE : MON COMPTE BANCAIRE

SIREN : 300000007 - GLN : 587451236586 IBAN : FR20 1254 2547 2569 8542 5874 698 - BIC : BIC_MONCOMPTE
REFERENCE AVIS DE PAIEMENT : F202500001_200000008
REF MANDAT ICS - FRXX IBAN CPTE DEBIT 

35 ma rue a moi,75018 PARIS, FR – contact@vendeur.fr - www.levendeur.fr – N° TVA : FR88 100 000 009 Page 1 / 1
Vos références
REFERENCE ACHETEUR / SERVICE EXECUTANT : SERVEXEC
REF APPEL D'OFFRES : APPEL_OFFRE-FRE0087
REF PROJET : PROJET_2547
REF COMPTABLE : REF COMPTABLE ACHETEUR
N° CONTRAT : CT2018120802
N° BON DE COMMANDE : PO201925478
Livraison: adresse, références
NOM LIVRé
ADRESSE LIVRAISON LIGNE 1
AD LIV ligne 2
06000 NICE, FR 

ID : PRIVATE_ID_DELIVERY -
N° BON DE LIVRAISON : AVISLIVRAISON_007654
DATE DE LIVRAISON : 31/01/2025
N° BON DE RECEPTION : BON_RECEPT_002

Date d'échéance : 03/03/2025   
F202500001  LOGO LE VENDEUR

VENDEUR NOM COMMERCIAL
LE VENDEUR
35 rue d'ici, ligne 2 vendeur
75018 PARIS, FR
CONTACT : MME CONTACT, DEP ADV, 01 02 03 54 87, contact@vendeur.fr
@dresse électronique (0225) : 100000009_STATUTS
ID : PRIVATE_123 - GLN : 587451236587
SIRET : 10000000900017 - DUNS : DUNS1235487
SIREN ASSUJETTI UNIQUE : 500000005
SIREN : 100 000 009
N° TVA intra : FR 88 100 000 009
CLIENT :
Contact ACHETEUR, DEP COMPTAFOUR
LE CLIENT
CLIENT NOM COMMERCIAL
MON ADRESSE LIGNE 1
acheteur ligne 2
acheteur ligne 3
06000 MA VILLE, FR

@dresse de facturation (0225) : 200000008
Contact: 01 01 25 45 87, contact@acheteur.fr

Références sur la facture
CADRE DE FACTURATION : B1 

DATE DE DEBUT DE PRESTATION : 01/01/2025
DATE DE FIN DE PRESTATION : 31/01/2025

TOTAL HT TOTAL TVA TOTAL TTC

110,00 8,70 118,70
AFNOR XP Z12-0122025-11

_Source: `c:\Users\g.baudrit\source\repos\gbaudrit\conf-aimer-votre-llm\demo\ctxc-sample-spec\with-ctxc\spec/afnor 1.2/XP_Z12-012/XP_Z12-012.pdf` (page:63/page:63)_

### E-750daa6c9d42

XP Z12-012 – Formats et Profils des messages Factures et Statuts de cycle de vie,
constitutifs du socle minimal applicable à la Réforme Facture Électronique en France

62 
4.7 Conversions entre formats du socle

La réforme impose une obligation de conversion entre les formats et profils de facture du socle minimum,
objet du présent document.

Il existe plusieurs situations de conversion :

• La conversion entre une facture UBL et une facture UN/CEFACT du même profil : c’est le plus simple
puisque le modèle sémantique se décline dans les deux syntaxes. Chaque donnée présente dans une
des deux syntaxes à une place équivalente dans l’autre syntaxe. Si une présentation LISIBLE est jointe
dans le fichier avant conversion, elle peut être jointe de la même façon dans le fichier converti.

• La conversion d’un profil EN 16931 vers un profil EXTENDED. Il en est de même puisque le profil
EXTENDED contient toutes les données du profil EN 16931.

• La conversion d‘un profil EXTENDED-CTC-FR vers un profil EN 16931 : l’ensemble des données
communes peuvent se convertir. Mais les données présentes dans le profil EXTENDED-CTC-FR qui ne
sont pas dans le profil EN 16931 ne peuvent pas être converties; Pour ne pas perdre d’information, il
est alors nécessaire de joindre un LISIBLE, soit en prenant celui qui a été fourni, si c’est le cas, soit en
créant un LISIBLE sur la base de toutes les informations présentes dans le profil EXTENDED-CTC-FR
avant conversion. Le LISIBLE DOIT alors être joint au fichier de facture converti.
Toutefois, étant donné que le profil EXTENDED-CTC-FR contient des tolérances dans certaines règles
de calcul, la conversion vers le profil EN16931 peut rendre le résultat non conforme aux règles plus
strictes.

• La conversion d’une facture structurée UBL ou UN/CEFAT CII vers Factur-X : se passe comme une
conversion entre formats et profils structurés, sauf que la création d’un LISIBLE est obligatoire, soit en
utilisant celui joint au fichier de facture source, soit en le créant à partir du fichier de données. Les
éventuelles pièces jointes présentes en BG-24 de la facture structurée peuvent être joints directement
comme fichier attaché du PDF/A-3, à côté du factur-x.xml.

• La conversion d’une facture Factur-X profil EN 16931 ou EXTENDED en format structuré (UBL ou
UN/CEFACT CII) consiste d’abord à convertir le fichier structuré factur-x.xml vers le format cible
(uniquement pour les données qui ont leur place dans le profil cible), puis à joindre le lisible en BG-24,
ainsi que toutes les pièces jointes éventuelles du Factur-X.

• Le dernier cas, qui ne sera admis que jusqu’au 1er septembre 2027, est la conversion d’un Factur-X au
profil BASIC WL (sans lignes) vers un format structuré qui doit contenir des lignes. Dans ce cas, la
conversion doit en plus créer des lignes de factures reprenant les informations de ventilation de TVA,
de façon à satisfaire les contrôles de la Norme EN 16931.

4.8 Présentation du fichier annexe de description des formats de facture du socle minimal

La description des formats de facture du socle minimal est réalisée au travers d’un fichier Excel comportant
différentes feuilles : 

Nom de la feuille  Description 

FE EN16931 + EXTENDED
Description sémantique de la facture pour les 2 profils (EN16931 et EXTENDED-CTC-FR), le profil EXTENDED-
CTC-FR intègre toutes les données dont l'ID commence par EXT. La cardinalité peut être augmentée dans le profil
EXTENDED-CTC-FR par rapport à EN16931
. Colonne C : cardinalité sémantique EN16931
. Colonne D : Cardinalité sémantique profil EN16931 France (CIUS)
. Colonne E : cardinalité sémantique EXTENDED-CTC-FR
AFNOR XP Z12-0122025-11

_Source: `c:\Users\g.baudrit\source\repos\gbaudrit\conf-aimer-votre-llm\demo\ctxc-sample-spec\with-ctxc\spec/afnor 1.2/XP_Z12-012/XP_Z12-012.pdf` (page:64/page:64)_

### E-bea720d7a977

XP Z12-012 – Formats et Profils des messages Factures et Statuts de cycle de vie,
constitutifs du socle minimal applicable à la Réforme Facture Électronique en France

63 
Nom de la feuille  Description 

BR-France CTC
Règles de gestion spécifiques France, par catégories :
. BR-FR : règle de gestion sur une donnée
. BR-FR-CO : règle de gestion conditionnelle
. BR-FR-DEC : règle de nombre de décimales
. BR-FR-MAP : règle de mapping pour créer le flux 1 ou 10.1
. BR-FR-MV : règles de gestion pour les factures multi-vendeurs
. BR-FR-MVMAP : règles de mapping pour les factures multi-vendeurs 

BR-France-CTC-CPRO  BR-FR-CPRO : règles de gestion pour les factures B2G (Chorus Pro) 

BR EN16931 + EXT FR et FX
Règles de gestion de la Norme EN16931, + Règle alternative pour le profil EXTENDED-CTC-FR (tolérance dans les
calculs en pied de 0,01 par ligne).
L'application des règles est ensuite indiquée aussi pour les profils additionnels Factur-x (BASIC, BASIC WL,
MINIMUM, EXTENDED). Des règles de gestion additionnelles sont aussi indiquées pour Factur-X EXTENDED :
. BR-FREXT-XXXX : règle pour le profil EXTENDED-CTC-FR
. BR-FXEXT- XXX : Règle profil EXTENDED Factur-x 

Codelists for XML Fx - 15 11
25 
Liste de codes applicables sur les profils EN16931 (éventuellement réduite du fait des règles de gestion France),
et le profil EXTENDED de Factur-X, applicable à compter du 15 novembre 2025 

Flux 2 UBL EN16931 FR  Description du format de Facture en UBL, pour le profil EN16931. Il s'agit de l'implémentation syntaxique de la
Norme EN16931, avec prise en compte des règles de gestion spécifiques France 

Flux 2 UBL EXT-CTC-FR  Description du format de Facture en UBL, pour le profil EXTENDED-CTC-FR. Il s'agit de l'implémentation
syntaxique du profil Sémantique EN16931, avec prise en compte des règles de gestion spécifiques France 

CII D22B & FX EN16931 FR
Description du format de Facture en UN/CEFACT CII D22B, pour le profil EN16931 (et donc aussi Factur-X
EN16931). Il s'agit de l'implémentation syntaxique de la Norme EN16931, avec prise en compte des règles de
gestion spécifiques France 

CII D22B & FX EXT-CTC-FR
Description du format de Facture en UN/CEFACT CII D22B, pour le profil EXTENDED-CTC-FR (et donc aussi
Factur-X EXTENDED-CTC-FR qui est un subset du profil EXTENDED de Factur-X). Il s'agit de l'implémentation
syntaxique du profil Sémantique EN16931, avec prise en compte des règles de gestion spécifiques France 

FACTUR-X BASIC WL FR
Description du format des données Factur-X en UN/CEFACT CII D22B, pour le profil BASIC WL. Il s'agit de
l'implémentation syntaxique de la Norme EN16931, avec prise en compte des règles de gestion spécifiques
France 

FE - Flux 1  Description sémantique du Flux 1, telle que publiée dans les spécifications externes de l'AIFE 3.0, annexe 1. 

Flux 1 UBL  Implémentation du Flux 1 en UBL Construit à partir du Flux 2 en UBL. 

Flux 1 CII  Implémentation du Flux 1 en UN/CEFACT construit à partir du Flux 2 an CII. 

E-REPORTING - Flux 10  Description sémantique et syntaxique du Flux 10, telle que publiée dans les spécifications externes de l'AIFE,
avec correspondance des champs du 10.1 avec le flux 2. 

Règles de gestion 3.1  Règles de gestion applicable pour les échanges entre Plateformes Agréées et le PPF (annexe 7 des spécifications
externes 3.1) 

CDV FE - CDAR
Description sémantique et syntaxique du Flux 6 (CDV) en CDAR, d'une part pour son utilisation entre
Plateformes Agréées et le PPF (cf spécifications externes AIFE), d'autre part entre Plateformes Agréées entre
elles et avec leurs clients respectifs (objet de cette publication) 

BR-FR-CDV pour factures  Règles de gestion pour les CDV (CDAR) relatifs à des Factures (Flux 2, 3)
AFNOR XP Z12-0122025-11

_Source: `c:\Users\g.baudrit\source\repos\gbaudrit\conf-aimer-votre-llm\demo\ctxc-sample-spec\with-ctxc\spec/afnor 1.2/XP_Z12-012/XP_Z12-012.pdf` (page:65/page:65)_

### E-351c60a1c75f

XP Z12-012 – Formats et Profils des messages Factures et Statuts de cycle de vie,
constitutifs du socle minimal applicable à la Réforme Facture Électronique en France

64 
Nom de la feuille  Description 

Acteurs CDV  Cycle de vie : dans le cadre des échanges de Cycle de vie, quels sont les acteurs référencés dans le CDAR (pour
conserver une confidentialité des Plateformes Agréées entre utilisateurs finaux) 

Codes Action  Codes "Action attendue" utilisables dans les messages de statut de cycle de vie 

Tableau des motifs de
STATUTS  Motifs possibles pour chaque statut, en B2B, à utiliser et contrôler dans le CDAR (Codes Motifs)

4.8.1 Feuille « FE EN16931 + EXTENDED »

Cette feuille décrit le modèle sémantique des 2 profils. En pratique c’est l’intégralité du profil EXTENDED-CTC-
FR qui est décrit, avec sa cardinalité (Colonne E). Mais en filtrant sur la colonne A des ID en excluant tous les
ID commençant par « EXT », on obtient la description du profil EN1 6931, avec la cardinalité en colonne D.

Pour une bonne compréhension, les colonnes sont organisées de la façon suivante :

• A : ID de chaque donnée ou groupe de données.

• B : présence de la donnée en flux 1 ou 10.1.

• C, D, E : cardinalités de la Norme EN 16931, du profil EN 16931 (identiques sauf pour BT-29 et BT-
46, car la description du profil EN 16931 a artificiellement répliqué cette donnée pour en expliquer
l’utilisation pour renseigner SIRET, CODE_ROUTAGE et SIREN de l’Assujetti Unique (pour le
VENDEUR)), et du profil EXTENDED-CTC-FR (en E).

• F à J : le nom des données.

• K à M : les Xpath en UBL et CII (pour information, colonnes masquées).

• N : type logique des données

• O et P : longueur de champs telle qu’exigée pour le flux 1, et pour les flux 2, 8 et 9 c’est-à-dire la facture
objet du présent document.

• Q : liste de code à utiliser quand le champ doit trouver sa valeur dans une liste.

• R : indication d’implémentation;

• S et T : description et note d’usage du champ (repris de EN 16931).

• U : règle de gestion des flux 1 et 10.1 applicable.

• V à Z : Règles de gestion spécifiques France applicables aux factures dans les formats du socle
minimum (Flux 2, 8 et 9, par type de règle).

• AA : règles applicables pour le B2G en France

• AB et AC : règles de la Norme EN 16931 applicable et Règle du profil EXTENDED-CTC-FR.

• AD : commentaires éventuels.

• AF et AH : indique les modifications à chaque version

• AJ : Indique si la donnée est exigée au DEMARRAGE ou en CIBLE (flux 1 ou 10.1).

• AL à AN : indique la présence de la donnée dans chaque profil.

• AP à AZ : règles de gestion applicables, fournies en texte.
AFNOR XP Z12-0122025-11

_Source: `c:\Users\g.baudrit\source\repos\gbaudrit\conf-aimer-votre-llm\demo\ctxc-sample-spec\with-ctxc\spec/afnor 1.2/XP_Z12-012/XP_Z12-012.pdf` (page:66/page:66)_

### E-dec098ff4682

XP Z12-012 – Formats et Profils des messages Factures et Statuts de cycle de vie,
constitutifs du socle minimal applicable à la Réforme Facture Électronique en France

65 
• BB à BH : règle de gestion applicable sur flux 1 ou 10.1 (colonne U) en texte.

4.8.2 Feuille « BR-France CTC »

Cette feuille décrit les Règles de Gestion, en référençant celles qui s’applique sur le flux 1 dont elles peuvent
être issues, sur quelles données elles s’appliquent et sur quels types de factures ou bien en mapping pour flux
1 ou flux 10. Elle contient aussi des règles de gestion additionnelles et de mapping flux 1 pour les factures
multi-vendeurs.

Les colonnes sont organisées de la façon suivante :

• Colonne A : Nom de la règle

• Colonne B : Code de la règle Flux 1 ou Flux 10 correspondante (si existe)

• Colonne C : Titre de la règle

• Colonne D : Description de la règle

• Colonne E : Champs concernés par la règle

• Colonnes F à M : comment s‘applique la règle, sur quels types de factures

✓ Flux 2 : e-invoicing

✓ Flux 8 sortant : Ventes B2B internationales

✓ Flux 8 entrants : acquisitions B2B internationales, sur lesquelles les règles spécifiques France ne
s’appliquent pas en général (car on ne peut pas imposer des règles aux factures émises par des
sociétés non françaises)

✓ Flux 9 : Ventes B2C

✓ Map Flux 1 ou Map flux 10 : règle de mapping pour construire le Flux 1 ou le Flux 10 à partir de la
facture.

✓ Règle métier : si la règle exige des données autre que celles de la facture (par exemple de vérifier
la présence du SIREN dans l’annuaire);

✓ Règle non vérifiable : règle donnée pour rappel, mais non vérifiable par un traitement schematron
ou même métier.

• Colonnes O-S : suivi des modifications par version

4.8.3 Feuille « BR-France-CTC-CPRO »

Cette feuille présente les règles spécifiques additionnelles applicables aux factures B2G, à destination du
secteur public et de la plateforme CHORUSPRO.

L’organisation des colonnes est la même que pour la feuille « BR-France CTC ».

4.8.4 Feuille « BR EN 16931 + EXT FR et FX »

Cette feuille présente les règles de la Norme EN 16931, et les règles des profils EXTENDED-CTC-FR et
EXTENDED de Factur-x qui remplacent certaines des règles de la Norme sur ces profils.

Pour chaque règle, il est précisé sur quel(s) profil(s) elle s’applique (y compris les profils de Factur-x
MINIMUM, BASIC WL, BASIC et EXTENDED).

Les Factures doivent donc d’abord être conformes à ces ensembles de règles, puis en complément, aux règles
spécifiques France présentées au chapitre précédent.

La feuille s’organise de la façon suivante : avec 2 tables
AFNOR XP Z12-0122025-11

_Source: `c:\Users\g.baudrit\source\repos\gbaudrit\conf-aimer-votre-llm\demo\ctxc-sample-spec\with-ctxc\spec/afnor 1.2/XP_Z12-012/XP_Z12-012.pdf` (page:67/page:67)_

### E-2aad5a0b3d31

XP Z12-012 – Formats et Profils des messages Factures et Statuts de cycle de vie,
constitutifs du socle minimal applicable à la Réforme Facture Électronique en France

66 
• Tableau des règles TVA, par catégorie de TVA

✓ Colonne B : indicateur de correction par version

✓ Colonne C : Nom des règles

✓ Colonnes D et E description des règles en français et en anglais

✓ Colonnes G à L : Applicabilité par profil

✓ Colonnes N et O : applicables sur flux 1, profils Base et Full
✓ Ensuite par blocs de lignes, correspondant à chaque catégorie de TVA

➢ Lignes 5 à 19 : pour Catégorie TVA « S ¬, avec en gris (ligne 16 et 17), les règles qui s’appliquent au
profil EXTENDED-CTC-FR au lieu des règles BR-S-8 et BR-S-9 pour apporter une tolérance dans les
calculs de sommes, et en vert, les règles qui s’appliquent au profil EXTENDED de Factur-x (les mêmes
règles mais prenant en compte une donnée en plus dans les sommes : montant des frais de service
logistiques).

➢ Lignes 20 à 32 : idem pour catégorie « Z », taux à Zéro

➢ Lignes 33 à 45 : idem pour catégorie « E », Exempté

➢ Lignes 46 à 58 : idem pour catégorie « AE », autoliquidation

➢ Lignes 59 à 73 : idem pour catégorie « K », livraisons intracommunautaires

➢ Lignes 74 à 86 : idem pour catégorie « G », Exports

➢ Lignes 87 à 103 : idem pour catégorie « O », Hors scope

➢ Lignes 104 à 109 : idem pour catégorie « L » (IGIC) et « M » (IPSI), non applicable en France

• Tableau des autres règles :

✓ Colonne Q : Nom des règles

✓ Colonnes R et U : description en français et en anglais

✓ Colonnes S et V : contexte en français et en anglais

✓ Colonnes T et W : sur quels champs

✓ Colonnes Y à AD : application par profil

✓ Colonnes AF et AG : application sur Flux 1, profils Base et Full

✓ Colonne AI et au-delà : modifications de cette table par version

✓ Les règles sont ensuite par catégories :

➢ Règles BR : règles de gestion applicable sur un champ

➢ Règles BR-CO : règles conditionnelles transverses

➢ Règles BR-DEC : règles sur le nombre de décimales

➢ Règles BR-CL : règles relatives aux valeurs de code à choisir dans une liste

➢ Règles BR-B : règles de « split payment » non applicables en France (pour l’Italie)

➢ Règles-FXEXT : Règles d’extension Factur-X sur des données d’extension du profil EXTENDED

➢ Les règles BR-CO-10, 11, 12, 13 et 15 sont remplacées par des règles BR-FREXT-CO-10, 11, 12, 13 et 15
pour le profil EXTENDED-CTC-FR et BR-FXEXT-CO-10, 11, 12, 13 et 15 pour le profil EXTENDED de
Factur-X (tolérance de calculs de sommes).
AFNOR XP Z12-0122025-11

_Source: `c:\Users\g.baudrit\source\repos\gbaudrit\conf-aimer-votre-llm\demo\ctxc-sample-spec\with-ctxc\spec/afnor 1.2/XP_Z12-012/XP_Z12-012.pdf` (page:68/page:68)_

### E-904305837dc5

XP Z12-012 – Formats et Profils des messages Factures et Statuts de cycle de vie,
constitutifs du socle minimal applicable à la Réforme Facture Électronique en France

67 
4.8.5 Feuille « Codelists for XML Fx - 15 11 25 »

Cette feuille donne les différentes listes de codes applicables à compter du 15 novembre 2025, y compris celles
qui s’appliquent sur certains champs d’extension essentiellement sur données du profil Factur-X EXTENDED
en UN/CEFACT CII.

Les listes sont organisées par groupes de colonnes, avec en titre les champs sur lesquels elles s’appliquent et
le lien avec la liste correspondante.

En particulier, les codes VATEX (raisons d’exemption de TVA) sont en colonnes AX à BA, avec tous les codes
dédiés à la réglementation française en bas de liste.

Attention, lorsque les codes s’appliquent à des extensions, c’est la codification des champs du profil
EXTENDED en CII de Factur-X qui est utilisée, car préexistante (cf Feuille CII D22B & FX EXT-CTC-FR) et parce
que ces champs ne sont pas intégrés dans le profil EXTENDED-CTC-FR.

4.8.6 Feuille « Flux 2 UBL EN 16931 FR » et « Flux 2 UBL EXT-CTC-FR »

Ces feuilles décrivent respectivement les deux profils EN16931 et EXTENDED-CTC-FR en UBL, c’est-à-dire en
décrivant la structure de l’UBL restreinte aux champs nécessaires pour implémenter les deux profils, dans
l’ordre du message (puisque les données doivent être présentées suivant un arbre strictement défini, y
compris dans l’ordre des données d’un même niveau);

Ces feuilles décrivent le message Facture : INVOICE (colonnes B à AT), puis le message AVOIR : CREDIT NOTE
(Colonnes (AV à CN); Certaines lignes sont en orange de part et d‘autres pour recaler les structures INVOICE
et CREDIT NOTE qui sont très proches, mais pas identiques.

Les colonnes s’organisent de la façon suivante pour le message INVOICE (et de façon équivalente ensuite pour
le message CREDIT NOTE) :

• Colonne B : ID des données de l’implémentation du profil en UBL (avec quelques ID de structure liés à
l’implémentation UBL);

• Colonne C : ID de la donnée, dans le modèle sémantique français (cf feuille « FE EN 16931 +
EXTENDED »).

• Colonne F : niveau d’arborescence en UBL (différent de celui de la Norme EN 16931, car l’arborescence
de l’UBL n’est pas la même que celle de la norme EN 16931). C’est ce qui permet de matérialiser
l’arbre de données de l’UBL, avec la cardinalité en colonne G.

• Colonne G : cardinalité de la donnée pour le profil (correspondant au profil de chaque feuille), ce qui
inclut implicitement une règle de gestion quand elle est différente de la cardinalité du message UBL
complet présente en colonne AR. Par exemple si la cardinalité UBL est 0..n (colonne AR) et que celle
de la colonne G est 1..1, cela signifie que la donnée n’est plus optionnelle et répétable, mais obligatoire
et présente une fois seulement; Ceci peut soit s’implémenter est créant un xsd dédié, soit au travers
d’une règle de gestion décrite dans un schematron (qui dira que la donnée DOIT être présente une fois
et une seule).

• Colonne H : Nom de la donnée reprise du modèle sémantique de la feuille « FE EN 16931 +
EXTENDED ».

• Colonne I : Xpath UBL.

• Colonnes J à AB : reprennent les informations des colonnes M à AC de la description sémantique
(feuille « FE EN 16931 + EXTENDED ».

• Colonnes AD et AE : appartenance de la ligne au Flux 1 (permet ensuite un filtrage), profils Base et Full.

• Colonnes AG à AT : description du mapping UBL :

✓ Colonne AG : nom du terme du champ de la Norme.

✓ Colonne AH : description de la donnée (Norme EN 16931).
AFNOR XP Z12-0122025-11

_Source: `c:\Users\g.baudrit\source\repos\gbaudrit\conf-aimer-votre-llm\demo\ctxc-sample-spec\with-ctxc\spec/afnor 1.2/XP_Z12-012/XP_Z12-012.pdf` (page:69/page:69)_

### E-9380790ca163

XP Z12-012 – Formats et Profils des messages Factures et Statuts de cycle de vie,
constitutifs du socle minimal applicable à la Réforme Facture Électronique en France

68 
✓ Colonne AI : Note d’usage de la donnée (Norme EN 16931).

✓ Colonne AJ : règles de CIUS ChorusPro (pour rappel, et info).

✓ Colonne AK : règles de la Norme EN 16931 applicable, ainsi que quelques règles PEPPOLBIS 3.0,
pour info.

✓ Colonne AL : type de la donnée.

✓ Colonne AM : cardinalité du modèle UBL du profil EN 16931 (source de la colonne G pour le
profil EN 16931).

✓ Colonne AN : cardinalité du modèle UBL du profil EXTENDED-CTC-FR (source de la colonne G
pour le profil EXTENDED-CTC-FR).

✓ Colonne AO et AP = Xpath, en présentation déployée ou en ligne.

✓ Colonne AR : Cardinalité du message UBL complet (indique le cas échéant le potentiel d’évolution
pour le profil).

✓ Colonnes AS et AT : informations de mapping de la Norme.

En UBL, il y a un message pour les factures (INVOICE) et un autre pour les avoirs (CREDIT NOTE). La
description se poursuit donc sur les autres colonnes de la même façon pour le message CREDIT NOTE.

Les colonnes CR et suivantes indique les modifications faites par les différentes versions.

Cette description pourrait conduire à la création d’un xsd dédié à chaque profil, restreignant l’arbre de
données au strict nécessaire. En pratique, la restriction se fait au travers du schematron d’application de la
Norme EN 16931 pour ce profil; Ceci implique l’ajout d’un grand nombre de règles qui viennent s’ajouter au
schématron, nommées « UBL-CR-XXX »

Les schematrons correspondants pour le profil EN 16931 se trouvent sur CE LIEN. La lecture du fichier
« EN 16931-UBL-validation-preprocessed.sch ¬ permet de voir l’ensemble de ces règles syntaxiques, qui
d’ailleurs, pour la plupart, consistent à désactiver certaines branches ou feuilles de l’arbre de données UBL
INVOICE, n’empêchent pas la facture de pouvoir être considérée comme valide, lorsque ces règles sont en
« warning » et non en « fatal ».

4.8.7 Feuilles « FACTUR-X BASIC WL FR », « CII D22B & FX EN 16931 FR » et « CII D22B & FX EXT-
CTC-FR)

Ces feuilles décrivent respectivement les trois profils BASIC WL (uniquement pour Factur-X), EN16931 et
EXTENDED-CTC-FR en UN/CEFACT CII, que ce soit en fichier de facture structuré ou comme composante du
Factur-X (fichier attaché factur-x.xml). Ceci décrit la structure du message UN/CEFACT CII restreint aux
champs nécessaires pour implémenter les trois profils, dans l’ordre du message (puisque les données doivent
être présentées suivant un arbre strictement défini, y compris dans l’ordre des données d’un même niveau).

Ces feuilles décrivent le message Facture : CII (signifiant Cross Industry Invoice), sachant qu’en UN/CEFACT
CII les AVOIRS et tous types de factures se codifient suivant ce message CII (pas de message CREDIT NOTE
dédié comme en UBL).

La structure du message est commune à l’ensemble des messages supply chain du modèle UN/CEFACT SCRDM
(Supply Chain Reference Data Model) dont le CII est un des messages (avec le CIO pour le message ORDER par
exemple).
AFNOR XP Z12-0122025-11

_Source: `c:\Users\g.baudrit\source\repos\gbaudrit\conf-aimer-votre-llm\demo\ctxc-sample-spec\with-ctxc\spec/afnor 1.2/XP_Z12-012/XP_Z12-012.pdf` (page:70/page:70)_

### E-e24ffe8a0457

XP Z12-012 – Formats et Profils des messages Factures et Statuts de cycle de vie,
constitutifs du socle minimal applicable à la Réforme Facture Électronique en France

69 
Il s’organise de la façon suivante (version réduite, puis plus déployée) : 
AFNOR XP Z12-0122025-11

_Source: `c:\Users\g.baudrit\source\repos\gbaudrit\conf-aimer-votre-llm\demo\ctxc-sample-spec\with-ctxc\spec/afnor 1.2/XP_Z12-012/XP_Z12-012.pdf` (page:71/page:71)_

### E-2fcb3241d1a4

XP Z12-012 – Formats et Profils des messages Factures et Statuts de cycle de vie,
constitutifs du socle minimal applicable à la Réforme Facture Électronique en France

70 
AFNOR XP Z12-0122025-11

_Source: `c:\Users\g.baudrit\source\repos\gbaudrit\conf-aimer-votre-llm\demo\ctxc-sample-spec\with-ctxc\spec/afnor 1.2/XP_Z12-012/XP_Z12-012.pdf` (page:72/page:72)_

### E-c3fddfa9f42a

XP Z12-012 – Formats et Profils des messages Factures et Statuts de cycle de vie,
constitutifs du socle minimal applicable à la Réforme Facture Électronique en France

71 
Ce qui donne la structure suivante, plus arborescente que la Norme EN 16931 et l’UBL :

• rsm:ExchangedDocumentContext : Bloc d’identification (Contexte) du message, qui contient les
informations définissant le processus sous-jacent (BT-23), puis le profil du message (BT-24), par
exemple urn:cen.eu:en16931:2017 pour le profil EN 16931

• rsm:ExchangedDocument : Bloc d’entête du message, qui contient des informations sur le message
lui-même avec le Numéro de facture (BT-1), puis son codetype (BT-3), puis sa date d’émission (BT-2),
puis les notes (BG-1).

• rsm:SupplyChainTradeTransaction : Bloc des informations de la transaction commerciale, corps de
la facture, lui-même composée de :

✓ ram:IncludedSupplyChainTradeLineItem : Bloc des lignes, qui donne toutes les informations
de lignes, elles-mêmes regroupées par sous-groupes structurés comme le corps du message.

✓ ram:ApplicableHeaderTradeAgreement : Bloc d’identification des Parties et des références à
la transaction, qui contient toutes les références et les Parties de l’échange, sauf celles relatives à
la facturation elle-même et au paiement.

✓ ram:ApplicableHeaderTradeDelivery : Bloc d’identification des informations de livraison

✓ ram:ApplicableHeaderTradeSettlement : Bloc d’information des termes de l’accord, c’est-à-
dire les acteurs de la facturation et du paiement (Facturant, Facturé à / Adressé à, Bénéficiaire,
Payeur), ainsi que les Remises et charges de niveau Document, le pied de TVA, les données de
paiement et les totaux.

Le fichier Excel présente le message en décrivant l’arbre en partant du haut et en descendant, branches par
branches, feuilles par feuilles; Les colonnes de la présentation Excel s’organisent de la façon suivante pour le
message UN/CEFACT CII :

• Colonne B : Codes de blocs CII, qui permettent de montrer la structure générale du message (cf -ci-
dessus), des codes couleurs permettent d’illustrer la structure du message

• Colonne C : ID des données de l’implémentation du profil en UN/CEFACT CII; On retrouve les ID de la
Norme sémantique, avec quelques ajouts suffixés pour identifier les éléments de structure
complémentaires. Pour les données d’extension, c’est la nomenclature du profil EXTENDED de Factur-
X qui est utilisée (car préexistante).

• Colonne D : ID de la donnée, dans le modèle sémantique français, avec la nomenclature des données
d’extension correspondante (cf feuille « FE EN 16931 + EXTENDED »).

• Colonne E : niveau d’arborescence en UN/CEFACT CII (différent de celui de la Norme EN 16931, car
l’arborescence du CII n’est pas la même que celle de la norme EN 16931); C’est ce qui permet de
matérialiser l’arbre de données UN/CEFACT CII, avec la cardinalité en colonne F, G et AS;

• Colonne F et G : cardinalités de la donnée pour les profils BASIC WL et EN 16931 (colonne F) et
EXTENDED-CTC-FR et EXTENDED de Factur-X (Colonne G), ce qui inclut implicitement une règle de
gestion quand elle est différente de la cardinalité du message UN/CEFACT CII complet présente en
colonne AS. Par exemple si la cardinalité UN/CEFACT CII est 0..n (colonne AS) et que celle de la colonne
G est 1;;1, cela signifie que la donnée n’est plus optionnelle et répétable, mais obligatoire et présente
une fois seulement. Ceci peut soit s’implémenter est créant un xsd dédié, soit au travers d’une règle de
gestion décrite dans un schematron (qui dira que la donnée DOIT être présente une fois et une seule).

• Colonne H : Nom de la donnée reprise du modèle sémantique de la feuille « FE EN 16931 +
EXTENDED ».

• Colonne I : Xpath UN/CEFACT CII.

• Colonnes J à AB : reprennent les informations des colonnes M à AC de la description sémantique
(feuille « FE EN 16931 + EXTENDED ».
AFNOR XP Z12-0122025-11

_Source: `c:\Users\g.baudrit\source\repos\gbaudrit\conf-aimer-votre-llm\demo\ctxc-sample-spec\with-ctxc\spec/afnor 1.2/XP_Z12-012/XP_Z12-012.pdf` (page:73/page:73)_

### E-fc6355790d27

XP Z12-012 – Formats et Profils des messages Factures et Statuts de cycle de vie,
constitutifs du socle minimal applicable à la Réforme Facture Électronique en France

72 
• Colonnes AD et AE : appartenance de la ligne au Flux 1 (permet ensuite un filtrage), profils Base et Full.

• Colonnes AG à AU : description du mapping UN/CEFACT CII :

✓ Colonne AG : nom du terme du champ de la Norme.

✓ Colonne AH : description de la donnée (Norme EN 16931).

✓ Colonne AI : Note d’usage de la donnée (Norme EN 16931).
✓ Colonne AJ : règles de CIUS ChorusPro (pour rappel, et info).

✓ Colonne AK : règles de la Norme EN 16931 applicable, ainsi que quelques règles PEPPOLBIS 3.0,
pour info.

✓ Colonne AL : type de la donnée.

✓ Colonne AM : cardinalité du modèle UN/CEFACT CII des profils BASIC WL (Factur-X) et EN16931,
source de la colonne F pour ces profils.

✓ Colonne AN : cardinalité du modèle UN/CEFACT CII des profils EXTENDED-CTC-FR et EXTENDED
(Factur-X), source de la colonne G pour le profil EXTENDED-CTC-FR.

✓ Colonne AO et AP = Xpath, en présentation déployée ou en ligne.

✓ Colonne AS : Cardinalité du message UN/CEFACT CII complet (indique le cas échéant le potentiel
d’évolution pour le profil);

✓ Colonnes AT et AU : informations de mapping de la Norme.

• Colonnes AX à BC : indique quelles lignes de description appartient à quel profil, ce qui permet d’avoir
une vision de chaque profil par simple filtrage.

• Colonnes BE et BF : donne le profil de Factur-x, qui est organisé en poupées gigognes : MINIMUM, puis
BASIC WL, puis BASIC, puis EN 16931, puis EXTENDED. La colonne BF donne un détail plus fin du
profil EXTENDED en intercalant le profil EXTENDED-CTC-FR.

• Colonnes BL à CP : exactement les mêmes que les colonnes AG à BF, mais en anglais.

• Colonnes CR et suivantes : indique(nt) les modifications faites par les différentes versions.

Cette description peut conduire à la création d’un xsd dédié à chaque profil, restreignant l’arbre de données
au strict nécessaire; C’est ce qui est fait pour chaque profil de Factur-X (voir cette page pour disposer de la
dernière version de la documentation et des description xsd et schematrons associés).

Pour la mise en œuvre du profil de la Norme EN 16931 seule, les outils proposés par la Commission
Européenne s’appuie sur le message UN/CEFACT CII D16B complet, sur lequel s’applique un schematron
d’application; Ceci implique l’ajout d’un grand nombre de règles qui viennent s’ajouter au schematron,
nommées « CII-SR-XXX » ou « CII-DT-XXX ».

Les schematrons correspondants pour le profil EN 16931 se trouvent sur CE LIEN. La lecture du fichier
« EN 16931-CII-validation-preprocessed.sch» permet de voir l’ensemble de ces règles syntaxiques, qui
d’ailleurs, pour la plupart, consistent à désactiver certaines branches ou feuilles de l’arbre de données
UN/CEFACT CII, n’empêchent pas la facture de pouvoir être considérée comme valide, lorsque ces règles sont
en « warning » et non en « fatal ».

Dans cette description, les lignes en rose correspondent à des données du profil EXTENDED-CTC-FR (et donc
aussi EXTENDED de Factur-X). Les lignes en gris plus ou moins foncé matérialisent le niveau de la structure
UN/CEFACT CII (plus la couleur est foncée, plus le niveau est proche de la racine).
AFNOR XP Z12-0122025-11

_Source: `c:\Users\g.baudrit\source\repos\gbaudrit\conf-aimer-votre-llm\demo\ctxc-sample-spec\with-ctxc\spec/afnor 1.2/XP_Z12-012/XP_Z12-012.pdf` (page:74/page:74)_

### E-fac48bc24014

XP Z12-012 – Formats et Profils des messages Factures et Statuts de cycle de vie,
constitutifs du socle minimal applicable à la Réforme Facture Électronique en France

73 
4.8.8 Feuilles « FE - Flux 1 », « Flux 1 UBL » et « Flux 1 CII »

Ces feuilles décrivent le flux 1 de 3 façons :

• Feuille « FE - Flux 1 » : la description du Flux 1 en modèle sémantique, telle que publiée dans la version
3.1 des spécifications externes. En colonnes W à AC les règles de gestion applicables des spécifications
externes 3.1 sont fournies en texte sur chaque ligne.

• Feuille « Flux 1 UBL » : la description du Flux 1 en UBL faite à partir du filtrage de la feuille « CII D22B
& FX EXT-CTC-FR » sur les données Flux 1 CIBLE (colonne AE), à laquelle les charges de niveau
Document ont été ajoutés (car ils le seront).

• Feuille « Flux 1 CII » : la description du Flux 1 en UN/CEFACT faite à partir du filtrage de la feuille
« Flux 2 UBL EXT-CTC-FR » sur les données Flux 1 CIBLE (colonne AF), à laquelle les charges de niveau
Document ont été ajoutés (car ils le seront).

4.8.9 Feuille « E-REPORTING - Flux 10 »

Il s’agit de la feuille de description du flux 10 publiée dans les spécifications externes 3.1, complétée de la
correspondance avec les données du modèle sémantique pour le flux 10.1, fournie en colonne S.

4.8.10 Feuille « Règles de gestion 3.1 »

Rappel des règles de gestion (Annexe 7), publiées dans les spécifications externes 3.1.
AFNOR XP Z12-0122025-11

_Source: `c:\Users\g.baudrit\source\repos\gbaudrit\conf-aimer-votre-llm\demo\ctxc-sample-spec\with-ctxc\spec/afnor 1.2/XP_Z12-012/XP_Z12-012.pdf` (page:75/page:75)_

### E-1463d8404445

XP Z12-012 – Formats et Profils des messages Factures et Statuts de cycle de vie,
constitutifs du socle minimal applicable à la Réforme Facture Électronique en France

74 
5 Le message de Cycle de Vie – CDAR

Le message de cycle de vie est implémenté en UN/CEFACT CDAR (Cross Domain Application and Response).
Il permet transmettre des informations sur un ou plusieurs messages reçus, à la fois pour renseigner sur la
bonne transmission mais aussi sur le bon traitement ou pas. Dans les échanges entre les Plateformes Agréées
et le PPF, il est utilisé pour tous les types de flux ou d’objet métier échangés;

Le présent Document décrit son utilisation uniquement pour échanger des informations du cycle de vie sur le
message facture entre Plateformes Agréées et avec les utilisateurs finaux. Cette utilisation peut différer de
celle exigée par le PPF, y compris pour les messages de statuts obligatoires (essentiellement sur la gestion de
l’entête du message);

5.1 Description de la structure du message CDAR à utiliser

Le message CDAR D22B est disponible dans son intégralité

• sur le lien
https://unece.org/trade/documents/2024/12/standards/cross-domain-acknowledgement-and-
response-d22b
pour sa description xsd

• et sur le lien
https://unece.org/trade/documents/2020/06/standards/cross-domain-application-error-and-
acknowledgement-process-brs
pour avoir le document de description en anglais de l’utilisation de ce message.

La gestion du cycle de vie entre VENDEUR et ACHETEUR est décomposée en 2 phases :

• La phase de transmission qui vise à suivre le cheminement de la facture de son émission à sa réception
par le destinataire. Dans cette phase les statuts sont créés par les Plateformes Agréées à destination
de leur client et de la Plateforme Agréée de leur contrepartie (et pour les statuts dit « Obligatoires »,
ils sont aussi transmis au PPF).

• La phase de Traitement, qui vise à ce que le VENDEUR et l’ACHETEUR s’échangent des statuts sur le
cycle de vie des factures; Ces statuts sont alors créés par le VENDEUR ou l’ACHETEUR et ont vocation
à être acheminés à la contrepartie au travers des Plateformes Agréées, sans être modifié (comme les
factures).

Il n’est pas prévu ou exigé de faire des messages de statuts sur la bonne réception des messages de statuts.

Il sera cependant nécessaire de qualifier si le message de statut relève de la phase de transmission ou de
traitement, notamment car ceci aura un impact sur la création de l’entête du message.

En effet, d’une façon générale, l’identité des Plateformes Agréées utilisées par une entreprise n’a pas à être
révélée aux tiers; Ainsi, les Plateformes Agréées n’ont pas à être identifiées dans les messages de cycle de vie
qui ont vocation à être partagés de bout en bout.
AFNOR XP Z12-0122025-11

_Source: `c:\Users\g.baudrit\source\repos\gbaudrit\conf-aimer-votre-llm\demo\ctxc-sample-spec\with-ctxc\spec/afnor 1.2/XP_Z12-012/XP_Z12-012.pdf` (page:76/page:76)_

### E-8859ee93ca16

XP Z12-012 – Formats et Profils des messages Factures et Statuts de cycle de vie,
constitutifs du socle minimal applicable à la Réforme Facture Électronique en France

75 
Le schéma ci-dessous illustre le cycle de vie et les différents types de statuts : 

VENDEUR   

Rejetée
(à l’émission) 
PDPE 

Déposée

Emise par la
plateforme 

Rejetée 
PDPR 

Reçue par la
plateforme

Mise à disposition    ACHETEUR
Phase de
Transmission    

Phase de
Traitement  
Refusée Prise en charge

Légende   Approuvée

Statuts de Traitement
posés par les Entreprises  
Approuvée
partiellement
Statuts de transmission,
posés par les PDP   En litige

Statuts obligatoires
transmis au PPF  
Annulée
(par Facture Rectificative)

Facture
Complétée  Suspendue

Encaissée  Paiement
transmis

Les messages de statuts de cycles de vie ont vocation à être utilisés pour trois fonction distinctes :

• Informer sur le statut de transmission et de traitement, en indiquant le cas échéant des erreurs
constatées et des actions attendues.

• Agir sur le processus ou cas d’usage en indiquant des changements de situation, par exemple
l’affacturage d’une facture, la nécessité de payer sur un autre compte bancaire que celui indiqué dans
la facture, le cas échéant fournir une information complémentaire oubliée ou exigée, nécessaire au
traitement<

• Communiquer des informations relatives au paiement ou à l’encaissement, à l’exécution d’un
escompte, une approbation partielle, bref à indiquer différents montants pour des situations diverses.

Pour ce faire, le message de cycle de vie est illustré par le schéma ci-dessous, qui illustre la structure utile du
message dans son entête (certaines données du message complet non utilisées ont été exclues pour en
simplifier la lecture). Les traits forts indiquent une cardinalité obligatoire (1..1 minimum), et en cas de
répétabilité, une cardinalité 0;;∞ ou 1;;∞; est indiquée;
AFNOR XP Z12-0122025-11

_Source: `c:\Users\g.baudrit\source\repos\gbaudrit\conf-aimer-votre-llm\demo\ctxc-sample-spec\with-ctxc\spec/afnor 1.2/XP_Z12-012/XP_Z12-012.pdf` (page:77/page:77)_

### E-96e40577968b

XP Z12-012 – Formats et Profils des messages Factures et Statuts de cycle de vie,
constitutifs du socle minimal applicable à la Réforme Facture Électronique en France

76 
Sa structure se présente donc de la façon suivante :

• Un bloc d’entête « Exhange Document Context », qui contient le profil du message CDAR.

• Un bloc d’entête « Exchange Document », identifiant essentiellement les Parties : qui crée, qui
transmet, pour qui est-ce destiné ?

• Un bloc « Aknowledgement », obligatoire et répétable (cardinalité 0..n), mais qui ne sera utilisé qu’une
fois seulement par message CDAR.
Ce bloc contient lui-même un bloc « Document » (ci-dessous), obligatoire et répétable, permettant de
faire un message CDAR commun à plusieurs Documents, ce qui ne sera pas mis en œuvre en général;
Ce bloc « Aknowledgement », contient donc (cf description ci-dessous pour voir la suite de la structure
en schéma :

✓ Un bloc « Document », qui correspond à la facture objet du message de cycle de vie, qui contient
lui même :

➢ Un bloc de « détail de statut ¬, optionnel et répétable (cardinalité 0;;n), permettant d’expliquer des
erreurs constatées, ou de fournir des informations complémentaires, et qui contient pour ce faire :

▪ Un bloc « Characteristic », optionnel et répétable (cardinalité 0..n), dédié à renseigner des
données à modifier ou en erreur, à e-reporter, à qualifier certains statuts (montant approuvé ou
payé par exemple).

On retrouve ainsi la structure habituelle des messages UN/CEFACT, à savoir (les codes sont ceux de la
description de l’annexe Cycle de Vie des spécifications externes 3;0) :

• Un bloc de contexte (MDB-1), qui permet d’identifier un profil de message auquel se rattachera un xsd
et un schematron pour les règles de gestion spécifiques éventuelles (l’équivalent des BT-23 et BT-24
pour les factures).
AFNOR XP Z12-0122025-11

_Source: `c:\Users\g.baudrit\source\repos\gbaudrit\conf-aimer-votre-llm\demo\ctxc-sample-spec\with-ctxc\spec/afnor 1.2/XP_Z12-012/XP_Z12-012.pdf` (page:78/page:78)_

### E-a5e0aaf11b1e

XP Z12-012 – Formats et Profils des messages Factures et Statuts de cycle de vie,
constitutifs du socle minimal applicable à la Réforme Facture Électronique en France

77 
• Un bloc d’entête de message (MDB-2) composé de :

✓ MDT-4 (ID) : un Identifiant de message (numéro du message de cycle de vie).

✓ MDT-5 (Name) : un nom de message.

✓ MDG-4 (IssueDateTime) : une date et heure de création du message de cycle de vie.

✓ MDT-9 (LanguageID) : une langue du message (français ou anglais).

✓ MDG-9 (SenderTradeParty) : une Partie en charge de la transmission du message (« Sender ») :
dans notre contexte :

➢ Pour la phase de transmission, il s’agit des Plateformes Agréées, qui ne seront qualifiés que par le code
rôle (« WK ») en MDT-21.

➢ Pour la phase de traitement, il s’agira des utilisateurs (ACHETEUR ou VENDEUR, ou certains tiers).

✓ MDG-16 (IssuerTradeParty) : une Partie à l’origine du message (donc à sa création : « Issuer ») :
dans notre contexte :

➢ Pour la phase de transmission, il s’agit des Plateformes Agréées, qui ne seront qualifiés que par le code
rôle (« WK »), en MDT-40.

➢ Pour la phase de traitement, il s’agira des utilisateurs (ACHETEUR ou VENDEUR, ou certains tiers).

✓ MDG-23 (Recipient) : une ou plusieurs Partie(s) destinataires du message de statut
(« Recipient ») : ce sont les utilisateurs finaux.

• Un bloc « Acknowledgement » (MDB-03), qui peut être multiple en CDAR D22B, mais qui sera utilisé
en cardinalité 1..1, composé des éléments suivants :

✓ MDT-74 (MultipleReferencesIndicator) : un indicateur permettant de dire si le bloc est pour
plusieurs Documents ou un seul. Par défaut, les messages de statuts seront pour un seul document.
Il pourra y avoir des exceptions pour certains cas d’usage nécessitant d’avoir un statut pour 2
factures ou plus, liées, de façon exceptionnelle.

✓ MDT-75 (ID) : un Numéro, si nécessaire.

✓ MDT-77 (TypeCode) : un code type, qui va permettre de distinguer un statut de la phase
transmission (305) d’un statut de la phase traitement (23).

✓ MDT-75 (Name) : un nom.

✓ MDG-31 (IssueDateTime) : une date et heure de création de l’évènement objet du statut.

✓ MDG-32 (ReferenceReferencedDocument) : le document objet du statut : ici la facture.
AFNOR XP Z12-0122025-11

_Source: `c:\Users\g.baudrit\source\repos\gbaudrit\conf-aimer-votre-llm\demo\ctxc-sample-spec\with-ctxc\spec/afnor 1.2/XP_Z12-012/XP_Z12-012.pdf` (page:79/page:79)_

### E-0896228207a3

XP Z12-012 – Formats et Profils des messages Factures et Statuts de cycle de vie,
constitutifs du socle minimal applicable à la Réforme Facture Électronique en France

78 
Ensuite, le bloc Document (MDG-32) est composé des éléments suivants :

• MDT-87 : le numéro de facture.

• MDT-88 (StatusCode): un code statut standard, c’est-à-dire venant d’une liste standard UNTDID 1373,
les valeurs sont détaillées dans l’Excel et dans les règles de gestion; C’est un statut facultatif, mais à
utiliser notamment pour les factures internationales, et en cohérence avec le code statut spécifique de
la réforme (en MDT-105).

• MDT-91 (Typecode): code type de la facture (380, 381, <);

• MDT-94 : nom de la facture (s’il existe).

• MDG-34 : date et heure de réception de la facture; Pour les statuts de transmission, c’est la date et
heure à laquelle la Plateforme Agréée créateur du message a enregistré la facture (en émission ou en
réception respectivement); Pour les statuts de traitement, c’est la date et heure à laquelle la facture a
été reçue pour le destinataire ou a fait l’objet d’un statut « Déposée ¬ pour l’émetteur;

• MDT-96 : pièce jointe, utile quand il faut compléter une facture avec un document additionnel, et dans
certains cas d’usage, ceci permet de joindre aussi des factures (par exemple une demande de paiement
direct dans un cas de sous-traitance avec paiement direct).

• MDT-97 (ReferenceTypeCode) : Code type qualifiant de référence, à choisir dans la liste UNTDID 1153
(a priori sans utilité)

• MDG-35 (FormattedIssueDateTime) : date de la facture (permet d’identifier la facture de façon
unique)

• MDT-104 (Status) : libellé du statut fournit en code en MDT-88.

• MDT-105 (ProcessConditionCode) : code statut tel que défini par la réforme (200 à 213 pour les
factures pour l’instant);

• MDT-106 (ProcessCondition) : statut en texte correspondant au code en MDT-105.
AFNOR XP Z12-0122025-11

_Source: `c:\Users\g.baudrit\source\repos\gbaudrit\conf-aimer-votre-llm\demo\ctxc-sample-spec\with-ctxc\spec/afnor 1.2/XP_Z12-012/XP_Z12-012.pdf` (page:80/page:80)_

### E-cf09411bec02

XP Z12-012 – Formats et Profils des messages Factures et Statuts de cycle de vie,
constitutifs du socle minimal applicable à la Réforme Facture Électronique en France

79 
• MDG-40 (IssuerTradeParty) : identifie TOUJOURS le VENDEUR, ce qui permet d’identifier la facture
de façon unique (numéro, date et n° de SIREN du Vendeur)

• MDG-41 (RecipientTradeParty) : par convention, permet de nommer un nouveau Bénéficiaire en cas
d’Affacturage;

• MDG-42 (SenderTradeParty) : sans utilité

• MDG-37 (SpecifiedDocumentStatus) : Bloc permettant de donner des détails sur le statut (et
potentiellement plusieurs puisque c’est une cardinalité 0;;n);
AFNOR XP Z12-0122025-11

_Source: `c:\Users\g.baudrit\source\repos\gbaudrit\conf-aimer-votre-llm\demo\ctxc-sample-spec\with-ctxc\spec/afnor 1.2/XP_Z12-012/XP_Z12-012.pdf` (page:81/page:81)_

### E-c9e91009e038

XP Z12-012 – Formats et Profils des messages Factures et Statuts de cycle de vie,
constitutifs du socle minimal applicable à la Réforme Facture Électronique en France

80 
On peut alors détailler le bloc de détail de statut (MDG-37) :

• MDG-38 : date et heure du statut. A utiliser en cas de Message Cycle de Vie transmettant un historique
des statuts de cycle de vie. Sinon, la date et heure du statut est déjà fournie en MDG-31.

• MDT-111 (ConditionCode) : A utiliser en cas de Message Cycle de Vie transmettant un historique des
statuts de cycle de vie, correspond au code statut standard fourni en MDT-88. 

• MDT-113 (ReasonCode) : permet de renseigner le motif du statut en code, à choisir dans une liste.

• MDT-114 (Reason) : permet de renseigner le motif en texte.

• MDT-112 (Condition) : libellé du statut renseigné en MDT-111, uniquement en cas de fourniture d’un
historique de statuts.

• MDT-115 (ProcessConditionCode) : A utiliser en cas de Message Cycle de Vie transmettant un
historique des statuts de cycle de vie, correspond au code statut de la réforme (comme le MDT-105)

• MDT-116 (ProcessCondition) : A utiliser en cas de Message Cycle de Vie transmettant un historique
des statuts de cycle de vie, correspond à MDT-115, en texte.

• MDT-121 (RequestedActionCode) : Action demandée en code (par exemple en attente d’un AVOIR).

• MDT-122 (RequestedAction) : Action attendue en texte.
AFNOR XP Z12-0122025-11

_Source: `c:\Users\g.baudrit\source\repos\gbaudrit\conf-aimer-votre-llm\demo\ctxc-sample-spec\with-ctxc\spec/afnor 1.2/XP_Z12-012/XP_Z12-012.pdf` (page:82/page:82)_

### E-ab83eddb8c02

XP Z12-012 – Formats et Profils des messages Factures et Statuts de cycle de vie,
constitutifs du socle minimal applicable à la Réforme Facture Électronique en France

81 
• MDT-124-2 (SequenceNumeric) : Permet de donner un numéro à chaque enregistrement de Détail de
statut.

• MDG-39 (IncludedNote) : Note, avec un code sujet et un texte. Permet de donner un texte libre pour
commentaire.

• MDG-43 (SpecifiedDocumentCharacteristic) : Bloc d’information répétable permettant de fournir des
données nécessaires pour le statut, composé des éléments suivants : 

✓ MDT-206 (ID) : code de la donnée sur laquelle le détail de statut porte (BT-84 pour un IBAN par
exemple).

✓ MDT-207 (TypeCode) : Code permettant de qualifier comment le bloc va être utilisé, cf règle BR-
FR-CDV-CL-11.

✓ MDT-208 (ValueChangeIndicator) : permet d’indiquer s’il s’agit de proposer ou de demander une
modification de valeur (par exemple numéro d’IBAN suite à affacturage);
AFNOR XP Z12-0122025-11

_Source: `c:\Users\g.baudrit\source\repos\gbaudrit\conf-aimer-votre-llm\demo\ctxc-sample-spec\with-ctxc\spec/afnor 1.2/XP_Z12-012/XP_Z12-012.pdf` (page:83/page:83)_

### E-06942bd7ae11

XP Z12-012 – Formats et Profils des messages Factures et Statuts de cycle de vie,
constitutifs du socle minimal applicable à la Réforme Facture Électronique en France

82 
✓ MDT-211 (Name) : Nom de la donnée référencée en MDT-206 (par exemple IBAN).

✓ MDT-212 (Description) : Description de la donnée (si nécessaire).

✓ MDT-213 (Location) : Xpath de la donnée concernée dans le message facture.

✓ MDT-214 (Value) : Nouvelle valeur à prendre en compte, s’il s’agit d’une donnée de type Texte.

✓ MDT-215 (ValueAmount) : Valeur de montant quand il faut référencer un montant. En particulier
pour un montant à e-reporter ; un montant de paiement, un montant d’approbation de facture, <

✓ MDT-217 (ValueMesure) : permet de signifier une Valeur de type unité de mesure attendue.

✓ MDT-218 (ValueDateTime) : permet de signifier une Valeur de type Date et / ou heure attendue.

✓ MDT-221 (ValueCode) : permet de signifier une Valeur de type Code attendue.

✓ MDT-222 (ValueQuantity) : permet de signifier une Valeur de type Quantité attendue.

✓ MDT-223 (ValueNumeric) : permet de signifier une Valeur de type Numeric attendue.

✓ MDT-224 (ValuePercent) : permet de signifier une Valeur de type Pourcentage attendue, et en cas
d’utilisation pour e-reporting d’encaissement, le taux de TVA applicable au montant encaissé
s’exprime ici;

5.2 Règles de gestion applicables

Le tableau ci-dessous liste les règles de gestion applicables au message CDAR pour l’échange de statuts de
Cycle de Vie de factures. Il s’agit principalement de règles qui rendent obligatoire une donnée facultative dans
le message CDAR ou de règle de liste de codes à respecter, en fonction du type de message (phase traitement
ou transmission). 

CODE BR  Titre  Description  S'applique à 

BR-FR-04  CodeType de la
facture
Les code types de documents pour une facture sont les suivants:
Factures simples :
- Facture commerciale (380)
- Facture auto-facturée (389)
- Facture affacturée (393)
- Facture auto-facturée affacturée (501) (*)

Factures d'acompte :
- Facture d'acompte (386)
- Facture d’acompte auto-facturée (500) (*) 

Factures rectificatives :
- Facture rectificative (384)
- Facture rectificative auto-facturée ( 471) (*)
- Facture rectificative affacturée (472) (*)
- Facture rectificative auto-facturée affacturée ( 473) (*)

Avoirs :
- Avoir auto-facturé (261)
- Avoir pour Remise Global (262)
- Avoir (381)
- Avoir affacturé (396)
- Avoir auto-facturé affacturé (502) (*)
- Avoir de facture d'acompte (503) (*)

Les autres types de factures définis dans la norme (UNTDID 1001) ne
doivent pas être utilisés.
/!\ : (*) En attente de l'intégration des codes par la maintenance
EN16931 
MDT-91 

BR-FR-CDV-01  Donnée Obligatoire  MDT-3 (et donc MDG-3)est obligatoire  MDG-3
AFNOR XP Z12-0122025-11

_Source: `c:\Users\g.baudrit\source\repos\gbaudrit\conf-aimer-votre-llm\demo\ctxc-sample-spec\with-ctxc\spec/afnor 1.2/XP_Z12-012/XP_Z12-012.pdf` (page:84/page:84)_

### E-9a29a6700862

XP Z12-012 – Formats et Profils des messages Factures et Statuts de cycle de vie,
constitutifs du socle minimal applicable à la Réforme Facture Électronique en France

83 
CODE BR  Titre  Description  S'applique à 

BR-FR-CDV-02  Donnée Obligatoire
MDT-3 doit être égal à urn.cpro.gouv.fr:1p0:CDV:invoice

Pour le CDV transmis au PPF, cette donnée doit être égale à
urn.cpro.gouv.fr:1p0:CDV:einvoicingF2 
MDT-3 

BR-FR-CDV-03  Donnée Obligatoire  MDT-4 est obligatoire  MDT-4 

BR-FR-CDV-04  Donnée Obligatoire  MDG-4 est obligatoire  MDG-4 

BR-FR-CDV-05  Donnée Obligatoire  MDG-9 est obligatoire  MDG-9 

BR-FR-CDV-06  Donnée Obligatoire  MDT-21 est obligatoire  MDT-21 

BR-FR-CDV-07  ID légal du
Destinataire du CDV
SI MDT-77 est égal à 23 ALORS MDT-38 est obligatoire
C'est un ID (légal, privé) de celui qui pose le statut
SI MDT-77 est égal à 305 ALORS MDT-38 n'est pas renseignée 
MDT-38 

BR-FR-CDV-08
Adresse électronique
du Destinataire du
CDV 
si MDT-59 EST DIFFERENT de WK ou DFH, MDT-73 est Obligatoire  MDT-73 

BR-FR-CDV-09 CDV Transmission ou
Traitement  MDT-77 est OBLIGATOIRE et doit être égal à 23 ou 305  MDT-77 

BR-FR-CDV-10  Identifiant unique de
facture : ID de Facture
MDT-87 (Identifiant du document objet du CDV) est OBLIGATOIRE

En cas de statut IRRECEVABLE (MDT-105 = 501), MDT-87 est le nom du
fichier irrecevable 
MDT-87 

BR-FR-CDV-11
Identifiant unique de
facture : Date de
facture 
MDG-35 est OBLIGATOIRE sauf si MDT-105 = 501 (IRRECEVABLE)  MDG-35 

BR-FR-CDV-12  Donnée Obligatoire  MDT-105 est OBLIGATOIRE  MDT-105 

BR-FR-CDV-13  Donnée Obligatoire  MDT-129 est OBLIGATOIRE sauf si MDT-105 = 501 (IRRECEVABLE)  MDT-129 

BR-FR-CDV-14  Statut Encaissé
Si le statut est "Encaissé" (MDT-105 = 212), ALORS il doit y avoir au
moins 1 Bloc MDG-43 avec une valeur de MDT-207 = MEN et une valeur
MDT-215 présente 
MDT-207 

BR-FR-CDV-CL-01  Donnée listée
MDT-2 est dans la liste ci-dessous :
- REGULATED
- NON_REGULATED
- B2C
- B2BINT
- OUTOFSCOPE

Cette donnée n'est pas transmise dans les CDV à destination du PPF
(pour les statuts obligatoires "Déposée", "Rejetée", "Refusée",
"Encaissée"), puisque seul les flux régulés (e-invoicing) font l'objet de
CDV vers le PPF. 

à compléter le cas échéant 
MDT-2
AFNOR XP Z12-0122025-11

_Source: `c:\Users\g.baudrit\source\repos\gbaudrit\conf-aimer-votre-llm\demo\ctxc-sample-spec\with-ctxc\spec/afnor 1.2/XP_Z12-012/XP_Z12-012.pdf` (page:85/page:85)_

### E-d3221c35f807

XP Z12-012 – Formats et Profils des messages Factures et Statuts de cycle de vie,
constitutifs du socle minimal applicable à la Réforme Facture Électronique en France

84 
CODE BR  Titre  Description  S'applique à 

BR-FR-CDV-CL-02 
CodeRole de
l'émetteur (Sender) du
CDV
Si le statut (MDT-77) est égal à 305, alors MDT-21 DOIT être égal à WK.
Si le statut (MDT-77) est égal à 23, alors MDT-21 DOIT être dans la liste
suivante :

(extrait de UNCL 3035):

BY : Acheteur ;
AB : Représentant de l'acheteur pour la vente.
DL : Affactureur (Factor)
SE : Vendeur
AB : Agent d'acheteur
SR : Agent de Vendeur
WK : Plateforme ou opérateur de dématérialisation (du
fournisseur/vendeur ou de l'acheteur) => Plateforme Agréée ou autre
PE : Bénéficiaire (Payee)
PR : Payeur

II : INVOICER (Invoice issuer)
IV : INVOICEE 
MDT-21 

BR-FR-CDV-CL-03  CodeRole du Créateur
(Issuer) du CDV
Si le statut (MDT-77) est égal à 305, alors MDT-40 DOIT être égal à WK
Si le statut (MDT-77) est égal à 23, alors MDT-40 est dans la liste
suivante :

(extrait de UNCL 3035)

BY : Acheteur ;
AB : Représentant de l'acheteur pour la vente.
DL : Affactureur (Factor)
SE : Vendeur
AB : Agent d'acheteur
SR : Agent de Vendeur
PE : Bénéficiaire (Payee)
PR : Payeur

II : INVOICER (Facturant)
IV : INVOICEE (Facturé à, adressé à) 
MDT-40 

BR-FR-CDV-CL-04  CodeRole du
Destinataire du CDV
MDT-59 DOIT ETRE dans la liste suivante :

(Extrait de UNCL 3035)

BY : Acheteur ;
AB : Représentant de l'acheteur pour la vente.
DL : Affactureur (Factor)
SE : Vendeur
AB : Agent d'acheteur
SR : Agent de Vendeur
PE : Bénéficiaire (Payee)
PR : Payeur

II : INVOICER (Facturant)
IV : INVOICEE (Facturé à, adressé à) 

WK : Plateforme ou opérateur de dématérialisation (du
fournisseur/vendeur ou de l'acheteur) 
MDT-59
AFNOR XP Z12-0122025-11

_Source: `c:\Users\g.baudrit\source\repos\gbaudrit\conf-aimer-votre-llm\demo\ctxc-sample-spec\with-ctxc\spec/afnor 1.2/XP_Z12-012/XP_Z12-012.pdf` (page:86/page:86)_

### E-b0773dfa432b

XP Z12-012 – Formats et Profils des messages Factures et Statuts de cycle de vie,
constitutifs du socle minimal applicable à la Réforme Facture Électronique en France

85 
CODE BR  Titre  Description  S'applique à 

BR-FR-CDV-CL-05  Code Statut Standard
(UNTDID 1373)
MDT-88 DOIT ETRE dans la liste UNTDID 1373, avec les
correspondances suivantes pour les statuts MDT-105

Phase Transmission : MDT-77 = 305
•10 (Document valid) : Déposée
•51 : Emise
•43 : Reçue
•8 : Rejetée
•48 : Acknowledge = Mise à Disposition 

Phase Traitement : MDT-77 = 23
• 45 (In Process) = Prise en charge
• 39 (on hold) = Suspendue
• 37 (Complete) = Complétée
• 50 (Refjected / Refused) = Refusée (by C4)
• 49 (Conditionnaly accepted) = Approuvée Partiellement
• 47 (Paid) = Paiement Transmis ET Encaissée
• 46 (Under Query) = En litige
• 1 (accepted) = Approuvée 
MDT-88 

BR-FR-CDV-CL-06  Code Statut Reforme  MDT-105 et MDT-115 sont dans la liste des Codes statuts de Facture  MDT-105, MDT-115 

BR-FR-CDV-CL-07  Code Type du Vendeur  MDT-132 DOIT ETRE égal à SE : Vendeur  MDT-132 

BR-FR-CDV-CL-08 
CodeRole du
Destinataire de la
facture (Nouveau
Bénéficiaire)
MDT-158 DOIT ETRE dans la liste ci-dessous :

(Extrait de UNCL 3035)

BY : Acheteur ;
AB : Représentant de l'acheteur pour la vente.
DL : Affactureur (Factor)
SE : Vendeur
AB : Agent d'acheteur
SR : Agent de Vendeur
WK : Plateforme ou opérateur de dématérialisation (du
fournisseur/vendeur ou de l'acheteur) ;
DFH : Pour le PPF
PE : Bénéficiaire (Payee)
PR : Payeur

II : INVOICER
IV : INVOICEE 
MDT-158 

BR-FR-CDV-CL-09 Code MOTIFS de
Statuts  MDT-113 est dans la liste des Codes motifs de statuts  MDT-113 

BR-FR-CDV-CL-10  Code ACTION requise  MDT-121 est dans la liste des Codes actions de Facture  MDT-121
AFNOR XP Z12-0122025-11

_Source: `c:\Users\g.baudrit\source\repos\gbaudrit\conf-aimer-votre-llm\demo\ctxc-sample-spec\with-ctxc\spec/afnor 1.2/XP_Z12-012/XP_Z12-012.pdf` (page:87/page:87)_

### E-c56a9a359cf8

XP Z12-012 – Formats et Profils des messages Factures et Statuts de cycle de vie,
constitutifs du socle minimal applicable à la Réforme Facture Électronique en France

86 
CODE BR  Titre  Description  S'applique à 

BR-FR-CDV-CL-11  Code objet MDG-43
MDT-207 est dans la liste suivante (à compléter) :

- MEN : Montant encaissé (TTC)
- MPA : Montant payé
- RAP : Reste à payer (en cas de paiement partiel);

- ESC : Escompte accordé ;
- RAB : Rabais accordé ;
- REM : Remise accordée.
- MAP : Montant HT Approuvé
- MAPTTC : Montant TTC Approuvé
- MNA : Montant HT NON Approuvé
- MNATTC : Montant TTC Non Approuvé

- CBB : Coordonnées Bancaires Bénéficiaire à modifier
- DIV : Donnée INVALIDE
- DVA : Donnée VALIDE attendue
- MAJ : Donnée à prendre en compte à la place de celle présente dans la
facture pour le traitement (Statut "Complétée" ou "Complément") 
MDT-207

5.3 Motifs des statuts de cycle de vie.

Certains statuts ont des listes restreintes de motifs, et notamment ceux qui ont comme conséquence
l’annulation automatique des factures : statuts « Rejetée à l’émission », « Rejetée en réception » et « Refusée ».

La liste de ces statuts est fournie dans la feuille « Tableau des motifs de STATUTS », avec leur description.

Un motif « NON_TRANSMISE » a été ajouté pour le statut « Déposée » pour le cas où une facture a pu être
traitée en émission, et donc faire l’objet d’un statut « Déposée ¬ qu’une transmission soit effectivement
possible du fait d’absence de choix de Plateforme Agréée de réception par le destinataire (c’est-à-dire parce
que le destinataire est bien présent dans l’annuaire mais ne dispose d’aucune ligne d’adressage associée à une
plateforme différente de la plateforme par défaut – matricule 9998).

5.4 Présentation du fichier annexe pour les feuilles CDAR

Le fichier Excel annexe au présent document décrit aussi l’implémentation du message Cycle de Vie appliquée
aux échanges de factures B2B au travers des Plateformes Agréées.

5.4.1 Feuille « CDV FE – CDAR »

Il s’agit de la feuille de description du message Cycle de Vie (CDAR : Cross Domain Aknowledgement &
Response); La source est l’Annexe 2 des spécifications externes 3.0, à laquelle certaines colonnes ont été
ajoutées :

• Colonne A : ID de la donnée (celle de l’Annexe 2 des spécifications externes 3.0)

• Colonne B : le niveau dans la structure XML (0 racine, 1, premier bloc, ..)

• Colonne C : Cardinalité dans le message CDAR

• Colonne D (masquée) : cardinalité corrigée pour le PPF dans l’annexe 2 des spécifications externes 3.0.
Ceci sera géré par des règles de schematron et pas par une modification de cardinalité xsd.

• Colonnes F à I : description des données, par niveau.

• Colonne J (et K, masquée) : Xpath en présentation dépliée (la présentation en une ligne est en colonne
K, masquée)
AFNOR XP Z12-0122025-11

_Source: `c:\Users\g.baudrit\source\repos\gbaudrit\conf-aimer-votre-llm\demo\ctxc-sample-spec\with-ctxc\spec/afnor 1.2/XP_Z12-012/XP_Z12-012.pdf` (page:88/page:88)_

### E-b2dc572bb123

XP Z12-012 – Formats et Profils des messages Factures et Statuts de cycle de vie,
constitutifs du socle minimal applicable à la Réforme Facture Électronique en France

87 
• Colonne L : règle de présence des données : R (Requise), O (Optionnelle), I (informatif, en pratique non
utilisée), pour les échanges entre Plateformes Agréées et PPF, pour information seulement.

• Colonne M : règle de présence des données : R (Requise), O (Optionnelle), I (informatif, en pratique
non utilisée) pour les échanges entre Plateformes Agréées; C’est cette colonne qui doit être prise en
compte pour la description du format CDV. Pour simplifier la lecture, la feuille a été filtrée de façon à
ne pas montrer les lignes « I ».

• Colonnes N à R : description des types logiques, longueur exigée par le PPF, listes applicables,
définition métier et commentaire reprises de l’Annexe 2 des spécifications externes 3.0

• Colonnes S à U (masquées) : règles de gestion à appliquer sur le message CDV pour les échanges PPF
 Plateformes Agréées.

• Colonne V : Règle de gestion à appliquer pour l’utilisation du message CDV entre Plateformes Agréées,
objet du présent document.

• Colonne W : texte des règles de gestion de la colonne V

• Colonne X : filtrage pour exclure les lignes du message qui n’ont pas à être utilisées.

5.4.2 Feuille « BR-FR-CDV pour factures »

Cette feuille reprend l’ensemble des règles de gestion applicables sur le message Cycle de Vie pour les
échanges de factures via les Plateformes Agréées. Base de construction du schematron à appliquer :

• Colonne B : Code de la règle de gestion

• Colonne C : Titre de la règle de gestion

• Colonne D : Description de la règle de gestion

• Colonne E : sur quelle(s) données du message la règle s’applique-t-elle.

• Colonnes G et après : indiquent les modifications apportées à chaque version.

5.4.3 Feuille « Acteurs CDV »

Cette feuille décrit, pour chaque statut, comment renseigner l’entête du message CDV, de façon à ne pas
nommer les Plateformes Agréées dans les messages. Il exprime aussi qui peut émettre le message (rôle) et
quels sont les destinataires.

5.4.4 Feuille « Codes Action »

Cette feuille présente les codes « Action » attendue, précédemment présents en feuille « Acteurs CDV ».

5.4.5 Feuille « Tableau des motifs de STATUTS »

Cette feuille présente les motifs applicables aux statuts :

• Colonne A : Code MOTIF

• Colonne B : Libellé du Motif

• Colonne C : Description du MOTIF et de quand il peut être utilisé

• Colonnes I à Q : Pour quels statuts le Motif peut être utilisé. Par filtrage, ceci permet d’avoir la liste des
motifs applicables par statut.

• Colonnes T et suivantes : indiquent les modifications apportées à chaque version.
AFNOR XP Z12-0122025-11

_Source: `c:\Users\g.baudrit\source\repos\gbaudrit\conf-aimer-votre-llm\demo\ctxc-sample-spec\with-ctxc\spec/afnor 1.2/XP_Z12-012/XP_Z12-012.pdf` (page:89/page:89)_

### E-79a77f97e655

XP Z12-012 – Formats et Profils des messages Factures et Statuts de cycle de vie,
constitutifs du socle minimal applicable à la Réforme Facture Électronique en France

88 
(normative)

Description Excel des formats et profils 

XP_Z12-012_Annexe_A_V1.2.xls
AFNOR XP Z12-0122025-11

_Source: `c:\Users\g.baudrit\source\repos\gbaudrit\conf-aimer-votre-llm\demo\ctxc-sample-spec\with-ctxc\spec/afnor 1.2/XP_Z12-012/XP_Z12-012.pdf` (page:90/page:90)_

### E-b736e5939d0e

XP Z12-012 – Formats et Profils des messages Factures et Statuts de cycle de vie,
constitutifs du socle minimal applicable à la Réforme Facture Électronique en France

89 
(normative)

Exemples de factures (flux 2) et de messages CDAR de cycle de vie 

XP_Z12-012_Annexe_B_V1.2.zip
AFNOR XP Z12-0122025-11

_Source: `c:\Users\g.baudrit\source\repos\gbaudrit\conf-aimer-votre-llm\demo\ctxc-sample-spec\with-ctxc\spec/afnor 1.2/XP_Z12-012/XP_Z12-012.pdf` (page:91/page:91)_

### E-66d1c1ecb722

XP Z12-012 – Formats et Profils des messages Factures et Statuts de cycle de vie,
constitutifs du socle minimal applicable à la Réforme Facture Électronique en France

90 
Bibliographie 

[1] Dossier de spécifications externes de la Facture électronique 3.0 - Dossier général - Agence
pour l’informatique financière de l’État;
[2] Dossier de spécifications externes de la Facture électronique 2.4 - Dossier général - Agence
pour l’informatique financière de l’État;
[3] Documentation du format Factur-X, publié par le FNFE-MPE et le FeRD, mis à jour tous les 6
mois, les 15 mai et 15 novembre de chaque année sur le site www.fnfe-mpe.org
AFNOR XP Z12-0122025-11

_Source: `c:\Users\g.baudrit\source\repos\gbaudrit\conf-aimer-votre-llm\demo\ctxc-sample-spec\with-ctxc\spec/afnor 1.2/XP_Z12-012/XP_Z12-012.pdf` (page:92/page:92)_

### E-abcd66e3bba7

  XP Z12-012 - Formats et Profils des messages Factures et Statuts de cycle de vie, constitutifs du socle
minimal applicable à la Réforme Facture Électronique en France.
ANNEXE B (normative) : Exemples de factures (flux 2) et de messages CDAR de cycle de vie
Page 1/25 
Commission de Normalisation AFNOR Facture Électronique
XP Z12-014 

Annexe B
Exemples de factures (flux 2) et de messages CDAR de cycle de vie 

Version 1.3 du 26 février 2026 

Rédacteur : FNFE-MPE, sur la base des travaux initiaux de la DPFE de la DGFIP et l’AIFE et en application des travaux de la
Commission de Normalisation AFNOR Facture Électronique, de l’ensemble de ses membres et des réunions de travail des
sous-groupes. 

GESTION DE VERSION

N° de Version Date de Version Description des évolutions

V1.0 2025 07 31 Version initiale

V1.2 2025 10 31
Modification PDP => PA

Correction de quelques erreurs sur les exemples de cycle de vie :

• Gestion dépendante des CDV PPF des CDV entre PA : MDT-2, MDT-3
• Présence de MDT-4 (dépendante aussi des CDV PPF / PA)

Suppression d’espace dans certains MOTIFS

V1.3 2026 02 26
Ajout d’exemples UBL EXTENDED

Ajout d’exemples de factures avec sous-ligne (UBL, CII, Factur-x)

Ajout de factures Multi-Vendeur (UBL, CII, Factur-X)  

_Source: `c:\Users\g.baudrit\source\repos\gbaudrit\conf-aimer-votre-llm\demo\ctxc-sample-spec\with-ctxc\spec/afnor/XP_Z12-012/XP_Z12-012_cdar.pdf` (page:1/page:1)_

### E-40903c7367ee

  XP Z12-012 - Formats et Profils des messages Factures et Statuts de cycle de vie, constitutifs du socle
minimal applicable à la Réforme Facture Électronique en France.
ANNEXE B (normative) : Exemples de factures (flux 2) et de messages CDAR de cycle de vie
Page 2/25 
Table des matières

1 Présentation générale .................................................................................................... 3
1.1 Factures .................................................................................................................................................... 3
1.2 Cycle de Vie - CDAR .................................................................................................................................. 4

2 Exemples ........................................................................................................................ 6
2.1 Exemples de factures ............................................................................................................................... 6
2.2 Exemples de messages CDV en CDAR ..................................................................................................... 23
2.2.1 Cas Nominal ...................................................................................................................................................... 23
2.2.2 Cas d’une facture en erreur pour illustrer un statut de litige ........................................................................... 25  

_Source: `c:\Users\g.baudrit\source\repos\gbaudrit\conf-aimer-votre-llm\demo\ctxc-sample-spec\with-ctxc\spec/afnor/XP_Z12-012/XP_Z12-012_cdar.pdf` (page:2/page:2)_

### E-1350843c3f1b

  XP Z12-012 - Formats et Profils des messages Factures et Statuts de cycle de vie, constitutifs du socle
minimal applicable à la Réforme Facture Électronique en France.
ANNEXE B (normative) : Exemples de factures (flux 2) et de messages CDAR de cycle de vie
Page 3/25 
1 Présentation générale

1.1 Factures

Les exemples de factures sont présentés sous les trois formats du socle minimum, tels que décrits dans la norme XP Z12-
012, à ce stade uniquement pour le profil EN16931 :

• Le format UN/CEFACT CII contient des commentaires sur chaque ligne comportant une donnée, permettant de
rappeler le code identifiant (BT-XX).
• Le format Factur-x permet d’avoir une représentation lisible, ce qui donne l’ensemble des données de la facture
sous forme lisible. Le factur-x.xml joint dans le Factur-x est l’UNCEFACT/CII ci-dessus, mais sans les commentaires.
• Le format UBL a été créé à partir du même jeu de données avec des commentaires sur chaque ligne comportant
une donnée, permettant de rappeler le code identifiant (BT-XX).

Comme expliqué dans la documentation, les syntaxes ont leur propre structure sémantique de données, ce qui conduit à
certains choix d’implémentation qu’il convient de garder en tête :

• La gestion des Notes est composée d’un contenu (BT-22) et d’un code sujet (BT-21). Si cette structure existe bien
en CII, ce n’est pas le cas en UBL. Il a été alors choisi de faire précéder le contenu de la Note de son code sujet entre
#. Exemple
ü #PMT#Indemnité forfaitaire pour frais de recouvrement en cas de retard de paiement : 40 €.
De plus, la norme autorise une cardinalité multiple pour les Notes (plusieurs Note). Si la cardinalité de la Note est
multiple en UBL, c’est pour permettre de la fournir en plusieurs langue. Par conséquent, bien que l’xsd et les
schematrons acceptent des Notes UBL multiples, un respect strict d’UBL voudrait qu’il n’y ait qu’une seule note par
facture. Il est donc possible de voir des factures UBL avec une concaténation de toutes les notes. En cas d’absence
de code sujet, il convient alors de séparer avec un double #. Exemple :
ü #Code#Texte#Code2#texte2##texte3 … 
Ceci n’est pas fait dans les exemples UBL, ce qui permet quand même une meilleure visibilité.
• La gestion des Identifiants des Parties, qui peut soit être privé (juste un Identifiant), soit être un Identifiant qualifié
par un schemeID (0009 pour SIRET, 0088 pour un GLN, …). La gestion est différente suivant qu’on est en UBL ou en
CII :
ü En UBL, on utilise un élément ID, avec son schemeID qui est optionnel (cardinalité 0..1). Donc comme la Norme
EN16931.
ü En CII, il existe 2 identifiants : 
§ ID, qui est sans schemeID, uniquement pour un ID privé non qualifié.
§ GlobalID qui oblige un @schemeID.
• Utilisation du bloc BG-24 (Documents Additionnels) pour les BT-17 (Référence à l’Appel d’offre ou au lot,
uniquement en CII) et de la BT-18 (Objet facturé, en CII et en UBL). Pour ce faire, une donnée additionnelle est
nécessaire dans le bloc BG-24 pour distinguer les 2 ou 3 BT :
ü Document TypeCode, qui prend les valeurs :
§ En UBL : en cac:AdditionalDocumentReference/cbc:ID : valeur 130 pour qualifier une donnée BT-18 (Objet
Facturé), le schemeID de l’OBjet facturé à choisir en litse 1153 devant être positionné en
cac:AdditionalDocumentReference/cbc:ID/@schemeID. Et aucune valeur dans ce champ pour un BG-24
§ En CII : en /ram:AdditionalReferencedDocument/ram:TypeCode avec les valeurs 130 pour un BT-18, 50 pour
un BT-17 et 916 pour un BG-24. Le qualifiant d’Objet facturé est quand à lui inscrit en
AdditionalReferencedDocument/ram:ReferenceTypeCode, à choisir dans la liste 1153.

Exemple en CII : 

<ram:AdditionalReferencedDocument> 
<ram:IssuerAssignedID>REF_ANNEXE_009875</ram:IssuerAssignedID>  <!-- BT-122 (Identifiant de document justificatif) : REF_ANNEXE_009875 --> 
<ram:URIID>url:gffter</ram:URIID>  <!-- BT-124 (Emplacement de document externe) : url:gffter --> 
<ram:TypeCode>916</ram:TypeCode>  <!-- BT-122-0 (Code type (916)) : 916 --> 
<ram:Name>DOCUMENT_ANNEXE</ram:Name>  <!-- BT-123 (Description de document justificatif) : DOCUMENT_ANNEXE -->
</ram:AdditionalReferencedDocument> 

<ram:AdditionalReferencedDocument> 

_Source: `c:\Users\g.baudrit\source\repos\gbaudrit\conf-aimer-votre-llm\demo\ctxc-sample-spec\with-ctxc\spec/afnor/XP_Z12-012/XP_Z12-012_cdar.pdf` (page:3/page:3)_

### E-ad196e643392

  XP Z12-012 - Formats et Profils des messages Factures et Statuts de cycle de vie, constitutifs du socle
minimal applicable à la Réforme Facture Électronique en France.
ANNEXE B (normative) : Exemples de factures (flux 2) et de messages CDAR de cycle de vie
Page 4/25 
<ram:IssuerAssignedID>APPEL_OFFRE-FRE0087</ram:IssuerAssignedID>  <!-- BT-17 (Identifiant d'appel d'offres ou de lot) : APPEL_OFFRE-FRE0087 --> 
<ram:TypeCode>50</ram:TypeCode>  <!-- BT-17-0 (Code type (50)) : 50 -->
</ram:AdditionalReferencedDocument> 

<ram:AdditionalReferencedDocument> 
<ram:IssuerAssignedID>REF_CLIENT2514</ram:IssuerAssignedID>  <!-- BT-18 (Identifiant d'objet facturé) : REF_CLIENT2514 --> 
<ram:TypeCode>130</ram:TypeCode>  <!-- BT-18-0 (Code type (130)) : 130 --> 
<ram:ReferenceTypeCode>IT</ram:ReferenceTypeCode>  <!-- BT-18-1 (Identifiant du schéma) : IT -->
</ram:AdditionalReferencedDocument> 

• Gestion de la BT-8 (TVA à l’encaissement ou au débit) :
ü En UBL, cette donnée est gérée au niveau document, comme une donnée unique, avec l’utilisation d’une liste
de code qui n’est pas la même qu’en UN/CEAT CII : 432 pour signifier une TVA à l’encaissement et 3 (date de
facture) pour indiquer une TVA au Débit.
ü En CII, la donnée est dans la ventilation de TVA (BG-23), qui est de cardinalité 0..n (car plusieurs taux ou
d’exemption sont possibles), ce qui implique soit de la fournir dans une des occurrences de la BG-23, soit de
fournir la même valeur dans chaque itération du bloc BG-23 en CII. Les valeurs à utiliser sont 72 pour exprimer
une TVA à l’encaissement, et 5 (date de facture) pour indiquer une TVA au débit.

A NOTER : en UBL, il y a un message dédié pour les avoir (Credit Note), qui est très proche du message INVOICE, mais avec
quelques différences.

1.2 Cycle de Vie - CDAR

Les exemples de cycle de vie sont présentés pour le cas nominal, partant de la facture UC1_F202500003_00-INV_20250701.

Tous les statuts sont présentés, avec 2 fichiers pour les statuts « Obligatoires » car le cycle de vie transmis au PPF diffère
légèrement de celui échangé entre Plateformes Agréées. En effet, les Plateformes Agréées sont identifiées et nommées
dans les messages de Cycle de Vie transmis au PPF alors qu’ils sont juste qualifiés (WK en CodeRole) pour les statuts échangés
entre Plateformes Agréées.

La raison est que les messages de cycle de vie ont vocation à être échangés tels quels avec les Émetteurs et Destinataires,
ce qui oblige à conserver l’anonymat des PDP utilisées par les uns vis-à-vis des autres.

Pour rappel, le message CDAR se décompose de la façon suivante (Exemple avec un message de statut d’encaissée, un des
plus complet) :

• Un entête donnant le contexte de l’échange
ü Le type de processus métier : REGULATED pour les factures relevant du e-invoicing en MDT-2 (rien n’est exigé
par le PPF et cette donnée est limitée à 3 caractères.
ü Un type de profil (MDT-3) : ici, il n’y en n’a qu’un seul qui signifie que c’est un flux 6 (CDV sur facture Flux 2 ou
Flux 3) : 
§ urn.cpro.gouv.fr:1p0:CDV:invoice pour les CDV entre Plateformes Agréées.
§ urn.cpro.gouv.fr:1p0:CDV:einvoicingF2 pour les CDV à destination du PPF.

Exemple pour un CDV à destination des Plateformes Agréées : 

<rsm:ExchangedDocumentContext>          
<ram:BusinessProcessSpecifiedDocumentContextParameter>               
<ram:ID>REGULATED</ram:ID>  <!-- MDT-2 (Type de processus métier (cadre de facturation)) : REGULATED -->          
</ram:BusinessProcessSpecifiedDocumentContextParameter>          
<ram:GuidelineSpecifiedDocumentContextParameter>               
<ram:ID>urn.cpro.gouv.fr:1p0:CDV:invoice</ram:ID>  <!-- MDT-3 (Type de profil (e-invoicing, e-reporting, facture etc..)) : urn.cpro.gouv.fr:1p0:CDV:invoice -->          
</ram:GuidelineSpecifiedDocumentContextParameter>     
</rsm:ExchangedDocumentContext> 

• Un entête de Document, qui indique :
ü Un Identifiant du Document (MDT-4) : avec une construction spécifique pour les CDV à destination du PPF.
ü Le nom du document (MDT-5).
ü La date et heure de création du Message de Cycle de vie : MDT-8 

_Source: `c:\Users\g.baudrit\source\repos\gbaudrit\conf-aimer-votre-llm\demo\ctxc-sample-spec\with-ctxc\spec/afnor/XP_Z12-012/XP_Z12-012_cdar.pdf` (page:4/page:4)_

### E-d7908016dcdc

  XP Z12-012 - Formats et Profils des messages Factures et Statuts de cycle de vie, constitutifs du socle
minimal applicable à la Réforme Facture Électronique en France.
ANNEXE B (normative) : Exemples de factures (flux 2) et de messages CDAR de cycle de vie
Page 5/25 
ü Les parties : le créateur du statut, l’émetteur du statut et le ou les destinataires. Voir la feuille « Acteurs CDV »
de l’Annexe A pour voir qui doit être identifié et comment, pour chaque statut.

Exemple : 

<rsm:ExchangedDocument>          
<ram:ID>F202500003_200_20250701151000#380_20250701</ram:ID>  <!-- MDT-4 (Id document) : F202500003_200_20250701151000#380_20250701 -->          
<ram:Name>UC1_F202500003_07-CDV-212_Encaissée</ram:Name>  <!-- MDT-5 (Nom document) : UC1_F202500003_07-CDV-212_Encaissée -->          
<ram:IssueDateTime>               
<udt:DateTimeString format="204">20250802100500</udt:DateTimeString>  <!-- MDT-8 (Date-heure de création du CDV) : 20250802100500 -->          
</ram:IssueDateTime>          
<ram:SenderTradeParty>               
<ram:RoleCode>WK</ram:RoleCode>  <!-- MDT-21 (Code rôle) : WK -->          
</ram:SenderTradeParty>          
<ram:IssuerTradeParty>               
<ram:GlobalID schemeID="0002">100000009</ram:GlobalID>  <!-- MDT-38 (ID émetteur document (global)) : 100000009 -->               
<ram:Name>VENDEUR</ram:Name>  <!-- MDT-39 (Raison sociale) : VENDEUR -->               
<ram:RoleCode>SE</ram:RoleCode>  <!-- MDT-40 (Code rôle) : SE -->          
</ram:IssuerTradeParty>          
<ram:RecipientTradeParty>               
<ram:GlobalID schemeID="0002">200000008</ram:GlobalID>  <!-- MDT-57 (ID destinataire (global)) : 200000008 -->               
<ram:Name>ACHETEUR</ram:Name>  <!-- MDT-58 (Raison sociale) : ACHETEUR -->               
<ram:RoleCode>BY</ram:RoleCode>  <!-- MDT-59 (Code rôle) : BY -->          
</ram:RecipientTradeParty>          
<ram:RecipientTradeParty>               
<ram:GlobalID schemeID="0238">9998</ram:GlobalID>  <!-- MDT-57t (-) : 9998 -->               
<ram:Name>PPF</ram:Name>  <!-- MDT-58t (-) : PPF -->               
<ram:RoleCode>DFH</ram:RoleCode>  <!-- MDT-59t (-) : DFH -->          
</ram:RecipientTradeParty>     
</rsm:ExchangedDocument> 

• Un bloc de regroupement de cycle de vie, qui n’est pas utilisé (un seul document par CDV, sauf cas très particulier),
qui contient :
ü Une information indiquant si c’est un statut de transmission (305) ou de traitement (23) : MDT-77
ü Une date et heure de dépôt du statut (par l’utilisateur) : MDT-78
ü Un bloc détaillant les caractéristiques de la facture Objet du message de cycle de vie, ainsi que le statut codifiée
2xx (212 pour un statut « Encaissé »), puis : 
§ Un bloc de détail de statut dans lequel est indiqué un motif de statut, une action requise, puis un dernier
sous-bloc de détail de données (par exemple le montant encaissé, avec taux de TVA applicable).

Exemple : 

<rsm:AcknowledgementDocument>          
<ram:MultipleReferencesIndicator>               
<udt:Indicator>false</udt:Indicator>  <!-- MDT-74 (Indicateur CDV MONO (false) ou MULTI (true) Document) : false -->          
</ram:MultipleReferencesIndicator>          
<ram:TypeCode>23</ram:TypeCode>  <!-- MDT-77 (Code type document) : 23 -->          
<ram:IssueDateTime>               
<udt:DateTimeString format="204">20250802100000</udt:DateTimeString>  <!-- MDT-78 (Date-heure de dépôt du statut CDV) : 20250802100000 -->          
</ram:IssueDateTime> 

<ram:ReferenceReferencedDocument>               
<ram:IssuerAssignedID>F202500003</ram:IssuerAssignedID>  <!-- MDT-87 (ID objet (BT-1 d'une facture)) : F202500003 -->               
<ram:StatusCode>47</ram:StatusCode>  <!-- MDT-88 (Code statut) : 47 -->               
<ram:TypeCode>380</ram:TypeCode>  <!-- MDT-91 (Code type de l'objet (BT-3 de la facture)) : 380 -->               
<ram:ReceiptDateTime>                    
<udt:DateTimeString format="204">20250701151000</udt:DateTimeString>  <!-- MDT-95 (Date-heure de réception de l'objet (pour une facture : date statut
Déposée / Rejetée pour l'Emetteur ; date statut Reçue / Rejetée pour le Destinataire)) : 20250701151000 -->               
</ram:ReceiptDateTime>               
<ram:FormattedIssueDateTime>                    
<qdt:DateTimeString format="102">20250701</qdt:DateTimeString>  <!-- MDT-100 (Date-heure (Date de facture BT-2)) : 20250701 -->               
</ram:FormattedIssueDateTime>               
<ram:ProcessConditionCode>212</ram:ProcessConditionCode>  <!-- MDT-105 (Code statut traitement) : 212 -->               
<ram:ProcessCondition>Encaissée</ram:ProcessCondition>  <!-- MDT-106 (Libellé statut traitement) : Encaissée -->               
<ram:IssuerTradeParty>                    
<ram:GlobalID schemeID="0002">100000009</ram:GlobalID>  <!-- MDT-129 ( Id émetteur document référencé (global)) : 100000009 -->               
</ram:IssuerTradeParty> 

<ram:SpecifiedDocumentStatus> 

<ram:SpecifiedDocumentCharacteristic>                         
<ram:TypeCode>MEN </ram:TypeCode>  <!-- MDT-207 ( Code du type de donnée) : MEN  -->                         
<ram:ValueChangedIndicator>                              
<udt:IndicatorString>false</udt:IndicatorString>  <!-- MDT-209 ( Indicateur) : false -->                         
</ram:ValueChangedIndicator> 

_Source: `c:\Users\g.baudrit\source\repos\gbaudrit\conf-aimer-votre-llm\demo\ctxc-sample-spec\with-ctxc\spec/afnor/XP_Z12-012/XP_Z12-012_cdar.pdf` (page:5/page:5)_

### E-a91e84078776

  XP Z12-012 - Formats et Profils des messages Factures et Statuts de cycle de vie, constitutifs du socle
minimal applicable à la Réforme Facture Électronique en France.
ANNEXE B (normative) : Exemples de factures (flux 2) et de messages CDAR de cycle de vie
Page 6/25 
<ram:ValueAmount currencyID="EUR">12000</ram:ValueAmount>  <!-- MDT-215 ( Montant (par exemple Encaissé)) : 12000 -->                         
<ram:ValuePercent>20.00</ram:ValuePercent>  <!-- MDT-224 ( Pourcentage (par exemple TVA pour un Encaissée)) : 20.00 -->                    
</ram:SpecifiedDocumentCharacteristic> 

</ram:SpecifiedDocumentStatus> 

</ram:ReferenceReferencedDocument> 

</rsm:AcknowledgementDocument> 

Un point d’attention particulier sur les dates et heures, qui sont multiples :

• La date du statut (MDT-8) : correspond à la date et heure de création du message Cycle de Vie.
• La date de dépôt du statut (MDT-78) : correspond à la date et heure où le statut est créé (par exemple lorsqu’un
statut est posé par un utilisateur dans une application, avant que l’application crée le message CDV qui sera ensuite
transmis).
• La date de réception de l’objet (MDT-95) : correspond à la date et heure de réception de la facture pour celui qui
pose le statut.
ü Pour les statuts posés par l’Émetteur ou sa PA-E : il s’agit de la date et heure du statut « Déposée » ou
« Rejetée » à l’émission (MDT-8 de ces statuts).
ü Pour les statuts posés par le Destinataire ou sa PA-R : il s’agit de la date et heure du statut « Reçue » ou
« Rejetée » (MDT-8 de ces statuts). 
ü Pour une facture et un acteur (émetteur/destinataire du CDV) donnés, ce champ donnera donc toujours la
même date et heure tout au long du cycle de vie.
• La date de l’objet (ici la facture) (MDT-100) : correspond à la date de la facture (BT-2) sur laquelle porte le CDV.

Le bloc « Données à reporter ou valeur attendue (« ram:SpecifiedDocumentCharacteristic ») se gère de la façon suivante :

• MDT-207 (ram:TypeCode) permet d’indiquer de quel type d’utilisation il s’agit : voir BR-FR-CDV-CL-11
• MDT-206 (ram :ID) permet de donner le ID de la donnée en erreur ou à corriger
• MDT-211 (ram:Name) donne le nom de la donnée
• MDT-213 (ram:Location) donne l’Xpath de la donnée
• Et ensuite les données sont proposées par type.

Pour le statut « Encaissée », le code du type de donnée est MEN, (Montant TTC encaissé), le montant est en MDT-215
(ram:ValueAmount) et le taux de TVA est MDT-224 (ram:ValuePercent).

2 Exemples

2.1 Exemples de factures

Les exemples de facture proposés sont les suivants :

• Facture F202500001_INV_20250201 : est une facture qui vise à disposer de la plupart des données possibles dans
une facture. Ceci implique quelques incohérences fonctionnelles (données de virement et de prélèvement par
exemple), mais permet de voir comment chaque donnée se positionne dans les syntaxes.
• Facture UC1_F202500003_00-INV_20250701 : est une facture simple, de service (Cadre de facturation S1), qui sert
de support aux exemples de statuts de Cycle de Vie.
• Facture UC5_F202500007_00-INV_20250702 et l’Avoir qui l’annule UC5b_F202500011_00-CN_20250703 (pour
cause de TVA erronée)
• Facture UC4_F202500006_00-INV_20250701 et Facture rectificative qui l’annule et la remplace
UC4b_F202500010_00-INVCORR_20250702.
• Facture UC12_F202600025_SOUS-LIGNE est une facture avec sous-ligne illustrant la vente d’un livre-jouet.
• Facture UC10_F202600004_MULTI-VENDEUR est une facture Multi-vendeur. 

_Source: `c:\Users\g.baudrit\source\repos\gbaudrit\conf-aimer-votre-llm\demo\ctxc-sample-spec\with-ctxc\spec/afnor/XP_Z12-012/XP_Z12-012_cdar.pdf` (page:6/page:6)_

### E-a2a9f1e61dc1

  XP Z12-012 - Formats et Profils des messages Factures et Statuts de cycle de vie, constitutifs du socle
minimal applicable à la Réforme Facture Électronique en France.
ANNEXE B (normative) : Exemples de factures (flux 2) et de messages CDAR de cycle de vie
Page 7/25 
• Facture UC11_F202600022_MULTI-VENDEUR est une facture multi-vendeur reprenant un exemple de facture de
distribution d’eau.

Les version CII cet UBL commentée ainsi que le lisible Factur-X permettent de voir l’ensemble des données présentes.

Les données de l’exemple F202500001_INV_20250201 sont listées ci-dessous. Comme la BT-46 est de cardinalité 0..1 pour
l’instant dans le profil EN16931, une version en profil EXTENDED-CTC-FR a été produite en CII et UBL pour voir la multiplicité
de la BT-46. 

_Source: `c:\Users\g.baudrit\source\repos\gbaudrit\conf-aimer-votre-llm\demo\ctxc-sample-spec\with-ctxc\spec/afnor/XP_Z12-012/XP_Z12-012_cdar.pdf` (page:7/page:7)_

### E-155179deb772

  XP Z12-012 - Formats et Profils des messages Factures et Statuts de cycle de vie, constitutifs du socle
minimal applicable à la Réforme Facture Électronique en France.
ANNEXE B (normative) : Exemples de factures (flux 2) et de messages CDAR de cycle de vie
Page 8/25 
BT Désignation Donnée Ligne 2 Ligne 3 Ligne 4

BT-1 Numéro de facture F202500001   

BT-2 Date d'émission facture
initiale / facture rectificative 01/02/2025   

BT-3 Code de type de facture 380   

BT-5 Code de devise de la facture EUR   

BT-6 Code de devise de
comptabilisation de la TVA    

BT-7 Date d'exigibilité de la taxe sur
la valeur ajoutée    

BT-8 Code de date d'exigibilité de la
taxe sur la valeur ajoutée 5   

BT-9 Date d'échéance / Date de
versement en cas d'acompte 45719   

BT-10 Référence de l'acheteur SERVEXEC   

BT-11 Référence de projet PROJET_2547   

BT-12 Référence du contrat CT2018120802   

BT-13 Référence du bon de
commande PO201925478   

BT-14 Numéro d’ordre de vente BON VENTE REF 2547   

BT-15 Référence d'avis de réception BON_RECEPT_002   

BT-16 Référence d'avis d'expédition AVISLIVRAISON_007654   

BT-17 Référence de l'appel d'offres
ou du lot APPEL_OFFRE-FRE0087   

BT-18 Identifiant d'objet facturé REF_CLIENT2514   

BT-18-1 Identifiant du schéma IT   

BT-19 Référence comptable de
l'acheteur REF COMPTABLE ACHETEUR   

BT-20 Conditions de paiement PAIEMENT 30 JOURS NET   

BG-1 NOTE DE FACTURE     

_Source: `c:\Users\g.baudrit\source\repos\gbaudrit\conf-aimer-votre-llm\demo\ctxc-sample-spec\with-ctxc\spec/afnor/XP_Z12-012/XP_Z12-012_cdar.pdf` (page:8/page:8)_

### E-38ecf8bc3f77

  XP Z12-012 - Formats et Profils des messages Factures et Statuts de cycle de vie, constitutifs du socle
minimal applicable à la Réforme Facture Électronique en France.
ANNEXE B (normative) : Exemples de factures (flux 2) et de messages CDAR de cycle de vie
Page 9/25 
BT-21 Code du sujet de la note de
facture REG   

BT-22 Note de facture VENDEUR SARL au capital de
50 000 EUR   

BT-21 Code du sujet de la note de
facture ABL   

BT-22 Note de facture RCS MAVILLE 100 000 009   

BT-21 Code du sujet de la note de
facture AAI   

BT-22 Note de facture
35 ma rue a moi,75018 PARIS,
FR – contact@vendeur.fr -
www.levendeur.fr  – N° TVA :
FR88 100 000 009   

BT-21 Code du sujet de la note de
facture PMD   

BT-22 Note de facture
Tout retard de paiement
engendre une pénalité
exigible à compter de la date
d'échéance, calculée sur la
base de trois fois le taux
d'intérêt légal. 

BT-21 Code du sujet de la note de
facture PMT   

BT-22 Note de facture
Indemnité forfaitaire pour
frais de recouvrement en cas
de retard de paiement : 40 €.   

BT-21 Code du sujet de la note de
facture AAB   

BT-22 Note de facture
Les réglements reçus avant la
date d'échéance ne
donneront pas lieu à
escompte.   

BT-21 Code du sujet de la note de
facture TXD   

BT-22 Note de facture MEMBRE_ASSUJETTI_UNIQUE   

BG-2 CONTROLE DU PROCESSUS    

BT-23 Type de processus métier
(cadre de facturation) B1   

BT-24 Type de profil (e-invoicing, e-
reporting, facture etc..) urn:cen.eu:en16931:2017   

BG-3 RÉFÉRENCE À UNE FACTURE
ANTÉRIEURE    

BT-25 Référence à une facture
antérieure    

BT-26 Date d'émission de facture
antérieure     

_Source: `c:\Users\g.baudrit\source\repos\gbaudrit\conf-aimer-votre-llm\demo\ctxc-sample-spec\with-ctxc\spec/afnor/XP_Z12-012/XP_Z12-012_cdar.pdf` (page:9/page:9)_

### E-e8f03c3b2ec7

  XP Z12-012 - Formats et Profils des messages Factures et Statuts de cycle de vie, constitutifs du socle
minimal applicable à la Réforme Facture Électronique en France.
ANNEXE B (normative) : Exemples de factures (flux 2) et de messages CDAR de cycle de vie
Page 10/25 
BG-4 VENDEUR    

BT-27 Raison sociale du vendeur LE VENDEUR   

BT-28 Appellation commerciale du
vendeur
VENDEUR NOM
COMMERCIAL   

BT-29 Identifiant privé du vendeur PRIVATE_123   

BT-29 Identifiant du schéma 587451236587   

BT-29-1 Identifiant du schéma 0088   

BT-29b Identifiant du vendeur (SIRET) 10000000900017   

BT-29b-1 Identifiant du schéma (SIRET) 0009   

BT-29c Identifiant du vendeur
(routage) DUNS1235487   

BT-29c-1 Identifiant du schéma
(routage) 0060   

BT-29d Identifiant du vendeur
(Assujetti unique) 500000005   

BT-29d-1 Identifiant du schéma
(Assujetti unique) 0231   

BT-30 Numéro de SIREN 100000009   

BT-30-1 Identifiant du schéma 0002   

BT-31 Identifiant à la TVA du
vendeur FR88100000009   

BT-31-0 Qualifiant d'Identifiant à la
TVA du Vendeur    

BT-32 Identifiant fiscal du vendeur    

BT-32-0 Qualifiant d'Identifiant fiscal
du Vendeur    

BT-33 Forme juridique et capital
social pour les sociétés
SARL AU CAPITAL DE 50 000
EUROS   

BT-34 Adresse électronique du
vendeur 100000009_STATUTS   

BT-34-1 Identifiant du schéma 0225   

BG-5 ADRESSE POSTALE DU
VENDEUR     

_Source: `c:\Users\g.baudrit\source\repos\gbaudrit\conf-aimer-votre-llm\demo\ctxc-sample-spec\with-ctxc\spec/afnor/XP_Z12-012/XP_Z12-012_cdar.pdf` (page:10/page:10)_

### E-af5347699cb5

  XP Z12-012 - Formats et Profils des messages Factures et Statuts de cycle de vie, constitutifs du socle
minimal applicable à la Réforme Facture Électronique en France.
ANNEXE B (normative) : Exemples de factures (flux 2) et de messages CDAR de cycle de vie
Page 11/25 
BT-35 Adresse du vendeur - Ligne 1 35 rue d'ici   

BT-36 Adresse du vendeur - Ligne 2 ligne 2 vendeur   

BT-162 Adresse du vendeur - Ligne 3    

BT-37 Localité du vendeur PARIS   

BT-38 Code postal du vendeur 75018   

BT-39 Subdivision du pays du
vendeur    

BT-40 Code de pays du vendeur FR   

BG-6 CONTACT DU VENDEUR    

BT-41 Point de contact du vendeur MME CONTACT   

BT-42 Numéro de téléphone du
contact du vendeur 01 02 03 54 87   

BT-43 Adresse électronique du
contact du vendeur contact@vendeur.fr   

BG-7 ACHETEUR    

BT-44 Raison sociale de l'acheteur LE CLIENT   

BT-45 Appellation commerciale de
l'acheteur CLIENT NOM COMMERCIAL   

BT-46 Identifiant complémentaire de
l'acheteur privateID   

BT-46 Identifiant complémentaire de
l'acheteur 3654789851   

BT-46-1 Identifiant du schéma 0088   

BT-46b
Identifiant de l'acheteur
(SIRET)
PROFIL EXTENDED
20000000800025   

BT-46b-1 Identifiant du schéma (SIRET)
PROFIL EXTENDED 0009   

BT-46c
Identifiant de l'acheteur
(routage)
PROFIL EXTENDED
CDROUT1   

BT-46c-1
Identifiant du schéma
(routage) 
PROFIL EXTENDED
0224    

_Source: `c:\Users\g.baudrit\source\repos\gbaudrit\conf-aimer-votre-llm\demo\ctxc-sample-spec\with-ctxc\spec/afnor/XP_Z12-012/XP_Z12-012_cdar.pdf` (page:11/page:11)_

### E-f238fb371aef

  XP Z12-012 - Formats et Profils des messages Factures et Statuts de cycle de vie, constitutifs du socle
minimal applicable à la Réforme Facture Électronique en France.
ANNEXE B (normative) : Exemples de factures (flux 2) et de messages CDAR de cycle de vie
Page 12/25 
BT-47 Numéro de SIREN 200000008   

BT-47-1 Identifiant du schéma 0002   

BT-48 Identifiant à la TVA  de
l'acheteur FR37200000008   

BT-48-0 Qualifiant d'Identifiant fiscal
de l'acheteur    

BT-49 Identifiant d'adressage 200000008   

BT-49-1 Identifiant du schéma de
l'identifiant d'adressage 0225   

BG-8 ADRESSE POSTALE DE
L'ACHETEUR    

BT-50 Adresse de l'acheteur - Ligne 1 MON ADRESSE LIGNE 1   

BT-51 Adresse de l'acheteur - Ligne 2 acheteur ligne 2   

BT-163 Adresse de l'acheteur - Ligne 3 acheteur ligne 3   

BT-52 Localité de l'acheteur MA VILLE   

BT-53 Code postal de l'acheteur 06000   

BT-54 Subdivision du pays de
l'acheteur    

BT-55 Code de pays de l'acheteur FR   

BG-9 CONTACT DE L’ACHETEUR    

BT-56 Point de contact de l’acheteur Contact ACHETEUR   

BT-57 Numéro de téléphone du
contact de l’acheteur 01 01 25 45 87   

BT-58 Adresse électronique du
contact de l’acheteur contact@acheteur.fr   

BG-10 BÉNÉFICIAIRE    

BT-59 Nom du bénéficiaire TIERS Bénéficiaire   

BT-60 Identifiant du complémentaire
du bénéficiaire    

BT-60-1 Identifiant du schéma 0088    

_Source: `c:\Users\g.baudrit\source\repos\gbaudrit\conf-aimer-votre-llm\demo\ctxc-sample-spec\with-ctxc\spec/afnor/XP_Z12-012/XP_Z12-012_cdar.pdf` (page:12/page:12)_

### E-2af243255709

  XP Z12-012 - Formats et Profils des messages Factures et Statuts de cycle de vie, constitutifs du socle
minimal applicable à la Réforme Facture Électronique en France.
ANNEXE B (normative) : Exemples de factures (flux 2) et de messages CDAR de cycle de vie
Page 13/25 
BT-61 Identifiant d’enregistrement
légal du bénéficiaire 300000007   

BT-61-1 Identifiant du schéma 0002   

BG-11 REPRÉSENTANT FISCAL DU
VENDEUR    

BT-62 Nom du représentant fiscal du
vendeur ASSUJETTI UNIQUE VENDEUR   

BT-63 Identifiant à la TVA du
représentant fiscal du vendeur FR78500000005   

BT-63-1
Identifiant du schéma de
l'identifiant TVA du
représentant fiscal 

BG-12
ADRESSE POSTALE DU
REPRÉSENTANT FISCAL DU
VENDEUR    

BT-64 Adresse du représentant fiscal
- Ligne 1 75 rue labas   

BT-65 Adresse du représentant fiscal
- Ligne 2 Assujetti Unique ligne 2   

BT-164 Adresse du représentant fiscal
- Ligne 3    

BT-66 Localité du représentant fiscal PARIS   

BT-67 Code postal du représentant
fiscal 75007   

BT-68 Subdivision du pays du
représentant fiscal    

BT-69 Code de pays du représentant
fiscal FR   

BG-13 INFORMATIONS DE LIVRAISON    

BT-70 Livré à NOM LIVRé   

BT-71 Identifiant de l'établissement
de livraison PRIVATE_ID_DELIVERY   

BT-71-1 Identifiant du schéma de
l'établissement de livraison    

BT-72 Date effective de livraison 31/01/2025   

BG-14 PERIODE DE FACTURATION    

BT-73 Date de début de période de
facturation 01/01/2025   

BT-74 Date de fin de période de
facturation 31/01/2025    

_Source: `c:\Users\g.baudrit\source\repos\gbaudrit\conf-aimer-votre-llm\demo\ctxc-sample-spec\with-ctxc\spec/afnor/XP_Z12-012/XP_Z12-012_cdar.pdf` (page:13/page:13)_

### E-c0bfe9c7905b

  XP Z12-012 - Formats et Profils des messages Factures et Statuts de cycle de vie, constitutifs du socle
minimal applicable à la Réforme Facture Électronique en France.
ANNEXE B (normative) : Exemples de factures (flux 2) et de messages CDAR de cycle de vie
Page 14/25 
BG-15 ADRESSE DE LIVRAISON    

BT-75 Adresse de livraison  - Ligne 1 ADRESSE LIVRAISON LIGNE 1   

BT-76 Adresse de livraison - Ligne 2 AD LIV ligne 2   

BT-165 Adresse de livraison - Ligne 3    

BT-77 Localité Adresse de livraison NICE   

BT-78 Code postal Adresse de
livraison 06000   

BT-79 Subdivision du pays     

BT-80 Code de pays FR   

BG-16 INSTRUCTIONS DE PAIEMENT    

BT-81 Code de type de moyen de
paiement 30   

BT-82 Libellé du moyen de paiement Virement   

BT-83 Avis de paiement F202500001_200000008   

BG-17 VIREMENT    

BT-84 Identifiant de compte de
paiement
FR20 1254 2547 2569 8542
5874 698   

BT-85 Nom de compte de paiement MON COMPTE BANCAIRE   

BT-86 Identifiant de prestataire de
services de paiement BIC_MONCOMPTE   

BG-18 INFORMATIONS CONCERNANT
LA CARTE DE PAIEMENT    

BT-87 Identifiant de compte de
paiement    

BT-88 Nom de compte de paiement    

BG-19 PRÉLÈVEMENT    

BT-89 Identifiant de référence de
mandat REF MANDAT ICS   

BT-90 Identifiant bancaire du
créancier     

_Source: `c:\Users\g.baudrit\source\repos\gbaudrit\conf-aimer-votre-llm\demo\ctxc-sample-spec\with-ctxc\spec/afnor/XP_Z12-012/XP_Z12-012_cdar.pdf` (page:14/page:14)_

### E-092c7256c4c9

  XP Z12-012 - Formats et Profils des messages Factures et Statuts de cycle de vie, constitutifs du socle
minimal applicable à la Réforme Facture Électronique en France.
ANNEXE B (normative) : Exemples de factures (flux 2) et de messages CDAR de cycle de vie
Page 15/25 
BT-91 Identifiant de compte débité
(IBAN) CPTE DEBIT   

BG-20 REMISES AU NIVEAU DU
DOCUMENT    

BT-92 Montant de la remise au
niveau document 5   

BT-93 Assiette de la remise au
niveau du document 100   

BT-94 Pourcentage de remise au
niveau du document 5   

BT-95
Code de type de TVA de la
remise au niveau du
document
S   

BT-96 Taux de TVA de la remise au
niveau du document 20   

BT-97 Motif de la remise au niveau
du document REMISE COMMERCIALE_1   

BT-98 Code de motif de la remise au
niveau du document 95   

BG-20 REMISES AU NIVEAU DU
DOCUMENT -2ème    

BT-92 Montant de la remise au
niveau document 1   

BT-93 Assiette de la remise au
niveau du document 100   

BT-94 Pourcentage de remise au
niveau du document 1   

BT-95
Code de type de TVA de la
remise au niveau du
document
S   

BT-96 Taux de TVA de la remise au
niveau du document 20   

BT-97 Motif de la remise au niveau
du document REMISE COMMERCIALE_2   

BT-98 Code de motif de la remise au
niveau du document 100   

BG-20 REMISES AU NIVEAU DU
DOCUMENT 3ème    

BT-92 Montant de la remise au
niveau document 1   

BT-93 Assiette de la remise au
niveau du document 100   

BT-94 Pourcentage de remise au
niveau du document 1   

BT-95
Code de type de TVA de la
remise au niveau du
document
S    

_Source: `c:\Users\g.baudrit\source\repos\gbaudrit\conf-aimer-votre-llm\demo\ctxc-sample-spec\with-ctxc\spec/afnor/XP_Z12-012/XP_Z12-012_cdar.pdf` (page:15/page:15)_

### E-cd60817df995

  XP Z12-012 - Formats et Profils des messages Factures et Statuts de cycle de vie, constitutifs du socle
minimal applicable à la Réforme Facture Électronique en France.
ANNEXE B (normative) : Exemples de factures (flux 2) et de messages CDAR de cycle de vie
Page 16/25 
BT-96 Taux de TVA de la remise au
niveau du document 20   

BT-97 Motif de la remise au niveau
du document REMISE COMMERCIALE_3   

BT-98 Code de motif de la remise au
niveau du document 100   

BG-20 REMISES AU NIVEAU DU
DOCUMENT 4ème    

BT-92 Montant de la remise au
niveau document 2   

BT-93 Assiette de la remise au
niveau du document 100   

BT-94 Pourcentage de remise au
niveau du document 2   

BT-95
Code de type de TVA de la
remise au niveau du
document
S   

BT-96 Taux de TVA de la remise au
niveau du document 10   

BT-97 Motif de la remise au niveau
du document REMISE COMMERCIALE_4   

BT-98 Code de motif de la remise au
niveau du document    

BG-21 CHARGES OU FRAIS AU
NIVEAU DU DOCUMENT    

BT-99 Montant des charges 10   

BT-100 Assiette des charges ou frais
au niveau du document 100   

BT-101 Pourcentage de charges ou
frais au niveau du document 10   

BT-102 Code de type de TVA des
charges S   

BT-103 Taux de TVA des charges ou
frais au niveau du document 20   

BT-104 Motif des charges ou frais au
niveau du document FRAIS DEPLACEMENT_1   

BT-105 Code de motif des charges ou
frais au niveau du document FC   

BG-21 CHARGES OU FRAIS AU
NIVEAU DU DOCUMENT 2ème    

BT-99 Montant des charges 1   

BT-100 Assiette des charges ou frais
au niveau du document 100    

_Source: `c:\Users\g.baudrit\source\repos\gbaudrit\conf-aimer-votre-llm\demo\ctxc-sample-spec\with-ctxc\spec/afnor/XP_Z12-012/XP_Z12-012_cdar.pdf` (page:16/page:16)_

### E-f037473cd2c6

  XP Z12-012 - Formats et Profils des messages Factures et Statuts de cycle de vie, constitutifs du socle
minimal applicable à la Réforme Facture Électronique en France.
ANNEXE B (normative) : Exemples de factures (flux 2) et de messages CDAR de cycle de vie
Page 17/25 
BT-101 Pourcentage de charges ou
frais au niveau du document 1   

BT-102 Code de type de TVA des
charges S   

BT-103 Taux de TVA des charges ou
frais au niveau du document 20   

BT-104 Motif des charges ou frais au
niveau du document AUTRE CHARGE   

BT-105 Code de motif des charges ou
frais au niveau du document ADR   

BG-21 CHARGES OU FRAIS AU
NIVEAU DU DOCUMENT 3ème    

BT-99 Montant des charges 2   

BT-100 Assiette des charges ou frais
au niveau du document    

BT-101 Pourcentage de charges ou
frais au niveau du document    

BT-102 Code de type de TVA des
charges K   

BT-103 Taux de TVA des charges ou
frais au niveau du document 0   

BT-104 Motif des charges ou frais au
niveau du document FRAIS DEPLACEMENT_2   

BT-105 Code de motif des charges ou
frais au niveau du document FC   

BG-21 CHARGES OU FRAIS AU
NIVEAU DU DOCUMENT 4ème    

BT-99 Montant des charges 1   

BT-100 Assiette des charges ou frais
au niveau du document    

BT-101 Pourcentage de charges ou
frais au niveau du document    

BT-102 Code de type de TVA des
charges S   

BT-103 Taux de TVA des charges ou
frais au niveau du document 10   

BT-104 Motif des charges ou frais au
niveau du document FRAIS DEPLACEMENT_3   

BT-105 Code de motif des charges ou
frais au niveau du document FC   

BG-22 TOTAUX DU DOCUMENT     

_Source: `c:\Users\g.baudrit\source\repos\gbaudrit\conf-aimer-votre-llm\demo\ctxc-sample-spec\with-ctxc\spec/afnor/XP_Z12-012/XP_Z12-012_cdar.pdf` (page:17/page:17)_

### E-cde968b19a15

  XP Z12-012 - Formats et Profils des messages Factures et Statuts de cycle de vie, constitutifs du socle
minimal applicable à la Réforme Facture Électronique en France.
ANNEXE B (normative) : Exemples de factures (flux 2) et de messages CDAR de cycle de vie
Page 18/25 
BT-106 Somme des montants nets des
lignes de facture 105   

BT-107 Somme des remises au niveau
du document 9   

BT-108 Somme des charges ou frais
au niveau du document 14   

BT-109 Montant total de la facture
hors TVA 110   

BT-110 Montant total de TVA de la
facture 8,7   

BT-110-1 Code devise    

BT-111
Montant total de TVA de la
facture exprimée (devise de
comptabilisation)    

BT-111-1 Code devise    

BT-112 Montant total de la Facture,
avec la TVA. 118,7   

BT-113 Montant payé 0   

BT-114 Montant arrondi 0   

BT-115 Montant à payer 118,7   

BG-23 VENTILATION DE LA TVA    

BT-116 Base d'imposition du type de
TVA 39   

BT-117 Montant de la TVA pour
chaque type de TVA 7,8   

BT-118 Code de type de TVA S   

BT-119 Taux de type de TVA 20   

BT-120 Motif d'exonération de la TVA    

BT-121 Code de motif d'exonération
de la TVA    

BG-23 VENTILATION DE LA TVA 2ème    

BT-116 Base d'imposition du type de
TVA 60   

BT-117 Montant de la TVA pour
chaque type de TVA 0    

_Source: `c:\Users\g.baudrit\source\repos\gbaudrit\conf-aimer-votre-llm\demo\ctxc-sample-spec\with-ctxc\spec/afnor/XP_Z12-012/XP_Z12-012_cdar.pdf` (page:18/page:18)_

### E-1d661d2d0fe0

  XP Z12-012 - Formats et Profils des messages Factures et Statuts de cycle de vie, constitutifs du socle
minimal applicable à la Réforme Facture Électronique en France.
ANNEXE B (normative) : Exemples de factures (flux 2) et de messages CDAR de cycle de vie
Page 19/25 
BT-118 Code de type de TVA E   

BT-119 Taux de type de TVA 0   

BT-120 Motif d'exonération de la TVA REMBOURSEMENT   

BT-121 Code de motif d'exonération
de la TVA VATEX-EU-79-C   

BG-23 VENTILATION DE LA TVA 3ème    

BT-116 Base d'imposition du type de
TVA    

BT-117 Montant de la TVA pour
chaque type de TVA 0,9   

BT-118 Code de type de TVA S   

BT-119 Taux de type de TVA 10   

BT-120 Motif d'exonération de la TVA    

BT-121 Code de motif d'exonération
de la TVA    

BG-23 VENTILATION DE LA TVA 4ème    

BT-116 Base d'imposition du type de
TVA 2   

BT-117 Montant de la TVA pour
chaque type de TVA 0   

BT-118 Code de type de TVA K   

BT-119 Taux de type de TVA 0   

BT-120 Motif d'exonération de la TVA LIVRAISON
INTRACOMMUNAUTAIRE   

BT-121 Code de motif d'exonération
de la TVA VATEX-EU-IC   

BG-24 DOCUMENTS JUSTIFICATIFS
ADDITIONNELS    

BT-122 Référence de document
justificatif REF_ANNEXE_009875   

BT-123 Description de document
justificatif DOCUMENT_ANNEXE   

BT-124 Emplacement de document
externe url:gffter    

_Source: `c:\Users\g.baudrit\source\repos\gbaudrit\conf-aimer-votre-llm\demo\ctxc-sample-spec\with-ctxc\spec/afnor/XP_Z12-012/XP_Z12-012_cdar.pdf` (page:19/page:19)_

### E-b79575cab2ab

  XP Z12-012 - Formats et Profils des messages Factures et Statuts de cycle de vie, constitutifs du socle
minimal applicable à la Réforme Facture Électronique en France.
ANNEXE B (normative) : Exemples de factures (flux 2) et de messages CDAR de cycle de vie
Page 20/25 
BT-125 Document joint    

BT-125-1 Code MIME du document joint    

BT-125-2 Nom de fichier du document
joint    

BG-25 LIGNE DE FACTURE        

BT-126 Identifiant de ligne de facture 1 2 3 4

BT-127-
00 Note de ligne de facture    

BT-127 Note de ligne de facture  DONT 0,50 EUR de DEEE  

BT-128 Identifiant d'objet de ligne de
facture  TARIF_2022  

BT-128-1 Identifiant du schéma  AFG  

BT-129 Quantité facturée 1 30 1 2

BT-130 Code de l'unité de mesure de
la quantité facturée C62 C62 C62 HUR

BT-131 Montant net de ligne de
facture 60 21 10 14

BT-132 Référence de ligne de bon de
commande référencée 1 4 3 2

BT-133
Référence comptable de
l'acheteur de la ligne de
facture
BUY_ACC_REF BUY_ACC_REF1 BUY_ACC_REF2 BUY_ACC_REF3

BG-26 PERIODE DE FACTURATION
D'UNE LIGNE    

BT-134 Date de début de période de
facturation d'une ligne 01/01/2025 01/01/2025 01/01/2025 01/01/2025

BT-135 Date de fin de période de
facturation d'une ligne 31/01/2025 31/01/2025 31/01/2025 31/01/2025

BG-27 REMISE DE LIGNE DE FACTURE    

BT-136 Montant d'une remise, hors
TVA  1  

BT-137 Assiette de la remise de ligne
de facture  100  

BT-138 Pourcentage de remise de
ligne de facture  1  

BT-139 Motif de la remise de ligne de
facture  REMISE VOLUME   

_Source: `c:\Users\g.baudrit\source\repos\gbaudrit\conf-aimer-votre-llm\demo\ctxc-sample-spec\with-ctxc\spec/afnor/XP_Z12-012/XP_Z12-012_cdar.pdf` (page:20/page:20)_

### E-cd63199b3acb

  XP Z12-012 - Formats et Profils des messages Factures et Statuts de cycle de vie, constitutifs du socle
minimal applicable à la Réforme Facture Électronique en France.
ANNEXE B (normative) : Exemples de factures (flux 2) et de messages CDAR de cycle de vie
Page 21/25 
BT-140 Code de motif de la remise de
ligne de facture  71  

BG-28 CHARGE OU FRAIS D'UNE
LIGNE DE FACTURE    

BT-141 Montant des charges ou frais  1  

BT-142
Assiette des charges ou frais
applicables à la ligne de
facture    

BT-143
Pourcentage de charges ou
frais applicable à la ligne de
facture    

BT-144
Motif des charges ou frais
applicables à la ligne de
facture 
FRAIS PREPARATION  

BT-145
Code de motif des charges ou
frais applicables à la ligne de
facture    

BG-29 DÉTAIL DU PRIX    

BT-146 Prix net de l'article 60 0,7 30 7

BT-147 Rabais sur le prix de l'article  0,1  3

BT-148 Prix brut de l'article 60 0,8 30 10

BT-149 Quantité de base du prix de
l'article 1 1 3 1

BT-150
Code de l'unité de mesure de
la quantité de base du prix de
l'article
C62 C62 C62 HUR

BG-30 INFORMATION SUR LA TVA    

BT-151 Code de type de TVA de
l'article facturé E S S S

BT-152 Taux de TVA de l'article
facturé 0 20 10 20

BG-31 INFORMATION SUR L'ARTICLE    

BT-153 Nom de l'article REMBOURSEMENT COMPOSANT FOURNITURES MOULE SUPPORT TEL

BT-154 Description de l'article Description du
remboursement Description de l'article Description du moule
Description de la
prestation de support
associée

BT-155 Identifiant vendeur de l'article  ART_1254 ART_9874 

BT-156 Identifiant acheteur de l'article  REF5487 REF9854  

_Source: `c:\Users\g.baudrit\source\repos\gbaudrit\conf-aimer-votre-llm\demo\ctxc-sample-spec\with-ctxc\spec/afnor/XP_Z12-012/XP_Z12-012_cdar.pdf` (page:21/page:21)_

### E-8d7e0916bf58

  XP Z12-012 - Formats et Profils des messages Factures et Statuts de cycle de vie, constitutifs du socle
minimal applicable à la Réforme Facture Électronique en France.
ANNEXE B (normative) : Exemples de factures (flux 2) et de messages CDAR de cycle de vie
Page 22/25 
BT-157 Identifiant standard de l'article  598785412598745 598785414325437 

BT-157-1 Identifiant du schéma  0160 0160 

BT-158 Identifiant de la classification
de l'article  SKU2578  

BT-158-1 Identifiant du schéma  SK  

BT-158-2 Identifiant version du schéma    

BT-159 Pays d'origine de l'article  FR  

BG-32 ATTRIBUTS D'ARTICLE    

BT-160 Nom d'attribut d'article  CO2(g) COULEUR 

BT-161 Valeur d'attribut d'article  12 BLANC 

BT-160 Nom d'attribut d'article   CO2(g) 

BT-161 Valeur d'attribut d'article   30  

_Source: `c:\Users\g.baudrit\source\repos\gbaudrit\conf-aimer-votre-llm\demo\ctxc-sample-spec\with-ctxc\spec/afnor/XP_Z12-012/XP_Z12-012_cdar.pdf` (page:22/page:22)_

### E-dc531e4ef767

  XP Z12-012 - Formats et Profils des messages Factures et Statuts de cycle de vie, constitutifs du socle
minimal applicable à la Réforme Facture Électronique en France.
ANNEXE B (normative) : Exemples de factures (flux 2) et de messages CDAR de cycle de vie
Page 23/25 
2.2 Exemples de messages CDV en CDAR

2.2.1 Cas Nominal

Le cas proposé est basé sur une facture échangée sans Rejet, refus, litige.

Les données principales de la facture sont les suivantes :

Caractéristique Remplissage

Nom des fichiers de facture (3 formats) Factur-X : UC1_F202500003_00-INV_20250701.pdf
CII : UC1_F202500003_00-INV_20250701_CII.xml
UBL : UC1_F202500003_00-INV_20250701_UBL.xml

Identifiant de facture F202500003

Date 01/07/2025

Type Facture e-invoicing (code type : 380)

Nom Vendeur LE VENDEUR

ID légal du Vendeur 100000009

Adresse électronique Vendeur (schemeId 0225) 100000009_STATUTS

Nom Acheteur LE CLIENT

ID légal de l’Acheteur 200000008

Adresse électronique Acheteur (schemeId 0225) 200000008

Nombre de lignes 2

Taux TVA (%) 20

Prix unitaire ligne 1 (€) 40,00

Unité pour P.U. ligne 1 HEURE

Quantité ligne 1 200

Prix unitaire ligne 2 (€) 400

Unité pour P.U. ligne 2 JOUR

Quantité ligne 2 5

Total HT ligne 1 (€) 8 000

Total HT ligne 2 (€) 2 000

Total document HT (€) 10 000

Total TVA (€) 2 000

Total document TTC (€) 12 000  

_Source: `c:\Users\g.baudrit\source\repos\gbaudrit\conf-aimer-votre-llm\demo\ctxc-sample-spec\with-ctxc\spec/afnor/XP_Z12-012/XP_Z12-012_cdar.pdf` (page:23/page:23)_

### E-0674475d79fb

  XP Z12-012 - Formats et Profils des messages Factures et Statuts de cycle de vie, constitutifs du socle
minimal applicable à la Réforme Facture Électronique en France.
ANNEXE B (normative) : Exemples de factures (flux 2) et de messages CDAR de cycle de vie
Page 24/25 
La cinématique du cycle de vie est la suivante :

Étape DATE Heure Évènement

UC1_00 01/07/2025 15:00:00 Le VENDEUR transmet sa facture à PA-E du Vendeur

UC1_01
01/07/2025 15:10:00 PA-E fait les contrôles et pose statut Déposée

01/07/2025 15:15:00 PA-E constitue le CDV « Déposée ». Statut disponible pour LE VENDEUR.
Transmission sous 24h au PPF.

01/07/2025 16:00:00 PA-E transmet la facture (flux 2) à PA-R

UC1_02
01/07/2025 16:10:00 PA-R fait les contrôles et pose statut Reçue

01/07/2025 16:15:00 PA-R Constitue CDV Reçue pour le VENDEUR et le transmet à PA-E. Statut mis à
disposition de l’ACHETEUR

01/07/2025 16:20:00 PA-R transmet la facture à l’ACHETEUR ou lui notifie sa disponibilité

UC1_03
01/07/2025 16:25:00 PA-R pose Statut MAD (Mise à Disposition), pour l’ACHETEUR

01/07/2025 16:30:00 PA-R Constitue CDV MAD pour le VENDEUR et le transmet à PA-E. Statut mis à
disposition de l’ACHETEUR

01/07/2025 16:40:00 PA-E met à disposition le statut MAD pour le VENDEUR

UC1_04
01/07/2025 18:00:00 L’ACHETEUR pose un statut PEC (Prise en Charge)

01/07/2025 18:10:00 PA-R (ou ACHETEUR) constitue le statut PEC et le transmet au VENDEUR via sa
PA-E

01/07/2025 18:15:00 PA-E met à disposition le statut PEC pour le VENDEUR

UC1_05
02/07/2025 10:00:00 L’ACHETEUR pose un statut « Approuvée »

02/07/2025 10:05:00 PA-R (ou ACHETEUR) constitue le statut Approuvée et le transmet à VE via sa
PA-E

02/07/2025 10:10:00 PA-E met à disposition le statut Approuvée au VENDEUR

UC1_06
30/07/2025 10:00:00 ACHETEUR pose un statut Paiement transmis

30/07/2025 10:05:00 PA-R (ou ACHETEUR) constitue le statut Paiement transmis et le transmet à VE
via sa PA-E

30/07/2025 10:10:00 PA-E met à disposition le statut Paiement transmis au VENDEUR

UC1_07
02/08/2025 10:00:00 VENDEUR pose un statut « Encaissée »

02/08/2025 10:05:00 PA-E (ou VE) constitue le statut Encaissée et le transmet à l’ACHETEUR via sa
PA-R
Transmission au PPF.

02/08/2025 10:10:00 PA-R met à disposition le statut « Encaissée » à l’ACHETEUR. 

_Source: `c:\Users\g.baudrit\source\repos\gbaudrit\conf-aimer-votre-llm\demo\ctxc-sample-spec\with-ctxc\spec/afnor/XP_Z12-012/XP_Z12-012_cdar.pdf` (page:24/page:24)_

### E-abd5631f4215

  XP Z12-012 - Formats et Profils des messages Factures et Statuts de cycle de vie, constitutifs du socle
minimal applicable à la Réforme Facture Électronique en France.
ANNEXE B (normative) : Exemples de factures (flux 2) et de messages CDAR de cycle de vie
Page 25/25 
Les fichiers des différents statuts de cycle de vie sont les suivants (et contiennent des commentaires pour identifier les codes
des données MDT-XXX) :

Statut Nom du fichier XML

Déposée UC1_F202500003_01-CDV-200_Déposé

UC1_F202500003_01-CDV-200_Déposée_POUR_PPF

Reçue UC1_F202500003_02-CDV-202_Reçue

Mise à disposition  UC1_F202500003_03-CDV-203_Mise_à_disposition

Prise en charge UC1_F202500003_04-CDV-204_Prise_en_charge

Approuvée UC1_F202500003_05-CDV-205_Approuvée

Paiement transmis UC1_F202500003_06-CDV-211_Paiement_transmis

12 000 € le 30/07/2025

Encaissée UC1_F202500003_07-CDV-212_Encaissée

UC1_F202500003_07-CDV-212_Encaissée_POUR_PPF 

2.2.2 Cas d’une facture en erreur pour illustrer un statut de litige

Pour les factures UC4_F202500006_00-INV_20250701 et UC5_F202500007_00-INV_20250702 qui sont semblables, les
statuts de mise en litige permettent d’illustrer comment indiquer un litige, avec un MOTIF (en MDT-113 en code et MDT-
114 en texte, ici Taux de TVA erroné), puis comment indiquer une action attendue (facture rectificative ou Avoir) en MDT-
121 et MDT-122, et enfin comment indiquer une donnée invalide et celle qui est attendue à la place :

• UC4_F202500006_04-CDV-207_En_litige.xml
• UC5_F202500007_04-CDV-207_En_litige.xml 

_Source: `c:\Users\g.baudrit\source\repos\gbaudrit\conf-aimer-votre-llm\demo\ctxc-sample-spec\with-ctxc\spec/afnor/XP_Z12-012/XP_Z12-012_cdar.pdf` (page:25/page:25)_

### E-d276abeaa42a

{
  "headerRowIndices": [
    0,
    1
  ],
  "rows": [
    [
      "Cardinalit\u00E9  CDAR",
      "Chemin",
      "ID",
      "Level",
      "N2",
      "N3",
      "N4",
      "N5"
    ],
    [
      "0..1",
      "/rsm:ExchangedDocument/ram:TypeCode",
      "MDT-6",
      "2",
      "Code type document",
      "",
      "",
      ""
    ],
    [
      "0..1",
      "/rsm:ExchangedDocument/ram:StatusCode",
      "MDT-7",
      "2",
      "Code statut",
      "",
      "",
      ""
    ],
    [
      "0..1",
      "/rsm:ExchangedDocument/ram:VersionID",
      "MDT-10",
      "2",
      "Version document",
      "",
      "",
      ""
    ],
    [
      "0..1",
      "/rsm:ExchangedDocument/ram:GlobalID",
      "MDT-11",
      "2",
      "Id document (global)",
      "",
      "",
      ""
    ],
    [
      "1..1",
      "/rsm:ExchangedDocument/ram:GlobalID/@schemeID",
      "MDT-11-1",
      "3",
      "",
      "Attribut Type Id",
      "",
      ""
    ],
    [
      "0..n",
      "/rsm:ExchangedDocument/ram:IncludedNote",
      "MDG-5",
      "2",
      "Note",
      "",
      "",
      ""
    ],
    [
      "0..1",
      "/rsm:ExchangedDocument/ram:IncludedNote/ram:ContentCode",
      "MDT-12",
      "3",
      "",
      "Code contenu",
      "",
      ""
    ],
    [
      "0..n",
      "/rsm:ExchangedDocument/ram:IncludedNote/ram:Content",
      "MDT-13",
      "3",
      "",
      "Contenu",
      "",
      ""
    ],
    [
      "0..1",
      "/rsm:ExchangedDocument/ram:IncludedNote/ram:Content/@languageID",
      "MDT-13-1",
      "4",
      "",
      "",
      "Attribut Langue",
      ""
    ],
    [
      "0..1",
      "/rsm:ExchangedDocument/ram:IncludedNote/ram:SubjectCode",
      "MDT-14",
      "3",
      "",
      "Sujet",
      "",
      ""
    ],
    [
      "0..n",
      "/rsm:ExchangedDocument/ram:EffectiveSpecifiedPeriod",
      "MDG-6",
      "2",
      "P\u00E9riode d\u0027application",
      "",
      "",
      ""
    ],
    [
      "0..1",
      "/rsm:ExchangedDocument/ram:EffectiveSpecifiedPeriod/ram:StartDateTime",
      "MDG-7",
      "3",
      "",
      "Date d\u00E9but",
      "",
      ""
    ],
    [
      "1..1",
      "/rsm:ExchangedDocument/ram:EffectiveSpecifiedPeriod/ram:StartDateTime/udt:DateTimeString",
      "MDT-15",
      "4",
      "",
      "",
      "Date-heure",
      ""
    ],
    [
      "1..1",
      "/rsm:ExchangedDocument/ram:EffectiveSpecifiedPeriod/ram:StartDateTime/udt:DateTimeString/@format",
      "MDT-15-1",
      "5",
      "",
      "",
      "Attribut Format",
      ""
    ],
    [
      "0..1",
      "/rsm:ExchangedDocument/ram:EffectiveSpecifiedPeriod/ram:EndDateTime",
      "MDG-8",
      "3",
      "",
      "Date fin",
      "",
      ""
    ],
    [
      "1..1",
      "/rsm:ExchangedDocument/ram:EffectiveSpecifiedPeriod/ram:EndDateTime/udt:DateTimeString",
      "MDT-16",
      "4",
      "",
      "",
      "Date-heure",
      ""
    ],
    [
      "1..1",
      "/rsm:ExchangedDocument/ram:EffectiveSpecifiedPeriod/ram:EndDateTime/udt:DateTimeString/@format",
      "MDT-16-1",
      "5",
      "",
      "",
      "Attribut Format",
      ""
    ],
    [
      "0..1",
      "/rsm:ExchangedDocument/ram:SenderTradeParty/ram:DefinedTradeContact/ram:TypeCode",
      "MDT-24",
      "4",
      "",
      "",
      "Type contact",
      ""
    ],
    [
      "0..n",
      "/rsm:ExchangedDocument/ram:SenderTradeParty/ram:DefinedTradeContact/ram:FaxUniversalCommunication",
      "MDG-12",
      "4",
      "",
      "",
      "Fax",
      ""
    ],
    [
      "0..1",
      "/rsm:ExchangedDocument/ram:SenderTradeParty/ram:DefinedTradeContact/ram:FaxUniversalCommunication/ram:CompleteNumber",
      "MDT-26",
      "5",
      "",
      "",
      "",
      "Num\u00E9ro fax"
    ],
    [
      "0..1",
      "/rsm:ExchangedDocument/ram:SenderTradeParty/ram:PostalTradeAddress",
      "MDG-14",
      "3",
      "",
      "Adresse postale \u00E9metteur",
      "",
      ""
    ],
    [
      "0..1",
      "/rsm:ExchangedDocument/ram:SenderTradeParty/ram:PostalTradeAddress/ram:PostcodeCode",
      "MDT-32",
      "4",
      "",
      "",
      "Code postal",
      ""
    ],
    [
      "0..1",
      "/rsm:ExchangedDocument/ram:SenderTradeParty/ram:PostalTradeAddress/ram:LineOne",
      "MDT-28",
      "4",
      "",
      "",
      "Ligne d\u0027adresse 1",
      ""
    ],
    [
      "0..1",
      "/rsm:ExchangedDocument/ram:SenderTradeParty/ram:PostalTradeAddress/ram:LineTwo",
      "MDT-29",
      "4",
      "",
      "",
      "Ligne d\u0027adresse 2",
      ""
    ],
    [
      "0..1",
      "/rsm:ExchangedDocument/ram:SenderTradeParty/ram:PostalTradeAddress/ram:LineThree",
      "MDT-30",
      "4",
      "",
      "",
      "Ligne d\u0027adresse 3",
      ""
    ],
    [
      "0..1",
      "/rsm:ExchangedDocument/ram:SenderTradeParty/ram:PostalTradeAddress/ram:CityName",
      "MDT-31",
      "4",
      "",
      "",
      "Ville",
      ""
    ],
    [
      "0..1",
      "/rsm:ExchangedDocument/ram:SenderTradeParty/ram:PostalTradeAddress/ram:CountryID",
      "MDT-34",
      "4",
      "",
      "",
      "Code pays",
      ""
    ],
    [
      "0..1",
      "/rsm:ExchangedDocument/ram:SenderTradeParty/ram:PostalTradeAddress/ram:CountrySubDivisionName",
      "MDT-33",
      "4",
      "",
      "",
      "R\u00E9gion",
      ""
    ],
    [
      "0..n",
      "/rsm:ExchangedDocument/ram:IssuerTradeParty/ram:DefinedTradeContact",
      "MDG-17",
      "3",
      "",
      "Contact \u00E9metteur",
      "",
      ""
    ],
    [
      "0..1",
      "/rsm:ExchangedDocument/ram:IssuerTradeParty/ram:DefinedTradeContact/ram:PersonName",
      "MDT-41",
      "4",
      "",
      "",
      "Nom",
      ""
    ],
    [
      "0..1",
      "/rsm:ExchangedDocument/ram:IssuerTradeParty/ram:DefinedTradeContact/ram:DepartmentName",
      "MDT-42",
      "4",
      "",
      "",
      "Service ",
      ""
    ],
    [
      "0..1",
      "/rsm:ExchangedDocument/ram:IssuerTradeParty/ram:DefinedTradeContact/ram:TypeCode",
      "MDT-43",
      "4",
      "",
      "",
      "Type contact",
      ""
    ],
    [
      "0..n",
      "/rsm:ExchangedDocument/ram:IssuerTradeParty/ram:DefinedTradeContact/ram:TelephoneUniversalCommunication",
      "MDG-18",
      "4",
      "",
      "",
      "T\u00E9l\u00E9phone",
      ""
    ],
    [
      "0..1",
      "/rsm:ExchangedDocument/ram:IssuerTradeParty/ram:DefinedTradeContact/ram:TelephoneUniversalCommunication/ram:CompleteNumber",
      "MDT-44",
      "5",
      "",
      "",
      "",
      "Num\u00E9ro t\u00E9l\u00E9phone"
    ],
    [
      "0..n",
      "/rsm:ExchangedDocument/ram:IssuerTradeParty/ram:DefinedTradeContact/ram:FaxUniversalCommunication",
      "MDG-19",
      "4",
      "",
      "",
      "Fax",
      ""
    ],
    [
      "0..1",
      "/rsm:ExchangedDocument/ram:IssuerTradeParty/ram:DefinedTradeContact/ram:FaxUniversalCommunication/ram:CompleteNumber",
      "MDT-45",
      "5",
      "",
      "",
      "",
      "Num\u00E9ro fax"
    ],
    [
      "0..1",
      "/rsm:ExchangedDocument/ram:IssuerTradeParty/ram:PostalTradeAddress",
      "MDG-21",
      "3",
      "",
      "Adresse postale \u00E9metteur",
      "",
      ""
    ],
    [
      "0..1",
      "/rsm:ExchangedDocument/ram:IssuerTradeParty/ram:PostalTradeAddress/ram:PostcodeCode",
      "MDT-51",
      "4",
      "",
      "",
      "Code postal",
      ""
    ],
    [
      "0..1",
      "/rsm:ExchangedDocument/ram:IssuerTradeParty/ram:PostalTradeAddress/ram:LineOne",
      "MDT-47",
      "4",
      "",
      "",
      "Ligne d\u0027adresse 1",
      ""
    ],
    [
      "0..1",
      "/rsm:ExchangedDocument/ram:IssuerTradeParty/ram:PostalTradeAddress/ram:LineTwo",
      "MDT-48",
      "4",
      "",
      "",
      "Ligne d\u0027adresse 2",
      ""
    ],
    [
      "0..1",
      "/rsm:ExchangedDocument/ram:IssuerTradeParty/ram:PostalTradeAddress/ram:LineThree",
      "MDT-49",
      "4",
      "",
      "",
      "Ligne d\u0027adresse 3",
      ""
    ],
    [
      "0..1",
      "/rsm:ExchangedDocument/ram:IssuerTradeParty/ram:PostalTradeAddress/ram:CityName",
      "MDT-50",
      "4",
      "",
      "",
      "Ville",
      ""
    ],
    [
      "0..1",
      "/rsm:ExchangedDocument/ram:IssuerTradeParty/ram:PostalTradeAddress/ram:CountryID",
      "MDT-53",
      "4",
      "",
      "",
      "Code pays",
      ""
    ],
    [
      "0..1",
      "/rsm:ExchangedDocument/ram:IssuerTradeParty/ram:PostalTradeAddress/ram:CountrySubDivisionName",
      "MDT-52",
      "4",
      "",
      "",
      "R\u00E9gion",
      ""
    ],
    [
      "0..n",
      "/rsm:ExchangedDocument/ram:RecipientTradeParty/ram:DefinedTradeContact",
      "MDG-24",
      "3",
      "",
      "Contact destinataire",
      "",
      ""
    ],
    [
      "0..1",
      "/rsm:ExchangedDocument/ram:RecipientTradeParty/ram:DefinedTradeContact/ram:PersonName",
      "MDT-60",
      "4",
      "",
      "",
      "Nom",
      ""
    ],
    [
      "0..1",
      "/rsm:ExchangedDocument/ram:RecipientTradeParty/ram:DefinedTradeContact/ram:DepartmentName",
      "MDT-61",
      "4",
      "",
      "",
      "Service ",
      ""
    ],
    [
      "0..1",
      "/rsm:ExchangedDocument/ram:RecipientTradeParty/ram:DefinedTradeContact/ram:TypeCode",
      "MDT-62",
      "4",
      "",
      "",
      "Type contact",
      ""
    ],
    [
      "0..n",
      "/rsm:ExchangedDocument/ram:RecipientTradeParty/ram:DefinedTradeContact/ram:TelephoneUniversalCommunication",
      "MDG-25",
      "4",
      "",
      "",
      "T\u00E9l\u00E9phone",
      ""
    ],
    [
      "0..1",
      "/rsm:ExchangedDocument/ram:RecipientTradeParty/ram:DefinedTradeContact/ram:TelephoneUniversalCommunication/ram:CompleteNumber",
      "MDT-63",
      "5",
      "",
      "",
      "",
      "Num\u00E9ro t\u00E9l\u00E9phone"
    ],
    [
      "0..n",
      "/rsm:ExchangedDocument/ram:RecipientTradeParty/ram:DefinedTradeContact/ram:FaxUniversalCommunication",
      "MDG-26",
      "4",
      "",
      "",
      "Fax",
      ""
    ],
    [
      "0..1",
      "/rsm:ExchangedDocument/ram:RecipientTradeParty/ram:DefinedTradeContact/ram:FaxUniversalCommunication/ram:CompleteNumber",
      "MDT-64",
      "5",
      "",
      "",
      "",
      "Num\u00E9ro fax"
    ],
    [
      "0..1",
      "/rsm:ExchangedDocument/ram:RecipientTradeParty/ram:DefinedTradeContact/ram:EmailURIUniversalCommunication",
      "MDG-27",
      "4",
      "",
      "",
      "Courriel",
      ""
    ],
    [
      "0..1",
      "/rsm:ExchangedDocument/ram:RecipientTradeParty/ram:DefinedTradeContact/ram:EmailURIUniversalCommunication/ram:URIID",
      "MDT-65",
      "5",
      "",
      "",
      "",
      "Adresse courriel"
    ],
    [
      "0..1",
      "/rsm:ExchangedDocument/ram:RecipientTradeParty/ram:PostalTradeAddress/ram:PostcodeCode",
      "MDT-70",
      "4",
      "",
      "",
      "Code postal",
      ""
    ],
    [
      "0..1",
      "/rsm:ExchangedDocument/ram:RecipientTradeParty/ram:PostalTradeAddress/ram:LineOne",
      "MDT-66",
      "4",
      "",
      "",
      "Ligne d\u0027adresse 1",
      ""
    ],
    [
      "0..1",
      "/rsm:ExchangedDocument/ram:RecipientTradeParty/ram:PostalTradeAddress/ram:LineTwo",
      "MDT-67",
      "4",
      "",
      "",
      "Ligne d\u0027adresse 2",
      ""
    ],
    [
      "0..1",
      "/rsm:ExchangedDocument/ram:RecipientTradeParty/ram:PostalTradeAddress/ram:LineThree",
      "MDT-68",
      "4",
      "",
      "",
      "Ligne d\u0027adresse 3",
      ""
    ],
    [
      "0..1",
      "/rsm:ExchangedDocument/ram:RecipientTradeParty/ram:PostalTradeAddress/ram:CityName",
      "MDT-69",
      "4",
      "",
      "",
      "Ville",
      ""
    ],
    [
      "0..1",
      "/rsm:ExchangedDocument/ram:RecipientTradeParty/ram:PostalTradeAddress/ram:CountrySubDivisionName",
      "MDT-71",
      "4",
      "",
      "",
      "R\u00E9gion",
      ""
    ],
    [
      "0..1",
      "/rsm:AcknowledgementDocument/ram:TypeCode",
      "MDT-77",
      "2",
      "Code type document",
      "",
      "",
      ""
    ],
    [
      "0..1",
      "/rsm:AcknowledgementDocument/ram:StatusCode",
      "MDT-79",
      "2",
      "Code statut r\u00E9ception",
      "",
      "",
      ""
    ],
    [
      "0..1",
      "/rsm:AcknowledgementDocument/ram:AcknowledgementStatusCode",
      "MDT-81",
      "2",
      "Code acquittement",
      "",
      "",
      ""
    ],
    [
      "0..1",
      "/rsm:AcknowledgementDocument/ram:ItemIdentificationID",
      "MDT-82",
      "2",
      "ID de l\u0027objet concern\u00E9",
      "",
      "",
      ""
    ],
    [
      "0..n",
      "/rsm:AcknowledgementDocument/ram:ReasonInformation",
      "MDT-83",
      "2",
      "Motif",
      "",
      "",
      ""
    ],
    [
      "0..1",
      "/rsm:AcknowledgementDocument/ram:ReasonInformation/@languageID",
      "MDT-83-1",
      "3",
      "",
      "Attribut Langue",
      "",
      ""
    ],
    [
      "0..1",
      "/rsm:AcknowledgementDocument/ram:ChannelCode",
      "MDT-84",
      "2",
      "Code canal d\u0027origine",
      "",
      "",
      ""
    ],
    [
      "0..1",
      "/rsm:AcknowledgementDocument/ram:ProcessConditionCode",
      "MDT-85",
      "2",
      "Code statut traitement",
      "",
      "",
      ""
    ],
    [
      "0..1",
      "/rsm:AcknowledgementDocument/ram:ProcessConditionCode/@listName",
      "MDT-85-1",
      "3",
      "",
      "Attribut Nom liste",
      "",
      ""
    ],
    [
      "0..n",
      "/rsm:AcknowledgementDocument/ram:ProcessCondition",
      "MDT-86",
      "2",
      "D\u00E9tail statut traitement",
      "",
      "",
      ""
    ],
    [
      "0..1",
      "/rsm:AcknowledgementDocument/ram:ProcessCondition/@languageID",
      "MDT-86-1",
      "3",
      "",
      "Attribut Langue",
      "",
      ""
    ],
    [
      "0..1",
      "/rsm:AcknowledgementDocument/ram:Status",
      "MDT-80",
      "2",
      "D\u00E9tail statut r\u00E9ception",
      "",
      "",
      ""
    ],
    [
      "0..1",
      "/rsm:AcknowledgementDocument/ram:Status/@languageID",
      "MDT-80-1",
      "3",
      "",
      "Attribut Langue",
      "",
      ""
    ],
    [
      "0..1",
      "/rsm:AcknowledgementDocument/ram:ReferenceReferencedDocument/ram:StatusCode",
      "MDT-88",
      "3",
      "",
      "Code statut",
      "",
      ""
    ],
    [
      "0..1",
      "/rsm:AcknowledgementDocument/ram:ReferenceReferencedDocument/ram:CopyIndicator",
      "MDG-33",
      "3",
      "",
      "Indicateur copie",
      "",
      ""
    ],
    [
      "0..1",
      "/rsm:AcknowledgementDocument/ram:ReferenceReferencedDocument/ram:CopyIndicator/udt:Indicator",
      "MDT-89",
      "4",
      "",
      "",
      "Flag copie",
      ""
    ],
    [
      "0..1",
      "/rsm:AcknowledgementDocument/ram:ReferenceReferencedDocument/ram:LineID",
      "MDT-90",
      "3",
      "",
      "Identifiant ligne",
      "",
      ""
    ],
    [
      "0..1",
      "/rsm:AcknowledgementDocument/ram:ReferenceReferencedDocument/ram:GlobalID",
      "MDT-92",
      "3",
      "",
      "Id objet (global)",
      "",
      ""
    ],
    [
      "0..1",
      "/rsm:AcknowledgementDocument/ram:ReferenceReferencedDocument/ram:GlobalID/@schemeID",
      "MDT-92-1",
      "4",
      "",
      "",
      "Attribut Type Id",
      ""
    ],
    [
      "0..1",
      "/rsm:AcknowledgementDocument/ram:ReferenceReferencedDocument/ram:RevisionID",
      "MDT-93",
      "3",
      "",
      "Id r\u00E9vision objet",
      "",
      ""
    ],
    [
      "0..1",
      "/rsm:AcknowledgementDocument/ram:ReferenceReferencedDocument/ram:LanguageID",
      "MDT-98",
      "3",
      "",
      "ID langue",
      "",
      ""
    ],
    [
      "0..n",
      "/rsm:AcknowledgementDocument/ram:ReferenceReferencedDocument/ram:Description",
      "MDT-99",
      "3",
      "",
      "Description",
      "",
      ""
    ],
    [
      "0..1",
      "/rsm:AcknowledgementDocument/ram:ReferenceReferencedDocument/ram:Description/@languageID",
      "MDT-99-1",
      "4",
      "",
      "",
      "Attribut Langue",
      ""
    ],
    [
      "0..n",
      "/rsm:AcknowledgementDocument/ram:ReferenceReferencedDocument/ram:IncludedAmount",
      "MDT-101",
      "3",
      "",
      "Montant",
      "",
      ""
    ],
    [
      "0..1",
      "/rsm:AcknowledgementDocument/ram:ReferenceReferencedDocument/ram:IncludedAmount/@currencyID",
      "MDT-101-1",
      "4",
      "",
      "",
      "Attribut Devise",
      ""
    ],
    [
      "0..1",
      "/rsm:AcknowledgementDocument/ram:ReferenceReferencedDocument/ram:VersionID",
      "MDT-102",
      "3",
      "",
      "Id version objet",
      "",
      ""
    ],
    [
      "0..1",
      "/rsm:AcknowledgementDocument/ram:ReferenceReferencedDocument/ram:TotalIssueCountNumeric",
      "MDT-103",
      "3",
      "",
      "Nombre total d\u0027anomalies",
      "",
      ""
    ],
    [
      "0..n",
      "/rsm:AcknowledgementDocument/ram:ReferenceReferencedDocument/ram:Status",
      "MDT-104",
      "3",
      "",
      "Libell\u00E9 statut",
      "",
      ""
    ],
    [
      "0..1",
      "/rsm:AcknowledgementDocument/ram:ReferenceReferencedDocument/ram:Status/@languageID",
      "MDT-104-1",
      "4",
      "",
      "",
      "Attribut Langue",
      ""
    ],
    [
      "0..1",
      "/rsm:AcknowledgementDocument/ram:ReferenceReferencedDocument/ram:ProcessCondition/@languageID",
      "MDT-106-1",
      "4",
      "",
      "",
      "Attribut Langue",
      ""
    ],
    [
      "0..n",
      "/rsm:AcknowledgementDocument/ram:ReferenceReferencedDocument/ram:IssuerTradeParty/ram:ID",
      "MDT-128",
      "4",
      "",
      "\u00A0",
      "Id \u00E9metteur document r\u00E9f\u00E9renc\u00E9",
      ""
    ],
    [
      "0..1",
      "/rsm:AcknowledgementDocument/ram:ReferenceReferencedDocument/ram:IssuerTradeParty/ram:Name",
      "MDT-131",
      "4",
      "",
      "\u00A0",
      "Raison sociale",
      ""
    ],
    [
      "0..n",
      "/rsm:AcknowledgementDocument/ram:ReferenceReferencedDocument/ram:IssuerTradeParty/ram:DefinedTradeContact",
      "MDT-133",
      "4",
      "",
      "\u00A0",
      "Contact \u00E9metteur document r\u00E9f\u00E9renc\u00E9",
      ""
    ],
    [
      "0..1",
      "/rsm:AcknowledgementDocument/ram:ReferenceReferencedDocument/ram:IssuerTradeParty/ram:DefinedTradeContact/ram:PersonName",
      "MDT-134",
      "5",
      "",
      "\u00A0",
      "\u00A0",
      "Nom"
    ],
    [
      "0..1",
      "/rsm:AcknowledgementDocument/ram:ReferenceReferencedDocument/ram:IssuerTradeParty/ram:DefinedTradeContact/ram:DepartmentName",
      "MDT-135",
      "5",
      "",
      "\u00A0",
      "\u00A0",
      "Service\u00A0"
    ],
    [
      "0..1",
      "/rsm:AcknowledgementDocument/ram:ReferenceReferencedDocument/ram:IssuerTradeParty/ram:DefinedTradeContact/ram:TypeCode",
      "MDT-136",
      "5",
      "",
      "\u00A0",
      "\u00A0",
      "Type contact"
    ],
    [
      "0..n",
      "/rsm:AcknowledgementDocument/ram:ReferenceReferencedDocument/ram:IssuerTradeParty/ram:DefinedTradeContact/ram:TelephoneUniversalCommunication",
      "MDT-137",
      "5",
      "",
      "\u00A0",
      "\u00A0",
      "T\u00E9l\u00E9phone"
    ],
    [
      "0..1",
      "/rsm:AcknowledgementDocument/ram:ReferenceReferencedDocument/ram:IssuerTradeParty/ram:DefinedTradeContact/ram:TelephoneUniversalCommunication/ram:CompleteNumber",
      "MDT-138",
      "6",
      "",
      "\u00A0",
      "\u00A0",
      "Num\u00E9ro t\u00E9l\u00E9phone"
    ],
    [
      "0..n",
      "/rsm:AcknowledgementDocument/ram:ReferenceReferencedDocument/ram:IssuerTradeParty/ram:DefinedTradeContact/ram:FaxUniversalCommunication",
      "MDT-139",
      "5",
      "",
      "\u00A0",
      "\u00A0",
      "Fax"
    ],
    [
      "0..1",
      "/rsm:AcknowledgementDocument/ram:ReferenceReferencedDocument/ram:IssuerTradeParty/ram:DefinedTradeContact/ram:FaxUniversalCommunication/ram:CompleteNumber",
      "MDT-140",
      "6",
      "",
      "\u00A0",
      "\u00A0",
      "Num\u00E9ro fax"
    ],
    [
      "0..1",
      "/rsm:AcknowledgementDocument/ram:ReferenceReferencedDocument/ram:IssuerTradeParty/ram:DefinedTradeContact/ram:EmailURIUniversalCommunication",
      "MDT-141",
      "5",
      "",
      "\u00A0",
      "\u00A0",
      "Courriel"
    ],
    [
      "0..1",
      "/rsm:AcknowledgementDocument/ram:ReferenceReferencedDocument/ram:IssuerTradeParty/ram:DefinedTradeContact/ram:EmailURIUniversalCommunication/ram:URIID",
      "MDT-142",
      "6",
      "",
      "\u00A0",
      "\u00A0",
      "Adresse courriel"
    ],
    [
      "0..1",
      "/rsm:AcknowledgementDocument/ram:ReferenceReferencedDocument/ram:IssuerTradeParty/ram:PostalTradeAddress",
      "MDT-143",
      "4",
      "",
      "\u00A0",
      "Adresse postale \u00E9metteur",
      ""
    ],
    [
      "0..1",
      "/rsm:AcknowledgementDocument/ram:ReferenceReferencedDocument/ram:IssuerTradeParty/ram:PostalTradeAddress/ram:PostcodeCode",
      "MDT-144",
      "5",
      "",
      "\u00A0",
      "\u00A0",
      "Code postal"
    ],
    [
      "0..1",
      "/rsm:AcknowledgementDocument/ram:ReferenceReferencedDocument/ram:IssuerTradeParty/ram:PostalTradeAddress/ram:LineOne",
      "MDT-145",
      "5",
      "",
      "\u00A0",
      "\u00A0",
      "Ligne d\u0027adresse 1"
    ],
    [
      "0..1",
      "/rsm:AcknowledgementDocument/ram:ReferenceReferencedDocument/ram:IssuerTradeParty/ram:PostalTradeAddress/ram:LineTwo",
      "MDT-146",
      "5",
      "",
      "\u00A0",
      "\u00A0",
      "Ligne d\u0027adresse 2"
    ],
    [
      "0..1",
      "/rsm:AcknowledgementDocument/ram:ReferenceReferencedDocument/ram:IssuerTradeParty/ram:PostalTradeAddress/ram:LineThree",
      "MDT-147",
      "5",
      "",
      "\u00A0",
      "\u00A0",
      "Ligne d\u0027adresse 3"
    ],
    [
      "0..1",
      "/rsm:AcknowledgementDocument/ram:ReferenceReferencedDocument/ram:IssuerTradeParty/ram:PostalTradeAddress/ram:CityName",
      "MDT-148",
      "5",
      "",
      "\u00A0",
      "\u00A0",
      "Ville"
    ],
    [
      "0..1",
      "/rsm:AcknowledgementDocument/ram:ReferenceReferencedDocument/ram:IssuerTradeParty/ram:PostalTradeAddress/ram:CountryID",
      "MDT-149",
      "5",
      "",
      "\u00A0",
      "\u00A0",
      "Code pays"
    ],
    [
      "0..1",
      "/rsm:AcknowledgementDocument/ram:ReferenceReferencedDocument/ram:IssuerTradeParty/ram:PostalTradeAddress/ram:CountrySubDivisionName",
      "MDT-150",
      "5",
      "",
      "\u00A0",
      "\u00A0",
      "R\u00E9gion"
    ],
    [
      "0..n",
      "/rsm:AcknowledgementDocument/ram:ReferenceReferencedDocument/ram:RecipientTradeParty/ram:ID",
      "MDT-154",
      "4",
      "",
      "\u00A0",
      "Id destinataire document",
      ""
    ],
    [
      "0..n",
      "/rsm:AcknowledgementDocument/ram:ReferenceReferencedDocument/ram:RecipientTradeParty/ram:DefinedTradeContact",
      "MDT-159",
      "4",
      "",
      "\u00A0",
      "Contact destinataire",
      ""
    ],
    [
      "0..1",
      "/rsm:AcknowledgementDocument/ram:ReferenceReferencedDocument/ram:RecipientTradeParty/ram:DefinedTradeContact/ram:PersonName",
      "MDT-160",
      "5",
      "",
      "\u00A0",
      "\u00A0",
      "Nom"
    ],
    [
      "0..1",
      "/rsm:AcknowledgementDocument/ram:ReferenceReferencedDocument/ram:RecipientTradeParty/ram:DefinedTradeContact/ram:DepartmentName",
      "MDT-161",
      "5",
      "",
      "\u00A0",
      "\u00A0",
      "Service\u00A0"
    ],
    [
      "0..1",
      "/rsm:AcknowledgementDocument/ram:ReferenceReferencedDocument/ram:RecipientTradeParty/ram:DefinedTradeContact/ram:TypeCode",
      "MDT-162",
      "5",
      "",
      "\u00A0",
      "\u00A0",
      "Type contact"
    ],
    [
      "0..n",
      "/rsm:AcknowledgementDocument/ram:ReferenceReferencedDocument/ram:RecipientTradeParty/ram:DefinedTradeContact/ram:TelephoneUniversalCommunication",
      "MDT-163",
      "5",
      "",
      "\u00A0",
      "\u00A0",
      "T\u00E9l\u00E9phone"
    ],
    [
      "0..1",
      "/rsm:AcknowledgementDocument/ram:ReferenceReferencedDocument/ram:RecipientTradeParty/ram:DefinedTradeContact/ram:TelephoneUniversalCommunication/ram:CompleteNumber",
      "MDT-164",
      "6",
      "",
      "\u00A0",
      "\u00A0",
      "Num\u00E9ro t\u00E9l\u00E9phone"
    ],
    [
      "0..n",
      "/rsm:AcknowledgementDocument/ram:ReferenceReferencedDocument/ram:RecipientTradeParty/ram:DefinedTradeContact/ram:FaxUniversalCommunication",
      "MDT-165",
      "5",
      "",
      "\u00A0",
      "\u00A0",
      "Fax"
    ],
    [
      "0..1",
      "/rsm:AcknowledgementDocument/ram:ReferenceReferencedDocument/ram:RecipientTradeParty/ram:DefinedTradeContact/ram:FaxUniversalCommunication/ram:CompleteNumber",
      "MDT-166",
      "6",
      "",
      "\u00A0",
      "\u00A0",
      "Num\u00E9ro fax"
    ],
    [
      "0..1",
      "/rsm:AcknowledgementDocument/ram:ReferenceReferencedDocument/ram:RecipientTradeParty/ram:DefinedTradeContact/ram:EmailURIUniversalCommunication",
      "MDT-167",
      "5",
      "",
      "\u00A0",
      "\u00A0",
      "Courriel"
    ],
    [
      "0..1",
      "/rsm:AcknowledgementDocument/ram:ReferenceReferencedDocument/ram:RecipientTradeParty/ram:DefinedTradeContact/ram:EmailURIUniversalCommunication/ram:URIID",
      "MDT-168",
      "6",
      "",
      "\u00A0",
      "\u00A0",
      "Adresse courriel"
    ],
    [
      "0..1",
      "/rsm:AcknowledgementDocument/ram:ReferenceReferencedDocument/ram:RecipientTradeParty/ram:PostalTradeAddress",
      "MDT-169",
      "4",
      "",
      "\u00A0",
      "Adresse postale destinataire du Document R\u00E9f\u00E9renc\u00E9",
      ""
    ],
    [
      "0..1",
      "/rsm:AcknowledgementDocument/ram:ReferenceReferencedDocument/ram:RecipientTradeParty/ram:PostalTradeAddress/ram:PostcodeCode",
      "MDT-170",
      "5",
      "",
      "\u00A0",
      "\u00A0",
      "Code postal"
    ],
    [
      "0..1",
      "/rsm:AcknowledgementDocument/ram:ReferenceReferencedDocument/ram:RecipientTradeParty/ram:PostalTradeAddress/ram:LineOne",
      "MDT-171",
      "5",
      "",
      "\u00A0",
      "\u00A0",
      "Ligne d\u0027adresse 1"
    ],
    [
      "0..1",
      "/rsm:AcknowledgementDocument/ram:ReferenceReferencedDocument/ram:RecipientTradeParty/ram:PostalTradeAddress/ram:LineTwo",
      "MDT-172",
      "5",
      "",
      "\u00A0",
      "\u00A0",
      "Ligne d\u0027adresse 2"
    ],
    [
      "0..1",
      "/rsm:AcknowledgementDocument/ram:ReferenceReferencedDocument/ram:RecipientTradeParty/ram:PostalTradeAddress/ram:LineThree",
      "MDT-173",
      "5",
      "",
      "\u00A0",
      "\u00A0",
      "Ligne d\u0027adresse 3"
    ],
    [
      "0..1",
      "/rsm:AcknowledgementDocument/ram:ReferenceReferencedDocument/ram:RecipientTradeParty/ram:PostalTradeAddress/ram:CityName",
      "MDT-174",
      "5",
      "",
      "\u00A0",
      "\u00A0",
      "Ville"
    ],
    [
      "0..1",
      "/rsm:AcknowledgementDocument/ram:ReferenceReferencedDocument/ram:RecipientTradeParty/ram:PostalTradeAddress/ram:CountryID",
      "MDT-175",
      "5",
      "",
      "\u00A0",
      "\u00A0",
      "Code pays"
    ],
    [
      "0..1",
      "/rsm:AcknowledgementDocument/ram:ReferenceReferencedDocument/ram:RecipientTradeParty/ram:PostalTradeAddress/ram:CountrySubDivisionName",
      "MDT-176",
      "5",
      "",
      "\u00A0",
      "\u00A0",
      "R\u00E9gion"
    ],
    [
      "0..1",
      "/rsm:AcknowledgementDocument/ram:ReferenceReferencedDocument/ram:SenderTradeParty",
      "MDG-42",
      "3",
      "",
      "Emetteur du flux Document R\u00E9f\u00E9renc\u00E9",
      "",
      ""
    ],
    [
      "0..n",
      "/rsm:AcknowledgementDocument/ram:ReferenceReferencedDocument/ram:SenderTradeParty/ram:ID",
      "MDT-180",
      "4",
      "",
      "\u00A0",
      "ID de l\u0027\u00E9metteur du Document r\u00E9f\u00E9renc\u00E9",
      ""
    ],
    [
      "0..n",
      "/rsm:AcknowledgementDocument/ram:ReferenceReferencedDocument/ram:SenderTradeParty/ram:GlobalID",
      "MDT-181",
      "4",
      "",
      "\u00A0",
      "Global ID de l\u0027emetteur du Document r\u00E9f\u00E9renc\u00E9",
      ""
    ],
    [
      "1..1",
      "/rsm:AcknowledgementDocument/ram:ReferenceReferencedDocument/ram:SenderTradeParty/ram:GlobalID/@schemeID",
      "MDT-182",
      "5",
      "",
      "\u00A0",
      "",
      "Attribut Type Id du Global ID de l\u0027emetteur du Document r\u00E9f\u00E9renc\u00E9"
    ],
    [
      "0..1",
      "/rsm:AcknowledgementDocument/ram:ReferenceReferencedDocument/ram:SenderTradeParty/ram:Name",
      "MDT-183",
      "4",
      "",
      "\u00A0",
      "Raison sociale",
      "\u00A0"
    ],
    [
      "0..1",
      "/rsm:AcknowledgementDocument/ram:ReferenceReferencedDocument/ram:SenderTradeParty/ram:RoleCode",
      "MDT-184",
      "4",
      "",
      "\u00A0",
      "Code r\u00F4le",
      "\u00A0"
    ],
    [
      "0..n",
      "/rsm:AcknowledgementDocument/ram:ReferenceReferencedDocument/ram:SenderTradeParty/ram:DefinedTradeContact",
      "MDT-185",
      "4",
      "",
      "\u00A0",
      "Contact du flux Document R\u00E9f\u00E9renc\u00E9",
      ""
    ],
    [
      "0..1",
      "/rsm:AcknowledgementDocument/ram:ReferenceReferencedDocument/ram:SenderTradeParty/ram:DefinedTradeContact/ram:PersonName",
      "MDT-186",
      "5",
      "",
      "\u00A0",
      "\u00A0",
      "Nom"
    ],
    [
      "0..1",
      "/rsm:AcknowledgementDocument/ram:ReferenceReferencedDocument/ram:SenderTradeParty/ram:DefinedTradeContact/ram:DepartmentName",
      "MDT-187",
      "5",
      "",
      "\u00A0",
      "\u00A0",
      "Service\u00A0"
    ],
    [
      "0..1",
      "/rsm:AcknowledgementDocument/ram:ReferenceReferencedDocument/ram:SenderTradeParty/ram:DefinedTradeContact/ram:TypeCode",
      "MDT-188",
      "5",
      "",
      "\u00A0",
      "\u00A0",
      "Type contact"
    ],
    [
      "0..n",
      "/rsm:AcknowledgementDocument/ram:ReferenceReferencedDocument/ram:SenderTradeParty/ram:DefinedTradeContact/ram:TelephoneUniversalCommunication",
      "MDT-189",
      "5",
      "",
      "\u00A0",
      "\u00A0",
      "T\u00E9l\u00E9phone"
    ],
    [
      "0..1",
      "/rsm:AcknowledgementDocument/ram:ReferenceReferencedDocument/ram:SenderTradeParty/ram:DefinedTradeContact/ram:TelephoneUniversalCommunication/ram:CompleteNumber",
      "MDT-190",
      "6",
      "",
      "\u00A0",
      "\u00A0",
      "Num\u00E9ro t\u00E9l\u00E9phone"
    ],
    [
      "0..n",
      "/rsm:AcknowledgementDocument/ram:ReferenceReferencedDocument/ram:SenderTradeParty/ram:DefinedTradeContact/ram:FaxUniversalCommunication",
      "MDT-191",
      "5",
      "",
      "\u00A0",
      "\u00A0",
      "Fax"
    ],
    [
      "0..1",
      "/rsm:AcknowledgementDocument/ram:ReferenceReferencedDocument/ram:SenderTradeParty/ram:DefinedTradeContact/ram:FaxUniversalCommunication/ram:CompleteNumber",
      "MDT-192",
      "6",
      "",
      "\u00A0",
      "\u00A0",
      "Num\u00E9ro fax"
    ],
    [
      "0..1",
      "/rsm:AcknowledgementDocument/ram:ReferenceReferencedDocument/ram:SenderTradeParty/ram:DefinedTradeContact/ram:EmailURIUniversalCommunication",
      "MDT-193",
      "5",
      "",
      "\u00A0",
      "\u00A0",
      "Courriel"
    ],
    [
      "0..1",
      "/rsm:AcknowledgementDocument/ram:ReferenceReferencedDocument/ram:SenderTradeParty/ram:DefinedTradeContact/ram:EmailURIUniversalCommunication/ram:URIID",
      "MDT-194",
      "6",
      "",
      "\u00A0",
      "\u00A0",
      "Adresse courriel"
    ],
    [
      "0..1",
      "/rsm:AcknowledgementDocument/ram:ReferenceReferencedDocument/ram:SenderTradeParty/ram:PostalTradeAddress",
      "MDT-195",
      "4",
      "",
      "\u00A0",
      "Adresse postale du flux Document R\u00E9f\u00E9renc\u00E9",
      ""
    ],
    [
      "0..1",
      "/rsm:AcknowledgementDocument/ram:ReferenceReferencedDocument/ram:SenderTradeParty/ram:PostalTradeAddress/ram:PostcodeCode",
      "MDT-196",
      "5",
      "",
      "\u00A0",
      "\u00A0",
      "Code postal"
    ],
    [
      "0..1",
      "/rsm:AcknowledgementDocument/ram:ReferenceReferencedDocument/ram:SenderTradeParty/ram:PostalTradeAddress/ram:LineOne",
      "MDT-197",
      "5",
      "",
      "\u00A0",
      "\u00A0",
      "Ligne d\u0027adresse 1"
    ],
    [
      "0..1",
      "/rsm:AcknowledgementDocument/ram:ReferenceReferencedDocument/ram:SenderTradeParty/ram:PostalTradeAddress/ram:LineTwo",
      "MDT-198",
      "5",
      "",
      "\u00A0",
      "\u00A0",
      "Ligne d\u0027adresse 2"
    ],
    [
      "0..1",
      "/rsm:AcknowledgementDocument/ram:ReferenceReferencedDocument/ram:SenderTradeParty/ram:PostalTradeAddress/ram:LineThree",
      "MDT-199",
      "5",
      "",
      "\u00A0",
      "\u00A0",
      "Ligne d\u0027adresse 3"
    ],
    [
      "0..1",
      "/rsm:AcknowledgementDocument/ram:ReferenceReferencedDocument/ram:SenderTradeParty/ram:PostalTradeAddress/ram:CityName",
      "MDT-200",
      "5",
      "",
      "\u00A0",
      "\u00A0",
      "Ville"
    ],
    [
      "0..1",
      "/rsm:AcknowledgementDocument/ram:ReferenceReferencedDocument/ram:SenderTradeParty/ram:PostalTradeAddress/ram:CountryID",
      "MDT-201",
      "5",
      "",
      "\u00A0",
      "\u00A0",
      "Code pays"
    ],
    [
      "0..1",
      "/rsm:AcknowledgementDocument/ram:ReferenceReferencedDocument/ram:SenderTradeParty/ram:PostalTradeAddress/ram:CountrySubDivisionName",
      "MDT-202",
      "5",
      "",
      "\u00A0",
      "\u00A0",
      "R\u00E9gion"
    ],
    [
      "0..1",
      "/rsm:AcknowledgementDocument/ram:ReferenceReferencedDocument/ram:SenderTradeParty/ram:URIUniversalCommunication",
      "MDT-203",
      "4",
      "",
      "\u00A0",
      "Adresse \u00E9lectronique du flux Document R\u00E9f\u00E9renc\u00E9",
      ""
    ],
    [
      "0..1",
      "/rsm:AcknowledgementDocument/ram:ReferenceReferencedDocument/ram:SenderTradeParty/ram:URIUniversalCommunication/ram:URIID",
      "MDT-204",
      "5",
      "",
      "\u00A0",
      "\u00A0",
      "Adresse \u00E9lectronique (r\u00E9seau CEF)"
    ],
    [
      "1..1",
      "/rsm:AcknowledgementDocument/ram:ReferenceReferencedDocument/ram:SenderTradeParty/ram:URIUniversalCommunication/ram:URIID/@schemeID",
      "MDT-204-1",
      "6",
      "",
      "",
      "",
      "Attribut Type Id"
    ],
    [
      "0..n",
      "/rsm:AcknowledgementDocument/ram:ReferenceReferencedDocument/ram:IncludedNote",
      "MDG-36",
      "3",
      "",
      "Montants",
      "",
      ""
    ],
    [
      "0..1",
      "/rsm:AcknowledgementDocument/ram:ReferenceReferencedDocument/ram:IncludedNote/ram:ContentCode",
      "MDT-107",
      "4",
      "",
      "",
      "Code montant",
      ""
    ],
    [
      "0..n",
      "/rsm:AcknowledgementDocument/ram:ReferenceReferencedDocument/ram:IncludedNote/ram:Content",
      "MDT-108",
      "4",
      "",
      "",
      "Valeur montant",
      ""
    ],
    [
      "0..1",
      "/rsm:AcknowledgementDocument/ram:ReferenceReferencedDocument/ram:IncludedNote/ram:Content/@languageID",
      "MDT-108-1",
      "5",
      "",
      "",
      "",
      "Attribut Langue"
    ],
    [
      "0..1",
      "/rsm:AcknowledgementDocument/ram:ReferenceReferencedDocument/ram:IncludedNote/ram:SubjectCode",
      "MDT-109",
      "4",
      "",
      "",
      "Sujet",
      ""
    ],
    [
      "0..1",
      "/rsm:AcknowledgementDocument/ram:ReferenceReferencedDocument/ram:SpecifiedDocumentStatus/ram:ConditionCode",
      "MDT-111",
      "4",
      "",
      "",
      "Code statut",
      ""
    ],
    [
      "0..1",
      "/rsm:AcknowledgementDocument/ram:ReferenceReferencedDocument/ram:SpecifiedDocumentStatus/ram:ConditionCode/@listName",
      "MDT-111-1",
      "5",
      "",
      "",
      "",
      "Attribut Nom liste"
    ],
    [
      "0..1",
      "/rsm:AcknowledgementDocument/ram:ReferenceReferencedDocument/ram:SpecifiedDocumentStatus/ram:Reason/@languageID",
      "MDT-114-1",
      "5",
      "",
      "",
      "",
      "Attribut Langue"
    ],
    [
      "0..n",
      "/rsm:AcknowledgementDocument/ram:ReferenceReferencedDocument/ram:SpecifiedDocumentStatus/ram:Condition",
      "MDT-112",
      "4",
      "",
      "",
      "Libell\u00E9 statut",
      ""
    ],
    [
      "0..1",
      "/rsm:AcknowledgementDocument/ram:ReferenceReferencedDocument/ram:SpecifiedDocumentStatus/ram:Condition/@languageID",
      "MDT-112-1",
      "5",
      "",
      "",
      "",
      "Attribut Langue"
    ],
    [
      "0..1",
      "/rsm:AcknowledgementDocument/ram:ReferenceReferencedDocument/ram:SpecifiedDocumentStatus/ram:ProcessConditionCode/@listName",
      "MDT-115-1",
      "5",
      "",
      "",
      "",
      "Attribut Nom liste"
    ],
    [
      "0..1",
      "/rsm:AcknowledgementDocument/ram:ReferenceReferencedDocument/ram:SpecifiedDocumentStatus/ram:ProcessCondition/@languageID",
      "MDT-116-1",
      "5",
      "",
      "",
      "",
      "Attribut Langue"
    ],
    [
      "0..1",
      "/rsm:AcknowledgementDocument/ram:ReferenceReferencedDocument/ram:SpecifiedDocumentStatus/ram:ReasonInformationCode",
      "MDT-117",
      "4",
      "",
      "",
      "Code information motif",
      ""
    ],
    [
      "0..1",
      "/rsm:AcknowledgementDocument/ram:ReferenceReferencedDocument/ram:SpecifiedDocumentStatus/ram:ReasonInformationCode/@listName",
      "MDT-117-1",
      "5",
      "",
      "",
      "",
      "Attribut Nom liste"
    ],
    [
      "0..n",
      "/rsm:AcknowledgementDocument/ram:ReferenceReferencedDocument/ram:SpecifiedDocumentStatus/ram:ReasonInformation",
      "MDT-118",
      "4",
      "",
      "",
      "Information motif",
      ""
    ],
    [
      "0..1",
      "/rsm:AcknowledgementDocument/ram:ReferenceReferencedDocument/ram:SpecifiedDocumentStatus/ram:ReasonInformation/@languageID",
      "MDT-118-1",
      "5",
      "",
      "",
      "",
      "Attribut Langue"
    ],
    [
      "0..1",
      "/rsm:AcknowledgementDocument/ram:ReferenceReferencedDocument/ram:SpecifiedDocumentStatus/ram:ReasonClassificationCode",
      "MDT-119",
      "4",
      "",
      "",
      "Code niveau erreur",
      ""
    ],
    [
      "0..1",
      "/rsm:AcknowledgementDocument/ram:ReferenceReferencedDocument/ram:SpecifiedDocumentStatus/ram:ReasonClassificationCode/@listName",
      "MDT-119-1",
      "5",
      "",
      "",
      "",
      "Attribut Nom liste"
    ],
    [
      "0..n",
      "/rsm:AcknowledgementDocument/ram:ReferenceReferencedDocument/ram:SpecifiedDocumentStatus/ram:ReasonClassification",
      "MDT-120",
      "4",
      "",
      "",
      "Niveau erreur",
      ""
    ],
    [
      "0..1",
      "/rsm:AcknowledgementDocument/ram:ReferenceReferencedDocument/ram:SpecifiedDocumentStatus/ram:ReasonClassification/@languageID",
      "MDT-120-1",
      "5",
      "",
      "",
      "",
      "Attribut Langue"
    ],
    [
      "0..1",
      "/rsm:AcknowledgementDocument/ram:ReferenceReferencedDocument/ram:SpecifiedDocumentStatus/ram:RequestedActionCode/@listName",
      "MDT-121-1",
      "5",
      "",
      "",
      "",
      "Attribut Nom liste"
    ],
    [
      "0..1",
      "/rsm:AcknowledgementDocument/ram:ReferenceReferencedDocument/ram:SpecifiedDocumentStatus/ram:RequestedAction/@languageID",
      "MDT-122-1",
      "5",
      "",
      "",
      "",
      "Attribut Langue"
    ],
    [
      "0..1",
      "/rsm:AcknowledgementDocument/ram:ReferenceReferencedDocument/ram:SpecifiedDocumentStatus/ram:InvalidInformation",
      "MDT-123",
      "4",
      "",
      "",
      "Donn\u00E9es invalides",
      ""
    ],
    [
      "0..1",
      "/rsm:AcknowledgementDocument/ram:ReferenceReferencedDocument/ram:SpecifiedDocumentStatus/ram:InvalidInformation/@languageID",
      "MDT-123-1",
      "5",
      "",
      "",
      "",
      "Attribut Langue"
    ],
    [
      "0..1",
      "/rsm:AcknowledgementDocument/ram:ReferenceReferencedDocument/ram:SpecifiedDocumentStatus/ram:ValidInformation",
      "MDT-124",
      "4",
      "",
      "",
      "Donn\u00E9es valides",
      ""
    ],
    [
      "0..1",
      "/rsm:AcknowledgementDocument/ram:ReferenceReferencedDocument/ram:SpecifiedDocumentStatus/ram:ValidInformation/@languageID",
      "MDT-124-1",
      "5",
      "",
      "",
      "",
      "Attribut Langue"
    ],
    [
      "0..1",
      "/rsm:AcknowledgementDocument/ram:ReferenceReferencedDocument/ram:SpecifiedDocumentStatus/ram:IncludedNote/ram:Content/@languageID",
      "MDT-126-1",
      "6",
      "",
      "",
      "",
      "Attribut Langue"
    ],
    [
      "0..1",
      "/rsm:AcknowledgementDocument/ram:ReferenceReferencedDocument/ram:ValiditySpecifiedPeriod",
      "MDT-225",
      "3",
      "",
      "P\u00E9riode de validit\u00E9 du Document R\u00E9f\u00E9renc\u00E9",
      "",
      ""
    ],
    [
      "0..1",
      "/rsm:AcknowledgementDocument/ram:ReferenceReferencedDocument/ram:ValiditySpecifiedPeriod/ram:StartDateTime",
      "MDT-226",
      "4",
      "",
      "",
      "Date de d\u00E9but",
      ""
    ],
    [
      "1..1",
      "/rsm:AcknowledgementDocument/ram:ReferenceReferencedDocument/ram:ValiditySpecifiedPeriod/ram:StartDateTime/udt:DateTimeString",
      "MDT-227",
      "5",
      "",
      "",
      "",
      "Date-heure"
    ],
    [
      "0..1",
      "/rsm:AcknowledgementDocument/ram:ReferenceReferencedDocument/ram:ValiditySpecifiedPeriod/ram:StartDateTime/udt:DateTimeString/@format",
      "MDT-228",
      "6",
      "",
      "",
      "",
      "Attribut Format"
    ],
    [
      "0..1",
      "/rsm:AcknowledgementDocument/ram:ReferenceReferencedDocument/ram:ValiditySpecifiedPeriod/ram:EndDateTime",
      "MDT-229",
      "4",
      "",
      "",
      "Date de fin",
      ""
    ],
    [
      "1..1",
      "/rsm:AcknowledgementDocument/ram:ReferenceReferencedDocument/ram:ValiditySpecifiedPeriod/ram:EndDateTime/udt:DateTimeString",
      "MDT-230",
      "5",
      "",
      "",
      "",
      "Date-heure"
    ],
    [
      "0..1",
      "/rsm:AcknowledgementDocument/ram:ReferenceReferencedDocument/ram:ValiditySpecifiedPeriod/ram:EndDateTime/udt:DateTimeString/@format",
      "MDT-231",
      "6",
      "",
      "",
      "",
      "Attribut Format"
    ]
  ]
}

_Source: `c:\Users\g.baudrit\source\repos\gbaudrit\conf-aimer-votre-llm\demo\ctxc-sample-spec\with-ctxc\spec/afnor/XP_Z12-012/XP_Z12-012.xlsx` (extract:cdar/sheet:CDV FE - CDAR/table:json)_

### E-d276abeaa42a

{
  "headerRowIndices": [
    0,
    1
  ],
  "rows": [
    [
      "Card. EN 16931",
      "R\u00E8gle Flux 2, 8 sortant, 9",
      "Terme M\u00E9tier FR",
      "Type logique",
      "Xpath"
    ],
    [
      "1..1",
      "",
      "CONTROLE DU PROCESSUS",
      "",
      "/Invoice"
    ],
    [
      "1..1",
      "",
      "Type de profil (e-invoicing, e-reporting, facture etc..)",
      "IDENTIFIANT",
      "/Invoice\n\n/cbc:CustomizationID"
    ],
    [
      "0..1",
      "BR-FR-08\nBR-FR-CO-08\nBR-FR-CO-09",
      "Type de processus m\u00E9tier (cadre de facturation)",
      "TEXTE",
      "/Invoice\n\n/cbc:ProfileID"
    ],
    [
      "1..1",
      "BR-FR-01\nBR-FR-02",
      "Num\u00E9ro de facture",
      "IDENTIFIANT",
      "/Invoice\n\n/cbc:ID"
    ],
    [
      "1..1",
      "BR-FR-03",
      "Date d\u0027\u00E9mission facture initiale / facture rectificative",
      "DATE",
      "/Invoice\n\n/cbc:IssueDate"
    ],
    [
      "",
      "-",
      "-",
      "-",
      ""
    ],
    [
      "0..1",
      "BR-FR-03\nBR-FR-CO-07\nBR-FR-CO-09",
      "Date d\u0027\u00E9ch\u00E9ance / Date de versement en cas d\u0027acompte",
      "DATE",
      "/Invoice\n\n/cbc:DueDate"
    ],
    [
      "1..1",
      "BR-FR-04\nBR-FR-CO-08\nBR-FR-MV-13",
      "Code de type de facture",
      "CODE",
      "/Invoice\n\n/cbc:InvoiceTypeCode"
    ],
    [
      "0..n",
      "BR-FR-05\nBR-FR-06\nBR-FR-20",
      "NOTE DE FACTURE",
      "",
      "/Invoice\n\n/cbc:Note"
    ],
    [
      "0..1",
      "BR-FR-05\nBR-FR-06\nBR-FR-20",
      "Code du sujet de la note de facture",
      "CODE",
      "/Invoice\n\n/cbc:Note"
    ],
    [
      "1..1",
      "BR-FR-05\nBR-FR-06\nBR-FR-20",
      "Note de facture",
      "TEXTE",
      "/Invoice\n\n/cbc:Note"
    ],
    [
      "0..1",
      "",
      "Date d\u0027exigibilit\u00E9 de la taxe sur la valeur ajout\u00E9e",
      "DATE",
      "/Invoice\n\n/cbc:TaxPointDate"
    ],
    [
      "1..1",
      "BR-FR-CO-12",
      "Code de devise de la facture",
      "CODE",
      "/Invoice\n\n/cbc:DocumentCurrencyCode"
    ],
    [
      "0..1",
      "BR-FR-CO-12",
      "Code de devise de comptabilisation de la TVA",
      "CODE",
      "/Invoice\n\n/cbc:TaxCurrencyCode"
    ],
    [
      "0..1",
      "",
      "R\u00E9f\u00E9rence comptable de l\u0027acheteur",
      "TEXTE",
      "/Invoice\n\n/cbc:AccountingCost"
    ],
    [
      "0..1",
      "",
      "R\u00E9f\u00E9rence de l\u0027acheteur",
      "TEXTE",
      "/Invoice\n\n/cbc:BuyerReference"
    ],
    [
      "0..1",
      "",
      "PERIODE DE FACTURATION",
      "",
      "/Invoice\n\n/cac:InvoicePeriod"
    ],
    [
      "0..1",
      "BR-FR-03",
      "Date de d\u00E9but de p\u00E9riode de facturation",
      "DATE",
      "/Invoice\n/cac:InvoicePeriod\n\n/cbc:StartDate"
    ],
    [
      "0..1",
      "BR-FR-03",
      "Date de fin de p\u00E9riode de facturation",
      "DATE",
      "/Invoice\n/cac:InvoicePeriod\n\n/cbc:EndDate"
    ],
    [
      "0..1",
      "",
      "Code de date d\u0027exigibilit\u00E9 de la taxe sur la valeur ajout\u00E9e",
      "CODE",
      "/Invoice\n/cac:InvoicePeriod\n\n/cbc:DescriptionCode"
    ],
    [
      "0..1",
      "-",
      "-",
      "-",
      "/Invoice\n\n/cac:OrderReference"
    ],
    [
      "0..1",
      "",
      "R\u00E9f\u00E9rence du bon de commande",
      "REFERENCE DU DOCUMENT",
      "/Invoice\n/cac:OrderReference\n\n/cbc:ID"
    ],
    [
      "0..1",
      "",
      "Num\u00E9ro d\u2019ordre de vente",
      "REFERENCE DU DOCUMENT",
      "/Invoice\n/cac:OrderReference\n\n/cbc:SalesOrderID"
    ],
    [
      "0..n",
      "BR-FR-CO-03\nBR-FR-CO-04\nBR-FR-CO-05",
      "R\u00C9F\u00C9RENCE \u00C0 UNE FACTURE ANT\u00C9RIEURE",
      "",
      "/Invoice\n\n/cac:BillingReference"
    ],
    [
      "1..1",
      "-",
      "-",
      "-",
      "/Invoice\n/cac:BillingReference\n\n/cac:InvoiceDocumentReference"
    ],
    [
      "1..1",
      "BR-FR-01\nBR-FR-02\nBR-FR-CO-03\nBR-FR-CO-04\nBR-FR-CO-05",
      "R\u00E9f\u00E9rence \u00E0 une facture ant\u00E9rieure",
      "REFERENCE DU DOCUMENT",
      "/Invoice\n/cac:BillingReference\n/cac:InvoiceDocumentReference\n\n/cbc:ID"
    ],
    [
      "0..1",
      "BR-FR-03\nBR-FR-CO-03\nBR-FR-CO-04\nBR-FR-CO-05",
      "Date d\u0027\u00E9mission de facture ant\u00E9rieure",
      "DATE",
      "/Invoice\n/cac:BillingReference\n/cac:InvoiceDocumentReference\n\n/cbc:IssueDate"
    ],
    [
      "",
      "BR-FR-04",
      "Type de facture ant\u00E9rieure",
      "CODE",
      "/Invoice\n/cac:BillingReference\n/cac:InvoiceDocumentReference\n\n/cbc:DocumentTypeCode"
    ],
    [
      "0..1",
      "-",
      "-",
      "-",
      "/Invoice\n\n/cac:DespatchDocumentReference"
    ],
    [
      "0..1",
      "",
      "R\u00E9f\u00E9rence d\u0027avis d\u0027exp\u00E9dition",
      "REFERENCE DU DOCUMENT",
      "/Invoice\n/cac:DespatchDocumentReference\n\n/cbc:ID"
    ],
    [
      "0..1",
      "-",
      "-",
      "-",
      "/Invoice\n\n/cac:ReceiptDocumentReference"
    ],
    [
      "0..1",
      "",
      "R\u00E9f\u00E9rence d\u0027avis de r\u00E9ception",
      "REFERENCE DU DOCUMENT",
      "/Invoice\n/cac:ReceiptDocumentReference\n\n/cbc:ID"
    ],
    [
      "0..1",
      "-",
      "-",
      "-",
      "/Invoice\n\n/cac:OriginatorDocumentReference"
    ],
    [
      "0..1",
      "",
      "R\u00E9f\u00E9rence de l\u0027appel d\u0027offres ou du lot",
      "REFERENCE DU DOCUMENT",
      "/Invoice\n/cac:OriginatorDocumentReference\n\n/cbc:ID"
    ],
    [
      "0..1",
      "-",
      "-",
      "-",
      "/Invoice\n\n/cac:ContractDocumentReference"
    ],
    [
      "0..1",
      "BR-FR-CO-03",
      "R\u00E9f\u00E9rence du contrat",
      "REFERENCE DU DOCUMENT",
      "/Invoice\n/cac:ContractDocumentReference\n\n/cbc:ID"
    ],
    [
      "",
      "",
      "Type de contrat",
      "TEXTE",
      "/Invoice\n/cac:ContractDocumentReference\n\n/cbc:DocumentType"
    ],
    [
      "0..n",
      "",
      "DOCUMENTS JUSTIFICATIFS ADDITIONNELS",
      "",
      "/Invoice\n\n/cac:AdditionalDocumentReference"
    ],
    [
      "1..1",
      "",
      "R\u00E9f\u00E9rence de document justificatif",
      "REFERENCE DU DOCUMENT",
      "/Invoice\n/cac:AdditionalDocumentReference\n\n/cbc:ID"
    ],
    [
      "0..1",
      "BR-FR-17\nBR-FR-18",
      "Description de document justificatif",
      "TEXTE",
      "/Invoice\n/cac:AdditionalDocumentReference\n\n/cbc:DocumentDescription"
    ],
    [
      "0..1",
      "-",
      "-",
      "-",
      "/Invoice\n/cac:AdditionalDocumentReference\n\n/cac:Attachment"
    ],
    [
      "0..1",
      "",
      "Document joint",
      "OBJET BIN",
      "/Invoice\n/cac:AdditionalDocumentReference\n/cac:Attachment\n\n/cbc:EmbeddedDocumentBinaryObject"
    ],
    [
      "1..1",
      "",
      "Code MIME du document joint",
      "CODE",
      "/Invoice\n/cac:AdditionalDocumentReference\n/cac:Attachment\n/cbc:EmbeddedDocumentBinaryObject\n\n/@mimeCode"
    ],
    [
      "1..1",
      "",
      "Nom de fichier du document joint",
      "TEXTE",
      "/Invoice\n/cac:AdditionalDocumentReference\n/cac:Attachment\n/cbc:EmbeddedDocumentBinaryObject\n\n/@filename"
    ],
    [
      "0..1",
      "-",
      "-",
      "-",
      "/Invoice\n/cac:AdditionalDocumentReference\n/cac:Attachment\n\n/cac:ExternalReference"
    ],
    [
      "0..1",
      "",
      "Emplacement de document externe",
      "TEXTE",
      "/Invoice\n/cac:AdditionalDocumentReference\n/cac:Attachment\n/cac:ExternalReference\n\n/cbc:URI"
    ],
    [
      "0..1",
      "-",
      "-",
      "-",
      "/Invoice\n\n/cac:AdditionalDocumentReference"
    ],
    [
      "0..1",
      "BR-FR-29\nBR-FR-30",
      "Identifiant d\u0027objet factur\u00E9",
      "IDENTIFIANT",
      "/Invoice\n/cac:AdditionalDocumentReference\n\n/cbc:ID"
    ],
    [
      "0..1",
      "",
      "Identifiant du sch\u00E9ma",
      "IDENTIFIANT",
      "/Invoice\n/cac:AdditionalDocumentReference\n/cbc:ID\n\n/@schemeID"
    ],
    [
      "1..1",
      "-",
      "-",
      "-",
      "/Invoice\n/cac:AdditionalDocumentReference\n\n/cbc:DocumentTypeCode"
    ],
    [
      "0..1",
      "-",
      "-",
      "-",
      "/Invoice\n\n/cac:ProjectReference"
    ],
    [
      "0..1",
      "",
      "R\u00E9f\u00E9rence de projet",
      "REFERENCE DU DOCUMENT",
      "/Invoice\n/cac:ProjectReference\n\n/cbc:ID"
    ],
    [
      "",
      "-",
      "-",
      "-",
      ""
    ],
    [
      "",
      "-",
      "-",
      "-",
      ""
    ],
    [
      "",
      "-",
      "-",
      "-",
      ""
    ],
    [
      "",
      "-",
      "-",
      "-",
      ""
    ],
    [
      "",
      "-",
      "-",
      "-",
      ""
    ],
    [
      "1..1",
      "",
      "VENDEUR",
      "",
      "/Invoice\n\n/cac:AccountingSupplierParty"
    ],
    [
      "0..1",
      "-",
      "-",
      "-",
      "/Invoice\n/cac:AccountingSupplierParty\n\n/cac:Party"
    ],
    [
      "0..1",
      "BR-FR-13\nBR-FR-22\nBR-FR-23\nBR-FR-25",
      "Adresse \u00E9lectronique du vendeur",
      "IDENTIFIANT",
      "/Invoice\n/cac:AccountingSupplierParty\n/cac:Party\n\n/cbc:EndpointID"
    ],
    [
      "1..1",
      "BR-FR-13\nBR-FR-22\nBR-FR-23\nBR-FR-25",
      "Identifiant du sch\u00E9ma",
      "IDENTIFIANT",
      "/Invoice\n/cac:AccountingSupplierParty\n/cac:Party\n/cbc:EndpointID\n\n/@schemeID"
    ],
    [
      "0..n",
      "-",
      "-",
      "-",
      "/Invoice\n/cac:AccountingSupplierParty\n/cac:Party\n\n/cac:PartyIdentification"
    ],
    [
      "0..n",
      "-",
      "-",
      "-",
      "/Invoice\n/cac:AccountingSupplierParty\n/cac:Party\n/cac:PartyIdentification\n\n/cbc:ID"
    ],
    [
      "0..1",
      "-",
      "-",
      "-",
      "/Invoice\n/cac:AccountingSupplierParty\n/cac:Party\n/cac:PartyIdentification\n/cbc:ID\n\n/@schemeID"
    ],
    [
      "0..n",
      "-",
      "-",
      "-",
      "/Invoice\n/cac:AccountingSupplierParty\n/cac:Party\n\n/cac:PartyIdentification"
    ],
    [
      "0..n",
      "BR-FR-CO-10\nBR-FR-CO-11\nBR-FR-09",
      "Identifiant du vendeur (SIRET)",
      "IDENTIFIANT",
      "/Invoice\n/cac:AccountingSupplierParty\n/cac:Party\n/cac:PartyIdentification\n\n/cbc:ID"
    ],
    [
      "0..1",
      "BR-FR-CO-10\nBR-FR-CO-11\nBR-FR-09",
      "Identifiant du sch\u00E9ma (SIRET)",
      "IDENTIFIANT",
      "/Invoice\n/cac:AccountingSupplierParty\n/cac:Party\n/cac:PartyIdentification\n/cbc:ID\n\n/@schemeID"
    ],
    [
      "0..n",
      "-",
      "-",
      "-",
      "/Invoice\n/cac:AccountingSupplierParty\n/cac:Party\n\n/cac:PartyIdentification"
    ],
    [
      "0..n",
      "BR-FR-CO-10\nBR-FR-CO-11\nBR-FR-24\nBR-FR-26",
      "Identifiant du vendeur (routage)",
      "IDENTIFIANT",
      "/Invoice\n/cac:AccountingSupplierParty\n/cac:Party\n/cac:PartyIdentification\n\n/cbc:ID"
    ],
    [
      "0..1",
      "BR-FR-CO-10\nBR-FR-CO-11\nBR-FR-24\nBR-FR-26",
      "Identifiant du sch\u00E9ma (routage)",
      "IDENTIFIANT",
      "/Invoice\n/cac:AccountingSupplierParty\n/cac:Party\n/cac:PartyIdentification\n/cbc:ID\n\n/@schemeID"
    ],
    [
      "0..n",
      "-",
      "-",
      "-",
      "/Invoice\n/cac:AccountingSupplierParty\n/cac:Party\n\n/cac:PartyIdentification"
    ],
    [
      "0..n",
      "BR-FR-CO-10\nBR-FR-CO-11\nBR-FR-CO-14\nBR-FR-CO-15",
      "Identifiant du vendeur (Assujetti unique)",
      "IDENTIFIANT",
      "/Invoice\n/cac:AccountingSupplierParty\n/cac:Party\n/cac:PartyIdentification\n\n/cbc:ID"
    ],
    [
      "0..1",
      "BR-FR-CO-10\nBR-FR-CO-11\nBR-FR-CO-14",
      "Identifiant du sch\u00E9ma (Assujetti unique)",
      "IDENTIFIANT",
      "/Invoice\n/cac:AccountingSupplierParty\n/cac:Party\n/cac:PartyIdentification\n/cbc:ID\n\n/@schemeID"
    ],
    [
      "0..1",
      "-",
      "-",
      "-",
      "/Invoice\n/cac:AccountingSupplierParty\n/cac:Party\n\n/cac:PartyIdentification"
    ],
    [
      "0..1",
      "",
      "Identifiant bancaire du cr\u00E9ancier",
      "IDENTIFIANT",
      "/Invoice\n/cac:AccountingSupplierParty\n/cac:Party\n/cac:PartyIdentification\n\n/cbc:ID"
    ],
    [
      "0..1",
      "-",
      "-",
      "-",
      "/Invoice\n/cac:AccountingSupplierParty\n/cac:Party\n/cac:PartyIdentification\n/cbc:ID\n\n/@schemeID"
    ],
    [
      "0..1",
      "-",
      "-",
      "-",
      "/Invoice\n/cac:AccountingSupplierParty\n/cac:Party\n\n/cac:PartyName"
    ],
    [
      "0..1",
      "",
      "Appellation commerciale du vendeur",
      "TEXTE",
      "/Invoice\n/cac:AccountingSupplierParty\n/cac:Party\n/cac:PartyName\n\n/cbc:Name"
    ],
    [
      "1..1",
      "",
      "ADRESSE POSTALE DU VENDEUR",
      "",
      "/Invoice\n/cac:AccountingSupplierParty\n/cac:Party\n\n/cac:PostalAddress"
    ],
    [
      "0..1",
      "",
      "Adresse du vendeur - Ligne 1",
      "TEXTE",
      "/Invoice\n/cac:AccountingSupplierParty\n/cac:Party\n/cac:PostalAddress\n\n/cbc:StreetName"
    ],
    [
      "0..1",
      "",
      "Adresse du vendeur - Ligne 2",
      "TEXTE",
      "/Invoice\n/cac:AccountingSupplierParty\n/cac:Party\n/cac:PostalAddress\n\n/cbc:AdditionalStreetName"
    ],
    [
      "0..1",
      "",
      "Localit\u00E9 du vendeur",
      "TEXTE",
      "/Invoice\n/cac:AccountingSupplierParty\n/cac:Party\n/cac:PostalAddress\n\n/cbc:CityName"
    ],
    [
      "0..1",
      "",
      "Code postal du vendeur",
      "TEXTE",
      "/Invoice\n/cac:AccountingSupplierParty\n/cac:Party\n/cac:PostalAddress\n\n/cbc:PostalZone"
    ],
    [
      "0..1",
      "",
      "Subdivision du pays du vendeur",
      "TEXTE",
      "/Invoice\n/cac:AccountingSupplierParty\n/cac:Party\n/cac:PostalAddress\n\n/cbc:CountrySubentity"
    ],
    [
      "0..1",
      "-",
      "-",
      "-",
      "/Invoice\n/cac:AccountingSupplierParty\n/cac:Party\n/cac:PostalAddress\n\n/cac:AddressLine"
    ],
    [
      "0..1",
      "",
      "Adresse du vendeur - Ligne 3",
      "TEXTE",
      "/Invoice\n/cac:AccountingSupplierParty\n/cac:Party\n/cac:PostalAddress\n/cac:AddressLine\n\n/cbc:Line"
    ],
    [
      "1..1",
      "-",
      "-",
      "-",
      "/Invoice\n/cac:AccountingSupplierParty\n/cac:Party\n/cac:PostalAddress\n\n/cac:Country"
    ],
    [
      "1..1",
      "",
      "Code de pays du vendeur",
      "CODE",
      "/Invoice\n/cac:AccountingSupplierParty\n/cac:Party\n/cac:PostalAddress\n/cac:Country\n\n/cbc:IdentificationCode"
    ],
    [
      "0..1",
      "-",
      "-",
      "-",
      "/Invoice\n/cac:AccountingSupplierParty\n/cac:Party\n\n/cac:PartyTaxScheme"
    ],
    [
      "0..1",
      "",
      "Identifiant \u00E0 la TVA du vendeur",
      "IDENTIFIANT",
      "/Invoice\n/cac:AccountingSupplierParty\n/cac:Party\n/cac:PartyTaxScheme\n\n/cbc:CompanyID"
    ],
    [
      "",
      "-",
      "-",
      "-",
      "/Invoice\n/cac:AccountingSupplierParty\n/cac:Party\n/cac:PartyTaxScheme\n\n/cac:TaxScheme"
    ],
    [
      "",
      "",
      "Qualifiant d\u0027Identifiant \u00E0 la TVA du Vendeur",
      "CODE",
      "/Invoice\n/cac:AccountingSupplierParty\n/cac:Party\n/cac:PartyTaxScheme\n/cac:TaxScheme\n\n/cbc:ID"
    ],
    [
      "0..1",
      "-",
      "-",
      "-",
      "/Invoice\n/cac:AccountingSupplierParty\n/cac:Party\n\n/cac:PartyTaxScheme"
    ],
    [
      "0..1",
      "",
      "Identifiant fiscal du vendeur",
      "IDENTIFIANT",
      "/Invoice\n/cac:AccountingSupplierParty\n/cac:Party\n/cac:PartyTaxScheme\n\n/cbc:CompanyID"
    ],
    [
      "",
      "-",
      "-",
      "-",
      "/Invoice\n/cac:AccountingSupplierParty\n/cac:Party\n/cac:PartyTaxScheme\n\n/cac:TaxScheme"
    ],
    [
      "",
      "",
      "Qualifiant d\u0027Identifiant fiscal du Vendeur",
      "CODE",
      "/Invoice\n/cac:AccountingSupplierParty\n/cac:Party\n/cac:PartyTaxScheme\n/cac:TaxScheme\n\n/cbc:ID"
    ],
    [
      "1..1",
      "-",
      "-",
      "-",
      "/Invoice\n/cac:AccountingSupplierParty\n/cac:Party\n\n/cac:PartyLegalEntity"
    ],
    [
      "1..1",
      "",
      "Raison sociale du vendeur",
      "TEXTE",
      "/Invoice\n/cac:AccountingSupplierParty\n/cac:Party\n/cac:PartyLegalEntity\n\n/cbc:RegistrationName"
    ],
    [
      "0..1",
      "BR-FR-10",
      "Num\u00E9ro de SIREN",
      "IDENTIFIANT",
      "/Invoice\n/cac:AccountingSupplierParty\n/cac:Party\n/cac:PartyLegalEntity\n\n/cbc:CompanyID"
    ],
    [
      "0..1",
      "",
      "Identifiant du sch\u00E9ma",
      "IDENTIFIANT",
      "/Invoice\n/cac:AccountingSupplierParty\n/cac:Party\n/cac:PartyLegalEntity\n/cbc:CompanyID\n\n/@schemeID"
    ],
    [
      "0..1",
      "",
      "Forme juridique et capital social pour les soci\u00E9t\u00E9s",
      "TEXTE",
      "/Invoice\n/cac:AccountingSupplierParty\n/cac:Party\n/cac:PartyLegalEntity\n\n/cbc:CompanyLegalForm"
    ],
    [
      "0..1",
      "",
      "CONTACT DU VENDEUR",
      "",
      "/Invoice\n/cac:AccountingSupplierParty\n/cac:Party\n\n/cac:Contact"
    ],
    [
      "0..1",
      "",
      "Point de contact du vendeur",
      "TEXTE",
      "/Invoice\n/cac:AccountingSupplierParty\n/cac:Party\n/cac:Contact\n\n/cbc:Name"
    ],
    [
      "0..1",
      "",
      "Num\u00E9ro de t\u00E9l\u00E9phone du contact du vendeur",
      "TEXTE",
      "/Invoice\n/cac:AccountingSupplierParty\n/cac:Party\n/cac:Contact\n\n/cbc:Telephone"
    ],
    [
      "0..1",
      "",
      "Adresse \u00E9lectronique du contact du vendeur",
      "TEXTE",
      "/Invoice\n/cac:AccountingSupplierParty\n/cac:Party\n/cac:Contact\n\n/cbc:ElectronicMail"
    ],
    [
      "",
      "",
      "AGENT DE VENDEUR (par exemple Tiers VALIDEUR DE LA FACTURE avant \u00E9mission)",
      "",
      "/Invoice\n/cac:AccountingSupplierParty\n/cac:Party\n\n/cac:AgentParty"
    ],
    [
      "",
      "BR-FR-23\nBR-FR-25",
      "Adresse \u00E9lectronique de l\u0027Agent de Vendeur",
      "IDENTIFIANT",
      "/Invoice\n/cac:AccountingSupplierParty\n/cac:Party\n/cac:AgentParty\n\n/cbc:EndpointID"
    ],
    [
      "",
      "BR-FR-23\nBR-FR-25",
      "Identifiant du sch\u00E9ma de l\u0027adresse \u00E9lectronique de l\u0027Agent de Vendeur",
      "IDENTIFIANT",
      "/Invoice\n/cac:AccountingSupplierParty\n/cac:Party\n/cac:AgentParty\n/cbc:EndpointID\n\n/@schemeID"
    ],
    [
      "",
      "",
      "Code du r\u00F4le de l\u0027Agent de Vendeur",
      "CODE",
      "/Invoice\n/cac:AccountingSupplierParty\n/cac:Party\n/cac:AgentParty\n\n/cbc:IndustryClassificationCode"
    ],
    [
      "",
      "-",
      "-",
      "-",
      "/Invoice\n/cac:AccountingSupplierParty\n/cac:Party\n/cac:AgentParty\n\n/cac:PartyIdentification"
    ],
    [
      "",
      "BR-FR-CO-10\nBR-FR-CO-11\nBR-FR-09",
      "Identifiant compl\u00E9mentaire de l\u0027Agent de Vendeur",
      "IDENTIFIANT",
      "/Invoice\n/cac:AccountingSupplierParty\n/cac:Party\n/cac:AgentParty\n/cac:PartyIdentification\n\n/cbc:ID"
    ],
    [
      "",
      "BR-FR-CO-10\nBR-FR-CO-11\nBR-FR-09",
      "Type Identifiant Schema de l\u0027Agent de Vendeur",
      "IDENTIFIANT",
      "/Invoice\n/cac:AccountingSupplierParty\n/cac:Party\n/cac:AgentParty\n/cac:PartyIdentification\n/cbc:ID\n\n/@schemeID"
    ],
    [
      "",
      "-",
      "-",
      "-",
      "/Invoice\n/cac:AccountingSupplierParty\n/cac:Party\n/cac:AgentParty\n\n/cac:PartyName"
    ],
    [
      "",
      "",
      "Appellation commerciale de l\u0027Agent de Vendeur",
      "TEXTE",
      "/Invoice\n/cac:AccountingSupplierParty\n/cac:Party\n/cac:AgentParty\n/cac:PartyName\n\n/cbc:Name"
    ],
    [
      "",
      "",
      "ADRESSE POSTALE DE L\u0027AGENT DE VENDEUR (DU VALIDEUR avant D\u00E9pos\u00E9)",
      "",
      "/Invoice\n/cac:AccountingSupplierParty\n/cac:Party\n/cac:AgentParty\n\n/cac:PostalAddress"
    ],
    [
      "",
      "",
      "Adresse Ligne 1 de l\u0027Agent de Vendeur",
      "TEXTE",
      "/Invoice\n/cac:AccountingSupplierParty\n/cac:Party\n/cac:AgentParty\n/cac:PostalAddress\n\n/cbc:StreetName"
    ],
    [
      "",
      "",
      "Adresse Ligne 2 de l\u0027Agent de Vendeur",
      "TEXTE",
      "/Invoice\n/cac:AccountingSupplierParty\n/cac:Party\n/cac:AgentParty\n/cac:PostalAddress\n\n/cbc:AdditionalStreetName"
    ],
    [
      "",
      "",
      "Ville de l\u0027Agent de Vendeur",
      "TEXTE",
      "/Invoice\n/cac:AccountingSupplierParty\n/cac:Party\n/cac:AgentParty\n/cac:PostalAddress\n\n/cbc:CityName"
    ],
    [
      "",
      "",
      "Code Postal de l\u0027Agent de Vendeur",
      "TEXTE",
      "/Invoice\n/cac:AccountingSupplierParty\n/cac:Party\n/cac:AgentParty\n/cac:PostalAddress\n\n/cbc:PostalZone"
    ],
    [
      "",
      "",
      "Code subdivision Pays de l\u0027Agent de Vendeur",
      "TEXTE",
      "/Invoice\n/cac:AccountingSupplierParty\n/cac:Party\n/cac:AgentParty\n/cac:PostalAddress\n\n/cbc:CountrySubentity"
    ],
    [
      "",
      "-",
      "-",
      "-",
      "/Invoice\n/cac:AccountingSupplierParty\n/cac:Party\n/cac:AgentParty\n/cac:PostalAddress\n\n/cac:AddressLine"
    ],
    [
      "",
      "",
      "Adresse Ligne 3 de l\u0027Agent de Vendeur",
      "TEXTE",
      "/Invoice\n/cac:AccountingSupplierParty\n/cac:Party\n/cac:AgentParty\n/cac:PostalAddress\n/cac:AddressLine\n\n/cbc:Line"
    ],
    [
      "",
      "-",
      "-",
      "-",
      "/Invoice\n/cac:AccountingSupplierParty\n/cac:Party\n/cac:AgentParty\n/cac:PostalAddress\n\n/cac:Country"
    ],
    [
      "",
      "",
      "Code Pays de l\u0027Agent de Vendeur",
      "CODE",
      "/Invoice\n/cac:AccountingSupplierParty\n/cac:Party\n/cac:AgentParty\n/cac:PostalAddress\n/cac:Country\n\n/cbc:IdentificationCode"
    ],
    [
      "",
      "-",
      "-",
      "-",
      "/Invoice\n/cac:AccountingSupplierParty\n/cac:Party\n/cac:AgentParty\n\n/cac:PartyTaxScheme"
    ],
    [
      "",
      "",
      "Identifiant \u00E0 la TVA de l\u0027Agent de Vendeur",
      "IDENTIFIANT",
      "/Invoice\n/cac:AccountingSupplierParty\n/cac:Party\n/cac:AgentParty\n/cac:PartyTaxScheme\n\n/cbc:CompanyID"
    ],
    [
      "",
      "-",
      "-",
      "-",
      "/Invoice\n/cac:AccountingSupplierParty\n/cac:Party\n/cac:AgentParty\n/cac:PartyTaxScheme\n\n/cac:TaxScheme"
    ],
    [
      "",
      "",
      "Scheme d\u0027Identifiant fiscal de l\u0027Agent de Vendeur",
      "CODE",
      "/Invoice\n/cac:AccountingSupplierParty\n/cac:Party\n/cac:AgentParty\n/cac:PartyTaxScheme\n/cac:TaxScheme\n\n/cbc:ID"
    ],
    [
      "",
      "-",
      "-",
      "-",
      "/Invoice\n/cac:AccountingSupplierParty\n/cac:Party\n/cac:AgentParty\n\n/PartyLegalEntity"
    ],
    [
      "",
      "",
      "Nom Raison sociale de l\u0027Agent de Vendeur",
      "TEXTE",
      "/Invoice\n/cac:AccountingSupplierParty\n/cac:Party\n/cac:AgentParty\n/cac:PartyLegalEntity\n\n/cbc:RegistrationName"
    ],
    [
      "",
      "",
      "Numero de SIREN de l\u0027Agent de Vendeur",
      "IDENTIFIANT",
      "/Invoice\n/cac:AccountingSupplierParty\n/cac:Party\n/cac:AgentParty\n/cac:PartyLegalEntity\n\n/cbc:CompanyID"
    ],
    [
      "",
      "",
      "Identifiant du sch\u00E9ma",
      "IDENTIFIANT",
      "/Invoice\n/cac:AccountingSupplierParty\n/cac:Party\n/cac:AgentParty\n/cac:PartyLegalEntity\n/cbc:CompanyID\n\n/@schemeID"
    ],
    [
      "",
      "",
      "CONTACT DE L\u0027AGENT DE VENDEUR (DU VALIDEUR avant D\u00E9pos\u00E9)",
      "",
      "/Invoice\n/cac:AccountingSupplierParty\n/cac:Party\n/cac:AgentParty\n\n/cac:Contact"
    ],
    [
      "",
      "",
      "Nom Contact de l\u0027Agent de Vendeur",
      "TEXTE",
      "/Invoice\n/cac:AccountingSupplierParty\n/cac:Party\n/cac:AgentParty\n/cac:Contact\n\n/cbc:Name"
    ],
    [
      "",
      "",
      "T\u00E9l\u00E9phone contact de l\u0027Agent de Vendeur",
      "TEXTE",
      "/Invoice\n/cac:AccountingSupplierParty\n/cac:Party\n/cac:AgentParty\n/cac:Contact\n\n/cbc:Telephone"
    ],
    [
      "",
      "",
      "Email Contact de l\u0027Agent de Vendeur",
      "TEXTE",
      "/Invoice\n/cac:AccountingSupplierParty\n/cac:Party\n/cac:AgentParty\n/cac:Contact\n\n/cbc:ElectronicMail"
    ],
    [
      "",
      "",
      "TIERS FACTURANT (service facturier)",
      "",
      "/Invoice\n/cac:AccountingSupplierParty\n/cac:Party\n/cac:ServiceProviderParty\n\n/cac:Party"
    ],
    [
      "",
      "BR-FR-23\nBR-FR-25",
      "Adresse \u00E9lectronique du  Facturant (Service Facturier) (adresse de facturation)",
      "IDENTIFIANT",
      "/Invoice\n/cac:AccountingSupplierParty\n/cac:Party\n/cac:ServiceProviderParty\n/cac:Party\n\n/cbc:EndpointID"
    ],
    [
      "",
      "BR-FR-23\nBR-FR-25",
      "Identifiant du sch\u00E9ma de l\u0027adresse \u00E9lectronique du  Facturant (Service Facturier)",
      "IDENTIFIANT",
      "/Invoice\n/cac:AccountingSupplierParty\n/cac:Party\n/cac:ServiceProviderParty\n/cac:Party\n/cbc:EndpointID\n\n/@schemeID"
    ],
    [
      "",
      "",
      "Code du r\u00F4le du Facturant (Service Facturier) ",
      "CODE",
      "/Invoice\n/cac:AccountingSupplierParty\n/cac:Party\n/cac:ServiceProviderParty\n/cac:Party\n\n/cbc:IndustryClassificationCode"
    ],
    [
      "",
      "-",
      "-",
      "-",
      "/Invoice\n/cac:AccountingSupplierParty\n/cac:Party\n/cac:ServiceProviderParty\n/cac:Party\n\n/cac:PartyIdentification"
    ],
    [
      "",
      "BR-FR-CO-10\nBR-FR-CO-11\nBR-FR-09",
      "Identifiant compl\u00E9mentaire du facturant (Service Facturier)",
      "IDENTIFIANT",
      "/Invoice\n/cac:AccountingSupplierParty\n/cac:Party\n/cac:ServiceProviderParty\n/cac:Party\n/cac:PartyIdentification\n\n/cbc:ID"
    ],
    [
      "",
      "BR-FR-CO-10\nBR-FR-CO-11\nBR-FR-09",
      "Identifiant du sch\u00E9ma",
      "IDENTIFIANT",
      "/Invoice\n/cac:AccountingSupplierParty\n/cac:Party\n/cac:ServiceProviderParty\n/cac:Party\n/cac:PartyIdentification\n/cbc:ID\n\n/@schemeID"
    ],
    [
      "",
      "-",
      "-",
      "-",
      "/Invoice\n/cac:AccountingSupplierParty\n/cac:Party\n/cac:ServiceProviderParty\n/cac:Party\n\n/cac:PartyName"
    ],
    [
      "",
      "",
      "Appellation commerciale du Facturant (Service Facturier)",
      "TEXTE",
      "/Invoice\n/cac:AccountingSupplierParty\n/cac:Party\n/cac:ServiceProviderParty\n/cac:Party\n/cac:PartyName\n\n/cbc:Name"
    ],
    [
      "",
      "",
      "ADRESSE POSTALE DU FACTURANT (SERVICE FACTURIER)",
      "",
      "/Invoice\n/cac:AccountingSupplierParty\n/cac:Party\n/cac:ServiceProviderParty\n/cac:Party\n\n/cac:PostalAddress"
    ],
    [
      "",
      "",
      "Adresse du Facturant (Service Facturier)  - Ligne 1",
      "TEXTE",
      "/Invoice\n/cac:AccountingSupplierParty\n/cac:Party\n/cac:ServiceProviderParty\n/cac:Party\n/cac:PostalAddress\n\n/cbc:StreetName"
    ],
    [
      "",
      "",
      "Adresse du Facturant (Service Facturier) - Ligne 2",
      "TEXTE",
      "/Invoice\n/cac:AccountingSupplierParty\n/cac:Party\n/cac:ServiceProviderParty\n/cac:Party\n/cac:PostalAddress\n\n/cbc:AdditionalStreetName"
    ],
    [
      "",
      "",
      "Localit\u00E9 du Facturant (Service Facturier)",
      "TEXTE",
      "/Invoice\n/cac:AccountingSupplierParty\n/cac:Party\n/cac:ServiceProviderParty\n/cac:Party\n/cac:PostalAddress\n\n/cbc:CityName"
    ],
    [
      "",
      "",
      "Code postal du Facturant (Service Facturier)",
      "TEXTE",
      "/Invoice\n/cac:AccountingSupplierParty\n/cac:Party\n/cac:ServiceProviderParty\n/cac:Party\n/cac:PostalAddress\n\n/cbc:PostalZone"
    ],
    [
      "",
      "",
      "Code subdivision Pays du Facturant (Service Facturier)",
      "TEXTE",
      "/Invoice\n/cac:AccountingSupplierParty\n/cac:Party\n/cac:ServiceProviderParty\n/cac:Party\n/cac:PostalAddress\n\n/cbc:CountrySubentity"
    ],
    [
      "",
      "-",
      "-",
      "-",
      "/Invoice\n/cac:AccountingSupplierParty\n/cac:Party\n/cac:ServiceProviderParty\n/cac:Party\n/cac:PostalAddress\n\n/cac:AddressLine"
    ],
    [
      "",
      "",
      "Adresse du Facturant (Service Facturier) - Ligne 3",
      "TEXTE",
      "/Invoice\n/cac:AccountingSupplierParty\n/cac:Party\n/cac:ServiceProviderParty\n/cac:Party\n/cac:PostalAddress\n/cac:AddressLine\n\n/cbc:Line"
    ],
    [
      "",
      "-",
      "-",
      "-",
      "/Invoice\n/cac:AccountingSupplierParty\n/cac:Party\n/cac:ServiceProviderParty\n/cac:Party\n/cac:PostalAddress\n\n/cac:Country"
    ],
    [
      "",
      "",
      "Code de pays du Facturant (Service Facturier)",
      "CODE",
      "/Invoice\n/cac:AccountingSupplierParty\n/cac:Party\n/cac:ServiceProviderParty\n/cac:Party\n/cac:PostalAddress\n/cac:Country\n\n/cbc:IdentificationCode"
    ],
    [
      "",
      "-",
      "-",
      "-",
      "/Invoice\n/cac:AccountingSupplierParty\n/cac:Party\n/cac:ServiceProviderParty\n/cac:Party\n\n/cac:PartyTaxScheme"
    ],
    [
      "",
      "",
      "Identifiant \u00E0 la TVA du  Facturant (Service Facturier)",
      "IDENTIFIANT",
      "/Invoice\n/cac:AccountingSupplierParty\n/cac:Party\n/cac:ServiceProviderParty\n/cac:Party\n/cac:PartyTaxScheme\n\n/cbc:CompanyID"
    ],
    [
      "",
      "-",
      "-",
      "-",
      "/Invoice\n/cac:AccountingSupplierParty\n/cac:Party\n/cac:ServiceProviderParty\n/cac:Party\n/cac:PartyTaxScheme\n\n/cac:TaxScheme"
    ],
    [
      "",
      "",
      "Identifiant \u00E0 la TVA du  Facturant (Service Facturier)",
      "CODE",
      "/Invoice\n/cac:AccountingSupplierParty\n/cac:Party\n/cac:ServiceProviderParty\n/cac:Party\n/cac:PartyTaxScheme\n/cac:TaxScheme\n\n/cbc:ID"
    ],
    [
      "",
      "-",
      "-",
      "-",
      "/Invoice\n/cac:AccountingSupplierParty\n/cac:Party\n/cac:ServiceProviderParty\n/cac:Party\n\n/cac:PartyLegalEntity"
    ],
    [
      "",
      "",
      "Raison sociale du Facturant (Service Facturier) ",
      "TEXTE",
      "/Invoice\n/cac:AccountingSupplierParty\n/cac:Party\n/cac:ServiceProviderParty\n/cac:Party\n/cac:PartyLegalEntity\n\n/cbc:RegistrationName"
    ],
    [
      "",
      "",
      "Numero SIREN du  Facturant (Service Facturier)",
      "IDENTIFIANT",
      "/Invoice\n/cac:AccountingSupplierParty\n/cac:Party\n/cac:ServiceProviderParty\n/cac:Party\n/cac:PartyLegalEntity\n\n/cbc:CompanyID"
    ],
    [
      "",
      "",
      "Identifiant du sch\u00E9ma",
      "IDENTIFIANT",
      "/Invoice\n/cac:AccountingSupplierParty\n/cac:Party\n/cac:ServiceProviderParty\n/cac:Party\n/cac:PartyLegalEntity\n/cbc:CompanyID\n\n/@schemeID"
    ],
    [
      "",
      "",
      "CONTACT DU FACTURANT (SERVICE FACTURIER)",
      "",
      "/Invoice\n/cac:AccountingSupplierParty\n/cac:Party\n/cac:ServiceProviderParty\n/cac:Party\n\n/cac:Contact"
    ],
    [
      "",
      "",
      "Point de contact du Facturant (Service Facturier)",
      "TEXTE",
      "/Invoice\n/cac:AccountingSupplierParty\n/cac:Party\n/cac:ServiceProviderParty\n/cac:Party\n/cac:Contact\n\n/cbc:Name"
    ],
    [
      "",
      "",
      "Num\u00E9ro de t\u00E9l\u00E9phone du contact du Facturant (Service Facturier)",
      "TEXTE",
      "/Invoice\n/cac:AccountingSupplierParty\n/cac:Party\n/cac:ServiceProviderParty\n/cac:Party\n/cac:Contact\n\n/cbc:Telephone"
    ],
    [
      "",
      "",
      "Adresse \u00E9lectronique du contact du Facturant (Service Facturier)",
      "TEXTE",
      "/Invoice\n/cac:AccountingSupplierParty\n/cac:Party\n/cac:ServiceProviderParty\n/cac:Party\n/cac:Contact\n\n/cbc:ElectronicMail"
    ],
    [
      "1..1",
      "",
      "ACHETEUR",
      "",
      "/Invoice\n\n/cac:AccountingCustomerParty"
    ],
    [
      "0..1",
      "-",
      "-",
      "-",
      "/Invoice\n/cac:AccountingCustomerParty\n\n/cac:Party"
    ],
    [
      "0..1",
      "BR-FR-12\nBR-FR-21\nBR-FR-23\nBR-FR-25",
      "Identifiant d\u0027adressage",
      "IDENTIFIANT",
      "/Invoice\n/cac:AccountingCustomerParty\n/cac:Party\n\n/cbc:EndpointID"
    ],
    [
      "1..1",
      "BR-FR-12\nBR-FR-21\nBR-FR-23\nBR-FR-25",
      "Identifiant du sch\u00E9ma de l\u0027identifiant d\u0027adressage",
      "IDENTIFIANT",
      "/Invoice\n/cac:AccountingCustomerParty\n/cac:Party\n/cbc:EndpointID\n\n/@schemeID"
    ],
    [
      "0..1",
      "-",
      "-",
      "-",
      "/Invoice\n/cac:AccountingCustomerParty\n/cac:Party\n\n/cac:PartyIdentification"
    ],
    [
      "0..1",
      "-",
      "-",
      "-",
      "/Invoice\n/cac:AccountingCustomerParty\n/cac:Party\n/cac:PartyIdentification\n\n/cbc:ID"
    ],
    [
      "0..1",
      "-",
      "-",
      "-",
      "/Invoice\n/cac:AccountingCustomerParty\n/cac:Party\n/cac:PartyIdentification\n/cbc:ID\n\n/@schemeID"
    ],
    [
      "0..1",
      "-",
      "-",
      "-",
      "/Invoice\n/cac:AccountingCustomerParty\n/cac:Party\n\n/cac:PartyIdentification"
    ],
    [
      "0..1",
      "BR-FR-CO-10\nBR-FR-CO-11\nBR-FR-09",
      "Identifiant de l\u0027acheteur (SIRET)",
      "IDENTIFIANT",
      "/Invoice\n/cac:AccountingCustomerParty\n/cac:Party\n/cac:PartyIdentification\n\n/cbc:ID"
    ],
    [
      "0..1",
      "BR-FR-CO-10\nBR-FR-CO-11\nBR-FR-09",
      "Identifiant du sch\u00E9ma (SIRET)",
      "IDENTIFIANT",
      "/Invoice\n/cac:AccountingCustomerParty\n/cac:Party\n/cac:PartyIdentification\n/cbc:ID\n\n/@schemeID"
    ],
    [
      "0..1",
      "-",
      "-",
      "-",
      "/Invoice\n/cac:AccountingCustomerParty\n/cac:Party\n\n/cac:PartyIdentification"
    ],
    [
      "0..1",
      "BR-FR-CO-10\nBR-FR-CO-11\nBR-FR-24\nBR-FR-26",
      "Identifiant de l\u0027acheteur (routage)",
      "IDENTIFIANT",
      "/Invoice\n/cac:AccountingCustomerParty\n/cac:Party\n/cac:PartyIdentification\n\n/cbc:ID"
    ],
    [
      "0..1",
      "BR-FR-CO-10\nBR-FR-CO-11\nBR-FR-24\nBR-FR-26",
      "Identifiant du sch\u00E9ma (routage)",
      "IDENTIFIANT",
      "/Invoice\n/cac:AccountingCustomerParty\n/cac:Party\n/cac:PartyIdentification\n/cbc:ID\n\n/@schemeID"
    ],
    [
      "0..1",
      "-",
      "-",
      "-",
      "/Invoice\n/cac:AccountingCustomerParty\n/cac:Party\n\n/cac:PartyName"
    ],
    [
      "0..1",
      "",
      "Appellation commerciale de l\u0027acheteur",
      "TEXTE",
      "/Invoice\n/cac:AccountingCustomerParty\n/cac:Party\n/cac:PartyName\n\n/cbc:Name"
    ],
    [
      "1..1",
      "",
      "ADRESSE POSTALE DE L\u0027ACHETEUR",
      "",
      "/Invoice\n/cac:AccountingCustomerParty\n/cac:Party\n\n/cac:PostalAddress"
    ],
    [
      "0..1",
      "",
      "Adresse de l\u0027acheteur - Ligne 1",
      "TEXTE",
      "/Invoice\n/cac:AccountingCustomerParty\n/cac:Party\n/cac:PostalAddress\n\n/cbc:StreetName"
    ],
    [
      "0..1",
      "",
      "Adresse de l\u0027acheteur - Ligne 2",
      "TEXTE",
      "/Invoice\n/cac:AccountingCustomerParty\n/cac:Party\n/cac:PostalAddress\n\n/cbc:AdditionalStreetName"
    ],
    [
      "0..1",
      "",
      "Localit\u00E9 de l\u0027acheteur",
      "TEXTE",
      "/Invoice\n/cac:AccountingCustomerParty\n/cac:Party\n/cac:PostalAddress\n\n/cbc:CityName"
    ],
    [
      "0..1",
      "",
      "Code postal de l\u0027acheteur",
      "TEXTE",
      "/Invoice\n/cac:AccountingCustomerParty\n/cac:Party\n/cac:PostalAddress\n\n/cbc:PostalZone"
    ],
    [
      "0..1",
      "",
      "Subdivision du pays de l\u0027acheteur",
      "TEXTE",
      "/Invoice\n/cac:AccountingCustomerParty\n/cac:Party\n/cac:PostalAddress\n\n/cbc:CountrySubentity"
    ],
    [
      "0..1",
      "-",
      "-",
      "-",
      "/Invoice\n/cac:AccountingCustomerParty\n/cac:Party\n/cac:PostalAddress\n\n/cac:AddressLine"
    ],
    [
      "0..1",
      "",
      "Adresse de l\u0027acheteur - Ligne 3",
      "TEXTE",
      "/Invoice\n/cac:AccountingCustomerParty\n/cac:Party\n/cac:PostalAddress\n/cac:AddressLine\n\n/cbc:Line"
    ],
    [
      "1..1",
      "-",
      "-",
      "-",
      "/Invoice\n/cac:AccountingCustomerParty\n/cac:Party\n/cac:PostalAddress\n\n/cac:Country"
    ],
    [
      "1..1",
      "",
      "Code de pays de l\u0027acheteur",
      "CODE",
      "/Invoice\n/cac:AccountingCustomerParty\n/cac:Party\n/cac:PostalAddress\n/cac:Country\n\n/cbc:IdentificationCode"
    ],
    [
      "0..1",
      "-",
      "-",
      "-",
      "/Invoice\n/cac:AccountingCustomerParty\n/cac:Party\n\n/cac:PartyTaxScheme"
    ],
    [
      "0..1",
      "",
      "Identifiant \u00E0 la TVA  de l\u0027acheteur",
      "IDENTIFIANT",
      "/Invoice\n/cac:AccountingCustomerParty\n/cac:Party\n/cac:PartyTaxScheme\n\n/cbc:CompanyID"
    ],
    [
      "",
      "-",
      "-",
      "-",
      "/Invoice\n/cac:AccountingCustomerParty\n/cac:Party\n/cac:PartyTaxScheme\n\n/cac:TaxScheme"
    ],
    [
      "",
      "",
      "Qualifiant d\u0027Identifiant fiscal de l\u0027acheteur",
      "CODE",
      "/Invoice\n/cac:AccountingCustomerParty\n/cac:Party\n/cac:PartyTaxScheme\n/cac:TaxScheme\n\n/cbc:ID"
    ],
    [
      "1..1",
      "-",
      "-",
      "-",
      "/Invoice\n/cac:AccountingCustomerParty\n/cac:Party\n\n/cac:PartyLegalEntity"
    ],
    [
      "1..1",
      "",
      "Raison sociale de l\u0027acheteur",
      "TEXTE",
      "/Invoice\n/cac:AccountingCustomerParty\n/cac:Party\n/cac:PartyLegalEntity\n\n/cbc:RegistrationName"
    ],
    [
      "0..1",
      "BR-FR-11",
      "Num\u00E9ro de SIREN",
      "IDENTIFIANT",
      "/Invoice\n/cac:AccountingCustomerParty\n/cac:Party\n/cac:PartyLegalEntity\n\n/cbc:CompanyID"
    ],
    [
      "0..1",
      "",
      "Identifiant du sch\u00E9ma",
      "IDENTIFIANT",
      "/Invoice\n/cac:AccountingCustomerParty\n/cac:Party\n/cac:PartyLegalEntity\n/cbc:CompanyID\n\n/@schemeID"
    ],
    [
      "0..1",
      "",
      "CONTACT DE L\u2019ACHETEUR",
      "",
      "/Invoice\n/cac:AccountingCustomerParty\n/cac:Party\n\n/cac:Contact"
    ],
    [
      "0..1",
      "",
      "Point de contact de l\u2019acheteur",
      "TEXTE",
      "/Invoice\n/cac:AccountingCustomerParty\n/cac:Party\n/cac:Contact\n\n/cbc:Name"
    ],
    [
      "0..1",
      "",
      "Num\u00E9ro de t\u00E9l\u00E9phone du contact de l\u2019acheteur",
      "TEXTE",
      "/Invoice\n/cac:AccountingCustomerParty\n/cac:Party\n/cac:Contact\n\n/cbc:Telephone"
    ],
    [
      "0..1",
      "",
      "Adresse \u00E9lectronique du contact de l\u2019acheteur",
      "TEXTE",
      "/Invoice\n/cac:AccountingCustomerParty\n/cac:Party\n/cac:Contact\n\n/cbc:ElectronicMail"
    ],
    [
      "",
      "",
      "AGENT D\u0027ACHETEUR (Agence media, Tiers valideur cot\u00E9 Acheteur)",
      "",
      "/Invoice\n/cac:AccountingCustomerParty\n/cac:Party\n\n/cac:AgentParty"
    ],
    [
      "",
      "BR-FR-23\nBR-FR-25",
      "Adresse \u00E9lectronique de l\u0027Agent de l\u0027Acheteur",
      "IDENTIFIANT",
      "/Invoice\n/cac:AccountingCustomerParty\n/cac:Party\n/cac:AgentParty\n\n/cbc:EndpointID"
    ],
    [
      "",
      "BR-FR-23\nBR-FR-25",
      "Identifiant du sch\u00E9ma de l\u0027adresse \u00E9lectronique de l\u0027Agent de l\u0027Acheteur",
      "IDENTIFIANT",
      "/Invoice\n/cac:AccountingCustomerParty\n/cac:Party\n/cac:AgentParty\n/cbc:EndpointID\n\n/@schemeID"
    ],
    [
      "",
      "",
      "Code du r\u00F4le de l\u0027Agent de l\u0027Acheteur",
      "CODE",
      "/Invoice\n/cac:AccountingCustomerParty\n/cac:Party\n/cac:AgentParty\n\n/cbc:IndustryClassificationCode"
    ],
    [
      "",
      "-",
      "-",
      "-",
      "/Invoice\n/cac:AccountingCustomerParty\n/cac:Party\n/cac:AgentParty\n\n/cac:PartyIdentification"
    ],
    [
      "",
      "BR-FR-CO-10\nBR-FR-CO-11\nBR-FR-09",
      "Identifiant compl\u00E9mentaire de l\u0027Agent de l\u0027Acheteur",
      "IDENTIFIANT",
      "/Invoice\n/cac:AccountingCustomerParty\n/cac:Party\n/cac:AgentParty\n/cac:PartyIdentification\n\n/cbc:ID"
    ],
    [
      "",
      "BR-FR-CO-10\nBR-FR-CO-11\nBR-FR-09",
      "Identifiant du sch\u00E9ma",
      "IDENTIFIANT",
      "/Invoice\n/cac:AccountingCustomerParty\n/cac:Party\n/cac:AgentParty\n/cac:PartyIdentification\n/cbc:ID\n\n/@schemeID"
    ],
    [
      "",
      "-",
      "-",
      "-",
      "/Invoice\n/cac:AccountingCustomerParty\n/cac:Party\n/cac:AgentParty\n\n/cac:PartyName"
    ],
    [
      "",
      "",
      "Appellation commerciale de l\u0027Agent de l\u0027Acheteur",
      "TEXTE",
      "/Invoice\n/cac:AccountingCustomerParty\n/cac:Party\n/cac:AgentParty\n/cac:PartyName\n\n/cbc:Name"
    ],
    [
      "",
      "",
      "ADRESSE POSTALE DE L\u0027AGENT DE L\u0027ACHETEUR",
      "",
      "/Invoice\n/cac:AccountingCustomerParty\n/cac:Party\n/cac:AgentParty\n\n/cac:PostalAddress"
    ],
    [
      "",
      "",
      "Adresse Ligne 1 de l\u0027Agent de l\u0027Acheteur",
      "TEXTE",
      "/Invoice\n/cac:AccountingCustomerParty\n/cac:Party\n/cac:AgentParty\n/cac:PostalAddress\n\n/cbc:StreetName"
    ],
    [
      "",
      "",
      "Adresse Ligne 2 de l\u0027Agent de l\u0027Acheteur",
      "TEXTE",
      "/Invoice\n/cac:AccountingCustomerParty\n/cac:Party\n/cac:AgentParty\n/cac:PostalAddress\n\n/cbc:AdditionalStreetName"
    ],
    [
      "",
      "",
      "Ville de l\u0027Agent de l\u0027Acheteur",
      "TEXTE",
      "/Invoice\n/cac:AccountingCustomerParty\n/cac:Party\n/cac:AgentParty\n/cac:PostalAddress\n\n/cbc:CityName"
    ],
    [
      "",
      "",
      "Code Postal de l\u0027Agent de l\u0027Acheteur",
      "TEXTE",
      "/Invoice\n/cac:AccountingCustomerParty\n/cac:Party\n/cac:AgentParty\n/cac:PostalAddress\n\n/cbc:PostalZone"
    ],
    [
      "",
      "",
      "Code subdivision Pays de l\u0027Agent de l\u0027Acheteur",
      "TEXTE",
      "/Invoice\n/cac:AccountingCustomerParty\n/cac:Party\n/cac:AgentParty\n/cac:PostalAddress\n\n/cbc:CountrySubentity"
    ],
    [
      "",
      "-",
      "-",
      "-",
      "/Invoice\n/cac:AccountingCustomerParty\n/cac:Party\n/cac:AgentParty\n/cac:PostalAddress\n\n/cac:AddressLine"
    ],
    [
      "",
      "",
      "Adresse Ligne 3 de l\u0027Agent de l\u0027Acheteur",
      "TEXTE",
      "/Invoice\n/cac:AccountingCustomerParty\n/cac:Party\n/cac:AgentParty\n/cac:PostalAddress\n/cac:AddressLine\n\n/cbc:Line"
    ],
    [
      "",
      "-",
      "-",
      "-",
      "/Invoice\n/cac:AccountingCustomerParty\n/cac:Party\n/cac:AgentParty\n/cac:PostalAddress\n\n/cac:Country"
    ],
    [
      "",
      "",
      "Code Pays de l\u0027Agent de l\u0027Acheteur",
      "CODE",
      "/Invoice\n/cac:AccountingCustomerParty\n/cac:Party\n/cac:AgentParty\n/cac:PostalAddress\n/cac:Country\n\n/cbc:IdentificationCode"
    ],
    [
      "",
      "-",
      "-",
      "-",
      "/Invoice\n/cac:AccountingCustomerParty\n/cac:Party\n/cac:AgentParty\n\n/cac:PartyTaxScheme"
    ],
    [
      "",
      "",
      "Identifiant \u00E0 la TVA de l\u0027Agent de l\u0027Acheteur",
      "IDENTIFIANT",
      "/Invoice\n/cac:AccountingCustomerParty\n/cac:Party\n/cac:AgentParty\n/cac:PartyTaxScheme\n\n/cbc:CompanyID"
    ],
    [
      "",
      "-",
      "-",
      "-",
      "/Invoice\n/cac:AccountingCustomerParty\n/cac:Party\n/cac:AgentParty\n/cac:PartyTaxScheme\n\n/cac:TaxScheme"
    ],
    [
      "",
      "",
      "Identifiant de sch\u00E9ma fiscal de l\u0027Agent de l\u0027Acheteur",
      "CODE",
      "/Invoice\n/cac:AccountingCustomerParty\n/cac:Party\n/cac:AgentParty\n/cac:PartyTaxScheme\n/cac:TaxScheme\n\n/cbc:ID"
    ],
    [
      "",
      "-",
      "-",
      "-",
      "/Invoice\n/cac:AccountingCustomerParty\n/cac:Party\n/cac:AgentParty\n\n/cac:PartyLegalEntity"
    ],
    [
      "",
      "",
      "Nom Raison sociale de l\u0027Agent de l\u0027Acheteur",
      "TEXTE",
      "/Invoice\n/cac:AccountingCustomerParty\n/cac:Party\n/cac:AgentParty\n/cac:PartyLegalEntity\n\n/cbc:RegistrationName"
    ],
    [
      "",
      "",
      "Numero de SIREN de l\u0027Agent de l\u0027Acheteur",
      "IDENTIFIANT",
      "/Invoice\n/cac:AccountingCustomerParty\n/cac:Party\n/cac:AgentParty\n/cac:PartyLegalEntity\n\n/cbc:CompanyID"
    ],
    [
      "",
      "",
      "Identifiant du sch\u00E9ma",
      "IDENTIFIANT",
      "/Invoice\n/cac:AccountingCustomerParty\n/cac:Party\n/cac:AgentParty\n/cac:PartyLegalEntity\n/cbc:CompanyID\n\n/@schemeID"
    ],
    [
      "",
      "",
      "CONTACT DE L\u0027AGENT DE L\u0027ACHETEUR",
      "",
      "/Invoice\n/cac:AccountingCustomerParty\n/cac:Party\n/cac:AgentParty\n\n/cac:Contact"
    ],
    [
      "",
      "",
      "Nom Contact de l\u0027Agent de l\u0027Acheteur",
      "TEXTE",
      "/Invoice\n/cac:AccountingCustomerParty\n/cac:Party\n/cac:AgentParty\n/cac:Contact\n\n/cbc:Name"
    ],
    [
      "",
      "",
      "T\u00E9l\u00E9phone contact de l\u0027Agent de l\u0027Acheteur",
      "TEXTE",
      "/Invoice\n/cac:AccountingCustomerParty\n/cac:Party\n/cac:AgentParty\n/cac:Contact\n\n/cbc:Telephone"
    ],
    [
      "",
      "",
      "Email Contact de l\u0027Agent de l\u0027Acheteur",
      "TEXTE",
      "/Invoice\n/cac:AccountingCustomerParty\n/cac:Party\n/cac:AgentParty\n/cac:Contact\n\n/cbc:ElectronicMail"
    ],
    [
      "",
      "",
      "ADRESS\u00C9E \u00C0",
      "",
      "/Invoice\n/cac:AccountingCustomerParty\n/cac:Party\n/cac:ServiceProviderParty\n\n/cac:Party"
    ],
    [
      "",
      "BR-FR-23\nBR-FR-25",
      "Identifiant d\u0027adressage",
      "IDENTIFIANT",
      "/Invoice\n/cac:AccountingCustomerParty\n/cac:Party\n/cac:ServiceProviderParty\n/cac:Party\n\n/cbc:EndpointID"
    ],
    [
      "",
      "BR-FR-23\nBR-FR-25",
      "Identifiant du sch\u00E9ma de l\u0027identifiant d\u0027adressage",
      "IDENTIFIANT",
      "/Invoice\n/cac:AccountingCustomerParty\n/cac:Party\n/cac:ServiceProviderParty\n/cac:Party\n/cbc:EndpointID\n\n/@schemeID"
    ],
    [
      "",
      "",
      "Code du r\u00F4le",
      "CODE",
      "/Invoice\n/cac:AccountingCustomerParty\n/cac:Party\n/cac:ServiceProviderParty\n/cac:Party\n\n/cbc:IndustryClassificationCode"
    ],
    [
      "",
      "-",
      "-",
      "-",
      "/Invoice\n/cac:AccountingCustomerParty\n/cac:Party\n/cac:ServiceProviderParty\n/cac:Party\n\n/cac:PartyIdentification"
    ],
    [
      "",
      "BR-FR-CO-10\nBR-FR-CO-11\nBR-FR-09",
      "Identifiant compl\u00E9mentaire de l\u0027adress\u00E9e \u00E0",
      "IDENTIFIANT",
      "/Invoice\n/cac:AccountingCustomerParty\n/cac:Party\n/cac:ServiceProviderParty\n/cac:Party\n/cac:PartyIdentification\n\n/cbc:ID"
    ],
    [
      "",
      "BR-FR-CO-10\nBR-FR-CO-11\nBR-FR-09",
      "Identifiant du sch\u00E9ma",
      "IDENTIFIANT",
      "/Invoice\n/cac:AccountingCustomerParty\n/cac:Party\n/cac:ServiceProviderParty\n/cac:Party\n/cac:PartyIdentification\n/cbc:ID\n\n/@schemeID"
    ],
    [
      "",
      "-",
      "-",
      "-",
      "/Invoice\n/cac:AccountingCustomerParty\n/cac:Party\n/cac:ServiceProviderParty\n/cac:Party\n\n/cac:PartyName"
    ],
    [
      "",
      "",
      "Appellation commerciale",
      "TEXTE",
      "/Invoice\n/cac:AccountingCustomerParty\n/cac:Party\n/cac:ServiceProviderParty\n/cac:Party\n/cac:PartyName\n\n/cbc:Name"
    ],
    [
      "",
      "",
      "ADRESSE POSTALE",
      "",
      "/Invoice\n/cac:AccountingCustomerParty\n/cac:Party\n/cac:ServiceProviderParty\n/cac:Party\n\n/cac:PostalAddress"
    ],
    [
      "",
      "",
      "Adresse - Ligne 1",
      "TEXTE",
      "/Invoice\n/cac:AccountingCustomerParty\n/cac:Party\n/cac:ServiceProviderParty\n/cac:Party\n/cac:PostalAddress\n\n/cbc:StreetName"
    ],
    [
      "",
      "",
      "Adresse - Ligne 2",
      "TEXTE",
      "/Invoice\n/cac:AccountingCustomerParty\n/cac:Party\n/cac:ServiceProviderParty\n/cac:Party\n/cac:PostalAddress\n\n/cbc:AdditionalStreetName"
    ],
    [
      "",
      "",
      "Localit\u00E9",
      "TEXTE",
      "/Invoice\n/cac:AccountingCustomerParty\n/cac:Party\n/cac:ServiceProviderParty\n/cac:Party\n/cac:PostalAddress\n\n/cbc:CityName"
    ],
    [
      "",
      "",
      "Code postal",
      "TEXTE",
      "/Invoice\n/cac:AccountingCustomerParty\n/cac:Party\n/cac:ServiceProviderParty\n/cac:Party\n/cac:PostalAddress\n\n/cbc:PostalZone"
    ],
    [
      "",
      "",
      "Code subdivision Pays",
      "TEXTE",
      "/Invoice\n/cac:AccountingCustomerParty\n/cac:Party\n/cac:ServiceProviderParty\n/cac:Party\n/cac:PostalAddress\n\n/cbc:CountrySubentity"
    ],
    [
      "",
      "-",
      "-",
      "-",
      "/Invoice\n/cac:AccountingCustomerParty\n/cac:Party\n/cac:ServiceProviderParty\n/cac:Party\n/cac:PostalAddress\n\n/cac:AddressLine"
    ],
    [
      "",
      "",
      "Adresse - Ligne 3",
      "TEXTE",
      "/Invoice\n/cac:AccountingCustomerParty\n/cac:Party\n/cac:ServiceProviderParty\n/cac:Party\n/cac:PostalAddress\n/cac:AddressLine\n\n/cbc:Line"
    ],
    [
      "",
      "-",
      "-",
      "-",
      "/Invoice\n/cac:AccountingCustomerParty\n/cac:Party\n/cac:ServiceProviderParty\n/cac:Party\n/cac:PostalAddress\n\n/cac:Country"
    ],
    [
      "",
      "",
      "Code de pays",
      "CODE",
      "/Invoice\n/cac:AccountingCustomerParty\n/cac:Party\n/cac:ServiceProviderParty\n/cac:Party\n/cac:PostalAddress\n/cac:Country\n\n/cbc:IdentificationCode"
    ],
    [
      "",
      "-",
      "-",
      "-",
      "/Invoice\n/cac:AccountingCustomerParty\n/cac:Party\n/cac:ServiceProviderParty\n/cac:Party\n\n/cac:PartyTaxScheme"
    ],
    [
      "",
      "",
      "Identifiant \u00E0 la TVA",
      "IDENTIFIANT",
      "/Invoice\n/cac:AccountingCustomerParty\n/cac:Party\n/cac:ServiceProviderParty\n/cac:Party\n/cac:PartyTaxScheme\n\n/cbc:CompanyID"
    ],
    [
      "",
      "-",
      "-",
      "-",
      "/Invoice\n/cac:AccountingCustomerParty\n/cac:Party\n/cac:ServiceProviderParty\n/cac:Party\n/cac:PartyTaxScheme\n\n/cac:TaxScheme"
    ],
    [
      "",
      "",
      "Qualifiant d\u0027Identifiant fiscal",
      "CODE",
      "/Invoice\n/cac:AccountingCustomerParty\n/cac:Party\n/cac:ServiceProviderParty\n/cac:Party\n/cac:PartyTaxScheme\n/cac:TaxScheme\n\n/cbc:ID"
    ],
    [
      "",
      "-",
      "-",
      "-",
      "/Invoice\n/cac:AccountingCustomerParty\n/cac:Party\n/cac:ServiceProviderParty\n/cac:Party\n\n/cac:AgentPartyLegalEntity"
    ],
    [
      "",
      "",
      "Raison sociale",
      "TEXTE",
      "/Invoice\n/cac:AccountingCustomerParty\n/cac:Party\n/cac:ServiceProviderParty\n/cac:Party\n/cac:PartyLegalEntity\n\n/cbc:RegistrationName"
    ],
    [
      "",
      "",
      "Num\u00E9ro SIREN",
      "IDENTIFIANT",
      "/Invoice\n/cac:AccountingCustomerParty\n/cac:Party\n/cac:ServiceProviderParty\n/cac:Party\n/cac:PartyLegalEntity\n\n/cbc:CompanyID"
    ],
    [
      "",
      "",
      "Identifiant du sch\u00E9ma",
      "IDENTIFIANT",
      "/Invoice\n/cac:AccountingCustomerParty\n/cac:Party\n/cac:ServiceProviderParty\n/cac:Party\n/cac:PartyLegalEntity\n/cbc:CompanyID\n\n/@schemeID"
    ],
    [
      "",
      "",
      "CONTACT",
      "",
      "/Invoice\n/cac:AccountingCustomerParty\n/cac:Party\n/cac:ServiceProviderParty\n/cac:Party\n\n/cac:Contact"
    ],
    [
      "",
      "",
      "Point de contact",
      "TEXTE",
      "/Invoice\n/cac:AccountingCustomerParty\n/cac:Party\n/cac:ServiceProviderParty\n/cac:Party\n/cac:Contact\n\n/cbc:Name"
    ],
    [
      "",
      "",
      "Num\u00E9ro de t\u00E9l\u00E9phone du contact",
      "TEXTE",
      "/Invoice\n/cac:AccountingCustomerParty\n/cac:Party\n/cac:ServiceProviderParty\n/cac:Party\n/cac:Contact\n\n/cbc:Telephone"
    ],
    [
      "",
      "",
      "Adresse \u00E9lectronique du contact",
      "TEXTE",
      "/Invoice\n/cac:AccountingCustomerParty\n/cac:Party\n/cac:ServiceProviderParty\n/cac:Party\n/cac:Contact\n\n/cbc:ElectronicMail"
    ],
    [
      "0..1",
      "",
      "B\u00C9N\u00C9FICIAIRE",
      "",
      "/Invoice\n\n/cac:PayeeParty"
    ],
    [
      "",
      "BR-FR-23\nBR-FR-25",
      "Adresse \u00E9lectronique du B\u00E9n\u00E9ficiaire",
      "IDENTIFIANT",
      "/Invoice\n/cac:PayeeParty\n\n/cbc:EndpointID"
    ],
    [
      "",
      "BR-FR-23\nBR-FR-25",
      "Identifiant du sch\u00E9ma de l\u0027adresse \u00E9lectronique du B\u00E9n\u00E9ficiaire",
      "IDENTIFIANT",
      "/Invoice\n/cac:PayeeParty\n/cbc:EndpointID\n\n/@schemeID"
    ],
    [
      "",
      "",
      "Code du r\u00F4le du b\u00E9n\u00E9ficiaire",
      "CODE",
      "/Invoice\n/cac:PayeeParty\n\n/cbc:IndustryClassificationCode"
    ],
    [
      "0..1",
      "-",
      "-",
      "-",
      "/Invoice\n/cac:PayeeParty\n\n/cac:PartyIdentification"
    ],
    [
      "0..1",
      "BR-FR-CO-10\nBR-FR-CO-11\nBR-FR-09",
      "Identifiant du compl\u00E9mentaire du b\u00E9n\u00E9ficiaire",
      "IDENTIFIANT",
      "/Invoice\n/cac:PayeeParty\n/cac:PartyIdentification\n\n/cbc:ID"
    ],
    [
      "0..1",
      "BR-FR-CO-10\nBR-FR-CO-11\nBR-FR-09",
      "Identifiant du sch\u00E9ma",
      "IDENTIFIANT",
      "/Invoice\n/cac:PayeeParty\n/cac:PartyIdentification\n/cbc:ID\n\n/@schemeID"
    ],
    [
      "0..1",
      "-",
      "-",
      "-",
      "/Invoice\n/cac:PayeeParty\n\n/cac:PartyIdentification"
    ],
    [
      "0..1",
      "",
      "Identifiant bancaire du cr\u00E9ancier",
      "IDENTIFIANT",
      "/Invoice\n/cac:PayeeParty\n/cac:PartyIdentification\n\n/cbc:ID"
    ],
    [
      "0..1",
      "-",
      "-",
      "-",
      "/Invoice\n/cac:PayeeParty\n/cac:PartyIdentification\n/cbc:ID\n\n/@schemeID"
    ],
    [
      "1..1",
      "-",
      "-",
      "-",
      "/Invoice\n/cac:PayeeParty\n\n/cac:PartyName"
    ],
    [
      "1..1",
      "",
      "Nom du b\u00E9n\u00E9ficiaire",
      "TEXTE",
      "/Invoice\n/cac:PayeeParty\n/cac:PartyName\n\n/cbc:Name"
    ],
    [
      "",
      "",
      "ADRESSE POSTALE DU B\u00C9N\u00C9FICIAIRE",
      "",
      "/Invoice\n/cac:PayeeParty\n\n/cac:PostalAddress"
    ],
    [
      "",
      "",
      "Adresse de B\u00E9n\u00E9ficiaire - Ligne 1",
      "TEXTE",
      "/Invoice\n/cac:PayeeParty\n/cac:PostalAddress\n\n/cbc:StreetName"
    ],
    [
      "",
      "",
      "Adresse du B\u00E9n\u00E9ficiaire - Ligne 2",
      "TEXTE",
      "/Invoice\n/cac:PayeeParty\n/cac:PostalAddress\n\n/cbc:AdditionalStreetName"
    ],
    [
      "",
      "",
      "Localit\u00E9 du B\u00E9n\u00E9ficiaire",
      "TEXTE",
      "/Invoice\n/cac:PayeeParty\n/cac:PostalAddress\n\n/cbc:CityName"
    ],
    [
      "",
      "",
      "Code postal du B\u00E9n\u00E9ficiaire",
      "TEXTE",
      "/Invoice\n/cac:PayeeParty\n/cac:PostalAddress\n\n/cbc:PostalZone"
    ],
    [
      "",
      "",
      "Subdivision du pays du B\u00E9n\u00E9ficiaire",
      "TEXTE",
      "/Invoice\n/cac:PayeeParty\n/cac:PostalAddress\n\n/cbc:CountrySubentity"
    ],
    [
      "",
      "-",
      "-",
      "-",
      "/Invoice\n/cac:PayeeParty\n/cac:PostalAddress\n\n/cac:AddressLine"
    ],
    [
      "",
      "",
      "Adresse du B\u00E9n\u00E9ficiaire - Ligne 3",
      "TEXTE",
      "/Invoice\n/cac:PayeeParty\n/cac:PostalAddress\n/cac:AddressLine\n\n/cbc:Line"
    ],
    [
      "",
      "-",
      "-",
      "-",
      "/Invoice\n/cac:PayeeParty\n/cac:PostalAddress\n\n/cac:Country"
    ],
    [
      "",
      "",
      "Code de pays du B\u00E9n\u00E9ficiaire",
      "CODE",
      "/Invoice\n/cac:PayeeParty\n/cac:PostalAddress\n/cac:Country\n\n/cbc:IdentificationCode"
    ],
    [
      "",
      "-",
      "-",
      "-",
      "/Invoice\n/cac:PayeeParty\n\n/cac:PartyTaxScheme"
    ],
    [
      "",
      "",
      "Identifiant \u00E0 la TVA du B\u00E9n\u00E9ficiaire",
      "IDENTIFIANT",
      "/Invoice\n/cac:PayeeParty\n/cac:PartyTaxScheme\n\n/cbc:CompanyID"
    ],
    [
      "",
      "-",
      "-",
      "-",
      "/Invoice\n/cac:PayeeParty\n/cac:PartyTaxScheme\n\n/cac:TaxScheme"
    ],
    [
      "",
      "",
      "Identifiant du sch\u00E9ma \u00E0 la TVA du\u00A0B\u00E9n\u00E9ficiaire\u00A0",
      "CODE",
      "/Invoice\n/cac:PayeeParty\n/cac:PartyTaxScheme\n/cac:TaxScheme\n\n/cbc:ID"
    ],
    [
      "0..1",
      "-",
      "-",
      "-",
      "/Invoice\n/cac:PayeeParty\n\n/cac:PartyLegalEntity"
    ],
    [
      "0..1",
      "",
      "Identifiant d\u2019enregistrement l\u00E9gal du b\u00E9n\u00E9ficiaire",
      "IDENTIFIANT",
      "/Invoice\n/cac:PayeeParty\n/cac:PartyLegalEntity\n\n/cbc:CompanyID"
    ],
    [
      "0..1",
      "",
      "Identifiant du sch\u00E9ma",
      "IDENTIFIANT",
      "/Invoice\n/cac:PayeeParty\n/cac:PartyLegalEntity\n/cbc:CompanyID\n\n/@schemeID"
    ],
    [
      "",
      "",
      "CONTACT DU B\u00C9N\u00C9FICIAIRE",
      "",
      "/Invoice\n/cac:PayeeParty\n\n/cac:Contact"
    ],
    [
      "",
      "",
      "Point de contact du B\u00E9n\u00E9ficiaire",
      "TEXTE",
      "/Invoice\n/cac:PayeeParty\n/cac:Contact\n\n/cbc:Name"
    ],
    [
      "",
      "",
      "Num\u00E9ro t\u00E9l\u00E9phone contact du B\u00E9n\u00E9ficiaire",
      "TEXTE",
      "/Invoice\n/cac:PayeeParty\n/cac:Contact\n\n/cbc:Telephone"
    ],
    [
      "",
      "",
      "Adresse \u00E9lectronique contact du B\u00E9n\u00E9ficiaire",
      "TEXTE",
      "/Invoice\n/cac:PayeeParty\n/cac:Contact\n\n/cbc:ElectronicMail"
    ],
    [
      "0..1",
      "BR-FR-CO-15",
      "REPR\u00C9SENTANT FISCAL DU VENDEUR",
      "",
      "/Invoice\n\n/cac:TaxRepresentativeParty"
    ],
    [
      "1..1",
      "-",
      "-",
      "-",
      "/Invoice\n/cac:TaxRepresentativeParty\n\n/cac:PartyName"
    ],
    [
      "1..1",
      "",
      "Nom du repr\u00E9sentant fiscal du vendeur",
      "TEXTE",
      "/Invoice\n/cac:TaxRepresentativeParty\n/cac:PartyName\n\n/cbc:Name"
    ],
    [
      "1..1",
      "",
      "ADRESSE POSTALE DU REPR\u00C9SENTANT FISCAL DU VENDEUR",
      "",
      "/Invoice\n/cac:TaxRepresentativeParty\n\n/cac:PostalAddress"
    ],
    [
      "0..1",
      "",
      "Adresse du repr\u00E9sentant fiscal - Ligne 1",
      "TEXTE",
      "/Invoice\n/cac:TaxRepresentativeParty\n/cac:PostalAddress\n\n/cbc:StreetName"
    ],
    [
      "0..1",
      "",
      "Adresse du repr\u00E9sentant fiscal - Ligne 2",
      "TEXTE",
      "/Invoice\n/cac:TaxRepresentativeParty\n/cac:PostalAddress\n\n/cbc:AdditionalStreetName"
    ],
    [
      "0..1",
      "",
      "Localit\u00E9 du repr\u00E9sentant fiscal",
      "TEXTE",
      "/Invoice\n/cac:TaxRepresentativeParty\n/cac:PostalAddress\n\n/cbc:CityName"
    ],
    [
      "0..1",
      "",
      "Code postal du repr\u00E9sentant fiscal",
      "TEXTE",
      "/Invoice\n/cac:TaxRepresentativeParty\n/cac:PostalAddress\n\n/cbc:PostalZone"
    ],
    [
      "0..1",
      "",
      "Subdivision du pays du repr\u00E9sentant fiscal",
      "TEXTE",
      "/Invoice\n/cac:TaxRepresentativeParty\n/cac:PostalAddress\n\n/cbc:CountrySubentity"
    ],
    [
      "0..1",
      "-",
      "-",
      "-",
      "/Invoice\n/cac:TaxRepresentativeParty\n/cac:PostalAddress\n\n/cac:AddressLine"
    ],
    [
      "0..1",
      "",
      "Adresse du repr\u00E9sentant fiscal - Ligne 3",
      "TEXTE",
      "/Invoice\n/cac:TaxRepresentativeParty\n/cac:PostalAddress\n/cac:AddressLine\n\n/cbc:Line"
    ],
    [
      "1..1",
      "-",
      "-",
      "-",
      "/Invoice\n/cac:TaxRepresentativeParty\n/cac:PostalAddress\n\n/cac:Country"
    ],
    [
      "1..1",
      "",
      "Code de pays du repr\u00E9sentant fiscal",
      "CODE",
      "/Invoice\n/cac:TaxRepresentativeParty\n/cac:PostalAddress\n/cac:Country\n\n/cbc:IdentificationCode"
    ],
    [
      "1..1",
      "-",
      "-",
      "-",
      "/Invoice\n/cac:TaxRepresentativeParty\n\n/cac:PartyTaxScheme"
    ],
    [
      "1..1",
      "",
      "Identifiant \u00E0 la TVA du repr\u00E9sentant fiscal du vendeur",
      "IDENTIFIANT",
      "/Invoice\n/cac:TaxRepresentativeParty\n/cac:PartyTaxScheme\n\n/cbc:CompanyID"
    ],
    [
      "",
      "-",
      "-",
      "-",
      "/Invoice\n/cac:TaxRepresentativeParty\n/cac:PartyTaxScheme\n\n/cac:TaxScheme"
    ],
    [
      "",
      "",
      "Identifiant du sch\u00E9ma de l\u0027identifiant TVA du repr\u00E9sentant fiscal\u00A0",
      "CODE",
      "/Invoice\n/cac:TaxRepresentativeParty\n/cac:PartyTaxScheme\n/cac:TaxScheme\n\n/cbc:ID"
    ],
    [
      "0..1",
      "",
      "INFORMATIONS DE LIVRAISON",
      "",
      "/Invoice\n\n/cac:Delivery"
    ],
    [
      "0..1",
      "BR-FR-03",
      "Date effective de livraison",
      "DATE",
      "/Invoice\n/cac:Delivery\n\n/cbc:ActualDeliveryDate"
    ],
    [
      "0..1",
      "-",
      "-",
      "-",
      "/Invoice\n/cac:Delivery\n\n/cac:DeliveryLocation"
    ],
    [
      "0..1",
      "",
      "Identifiant de l\u0027\u00E9tablissement de livraison",
      "IDENTIFIANT",
      "/Invoice\n/cac:Delivery\n/cac:DeliveryLocation\n\n/cbc:ID"
    ],
    [
      "0..1",
      "",
      "Identifiant du sch\u00E9ma de l\u0027\u00E9tablissement de livraison",
      "IDENTIFIANT",
      "/Invoice\n/cac:Delivery\n/cac:DeliveryLocation\n/cbc:ID\n\n/@schemeID"
    ],
    [
      "0..1",
      "",
      "ADRESSE DE LIVRAISON",
      "",
      "/Invoice\n/cac:Delivery\n/cac:DeliveryLocation\n\n/cac:Address"
    ],
    [
      "0..1",
      "",
      "Adresse de livraison  - Ligne 1",
      "TEXTE",
      "/Invoice\n/cac:Delivery\n/cac:DeliveryLocation\n/cac:Address\n\n/cbc:StreetName"
    ],
    [
      "0..1",
      "",
      "Adresse de livraison - Ligne 2",
      "TEXTE",
      "/Invoice\n/cac:Delivery\n/cac:DeliveryLocation\n/cac:Address\n\n/cbc:AdditionalStreetName"
    ],
    [
      "0..1",
      "",
      "Localit\u00E9 Adresse de livraison",
      "TEXTE",
      "/Invoice\n/cac:Delivery\n/cac:DeliveryLocation\n/cac:Address\n\n/cbc:CityName"
    ],
    [
      "0..1",
      "",
      "Code postal Adresse de livraison",
      "TEXTE",
      "/Invoice\n/cac:Delivery\n/cac:DeliveryLocation\n/cac:Address\n\n/cbc:PostalZone"
    ],
    [
      "0..1",
      "",
      "Subdivision du pays ",
      "TEXTE",
      "/Invoice\n/cac:Delivery\n/cac:DeliveryLocation\n/cac:Address\n\n/cbc:CountrySubentity"
    ],
    [
      "0..1",
      "-",
      "-",
      "-",
      "/Invoice\n/cac:Delivery\n/cac:DeliveryLocation\n/cac:Address\n\n/cac:AddressLine"
    ],
    [
      "0..1",
      "",
      "Adresse de livraison - Ligne 3",
      "TEXTE",
      "/Invoice\n/cac:Delivery\n/cac:DeliveryLocation\n/cac:Address\n/cac:AddressLine\n\n/cbc:Line"
    ],
    [
      "1..1",
      "-",
      "-",
      "-",
      "/Invoice\n/cac:Delivery\n/cac:DeliveryLocation\n/cac:Address\n\n/cac:Country"
    ],
    [
      "1..1",
      "",
      "Code de pays",
      "CODE",
      "/Invoice\n/cac:Delivery\n/cac:DeliveryLocation\n/cac:Address\n/cac:Country\n\n/cbc:IdentificationCode"
    ],
    [
      "0..1",
      "-",
      "-",
      "-",
      "/Invoice\n/cac:Delivery\n\n/cac:DeliveryParty"
    ],
    [
      "0..1",
      "-",
      "-",
      "-",
      "/Invoice\n/cac:Delivery\n/cac:DeliveryParty\n\n/cac:PartyName"
    ],
    [
      "0..1",
      "",
      "Livr\u00E9 \u00E0",
      "TEXTE",
      "/Invoice\n/cac:Delivery\n/cac:DeliveryParty\n/cac:PartyName\n\n/cbc:Name"
    ],
    [
      "",
      "",
      "CONDITIONS DE LIVRAISON - INCOTERMS",
      "",
      "/Invoice\n\n/cac:DeliveryTerms"
    ],
    [
      "",
      "",
      "INCOTERMS (Type de livraison en code)",
      "CODE",
      "/Invoice\n/cac:DeliveryTerms\n\n/cbc:ID"
    ],
    [
      "",
      "-",
      "-",
      "-",
      "/Invoice\n/cac:DeliveryTerms\n\n/DeliveryLocation"
    ],
    [
      "",
      "",
      "Nom du lieu de livraison",
      "TEXTE",
      "/Invoice\n/cac:DeliveryTerms\n/cac:DeliveryLocation\n\n/cbc:Name"
    ],
    [
      "0..1",
      "",
      "INSTRUCTIONS DE PAIEMENT",
      "",
      "/Invoice\n\n/cac:PaymentMeans"
    ],
    [
      "1..1",
      "",
      "Code de type de moyen de paiement",
      "CODE",
      "/Invoice\n/cac:PaymentMeans\n\n/cbc:PaymentMeansCode"
    ],
    [
      "0..1",
      "",
      "Libell\u00E9 du moyen de paiement",
      "TEXTE",
      "/Invoice\n/cac:PaymentMeans\n/cbc:PaymentMeansCode\n\n/@Name"
    ],
    [
      "",
      "-",
      "-",
      "-",
      ""
    ],
    [
      "0..1",
      "",
      "Avis de paiement",
      "TEXTE",
      "/Invoice\n/cac:PaymentMeans\n\n/cbc:PaymentID"
    ],
    [
      "0..1",
      "",
      "INFORMATIONS CONCERNANT LA CARTE DE PAIEMENT",
      "",
      "/Invoice\n/cac:PaymentMeans\n\n/cac:CardAccount"
    ],
    [
      "1..1",
      "",
      "Identifiant de compte de paiement",
      "TEXTE",
      "/Invoice\n/cac:PaymentMeans\n/cac:CardAccount\n\n/cbc:PrimaryAccountNumberID"
    ],
    [
      "1..1",
      "-",
      "-",
      "-",
      "/Invoice\n/cac:PaymentMeans\n/cac:CardAccount\n\n/cbc:NetworkID"
    ],
    [
      "0..1",
      "",
      "Nom de compte de paiement",
      "TEXTE",
      "/Invoice\n/cac:PaymentMeans\n/cac:CardAccount\n\n/cbc:HolderName"
    ],
    [
      "0..n",
      "",
      "VIREMENT",
      "",
      "/Invoice\n/cac:PaymentMeans\n\n/cac:PayeeFinancialAccount"
    ],
    [
      "1..1",
      "",
      "Identifiant de compte de paiement",
      "IDENTIFIANT",
      "/Invoice\n/cac:PaymentMeans\n/cac:PayeeFinancialAccount\n\n/cbc:ID"
    ],
    [
      "0..1",
      "",
      "Nom de compte de paiement",
      "TEXTE",
      "/Invoice\n/cac:PaymentMeans\n/cac:PayeeFinancialAccount\n\n/cbc:Name"
    ],
    [
      "0..1",
      "-",
      "-",
      "-",
      "/Invoice\n/cac:PaymentMeans\n/cac:PayeeFinancialAccount\n\n/cac:FinancialInstitutionBranch"
    ],
    [
      "0..1",
      "",
      "Identifiant de prestataire de services de paiement",
      "IDENTIFIANT",
      "/Invoice\n/cac:PaymentMeans\n/cac:PayeeFinancialAccount\n/cac:FinancialInstitutionBranch\n\n/cbc:ID"
    ],
    [
      "0..1",
      "",
      "PR\u00C9L\u00C8VEMENT",
      "",
      "/Invoice\n/cac:PaymentMeans\n\n/cac:PaymentMandate"
    ],
    [
      "0..1",
      "",
      "Identifiant de r\u00E9f\u00E9rence de mandat",
      "IDENTIFIANT",
      "/Invoice\n/cac:PaymentMeans\n/cac:PaymentMandate\n\n/cbc:ID"
    ],
    [
      "",
      "",
      "PAYEUR DE LA FACTURE",
      "",
      "/Invoice\n/cac:PaymentMeans\n/cac:PaymentMandate\n\n/cac:PayerParty"
    ],
    [
      "",
      "BR-FR-23\nBR-FR-25",
      "Adresse \u00E9lectronique du payeur",
      "IDENTIFIANT",
      "/Invoice\n/cac:PaymentMeans\n/cac:PaymentMandate\n/cac:PayerParty\n\n/cbc:EndpointID"
    ],
    [
      "",
      "BR-FR-23\nBR-FR-25",
      "Identifiant du sch\u00E9ma de l\u0027adresse \u00E9lectronique du payeur",
      "IDENTIFIANT",
      "/Invoice\n/cac:PaymentMeans\n/cac:PaymentMandate\n/cac:PayerParty\n/cbc:EndpointID\n\n/@schemeID"
    ],
    [
      "",
      "",
      "Code du r\u00F4le du Payeur",
      "CODE",
      "/Invoice\n/cac:PaymentMeans\n/cac:PaymentMandate\n/cac:PayerParty\n\n/cbc:IndustryClassificationCode"
    ],
    [
      "",
      "-",
      "-",
      "-",
      "/Invoice\n/cac:PaymentMeans\n/cac:PaymentMandate\n/cac:PayerParty\n\n/cac:PartyIdentification"
    ],
    [
      "",
      "BR-FR-CO-10\nBR-FR-CO-11\nBR-FR-09",
      "Identifiant compl\u00E9mentaire du payeur",
      "IDENTIFIANT",
      "/Invoice\n/cac:PaymentMeans\n/cac:PaymentMandate\n/cac:PayerParty\n/cac:PartyIdentification\n\n/cbc:ID"
    ],
    [
      "",
      "BR-FR-CO-10\nBR-FR-CO-11\nBR-FR-09",
      "Identifiant du sch\u00E9ma",
      "IDENTIFIANT",
      "/Invoice\n/cac:PaymentMeans\n/cac:PaymentMandate\n/cac:PayerParty\n/cac:PartyIdentification\n/cbc:ID\n\n/@schemeID"
    ],
    [
      "",
      "-",
      "-",
      "-",
      "/Invoice\n/cac:PaymentMeans\n/cac:PaymentMandate\n/cac:PayerParty\n\n/cac:PartyName"
    ],
    [
      "",
      "",
      "Appellation commerciale du payeur",
      "TEXTE",
      "/Invoice\n/cac:PaymentMeans\n/cac:PaymentMandate\n/cac:PayerParty\n/cac:PartyName\n\n/cbc:Name"
    ],
    [
      "",
      "",
      "ADRESSE POSTALE DU PAYEUR",
      "",
      "/Invoice\n/cac:PaymentMeans\n/cac:PaymentMandate\n/cac:PayerParty\n\n/cac:PostalAddress"
    ],
    [
      "",
      "",
      "Adresse de Payeur - Ligne 1",
      "TEXTE",
      "/Invoice\n/cac:PaymentMeans\n/cac:PaymentMandate\n/cac:PayerParty\n/cac:PostalAddress\n\n/cbc:StreetName"
    ],
    [
      "",
      "",
      "Adresse du Payeur - Ligne 2",
      "TEXTE",
      "/Invoice\n/cac:PaymentMeans\n/cac:PaymentMandate\n/cac:PayerParty\n/cac:PostalAddress\n\n/cbc:AdditionalStreetName"
    ],
    [
      "",
      "",
      "Localit\u00E9 du Payeur",
      "TEXTE",
      "/Invoice\n/cac:PaymentMeans\n/cac:PaymentMandate\n/cac:PayerParty\n/cac:PostalAddress\n\n/cbc:CityName"
    ],
    [
      "",
      "",
      "Code postal du Payeur",
      "TEXTE",
      "/Invoice\n/cac:PaymentMeans\n/cac:PaymentMandate\n/cac:PayerParty\n/cac:PostalAddress\n\n/cbc:PostalZone"
    ],
    [
      "",
      "",
      "Subdivision du pays du payeur",
      "TEXTE",
      "/Invoice\n/cac:PaymentMeans\n/cac:PaymentMandate\n/cac:PayerParty\n/cac:PostalAddress\n\n/cbc:CountrySubentity"
    ],
    [
      "",
      "-",
      "-",
      "-",
      "/Invoice\n/cac:PaymentMeans\n/cac:PaymentMandate\n/cac:PayerParty\n/cac:PostalAddress\n\n/cac:AddressLine"
    ],
    [
      "",
      "",
      "Adresse du Payeur - Ligne 3",
      "TEXTE",
      "/Invoice\n/cac:PaymentMeans\n/cac:PaymentMandate\n/cac:PayerParty\n/cac:PostalAddress\n/cac:AddressLine\n\n/cbc:Line"
    ],
    [
      "",
      "-",
      "-",
      "-",
      "/Invoice\n/cac:PaymentMeans\n/cac:PaymentMandate\n/cac:PayerParty\n/cac:PostalAddress\n\n/cac:Country"
    ],
    [
      "",
      "",
      "Code de pays du payeur",
      "CODE",
      "/Invoice\n/cac:PaymentMeans\n/cac:PaymentMandate\n/cac:PayerParty\n/cac:PostalAddress\n/cac:Country\n\n/cbc:IdentificationCode"
    ],
    [
      "",
      "-",
      "-",
      "-",
      "/Invoice\n/cac:PaymentMeans\n/cac:PaymentMandate\n/cac:PayerParty\n\n/cac:PartyTaxScheme"
    ],
    [
      "",
      "",
      "Identifiant \u00E0 la TVA payeur",
      "IDENTIFIANT",
      "/Invoice\n/cac:PaymentMeans\n/cac:PaymentMandate\n/cac:PayerParty\n/cac:PartyTaxScheme\n\n/cbc:CompanyID"
    ],
    [
      "",
      "-",
      "-",
      "-",
      "/Invoice\n/cac:PaymentMeans\n/cac:PaymentMandate\n/cac:PayerParty\n/cac:PartyTaxScheme\n\n/cac:TaxScheme"
    ],
    [
      "",
      "",
      "Identifiant du sch\u00E9ma \u00E0 la TVA du\u00A0payeur",
      "CODE",
      "/Invoice\n/cac:PaymentMeans\n/cac:PaymentMandate\n/cac:PayerParty\n/cac:PartyTaxScheme\n/cac:TaxScheme\n\n/cbc:ID"
    ],
    [
      "",
      "-",
      "-",
      "-",
      "/Invoice\n/cac:PaymentMeans\n/cac:PaymentMandate\n/cac:PayerParty\n\n/cac:PartyLegalEntity"
    ],
    [
      "",
      "",
      "Raison sociale du payeur",
      "TEXTE",
      "/Invoice\n/cac:PaymentMeans\n/cac:PaymentMandate\n/cac:PayerParty\n/cac:PartyLegalEntity\n\n/cbc:RegistrationName"
    ],
    [
      "",
      "",
      "Numero de SIREN",
      "IDENTIFIANT",
      "/Invoice\n/cac:PaymentMeans\n/cac:PaymentMandate\n/cac:PayerParty\n/cac:PartyLegalEntity\n\n/cbc:CompanyID"
    ],
    [
      "",
      "",
      "Identifiant du sch\u00E9ma",
      "IDENTIFIANT",
      "/Invoice\n/cac:PaymentMeans\n/cac:PaymentMandate\n/cac:PayerParty\n/cac:PartyLegalEntity\n/cbc:CompanyID\n\n/@schemeID"
    ],
    [
      "",
      "",
      "CONTACT DU PAYEUR",
      "",
      "/Invoice\n/cac:PaymentMeans\n/cac:PaymentMandate\n/cac:PayerParty\n\n/cac:Contact"
    ],
    [
      "",
      "",
      "Point de contact du Payeur",
      "TEXTE",
      "/Invoice\n/cac:PaymentMeans\n/cac:PaymentMandate\n/cac:PayerParty\n/cac:Contact\n\n/cbc:Name"
    ],
    [
      "",
      "",
      "Num\u00E9ro t\u00E9l\u00E9phone contact du payeur",
      "TEXTE",
      "/Invoice\n/cac:PaymentMeans\n/cac:PaymentMandate\n/cac:PayerParty\n/cac:Contact\n\n/cbc:Telephone"
    ],
    [
      "",
      "",
      "Adresse \u00E9lectronique contact du payeur",
      "TEXTE",
      "/Invoice\n/cac:PaymentMeans\n/cac:PaymentMandate\n/cac:PayerParty\n/cac:Contact\n\n/cbc:ElectronicMail"
    ],
    [
      "0..1",
      "-",
      "-",
      "-",
      "/Invoice\n/cac:PaymentMeans\n/cac:PaymentMandate\n\n/cac:PayerFinancialAccount"
    ],
    [
      "0..1",
      "",
      "Identifiant de compte d\u00E9bit\u00E9 (IBAN)",
      "IDENTIFIANT",
      "/Invoice\n/cac:PaymentMeans\n/cac:PaymentMandate\n/cac:PayerFinancialAccount\n\n/cbc:ID"
    ],
    [
      "0..1",
      "-",
      "-",
      "-",
      "/Invoice\n\n/cac:PaymentTerms"
    ],
    [
      "0..1",
      "",
      "Conditions de paiement",
      "TEXTE",
      "/Invoice\n/cac:PaymentTerms\n\n/cbc:Note"
    ],
    [
      "0..n",
      "",
      "REMISES AU NIVEAU DU DOCUMENT",
      "",
      "/Invoice\n\n/cac:AllowanceCharge"
    ],
    [
      "",
      "-",
      "-",
      "-",
      "/Invoice\n/cac:AllowanceCharge\n\n/cbc:ChargeIndicator"
    ],
    [
      "0..1",
      "",
      "Code de motif de la remise au niveau du document",
      "CODE",
      "/Invoice\n/cac:AllowanceCharge\n\n/cbc:AllowanceChargeReasonCode"
    ],
    [
      "0..1",
      "",
      "Motif de la remise au niveau du document",
      "TEXTE",
      "/Invoice\n/cac:AllowanceCharge\n\n/cbc:AllowanceChargeReason"
    ],
    [
      "0..1",
      "",
      "Pourcentage de remise au niveau du document",
      "POURCENTAGE",
      "/Invoice\n/cac:AllowanceCharge\n\n/cbc:MultiplierFactorNumeric"
    ],
    [
      "1..1",
      "BR-FR-DEC-01",
      "Montant de la remise au niveau document",
      "MONTANT",
      "/Invoice\n/cac:AllowanceCharge\n\n/cbc:Amount"
    ],
    [
      "",
      "-",
      "-",
      "-",
      "/Invoice\n/cac:AllowanceCharge\n/cbc:Amount\n\n/@currencyID"
    ],
    [
      "0..1",
      "BR-FR-DEC-01",
      "Assiette de la remise au niveau du document",
      "MONTANT",
      "/Invoice\n/cac:AllowanceCharge\n\n/cbc:BaseAmount"
    ],
    [
      "",
      "-",
      "-",
      "-",
      "/Invoice\n/cac:AllowanceCharge\n/cbc:BaseAmount\n\n/@currencyID"
    ],
    [
      "1..1",
      "-",
      "-",
      "-",
      "/Invoice\n/cac:AllowanceCharge\n\n/cac:TaxCategory"
    ],
    [
      "1..1",
      "BR-FR-15",
      "Code de type de TVA de la remise au niveau du document",
      "CODE",
      "/Invoice\n/cac:AllowanceCharge\n/cac:TaxCategory\n\n/cbc:ID"
    ],
    [
      "0..1",
      "BR-FR-16\nBR-FR-DEC-04",
      "Taux de TVA de la remise au niveau du document",
      "POURCENTAGE",
      "/Invoice\n/cac:AllowanceCharge\n/cac:TaxCategory\n\n/cbc:Percent"
    ],
    [
      "",
      "",
      "Code Motif d\u0027exon\u00E9ration de la TVA de la remise au niveau du document",
      "CODE",
      "/Invoice\n/cac:AllowanceCharge\n/TaxCategory\n\n/cbc:TaxExemptionReasonCode"
    ],
    [
      "",
      "",
      "Motif d\u0027exon\u00E9ration de la TVA de la remise au niveau du document",
      "TEXTE",
      "/Invoice\n/cac:AllowanceCharge\n/TaxCategory\n\n/cbc:TaxExemptionReason"
    ],
    [
      "",
      "-",
      "-",
      "-",
      "/Invoice\n/cac:AllowanceCharge\n/cac:TaxCategory\n\n/cac:TaxScheme"
    ],
    [
      "",
      "",
      "Qualifiant  d\u0027identifiant TVA de la remise au niveau du document",
      "CODE",
      "/Invoice\n/cac:AllowanceCharge\n/cac:TaxCategory\n/cac:TaxScheme\n\n/cbc:ID"
    ],
    [
      "0..n",
      "",
      "CHARGES OU FRAIS AU NIVEAU DU DOCUMENT",
      "",
      "/Invoice\n\n/cac:AllowanceCharge"
    ],
    [
      "",
      "-",
      "-",
      "-",
      "/Invoice\n/cac:AllowanceCharge\n\n/cbc:ChargeIndicator"
    ],
    [
      "0..1",
      "",
      "Code de motif des charges ou frais au niveau du document",
      "CODE",
      "/Invoice\n/cac:AllowanceCharge\n\n/cbc:AllowanceChargeReasonCode"
    ],
    [
      "0..1",
      "",
      "Motif des charges ou frais au niveau du document",
      "TEXTE",
      "/Invoice\n/cac:AllowanceCharge\n\n/cbc:AllowanceChargeReason"
    ],
    [
      "0..1",
      "",
      "Pourcentage de charges ou frais au niveau du document",
      "POURCENTAGE",
      "/Invoice\n/cac:AllowanceCharge\n\n/cbc:MultiplierFactorNumeric"
    ],
    [
      "1..1",
      "BR-FR-DEC-01",
      "Montant des charges",
      "MONTANT",
      "/Invoice\n/cac:AllowanceCharge\n\n/cbc:Amount"
    ],
    [
      "",
      "-",
      "-",
      "-",
      "/Invoice\n/cac:AllowanceCharge\n/cbc:Amount\n\n/@currencyID"
    ],
    [
      "0..1",
      "BR-FR-DEC-01",
      "Assiette des charges ou frais au niveau du document",
      "MONTANT",
      "/Invoice\n/cac:AllowanceCharge\n\n/cbc:BaseAmount"
    ],
    [
      "",
      "-",
      "-",
      "-",
      "/Invoice\n/cac:AllowanceCharge\n/cbc:BaseAmount\n\n/@currencyID"
    ],
    [
      "1..1",
      "-",
      "-",
      "-",
      "/Invoice\n/cac:AllowanceCharge\n\n/cac:TaxCategory"
    ],
    [
      "1..1",
      "BR-FR-15",
      "Code de type de TVA des charges",
      "CODE",
      "/Invoice\n/cac:AllowanceCharge\n/cac:TaxCategory\n\n/cbc:ID"
    ],
    [
      "0..1",
      "BR-FR-16\nBR-FR-DEC-04",
      "Taux de TVA des charges ou frais au niveau du document",
      "POURCENTAGE",
      "/Invoice\n/cac:AllowanceCharge\n/cac:TaxCategory\n\n/cbc:Percent"
    ],
    [
      "",
      "",
      "Code Motif d\u0027exon\u00E9ration de la TVA des charges et frais au niveau du document",
      "CODE",
      "/Invoice\n/cac:AllowanceCharge\n/TaxCategory\n\n/cbc:TaxExemptionReasonCode"
    ],
    [
      "",
      "",
      "Motif d\u0027exon\u00E9ration de la TVA des charges et frais au niveau du document",
      "TEXTE",
      "/Invoice\n/cac:AllowanceCharge\n/TaxCategory\n\n/cbc:TaxExemptionReason"
    ],
    [
      "",
      "-",
      "-",
      "-",
      "/Invoice\n/cac:AllowanceCharge\n/cac:TaxCategory\n\n/cac:TaxScheme"
    ],
    [
      "",
      "",
      "Qualifiant du code de type de TVA des charges ou frais au niveau du document\t",
      "CODE",
      "/Invoice\n/cac:AllowanceCharge\n/cac:TaxCategory\n/cac:TaxScheme\n\n/cbc:ID"
    ],
    [
      "0..1",
      "-",
      "-",
      "-",
      "/Invoice\n\n/cac:TaxTotal"
    ],
    [
      "0..1",
      "BR-FR-DEC-01",
      "Montant total de TVA de la facture",
      "MONTANT",
      "/Invoice\n/cac:TaxTotal\n\n/cbc:TaxAmount"
    ],
    [
      "",
      "",
      "Code devise",
      "CODE",
      "/Invoice\n/cac:TaxTotal\n/cbc:TaxAmount\n\n/@currencyID"
    ],
    [
      "1..n",
      "",
      "VENTILATION DE LA TVA",
      "",
      "/Invoice\n/cac:TaxTotal\n\n/cac:TaxSubtotal"
    ],
    [
      "1..1",
      "BR-FR-DEC-01",
      "Base d\u0027imposition du type de TVA",
      "MONTANT",
      "/Invoice\n/cac:TaxTotal\n/cac:TaxSubtotal\n\n/cbc:TaxableAmount"
    ],
    [
      "",
      "-",
      "-",
      "-",
      "/Invoice\n/cac:TaxTotal\n/cac:TaxSubtotal\n/cbc:TaxableAmount\n\n/@currencyID"
    ],
    [
      "1..1",
      "BR-FR-DEC-01",
      "Montant de la TVA pour chaque type de TVA",
      "MONTANT",
      "/Invoice\n/cac:TaxTotal\n/cac:TaxSubtotal\n\n/cbc:TaxAmount"
    ],
    [
      "",
      "-",
      "-",
      "-",
      "/Invoice\n/cac:TaxTotal\n/cac:TaxSubtotal\n/cbc:TaxAmount\n\n/@currencyID"
    ],
    [
      "1..1",
      "-",
      "-",
      "-",
      "/Invoice\n/cac:TaxTotal\n/cac:TaxSubtotal\n\n/cac:TaxCategory"
    ],
    [
      "1..1",
      "BR-FR-15",
      "Code de type de TVA",
      "CODE",
      "/Invoice\n/cac:TaxTotal\n/cac:TaxSubtotal\n/cac:TaxCategory\n\n/cbc:ID"
    ],
    [
      "0..1",
      "BR-FR-16\nBR-FR-DEC-04",
      "Taux de type de TVA",
      "POURCENTAGE",
      "/Invoice\n/cac:TaxTotal\n/cac:TaxSubtotal\n/cac:TaxCategory\n\n/cbc:Percent"
    ],
    [
      "0..1",
      "",
      "Code de motif d\u0027exon\u00E9ration de la TVA",
      "CODE",
      "/Invoice\n/cac:TaxTotal\n/cac:TaxSubtotal\n/cac:TaxCategory\n\n/cbc:TaxExemptionReasonCode"
    ],
    [
      "0..1",
      "",
      "Motif d\u0027exon\u00E9ration de la TVA",
      "TEXTE",
      "/Invoice\n/cac:TaxTotal\n/cac:TaxSubtotal\n/cac:TaxCategory\n\n/cbc:TaxExemptionReason"
    ],
    [
      "",
      "-",
      "-",
      "-",
      "/Invoice\n/cac:TaxTotal\n/cac:TaxSubtotal\n/cac:TaxCategory\n\n/cac:TaxScheme"
    ],
    [
      "",
      "-",
      "-",
      "-",
      "/Invoice\n/cac:TaxTotal\n/cac:TaxSubtotal\n/cac:TaxCategory\n/cac:TaxScheme\n\n/cbc:ID"
    ],
    [
      "0..1",
      "-",
      "-",
      "-",
      "/Invoice\n\n/cac:TaxTotal"
    ],
    [
      "0..1",
      "BR-FR-DEC-01",
      "Montant total de TVA de la facture exprim\u00E9e (devise de comptabilisation)",
      "MONTANT",
      "/Invoice\n/cac:TaxTotal\n\n/cbc:TaxAmount"
    ],
    [
      "",
      "BR-FR-CO-12",
      "Code devise",
      "CODE",
      "/Invoice\n/cac:TaxTotal\n/cbc:TaxAmount\n\n/@currencyID"
    ],
    [
      "1..1",
      "",
      "TOTAUX DU DOCUMENT",
      "",
      "/Invoice\n\n/cac:LegalMonetaryTotal"
    ],
    [
      "1..1",
      "BR-FR-DEC-01",
      "Somme des montants nets des lignes de facture",
      "MONTANT",
      "/Invoice\n/cac:LegalMonetaryTotal\n\n/cbc:LineExtensionAmount"
    ],
    [
      "",
      "-",
      "-",
      "-",
      "/Invoice\n/cac:LegalMonetaryTotal\n/cbc:LineExtensionAmount\n\n/@currencyID"
    ],
    [
      "1..1",
      "BR-FR-DEC-01",
      "Montant total de la facture hors TVA",
      "MONTANT",
      "/Invoice\n/cac:LegalMonetaryTotal\n\n/cbc:TaxExclusiveAmount"
    ],
    [
      "",
      "-",
      "-",
      "-",
      "/Invoice\n/cac:LegalMonetaryTotal\n/cbc:TaxExclusiveAmount\n\n/@currencyID"
    ],
    [
      "1..1",
      "BR-FR-DEC-01",
      "Montant total de la Facture, avec la TVA.",
      "MONTANT",
      "/Invoice\n/cac:LegalMonetaryTotal\n\n/cbc:TaxInclusiveAmount"
    ],
    [
      "",
      "-",
      "-",
      "-",
      "/Invoice\n/cac:LegalMonetaryTotal\n/cbc:TaxInclusiveAmount\n\n/@currencyID"
    ],
    [
      "0..1",
      "BR-FR-DEC-01",
      "Somme des remises au niveau du document",
      "MONTANT",
      "/Invoice\n/cac:LegalMonetaryTotal\n\n/cbc:AllowanceTotalAmount"
    ],
    [
      "",
      "-",
      "-",
      "-",
      "/Invoice\n/cac:LegalMonetaryTotal\n/cbc:AllowanceTotalAmount\n\n/@currencyID"
    ],
    [
      "0..1",
      "BR-FR-DEC-01",
      "Somme des charges ou frais au niveau du document",
      "MONTANT",
      "/Invoice\n/cac:LegalMonetaryTotal\n\n/cbc:ChargeTotalAmount"
    ],
    [
      "",
      "-",
      "-",
      "-",
      "/Invoice\n/cac:LegalMonetaryTotal\n/cbc:ChargeTotalAmount\n\n/@currencyID"
    ],
    [
      "0..1",
      "BR-FR-DEC-01",
      "Montant pay\u00E9",
      "MONTANT",
      "/Invoice\n/cac:LegalMonetaryTotal\n\n/cbc:PrepaidAmount"
    ],
    [
      "",
      "-",
      "-",
      "-",
      "/Invoice\n/cac:LegalMonetaryTotal\n/cbc:PrepaidAmount\n\n/@currencyID"
    ],
    [
      "0..1",
      "BR-FR-DEC-01",
      "Montant arrondi",
      "MONTANT",
      "/Invoice\n/cac:LegalMonetaryTotal\n\n/cbc:PayableRoundingAmount"
    ],
    [
      "",
      "-",
      "-",
      "-",
      "/Invoice\n/cac:LegalMonetaryTotal\n/cbc:PayableRoundingAmount\n\n/@currencyID"
    ],
    [
      "1..1",
      "BR-FR-DEC-01",
      "Montant \u00E0 payer",
      "MONTANT",
      "/Invoice\n/cac:LegalMonetaryTotal\n\n/cbc:PayableAmount"
    ],
    [
      "",
      "-",
      "-",
      "-",
      "/Invoice\n/cac:LegalMonetaryTotal\n/cbc:PayableAmount\n\n/@currencyID"
    ],
    [
      "1..n",
      "",
      "LIGNE DE FACTURE",
      "",
      "/Invoice\n\n/cac:InvoiceLine"
    ],
    [
      "1..1",
      "",
      "Identifiant de ligne de facture",
      "IDENTIFIANT",
      "/Invoice\n/cac:InvoiceLine\n\n/cbc:ID"
    ],
    [
      "0..1",
      "",
      "Note de ligne de facture",
      "",
      "/Invoice\n/cac:InvoiceLine\n\n/cbc:Note"
    ],
    [
      "",
      "",
      "Code sujet de la note de ligne",
      "CODE",
      "/Invoice\n/cac:InvoiceLine\n\n/cbc:Note"
    ],
    [
      "0..1",
      "",
      "Note de ligne de facture",
      "TEXTE",
      "/Invoice\n/cac:InvoiceLine\n\n/cbc:Note"
    ],
    [
      "1..1",
      "BR-FR-DEC-02",
      "Quantit\u00E9 factur\u00E9e",
      "QUANTITE",
      "/Invoice\n/cac:InvoiceLine\n\n/cbc:InvoicedQuantity"
    ],
    [
      "1..1",
      "",
      "Code de l\u0027unit\u00E9 de mesure de la quantit\u00E9 factur\u00E9e",
      "CODE",
      "/Invoice\n/cac:InvoiceLine\n/cbc:InvoicedQuantity\n\n/@unitCode"
    ],
    [
      "1..1",
      "BR-FR-DEC-01\nBR-FR-MV-10",
      "Montant net de ligne de facture",
      "MONTANT",
      "/Invoice\n/cac:InvoiceLine\n\n/cbc:LineExtensionAmount"
    ],
    [
      "",
      "-",
      "-",
      "-",
      "/Invoice\n/cac:InvoiceLine\n/cbc:LineExtensionAmount\n\n/@currencyID"
    ],
    [
      "0..1",
      "",
      "R\u00E9f\u00E9rence comptable de l\u0027acheteur de la ligne de facture",
      "TEXTE",
      "/Invoice\n/cac:InvoiceLine\n\n/cbc:AccountingCost"
    ],
    [
      "0..1",
      "",
      "PERIODE DE FACTURATION D\u0027UNE LIGNE",
      "",
      "/Invoice\n/cac:InvoiceLine\n\n/cac:InvoicePeriod"
    ],
    [
      "0..1",
      "",
      "Date de d\u00E9but de p\u00E9riode de facturation d\u0027une ligne",
      "DATE",
      "/Invoice\n/cac:InvoiceLine\n/cac:InvoicePeriod\n\n/cbc:StartDate"
    ],
    [
      "0..1",
      "BR-FR-03",
      "Date de fin de p\u00E9riode de facturation d\u0027une ligne",
      "DATE",
      "/Invoice\n/cac:InvoiceLine\n/cac:InvoicePeriod\n\n/cbc:EndDate"
    ],
    [
      "",
      "",
      "Code de date d\u0027exigibilit\u00E9 de la taxe sur la valeur ajout\u00E9e \u00E0 la ligne",
      "CODE",
      "/Invoice\n/cac:InvoiceLine\n/cac:InvoicePeriod\n\n/cbc:DescriptionCode"
    ],
    [
      "0..1",
      "",
      "D\u00E9tail de l\u0027ordre de Vente \u00E0 la ligne",
      "",
      "/Invoice\n/cac:InvoiceLine\n\n/cac:OrderLineReference"
    ],
    [
      "0..1",
      "",
      "R\u00E9f\u00E9rence de ligne de bon de commande r\u00E9f\u00E9renc\u00E9e",
      "REFERENCE DU DOCUMENT",
      "/Invoice\n/cac:InvoiceLine\n/cac:OrderLineReference\n\n/cbc:LineID"
    ],
    [
      "",
      "",
      "Ligne de de l\u0027ordre de vente factur\u00E9",
      "IDENTIFIANT",
      "/Invoice\n/cac:InvoiceLine\n/cac:OrderLineReference\n\n/cbc:SalesOrderLineID"
    ],
    [
      "",
      "-",
      "-",
      "-",
      "/Invoice\n/cac:InvoiceLine\n/cac:OrderLineReference\n\n/cac:OrderReference"
    ],
    [
      "",
      "",
      "Identifiant de la commande g\u00E9n\u00E9r\u00E9e par l\u0027acheteur",
      "TEXTE",
      "/Invoice\n/cac:InvoiceLine\n/cac:OrderLineReference\n/cac:OrderReference\n\n/cbc:ID"
    ],
    [
      "",
      "",
      "Identifiant de l\u0027ordre de vente \u00E0 la ligne",
      "IDENTIFIANT",
      "/Invoice\n/cac:InvoiceLine\n/cac:OrderLineReference\n/cac:OrderReference\n\n/cbc:SalesOrderID"
    ],
    [
      "",
      "",
      "D\u00E9tail de l\u0027avis d\u0027exp\u00E9dition ",
      "",
      "/Invoice\n/cac:InvoiceLine\n\n/cac:DespatchLineReference"
    ],
    [
      "",
      "",
      "Ligne de l\u0027avis d\u0027exp\u00E9dition factur\u00E9",
      "IDENTIFIANT",
      "/Invoice\n/cac:InvoiceLine\n/cac:DespatchLineReference\n\n/cbc:LineID"
    ],
    [
      "",
      "-",
      "-",
      "-",
      "/Invoice\n/cac:InvoiceLine\n/cac:DespatchLineReference\n\n/cac:DocumentReference"
    ],
    [
      "",
      "",
      "Identifiant de l\u0027avis d\u0027exp\u00E9dition",
      "IDENTIFIANT",
      "/Invoice\n/cac:InvoiceLine\n/cac:DespatchLineReference\n/cac:DocumentReference\n\n/cbc:ID"
    ],
    [
      "",
      "",
      "D\u00E9tail de l\u0027avis de r\u00E9ception \u00E0 la ligne",
      "",
      "/Invoice\n/cac:InvoiceLine\n\n/cac:ReceiptLineReference"
    ],
    [
      "",
      "",
      "Ligne du bon de r\u00E9ception factur\u00E9",
      "IDENTIFIANT",
      "/Invoice\n/cac:InvoiceLine\n/cac:ReceiptLineReference\n\n/cbc:LineID"
    ],
    [
      "",
      "-",
      "-",
      "-",
      "/Invoice\n/cac:InvoiceLine\n/cac:ReceiptLineReference\n\n/cac:DocumentReference"
    ],
    [
      "",
      "",
      "Identifiant du bon de r\u00E9ception",
      "IDENTIFIANT",
      "/Invoice\n/cac:InvoiceLine\n/cac:ReceiptLineReference\n/cac:DocumentReference\n\n/cbc:ID"
    ],
    [
      "",
      "BR-FR-CO-05",
      "AJOUT REFERENCE A FACTURE ANTERIEURE EN LIGNE (permet de g\u00E9rer les reprises en ligne, notamment sur factures d\u0027acompte)",
      "",
      "/Invoice\n/cac:InvoiceLine\n\n/cac:BillingReference"
    ],
    [
      "",
      "-",
      "-",
      "-",
      "/Invoice\n/cac:InvoiceLine\n/cac:BillingReference\n\n/cac:InvoiceDocumentReference"
    ],
    [
      "",
      "BR-FR-01\nBR-FR-02\nBR-FR-CO-05",
      "ID de la facture ant\u00E9rieure",
      "REFERENCE DU DOCUMENT",
      "/Invoice\n/cac:InvoiceLine\n/cac:BillingReference\n/cac:InvoiceDocumentReference\n\n/cbc:ID"
    ],
    [
      "",
      "BR-FR-03",
      "Date de facture ant\u00E9rieure",
      "DATE",
      "/Invoice\n/cac:InvoiceLine\n/cac:BillingReference\n/cac:InvoiceDocumentReference\n\n/cbc:IssueDate"
    ],
    [
      "",
      "BR-FR-04",
      "Type de facture ant\u00E9rieure",
      "CODE",
      "/Invoice\n/cac:InvoiceLine\n/cac:BillingReference\n/cac:InvoiceDocumentReference\n\n/cbc:DocumentTypeCode"
    ],
    [
      "",
      "-",
      "-",
      "-",
      "/Invoice\n/cac:InvoiceLine\n/cac:BillingReference\n\n/cac:BillingReferenceLine"
    ],
    [
      "",
      "",
      "N\u00B0 de ligne de facture ant\u00E9rieure",
      "IDENTIFIANT",
      "/Invoice\n/cac:InvoiceLine\n/cac:BillingReference\n/cac:BillingReferenceLine\n\n/cbc:ID"
    ],
    [
      "",
      "-",
      "-",
      "-",
      "/Invoice\n/cac:InvoiceLine\n\n/cac:BillingReference"
    ],
    [
      "",
      "-",
      "-",
      "-",
      "/Invoice\n/cac:InvoiceLine\n/cac:BillingReference\n\n/cac:InvoiceDocumentReference"
    ],
    [
      "",
      "-",
      "-",
      "-",
      "/Invoice\n/cac:InvoiceLine\n/cac:BillingReference\n/cac:InvoiceDocumentReference\n\n/cbc:ID"
    ],
    [
      "",
      "BR-FR-MV-01\nBR-FR-MV-02",
      "Sous-type de ligne de facture",
      "Code",
      "/Invoice\n/cac:InvoiceLine\n/cac:BillingReference\n/cac:InvoiceDocumentReference\n\n/cbc:DocumentStatusCode"
    ],
    [
      "",
      "-",
      "-",
      "-",
      "/Invoice\n/cac:InvoiceLine\n/cac:BillingReference\n\n/cac:BillingReferenceLine"
    ],
    [
      "",
      "",
      "Identifiant de ligne Parent",
      "IDENTIFIANT",
      "/Invoice\n/cac:InvoiceLine\n/cac:BillingReference\n/cac:BillingReferenceLine\n\n/cbc:ID"
    ],
    [
      "0..1",
      "-",
      "-",
      "-",
      "/Invoice\n/cac:InvoiceLine\n\n/cac:DocumentReference"
    ],
    [
      "0..1",
      "BR-FR-29\nBR-FR-30\nBR-FR-MV-03\nBR-FR-MV-05\nBR-FR-MV-07\nBR-FR-MV-08\nBR-FR-MV-11\nBR-FR-MV-12",
      "Identifiant d\u0027objet de ligne de facture",
      "IDENTIFIANT",
      "/Invoice\n/cac:InvoiceLine\n/cac:DocumentReference\n\n/cbc:ID"
    ],
    [
      "0..1",
      "BR-FR-MV-03\nBR-FR-MV-05\nBR-FR-MV-07\nBR-FR-MV-08\nBR-FR-MV-11\nBR-FR-MV-12",
      "Identifiant du sch\u00E9ma",
      "IDENTIFIANT",
      "/Invoice\n/cac:InvoiceLine\n/cac:DocumentReference\n/cbc:ID\n\n/@schemeID"
    ],
    [
      "1..1",
      "-",
      "-",
      "-",
      "/Invoice\n/cac:InvoiceLine\n/cac:DocumentReference\n\n/cbc:DocumentTypeCode"
    ],
    [
      "",
      "",
      "D\u00E9tail de l\u0027adresse de livraison \u00E0 la ligne (Gestion du multi livraison)",
      "",
      "/Invoice\n/cac:InvoiceLine\n\n/cac:Delivery"
    ],
    [
      "",
      "BR-FR-03",
      "Date de livraison \u00E0 la ligne valeur",
      "DATE",
      "/Invoice\n/cac:InvoiceLine\n/cac:Delivery\n\n/cbc:ActualDeliveryDate"
    ],
    [
      "",
      "-",
      "-",
      "-",
      "/Invoice\n/cac:InvoiceLine\n/cac:Delivery\n\n/cac:DeliveryLocation"
    ],
    [
      "",
      "",
      "Identifiant global du lieu de livraison \u00E0 la ligne",
      "IDENTIFIANT",
      "/Invoice\n/cac:InvoiceLine\n/cac:Delivery\n/cac:DeliveryLocation\n\n/cbc:ID"
    ],
    [
      "",
      "",
      "Identifiant du sch\u00E9ma de l\u0027identifiant global du lieu de livraison",
      "IDENTIFIANT",
      "/Invoice\n/cac:InvoiceLine\n/cac:Delivery\n/cac:DeliveryLocation\n/cbc:ID\n\n/@schemeID"
    ],
    [
      "",
      "",
      "Adresse postale de livraison \u00E0 la ligne",
      "",
      "/Invoice\n/cac:InvoiceLine\n/cac:Delivery\n/cac:DeliveryLocation\n\n/cac:Address"
    ],
    [
      "",
      "",
      "Ligne Adresse 1 (si diff\u00E9rent ent\u00EAte)",
      "TEXTE",
      "/Invoice\n/cac:InvoiceLine\n/cac:Delivery\n/cac:DeliveryLocation\n/cac:Address\n\n/cbc:StreetName"
    ],
    [
      "",
      "",
      "Ligne adresse 2 (si diff\u00E9rent ent\u00EAte)",
      "TEXTE",
      "/Invoice\n/cac:InvoiceLine\n/cac:Delivery\n/cac:DeliveryLocation\n/cac:Address\n\n/cbc:AdditionalStreetName"
    ],
    [
      "",
      "",
      "Ville de livraison (si diff\u00E9rent ent\u00EAte)",
      "TEXTE",
      "/Invoice\n/cac:InvoiceLine\n/cac:Delivery\n/cac:DeliveryLocation\n/cac:Address\n\n/cbc:CityName"
    ],
    [
      "",
      "",
      "Code Postal de livraison (si diff\u00E9rent ent\u00EAte)",
      "TEXTE",
      "/Invoice\n/cac:InvoiceLine\n/cac:Delivery\n/cac:DeliveryLocation\n/cac:Address\n\n/cbc:PostalZone"
    ],
    [
      "",
      "",
      "Subdivision Pays (si diff\u00E9rent ent\u00EAte)",
      "TEXTE",
      "/Invoice\n/cac:InvoiceLine\n/cac:Delivery\n/cac:DeliveryLocation\n/cac:Address\n\n/cbc:CountrySubentity"
    ],
    [
      "",
      "-",
      "-",
      "-",
      "/Invoice\n/cac:InvoiceLine\n/cac:Delivery\n/cac:DeliveryLocation\n/cac:Address\n\n/cac:AddressLine"
    ],
    [
      "",
      "",
      "Ligne Adresse 3 (si diff\u00E9rent ent\u00EAte)",
      "TEXTE",
      "/Invoice\n/cac:InvoiceLine\n/cac:Delivery\n/cac:DeliveryLocation\n/cac:Address\n/cac:AddressLine\n\n/cbc:Line"
    ],
    [
      "",
      "-",
      "-",
      "-",
      "/Invoice\n/cac:InvoiceLine\n/cac:Delivery\n/cac:DeliveryLocation\n/cac:Address\n\n/cac:Country"
    ],
    [
      "",
      "",
      "Code Pays (si diff\u00E9rent ent\u00EAte)",
      "CODE",
      "/Invoice\n/cac:InvoiceLine\n/cac:Delivery\n/cac:DeliveryLocation\n/cac:Address\n/cac:Country\n\n/cbc:IdentificationCode"
    ],
    [
      "",
      "-",
      "-",
      "-",
      "/Invoice\n/cac:InvoiceLine\n/cac:Delivery\n\n/cac:DeliveryParty"
    ],
    [
      "",
      "-",
      "-",
      "-",
      "/Invoice\n/cac:InvoiceLine\n/cac:Delivery\n/cac:DeliveryParty\n\n/cac:PartyName"
    ],
    [
      "",
      "",
      "Nom du lieu de livraison (si different ent\u00EAte)",
      "TEXTE",
      "/Invoice\n/cac:InvoiceLine\n/cac:Delivery\n/cac:DeliveryParty\n/cac:PartyName\n\n/cbc:Name"
    ],
    [
      "",
      "-",
      "-",
      "-",
      "/Invoice\n/cac:InvoiceLine\n\n/cac:TaxTotal"
    ],
    [
      "",
      "BR-FR-DEC-01\nBR-FR-MV-09\nBR-FR-MV-10",
      "Montant TVA de la ligne de facture dans la devise de la facture",
      "MONTANT",
      "/Invoice\n/cac:InvoiceLine\n/cac:TaxTotal\n\n/cbc:TaxAmount"
    ],
    [
      "",
      "",
      "Devise du Montant TVA de la ligne de facture",
      "CODE",
      "/Invoice\n/cac:InvoiceLine\n/cac:TaxTotal\n/cbc:TaxAmount\n\n/@currencyID"
    ],
    [
      "",
      "-",
      "-",
      "-",
      "/Invoice\n/cac:InvoiceLine\n\n/cac:TaxTotal"
    ],
    [
      "",
      "BR-FR-DEC-01",
      "Montant TVA de la ligne de facture dans la devise  de comptabilisation",
      "MONTANT",
      "/Invoice\n/cac:InvoiceLine\n/cac:TaxTotal\n\n/cbc:TaxAmount"
    ],
    [
      "",
      "",
      "Devise de comptabilisation du Montant TVA de la ligne de facture",
      "CODE",
      "/Invoice\n/cac:InvoiceLine\n/cac:TaxTotal\n/cbc:TaxAmount\n\n/@currencyID"
    ],
    [
      "0..n",
      "",
      "REMISE DE LIGNE DE FACTURE",
      "",
      "/Invoice\n/cac:InvoiceLine\n\n/cac:AllowanceCharge"
    ],
    [
      "",
      "-",
      "-",
      "-",
      "/Invoice\n/cac:InvoiceLine\n/cac:AllowanceCharge\n\n/cbc:ChargeIndicator"
    ],
    [
      "0..1",
      "",
      "Code de motif de la remise de ligne de facture",
      "CODE",
      "/Invoice\n/cac:InvoiceLine\n/cac:AllowanceCharge\n\n/cbc:AllowanceChargeReasonCode"
    ],
    [
      "0..1",
      "",
      "Motif de la remise de ligne de facture",
      "TEXTE",
      "/Invoice\n/cac:InvoiceLine\n/cac:AllowanceCharge\n\n/cbc:AllowanceChargeReason"
    ],
    [
      "0..1",
      "",
      "Pourcentage de remise de ligne de facture",
      "POURCENTAGE",
      "/Invoice\n/cac:InvoiceLine\n/cac:AllowanceCharge\n\n/cbc:MultiplierFactorNumeric"
    ],
    [
      "1..1",
      "BR-FR-DEC-01",
      "Montant d\u0027une remise, hors TVA",
      "MONTANT",
      "/Invoice\n/cac:InvoiceLine\n/cac:AllowanceCharge\n\n/cbc:Amount"
    ],
    [
      "",
      "-",
      "-",
      "-",
      "/Invoice\n/cac:InvoiceLine\n/cac:AllowanceCharge\n/cbc:Amount\n\n/@currencyID"
    ],
    [
      "0..1",
      "BR-FR-DEC-01",
      "Assiette de la remise de ligne de facture",
      "MONTANT",
      "/Invoice\n/cac:InvoiceLine\n/cac:AllowanceCharge\n\n/cbc:BaseAmount"
    ],
    [
      "",
      "-",
      "-",
      "-",
      "/Invoice\n/cac:InvoiceLine\n/cac:AllowanceCharge\n/cbc:BaseAmount\n\n/@currencyID"
    ],
    [
      "0..n",
      "",
      "CHARGE OU FRAIS D\u0027UNE LIGNE DE FACTURE",
      "",
      "/Invoice\n/cac:InvoiceLine\n\n/cac:AllowanceCharge"
    ],
    [
      "",
      "-",
      "-",
      "-",
      "/Invoice\n/cac:InvoiceLine\n/cac:AllowanceCharge\n\n/cbc:ChargeIndicator"
    ],
    [
      "0..1",
      "",
      "Code de motif des charges ou frais applicables \u00E0 la ligne de facture",
      "CODE",
      "/Invoice\n/cac:InvoiceLine\n/cac:AllowanceCharge\n\n/cbc:AllowanceChargeReasonCode"
    ],
    [
      "0..1",
      "",
      "Motif des charges ou frais applicables \u00E0 la ligne de facture",
      "TEXTE",
      "/Invoice\n/cac:InvoiceLine\n/cac:AllowanceCharge\n\n/cbc:AllowanceChargeReason"
    ],
    [
      "0..1",
      "",
      "Pourcentage de charges ou frais applicable \u00E0 la ligne de facture",
      "POURCENTAGE",
      "/Invoice\n/cac:InvoiceLine\n/cac:AllowanceCharge\n\n/cbc:MultiplierFactorNumeric"
    ],
    [
      "1..1",
      "BR-FR-DEC-01",
      "Montant des charges ou frais",
      "MONTANT",
      "/Invoice\n/cac:InvoiceLine\n/cac:AllowanceCharge\n\n/cbc:Amount"
    ],
    [
      "",
      "-",
      "-",
      "-",
      "/Invoice\n/cac:InvoiceLine\n/cac:AllowanceCharge\n/cbc:Amount\n\n/@currencyID"
    ],
    [
      "0..1",
      "BR-FR-DEC-01",
      "Assiette des charges ou frais applicables \u00E0 la ligne de facture",
      "MONTANT",
      "/Invoice\n/cac:InvoiceLine\n/cac:AllowanceCharge\n\n/cbc:BaseAmount"
    ],
    [
      "",
      "-",
      "-",
      "-",
      "/Invoice\n/cac:InvoiceLine\n/cac:AllowanceCharge\n/cbc:BaseAmount\n\n/@currencyID"
    ],
    [
      "1..1",
      "",
      "INFORMATION SUR L\u0027ARTICLE",
      "",
      "/Invoice\n/cac:InvoiceLine\n\n/cac:Item"
    ],
    [
      "0..1",
      "",
      "Description de l\u0027article",
      "TEXTE",
      "/Invoice\n/cac:InvoiceLine\n/cac:Item\n\n/cbc:Description"
    ],
    [
      "",
      "",
      "Quantit\u00E9 dans une unit\u00E9 de la ligne Parent (EXT-FR-FE-162)",
      "QUANTITE",
      "/Invoice\n/cac:InvoiceLine\n/cac:Item\n\n/cbc:PackQuantity"
    ],
    [
      "",
      "",
      "Code de l\u0027unit\u00E9 de mesure de la Quantit\u00E9 dans une unit\u00E9 de la ligne Parent (EXT-FR-FE-162)",
      "CODE",
      "/Invoice\n/cac:InvoiceLine\n/cac:Item\n/cbc:PackQuantity\n\n/@unitCode"
    ],
    [
      "1..1",
      "",
      "Nom de l\u0027article",
      "TEXTE",
      "/Invoice\n/cac:InvoiceLine\n/cac:Item\n\n/cbc:Name"
    ],
    [
      "0..1",
      "-",
      "-",
      "-",
      "/Invoice\n/cac:InvoiceLine\n/cac:Item\n\n/cac:BuyersItemIdentification"
    ],
    [
      "0..1",
      "",
      "Identifiant acheteur de l\u0027article",
      "IDENTIFIANT",
      "/Invoice\n/cac:InvoiceLine\n/cac:Item\n/cac:BuyersItemIdentification\n\n/cbc:ID"
    ],
    [
      "0..1",
      "-",
      "-",
      "-",
      "/Invoice\n/cac:InvoiceLine\n/cac:Item\n\n/cac:SellersItemIdentification"
    ],
    [
      "0..1",
      "",
      "Identifiant vendeur de l\u0027article",
      "IDENTIFIANT",
      "/Invoice\n/cac:InvoiceLine\n/cac:Item\n/cac:SellersItemIdentification\n\n/cbc:ID"
    ],
    [
      "0..1",
      "-",
      "-",
      "-",
      "/Invoice\n/cac:InvoiceLine\n/cac:Item\n\n/cac:StandardItemIdentification"
    ],
    [
      "0..1",
      "",
      "Identifiant standard de l\u0027article",
      "IDENTIFIANT",
      "/Invoice\n/cac:InvoiceLine\n/cac:Item\n/cac:StandardItemIdentification\n\n/cbc:ID"
    ],
    [
      "1..1",
      "",
      "Identifiant du sch\u00E9ma",
      "IDENTIFIANT",
      "/Invoice\n/cac:InvoiceLine\n/cac:Item\n/cac:StandardItemIdentification\n/cbc:ID\n\n/@schemeID"
    ],
    [
      "0..1",
      "-",
      "-",
      "-",
      "/Invoice\n/cac:InvoiceLine\n/cac:Item\n\n/cac:OriginCountry"
    ],
    [
      "0..1",
      "",
      "Pays d\u0027origine de l\u0027article",
      "CODE",
      "/Invoice\n/cac:InvoiceLine\n/cac:Item\n/cac:OriginCountry\n\n/cbc:IdentificationCode"
    ],
    [
      "0..n",
      "-",
      "-",
      "-",
      "/Invoice\n/cac:InvoiceLine\n/cac:Item\n\n/cac:CommodityClassification"
    ],
    [
      "0..n",
      "",
      "Identifiant de la classification de l\u0027article",
      "IDENTIFIANT",
      "/Invoice\n/cac:InvoiceLine\n/cac:Item\n/cac:CommodityClassification\n\n/cbc:ItemClassificationCode"
    ],
    [
      "1..1",
      "",
      "Identifiant du sch\u00E9ma",
      "IDENTIFIANT",
      "/Invoice\n/cac:InvoiceLine\n/cac:Item\n/cac:CommodityClassification\n/cbc:ItemClassificationCode\n\n/@listID"
    ],
    [
      "0..1",
      "",
      "Identifiant version du sch\u00E9ma",
      "IDENTIFIANT",
      "/Invoice\n/cac:InvoiceLine\n/cac:Item\n/cac:CommodityClassification\n/cbc:ItemClassificationCode\n\n/@listVersionID"
    ],
    [
      "1..1",
      "",
      "INFORMATION SUR LA TVA",
      "",
      "/Invoice\n/cac:InvoiceLine\n/cac:Item\n\n/cac:ClassifiedTaxCategory"
    ],
    [
      "1..1",
      "BR-FR-15",
      "Code de type de TVA de l\u0027article factur\u00E9",
      "CODE",
      "/Invoice\n/cac:InvoiceLine\n/cac:Item\n/cac:ClassifiedTaxCategory\n\n/cbc:ID"
    ],
    [
      "0..1",
      "BR-FR-16\nBR-FR-DEC-04",
      "Taux de TVA de l\u0027article factur\u00E9",
      "POURCENTAGE",
      "/Invoice\n/cac:InvoiceLine\n/cac:Item\n/cac:ClassifiedTaxCategory\n\n/cbc:Percent"
    ],
    [
      "",
      "",
      "Code de Motif d\u0027exemption de TVA en ligne",
      "CODE",
      "/Invoice\n/cac:InvoiceLine\n/cac:Item\n/cac:ClassifiedTaxCategory\n\n/cbc:TaxExemptionReasonCode"
    ],
    [
      "",
      "",
      "Motif d\u0027exemption de TVA en ligne",
      "TEXTE",
      "/Invoice\n/cac:InvoiceLine\n/cac:Item\n/cac:ClassifiedTaxCategory\n\n/cbc:TaxExemptionReason"
    ],
    [
      "",
      "-",
      "-",
      "-",
      "/Invoice\n/cac:InvoiceLine\n/cac:Item\n/cac:ClassifiedTaxCategory\n\n/cac:TaxScheme"
    ],
    [
      "",
      "-",
      "-",
      "-",
      "/Invoice\n/cac:InvoiceLine\n/cac:Item\n/cac:ClassifiedTaxCategory\n/cac:TaxScheme\n\n/cbc:ID"
    ],
    [
      "0..n",
      "",
      "ATTRIBUTS D\u0027ARTICLE",
      "",
      "/Invoice\n/cac:InvoiceLine\n/cac:Item\n\n/cac:AdditionalItemProperty"
    ],
    [
      "1..1",
      "BR-FR-27",
      "Nom d\u0027attribut d\u0027article",
      "TEXTE",
      "/Invoice\n/cac:InvoiceLine\n/cac:Item\n/cac:AdditionalItemProperty\n\n/cbc:Name"
    ],
    [
      "",
      "BR-FR-27",
      "Code d\u0027attribut d\u0027article",
      "CODE",
      "/Invoice\n/cac:InvoiceLine\n/cac:Item\n/cac:AdditionalItemProperty\n\n/cbc:NameCode"
    ],
    [
      "1..1",
      "BR-FR-28",
      "Valeur d\u0027attribut d\u0027article",
      "TEXTE",
      "/Invoice\n/cac:InvoiceLine\n/cac:Item\n/cac:AdditionalItemProperty\n\n/cbc:Value"
    ],
    [
      "",
      "BR-FR-28",
      "Valeur d\u0027attribut d\u0027article avec unit\u00E9 de mesure",
      "QUANTITE",
      "/Invoice\n/cac:InvoiceLine\n/cac:Item\n/cac:AdditionalItemProperty\n\n/cbc:ValueQuantity"
    ],
    [
      "",
      "BR-FR-28",
      "",
      "Code",
      "/Invoice\n/cac:InvoiceLine\n/cac:Item\n/cac:AdditionalItemProperty\n/cbc:ValueQuantity\n\n/@unitCode"
    ],
    [
      "",
      "",
      "VENDEUR \u00E0 la ligne0..1",
      "",
      "/Invoice\n/cac:InvoiceLine\n/cac:Item\n\n/cac:ManufacturerParty"
    ],
    [
      "",
      "BR-FR-13\nBR-FR-22\nBR-FR-23\nBR-FR-25",
      "Adresse \u00E9lectronique du vendeur \u00E0 la ligne",
      "IDENTIFIANT",
      "/Invoice\n/cac:InvoiceLine\n/cac:Item\n/cac:ManufacturerParty\n\n/cbc:EndpointID"
    ],
    [
      "",
      "BR-FR-13\nBR-FR-22\nBR-FR-23\nBR-FR-25",
      "Identifiant du sch\u00E9ma",
      "IDENTIFIANT",
      "/Invoice\n/cac:InvoiceLine\n/cac:Item\n/cac:ManufacturerParty\n/cbc:EndpointID\n\n/@schemeID"
    ],
    [
      "",
      "-",
      "-",
      "-",
      "/Invoice\n/cac:InvoiceLine\n/cac:Item\n/cac:ManufacturerParty\n\n/cac:PartyIdentification"
    ],
    [
      "",
      "",
      "Identifiant priv\u00E9 du vendeur \u00E0 la ligne",
      "IDENTIFIANT",
      "/Invoice\n/cac:InvoiceLine\n/cac:Item\n/cac:ManufacturerParty\n/cac:PartyIdentification\n\n/cbc:ID"
    ],
    [
      "",
      "",
      "Identifiant du sch\u00E9ma",
      "IDENTIFIANT",
      "/Invoice\n/cac:InvoiceLine\n/cac:Item\n/cac:ManufacturerParty\n/cac:PartyIdentification\n/cbc:ID\n\n/@schemeID"
    ],
    [
      "",
      "-",
      "-",
      "-",
      "/Invoice\n/cac:InvoiceLine\n/cac:Item\n/cac:ManufacturerParty\n\n/cac:PartyName"
    ],
    [
      "",
      "",
      "Appellation commerciale du vendeur \u00E0 la ligne",
      "TEXTE",
      "/Invoice\n/cac:InvoiceLine\n/cac:Item\n/cac:ManufacturerParty\n/cac:PartyName\n\n/cbc:Name"
    ],
    [
      "",
      "",
      "ADRESSE POSTALE DU VENDEUR EN LIGNE",
      "",
      "/Invoice\n/cac:InvoiceLine\n/cac:Item\n/cac:ManufacturerParty\n\n/cac:PostalAddress"
    ],
    [
      "",
      "",
      "Adresse du vendeur en ligne - Ligne 1",
      "TEXTE",
      "/Invoice\n/cac:InvoiceLine\n/cac:Item\n/cac:ManufacturerParty\n/cac:PostalAddress\n\n/cbc:StreetName"
    ],
    [
      "",
      "",
      "Adresse du vendeur en ligne - Ligne 2",
      "TEXTE",
      "/Invoice\n/cac:InvoiceLine\n/cac:Item\n/cac:ManufacturerParty\n/cac:PostalAddress\n\n/cbc:AdditionalStreetName"
    ],
    [
      "",
      "",
      "Localit\u00E9 du vendeur en ligne ",
      "TEXTE",
      "/Invoice\n/cac:InvoiceLine\n/cac:Item\n/cac:ManufacturerParty\n/cac:PostalAddress\n\n/cbc:CityName"
    ],
    [
      "",
      "",
      "Code postal du vendeur \u00E0 la ligne",
      "TEXTE",
      "/Invoice\n/cac:InvoiceLine\n/cac:Item\n/cac:ManufacturerParty\n/cac:PostalAddress\n\n/cbc:PostalZone"
    ],
    [
      "",
      "",
      "Subdivision du pays du vendeur en ligne ",
      "TEXTE",
      "/Invoice\n/cac:InvoiceLine\n/cac:Item\n/cac:ManufacturerParty\n/cac:PostalAddress\n\n/cbc:CountrySubentity"
    ],
    [
      "",
      "-",
      "-",
      "-",
      "/Invoice\n/cac:InvoiceLine\n/cac:Item\n/cac:ManufacturerParty\n/cac:PostalAddress\n\n/cac:AddressLine"
    ],
    [
      "",
      "",
      "Adresse du vendeur en ligne - Ligne 3",
      "TEXTE",
      "/Invoice\n/cac:InvoiceLine\n/cac:Item\n/cac:ManufacturerParty\n/cac:PostalAddress\n/cac:AddressLine\n\n/cbc:Line"
    ],
    [
      "",
      "-",
      "-",
      "-",
      "/Invoice\n/cac:InvoiceLine\n/cac:Item\n/cac:ManufacturerParty\n/cac:PostalAddress\n\n/cac:Country"
    ],
    [
      "",
      "BR-FR-MV-03",
      "Code de pays du vendeur en ligne ",
      "CODE",
      "/Invoice\n/cac:InvoiceLine\n/cac:Item\n/cac:ManufacturerParty\n/cac:PostalAddress\n/cac:Country\n\n/cbc:IdentificationCode"
    ],
    [
      "",
      "-",
      "-",
      "-",
      "/Invoice\n/cac:InvoiceLine\n/cac:Item\n/cac:ManufacturerParty\n\n/cac:PartyTaxScheme"
    ],
    [
      "",
      "",
      "Identifiant \u00E0 la TVA du vendeur",
      "IDENTIFIANT",
      "/Invoice\n/cac:InvoiceLine\n/cac:Item\n/cac:ManufacturerParty\n/cac:PartyTaxScheme\n\n/cbc:CompanyID"
    ],
    [
      "",
      "-",
      "-",
      "-",
      "/Invoice\n/cac:InvoiceLine\n/cac:Item\n/cac:ManufacturerParty\n/cac:PartyTaxScheme\n\n/cac:TaxScheme"
    ],
    [
      "",
      "",
      "Qualifiant d\u0027Identifiant \u00E0 la TVA du Vendeur",
      "CODE",
      "/Invoice\n/cac:InvoiceLine\n/cac:Item\n/cac:ManufacturerParty\n/cac:PartyTaxScheme\n/cac:TaxScheme\n\n/cbc:ID"
    ],
    [
      "",
      "-",
      "-",
      "-",
      "/Invoice\n/cac:InvoiceLine\n/cac:Item\n/cac:ManufacturerParty\n\n/cac:PartyTaxScheme"
    ],
    [
      "",
      "",
      "Identifiant fiscal du vendeur \u00E0 la ligne",
      "IDENTIFIANT",
      "/Invoice\n/cac:InvoiceLine\n/cac:Item\n/cac:ManufacturerParty\n/cac:PartyTaxScheme\n\n/cbc:CompanyID"
    ],
    [
      "",
      "-",
      "-",
      "-",
      "/Invoice\n/cac:InvoiceLine\n/cac:Item\n/cac:ManufacturerParty\n/cac:PartyTaxScheme\n\n/cac:TaxScheme"
    ],
    [
      "",
      "",
      "Qualifiant d\u0027Identifiant fiscal du Vendeur",
      "CODE",
      "/Invoice\n/cac:InvoiceLine\n/cac:Item\n/cac:ManufacturerParty\n/cac:PartyTaxScheme\n/cac:TaxScheme\n\n/cbc:ID"
    ],
    [
      "",
      "-",
      "-",
      "-",
      "/Invoice\n/cac:InvoiceLine\n/cac:Item\n/cac:ManufacturerParty\n\n/cac:PartyLegalEntity"
    ],
    [
      "",
      "BR-FR-MV-03",
      "Raison sociale du vendeur \u00E0 la ligne",
      "TEXTE",
      "/Invoice\n/cac:InvoiceLine\n/cac:Item\n/cac:ManufacturerParty\n/cac:PartyLegalEntity\n\n/cbc:RegistrationName"
    ],
    [
      "",
      "BR-FR-MV-03\nBR-FR-MV-06",
      "Num\u00E9ro de SIREN du Vendeur \u00E0 la ligne",
      "IDENTIFIANT",
      "/Invoice\n/cac:InvoiceLine\n/cac:Item\n/cac:ManufacturerParty\n/cac:PartyLegalEntity\n\n/cbc:CompanyID"
    ],
    [
      "",
      "",
      "Identifiant du sch\u00E9ma",
      "IDENTIFIANT",
      "/Invoice\n/cac:InvoiceLine\n/cac:Item\n/cac:ManufacturerParty\n/cac:PartyLegalEntity\n/cbc:CompanyID\n\n/@schemeID"
    ],
    [
      "1..1",
      "",
      "D\u00C9TAIL DU PRIX",
      "",
      "/Invoice\n/cac:InvoiceLine\n\n/cac:Price"
    ],
    [
      "1..1",
      "BR-FR-DEC-03",
      "Prix net de l\u0027article",
      "MONTANT DU PRIX UNITAIRE",
      "/Invoice\n/cac:InvoiceLine\n/cac:Price\n\n/cbc:PriceAmount"
    ],
    [
      "",
      "-",
      "-",
      "-",
      "/Invoice\n/cac:InvoiceLine\n/cac:Price\n/cbc:PriceAmount\n\n/@currencyID"
    ],
    [
      "0..1",
      "BR-FR-DEC-02",
      "Quantit\u00E9 de base du prix de l\u0027article",
      "QUANTITE",
      "/Invoice\n/cac:InvoiceLine\n/cac:Price\n\n/cbc:BaseQuantity"
    ],
    [
      "0..1",
      "",
      "Code de l\u0027unit\u00E9 de mesure de la quantit\u00E9 de base du prix de l\u0027article",
      "CODE",
      "/Invoice\n/cac:InvoiceLine\n/cac:Price\n/cbc:BaseQuantity\n\n/@unitCode"
    ],
    [
      "0..1",
      "-",
      "-",
      "-",
      "/Invoice\n/cac:InvoiceLine\n/cac:Price\n\n/cac:AllowanceCharge"
    ],
    [
      "0..1",
      "-",
      "-",
      "-",
      "/Invoice\n/cac:InvoiceLine\n/cac:Price\n/cac:AllowanceCharge\n\n/cbc:ChargeIndicator"
    ],
    [
      "0..1",
      "BR-FR-DEC-03",
      "Rabais sur le prix de l\u0027article",
      "MONTANT DU PRIX UNITAIRE",
      "/Invoice\n/cac:InvoiceLine\n/cac:Price\n/cac:AllowanceCharge\n\n/cbc:Amount"
    ],
    [
      "",
      "-",
      "-",
      "-",
      "/Invoice\n/cac:InvoiceLine\n/cac:Price\n/cac:AllowanceCharge\n/cbc:Amount\n\n/@currencyID"
    ],
    [
      "0..1",
      "BR-FR-DEC-03",
      "Prix brut de l\u0027article",
      "MONTANT DU PRIX UNITAIRE",
      "/Invoice\n/cac:InvoiceLine\n/cac:Price\n/cac:AllowanceCharge\n\n/cbc:BaseAmount"
    ],
    [
      "",
      "-",
      "-",
      "-",
      "/Invoice\n/cac:InvoiceLine\n/cac:Price\n/cac:AllowanceCharge\n/cbc:BaseAmount\n\n/@currencyID"
    ]
  ]
}

_Source: `c:\Users\g.baudrit\source\repos\gbaudrit\conf-aimer-votre-llm\demo\ctxc-sample-spec\with-ctxc\spec/afnor/XP_Z12-012/XP_Z12-012.xlsx` (extract:flux2_ubl_ext_ctc_fr/sheet:Flux 2 UBL EXT-CTC-FR/table:json)_

### E-d276abeaa42a

{
  "headerRowIndices": [
    0,
    1,
    2,
    3,
    4
  ],
  "rows": [
    [
      "Description",
      "S\u0027applique \u00E0"
    ],
    [
      "L\u0027identifiant de facture DOIT \u00CATRE limit\u00E9 \u00E0 35 caract\u00E8res",
      "BT-1, BT-25, EXT-FR-FE-136"
    ],
    [
      "L\u0027Identifiant de facture (BT-1) est compos\u00E9 de caract\u00E8res alphanum\u00E9riques (A-Z, a-z, 0-9). Les caract\u00E8res sp\u00E9ciaux suivants sont autoris\u00E9s :\n- tiret (\u0022-\u0022)\n- signe \u0022\u002B\u0022\n- tiret bas (underscore : \u0022_\u0022)\n- barre oblique (slash : \u0022/\u0022)",
      "BT-1, BT-25, EXT-FR-FE-136"
    ],
    [
      "L\u0027ann\u00E9e d\u0027une date DOIT ETRE comprise entre 2000 et 2099",
      "Tout type DATE"
    ],
    [
      "Les codes types de documents pour une facture sont les suivants:\nFactures simples :\n- Facture commerciale (380)\n- Facture auto-factur\u00E9e (389)\n- Facture affactur\u00E9e (393)\n- Facture auto-factur\u00E9e affactur\u00E9e (501)\n\nFactures d\u0027acompte :\n- Facture d\u0027acompte (386)\n- Facture d\u2019acompte auto-factur\u00E9e (500)\n\nFactures rectificatives :\n- Facture rectificative (384)\n- Facture rectificative auto-factur\u00E9e ( 471)\n- Facture rectificative affactur\u00E9e (472)\n- Facture rectificative auto-factur\u00E9e affactur\u00E9e ( 473)\n\nAvoirs :\n- Avoir auto-factur\u00E9 (261)\n- Avoir pour Remise Globale (262)\n- Avoir (381)\n- Avoir affactur\u00E9 (396)\n- Avoir auto-factur\u00E9 affactur\u00E9 (502)\n- Avoir de facture d\u0027acompte (503)\n\nLes autres types de factures d\u00E9finis dans la norme (UNTDID 1001) ne doivent pas \u00EAtre utilis\u00E9s.",
      "BT-3, EXT-FR-FE-02, EXT-FR-FE-137"
    ],
    [
      "Toute facture DOIT comporter au moins 3 notes (BG-1) avec les codes suivants :\n- BT-21 = PMT, pour la mention de p\u00E9nalit\u00E9 de 40 EUROS forfaitaire pour frais de recouvrement (en BT-22)\n- BT-21 = PMD, Mention de p\u00E9nalit\u00E9s qui correspond aux conditions de paiement propres \u00E0 chaque entreprise (en BT-22).\n- BT21 = AAB, mention d\u0027escompte ou d\u0027absence d\u0027escompte (en BT-22)",
      "BT-22, BT-21"
    ],
    [
      "Parmi les notes (BG-3), les codes sujets (BT-21) PMD, PMT, AAB et TXD ne DOIVENT \u00EAtre pr\u00E9sents qu\u0027UNE SEULE FOIS CHACUN",
      "BT-22, BT-21"
    ],
    [
      "Les valeurs autoris\u00E9es pour le Cadre de Facturation (BT-23) sont:\nB1 : D\u00E9p\u00F4t d\u0027une facture de bien\nS1 : D\u00E9p\u00F4t d\u0027une facture de prestation de service\nM1 : D\u00E9p\u00F4t d\u0027une facture double (livraison de biens et services qui ne sont pas accessoires l\u0027une de l\u0027autre)\nB2 : D\u00E9p\u00F4t d\u0027une facture de bien d\u00E9j\u00E0 pay\u00E9e\nS2 : D\u00E9p\u00F4t d\u0027une facture de prestation de service d\u00E9j\u00E0 pay\u00E9e\nM2 : D\u00E9p\u00F4t d\u0027une facture double d\u00E9j\u00E0 pay\u00E9e\nS3 : D\u00E9p\u00F4t d\u0027une demande de paiement de sous-traitance avec paiement direct (uniquement B2G, restriction non v\u00E9rifiable)\n\nB4 : D\u00E9p\u00F4t d\u0027une facture d\u00E9finitive (apr\u00E8s acompte) de bien\nS4 : D\u00E9p\u00F4t d\u0027une facture d\u00E9finitive (apr\u00E8s acompte) de service\nM4 : D\u00E9p\u00F4t d\u0027une facture d\u00E9finitive (apr\u00E8s acompte) double\nS5 : D\u00E9p\u00F4t par un sous-traitant d\u2019une facture de prestation de service\nS6 : D\u00E9p\u00F4t par un cotraitant d\u2019une facture de prestation de service\nB7 : D\u00E9p\u00F4t d\u0027une facture de bien ayant fait l\u0027objet d\u0027un e-reporting (TVA d\u00E9j\u00E0 collect\u00E9e)\nS7 : D\u00E9p\u00F4t d\u0027une facture de prestation de service ayant fait l\u0027objet d\u0027un e-reporting (TVA d\u00E9j\u00E0 collect\u00E9e)\nB8 : D\u00E9p\u00F4t d\u0027une facture multi-vendeurs de bien\nS8 : D\u00E9p\u00F4t d\u0027une facture multi-vendeurs de service\nM8 : D\u00E9p\u00F4t d\u0027une facture multi-vendeurs double, contenant des factures unitaires qui ne sont pas toutes Sx ou Bx.",
      "BT-23"
    ],
    [
      "Dans une Partie, si le SIRET est renseign\u00E9 (ID Priv\u00E9, 0009), Les 9 premiers chiffres du SIRET doivent correspondre au SIREN renseign\u00E9 en ID l\u00E9gal (schemeID 0002) et le SIRET doit faire 14 chiffres",
      "BT-29, BT-46, BT-60, EXT-FR-FE-06, EXT-FR-FE-46, EXT-FR-FE-69, EXT-FR-FE-92, EXT-FR-FE-115, BT-71, EXT-FR-FE-146"
    ],
    [
      "Le SIREN du Vendeur est Obligatoire, et doit \u00EAtre pr\u00E9sent et actif dans l\u0027annuaire PPF",
      "BT-30"
    ],
    [
      "Pour les factures relevant du p\u00E9rim\u00E8tre \u0022e-invoicing\u0022, le SIREN de l\u0027Acheteur est Obligatoire, et DOIT \u00EAtre pr\u00E9sent et actif dans l\u0027annuaire PPF\r\n\r\nR\u00E8gle \u00E0 ex\u00E9cuter si la facture fait l\u0027objet d\u0027un traitement B2B ou si elle contient une note (BG-1) avec un code sujet (BT-21) = BAR et un contenu (BT-22) = B2B :\r\n\r\nL\u0027identifiant l\u00E9gal de l\u0027Acheteur (BT-47) DOIT \u00EAtre pr\u00E9sent.",
      "BT-47"
    ],
    [
      "D\u00E8s lors que la facture \u00E9lectronique doit \u00EAtre transmise et attend des statuts de cycle de vie en retour, l\u0027adresse \u00E9lectronique de l\u0027Acheteur (BT-49) est OBLIGATOIRE. C\u0027est l\u0027adresse \u00E9lectronique \u00E0 laquelle la facture est transmise (hors autofactures), ainsi que les statuts de cycle de vie \u00E0 destination de l\u0027ACHETEUR.\r\n\r\nPour information (g\u00E9r\u00E9 par d\u0027autres r\u00E8gles) : \r\nPour les factures hors autofacturation relevant du p\u00E9rim\u00E8tre \u0022e-invoicing\u0022, cette adresse \u00E9lectronique DOIT \u00EAtre de la forme \u0022SIREN\u0022 ou \u0022SIREN_XXX\u0022, le SIREN \u00E9tant celui de l\u0027Acheteur renseign\u00E9 en BT-47, avec un schemeId (BT-49-1) = 0225.\r\n\r\nPour les factures hors p\u00E9rim\u00E8tre \u0022e-invoicing\u0022 ou dans le p\u00E9rim\u00E8tre \u0022e-invoicing\u0022 en autofacturation \u00E9mises par l\u0027Acheteur, l\u0027adresse \u00E9lectronique de l\u0027Acheteur DOIT \u00EAtre dans un des schemesID de la liste de codes EAS (y compris un email, avec schemeID (BT-49-1) = EM).\r\n\r\nPour les factures mises \u00E0 disposition sur un portail, une adresse email (schemeID (BT-49-1) = EM) de type \u0022noreply@domaineduvendeur\u0022 peut \u00EAtre utilis\u00E9e pour signifier l\u0027absence d\u0027adresse \u00E9lectronique de l\u0027Acheteur.",
      "BT-49, BT-49-1"
    ],
    [
      "D\u00E8s lors que la facture \u00E9lectronique doit \u00EAtre transmise et attend des statuts de cycle de vie en retour, l\u0027adresse \u00E9lectronique du Vendeur (BT-34) est OBLIGATOIRE. C\u0027est l\u0027adresse \u00E9lectronique \u00E0 laquelle la facture en autofacturation est transmise, ainsi que les statuts de cycle de vie \u00E0 destination du Vendeur.\r\n\r\nPour information (g\u00E9r\u00E9 par d\u0027autres r\u00E8gles) : \r\nPour les factures en autofacturation relevant du p\u00E9rim\u00E8tre \u0022e-invoicing\u0022, cette adresse \u00E9lectronique DOIT \u00EAtre de la forme \u0022SIREN\u0022 ou \u0022SIREN_XXX\u0022, le SIREN \u00E9tant celui du Vendeur renseign\u00E9 en BT-30, avec un schemeId (BT-34-1) = 0225.\r\n\r\nPour les factures hors p\u00E9rim\u00E8tre \u0022e-invoicing\u0022 ou dans le p\u00E9rim\u00E8tre \u0022e-invoicing\u0022 mais pas en autofacturation, l\u0027adresse \u00E9lectronique du Vendeur DOIT \u00EAtre dans un des schemesID de la liste de codes EAS (y compris un email, avec schemeID (BT-34-1) = EM).\r\n\r\nPour les factures mises \u00E0 disposition sur un portail, une adresse email de type \u0022noreply@domaineduvendeur\u0022 peut \u00EAtre utilis\u00E9e pour signifier l\u0027absence d\u0027adresse \u00E9lectronique du Vendeur.",
      "BT-34, BT-34-1"
    ],
    [
      "Seuls les codes de cat\u00E9gorie de TVA suivants seront accept\u00E9s :\nS = Taux de TVA standard\nE = Exon\u00E9r\u00E9 de TVA\nAE = Autoliquidation de TVA\nK = Exon\u00E9ration pour cause de livraison intracommunautaire\nG = Exon\u00E9ration de TVA pour Export hors UE\nO = Hors du p\u00E9rim\u00E8tre d\u0027application de la TVA\nZ = Taux de TVA \u00E9gal \u00E0 0 (cf. G1.47)\n\nLes codes de cat\u00E9gorie de TVA suivants ne sont pas pertinents en France :\nL = Iles Canaries\nM = Ceuta et Mellila",
      "BT-95, BT-102, BT-118, BT-151"
    ],
    [
      "Le taux de la TVA applicable est conforme \u00E0 la liste suivante :\nTaux\n0, 0.0, 0.00\n10, 10.0, 10.00\n13, 13.0, 13.00\n20, 20.0, 20.00\n8.5, 8.50\n19.6, 19.60\n2.1, 2.10\n5.5, 5.50\n7, 7.0, 7.00\n20.6, 20.60\n1.05\n0.9, 0.90\n1.75\n9.2, 9.20\n9.6, 9.60\n\nLe taux est exprim\u00E9 en pourcentage et non en coefficient (exemple : 20). Le symbole \u00AB % \u00BB n\u2019est pas \u00E0 indiquer.\nLe s\u00E9parateur (\u00AB . \u00BB) n\u0027est pas comptabilis\u00E9 dans les 5 caract\u00E8res.",
      "BT-96, BT-103, BT-119, BT-152"
    ],
    [
      "Pour qualifier les Pi\u00E8ces jointes, les codes suivants peuvent \u00EAtre utilis\u00E9s :\r\nRIB : pour un RIB (qui contient l\u0027IBAN / N\u00B0 de compte \u002B nom de Titulaire)\r\nLISIBLE : pour LA REPR\u00C9SENTATION LISIBLE COMPL\u00C8TE DE LA FACTURE.\r\nFEUILLE_DE_STYLE : pour le feuille de style permettant de cr\u00E9er une repr\u00E9sentation lisible\r\nPJA : pour une pi\u00E8ce jointe additionnelle\r\nBORDEREAU_SUIVI : pour un bordereau de suivi\r\nDOCUMENT_ANNEXE : pour un document annexe\r\nBON_LIVRAISON :  un bon de livraison\r\nBON_COMMANDE: pour un Bon de Commande\r\nBORDEREAU_SUIVI_VALIDATION : pour un bordereau de suivi et validation\r\nETAT_ACOMPTE : pour un Etat d\u0027acompte\r\nFACTURE_PAIEMENT_DIRECT : pour une facture de sous-traitant \u00E0 payer en direct\r\nRECAPITULATIF_COTRAITANCE : pour lister l\u0027ensemble des factures de co-traitance \u00E0 traiter ensemble. ",
      "BT-123"
    ],
    [
      "Il ne peut pas y avoir deux Documents additionnels (BG-24) pour lesquels la description BT-123 est \u00E9gale \u00E0 LISIBLE",
      "BT-123"
    ],
    [
      "Qualification du traitement attendu : Il est possible d\u0027utiliser une Note pour indiquer quel traitement est attendu sur la facture. Le code sujet DOIT \u00EAtre BAR et les valeurs attendues, pour \u00EAtre signifiantes, DOIVENT \u00EAtre dans la liste ci-dessous, avec leurs significations :\n. B2B : signifie \u0022rel\u00E8ve du e-invoicing\u0022\n. B2BINT : signifie \u0022rel\u00E8ve du e-reporting des ventes B2Bint\u0022\n. B2C : signifie \u0022rel\u00E8ve du e-reporting B2C Ventes\u0022\n. OUTOFSCOPE : signifie \u0022hors r\u00E9forme\u0022\n. ARCHIVEONLY : signifie qu\u0027il s\u0027agit d\u0027un AVOIR interne cr\u00E9\u00E9 pour annuler une facture REJET\u00C9E ou REFUS\u00C9E, et NE DOIT PAS faire l\u0027objet d\u0027un traitement e-invoicing (pas de flux 1, pas de transmission au destinataire)",
      "BG-1, BT-21, BT-22"
    ],
    [
      "R\u00E8gle \u00E0 ex\u00E9cuter si la facture fait l\u0027objet d\u0027un traitement B2B ou si elle contient une note (BG-1) avec un code sujet (BT-21) = BAR et un contenu (BT-22) = B2B :\r\n\r\nSi la facture n\u0027est pas autofactur\u00E9e (BT-3) pas dans liste (\u0027389\u0027, \u0027501\u0027, \u0027500\u0027, \u0027471\u0027, \u0027473\u0027, \u0027261\u0027, \u0027502\u0027)\r\n\r\nALORS l\u0027adresse de facturation \u00E9lectronique de l\u0027ACHETEUR (BT-49) doit commencer par le N\u00B0 SIREN de l\u0027ACHETEUR (BT-47) ET le schemeID de l\u0027adresse (BT-49-1) DOIT \u00EAtre \u00E9gal \u00E0 0225",
      "BT-49, BT-49-1"
    ],
    [
      "R\u00E8gle \u00E0 ex\u00E9cuter si la facture fait l\u0027objet d\u0027un traitement B2B ou si elle contient une note (BG-1) avec un code sujet (BT-21) = BAR et un contenu (BT-22) = B2B :\r\n\r\nSi la facture est autofactur\u00E9e (BT-3 dans liste (\u0027389\u0027, \u0027501\u0027, \u0027500\u0027, \u0027471\u0027, \u0027473\u0027, \u0027261\u0027, \u0027502\u0027)\r\n\r\nALORS l\u0027adresse de facturation \u00E9lectronique du VENDEUR (BT-34) doit commencer par le N\u00B0 SIREN du VENDEUR (BT-30) ET le schemeID de l\u0027adresse (BT-30-1) DOIT \u00EAtre \u00E9gal \u00E0 0225",
      "BT-34, BT-34-1"
    ],
    [
      "Toute adresse \u00E9lectronique avec schemeID = 0225 est compos\u00E9 de caract\u00E8res alphanum\u00E9riques (A-Z, a-z, 0-9). Les caract\u00E8res sp\u00E9ciaux suivants sont autoris\u00E9s :\n- tiret (\u0022-\u0022)\n- tiret bas (underscore : \u0022_\u0022)\n- pont (\u0022.\u0022)",
      "BT-34 / BT-34-1, BT-49 / BT-49-1\nEXT-FR-FE-12 / EXT-FR-FE-13, EXT-FR-FE-29 / EXT-FR-FE-30, EXT-FR-FE-52 / EXT-FR-FE-53, EXT-FR-FE-75 / EXT-FR-FE-76, EXT-FR-FE-98 /EXT-FR-FE-99, EXT-FR-FE-121 / EXT-FR-FE-122"
    ],
    [
      "Toute IDpriv\u00E9 d\u0027une partie avec schemeID = 0224 est compos\u00E9 de caract\u00E8res alphanum\u00E9riques (A-Z, a-z, 0-9). Les caract\u00E8res sp\u00E9ciaux suivants sont autoris\u00E9s :\n- tiret (\u0022-\u0022)\n- tiret bas (underscore : \u0022_\u0022)\n- pont (\u0022.\u0022)",
      "BT-29 / BT-29-1, BT-46 / BT-46-1"
    ],
    [
      "Toute adresse \u00E9lectronique ne doit pas d\u00E9passer 125 caract\u00E8res",
      "BT-34, BT-49\nEXT-FR-FE-12, EXT-FR-FE-29 , EXT-FR-FE-52, EXT-FR-FE-75, EXT-FR-FE-98, EXT-FR-FE-121"
    ],
    [
      "Toute IDpriv\u00E9 d\u0027une partie avec schemeID = 0224 ne doit pas d\u00E9passer 100 caract\u00E8res",
      "BT-29 / BT-29-1, BT-46 / BT-46-1"
    ],
    [
      "Un groupe Attribut d\u0027article (BG-32) DOIT contenir soit un nom d\u0027attribut d\u0027article (BT-160), soit un Code d\u0027attribut d\u0027article (EXT-FR-FE-159)",
      "BG-32, BT-160, EXT-FR-FE-159"
    ],
    [
      "Un groupe Attribut d\u0027article (BG-32) DOIT contenir soit une valeur d\u0027attribut (BT-161), soit une valeur d\u0027attribut avec unit\u00E9 de mesure (EXT-FR-FE-160), et son unit\u00E9 de mesure (EXT-FR-FE-161), et pas les deux.",
      "BT-161, EXT-FR-FE-160, EXT-FR-FE-161"
    ],
    [
      "Parmi Identifiants d\u0027Objets factur\u00E9s (BT-18), les sch\u00E9mas d\u0027identification (BT-18-1) \u0022AFL\u0022 et \u0022AVV\u0022 ne DOIVENT \u00EAtre pr\u00E9sents qu\u0027UNE SEULE FOIS CHACUN",
      "BT-18, BT-18-1"
    ],
    [
      "Parmi Identifiants d\u0027Objets factur\u00E9s \u00E0 la ligne (BT-128), les sch\u00E9mas d\u0027identification (BT-128-1) \u0022AFL\u0022 et \u0022AVV\u0022 ne DOIVENT \u00EAtre pr\u00E9sents qu\u0027UNE SEULE FOIS CHACUN",
      "BT-128, BT-128-1"
    ],
    [
      "En cas de multiplicit\u00E9 de notes (BG-1) ayant un code sujet (BT-21) = BAR, une seule des valeurs suivantes peuvent \u00EAtre pr\u00E9sentes dans le contenu (BT-22) : \n. B2B\n. B2BINT\n. B2C\n. OUTOFSCOPE\n. ARCHIVEONLY",
      "BG-1, BT-21, BT-22"
    ],
    [
      "La date de facture (BT-2) DOIT ETRE ant\u00E9rieure ou \u00E9gale \u00E0 date d\u0027application du contr\u00F4le de conformit\u00E9\r\n\r\nR\u00E8gle non pr\u00E9sente dans le sch\u00E9matron car d\u00E9pend d\u0027une donn\u00E9e externe (date de traitement)",
      "BT-2"
    ],
    [
      "L\u0027identifiant unique de facture doit \u00EAtre compos\u00E9 des \u00E9l\u00E9ments suivants:\n- Num\u00E9ro de facture (BT-1)\n- Ann\u00E9e de production de la facture (Issue de la date d\u0027\u00E9mission de la facture (BT-2))\n- Identifiant l\u00E9gal du Vendeur : num\u00E9ro SIREN (BT-30)\n\nL\u2019unicit\u00E9 de la facture vise \u00E0 \u00E9viter les erreurs de facturation (double facturation notamment). Une facture pr\u00E9sentant des informations similaires cumulativement sur ces trois donn\u00E9es par rapport \u00E0 une facture pr\u00E9c\u00E9demment envoy\u00E9e fera l\u2019objet d\u2019un rejet par les plateformes.\nLe contr\u00F4le d\u2019unicit\u00E9 est syst\u00E9matiquement bloquant.\n\nEn cas de mandat de facturation, le num\u00E9ro de facture doit comporter une racine propre au mandataire pour \u00E9viter les doublons de facture avec celles de son mandant.\n\nLe num\u00E9ro de facture doit respecter la r\u00E8glementation du BOFIP suivante:\nBOI-TVA-DECLA-30-20-20-10 du 18/10/2023\nSection : A. La num\u00E9rotation des factures",
      "BT-1, BT-2, BT-30"
    ],
    [
      "Si le codetype de la facture (BT-3) est \u00E9gal \u00E0 262 (Avoir Remise Globale), alors :\n- Le num\u00E9ro de contrat (BT-12) DOIT \u00EAtre pr\u00E9sent\n- La p\u00E9riode de facturation (BG-14) DOIT \u00EAtre pr\u00E9sente",
      "BT-3, BT-12, BG-14"
    ],
    [
      "Si le codetype de la facture (BT-3) est dans la liste suivante :\n\nFactures rectificatives :\n- Facture rectificative (384)\n- Facture rectificative auto-factur\u00E9e (471) (*)\n- Facture rectificative affactur\u00E9e (472) (*)\n- Facture rectificative auto-factur\u00E9e affactur\u00E9e (473)  (*)\n\nAlors UNE ET UNE SEULE R\u00E9f\u00E9rence \u00E0 une facture ant\u00E9rieure (BT-25) DOIT \u00EAtre pr\u00E9sente, ainsi que sa Date (BT-26)",
      "BT-3, BT-25, BT-26"
    ],
    [
      "Si le codetype de la facture (BT-3) est dans la liste suivante :\n\nAvoirs :\n- Avoir auto-factur\u00E9 (261)\n- Avoir (381)\n- Avoir affactur\u00E9 (396)\n- Avoir auto-factur\u00E9 affactur\u00E9 (502) (*)\n- Avoir de facture d\u0027acompte (503) (*)\n\nAlors AU MOINS une R\u00E9f\u00E9rence \u00E0 une facture ant\u00E9rieure (BT-25) DOIT \u00EAtre pr\u00E9sente ainsi que sa Date (BT-26) OU BIEN une R\u00E9f\u00E9rence \u00E0 une facture ant\u00E9rieure en ligne (EXT-FR-FE-136) DOIT \u00EAtre pr\u00E9sente DANS CHAQUE ligne (BG-25), ainsi que sa date (EXT-FR-FE-138)",
      "BT-3, BT-25, EXT-FR-FE-136, EXT-FR-FE-138"
    ],
    [
      "La Date d\u0027\u00E9ch\u00E9ance (BT-9), si pr\u00E9sente, DOIT \u00EAtre post\u00E9rieure ou \u00E9gale \u00E0 la Date de facture (BT-2),\r\nSAUF SI la facture est de type acompte (BT-3) :\r\n- Facture d\u0027acompte (386)\r\n- Facture d\u2019acompte auto-factur\u00E9 (500) (*)\r\n- Avoir de facture d\u0027acompte (503) (*)\r\n\r\nOU SAUF SI le Cadre de facturation (BT-23) est \u00E9gal \u00E0 :\r\n- B2 : D\u00E9p\u00F4t d\u0027une facture de bien d\u00E9j\u00E0 pay\u00E9e\r\n- S2 : D\u00E9p\u00F4t d\u0027une facture de prestation de service d\u00E9j\u00E0 pay\u00E9e\r\n- M2 : D\u00E9p\u00F4t d\u0027une facture double d\u00E9j\u00E0 pay\u00E9e",
      "BT-9, BT-3, BT-2, BT-23"
    ],
    [
      "Si le cadre de facturation (BT-23) est :\n- B4 : Factures d\u00E9finitives (apr\u00E8s acompte) de bien\n- S4 : Factures d\u00E9finitives (apr\u00E8s acompte) de prestation de service\n- M4 : Factures d\u00E9finitives (apr\u00E8s acompte) double\n\nALORS le type de facture ne peut pas \u00EAtre :\n- Facture d\u0027acompte (386)\n- Facture d\u2019acompte auto-factur\u00E9e (500)\n- Avoir de facture d\u0027acompte (503)",
      "BT-23, BT-3"
    ],
    [
      "Si le cadre de facturation (BT-23) est :\n- B2 : D\u00E9p\u00F4t d\u0027une facture de bien d\u00E9j\u00E0 pay\u00E9e\n- S2 : D\u00E9p\u00F4t d\u0027une facture de prestation de service d\u00E9j\u00E0 pay\u00E9e\n- M2 : D\u00E9p\u00F4t d\u0027une facture double d\u00E9j\u00E0 pay\u00E9e\n\nALORS\n- Le montant d\u00E9j\u00E0 pay\u00E9 (BT-113) est \u00E9gal Montant total de la Facture avec la TVA (BT-112)\n- le Net \u00E0 payer (BT-115) est \u00E9gal \u00E0 0\n- la Date d\u0027\u00E9ch\u00E9ance (BT-9) DOIT indiquer la date \u00E0 laquelle la facture a \u00E9t\u00E9 pay\u00E9e",
      "BT-23, BT-9, BT-112, BT-113, BT-115"
    ],
    [
      "Lorsque les Identifiants priv\u00E9s des acteurs sont multiples (par exemple BT-29), ils doivent \u00EAtre qualifi\u00E9s par un identifiant du sch\u00E9ma (BT-29-1), il ne peut y avoir 2 identifiants priv\u00E9s avec le m\u00EAme identifiant du sch\u00E9ma",
      "BT-29, BT-46, BT-60, EXT-FR-FE-06, EXT-FR-FE-46, EXT-FR-FE-69, EXT-FR-FE-92, EXT-FR-FE-115, BT-71, EXT-FR-FE-146"
    ],
    [
      "Les identifiants priv\u00E9s des parties permettent de fournir des identifiants sp\u00E9cifiques, qualifi\u00E9s par l\u0027identifiant du schema (codelist ICD). Ainsi :\n- un SIRET (identifiant du schema = 0009)\n- un CODE_ROUTAGE (identifiant du schema = 0224)\n- Le SIREN de l\u0027assujetti unique du Vendeur (identifiant du schema : 0231), uniquement en BT-29",
      "BT-29, BT-46, BT-60, EXT-FR-FE-06, EXT-FR-FE-46, EXT-FR-FE-69, EXT-FR-FE-92, EXT-FR-FE-115, BT-71, EXT-FR-FE-146"
    ],
    [
      "Si la Devise de facture (BT-5) est diff\u00E9rente de EUR, alors\n- la devise de comptabilit\u00E9 BT-6 DOIT \u00EAtre pr\u00E9sente et \u00E9gale \u00E0 EUR\n- Le montant de TVA en devise de comptabilit\u00E9 (et donc en EURO BT-111 DOIT \u00EAtre pr\u00E9sente, et BT-111-1 DOIT \u00EAtre \u00E9gal \u00E0 EUR",
      "BT-5, BT-6, BT-110, BT-111"
    ],
    [
      "S\u0027il existe une occurrence de BT-29 avec un sch\u00E9ma d\u0027identification BT-29-1 = 0231, alors le Vendeur est Membre d\u0027un Assujetti Unique (AU), et un bloc BG-1 DOIT \u00EAtre pr\u00E9sent avec pour Code sujet (BT-21) = \u0022TXD\u0022 ET un texte de note (BT-22) = \u0022MEMBRE_ASSUJETTI_UNIQUE\u0022.",
      "BT-29, BT-29-1, BT-21, BT-22"
    ],
    [
      "S\u0027il existe une occurrence de BT-29 avec un sch\u00E9ma d\u0027identification BT-29-1 = 0231, alors le Vendeur est Membre d\u0027un Assujetti Unique (AU) et le Bloc du Repr\u00E9sentant fiscal du Vendeur (BG-11) DOIT \u00EAtre pr\u00E9sent et contient les informations de l\u0027Assujetti Unique (et en particulier son n\u00B0 de TVA en BT-63)",
      "BT-29, BT-29-1, BG-11, BT-63"
    ],
    [
      "Le montant dans une facture est exprim\u00E9 par un nombre sur 19 positions, et ne peut comporter plus de 2 d\u00E9cimales.\nLe s\u00E9parateur entre le nombre entier et les d\u00E9cimales est un point (\u00AB . \u00BB).\nLe signe \u00AB - \u00BB devant le montant compte comme un caract\u00E8re.\nSi le nombre total de chiffres du nombre (partie enti\u00E8re et partie d\u00E9cimale comprises) d\u00E9passe 19 caract\u00E8res, le montant sera rejet\u00E9. Le s\u00E9parateur (\u00AB . \u00BB) n\u0027est pas comptabilis\u00E9 dans les 19 caract\u00E8res.",
      "BT-92, BT-93, BT-99, BT-100, BT-106, BT-107, BT-108, BT-109, BT-110, BT-111, BT-112, BT-113, BT-114, BT-115, BT-116, BT-117, BT-131, BT-136, BT-137, BT-141, BT-142,\nEXT-FR-FE-181, EXT-FR-FE-182, EXT-FR-FE-184"
    ],
    [
      "La quantit\u00E9 factur\u00E9e dans une facture est exprim\u00E9 par un nombre sur 19 positions, et ne peut comporter plus de 4 d\u00E9cimales.\r\nLe s\u00E9parateur entre le nombre entier et les d\u00E9cimales est un point (\u00AB . \u00BB).\r\nLe signe \u00AB - \u00BB devant le montant compte comme un caract\u00E8re.\r\nSi le nombre total de chiffres du nombre (partie enti\u00E8re et partie d\u00E9cimale comprises) d\u00E9passe 19 caract\u00E8res, le montant sera rejet\u00E9. Le s\u00E9parateur (\u00AB . \u00BB) n\u0027est pas comptabilis\u00E9 dans les 19 caract\u00E8res.",
      "BT-129, BT-149"
    ],
    [
      "Le montant dans une facture est exprim\u00E9 par un nombre sur 19 positions, et ne peut comporter plus de 6 d\u00E9cimales.\nLe s\u00E9parateur entre le nombre entier et les d\u00E9cimales est un point (\u00AB . \u00BB).\nIl n\u0027y a pas de signe (toujours positif)\nSi le nombre total de chiffres du nombre (partie enti\u00E8re et partie d\u00E9cimale comprises) d\u00E9passe 19 caract\u00E8res, le montant sera rejet\u00E9. Le s\u00E9parateur (\u00AB . \u00BB) n\u0027est pas comptabilis\u00E9 dans les 19 caract\u00E8res.",
      "BT-146, BT-147, BT-148"
    ],
    [
      "Le taux de TVA dans une facture est exprim\u00E9 par un nombre sur 4 positions, et ne peut comporter plus de 2 d\u00E9cimales.\nLe s\u00E9parateur entre le nombre entier et les d\u00E9cimales est un point (\u00AB . \u00BB).\nIl n\u0027y a pas de signe (toujours positif)\nSi le nombre total de chiffres du nombre (partie enti\u00E8re et partie d\u00E9cimale comprises) d\u00E9passe 4 caract\u00E8res, le montant sera rejet\u00E9. Le s\u00E9parateur (\u00AB . \u00BB) n\u0027est pas comptabilis\u00E9 dans les 4 caract\u00E8res.\n",
      "BT-96, BT-103, BT-119, BT-152"
    ],
    [
      "Si le Cadre de facturation (BT-23) est \u00E9gal \u00E0 S8, B8 ou M8 alors:\n\nToutes les lignes (BG-25) DOIVENT contenir un sous-type de ligne (EXT-FR-FE-163).",
      "EXT-FR-FE-163"
    ],
    [
      "Si le Cadre de facturation (BT-23) est \u00E9gal \u00E0 S8, B8 ou M8 alors :\n\nLa facture DOIT contenir au moins 1 ligne (BG-25) avec le sous-type de ligne (EXT-FR-FE-163) \u00E9gal \u00E0 \u0022GROUP\u0022 et sans identifiant de ligne Parent (EXT-FR-FE-162)",
      "EXT-FR-FE-163"
    ],
    [
      "Si le Cadre de facturation (BT-23) est \u00E9gal \u00E0 S8, B8 ou M8 alors :\n\nPour chaque ligne (BG-25) avec un sous-type de ligne (EXT-FR-FE-163) \u00E9gal \u00E0 \u0022GROUP\u0022 et sans identifiant de ligne Parent (EXT-FR-FE-162), les donn\u00E9es suivantes DOIVENT \u00EAtre pr\u00E9sentes :\n. Un nom de vendeur \u00E0 la ligne (EXT-FR-FE-164)\n. Un identifiant de vendeur \u00E0 la ligne (EXT-FR-FE-167)\n. Un code pays de vendeur \u00E0 la ligne (EXT-FR-FE-177)\n. Une valeur d\u0027objet factur\u00E9 (BT-128) avec identifiant de schema (BT-128-1) = AFL (num\u00E9ro de facture par vendeur)\n. Une valeur d\u0027objet factur\u00E9 (BT-128) avec identifiant de schema (BT-128-1) = AVV (cadre de facturation par vendeur), diff\u00E9rent de M8/S8/B8\n.Un montant total avec TVA \u00E0 la ligne (EXT-FR-FE-184) en devise de facture",
      "EXT-FR-FE-164, EXT-FR-FE-167, EXT-FR-FE-177, BT-128, BT-128-1"
    ],
    [
      "Si le Cadre de facturation (BT-23) est \u00E9gal \u00E0 S8, B8 ou M8 alors :\n\nPour chaque ligne (BG-25) avec un sous-type de ligne (EXT-FR-FE-163) \u00E9gal \u00E0 \u0022GROUP\u0022 et sans identifiant de ligne Parent (EXT-FR-FE-162), si le Vendeur de ligne est assujetti \u00E0 la TVA et dispose d\u0027un Identifiant de TVA, alors, l\u0027identifiant TVA \u00E0 la ligne (EXT-FR-FE-168) DOIT \u00EAtre pr\u00E9sent.",
      "EXT-FR-FE-168"
    ],
    [
      "Si le Cadre de facturation (BT-23) est \u00E9gal \u00E0 S8, B8 ou M8 alors :\n\nLe total HT de ligne (BT-131) des lignes (BG-25) avec un sous-type de ligne (EXT-FR-FE-163) \u00E9gal \u00E0 \u0022GROUP\u0022 et sans identifiant de ligne Parent (EXT-FR-FE-162) DOIT \u00EAtre \u00E9gal \u00E0 la somme des totaux de ligne (BT-131) des lignes pour lesquelles l\u0027identifant de ligne Parent (EXT-FR-FE-162) est \u00E9gal \u00E0 l\u0027identifiant de ligne (BT-126) de la ligne \u0022GROUP\u0022.",
      "EXT-FR-FE-BG-12, BT-128, EXT-FR-FE-162"
    ],
    [
      "Si le Cadre de facturation (BT-23) est \u00E9gal \u00E0 S8, B8 ou M8 alors :\n\nToutes les lignes de factures (BG-25) DOIVENT contenir un identifiant l\u00E9gal de vendeur \u00E0 la ligne (EXT-FR-FE-167), identique \u00E0 celui de la ligne (BG-25) dont l\u0027identifiant de ligne (BT-126) est \u00E9gal \u00E0 l\u0027identifiant de ligne Parent (EXT-FR-FE-162), si pr\u00E9sent.",
      "EXT-FR-FE-167"
    ],
    [
      "Si le Cadre de facturation (BT-23) est \u00E9gal \u00E0 S8, B8 ou M8 alors :\n\nToutes les lignes de factures (BG-25) DOIVENT contenir un num\u00E9ro de facture de ligne, codifi\u00E9 avec l\u0027objet factur\u00E9 (BT-128 avec BT-128-1 = AFL) identique \u00E0 celui de la ligne (BG-25)  dont l\u0027identifiant de ligne (BT-126) est \u00E9gal \u00E0 l\u0027identifiant de ligne Parent (EXT-FR-FE-162), si pr\u00E9sent.",
      "BT-128, BT-128-1"
    ],
    [
      "Si le Cadre de facturation (BT-23) est \u00E9gal \u00E0 S8, B8 ou M8 alors :\n\nToutes les lignes de factures (BG-25) DOIVENT contenir une raison d\u0027exemption TVA en texte commen\u00E7ant par le num\u00E9ro de facture en ligne (EXT-FR-FE-178) entre # (exemple #F2025003#)",
      "BT-128, BT-128-1, EXT-FR-FE-178"
    ],
    [
      "Si le Cadre de facturation (BT-23) est \u00E9gal \u00E0 S8, B8 ou M8 alors :\n\nLe montant total TVA \u00E0 la ligne (EXT-FR-FE-181) des lignes (BG-25) avec un sous-type de ligne (EXT-FR-FE-163) \u00E9gal \u00E0 \u0022GROUP\u0022 et sans identifiant de ligne Parent (EXT-FR-FE-162) DOIT \u00EAtre \u00E9gal \u00E0 la somme des Montants de TVA de la ventilation de TVA (BT-117) pour lesquelles la raison d\u0027exemption (BT-120) commence par le numero de facture \u00E0 la ligne (BT-128 avec BT-128-1 = AFL) entre # ",
      "EXT-FR-FE-181"
    ],
    [
      "Si le Cadre de facturation (BT-23) est \u00E9gal \u00E0 S8, B8 ou M8 alors :\n\nSi le montant total avec TVA en ligne (EXT-FR-FE-184) d\u0027une ligne (BG-25) avec un sous-type de ligne (EXT-FR-FE-163) \u00E9gal \u00E0 \u0022GROUP\u0022 et sans identifiant de ligne Parent (EXT-FR-FE-162) est pr\u00E9sent, alors :\n\nLa valeur absolue du (montant total avec TVA (EXT-FR-FE-184) - le montant HT total de ligne (BT-131) - le montant total de TVA de ligne (EXT-FR-FE-181)) \u003C= 0,01 * nbre de sous-ligne avec sous-type de ligne (EXT-FR-FE-163) \u00E9gal \u00E0 \u0022DETAIL\u0022.",
      "EXT-FR-FE-184, EXT-FR-FE-181, BT-131"
    ],
    [
      "Si le Cadre de facturation (BT-23) est \u00E9gal \u00E0 S8, B8 ou M8 alors :\n\nSi le Vendeur principal identifi\u00E9 dans le bloc Vendeur (BG-4) de la facture au travers de son idetifiant l\u00E9gal (BT-27) dispose d\u0027un groupe de lignes de facturation, alors l\u0027identifiant de facture \u00E0 la ligne ((BT-128) avec scheme ID = AFL (BT-128-1) ), quand pr\u00E9sent (au minimum sur la ligne \u0022GROUP\u0022), DOIT \u00EAtre \u00E9gal au num\u00E9ro de facture (BT-1).",
      "BT-128, BT-128-1"
    ],
    [
      "Si le Cadre de facturation (BT-23) est \u00E9gal \u00E0 S8, B8 ou M8 alors :\n\nLes num\u00E9ros de facture \u00E0 la ligne (Valeur de BT-128 avec BT-128-1 = AFL) pour les lignes (BG-25) avec sous-type de ligne (EXT-FR-FE-163) = \u0022GROUP\u0022 et sans identifiant de ligne Parent (EXT-FR-FE-162) DOIVENT \u00EAtre uniques (une seule occurence).\n\nVoir recommandations pour cr\u00E9er des num\u00E9ros de factures unitaires distincts et conformes aux exigences r\u00E9glementaires, chapitre 4.4.12.2.",
      "BT-128, BT-128-1"
    ],
    [
      "Si le Cadre de facturation (BT-23) est \u00E9gal \u00E0 S8, B8 ou M8 alors :\n\nle code type de facture (BT-3) est diff\u00E9rent de :\n- Facture auto-factur\u00E9e (389)\n- Avoir auto-factur\u00E9 (261)\n- Facture auto-factur\u00E9e affactur\u00E9e (501)\n- Facture d\u2019acompte auto-factur\u00E9e (500)\n- Avoir auto-factur\u00E9 affactur\u00E9 (502)\n- Facture rectificative auto-factur\u00E9e ( 471)\n- Facture rectificative auto-factur\u00E9e affactur\u00E9e ( 473)",
      "BT-3"
    ],
    [
      "Si le Cadre de facturation (BT-23) est \u00E9gal \u00E0 S8, B8 ou M8 alors la Plateforme Agr\u00E9\u00E9e d\u0027\u00E9mission qui supporte la gestion des factures multi-vendeurs DOIT cr\u00E9er autant de flux 1 que de num\u00E9ro de facture en ligne pr\u00E9sents dans la facture. Pour ce faire, une premi\u00E8re \u00E9tape consiste \u00E0 cr\u00E9er des factures unitaires par num\u00E9ro de facture en ligne en suivant les r\u00E8gles ci-dessous sur la base des informations fournies dans la ligne (BG-25) avec un sous-type de ligne (EXT-FR-FE-163) \u00E9gal \u00E0 \u0022GROUP\u0022 et sans identifiant de ligne Parent (EXT-FR-FE-162) :\n. Remplacer les informations du Vendeur (BG-4) par celles du Vendeur en ligne (EXT-FR-FE-BG-12)\n. Remplacer le num\u00E9ro de facture (BT-1) par le numero de facture en ligne (BT-128, avec BT-128-1 = AFL)\n. Remplacer le Cadre de facturation (BT-23) par le cadre de facturation en ligne (BT-128 avec BT-128-1 = AVV).\n. Remplacer le code de date d\u0027exigibilit\u00E9 TVA (option sur les d\u00E9bits, BT-8) par celui indiqu\u00E9 en ligne (EXT-FR-FE-180)\n. Remplacer le total TVA dans la devise de la facture (BT-110) par le montant TVA en devise de facture en ligne (EXT-FR-FE-181).\n. Si pr\u00E9sent, remplacer le total TVA dans la devise de comptabilisation (BT-111) par le montant TVA en devise de comptabilisation en ligne (EXT-FR-FE-182).\n.Remplacer le montant total avec TVA (BT-112), par le montant  total avec TVA en ligne (EXT-FR-FE-184).\n. Porter le montant d\u00E9j\u00E0 pay\u00E9 (BT-113) au montant total avec TVA ci-dessus.\n. Porter le montant Net \u00E0 payer (BT-115) \u00E0 0 (par cons\u00E9quent).\n. Conserver uniquement les lignes pour lesquelles le num\u00E9ro de facture en ligne est celui la facture unitaire (BT-128, avec BT-128-1 = AFL).\n. Conserver uniquement les lignes de vendilation de TVA (BG-23) pour lesquelles la raison d\u0027exemption en texte (BT-120) commence par le num\u00E9ro de facture en ligne  (BT-128, avec BT-128-1 = AFL) entre #",
      "EXT-FR-FE-BG-12, BT-128, BT-128-1, EXT-FR-FE-180, EXT-FR-FE-181, EXT-FR-FE-182, EXT-FR-FE-184"
    ]
  ]
}

_Source: `c:\Users\g.baudrit\source\repos\gbaudrit\conf-aimer-votre-llm\demo\ctxc-sample-spec\with-ctxc\spec/afnor/XP_Z12-012/XP_Z12-012.xlsx` (extract:flux2_ubl_ext_ctc_fr_rules/sheet:BR-France CTC/table:json)_

