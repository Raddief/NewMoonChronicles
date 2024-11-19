// Ide stage
/*
{
    "levels": [
        {
            "levelid": 1,
            "description": "The Surface",
            "levels": [
                {
                    "id": 1,
                    "description": "You step down onto the moon's surface, bleak and empty. You have four options:",
                    "options": [
                        {
                            "id": 1,
                            "action": "Wander",
                            "description": "You decide to wander around the forest.",
                            "feedback": [
                                {
                                    "chance": 75,
                                    "result": "You find nothing.",
                                    "flag": "nothing"
                                },
                                {
                                    "chance": 25,
                                    "result": "You find a moon bug.",
                                    "flag": "moon_bug"
                                }
                            ]
                        },
                        {
                            "id": 2,
                            "action": "Check Rocks",
                            "description": "You decide to check the rocks nearby.",
                            "feedback": [
                                {
                                    "chance": 40,
                                    "result": "You find a penny.",
                                    "flag": "penny"
                                },
                                {
                                    "chance": 60,
                                    "result": "You find nothing.",
                                    "flag": "nothing"
                                }
                            ]
                        },
                        {
                            "id": 3,
                            "action": "Move North",
                            "description": "You decide to move north.",
                            "feedback": [
                                {
                                    "chance": 100,
                                    "result": "The surface seems similar.",
                                    "flag": "move_stage",
                                    "nextStageId": "2"
                                }
                            ]
                        },
                        {
                            "id": 4,
                            "action": "Shout",
                            "description": "You decide to shout and see if anyone responds.",
                            "feedback": [
                                {
                                    "chance": 100,
                                    "result": "You hear nothing but silence.",
                                    "flag": "nothing"
                                }
                            ]
                        },
                        {
                            "id": 5,
                            "action": "Approach Shopkeeper",
                            "description": "Check the shopkeeper.",
                            "feedback": [
                                {
                                    "chance": 100,
                                    "result": "You walk towards the strange humanoid.",
                                    "flag": "open_shop"
                                }
                            ]
                        },
                        {
                            "id": 6,
                            "action": "Check Inventory",
                            "description": "You decide to check your inventory.",
                            "feedback": [
                                {
                                    "chance": 100,
                                    "result": "You open your inventory.",
                                    "flag": "check_inv"
                                }
                            ]
                        }
                    ]
                },
                {
                    "id": 2,
                    "description": "You are now in the northern area. You have two options:",
                    "options": [
                        {
                            "id": 1,
                            "action": "Shout",
                            "description": "You decide to shout and see if anyone responds.",
                            "feedback": [
                                {
                                    "chance": 100,
                                    "result": "You hear nothing but silence.",
                                    "flag": "nothing"
                                }
                            ]
                        },
                        {
                            "id": 2,
                            "action": "Move South",
                            "description": "You decide to move back south.",
                            "feedback": [
                                {
                                    "chance": 100,
                                    "result": "You move back to the previous area.",
                                    "flag": "move_stage",
                                    "nextStageId": "1"
                                }
                            ]
                        },
                        {
                            "id": 3,
                            "action": "Check Inventory",
                            "description": "You decide to check your inventory.",
                            "feedback": [
                                {
                                    "chance": 100,
                                    "result": "You open your inventory.",
                                    "flag": "check_inv"
                                }
                            ]
                        },
                        {
                            "id": 4,
                            "action": "Combat Dummy",
                            "description": "Test the combat system [!]",
                            "feedback": [
                                {
                                    "chance": 100,
                                    "result": "You enter a dreamlike state.",
                                    "flag": "combat",
                                    "entityName": "Space Goblin... or something.",
                                    "hp": 50,
                                    "attack": 60,
                                    "defense": 5,
                                    "agility": 5,
                                    "experience": 0,
                                    "level": 1,
                                    "gold": 7
                                }
                            ]
                        }
                    ]
                }
            ]
        },
        {
            "levelid": 2,
            "description": "Lunar Forest",
            "levels": [
                {
                    "id": 1,
                    "description": "You enter the second floor. You have three options:",
                    "options": [
                        {
                            "id": 1,
                            "action": "Explore",
                            "description": "You decide to explore the area.",
                            "feedback": [
                                {
                                    "chance": 50,
                                    "result": "You find nothing.",
                                    "flag": "nothing"
                                },
                                {
                                    "chance": 50,
                                    "result": "You find a hidden treasure.",
                                    "flag": "treasure"
                                }
                            ]
                        },
                        {
                            "id": 2,
                            "action": "Fight Monster",
                            "description": "You encounter a monster.",
                            "feedback": [
                                {
                                    "chance": 100,
                                    "result": "You engage in combat with a monster.",
                                    "flag": "combat",
                                    "entityName": "Monster",
                                    "hp": 100,
                                    "attack": 20,
                                    "defense": 10,
                                    "agility": 10,
                                    "experience": 50,
                                    "level": 2,
                                    "gold": 10
                                }
                            ]
                        },
                        {
                            "id": 3,
                            "action": "Move Up",
                            "description": "You decide to move up to the next floor.",
                            "feedback": [
                                {
                                    "chance": 100,
                                    "result": "You move up to the next floor.",
                                    "flag": "move_stage",
                                    "nextStageId": "3"
                                }
                            ]
                        }
                    ]
                }
            ]
        }
    ]
}
*/