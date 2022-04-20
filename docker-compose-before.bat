Rem build the images
docker build --no-cache -t api_image -f ./LobsterInk.Adventure.Api/Dockerfile .

docker build --no-cache -t web_image -f ./LobsterInk.Adventure.Web/Dockerfile .
