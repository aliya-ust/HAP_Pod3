√l
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
$str22 <
)22< =
;22= >
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
$str44 ;
)44; <
;44< =
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
$str77 0
)770 1
;771 2
Console88 
.88 
	WriteLine88 
(88 
$str88 0
)880 1
;881 2
Console99 
.99 
	WriteLine99 
(99 
$str99 0
)990 1
;991 2
Console:: 
.:: 
	WriteLine:: 
(:: 
$str:: 
)::  
;::  !
Console;; 
.;; 
Write;; 
(;; 
$str;; '
);;' (
;;;( )
string<< 

?<< 
input<< 
=<< 
Console<< 
.<< 
ReadLine<< $
(<<$ %
)<<% &
;<<& '
if>> 
(>> 
!>> 	
int>>	 
.>> 
TryParse>> 
(>> 
input>> 
,>> 
out>>  
int>>! $
choice>>% +
)>>+ ,
)>>, -
{?? 
Console@@ 
.@@ 
	WriteLine@@ 
(@@ 
$str@@ R
)@@R S
;@@S T
continueAA 
;AA 
}BB 
ifDD 
(DD 
choiceDD 
<DD 
$numDD 
||DD 
choiceDD 
>DD 
$numDD !
)DD! "
{EE 
ConsoleFF 
.FF 
	WriteLineFF 
(FF 
$strFF P
)FFP Q
;FFQ R
continueGG 
;GG 
}HH 
switchJJ 

(JJ 
choiceJJ 
)JJ 
{KK 
caseLL 
$numLL 
:LL 
ConsoleMM 
.MM 
	WriteLineMM 
(MM 
$"MM  
$strMM  "
{MM" #
patientMenuMM# .
.MM. /
RegisterPatientMM/ >
(MM> ?
)MM? @
}MM@ A
"MMA B
)MMB C
;MMC D
ConsoleNN 
.NN 
WriteNN 
(NN 
ContinueMessageNN )
)NN) *
;NN* +
ConsoleOO 
.OO 
ReadKeyOO 
(OO 
)OO 
;OO 
breakPP 
;PP 
caseQQ 
$numQQ 
:QQ 
ConsoleRR 
.RR 
	WriteLineRR 
(RR 
$"RR  
$strRR  "
{RR" #

doctorMenuRR# -
.RR- .
	AddDoctorRR. 7
(RR7 8
)RR8 9
}RR9 :
"RR: ;
)RR; <
;RR< =
ConsoleSS 
.SS 
WriteSS 
(SS 
ContinueMessageSS )
)SS) *
;SS* +
ConsoleTT 
.TT 
ReadKeyTT 
(TT 
)TT 
;TT 
breakUU 
;UU 
caseVV 
$numVV 
:VV 
ListWW 
<WW 
DoctorWW 
>WW 
doctorsWW  
=WW! "

doctorMenuWW# -
.WW- .(
SearchDoctorBySpecialisationWW. J
(WWJ K
)WWK L
;WWL M
foreachXX 
(XX 
DoctorXX 
dXX 
inXX  
doctorsXX! (
)XX( )
{YY 
ConsoleZZ 
.ZZ 
	WriteLineZZ !
(ZZ! "
dZZ" #
)ZZ# $
;ZZ$ %
}[[ 
Console\\ 
.\\ 
Write\\ 
(\\ 
ContinueMessage\\ )
)\\) *
;\\* +
Console]] 
.]] 
ReadKey]] 
(]] 
)]] 
;]] 
break^^ 
;^^ 
case__ 
$num__ 
:__ 
Console`` 
.`` 
	WriteLine`` 
(`` 
$"``  
$str``  "
{``" #
appointmentMenu``# 2
.``2 3
BookAppointment``3 B
(``B C
)``C D
}``D E
"``E F
)``F G
;``G H
Consoleaa 
.aa 
Writeaa 
(aa 
ContinueMessageaa )
)aa) *
;aa* +
Consolebb 
.bb 
ReadKeybb 
(bb 
)bb 
;bb 
breakcc 
;cc 
casedd 
$numdd 
:dd 
appointmentMenuee 
.ee 
ViewAppointmentsee ,
(ee, -
)ee- .
;ee. /
Consoleff 
.ff 
Writeff 
(ff 
ContinueMessageff )
)ff) *
;ff* +
Consolegg 
.gg 
ReadKeygg 
(gg 
)gg 
;gg 
breakhh 
;hh 
caseii 
$numii 
:ii 
appointmentMenujj 
.jj $
ConfirmCancelAppointmentjj 4
(jj4 5
)jj5 6
;jj6 7
Consolekk 
.kk 
Writekk 
(kk 
ContinueMessagekk )
)kk) *
;kk* +
Consolell 
.ll 
ReadKeyll 
(ll 
)ll 
;ll 
breakmm 
;mm 
casenn 
$numnn 
:nn 
Consoleoo 
.oo 
	WriteLineoo 
(oo 
$"oo  
$stroo  "
{oo" #
healthRecordMenuoo# 3
.oo3 4
AddHealthRecordoo4 C
(ooC D
)ooD E
}ooE F
"ooF G
)ooG H
;ooH I
Consolepp 
.pp 
Writepp 
(pp 
ContinueMessagepp )
)pp) *
;pp* +
Consoleqq 
.qq 
ReadKeyqq 
(qq 
)qq 
;qq 
breakrr 
;rr 
casess 
$numss 
:ss 
healthRecordMenutt 
.tt 

ViewRecordtt '
(tt' (
)tt( )
;tt) *
breakuu 
;uu 
casevv 
$numvv 
:vv 
Consoleww 
.ww 
	WriteLineww 
(ww 
$"ww  
$strww  4
{ww4 5
patientMenuww5 @
.ww@ A
UpdatePatientwwA N
(wwN O
)wwO P
}wwP Q
"wwQ R
)wwR S
;wwS T
Consolexx 
.xx 
Writexx 
(xx 
ContinueMessagexx )
)xx) *
;xx* +
Consoleyy 
.yy 
ReadKeyyy 
(yy 
)yy 
;yy 
breakzz 
;zz 
case{{ 
$num{{ 
:{{ 
Console|| 
.|| 
	WriteLine|| 
(|| 
$"||  
$str||  3
{||3 4

doctorMenu||4 >
.||> ?
UpdateDoctor||? K
(||K L
)||L M
}||M N
"||N O
)||O P
;||P Q
Console}} 
.}} 
Write}} 
(}} 
ContinueMessage}} )
)}}) *
;}}* +
Console~~ 
.~~ 
ReadKey~~ 
(~~ 
)~~ 
;~~ 
break 
; 
case
ÄÄ 
$num
ÄÄ 
:
ÄÄ 
Console
ÅÅ 
.
ÅÅ 
	WriteLine
ÅÅ 
(
ÅÅ 
$"
ÅÅ  
$str
ÅÅ  :
{
ÅÅ: ;
healthRecordMenu
ÅÅ; K
.
ÅÅK L 
UpdateHealthRecord
ÅÅL ^
(
ÅÅ^ _
)
ÅÅ_ `
}
ÅÅ` a
"
ÅÅa b
)
ÅÅb c
;
ÅÅc d
Console
ÇÇ 
.
ÇÇ 
Write
ÇÇ 
(
ÇÇ 
ContinueMessage
ÇÇ )
)
ÇÇ) *
;
ÇÇ* +
Console
ÉÉ 
.
ÉÉ 
ReadKey
ÉÉ 
(
ÉÉ 
)
ÉÉ 
;
ÉÉ 
break
ÑÑ 
;
ÑÑ 
case
ÖÖ 
$num
ÖÖ 
:
ÖÖ 
exit
ÜÜ 
=
ÜÜ 
true
ÜÜ 
;
ÜÜ 
Console
áá 
.
áá 
	WriteLine
