# Teilnehmer Verwaltung v4

## Teilnehmer Daten generieren
Bis jetzt haben wir die Teilnehmerdaten mit denen wir arbeiten wollen, über die Console eingegeben. Dies kann mühsam werden wenn wir pro Teilnehmer mehr Daten erfassen wollen oder wenn es mal 500 Teilnehmer sein sollen.
Deshalb sollen in der Version 4 die Daten aus einer öffentlichen Datenquelle abgefragt und verwendet werden.

Der REST Endpunkt https://randomuser.me/api/ liefert zufällige Personendaten, welche abgerufen und für Teilnehmer verwendet werden können. Dazu muss ein REST Client verwendet werden.

REST Grundlagen: 
- https://www.computerweekly.com/de/definition/Representational-State-Transfer-REST
- https://www.ibm.com/de-de/topics/rest-apis
- uvm.


How it works in C#: 
https://ironpdf.com/blog/net-help/restsharp-csharp/


## Aufgaben
- Lies dich in das Thema REST ein. 
- Erstelle eine kleine C# Consolen Applikation welche Daten von einer REST API konsumiert und diese "schön" darstellt.
- Bau den REST Endpunkt https://randomuser.me/api/ als Teilnehmer Daten Lieferant in eine Teilnehmer Verwaltung v4 Applikation ein,
  und speichere die Teilnehmerdaten in einer MongoDB. Dabei soll der REST-Client in eine eigene Klasse gekapselt werden.



![konzept](/doc/images/teilnehmerverwaltungV4-konzept.drawio.png)
