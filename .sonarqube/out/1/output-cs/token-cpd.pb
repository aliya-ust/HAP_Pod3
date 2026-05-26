©j
@C:\Users\310466\Desktop\Learning\HealthAxis\HealthApp\Program.cs
var 
services 
= 
new 
ServiceCollection $
($ %
)% &
;& '
services 
. 	
AddSingleton	 
< 
	PatientDb 
>  
(  !
)! "
;" #
services 
. 	
AddSingleton	 
< 
DoctorDb 
> 
(  
)  !
;! "
services 
. 	
AddSingleton	 
< 
HealthRecordDB $
>$ %
(% &
)& '
;' (
services 
. 	
AddSingleton	 
< 
AppointmentDb #
># $
($ %
)% &
;& '
services 
. 	
	AddScoped	 
< 
IPatientRepository %
,% &
PatientRepository' 8
>8 9
(9 :
): ;
;; <
services 
. 	
	AddScoped	 
< 
IDoctorRepository $
,$ %
DoctorRepository& 6
>6 7
(7 8
)8 9
;9 :
services 
. 	
	AddScoped	 
< #
IHealthRecordRepository *
,* +"
HealthRecordRepository, B
>B C
(C D
)D E
;E F
services 
. 	
	AddScoped	 
< "
IAppointmentRepository )
,) *!
AppointmentRepository+ @
>@ A
(A B
)B C
;C D
services 
. 	
	AddScoped	 
< 
IPatientService "
," #
PatientService$ 2
>2 3
(3 4
)4 5
;5 6
services 
. 	
	AddScoped	 
< 
IDoctorService !
,! "
DoctorService# 0
>0 1
(1 2
)2 3
;3 4
services 
. 	
	AddScoped	 
<  
IHealthRecordService '
,' (
HealthRecordService) <
>< =
(= >
)> ?
;? @
services 
. 	
	AddScoped	 