áá 
(
áá 
$str
áá 2
)
áá2 3
;
áá3 4
break
àà 
;
àà 
}
ââ 
}ää ñ
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
}DD Ù]
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
;66 
return88 
_appointmentRepo88 #
.88# $
AddAppointment88$ 2
(882 3
appointment883 >
)88> ?
;88? @
}99 	
public<< 
List<< 
<<< 
Appointment<< 
><<  &
GetAppointmentsByPatientId<<! ;
(<<; <
int<<< ?
	patientId<<@ I
)<<I J
{== 	
List>> 
<>> 
Appointment>> 
>>> 
appointments>> *
=>>+ ,
_appointmentRepo>>- =
.>>= >&
GetAppointmentsByPatientId>>> X
(>>X Y
	patientId>>Y b
)>>b c
;>>c d
if?? 
(?? 
appointments?? 
.?? 
Count?? "
==??# %
$num??& '
)??' (
{@@ 
throwAA 
newAA (
AppointmentNotFoundExceptionAA 6
(AA6 7
$"AA7 9
$strAA9 ^
{AA^ _
	patientIdAA_ h
}AAh i
$strAAi j
"AAj k
)AAk l
;AAl m
}BB 
returnDD 
appointmentsDD 
;DD  
}EE 	
publicHH 
ListHH 
<HH 
AppointmentHH 
>HH  %
GetAppointmentsByDoctorIdHH! :
(HH: ;
intHH; >
doctorIdHH? G
)HHG H
{II 	
varJJ 
appointmentsJJ 
=JJ 
_appointmentRepoJJ /
.JJ/ 0%
GetAppointmentsByDoctorIdJJ0 I
(JJI J
doctorIdJJJ R
)JJR S
;JJS T
ifKK 
(KK 
appointmentsKK 
.KK 
CountKK "
==KK# %
$numKK& '
)KK' (
{LL 
throwMM 
newMM (
AppointmentNotFoundExceptionMM 6
(MM6 7
$"MM7 9
$strMM9 ]
{MM] ^
doctorIdMM^ f
}MMf g
$strMMg h
"MMh i
)MMi j
;MMj k
}NN 
returnPP 
appointmentsPP 
;PP  
}QQ 	
publicTT 
AppointmentTT 
?TT 
GetAppointmentByIdTT .
(TT. /
intTT/ 2
appointmentIdTT3 @
)TT@ A
{UU 	
AppointmentVV 
?VV 
appointmentVV $
=VV% &
_appointmentRepoVV' 7
.VV7 8
GetAppointmentByIdVV8 J
(VVJ K
appointmentIdVVK X
)VVX Y
;VVY Z
ifXX 
(XX 
appointmentXX 
isXX 
nullXX #
)XX# $
{YY 
throwZZ 
newZZ (
AppointmentNotFoundExceptionZZ 6
(ZZ6 7
$"ZZ7 9
$strZZ9 K
{ZZK L
appointmentIdZZL Y
}ZZY Z
$strZZZ i
"ZZi j
)ZZj k
;ZZk l
}[[ 
return\\ 
appointment\\ 
;\\ 
}]] 	
public`` 
static`` 
int`` "
AppointmentIdGenerator`` 0
(``0 1
List``1 5
<``5 6
Appointment``6 A
>``A B
appointments``C O
)``O P
{aa 	
returnbb 
appointmentsbb 
.bb  
Anybb  #
(bb# $
)bb$ %
?cc 
appointmentscc 
.cc 
Maxcc "
(cc" #
acc# $
=>cc% '
acc( )
.cc) *
AppointmentIdcc* 7
)cc7 8
+cc9 :
$numcc; <
:dd 
$numdd 
;dd 
}ee 	
publichh 
stringhh 
CancelAppointmenthh '
(hh' (
inthh( +
appointmentIdhh, 9
,hh9 :
stringhh; A
reasonhhB H
)hhH I
{ii 	
varjj 
appointmentjj 
=jj 
_appointmentRepojj .
.jj. /
GetAppointmentByIdjj/ A
(jjA B
appointmentIdjjB O
)jjO P
;jjP Q
ifll 
(ll 
appointmentll 
isll 
nullll #
)ll# $
{mm 
thrownn 
newnn (
AppointmentNotFoundExceptionnn 6
(nn6 7
$"nn7 9
$strnn9 K
{nnK L
appointmentIdnnL Y
}nnY Z
$strnnZ i
"nni j
)nnj k
;nnk l
}oo 
appointmentpp 
.pp 
Cancelpp 
(pp 
reasonpp %
)pp% &
;pp& '
returnqq 
$"qq 
$strqq '
{qq' (
appointmentIdqq( 5
}qq5 6
$strqq6 V
"qqV W
;qqW X
}rr 	
publicuu 
stringuu 
ConfirmAppointmentuu (
(uu( )
intuu) ,
appointmentIduu- :
)uu: ;
{vv 	
varww 
appointmentww 
=ww 
_appointmentRepoww .
.ww. /
GetAppointmentByIdww/ A
(wwA B
appointmentIdwwB O
)wwO P
;wwP Q
ifyy 
(yy 
appointmentyy 
isyy 
nullyy #
)yy# $
{zz 
throw{{ 
new{{ (
AppointmentNotFoundException{{ 6
({{6 7
$"{{7 9
$str{{9 K
{{{K L
appointmentId{{L Y
}{{Y Z
$str{{Z i
"{{i j
){{j k
;{{k l
}|| 
appointment}} 
.}} 
Confirm}} 
(}}  
)}}  !
;}}! "
return~~ 
$"~~ 
$str~~ '
{~~' (
appointmentId~~( 5
}~~5 6
$str~~6 V
"~~V W
;~~W X
} 	
public
ÇÇ 
List
ÇÇ 
<
ÇÇ 
Appointment
ÇÇ 
>
ÇÇ  %
GetUpcomingAppointments
ÇÇ! 8
(
ÇÇ8 9
)
ÇÇ9 :
{
ÉÉ 	
List
ÑÑ 
<
ÑÑ 
Appointment
ÑÑ 
>
ÑÑ "
upcomingAppointments
ÑÑ 2
=
ÑÑ3 4
_appointmentRepo
ÑÑ6 F
.
ÖÖ  
GetAllAppointments
ÖÖ #
(
ÖÖ# $
)
ÖÖ$ %
.
ÜÜ 
Where
ÜÜ 
(
ÜÜ 
a
ÜÜ 
=>
ÜÜ 
a
ÜÜ 
.
ÜÜ 
ScheduledDate
ÜÜ +
>
ÜÜ, -
DateTime
ÜÜ. 6
.
ÜÜ6 7
Now
ÜÜ7 :
&&
ÜÜ; =
a
áá 
.
áá 
Status
áá $
==
áá% '
AppointmentStatus
áá( 9
.
áá9 :
	Confirmed
áá: C
)
ááC D
.
àà 
OrderBy
àà 
(
àà 
a
àà 
=>
àà 
a
àà 
.
àà  
ScheduledDate
àà  -
)
àà- .
.
ââ 
ToList
ââ 
(
ââ 
)
ââ 
;
ââ 
if
ãã 
(
ãã "
upcomingAppointments
ãã $
is
ãã% '
null
ãã( ,
)
ãã, -
{
åå 
throw
çç 
new
çç *
AppointmentNotFoundException
çç 6
(
çç6 7
$str
çç7 [
)
çç[ \
;
çç\ ]
}
éé 
return
èè "
upcomingAppointments
èè '
;
èè' (
}
êê 	
public
íí 
Appointment
íí 
UpdateAppointment
íí ,
(
íí, -
Appointment
íí- 8
appointment
íí9 D
)
ííD E
{
ìì 	
Appointment
îî 
?
îî !
existingAppointment
îî ,
=
îî- . 
GetAppointmentById
îî/ A
(
îîA B
appointment
îîB M
.
îîM N
AppointmentId
îîN [
)
îî[ \
;
îî\ ]
if
ññ 
(
ññ !
existingAppointment
ññ #
is
ññ$ &
null
ññ' +
)
ññ+ ,
{
óó 
throw
òò 
new
òò *
AppointmentNotFoundException
òò 6
(
òò6 7
$"
òò7 9
$str
òò9 K
{
òòK L
appointment
òòL W
.
òòW X
AppointmentId
òòX e
}
òòe f
$str
òòf u
"
òòu v
)
òòv w
;
òòw x
}
ôô 
return
öö 
_appointmentRepo
öö #
.
öö# $
UpdateAppointment
öö$ 5
(
öö5 6!
existingAppointment
öö6 I
,
ööI J
appointment
ööK V
)
ööV W
;
ööW X
}
õõ 	
}
úú 
}ùù ›
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
}?? Ö&
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
}44 	
public66 
string66 
DeleteDoctor66 "
(66" #
int66# &
id66' )
)66) *
{77 	
var88 
doctor88 
=88 
	_doctorDb88 "
.88" #
Doctors88# *
.88* +
FirstOrDefault88+ 9
(889 :
d88: ;
=>88< >
d88? @
.88@ A
DoctorId88A I
==88J L
id88M O
)88O P
;88P Q
if99 
(99 
doctor99 
==99 
null99 
)99 
throw:: 
new:: #
DoctorNotFoundException:: 1
(::1 2
$str::2 V
)::V W
;::W X
	_doctorDb<< 
.<< 
Doctors<< 
.<< 
Remove<< $
(<<$ %
doctor<<% +
)<<+ ,
;<<, -
return== 
$"== 
$str== "
{==" #
id==# %
}==% &
$str==& D
"==D E
;==E F
}>> 	
}?? 
}@@ ﬂ!
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
$str '
{' (
appointment( 3
.3 4
AppointmentId4 A
}A B
$strB `
"` a
;a b
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
}44 Ÿ
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
public 
int 
InsuranceId 
{  
get! $
;$ %
set& )
;) *
}+ ,
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
} ﬁ&
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
> 
AvailableSlots *
{+ ,
get- 0
;0 1
set2 5
;5 6
}7 8
=9 :
new; >
List? C
<C D
stringD J
>J K
(K L
)L M
;M N
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
public 
bool 
IsAvailable 
(  
DateTime  (
date) -
)- .
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
 ”-
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
}HH ÎM
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
;11+ ,
int33 
insuranceId33 
=33  !
int33" %
.33% &
Parse33& +
(33+ ,
insuranceInput33, :
!33: ;
)33; <
;33< =
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
ÖÖ 
int
ÖÖ 
.
ÖÖ 
Parse
ÖÖ #
(
ÖÖ# $
insuranceInput
ÖÖ$ 2
)
ÖÖ2 3
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
}ññ íÄ
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
(II &
OperationCanceledExceptionII -
)II- .
{JJ 
returnKK 
$strKK +
;KK+ ,
}LL 
catchMM 
(MM %
InvalidOperationExceptionMM ,
)MM, -
{NN 
returnOO 
$strOO ^
;OO^ _
}PP 
}QQ 	
publicSS 
voidSS 

ViewRecordSS 
(SS 
)SS  
{TT 	
ConsoleUU 
.UU 
ClearUU 
(UU 
)UU 
;UU 
ConsoleWW 
.WW 
	WriteLineWW 
(WW 
$strWW 0
)WW0 1
;WW1 2
ConsoleXX 
.XX 
	WriteLineXX 
(XX 
$strXX /
)XX/ 0
;XX0 1
ConsoleYY 
.YY 
	WriteLineYY 
(YY 
$strYY /
)YY/ 0
;YY0 1
ConsoleZZ 
.ZZ 
WriteZZ 
(ZZ 
$strZZ *
)ZZ* +
;ZZ+ ,
var\\ 
choice\\ 
=\\ 
Console\\  
.\\  !
ReadLine\\! )
(\\) *
)\\* +
;\\+ ,
switch^^ 
(^^ 
choice^^ 
)^^ 
{__ 
case`` 
$str`` 
:`` 
HandleViewByIdaa "
(aa" #
$straa# ,
,aa, - 
_healthRecordServiceaa. B
.aaB C.
"GetByPatientIdOrderByVisitDateDescaaC e
)aae f
;aaf g
breakbb 
;bb 
casedd 
$strdd 
:dd 
HandleViewByIdee "
(ee" #
$stree# +
,ee+ , 
_healthRecordServiceee- A
.eeA B-
!GetByDoctorIdOrderByVisitDateDesceeB c
)eec d
;eed e
breakff 
;ff 
casehh 
$strhh 
:hh "
HandleViewSingleRecordii *
(ii* +
)ii+ ,
;ii, -
breakjj 
;jj 
defaultll 
:ll 
Consolemm 
.mm 
	WriteLinemm %
(mm% &
$strmm& 7
)mm7 8
;mm8 9
Consolenn 
.nn 
ReadKeynn #
(nn# $
)nn$ %
;nn% &
breakoo 
;oo 
}pp 
}qq 	
privatess 
staticss 
voidss 
HandleViewByIdss *
(ss* +
stringtt 

entityNamett 
,tt 
Funcuu 
<uu 
intuu 
,uu 
Listuu 
<uu 
HealthRecorduu '
>uu' (
>uu( )
	fetchFuncuu* 3
)uu3 4
{vv 	
tryww 
{xx 
varyy 
idInputyy 
=yy 
InputValidatoryy ,
.yy, -
GetValidatedInputyy- >
(yy> ?
$"zz 
$strzz 
{zz 

entityNamezz '
}zz' (
$strzz( -
"zz- .
,zz. /
InputValidator{{ "
.{{" #
	IsValidId{{# ,
,{{, -
$"|| 
$str|| 
{|| 

entityName|| )
}||) *
$str||* .
"||. /
)||/ 0
;||0 1
int~~ 
id~~ 
=~~ 
int~~ 
.~~ 
Parse~~ "
(~~" #
idInput~~# *
!~~* +
)~~+ ,
;~~, -
var
ÄÄ 
records
ÄÄ 
=
ÄÄ 
	fetchFunc
ÄÄ '
(
ÄÄ' (
id
ÄÄ( *
)
ÄÄ* +
;
ÄÄ+ ,
Console
ÇÇ 
.
ÇÇ 
Clear
ÇÇ 
(
ÇÇ 
)
ÇÇ 
;
ÇÇ  
Console
ÉÉ 
.
ÉÉ 
	WriteLine
ÉÉ !
(
ÉÉ! "
$str
ÉÉ" 3
)
ÉÉ3 4
;
ÉÉ4 5
foreach
ÖÖ 
(
ÖÖ 
var
ÖÖ 
r
ÖÖ 
in
ÖÖ !
records
ÖÖ" )
)
ÖÖ) *
Console
ÜÜ 
.
ÜÜ 
	WriteLine
ÜÜ %
(
ÜÜ% &
r
ÜÜ& '
)
ÜÜ' (
;
ÜÜ( )
}
áá 
catch
àà 
(
àà 
	Exception
àà 
ex
àà 
)
àà  
{
ââ 
Console
ää 
.
ää 
	WriteLine
ää !
(
ää! "
ex
ää" $
.
ää$ %
Message
ää% ,
)
ää, -
;
ää- .
}
ãã 
}
åå 	
private
éé 
void
éé $
HandleViewSingleRecord
éé +
(
éé+ ,
)
éé, -
{
èè 	
try
êê 
{
ëë 
var
íí 
idInput
íí 
=
íí 
InputValidator
íí ,
.
íí, -
GetValidatedInput
íí- >
(
íí> ?
$str
ìì '
,
ìì' (
InputValidator
îî "
.
îî" #
	IsValidId
îî# ,
,
îî, -
$str
ïï (
)
ïï( )
;
ïï) *
int
óó 
recordId
óó 
=
óó 
int
óó "
.
óó" #
Parse
óó# (
(
óó( )
idInput
óó) 0
!
óó0 1
)
óó1 2
;
óó2 3
var
ôô 
record
ôô 
=
ôô "
_healthRecordService
ôô 1
.
ôô1 2
GetRecordById
ôô2 ?
(
ôô? @
recordId
ôô@ H
)
ôôH I
;
ôôI J
Console
õõ 
.
õõ 
Clear
õõ 
(
õõ 
)
õõ 
;
õõ  
Console
úú 
.
úú 
	WriteLine
úú !
(
úú! "
record
úú" (
)
úú( )
;
úú) *
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
††- .
}
°° 
}
¢¢ 	
public
§§ 
string
§§  
UpdateHealthRecord
§§ (
(
§§( )
)
§§) *
{
•• 	
try
¶¶ 
{
ßß 
Console
®® 
.
®® 
Write
®® 
(
®® 
$str
®® B
)
®®B C
;
®®C D
var
©© 
input
©© 
=
©© 
Console
©© #
.
©©# $
ReadLine
©©$ ,
(
©©, -
)
©©- .
;
©©. /
if
´´ 
(
´´ 
input
´´ 
?
´´ 
.
´´ 
ToLower
´´ "
(
´´" #
)
´´# $
==
´´% '
$str
´´( +
)
´´+ ,
return
¨¨ 
HandleCancel
¨¨ '
(
¨¨' (
)
¨¨( )
;
¨¨) *
if
ÆÆ 
(
ÆÆ 
!
ÆÆ 
int
ÆÆ 
.
ÆÆ 
TryParse
ÆÆ !
(
ÆÆ! "
input
ÆÆ" '
,
ÆÆ' (
out
ÆÆ) ,
int
ÆÆ- 0
recordId
ÆÆ1 9
)
ÆÆ9 :
||
ÆÆ; =
recordId
ÆÆ> F
<=
ÆÆG I
$num
ÆÆJ K
)
ÆÆK L
return
ØØ 
$str
ØØ .
;
ØØ. /
var
±± 
existing
±± 
=
±± "
_healthRecordService
±± 3
.
±±3 4
GetRecordById
±±4 A
(
±±A B
recordId
±±B J
)
±±J K
;
±±K L
if
≤≤ 
(
≤≤ 
existing
≤≤ 
==
≤≤ 
null
≤≤  $
)
≤≤$ %
return
≥≥ 
$str
≥≥ -
;
≥≥- .
Console
µµ 
.
µµ 
	WriteLine
µµ !
(
µµ! "
$str
µµ" 5
)
µµ5 6
;
µµ6 7
Console
∂∂ 
.
∂∂ 
	WriteLine
∂∂ !
(
∂∂! "
existing
∂∂" *
)
∂∂* +
;
∂∂+ ,
var
∏∏ 
	dateInput
∏∏ 
=
∏∏ 
InputValidator
∏∏  .
.
∏∏. /
GetOptionalDate
∏∏/ >
(
∏∏> ?
$str
ππ 5
)
ππ5 6
;
ππ6 7
var
ªª 
diagnosisInput
ªª "
=
ªª# $
InputValidator
ªª% 3
.
ªª3 4
GetValidatedInput
ªª4 E
(
ªªE F
$str
ºº =
,
ºº= >
InputValidator
ΩΩ "
.
ΩΩ" #

IsNonEmpty
ΩΩ# -
,
ΩΩ- .
$str
ææ (
,
ææ( )

allowEmpty
øø 
:
øø 
true
øø  $
)
øø$ %
;
øø% &
var
¡¡ 
prescriptionInput
¡¡ %
=
¡¡& '
InputValidator
¡¡( 6
.
¡¡6 7
GetValidatedInput
¡¡7 H
(
¡¡H I
$str
¬¬ @
,
¬¬@ A
InputValidator
√√ "
.
√√" #

IsNonEmpty
√√# -
,
√√- .
$str
ƒƒ +
,
ƒƒ+ ,

allowEmpty
≈≈ 
:
≈≈ 
true
≈≈  $
)
≈≈$ %
;
≈≈% &
var
«« 

notesInput
«« 
=
««  
InputValidator
««! /
.
««/ 0
GetValidatedInput
««0 A
(
««A B
$str
»» @
,
»»@ A
InputValidator
…… "
.
……" #

IsNonEmpty
……# -
,
……- .
$str
   $
,
  $ %

allowEmpty
ÀÀ 
:
ÀÀ 
true
ÀÀ  $
)
ÀÀ$ %
;
ÀÀ% &
var
ÕÕ 
updated
ÕÕ 
=
ÕÕ 
new
ÕÕ !
HealthRecord
ÕÕ" .
{
ŒŒ 
RecordId
œœ 
=
œœ 
existing
œœ '
.
œœ' (
RecordId
œœ( 0
,
œœ0 1
Patient
–– 
=
–– 
existing
–– &
.
––& '
Patient
––' .
,
––. /
Doctor
—— 
=
—— 
existing
—— %
.
——% &
Doctor
——& ,
,
——, -
	VisitDate
““ 
=
““ 
	dateInput
““  )
??
““* ,
existing
““- 5
.
““5 6
	VisitDate
““6 ?
,
““? @
	Diagnosis
”” 
=
”” 
diagnosisInput
””  .
??
””/ 1
existing
””2 :
.
””: ;
	Diagnosis
””; D
,
””D E
Prescription
‘‘  
=
‘‘! "
prescriptionInput
‘‘# 4
??
‘‘5 7
existing
‘‘8 @
.
‘‘@ A
Prescription
‘‘A M
,
‘‘M N
DoctorNotes
’’ 
=
’’  !

notesInput
’’" ,
??
’’- /
existing
’’0 8
.
’’8 9
DoctorNotes
’’9 D
}
÷÷ 
;
÷÷ 
Console
ÿÿ 
.
ÿÿ 
Clear
ÿÿ 
(
ÿÿ 
)
ÿÿ 
;
ÿÿ  
return
ŸŸ "
_healthRecordService
ŸŸ +
.
ŸŸ+ , 
UpdateHealthRecord
ŸŸ, >
(
ŸŸ> ?
updated
ŸŸ? F
)
ŸŸF G
.
ŸŸG H
ToString
ŸŸH P
(
ŸŸP Q
)
ŸŸQ R
;
ŸŸR S
}
⁄⁄ 
catch
€€ 
(
€€ (
OperationCanceledException
€€ -
)
€€- .
{
‹‹ 
return
›› 
HandleCancel
›› #
(
››# $
)
››$ %
;
››% &
}
ﬁﬁ 
catch
ﬂﬂ 
(
ﬂﬂ +
HealthRecordNotFoundException
ﬂﬂ 0
ex
ﬂﬂ1 3
)
ﬂﬂ3 4
{
‡‡ 
return
·· 
ex
·· 
.
·· 
Message
·· !
;
··! "
}
‚‚ 
}
„„ 	
private
ÊÊ 
static
ÊÊ 
string
ÊÊ 
HandleCancel
ÊÊ *
(
ÊÊ* +
)
ÊÊ+ ,
{
ÁÁ 	
Console
ËË 
.
ËË 
	WriteLine
ËË 
(
ËË #
HealthRecordCancelled
ËË 3
)
ËË3 4
;
ËË4 5
Console
ÈÈ 
.
ÈÈ 
	WriteLine
ÈÈ 
(
ÈÈ 
Continue
ÈÈ &
)
ÈÈ& '
;
ÈÈ' (
Console
ÍÍ 
.
ÍÍ 
ReadKey
ÍÍ 
(
ÍÍ 
)
ÍÍ 
;
ÍÍ 
return
ÎÎ 
$str
ÎÎ 
;
ÎÎ 
}
ÏÏ 	
}
ÌÌ 
}ÓÓ ØU
TC:\Users\310466\Desktop\Learning\HealthAxis\HealthApp\ConsoleApp\Menus\DoctorMenu.cs
	namespace 	
	HealthApp
 
{ 
public 

class 

DoctorMenu 
{ 
private 
readonly 
IDoctorService '
_doctorService( 6
;6 7
public 
const 
string 
Continue $
=% &
$str' G
;G H
public 

DoctorMenu 
( 
IDoctorService (
doctorService) 6
)6 7
{ 	
_doctorService 
= 
doctorService *
;* +
} 	
public 
string 
	AddDoctor 
(  
)  !
{ 	
try 
{ 
Console 
. 
Clear 
( 
) 
;  
var 
fullName 
= 
InputValidator -
.- .
GetValidatedInput. ?
(? @
$str 8
,8 9
InputValidator   "
.  " #
IsValidName  # .
,  . /
$str!! 9
)!!9 :
;!!: ;
var## 
specialisation## "
=### $
InputValidator##% 3
.##3 4
GetValidatedInput##4 E
(##E F
$str$$ =
,$$= >
InputValidator%% "
.%%" #
IsValidName%%# .
,%%. /
$str&& >
)&&> ?
;&&? @
var(( 
experienceInput(( #
=(($ %
InputValidator((& 4
.((4 5
GetValidatedInput((5 F
(((F G
$str)) 1
,))1 2
InputValidator** "
.**" #
IsValidExperience**# 4
,**4 5
$str++ )
)++) *
;++* +
var-- 
feeInput-- 
=-- 
InputValidator-- -
.--- .
GetValidatedInput--. ?
(--? @
$str.. .
,... /
InputValidator// "
.//" #

IsValidFee//# -
,//- .
$str00 /
)00/ 0
;000 1
var22 
doctor22 
=22 
new22  
Doctor22! '
{33 
FullName44 
=44 
fullName44 '
!44' (
,44( )
Specialisation55 "
=55# $
specialisation55% 3
!553 4
,554 5
YearsOfExperience66 %
=66& '
int66( +
.66+ ,
Parse66, 1
(661 2
experienceInput662 A
!66A B
)66B C
,66C D
ConsultationFee77 #
=77$ %
decimal77& -
.77- .
Parse77. 3
(773 4
feeInput774 <
!77< =
)77= >
,77> ?
IsActive88 
=88 
true88 #
}99 
;99 
return;; 
_doctorService;; %
.;;% &
	AddDoctor;;& /
(;;/ 0
doctor;;0 6
);;6 7
;;;7 8
}<< 
catch== 
(== &
OperationCanceledException== -
)==- .
{>> 
return?? 
$str?? +
;??+ ,
}@@ 
}AA 	
publicDD 
ListDD 
<DD 
DoctorDD 
>DD (
SearchDoctorBySpecialisationDD 8
(DD8 9
)DD9 :
{EE 	
tryFF 
{GG 
ConsoleHH 
.HH 
ClearHH 
(HH 
)HH 
;HH  
varJJ 
specialisationJJ "
=JJ# $
InputValidatorJJ% 3
.JJ3 4
GetValidatedInputJJ4 E
(JJE F
$strKK G
,KKG H
InputValidatorLL "
.LL" #
IsValidNameLL# .
,LL. /
$strMM -
)MM- .
;MM. /
returnOO 
_doctorServiceOO %
.OO% &&
GetDoctorsBySpecialisationOO& @
(OO@ A
specialisationOOA O
!OOO P
)OOP Q
;OOQ R
}PP 
catchQQ 
(QQ &
OperationCanceledExceptionQQ -
)QQ- .
{RR 
ConsoleSS 
.SS 
	WriteLineSS !
(SS! "
$strSS" 5
)SS5 6
;SS6 7
ConsoleTT 
.TT 
WriteTT 
(TT 
ContinueTT &
)TT& '
;TT' (
ConsoleUU 
.UU 
ReadKeyUU 
(UU  
)UU  !
;UU! "
returnVV 
[VV 
]VV 
;VV 
}WW 
catchXX 
(XX +
SpecialisationNotFoundExceptionXX 2
exXX3 5
)XX5 6
{YY 
ConsoleZZ 
.ZZ 
	WriteLineZZ !
(ZZ! "
exZZ" $
.ZZ$ %
MessageZZ% ,
)ZZ, -
;ZZ- .
Console[[ 
.[[ 
Write[[ 
([[ 
Continue[[ &
)[[& '
;[[' (
Console\\ 
.\\ 
ReadKey\\ 
(\\  
)\\  !
;\\! "
return]] 
[]] 
]]] 
;]] 
}^^ 
}__ 	
publicaa 
stringaa 
UpdateDoctoraa "
(aa" #
)aa# $
{bb 	
trycc 
{dd 
Consoleee 
.ee 
Clearee 
(ee 
)ee 
;ee  
Consolegg 
.gg 
Writegg 
(gg 
$strgg B
)ggB C
;ggC D
varhh 
inputhh 
=hh 
Consolehh #
.hh# $
ReadLinehh$ ,
(hh, -
)hh- .
;hh. /
ifjj 
(jj 
inputjj 
?jj 
.jj 
ToLowerjj "
(jj" #
)jj# $
==jj% '
$strjj( +
)jj+ ,
returnkk 
$strkk .
;kk. /
ifmm 
(mm 
!mm 
intmm 
.mm 
TryParsemm !
(mm! "
inputmm" '
,mm' (
outmm) ,
intmm- 0
doctorIdmm1 9
)mm9 :
||mm; =
doctorIdmm> F
<=mmG I
$nummmJ K
)mmK L
returnnn 
$strnn .
;nn. /
varpp 
existingDoctorpp "
=pp# $
_doctorServicepp% 3
.pp3 4
GetDoctorByIdpp4 A
(ppA B
doctorIdppB J
)ppJ K
;ppK L
ifqq 
(qq 
existingDoctorqq "
==qq# %
nullqq& *
)qq* +
returnrr 
$strrr -
;rr- .
Consolett 
.tt 
	WriteLinett !
(tt! "
$strtt" =
)tt= >
;tt> ?
Consoleuu 
.uu 
	WriteLineuu !
(uu! "
existingDoctoruu" 0
)uu0 1
;uu1 2
varww 
fullNameInputww !
=ww" #
InputValidatorww$ 2
.ww2 3
GetValidatedInputww3 D
(wwD E
$strxx F
,xxF G
InputValidatoryy "
.yy" #
IsValidNameyy# .
,yy. /
$strzz #
,zz# $

allowEmpty{{ 
:{{ 
true{{  $
){{$ %
;{{% &
var}} 
	specInput}} 
=}} 
InputValidator}}  .
.}}. /
GetValidatedInput}}/ @
(}}@ A
$str~~ K
,~~K L
InputValidator "
." #
IsValidName# .
,. /
$str
ÄÄ -
,
ÄÄ- .

allowEmpty
ÅÅ 
:
ÅÅ 
true
ÅÅ  $
)
ÅÅ$ %
;
ÅÅ% &
var
ÉÉ 
expInput
ÉÉ 
=
ÉÉ 
InputValidator
ÉÉ -
.
ÉÉ- .
GetValidatedInput
ÉÉ. ?
(
ÉÉ? @
$str
ÑÑ G
,
ÑÑG H
InputValidator
ÖÖ "
.
ÖÖ" #
IsValidExperience
ÖÖ# 4
,
ÖÖ4 5
$str
ÜÜ )
,
ÜÜ) *

allowEmpty
áá 
:
áá 
true
áá  $
)
áá$ %
;
áá% &
var
ââ 
feeInput
ââ 
=
ââ 
InputValidator
ââ -
.
ââ- .
GetValidatedInput
ââ. ?
(
ââ? @
$str
ää @
,
ää@ A
InputValidator
ãã "
.
ãã" #

IsValidFee
ãã# -
,
ãã- .
$str
åå "
,
åå" #

allowEmpty
çç 
:
çç 
true
çç  $
)
çç$ %
;
çç% &
var
èè 
updatedDoctor
èè !
=
èè" #
new
èè$ '
Doctor
èè( .
{
êê 
DoctorId
ëë 
=
ëë 
existingDoctor
ëë -
.
ëë- .
DoctorId
ëë. 6
,
ëë6 7
FullName
íí 
=
íí 
fullNameInput
íí ,
??
íí- /
existingDoctor
íí0 >
.
íí> ?
FullName
íí? G
,
ííG H
Specialisation
ìì "
=
ìì# $
	specInput
ìì% .
??
ìì/ 1
existingDoctor
ìì2 @
.
ìì@ A
Specialisation
ììA O
,
ììO P
YearsOfExperience
îî %
=
îî& '
expInput
îî( 0
!=
îî1 3
null
îî4 8
?
îî9 :
int
îî; >
.
îî> ?
Parse
îî? D
(
îîD E
expInput
îîE M
)
îîM N
:
îîO P
existingDoctor
îîQ _
.
îî_ `
YearsOfExperience
îî` q
,
îîq r
ConsultationFee
ïï #
=
ïï$ %
feeInput
ïï& .
!=
ïï/ 1
null
ïï2 6
?
ïï7 8
decimal
ïï9 @
.
ïï@ A
Parse
ïïA F
(
ïïF G
feeInput
ïïG O
)
ïïO P
:
ïïQ R
existingDoctor
ïïS a
.
ïïa b
ConsultationFee
ïïb q
,
ïïq r
IsActive
ññ 
=
ññ 
existingDoctor
ññ -
.
ññ- .
IsActive
ññ. 6
}
óó 
;
óó 
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
ôô  
return
öö 
_doctorService
öö %
.
öö% &
UpdateDoctor
öö& 2
(
öö2 3
updatedDoctor
öö3 @
)
öö@ A
.
ööA B
ToString
ööB J
(
ööJ K
)
ööK L
;
ööL M
}
õõ 
catch
úú 
(
úú (
OperationCanceledException
úú -
)
úú- .
{
ùù 
return
ûû 
$str
ûû *
;
ûû* +
}
üü 
catch
†† 
(
†† %
DoctorNotFoundException
†† *
ex
††+ -
)
††- .
{
°° 
return
¢¢ 
ex
¢¢ 
.
¢¢ 
Message
¢¢ !
;
¢¢! "
}
££ 
}
§§ 	
}
•• 
}¶¶ ÌÖ
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
;337 8
Console44 
.44 
	WriteLine44 !
(44! "
$str44" L
)44L M
;44M N
Console55 
.55 
	WriteLine55 !
(55! "
$str55" L
)55L M
;55M N
var77 
slotChoiceInput77 #
=77$ %
InputValidator77& 4
.774 5
GetValidatedInput775 F
(77F G
$str88 )
,88) *
input99 
=>99 
int99  
.99  !
TryParse99! )
(99) *
input99* /
,99/ 0
out991 4
int995 8
s999 :
)99: ;
&&99< >
s99? @
>=99A C
$num99D E
&&99F H
s99I J
<=99K M
$num99N O
,99O P
$str:: #
)::# $
;::$ %
int<< 

slotChoice<< 
=<<  
int<<! $
.<<$ %
Parse<<% *
(<<* +
slotChoiceInput<<+ :
!<<: ;
)<<; <
;<<< =
string>> 
[>> 
]>> 
slots>> 
=>>  
{?? 
$str@@ 
,@@ 
$str@@  *
,@@* +
$str@@, 6
,@@6 7
$strAA 
,AA 
$strAA  *
,AA* +
$strAA, 6
}BB 
;BB 
stringDD 
slotDD 
=DD 
slotsDD #
[DD# $

slotChoiceDD$ .
-DD/ 0
$numDD1 2
]DD2 3
;DD3 4
returnFF 
_appointmentServiceFF *
.FF* +
BookAppointmentFF+ :
(FF: ;
patientFF; B
,FFB C
doctorFFD J
,FFJ K
dateFFL P
,FFP Q
slotFFR V
)FFV W
;FFW X
}GG 
catchHH 
(HH &
OperationCanceledExceptionHH -
)HH- .
{II 
returnJJ 
HandleCancelJJ #
(JJ# $
$strJJ$ 8
)JJ8 9
;JJ9 :
}KK 
catchLL 
(LL 
	ExceptionLL 
exLL 
)LL  
{MM 
returnNN 
exNN 
.NN 
MessageNN !
;NN! "
}OO 
}PP 	
publicRR 
ListRR 
<RR 
AppointmentRR 
>RR  
ViewAppointmentsRR! 1
(RR1 2
)RR2 3
{SS 	
ConsoleTT 
.TT 
ClearTT 
(TT 
)TT 
;TT 
ConsoleVV 
.VV 
	WriteLineVV 
(VV 
$strVV 0
)VV0 1
;VV1 2
ConsoleWW 
.WW 
	WriteLineWW 
(WW 
$strWW /
)WW/ 0
;WW0 1
ConsoleXX 
.XX 
	WriteLineXX 
(XX 
$strXX 4
)XX4 5
;XX5 6
ConsoleYY 
.YY 
	WriteLineYY 
(YY 
$strYY '
)YY' (
;YY( )
ConsoleZZ 
.ZZ 
WriteZZ 
(ZZ 
$strZZ *
)ZZ* +
;ZZ+ ,
var\\ 
choice\\ 
=\\ 
Console\\  
.\\  !
ReadLine\\! )
(\\) *
)\\* +
;\\+ ,
switch^^ 
(^^ 
choice^^ 
)^^ 
{__ 
case`` 
$str`` 
:`` 
ViewByIdaa 
(aa 
$straa &
,aa& '
_appointmentServiceaa( ;
.aa; <&
GetAppointmentsByPatientIdaa< V
)aaV W
;aaW X
breakbb 
;bb 
casedd 
$strdd 
:dd 
ViewByIdee 
(ee 
$stree %
,ee% &
_appointmentServiceee' :
.ee: ;%
GetAppointmentsByDoctorIdee; T
)eeT U
;eeU V
breakff 
;ff 
casehh 
$strhh 
:hh !
ViewSingleAppointmentii )
(ii) *
)ii* +
;ii+ ,
breakjj 
;jj 
defaultll 
:ll 
returnmm 
[mm 
]mm 
;mm 
}nn 
returnpp 
[pp 
]pp 
;pp 
}qq 	
privatess 
staticss 
voidss 
ViewByIdss $
(ss$ %
stringss% +
entityss, 2
,ss2 3
Funcss4 8
<ss8 9
intss9 <
,ss< =
Listss> B
<ssB C
AppointmentssC N
>ssN O
>ssO P
	fetchFuncssQ Z
)ssZ [
{tt 	
tryuu 
{vv 
varww 
idInputww 
=ww 
InputValidatorww ,
.ww, -
GetValidatedInputww- >
(ww> ?
$"xx 
$strxx 
{xx 
entityxx #
}xx# $
$strxx$ )
"xx) *
,xx* +
InputValidatoryy "
.yy" #
	IsValidIdyy# ,
,yy, -
$"zz 
$strzz 
{zz 
entityzz %
}zz% &
$strzz& *
"zz* +
)zz+ ,
;zz, -
int|| 
id|| 
=|| 
int|| 
.|| 
Parse|| "
(||" #
idInput||# *
!||* +
)||+ ,
;||, -
var~~ 
appointments~~  
=~~! "
	fetchFunc~~# ,
(~~, -
id~~- /
)~~/ 0
;~~0 1
Console
ÄÄ 
.
ÄÄ 
Clear
ÄÄ 
(
ÄÄ 
)
ÄÄ 
;
ÄÄ  
Console
ÅÅ 
.
ÅÅ 
	WriteLine
ÅÅ !
(
ÅÅ! "
$str
ÅÅ" <
)
ÅÅ< =
;
ÅÅ= >
foreach
ÉÉ 
(
ÉÉ 
var
ÉÉ 
a
ÉÉ 
in
ÉÉ !
appointments
ÉÉ" .
)
ÉÉ. /
Console
ÑÑ 
.
ÑÑ 
	WriteLine
ÑÑ %
(
ÑÑ% &
a
ÑÑ& '
.
ÑÑ' (

GetDetails
ÑÑ( 2
(
ÑÑ2 3
)
ÑÑ3 4
)
ÑÑ4 5
;
ÑÑ5 6
Pause
ÜÜ 
(
ÜÜ 
)
ÜÜ 
;
ÜÜ 
}
áá 
catch
àà 
(
àà 
	Exception
àà 
ex
àà 
)
àà  
{
ââ 
Console
ää 
.
ää 
	WriteLine
ää !
(
ää! "
ex
ää" $
.
ää$ %
Message
ää% ,
)
ää, -
;
ää- .
Pause
ãã 
(
ãã 
)
ãã 
;
ãã 
}
åå 
}
çç 	
private
èè 
void
èè #
ViewSingleAppointment
èè *
(
èè* +
)
èè+ ,
{
êê 	
try
ëë 
{
íí 
var
ìì 
idInput
ìì 
=
ìì 
InputValidator
ìì ,
.
ìì, -
GetValidatedInput
ìì- >
(
ìì> ?
$str
îî ,
,
îî, -
InputValidator
ïï "
.
ïï" #
	IsValidId
ïï# ,
,
ïï, -
$str
ññ -
)
ññ- .
;
ññ. /
int
òò 
id
òò 
=
òò 
int
òò 
.
òò 
Parse
òò "
(
òò" #
idInput
òò# *
!
òò* +
)
òò+ ,
;
òò, -
var
öö 
appointment
öö 
=
öö  !!
_appointmentService
öö" 5
.
öö5 6 
GetAppointmentById
öö6 H
(
ööH I
id
ööI K
)
ööK L
;
ööL M
Console
úú 
.
úú 
Clear
úú 
(
úú 
)
úú 
;
úú  
Console
ùù 
.
ùù 
	WriteLine
ùù !
(
ùù! "
appointment
ùù" -
?
ùù- .
.
ùù. /

GetDetails
ùù/ 9
(
ùù9 :
)
ùù: ;
)
ùù; <
;
ùù< =
Pause
üü 
(
üü 
)
üü 
;
üü 
}
†† 
catch
°° 
(
°° 
	Exception
°° 
ex
°° 
)
°°  
{
¢¢ 
Console
££ 
.
££ 
	WriteLine
££ !
(
££! "
ex
££" $
.
££$ %
Message
££% ,
)
££, -
;
££- .
Pause
§§ 
(
§§ 
)
§§ 
;
§§ 
}
•• 
}
¶¶ 	
public
®® 
string
®® &
ConfirmCancelAppointment
®® .
(
®®. /
)
®®/ 0
{
©© 	
Console
™™ 
.
™™ 
Clear
™™ 
(
™™ 
)
™™ 
;
™™ 
Console
¨¨ 
.
¨¨ 
	WriteLine
¨¨ 
(
¨¨ 
$str
¨¨ 6
)
¨¨6 7
;
¨¨7 8
Console
≠≠ 
.
≠≠ 
	WriteLine
≠≠ 
(
≠≠ 
$str
≠≠ 5
)
≠≠5 6
;
≠≠6 7
Console
ÆÆ 
.
ÆÆ 
	WriteLine
ÆÆ 
(
ÆÆ 
$str
ÆÆ '
)
ÆÆ' (
;
ÆÆ( )
Console
ØØ 
.
ØØ 
Write
ØØ 
(
ØØ 
$str
ØØ *
)
ØØ* +
;
ØØ+ ,
var
±± 
choice
±± 
=
±± 
Console
±±  
.
±±  !
ReadLine
±±! )
(
±±) *
)
±±* +
;
±±+ ,
return
≥≥ 
choice
≥≥ 
switch
≥≥  
{
¥¥ 
$str
µµ 
=>
µµ  
ConfirmAppointment
µµ )
(
µµ) *
)
µµ* +
,
µµ+ ,
$str
∂∂ 
=>
∂∂ 
CancelAppointment
∂∂ (
(
∂∂( )
)
∂∂) *
,
∂∂* +
_
∑∑ 
=>
∑∑ 
$str
∑∑ &
}
∏∏ 
;
∏∏ 
}
ππ 	
private
ªª 
string
ªª  
ConfirmAppointment
ªª )
(
ªª) *
)
ªª* +
{
ºº 	
try
ΩΩ 
{
ææ 
var
øø 
input
øø 
=
øø 
InputValidator
øø *
.
øø* +
GetValidatedInput
øø+ <
(
øø< =
$str
¿¿ ,
,
¿¿, -
InputValidator
¡¡ "
.
¡¡" #
	IsValidId
¡¡# ,
,
¡¡, -
$str
¬¬ -
)
¬¬- .
;
¬¬. /
int
ƒƒ 
id
ƒƒ 
=
ƒƒ 
int
ƒƒ 
.
ƒƒ 
Parse
ƒƒ "
(
ƒƒ" #
input
ƒƒ# (
!
ƒƒ( )
)
ƒƒ) *
;
ƒƒ* +
var
∆∆ 
appointment
∆∆ 
=
∆∆  !!
_appointmentService
∆∆" 5
.
∆∆5 6 
GetAppointmentById
∆∆6 H
(
∆∆H I
id
∆∆I K
)
∆∆K L
;
∆∆L M
if
«« 
(
«« 
appointment
«« 
==
««  "
null
««# '
)
««' (
return
»» 
$str
»» 3
;
»»3 4
appointment
   
.
   
Confirm
   #
(
  # $
)
  $ %
;
  % &
return
ÃÃ 
$str
ÃÃ <
;
ÃÃ< =
}
ÕÕ 
catch
ŒŒ 
(
ŒŒ 
	Exception
ŒŒ 
ex
ŒŒ 
)
ŒŒ  
{
œœ 
return
–– 
ex
–– 
.
–– 
Message
–– !
;
––! "
}
—— 
}
““ 	
private
‘‘ 
string
‘‘ 
CancelAppointment
‘‘ (
(
‘‘( )
)
‘‘) *
{
’’ 	
try
÷÷ 
{
◊◊ 
var
ÿÿ 
idInput
ÿÿ 
=
ÿÿ 
InputValidator
ÿÿ ,
.
ÿÿ, -
GetValidatedInput
ÿÿ- >
(
ÿÿ> ?
$str
ŸŸ ,
,
ŸŸ, -
InputValidator
⁄⁄ "
.
⁄⁄" #
	IsValidId
⁄⁄# ,
,
⁄⁄, -
$str
€€ -
)
€€- .
;
€€. /
int
›› 
id
›› 
=
›› 
int
›› 
.
›› 
Parse
›› "
(
››" #
idInput
››# *
!
››* +
)
››+ ,
;
››, -
var
ﬂﬂ 
reason
ﬂﬂ 
=
ﬂﬂ 
InputValidator
ﬂﬂ +
.
ﬂﬂ+ ,
GetValidatedInput
ﬂﬂ, =
(
ﬂﬂ= >
$str
‡‡ 1
,
‡‡1 2
InputValidator
·· "
.
··" #

IsNonEmpty
··# -
,
··- .
$str
‚‚ -
)
‚‚- .
;
‚‚. /
return
‰‰ !
_appointmentService
‰‰ *
.
‰‰* +
CancelAppointment
‰‰+ <
(
‰‰< =
id
‰‰= ?
,
‰‰? @
reason
‰‰A G
!
‰‰G H
)
‰‰H I
;
‰‰I J
}
ÂÂ 
catch
ÊÊ 
(
ÊÊ 
	Exception
ÊÊ 
ex
ÊÊ 
)
ÊÊ  
{
ÁÁ 
return
ËË 
ex
ËË 
.
ËË 
Message
ËË !
;
ËË! "
}
ÈÈ 
}
ÍÍ 	
private
ÏÏ 
static
ÏÏ 
string
ÏÏ 
HandleCancel
ÏÏ *
(
ÏÏ* +
string
ÏÏ+ 1
message
ÏÏ2 9
)
ÏÏ9 :
{
ÌÌ 	
Console
ÓÓ 
.
ÓÓ 
	WriteLine
ÓÓ 
(
ÓÓ 
message
ÓÓ %
)
ÓÓ% &
;
ÓÓ& '
Console
ÔÔ 
.
ÔÔ 
ReadKey
ÔÔ 
(
ÔÔ 
)
ÔÔ 
;
ÔÔ 
return
 
$str
 
;
 
}
ÒÒ 	
private
ÛÛ 
static
ÛÛ 
void
ÛÛ 
Pause
ÛÛ !
(
ÛÛ! "
)
ÛÛ" #
{
ÙÙ 	
Console
ıı 
.
ıı 
	WriteLine
ıı 
(
ıı 
$str
ıı >
)
ıı> ?
;
ıı? @
Console
ˆˆ 
.
ˆˆ 
ReadKey
ˆˆ 
(
ˆˆ 
)
ˆˆ 
;
ˆˆ 
}
˜˜ 	
}
¯¯ 
}˘˘ ˜
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
} ˝	
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
;$ %
string 
DeleteDoctor 
( 
int 
id  "
)" #
;# $
} 
} ß
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
} ÷\
ZC:\Users\310466\Desktop\Learning\HealthAxis\HealthApp\ConsoleApp\Helpers\InputValidator.cs
	namespace 	
	HealthApp
 
. 

ConsoleApp 
. 
Helpers &
{ 
public 

static 
class 
InputValidator &
{ 
public 
static 
string 
? 
GetValidatedInput /
(/ 0
string		 
prompt		 
,		 
Func

 
<

 
string

 
,

 
bool

 
>

 
	validator

 (
,

( )
string 
errorMessage 
,  
bool 

allowEmpty 
= 
false #
)# $
{ 	
while 
( 
true 
) 
{ 
Console 
. 
Write 
( 
prompt $
)$ %
;% &
string 
? 
input 
= 
Console  '
.' (
ReadLine( 0
(0 1
)1 2
;2 3
if 
( 
input 
? 
. 
ToLower "
(" #
)# $
==% '
$str( +
)+ ,
throw 
new &
OperationCanceledException 8
(8 9
)9 :
;: ;
if 
( 

allowEmpty 
&& !
string" (
.( )
IsNullOrWhiteSpace) ;
(; <
input< A
)A B
)B C
return 
null 
;  
if 
( 
! 
string 
. 
IsNullOrWhiteSpace .
(. /
input/ 4
)4 5
&&6 8
	validator9 B
(B C
inputC H
)H I
)I J
return 
input  
.  !
Trim! %
(% &
)& '
;' (
Console 
. 
	WriteLine !
(! "
errorMessage" .
). /
;/ 0
} 
} 	
public   
static   
DateTime   
GetValidDate   +
(  + ,
string  , 2
prompt  3 9
)  9 :
{!! 	
while"" 
("" 
true"" 
)"" 
{## 
Console$$ 
.$$ 
Write$$ 
($$ 
prompt$$ $
)$$$ %
;$$% &
var%% 
input%% 
=%% 
Console%% #
.%%# $
ReadLine%%$ ,
(%%, -
)%%- .
;%%. /
if'' 
('' 
input'' 
?'' 
.'' 
ToLower'' "
(''" #
)''# $
==''% '
$str''( +
)''+ ,
throw(( 
new(( &
OperationCanceledException(( 8
(((8 9
)((9 :
;((: ;
if** 
(** 
DateTime** 
.** 
TryParseExact** *
(*** +
input++ 
,++ 
$str,,  
,,,  !
CultureInfo-- 
.--  
InvariantCulture--  0
,--0 1
DateTimeStyles.. "
..." #
None..# '
,..' (
out// 
var// 
date//  
)//  !
)//! "
{00 
return11 
date11 
;11  
}22 
Console44 
.44 
	WriteLine44 !
(44! "
$str44" 1
)441 2
;442 3
}55 
}66 	
public88 
static88 
DateTime88 
?88 
GetOptionalDate88  /
(88/ 0
string880 6
prompt887 =
)88= >
{99 	
while:: 
(:: 
true:: 
):: 
{;; 
Console<< 
.<< 
Write<< 
(<< 
prompt<< $
)<<$ %
;<<% &
var== 
input== 
=== 
Console== #
.==# $
ReadLine==$ ,
(==, -
)==- .
;==. /
if?? 
(?? 
string?? 
.?? 
IsNullOrWhiteSpace?? -
(??- .
input??. 3
)??3 4
)??4 5
return@@ 
null@@ 
;@@  
ifBB 
(BB 
inputBB 
?BB 
.BB 
ToLowerBB "
(BB" #
)BB# $
==BB% '
$strBB( +
)BB+ ,
throwCC 
newCC &
OperationCanceledExceptionCC 8
(CC8 9
)CC9 :
;CC: ;
ifEE 
(EE 
DateTimeEE 
.EE 
TryParseExactEE *
(EE* +
inputFF 
,FF 
$strGG  
,GG  !
CultureInfoHH 
.HH  
InvariantCultureHH  0
,HH0 1
DateTimeStylesII "
.II" #
NoneII# '
,II' (
outJJ 
varJJ 
dateJJ  
)JJ  !
)JJ! "
{KK 
returnLL 
dateLL 
;LL  
}MM 
ConsoleOO 
.OO 
	WriteLineOO !
(OO! "
$strOO" 1
)OO1 2
;OO2 3
}PP 
}QQ 	
publicSS 
staticSS 

GenderTypeSS  
?SS  !
GetOptionalGenderSS" 3
(SS3 4
stringSS4 :
promptSS; A
)SSA B
{TT 	
whileUU 
(UU 
trueUU 
)UU 
{VV 
ConsoleWW 
.WW 
WriteWW 
(WW 
promptWW $
)WW$ %
;WW% &
varXX 
inputXX 
=XX 
ConsoleXX #
.XX# $
ReadLineXX$ ,
(XX, -
)XX- .
;XX. /
ifZZ 
(ZZ 
stringZZ 
.ZZ 
IsNullOrWhiteSpaceZZ -
(ZZ- .
inputZZ. 3
)ZZ3 4
)ZZ4 5
return[[ 
null[[ 
;[[  
if]] 
(]] 
input]] 
?]] 
.]] 
ToLower]] "
(]]" #
)]]# $
==]]% '
$str]]( +
)]]+ ,
throw^^ 
new^^ &
OperationCanceledException^^ 8
(^^8 9
)^^9 :
;^^: ;
if`` 
(`` 
Enum`` 
.`` 
TryParse`` !
<``! "

GenderType``" ,
>``, -
(``- .
input``. 3
,``3 4
true``5 9
,``9 :
out``; >
var``? B
gender``C I
)``I J
)``J K
returnaa 
genderaa !
;aa! "
Consolecc 
.cc 
	WriteLinecc !
(cc! "
$strcc" 3
)cc3 4
;cc4 5
}dd 
}ee 	
publicgg 
staticgg 

GenderTypegg  
GetValidGendergg! /
(gg/ 0
stringgg0 6
promptgg7 =
)gg= >
{hh 	
whileii 
(ii 
trueii 
)ii 
{jj 
Consolekk 
.kk 
Writekk 
(kk 
promptkk $
)kk$ %
;kk% &
varll 
inputll 
=ll 
Consolell #
.ll# $
ReadLinell$ ,
(ll, -
)ll- .
;ll. /
ifnn 
(nn 
inputnn 
?nn 
.nn 
ToLowernn "
(nn" #
)nn# $
==nn% '
$strnn( +
)nn+ ,
throwoo 
newoo &
OperationCanceledExceptionoo 8
(oo8 9
)oo9 :
;oo: ;
ifqq 
(qq 
Enumqq 
.qq 
TryParseqq !
<qq! "

GenderTypeqq" ,
>qq, -
(qq- .
inputqq. 3
,qq3 4
trueqq5 9
,qq9 :
outqq; >
varqq? B
genderqqC I
)qqI J
)qqJ K
returnrr 
genderrr !
;rr! "
Consolett 
.tt 
	WriteLinett !
(tt! "
$strtt" 3
)tt3 4
;tt4 5
}uu 
}vv 	
publicxx 
staticxx 
boolxx 
IsValidNamexx &
(xx& '
stringxx' -
inputxx. 3
)xx3 4
=>xx5 7
!yy 	
stringyy	 
.yy 
IsNullOrWhiteSpaceyy "
(yy" #
inputyy# (
)yy( )
&&yy* ,
!yy- .
inputyy. 3
.yy3 4
Anyyy4 7
(yy7 8
charyy8 <
.yy< =
IsDigityy= D
)yyD E
;yyE F
public{{ 
static{{ 
bool{{ 
IsValidPhone{{ '
({{' (
string{{( .
input{{/ 4
){{4 5
=>{{6 8
input|| 
.|| 
Length|| 
==|| 
$num|| 
&&|| !
input||" '
.||' (
All||( +
(||+ ,
char||, 0
.||0 1
IsDigit||1 8
)||8 9
;||9 :
public~~ 
static~~ 
bool~~ 
IsValidEmail~~ '
(~~' (
string~~( .
input~~/ 4
)~~4 5
=>~~6 8
input 
. 
Contains 
( 
$char 
) 
;  
public
ÅÅ 
static
ÅÅ 
bool
ÅÅ  
IsValidInsuranceId
ÅÅ -
(
ÅÅ- .
string
ÅÅ. 4
input
ÅÅ5 :
)
ÅÅ: ;
=>
ÅÅ< >
int
ÇÇ 
.
ÇÇ 
TryParse
ÇÇ 
(
ÇÇ 
input
ÇÇ 
,
ÇÇ 
out
ÇÇ  #
int
ÇÇ$ '
id
ÇÇ( *
)
ÇÇ* +
&&
ÇÇ, .
id
ÇÇ/ 1
>=
ÇÇ2 4
$num
ÇÇ5 6
;
ÇÇ6 7
public
ÑÑ 
static
ÑÑ 
bool
ÑÑ 
IsValidExperience
ÑÑ ,
(
ÑÑ, -
string
ÑÑ- 3
input
ÑÑ4 9
)
ÑÑ9 :
=>
ÑÑ; =
int
ÖÖ 
.
ÖÖ 
TryParse
ÖÖ 
(
ÖÖ 
input
ÖÖ 
,
ÖÖ 
out
ÖÖ  #
int
ÖÖ$ '
val
ÖÖ( +
)
ÖÖ+ ,
&&
ÖÖ- /
val
ÖÖ0 3
>=
ÖÖ4 6
$num
ÖÖ7 8
;
ÖÖ8 9
public
áá 
static
áá 
bool
áá 

IsValidFee
áá %
(
áá% &
string
áá& ,
input
áá- 2
)
áá2 3
=>
áá4 6
decimal
àà 
.
àà 
TryParse
àà 
(
àà 
input
àà "
,
àà" #
out
àà$ '
decimal
àà( /
val
àà0 3
)
àà3 4
&&
àà5 7
val
àà8 ;
>=
àà< >
$num
àà? @
;
àà@ A
public
ää 
static
ää 
bool
ää 
	IsValidId
ää $
(
ää$ %
string
ää% +
input
ää, 1
)
ää1 2
=>
ää3 5
int
ãã 
.
ãã 
TryParse
ãã 
(
ãã 
input
ãã 
,
ãã 
out
ãã  #
int
ãã$ '
id
ãã( *
)
ãã* +
&&
ãã, .
id
ãã/ 1
>
ãã2 3
$num
ãã4 5
;
ãã5 6
public
çç 
static
çç 
bool
çç 

IsNonEmpty
çç %
(
çç% &
string
çç& ,
input
çç- 2
)
çç2 3
=>
çç4 6
!
éé 
string
éé 
.
éé  
IsNullOrWhiteSpace
éé &
(
éé& '
input
éé' ,
)
éé, -
;
éé- .
}
èè 
}êê ñ
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
} ¬,
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
} 
, 
Doctor 
= 
new 
Doctor #
{ 
DoctorId 
= 
$num  
,  !
FullName 
= 
$str *
,* +
Specialisation "
=# $
$str% 1
} 
, 
ScheduledDate 
= 
DateTime  (
.( )
Now) ,
., -
AddDays- 4
(4 5
$num5 6
)6 7
,7 8
TimeSlot 
= 
$str %
,% &
Status 
= 
AppointmentStatus *
.* +
	Confirmed+ 4
} 
, 
new 
Appointment 
{ 
AppointmentId   
=   
$num    !
,  ! "
Patient!! 
=!! 
new!! 
Patient!! %
{"" 
	PatientId## 
=## 
$num##  !
,##! "
FullName$$ 
=$$ 
$str$$ )
,$$) *
Email%% 
=%% 
$str%% 0
,%%0 1
PhoneNumber&& 
=&&  !
$str&&" .
}'' 
,'' 
Doctor(( 
=(( 
new(( 
Doctor(( #
{)) 
DoctorId** 
=** 
$num**  
,**  !
FullName++ 
=++ 
$str++ *
,++* +
Specialisation,, "
=,,# $
$str,,% 2
}-- 
,-- 
ScheduledDate.. 
=.. 
DateTime..  (
...( )
Now..) ,
..., -
AddDays..- 4
(..4 5
$num..5 6
)..6 7
,..7 8
TimeSlot// 
=// 
$str// %
,//% &
Status00 
=00 
AppointmentStatus00 *
.00* +
Pending00+ 2
}11 
,11 
new33 
Appointment33 
{44 
AppointmentId55 
=55 
$num55  !
,55! "
Patient66 
=66 
new66 
Patient66 %
{77 
	PatientId88 
=88 
$num88  !
,88! "
FullName99 
=99 
$str99 ,
,99, -
Email:: 
=:: 
$str:: 3
,::3 4
PhoneNumber;; 
=;;  !
$str;;" .
}<< 
,<< 
Doctor== 
=== 
new== 
Doctor== #
{>> 
DoctorId?? 
=?? 
$num??  
,??  !
FullName@@ 
=@@ 
$str@@ *
,@@* +
SpecialisationAA "
=AA# $
$strAA% 1
}BB 
,BB 
ScheduledDateCC 
=CC 
DateTimeCC  (
.CC( )
NowCC) ,
.CC, -
AddDaysCC- 4
(CC4 5
$numCC5 6
)CC6 7
,CC7 8
TimeSlotDD 
=DD 
$strDD %
,DD% &
StatusEE 
=EE 
AppointmentStatusEE *
.EE* +
	CancelledEE+ 4
,EE4 5
CancellationReasonFF "
=FF# $
$strFF% E
}GG 
,GG 
newII 
AppointmentII 
{JJ 
AppointmentIdKK 
=KK 
$numKK  !
,KK! "
PatientLL 
=LL 
newLL 
PatientLL %
{MM 
	PatientIdNN 
=NN 
$numNN  !
,NN! "
FullNameOO 
=OO 
$strOO ,
,OO, -
EmailPP 
=PP 
$strPP 3
,PP3 4
PhoneNumberQQ 
=QQ  !
$strQQ" .
}RR 
,RR 
DoctorSS 
=SS 
newSS 
DoctorSS #
{TT 
DoctorIdUU 
=UU 
$numUU  
,UU  !
FullNameVV 
=VV 
$strVV *
,VV* +
SpecialisationWW "
=WW# $
$strWW% 2
}XX 
,XX 
ScheduledDateYY 
=YY 
DateTimeYY  (
.YY( )
NowYY) ,
.YY, -
AddDaysYY- 4
(YY4 5
$numYY5 6
)YY6 7
,YY7 8
TimeSlotZZ 
=ZZ 
$strZZ %
,ZZ% &
Status[[ 
=[[ 
AppointmentStatus[[ *
.[[* +
	Completed[[+ 4
}\\ 
}]] 	
;]]	 

}^^ 
}__ 