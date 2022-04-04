FROM node:alpine AS builder

WORKDIR /app

COPY ./package.json ./package-lock.json ./
RUN npm install

COPY . /app/
RUN npm run build-prod

FROM nginx:alpine

COPY --from=builder /app/dist/by-coders.importer /usr/share/nginx/html
COPY ./nginx.conf /etc/nginx/nginx.conf