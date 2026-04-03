using ContextCompiler.Abstractions.Output;
using ContextCompiler.Abstractions.Prompt;
using ContextCompiler.Modules.Abstractions;

namespace ContextCompiler.Blueprints.Testing.TestCase;

internal sealed class TestCaseBlueprintComposer(
    IPrompt prompt,
    IBlueprintBuilder blueprintBuilder,
    IBlueprintStepBuilder stepBuilder) : IBlueprintComposerModule
{
    public ModuleMetadata Metadata => IModule.Meta("blueprints.testing.testcase", GlobalPipelineModuleKinds.PromptComposer, priority: 10);

    public Task Run(CancellationToken cancellationToken)
    {
        IBlueprint blueprint = blueprintBuilder
            .InitNew()
            .WithId("testing.testcase")
            .WithName("Rédaction de Test Cases")
            .WithDescription("Blueprint pour rédiger des test cases complets et traçables avec préconditions, étapes de test, résultats attendus et lien vers les exigences.")

            // === OBJECTIFS ===
            .WithObjective(o => o
                .WithId("OBJ-TC-1")
                .WithDescription("Rédiger des test cases clairs, complets et testables")
                .WithRationale("Des test cases bien écrits facilitent l'exécution et réduisent les ambiguïtés"))
            .WithObjective(o => o
                .WithId("OBJ-TC-2")
                .WithDescription("Assurer la traçabilité complète entre test cases et exigences")
                .WithRationale("La traçabilité garantit la couverture des exigences et facilite l'analyse d'impact"))
            .WithObjective(o => o
                .WithId("OBJ-TC-3")
                .WithDescription("Couvrir les scénarios positifs, négatifs et cas limites")
                .WithRationale("Une couverture complète améliore la qualité et réduit les défauts en production"))
            .WithObjective(o => o
                .WithId("OBJ-TC-4")
                .WithDescription("Faciliter l'exécution répétable et la documentation des résultats")
                .WithRationale("La répétabilité et la documentation sont essentielles pour les tests de régression"))
            .WithObjective(o => o
                .WithId("OBJ-TC-5")
                .WithDescription("Maintenir un référentiel de test cases à jour et réutilisable")
                .WithRationale("Un référentiel bien maintenu réduit les coûts et améliore l'efficacité"))

            // === CONTRAINTES GLOBALES ===
            .WithGlobalMustConstraint(m => m
                .WithId("MUST-TC-1")
                .WithText("Définir un identifiant unique et un titre descriptif pour chaque test case")
                .WithRationale("L'identification unique facilite la traçabilité et la communication"))
            .WithGlobalMustConstraint(m => m
                .WithId("MUST-TC-2")
                .WithText("Spécifier toutes les préconditions et données de test nécessaires")
                .WithRationale("Les préconditions claires assurent la reproductibilité et l'exécution correcte"))
            .WithGlobalMustConstraint(m => m
                .WithId("MUST-TC-3")
                .WithText("Rédiger des étapes de test claires, numérotées et séquentielles")
                .WithRationale("Des étapes claires guident l'exécution et évitent les erreurs"))
            .WithGlobalMustConstraint(m => m
                .WithId("MUST-TC-4")
                .WithText("Définir le résultat attendu pour chaque étape de test")
                .WithRationale("Les résultats attendus permettent la validation objective de chaque étape"))
            .WithGlobalMustConstraint(m => m
                .WithId("MUST-TC-5")
                .WithText("Maintenir la matrice de traçabilité vers les exigences")
                .WithRationale("La traçabilité assure la couverture complète des exigences"))
            .WithGlobalMustConstraint(m => m
                .WithId("MUST-TC-6")
                .WithText("Utiliser des conventions de nommage cohérentes (ID, catégories, priorités)")
                .WithRationale("La cohérence facilite l'organisation et la recherche des test cases"))
            .WithGlobalMustConstraint(m => m
                .WithId("MUST-TC-7")
                .WithText("Attribuer une priorité et une sévérité à chaque test case")
                .WithRationale("La priorisation guide l'exécution et l'allocation des ressources"))
            .WithGlobalMustConstraint(m => m
                .WithId("MUST-TC-8")
                .WithText("Documenter les données de test avec leurs valeurs attendues")
                .WithRationale("Des données bien documentées assurent la reproductibilité"))
            .WithGlobalMustConstraint(m => m
                .WithId("MUST-TC-9")
                .WithText("Inclure les post-conditions pour vérifier l'état du système après test")
                .WithRationale("Les post-conditions valident que le système est dans un état cohérent"))

            .WithGlobalMustNotConstraint(mn => mn
                .WithId("MUSTNOT-TC-1")
                .WithText("Rédiger des étapes de test vagues ou ambiguës")
                .WithRationale("L'ambiguïté entraîne des exécutions incorrectes et des résultats incohérents"))
            .WithGlobalMustNotConstraint(mn => mn
                .WithId("MUSTNOT-TC-2")
                .WithText("Omettre les résultats attendus ou utiliser 'devrait fonctionner'")
                .WithRationale("Les résultats attendus précis sont essentiels pour une validation objective"))
            .WithGlobalMustNotConstraint(mn => mn
                .WithId("MUSTNOT-TC-3")
                .WithText("Ignorer les scénarios d'erreur et cas limites")
                .WithRationale("Les cas limites révèlent souvent les défauts les plus critiques"))
            .WithGlobalMustNotConstraint(mn => mn
                .WithId("MUSTNOT-TC-4")
                .WithText("Mélanger plusieurs scénarios dans un seul test case")
                .WithRationale("Un test case doit tester une seule fonctionnalité pour faciliter le diagnostic"))
            .WithGlobalMustNotConstraint(mn => mn
                .WithId("MUSTNOT-TC-5")
                .WithText("Créer des test cases dépendants les uns des autres")
                .WithRationale("Les dépendances compliquent l'exécution et la maintenance"))
            .WithGlobalMustNotConstraint(mn => mn
                .WithId("MUSTNOT-TC-6")
                .WithText("Utiliser des valeurs de test non réalistes ou invalides sans justification")
                .WithRationale("Les valeurs réalistes augmentent la pertinence et la fiabilité des tests"))
            .WithGlobalMustNotConstraint(mn => mn
                .WithId("MUSTNOT-TC-7")
                .WithText("Oublier de mettre à jour les test cases après modification des exigences")
                .WithRationale("Les test cases obsolètes créent de la confusion et réduisent la couverture"))

            // === ASSUMPTIONS ===
            .WithAssumption(a => a
                .WithId("AS-TC-1")
                .WithDescription("Un outil de gestion de test cases est disponible (TestRail, Zephyr, Azure Test Plans, etc.)")
                .WithRationale("Un outil facilite la documentation, l'exécution et le suivi des test cases"))
            .WithAssumption(a => a
                .WithId("AS-TC-2")
                .WithDescription("Les exigences sont documentées et accessibles")
                .WithRationale("Les exigences sont la base pour créer des test cases pertinents"))
            .WithAssumption(a => a
                .WithId("AS-TC-3")
                .WithDescription("Un environnement de test stable et représentatif est disponible")
                .WithRationale("Un environnement fiable est nécessaire pour l'exécution des test cases"))
            .WithAssumption(a => a
                .WithId("AS-TC-4")
                .WithDescription("Un système de gestion des défauts est en place (Jira, Azure DevOps, etc.)")
                .WithRationale("Le suivi des défauts découverts est essentiel pour l'amélioration de la qualité"))
            .WithAssumption(a => a
                .WithId("AS-TC-5")
                .WithDescription("Les testeurs ont accès aux données de test et aux comptes nécessaires")
                .WithRationale("L'accès aux ressources est indispensable pour l'exécution des tests"))

            // === GLOSSAIRE ===
            .WithGlossaryTerm(g => g
                .WithTerm("Test Case")
                .WithDefinition("Document décrivant les entrées, actions d'exécution, conditions et résultats attendus pour tester une fonctionnalité"))
            .WithGlossaryTerm(g => g
                .WithTerm("Précondition")
                .WithDefinition("État ou condition qui doit être établi avant l'exécution du test case"))
            .WithGlossaryTerm(g => g
                .WithTerm("Étape de test")
                .WithDefinition("Action spécifique à effectuer lors de l'exécution du test, avec son résultat attendu"))
            .WithGlossaryTerm(g => g
                .WithTerm("Résultat attendu")
                .WithDefinition("Comportement ou sortie prévu du système pour une étape de test donnée"))
            .WithGlossaryTerm(g => g
                .WithTerm("Résultat réel")
                .WithDefinition("Comportement ou sortie observé du système lors de l'exécution réelle du test"))
            .WithGlossaryTerm(g => g
                .WithTerm("Post-condition")
                .WithDefinition("État dans lequel le système doit se trouver après l'exécution complète du test case"))
            .WithGlossaryTerm(g => g
                .WithTerm("Données de test")
                .WithDefinition("Ensemble des valeurs d'entrée utilisées pour exécuter le test case"))
            .WithGlossaryTerm(g => g
                .WithTerm("Matrice de traçabilité")
                .WithDefinition("Document établissant la correspondance entre exigences et test cases"))
            .WithGlossaryTerm(g => g
                .WithTerm("Test positif")
                .WithDefinition("Test vérifiant que le système fonctionne correctement avec des données valides"))
            .WithGlossaryTerm(g => g
                .WithTerm("Test négatif")
                .WithDefinition("Test vérifiant que le système gère correctement les erreurs et données invalides"))
            .WithGlossaryTerm(g => g
                .WithTerm("Cas limite")
                .WithDefinition("Valeur d'entrée à la frontière des domaines valides et invalides"))
            .WithGlossaryTerm(g => g
                .WithTerm("Couverture de test")
                .WithDefinition("Mesure du pourcentage d'exigences couvertes par les test cases"))
            .WithGlossaryTerm(g => g
                .WithTerm("Test de régression")
                .WithDefinition("Test vérifiant que les modifications n'ont pas introduit de nouveaux défauts"))
            .WithGlossaryTerm(g => g
                .WithTerm("Priorité")
                .WithDefinition("Importance relative d'un test case pour l'ordre d'exécution (Haute, Moyenne, Basse)"))
            .WithGlossaryTerm(g => g
                .WithTerm("Sévérité")
                .WithDefinition("Impact d'un défaut potentiel sur le système (Critique, Majeure, Mineure, Triviale)"))

            // === COMMANDES ===
            .WithCommand(c => c
                .WithName("write-testcase")
                .WithDescription("Rédiger un nouveau test case complet")
                .WithExample("TC-001: Vérifier la connexion utilisateur avec identifiants valides - Given un utilisateur enregistré, When il saisit ses identifiants corrects, Then il accède à son tableau de bord"))
            .WithCommand(c => c
                .WithName("review-testcase")
                .WithDescription("Réviser un test case existant pour complétude et clarté")
                .WithExample("Réviser TC-123 pour vérifier que toutes les étapes ont des résultats attendus précis et que les données de test sont documentées"))
            .WithCommand(c => c
                .WithName("execute-testcase")
                .WithDescription("Exécuter un test case et documenter les résultats")
                .WithExample("Exécuter TC-456 dans l'environnement de test et documenter Pass/Fail avec captures d'écran si échec"))
            .WithCommand(c => c
                .WithName("update-results")
                .WithDescription("Mettre à jour les résultats d'exécution et créer des défauts si nécessaire")
                .WithExample("Pour TC-789 Failed, créer défaut DEF-012 'Erreur 500 lors de la validation' avec logs et captures"))
            .WithCommand(c => c
                .WithName("link-to-requirement")
                .WithDescription("Établir ou vérifier le lien de traçabilité vers une exigence")
                .WithExample("Lier TC-234 à REQ-567 'Authentification multi-facteurs' dans la matrice de traçabilité"))
            .WithCommand(c => c
                .WithName("generate-coverage-report")
                .WithDescription("Générer un rapport de couverture des exigences par les test cases")
                .WithExample("Produire le rapport de couverture pour le module 'Gestion des paiements' montrant les exigences non couvertes"))

            // === STEPS ===
            .WithStep(s => s
                .WithTitle("Identifier l'objectif du test et l'exigence associée")
                .WithDescription("Déterminer clairement ce qui doit être testé et quelle exigence sera vérifiée.")
                .WithExpectedOutcome("Objectif de test clairement défini et lié à une exigence spécifique")
                .WithMustConstraint(m => m
                    .WithId("STEP1_MUST1")
                    .WithText("Identifier l'exigence ou la User Story source")
                    .WithRationale("Le lien vers l'exigence assure la traçabilité et justifie le test"))
                .WithMustConstraint(m => m
                    .WithId("STEP1_MUST2")
                    .WithText("Définir l'objectif spécifique du test (fonctionnalité à valider)")
                    .WithRationale("Un objectif clair guide la rédaction et facilite la compréhension"))
                .WithMustConstraint(m => m
                    .WithId("STEP1_MUST3")
                    .WithText("Vérifier que l'exigence est complète et testable")
                    .WithRationale("Une exigence incomplète ne peut pas être testée correctement"))
                .WithMustNotConstraint(mn => mn
                    .WithId("STEP1_MUSTNOT1")
                    .WithText("Créer un test case sans référence à une exigence")
                    .WithRationale("Les test cases sans traçabilité ne peuvent pas prouver la couverture")))

            .WithStep(s => s
                .WithTitle("Définir l'identifiant et le titre du test case")
                .WithDescription("Créer un identifiant unique et un titre descriptif pour le test case.")
                .WithExpectedOutcome("Test case identifié de façon unique avec un titre clair et descriptif")
                .WithMustConstraint(m => m
                    .WithId("STEP2_MUST1")
                    .WithText("Créer un identifiant unique selon la convention de nommage (ex: TC-001, TEST-USER-LOGIN-001)")
                    .WithRationale("L'identifiant unique facilite la référence et le suivi"))
                .WithMustConstraint(m => m
                    .WithId("STEP2_MUST2")
                    .WithText("Rédiger un titre descriptif indiquant ce qui est testé")
                    .WithRationale("Un titre descriptif permet de comprendre rapidement le test sans le lire en détail"))
                .WithMustConstraint(m => m
                    .WithId("STEP2_MUST3")
                    .WithText("Suivre les conventions de l'équipe pour la nomenclature")
                    .WithRationale("La cohérence facilite l'organisation et la recherche"))
                .WithMustNotConstraint(mn => mn
                    .WithId("STEP2_MUSTNOT1")
                    .WithText("Utiliser des titres vagues comme 'Test 1' ou 'Vérifier le système'")
                    .WithRationale("Les titres génériques n'informent pas sur le contenu du test")))

            .WithStep(s => s
                .WithTitle("Déterminer la priorité et la sévérité")
                .WithDescription("Évaluer l'importance du test case et l'impact potentiel d'un défaut.")
                .WithExpectedOutcome("Priorité et sévérité assignées en fonction de l'impact métier et du risque")
                .WithMustConstraint(m => m
                    .WithId("STEP3_MUST1")
                    .WithText("Attribuer une priorité (Haute/Moyenne/Basse) selon l'importance fonctionnelle")
                    .WithRationale("La priorité guide l'ordre d'exécution et l'allocation des ressources"))
                .WithMustConstraint(m => m
                    .WithId("STEP3_MUST2")
                    .WithText("Définir la sévérité (Critique/Majeure/Mineure/Triviale) selon l'impact d'un défaut")
                    .WithRationale("La sévérité aide à prioriser la correction des défauts découverts"))
                .WithMustConstraint(m => m
                    .WithId("STEP3_MUST3")
                    .WithText("Consulter le Product Owner ou Business Analyst si nécessaire")
                    .WithRationale("La priorité doit refléter la valeur métier"))
                .WithMustNotConstraint(mn => mn
                    .WithId("STEP3_MUSTNOT1")
                    .WithText("Marquer tous les tests comme priorité haute")
                    .WithRationale("Une priorisation uniforme annule l'utilité de la priorisation")))

            .WithStep(s => s
                .WithTitle("Spécifier les préconditions")
                .WithDescription("Définir toutes les conditions qui doivent être remplies avant l'exécution du test.")
                .WithExpectedOutcome("Liste complète et claire des préconditions nécessaires")
                .WithMustConstraint(m => m
                    .WithId("STEP4_MUST1")
                    .WithText("Lister tous les prérequis système (services démarrés, configuration, etc.)")
                    .WithRationale("Les prérequis système assurent que l'environnement est prêt"))
                .WithMustConstraint(m => m
                    .WithId("STEP4_MUST2")
                    .WithText("Documenter l'état initial requis (ex: utilisateur connecté, base de données vide)")
                    .WithRationale("L'état initial définit le contexte de départ du test"))
                .WithMustConstraint(m => m
                    .WithId("STEP4_MUST3")
                    .WithText("Spécifier les données et comptes nécessaires")
                    .WithRationale("Les ressources nécessaires doivent être préparées avant l'exécution"))
                .WithMustConstraint(m => m
                    .WithId("STEP4_MUST4")
                    .WithText("Vérifier que les préconditions sont réalistes et réalisables")
                    .WithRationale("Des préconditions irréalistes rendent le test inexécutable"))
                .WithMustNotConstraint(mn => mn
                    .WithId("STEP4_MUSTNOT1")
                    .WithText("Omettre des préconditions importantes")
                    .WithRationale("Les préconditions manquantes entraînent des échecs incorrects")))

            .WithStep(s => s
                .WithTitle("Préparer les données de test")
                .WithDescription("Définir et documenter toutes les données d'entrée nécessaires pour le test.")
                .WithExpectedOutcome("Données de test complètes, documentées et réalistes")
                .WithMustConstraint(m => m
                    .WithId("STEP5_MUST1")
                    .WithText("Documenter toutes les valeurs d'entrée avec leurs formats")
                    .WithRationale("Les valeurs documentées assurent la reproductibilité"))
                .WithMustConstraint(m => m
                    .WithId("STEP5_MUST2")
                    .WithText("Inclure des données valides pour les tests positifs")
                    .WithRationale("Les tests positifs vérifient le comportement nominal"))
                .WithMustConstraint(m => m
                    .WithId("STEP5_MUST3")
                    .WithText("Inclure des données invalides pour les tests négatifs")
                    .WithRationale("Les tests négatifs vérifient la gestion des erreurs"))
                .WithMustConstraint(m => m
                    .WithId("STEP5_MUST4")
                    .WithText("Tester les valeurs limites et cas extrêmes")
                    .WithRationale("Les cas limites révèlent souvent des défauts cachés"))
                .WithMustConstraint(m => m
                    .WithId("STEP5_MUST5")
                    .WithText("Utiliser des données réalistes et représentatives")
                    .WithRationale("Les données réalistes augmentent la pertinence du test"))
                .WithMustNotConstraint(mn => mn
                    .WithId("STEP5_MUSTNOT1")
                    .WithText("Utiliser des données de production sensibles sans anonymisation")
                    .WithRationale("Les données sensibles doivent être protégées selon les réglementations")))

            .WithStep(s => s
                .WithTitle("Rédiger les étapes de test")
                .WithDescription("Écrire les actions séquentielles à effectuer lors de l'exécution du test.")
                .WithExpectedOutcome("Étapes de test claires, numérotées, séquentielles et complètes")
                .WithMustConstraint(m => m
                    .WithId("STEP6_MUST1")
                    .WithText("Numéroter chaque étape séquentiellement")
                    .WithRationale("La numérotation facilite le suivi et la référence"))
                .WithMustConstraint(m => m
                    .WithId("STEP6_MUST2")
                    .WithText("Décrire chaque action de manière claire et non ambiguë")
                    .WithRationale("La clarté évite les erreurs d'exécution et les interprétations"))
                .WithMustConstraint(m => m
                    .WithId("STEP6_MUST3")
                    .WithText("Utiliser un langage actif et des verbes d'action (cliquer, saisir, valider)")
                    .WithRationale("Le langage actif rend les instructions plus claires"))
                .WithMustConstraint(m => m
                    .WithId("STEP6_MUST4")
                    .WithText("Inclure les valeurs à saisir et les options à sélectionner")
                    .WithRationale("Les détails précis permettent une exécution exacte"))
                .WithMustConstraint(m => m
                    .WithId("STEP6_MUST5")
                    .WithText("Maintenir une granularité appropriée (ni trop détaillé, ni trop vague)")
                    .WithRationale("Le bon niveau de détail optimise la clarté et la maintenabilité"))
                .WithMustNotConstraint(mn => mn
                    .WithId("STEP6_MUSTNOT1")
                    .WithText("Écrire des étapes dépendantes de connaissances implicites")
                    .WithRationale("Les connaissances implicites créent de l'ambiguïté et des erreurs")))

            .WithStep(s => s
                .WithTitle("Définir les résultats attendus")
                .WithDescription("Spécifier le comportement ou la sortie attendue pour chaque étape de test.")
                .WithExpectedOutcome("Résultat attendu précis et vérifiable pour chaque étape")
                .WithMustConstraint(m => m
                    .WithId("STEP7_MUST1")
                    .WithText("Définir un résultat attendu pour chaque étape de test")
                    .WithRationale("Les résultats attendus permettent la validation objective"))
                .WithMustConstraint(m => m
                    .WithId("STEP7_MUST2")
                    .WithText("Rendre chaque résultat observable et vérifiable")
                    .WithRationale("Un résultat non observable ne peut pas être validé"))
                .WithMustConstraint(m => m
                    .WithId("STEP7_MUST3")
                    .WithText("Utiliser des valeurs spécifiques plutôt que des descriptions vagues")
                    .WithRationale("Les valeurs spécifiques éliminent l'ambiguïté"))
                .WithMustConstraint(m => m
                    .WithId("STEP7_MUST4")
                    .WithText("Inclure les messages, codes d'erreur et changements d'état attendus")
                    .WithRationale("Les détails complets facilitent la validation et le diagnostic"))
                .WithMustNotConstraint(mn => mn
                    .WithId("STEP7_MUSTNOT1")
                    .WithText("Utiliser des expressions vagues comme 'devrait fonctionner' ou 'affiche quelque chose'")
                    .WithRationale("L'imprécision empêche une validation objective et crée des désaccords")))

            .WithStep(s => s
                .WithTitle("Définir les post-conditions")
                .WithDescription("Spécifier l'état dans lequel le système doit se trouver après le test.")
                .WithExpectedOutcome("Post-conditions claires définissant l'état final du système")
                .WithMustConstraint(m => m
                    .WithId("STEP8_MUST1")
                    .WithText("Documenter l'état final attendu du système")
                    .WithRationale("Les post-conditions valident la cohérence globale du système"))
                .WithMustConstraint(m => m
                    .WithId("STEP8_MUST2")
                    .WithText("Inclure les vérifications de base de données ou d'état persistant")
                    .WithRationale("Les changements persistants doivent être validés"))
                .WithMustConstraint(m => m
                    .WithId("STEP8_MUST3")
                    .WithText("Spécifier les actions de nettoyage nécessaires")
                    .WithRationale("Le nettoyage assure que le test n'impacte pas les tests suivants"))
                .WithMustNotConstraint(mn => mn
                    .WithId("STEP8_MUSTNOT1")
                    .WithText("Laisser le système dans un état incohérent après le test")
                    .WithRationale("Un état incohérent peut corrompre les tests suivants")))

            .WithStep(s => s
                .WithTitle("Catégoriser et taguer le test case")
                .WithDescription("Assigner des catégories et tags pour faciliter l'organisation et la recherche.")
                .WithExpectedOutcome("Test case correctement catégorisé avec tags appropriés")
                .WithMustConstraint(m => m
                    .WithId("STEP9_MUST1")
                    .WithText("Assigner une catégorie fonctionnelle (ex: Authentification, Paiement, Reporting)")
                    .WithRationale("La catégorisation facilite l'organisation et les campagnes de test"))
                .WithMustConstraint(m => m
                    .WithId("STEP9_MUST2")
                    .WithText("Ajouter des tags pour type de test (positif, négatif, régression, smoke)")
                    .WithRationale("Les tags permettent de créer des suites de test ciblées"))
                .WithMustConstraint(m => m
                    .WithId("STEP9_MUST3")
                    .WithText("Indiquer le niveau de test (unitaire, intégration, système, acceptation)")
                    .WithRationale("Le niveau de test guide la planification et l'exécution"))
                .WithMustNotConstraint(mn => mn
                    .WithId("STEP9_MUSTNOT1")
                    .WithText("Créer de nouvelles catégories sans coordination avec l'équipe")
                    .WithRationale("La prolifération de catégories crée de la confusion")))

            .WithStep(s => s
                .WithTitle("Établir la traçabilité vers les exigences")
                .WithDescription("Créer et documenter les liens entre le test case et les exigences.")
                .WithExpectedOutcome("Liens de traçabilité complets vers toutes les exigences testées")
                .WithMustConstraint(m => m
                    .WithId("STEP10_MUST1")
                    .WithText("Lier le test case à toutes les exigences couvertes")
                    .WithRationale("La traçabilité complète assure la couverture des exigences"))
                .WithMustConstraint(m => m
                    .WithId("STEP10_MUST2")
                    .WithText("Documenter le lien dans la matrice de traçabilité")
                    .WithRationale("La matrice centralise et visualise la couverture"))
                .WithMustConstraint(m => m
                    .WithId("STEP10_MUST3")
                    .WithText("Vérifier que l'exigence n'est pas déjà couverte de façon redondante")
                    .WithRationale("Éviter la redondance optimise les efforts de test"))
                .WithMustNotConstraint(mn => mn
                    .WithId("STEP10_MUSTNOT1")
                    .WithText("Créer des test cases sans lien vers des exigences")
                    .WithRationale("Les tests non liés ne contribuent pas à la couverture mesurable")))

            .WithStep(s => s
                .WithTitle("Réviser et valider le test case")
                .WithDescription("Faire réviser le test case par un pair ou le test lead.")
                .WithExpectedOutcome("Test case révisé, validé et prêt pour exécution")
                .WithMustConstraint(m => m
                    .WithId("STEP11_MUST1")
                    .WithText("Faire réviser par un pair ou le test lead")
                    .WithRationale("La révision par les pairs améliore la qualité et détecte les erreurs"))
                .WithMustConstraint(m => m
                    .WithId("STEP11_MUST2")
                    .WithText("Vérifier la complétude (préconditions, étapes, résultats, post-conditions)")
                    .WithRationale("Un test case complet est exécutable sans questions"))
                .WithMustConstraint(m => m
                    .WithId("STEP11_MUST3")
                    .WithText("Valider la clarté et l'absence d'ambiguïté")
                    .WithRationale("La clarté assure une exécution cohérente par tous les testeurs"))
                .WithMustConstraint(m => m
                    .WithId("STEP11_MUST4")
                    .WithText("Corriger les commentaires de révision avant finalisation")
                    .WithRationale("Les commentaires améliorent la qualité et doivent être intégrés"))
                .WithMustNotConstraint(mn => mn
                    .WithId("STEP11_MUSTNOT1")
                    .WithText("Marquer comme prêt sans révision par les pairs")
                    .WithRationale("La révision est essentielle pour détecter les erreurs et ambiguïtés")))

            .WithStep(s => s
                .WithTitle("Exécuter le test case et documenter les résultats")
                .WithDescription("Exécuter le test case dans l'environnement approprié et enregistrer les résultats.")
                .WithExpectedOutcome("Test case exécuté avec résultats documentés (Pass/Fail) et preuves")
                .WithMustConstraint(m => m
                    .WithId("STEP12_MUST1")
                    .WithText("Exécuter dans l'environnement de test approprié")
                    .WithRationale("L'environnement correct garantit la validité des résultats"))
                .WithMustConstraint(m => m
                    .WithId("STEP12_MUST2")
                    .WithText("Documenter le statut de chaque étape (Pass/Fail/Blocked)")
                    .WithRationale("Le statut détaillé facilite le diagnostic des échecs"))
                .WithMustConstraint(m => m
                    .WithId("STEP12_MUST3")
                    .WithText("Capturer les preuves (captures d'écran, logs) en cas d'échec")
                    .WithRationale("Les preuves sont essentielles pour la correction des défauts"))
                .WithMustConstraint(m => m
                    .WithId("STEP12_MUST4")
                    .WithText("Créer un défaut détaillé si le test échoue")
                    .WithRationale("Les défauts documentés permettent la correction et le suivi"))
                .WithMustConstraint(m => m
                    .WithId("STEP12_MUST5")
                    .WithText("Enregistrer la date, l'exécutant et l'environnement d'exécution")
                    .WithRationale("Le contexte d'exécution aide à reproduire et diagnostiquer"))
                .WithMustNotConstraint(mn => mn
                    .WithId("STEP12_MUSTNOT1")
                    .WithText("Marquer comme Pass si une seule étape a échoué")
                    .WithRationale("Un échec partiel invalide le test case complet")))

            .WithStep(s => s
                .WithTitle("Maintenir et mettre à jour le test case")
                .WithDescription("Garder le test case à jour lorsque les exigences ou le système évoluent.")
                .WithExpectedOutcome("Test case maintenu à jour et synchronisé avec les exigences actuelles")
                .WithMustConstraint(m => m
                    .WithId("STEP13_MUST1")
                    .WithText("Réviser le test case lorsque l'exigence associée change")
                    .WithRationale("Les modifications d'exigences doivent être reflétées dans les tests"))
                .WithMustConstraint(m => m
                    .WithId("STEP13_MUST2")
                    .WithText("Marquer comme obsolète les test cases qui ne sont plus pertinents")
                    .WithRationale("Les tests obsolètes créent du bruit et gaspillent des ressources"))
                .WithMustConstraint(m => m
                    .WithId("STEP13_MUST3")
                    .WithText("Documenter l'historique des modifications importantes")
                    .WithRationale("L'historique aide à comprendre l'évolution du test"))
                .WithMustConstraint(m => m
                    .WithId("STEP13_MUST4")
                    .WithText("Archiver les anciens test cases plutôt que les supprimer")
                    .WithRationale("L'archivage préserve l'historique pour référence future")))

            .Build();

        prompt.Blueprints = [.. prompt.Blueprints, blueprint];

        return Task.CompletedTask;
    }
}
