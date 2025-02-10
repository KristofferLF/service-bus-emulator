1. Last ned og installer Docker Desktop
   - Velg å bruke WSL 2 dersom du får valget
2. Installer WSL
   - https://learn.microsoft.com/en-us/windows/wsl/install
3. Konfigurer Docker til å bruke WSL dersom du ikke fikk valget om å bruke WSL tidligere
   - https://docs.docker.com/desktop/features/wsl/#:%7E:text=Turn%20on%20Docker%20Desktop%20WSL%202%201%20Download,engine%20..%20...%206%20Select%20Apply%20%26%20Restart
4. Sjekk at Docker Engine kjører ved å gå inn i programmet og se nederst til venstre i taskbaren
5. Klon ned Git-repoet med filene til workshoppen
   - https://github.com/KristofferLF/service-bus-emulator

  
Herfra skal man arbeide videre i "EgetOppsett"-prosjektet i repoet som ble klonet ned. Det er også et "Løsningsforslag"-prosjekt der man kan finne noen tips dersom man skulle stå fast.


6. Endre på CONFIG_PATH i ".env"-filen i "Docker"-mappen til å tilsvare pathen til "config.json"-filen fra repoet
   - F.eks. "C:\git\service-bus-emulator\Fagkveld\Løsningforslag\Docker\config.json"
7. Lagre endringene og kjør denne kommandoen i PowerShell: "docker compose -f <path_til_docker-compose.yaml> up -d"
   - Erstatt med pathen til "docker-compose.yaml"-filen


Steg 8 trenger bare å gjøres dersom det oppsto en feil i steg 7. Hvis det ikke oppsto en feil, fortsett til steg 9.


8. Dersom du fikk en feil i steg 7 ved nedlastning av imagene til Docker:
   1. Last ned de lokalene imagene til emulatoren og SQL Edge
   2. Bruk kommandoen "docker load --input <filnavn.tar>" for å laste inn imagene til Docker
      - Pass på at Docker Engine kjører samtidig
   3. Endre på "image"-verdien for både "servicebus-emulator" og "sqledge" til å tilsvare navnet på imaget (filnavnet)
   4. Kjøre kommandoen fra steg 7 på nytt


9. Åpne løsningen lokalt i Visual Studio eller en annen IDE
10. Kjør løsningen og se at ID-en til den nyeste messagen oppdaterer seg for hver kjøring
