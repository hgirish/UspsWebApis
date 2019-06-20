Local loRequest as Microsoft.XMLHTTP
CLEAR 
lcAddress1 = "123 main  street"
lcAddress2 = ""
lcCity = "Culver City"
lcState = "CA"
lcZip = ""

lcBaseUrl = "https://localhost:5001/api/addressvalidation/"

loRequest = CREATEOBJECT("Microsoft.XMLHTTP")
url =  lcBaseUrl + "?address1="+lcAddress1 + "&address2=" + lcAddress2 +"&city="+lcCity+"&State=" + lcState + "&zip=" + lcZip 
?url
*** or ***

*** Make the service call
loAlbums = loRequest.open("GET",url)
loRequest.send()
Do While loRequest.readyState <>4
   Doevents && Force && when using VFP9
ENDDO
lcJsonStr = loRequest.responseText
*** inspect the result
*? loRequest.status && 200 means ok, 404 not found etc. http status numbers see wikipedia, w3c, google them, etc.
? Left(loRequest.responseText,1000)

*** https://github.com/Irwin1985/jsonfox
*SET PROCEDURE TO jsonfox.prg additive
**SET PATH TO " d:\myvfp\jsonfox\" additive
 loJSON = NewObject("JSONFox", "d:\myvfp\jsonfox\jsonfox.prg")
 obj = loJSON.decode(lcJsonStr)
 
  
 * Don't forget check the LastErrorText
 If !Empty(loJson.LastErrorText) 
 	MessageBox(loJson.LastErrorText, 0+48, "Something went wrong")
	Release loJson
	Return
 EndIf
 
loAddr = obj._address
IF !ISNULL(loAddr._Error)
loErr = loaddr._Error
?loErr._Number
?loErr._Description
?loErr._HelpFile
?loErr._HelpContext
ELSE 
?loaddr._Address1
?loaddr._Address2
?loaddr._city
?loaddr._state
?loaddr._zip4
?loaddr._zip5
?loaddr._FirmName
?loAddr._Business
?loaddr._Urbanization
?loAddr._FootNotes

ENDIF


 
 
 *** Display Object Like loAddr