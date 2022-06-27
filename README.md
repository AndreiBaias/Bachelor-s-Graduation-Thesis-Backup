# Graduation thesis

## Research on the topic of training NPCs using Reinforcement Learning and Curriculum Learning

### Coordinator : Associate Professor Doctor Ciprian Paduraru 

#### How to replicate the experiments:

1. Download Unity version [2021.1.16.f1](https://unity3d.com/unity/whats-new/2021.1.16) (Unity Hub is not required but is recommended)
2. Download ML-Agent [release 18](https://github.com/Unity-Technologies/ml-agents/releases/tag/release_18) (read official documentation and make sure you install the right Python version etc.)
3. Pull repo but don't open project
4. Open file ../BTreeGeneticFramework-master/Packages/manifest.json and do the following:
    * change line "com.unity.ml-agents": "file:C:/repos/ml-agents/com.unity.ml-agents" to your ML-Agents path
    * change line "com.unity.ml-agents.extensions": "file:C:/repos/ml-agents/com.unity.ml-agents.extensions" to your ML-Agents extensions path
5. Open file ..BTreeGeneticFramework-master/Packages/packages-lock.json and do the same changes as per point 4
6. Open the project and make sure you have ML-Agents and ML-Agents extensions version 2.0.0-pre.3 or version 2.1.0-exp.1
7. (Optional) Build the game
8. (Optional) Create a Python venv
9. Train the agent following the instructions provided by the official ML-Agents documentation e.g.

cd D:\Curriculum-Learning\BTreeGeneticFramework-master

\venv\Scripts\activate

mlagents-learn D:\Curriculum-Learning\BTreeGeneticFramework-master\Configs\ConfigSAC50.yaml --env="D:\Curriculum-Learning\BTreeGeneticFramework-master\BuiltGame\UniteBoston2015TrainingDay.exe" --num-envs=30 --run-id=SAC50 --time-scale=16 --no-graphics

10. Use tensorboard for an overview of the training process
tensorboard --logdir results --port 6006
