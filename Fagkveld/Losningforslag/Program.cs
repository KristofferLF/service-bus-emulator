using Azure.Messaging.ServiceBus;

// Tatt fra et lignende eksempel på Azure Service Bus Emulator: https://github.com/alex-wolf-ps/service-bus-emulator

// Klienten som styrer tilkoblingen og brukes til å opprette produsenter og mottakere
ServiceBusClient client;

// Produsenten / Senderen som legger meldinger på køen.
ServiceBusSender sender;

// Mottakeren som tar i mot meldinger som ligger på køen.
ServiceBusReceiver receiver;

// Antall meldinger som skal legges på køen
const int numberOfMessages = 3;

client = new ServiceBusClient("Endpoint=sb://localhost:5672;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=SAS_KEY_VALUE;UseDevelopmentEmulator=true;");
sender = client.CreateSender("queue.1");
receiver = client.CreateReceiver("queue.1");

// Lag en meldingsbatch
using ServiceBusMessageBatch messageBatch = await sender.CreateMessageBatchAsync();

for (int i = 1; i <= numberOfMessages; i++)
{
    // Forsøk å legge en melding til i batchen
    if (!messageBatch.TryAddMessage(new ServiceBusMessage($"Melding {i}")))
    {
        // Kaster et exception dersom meldingen er for stor
        throw new Exception($"Melding {i} er for stor til å legges til i batchen.");
    }
}

try
{
    // Bruker produsenten til å legge meldingsbatchen til i køen
    await sender.SendMessagesAsync(messageBatch);
    Console.WriteLine($"Meldingsbatchen med {messageBatch.Count} meldinger har blitt lagt til i køen.\n");

    // Bruker mottakeren til å peeke den nyeste meldingen i køen
    //var meldingID = receiver.PeekMessageAsync().Id;
    var melding = receiver.ReceiveMessageAsync().Result;
    Console.WriteLine($"Hentet melding.\nID: {melding.MessageId}\nBody: {melding.Body}");
}
finally
{
    await receiver.DisposeAsync();
    await sender.DisposeAsync();
    await client.DisposeAsync();
}

Console.WriteLine("\nTrykk på hvilken som helst key for å avslutte applikasjonen.");
Console.ReadKey();