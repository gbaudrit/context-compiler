using ContextCompiler.Modules.Abstractions;
using ContextCompiler.Abstractions.Common;
using ContextCompiler.Prompting.Abstractions;
using ContextCompiler.Prompting.Abstractions.Prompt;
using ContextCompiler.Prompting.Abstractions.Pipelines.PromptComposition;

namespace ContextCompiler.Blueprints.Agile.UserStory;

internal sealed class AgileUserStoryBlueprintComposer(
    IPrompt prompt,
    IBlueprintBuilder blueprintBuilder,
    IBlueprintStepBuilder stepBuilder) : IBlueprintComposerModule
{
    public ModuleMetadata Metadata => IGlobalPipelineModule.Meta("blueprints.agile.userstory", GlobalPipelineModuleKinds.OutputComposition, priority: 10);

    public async Task<IResult<IPromptComposerRunResult>> Run(IPromptComposerRunContext context, CancellationToken cancellationToken)
    {
        IBlueprint blueprint = blueprintBuilder
            .InitNew()
            .WithId("agile.userstory")
            .WithName("Rédaction de User Story Agile")
            .WithDescription("Blueprint pour rédiger des User Stories Agile de haute qualité avec critères d'acceptation, principes INVEST, et Definition of Ready/Done.")

            // === OBJECTIFS ===
            .WithObjective(o => o
                .WithId("OBJ-US-1")
                .WithDescription("Rédiger des User Stories qui apportent une valeur claire au métier")
                .WithRationale("La valeur métier justifie l'investissement et guide la priorisation"))
            .WithObjective(o => o
                .WithId("OBJ-US-2")
                .WithDescription("Assurer que les User Stories sont testables et estimables")
                .WithRationale("La testabilité et l'estimabilité sont essentielles pour la planification et la validation"))
            .WithObjective(o => o
                .WithId("OBJ-US-3")
                .WithDescription("Garantir la complétude et la qualité des critères d'acceptation")
                .WithRationale("Des critères complets et clairs évitent les malentendus et facilitent les tests"))
            .WithObjective(o => o
                .WithId("OBJ-US-4")
                .WithDescription("Faciliter la communication entre Product Owner, équipe de développement et parties prenantes")
                .WithRationale("Une communication efficace réduit les risques et améliore la collaboration"))

            // === CONTRAINTES GLOBALES ===
            .WithGlobalMustConstraint(m => m
                .WithId("MUST-US-1")
                .WithText("Utiliser le format standard : 'En tant que [rôle], je veux [fonctionnalité] afin de [bénéfice métier]'")
                .WithRationale("Le format standard assure la cohérence et la compréhension par tous"))
            .WithGlobalMustConstraint(m => m
                .WithId("MUST-US-2")
                .WithText("Valider chaque User Story avec les critères INVEST")
                .WithRationale("INVEST garantit la qualité et la valeur de chaque User Story"))
            .WithGlobalMustConstraint(m => m
                .WithId("MUST-US-3")
                .WithText("Rédiger les critères d'acceptation au format Given/When/Then")
                .WithRationale("Le format Gherkin standardise et facilite l'automatisation des tests"))
            .WithGlobalMustConstraint(m => m
                .WithId("MUST-US-4")
                .WithText("Identifier clairement le rôle utilisateur et la valeur métier")
                .WithRationale("Le rôle et la valeur sont essentiels pour comprendre le 'qui' et le 'pourquoi'"))
            .WithGlobalMustConstraint(m => m
                .WithId("MUST-US-5")
                .WithText("Vérifier la Definition of Ready avant de démarrer le développement")
                .WithRationale("La DoR assure que la story est prête à être développée efficacement"))
            .WithGlobalMustConstraint(m => m
                .WithId("MUST-US-6")
                .WithText("Définir la Definition of Done pour valider la complétion")
                .WithRationale("La DoD fournit des critères objectifs de complétion"))
            .WithGlobalMustConstraint(m => m
                .WithId("MUST-US-7")
                .WithText("Garder les User Stories petites et réalisables dans un sprint")
                .WithRationale("Les petites stories assurent un feedback rapide et réduisent les risques"))

            .WithGlobalMustNotConstraint(mn => mn
                .WithId("MUSTNOT-US-1")
                .WithText("Écrire des spécifications techniques détaillées dans la User Story")
                .WithRationale("Les détails techniques limitent la créativité et violent le principe de négociabilité"))
            .WithGlobalMustNotConstraint(mn => mn
                .WithId("MUSTNOT-US-2")
                .WithText("Utiliser du jargon technique incompréhensible pour le métier")
                .WithRationale("Le jargon technique empêche la compréhension par le Product Owner et les parties prenantes"))
            .WithGlobalMustNotConstraint(mn => mn
                .WithId("MUSTNOT-US-3")
                .WithText("Créer des User Stories trop grandes (Epics déguisées)")
                .WithRationale("Les grandes stories violent INVEST et retardent le feedback"))
            .WithGlobalMustNotConstraint(mn => mn
                .WithId("MUSTNOT-US-4")
                .WithText("Oublier de préciser la valeur métier (le 'afin de')")
                .WithRationale("Sans valeur claire, impossible de prioriser ou justifier la story"))
            .WithGlobalMustNotConstraint(mn => mn
                .WithId("MUSTNOT-US-5")
                .WithText("Rédiger des critères d'acceptation ambigus ou non testables")
                .WithRationale("L'ambiguïté empêche la validation objective et crée des désaccords"))

            // === ASSUMPTIONS ===
            .WithAssumption(a => a
                .WithId("AS-US-1")
                .WithDescription("L'équipe pratique une méthodologie Agile (Scrum, Kanban, etc.)")
                .WithRationale("Les User Stories sont un outil Agile nécessitant un contexte itératif"))
            .WithAssumption(a => a
                .WithId("AS-US-2")
                .WithDescription("Un Product Owner ou Business Analyst est disponible pour clarifier les besoins")
                .WithRationale("La clarification continue est essentielle pour affiner les User Stories"))
            .WithAssumption(a => a
                .WithId("AS-US-3")
                .WithDescription("L'équipe utilise un outil de gestion de backlog (Jira, Azure DevOps, etc.)")
                .WithRationale("Un outil de gestion facilite la documentation et le suivi des User Stories"))
            .WithAssumption(a => a
                .WithId("AS-US-4")
                .WithDescription("Les utilisateurs finaux ou leurs représentants sont accessibles pour validation")
                .WithRationale("La validation utilisateur assure que les stories répondent aux vrais besoins"))

            // === GLOSSAIRE ===
            .WithGlossaryTerm(g => g
                .WithTerm("User Story")
                .WithDefinition("Description courte d'une fonctionnalité du point de vue de l'utilisateur final, exprimant ce qu'il veut accomplir et pourquoi"))
            .WithGlossaryTerm(g => g
                .WithTerm("INVEST")
                .WithDefinition("Critères de qualité pour User Stories : Independent, Negotiable, Valuable, Estimable, Small, Testable"))
            .WithGlossaryTerm(g => g
                .WithTerm("Critères d'acceptation")
                .WithDefinition("Conditions spécifiques qui doivent être satisfaites pour qu'une User Story soit considérée comme terminée"))
            .WithGlossaryTerm(g => g
                .WithTerm("Given/When/Then")
                .WithDefinition("Format Gherkin pour écrire des critères d'acceptation : Given (contexte), When (action), Then (résultat attendu)"))
            .WithGlossaryTerm(g => g
                .WithTerm("Definition of Ready (DoR)")
                .WithDefinition("Checklist de critères qu'une User Story doit remplir avant d'être développée"))
            .WithGlossaryTerm(g => g
                .WithTerm("Definition of Done (DoD)")
                .WithDefinition("Checklist de critères qu'une User Story doit remplir pour être considérée comme terminée"))
            .WithGlossaryTerm(g => g
                .WithTerm("Epic")
                .WithDefinition("Grande User Story qui doit être décomposée en plusieurs User Stories plus petites"))
            .WithGlossaryTerm(g => g
                .WithTerm("Story Points")
                .WithDefinition("Unité de mesure relative pour estimer l'effort nécessaire pour réaliser une User Story"))
            .WithGlossaryTerm(g => g
                .WithTerm("Persona")
                .WithDefinition("Représentation fictive d'un type d'utilisateur typique du système"))
            .WithGlossaryTerm(g => g
                .WithTerm("Backlog")
                .WithDefinition("Liste priorisée de User Stories et autres éléments de travail à réaliser"))

            // === COMMANDES ===
            .WithCommand(c => c
                .WithName("write-story")
                .WithDescription("Rédiger une nouvelle User Story complète")
                .WithExample("En tant que client enregistré, je veux pouvoir consulter mon historique de commandes afin de suivre mes achats passés"))
            .WithCommand(c => c
                .WithName("review-story")
                .WithDescription("Réviser une User Story existante selon les critères INVEST")
                .WithExample("Vérifier que la story US-123 respecte tous les critères INVEST et proposer des améliorations"))
            .WithCommand(c => c
                .WithName("split-epic")
                .WithDescription("Décomposer une Epic en User Stories plus petites")
                .WithExample("Décomposer l'Epic 'Gestion des paiements' en User Stories réalisables en un sprint"))
            .WithCommand(c => c
                .WithName("add-acceptance-criteria")
                .WithDescription("Ajouter ou améliorer les critères d'acceptation")
                .WithExample("Given l'utilisateur est connecté, When il clique sur 'Mon compte', Then il accède à son profil"))
            .WithCommand(c => c
                .WithName("validate-dor")
                .WithDescription("Vérifier qu'une User Story respecte la Definition of Ready")
                .WithExample("Vérifier que US-456 a tous les critères d'acceptation, est estimée et sans dépendances bloquantes"))

            // === STEPS ===
            .WithStep(s => s
                .WithTitle("Identifier le rôle utilisateur et le persona")
                .WithDescription("Identifier clairement qui est l'utilisateur de cette fonctionnalité et quel persona il représente.")
                .WithExpectedOutcome("Rôle utilisateur spécifique et persona clairement définis")
                .WithMustConstraint(m => m
                    .WithId("STEP1_MUST1")
                    .WithText("Définir un rôle utilisateur spécifique et concret (ex: 'client enregistré', pas juste 'utilisateur')")
                    .WithRationale("Un rôle spécifique permet de mieux comprendre les besoins et le contexte d'utilisation"))
                .WithMustConstraint(m => m
                    .WithId("STEP1_MUST2")
                    .WithText("S'assurer que le rôle correspond à un persona documenté si disponible")
                    .WithRationale("La cohérence avec les personas documentés assure une meilleure compréhension des utilisateurs"))
                .WithMustConstraint(m => m
                    .WithId("STEP1_MUST3")
                    .WithText("Vérifier que le rôle a un intérêt légitime dans la fonctionnalité")
                    .WithRationale("Seuls les rôles avec un intérêt réel garantissent une valeur métier"))
                .WithMustNotConstraint(mn => mn
                    .WithId("STEP1_MUSTNOT1")
                    .WithText("Utiliser des rôles vagues ou génériques comme 'utilisateur' ou 'personne'")
                    .WithRationale("Les rôles génériques rendent la User Story moins ciblée et moins utile")))

            .WithStep(s => s
                .WithTitle("Définir la fonctionnalité désirée")
                .WithDescription("Décrire clairement ce que l'utilisateur veut faire ou accomplir.")
                .WithExpectedOutcome("Fonctionnalité clairement définie avec un langage orienté action")
                .WithMustConstraint(m => m
                    .WithId("STEP2_MUST1")
                    .WithText("Décrire l'action ou la capacité souhaitée de manière claire et concise")
                    .WithRationale("La clarté et la concision facilitent la compréhension par tous les membres de l'équipe"))
                .WithMustConstraint(m => m
                    .WithId("STEP2_MUST2")
                    .WithText("Utiliser un langage orienté action (verbes d'action)")
                    .WithRationale("Les verbes d'action rendent la fonctionnalité plus concrète et compréhensible"))
                .WithMustConstraint(m => m
                    .WithId("STEP2_MUST3")
                    .WithText("Éviter les détails d'implémentation technique")
                    .WithRationale("La User Story doit rester focalisée sur le 'quoi' et le 'pourquoi', pas le 'comment'"))
                .WithMustNotConstraint(mn => mn
                    .WithId("STEP2_MUSTNOT1")
                    .WithText("Spécifier comment la fonctionnalité doit être techniquement implémentée")
                    .WithRationale("Les détails techniques limitent la créativité de l'équipe et la négociabilité")))

            .WithStep(s => s
                .WithTitle("Articuler la valeur métier")
                .WithDescription("Expliquer pourquoi cette fonctionnalité est importante et quelle valeur elle apporte.")
                .WithExpectedOutcome("Valeur métier clairement exprimée et compréhensible par tous")
                .WithMustConstraint(m => m
                    .WithId("STEP3_MUST1")
                    .WithText("Exprimer clairement le bénéfice métier ou utilisateur")
                    .WithRationale("La valeur justifie l'investissement et guide la priorisation"))
                .WithMustConstraint(m => m
                    .WithId("STEP3_MUST2")
                    .WithText("Relier la valeur à un objectif business mesurable si possible")
                    .WithRationale("Les objectifs mesurables permettent de valider le succès de la fonctionnalité"))
                .WithMustConstraint(m => m
                    .WithId("STEP3_MUST3")
                    .WithText("S'assurer que la valeur est compréhensible pour les parties prenantes non-techniques")
                    .WithRationale("Toutes les parties prenantes doivent comprendre pourquoi la story est importante"))
                .WithMustNotConstraint(mn => mn
                    .WithId("STEP3_MUSTNOT1")
                    .WithText("Utiliser des justifications techniques comme valeur métier")
                    .WithRationale("La valeur métier doit être exprimée en termes de bénéfices utilisateur ou business")))

            .WithStep(s => s
                .WithTitle("Rédiger les critères d'acceptation")
                .WithDescription("Définir les conditions précises qui doivent être satisfaites pour que la User Story soit acceptée.")
                .WithExpectedOutcome("Critères d'acceptation complets, testables et au format Given/When/Then")
                .WithMustConstraint(m => m
                    .WithId("STEP4_MUST1")
                    .WithText("Utiliser le format Given/When/Then pour chaque critère")
                    .WithRationale("Le format Gherkin standardise les critères et facilite leur compréhension et automatisation"))
                .WithMustConstraint(m => m
                    .WithId("STEP4_MUST2")
                    .WithText("Couvrir les scénarios principaux (happy path)")
                    .WithRationale("Les scénarios principaux définissent le comportement nominal attendu"))
                .WithMustConstraint(m => m
                    .WithId("STEP4_MUST3")
                    .WithText("Inclure les cas d'erreur et les scénarios alternatifs")
                    .WithRationale("Les cas d'erreur garantissent la robustesse et une meilleure expérience utilisateur"))
                .WithMustConstraint(m => m
                    .WithId("STEP4_MUST4")
                    .WithText("Rendre chaque critère testable et vérifiable")
                    .WithRationale("Les critères testables permettent une validation objective de la story"))
                .WithMustConstraint(m => m
                    .WithId("STEP4_MUST5")
                    .WithText("Numéroter ou identifier chaque critère pour faciliter les références")
                    .WithRationale("L'identification facilite la communication et le suivi durant le développement"))
                .WithMustNotConstraint(mn => mn
                    .WithId("STEP4_MUSTNOT1")
                    .WithText("Rédiger des critères ambigus avec 'environ', 'peut-être', 'si possible'")
                    .WithRationale("L'ambiguïté empêche une validation objective et crée des malentendus")))

            .WithStep(s => s
                .WithTitle("Valider avec les critères INVEST")
                .WithDescription("Vérifier que la User Story respecte les principes INVEST de qualité.")
                .WithExpectedOutcome("User Story validée selon tous les critères INVEST")
                .WithMustConstraint(m => m
                    .WithId("STEP5_MUST1")
                    .WithText("Vérifier l'indépendance : la story peut être développée seule")
                    .WithRationale("L'indépendance réduit les dépendances et permet un développement flexible"))
                .WithMustConstraint(m => m
                    .WithId("STEP5_MUST2")
                    .WithText("Vérifier la négociabilité : les détails d'implémentation sont flexibles")
                    .WithRationale("La négociabilité permet à l'équipe de trouver la meilleure solution technique"))
                .WithMustConstraint(m => m
                    .WithId("STEP5_MUST3")
                    .WithText("Vérifier la valeur : apporte un bénéfice clair à l'utilisateur ou au business")
                    .WithRationale("Toute story doit justifier son développement par une valeur claire"))
                .WithMustConstraint(m => m
                    .WithId("STEP5_MUST4")
                    .WithText("Vérifier l'estimabilité : l'équipe peut estimer l'effort nécessaire")
                    .WithRationale("L'estimation permet la planification et l'engagement de l'équipe"))
                .WithMustConstraint(m => m
                    .WithId("STEP5_MUST5")
                    .WithText("Vérifier la taille : peut être complétée dans un sprint")
                    .WithRationale("Une taille appropriée assure un feedback rapide et réduit les risques"))
                .WithMustConstraint(m => m
                    .WithId("STEP5_MUST6")
                    .WithText("Vérifier la testabilité : peut être testée objectivement")
                    .WithRationale("La testabilité garantit qu'on peut valider objectivement la complétion"))
                .WithMustNotConstraint(mn => mn
                    .WithId("STEP5_MUSTNOT1")
                    .WithText("Accepter une User Story qui viole un ou plusieurs critères INVEST sans la décomposer")
                    .WithRationale("Les violations d'INVEST indiquent des problèmes qui doivent être résolus")))

            .WithStep(s => s
                .WithTitle("Définir la Definition of Ready")
                .WithDescription("Établir les critères qui doivent être remplis avant de commencer le développement.")
                .WithExpectedOutcome("User Story prête à être développée avec tous les critères DoR satisfaits")
                .WithMustConstraint(m => m
                    .WithId("STEP6_MUST1")
                    .WithText("Vérifier que la User Story est clairement rédigée et compréhensible")
                    .WithRationale("La clarté évite les malentendus et les retours en arrière durant le développement"))
                .WithMustConstraint(m => m
                    .WithId("STEP6_MUST2")
                    .WithText("S'assurer que les critères d'acceptation sont complets")
                    .WithRationale("Des critères complets définissent clairement le périmètre et les attentes"))
                .WithMustConstraint(m => m
                    .WithId("STEP6_MUST3")
                    .WithText("Confirmer que les dépendances sont identifiées et gérées")
                    .WithRationale("Les dépendances non identifiées peuvent bloquer le développement"))
                .WithMustConstraint(m => m
                    .WithId("STEP6_MUST4")
                    .WithText("Valider que la story est estimée par l'équipe")
                    .WithRationale("L'estimation collective reflète la compréhension partagée et l'engagement"))
                .WithMustConstraint(m => m
                    .WithId("STEP6_MUST5")
                    .WithText("Vérifier que le Product Owner a priorisé la story dans le backlog")
                    .WithRationale("La priorisation guide le travail de l'équipe vers la valeur maximale")))

            .WithStep(s => s
                .WithTitle("Définir la Definition of Done")
                .WithDescription("Établir les critères de complétion qui valident que la User Story est terminée.")
                .WithExpectedOutcome("Definition of Done claire et partagée par toute l'équipe")
                .WithMustConstraint(m => m
                    .WithId("STEP7_MUST1")
                    .WithText("Spécifier que tous les critères d'acceptation sont satisfaits")
                    .WithRationale("Les critères d'acceptation définissent le périmètre fonctionnel de la story"))
                .WithMustConstraint(m => m
                    .WithId("STEP7_MUST2")
                    .WithText("Inclure les exigences de tests (unitaires, intégration, acceptation)")
                    .WithRationale("Les tests garantissent la qualité et la non-régression"))
                .WithMustConstraint(m => m
                    .WithId("STEP7_MUST3")
                    .WithText("Définir les critères de qualité code (revue de code, standards)")
                    .WithRationale("La qualité du code assure la maintenabilité à long terme"))
                .WithMustConstraint(m => m
                    .WithId("STEP7_MUST4")
                    .WithText("Spécifier les exigences de documentation si nécessaire")
                    .WithRationale("La documentation facilite la compréhension et l'utilisation future"))
                .WithMustConstraint(m => m
                    .WithId("STEP7_MUST5")
                    .WithText("Inclure la démo au Product Owner et validation métier")
                    .WithRationale("La validation métier confirme que la story répond au besoin")))

            .WithStep(s => s
                .WithTitle("Ajouter les notes techniques et dépendances")
                .WithDescription("Documenter les considérations techniques, contraintes et dépendances identifiées.")
                .WithExpectedOutcome("Notes techniques complètes avec dépendances et questions ouvertes documentées")
                .WithMustConstraint(m => m
                    .WithId("STEP8_MUST1")
                    .WithText("Identifier les dépendances avec d'autres User Stories ou composants")
                    .WithRationale("Les dépendances identifiées permettent une meilleure planification"))
                .WithMustConstraint(m => m
                    .WithId("STEP8_MUST2")
                    .WithText("Documenter les contraintes techniques connues")
                    .WithRationale("Les contraintes techniques influencent la conception et l'estimation"))
                .WithMustConstraint(m => m
                    .WithId("STEP8_MUST3")
                    .WithText("Lister les questions ouvertes nécessitant clarification")
                    .WithRationale("Les questions ouvertes doivent être résolues avant le développement"))
                .WithMustNotConstraint(mn => mn
                    .WithId("STEP8_MUSTNOT1")
                    .WithText("Imposer une solution technique spécifique dans les notes")
                    .WithRationale("L'équipe doit pouvoir choisir la meilleure solution durant le développement")))

            .WithStep(s => s
                .WithTitle("Estimer et dimensionner la User Story")
                .WithDescription("Évaluer l'effort nécessaire et vérifier que la taille est appropriée.")
                .WithExpectedOutcome("User Story estimée collectivement et de taille appropriée pour un sprint")
                .WithMustConstraint(m => m
                    .WithId("STEP9_MUST1")
                    .WithText("Estimer avec l'équipe de développement (Planning Poker, T-shirt sizing, etc.)")
                    .WithRationale("L'estimation collective reflète la compréhension partagée et l'engagement de l'équipe"))
                .WithMustConstraint(m => m
                    .WithId("STEP9_MUST2")
                    .WithText("Vérifier que l'estimation est dans une fourchette raisonnable pour un sprint")
                    .WithRationale("Une story doit pouvoir être complétée dans un sprint pour assurer un feedback rapide"))
                .WithMustConstraint(m => m
                    .WithId("STEP9_MUST3")
                    .WithText("Documenter les Story Points ou la taille estimée")
                    .WithRationale("L'estimation documentée aide à la planification et au suivi de vélocité"))
                .WithMustConstraint(m => m
                    .WithId("STEP9_MUST4")
                    .WithText("Si trop grande, identifier comment décomposer en stories plus petites")
                    .WithRationale("Les stories trop grandes doivent être décomposées pour respecter le principe INVEST"))
                .WithMustNotConstraint(mn => mn
                    .WithId("STEP9_MUSTNOT1")
                    .WithText("Laisser le Product Owner estimer seul sans l'équipe de développement")
                    .WithRationale("Seule l'équipe de développement peut estimer l'effort technique réaliste")))

            .WithStep(s => s
                .WithTitle("Prioriser et placer dans le backlog")
                .WithDescription("Déterminer la priorité de la User Story et la positionner dans le backlog produit.")
                .WithExpectedOutcome("User Story priorisée et positionnée dans le backlog")
                .WithMustConstraint(m => m
                    .WithId("STEP10_MUST1")
                    .WithText("Évaluer la valeur métier et l'urgence")
                    .WithRationale("La valeur et l'urgence guident la priorisation et la planification"))
                .WithMustConstraint(m => m
                    .WithId("STEP10_MUST2")
                    .WithText("Considérer les dépendances et contraintes de livraison")
                    .WithRationale("Les dépendances et contraintes peuvent affecter l'ordre de réalisation"))
                .WithMustConstraint(m => m
                    .WithId("STEP10_MUST3")
                    .WithText("Positionner dans le backlog en fonction de la priorité")
                    .WithRationale("Un backlog ordonné par priorité maximise la valeur livrée"))
                .WithMustConstraint(m => m
                    .WithId("STEP10_MUST4")
                    .WithText("Relier à un Epic ou une Initiative si applicable")
                    .WithRationale("Le lien avec les Epics et Initiatives assure la cohérence stratégique")))

            .WithStep(s => s
                .WithTitle("Réviser et affiner avec les parties prenantes")
                .WithDescription("Valider la User Story avec le Product Owner, l'équipe et les parties prenantes.")
                .WithExpectedOutcome("User Story validée, affinée et prête avec accord de toutes les parties prenantes")
                .WithMustConstraint(m => m
                    .WithId("STEP11_MUST1")
                    .WithText("Organiser une session de refinement avec l'équipe")
                    .WithRationale("Le refinement collectif améliore la compréhension partagée"))
                .WithMustConstraint(m => m
                    .WithId("STEP11_MUST2")
                    .WithText("Clarifier les ambiguïtés et questions ouvertes")
                    .WithRationale("Les ambiguïtés résolues évitent les malentendus durant le développement"))
                .WithMustConstraint(m => m
                    .WithId("STEP11_MUST3")
                    .WithText("Obtenir l'accord du Product Owner sur la formulation finale")
                    .WithRationale("L'accord du Product Owner valide que la story répond au besoin métier"))
                .WithMustConstraint(m => m
                    .WithId("STEP11_MUST4")
                    .WithText("Mettre à jour la User Story avec les retours et clarifications")
                    .WithRationale("Une documentation à jour garantit que tous partagent la même compréhension")))

            .Build();

        prompt.Blueprints = [.. prompt.Blueprints, blueprint];

        return await context.Success();
    }
}
