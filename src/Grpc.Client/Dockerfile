FROM mcr.microsoft.com/dotnet/core/sdk:3.0 AS build
COPY ./Grpc.Client/ /src/Grpc.Client/
COPY ./Grpc.Proto/ /src/Grpc.Proto/
RUN set -ex; \
    dotnet publish /src/Grpc.Client -c Release -o /app;

FROM mcr.microsoft.com/dotnet/core/runtime:3.0
RUN set -ex; \
    apt-get update; \
    apt-get install -y --no-install-recommends wait-for-it; \
    echo '#!/bin/bash\ndotnet /app/Grpc.Client.dll "$@"' > /usr/local/bin/grpc-client && \
    chmod +x /usr/local/bin/grpc-client; \
    apt-get autoremove; apt-get clean; \ 
    rm -rf /var/lib/apt/lists/* /tmp/* /var/tmp/*
WORKDIR /app
COPY --from=build /app .
ENTRYPOINT [ "grpc-client" ]
CMD [ "--help" ]
