CREATE DEFINER=`dev-2311029`@`%` PROCEDURE `setVictoires`(in idw int, in idl int, out nbVictoires int)
begin
update fide_joueurs
set fide_joueurs.Victoires = fide_joueurs.Victoires + 1
where fide_joueurs.idJoueur = idw;

update fide_joueurs
set fide_joueurs.Defaites = fide_joueurs.Defaites + 1
where fide_joueurs.idJoueur = idl;

select fide_joueurs.Victoires into nbVictoires from fide_joueurs where fide_joueurs.idJoueur = idw ;

end