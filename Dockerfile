FROM nginx:1.27.2-alpine

COPY ./default-server.conf /etc/nginx/conf.d/default.conf
COPY ./app-out/wwwroot/ /usr/share/nginx/html/
