;#DropDB ImagesXafEasyTest

#Application ImagesXaf.Win
#Application ImagesXaf.Web
#IfDef ImagesXaf.Win

*Action About...
 
*Action OK

#EndIf

#IfDef ImagesXaf.Web
!Action Navigation(My Details)
#EndIf
