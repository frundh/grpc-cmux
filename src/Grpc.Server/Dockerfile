FROM mcr.microsoft.com/dotnet/core/sdk:3.0 AS build
COPY ./Grpc.Server/ /src/Grpc.Server/
COPY ./Grpc.Proto/ /src/Grpc.Proto/
RUN set -ex; \
    dotnet publish /src/Grpc.Server -c Release -o /app;

FROM envoyproxy/envoy AS envoy

FROM mcr.microsoft.com/dotnet/core/aspnet:3.0
ENV ASPNETCORE_URLS "http://0.0.0.0:80"
RUN set -ex; \
    apt-get update; \
    apt-get install -y --no-install-recommends supervisor; \
    apt-get autoremove; apt-get clean; \ 
    rm -rf /var/lib/apt/lists/* /tmp/* /var/tmp/*

WORKDIR /app
COPY --from=build /app .
COPY --from=envoy /usr/local/bin/envoy /usr/local/bin/envoy
COPY ./Grpc.Server/supervisord.conf /etc/supervisor/conf.d/supervisord.conf
COPY ./Grpc.Server/envoy-cmux.yaml /etc/envoy/envoy.yaml
EXPOSE 80
ENTRYPOINT [ "supervisord", "-c", "/etc/supervisor/conf.d/supervisord.conf", "--nodaemon" ]