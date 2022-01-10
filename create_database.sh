MODEL_LIST=("Building" \
"BuildingLevel" \
"BuildingLevelSize" \
"BuildingStyle" \
"BuildingAnimSetting" \
"Character" \
"Diary" \
"DiaryTitle" \
"Island" \
"Story" \
"StoryDialogue" \
"EnvironmentMusic" \
"SoundSetting")

cd google-sheet-api-service

# rm -rf Migrations/*
# for((i=0; i<${#MODEL_LIST[@]};i++))
# do
#     echo ${MODEL_LIST[i]}
#     MVC_CONTEXT_NAME="Mvc${MODEL_LIST[i]}Context"

#     rm -rf ${MVC_CONTEXT_NAME}*.db
#     dotnet ef migrations add InitialCreate --context ${MVC_CONTEXT_NAME}
#     dotnet ef database update --context ${MVC_CONTEXT_NAME}
# done

MODEL_NAME="SoundSetting"
rm -rf Migrations/Mvc${MODEL_NAME}*
MVC_CONTEXT_NAME="Mvc${MODEL_NAME}Context"

rm -rf ${MVC_CONTEXT_NAME}*.db
dotnet ef migrations add InitialCreate --context ${MVC_CONTEXT_NAME}
dotnet ef database update --context ${MVC_CONTEXT_NAME}
