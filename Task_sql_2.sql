SELECT c.ClientName, COUNT(cc.id) FROM Clients c lEFT JOIN ClientContacts cc ON c.id = cc.ClientId
GROUP BY c.id;

SELECT c.ClientName, COUNT(cc.id) as cCount FROM Clients c lEFT JOIN ClientContacts cc ON c.id = cc.ClientId
GROUP BY c.id 
HAVING cCount > 2;