#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM microsoft/dotnet:2.2-aspnetcore-runtime-nanoserver-1803 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.2-sdk-nanoserver-1803 AS build
WORKDIR /src
COPY ["COVID19UpdatesAPI/COVID19UpdatesAPI.csproj", "COVID19UpdatesAPI/"]
RUN dotnet restore "COVID19UpdatesAPI/COVID19UpdatesAPI.csproj"
COPY . .
WORKDIR "/src/COVID19UpdatesAPI"
RUN dotnet build "COVID19UpdatesAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "COVID19UpdatesAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "COVID19UpdatesAPI.dll"]