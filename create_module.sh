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
"EnvironmentMusic")

# dotnet-aspnet-codegenerator controller -name MoviesController -m Movie -dc MvcMovieContext --relativeFolderPath Controllers --useDefaultLayout --referenceScriptLibraries

cd google-sheet-api-service
# rm -rf Migrations/*
# for((i=0; i<${#MODEL_LIST[@]};i++))
# do
#     echo ${MODEL_LIST[i]}
#     CONTROLLER_NAME="${MODEL_LIST[i]}Controller"
#     MVC_CONTEXT_NAME="Mvc${MODEL_LIST[i]}Context"

#     rm -rf Controllers/${CONTROLLER_NAME}.cs \
#     Data/${MVC_CONTEXT_NAME}.cs \
#     Views/${MODEL_LIST[i]}*

#     dotnet-aspnet-codegenerator controller -name ${CONTROLLER_NAME} -m ${MODEL_LIST[i]} -dc ${MVC_CONTEXT_NAME} --relativeFolderPath Controllers --useDefaultLayout --referenceScriptLibraries -sqlite
# done

MODEL_NAME="EnvironmentMusic"
rm -rf Migrations/Mvc${MODEL_NAME}*
CONTROLLER_NAME="${MODEL_NAME}Controller"
MVC_CONTEXT_NAME="Mvc${MODEL_NAME}Context"

rm -rf Controllers/${CONTROLLER_NAME}.cs \
Data/${MVC_CONTEXT_NAME}.cs \
Views/${MODEL_NAME}*
dotnet-aspnet-codegenerator controller -name ${CONTROLLER_NAME} -m ${MODEL_NAME} -dc ${MVC_CONTEXT_NAME} --relativeFolderPath Controllers --useDefaultLayout --referenceScriptLibraries -sqlite