FROM node:13.6.0-alpine as build
WORKDIR /usr/src/app
COPY src/client/ui/package.json src/client/ui/yarn.lock ./
RUN yarn config set strict-ssl false
RUN yarn
COPY src/client/ui/. ./
RUN chmod +x node_modules/.bin/react-scripts
RUN yarn build

FROM nginx:1.17.7-alpine
COPY --from=build /usr/src/app/build /usr/share/nginx/html
EXPOSE 80
CMD ["nginx", "-g", "daemon off;"]