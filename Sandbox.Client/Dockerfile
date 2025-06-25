# Build stage
FROM node:20 AS build

WORKDIR /app

COPY package*.json ./
RUN npm install

# Copy app source
COPY . .

# Replace API URL in environment.prod.ts
ARG API_URL=http://api/api
RUN sed -i "s|apiUrl: '.*'|apiUrl: '${API_URL}'|" src/environments/environment.prod.ts

# Build the app using the production config
RUN npm run build -- --configuration production

# Serve with nginx
FROM nginx:alpine

COPY --from=build /app/dist/sandbox-client/browser /usr/share/nginx/html

EXPOSE 80