< 
IAppointmentService &
,& '
AppointmentService( :
>: ;
(; <
)< =
;= >
services 
. 	
	AddScoped	 
< 
PatientMenu 
> 
(  
)  !
;! "
services 
. 	
	AddScoped	 
< 

DoctorMenu 
> 
( 
)  
;  !
services 
. 	
	AddScoped	 
< 
HealthRecordMenu #
># $
($ %
)% &
;& '
services 
. 	
	AddScoped	 
< 
AppointmentMenu "
>" #
(# $
)$ %
;% &
var!! 
provider!! 
=!! 
services!! 
.!!  
BuildServiceProvider!! ,
(!!, -
)!!- .
;!!. /
var## 
patientMenu## 
=## 
provider## 
.## 
GetRequiredService## -
<##- .
PatientMenu##. 9
>##9 :
(##: ;
)##; <
;##< =
var$$ 

doctorMenu$$ 
=$$ 
provider$$ 
.$$ 
GetRequiredService$$ ,
<$$, -

DoctorMenu$$- 7
>$$7 8
($$8 9
)$$9 :
;$$: ;
var%% 
healthRecordMenu%% 
=%% 
provider%% 
.%%  
GetRequiredService%%  2
<%%2 3
HealthRecordMenu%%3 C
>%%C D
(%%D E
)%%E F
;%%F G
var&& 
appointmentMenu&& 
=&& 
provider&& 
.&& 
GetRequiredService&& 1
<&&1 2
AppointmentMenu&&2 A
>&&A B
(&&B C
)&&C D
;&&D E
const(( 
string(( 
ContinueMessage(( 
=(( 
$str(( ?
;((? @
bool** 
exit** 	
=**
 
false** 
;** 
while++ 
(++ 
!++ 
exit++ 
)++ 
{,, 
Console-- 
.-- 
Clear-- 
(-- 
)-- 
;-- 
Console.. 
... 
	WriteLine.. 
(.. 
$str.. >
)..> ?
;..? @
Console// 
.// 
	WriteLine// 
(// 
$str// 1
)//1 2
;//2 3
Console00 
.00 
	WriteLine00 
(00 
$str00 +
)00+ ,
;00, -
Console11 
.11 
	WriteLine11 
(11 
$str11 ;
)11; <
;11< =
Console22 
.22 
	WriteLine22 
(22 
$str22 .
)22. /
;22/ 0
Console33 
.33 
	WriteLine33 
(33 
$str33 >
)33> ?
;33? @
Console44 
.44 
	WriteLine44 
(44 
$str44 4
)444 5
;445 6
Console55 
.55 
	WriteLine55 
(55 
$str55 L
)55L M
;55M N
Console66 
.66 
	WriteLine66 
(66 
$str66 <
)66< =
;66= >
Console77 
.77 
	WriteLine77 
(77 
$str77 B
)77B C
;77C D
Console88 
.88 
	WriteLine88 
(88 
$str88 
)88  
;88  !
Console99 
.99 
Write99 
(99 
$str99 '
)99' (
;99( )
string:: 

?:: 
input:: 
=:: 
Console:: 
.:: 
ReadLine:: $
(::$ %
)::% &
;::& '
if<< 
(<< 
!<< 	
int<<	 
.<< 
TryParse<< 
(<< 
input<< 
,<< 
out<<  
int<<! $
choice<<% +
)<<+ ,
)<<, -
{== 
Console>> 
.>> 
	WriteLine>> 
(>> 
$str>> Q
)>>Q R
;>>R S
continue?? 
;?? 
}@@ 
ifBB 
(BB 
choiceBB 
<BB 
$numBB 
||BB 
choiceBB 
>BB 
$numBB  
)BB  !
{CC 
ConsoleDD 
.DD 
	WriteLineDD 
(DD 
$strDD O
)DDO P
;DDP Q
continueEE 
;EE 
}FF 
switchHH 

(HH 
choiceHH 
)HH 
{II 
caseJJ 
$numJJ 
:JJ 
ConsoleKK 
.KK 
	WriteLineKK 
(KK 
$"KK  
$strKK  "
{KK" #
patientMenuKK# .
.KK. /
RegisterPatientKK/ >
(KK> ?
)KK? @
}KK@ A
"KKA B
)KKB C
;KKC D
ConsoleLL 
.LL 
WriteLL 
(LL 
ContinueMessageLL )
)LL) *
;LL* +
ConsoleMM 
.MM 
ReadKeyMM 
(MM 
)MM 
;MM 
breakNN 
;NN 
caseOO 
$numOO 
:OO 
ConsolePP 
.PP 
	WriteLinePP 
(PP 
$"PP  
$strPP  "
{PP" #

doctorMenuPP# -
.PP- .
	AddDoctorPP. 7
(PP7 8
)PP8 9
}PP9 :
"PP: ;
)PP; <
;PP< =
ConsoleQQ 
.QQ 
WriteQQ 
(QQ 
ContinueMessageQQ )
)QQ) *
;QQ* +
ConsoleRR 
.RR 
ReadKeyRR 
(RR 
)RR 
;RR 
breakSS 
;SS 
caseTT 
$numTT 
:TT 
ListUU 
<UU 
DoctorUU 
>UU 
doctorsUU  
=UU! "

doctorMenuUU# -
.UU- .(
SearchDoctorBySpecialisationUU. J
(UUJ K
)UUK L
;UUL M
foreachVV 
(VV 
DoctorVV 
dVV 
inVV  
doctorsVV! (
)VV( )
{WW 
ConsoleXX 
.XX 
	WriteLineXX !
(XX! "
dXX" #
)XX# $
;XX$ %
}YY 
ConsoleZZ 
.ZZ 
WriteZZ 
(ZZ 
ContinueMessageZZ )
)ZZ) *
;ZZ* +
Console[[ 
.[[ 
ReadKey[[ 
([[ 
)[[ 
;[[ 
break\\ 
;\\ 
case]] 
$num]] 
:]] 
Console^^ 
.^^ 
	WriteLine^^ 
(^^ 
$"^^  
$str^^  "
{^^" #
appointmentMenu^^# 2
.^^2 3
BookAppointment^^3 B
(^^B C
)^^C D
}^^D E
"^^E F
)^^F G
;^^G H
Console__ 
.__ 
Write__ 
(__ 
ContinueMessage__ )
)__) *
;__* +
Console`` 
.`` 
ReadKey`` 
(`` 
)`` 
;`` 
breakaa 
;aa 
casebb 
$numbb 
:bb 
appointmentMenucc 
.cc 
ViewAppointmentscc ,
(cc, -
)cc- .
;cc. /
Consoledd 
.dd 
Writedd 
(dd 
ContinueMessagedd )
)dd) *
;dd* +
Consoleee 
.ee 
ReadKeyee 
(ee 
)ee 
;ee 
breakff 
;ff 
casegg 
$numgg 
:gg 
appointmentMenuhh 
.hh $
ConfirmCancelAppointmenthh 4
(hh4 5
)hh5 6
;hh6 7
Consoleii 
.ii 
Writeii 
(ii 
ContinueMessageii )
)ii) *
;ii* +
Consolejj 
.jj 
ReadKeyjj 
(jj 
)jj 
;jj 
breakkk 
;kk 
casell 
$numll 
:ll 
Consolemm 
.mm 
	WriteLinemm 
(mm 
$"mm  
$strmm  "
{mm" #
healthRecordMenumm# 3
.mm3 4
AddHealthRecordmm4 C
(mmC D
)mmD E
}mmE F
"mmF G
)mmG H
;mmH I
Consolenn 
.nn 
Writenn 
(nn 
ContinueMessagenn )
)nn) *
;nn* +
Consoleoo 
.oo 
ReadKeyoo 
(oo 
)oo 
;oo 
breakpp 
;pp 
caseqq 
$numqq 
:qq 
healthRecordMenurr 
.rr 

ViewRecordrr '
(rr' (
)rr( )
;rr) *
breakss 
;ss 
casett 
$numtt 
:tt 
Consoleuu 
.uu 
	WriteLineuu 
(uu 
$"uu  
$struu  4
{uu4 5
patientMenuuu5 @
.uu@ A
UpdatePatientuuA N
(uuN O
)uuO P
}uuP Q
"uuQ R
)uuR S
;uuS T
Consolevv 
.vv 
Writevv 
(vv 
ContinueMessagevv )
)vv) *
;vv* +
Consoleww 
.ww 
ReadKeyww 
(ww 
)ww 
;ww 
breakxx 
;xx 
caseyy 
$numyy 
:yy 
Consolezz 
.zz 
	WriteLinezz 
(zz 
$"zz  
$strzz  3
{zz3 4

doctorMenuzz4 >
.zz> ?
UpdateDoctorzz? K
(zzK L
)zzL M
}zzM N
"zzN O
)zzO P
;zzP Q
Console{{ 
.{{ 
Write{{ 
({{ 
ContinueMessage{{ )
){{) *
;{{* +
Console|| 
.|| 
ReadKey|| 
(|| 
)|| 
;|| 
break}} 
;}} 
case~~ 
$num~~ 
:~~ 
Console 
. 
	WriteLine 
( 
$"  
$str  :
{: ;
healthRecordMenu; K
.K L
UpdateHealthRecordL ^
(^ _
)_ `
}` a
"a b
)b c
;c d
Console
ÄÄ 
.
ÄÄ 
Write
ÄÄ 
(
ÄÄ 
ContinueMessage
ÄÄ )
)
ÄÄ) *
;
ÄÄ* +
Console
ÅÅ 
.
ÅÅ 
ReadKey
ÅÅ 
(
ÅÅ 
)
ÅÅ 
;
ÅÅ 
break
ÇÇ 
;
ÇÇ 
case
ÉÉ 
$num
ÉÉ 
:
ÉÉ 
exit
ÑÑ 
=
ÑÑ 
true
ÑÑ 
;
ÑÑ 
Console
ÖÖ 
.
ÖÖ 
	WriteLine
ÖÖ 
(
ÖÖ 
$str
ÖÖ 2
)
ÖÖ2 3
;
ÖÖ3 4
break
ÜÜ 
;
ÜÜ 
}
áá 
}àà ñ
[C:\Users\310466\Desktop\Learning\HealthAxis\HealthApp\ConsoleApp\Services\PatientService.cs
	namespace

 	
	HealthApp


 
.

 

ConsoleApp

 
.

 
Services

 '
{ 
public 

class 
PatientService 
:  !
IPatientService" 1
{ 
private 
readonly 
IPatientRepository +
_patientRepo, 8
;8 9
public 
PatientService 
( 
IPatientRepository 0
patientRepo1 <
)< =
{ 	
_patientRepo 
= 
patientRepo &
;& '
} 	
public 
string 
RegisterPatient %
(% &
Patient& -
patient. 5
)5 6
{ 	
List 
< 
Patient 
> 
patients "
=# $
_patientRepo% 1
.1 2
GetAllPatients2 @
(@ A
)A B
;B C
patient 
. 
	PatientId 
= 
PatientIdGenerator  2
(2 3
patients3 ;
); <
;< =
return 
_patientRepo 
.  
RegisterPatient  /
(/ 0
patient0 7
)7 8
;8 9
} 	
public 
Patient 
UpdatePatient $
($ %
Patient% ,
patient- 4
)4 5
{ 	
Patient   
?   
existingPatient   $
=  % &
GetPatientById  ' 5
(  5 6
patient  6 =
.  = >
	PatientId  > G
)  G H
;  H I
if"" 
("" 
existingPatient"" 
is""  "
null""# '
)""' (
{## 
throw$$ 
new$$ $
PatientNotFoundException$$ 2
($$2 3
$"$$3 5
$str$$5 C
{$$C D
patient$$D K
.$$K L
	PatientId$$L U
}$$U V
$str$$V e
"$$e f
)$$f g
;$$g h
}%% 
return&& 
_patientRepo&& 
.&&  
UpdatePatient&&  -
(&&- .
existingPatient&&. =
,&&= >
patient&&? F
)&&F G
;&&G H
}'' 	
public)) 
Patient)) 
?)) 
GetPatientById)) &
())& '
int))' *
id))+ -
)))- .
{** 	
Patient++ 
?++ 
patient++ 
=++ 
_patientRepo++ +
.+++ ,
GetPatientById++, :
(++: ;
id++; =
)++= >
;++> ?
if-- 
(-- 
patient-- 
is-- 
null-- 
)--  
{.. 
throw// 
new// $
PatientNotFoundException// 2
(//2 3
$"//3 5
$str//5 C
{//C D
id//D F
}//F G
$str//G V
"//V W
)//W X
;//X Y
}00 
return11 
patient11 
;11 
}22 	
public44 
static44 
int44 
PatientIdGenerator44 ,
(44, -
List44- 1
<441 2
Patient442 9
>449 :
patients44; C
)44C D
{55 	
return66 
patients66 
.66 
Any66 
(66  
)66  !
?77 
patients77 
.77 
Max77 
(77 
p77  
=>77! #
p77$ %
.77% &
	PatientId77& /
)77/ 0
+771 2
$num773 4
:88 
$num88 
;88 
}99 	
}:: 
};; Ö9
`C:\Users\310466\Desktop\Learning\HealthAxis\HealthApp\ConsoleApp\Services\HealthRecordService.cs
	namespace 	
	HealthApp
 
. 

ConsoleApp 
. 
Services '
{ 
public 

class 
HealthRecordService $
:% & 
IHealthRecordService' ;
{		 
private 
readonly #
IHealthRecordRepository 0#
_healthRecordRepository1 H
;H I
private 
readonly 
IDoctorRepository *
_doctorRepository+ <
;< =
private 
readonly 
IPatientRepository +
_patientRepository, >
;> ?
public 
HealthRecordService "
(" ##
IHealthRecordRepository# :"
healthRecordRepository; Q
,Q R
IDoctorRepository$ 5
doctorRepository6 F
,F G
IPatientRepository$ 6
patientRepository7 H
)H I
{ 	#
_healthRecordRepository #
=$ %"
healthRecordRepository& <
;< =
_doctorRepository 
= 
doctorRepository  0
;0 1
_patientRepository 
=  
patientRepository! 2
;2 3
} 	
public 
string 
AddHealthRecord %
(% &
HealthRecord& 2
record3 9
)9 :
{ 	
List 
< 
HealthRecord 
> 
records &
=' (#
_healthRecordRepository) @
.@ A
GetAllRecordsA N
(N O
)O P
;P Q
record 
. 
RecordId 
= 
RecordIdGenerator /
(/ 0
records0 7
)7 8
;8 9
return #
_healthRecordRepository *
.* +
AddHealthRecord+ :
(: ;
record; A
)A B
;B C
} 	
public"" 
List"" 
<"" 
HealthRecord""  
>""  !.
"GetByPatientIdOrderByVisitDateDesc""" D
(""D E
int""E H
id""I K
)""K L
{## 	
var$$ 
patient$$ 
=$$ 
_patientRepository$$ ,
.$$, -
GetPatientById$$- ;
($$; <
id$$< >
)$$> ?
;$$? @
if&& 
(&& 
patient&& 
==&& 
null&& 
)&&  
{'' 
throw(( 
new(( $
PatientNotFoundException(( 2
(((2 3
$str((3 [
)(([ \
;((\ ]
})) 
var++ 
records++ 
=++ #
_healthRecordRepository++ 1
.,, .
"GetByPatientIdOrderByVisitDateDesc,, 3
(,,3 4
id,,4 6
),,6 7
;,,7 8
if.. 
(.. 
records.. 
==.. 
null.. 
||..  "
records..# *
...* +
Count..+ 0
==..1 3
$num..4 5
)..5 6
{// 
throw00 
new00 )
HealthRecordNotFoundException00 7
(007 8
$str008 f
)00f g
;00g h
}11 
return33 
records33 
;33 
}44 	
public77 
List77 
<77 
HealthRecord77  
>77  !-
!GetByDoctorIdOrderByVisitDateDesc77" C
(77C D
int77D G
id77H J
)77J K
{88 	
var99 
doctor99 
=99 
_doctorRepository99 *
.99* +
GetDoctorById99+ 8
(998 9
id999 ;
)99; <
;99< =
if;; 
(;; 
doctor;; 
==;; 
null;; 
);; 
{<< 
throw== 
new== #
DoctorNotFoundException== 1
(==1 2
$str==2 Y
)==Y Z
;==Z [
}>> 
var@@ 
records@@ 
=@@ #
_healthRecordRepository@@ 1
.AA -
!GetByDoctorIdOrderByVisitDateDescAA 2
(AA2 3
idAA3 5
)AA5 6
;AA6 7
ifCC 
(CC 
recordsCC 
==CC 
nullCC 
||CC  "
recordsCC# *
.CC* +
CountCC+ 0
==CC1 3
$numCC4 5
)CC5 6
{DD 
throwEE 
newEE )
HealthRecordNotFoundExceptionEE 7
(EE7 8
$strEE8 e
)EEe f
;EEf g
}FF 
returnHH 
recordsHH 
;HH 
}II 	
publicLL 
HealthRecordLL 
UpdateHealthRecordLL .
(LL. /
HealthRecordLL/ ;
recordLL< B
)LLB C
{MM 	
HealthRecordNN 
?NN  
existingHealthRecordNN .
=NN/ 0
GetRecordByIdNN1 >
(NN> ?
recordNN? E
.NNE F
RecordIdNNF N
)NNN O
;NNO P
ifPP 
(PP  
existingHealthRecordPP $
isPP% '
nullPP( ,
)PP, -
{QQ 
throwRR 
newRR )
HealthRecordNotFoundExceptionRR 7
(RR7 8
$"RR8 :
$strRR: N
{RRN O
recordRRO U
.RRU V
RecordIdRRV ^
}RR^ _
$strRR_ n
"RRn o
)RRo p
;RRp q
}SS 
returnTT #
_healthRecordRepositoryTT *
.TT* +
UpdateHealthRecordTT+ =
(TT= > 
existingHealthRecordTT> R
,TTR S
recordTTT Z
)TTZ [
;TT[ \
}UU 	
publicXX 
HealthRecordXX 
?XX 
GetRecordByIdXX *
(XX* +
intXX+ .
recordIdXX/ 7
)XX7 8
{YY 	
HealthRecordZZ 
?ZZ 
recordZZ  
=ZZ! "#
_healthRecordRepositoryZZ# :
.ZZ: ;
GetRecordByIdZZ; H
(ZZH I
recordIdZZI Q
)ZZQ R
;ZZR S
if[[ 
([[ 
record[[ 
is[[ 
null[[ 
)[[ 
{\\ 
throw]] 
new]] )
HealthRecordNotFoundException]] 7
(]]7 8
$"]]8 :
$str]]: N
{]]N O
recordId]]O W
}]]W X
$str]]X g
"]]g h
)]]h i
;]]i j
}^^ 
return__ 
record__ 
;__ 
}`` 	
publiccc 
staticcc 
intcc 
RecordIdGeneratorcc +
(cc+ ,
Listcc, 0
<cc0 1
HealthRecordcc1 =
>cc= >
recordscc? F
)ccF G
{dd 	
returnee 
recordsee 
.ee 
Anyee 
(ee 
)ee  
?ff 
recordsff 
.ff 
Maxff 
(ff 
rff 
=>ff  "
rff# $
.ff$ %
RecordIdff% -
)ff- .
+ff/ 0
$numff1 2
:gg 
$numgg 
;gg 
}hh 	
}ii 
}jj µ%
ZC:\Users\310466\Desktop\Learning\HealthAxis\HealthApp\ConsoleApp\Services\DoctorService.cs
	namespace 	
	HealthApp
 
. 

ConsoleApp 
. 
Services '
{ 
public		 

class		 
DoctorService		 
:		  
IDoctorService		! /
{

 
private 
readonly 
IDoctorRepository *
_doctorRepo+ 6
;6 7
public 
DoctorService 
( 
IDoctorRepository .
doctorRepository/ ?
)? @
{ 	
_doctorRepo 
= 
doctorRepository *
;* +
} 	
public 
string 
	AddDoctor 
(  
Doctor  &
doctor' -
)- .
{ 	
List 
< 
Doctor 
> 
doctors  
=! "
_doctorRepo# .
.. /
GetAllDoctors/ <
(< =
)= >
;> ?
doctor 
. 
DoctorId 
= 
DoctorIdGenerator /
(/ 0
doctors0 7
)7 8
;8 9
return 
_doctorRepo 
. 
	AddDoctor (
(( )
doctor) /
)/ 0
;0 1
} 	
public 
Doctor 
? 
GetDoctorById $
($ %
int% (
id) +
)+ ,
{ 	
Doctor 
? 
doctor 
= 
_doctorRepo (
.( )
GetDoctorById) 6
(6 7
id7 9
)9 :
;: ;
if 
( 
doctor 
is 
null 
) 
{ 
throw   
new   #
DoctorNotFoundException   1
(  1 2
$"  2 4
$str  4 A
{  A B
id  B D
}  D E
$str  E T
"  T U
)  U V
;  V W
}!! 
return"" 
doctor"" 
;"" 
}## 	
public%% 
List%% 
<%% 
Doctor%% 
>%% &
GetDoctorsBySpecialisation%% 6
(%%6 7
string%%7 =
specialisation%%> L
)%%L M
{&& 	
var'' 
result'' 
='' 
_doctorRepo'' $
.''$ %&
GetDoctorsBySpecialisation''% ?
(''? @
specialisation''@ N
)''N O
;''O P
if)) 
()) 
result)) 
==)) 
null)) 
||)) !
result))" (
.))( )
Count))) .
==))/ 1
$num))2 3
)))3 4
{** 
throw++ 
new++ +
SpecialisationNotFoundException++ 9
(++9 :
$"++: <
$str++< Z
{++Z [
specialisation++[ i
}++i j
$str++j y
"++y z
)++z {
;++{ |
},, 
return.. 
result.. 
;.. 
}// 	
public11 
Doctor11 
UpdateDoctor11 "
(11" #
Doctor11# )
doctor11* 0
)110 1
{22 	
Doctor33 
?33 
existingDoctor33 "
=33# $
GetDoctorById33% 2
(332 3
doctor333 9
.339 :
DoctorId33: B
)33B C
;33C D
if55 
(55 
existingDoctor55 
is55 !
null55" &
)55& '
{66 
throw77 
new77 #
DoctorNotFoundException77 1
(771 2
$"772 4
$str774 A
{77A B
doctor77B H
.77H I
DoctorId77I Q
}77Q R
$str77R a
"77a b
)77b c
;77c d
}88 
return99 
_doctorRepo99 
.99 
UpdateDoctor99 +
(99+ ,
existingDoctor99, :
,99: ;
doctor99< B
)99B C
;99C D
}:: 	
public== 
static== 
int== 
DoctorIdGenerator== +
(==+ ,
List==, 0
<==0 1
Doctor==1 7
>==7 8
doctors==9 @
)==@ A
{>> 	
return?? 
doctors?? 
.?? 
Any?? 
(?? 
)??  
?@@ 
doctors@@ 
.@@ 
Max@@ 
(@@ 
d@@ 
=>@@  "
d@@# $
.@@$ %
DoctorId@@% -
)@@- .
+@@/ 0
$num@@1 2
:AA 
$numAA 
;AA 
}BB 	
}CC 
}DD ©_
_C:\Users\310466\Desktop\Learning\HealthAxis\HealthApp\ConsoleApp\Services\AppointmentService.cs
	namespace		 	
	HealthApp		
 
.		 

ConsoleApp		 
.		 
Services		 '
{

 
public 

class 
AppointmentService #
:$ %
IAppointmentService& 9
{ 
private 
readonly "
IAppointmentRepository /
_appointmentRepo0 @
;@ A
public 
AppointmentService !
(! ""
IAppointmentRepository" 8!
appointmentRepository9 N
)N O
{ 	
_appointmentRepo 
= !
appointmentRepository 4
;4 5
} 	
public 
string 
BookAppointment %
(% &
Patient& -
patient. 5
,5 6
Doctor7 =
doctor> D
,D E
DateTimeF N
dateO S
,S T
stringU [
slot\ `
)` a
{ 	
if 
( 
date 
< 
DateTime 
.  
Now  #
)# $
{ 
throw 
new 
PastDateException +
(+ ,
$str, R
)R S
;S T
} 
if 
( 
! 
doctor 
. 
IsAvailable #
(# $
date$ (
)( )
)) *
{ 
throw 
new &
DoctorUnavailableException 4
(4 5
$str5 `
)` a
;a b
} 
var!! 
appointments!! 
=!! 
_appointmentRepo!! /
.!!/ 0
GetAllAppointments!!0 B
(!!B C
)!!C D
;!!D E
bool## 
isSlotTaken## 
=## 
appointments## +
.##+ ,
Any##, /
(##/ 0
a##0 1
=>##2 4
a$$ 
.$$ 
Doctor$$ 
.$$ 
DoctorId$$ !
==$$" $
doctor$$% +
.$$+ ,
DoctorId$$, 4
&&$$5 7
a%% 
.%% 
ScheduledDate%% 
.%%  
Date%%  $
==%%% '
date%%( ,
.%%, -
Date%%- 1
&&%%2 4
a&& 
.&& 
TimeSlot&& 
==&& 
slot&& "
&&&&# %
a'' 
.'' 
Status'' 
!='' 
AppointmentStatus'' -
.''- .
	Cancelled''. 7
)''7 8
;''8 9
if)) 
()) 
isSlotTaken)) 
))) 
{** 
throw++ 
new++ (
AppointmentConflictException++ 6
(++6 7
$str++7 ^
)++^ _
;++_ `
},, 
var.. 
appointment.. 
=.. 
new.. !
Appointment.." -
{// 
AppointmentId00 
=00 "
AppointmentIdGenerator00  6
(006 7
appointments007 C
)00C D
,00D E
Patient11 
=11 
patient11 !
,11! "
Doctor22 
=22 
doctor22 
,22  
ScheduledDate33 
=33 
date33  $
,33$ %
TimeSlot44 
=44 
slot44 
,44  
Status55 
=55 
AppointmentStatus55 *
.55* +
Pending55+ 2
}66 
;66 
_appointmentRepo88 
.88 
AddAppointment88 +
(88+ ,
appointment88, 7
)887 8
;888 9
return99 
$"99 
$str99 '
{99' (
appointment99( 3
.993 4
AppointmentId994 A
}99A B
$str99B `
"99` a
;99a b
}:: 	
public== 
List== 
<== 
Appointment== 
>==  &
GetAppointmentsByPatientId==! ;
(==; <
int==< ?
	patientId==@ I
)==I J
{>> 	
List?? 
<?? 
Appointment?? 
>?? 
appointments?? *
=??+ ,
_appointmentRepo??- =
.??= >&
GetAppointmentsByPatientId??> X
(??X Y
	patientId??Y b
)??b c
;??c d
if@@ 
(@@ 
appointments@@ 
.@@ 
Count@@ "
==@@# %
$num@@& '
)@@' (
{AA 
throwBB 
newBB (
AppointmentNotFoundExceptionBB 6
(BB6 7
$"BB7 9
$strBB9 ^
{BB^ _
	patientIdBB_ h
}BBh i
$strBBi j
"BBj k
)BBk l
;BBl m
}CC 
returnEE 
appointmentsEE 
;EE  
}FF 	
publicII 
ListII 
<II 
AppointmentII 
>II  %
GetAppointmentsByDoctorIdII! :
(II: ;
intII; >
doctorIdII? G
)IIG H
{JJ 	
varKK 
appointmentsKK 
=KK 
_appointmentRepoKK /
.KK/ 0%
GetAppointmentsByDoctorIdKK0 I
(KKI J
doctorIdKKJ R
)KKR S
;KKS T
ifLL 
(LL 
appointmentsLL 
.LL 
CountLL "
==LL# %
$numLL& '
)LL' (
{MM 
throwNN 
newNN (
AppointmentNotFoundExceptionNN 6
(NN6 7
$"NN7 9
$strNN9 ]
{NN] ^
doctorIdNN^ f
}NNf g
$strNNg h
"NNh i
)NNi j
;NNj k
}OO 
returnQQ 
appointmentsQQ 
;QQ  
}RR 	
publicUU 
AppointmentUU 
?UU 
GetAppointmentByIdUU .
(UU. /
intUU/ 2
appointmentIdUU3 @
)UU@ A
{VV 	
AppointmentWW 
?WW 
appointmentWW $
=WW% &
_appointmentRepoWW' 7
.WW7 8
GetAppointmentByIdWW8 J
(WWJ K
appointmentIdWWK X
)WWX Y
;WWY Z
ifYY 
(YY 
appointmentYY 
isYY 
nullYY #
)YY# $
{ZZ 
throw[[ 
new[[ (
AppointmentNotFoundException[[ 6
([[6 7
$"[[7 9
$str[[9 K
{[[K L
appointmentId[[L Y
}[[Y Z
$str[[Z i
"[[i j
)[[j k
;[[k l
}\\ 
return]] 
appointment]] 
;]] 
}^^ 	
publicaa 
staticaa 
intaa "
AppointmentIdGeneratoraa 0
(aa0 1
Listaa1 5
<aa5 6
Appointmentaa6 A
>aaA B
appointmentsaaC O
)aaO P
{bb 	
returncc 
appointmentscc 
.cc  
Anycc  #
(cc# $
)cc$ %
?dd 
appointmentsdd 
.dd 
Maxdd "
(dd" #
add# $
=>dd% '
add( )
.dd) *
AppointmentIddd* 7
)dd7 8
+dd9 :
$numdd; <
:ee 
$numee 
;ee 
}ff 	
publicii 
stringii 
CancelAppointmentii '
(ii' (
intii( +
appointmentIdii, 9
,ii9 :
stringii; A
reasoniiB H
)iiH I
{jj 	
varkk 
appointmentkk 
=kk 
_appointmentRepokk .
.kk. /
GetAppointmentByIdkk/ A
(kkA B
appointmentIdkkB O
)kkO P
;kkP Q
ifmm 
(mm 
appointmentmm 
ismm 
nullmm #
)mm# $
{nn 
throwoo 
newoo (
AppointmentNotFoundExceptionoo 6
(oo6 7
$"oo7 9
$stroo9 K
{ooK L
appointmentIdooL Y
}ooY Z
$strooZ i
"ooi j
)ooj k
;ook l
}pp 
appointmentqq 
.qq 
Cancelqq 
(qq 
reasonqq %
)qq% &
;qq& '
returnrr 
$"rr 
$strrr '
{rr' (
appointmentIdrr( 5
}rr5 6
$strrr6 V
"rrV W
;rrW X
}ss 	
publicvv 
stringvv 
ConfirmAppointmentvv (
(vv( )
intvv) ,
appointmentIdvv- :
)vv: ;
{ww 	
varxx 
appointmentxx 
=xx 
_appointmentRepoxx .
.xx. /
GetAppointmentByIdxx/ A
(xxA B
appointmentIdxxB O
)xxO P
;xxP Q
ifzz 
(zz 
appointmentzz 
iszz 
nullzz #
)zz# $
{{{ 
throw|| 
new|| (
AppointmentNotFoundException|| 6
(||6 7
$"||7 9
$str||9 K
{||K L
appointmentId||L Y
}||Y Z
$str||Z i
"||i j
)||j k
;||k l
}}} 
appointment~~ 
.~~ 
Confirm~~ 
(~~  
)~~  !
;~~! "
return 
$" 
$str '
{' (
appointmentId( 5
}5 6
$str6 V
"V W
;W X
}
ÄÄ 	
public
ÉÉ 
List
ÉÉ 
<
ÉÉ 
Appointment
ÉÉ 
>
ÉÉ  %
GetUpcomingAppointments
ÉÉ! 8
(
ÉÉ8 9
)
ÉÉ9 :
{
ÑÑ 	
List
ÖÖ 
<
ÖÖ 
Appointment
ÖÖ 
>
ÖÖ "
upcomingAppointments
ÖÖ 2
=
ÖÖ3 4
_appointmentRepo
ÖÖ6 F
.
ÜÜ  
GetAllAppointments
ÜÜ #
(
ÜÜ# $
)
ÜÜ$ %
.
áá 
Where
áá 
(
áá 
a
áá 
=>
áá 
a
áá 
.
áá 
ScheduledDate
áá +
>
áá, -
DateTime
áá. 6
.
áá6 7
Now
áá7 :
&&
áá; =
a
àà 
.
àà 
Status
àà $
==
àà% '
AppointmentStatus
àà( 9
.
àà9 :
	Confirmed
àà: C
)
ààC D
.
ââ 
OrderBy
ââ 
(
ââ 
a
ââ 
=>
ââ 
a
ââ 
.
ââ  
ScheduledDate
ââ  -
)
ââ- .
.
ää 
ToList
ää 
(
ää 
)
ää 
;
ää 
if
åå 
(
åå "
upcomingAppointments
åå $
is
åå% '
null
åå( ,
)
åå, -
{
çç 
throw
éé 
new
éé *
AppointmentNotFoundException
éé 6
(
éé6 7
$str
éé7 [
)
éé[ \
;
éé\ ]
}
èè 
return
êê "
upcomingAppointments
êê '
;
êê' (
}
ëë 	
public
ìì 
Appointment
ìì 
UpdateAppointment
ìì ,
(
ìì, -
Appointment
ìì- 8
appointment
ìì9 D
)
ììD E
{
îî 	
Appointment
ïï 
?
ïï !
existingAppointment
ïï ,
=
ïï- . 
GetAppointmentById
ïï/ A
(
ïïA B
appointment
ïïB M
.
ïïM N
AppointmentId
ïïN [
)
ïï[ \
;
ïï\ ]
if
óó 
(
óó !
existingAppointment
óó #
is
óó$ &
null
óó' +
)
óó+ ,
{
òò 
throw
ôô 
new
ôô *
AppointmentNotFoundException
ôô 6
(
ôô6 7
$"
ôô7 9
$str
ôô9 K
{
ôôK L
appointment
ôôL W
.
ôôW X
AppointmentId
ôôX e
}
ôôe f
$str
ôôf u
"
ôôu v
)
ôôv w
;
ôôw x
}
öö 
return
õõ 
_appointmentRepo
õõ #
.
õõ# $
UpdateAppointment
õõ$ 5
(
õõ5 6!
existingAppointment
õõ6 I
,
õõI J
appointment
õõK V
)
õõV W
;
õõW X
}
úú 	
}
ùù 
}ûû ›
bC:\Users\310466\Desktop\Learning\HealthAxis\HealthApp\ConsoleApp\Repositories\PatientRepository.cs
	namespace		 	
	HealthApp		
 
.		 

ConsoleApp		 
.		 
Repositories		 +
{

 
public 

class 
PatientRepository "
:# $
IPatientRepository% 7
{ 
private 
readonly 
	PatientDb "
_patientsDb# .
;. /
public 
PatientRepository  
(  !
	PatientDb! *
	patientDb+ 4
)4 5
{ 	
_patientsDb 
= 
	patientDb #
;# $
} 	
public 
string 
RegisterPatient %
(% &
Patient& -
patient. 5
)5 6
{ 	
_patientsDb 
. 
Patients  
.  !
Add! $
($ %
patient% ,
), -
;- .
return 
$" 
$str  
{  !
patient! (
.( )
	PatientId) 2
}2 3
$str3 G
"G H
;H I
} 	
public 
List 
< 
Patient 
> 
GetAllPatients +
(+ ,
), -
{ 	
return 
_patientsDb 
. 
Patients '
.' (
ToList( .
(. /
)/ 0
;0 1
} 	
public 
Patient 
UpdatePatient $
($ %
Patient% ,
existingPatient- <
,< =
Patient> E
patientF M
)M N
{   	
existingPatient!! 
.!! 
FullName!! $
=!!% &
patient!!' .
.!!. /
FullName!!/ 7
;!!7 8
existingPatient"" 
."" 
DateOfBirth"" '
=""( )
patient""* 1
.""1 2
DateOfBirth""2 =
;""= >
existingPatient## 
.## 
Gender## "
=### $
patient##% ,
.##, -
Gender##- 3
;##3 4
existingPatient$$ 
.$$ 
PhoneNumber$$ '
=$$( )
patient$$* 1
.$$1 2
PhoneNumber$$2 =
;$$= >
existingPatient%% 
.%% 
Email%% !
=%%" #
patient%%$ +
.%%+ ,
Email%%, 1
;%%1 2
existingPatient&& 
.&& 
InsuranceId&& '
=&&( )
patient&&* 1
.&&1 2
InsuranceId&&2 =
;&&= >
return(( 
existingPatient(( "
;((" #
})) 	
public++ 
Patient++ 
?++ 
GetPatientById++ &
(++& '
int++' *
id+++ -
)++- .
{,, 	
return-- 
_patientsDb-- 
.-- 
Patients-- '
.--' (
FirstOrDefault--( 6
(--6 7
p--7 8
=>--9 ;
p--< =
.--= >
	PatientId--> G
==--H J
id--K M
)--M N
;--N O
}.. 	
}// 
}00 À)
gC:\Users\310466\Desktop\Learning\HealthAxis\HealthApp\ConsoleApp\Repositories\HealthRecordRepository.cs
	namespace 	
	HealthApp
 
. 

ConsoleApp 
. 
Repositories +
{ 
public		 

class		 "
HealthRecordRepository		 '
:		( )#
IHealthRecordRepository		* A
{

 
private 
readonly 
HealthRecordDB '
_healthRecordDb( 7
;7 8
public "
HealthRecordRepository %
(% &
HealthRecordDB& 4
healthRecordDB5 C
)C D
{ 	
_healthRecordDb 
= 
healthRecordDB ,
;, -
} 	
public 
string 
AddHealthRecord %
(% &
HealthRecord& 2
record3 9
)9 :
{ 	
_healthRecordDb 
. 
Records #
.# $
Add$ '
(' (
record( .
). /
;/ 0
return 
$" 
$str 
{  
record  &
.& '
RecordId' /
}/ 0
$str0 D
"D E
;E F
} 	
public 
List 
< 
HealthRecord  
>  !
GetAllRecords" /
(/ 0
)0 1
{ 	
return 
_healthRecordDb "
." #
Records# *
.* +
ToList+ 1
(1 2
)2 3
;3 4
} 	
public 
List 
< 
HealthRecord  
>  !.
"GetByPatientIdOrderByVisitDateDesc" D
(D E
intE H
idI K
)K L
{ 	
return 
_healthRecordDb "
." #
Records# *
.   
Where   
(   
r   
=>   
r    !
.  ! "
Patient  " )
!=  * ,
null  - 1
&&  2 4
r  5 6
.  6 7
Patient  7 >
.  > ?
	PatientId  ? H
==  I K
id  L N
)  N O
.!! 
OrderByDescending!! &
(!!& '
r!!' (
=>!!) +
r!!, -
.!!- .
	VisitDate!!. 7
)!!7 8
."" 
ToList"" 
("" 
)"" 
;"" 
}## 	
public%% 
List%% 
<%% 
HealthRecord%%  
>%%  !-
!GetByDoctorIdOrderByVisitDateDesc%%" C
(%%C D
int%%D G
id%%H J
)%%J K
{&& 	
return'' 
_healthRecordDb'' "
.''" #
Records''# *
.(( 
Where(( 
((( 
r(( 
=>(( 
r((  !
.((! "
Doctor((" (
!=(() +
null((, 0
&&((1 3
r((4 5
.((5 6
Doctor((6 <
.((< =
DoctorId((= E
==((F H
id((I K
)((K L
.)) 
OrderByDescending)) &
())& '
r))' (
=>))) +
r)), -
.))- .
	VisitDate)). 7
)))7 8
.** 
ToList** 
(** 
)** 
;** 
}++ 	
public-- 
HealthRecord-- 
?-- 
GetRecordById-- *
(--* +
int--+ .
id--/ 1
)--1 2
{.. 	
return// 
_healthRecordDb// "
.//" #
Records//# *
.//* +
FirstOrDefault//+ 9
(//9 :
r//: ;
=>//< >
r//? @
.//@ A
RecordId//A I
==//J L
id//M O
)//O P
;//P Q
}00 	
public22 
HealthRecord22 
UpdateHealthRecord22 .
(22. /
HealthRecord22/ ; 
existingHealthRecord22< P
,22P Q
HealthRecord22R ^
record22_ e
)22e f
{33 	 
existingHealthRecord44  
.44  !
RecordId44! )
=44* +
record44, 2
.442 3
RecordId443 ;
;44; < 
existingHealthRecord55  
.55  !
Patient55! (
=55) *
record55+ 1
.551 2
Patient552 9
;559 : 
existingHealthRecord66  
.66  !
Doctor66! '
=66( )
record66* 0
.660 1
Doctor661 7
;667 8 
existingHealthRecord77  
.77  !
	VisitDate77! *
=77+ ,
record77- 3
.773 4
	VisitDate774 =
;77= > 
existingHealthRecord88  
.88  !
	Diagnosis88! *
=88+ ,
record88- 3
.883 4
	Diagnosis884 =
;88= > 
existingHealthRecord99  
.99  !
Prescription99! -
=99. /
record990 6
.996 7
Prescription997 C
;99C D 
existingHealthRecord::  
.::  !
DoctorNotes::! ,
=::- .
record::/ 5
.::5 6
DoctorNotes::6 A
;::A B
return<<  
existingHealthRecord<< '
;<<' (
}== 	
}>> 
}?? ç
aC:\Users\310466\Desktop\Learning\HealthAxis\HealthApp\ConsoleApp\Repositories\DoctorRepository.cs
	namespace		 	
	HealthApp		
 
.		 

ConsoleApp		 
.		 
Repositories		 +
{

 
public 

class 
DoctorRepository !
:" #
IDoctorRepository$ 5
{ 
private 
readonly 
DoctorDb !
	_doctorDb" +
;+ ,
public 
DoctorRepository 
(  
DoctorDb  (
doctorDb) 1
)1 2
{ 	
	_doctorDb 
= 
doctorDb  
;  !
} 	
public 
string 
	AddDoctor 
(  
Doctor  &
doctor' -
)- .
{ 	
	_doctorDb 
. 
Doctors 
. 
Add !
(! "
doctor" (
)( )
;) *
return 
$" 
$str 
{  
doctor  &
.& '
DoctorId' /
}/ 0
$str0 D
"D E
;E F
} 	
public 
Doctor 
? 
GetDoctorById $
($ %
int% (
id) +
)+ ,
{ 	
return 
	_doctorDb 
. 
Doctors $
.$ %
FirstOrDefault% 3
(3 4
d4 5
=>6 8
d9 :
.: ;
DoctorId; C
==D F
idG I
)I J
;J K
} 	
public 
List 
< 
Doctor 
> &
GetDoctorsBySpecialisation 6
(6 7
string7 =
specialisation> L
)L M
{   	
return!! 
	_doctorDb!! 
.!! 
Doctors!! $
."" 
Where"" 
("" 
d"" 
=>"" 
d"" 
."" 
Specialisation"" ,
."", -
Equals""- 3
(""3 4
specialisation""4 B
,""B C
StringComparison""D T
.""T U
OrdinalIgnoreCase""U f
)""f g
)""g h
.## 
ToList## 
(## 
)## 
;## 
}$$ 	
public&& 
Doctor&& 
UpdateDoctor&& "
(&&" #
Doctor&&# )
existingDoctor&&* 8
,&&8 9
Doctor&&: @
doctor&&A G
)&&G H
{'' 	
existingDoctor(( 
.(( 
FullName(( #
=(($ %
doctor((& ,
.((, -
FullName((- 5
;((5 6
existingDoctor)) 
.)) 
Specialisation)) )
=))* +
doctor)), 2
.))2 3
Specialisation))3 A
;))A B
existingDoctor** 
.** 
YearsOfExperience** ,
=**- .
doctor**/ 5
.**5 6
YearsOfExperience**6 G
;**G H
existingDoctor++ 
.++ 
ConsultationFee++ *
=+++ ,
doctor++- 3
.++3 4
ConsultationFee++4 C
;++C D
existingDoctor,, 
.,, 
IsActive,, #
=,,$ %
doctor,,& ,
.,,, -
IsActive,,- 5
;,,5 6
return.. 
existingDoctor.. !
;..! "
}// 	
public11 
List11 
<11 
Doctor11 
>11 
GetAllDoctors11 )
(11) *
)11* +
{22 	
return33 
	_doctorDb33 
.33 
Doctors33 $
.33$ %
ToList33% +
(33+ ,
)33, -
;33- .
}44 	
}55 
}66 ﬂ!
fC:\Users\310466\Desktop\Learning\HealthAxis\HealthApp\ConsoleApp\Repositories\AppointmentRepository.cs
	namespace 	
	HealthApp
 
. 

ConsoleApp 
. 
Repositories +
{ 
public 

class !
AppointmentRepository &
:' ("
IAppointmentRepository) ?
{ 
private		 
readonly		 
AppointmentDb		 &
_appointmentDb		' 5
;		5 6
public !
AppointmentRepository $
($ %
AppointmentDb% 2
appointmentDb3 @
)@ A
{ 	
_appointmentDb 
= 
appointmentDb *
;* +
} 	
public 
string 
AddAppointment $
($ %
Appointment% 0
appointment1 <
)< =
{ 	
_appointmentDb 
. 
Appointments '
.' (
Add( +
(+ ,
appointment, 7
)7 8
;8 9
return 
$" 
$str $
{$ %
appointment% 0
.0 1
AppointmentId1 >
}> ?
$str? S
"S T
;T U
} 	
public 
List 
< 
Appointment 
>  
GetAllAppointments! 3
(3 4
)4 5
{ 	
return 
_appointmentDb !
.! "
Appointments" .
;. /
} 	
public 
Appointment 
? 
GetAppointmentById .
(. /
int/ 2
id3 5
)5 6
{ 	
return 
_appointmentDb !
.! "
Appointments" .
.. /
FirstOrDefault/ =
(= >
a> ?
=>@ B
aC D
.D E
AppointmentIdE R
==S U
idV X
)X Y
;Y Z
} 	
public   
Appointment   
UpdateAppointment   ,
(  , -
Appointment  - 8
existingAppointment  9 L
,  L M
Appointment  N Y
appointment  Z e
)  e f
{!! 	
existingAppointment"" 
.""  
Patient""  '
=""( )
appointment""* 5
.""5 6
Patient""6 =
;""= >
existingAppointment## 
.##  
Doctor##  &
=##' (
appointment##) 4
.##4 5
Doctor##5 ;
;##; <
existingAppointment$$ 
.$$  
ScheduledDate$$  -
=$$. /
appointment$$0 ;
.$$; <
ScheduledDate$$< I
;$$I J
existingAppointment%% 
.%%  
TimeSlot%%  (
=%%) *
appointment%%+ 6
.%%6 7
TimeSlot%%7 ?
;%%? @
return'' 
existingAppointment'' &
;''& '
}(( 	
public** 
List** 
<** 
Appointment** 
>**  &
GetAppointmentsByPatientId**! ;
(**; <
int**< ?
	patientId**@ I
)**I J
{++ 	
return,, 
_appointmentDb,, !
.,,! "
Appointments,," .
.,,. /
Where,,/ 4
(,,4 5
a,,5 6
=>,,7 9
a,,: ;
.,,; <
Patient,,< C
.,,C D
	PatientId,,D M
==,,N P
	patientId,,Q Z
),,Z [
.,,[ \
ToList,,\ b
(,,b c
),,c d
;,,d e
}-- 	
public// 
List// 
<// 
Appointment// 
>//  %
GetAppointmentsByDoctorId//! :
(//: ;
int//; >
doctorId//? G
)//G H
{00 	
return11 
_appointmentDb11 !
.11! "
Appointments11" .
.11. /
Where11/ 4
(114 5
a115 6
=>117 9
a11: ;
.11; <
Doctor11< B
.11B C
DoctorId11C K
==11L N
doctorId11O W
)11W X
.11X Y
ToList11Y _
(11_ `
)11` a
;11a b
}22 	
}33 
}44 Ú
RC:\Users\310466\Desktop\Learning\HealthAxis\HealthApp\ConsoleApp\Models\Patient.cs
	namespace 	
	HealthApp
 
. 

ConsoleApp 
. 
Models %
{ 
public 

enum 

GenderType 
{ 
Male !
,! "
Female# )
,) *
Other+ 0
}1 2
;2 3
public 

class 
Patient 
{ 
public 
int 
	PatientId 
{ 
get "
;" #
set$ '
;' (
}) *
public 
required 
string 
FullName '
{( )
get* -
;- .
set/ 2
;2 3
}4 5
public		 
DateTime		 
DateOfBirth		 #
{		$ %
get		& )
;		) *
set		+ .
;		. /
}		0 1
public

 

GenderType

 
Gender

  
{

! "
get

# &
;

& '
set

( +
;

+ ,
}

- .
public 
required 
string 
PhoneNumber *
{+ ,
get- 0
;0 1
set2 5
;5 6
}7 8
public 
required 
string 
Email $
{% &
get' *
;* +
set, /
;/ 0
}1 2
public 
required 
string 
InsuranceId *
{+ ,
get- 0
;0 1
set2 5
;5 6
}7 8
public 
DateTime 
CreatedDate #
{$ %
get& )
;) *
set+ .
;. /
}0 1
=2 3
DateTime4 <
.< =
Now= @
;@ A
public 
int 
GetAge 
( 
) 
{ 	
var 
today 
= 
DateTime  
.  !
Today! &
;& '
var 
age 
= 
today 
. 
Year  
-! "
DateOfBirth# .
.. /
Year/ 3
;3 4
if 
( 
DateOfBirth 
. 
Date  
>! "
today# (
.( )
AddYears) 1
(1 2
-2 3
age3 6
)6 7
)7 8
age 
-- 
; 
return 
age 
; 
} 	
public 
string 
GetProfileSummary '
(' (
)( )
{ 	
return 
$" 
$str 
{ 
	PatientId $
}$ %
$str% .
{. /
FullName/ 7
}7 8
$str8 @
{@ A
GetAgeA G
(G H
)H I
}I J
$strJ U
{U V
GenderV \
}\ ]
$str] g
{g h
Emailh m
}m n
$strn x
{x y
PhoneNumber	y Ñ
}
Ñ Ö
$str
Ö ñ
{
ñ ó
InsuranceId
ó ¢
}
¢ £
"
£ §
;
§ •
}   	
}!! 
}"" î
WC:\Users\310466\Desktop\Learning\HealthAxis\HealthApp\ConsoleApp\Models\HealthRecord.cs
	namespace 	
	HealthApp
 
. 

ConsoleApp 
. 
Models %
{ 
public 

class 
HealthRecord 
{ 
public 
int 
RecordId 
{ 
get !
;! "
set# &
;& '
}( )
public 
required 
Patient 
Patient  '
{( )
get* -
;- .
set/ 2
;2 3
}4 5
public 
required 
Doctor 
Doctor %
{& '
get( +
;+ ,
set- 0
;0 1
}2 3
public 
DateTime 
	VisitDate !
{" #
get$ '
;' (
set) ,
;, -
}. /
public		 
required		 
string		 
	Diagnosis		 (
{		) *
get		+ .
;		. /
set		0 3
;		3 4
}		5 6
public

 
required

 
string

 
Prescription

 +
{

, -
get

. 1
;

1 2
set

3 6
;

6 7
}

8 9
public 
required 
string 
DoctorNotes *
{+ ,
get- 0
;0 1
set2 5
;5 6
}7 8
public 
string 

GetSummary  
(  !
)! "
{ 	
return 
$" 
$str  
{  !
RecordId! )
}) *
$str* 6
{6 7
Patient7 >
.> ?
FullName? G
}G H
$strH S
{S T
DoctorT Z
.Z [
FullName[ c
}c d
$strd m
{m n
	VisitDaten w
.w x
ToShortDateString	x â
(
â ä
)
ä ã
}
ã å
$str
å ö
{
ö õ
	Diagnosis
õ §
}
§ •
$str
• ∂
{
∂ ∑
Prescription
∑ √
}
√ ƒ
$str
ƒ Œ
{
Œ œ
DoctorNotes
œ ⁄
}
⁄ €
"
€ ‹
;
‹ ›
} 	
public 
override 
string 
ToString '
(' (
)( )
{ 	
return 
$" 
$str #
{# $
	VisitDate$ -
.- .
ToShortDateString. ?
(? @
)@ A
}A B
$strB N
{N O
PatientO V
.V W
FullNameW _
}_ `
$str` k
{k l
Doctorl r
.r s
FullNames {
}{ |
$str	| ä
{
ä ã
	Diagnosis
ã î
}
î ï
$str
ï ¶
{
¶ ß
Prescription
ß ≥
}
≥ ¥
$str
¥ ≈
{
≈ ∆
DoctorNotes
∆ —
}
— “
"
“ ”
;
” ‘
} 	
} 
} Í&
QC:\Users\310466\Desktop\Learning\HealthAxis\HealthApp\ConsoleApp\Models\Doctor.cs
	namespace 	
	HealthApp
 
. 

ConsoleApp 
. 
Models %
{ 
public 

class 
Doctor 
{ 
public 
int 
DoctorId 
{ 
get !
;! "
set# &
;& '
}( )
public 
required 
string 
FullName '
{( )
get* -
;- .
set/ 2
;2 3
}4 5
public 
required 
string 
Specialisation -
{. /
get0 3
;3 4
set5 8
;8 9
}: ;
public 
int 
YearsOfExperience $
{% &
get' *
;* +
set, /
;/ 0
}1 2
public		 
decimal		 
ConsultationFee		 &
{		' (
get		) ,
;		, -
set		. 1
;		1 2
}		3 4
public

 
bool

 
IsActive

 
{

 
get

 "
;

" #
set

$ '
;

' (
}

) *
public 
List 
< 
string 
> 
Slots !
{" #
get$ '
;' (
set) ,
;, -
}. /
=0 1
new2 5
List6 :
<: ;
string; A
>A B
(B C
)C D
;D E
public 
List 
< 
DateTime 
> 

LeaveDates (
{) *
get+ .
;. /
set0 3
;3 4
}5 6
=7 8
new9 <
List= A
<A B
DateTimeB J
>J K
(K L
)L M
;M N
public 
virtual 
bool 
IsAvailable '
(' (
DateTime( 0
date1 5
)5 6
{ 	
if 
( 
! 
IsActive 
) 
{ 
return 
false 
; 
} 
if 
( 

LeaveDates 
. 
Any 
( 
d  
=>! #
d$ %
.% &
Date& *
==+ -
date. 2
.2 3
Date3 7
)7 8
)8 9
{ 
return 
false 
; 
} 
return 
true 
; 
} 	
public 
string 
GetScheduleSummary (
(( )
List) -
<- .
Appointment. 9
>9 :
appointments; G
)G H
{   	
int!! 
count!! 
=!! 
appointments!! $
.!!$ %
Count!!% *
(!!* +
a!!+ ,
=>!!- /
a"" 
."" 
Doctor"" 
."" 
DoctorId"" !
==""" $
this""% )
."") *
DoctorId""* 2
&&""3 5
a## 
.## 
ScheduledDate## 
.##  
Date##  $
>=##% '
DateTime##( 0
.##0 1
Today##1 6
&&##7 9
a$$ 
.$$ 
Status$$ 
==$$ 
AppointmentStatus$$ -
.$$- .
	Confirmed$$. 7
)%% 
;%% 
if'' 
('' 
count'' 
=='' 
$num'' 
)'' 
{(( 
return)) 
$")) 
$str)) 
{)) 
FullName)) &
}))& '
$str))' O
"))O P
;))P Q
}** 
return,, 
$",, 
$str,, 
{,, 
FullName,, "
},," #
$str,,# (
{,,( )
count,,) .
},,. /
$str,,/ P
",,P Q
;,,Q R
}-- 	
public00 
override00 
string00 
ToString00 '
(00' (
)00( )
{11 	
return22 
$"22 
$str22  
{22  !
DoctorId22! )
}22) *
$str22* 8
{228 9
FullName229 A
}22A B
$str22B U
{22U V
Specialisation22V d
}22d e
$str22e t
{22t u
YearsOfExperience	22u Ü
}
22Ü á
$str
22á ¶
{
22¶ ß
ConsultationFee
22ß ∂
}
22∂ ∑
$str
22∑ ¬
{
22¬ √
(
22√ ƒ
IsActive
22ƒ Ã
?
22Õ Œ
$str
22œ ‘
:
22’ ÷
$str
22◊ €
)
22€ ‹
}
22‹ ›
"
22› ﬁ
;
22ﬁ ﬂ
}33 	
}44 
}55 ÿ
\C:\Users\310466\Desktop\Learning\HealthAxis\HealthApp\ConsoleApp\Models\AppointmentStatus.cs
	namespace 	
	HealthApp
 
. 

ConsoleApp 
. 
Models %
{ 
public 

enum 
AppointmentStatus !
{ 
Pending 
, 
	Confirmed 
, 
	Completed 
, 
	Cancelled 
}		 
}

 Ót
TC:\Users\310466\Desktop\Learning\HealthAxis\HealthApp\ConsoleApp\Menus\DoctorMenu.cs
	namespace 	
	HealthApp
 
{ 
public 

class 

DoctorMenu 
{ 
private 
readonly 
IDoctorService '
_doctorService( 6
;6 7
public 
const 
string 
Continue $
=% &
$str' G
;G H
public 

DoctorMenu 
( 
IDoctorService (
doctorService) 6
)6 7
{ 	
_doctorService 
= 
doctorService *
;* +
} 	
public 
string 
	AddDoctor 
(  
)  !
{ 	
try 
{ 
Console 
. 
Clear 
( 
) 
;  
var 
fullName 
= 
InputValidator -
.- .
GetValidatedInput. ?
(? @
$str   8
,  8 9
InputValidator!! "
.!!" #
IsValidName!!# .
,!!. /
$str"" 9
)""9 :
;"": ;
var$$ 
specialisation$$ "
=$$# $
InputValidator$$% 3
.$$3 4
GetValidatedInput$$4 E
($$E F
$str%% =
,%%= >
InputValidator&& "
.&&" #
IsValidName&&# .
,&&. /
$str'' >
)''> ?
;''? @
var)) 
experienceInput)) #
=))$ %
InputValidator))& 4
.))4 5
GetValidatedInput))5 F
())F G
$str** 1
,**1 2
InputValidator++ "
.++" #
IsValidExperience++# 4
,++4 5
$str,, )
),,) *
;,,* +
var.. 
feeInput.. 
=.. 
InputValidator.. -
...- .
GetValidatedInput... ?
(..? @
$str// .
,//. /
InputValidator00 "
.00" #

IsValidFee00# -
,00- .
$str11 /
)11/ 0
;110 1

SlotHelper33 
.33 

PrintSlots33 %
(33% &
)33& '
;33' (
Console44 
.44 
	WriteLine44 !
(44! "
$str44" J
)44J K
;44K L
List66 
<66 
string66 
>66 
?66 
selectedSlots66 +
;66+ ,
while88 
(88 
true88 
)88 
{99 
Console:: 
.:: 
Write:: !
(::! "
$str::" =
)::= >
;::> ?
string;; 
?;; 
input;; !
=;;" #
Console;;$ +
.;;+ ,
ReadLine;;, 4
(;;4 5
);;5 6
;;;6 7
selectedSlots== !
===" #

SlotHelper==$ .
.==. /
SimpleParseSlots==/ ?
(==? @
input==@ E
??==F H
$str==I K
)==K L
;==L M
if?? 
(?? 
selectedSlots?? %
!=??& (
null??) -
&&??. 0
selectedSlots??1 >
.??> ?
Count??? D
>??E F
$num??G H
)??H I
break@@ 
;@@ 
ConsoleBB 
.BB 
	WriteLineBB %
(BB% &
$strBB& L
)BBL M
;BBM N
}CC 
varEE 

leaveDatesEE 
=EE  
newEE! $
ListEE% )
<EE) *
DateTimeEE* 2
>EE2 3
(EE3 4
)EE4 5
;EE5 6
ConsoleGG 
.GG 
	WriteLineGG !
(GG! "
$strGG" \
)GG\ ]
;GG] ^
whileII 
(II 
trueII 
)II 
{JJ 
ConsoleKK 
.KK 
WriteKK !
(KK! "
$strKK" 0
)KK0 1
;KK1 2
varLL 
inputLL 
=LL 
ConsoleLL  '
.LL' (
ReadLineLL( 0
(LL0 1
)LL1 2
?LL2 3
.LL3 4
TrimLL4 8
(LL8 9
)LL9 :
.LL: ;
ToLowerLL; B
(LLB C
)LLC D
;LLD E
ifNN 
(NN 
inputNN 
==NN  
$strNN! '
)NN' (
breakOO 
;OO 
ifQQ 
(QQ 
DateTimeQQ  
.QQ  !
TryParseExactQQ! .
(QQ. /
inputRR !
,RR! "
$strSS (
,SS( )
CultureInfoTT '
.TT' (
InvariantCultureTT( 8
,TT8 9
DateTimeStylesUU *
.UU* +
NoneUU+ /
,UU/ 0
outVV 
varVV  #
dateVV$ (
)VV( )
)VV) *
{WW 
ifXX 
(XX 
!XX 

leaveDatesXX '
.XX' (
ContainsXX( 0
(XX0 1
dateXX1 5
)XX5 6
)XX6 7

leaveDatesYY &
.YY& '
AddYY' *
(YY* +
dateYY+ /
)YY/ 0
;YY0 1
}ZZ 
else[[ 
{\\ 
Console]] 
.]]  
	WriteLine]]  )
(]]) *
$str]]* @
)]]@ A
;]]A B
}^^ 
}__ 
varaa 
doctoraa 
=aa 
newaa  
Doctoraa! '
{bb 
FullNamecc 
=cc 
fullNamecc '
!cc' (
,cc( )
Specialisationdd "
=dd# $
specialisationdd% 3
!dd3 4
,dd4 5
YearsOfExperienceee %
=ee& '
intee( +
.ee+ ,
Parseee, 1
(ee1 2
experienceInputee2 A
!eeA B
)eeB C
,eeC D
ConsultationFeeff #
=ff$ %
decimalff& -
.ff- .
Parseff. 3
(ff3 4
feeInputff4 <
!ff< =
)ff= >
,ff> ?
IsActivegg 
=gg 
truegg #
,gg# $
Slotsii 
=ii 
selectedSlotsii )
,ii) *

LeaveDatesjj 
=jj  

leaveDatesjj! +
}kk 
;kk 
returnmm 
_doctorServicemm %
.mm% &
	AddDoctormm& /
(mm/ 0
doctormm0 6
)mm6 7
;mm7 8
}nn 
catchoo 
(oo &
OperationCanceledExceptionoo -
)oo- .
{pp 
returnqq 
$strqq +
;qq+ ,
}rr 
}ss 	
publicuu 
Listuu 
<uu 
Doctoruu 
>uu (
SearchDoctorBySpecialisationuu 8
(uu8 9
)uu9 :
{vv 	
tryww 
{xx 
Consoleyy 
.yy 
Clearyy 
(yy 
)yy 
;yy  
var{{ 
specialisation{{ "
={{# $
InputValidator{{% 3
.{{3 4
GetValidatedInput{{4 E
({{E F
$str|| G
,||G H
InputValidator}} "
.}}" #
IsValidName}}# .
,}}. /
$str~~ -
)~~- .
;~~. /
return
ÄÄ 
_doctorService
ÄÄ %
.
ÄÄ% &(
GetDoctorsBySpecialisation
ÄÄ& @
(
ÄÄ@ A
specialisation
ÄÄA O
!
ÄÄO P
)
ÄÄP Q
;
ÄÄQ R
}
ÅÅ 
catch
ÇÇ 
(
ÇÇ (
OperationCanceledException
ÇÇ -
)
ÇÇ- .
{
ÉÉ 
Console
ÑÑ 
.
ÑÑ 
	WriteLine
ÑÑ !
(
ÑÑ! "
$str
ÑÑ" 5
)
ÑÑ5 6
;
ÑÑ6 7
Console
ÖÖ 
.
ÖÖ 
Write
ÖÖ 
(
ÖÖ 
Continue
ÖÖ &
)
ÖÖ& '
;
ÖÖ' (
Console
ÜÜ 
.
ÜÜ 
ReadKey
ÜÜ 
(
ÜÜ  
)
ÜÜ  !
;
ÜÜ! "
return
áá 
[
áá 
]
áá 
;
áá 
}
àà 
catch
ââ 
(
ââ -
SpecialisationNotFoundException
ââ 2
ex
ââ3 5
)
ââ5 6
{
ää 
Console
ãã 
.
ãã 
	WriteLine
ãã !
(
ãã! "
ex
ãã" $
.
ãã$ %
Message
ãã% ,
)
ãã, -
;
ãã- .
Console
åå 
.
åå 
Write
åå 
(
åå 
Continue
åå &
)
åå& '
;
åå' (
Console
çç 
.
çç 
ReadKey
çç 
(
çç  
)
çç  !
;
çç! "
return
éé 
[
éé 
]
éé 
;
éé 
}
èè 
}
êê 	
public
íí 
string
íí 
UpdateDoctor
íí "
(
íí" #
)
íí# $
{
ìì 	
try
îî 
{
ïï 
Console
ññ 
.
ññ 
Clear
ññ 
(
ññ 
)
ññ 
;
ññ  
Console
òò 
.
òò 
Write
òò 
(
òò 
$str
òò B
)
òòB C
;
òòC D
var
ôô 
input
ôô 
=
ôô 
Console
ôô #
.
ôô# $
ReadLine
ôô$ ,
(
ôô, -
)
ôô- .
;
ôô. /
if
õõ 
(
õõ 
input
õõ 
?
õõ 
.
õõ 
ToLower
õõ "
(
õõ" #
)
õõ# $
==
õõ% '
$str
õõ( +
)
õõ+ ,
return
úú 
$str
úú .
;
úú. /
if
ûû 
(
ûû 
!
ûû 
int
ûû 
.
ûû 
TryParse
ûû !
(
ûû! "
input
ûû" '
,
ûû' (
out
ûû) ,
int
ûû- 0
doctorId
ûû1 9
)
ûû9 :
||
ûû; =
doctorId
ûû> F
<=
ûûG I
$num
ûûJ K
)
ûûK L
return
üü 
$str
üü .
;
üü. /
var
°° 
existingDoctor
°° "
=
°°# $
_doctorService
°°% 3
.
°°3 4
GetDoctorById
°°4 A
(
°°A B
doctorId
°°B J
)
°°J K
;
°°K L
if
¢¢ 
(
¢¢ 
existingDoctor
¢¢ "
==
¢¢# %
null
¢¢& *
)
¢¢* +
return
££ 
$str
££ -
;
££- .
Console
•• 
.
•• 
	WriteLine
•• !
(
••! "
$str
••" =
)
••= >
;
••> ?
Console
¶¶ 
.
¶¶ 
	WriteLine
¶¶ !
(
¶¶! "
existingDoctor
¶¶" 0
)
¶¶0 1
;
¶¶1 2
var
®® 
fullNameInput
®® !
=
®®" #
InputValidator
®®$ 2
.
®®2 3
GetValidatedInput
®®3 D
(
®®D E
$str
©© F
,
©©F G
InputValidator
™™ "
.
™™" #
IsValidName
™™# .
,
™™. /
$str
´´ #
,
´´# $

allowEmpty
¨¨ 
:
¨¨ 
true
¨¨  $
)
¨¨$ %
;
¨¨% &
var
ÆÆ 
	specInput
ÆÆ 
=
ÆÆ 
InputValidator
ÆÆ  .
.
ÆÆ. /
GetValidatedInput
ÆÆ/ @
(
ÆÆ@ A
$str
ØØ K
,
ØØK L
InputValidator
∞∞ "
.
∞∞" #
IsValidName
∞∞# .
,
∞∞. /
$str
±± -
,
±±- .

allowEmpty
≤≤ 
:
≤≤ 
true
≤≤  $
)
≤≤$ %
;
≤≤% &
var
¥¥ 
expInput
¥¥ 
=
¥¥ 
InputValidator
¥¥ -
.
¥¥- .
GetValidatedInput
¥¥. ?
(
¥¥? @
$str
µµ G
,
µµG H
InputValidator
∂∂ "
.
∂∂" #
IsValidExperience
∂∂# 4
,
∂∂4 5
$str
∑∑ )
,
∑∑) *

allowEmpty
∏∏ 
:
∏∏ 
true
∏∏  $
)
∏∏$ %
;
∏∏% &
var
∫∫ 
feeInput
∫∫ 
=
∫∫ 
InputValidator
∫∫ -
.
∫∫- .
GetValidatedInput
∫∫. ?
(
∫∫? @
$str
ªª @
,
ªª@ A
InputValidator
ºº "
.
ºº" #

IsValidFee
ºº# -
,
ºº- .
$str
ΩΩ "
,
ΩΩ" #

allowEmpty
ææ 
:
ææ 
true
ææ  $
)
ææ$ %
;
ææ% &
var
¿¿ 
isActiveInput
¿¿ !
=
¿¿" #
InputValidator
¿¿$ 2
.
¿¿2 3
GetOptionalBool
¿¿3 B
(
¿¿B C
$str
¡¡ G
)
¡¡G H
;
¡¡H I
var
√√ 
updatedDoctor
√√ !
=
√√" #
new
√√$ '
Doctor
√√( .
{
ƒƒ 
DoctorId
≈≈ 
=
≈≈ 
existingDoctor
≈≈ -
.
≈≈- .
DoctorId
≈≈. 6
,
≈≈6 7
FullName
∆∆ 
=
∆∆ 
fullNameInput
∆∆ ,
??
∆∆- /
existingDoctor
∆∆0 >
.
∆∆> ?
FullName
∆∆? G
,
∆∆G H
Specialisation
«« "
=
««# $
	specInput
««% .
??
««/ 1
existingDoctor
««2 @
.
««@ A
Specialisation
««A O
,
««O P
YearsOfExperience
»» %
=
»»& '
expInput
»»( 0
!=
»»1 3
null
»»4 8
?
»»9 :
int
»»; >
.
»»> ?
Parse
»»? D
(
»»D E
expInput
»»E M
)
»»M N
:
»»O P
existingDoctor
»»Q _
.
»»_ `
YearsOfExperience
»»` q
,
»»q r
ConsultationFee
…… #
=
……$ %
feeInput
……& .
!=
……/ 1
null
……2 6
?
……7 8
decimal
……9 @
.
……@ A
Parse
……A F
(
……F G
feeInput
……G O
)
……O P
:
……Q R
existingDoctor
……S a
.
……a b
ConsultationFee
……b q
,
……q r
IsActive
   
=
   
isActiveInput
   ,
??
  - /
existingDoctor
  0 >
.
  > ?
IsActive
  ? G
,
  G H
}
ÀÀ 
;
ÀÀ 
Console
ÕÕ 
.
ÕÕ 
Clear
ÕÕ 
(
ÕÕ 
)
ÕÕ 
;
ÕÕ  
return
ŒŒ 
_doctorService
ŒŒ %
.
ŒŒ% &
UpdateDoctor
ŒŒ& 2
(
ŒŒ2 3
updatedDoctor
ŒŒ3 @
)
ŒŒ@ A
.
ŒŒA B
ToString
ŒŒB J
(
ŒŒJ K
)
ŒŒK L
;
ŒŒL M
}
œœ 
catch
–– 
(
–– (
OperationCanceledException
–– -
)
––- .
{
—— 
return
““ 
$str
““ *
;
““* +
}
”” 
catch
‘‘ 
(
‘‘ %
DoctorNotFoundException
‘‘ *
ex
‘‘+ -
)
‘‘- .
{
’’ 
return
÷÷ 
ex
÷÷ 
.
÷÷ 
Message
÷÷ !
;
÷÷! "
}
◊◊ 
}
ÿÿ 	
}
ŸŸ 
}⁄⁄ ”-
VC:\Users\310466\Desktop\Learning\HealthAxis\HealthApp\ConsoleApp\Models\Appointment.cs
	namespace 	
	HealthApp
 
. 

ConsoleApp 
. 
Models %
{ 
public 

class 
Appointment 
{		 
public

 
int

 
AppointmentId

  
{

! "
get

# &
;

& '
set

( +
;

+ ,
}

- .
public 
required 
Patient 
Patient  '
{( )
get* -
;- .
set/ 2
;2 3
}4 5
public 
required 
Doctor 
Doctor %
{& '
get( +
;+ ,
set- 0
;0 1
}2 3
public 
DateTime 
ScheduledDate %
{& '
get( +
;+ ,
set- 0
;0 1
}2 3
public 
required 
string 
TimeSlot '
{( )
get* -
;- .
set/ 2
;2 3
}4 5
public 
AppointmentStatus  
Status! '
{( )
get* -
;- .
set/ 2
;2 3
}4 5
=6 7
AppointmentStatus8 I
.I J
PendingJ Q
;Q R
public 
string 
CancellationReason (
{) *
get+ .
;. /
set0 3
;3 4
}5 6
=7 8
$str9 ;
;; <
public 
void 
Confirm 
( 
) 
{ 	
if 
( 
Status 
== 
AppointmentStatus +
.+ ,
	Cancelled, 5
)5 6
{ 
throw 
new %
InvalidOperationException 3
(3 4
$str4 ]
)] ^
;^ _
} 
Status 
= 
AppointmentStatus &
.& '
	Confirmed' 0
;0 1
} 	
public 
void 
Cancel 
( 
string !
reason" (
)( )
{ 	
if   
(   
Status   
==   
AppointmentStatus   +
.  + ,
	Completed  , 5
)  5 6
{!! 
throw"" 
new"" %
InvalidOperationException"" 3
(""3 4
$str""4 \
)""\ ]
;""] ^
}## 
Status%% 
=%% 
AppointmentStatus%% &
.%%& '
	Cancelled%%' 0
;%%0 1
CancellationReason&& 
=&&  
reason&&! '
;&&' (
}'' 	
public** 
void** 
Complete** 
(** 
)** 
{++ 	
if,, 
(,, 
Status,, 
!=,, 
AppointmentStatus,, +
.,,+ ,
	Confirmed,,, 5
),,5 6
{-- 
throw.. 
new.. %
InvalidOperationException.. 3
(..3 4
$str..4 c
)..c d
;..d e
}// 
Status11 
=11 
AppointmentStatus11 &
.11& '
	Completed11' 0
;110 1
}22 	
public55 
string55 

GetDetails55  
(55  !
)55! "
{66 	
StringBuilder77 
details77 !
=77" #
new77$ '
StringBuilder77( 5
(775 6
)776 7
;777 8
details99 
.99 

AppendLine99 
(99 
$"99 !
$str99! 1
{991 2
AppointmentId992 ?
}99? @
"99@ A
)99A B
;99B C
details:: 
.:: 

AppendLine:: 
(:: 
$":: !
$str::! *
{::* +
Patient::+ 2
?::2 3
.::3 4
FullName::4 <
}::< =
"::= >
)::> ?
;::? @
details;; 
.;; 

AppendLine;; 
(;; 
$";; !
$str;;! )
{;;) *
Doctor;;* 0
?;;0 1
.;;1 2
FullName;;2 :
};;: ;
$str;;; =
{;;= >
Doctor;;> D
?;;D E
.;;E F
Specialisation;;F T
};;T U
$str;;U V
";;V W
);;W X
;;;X Y
details<< 
.<< 

AppendLine<< 
(<< 
$"<< !
$str<<! '
{<<' (
ScheduledDate<<( 5
.<<5 6
ToShortDateString<<6 G
(<<G H
)<<H I
}<<I J
"<<J K
)<<K L
;<<L M
details== 
.== 

AppendLine== 
(== 
$"== !
$str==! ,
{==, -
TimeSlot==- 5
}==5 6
"==6 7
)==7 8
;==8 9
details>> 
.>> 

AppendLine>> 
(>> 
$">> !
$str>>! )
{>>) *
Status>>* 0
}>>0 1
">>1 2
)>>2 3
;>>3 4
if@@ 
(@@ 
!@@ 
string@@ 
.@@ 
IsNullOrEmpty@@ %
(@@% &
CancellationReason@@& 8
)@@8 9
)@@9 :
{AA 
detailsBB 
.BB 

AppendLineBB "
(BB" #
$"BB# %
$strBB% :
{BB: ;
CancellationReasonBB; M
}BBM N
"BBN O
)BBO P
;BBP Q
}CC 
returnEE 
detailsEE 
.EE 
ToStringEE #
(EE# $
)EE$ %
;EE% &
}FF 	
}GG 
}HH Áâ
ZC:\Users\310466\Desktop\Learning\HealthAxis\HealthApp\ConsoleApp\Menus\HealthRecordMenu.cs
	namespace		 	
	HealthApp		
 
.		 

ConsoleApp		 
.		 
Menus		 $
{

 
public 

class 
HealthRecordMenu !
{ 
private 
readonly  
IHealthRecordService - 
_healthRecordService. B
;B C
private 
readonly 
IAppointmentService ,
_appointmentService- @
;@ A
public 
const 
string 
Continue $
=% &
$str' G
;G H
public 
const 
string !
HealthRecordCancelled 1
=2 3
$str4 W
;W X
public 
HealthRecordMenu 
(   
IHealthRecordService  4
healthRecordService5 H
,H I
IAppointmentService  3
appointmentService4 F
)F G
{ 	 
_healthRecordService  
=! "
healthRecordService# 6
;6 7
_appointmentService 
=  !
appointmentService" 4
;4 5
} 	
public 
string 
AddHealthRecord %
(% &
)& '
{ 	
try 
{ 
Console 
. 
Clear 
( 
) 
;  
var!! 
appointmentIdInput!! &
=!!' (
InputValidator!!) 7
.!!7 8
GetValidatedInput!!8 I
(!!I J
$str"" =
,""= >
InputValidator## "
.##" #
	IsValidId### ,
,##, -
$str$$ -
)$$- .
;$$. /
int&& 
appointmentId&& !
=&&" #
int&&$ '
.&&' (
Parse&&( -
(&&- .
appointmentIdInput&&. @
!&&@ A
)&&A B
;&&B C
var(( 
appointment(( 
=((  !
_appointmentService((" 5
.((5 6
GetAppointmentById((6 H
(((H I
appointmentId((I V
)((V W
;((W X
if)) 
()) 
appointment)) 
==))  "
null))# '
)))' (
return** 
$str** 2
;**2 3
appointment,, 
.,, 
Complete,, $
(,,$ %
),,% &
;,,& '
var.. 
	diagnosis.. 
=.. 
InputValidator..  .
.... /
GetValidatedInput../ @
(..@ A
$str// '
,//' (
InputValidator00 "
.00" #

IsNonEmpty00# -
,00- .
$str11 0
)110 1
;111 2
var33 
prescription33  
=33! "
InputValidator33# 1
.331 2
GetValidatedInput332 C
(33C D
$str44 *
,44* +
InputValidator55 "
.55" #

IsNonEmpty55# -
,55- .
$str66 3
)663 4
;664 5
var88 
doctorNotes88 
=88  !
InputValidator88" 0
.880 1
GetValidatedInput881 B
(88B C
$str99 *
,99* +
InputValidator:: "
.::" #

IsNonEmpty::# -
,::- .
$str;; 3
);;3 4
;;;4 5
var== 
record== 
=== 
new==  
HealthRecord==! -
{>> 
Patient?? 
=?? 
appointment?? )
.??) *
Patient??* 1
,??1 2
Doctor@@ 
=@@ 
appointment@@ (
.@@( )
Doctor@@) /
,@@/ 0
	VisitDateAA 
=AA 
appointmentAA  +
.AA+ ,
ScheduledDateAA, 9
,AA9 :
	DiagnosisBB 
=BB 
	diagnosisBB  )
!BB) *
,BB* +
PrescriptionCC  
=CC! "
prescriptionCC# /
!CC/ 0
,CC0 1
DoctorNotesDD 
=DD  !
doctorNotesDD" -
!DD- .
}EE 
;EE 
returnGG  
_healthRecordServiceGG +
.GG+ ,
AddHealthRecordGG, ;
(GG; <
recordGG< B
)GGB C
;GGC D
}HH 
catchII 
(II (
AppointmentNotFoundExceptionII /
exII0 2
)II2 3
{JJ 
returnKK 
exKK 
.KK 
MessageKK !
;KK! "
}LL 
catchMM 
(MM &
OperationCanceledExceptionMM -
)MM- .
{NN 
returnOO 
$strOO +
;OO+ ,
}PP 
catchQQ 
(QQ %
InvalidOperationExceptionQQ ,
)QQ, -
{RR 
returnSS 
$strSS ^
;SS^ _
}TT 
}UU 	
publicWW 
voidWW 

ViewRecordWW 
(WW 
)WW  
{XX 	
ConsoleYY 
.YY 
ClearYY 
(YY 
)YY 
;YY 
Console[[ 
.[[ 
	WriteLine[[ 
([[ 
$str[[ 0
)[[0 1
;[[1 2
Console\\ 
.\\ 
	WriteLine\\ 
(\\ 
$str\\ /
)\\/ 0
;\\0 1
Console]] 
.]] 
	WriteLine]] 
(]] 
$str]] /
)]]/ 0
;]]0 1
Console^^ 
.^^ 
Write^^ 
(^^ 
$str^^ *
)^^* +
;^^+ ,
var`` 
choice`` 
=`` 
Console``  
.``  !
ReadLine``! )
(``) *
)``* +
;``+ ,
switchbb 
(bb 
choicebb 
)bb 
{cc 
casedd 
$strdd 
:dd 
HandleViewByIdee "
(ee" #
$stree# ,
,ee, - 
_healthRecordServiceee. B
.eeB C.
"GetByPatientIdOrderByVisitDateDesceeC e
)eee f
;eef g
breakff 
;ff 
casehh 
$strhh 
:hh 
HandleViewByIdii "
(ii" #
$strii# +
,ii+ , 
_healthRecordServiceii- A
.iiA B-
!GetByDoctorIdOrderByVisitDateDesciiB c
)iic d
;iid e
breakjj 
;jj 
casell 
$strll 
:ll "
HandleViewSingleRecordmm *
(mm* +
)mm+ ,
;mm, -
breaknn 
;nn 
defaultpp 
:pp 
Consoleqq 
.qq 
	WriteLineqq %
(qq% &
$strqq& 7
)qq7 8
;qq8 9
Consolerr 
.rr 
ReadKeyrr #
(rr# $
)rr$ %
;rr% &
breakss 
;ss 
}tt 
}uu 	
privateww 
staticww 
voidww 
HandleViewByIdww *
(ww* +
stringxx 

entityNamexx 
,xx 
Funcyy 
<yy 
intyy 
,yy 
Listyy 
<yy 
HealthRecordyy '
>yy' (
>yy( )
	fetchFuncyy* 3
)yy3 4
{zz 	
try{{ 
{|| 
var}} 
idInput}} 
=}} 
InputValidator}} ,
.}}, -
GetValidatedInput}}- >
(}}> ?
$"~~ 
$str~~ 
{~~ 

entityName~~ '
}~~' (
$str~~( -
"~~- .
,~~. /
InputValidator "
." #
	IsValidId# ,
,, -
$"
ÄÄ 
$str
ÄÄ 
{
ÄÄ 

entityName
ÄÄ )
}
ÄÄ) *
$str
ÄÄ* .
"
ÄÄ. /
)
ÄÄ/ 0
;
ÄÄ0 1
int
ÇÇ 
id
ÇÇ 
=
ÇÇ 
int
ÇÇ 
.
ÇÇ 
Parse
ÇÇ "
(
ÇÇ" #
idInput
ÇÇ# *
!
ÇÇ* +
)
ÇÇ+ ,
;
ÇÇ, -
var
ÑÑ 
records
ÑÑ 
=
ÑÑ 
	fetchFunc
ÑÑ '
(
ÑÑ' (
id
ÑÑ( *
)
ÑÑ* +
;
ÑÑ+ ,
Console
ÜÜ 
.
ÜÜ 
Clear
ÜÜ 
(
ÜÜ 
)
ÜÜ 
;
ÜÜ  
Console
áá 
.
áá 
	WriteLine
áá !
(
áá! "
$str
áá" 3
)
áá3 4
;
áá4 5
foreach
ââ 
(
ââ 
var
ââ 
r
ââ 
in
ââ !
records
ââ" )
)
ââ) *
Console
ää 
.
ää 
	WriteLine
ää %
(
ää% &
r
ää& '
)
ää' (
;
ää( )
}
ãã 
catch
åå 
(
åå &
PatientNotFoundException
åå +
ex
åå, .
)
åå. /
{
çç 
Console
éé 
.
éé 
	WriteLine
éé !
(
éé! "
ex
éé" $
.
éé$ %
Message
éé% ,
)
éé, -
;
éé- .
}
èè 
catch
êê 
(
êê +
HealthRecordNotFoundException
êê 0
ex
êê1 3
)
êê3 4
{
ëë 
Console
íí 
.
íí 
	WriteLine
íí !
(
íí! "
ex
íí" $
.
íí$ %
Message
íí% ,
)
íí, -
;
íí- .
}
ìì 
catch
îî 
(
îî 
	Exception
îî 
ex
îî 
)
îî  
{
ïï 
Console
ññ 
.
ññ 
	WriteLine
ññ !
(
ññ! "
ex
ññ" $
.
ññ$ %
Message
ññ% ,
)
ññ, -
;
ññ- .
}
óó 
}
òò 	
private
öö 
void
öö $
HandleViewSingleRecord
öö +
(
öö+ ,
)
öö, -
{
õõ 	
try
úú 
{
ùù 
var
ûû 
idInput
ûû 
=
ûû 
InputValidator
ûû ,
.
ûû, -
GetValidatedInput
ûû- >
(
ûû> ?
$str
üü '
,
üü' (
InputValidator
†† "
.
††" #
	IsValidId
††# ,
,
††, -
$str
°° (
)
°°( )
;
°°) *
int
££ 
recordId
££ 
=
££ 
int
££ "
.
££" #
Parse
££# (
(
££( )
idInput
££) 0
!
££0 1
)
££1 2
;
££2 3
var
•• 
record
•• 
=
•• "
_healthRecordService
•• 1
.
••1 2
GetRecordById
••2 ?
(
••? @
recordId
••@ H
)
••H I
;
••I J
Console
ßß 
.
ßß 
Clear
ßß 
(
ßß 
)
ßß 
;
ßß  
Console
®® 
.
®® 
	WriteLine
®® !
(
®®! "
record
®®" (
)
®®( )
;
®®) *
}
©© 
catch
™™ 
(
™™ +
HealthRecordNotFoundException
™™ 0
ex
™™1 3
)
™™3 4
{
´´ 
Console
¨¨ 
.
¨¨ 
	WriteLine
¨¨ !
(
¨¨! "
ex
¨¨" $
.
¨¨$ %
Message
¨¨% ,
)
¨¨, -
;
¨¨- .
}
≠≠ 
catch
ÆÆ 
(
ÆÆ 
	Exception
ÆÆ 
ex
ÆÆ 
)
ÆÆ  
{
ØØ 
Console
∞∞ 
.
∞∞ 
	WriteLine
∞∞ !
(
∞∞! "
ex
∞∞" $
.
∞∞$ %
Message
∞∞% ,
)
∞∞, -
;
∞∞- .
}
±± 
}
≤≤ 	
public
¥¥ 
string
¥¥  
UpdateHealthRecord
¥¥ (
(
¥¥( )
)
¥¥) *
{
µµ 	
try
∂∂ 
{
∑∑ 
Console
∏∏ 
.
∏∏ 
Write
∏∏ 
(
∏∏ 
$str
∏∏ B
)
∏∏B C
;
∏∏C D
var
ππ 
input
ππ 
=
ππ 
Console
ππ #
.
ππ# $
ReadLine
ππ$ ,
(
ππ, -
)
ππ- .
;
ππ. /
if
ªª 
(
ªª 
input
ªª 
?
ªª 
.
ªª 
ToLower
ªª "
(
ªª" #
)
ªª# $
==
ªª% '
$str
ªª( +
)
ªª+ ,
return
ºº 
HandleCancel
ºº '
(
ºº' (
)
ºº( )
;
ºº) *
if
ææ 
(
ææ 
!
ææ 
int
ææ 
.
ææ 
TryParse
ææ !
(
ææ! "
input
ææ" '
,
ææ' (
out
ææ) ,
int
ææ- 0
recordId
ææ1 9
)
ææ9 :
||
ææ; =
recordId
ææ> F
<=
ææG I
$num
ææJ K
)
ææK L
return
øø 
$str
øø .
;
øø. /
var
¡¡ 
existing
¡¡ 
=
¡¡ "
_healthRecordService
¡¡ 3
.
¡¡3 4
GetRecordById
¡¡4 A
(
¡¡A B
recordId
¡¡B J
)
¡¡J K
;
¡¡K L
if
¬¬ 
(
¬¬ 
existing
¬¬ 
==
¬¬ 
null
¬¬  $
)
¬¬$ %
return
√√ 
$str
√√ -
;
√√- .
Console
≈≈ 
.
≈≈ 
	WriteLine
≈≈ !
(
≈≈! "
$str
≈≈" 5
)
≈≈5 6
;
≈≈6 7
Console
∆∆ 
.
∆∆ 
	WriteLine
∆∆ !
(
∆∆! "
existing
∆∆" *
)
∆∆* +
;
∆∆+ ,
var
»» 
	dateInput
»» 
=
»» 
InputValidator
»»  .
.
»». /
GetOptionalDate
»»/ >
(
»»> ?
$str
…… 5
)
……5 6
;
……6 7
var
ÀÀ 
diagnosisInput
ÀÀ "
=
ÀÀ# $
InputValidator
ÀÀ% 3
.
ÀÀ3 4
GetValidatedInput
ÀÀ4 E
(
ÀÀE F
$str
ÃÃ =
,
ÃÃ= >
InputValidator
ÕÕ "
.
ÕÕ" #

IsNonEmpty
ÕÕ# -
,
ÕÕ- .
$str
ŒŒ (
,
ŒŒ( )

allowEmpty
œœ 
:
œœ 
true
œœ  $
)
œœ$ %
;
œœ% &
var
—— 
prescriptionInput
—— %
=
——& '
InputValidator
——( 6
.
——6 7
GetValidatedInput
——7 H
(
——H I
$str
““ @
,
““@ A
InputValidator
”” "
.
””" #

IsNonEmpty
””# -
,
””- .
$str
‘‘ +
,
‘‘+ ,

allowEmpty
’’ 
:
’’ 
true
’’  $
)
’’$ %
;
’’% &
var
◊◊ 

notesInput
◊◊ 
=
◊◊  
InputValidator
◊◊! /
.
◊◊/ 0
GetValidatedInput
◊◊0 A
(
◊◊A B
$str
ÿÿ @
,
ÿÿ@ A
InputValidator
ŸŸ "
.
ŸŸ" #

IsNonEmpty
ŸŸ# -
,
ŸŸ- .
$str
⁄⁄ $
,
⁄⁄$ %

allowEmpty
€€ 
:
€€ 
true
€€  $
)
€€$ %
;
€€% &
var
›› 
updated
›› 
=
›› 
new
›› !
HealthRecord
››" .
{
ﬁﬁ 
RecordId
ﬂﬂ 
=
ﬂﬂ 
existing
ﬂﬂ '
.
ﬂﬂ' (
RecordId
ﬂﬂ( 0
,
ﬂﬂ0 1
Patient
‡‡ 
=
‡‡ 
existing
‡‡ &
.
‡‡& '
Patient
‡‡' .
,
‡‡. /
Doctor
·· 
=
·· 
existing
·· %
.
··% &
Doctor
··& ,
,
··, -
	VisitDate
‚‚ 
=
‚‚ 
	dateInput
‚‚  )
??
‚‚* ,
existing
‚‚- 5
.
‚‚5 6
	VisitDate
‚‚6 ?
,
‚‚? @
	Diagnosis
„„ 
=
„„ 
diagnosisInput
„„  .
??
„„/ 1
existing
„„2 :
.
„„: ;
	Diagnosis
„„; D
,
„„D E
Prescription
‰‰  
=
‰‰! "
prescriptionInput
‰‰# 4
??
‰‰5 7
existing
‰‰8 @
.
‰‰@ A
Prescription
‰‰A M
,
‰‰M N
DoctorNotes
ÂÂ 
=
ÂÂ  !

notesInput
ÂÂ" ,
??
ÂÂ- /
existing
ÂÂ0 8
.
ÂÂ8 9
DoctorNotes
ÂÂ9 D
}
ÊÊ 
;
ÊÊ 
Console
ËË 
.
ËË 
Clear
ËË 
(
ËË 
)
ËË 
;
ËË  
return
ÈÈ "
_healthRecordService
ÈÈ +
.
ÈÈ+ , 
UpdateHealthRecord
ÈÈ, >
(
ÈÈ> ?
updated
ÈÈ? F
)
ÈÈF G
.
ÈÈG H
ToString
ÈÈH P
(
ÈÈP Q
)
ÈÈQ R
;
ÈÈR S
}
ÍÍ 
catch
ÎÎ 
(
ÎÎ (
OperationCanceledException
ÎÎ -
)
ÎÎ- .
{
ÏÏ 
return
ÌÌ 
HandleCancel
ÌÌ #
(
ÌÌ# $
)
ÌÌ$ %
;
ÌÌ% &
}
ÓÓ 
catch
ÔÔ 
(
ÔÔ +
HealthRecordNotFoundException
ÔÔ 0
ex
ÔÔ1 3
)
ÔÔ3 4
{
 
return
ÒÒ 
ex
ÒÒ 
.
ÒÒ 
Message
ÒÒ !
;
ÒÒ! "
}
ÚÚ 
}
ÛÛ 	
private
ˆˆ 
static
ˆˆ 
string
ˆˆ 
HandleCancel
ˆˆ *
(
ˆˆ* +
)
ˆˆ+ ,
{
˜˜ 	
Console
¯¯ 
.
¯¯ 
	WriteLine
¯¯ 
(
¯¯ #
HealthRecordCancelled
¯¯ 3
)
¯¯3 4
;
¯¯4 5
Console
˘˘ 
.
˘˘ 
	WriteLine
˘˘ 
(
˘˘ 
Continue
˘˘ &
)
˘˘& '
;
˘˘' (
Console
˙˙ 
.
˙˙ 
ReadKey
˙˙ 
(
˙˙ 
)
˙˙ 
;
˙˙ 
return
˚˚ 
$str
˚˚ 
;
˚˚ 
}
¸¸ 	
}
˝˝ 
}˛˛ ¬L
UC:\Users\310466\Desktop\Learning\HealthAxis\HealthApp\ConsoleApp\Menus\PatientMenu.cs
	namespace 	
	HealthApp
 
. 

ConsoleApp 
. 
Menus $
{ 
public		 

class		 
PatientMenu		 
{

 
private 
readonly 
IPatientService (
_patientService) 8
;8 9
public 
const 
string 
Continue $
=% &
$str' G
;G H
public 
const 
string (
PatientRegistrationCancelled 8
=9 :
$str; \
;\ ]
public 
PatientMenu 
( 
IPatientService *
patientService+ 9
)9 :
{ 	
_patientService 
= 
patientService ,
;, -
} 	
public 
string 
RegisterPatient %
(% &
)& '
{ 	
try 
{ 
Console 
. 
Clear 
( 
) 
;  
var 
fullName 
= 
InputValidator -
.- .
GetValidatedInput. ?
(? @
$str 8
,8 9
InputValidator "
." #
IsValidName# .
,. /
$str 3
)3 4
;4 5
var!! 
dob!! 
=!! 
InputValidator!! (
.!!( )
GetValidDate!!) 5
(!!5 6
$str!!6 P
)!!P Q
;!!Q R
var"" 
gender"" 
="" 
InputValidator"" +
.""+ ,
GetValidGender"", :
("": ;
$str""; W
)""W X
;""X Y
var$$ 
phone$$ 
=$$ 
InputValidator$$ *
.$$* +
GetValidatedInput$$+ <
($$< =
$str%% #
,%%# $
InputValidator&& "
.&&" #
IsValidPhone&&# /
,&&/ 0
$str'' -
)''- .
;''. /
var)) 
email)) 
=)) 
InputValidator)) *
.))* +
GetValidatedInput))+ <
())< =
$str** #
,**# $
InputValidator++ "
.++" #
IsValidEmail++# /
,++/ 0
$str,, #
),,# $
;,,$ %
var.. 
insuranceInput.. "
=..# $
InputValidator..% 3
...3 4
GetValidatedInput..4 E
(..E F
$str// *
,//* +
InputValidator00 "
.00" #
IsValidInsuranceId00# 5
,005 6
$str11 *
)11* +
;11+ ,
string33 
insuranceId33 "
=33# $
insuranceInput33% 3
!333 4
;334 5
var55 
patient55 
=55 
new55 !
Patient55" )
{66 
FullName77 
=77 
fullName77 '
!77' (
,77( )
DateOfBirth88 
=88  !
dob88" %
,88% &
Gender99 
=99 
gender99 #
,99# $
PhoneNumber:: 
=::  !
phone::" '
!::' (
,::( )
Email;; 
=;; 
email;; !
!;;! "
,;;" #
InsuranceId<< 
=<<  !
insuranceId<<" -
}== 
;== 
return?? 
_patientService?? &
.??& '
RegisterPatient??' 6
(??6 7
patient??7 >
)??> ?
;??? @
}@@ 
catchAA 
(AA &
OperationCanceledExceptionAA -
)AA- .
{BB 
returnCC 
$strCC +
;CC+ ,
}DD 
}EE 	
publicGG 
stringGG 
UpdatePatientGG #
(GG# $
)GG$ %
{HH 	
tryII 
{JJ 
ConsoleKK 
.KK 
ClearKK 
(KK 
)KK 
;KK  
ConsoleMM 
.MM 
WriteMM 
(MM 
$strMM Y
)MMY Z
;MMZ [
stringNN 
?NN 
inputNN 
=NN 
ConsoleNN  '
.NN' (
ReadLineNN( 0
(NN0 1
)NN1 2
;NN2 3
ifPP 
(PP 
inputPP 
?PP 
.PP 
ToLowerPP "
(PP" #
)PP# $
==PP% '
$strPP( +
)PP+ ,
returnQQ 
$strQQ .
;QQ. /
ifSS 
(SS 
!SS 
intSS 
.SS 
TryParseSS !
(SS! "
inputSS" '
,SS' (
outSS) ,
intSS- 0
	patientIdSS1 :
)SS: ;
||SS< >
	patientIdSS? H
<=SSI K
$numSSL M
)SSM N
returnTT 
$strTT /
;TT/ 0
varVV 
existingPatientVV #
=VV$ %
_patientServiceVV& 5
.VV5 6
GetPatientByIdVV6 D
(VVD E
	patientIdVVE N
)VVN O
;VVO P
ifWW 
(WW 
existingPatientWW #
==WW$ &
nullWW' +
)WW+ ,
returnXX 
$strXX .
;XX. /
ConsoleZZ 
.ZZ 
	WriteLineZZ !
(ZZ! "
$strZZ" >
)ZZ> ?
;ZZ? @
Console[[ 
.[[ 
	WriteLine[[ !
([[! "
existingPatient[[" 1
)[[1 2
;[[2 3
var]] 
fullNameInput]] !
=]]" #
InputValidator]]$ 2
.]]2 3
GetValidatedInput]]3 D
(]]D E
$str^^ N
,^^N O
InputValidator__ "
.__" #
IsValidName__# .
,__. /
$str`` 9
,``9 :

allowEmptyaa 
:aa 
trueaa  $
)aa$ %
;aa% &
varcc 
dobInputcc 
=cc 
InputValidatorcc -
.cc- .
GetOptionalDatecc. =
(cc= >
$strdd M
)ddM N
;ddN O
varff 
genderInputff 
=ff  !
InputValidatorff" 0
.ff0 1
GetOptionalGenderff1 B
(ffB C
$strgg O
)ggO P
;ggP Q
varjj 

phoneInputjj 
=jj  
InputValidatorjj! /
.jj/ 0
GetValidatedInputjj0 A
(jjA B
$strkk H
,kkH I
InputValidatorll "
.ll" #
IsValidPhonell# /
,ll/ 0
$strmm .
,mm. /

allowEmptynn 
:nn 
truenn  $
)nn$ %
;nn% &
varpp 

emailInputpp 
=pp  
InputValidatorpp! /
.pp/ 0
GetValidatedInputpp0 A
(ppA B
$strqq H
,qqH I
InputValidatorrr "
.rr" #
IsValidEmailrr# /
,rr/ 0
$strss $
,ss$ %

allowEmptytt 
:tt 
truett  $
)tt$ %
;tt% &
varvv 
insuranceInputvv "
=vv# $
InputValidatorvv% 3
.vv3 4
GetValidatedInputvv4 E
(vvE F
$strww O
,wwO P
InputValidatorxx "
.xx" #
IsValidInsuranceIdxx# 5
,xx5 6
$stryy +
,yy+ ,

allowEmptyzz 
:zz 
truezz  $
)zz$ %
;zz% &
var|| 
updatedPatient|| "
=||# $
new||% (
Patient||) 0
{}} 
	PatientId~~ 
=~~ 
existingPatient~~  /
.~~/ 0
	PatientId~~0 9
,~~9 :
FullName 
= 
fullNameInput ,
??- /
existingPatient0 ?
.? @
FullName@ H
,H I
DateOfBirth
ÄÄ 
=
ÄÄ  !
dobInput
ÄÄ" *
??
ÄÄ+ -
existingPatient
ÄÄ. =
.
ÄÄ= >
DateOfBirth
ÄÄ> I
,
ÄÄI J
Gender
ÅÅ 
=
ÅÅ 
genderInput
ÅÅ (
??
ÅÅ) +
existingPatient
ÅÅ, ;
.
ÅÅ; <
Gender
ÅÅ< B
,
ÅÅB C
PhoneNumber
ÇÇ 
=
ÇÇ  !

phoneInput
ÇÇ" ,
??
ÇÇ- /
existingPatient
ÇÇ0 ?
.
ÇÇ? @
PhoneNumber
ÇÇ@ K
,
ÇÇK L
Email
ÉÉ 
=
ÉÉ 

emailInput
ÉÉ &
??
ÉÉ' )
existingPatient
ÉÉ* 9
.
ÉÉ9 :
Email
ÉÉ: ?
,
ÉÉ? @
InsuranceId
ÑÑ 
=
ÑÑ  !
insuranceInput
ÑÑ" 0
!=
ÑÑ1 3
null
ÑÑ4 8
?
ÖÖ 
insuranceInput
ÖÖ (
:
ÜÜ 
existingPatient
ÜÜ )
.
ÜÜ) *
InsuranceId
ÜÜ* 5
}
áá 
;
áá 
Console
ââ 
.
ââ 
Clear
ââ 
(
ââ 
)
ââ 
;
ââ  
return
ää 
_patientService
ää &
.
ää& '
UpdatePatient
ää' 4
(
ää4 5
updatedPatient
ää5 C
)
ääC D
.
ääD E
GetProfileSummary
ääE V
(
ääV W
)
ääW X
;
ääX Y
}
ãã 
catch
åå 
(
åå (
OperationCanceledException
åå -
)
åå- .
{
çç 
return
éé 
$str
éé *
;
éé* +
}
èè 
catch
êê 
(
êê &
PatientNotFoundException
êê +
ex
êê, .
)
êê. /
{
ëë 
return
íí 
ex
íí 
.
íí 
Message
íí !
;
íí! "
}
ìì 
}
îî 	
}
ïï 
}ññ Úà
YC:\Users\310466\Desktop\Learning\HealthAxis\HealthApp\ConsoleApp\Menus\AppointmentMenu.cs
	namespace 	
	HealthApp
 
{		 
public

 

class

 
AppointmentMenu

  
{ 
private 
readonly 
IAppointmentService ,
_appointmentService- @
;@ A
private 
readonly 
IPatientService (
_patientService) 8
;8 9
private 
readonly 
IDoctorService '
_doctorService( 6
;6 7
public 
AppointmentMenu 
( 
IAppointmentService 2
appointmentService3 E
,E F
IPatientService  /
patientService0 >
,> ?
IDoctorService  .
doctorService/ <
)< =
{ 	
_appointmentService 
=  !
appointmentService" 4
;4 5
_patientService 
= 
patientService ,
;, -
_doctorService 
= 
doctorService *
;* +
} 	
public 
string 
BookAppointment %
(% &
)& '
{ 	
try 
{ 
Console 
. 
Clear 
( 
) 
;  
var 
patientIdInput "
=# $
InputValidator% 3
.3 4
GetValidatedInput4 E
(E F
$str   9
,  9 :
InputValidator!! "
.!!" #
	IsValidId!!# ,
,!!, -
$str"" )
)"") *
;""* +
int$$ 
	patientId$$ 
=$$ 
int$$  #
.$$# $
Parse$$$ )
($$) *
patientIdInput$$* 8
!$$8 9
)$$9 :
;$$: ;
var%% 
patient%% 
=%% 
_patientService%% -
.%%- .
GetPatientById%%. <
(%%< =
	patientId%%= F
)%%F G
;%%G H
if&& 
(&& 
patient&& 
==&& 
null&& #
)&&# $
return&&% +
$str&&, ?
;&&? @
var(( 
doctorIdInput(( !
=((" #
InputValidator(($ 2
.((2 3
GetValidatedInput((3 D
(((D E
$str)) 8
,))8 9
InputValidator** "
.**" #
	IsValidId**# ,
,**, -
$str++ (
)++( )
;++) *
int-- 
doctorId-- 
=-- 
int-- "
.--" #
Parse--# (
(--( )
doctorIdInput--) 6
!--6 7
)--7 8
;--8 9
var.. 
doctor.. 
=.. 
_doctorService.. +
...+ ,
GetDoctorById.., 9
(..9 :
doctorId..: B
)..B C
;..C D
if// 
(// 
doctor// 
==// 
null// "
)//" #
return//$ *
$str//+ =
;//= >
var11 
date11 
=11 
InputValidator11 )
.11) *
GetValidDate11* 6
(116 7
$str117 ^
)11^ _
;11_ `
Console33 
.33 
	WriteLine33 !
(33! "
$str33" 6
)336 7
;337 8
for55 
(55 
int55 
i55 
=55 
$num55 
;55 
i55  !
<55" #
doctor55$ *
.55* +
Slots55+ 0
.550 1
Count551 6
;556 7
i558 9
++559 ;
)55; <
{66 
Console77 
.77 
	WriteLine77 %
(77% &
$"77& (
$str77( )
{77) *
i77* +
+77, -
$num77. /
}77/ 0
$str770 2
{772 3
doctor773 9
.779 :
Slots77: ?
[77? @
i77@ A
]77A B
}77B C
"77C D
)77D E
;77E F
}88 
var:: 
slotChoiceInput:: #
=::$ %
InputValidator::& 4
.::4 5
GetValidatedInput::5 F
(::F G
$";; 
$str;; %
{;;% &
doctor;;& ,
.;;, -
Slots;;- 2
.;;2 3
Count;;3 8
};;8 9
$str;;9 <
";;< =
,;;= >
input<< 
=><< 
int<<  
.<<  !
TryParse<<! )
(<<) *
input<<* /
,<</ 0
out<<1 4
int<<5 8
s<<9 :
)<<: ;
&&<<< >
s<<? @
>=<<A C
$num<<D E
&&<<F H
s<<I J
<=<<K M
doctor<<N T
.<<T U
Slots<<U Z
.<<Z [
Count<<[ `
,<<` a
$str== #
)==# $
;==$ %
int?? 

slotChoice?? 
=??  
int??! $
.??$ %
Parse??% *
(??* +
slotChoiceInput??+ :
!??: ;
)??; <
;??< =
stringAA 
slotAA 
=AA 
doctorAA $
.AA$ %
SlotsAA% *
[AA* +

slotChoiceAA+ 5
-AA6 7
$numAA8 9
]AA9 :
;AA: ;
returnCC 
_appointmentServiceCC *
.CC* +
BookAppointmentCC+ :
(CC: ;
patientCC; B
,CCB C
doctorCCD J
,CCJ K
dateCCL P
,CCP Q
slotCCR V
)CCV W
;CCW X
}DD 
catchEE 
(EE &
OperationCanceledExceptionEE -
)EE- .
{FF 
returnGG 
HandleCancelGG #
(GG# $
$strGG$ 8
)GG8 9
;GG9 :
}HH 
catchII 
(II 
	ExceptionII 
exII 
)II  
{JJ 
returnKK 
exKK 
.KK 
MessageKK !
;KK! "
}LL 
}MM 	
publicOO 
ListOO 
<OO 
AppointmentOO 
>OO  
ViewAppointmentsOO! 1
(OO1 2
)OO2 3
{PP 	
ConsoleQQ 
.QQ 
ClearQQ 
(QQ 
)QQ 
;QQ 
ConsoleSS 
.SS 
	WriteLineSS 
(SS 
$strSS 0
)SS0 1
;SS1 2
ConsoleTT 
.TT 
	WriteLineTT 
(TT 
$strTT /
)TT/ 0
;TT0 1
ConsoleUU 
.UU 
	WriteLineUU 
(UU 
$strUU 4
)UU4 5
;UU5 6
ConsoleVV 
.VV 
	WriteLineVV 
(VV 
$strVV '
)VV' (
;VV( )
ConsoleWW 
.WW 
WriteWW 
(WW 
$strWW *
)WW* +
;WW+ ,
varYY 
choiceYY 
=YY 
ConsoleYY  
.YY  !
ReadLineYY! )
(YY) *
)YY* +
;YY+ ,
switch[[ 
([[ 
choice[[ 
)[[ 
{\\ 
case]] 
$str]] 
:]] 
ViewById^^ 
(^^ 
$str^^ &
,^^& '
_appointmentService^^( ;
.^^; <&
GetAppointmentsByPatientId^^< V
)^^V W
;^^W X
break__ 
;__ 
caseaa 
$straa 
:aa 
ViewByIdbb 
(bb 
$strbb %
,bb% &
_appointmentServicebb' :
.bb: ;%
GetAppointmentsByDoctorIdbb; T
)bbT U
;bbU V
breakcc 
;cc 
caseee 
$stree 
:ee !
ViewSingleAppointmentff )
(ff) *
)ff* +
;ff+ ,
breakgg 
;gg 
defaultii 
:ii 
returnjj 
[jj 
]jj 
;jj 
}kk 
returnmm 
[mm 
]mm 
;mm 
}nn 	
privatepp 
staticpp 
voidpp 
ViewByIdpp $
(pp$ %
stringpp% +
entitypp, 2
,pp2 3
Funcpp4 8
<pp8 9
intpp9 <
,pp< =
Listpp> B
<ppB C
AppointmentppC N
>ppN O
>ppO P
	fetchFuncppQ Z
)ppZ [
{qq 	
tryrr 
{ss 
vartt 
idInputtt 
=tt 
InputValidatortt ,
.tt, -
GetValidatedInputtt- >
(tt> ?
$"uu 
$struu 
{uu 
entityuu #
}uu# $
$struu$ )
"uu) *
,uu* +
InputValidatorvv "
.vv" #
	IsValidIdvv# ,
,vv, -
$"ww 
$strww 
{ww 
entityww %
}ww% &
$strww& *
"ww* +
)ww+ ,
;ww, -
intyy 
idyy 
=yy 
intyy 
.yy 
Parseyy "
(yy" #
idInputyy# *
!yy* +
)yy+ ,
;yy, -
var{{ 
appointments{{  
={{! "
	fetchFunc{{# ,
({{, -
id{{- /
){{/ 0
;{{0 1
Console}} 
.}} 
Clear}} 
(}} 
)}} 
;}}  
Console~~ 
.~~ 
	WriteLine~~ !
(~~! "
$str~~" <
)~~< =
;~~= >
foreach
ÄÄ 
(
ÄÄ 
var
ÄÄ 
a
ÄÄ 
in
ÄÄ !
appointments
ÄÄ" .
)
ÄÄ. /
Console
ÅÅ 
.
ÅÅ 
	WriteLine
ÅÅ %
(
ÅÅ% &
a
ÅÅ& '
.
ÅÅ' (

GetDetails
ÅÅ( 2
(
ÅÅ2 3
)
ÅÅ3 4
)
ÅÅ4 5
;
ÅÅ5 6
Pause
ÉÉ 
(
ÉÉ 
)
ÉÉ 
;
ÉÉ 
}
ÑÑ 
catch
ÖÖ 
(
ÖÖ 
	Exception
ÖÖ 
ex
ÖÖ 
)
ÖÖ  
{
ÜÜ 
Console
áá 
.
áá 
	WriteLine
áá !
(
áá! "
ex
áá" $
.
áá$ %
Message
áá% ,
)
áá, -
;
áá- .
Pause
àà 
(
àà 
)
àà 
;
àà 
}
ââ 
}
ää 	
private
åå 
void
åå #
ViewSingleAppointment
åå *
(
åå* +
)
åå+ ,
{
çç 	
try
éé 
{
èè 
var
êê 
idInput
êê 
=
êê 
InputValidator
êê ,
.
êê, -
GetValidatedInput
êê- >
(
êê> ?
$str
ëë ,
,
ëë, -
InputValidator
íí "
.
íí" #
	IsValidId
íí# ,
,
íí, -
$str
ìì -
)
ìì- .
;
ìì. /
int
ïï 
id
ïï 
=
ïï 
int
ïï 
.
ïï 
Parse
ïï "
(
ïï" #
idInput
ïï# *
!
ïï* +
)
ïï+ ,
;
ïï, -
var
óó 
appointment
óó 
=
óó  !!
_appointmentService
óó" 5
.
óó5 6 
GetAppointmentById
óó6 H
(
óóH I
id
óóI K
)
óóK L
;
óóL M
Console
ôô 
.
ôô 
Clear
ôô 
(
ôô 
)
ôô 
;
ôô  
Console
öö 
.
öö 
	WriteLine
öö !
(
öö! "
appointment
öö" -
?
öö- .
.
öö. /

GetDetails
öö/ 9
(
öö9 :
)
öö: ;
)
öö; <
;
öö< =
Pause
úú 
(
úú 
)
úú 
;
úú 
}
ùù 
catch
ûû 
(
ûû 
	Exception
ûû 
ex
ûû 
)
ûû  
{
üü 
Console
†† 
.
†† 
	WriteLine
†† !
(
††! "
ex
††" $
.
††$ %
Message
††% ,
)
††, -
;
††- .
Pause
°° 
(
°° 
)
°° 
;
°° 
}
¢¢ 
}
££ 	
public
•• 
string
•• &
ConfirmCancelAppointment
•• .
(
••. /
)
••/ 0
{
¶¶ 	
Console
ßß 
.
ßß 
Clear
ßß 
(
ßß 
)
ßß 
;
ßß 
Console
©© 
.
©© 
	WriteLine
©© 
(
©© 
$str
©© 6
)
©©6 7
;
©©7 8
Console
™™ 
.
™™ 
	WriteLine
™™ 
(
™™ 
$str
™™ 5
)
™™5 6
;
™™6 7
Console
´´ 
.
´´ 
	WriteLine
´´ 
(
´´ 
$str
´´ '
)
´´' (
;
´´( )
Console
¨¨ 
.
¨¨ 
Write
¨¨ 
(
¨¨ 
$str
¨¨ *
)
¨¨* +
;
¨¨+ ,
var
ÆÆ 
choice
ÆÆ 
=
ÆÆ 
Console
ÆÆ  
.
ÆÆ  !
ReadLine
ÆÆ! )
(
ÆÆ) *
)
ÆÆ* +
;
ÆÆ+ ,
return
∞∞ 
choice
∞∞ 
switch
∞∞  
{
±± 
$str
≤≤ 
=>
≤≤  
ConfirmAppointment
≤≤ )
(
≤≤) *
)
≤≤* +
,
≤≤+ ,
$str
≥≥ 
=>
≥≥ 
CancelAppointment
≥≥ (
(
≥≥( )
)
≥≥) *
,
≥≥* +
_
¥¥ 
=>
¥¥ 
$str
¥¥ &
}
µµ 
;
µµ 
}
∂∂ 	
private
∏∏ 
string
∏∏  
ConfirmAppointment
∏∏ )
(
∏∏) *
)
∏∏* +
{
ππ 	
try
∫∫ 
{
ªª 
var
ºº 
input
ºº 
=
ºº 
InputValidator
ºº *
.
ºº* +
GetValidatedInput
ºº+ <
(
ºº< =
$str
ΩΩ ,
,
ΩΩ, -
InputValidator
ææ "
.
ææ" #
	IsValidId
ææ# ,
,
ææ, -
$str
øø -
)
øø- .
;
øø. /
int
¡¡ 
id
¡¡ 
=
¡¡ 
int
¡¡ 
.
¡¡ 
Parse
¡¡ "
(
¡¡" #
input
¡¡# (
!
¡¡( )
)
¡¡) *
;
¡¡* +
var
√√ 
appointment
√√ 
=
√√  !!
_appointmentService
√√" 5
.
√√5 6 
GetAppointmentById
√√6 H
(
√√H I
id
√√I K
)
√√K L
;
√√L M
if
ƒƒ 
(
ƒƒ 
appointment
ƒƒ 
==
ƒƒ  "
null
ƒƒ# '
)
ƒƒ' (
return
≈≈ 
$str
≈≈ 3
;
≈≈3 4
appointment
«« 
.
«« 
Confirm
«« #
(
««# $
)
««$ %
;
««% &
return
…… 
$str
…… <
;
……< =
}
   
catch
ÀÀ 
(
ÀÀ 
	Exception
ÀÀ 
ex
ÀÀ 
)
ÀÀ  
{
ÃÃ 
return
ÕÕ 
ex
ÕÕ 
.
ÕÕ 
Message
ÕÕ !
;
ÕÕ! "
}
ŒŒ 
}
œœ 	
private
—— 
string
—— 
CancelAppointment
—— (
(
——( )
)
——) *
{
““ 	
try
”” 
{
‘‘ 
var
’’ 
idInput
’’ 
=
’’ 
InputValidator
’’ ,
.
’’, -
GetValidatedInput
’’- >
(
’’> ?
$str
÷÷ ,
,
÷÷, -
InputValidator
◊◊ "
.
◊◊" #
	IsValidId
◊◊# ,
,
◊◊, -
$str
ÿÿ -
)
ÿÿ- .
;
ÿÿ. /
int
⁄⁄ 
id
⁄⁄ 
=
⁄⁄ 
int
⁄⁄ 
.
⁄⁄ 
Parse
⁄⁄ "
(
⁄⁄" #
idInput
⁄⁄# *
!
⁄⁄* +
)
⁄⁄+ ,
;
⁄⁄, -
var
‹‹ 
reason
‹‹ 
=
‹‹ 
InputValidator
‹‹ +
.
‹‹+ ,
GetValidatedInput
‹‹, =
(
‹‹= >
$str
›› 1
,
››1 2
InputValidator
ﬁﬁ "
.
ﬁﬁ" #

IsNonEmpty
ﬁﬁ# -
,
ﬁﬁ- .
$str
ﬂﬂ -
)
ﬂﬂ- .
;
ﬂﬂ. /
return
·· !
_appointmentService
·· *
.
··* +
CancelAppointment
··+ <
(
··< =
id
··= ?
,
··? @
reason
··A G
!
··G H
)
··H I
;
··I J
}
‚‚ 
catch
„„ 
(
„„ 
	Exception
„„ 
ex
„„ 
)
„„  
{
‰‰ 
return
ÂÂ 
ex
ÂÂ 
.
ÂÂ 
Message
ÂÂ !
;
ÂÂ! "
}
ÊÊ 
}
ÁÁ 	
private
ÈÈ 
static
ÈÈ 
string
ÈÈ 
HandleCancel
ÈÈ *
(
ÈÈ* +
string
ÈÈ+ 1
message
ÈÈ2 9
)
ÈÈ9 :
{
ÍÍ 	
Console
ÎÎ 
.
ÎÎ 
	WriteLine
ÎÎ 
(
ÎÎ 
message
ÎÎ %
)
ÎÎ% &
;
ÎÎ& '
Console
ÏÏ 
.
ÏÏ 
ReadKey
ÏÏ 
(
ÏÏ 
)
ÏÏ 
;
ÏÏ 
return
ÌÌ 
$str
ÌÌ 
;
ÌÌ 
}
ÓÓ 	
private
 
static
 
void
 
Pause
 !
(
! "
)
" #
{
ÒÒ 	
Console
ÚÚ 
.
ÚÚ 
	WriteLine
ÚÚ 
(
ÚÚ 
$str
ÚÚ >
)
ÚÚ> ?
;
ÚÚ? @
Console
ÛÛ 
.
ÛÛ 
ReadKey
ÛÛ 
(
ÛÛ 
)
ÛÛ 
;
ÛÛ 
}
ÙÙ 	
}
ıı 
}ˆˆ ˜
^C:\Users\310466\Desktop\Learning\HealthAxis\HealthApp\ConsoleApp\Interfaces\IPatientService.cs
	namespace 	
	HealthApp
 
. 

ConsoleApp 
. 

Interfaces )
{ 
public 

	interface 
IPatientService $
{ 
string		 
RegisterPatient		 
(		 
Patient		 &
patient		' .
)		. /
;		/ 0
Patient

 
UpdatePatient

 
(

 
Patient

 %
patient

& -
)

- .
;

. /
Patient 
? 
GetPatientById 
(  
int  #
id$ &
)& '
;' (
} 
} Ã
aC:\Users\310466\Desktop\Learning\HealthAxis\HealthApp\ConsoleApp\Interfaces\IPatientRepository.cs
	namespace 	
	HealthApp
 
. 

ConsoleApp 
. 

Interfaces )
{ 
public 

	interface 
IPatientRepository '
{ 
string 
RegisterPatient 
( 
Patient &
patient' .
). /
;/ 0
Patient 
UpdatePatient 
( 
Patient %
existingPatient& 5
,5 6
Patient7 >
patient? F
)F G
;G H
List		 
<		 
Patient		 
>		 
GetAllPatients		 $
(		$ %
)		% &
;		& '
Patient

 
?

 
GetPatientById

 
(

  
int

  #
id

$ &
)

& '
;

' (
} 
} ¨	
cC:\Users\310466\Desktop\Learning\HealthAxis\HealthApp\ConsoleApp\Interfaces\IHealthRecordService.cs
	namespace 	
	HealthApp
 
. 

ConsoleApp 
. 

Interfaces )
{ 
public 

	interface  
IHealthRecordService )
{ 
string 
AddHealthRecord 
( 
HealthRecord +
record, 2
)2 3
;3 4
HealthRecord 
UpdateHealthRecord '
(' (
HealthRecord( 4
record5 ;
); <
;< =
HealthRecord		 
?		 
GetRecordById		 #
(		# $
int		$ '
recordId		( 0
)		0 1
;		1 2
List

 
<

 
HealthRecord

 
>

 .
"GetByPatientIdOrderByVisitDateDesc

 =
(

= >
int

> A
id

B D
)

D E
;

E F
List 
< 
HealthRecord 
> -
!GetByDoctorIdOrderByVisitDateDesc <
(< =
int= @
idA C
)C D
;D E
} 
} â
fC:\Users\310466\Desktop\Learning\HealthAxis\HealthApp\ConsoleApp\Interfaces\IHealthRecordRepository.cs
	namespace 	
	HealthApp
 
. 

ConsoleApp 
. 

Interfaces )
{ 
public 

	interface #
IHealthRecordRepository ,
{ 
string 
AddHealthRecord 
( 
HealthRecord +
record, 2
)2 3
;3 4
HealthRecord 
? 
GetRecordById #
(# $
int$ '
id( *
)* +
;+ ,
List		 
<		 
HealthRecord		 
>		 .
"GetByPatientIdOrderByVisitDateDesc		 =
(		= >
int		> A
id		B D
)		D E
;		E F
List

 
<

 
HealthRecord

 
>

 -
!GetByDoctorIdOrderByVisitDateDesc

 <
(

< =
int

= @
id

A C
)

C D
;

D E
HealthRecord 
UpdateHealthRecord '
(' (
HealthRecord( 4 
existingHealthRecord5 I
,I J
HealthRecordK W
recordX ^
)^ _
;_ `
List 
< 
HealthRecord 
> 
GetAllRecords (
(( )
)) *
;* +
} 
} ∞
]C:\Users\310466\Desktop\Learning\HealthAxis\HealthApp\ConsoleApp\Interfaces\IDoctorService.cs
	namespace 	
	HealthApp
 
. 

ConsoleApp 
. 

Interfaces )
{ 
public 

	interface 
IDoctorService #
{ 
string		 
	AddDoctor		 
(		 
Doctor		 
doctor		  &
)		& '
;		' (
Doctor

 
?

 
GetDoctorById

 
(

 
int

 !
id

" $
)

$ %
;

% &
List 
< 
Doctor 
> &
GetDoctorsBySpecialisation /
(/ 0
string0 6
specialisation7 E
)E F
;F G
Doctor 
UpdateDoctor 
( 
Doctor "
doctor# )
)) *
;* +
} 
} Å	
`C:\Users\310466\Desktop\Learning\HealthAxis\HealthApp\ConsoleApp\Interfaces\IDoctorRepository.cs
	namespace 	
	HealthApp
 
. 

ConsoleApp 
. 

Interfaces )
{ 
public 

	interface 
IDoctorRepository &
{ 
string 
	AddDoctor 
( 
Doctor 
doctor  &
)& '
;' (
Doctor 
? 
GetDoctorById 
( 
int !
id" $
)$ %
;% &
List		 
<		 
Doctor		 
>		 &
GetDoctorsBySpecialisation		 /
(		/ 0
string		0 6
specialisation		7 E
)		E F
;		F G
Doctor

 
UpdateDoctor

 
(

 
Doctor

 "
existingDoctor

# 1
,

1 2
Doctor

3 9
doctor

: @
)

@ A
;

A B
List 
< 
Doctor 
> 
GetAllDoctors "
(" #
)# $
;$ %
} 
} ß
bC:\Users\310466\Desktop\Learning\HealthAxis\HealthApp\ConsoleApp\Interfaces\IAppointmentService.cs
	namespace 	
	HealthApp
 
. 

ConsoleApp 
. 

Interfaces )
{ 
public 
	interface 
IAppointmentService $
{ 
string 

BookAppointment 
( 
Patient "
patient# *
,* +
Doctor, 2
doctor3 9
,9 :
DateTime; C
dateD H
,H I
stringJ P
slotQ U
)U V
;V W
string		 

CancelAppointment		 
(		 
int		  
appointmentId		! .
,		. /
string		0 6
reason		7 =
)		= >
;		> ?
List

 
<

 	
Appointment

	 
>

 &
GetAppointmentsByPatientId

 0
(

0 1
int

1 4
	patientId

5 >
)

> ?
;

? @
List 
< 	
Appointment	 
> %
GetAppointmentsByDoctorId /
(/ 0
int0 3
doctorId4 <
)< =
;= >
Appointment 
? 
GetAppointmentById #
(# $
int$ '
appointmentId( 5
)5 6
;6 7
List 
< 	
Appointment	 
> #
GetUpcomingAppointments -
(- .
). /
;/ 0
Appointment 
UpdateAppointment !
(! "
Appointment" -
appointment. 9
)9 :
;: ;
} 
} ç
eC:\Users\310466\Desktop\Learning\HealthAxis\HealthApp\ConsoleApp\Interfaces\IAppointmentRepository.cs
	namespace 	
	HealthApp
 
. 

ConsoleApp 
. 

Interfaces )
{ 
public 

	interface "
IAppointmentRepository +
{ 
string 
AddAppointment 
( 
Appointment )
appointment* 5
)5 6
;6 7
List 
< 
Appointment 
> 
GetAllAppointments ,
(, -
)- .
;. /
Appointment 
? 
GetAppointmentById '
(' (
int( +
id, .
). /
;/ 0
Appointment		 
UpdateAppointment		 %
(		% &
Appointment		& 1
existingAppointment		2 E
,		E F
Appointment		G R
appointment		S ^
)		^ _
;		_ `
List

 
<

 
Appointment

 
>

 %
GetAppointmentsByDoctorId

 3
(

3 4
int

4 7
doctorId

8 @
)

@ A
;

A B
List 
< 
Appointment 
> &
GetAppointmentsByPatientId 4
(4 5
int5 8
	patientId9 B
)B C
;C D
} 
} Ü
VC:\Users\310466\Desktop\Learning\HealthAxis\HealthApp\ConsoleApp\Helpers\SlotHelper.cs
	namespace 	
	HealthApp
 
. 

ConsoleApp 
. 
Helpers &
{ 
public 

static 
class 

SlotHelper "
{ 
private

 
static

 
readonly

 
List

  $
<

$ %
string

% +
>

+ ,
AvailableSlots

- ;
=

< =
new

> A
List

B F
<

F G
string

G M
>

M N
{ 	
$str 
, 
$str 
, 
$str 
, 
$str 
, 
$str 
, 
$str 
, 
$str 
, 
$str 
} 	
;	 

public 
static 
void 

PrintSlots %
(% &
)& '
{ 	
for 
( 
int 
i 
= 
$num 
; 
i 
< 
AvailableSlots  .
.. /
Count/ 4
;4 5
i6 7
++7 9
)9 :
{ 
Console 
. 
	WriteLine !
(! "
$"" $
{$ %
i% &
+' (
$num) *
}* +
$str+ -
{- .
AvailableSlots. <
[< =
i= >
]> ?
}? @
"@ A
)A B
;B C
} 
} 	
public 
static 
List 
< 
string !
>! "
?" #
SimpleParseSlots$ 4
(4 5
string5 ;
input< A
)A B
{ 	
var   
result   
=   
new   
List   !
<  ! "
string  " (
>  ( )
(  ) *
)  * +
;  + ,
var"" 
parts"" 
="" 
input"" 
."" 
Split"" #
(""# $
$char""$ '
)""' (
;""( )
foreach$$ 
($$ 
var$$ 
part$$ 
in$$  
parts$$! &
)$$& '
{%% 
if&& 
(&& 
int&& 
.&& 
TryParse&&  
(&&  !
part&&! %
.&&% &
Trim&&& *
(&&* +
)&&+ ,
,&&, -
out&&. 1
int&&2 5
index&&6 ;
)&&; <
&&&&= ?
index'' 
>='' 
$num'' 
&&'' !
index''" '
<=''( *
AvailableSlots''+ 9
.''9 :
Count'': ?
)''? @
{(( 
var)) 
slot)) 
=)) 
AvailableSlots)) -
[))- .
index)). 3
-))4 5
$num))6 7
]))7 8
;))8 9
if++ 
(++ 
!++ 
result++ 
.++  
Contains++  (
(++( )
slot++) -
)++- .
)++. /
{,, 
result-- 
.-- 
Add-- "
(--" #
slot--# '
)--' (
;--( )
}.. 
}// 
}00 
return22 
result22 
.22 
Count22 
>22  !
$num22" #
?22$ %
result22& ,
:22- .
null22/ 3
;223 4
}33 	
}44 
}55 Õq
ZC:\Users\310466\Desktop\Learning\HealthAxis\HealthApp\ConsoleApp\Helpers\InputValidator.cs
	namespace 	
	HealthApp
 
. 

ConsoleApp 
. 
Helpers &
{ 
public 

static 
class 
InputValidator &
{ 
public		 
static		 
string		 
?		 
GetValidatedInput		 /
(		/ 0
string

 
prompt

 
,

 
Func 
< 
string 
, 
bool 
> 
	validator (
,( )
string 
errorMessage 
,  
bool 

allowEmpty 
= 
false #
)# $
{ 	
while 
( 
true 
) 
{ 
Console 
. 
Write 
( 
prompt $
)$ %
;% &
string 
? 
input 
= 
Console  '
.' (
ReadLine( 0
(0 1
)1 2
;2 3
if 
( 
input 
? 
. 
ToLower "
(" #
)# $
==% '
$str( +
||, .
input/ 4
?4 5
.5 6
ToLower6 =
(= >
)> ?
==@ B
$strC I
)I J
throw 
new &
OperationCanceledException 8
(8 9
)9 :
;: ;
if 
( 

allowEmpty 
&& !
string" (
.( )
IsNullOrWhiteSpace) ;
(; <
input< A
)A B
)B C
return 
null 
;  
if 
( 
! 
string 
. 
IsNullOrWhiteSpace .
(. /
input/ 4
)4 5
&&6 8
	validator9 B
(B C
inputC H
)H I
)I J
return 
input  
.  !
Trim! %
(% &
)& '
;' (
Console 
. 
	WriteLine !
(! "
errorMessage" .
). /
;/ 0
} 
} 	
public!! 
static!! 
DateTime!! 
GetValidDate!! +
(!!+ ,
string!!, 2
prompt!!3 9
)!!9 :
{"" 	
while## 
(## 
true## 
)## 
{$$ 
Console%% 
.%% 
Write%% 
(%% 
prompt%% $
)%%$ %
;%%% &
var&& 
input&& 
=&& 
Console&& #
.&&# $
ReadLine&&$ ,
(&&, -
)&&- .
;&&. /
if(( 
((( 
input(( 
?(( 
.(( 
ToLower(( "
(((" #
)((# $
==((% '
$str((( +
)((+ ,
throw)) 
new)) &
OperationCanceledException)) 8
())8 9
)))9 :
;)): ;
if++ 
(++ 
DateTime++ 
.++ 
TryParseExact++ *
(++* +
input,, 
,,, 
$str--  
,--  !
CultureInfo.. 
...  
InvariantCulture..  0
,..0 1
DateTimeStyles// "
.//" #
None//# '
,//' (
out00 
var00 
date00  
)00  !
)00! "
{11 
return22 
date22 
;22  
}33 
Console55 
.55 
	WriteLine55 !
(55! "
$str55" 1
)551 2
;552 3
}66 
}77 	
public99 
static99 
DateTime99 
?99 
GetOptionalDate99  /
(99/ 0
string990 6
prompt997 =
)99= >
{:: 	
while;; 
(;; 
true;; 
);; 
{<< 
Console== 
.== 
Write== 
(== 
prompt== $
)==$ %
;==% &
var>> 
input>> 
=>> 
Console>> #
.>># $
ReadLine>>$ ,
(>>, -
)>>- .
;>>. /
if@@ 
(@@ 
string@@ 
.@@ 
IsNullOrWhiteSpace@@ -
(@@- .
input@@. 3
)@@3 4
)@@4 5
returnAA 
nullAA 
;AA  
ifCC 
(CC 
inputCC 
?CC 
.CC 
ToLowerCC "
(CC" #
)CC# $
==CC% '
$strCC( +
)CC+ ,
throwDD 
newDD &
OperationCanceledExceptionDD 8
(DD8 9
)DD9 :
;DD: ;
ifFF 
(FF 
DateTimeFF 
.FF 
TryParseExactFF *
(FF* +
inputGG 
,GG 
$strHH  
,HH  !
CultureInfoII 
.II  
InvariantCultureII  0
,II0 1
DateTimeStylesJJ "
.JJ" #
NoneJJ# '
,JJ' (
outKK 
varKK 
dateKK  
)KK  !
)KK! "
{LL 
returnMM 
dateMM 
;MM  
}NN 
ConsolePP 
.PP 
	WriteLinePP !
(PP! "
$strPP" 1
)PP1 2
;PP2 3
}QQ 
}RR 	
publicTT 
staticTT 

GenderTypeTT  
?TT  !
GetOptionalGenderTT" 3
(TT3 4
stringTT4 :
promptTT; A
)TTA B
{UU 	
whileVV 
(VV 
trueVV 
)VV 
{WW 
ConsoleXX 
.XX 
WriteXX 
(XX 
promptXX $
)XX$ %
;XX% &
varYY 
inputYY 
=YY 
ConsoleYY #
.YY# $
ReadLineYY$ ,
(YY, -
)YY- .
;YY. /
if[[ 
([[ 
string[[ 
.[[ 
IsNullOrWhiteSpace[[ -
([[- .
input[[. 3
)[[3 4
)[[4 5
return\\ 
null\\ 
;\\  
if^^ 
(^^ 
input^^ 
?^^ 
.^^ 
ToLower^^ "
(^^" #
)^^# $
==^^% '
$str^^( +
)^^+ ,
throw__ 
new__ &
OperationCanceledException__ 8
(__8 9
)__9 :
;__: ;
ifaa 
(aa 
Enumaa 
.aa 
TryParseaa !
<aa! "

GenderTypeaa" ,
>aa, -
(aa- .
inputaa. 3
,aa3 4
trueaa5 9
,aa9 :
outaa; >
varaa? B
genderaaC I
)aaI J
)aaJ K
returnbb 
genderbb !
;bb! "
Consoledd 
.dd 
	WriteLinedd !
(dd! "
$strdd" 3
)dd3 4
;dd4 5
}ee 
}ff 	
publichh 
statichh 

GenderTypehh  
GetValidGenderhh! /
(hh/ 0
stringhh0 6
prompthh7 =
)hh= >
{ii 	
whilejj 
(jj 
truejj 
)jj 
{kk 
Consolell 
.ll 
Writell 
(ll 
promptll $
)ll$ %
;ll% &
varmm 
inputmm 
=mm 
Consolemm #
.mm# $
ReadLinemm$ ,
(mm, -
)mm- .
;mm. /
ifoo 
(oo 
inputoo 
?oo 
.oo 
ToLoweroo "
(oo" #
)oo# $
==oo% '
$stroo( +
)oo+ ,
throwpp 
newpp &
OperationCanceledExceptionpp 8
(pp8 9
)pp9 :
;pp: ;
ifrr 
(rr 
Enumrr 
.rr 
TryParserr !
<rr! "

GenderTyperr" ,
>rr, -
(rr- .
inputrr. 3
,rr3 4
truerr5 9
,rr9 :
outrr; >
varrr? B
genderrrC I
)rrI J
)rrJ K
returnss 
genderss !
;ss! "
Consoleuu 
.uu 
	WriteLineuu !
(uu! "
$struu" 3
)uu3 4
;uu4 5
}vv 
}ww 	
publicyy 
staticyy 
boolyy 
?yy 
GetOptionalBoolyy +
(yy+ ,
stringyy, 2
promptyy3 9
)yy9 :
{zz 	
while{{ 
({{ 
true{{ 
){{ 
{|| 
Console}} 
.}} 
Write}} 
(}} 
prompt}} $
)}}$ %
;}}% &
var~~ 
input~~ 
=~~ 
Console~~ #
.~~# $
ReadLine~~$ ,
(~~, -
)~~- .
?~~. /
.~~/ 0
Trim~~0 4
(~~4 5
)~~5 6
.~~6 7
ToLower~~7 >
(~~> ?
)~~? @
;~~@ A
if
ÄÄ 
(
ÄÄ 
string
ÄÄ 
.
ÄÄ  
IsNullOrWhiteSpace
ÄÄ -
(
ÄÄ- .
input
ÄÄ. 3
)
ÄÄ3 4
)
ÄÄ4 5
return
ÅÅ 
null
ÅÅ 
;
ÅÅ  
if
ÉÉ 
(
ÉÉ 
input
ÉÉ 
==
ÉÉ 
$str
ÉÉ  
)
ÉÉ  !
throw
ÑÑ 
new
ÑÑ (
OperationCanceledException
ÑÑ 8
(
ÑÑ8 9
)
ÑÑ9 :
;
ÑÑ: ;
if
ÜÜ 
(
ÜÜ 
input
ÜÜ 
==
ÜÜ 
$str
ÜÜ  
)
ÜÜ  !
return
ÜÜ" (
true
ÜÜ) -
;
ÜÜ- .
if
áá 
(
áá 
input
áá 
==
áá 
$str
áá  
)
áá  !
return
áá" (
false
áá) .
;
áá. /
Console
ââ 
.
ââ 
	WriteLine
ââ !
(
ââ! "
$str
ââ" 1
)
ââ1 2
;
ââ2 3
}
ää 
}
ãã 	
public
çç 
static
çç 
bool
çç 
IsValidName
çç &
(
çç& '
string
çç' -
input
çç. 3
)
çç3 4
=>
çç5 7
!
éé 	
string
éé	 
.
éé  
IsNullOrWhiteSpace
éé "
(
éé" #
input
éé# (
)
éé( )
&&
éé* ,
!
éé- .
input
éé. 3
.
éé3 4
Any
éé4 7
(
éé7 8
char
éé8 <
.
éé< =
IsDigit
éé= D
)
ééD E
;
ééE F
public
êê 
static
êê 
bool
êê 
IsValidPhone
êê '
(
êê' (
string
êê( .
input
êê/ 4
)
êê4 5
{
ëë 	
string
íí 
pattern
íí 
=
íí 
$str
íí ,
;
íí, -
return
ìì 
Regex
ìì 
.
ìì 
IsMatch
ìì  
(
ìì  !
input
îî 
,
îî 
pattern
ïï 
,
ïï 
RegexOptions
ññ 
.
ññ 
None
ññ !
,
ññ! "
TimeSpan
óó 
.
óó 
FromMilliseconds
óó )
(
óó) *
$num
óó* -
)
óó- .
)
òò 
;
òò 
}
ôô 	
public
õõ 
static
õõ 
bool
õõ 
IsValidEmail
õõ '
(
õõ' (
string
õõ( .
input
õõ/ 4
)
õõ4 5
{
úú 	
string
ùù 
pattern
ùù 
=
ùù 
$str
ùù :
;
ùù: ;
return
üü 
Regex
üü 
.
üü 
IsMatch
üü  
(
üü  !
input
†† 
,
†† 
pattern
°° 
,
°° 
RegexOptions
¢¢ 
.
¢¢ 
None
¢¢ !
,
¢¢! "
TimeSpan
££ 
.
££ 
FromMilliseconds
££ )
(
££) *
$num
££* -
)
££- .
)
§§ 
;
§§ 
}
•• 	
public
ßß 
static
ßß 
bool
ßß  
IsValidInsuranceId
ßß -
(
ßß- .
string
ßß. 4
input
ßß5 :
)
ßß: ;
=>
ßß< >
!
®® 
string
®® 
.
®®  
IsNullOrWhiteSpace
®® &
(
®®& '
input
®®' ,
)
®®, -
&&
®®. 0
input
©© 
.
©© 
All
©© 
(
©© 
char
©© 
.
©© 
IsLetterOrDigit
©© *
)
©©* +
;
©©+ ,
public
´´ 
static
´´ 
bool
´´ 
IsValidExperience
´´ ,
(
´´, -
string
´´- 3
input
´´4 9
)
´´9 :
=>
´´; =
int
¨¨ 
.
¨¨ 
TryParse
¨¨ 
(
¨¨ 
input
¨¨ 
,
¨¨ 
out
¨¨  #
int
¨¨$ '
val
¨¨( +
)
¨¨+ ,
&&
¨¨- /
val
¨¨0 3
>=
¨¨4 6
$num
¨¨7 8
;
¨¨8 9
public
ÆÆ 
static
ÆÆ 
bool
ÆÆ 

IsValidFee
ÆÆ %
(
ÆÆ% &
string
ÆÆ& ,
input
ÆÆ- 2
)
ÆÆ2 3
=>
ÆÆ4 6
decimal
ØØ 
.
ØØ 
TryParse
ØØ 
(
ØØ 
input
ØØ "
,
ØØ" #
out
ØØ$ '
decimal
ØØ( /
val
ØØ0 3
)
ØØ3 4
&&
ØØ5 7
val
ØØ8 ;
>=
ØØ< >
$num
ØØ? @
;
ØØ@ A
public
±± 
static
±± 
bool
±± 
	IsValidId
±± $
(
±±$ %
string
±±% +
input
±±, 1
)
±±1 2
=>
±±3 5
int
≤≤ 
.
≤≤ 
TryParse
≤≤ 
(
≤≤ 
input
≤≤ 
,
≤≤ 
out
≤≤  #
int
≤≤$ '
id
≤≤( *
)
≤≤* +
&&
≤≤, .
id
≤≤/ 1
>
≤≤2 3
$num
≤≤4 5
;
≤≤5 6
public
¥¥ 
static
¥¥ 
bool
¥¥ 

IsNonEmpty
¥¥ %
(
¥¥% &
string
¥¥& ,
input
¥¥- 2
)
¥¥2 3
=>
¥¥4 6
!
µµ 
string
µµ 
.
µµ  
IsNullOrWhiteSpace
µµ &
(
µµ& '
input
µµ' ,
)
µµ, -
;
µµ- .
}
∂∂ 
}∑∑ ñ
nC:\Users\310466\Desktop\Learning\HealthAxis\HealthApp\ConsoleApp\Exceptions\SpecialisationNotFoundException.cs
	namespace 	
	HealthApp
 
. 

ConsoleApp 
. 

Exceptions )
{ 
public 

class +
SpecialisationNotFoundException 0
:1 2
	Exception3 <
{ 
public +
SpecialisationNotFoundException .
(. /
string/ 5
message6 =
)= >
:? @
baseA E
(E F
messageF M
)M N
{ 	
}		 	
}

 
} Å
gC:\Users\310466\Desktop\Learning\HealthAxis\HealthApp\ConsoleApp\Exceptions\PatientNotFoundException.cs
	namespace 	
	HealthApp
 
. 

ConsoleApp 
. 

Exceptions )
{ 
public 

class $
PatientNotFoundException )
:* +
	Exception, 5
{ 
public $
PatientNotFoundException '
(' (
string( .
message/ 6
)6 7
:8 9
base: >
(> ?
message? F
)F G
{ 	
} 	
}		 
}

 ê
lC:\Users\310466\Desktop\Learning\HealthAxis\HealthApp\ConsoleApp\Exceptions\PatientAlreadyExistsException.cs
	namespace 	
	HealthApp
 
. 

ConsoleApp 
. 

Exceptions )
{ 
public 

class )
PatientAlreadyExistsException .
:/ 0
	Exception1 :
{ 
public )
PatientAlreadyExistsException ,
(, -
string- 3
message4 ;
); <
:= >
base? C
(C D
messageD K
)K L
{ 	
} 	
}		 
}

 Ï
`C:\Users\310466\Desktop\Learning\HealthAxis\HealthApp\ConsoleApp\Exceptions\PastDateException.cs
	namespace 	
	HealthApp
 
. 

ConsoleApp 
. 

Exceptions )
{ 
public 

class 
PastDateException "
:# $
	Exception% .
{ 
public 
PastDateException  
(  !
string! '
message( /
)/ 0
:1 2
base3 7
(7 8
message8 ?
)? @
{ 	
} 	
}		 
}

 ê
lC:\Users\310466\Desktop\Learning\HealthAxis\HealthApp\ConsoleApp\Exceptions\HealthRecordNotFoundException.cs
	namespace 	
	HealthApp
 
. 

ConsoleApp 
. 

Exceptions )
{ 
public 

class )
HealthRecordNotFoundException .
:/ 0
	Exception1 :
{ 
public )
HealthRecordNotFoundException ,
(, -
string- 3
message4 ;
); <
:= >
base? C
(C D
messageD K
)K L
{ 	
} 	
}		 
}

 ä
jC:\Users\310466\Desktop\Learning\HealthAxis\HealthApp\ConsoleApp\Exceptions\HealthRecordExistsException.cs
	namespace 	
	HealthApp
 
. 

ConsoleApp 
. 

Exceptions )
{ 
public 

class '
HealthRecordExistsException ,
:- .
	Exception/ 8
{ 
public '
HealthRecordExistsException *
(* +
string+ 1
message2 9
)9 :
:; <
base= A
(A B
messageB I
)I J
{ 	
} 	
}		 
}

 á
iC:\Users\310466\Desktop\Learning\HealthAxis\HealthApp\ConsoleApp\Exceptions\DoctorUnavailableException.cs
	namespace 	
	HealthApp
 
. 

ConsoleApp 
. 

Exceptions )
{ 
public 

class &
DoctorUnavailableException +
:, -
	Exception. 7
{ 
public &
DoctorUnavailableException )
() *
string* 0
message1 8
)8 9
:: ;
base< @
(@ A
messageA H
)H I
{ 	
}		 	
}

 
} ˛
fC:\Users\310466\Desktop\Learning\HealthAxis\HealthApp\ConsoleApp\Exceptions\DoctorNotFoundException.cs
	namespace 	
	HealthApp
 
. 

ConsoleApp 
. 

Exceptions )
{ 
public 

class #
DoctorNotFoundException (
:) *
	Exception+ 4
{ 
public #
DoctorNotFoundException &
(& '
string' -
message. 5
)5 6
:7 8
base9 =
(= >
message> E
)E F
{ 	
}		 	
}

 
} ç
kC:\Users\310466\Desktop\Learning\HealthAxis\HealthApp\ConsoleApp\Exceptions\DoctorAlreadyExistsException.cs
	namespace 	
	HealthApp
 
. 

ConsoleApp 
. 

Exceptions )
{ 
public 

class (
DoctorAlreadyExistsException -
:. /
	Exception0 9
{ 
public (
DoctorAlreadyExistsException +
(+ ,
string, 2
message3 :
): ;
:< =
base> B
(B C
messageC J
)J K
{ 	
}		 	
}

 
} ç
kC:\Users\310466\Desktop\Learning\HealthAxis\HealthApp\ConsoleApp\Exceptions\AppointmentNotFoundException.cs
	namespace 	
	HealthApp
 
. 

ConsoleApp 
. 

Exceptions )
{ 
public 

class (
AppointmentNotFoundException -
:. /
	Exception0 9
{ 
public (
AppointmentNotFoundException +
(+ ,
string, 2
message3 :
): ;
:< =
base> B
(B C
messageC J
)J K
{ 	
} 	
}		 
}

 ô
oC:\Users\310466\Desktop\Learning\HealthAxis\HealthApp\ConsoleApp\Exceptions\AppointmentNotCompletedException.cs
	namespace 	
	HealthApp
 
. 

ConsoleApp 
. 

Exceptions )
{ 
public 

class ,
 AppointmentNotCompletedException 1
:2 3
	Exception4 =
{ 
public ,
 AppointmentNotCompletedException /
(/ 0
string0 6
message7 >
)> ?
:@ A
baseB F
(F G
messageG N
)N O
{ 	
} 	
}		 
}

 ç
kC:\Users\310466\Desktop\Learning\HealthAxis\HealthApp\ConsoleApp\Exceptions\AppointmentConflictException.cs
	namespace 	
	HealthApp
 
. 

ConsoleApp 
. 

Exceptions )
{ 
public 

class (
AppointmentConflictException -
:. /
	Exception0 9
{ 
public (
AppointmentConflictException +
(+ ,
string, 2
message3 :
): ;
:< =
base> B
(B C
messageC J
)J K
{ 	
} 	
}		 
}

 ñ
WC:\Users\310466\Desktop\Learning\HealthAxis\HealthApp\ConsoleApp\Databases\PatientDb.cs
	namespace 	
	HealthApp
 
. 

ConsoleApp 
. 
	Databases (
;( )
public 
class 
	PatientDb 
{ 
public 

List 
< 
Patient 
> 
Patients !
{" #
get$ '
;' (
set) ,
;, -
}. /
=0 1
new2 5
List6 :
<: ;
Patient; B
>B C
(C D
)D E
;E F
} ∫
\C:\Users\310466\Desktop\Learning\HealthAxis\HealthApp\ConsoleApp\Databases\HealthRecordDB.cs
	namespace 	
	HealthApp
 
. 

ConsoleApp 
. 
	Databases (
{ 
public 

class 
HealthRecordDB 
{ 
public 
List 
< 
HealthRecord  
>  !
Records" )
{* +
get, /
;/ 0
set1 4
;4 5
}6 7
=8 9
new: =
List> B
<B C
HealthRecordC O
>O P
(P Q
)Q R
;R S
}		 
}

 ¢
VC:\Users\310466\Desktop\Learning\HealthAxis\HealthApp\ConsoleApp\Databases\DoctorDb.cs
	namespace 	
	HealthApp
 
. 

ConsoleApp 
. 
	Databases (
{ 
public 

class 
DoctorDb 
{ 
public		 
List		 
<		 
Doctor		 
>		 
Doctors		 #
{		$ %
get		& )
;		) *
set		+ .
;		. /
}		0 1
=		2 3
new		4 7
List		8 <
<		< =
Doctor		= C
>		C D
(		D E
)		E F
;		F G
}

 
} Ê.
[C:\Users\310466\Desktop\Learning\HealthAxis\HealthApp\ConsoleApp\Databases\AppointmentDb.cs
	namespace 	
	HealthApp
 
. 

ConsoleApp 
. 
	Databases (
{ 
public 

class 
AppointmentDb 
{ 
public 
List 
< 
Appointment 
>  
Appointments! -
{. /
get0 3
;3 4
set5 8
;8 9
}: ;
=< =
new> A
ListB F
<F G
AppointmentG R
>R S
{ 	
new		 
Appointment		 
{

 
AppointmentId 
= 
$num  !
,! "
Patient 
= 
new 
Patient %
{ 
	PatientId 
= 
$num  #
,# $
FullName 
= 
$str )
,) *
Email 
= 
$str 0
,0 1
PhoneNumber 
=  !
$str" .
,. /
InsuranceId 
=  !
$str" 0
} 
, 
Doctor 
= 
new 
Doctor #
{ 
DoctorId 
= 
$num  
,  !
FullName 
= 
$str *
,* +
Specialisation "
=# $
$str% 1
} 
, 
ScheduledDate 
= 
DateTime  (
.( )
Now) ,
., -
AddDays- 4
(4 5
$num5 6
)6 7
,7 8
TimeSlot 
= 
$str %
,% &
Status 
= 
AppointmentStatus *
.* +
	Confirmed+ 4
} 
, 
new 
Appointment 
{   
AppointmentId!! 
=!! 
$num!!  !
,!!! "
Patient"" 
="" 
new"" 
Patient"" %
{## 
	PatientId$$ 
=$$ 
$num$$  !
,$$! "
FullName%% 
=%% 
$str%% )
,%%) *
Email&& 
=&& 
$str&& 0
,&&0 1
PhoneNumber'' 
=''  !
$str''" .
,''. /
InsuranceId(( 
=((  !
$str((" *
})) 
,)) 
Doctor** 
=** 
new** 
Doctor** #
{++ 
DoctorId,, 
=,, 
$num,,  
,,,  !
FullName-- 
=-- 
$str-- *
,--* +
Specialisation.. "
=..# $
$str..% 2
}// 
,// 
ScheduledDate00 
=00 
DateTime00  (
.00( )
Now00) ,
.00, -
AddDays00- 4
(004 5
$num005 6
)006 7
,007 8
TimeSlot11 
=11 
$str11 %
,11% &
Status22 
=22 
AppointmentStatus22 *
.22* +
Pending22+ 2
}33 
,33 
new55 
Appointment55 
{66 
AppointmentId77 
=77 
$num77  !
,77! "
Patient88 
=88 
new88 
Patient88 %
{99 
	PatientId:: 
=:: 
$num::  !
,::! "
FullName;; 
=;; 
$str;; ,
,;;, -
Email<< 
=<< 
$str<< 3
,<<3 4
PhoneNumber== 
===  !
$str==" .
,==. /
InsuranceId>> 
=>>  !
$str>>" *
}?? 
,?? 
Doctor@@ 
=@@ 
new@@ 
Doctor@@ #
{AA 
DoctorIdBB 
=BB 
$numBB  
,BB  !
FullNameCC 
=CC 
$strCC *
,CC* +
SpecialisationDD "
=DD# $
$strDD% 1
}EE 
,EE 
ScheduledDateFF 
=FF 
DateTimeFF  (
.FF( )
NowFF) ,
.FF, -
AddDaysFF- 4
(FF4 5
$numFF5 6
)FF6 7
,FF7 8
TimeSlotGG 
=GG 
$strGG %
,GG% &
StatusHH 
=HH 
AppointmentStatusHH *
.HH* +
	CancelledHH+ 4
,HH4 5
CancellationReasonII "
=II# $
$strII% E
}JJ 
,JJ 
newLL 
AppointmentLL 
{MM 
AppointmentIdNN 
=NN 
$numNN  !
,NN! "
PatientOO 
=OO 
newOO 
PatientOO %
{PP 
	PatientIdQQ 
=QQ 
$numQQ  !
,QQ! "
FullNameRR 
=RR 
$strRR ,
,RR, -
EmailSS 
=SS 
$strSS 3
,SS3 4
PhoneNumberTT 
=TT  !
$strTT" .
,TT. /
InsuranceIdUU 
=UU  !
$strUU" *
}VV 
,VV 
DoctorWW 
=WW 
newWW 
DoctorWW #
{XX 
DoctorIdYY 
=YY 
$numYY  
,YY  !
FullNameZZ 
=ZZ 
$strZZ *
,ZZ* +
Specialisation[[ "
=[[# $
$str[[% 2
}\\ 
,\\ 
ScheduledDate]] 
=]] 
DateTime]]  (
.]]( )
Now]]) ,
.]], -
AddDays]]- 4
(]]4 5
$num]]5 6
)]]6 7
,]]7 8
TimeSlot^^ 
=^^ 
$str^^ %
,^^% &
Status__ 
=__ 
AppointmentStatus__ *
.__* +
	Completed__+ 4
}`` 
}aa 	
;aa	 

}bb 
}cc 