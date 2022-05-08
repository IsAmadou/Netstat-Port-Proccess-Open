Netstat: liste des ports tcp/udp ouverts avec le processus, table de routage, table arp et liste des interfaces réseaux-----------------------------------------------------------------------------------------------------------------------
Url     : http://codes-sources.commentcamarche.net/source/53690-netstat-liste-des-ports-tcp-udp-ouverts-avec-le-processus-table-de-routage-table-arp-et-liste-des-interfaces-reseauxAuteur  : ShareVBDate    : 08/08/2013
Licence :
=========

Ce document intitulé « Netstat: liste des ports tcp/udp ouverts avec le processus, table de routage, table arp et liste des interfaces réseaux » issu de CommentCaMarche
(codes-sources.commentcamarche.net) est mis à disposition sous les termes de
la licence Creative Commons. Vous pouvez copier, modifier des copies de cette
source, dans les conditions fixées par la licence, tant que cette note
apparaît clairement.

Description :
=============

Ce code est un ensemble de classes permettant de lire certaines tables d'informa
tions r&eacute;seau (par la dll iphlpapi) :
<br />-&gt; la liste des ports TCP/
UDP ouverts sur la machine avec le processus qui a ouvert la connexion
<br />-&
gt; la table ARP contenant les mappings adresses MAC &lt;-&gt; adresses IP connu
 sur la machine avec l'interface associ&eacute;e
<br />-&gt; la table de routag
e avec l'ensemble des routes connues sur la machine sur les interfaces associ&ea
cute;es
<br />-&gt; la liste des interfaces r&eacute;seaux avec le mapping vers
 des instances de la classe System.Net.NetworkInformation.NetworkInterface. Cela
 permet d'obtenir toutes informations de statistiques, d'&eacute;tat et de confi
guration fournies par cette classe
<br />
<br />Ce code permet aussi de fermer
 une connexion TCP ouverte.
<br /><a name='conclusion'></a><h2> Conclusion : </
h2>
<br />N'h&eacute;sitez pas &agrave; commenter et &agrave; noter !
