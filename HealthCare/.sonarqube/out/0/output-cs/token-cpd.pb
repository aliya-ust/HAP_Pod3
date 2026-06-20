ö
iC:\Users\310055\source\repos\UST-Live-01\HealthCare\HealthCare.Api\Services\Interfaces\IPatientService.cs
	namespace 	

HealthCare
 
. 
Api 
. 
Services !
.! "

Interfaces" ,
{ 
public 

	interface 
IPatientService $
{ 
Task		 
<		 
PatientListDto		 
>		 
GetByIdAsync		 )
(		) *
int		* -
id		. 0
)		0 1
;		1 2
Task

 
<

 
PagedResult

 
<

 
PatientListDto

 '
>

' (
>

( )
GetAllAsync

* 5
(

5 6
PatientFilter

6 C
filter

D J
)

J K
;

K L
Task 
AddAsync 
( 
CreatePatientDto &
dto' *
)* +
;+ ,
Task 
UpdateAsync 
( 
int 
id 
,  
UpdatePatientDto! 1
dto2 5
)5 6
;6 7
Task 
DeleteAsync 
( 
int 
id 
)  
;  !
Task 
UpdateStatusAsync 
( 
int "
id# %
,% &
bool' +
isActive, 4
)4 5
;5 6
} 
} Å
eC:\Users\310055\source\repos\UST-Live-01\HealthCare\HealthCare.Api\Services\Interfaces\IJwtService.cs
	namespace 	

HealthCare
 
. 
Api 
. 
Services !
.! "

Interfaces" ,
{ 
public 

	interface 
IJwtService  
{ 
Task 
< 
string 
> 
GenerateToken "
(" #
IdentityUser# /
user0 4
,4 5
int6 9
?9 :
	patientId; D
=E F
nullG K
,K L
intM P
?P Q
doctorIdR Z
=[ \
null] a
)a b
;b c
} 
}		 ∫
nC:\Users\310055\source\repos\UST-Live-01\HealthCare\HealthCare.Api\Services\Interfaces\IHealthRecordService.cs
	namespace 	

HealthCare
 
. 
Api 
. 
Services !
.! "

Interfaces" ,
{ 
public 

	interface  
IHealthRecordService )
{ 
Task 
< 
HealthRecordListDto  
?  !
>! "
GetByIdAsync# /
(/ 0
int0 3
id4 6
)6 7
;7 8
Task		 
<		 
PagedResult		 
<		 
HealthRecordListDto		 ,
>		, -
>		- .
GetAllAsync		/ :
(		: ;
HealthRecordFilter		; M
filter		N T
)		T U
;		U V
Task

 
AddAsync

 
(

 
int

 
doctorId

 "
,

" #!
CreateHealthRecordDto

$ 9
dto

: =
)

= >
;

> ?
Task 
UpdateAsync 
( 
int 
id 
,  !
UpdateHealthRecordDto! 6
dto7 :
): ;
;; <
Task 
DeleteAsync 
( 
int 
id 
)  
;  !
Task 
< 
List 
< 
HealthRecordListDto %
>% &
>& '$
GetHealthRecordByPatient( @
(@ A
intA D
idE G
)G H
;H I
Task 
< 
List 
< 
HealthRecordListDto %
>% &
>& '(
GetHealthRecordByAppointment( D
(D E
intE H
idI K
)K L
;L M
} 
} ©
hC:\Users\310055\source\repos\UST-Live-01\HealthCare\HealthCare.Api\Services\Interfaces\IDoctorservice.cs
	namespace 	

HealthCare
 
. 
Api 
. 
Services !
.! "

Interfaces" ,
{ 
public 

	interface 
IDoctorService #
{ 
Task		 
<		 
DoctorListDto		 
>		 
GetByIdAsync		 (
(		( )
int		) ,
id		- /
)		/ 0
;		0 1
Task

 
<

 
PagedResult

 
<

 
DoctorListDto

 &
>

& '
>

' (
GetAllAsync

) 4
(

4 5
DoctorFilter

5 A
filter

B H
)

H I
;

I J
Task 
AddAsync 
( 
CreateDoctorDto %
dto& )
)) *
;* +
Task 
UpdateAsync 
( 
int 
id 
,  
UpdateDoctorDto! 0
dto1 4
)4 5
;5 6
Task 
DeleteAsync 
( 
int 
id 
)  
;  !
Task 
< 
List 
< 
string 
> 
> 
GetSlots #
(# $
int$ '
doctorId( 0
)0 1
;1 2
Task 
UpdateStatusAsync 
( 
int "
id# %
,% &
bool' +
isActive, 4
)4 5
;5 6
Task 
CreateSlots 
( 
int 
id 
,  
List! %
<% &
string& ,
>, -
	timeslots. 7
)7 8
;8 9
Task 
<  
CreateLeaveResultDto !
>! "
CreateLeave# .
(. /
int/ 2
id3 5
,5 6
List7 ;
<; <
CreateLeaveDto< J
>J K
leavesL R
)R S
;S T
Task 
< 
List 
< 
DoctorListDto 
>  
>  !
AvailableDoctors" 2
(2 3
string3 9
specialisation: H
,H I
DateOnlyJ R
dateS W
)W X
;X Y
} 
} æO
rC:\Users\310055\source\repos\UST-Live-01\HealthCare\HealthCare.Api\Services\Implementations\HealthRecordService.cs
	namespace 	

HealthCare
 
. 
Api 
. 
Services !
.! "
Implementations" 1
{ 
public 

class 
HealthRecordService $
:% & 
IHealthRecordService' ;
{ 
private 
readonly #
IHealthRecordRepository 0
_repository1 <
;< =
private 
readonly 
HealthCareDbContext ,
_context- 5
;5 6
private 
readonly 
IMapper  
_mapper! (
;( )
public 
HealthRecordService "
(" ##
IHealthRecordRepository# :

repository; E
,E F
HealthCareDbContextG Z
context[ b
,b c
IMapperd k
mapperl r
)r s
{ 	
_repository 
= 

repository $
;$ %
_context 
= 
context 
; 
_mapper 
= 
mapper 
; 
} 	
public 
async 
Task 
< 
HealthRecordListDto -
?- .
>. /
GetByIdAsync0 <
(< =
int= @
idA C
)C D
{ 	
var 
record 
= 
await 
_repository *
.* +
GetByIdAsync+ 7
(7 8
id8 :
): ;
;; <
if 
( 
record 
is 
null 
) 
throw 
new %
InvalidOperationException 3
(3 4
$str4 N
)N O
;O P
return!! 
_mapper!! 
.!! 
Map!! 
<!! 
HealthRecordListDto!! 2
>!!2 3
(!!3 4
record!!4 :
)!!: ;
;!!; <
}"" 	
public$$ 
async$$ 
Task$$ 
<$$ 
PagedResult$$ %
<$$% &
HealthRecordListDto$$& 9
>$$9 :
>$$: ;
GetAllAsync$$< G
($$G H
HealthRecordFilter$$H Z
filter$$[ a
)$$a b
{%% 	

Expression'' 
<'' 
Func'' 
<'' 
HealthRecord'' (
,''( )
bool''* .
>''. /
>''/ 0
?''0 1
	predicate''2 ;
=''< =
null''> B
;''B C
if)) 
()) 
filter)) 
.)) 
	VisitDate))  
.))  !
HasValue))! )
)))) *
{** 
var++ 
start++ 
=++ 
filter++ "
.++" #
	VisitDate++# ,
.++, -
Value++- 2
.++2 3

ToDateTime++3 =
(++= >
TimeOnly++> F
.++F G
MinValue++G O
)++O P
;++P Q
var,, 
end,, 
=,, 
start,, 
.,,  
AddDays,,  '
(,,' (
$num,,( )
),,) *
;,,* +
	predicate.. 
=.. 
hr.. 
=>.. !
hr.." $
...$ %
	VisitDate..% .
>=../ 1
start..2 7
&&..8 :
hr..; =
...= >
	VisitDate..> G
<..H I
end..J M
;..M N
}// 
Func22 
<22 

IQueryable22 
<22 
HealthRecord22 (
>22( )
,22) *
IOrderedQueryable22+ <
<22< =
HealthRecord22= I
>22I J
>22J K
orderBy22L S
=22T U
q33 
=>33 
q33 
.33 
OrderBy33 
(33 
hr33 !
=>33" $
hr33% '
.33' (
	VisitDate33( 1
)331 2
;332 3
var66 
pagedResult66 
=66 
await66 #
_repository66$ /
.66/ 0
GetAllAsync660 ;
(66; <
filter77 
.77 

PageNumber77 !
,77! "
filter88 
.88 
EffectivePageSize88 (
,88( )
	predicate99 
,99 
orderBy:: 
);; 
;;; 
return>> 
new>> 
PagedResult>> "
<>>" #
HealthRecordListDto>># 6
>>>6 7
{?? 
Items@@ 
=@@ 
_mapper@@ 
.@@  
Map@@  #
<@@# $
IEnumerable@@$ /
<@@/ 0
HealthRecordListDto@@0 C
>@@C D
>@@D E
(@@E F
pagedResult@@F Q
.@@Q R
Items@@R W
)@@W X
,@@X Y

PageNumberAA 
=AA 
pagedResultAA (
.AA( )

PageNumberAA) 3
,AA3 4
PageSizeBB 
=BB 
pagedResultBB &
.BB& '
PageSizeBB' /
,BB/ 0

TotalCountCC 
=CC 
pagedResultCC (
.CC( )

TotalCountCC) 3
}DD 
;DD 
}EE 	
publicGG 
asyncGG 
TaskGG 
AddAsyncGG "
(GG" #
intGG# &
doctorIdGG' /
,GG/ 0!
CreateHealthRecordDtoGG1 F
dtoGGG J
)GGJ K
{HH 	
varII 
recordII 
=II 
_mapperII  
.II  !
MapII! $
<II$ %
HealthRecordII% 1
>II1 2
(II2 3
dtoII3 6
)II6 7
;II7 8
recordJJ 
.JJ 
DoctorIdJJ 
=JJ 
doctorIdJJ &
;JJ& '
awaitKK 
_repositoryKK 
.KK 
AddAsyncKK &
(KK& '
recordKK' -
)KK- .
;KK. /
awaitLL 
_contextLL 
.LL 
SaveChangesAsyncLL +
(LL+ ,
)LL, -
;LL- .
}MM 	
publicOO 
asyncOO 
TaskOO 
UpdateAsyncOO %
(OO% &
intOO& )
idOO* ,
,OO, -!
UpdateHealthRecordDtoOO. C
dtoOOD G
)OOG H
{PP 	
varQQ 
recordQQ 
=QQ 
awaitQQ 
_repositoryQQ *
.QQ* +
GetByIdAsyncQQ+ 7
(QQ7 8
idQQ8 :
)QQ: ;
;QQ; <
ifSS 
(SS 
recordSS 
isSS 
nullSS 
)SS 
throwTT 
newTT %
InvalidOperationExceptionTT 3
(TT3 4
$strTT4 N
)TTN O
;TTO P
_mapperVV 
.VV 
MapVV 
(VV 
dtoVV 
,VV 
recordVV #
)VV# $
;VV$ %
awaitWW 
_repositoryWW 
.WW 
UpdateAsyncWW )
(WW) *
recordWW* 0
)WW0 1
;WW1 2
awaitXX 
_contextXX 
.XX 
SaveChangesAsyncXX +
(XX+ ,
)XX, -
;XX- .
}YY 	
public[[ 
async[[ 
Task[[ 
DeleteAsync[[ %
([[% &
int[[& )
id[[* ,
)[[, -
{\\ 	
var]] 
record]] 
=]] 
await]] 
_repository]] *
.]]* +
GetByIdAsync]]+ 7
(]]7 8
id]]8 :
)]]: ;
;]]; <
if__ 
(__ 
record__ 
is__ 
null__ 
)__ 
throw`` 
new`` %
InvalidOperationException`` 3
(``3 4
$str``4 N
)``N O
;``O P
trybb 
{cc 
awaitdd 
_repositorydd !
.dd! "
DeleteAsyncdd" -
(dd- .
iddd. 0
)dd0 1
;dd1 2
awaitee 
_contextee 
.ee 
SaveChangesAsyncee /
(ee/ 0
)ee0 1
;ee1 2
}ff 
catchgg 
(gg 
DbUpdateExceptiongg $
exgg% '
)gg' (
{hh 
throwii 
newii %
InvalidOperationExceptionii 3
(ii3 4
$strii4 U
,iiU V
exiiW Y
)iiY Z
;iiZ [
}jj 
}kk 	
publicmm 
asyncmm 
Taskmm 
<mm 
Listmm 
<mm 
HealthRecordListDtomm 2
>mm2 3
>mm3 4$
GetHealthRecordByPatientmm5 M
(mmM N
intmmN Q
idmmR T
)mmT U
{nn 	
varoo 
recordsoo 
=oo 
awaitoo 
_repositoryoo  +
.oo+ ,$
GetHealthRecordByPatientoo, D
(ooD E
idooE G
)ooG H
;ooH I
returnpp 
recordspp 
.pp 
Countpp  
==pp! #
$numpp$ %
?pp& '
newpp( +
Listpp, 0
<pp0 1
HealthRecordListDtopp1 D
>ppD E
(ppE F
)ppF G
:ppH I
recordsppJ Q
;ppQ R
}qq 	
publicss 
asyncss 
Taskss 
<ss 
Listss 
<ss 
HealthRecordListDtoss 2
>ss2 3
>ss3 4(
GetHealthRecordByAppointmentss5 Q
(ssQ R
intssR U
idssV X
)ssX Y
{tt 	
varuu 
recordsuu 
=uu 
awaituu 
_repositoryuu  +
.uu+ ,(
GetHealthRecordByAppointmentuu, H
(uuH I
iduuI K
)uuK L
;uuL M
returnvv 
recordsvv 
.vv 
Countvv  
==vv! #
$numvv$ %
?vv& '
newvv( +
Listvv, 0
<vv0 1
HealthRecordListDtovv1 D
>vvD E
(vvE F
)vvF G
:vvH I
recordsvvJ Q
;vvQ R
}ww 	
}xx 
}yy á
mC:\Users\310055\source\repos\UST-Live-01\HealthCare\HealthCare.Api\Services\Interfaces\IAppointmentService.cs
	namespace 	

HealthCare
 
. 
Api 
. 
Services !
.! "

Interfaces" ,
{ 
public 

	interface 
IAppointmentService (
{ 
Task		 
<		 
AppointmentListDto		 
?		  
>		  !
GetByIdAsync		" .
(		. /
int		/ 2
id		3 5
)		5 6
;		6 7
Task

 
<

 
PagedResult

 
<

 
AppointmentListDto

 +
>

+ ,
>

, -
GetAllAsync

. 9
(

9 :
AppointmentFilter

: K
filter

L R
)

R S
;

S T
Task 
UpdateAsync 
( 
int 
id 
,   
UpdateAppointmentDto! 5
dto6 9
)9 :
;: ;
Task 
DeleteAsync 
( 
int 
id 
)  
;  !
Task 
< 
List 
< 
string 
> 
> 
AvailableTimeSlots -
(- .
DateOnly. 6
date7 ;
,; <
int= @
doctorIdA I
)I J
;J K
Task 
< 
bool 
> 
IsAvailable 
( 
DateOnly '
date( ,
,, -
int. 1
doctorId2 :
,: ;
string< B
timeSlotC K
)K L
;L M
Task 
AddAsync 
(  
CreateAppointmentDto *
dto+ .
,. /
int0 3
	patientId4 =
)= >
;> ?
Task 
UpdateStatusAsync 
( 
int "
id# %
,% & 
UpdateAppointmentDto' ;
dto< ?
)? @
;@ A
Task 
< 
List 
<  
AppointmentReportDto &
>& '
>' (
GetDailyReport) 7
(7 8
)8 9
;9 :
Task 
< 
List 
< 
AppointmentListDto $
>$ %
>% &
GetDoctorSchedule' 8
(8 9
DateOnly9 A
dateB F
,F G
intH K
idL N
)N O
;O P
Task 
< 
List 
< 
AppointmentListDto $
>$ %
>% &
GetPatientSchedule' 9
(9 :
DateOnly: B
dateC G
,G H
intI L
idM O
)O P
;P Q
Task 
< 
List 
< 
AppointmentListDto $
>$ %
>% &#
GetAppointmentByPatient' >
(> ?
int? B
idC E
)E F
;F G
Task 
< 
List 
< 
AppointmentListDto $
>$ %
>% &"
GetAppointmentByDoctor' =
(= >
int> A
idB D
)D E
;E F
Task *
CancelAppointmentsByDoctorDate +
(+ ,
int, /
doctorId0 8
,8 9
DateOnly: B
dateC G
)G H
;H I
} 
} «[
mC:\Users\310055\source\repos\UST-Live-01\HealthCare\HealthCare.Api\Services\Implementations\PatientService.cs
	namespace 	

HealthCare
 
. 
Api 
. 
Services !
.! "
Impl" &
{ 
public 

class 
PatientService 
:  !
IPatientService" 1
{ 
private 
readonly 
IRepository $
<$ %
Patient% ,
>, -
_repository. 9
;9 :
private 
readonly 
HealthCareDbContext ,
_context- 5
;5 6
private 
readonly 
IMapper  
_mapper! (
;( )
private 
const 
string 
NotFoundMessage ,
=- .
$str/ C
;C D
public 
PatientService 
( 
IRepository )
<) *
Patient* 1
>1 2

repository3 =
,= >
HealthCareDbContext? R
contextS Z
,Z [
IMapper\ c
mapperd j
)j k
{ 	
_repository 
= 

repository $
;$ %
_context 
= 
context 
; 
_mapper 
= 
mapper 
; 
} 	
public 
async 
Task 
< 
PatientListDto (
>( )
GetByIdAsync* 6
(6 7
int7 :
id; =
)= >
{ 	
var 
patient 
= 
await 
_repository  +
.+ ,
GetByIdAsync, 8
(8 9
id9 ;
); <
;< =
if   
(   
patient   
is   
null   
)    
throw!! 
new!! %
InvalidOperationException!! 3
(!!3 4
NotFoundMessage!!4 C
)!!C D
;!!D E
return## 
_mapper## 
.## 
Map## 
<## 
PatientListDto## -
>##- .
(##. /
patient##/ 6
)##6 7
;##7 8
}$$ 	
public(( 
async(( 
Task(( 
AddAsync(( "
(((" #
CreatePatientDto((# 3
dto((4 7
)((7 8
{)) 	
var** 
patient** 
=** 
_mapper** !
.**! "
Map**" %
<**% &
Patient**& -
>**- .
(**. /
dto**/ 2
)**2 3
;**3 4
await++ 
_repository++ 
.++ 
AddAsync++ &
(++& '
patient++' .
)++. /
;++/ 0
await,, 
_context,, 
.,, 
SaveChangesAsync,, +
(,,+ ,
),,, -
;,,- .
}-- 	
public// 
async// 
Task// 
<// 
PagedResult// %
<//% &
PatientListDto//& 4
>//4 5
>//5 6
GetAllAsync//7 B
(//B C
PatientFilter//C P
filter//Q W
)//W X
{00 	

Expression11 
<11 
Func11 
<11 
Patient11 #
,11# $
bool11% )
>11) *
>11* +
	predicate11, 5
=116 7
p118 9
=>11: <
true11= A
;11A B
if44 
(44 
filter44 
.44 
HasInsurance44 #
.44# $
HasValue44$ ,
)44, -
{55 
if66 
(66 
filter66 
.66 
HasInsurance66 '
.66' (
Value66( -
)66- .
{77 
	predicate88 
=88 
p88  !
=>88" $
p99 
.99 
InsuranceId99 %
!=99& (
null99) -
;99- .
}:: 
else;; 
{<< 
	predicate== 
=== 
p==  !
=>==" $
p>> 
.>> 
InsuranceId>> %
==>>& (
null>>) -
;>>- .
}?? 
}@@ 
ifDD 
(DD 
!DD 
stringDD 
.DD 
IsNullOrWhiteSpaceDD *
(DD* +
filterDD+ 1
.DD1 2
FullNameDD2 :
)DD: ;
)DD; <
{EE 
varFF 
searchFF 
=FF 
filterFF #
.FF# $
FullNameFF$ ,
.FF, -
TrimFF- 1
(FF1 2
)FF2 3
;FF3 4
ifHH 
(HH 
filterHH 
.HH 
HasInsuranceHH '
.HH' (
HasValueHH( 0
)HH0 1
{II 
ifJJ 
(JJ 
filterJJ 
.JJ 
HasInsuranceJJ +
.JJ+ ,
ValueJJ, 1
)JJ1 2
{KK 
	predicateLL !
=LL" #
pLL$ %
=>LL& (
pMM 
.MM 
InsuranceIdMM )
!=MM* ,
nullMM- 1
&&MM2 4
pNN 
.NN 
FullNameNN &
!=NN' )
nullNN* .
&&NN/ 1
EFOO 
.OO 
	FunctionsOO (
.OO( )
LikeOO) -
(OO- .
pOO. /
.OO/ 0
FullNameOO0 8
,OO8 9
$"OO: <
$strOO< =
{OO= >
searchOO> D
}OOD E
$strOOE F
"OOF G
)OOG H
;OOH I
}PP 
elseQQ 
{RR 
	predicateSS !
=SS" #
pSS$ %
=>SS& (
pTT 
.TT 
InsuranceIdTT )
==TT* ,
nullTT- 1
&&TT2 4
pUU 
.UU 
FullNameUU &
!=UU' )
nullUU* .
&&UU/ 1
EFVV 
.VV 
	FunctionsVV (
.VV( )
LikeVV) -
(VV- .
pVV. /
.VV/ 0
FullNameVV0 8
,VV8 9
$"VV: <
$strVV< =
{VV= >
searchVV> D
}VVD E
$strVVE F
"VVF G
)VVG H
;VVH I
}WW 
}XX 
elseYY 
{ZZ 
	predicate[[ 
=[[ 
p[[  !
=>[[" $
p\\ 
.\\ 
FullName\\ "
!=\\# %
null\\& *
&&\\+ -
EF]] 
.]] 
	Functions]] $
.]]$ %
Like]]% )
(]]) *
p]]* +
.]]+ ,
FullName]], 4
,]]4 5
$"]]6 8
$str]]8 9
{]]9 :
search]]: @
}]]@ A
$str]]A B
"]]B C
)]]C D
;]]D E
}^^ 
}__ 
varaa 
pagedResultaa 
=aa 
awaitaa #
_repositoryaa$ /
.aa/ 0
GetAllAsyncaa0 ;
(aa; <
filterbb 
.bb 

PageNumberbb !
,bb! "
filtercc 
.cc 
EffectivePageSizecc (
,cc( )
	predicatedd 
)ee 
;ee 
returngg 
newgg 
PagedResultgg "
<gg" #
PatientListDtogg# 1
>gg1 2
{hh 
Itemsii 
=ii 
_mapperii 
.ii  
Mapii  #
<ii# $
IEnumerableii$ /
<ii/ 0
PatientListDtoii0 >
>ii> ?
>ii? @
(ii@ A
pagedResultiiA L
.iiL M
ItemsiiM R
)iiR S
,iiS T

PageNumberjj 
=jj 
pagedResultjj (
.jj( )

PageNumberjj) 3
,jj3 4
PageSizekk 
=kk 
pagedResultkk &
.kk& '
PageSizekk' /
,kk/ 0

TotalCountll 
=ll 
pagedResultll (
.ll( )

TotalCountll) 3
}mm 
;mm 
}nn 	
publicpp 
asyncpp 
Taskpp 
UpdateAsyncpp %
(pp% &
intpp& )
idpp* ,
,pp, -
UpdatePatientDtopp. >
dtopp? B
)ppB C
{qq 	
varrr 
patientrr 
=rr 
awaitrr 
_repositoryrr  +
.rr+ ,
GetByIdAsyncrr, 8
(rr8 9
idrr9 ;
)rr; <
;rr< =
iftt 
(tt 
patienttt 
istt 
nulltt 
)tt  
throwuu 
newuu %
InvalidOperationExceptionuu 3
(uu3 4
NotFoundMessageuu4 C
)uuC D
;uuD E
_mapperww 
.ww 
Mapww 
(ww 
dtoww 
,ww 
patientww $
)ww$ %
;ww% &
awaityy 
_repositoryyy 
.yy 
UpdateAsyncyy )
(yy) *
patientyy* 1
)yy1 2
;yy2 3
awaitzz 
_contextzz 
.zz 
SaveChangesAsynczz +
(zz+ ,
)zz, -
;zz- .
}{{ 	
public}} 
async}} 
Task}} 
UpdateStatusAsync}} +
(}}+ ,
int}}, /
id}}0 2
,}}2 3
bool}}4 8
isActive}}9 A
)}}A B
{~~ 	
var 
patient 
= 
await 
_repository  +
.+ ,
GetByIdAsync, 8
(8 9
id9 ;
); <
;< =
if
ÅÅ 
(
ÅÅ 
patient
ÅÅ 
is
ÅÅ 
null
ÅÅ 
)
ÅÅ  
throw
ÇÇ 
new
ÇÇ '
InvalidOperationException
ÇÇ 3
(
ÇÇ3 4
NotFoundMessage
ÇÇ4 C
)
ÇÇC D
;
ÇÇD E
patient
ÑÑ 
.
ÑÑ 
IsActive
ÑÑ 
=
ÑÑ 
isActive
ÑÑ '
;
ÑÑ' (
await
ÜÜ 
_repository
ÜÜ 
.
ÜÜ 
UpdateAsync
ÜÜ )
(
ÜÜ) *
patient
ÜÜ* 1
)
ÜÜ1 2
;
ÜÜ2 3
await
áá 
_context
áá 
.
áá 
SaveChangesAsync
áá +
(
áá+ ,
)
áá, -
;
áá- .
}
àà 	
public
ää 
async
ää 
Task
ää 
DeleteAsync
ää %
(
ää% &
int
ää& )
id
ää* ,
)
ää, -
{
ãã 	
var
åå 
patient
åå 
=
åå 
await
åå 
_repository
åå  +
.
åå+ ,
GetByIdAsync
åå, 8
(
åå8 9
id
åå9 ;
)
åå; <
;
åå< =
if
éé 
(
éé 
patient
éé 
is
éé 
null
éé 
)
éé  
throw
èè 
new
èè '
InvalidOperationException
èè 3
(
èè3 4
NotFoundMessage
èè4 C
)
èèC D
;
èèD E
try
ëë 
{
íí 
await
ìì 
_repository
ìì !
.
ìì! "
DeleteAsync
ìì" -
(
ìì- .
id
ìì. 0
)
ìì0 1
;
ìì1 2
await
îî 
_context
îî 
.
îî 
SaveChangesAsync
îî /
(
îî/ 0
)
îî0 1
;
îî1 2
}
ïï 
catch
ññ 
(
ññ 
DbUpdateException
ññ $
ex
ññ% '
)
ññ' (
{
óó 
throw
òò 
new
òò '
InvalidOperationException
òò 3
(
òò3 4
$stròò4 ê
,òòê ë
exòòí î
)òòî ï
;òòï ñ
}
ôô 
}
öö 	
}
õõ 
}úú Ù0
iC:\Users\310055\source\repos\UST-Live-01\HealthCare\HealthCare.Api\Services\Implementations\JwtService.cs
	namespace		 	

HealthCare		
 
.		 
Api		 
.		 
Services		 !
.		! "
Implementations		" 1
{

 
public 

class 

JwtService 
: 
IJwtService )
{ 
private 
readonly 
IConfiguration '
_config( /
;/ 0
private 
readonly 
UserManager $
<$ %
IdentityUser% 1
>1 2
_userManager3 ?
;? @
public 

JwtService 
( 
IConfiguration (
config) /
,/ 0
UserManager1 <
<< =
IdentityUser= I
>I J
userManagerK V
)V W
{ 	
_config 
= 
config 
; 
_userManager 
= 
userManager &
;& '
} 	
public 
async 
Task 
< 
string  
>  !
GenerateToken" /
(/ 0
IdentityUser0 <
user= A
,A B
intC F
?F G
	patientIdH Q
=R S
nullT X
,X Y
intZ ]
?] ^
doctorId_ g
=h i
nullj n
)n o
{ 	
var 
jwtSettings 
= 
_config %
.% &

GetSection& 0
(0 1
$str1 6
)6 7
;7 8
var 
key 
= 
new  
SymmetricSecurityKey .
(. /
Encoding/ 7
.7 8
UTF88 <
.< =
GetBytes= E
(E F
jwtSettingsF Q
[Q R
$strR W
]W X
!X Y
)Y Z
)Z [
;[ \
var 
credentials 
= 
new !
SigningCredentials" 4
(4 5
key5 8
,8 9
SecurityAlgorithms: L
.L M

HmacSha256M W
)W X
;X Y
var 
roles 
= 
await 
_userManager *
.* +
GetRolesAsync+ 8
(8 9
user9 =
)= >
;> ?
var 
claims 
= 
new 
List !
<! "
Claim" '
>' (
{ 
new 
Claim 
( #
JwtRegisteredClaimNames 1
.1 2
Sub2 5
,5 6
user6 :
.: ;
Id; =
)= >
,> ?
new   
Claim   
(   #
JwtRegisteredClaimNames   1
.  1 2
Email  2 7
,  7 8
user  9 =
.  = >
Email  > C
??  D F
string  G M
.  M N
Empty  N S
)  S T
,  T U
new!! 
Claim!! 
(!! #
JwtRegisteredClaimNames!! 1
.!!1 2
Jti!!2 5
,!!5 6
Guid!!6 :
.!!: ;
NewGuid!!; B
(!!B C
)!!C D
.!!D E
ToString!!E M
(!!M N
)!!N O
)!!O P
,!!P Q
new"" 
Claim"" 
("" 

ClaimTypes"" $
.""$ %
NameIdentifier""% 3
,""3 4
user""4 8
.""8 9
Id""9 ;
)""; <
}## 
;## 
if%% 
(%% 
	patientId%% 
.%% 
HasValue%% "
)%%" #
{&& 
claims'' 
.'' 
Add'' 
('' 
new'' 
Claim'' $
(''$ %
$str''% 0
,''0 1
	patientId''2 ;
.''; <
Value''< A
.''A B
ToString''B J
(''J K
)''K L
)''L M
)''M N
;''N O
}(( 
if** 
(** 
doctorId** 
.** 
HasValue** !
)**! "
{++ 
claims,, 
.,, 
Add,, 
(,, 
new,, 
Claim,, $
(,,$ %
$str,,% /
,,,/ 0
doctorId,,1 9
.,,9 :
Value,,: ?
.,,? @
ToString,,@ H
(,,H I
),,I J
),,J K
),,K L
;,,L M
}-- 
foreach// 
(// 
var// 
role// 
in//  
roles//! &
)//& '
{00 
claims11 
.11 
Add11 
(11 
new11 
Claim11 $
(11$ %

ClaimTypes11% /
.11/ 0
Role110 4
,114 5
role116 :
)11: ;
)11; <
;11< =
}22 
var44 
expirationMinutes44 !
=44" #
int44$ '
.44' (
Parse44( -
(44- .
jwtSettings44. 9
[449 :
$str44: X
]44X Y
!44Y Z
)44Z [
;44[ \
var66 
token66 
=66 
new66 
JwtSecurityToken66 ,
(66, -
issuer88 
:88 
jwtSettings88 #
[88# $
$str88$ ,
]88, -
,88- .
audience99 
:99 
jwtSettings99 %
[99% &
$str99& 0
]990 1
,991 2
claims:: 
::: 
claims:: 
,:: 
expires;; 
:;; 
DateTime;; !
.;;! "
UtcNow;;" (
.;;( )

AddMinutes;;) 3
(;;3 4
expirationMinutes;;4 E
);;E F
,;;F G
signingCredentials<< "
:<<" #
credentials<<$ /
)?? 
;?? 
returnAA 
newAA #
JwtSecurityTokenHandlerAA .
(AA. /
)AA/ 0
.AA0 1

WriteTokenAA1 ;
(AA; <
tokenAA< A
)AAA B
;AAB C
}BB 	
}CC 
}DD ú
fC:\Users\310055\source\repos\UST-Live-01\HealthCare\HealthCare.Api\Services\Interfaces\IAuthService.cs
	namespace 	

HealthCare
 
. 
Api 
. 
Services !
.! "

Interfaces" ,
{ 
public 

	interface 
IAuthService !
{ 
Task		  
RegisterPatientAsync		 !
(		! "
CreatePatientDto		" 2
dto		3 6
)		6 7
;		7 8
Task

 
RegisterDoctorAsync

  
(

  !
CreateDoctorDto

! 0
dto

1 4
)

4 5
;

5 6
Task 
< 
AuthResponseDto 
> 

LoginAsync (
(( )
LoginDto) 1
dto2 5
)5 6
;6 7
Task 
ChangePasswordAsync  
(  !
string! '
userId( .
,. /
ChangePasswordDto0 A
dtoB E
)E F
;F G
} 
} ’é
lC:\Users\310055\source\repos\UST-Live-01\HealthCare\HealthCare.Api\Services\Implementations\DoctorService.cs
	namespace 	

HealthCare
 
. 
Api 
. 
Services !
.! "
Implementations" 1
{ 
public 

class 
DoctorService 
:  
IDoctorService! /
{ 
private 
readonly 
IDoctorRepository *
_repository+ 6
;6 7
private 
readonly "
IAppointmentRepository /"
_appointmentRepository0 F
;F G
private 
readonly 
HealthCareDbContext ,
_context- 5
;5 6
private 
readonly 
IMapper  
_mapper! (
;( )
private 
const 
string $
NotFoundExceptionMessage 5
=6 7
$str8 K
;K L
public 
DoctorService 
( 
IDoctorRepository .

repository/ 9
,9 :"
IAppointmentRepository; Q!
appointmentRepositoryR g
,g h
HealthCareDbContexti |
context	} Ñ
,
Ñ Ö
IMapper
Ü ç
mapper
é î
)
î ï
{ 	
_repository 
= 

repository $
;$ %"
_appointmentRepository "
=# $!
appointmentRepository% :
;: ;
_context 
= 
context 
; 
_mapper 
= 
mapper 
; 
} 	
public 
async 
Task 
< 
DoctorListDto '
>' (
GetByIdAsync) 5
(5 6
int6 9
id: <
)< =
{ 	
var 
doctor 
= 
await 
_repository *
.* +
GetByIdAsync+ 7
(7 8
id8 :
): ;
;; <
if!! 
(!! 
doctor!! 
is!! 
null!! 
)!! 
throw"" 
new"" %
InvalidOperationException"" 3
(""3 4$
NotFoundExceptionMessage""4 L
)""L M
;""M N
return$$ 
_mapper$$ 
.$$ 
Map$$ 
<$$ 
DoctorListDto$$ ,
>$$, -
($$- .
doctor$$. 4
)$$4 5
;$$5 6
}%% 	
public'' 
async'' 
Task'' 
<'' 
PagedResult'' %
<''% &
DoctorListDto''& 3
>''3 4
>''4 5
GetAllAsync''6 A
(''A B
DoctorFilter''B N
filter''O U
)''U V
{(( 	

Expression** 
<** 
Func** 
<** 
Doctor** "
,**" #
bool**$ (
>**( )
>**) *
?*** +
	predicate**, 5
=**6 7
null**8 <
;**< =
if,, 
(,, 
!,, 
string,, 
.,, 
IsNullOrWhiteSpace,, *
(,,* +
filter,,+ 1
.,,1 2
Specialisation,,2 @
),,@ A
&&,,B D
filter,,E K
.,,K L
MinExperience,,L Y
.,,Y Z
HasValue,,Z b
),,b c
{-- 
	predicate.. 
=.. 
d.. 
=>..  
d..! "
..." #
Specialisation..# 1
==..2 4
filter..5 ;
...; <
Specialisation..< J
&&//  
d//! "
.//" #
YearsOfExperience//# 4
>=//5 7
filter//8 >
.//> ?
MinExperience//? L
.//L M
Value//M R
;//R S
}00 
else11 
if11 
(11 
!11 
string11 
.11 
IsNullOrWhiteSpace11 /
(11/ 0
filter110 6
.116 7
Specialisation117 E
)11E F
)11F G
{22 
	predicate33 
=33 
d33 
=>33  
d33! "
.33" #
Specialisation33# 1
==332 4
filter335 ;
.33; <
Specialisation33< J
;33J K
}44 
else55 
if55 
(55 
filter55 
.55 
MinExperience55 )
.55) *
HasValue55* 2
)552 3
{66 
	predicate77 
=77 
d77 
=>77  
d77! "
.77" #
YearsOfExperience77# 4
>=775 7
filter778 >
.77> ?
MinExperience77? L
.77L M
Value77M R
;77R S
}88 
Func;; 
<;; 

IQueryable;; 
<;; 
Doctor;; "
>;;" #
,;;# $
IOrderedQueryable;;% 6
<;;6 7
Doctor;;7 =
>;;= >
>;;> ?
orderBy;;@ G
=;;H I
q<< 
=><< 
q<< 
.<< 
OrderByDescending<< (
(<<( )
d<<) *
=><<+ -
d<<. /
.<</ 0
YearsOfExperience<<0 A
)<<A B
;<<B C
var?? 
pagedResult?? 
=?? 
await?? #
_repository??$ /
.??/ 0
GetAllAsync??0 ;
(??; <
filter@@ 
.@@ 

PageNumber@@ !
,@@! "
filterAA 
.AA 
EffectivePageSizeAA (
,AA( )
	predicateBB 
,BB 
orderByCC 
)DD 
;DD 
returnGG 
newGG 
PagedResultGG "
<GG" #
DoctorListDtoGG# 0
>GG0 1
{HH 
ItemsII 
=II 
_mapperII 
.II  
MapII  #
<II# $
IEnumerableII$ /
<II/ 0
DoctorListDtoII0 =
>II= >
>II> ?
(II? @
pagedResultII@ K
.IIK L
ItemsIIL Q
)IIQ R
,IIR S

PageNumberJJ 
=JJ 
pagedResultJJ (
.JJ( )

PageNumberJJ) 3
,JJ3 4
PageSizeKK 
=KK 
pagedResultKK &
.KK& '
PageSizeKK' /
,KK/ 0

TotalCountLL 
=LL 
pagedResultLL (
.LL( )

TotalCountLL) 3
}MM 
;MM 
}NN 	
publicPP 
asyncPP 
TaskPP 
AddAsyncPP "
(PP" #
CreateDoctorDtoPP# 2
dtoPP3 6
)PP6 7
{QQ 	
varRR 
doctorRR 
=RR 
_mapperRR  
.RR  !
MapRR! $
<RR$ %
DoctorRR% +
>RR+ ,
(RR, -
dtoRR- 0
)RR0 1
;RR1 2
awaitSS 
_repositorySS 
.SS 
AddAsyncSS &
(SS& '
doctorSS' -
)SS- .
;SS. /
awaitUU 
_repositoryUU 
.UU 
CreateSlotsUU )
(UU) *
doctorUU* 0
.UU0 1
DoctorIdUU1 9
,UU9 :
dtoUU; >
.UU> ?
	TimeSlotsUU? H
)UUH I
;UUI J
awaitWW 
_contextWW 
.WW 
SaveChangesAsyncWW +
(WW+ ,
)WW, -
;WW- .
}XX 	
publicZZ 
asyncZZ 
TaskZZ 
UpdateAsyncZZ %
(ZZ% &
intZZ& )
idZZ* ,
,ZZ, -
UpdateDoctorDtoZZ. =
dtoZZ> A
)ZZA B
{[[ 	
var\\ 
doctor\\ 
=\\ 
await\\ 
_repository\\ *
.\\* +
GetByIdAsync\\+ 7
(\\7 8
id\\8 :
)\\: ;
;\\; <
if^^ 
(^^ 
doctor^^ 
is^^ 
null^^ 
)^^ 
throw__ 
new__ %
InvalidOperationException__ 3
(__3 4$
NotFoundExceptionMessage__4 L
)__L M
;__M N
_mapperaa 
.aa 
Mapaa 
(aa 
dtoaa 
,aa 
doctoraa #
)aa# $
;aa$ %
awaitcc 
_repositorycc 
.cc 
UpdateAsynccc )
(cc) *
doctorcc* 0
)cc0 1
;cc1 2
awaitdd 
_contextdd 
.dd 
SaveChangesAsyncdd +
(dd+ ,
)dd, -
;dd- .
}ee 	
publicgg 
asyncgg 
Taskgg 
UpdateStatusAsyncgg +
(gg+ ,
intgg, /
idgg0 2
,gg2 3
boolgg4 8
isActivegg9 A
)ggA B
{hh 	
varii 
doctorii 
=ii 
awaitii 
_repositoryii *
.ii* +
GetByIdAsyncii+ 7
(ii7 8
idii8 :
)ii: ;
;ii; <
ifkk 
(kk 
doctorkk 
iskk 
nullkk 
)kk 
throwll 
newll %
InvalidOperationExceptionll 3
(ll3 4$
NotFoundExceptionMessagell4 L
)llL M
;llM N
doctornn 
.nn 
IsActivenn 
=nn 
isActivenn &
;nn& '
awaitpp 
_repositorypp 
.pp 
UpdateAsyncpp )
(pp) *
doctorpp* 0
)pp0 1
;pp1 2
awaitqq 
_contextqq 
.qq 
SaveChangesAsyncqq +
(qq+ ,
)qq, -
;qq- .
}rr 	
publictt 
asynctt 
Tasktt 
DeleteAsynctt %
(tt% &
inttt& )
idtt* ,
)tt, -
{uu 	
varvv 
doctorvv 
=vv 
awaitvv 
_repositoryvv *
.vv* +
GetByIdAsyncvv+ 7
(vv7 8
idvv8 :
)vv: ;
;vv; <
ifxx 
(xx 
doctorxx 
isxx 
nullxx 
)xx 
throwyy 
newyy %
InvalidOperationExceptionyy 3
(yy3 4$
NotFoundExceptionMessageyy4 L
)yyL M
;yyM N
try{{ 
{|| 
await}} 
_repository}} !
.}}! "
DeleteAsync}}" -
(}}- .
id}}. 0
)}}0 1
;}}1 2
await~~ 
_context~~ 
.~~ 
SaveChangesAsync~~ /
(~~/ 0
)~~0 1
;~~1 2
} 
catch
ÄÄ 
(
ÄÄ 
DbUpdateException
ÄÄ $
ex
ÄÄ% '
)
ÄÄ' (
{
ÅÅ 
throw
ÇÇ 
new
ÇÇ '
InvalidOperationException
ÇÇ 3
(
ÇÇ3 4
$strÇÇ4 è
,ÇÇè ê
exÇÇë ì
)ÇÇì î
;ÇÇî ï
}
ÉÉ 
}
ÑÑ 	
public
ÜÜ 
async
ÜÜ 
Task
ÜÜ 
<
ÜÜ 
List
ÜÜ 
<
ÜÜ 
string
ÜÜ %
>
ÜÜ% &
>
ÜÜ& '
GetSlots
ÜÜ( 0
(
ÜÜ0 1
int
ÜÜ1 4
doctorId
ÜÜ5 =
)
ÜÜ= >
{
áá 	
var
àà 
slots
àà 
=
àà 
await
àà 
_repository
àà )
.
àà) *
GetSlots
àà* 2
(
àà2 3
doctorId
àà3 ;
)
àà; <
;
àà< =
if
ää 
(
ää 
slots
ää 
.
ää 
Count
ää 
==
ää 
$num
ää  
)
ää  !
throw
ãã 
new
ãã '
InvalidOperationException
ãã 3
(
ãã3 4
$str
ãã4 _
)
ãã_ `
;
ãã` a
return
çç 
slots
çç 
;
çç 
}
éé 	
public
êê 
async
êê 
Task
êê 
CreateSlots
êê %
(
êê% &
int
êê& )
id
êê* ,
,
êê, -
List
êê. 2
<
êê2 3
string
êê3 9
>
êê9 :
	timeslots
êê; D
)
êêD E
{
ëë 	
await
íí 
_repository
íí 
.
íí 
CreateSlots
íí )
(
íí) *
id
íí* ,
,
íí, -
	timeslots
íí. 7
)
íí7 8
;
íí8 9
await
ìì 
_context
ìì 
.
ìì 
SaveChangesAsync
ìì +
(
ìì+ ,
)
ìì, -
;
ìì- .
}
îî 	
private
ññ 
async
ññ 
Task
ññ 
<
ññ 
List
ññ 
<
ññ  
string
ññ  &
>
ññ& '
>
ññ' (%
AvailableTimeSlotsCheck
ññ) @
(
ññ@ A
DateOnly
ññA I
date
ññJ N
,
ññN O
int
ññP S
doctorId
ññT \
)
ññ\ ]
{
óó 	
var
òò 
allSlots
òò 
=
òò 
await
òò  
_repository
òò! ,
.
òò, -
GetSlots
òò- 5
(
òò5 6
doctorId
òò6 >
)
òò> ?
;
òò? @
var
ôô 
bookedSlots
ôô 
=
ôô 
await
ôô #$
_appointmentRepository
ôô$ :
.
ôô: ;
BookedTimeSlots
ôô; J
(
ôôJ K
date
ôôK O
,
ôôO P
doctorId
ôôQ Y
)
ôôY Z
;
ôôZ [
return
öö 
allSlots
öö 
.
öö 
Except
öö "
(
öö" #
bookedSlots
öö# .
)
öö. /
.
öö/ 0
ToList
öö0 6
(
öö6 7
)
öö7 8
;
öö8 9
}
õõ 	
public
ùù 
async
ùù 
Task
ùù 
<
ùù "
CreateLeaveResultDto
ùù .
>
ùù. /
CreateLeave
ùù0 ;
(
ùù; <
int
ùù< ?
id
ùù@ B
,
ùùB C
List
ùùD H
<
ùùH I
CreateLeaveDto
ùùI W
>
ùùW X
leaves
ùùY _
)
ùù_ `
{
ûû 	
var
üü 
result
üü 
=
üü 
new
üü "
CreateLeaveResultDto
üü 1
(
üü1 2
)
üü2 3
;
üü3 4
var
†† 
existingLeaves
†† 
=
††  
await
††! &
_repository
††' 2
.
††2 3!
GetLeavesByDoctorId
††3 F
(
††F G
id
††G I
)
††I J
;
††J K
var
°°  
existingLeaveDates
°° "
=
°°# $
existingLeaves
°°% 3
.
°°3 4
Select
°°4 :
(
°°: ;
l
°°; <
=>
°°= ?
l
°°@ A
.
°°A B
	LeaveDate
°°B K
)
°°K L
.
°°L M
	ToHashSet
°°M V
(
°°V W
)
°°W X
;
°°X Y
var
££ 
leavesToCreate
££ 
=
££  
new
££! $
List
££% )
<
££) *
CreateLeaveDto
££* 8
>
££8 9
(
££9 :
)
££: ;
;
££; <
foreach
•• 
(
•• 
var
•• 
leave
•• 
in
•• !
leaves
••" (
)
••( )
{
¶¶ 
if
ßß 
(
ßß  
existingLeaveDates
ßß &
.
ßß& '
Contains
ßß' /
(
ßß/ 0
leave
ßß0 5
.
ßß5 6
	LeaveDate
ßß6 ?
)
ßß? @
)
ßß@ A
{
®® 
result
©© 
.
©© 
SkippedDates
©© '
.
©©' (
Add
©©( +
(
©©+ ,
leave
©©, 1
.
©©1 2
	LeaveDate
©©2 ;
)
©©; <
;
©©< =
continue
™™ 
;
™™ 
}
´´ 
var
≠≠ 
availableSlots
≠≠ "
=
≠≠# $
await
≠≠% *%
AvailableTimeSlotsCheck
≠≠+ B
(
≠≠B C
leave
≠≠C H
.
≠≠H I
	LeaveDate
≠≠I R
,
≠≠R S
id
≠≠T V
)
≠≠V W
;
≠≠W X
var
ÆÆ 
allSlots
ÆÆ 
=
ÆÆ 
await
ÆÆ $
GetSlots
ÆÆ% -
(
ÆÆ- .
id
ÆÆ. 0
)
ÆÆ0 1
;
ÆÆ1 2
if
∞∞ 
(
∞∞ 
availableSlots
∞∞ "
.
∞∞" #
Count
∞∞# (
!=
∞∞) +
allSlots
∞∞, 4
.
∞∞4 5
Count
∞∞5 :
)
∞∞: ;
{
±± 
await
≥≥ $
_appointmentRepository
≥≥ 0
.
≥≥0 1,
CancelAppointmentsByDoctorDate
≥≥1 O
(
≥≥O P
id
≥≥P R
,
≥≥R S
leave
≥≥T Y
.
≥≥Y Z
	LeaveDate
≥≥Z c
)
≥≥c d
;
≥≥d e
result
¥¥ 
.
¥¥ .
 CreatedWithCancelledAppointments
¥¥ ;
.
¥¥; <
Add
¥¥< ?
(
¥¥? @
leave
¥¥@ E
.
¥¥E F
	LeaveDate
¥¥F O
)
¥¥O P
;
¥¥P Q
}
µµ 
leavesToCreate
∑∑ 
.
∑∑ 
Add
∑∑ "
(
∑∑" #
leave
∑∑# (
)
∑∑( )
;
∑∑) *
}
∏∏ 
if
∫∫ 
(
∫∫ 
leavesToCreate
∫∫ 
.
∫∫ 
Count
∫∫ $
>
∫∫% &
$num
∫∫' (
)
∫∫( )
{
ªª 
await
ºº 
_repository
ºº !
.
ºº! "
CreateLeaves
ºº" .
(
ºº. /
id
ºº/ 1
,
ºº1 2
leavesToCreate
ºº3 A
)
ººA B
;
ººB C
await
ΩΩ 
_context
ΩΩ 
.
ΩΩ 
SaveChangesAsync
ΩΩ /
(
ΩΩ/ 0
)
ΩΩ0 1
;
ΩΩ1 2
}
ææ 
return
¿¿ 
result
¿¿ 
;
¿¿ 
}
¡¡ 	
public
√√ 
async
√√ 
Task
√√ 
<
√√ 
List
√√ 
<
√√ 
DoctorListDto
√√ ,
>
√√, -
>
√√- .
AvailableDoctors
√√/ ?
(
√√? @
string
√√@ F
specialisation
√√G U
,
√√U V
DateOnly
√√W _
date
√√` d
)
√√d e
=>
√√f h
await
ƒƒ 
_repository
ƒƒ 
.
ƒƒ 
AvailableDoctors
ƒƒ .
(
ƒƒ. /
specialisation
ƒƒ/ =
,
ƒƒ= >
date
ƒƒ? C
)
ƒƒC D
;
ƒƒD E
}
≈≈ 
}∆∆ »i
jC:\Users\310055\source\repos\UST-Live-01\HealthCare\HealthCare.Api\Services\Implementations\AuthService.cs
	namespace 	

HealthCare
 
. 
Api 
. 
Services !
.! "
Implementations" 1
{ 
public 

class 
AuthService 
: 
IAuthService +
{ 
private 
readonly 
UserManager $
<$ %
IdentityUser% 1
>1 2
_userManager3 ?
;? @
private 
readonly 
IMapper  
_mapper! (
;( )
private 
readonly 
IPatientRepository +
_patientRepo, 8
;8 9
private 
readonly 
IDoctorRepository *
_doctorRepo+ 6
;6 7
private 
readonly 
IJwtService $
_jwtService% 0
;0 1
private 
readonly 
HealthCareDbContext ,
_context- 5
;5 6
public 
AuthService 
( 
UserManager 
< 
IdentityUser $
>$ %
userManager& 1
,1 2
IMapper 
mapper 
, 
IPatientRepository 
patientRepo *
,* +
IDoctorRepository 

doctorRepo (
,( )
IJwtService 

jwtService "
," #
HealthCareDbContext 
context  '
)' (
{   	
_userManager!! 
=!! 
userManager!! &
;!!& '
_mapper"" 
="" 
mapper"" 
;"" 
_patientRepo## 
=## 
patientRepo## &
;##& '
_doctorRepo$$ 
=$$ 

doctorRepo$$ $
;$$$ %
_jwtService%% 
=%% 

jwtService%% $
;%%$ %
_context&& 
=&& 
context&& 
;&& 
}'' 	
private)) 
async)) 
Task)) 
<)) 
IdentityUser)) '
>))' (#
CreateUserWithRoleAsync))) @
())@ A
string))A G
email))H M
,))M N
string))O U
password))V ^
,))^ _
string))` f
role))g k
)))k l
{** 	
var,, 
existingUser,, 
=,, 
await,, $
_userManager,,% 1
.,,1 2
FindByEmailAsync,,2 B
(,,B C
email,,C H
),,H I
;,,I J
if-- 
(-- 
existingUser-- 
!=-- 
null--  $
)--$ %
throw.. 
new.. %
InvalidOperationException.. 3
(..3 4
$str..4 J
)..J K
;..K L
var11 
user11 
=11 
new11 
IdentityUser11 '
{22 
UserName33 
=33 
email33  
,33  !
Email44 
=44 
email44 
}55 
;55 
var77 
result77 
=77 
await77 
_userManager77 +
.77+ ,
CreateAsync77, 7
(777 8
user778 <
,77< =
password77> F
)77F G
;77G H
if99 
(99 
!99 
result99 
.99 
	Succeeded99 !
)99! "
throw:: 
new:: %
InvalidOperationException:: 3
(::3 4
string::4 :
.::: ;
Join::; ?
(::? @
$str::@ D
,::D E
result::F L
.::L M
Errors::M S
.::S T
Select::T Z
(::Z [
e::[ \
=>::] _
e::` a
.::a b
Description::b m
)::m n
)::n o
)::o p
;::p q
await== 
_userManager== 
.== 
AddToRoleAsync== -
(==- .
user==. 2
,==2 3
role==4 8
)==8 9
;==9 :
return?? 
user?? 
;?? 
}@@ 	
publicBB 
asyncBB 
TaskBB  
RegisterPatientAsyncBB .
(BB. /
CreatePatientDtoBB/ ?
dtoBB@ C
)BBC D
{CC 	
varDD 
userDD 
=DD 
awaitDD #
CreateUserWithRoleAsyncDD 4
(DD4 5
dtoDD5 8
.DD8 9
EmailDD9 >
,DD> ?
dtoDD@ C
.DDC D
PasswordDDD L
,DDL M
$strDDN W
)DDW X
;DDX Y
varGG 
patientGG 
=GG 
_mapperGG !
.GG! "
MapGG" %
<GG% &
PatientGG& -
>GG- .
(GG. /
dtoGG/ 2
)GG2 3
;GG3 4
patientHH 
.HH 
UserIdHH 
=HH 
userHH !
.HH! "
IdHH" $
;HH$ %
awaitJJ 
_patientRepoJJ 
.JJ 
AddAsyncJJ '
(JJ' (
patientJJ( /
)JJ/ 0
;JJ0 1
awaitKK 
_contextKK 
.KK 
SaveChangesAsyncKK +
(KK+ ,
)KK, -
;KK- .
}LL 	
publicNN 
asyncNN 
TaskNN 
RegisterDoctorAsyncNN -
(NN- .
CreateDoctorDtoNN. =
dtoNN> A
)NNA B
{OO 	
varPP 
userPP 
=PP 
awaitPP #
CreateUserWithRoleAsyncPP 4
(PP4 5
dtoPP5 8
.PP8 9
EmailPP9 >
,PP> ?
dtoPP@ C
.PPC D
PasswordPPD L
,PPL M
$strPPN V
)PPV W
;PPW X
varSS 
doctorSS 
=SS 
_mapperSS  
.SS  !
MapSS! $
<SS$ %
DoctorSS% +
>SS+ ,
(SS, -
dtoSS- 0
)SS0 1
;SS1 2
doctorTT 
.TT 
UserIdTT 
=TT 
userTT  
.TT  !
IdTT! #
;TT# $
awaitVV 
_doctorRepoVV 
.VV 
AddAsyncVV &
(VV& '
doctorVV' -
)VV- .
;VV. /
awaitXX 
_contextXX 
.XX 
SaveChangesAsyncXX +
(XX+ ,
)XX, -
;XX- .
awaitZZ 
_doctorRepoZZ 
.ZZ 
CreateSlotsZZ )
(ZZ) *
doctorZZ* 0
.ZZ0 1
DoctorIdZZ1 9
,ZZ9 :
dtoZZ; >
.ZZ> ?
	TimeSlotsZZ? H
)ZZH I
;ZZI J
await\\ 
_context\\ 
.\\ 
SaveChangesAsync\\ +
(\\+ ,
)\\, -
;\\- .
}]] 	
public__ 
async__ 
Task__ 
<__ 
AuthResponseDto__ )
>__) *

LoginAsync__+ 5
(__5 6
LoginDto__6 >
dto__? B
)__B C
{`` 	
varbb 
userbb 
=bb 
awaitbb 
_userManagerbb )
.bb) *
FindByEmailAsyncbb* :
(bb: ;
dtobb; >
.bb> ?
Emailbb? D
)bbD E
;bbE F
ifcc 
(cc 
usercc 
==cc 
nullcc 
)cc 
throwdd 
newdd %
InvalidOperationExceptiondd 3
(dd3 4
$strdd4 J
)ddJ K
;ddK L
vargg 
isValidgg 
=gg 
awaitgg 
_userManagergg  ,
.gg, -
CheckPasswordAsyncgg- ?
(gg? @
usergg@ D
,ggD E
dtoggF I
.ggI J
PasswordggJ R
)ggR S
;ggS T
ifhh 
(hh 
!hh 
isValidhh 
)hh 
throwii 
newii '
UnauthorizedAccessExceptionii 5
(ii5 6
$strii6 K
)iiK L
;iiL M
varll 
rolesll 
=ll 
awaitll 
_userManagerll *
.ll* +
GetRolesAsyncll+ 8
(ll8 9
userll9 =
)ll= >
;ll> ?
ifmm 
(mm 
rolesmm 
==mm 
nullmm 
||mm  
!mm! "
rolesmm" '
.mm' (
Anymm( +
(mm+ ,
)mm, -
)mm- .
{nn 
throwoo 
newoo %
InvalidOperationExceptionoo 3
(oo3 4
$stroo4 K
)ooK L
;ooL M
}pp 
stringss 
tokenss 
;ss 
vartt 
rolett 
=tt 
rolestt 
[tt 
$numtt 
]tt 
;tt  
ifuu 
(uu 
roleuu 
==uu 
$struu !
)uu! "
{vv 
varww 
patientww 
=ww 
awaitww #
_patientRepoww$ 0
.ww0 1
GetByUserIdAsyncww1 A
(wwA B
userwwB F
.wwF G
IdwwG I
)wwI J
;wwJ K
ifyy 
(yy 
patientyy 
==yy 
nullyy #
)yy# $
throwzz 
newzz %
InvalidOperationExceptionzz 7
(zz7 8
$strzz8 S
)zzS T
;zzT U
token}} 
=}} 
await}} 
_jwtService}} )
.}}) *
GenerateToken}}* 7
(}}7 8
user}}8 <
,}}< =
	patientId}}> G
:}}G H
patient}}I P
.}}P Q
	PatientId}}Q Z
)}}Z [
;}}[ \
}~~ 
else 
if 
( 
role 
== 
$str %
)% &
{
ÄÄ 
var
ÅÅ 
doctor
ÅÅ 
=
ÅÅ 
await
ÅÅ "
_doctorRepo
ÅÅ# .
.
ÅÅ. /
GetByUserIdAsync
ÅÅ/ ?
(
ÅÅ? @
user
ÅÅ@ D
.
ÅÅD E
Id
ÅÅE G
)
ÅÅG H
;
ÅÅH I
if
ÉÉ 
(
ÉÉ 
doctor
ÉÉ 
==
ÉÉ 
null
ÉÉ "
)
ÉÉ" #
throw
ÑÑ 
new
ÑÑ '
InvalidOperationException
ÑÑ 7
(
ÑÑ7 8
$str
ÑÑ8 R
)
ÑÑR S
;
ÑÑS T
token
áá 
=
áá 
await
áá 
_jwtService
áá )
.
áá) *
GenerateToken
áá* 7
(
áá7 8
user
áá8 <
,
áá< =
doctorId
áá> F
:
ááF G
doctor
ááH N
.
ááN O
DoctorId
ááO W
)
ááW X
;
ááX Y
}
àà 
else
ââ 
if
ââ 
(
ââ 
role
ââ 
==
ââ 
$str
ââ $
)
ââ$ %
{
ää 
token
åå 
=
åå 
await
åå 
_jwtService
åå )
.
åå) *
GenerateToken
åå* 7
(
åå7 8
user
åå8 <
)
åå< =
;
åå= >
}
çç 
else
éé 
{
èè 
throw
êê 
new
êê '
InvalidOperationException
êê 3
(
êê3 4
$str
êê4 C
)
êêC D
;
êêD E
}
ëë 
var
îî 
response
îî 
=
îî 
new
îî 
AuthResponseDto
îî .
{
ïï 
AccessToken
ññ 
=
ññ 
token
ññ #
,
ññ# $
Role
óó 
=
óó 
role
óó 
}
òò 
;
òò 
return
öö 
response
öö 
;
öö 
}
õõ 	
public
ùù 
async
ùù 
Task
ùù !
ChangePasswordAsync
ùù -
(
ùù- .
string
ùù. 4
userId
ùù5 ;
,
ùù; <
ChangePasswordDto
ùù= N
dto
ùùO R
)
ùùR S
{
ûû 	
var
üü 
user
üü 
=
üü 
await
üü 
_userManager
üü )
.
üü) *
FindByIdAsync
üü* 7
(
üü7 8
userId
üü8 >
)
üü> ?
;
üü? @
if
°° 
(
°° 
user
°° 
==
°° 
null
°° 
)
°° 
throw
¢¢ 
new
¢¢ '
InvalidOperationException
¢¢ 3
(
¢¢3 4
$str
¢¢4 D
)
¢¢D E
;
¢¢E F
var
§§ 
result
§§ 
=
§§ 
await
§§ 
_userManager
§§ +
.
§§+ ,!
ChangePasswordAsync
§§, ?
(
§§? @
user
•• 
,
•• 
dto
¶¶ 
.
¶¶ 
CurrentPassword
¶¶ #
,
¶¶# $
dto
ßß 
.
ßß 
NewPassword
ßß 
)
®® 
;
®® 
if
™™ 
(
™™ 
!
™™ 
result
™™ 
.
™™ 
	Succeeded
™™ !
)
™™! "
throw
´´ 
new
´´ '
InvalidOperationException
´´ 3
(
´´3 4
string
¨¨ 
.
¨¨ 
Join
¨¨ 
(
¨¨  
$str
¨¨  $
,
¨¨$ %
result
¨¨& ,
.
¨¨, -
Errors
¨¨- 3
.
¨¨3 4
Select
¨¨4 :
(
¨¨: ;
e
¨¨; <
=>
¨¨= ?
e
¨¨@ A
.
¨¨A B
Description
¨¨B M
)
¨¨M N
)
¨¨N O
)
≠≠ 
;
≠≠ 
}
ÆÆ 	
}
∞∞ 
}±± Üú
qC:\Users\310055\source\repos\UST-Live-01\HealthCare\HealthCare.Api\Services\Implementations\AppointmentService.cs
	namespace 	

HealthCare
 
. 
Api 
. 
Services !
.! "
Implementations" 1
{ 
public 

class 
AppointmentService #
:$ %
IAppointmentService& 9
{ 
private 
readonly "
IAppointmentRepository /
_repository0 ;
;; <
private 
readonly 
IDoctorService '
_doctorService( 6
;6 7
private 
readonly 
HealthCareDbContext ,
_context- 5
;5 6
private 
readonly 
IMapper  
_mapper! (
;( )
public 
AppointmentService !
(! ""
IAppointmentRepository" 8

repository9 C
,C D
IDoctorServiceE S
doctorServiceT a
,a b
HealthCareDbContextc v
contextw ~
,~ 
IMapper
Ä á
mapper
à é
)
é è
{ 	
_repository 
= 

repository $
;$ %
_doctorService 
= 
doctorService *
;* +
_context 
= 
context 
; 
_mapper 
= 
mapper 
; 
} 	
public 
async 
Task 
< 
AppointmentListDto ,
?, -
>- .
GetByIdAsync/ ;
(; <
int< ?
id@ B
)B C
{ 	
var   
appointment   
=   
await   #
_repository  $ /
.  / 0
GetByIdAsync  0 <
(  < =
id  = ?
)  ? @
;  @ A
if"" 
("" 
appointment"" 
is"" 
null"" #
)""# $
throw## 
new## %
InvalidOperationException## 3
(##3 4
$str##4 L
)##L M
;##M N
return%% 
_mapper%% 
.%% 
Map%% 
<%% 
AppointmentListDto%% 1
>%%1 2
(%%2 3
appointment%%3 >
)%%> ?
;%%? @
}&& 	
public(( 
async(( 
Task(( 
<(( 
PagedResult(( %
<((% &
AppointmentListDto((& 8
>((8 9
>((9 :
GetAllAsync((; F
(((F G
AppointmentFilter((G X
filter((Y _
)((_ `
{)) 	

Expression++ 
<++ 
Func++ 
<++ 
Appointment++ '
,++' (
bool++) -
>++- .
>++. /
?++/ 0
	predicate++1 :
=++; <
null++= A
;++A B
if-- 
(-- 
!-- 
string-- 
.-- 
IsNullOrWhiteSpace-- *
(--* +
filter--+ 1
.--1 2
Status--2 8
)--8 9
&&--: <
filter--= C
.--C D
ScheduledDate--D Q
.--Q R
HasValue--R Z
)--Z [
{.. 
	predicate// 
=// 
a// 
=>//  
a00 
.00 
Status00 
==00 
filter00  &
.00& '
Status00' -
&&00. 0
a11 
.11 
ScheduledDate11 #
==11$ &
filter11' -
.11- .
ScheduledDate11. ;
.11; <
Value11< A
;11A B
}22 
else33 
if33 
(33 
!33 
string33 
.33 
IsNullOrWhiteSpace33 /
(33/ 0
filter330 6
.336 7
Status337 =
)33= >
)33> ?
{44 
	predicate55 
=55 
a55 
=>55  
a55! "
.55" #
Status55# )
==55* ,
filter55- 3
.553 4
Status554 :
;55: ;
}66 
else77 
if77 
(77 
filter77 
.77 
ScheduledDate77 )
.77) *
HasValue77* 2
)772 3
{88 
	predicate99 
=99 
a99 
=>99  
a99! "
.99" #
ScheduledDate99# 0
==991 3
filter994 :
.99: ;
ScheduledDate99; H
.99H I
Value99I N
;99N O
}:: 
Func== 
<== 

IQueryable== 
<== 
Appointment== '
>==' (
,==( )
IOrderedQueryable==* ;
<==; <
Appointment==< G
>==G H
>==H I
orderBy==J Q
===R S
q>> 
=>>> 
q>> 
.>> 
OrderBy>> 
(>> 
a>>  
=>>>! #
a>>$ %
.>>% &
ScheduledDate>>& 3
)>>3 4
;>>4 5
varAA 
pagedResultAA 
=AA 
awaitAA #
_repositoryAA$ /
.AA/ 0
GetAllAsyncAA0 ;
(AA; <
filterBB 
.BB 

PageNumberBB !
,BB! "
filterCC 
.CC 
EffectivePageSizeCC (
,CC( )
	predicateDD 
,DD 
orderByEE 
)FF 
;FF 
returnII 
newII 
PagedResultII "
<II" #
AppointmentListDtoII# 5
>II5 6
{JJ 
ItemsKK 
=KK 
_mapperKK 
.KK  
MapKK  #
<KK# $
IEnumerableKK$ /
<KK/ 0
AppointmentListDtoKK0 B
>KKB C
>KKC D
(KKD E
pagedResultKKE P
.KKP Q
ItemsKKQ V
)KKV W
,KKW X

PageNumberLL 
=LL 
pagedResultLL (
.LL( )

PageNumberLL) 3
,LL3 4
PageSizeMM 
=MM 
pagedResultMM &
.MM& '
PageSizeMM' /
,MM/ 0

TotalCountNN 
=NN 
pagedResultNN (
.NN( )

TotalCountNN) 3
}OO 
;OO 
}PP 	
publicRR 
asyncRR 
TaskRR 
AddAsyncRR "
(RR" # 
CreateAppointmentDtoRR# 7
dtoRR8 ;
,RR; <
intRR= @
	patientIdRRA J
)RRJ K
{SS 	
ifTT 
(TT 
dtoTT 
.TT 
ScheduledDateTT !
<TT" #
DateOnlyTT$ ,
.TT, -
FromDateTimeTT- 9
(TT9 :
DateTimeTT: B
.TTB C
TodayTTC H
)TTH I
)TTI J
throwUU 
newUU %
InvalidOperationExceptionUU 3
(UU3 4
$strUU4 a
)UUa b
;UUb c
awaitWW 
IsAvailableWW 
(WW 
dtoWW !
.WW! "
ScheduledDateWW" /
,WW/ 0
dtoWW1 4
.WW4 5
DoctorIdWW5 =
,WW= >
dtoWW? B
.WWB C
TimeSlotWWC K
)WWK L
;WWL M
varYY 
appointmentYY 
=YY 
_mapperYY %
.YY% &
MapYY& )
<YY) *
AppointmentYY* 5
>YY5 6
(YY6 7
dtoYY7 :
)YY: ;
;YY; <
appointmentZZ 
.ZZ 
	PatientIdZZ !
=ZZ" #
	patientIdZZ$ -
;ZZ- .
try\\ 
{]] 
await^^ 
_repository^^ !
.^^! "
AddAsync^^" *
(^^* +
appointment^^+ 6
)^^6 7
;^^7 8
await__ 
_context__ 
.__ 
SaveChangesAsync__ /
(__/ 0
)__0 1
;__1 2
}`` 
catchaa 
(aa 
DbUpdateExceptionaa $
exaa% '
)aa' (
{bb 
throwcc 
newcc %
InvalidOperationExceptioncc 3
(cc3 4
$strcc4 U
,ccU V
exccW Y
)ccY Z
;ccZ [
}dd 
}ee 	
publicgg 
asyncgg 
Taskgg 
UpdateAsyncgg %
(gg% &
intgg& )
idgg* ,
,gg, - 
UpdateAppointmentDtogg. B
dtoggC F
)ggF G
{hh 	
varii 
appointmentii 
=ii 
awaitii #
_repositoryii$ /
.ii/ 0
GetByIdAsyncii0 <
(ii< =
idii= ?
)ii? @
;ii@ A
ifkk 
(kk 
appointmentkk 
iskk 
nullkk #
)kk# $
throwll 
newll %
InvalidOperationExceptionll 3
(ll3 4
$strll4 L
)llL M
;llM N
_mappernn 
.nn 
Mapnn 
(nn 
dtonn 
,nn 
appointmentnn (
)nn( )
;nn) *
awaitoo 
_repositoryoo 
.oo 
UpdateAsyncoo )
(oo) *
appointmentoo* 5
)oo5 6
;oo6 7
awaitpp 
_contextpp 
.pp 
SaveChangesAsyncpp +
(pp+ ,
)pp, -
;pp- .
}qq 	
publicss 
asyncss 
Taskss 
UpdateStatusAsyncss +
(ss+ ,
intss, /
idss0 2
,ss2 3 
UpdateAppointmentDtoss4 H
dtossI L
)ssL M
{tt 	
varuu 
appointmentuu 
=uu 
awaituu #
_repositoryuu$ /
.uu/ 0
GetByIdAsyncuu0 <
(uu< =
iduu= ?
)uu? @
;uu@ A
ifww 
(ww 
appointmentww 
isww 
nullww #
)ww# $
throwxx 
newxx %
InvalidOperationExceptionxx 3
(xx3 4
$strxx4 H
)xxH I
;xxI J
appointmentzz 
.zz 
Statuszz 
=zz  
dtozz! $
.zz$ %
Statuszz% +
;zz+ ,
appointment{{ 
.{{ 
CancellationReason{{ *
={{+ ,
dto{{- 0
.{{0 1
CancellationReason{{1 C
;{{C D
await}} 
_repository}} 
.}} 
UpdateAsync}} )
(}}) *
appointment}}* 5
)}}5 6
;}}6 7
await~~ 
_context~~ 
.~~ 
SaveChangesAsync~~ +
(~~+ ,
)~~, -
;~~- .
} 	
public
ÅÅ 
async
ÅÅ 
Task
ÅÅ 
DeleteAsync
ÅÅ %
(
ÅÅ% &
int
ÅÅ& )
id
ÅÅ* ,
)
ÅÅ, -
{
ÇÇ 	
var
ÉÉ 
appointment
ÉÉ 
=
ÉÉ 
await
ÉÉ #
_repository
ÉÉ$ /
.
ÉÉ/ 0
GetByIdAsync
ÉÉ0 <
(
ÉÉ< =
id
ÉÉ= ?
)
ÉÉ? @
;
ÉÉ@ A
if
ÖÖ 
(
ÖÖ 
appointment
ÖÖ 
is
ÖÖ 
null
ÖÖ #
)
ÖÖ# $
throw
ÜÜ 
new
ÜÜ '
InvalidOperationException
ÜÜ 3
(
ÜÜ3 4
$str
ÜÜ4 L
)
ÜÜL M
;
ÜÜM N
try
áá 
{
àà 
await
ââ 
_repository
ââ !
.
ââ! "
DeleteAsync
ââ" -
(
ââ- .
id
ââ. 0
)
ââ0 1
;
ââ1 2
await
ää 
_context
ää 
.
ää 
SaveChangesAsync
ää /
(
ää/ 0
)
ää0 1
;
ää1 2
}
ãã 
catch
åå 
(
åå 
DbUpdateException
åå $
ex
åå% '
)
åå' (
{
çç 
throw
éé 
new
éé '
InvalidOperationException
éé 3
(
éé3 4
$stréé4 Ñ
,ééÑ Ö
exééÜ à
)ééà â
;ééâ ä
}
èè 
}
êê 	
public
íí 
async
íí 
Task
íí 
<
íí 
List
íí 
<
íí 
string
íí %
>
íí% &
>
íí& ' 
AvailableTimeSlots
íí( :
(
íí: ;
DateOnly
íí; C
date
ííD H
,
ííH I
int
ííJ M
doctorId
ííN V
)
ííV W
{
ìì 	
if
îî 
(
îî 
date
îî 
<
îî 
DateOnly
îî 
.
îî  
FromDateTime
îî  ,
(
îî, -
DateTime
îî- 5
.
îî5 6
Today
îî6 ;
)
îî; <
)
îî< =
throw
ïï 
new
ïï '
InvalidOperationException
ïï 3
(
ïï3 4
$str
ïï4 `
)
ïï` a
;
ïïa b
var
óó 
allSlots
óó 
=
óó 
await
óó  
_doctorService
óó! /
.
óó/ 0
GetSlots
óó0 8
(
óó8 9
doctorId
óó9 A
)
óóA B
;
óóB C
var
òò 
bookedSlots
òò 
=
òò 
await
òò #
_repository
òò$ /
.
òò/ 0
BookedTimeSlots
òò0 ?
(
òò? @
date
òò@ D
,
òòD E
doctorId
òòF N
)
òòN O
;
òòO P
var
öö 
	freeSlots
öö 
=
öö 
allSlots
öö $
.
öö$ %
Except
öö% +
(
öö+ ,
bookedSlots
öö, 7
)
öö7 8
.
öö8 9
ToList
öö9 ?
(
öö? @
)
öö@ A
;
ööA B
return
úú 
	freeSlots
úú 
;
úú 
}
ùù 	
public
üü 
async
üü 
Task
üü 
<
üü 
bool
üü 
>
üü 
IsAvailable
üü  +
(
üü+ ,
DateOnly
üü, 4
date
üü5 9
,
üü9 :
int
üü; >
doctorId
üü? G
,
üüG H
string
üüI O
timeSlot
üüP X
)
üüX Y
{
†† 	
var
°° 
	available
°° 
=
°° 
await
°° !
_repository
°°" -
.
°°- .
IsAvailable
°°. 9
(
°°9 :
date
°°: >
,
°°> ?
doctorId
°°@ H
,
°°H I
timeSlot
°°J R
)
°°R S
;
°°S T
if
££ 
(
££ 
!
££ 
	available
££ 
)
££ 
throw
§§ 
new
§§ '
InvalidOperationException
§§ 3
(
§§3 4
$str
§§4 W
)
§§W X
;
§§X Y
return
¶¶ 
true
¶¶ 
;
¶¶ 
}
ßß 	
public
©© 
async
©© 
Task
©© 
<
©© 
List
©© 
<
©© "
AppointmentReportDto
©© 3
>
©©3 4
>
©©4 5
GetDailyReport
©©6 D
(
©©D E
)
©©E F
{
™™ 	
var
´´ 
report
´´ 
=
´´ 
await
´´ 
_repository
´´ *
.
´´* +
GetDailyReport
´´+ 9
(
´´9 :
)
´´: ;
;
´´; <
return
¨¨ 
report
¨¨ 
.
¨¨ 
Count
¨¨ 
==
¨¨  "
$num
¨¨# $
?
¨¨% &
new
¨¨' *
List
¨¨+ /
<
¨¨/ 0"
AppointmentReportDto
¨¨0 D
>
¨¨D E
(
¨¨E F
)
¨¨F G
:
¨¨H I
report
¨¨J P
;
¨¨P Q
}
≠≠ 	
public
ØØ 
async
ØØ 
Task
ØØ 
<
ØØ 
List
ØØ 
<
ØØ  
AppointmentListDto
ØØ 1
>
ØØ1 2
>
ØØ2 3
GetDoctorSchedule
ØØ4 E
(
ØØE F
DateOnly
ØØF N
date
ØØO S
,
ØØS T
int
ØØU X
id
ØØY [
)
ØØ[ \
{
∞∞ 	
var
±± 
schedule
±± 
=
±± 
await
±±  
_repository
±±! ,
.
±±, -
GetDoctorSchedule
±±- >
(
±±> ?
date
±±? C
,
±±C D
id
±±E G
)
±±G H
;
±±H I
return
≤≤ 
schedule
≤≤ 
.
≤≤ 
Count
≤≤ !
==
≤≤" $
$num
≤≤% &
?
≤≤' (
new
≤≤) ,
List
≤≤- 1
<
≤≤1 2 
AppointmentListDto
≤≤2 D
>
≤≤D E
(
≤≤E F
)
≤≤F G
:
≤≤H I
schedule
≤≤J R
;
≤≤R S
}
≥≥ 	
public
µµ 
async
µµ 
Task
µµ 
<
µµ 
List
µµ 
<
µµ  
AppointmentListDto
µµ 1
>
µµ1 2
>
µµ2 3 
GetPatientSchedule
µµ4 F
(
µµF G
DateOnly
µµG O
date
µµP T
,
µµT U
int
µµV Y
id
µµZ \
)
µµ\ ]
{
∂∂ 	
var
∑∑ 
schedule
∑∑ 
=
∑∑ 
await
∑∑  
_repository
∑∑! ,
.
∑∑, - 
GetPatientSchedule
∑∑- ?
(
∑∑? @
date
∑∑@ D
,
∑∑D E
id
∑∑F H
)
∑∑H I
;
∑∑I J
return
∏∏ 
schedule
∏∏ 
.
∏∏ 
Count
∏∏ !
==
∏∏" $
$num
∏∏% &
?
∏∏' (
new
∏∏) ,
List
∏∏- 1
<
∏∏1 2 
AppointmentListDto
∏∏2 D
>
∏∏D E
(
∏∏E F
)
∏∏F G
:
∏∏H I
schedule
∏∏J R
;
∏∏R S
}
ππ 	
public
ªª 
async
ªª 
Task
ªª 
<
ªª 
List
ªª 
<
ªª  
AppointmentListDto
ªª 1
>
ªª1 2
>
ªª2 3%
GetAppointmentByPatient
ªª4 K
(
ªªK L
int
ªªL O
id
ªªP R
)
ªªR S
{
ºº 	
var
ΩΩ 
appointments
ΩΩ 
=
ΩΩ 
await
ΩΩ $
_repository
ΩΩ% 0
.
ΩΩ0 1%
GetAppointmentByPatient
ΩΩ1 H
(
ΩΩH I
id
ΩΩI K
)
ΩΩK L
;
ΩΩL M
return
ææ 
appointments
ææ 
.
ææ  
Count
ææ  %
==
ææ& (
$num
ææ) *
?
ææ+ ,
new
ææ- 0
List
ææ1 5
<
ææ5 6 
AppointmentListDto
ææ6 H
>
ææH I
(
ææI J
)
ææJ K
:
ææL M
appointments
ææN Z
;
ææZ [
}
øø 	
public
¡¡ 
async
¡¡ 
Task
¡¡ 
<
¡¡ 
List
¡¡ 
<
¡¡  
AppointmentListDto
¡¡ 1
>
¡¡1 2
>
¡¡2 3$
GetAppointmentByDoctor
¡¡4 J
(
¡¡J K
int
¡¡K N
id
¡¡O Q
)
¡¡Q R
{
¬¬ 	
var
√√ 
appointments
√√ 
=
√√ 
await
√√ $
_repository
√√% 0
.
√√0 1$
GetAppointmentByDoctor
√√1 G
(
√√G H
id
√√H J
)
√√J K
;
√√K L
return
ƒƒ 
appointments
ƒƒ 
.
ƒƒ  
Count
ƒƒ  %
==
ƒƒ& (
$num
ƒƒ) *
?
ƒƒ+ ,
new
ƒƒ- 0
List
ƒƒ1 5
<
ƒƒ5 6 
AppointmentListDto
ƒƒ6 H
>
ƒƒH I
(
ƒƒI J
)
ƒƒJ K
:
ƒƒL M
appointments
ƒƒN Z
;
ƒƒZ [
}
≈≈ 	
public
«« 
async
«« 
Task
«« ,
CancelAppointmentsByDoctorDate
«« 8
(
««8 9
int
««9 <
doctorId
««= E
,
««E F
DateOnly
««G O
date
««P T
)
««T U
{
»» 	
await
…… 
_repository
…… 
.
…… ,
CancelAppointmentsByDoctorDate
…… <
(
……< =
doctorId
……= E
,
……E F
date
……G K
)
……K L
;
……L M
await
   
_context
   
.
   
SaveChangesAsync
   +
(
  + ,
)
  , -
;
  - .
}
ÀÀ 	
}
ÃÃ 
}ÕÕ ¬
iC:\Users\310055\source\repos\UST-Live-01\HealthCare\HealthCare.Api\Repositories\Interfaces\IRepository.cs
	namespace 	

HealthCare
 
. 
Api 
. 
Repositories %
.% &

Interfaces& 0
{ 
public 

	interface 
IRepository  
<  !
T! "
>" #
where$ )
T* +
:, -
class. 3
{ 
Task 
< 
T 
? 
> 
GetByIdAsync 
( 
int !
id" $
)$ %
;% &
Task		 
<		 
PagedResult		 
<		 
T		 
>		 
>		 
GetAllAsync		 (
(		( )
int

 

pageNumber

 
,

 
int 
pageSize 
, 

Expression 
< 
Func 
< 
T 
, 
bool #
># $
>$ %
?% &
	predicate' 0
=1 2
null3 7
,7 8
Func 
< 

IQueryable 
< 
T 
> 
, 
IOrderedQueryable  1
<1 2
T2 3
>3 4
>4 5
?5 6
orderBy7 >
=? @
nullA E
) 	
;	 

Task 
AddAsync 
( 
T 
entity 
) 
;  
Task 
UpdateAsync 
( 
T 
entity !
)! "
;" #
Task 
DeleteAsync 
( 
int 
id 
)  
;  !
} 
} ¥
pC:\Users\310055\source\repos\UST-Live-01\HealthCare\HealthCare.Api\Repositories\Interfaces\IPatientRepository.cs
	namespace 	

HealthCare
 
. 
Api 
. 
Repositories %
.% &

Interfaces& 0
{ 
public 

	interface 
IPatientRepository '
:( )
IRepository* 5
<5 6
Patient6 =
>= >
{ 
Task 
< 
Patient 
? 
> 
GetByUserIdAsync '
(' (
string( .
userId/ 5
)5 6
;6 7
} 
}		 Í
uC:\Users\310055\source\repos\UST-Live-01\HealthCare\HealthCare.Api\Repositories\Interfaces\IHealthRecordRepository.cs
	namespace 	

HealthCare
 
. 
Api 
. 
Repositories %
.% &

Interfaces& 0
{ 
public 

	interface #
IHealthRecordRepository ,
:- .
IRepository/ :
<: ;
HealthRecord; G
>G H
{ 
Task 
< 
List 
< 
HealthRecordListDto %
>% &
>& '$
GetHealthRecordByPatient( @
(@ A
intA D
idE G
)G H
;H I
Task		 
<		 
List		 
<		 
HealthRecordListDto		 %
>		% &
>		& '(
GetHealthRecordByAppointment		( D
(		D E
int		E H
id		I K
)		K L
;		L M
}

 
} Ç
oC:\Users\310055\source\repos\UST-Live-01\HealthCare\HealthCare.Api\Repositories\Interfaces\IDoctorRepository.cs
	namespace 	

HealthCare
 
. 
Api 
. 
Repositories %
.% &

Interfaces& 0
{ 
public 

	interface 
IDoctorRepository &
:' (
IRepository) 4
<4 5
Doctor5 ;
>; <
{ 
Task 
< 
Doctor 
? 
> 
GetByUserIdAsync &
(& '
string' -
userId. 4
)4 5
;5 6
Task		 
<		 
List		 
<		 
string		 
>		 
>		 
GetSlots		 #
(		# $
int		$ '
doctorId		( 0
)		0 1
;		1 2
Task

 
CreateSlots

 
(

 
int

 
doctorId

 %
,

% &
List

' +
<

+ ,
string

, 2
>

2 3
	timeslots

4 =
)

= >
;

> ?
Task 
< 
List 
< 
DoctorLeaves 
> 
>  
GetLeavesByDoctorId! 4
(4 5
int5 8
doctorId9 A
)A B
;B C
Task 
CreateLeaves 
( 
int 
doctorId &
,& '
List( ,
<, -
CreateLeaveDto- ;
>; <
leaves= C
)C D
;D E
Task 
< 
List 
< 
DoctorListDto 
>  
>  !
AvailableDoctors" 2
(2 3
string3 9
specialisation: H
,H I
DateOnlyJ R
dateS W
)W X
;X Y
} 
} ˆ
tC:\Users\310055\source\repos\UST-Live-01\HealthCare\HealthCare.Api\Repositories\Interfaces\IAppointmentRepository.cs
	namespace 	

HealthCare
 
. 
Api 
. 
Repositories %
.% &

Interfaces& 0
{ 
public 

	interface "
IAppointmentRepository +
:, -
IRepository. 9
<9 :
Appointment: E
>E F
{ 
Task 
< 
List 
< 
string 
> 
> 
BookedTimeSlots *
(* +
DateOnly+ 3
date4 8
,8 9
int: =
doctorId> F
)F G
;G H
Task		 
<		 
bool		 
>		 
IsAvailable		 
(		 
DateOnly		 '
date		( ,
,		, -
int		. 1
doctorId		2 :
,		: ;
string		< B
timeSlot		C K
)		K L
;		L M
Task

 
<

 
List

 
<

  
AppointmentReportDto

 &
>

& '
>

' (
GetDailyReport

) 7
(

7 8
)

8 9
;

9 :
Task 
< 
List 
< 
AppointmentListDto $
>$ %
>% &
GetDoctorSchedule' 8
(8 9
DateOnly9 A
dateB F
,F G
intH K
idL N
)N O
;O P
Task 
< 
List 
< 
AppointmentListDto $
>$ %
>% &
GetPatientSchedule' 9
(9 :
DateOnly: B
dateC G
,G H
intI L
idM O
)O P
;P Q
Task 
< 
List 
< 
AppointmentListDto $
>$ %
>% &#
GetAppointmentByPatient' >
(> ?
int? B
idC E
)E F
;F G
Task 
< 
List 
< 
AppointmentListDto $
>$ %
>% &"
GetAppointmentByDoctor' =
(= >
int> A
idB D
)D E
;E F
Task *
CancelAppointmentsByDoctorDate +
(+ ,
int, /
doctorId0 8
,8 9
DateOnly: B
dateC G
)G H
;H I
} 
} ∫*
mC:\Users\310055\source\repos\UST-Live-01\HealthCare\HealthCare.Api\Repositories\Implementations\Repository.cs
	namespace 	

HealthCare
 
. 
Api 
. 
Repositories %
.% &
Implementations& 5
{ 
public		 

class		 

Repository		 
<		 
T		 
>		 
:		  
IRepository		! ,
<		, -
T		- .
>		. /
where		0 5
T		6 7
:		8 9
class		: ?
{

 
	protected 
readonly 
HealthCareDbContext .
_context/ 7
;7 8
	protected 
readonly 
DbSet  
<  !
T! "
>" #
_dbSet$ *
;* +
public 

Repository 
( 
HealthCareDbContext -
context. 5
)5 6
{ 	
_context 
= 
context 
; 
_dbSet 
= 
context 
. 
Set  
<  !
T! "
>" #
(# $
)$ %
;% &
} 	
public 
async 
Task 
< 
T 
? 
> 
GetByIdAsync *
(* +
int+ .
id/ 1
)1 2
=>3 5
await 
_dbSet 
. 
	FindAsync "
(" #
id# %
)% &
;& '
public 
async 
Task 
< 
PagedResult %
<% &
T& '
>' (
>( )
GetAllAsync* 5
(5 6
int 

pageNumber 
, 
int 
pageSize 
, 

Expression 
< 
Func 
< 
T 
, 
bool #
># $
>$ %
?% &
	predicate' 0
=1 2
null3 7
,7 8
Func 
< 

IQueryable 
< 
T 
> 
, 
IOrderedQueryable  1
<1 2
T2 3
>3 4
>4 5
?5 6
orderBy7 >
=? @
nullA E
)E F
{ 	

IQueryable 
< 
T 
> 
query 
=  !
_dbSet" (
;( )
if 
( 
	predicate 
!= 
null !
)! "
query   
=   
query   
.   
Where   #
(  # $
	predicate  $ -
)  - .
;  . /
if"" 
("" 
orderBy"" 
!="" 
null"" 
)""  
query## 
=## 
orderBy## 
(##  
query##  %
)##% &
;##& '
var%% 

totalCount%% 
=%% 
await%% "
query%%# (
.%%( )

CountAsync%%) 3
(%%3 4
)%%4 5
;%%5 6
var'' 
items'' 
='' 
await'' 
query'' #
.(( 
Skip(( 
((( 
((( 

pageNumber(( !
-((" #
$num(($ %
)((% &
*((' (
pageSize(() 1
)((1 2
.)) 
Take)) 
()) 
pageSize)) 
))) 
.** 
ToListAsync** 
(** 
)** 
;** 
return,, 
new,, 
PagedResult,, "
<,," #
T,,# $
>,,$ %
{-- 
Items.. 
=.. 
items.. 
,.. 

PageNumber// 
=// 

pageNumber// '
,//' (
PageSize00 
=00 
pageSize00 #
,00# $

TotalCount11 
=11 

totalCount11 '
}22 
;22 
}33 	
public55 
async55 
Task55 
AddAsync55 "
(55" #
T55# $
entity55% +
)55+ ,
=>55- /
await66 
_dbSet66 
.66 
AddAsync66 !
(66! "
entity66" (
)66( )
;66) *
public88 
Task88 
UpdateAsync88 
(88  
T88  !
entity88" (
)88( )
{99 	
_dbSet:: 
.:: 
Update:: 
(:: 
entity::  
)::  !
;::! "
return;; 
Task;; 
.;; 
CompletedTask;; %
;;;% &
}<< 	
public>> 
async>> 
Task>> 
DeleteAsync>> %
(>>% &
int>>& )
id>>* ,
)>>, -
{?? 	
var@@ 
entity@@ 
=@@ 
await@@ 
_dbSet@@ %
.@@% &
	FindAsync@@& /
(@@/ 0
id@@0 2
)@@2 3
;@@3 4
ifAA 
(AA 
entityAA 
isAA 
notAA 
nullAA "
)AA" #
_dbSetBB 
.BB 
RemoveBB 
(BB 
entityBB $
)BB$ %
;BB% &
}CC 	
}DD 
}EE …

tC:\Users\310055\source\repos\UST-Live-01\HealthCare\HealthCare.Api\Repositories\Implementations\PatientRepository.cs
	namespace 	

HealthCare
 
. 
Api 
. 
Repositories %
.% &
Implementations& 5
{ 
public 

class 
PatientRepository "
:# $

Repository% /
</ 0
Patient0 7
>7 8
,8 9
IPatientRepository: L
{		 
public

 
PatientRepository

  
(

  !
HealthCareDbContext

! 4
context

5 <
)

< =
:

> ?
base

@ D
(

D E
context

E L
)

L M
{

N O
}

P Q
public 
async 
Task 
< 
Patient !
?! "
>" #
GetByUserIdAsync$ 4
(4 5
string5 ;
userId< B
)B C
{ 	
return 
await 
_context !
.! "
Patients" *
. 
FirstOrDefaultAsync $
($ %
p% &
=>' )
p* +
.+ ,
UserId, 2
==3 5
userId6 <
)< =
;= >
} 	
} 
} ˝
yC:\Users\310055\source\repos\UST-Live-01\HealthCare\HealthCare.Api\Repositories\Implementations\HealthRecordRepository.cs
	namespace 	

HealthCare
 
. 
Api 
. 
Repositories %
.% &
Implementations& 5
{		 
public

 

class

 "
HealthRecordRepository

 '
:

( )

Repository

* 4
<

4 5
HealthRecord

5 A
>

A B
,

B C#
IHealthRecordRepository

D [
{ 
public "
HealthRecordRepository %
(% &
HealthCareDbContext& 9
context: A
)A B
:C D
baseE I
(I J
contextJ Q
)Q R
{S T
}U V
public 
async 
Task 
< 
List 
< 
HealthRecordListDto 2
>2 3
>3 4$
GetHealthRecordByPatient5 M
(M N
intN Q
idR T
)T U
=>V X
await 
_dbSet 
. 
Where 
( 
hr 
=> 
hr 
.  
	PatientId  )
==* ,
id- /
)/ 0
. 
Select 
( 
hr 
=> 
new !
HealthRecordListDto" 5
{ 
RecordId 
= 
hr !
.! "
RecordId" *
,* +
PatientName 
=  !
hr" $
.$ %
Patient% ,
., -
FullName- 5
,5 6

DoctorName 
=  
hr! #
.# $
Doctor$ *
.* +
FullName+ 3
,3 4
	VisitDate 
= 
hr  "
." #
	VisitDate# ,
,, -
	Diagnosis 
= 
hr  "
." #
	Diagnosis# ,
,, -
Prescription  
=! "
hr# %
.% &
Prescription& 2
,2 3
Notes 
= 
hr 
. 
Notes $
} 
) 
. 
ToListAsync 
( 
) 
; 
public 
async 
Task 
< 
List 
< 
HealthRecordListDto 2
>2 3
>3 4(
GetHealthRecordByAppointment5 Q
(Q R
intR U
idV X
)X Y
=>Z \
await 
_dbSet 
. 
Where 
( 
hr 
=> 
hr 
.  
AppointmentId  -
==. 0
id1 3
)3 4
.   
Select   
(   
hr   
=>   
new   !
HealthRecordListDto  " 5
{!! 
RecordId"" 
="" 
hr"" !
.""! "
RecordId""" *
,""* +
PatientName## 
=##  !
hr##" $
.##$ %
Patient##% ,
.##, -
FullName##- 5
,##5 6

DoctorName$$ 
=$$  
hr$$! #
.$$# $
Doctor$$$ *
.$$* +
FullName$$+ 3
,$$3 4
	VisitDate%% 
=%% 
hr%%  "
.%%" #
	VisitDate%%# ,
,%%, -
	Diagnosis&& 
=&& 
hr&&  "
.&&" #
	Diagnosis&&# ,
,&&, -
Prescription''  
=''! "
hr''# %
.''% &
Prescription''& 2
,''2 3
Notes(( 
=(( 
hr(( 
.(( 
Notes(( $
})) 
))) 
.** 
ToListAsync** 
(** 
)** 
;** 
}++ 
},, ¶9
sC:\Users\310055\source\repos\UST-Live-01\HealthCare\HealthCare.Api\Repositories\Implementations\DoctorRepository.cs
	namespace 	

HealthCare
 
. 
Api 
. 
Repositories %
.% &
Implementations& 5
{		 
public

 

class

 
DoctorRepository

 !
:

" #

Repository

$ .
<

. /
Doctor

/ 5
>

5 6
,

6 7
IDoctorRepository

8 I
{ 
public 
DoctorRepository 
(  
HealthCareDbContext  3
context4 ;
); <
:= >
base? C
(C D
contextD K
)K L
{M N
}O P
public 
async 
Task 
< 
Doctor  
?  !
>! "
GetByUserIdAsync# 3
(3 4
string4 :
userId; A
)A B
{ 	
return 
await 
_context !
.! "
Doctors" )
. 
FirstOrDefaultAsync $
($ %
p% &
=>' )
p* +
.+ ,
UserId, 2
==3 5
userId6 <
)< =
;= >
} 	
public 
async 
Task 
< 
List 
< 
string %
>% &
>& '
GetSlots( 0
(0 1
int1 4
doctorId5 =
)= >
=>? A
await 
_context 
. 
AvailableSlots )
. 
Where 
( 
s 
=> 
s 
. 
DoctorId &
==' )
doctorId* 2
)2 3
. 
Select 
( 
s 
=> 
s 
. 
TimeSlot '
)' (
. 
ToListAsync 
( 
) 
; 
public 
async 
Task 
CreateSlots %
(% &
int& )
doctorId* 2
,2 3
List4 8
<8 9
string9 ?
>? @
	timeslotsA J
)J K
{ 	
var 
slots 
= 
	timeslots !
.! "
Select" (
(( )
t) *
=>+ -
new. 1
AvailableSlots2 @
{ 
DoctorId 
= 
doctorId #
,# $
TimeSlot 
= 
t 
}   
)   
;   
await"" 
_context"" 
."" 
AvailableSlots"" )
."") *
AddRangeAsync""* 7
(""7 8
slots""8 =
)""= >
;""> ?
}## 	
public%% 
async%% 
Task%% 
<%% 
List%% 
<%% 
DoctorLeaves%% +
>%%+ ,
>%%, -
GetLeavesByDoctorId%%. A
(%%A B
int%%B E
doctorId%%F N
)%%N O
=>%%P R
await&& 
_context&& 
.&& 
DoctorLeaves&& '
.'' 
Where'' 
('' 
l'' 
=>'' 
l'' 
.'' 
DoctorId'' &
==''' )
doctorId''* 2
)''2 3
.(( 
ToListAsync(( 
((( 
)(( 
;(( 
public** 
async** 
Task** 
CreateLeaves** &
(**& '
int**' *
doctorId**+ 3
,**3 4
List**5 9
<**9 :
CreateLeaveDto**: H
>**H I
leaves**J P
)**P Q
{++ 	
var,, 
entities,, 
=,, 
leaves,, !
.,,! "
Select,," (
(,,( )
l,,) *
=>,,+ -
new,,. 1
DoctorLeaves,,2 >
{-- 
DoctorId.. 
=.. 
doctorId.. #
,..# $
	LeaveDate// 
=// 
l// 
.// 
	LeaveDate// '
,//' (
Reason00 
=00 
l00 
.00 
Reason00 !
}11 
)11 
;11 
await33 
_context33 
.33 
DoctorLeaves33 '
.33' (
AddRangeAsync33( 5
(335 6
entities336 >
)33> ?
;33? @
}44 	
public66 
async66 
Task66 
<66 
List66 
<66 
DoctorListDto66 ,
>66, -
>66- .
AvailableDoctors66/ ?
(66? @
string66@ F
specialisation66G U
,66U V
DateOnly66W _
date66` d
)66d e
{77 	
return88 
await88 
_dbSet88 
.99 
Where99 
(99 
d99 
=>99 
d99 
.99 
Specialisation99 ,
==99- /
specialisation990 >
&&99? A
d99B C
.99C D
IsActive99D L
)99L M
.:: 
Where:: 
(:: 
d:: 
=>:: 
!:: 
d:: 
.:: 
Leaves:: %
.::% &
Any::& )
(::) *
l::* +
=>::, .
l::/ 0
.::0 1
	LeaveDate::1 :
==::; =
date::> B
)::B C
)::C D
.;; 
Where;; 
(;; 
d;; 
=>;; 
d;; 
.;; 
AvailableSlots;; ,
.<< 
Select<< 
(<< 
s<< 
=><<  
s<<! "
.<<" #
TimeSlot<<# +
)<<+ ,
.== 
Except== 
(== 
d== 
.== 
Appointments== *
.>> 
Where>> 
(>> 
a>>  
=>>>! #
a>>$ %
.>>% &
ScheduledDate>>& 3
==>>4 6
date>>7 ;
&&>>< >
a>>? @
.>>@ A
Status>>A G
!=>>H J
$str>>K V
)>>V W
.?? 
Select?? 
(??  
a??  !
=>??" $
a??% &
.??& '
TimeSlot??' /
)??/ 0
)??0 1
.@@ 
Any@@ 
(@@ 
)@@ 
)@@ 
.AA 
SelectAA 
(AA 
dAA 
=>AA 
newAA  
DoctorListDtoAA! .
{BB 
DoctorIdCC 
=CC 
dCC  
.CC  !
DoctorIdCC! )
,CC) *
FullNameDD 
=DD 
dDD  
.DD  !
FullNameDD! )
,DD) *
SpecialisationEE "
=EE# $
dEE% &
.EE& '
SpecialisationEE' 5
,EE5 6
ConsultationFeeFF #
=FF$ %
dFF& '
.FF' (
ConsultationFeeFF( 7
,FF7 8
IsActiveGG 
=GG 
dGG  
.GG  !
IsActiveGG! )
}HH 
)HH 
.II 
ToListAsyncII 
(II 
)II 
;II 
}JJ 	
}KK 
}LL ˚f
xC:\Users\310055\source\repos\UST-Live-01\HealthCare\HealthCare.Api\Repositories\Implementations\AppointmentRepository.cs
	namespace 	

HealthCare
 
. 
Api 
. 
Repositories %
.% &
Implementations& 5
{		 
public

 

class

 !
AppointmentRepository

 &
:

' (

Repository

) 3
<

3 4
Appointment

4 ?
>

? @
,

@ A"
IAppointmentRepository

B X
{ 
private 
const 
string 
	Cancelled &
=' (
$str) 4
;4 5
public !
AppointmentRepository $
($ %
HealthCareDbContext% 8
context9 @
)@ A
:B C
baseD H
(H I
contextI P
)P Q
{R S
}T U
public 
async 
Task 
< 
List 
< 
string %
>% &
>& '
BookedTimeSlots( 7
(7 8
DateOnly8 @
dateA E
,E F
intG J
doctorIdK S
)S T
=>U W
await 
_dbSet 
. 
Where 
( 
a 
=> 
a 
. 
ScheduledDate +
==, .
date/ 3
&& 
a 
. 
DoctorId &
==' )
doctorId* 2
&& 
a 
. 
Status $
!=% '
	Cancelled( 1
)1 2
. 
Select 
( 
a 
=> 
a 
. 
TimeSlot '
)' (
. 
ToListAsync 
( 
) 
; 
public 
async 
Task 
< 
bool 
> 
IsAvailable  +
(+ ,
DateOnly, 4
date5 9
,9 :
int; >
doctorId? G
,G H
stringI O
timeSlotP X
)X Y
{ 	
var 
exists 
= 
await 
_dbSet %
.% &
AnyAsync& .
(. /
a/ 0
=>1 3
a 
. 
ScheduledDate 
==  "
date# '
&& 
a 
. 
DoctorId 
==  
doctorId! )
&& 
a 
. 
TimeSlot 
==  
timeSlot! )
&& 
a 
. 
Status 
!= 
	Cancelled (
)( )
;) *
return 
! 
exists 
; 
}   	
public"" 
async"" 
Task"" 
<"" 
List"" 
<""  
AppointmentReportDto"" 3
>""3 4
>""4 5
GetDailyReport""6 D
(""D E
)""E F
=>""G I
await## 
_dbSet## 
.$$ 
Where$$ 
($$ 
a$$ 
=>$$ 
a$$ 
.$$ 
ScheduledDate$$ +
>=$$, .
DateOnly$$/ 7
.$$7 8
FromDateTime$$8 D
($$D E
DateTime$$E M
.$$M N
Today$$N S
.$$S T
AddDays$$T [
($$[ \
-$$\ ]
$num$$] _
)$$_ `
)$$` a
)$$a b
.%% 
GroupBy%% 
(%% 
a%% 
=>%% 
a%% 
.%%  
ScheduledDate%%  -
)%%- .
.&& 
Select&& 
(&& 
g&& 
=>&& 
new&&   
AppointmentReportDto&&! 5
{'' 
Date(( 
=(( 
g(( 
.(( 
Key((  
,((  !
PendingCount))  
=))! "
g))# $
.))$ %
Count))% *
())* +
a))+ ,
=>))- /
a))0 1
.))1 2
Status))2 8
==))9 ;
$str))< E
)))E F
,))F G
ConfirmedCount** "
=**# $
g**% &
.**& '
Count**' ,
(**, -
a**- .
=>**/ 1
a**2 3
.**3 4
Status**4 :
==**; =
$str**> I
)**I J
,**J K
CancelledCount++ "
=++# $
g++% &
.++& '
Count++' ,
(++, -
a++- .
=>++/ 1
a++2 3
.++3 4
Status++4 :
==++; =
	Cancelled++> G
)++G H
,++H I
CompletedCount,, "
=,,# $
g,,% &
.,,& '
Count,,' ,
(,,, -
a,,- .
=>,,/ 1
a,,2 3
.,,3 4
Status,,4 :
==,,; =
$str,,> I
),,I J
}-- 
)-- 
... 
OrderBy.. 
(.. 
r.. 
=>.. 
r.. 
...  
Date..  $
)..$ %
.// 
ToListAsync// 
(// 
)// 
;// 
public11 
async11 
Task11 
<11 
List11 
<11 
AppointmentListDto11 1
>111 2
>112 3
GetDoctorSchedule114 E
(11E F
DateOnly11F N
date11O S
,11S T
int11U X
id11Y [
)11[ \
=>11] _
await22 
_dbSet22 
.33 
Where33 
(33 
a33 
=>33 
a33 
.33 
ScheduledDate33 +
==33, .
date33/ 3
&&334 6
a337 8
.338 9
DoctorId339 A
==33B D
id33E G
)33G H
.44 
Select44 
(44 
a44 
=>44 
new44  
AppointmentListDto44! 3
{55 
AppointmentId66 !
=66" #
a66$ %
.66% &
AppointmentId66& 3
,663 4
PatientName77 
=77  !
a77" #
.77# $
Patient77$ +
.77+ ,
FullName77, 4
,774 5

DoctorName88 
=88  
a88! "
.88" #
Doctor88# )
.88) *
FullName88* 2
,882 3
ScheduledDate99 !
=99" #
a99$ %
.99% &
ScheduledDate99& 3
,993 4
TimeSlot:: 
=:: 
a::  
.::  !
TimeSlot::! )
,::) *
Status;; 
=;; 
a;; 
.;; 
Status;; %
}<< 
)<< 
.== 
ToListAsync== 
(== 
)== 
;== 
public?? 
async?? 
Task?? 
<?? 
List?? 
<?? 
AppointmentListDto?? 1
>??1 2
>??2 3
GetPatientSchedule??4 F
(??F G
DateOnly??G O
date??P T
,??T U
int??V Y
id??Z \
)??\ ]
=>??^ `
await@@ 
_dbSet@@ 
.AA 
WhereAA 
(AA 
aAA 
=>AA 
aAA 
.AA 
ScheduledDateAA +
==AA, .
dateAA/ 3
&&AA4 6
aAA7 8
.AA8 9
	PatientIdAA9 B
==AAC E
idAAF H
)AAH I
.BB 
SelectBB 
(BB 
aBB 
=>BB 
newBB  
AppointmentListDtoBB! 3
{CC 
AppointmentIdDD !
=DD" #
aDD$ %
.DD% &
AppointmentIdDD& 3
,DD3 4
PatientNameEE 
=EE  !
aEE" #
.EE# $
PatientEE$ +
.EE+ ,
FullNameEE, 4
,EE4 5

DoctorNameFF 
=FF  
aFF! "
.FF" #
DoctorFF# )
.FF) *
FullNameFF* 2
,FF2 3
ScheduledDateGG !
=GG" #
aGG$ %
.GG% &
ScheduledDateGG& 3
,GG3 4
TimeSlotHH 
=HH 
aHH  
.HH  !
TimeSlotHH! )
,HH) *
StatusII 
=II 
aII 
.II 
StatusII %
}JJ 
)JJ 
.KK 
ToListAsyncKK 
(KK 
)KK 
;KK 
publicMM 
asyncMM 
TaskMM 
<MM 
ListMM 
<MM 
AppointmentListDtoMM 1
>MM1 2
>MM2 3#
GetAppointmentByPatientMM4 K
(MMK L
intMML O
idMMP R
)MMR S
=>MMT V
awaitNN 
_dbSetNN 
.OO 
WhereOO 
(OO 
aOO 
=>OO 
aOO 
.OO 
	PatientIdOO '
==OO( *
idOO+ -
&&OO. 0
aOO1 2
.OO2 3
ScheduledDateOO3 @
>=OOA C
DateOnlyOOD L
.OOL M
FromDateTimeOOM Y
(OOY Z
DateTimeOOZ b
.OOb c
TodayOOc h
)OOh i
)OOi j
.PP 
SelectPP 
(PP 
aPP 
=>PP 
newPP  
AppointmentListDtoPP! 3
{QQ 
AppointmentIdRR !
=RR" #
aRR$ %
.RR% &
AppointmentIdRR& 3
,RR3 4
PatientNameSS 
=SS  !
aSS" #
.SS# $
PatientSS$ +
.SS+ ,
FullNameSS, 4
,SS4 5

DoctorNameTT 
=TT  
aTT! "
.TT" #
DoctorTT# )
.TT) *
FullNameTT* 2
,TT2 3
ScheduledDateUU !
=UU" #
aUU$ %
.UU% &
ScheduledDateUU& 3
,UU3 4
TimeSlotVV 
=VV 
aVV  
.VV  !
TimeSlotVV! )
,VV) *
StatusWW 
=WW 
aWW 
.WW 
StatusWW %
}XX 
)XX 
.YY 
ToListAsyncYY 
(YY 
)YY 
;YY 
public[[ 
async[[ 
Task[[ 
<[[ 
List[[ 
<[[ 
AppointmentListDto[[ 1
>[[1 2
>[[2 3"
GetAppointmentByDoctor[[4 J
([[J K
int[[K N
id[[O Q
)[[Q R
=>[[S U
await\\ 
_dbSet\\ 
.]] 
Where]] 
(]] 
a]] 
=>]] 
a]] 
.]] 
DoctorId]] &
==]]' )
id]]* ,
&&]]- /
a]]0 1
.]]1 2
ScheduledDate]]2 ?
>=]]@ B
DateOnly]]C K
.]]K L
FromDateTime]]L X
(]]X Y
DateTime]]Y a
.]]a b
Today]]b g
)]]g h
)]]h i
.^^ 
Select^^ 
(^^ 
a^^ 
=>^^ 
new^^  
AppointmentListDto^^! 3
{__ 
AppointmentId`` !
=``" #
a``$ %
.``% &
AppointmentId``& 3
,``3 4
PatientNameaa 
=aa  !
aaa" #
.aa# $
Patientaa$ +
.aa+ ,
FullNameaa, 4
,aa4 5

DoctorNamebb 
=bb  
abb! "
.bb" #
Doctorbb# )
.bb) *
FullNamebb* 2
,bb2 3
ScheduledDatecc !
=cc" #
acc$ %
.cc% &
ScheduledDatecc& 3
,cc3 4
TimeSlotdd 
=dd 
add  
.dd  !
TimeSlotdd! )
,dd) *
Statusee 
=ee 
aee 
.ee 
Statusee %
}ff 
)ff 
.gg 
ToListAsyncgg 
(gg 
)gg 
;gg 
publicii 
asyncii 
Taskii *
CancelAppointmentsByDoctorDateii 8
(ii8 9
intii9 <
doctorIdii= E
,iiE F
DateOnlyiiG O
dateiiP T
)iiT U
{jj 	
varkk 
appointmentskk 
=kk 
awaitkk $
_dbSetkk% +
.ll 
Wherell 
(ll 
all 
=>ll 
all 
.ll 
DoctorIdll &
==ll' )
doctorIdll* 2
&&mm 
amm 
.mm 
ScheduledDatemm +
==mm, .
datemm/ 3
&&nn 
ann 
.nn 
Statusnn $
!=nn% '
	Cancellednn( 1
)nn1 2
.oo 
ToListAsyncoo 
(oo 
)oo 
;oo 
foreachqq 
(qq 
varqq 
appointmentqq $
inqq% '
appointmentsqq( 4
)qq4 5
{rr 
appointmentss 
.ss 
Statusss "
=ss# $
	Cancelledss% .
;ss. /
appointmenttt 
.tt 
CancellationReasontt .
=tt/ 0
$strtt1 B
;ttB C
}uu 
}vv 	
}ww 
}xx Åf
MC:\Users\310055\source\repos\UST-Live-01\HealthCare\HealthCare.Api\Program.cs
var 
builder 
= 
WebApplication 
. 
CreateBuilder *
(* +
args+ /
)/ 0
;0 1
builder 
. 
Services 
. 
AddProblemDetails "
(" #
)# $
;$ %
builder 
. 
Services 
. 
AddExceptionHandler $
<$ %"
GlobalExceptionHandler% ;
>; <
(< =
)= >
;> ?
builder 
. 
Services 
. 
AddControllers 
(  
)  !
;! "
builder 
. 
Services 
. 
AddAutoMapper 
( 
cfg "
=># %
{ 
cfg 
. 

AddProfile 
< 
MappingProfile !
>! "
(" #
)# $
;$ %
} 
) 
; 
builder 
. 
Services 
. 
AddDbContext 
< 
HealthCareDbContext 1
>1 2
(2 3
options3 :
=>; =
options 
. 
UseSqlServer 
( 
builder  
.  !
Configuration! .
.. /
GetConnectionString/ B
(B C
$strC [
)[ \
)\ ]
)   
;   
builder"" 
."" 
Services"" 
."" 
AddIdentity"" 
<"" 
IdentityUser"" )
,"") *
IdentityRole""+ 7
>""7 8
(""8 9
options""9 @
=>""A C
{## 
options$$ 
.$$ 
User$$ 
.$$ 
RequireUniqueEmail$$ #
=$$$ %
true$$& *
;$$* +
options%% 
.%% 
Password%% 
.%% 
RequireDigit%% !
=%%" #
true%%$ (
;%%( )
options&& 
.&& 
Password&& 
.&& 
RequireUppercase&& %
=&&& '
true&&( ,
;&&, -
options'' 
.'' 
Password'' 
.'' "
RequireNonAlphanumeric'' +
='', -
true''. 2
;''2 3
options(( 
.(( 
Password(( 
.(( 
RequiredLength(( #
=(($ %
$num((& '
;((' (
})) 
))) 
.)) $
AddEntityFrameworkStores)) 
<)) 
HealthCareDbContext)) /
>))/ 0
())0 1
)))1 2
.))2 3$
AddDefaultTokenProviders))3 K
())K L
)))L M
;))M N
builder++ 
.++ 
Services++ 
.++ 
AddAuthentication++ "
(++" #
JwtBearerDefaults++# 4
.++4 5 
AuthenticationScheme++5 I
)++I J
.,, 
AddJwtBearer,, 
(,, 
option,, 
=>,, 
{-- 
var.. 
jwt.. 
=.. 
builder.. 
... 
Configuration.. #
...# $

GetSection..$ .
(... /
$str../ 4
)..4 5
;..5 6
option// 

.//
 %
TokenValidationParameters// $
=//% &
new//' *%
TokenValidationParameters//+ D
{00 
ValidateIssuer11 
=11 
true11 
,11 
ValidIssuer22 
=22 
jwt22 
[22 
$str22 "
]22" #
,22# $
ValidateAudience33 
=33 
true33 
,33  
ValidAudience44 
=44 
jwt44 
[44 
$str44 &
]44& '
,44' (
ValidateLifetime55 
=55 
true55 
,55  $
ValidateIssuerSigningKey66  
=66! "
true66# '
,66' (
IssuerSigningKey77 
=77 
new77  
SymmetricSecurityKey77 3
(773 4
Encoding774 <
.77< =
UTF877= A
.77A B
GetBytes77B J
(77J K
jwt77K N
[77N O
$str77O T
]77T U
!77U V
)77V W
)77W X
,77X Y
RoleClaimType99 
=99 

ClaimTypes99 "
.99" #
Role99# '
,99' (
NameClaimType:: 
=:: 

ClaimTypes:: "
.::" #
NameIdentifier::# 1
,::1 2
	ClockSkew<< 
=<< 
TimeSpan<< 
.<< 
Zero<< !
}== 
;== 
option>> 

.>>
 
Events>> 
=>> 
new>> 
JwtBearerEvents>> '
{?? "
OnAuthenticationFailed@@ 
=@@  
context@@! (
=>@@) +
{AA 	
ConsoleCC 
.CC 
	WriteLineCC 
(CC 
$"CC  
$strCC  +
{CC+ ,
contextCC, 3
.CC3 4
	ExceptionCC4 =
.CC= >
MessageCC> E
}CCE F
"CCF G
)CCG H
;CCH I
returnDD 
TaskDD 
.DD 
CompletedTaskDD %
;DD% &
}EE 	
}FF 
;FF 
}GG 
)GG 
;GG 
builderJJ 
.JJ 
ServicesJJ 
.JJ 
	AddScopedJJ 
(JJ 
typeofJJ !
(JJ! "
IRepositoryJJ" -
<JJ- .
>JJ. /
)JJ/ 0
,JJ0 1
typeofJJ2 8
(JJ8 9

RepositoryJJ9 C
<JJC D
>JJD E
)JJE F
)JJF G
;JJG H
builderKK 
.KK 
ServicesKK 
.KK 
	AddScopedKK 
<KK 
IPatientRepositoryKK -
,KK- .
PatientRepositoryKK/ @
>KK@ A
(KKA B
)KKB C
;KKC D
builderLL 
.LL 
ServicesLL 
.LL 
	AddScopedLL 
<LL 
IDoctorRepositoryLL ,
,LL, -
DoctorRepositoryLL. >
>LL> ?
(LL? @
)LL@ A
;LLA B
builderMM 
.MM 
ServicesMM 
.MM 
	AddScopedMM 
<MM "
IAppointmentRepositoryMM 1
,MM1 2!
AppointmentRepositoryMM3 H
>MMH I
(MMI J
)MMJ K
;MMK L
builderNN 
.NN 
ServicesNN 
.NN 
	AddScopedNN 
<NN #
IHealthRecordRepositoryNN 2
,NN2 3"
HealthRecordRepositoryNN4 J
>NNJ K
(NNK L
)NNL M
;NNM N
builderQQ 
.QQ 
ServicesQQ 
.QQ 
	AddScopedQQ 
<QQ 
IJwtServiceQQ &
,QQ& '

JwtServiceQQ( 2
>QQ2 3
(QQ3 4
)QQ4 5
;QQ5 6
builderRR 
.RR 
ServicesRR 
.RR 
	AddScopedRR 
<RR 
IAuthServiceRR '
,RR' (
AuthServiceRR) 4
>RR4 5
(RR5 6
)RR6 7
;RR7 8
builderSS 
.SS 
ServicesSS 
.SS 
	AddScopedSS 
<SS 
IPatientServiceSS *
,SS* +
PatientServiceSS, :
>SS: ;
(SS; <
)SS< =
;SS= >
builderTT 
.TT 
ServicesTT 
.TT 
	AddScopedTT 
<TT 
IDoctorServiceTT )
,TT) *
DoctorServiceTT+ 8
>TT8 9
(TT9 :
)TT: ;
;TT; <
builderUU 
.UU 
ServicesUU 
.UU 
	AddScopedUU 
<UU 
IAppointmentServiceUU .
,UU. /
AppointmentServiceUU0 B
>UUB C
(UUC D
)UUD E
;UUE F
builderVV 
.VV 
ServicesVV 
.VV 
	AddScopedVV 
<VV  
IHealthRecordServiceVV /
,VV/ 0
HealthRecordServiceVV1 D
>VVD E
(VVE F
)VVF G
;VVG H
builderXX 
.XX 
ServicesXX 
.XX #
AddEndpointsApiExplorerXX (
(XX( )
)XX) *
;XX* +
builderZZ 
.ZZ 
ServicesZZ 
.ZZ 
AddSwaggerGenZZ 
(ZZ 
optionsZZ &
=>ZZ' )
{[[ 
options\\ 
.\\ 

SwaggerDoc\\ 
(\\ 
$str\\ 
,\\ 
new\\  
OpenApiInfo\\! ,
{]] 
Title^^ 
=^^ 
$str^^ 
,^^  
Version__ 
=__ 
$str__ 
}`` 
)`` 
;`` 
optionsbb 
.bb !
AddSecurityDefinitionbb !
(bb! "
$strbb" *
,bb* +
newbb, /!
OpenApiSecuritySchemebb0 E
{cc 
Typedd 
=dd 
SecuritySchemeTypedd !
.dd! "
Httpdd" &
,dd& '
Schemeee 
=ee 
$stree 
,ee 
BearerFormatff 
=ff 
$strff 
,ff 
Descriptiongg 
=gg 
$strgg A
}hh 
)hh 
;hh 
optionsjj 
.jj "
AddSecurityRequirementjj "
(jj" #
documentjj# +
=>jj, .
newjj/ 2&
OpenApiSecurityRequirementjj3 M
{kk 
[ll 	
newll	 *
OpenApiSecuritySchemeReferencell +
(ll+ ,
$strll, 4
,ll4 5
documentll6 >
)ll> ?
]ll? @
=llA B
[llC D
]llD E
}mm 
)mm 
;mm 
}nn 
)nn 
;nn 
varpp 
apppp 
=pp 	
builderpp
 
.pp 
Buildpp 
(pp 
)pp 
;pp 
appqq 
.qq 
UseExceptionHandlerqq 
(qq 
)qq 
;qq 
usingss 
(ss 
varss 

scopess 
=ss 
appss 
.ss 
Servicesss 
.ss  
CreateScopess  +
(ss+ ,
)ss, -
)ss- .
{tt 
varuu 
servicesuu 
=uu 
scopeuu 
.uu 
ServiceProvideruu (
;uu( )
varvv 
roleManagervv 
=vv 
scopevv 
.vv 
ServiceProvidervv +
.vv+ ,
GetRequiredServicevv, >
<vv> ?
RoleManagervv? J
<vvJ K
IdentityRolevvK W
>vvW X
>vvX Y
(vvY Z
)vvZ [
;vv[ \
varww 
userManagerww 
=ww 
servicesww 
.ww 
GetRequiredServiceww 1
<ww1 2
UserManagerww2 =
<ww= >
IdentityUserww> J
>wwJ K
>wwK L
(wwL M
)wwM N
;wwN O
varxx 
configxx 
=xx 
servicesxx 
.xx 
GetRequiredServicexx ,
<xx, -
IConfigurationxx- ;
>xx; <
(xx< =
)xx= >
;xx> ?
awaitzz 	

RoleSeederzz
 
.zz 
SeedRolesAsynczz #
(zz# $
roleManagerzz$ /
)zz/ 0
;zz0 1
await{{ 	

UserSeeder{{
 
.{{ 
SeedAdminAsync{{ #
({{# $
userManager{{$ /
,{{/ 0
roleManager{{1 <
,{{< =
config{{> D
){{D E
;{{E F
}|| 
if 
( 
app 
. 
Environment 
. 
IsDevelopment !
(! "
)" #
)# $
{ÄÄ 
app
ÅÅ 
.
ÅÅ 

UseSwagger
ÅÅ 
(
ÅÅ 
)
ÅÅ 
;
ÅÅ 
app
ÇÇ 
.
ÇÇ 
UseSwaggerUI
ÇÇ 
(
ÇÇ 
)
ÇÇ 
;
ÇÇ 
}ÉÉ 
appÖÖ 
.
ÖÖ !
UseHttpsRedirection
ÖÖ 
(
ÖÖ 
)
ÖÖ 
;
ÖÖ 
appÜÜ 
.
ÜÜ 

UseRouting
ÜÜ 
(
ÜÜ 
)
ÜÜ 
;
ÜÜ 
appáá 
.
áá 
UseAuthentication
áá 
(
áá 
)
áá 
;
áá 
appàà 
.
àà 
UseAuthorization
àà 
(
àà 
)
àà 
;
àà 
appää 
.
ää 
MapControllers
ää 
(
ää 
)
ää 
;
ää 
awaitåå 
app
åå 	
.
åå	 

RunAsync
åå
 
(
åå 
)
åå 
;
åå –
TC:\Users\310055\source\repos\UST-Live-01\HealthCare\HealthCare.Api\Models\Patient.cs
	namespace 	

HealthCare
 
. 
Api 
. 
Models 
{ 
public 

class 
Patient 
{		 
[

 	
Key

	 
]

 
public 
int 
	PatientId 
{ 
get "
;" #
set$ '
;' (
}) *
public 
string 
? 
UserId 
{ 
get  #
;# $
set% (
;( )
}* +
[ 	
Required	 
] 
[ 	
	MaxLength	 
( 
$num 
) 
] 
public 
string 
FullName 
{  
get! $
;$ %
set& )
;) *
}+ ,
=- .
null/ 3
!3 4
;4 5
[ 	
Required	 
] 
public 
DateOnly 
DateOfBirth #
{$ %
get& )
;) *
set+ .
;. /
}0 1
[ 	
Required	 
] 
[ 	
	MaxLength	 
( 
$num 
) 
] 
[ 	
AllowedValues	 
( 
$str 
, 
$str '
,' (
$str) 0
,0 1
ErrorMessage2 >
=? @
$strA i
)i j
]j k
public 
string 
Gender 
{ 
get "
;" #
set$ '
;' (
}) *
=+ ,
null- 1
!1 2
;2 3
[ 	
Required	 
] 
[ 	
	MaxLength	 
( 
$num 
) 
] 
public 
string 
PhoneNumber !
{" #
get$ '
;' (
set) ,
;, -
}. /
=0 1
null2 6
!6 7
;7 8
[ 	
	MaxLength	 
( 
$num 
) 
] 
public   
string   
?   
InsuranceId   "
{  # $
get  % (
;  ( )
set  * -
;  - .
}  / 0
public"" 
bool"" 
IsActive"" 
{"" 
get"" "
;""" #
set""$ '
;""' (
}"") *
=""+ ,
true""- 1
;""1 2
public$$ 
DateTimeOffset$$ 
CreatedDate$$ )
{$$* +
get$$, /
;$$/ 0
set$$1 4
;$$4 5
}$$6 7
['' 	

ForeignKey''	 
('' 
nameof'' 
('' 
UserId'' !
)''! "
)''" #
]''# $
public(( 
IdentityUser(( 
?(( 
User(( !
{((" #
get(($ '
;((' (
set(() ,
;((, -
}((. /
public** 
ICollection** 
<** 
Appointment** &
>**& '
Appointments**( 4
{**5 6
get**7 :
;**: ;
set**< ?
;**? @
}**A B
=**C D
[**E F
]**F G
;**G H
public++ 
ICollection++ 
<++ 
HealthRecord++ '
>++' (
HealthRecords++) 6
{++7 8
get++9 <
;++< =
set++> A
;++A B
}++C D
=++E F
[++G H
]++H I
;++I J
},, 
}-- ü
YC:\Users\310055\source\repos\UST-Live-01\HealthCare\HealthCare.Api\Models\HealthRecord.cs
	namespace 	

HealthCare
 
. 
Api 
. 
Models 
{ 
public 

class 
HealthRecord 
{ 
[ 	
Key	 
] 
public		 
int		 
RecordId		 
{		 
get		 !
;		! "
set		# &
;		& '
}		( )
public 
int 
AppointmentId  
{! "
get# &
;& '
set( +
;+ ,
}- .
public 
int 
	PatientId 
{ 
get "
;" #
set$ '
;' (
}) *
public 
int 
DoctorId 
{ 
get !
;! "
set# &
;& '
}( )
[ 	
Required	 
] 
public 
DateTime 
	VisitDate !
{" #
get$ '
;' (
set) ,
;, -
}. /
[ 	
Required	 
] 
[ 	
	MaxLength	 
( 
$num 
) 
] 
public 
string 
	Diagnosis 
{  !
get" %
;% &
set' *
;* +
}, -
=. /
null0 4
!4 5
;5 6
[ 	
Required	 
] 
[ 	
	MaxLength	 
( 
$num 
) 
] 
public 
string 
Prescription "
{# $
get% (
;( )
set* -
;- .
}/ 0
=1 2
null3 7
!7 8
;8 9
[ 	
	MaxLength	 
( 
$num 
) 
] 
public 
string 
? 
Notes 
{ 
get "
;" #
set$ '
;' (
}) *
public 
DateTimeOffset 
CreatedDate )
{* +
get, /
;/ 0
set1 4
;4 5
}6 7
=8 9
DateTimeOffset: H
.H I
UtcNowI O
;O P
[   	

ForeignKey  	 
(   
nameof   
(   
AppointmentId   (
)  ( )
)  ) *
]  * +
public!! 
Appointment!! 
Appointment!! &
{!!' (
get!!) ,
;!!, -
set!!. 1
;!!1 2
}!!3 4
=!!5 6
null!!7 ;
!!!; <
;!!< =
[## 	

ForeignKey##	 
(## 
nameof## 
(## 
	PatientId## $
)##$ %
)##% &
]##& '
public$$ 
Patient$$ 
Patient$$ 
{$$  
get$$! $
;$$$ %
set$$& )
;$$) *
}$$+ ,
=$$- .
null$$/ 3
!$$3 4
;$$4 5
[&& 	

ForeignKey&&	 
(&& 
nameof&& 
(&& 
DoctorId&& #
)&&# $
)&&$ %
]&&% &
public'' 
Doctor'' 
Doctor'' 
{'' 
get'' "
;''" #
set''$ '
;''' (
}'') *
=''+ ,
null''- 1
!''1 2
;''2 3
}(( 
})) ˘
YC:\Users\310055\source\repos\UST-Live-01\HealthCare\HealthCare.Api\Models\DoctorLeaves.cs
	namespace 	

HealthCare
 
. 
Api 
. 
Models 
{ 
public 

class 
DoctorLeaves 
{ 
[ 	
Key	 
] 
public		 
int		 
Id		 
{		 
get		 
;		 
set		  
;		  !
}		" #
public 
int 
DoctorId 
{ 
get !
;! "
set# &
;& '
}( )
[ 	
Required	 
] 
public 
DateOnly 
	LeaveDate !
{" #
get$ '
;' (
set) ,
;, -
}. /
[ 	
	MaxLength	 
( 
$num 
) 
] 
public 
string 
? 
Reason 
{ 
get  #
;# $
set% (
;( )
}* +
public 
DateTimeOffset 
CreatedDate )
{* +
get, /
;/ 0
set1 4
;4 5
}6 7
=8 9
DateTimeOffset: H
.H I
UtcNowI O
;O P
[ 	

ForeignKey	 
( 
nameof 
( 
DoctorId #
)# $
)$ %
]% &
public 
Doctor 
Doctor 
{ 
get "
;" #
set$ '
;' (
}) *
=+ ,
null- 1
!1 2
;2 3
} 
} …!
SC:\Users\310055\source\repos\UST-Live-01\HealthCare\HealthCare.Api\Models\Doctor.cs
	namespace 	

HealthCare
 
. 
Api 
. 
Models 
{ 
[		 
Index		 

(		
 
nameof		 
(		 
Specialisation		  
)		  !
,		! "
Name		# '
=		( )
$str		* E
)		E F
]		F G
public

 

class

 
Doctor

 
{ 
[ 	
Key	 
] 
public 
int 
DoctorId 
{ 
get !
;! "
set# &
;& '
}( )
public 
string 
? 
UserId 
{ 
get  #
;# $
set% (
;( )
}* +
[ 	
Required	 
] 
[ 	
	MaxLength	 
( 
$num 
) 
] 
public 
string 
FullName 
{  
get! $
;$ %
set& )
;) *
}+ ,
=- .
null/ 3
!3 4
;4 5
[ 	
Required	 
] 
[ 	
	MaxLength	 
( 
$num 
) 
] 
public 
string 
Specialisation $
{% &
get' *
;* +
set, /
;/ 0
}1 2
=3 4
null5 9
!9 :
;: ;
[ 	
Required	 
] 
[ 	
Range	 
( 
$num 
, 
$num 
) 
] 
public 
int 
YearsOfExperience $
{% &
get' *
;* +
set, /
;/ 0
}1 2
[ 	
Required	 
] 
[ 	
Column	 
( 
TypeName 
= 
$str *
)* +
]+ ,
[ 	
Range	 
( 
$num 
, 
$num 
) 
] 
public   
decimal   
ConsultationFee   &
{  ' (
get  ) ,
;  , -
set  . 1
;  1 2
}  3 4
public"" 
bool"" 
IsActive"" 
{"" 
get"" "
;""" #
set""$ '
;""' (
}"") *
=""+ ,
true""- 1
;""1 2
public$$ 
DateTimeOffset$$ 
CreatedDate$$ )
{$$* +
get$$, /
;$$/ 0
set$$1 4
;$$4 5
}$$6 7
['' 	

ForeignKey''	 
('' 
nameof'' 
('' 
UserId'' !
)''! "
)''" #
]''# $
public(( 
IdentityUser(( 
?(( 
User(( !
{((" #
get(($ '
;((' (
set(() ,
;((, -
}((. /
public** 
ICollection** 
<** 
Appointment** &
>**& '
Appointments**( 4
{**5 6
get**7 :
;**: ;
set**< ?
;**? @
}**A B
=**C D
[**E F
]**F G
;**G H
public++ 
ICollection++ 
<++ 
HealthRecord++ '
>++' (
HealthRecords++) 6
{++7 8
get++9 <
;++< =
set++> A
;++A B
}++C D
=++E F
[++G H
]++H I
;++I J
public,, 
ICollection,, 
<,, 
AvailableSlots,, )
>,,) *
AvailableSlots,,+ 9
{,,: ;
get,,< ?
;,,? @
set,,A D
;,,D E
},,F G
=,,H I
[,,J K
],,K L
;,,L M
public-- 
ICollection-- 
<-- 
DoctorLeaves-- '
>--' (
Leaves--) /
{--0 1
get--2 5
;--5 6
set--7 :
;--: ;
}--< =
=--> ?
[--@ A
]--A B
;--B C
}.. 
}// ê
[C:\Users\310055\source\repos\UST-Live-01\HealthCare\HealthCare.Api\Models\AvailableSlots.cs
	namespace 	

HealthCare
 
. 
Api 
. 
Models 
{ 
public 

class 
AvailableSlots 
{ 
[ 	
Key	 
] 
public		 
int		 
Id		 
{		 
get		 
;		 
set		  
;		  !
}		" #
public 
int 
DoctorId 
{ 
get !
;! "
set# &
;& '
}( )
[ 	
Required	 
] 
[ 	
	MaxLength	 
( 
$num 
) 
] 
public 
string 
TimeSlot 
{  
get! $
;$ %
set& )
;) *
}+ ,
=- .
null/ 3
!3 4
;4 5
public 
DateTimeOffset 
CreatedDate )
{* +
get, /
;/ 0
set1 4
;4 5
}6 7
=8 9
DateTimeOffset: H
.H I
UtcNowI O
;O P
[ 	

ForeignKey	 
( 
nameof 
( 
DoctorId #
)# $
)$ %
]% &
public 
Doctor 
Doctor 
{ 
get "
;" #
set$ '
;' (
}) *
=+ ,
null- 1
!1 2
;2 3
} 
} ˚
YC:\Users\310055\source\repos\UST-Live-01\HealthCare\HealthCare.Api\Models\AuthResponse.cs
	namespace 	

HealthCare
 
. 
Api 
. 
Models 
{ 
public 

class 
AuthResponse 
{ 
public 
string 
AccessToken !
{" #
get$ '
;' (
set) ,
;, -
}. /
=0 1
string2 8
.8 9
Empty9 >
;> ?
public 
string 
? 
Message 
{  
get! $
;$ %
set& )
;) *
}+ ,
public 
int 
	ExpiresIn 
{ 
get "
;" #
set$ '
;' (
}) *
} 
}		 ∆
XC:\Users\310055\source\repos\UST-Live-01\HealthCare\HealthCare.Api\Models\Appointment.cs
	namespace 	

HealthCare
 
. 
Api 
. 
Models 
{ 
public 

class 
Appointment 
{ 
[		 	
Key			 
]		 
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
public 
int 
	PatientId 
{ 
get "
;" #
set$ '
;' (
}) *
public 
int 
DoctorId 
{ 
get !
;! "
set# &
;& '
}( )
[ 	
Required	 
] 
public 
DateOnly 
ScheduledDate %
{& '
get( +
;+ ,
set- 0
;0 1
}2 3
[ 	
Required	 
] 
[ 	
	MaxLength	 
( 
$num 
) 
] 
public 
string 
TimeSlot 
{  
get! $
;$ %
set& )
;) *
}+ ,
=- .
null/ 3
!3 4
;4 5
[ 	
Required	 
] 
[ 	
	MaxLength	 
( 
$num 
) 
] 
[ 	
AllowedValues	 
( 
$str  
,  !
$str" -
,- .
$str/ :
,: ;
$str< G
,G H
ErrorMessage 
= 
$str X
)X Y
]Y Z
public 
string 
Status 
{ 
get "
;" #
set$ '
;' (
}) *
=+ ,
$str- 6
;6 7
[ 	
	MaxLength	 
( 
$num 
) 
] 
public 
string 
? 
CancellationReason )
{* +
get, /
;/ 0
set1 4
;4 5
}6 7
public 
DateTimeOffset 
CreatedDate )
{* +
get, /
;/ 0
set1 4
;4 5
}6 7
=8 9
DateTimeOffset: H
.H I
UtcNowI O
;O P
["" 	

ForeignKey""	 
("" 
nameof"" 
("" 
	PatientId"" $
)""$ %
)""% &
]""& '
public## 
Patient## 
Patient## 
{##  
get##! $
;##$ %
set##& )
;##) *
}##+ ,
=##- .
null##/ 3
!##3 4
;##4 5
[%% 	

ForeignKey%%	 
(%% 
nameof%% 
(%% 
DoctorId%% #
)%%# $
)%%$ %
]%%% &
public&& 
Doctor&& 
Doctor&& 
{&& 
get&& "
;&&" #
set&&$ '
;&&' (
}&&) *
=&&+ ,
null&&- 1
!&&1 2
;&&2 3
public(( 
HealthRecord(( 
?(( 
HealthRecord(( )
{((* +
get((, /
;((/ 0
set((1 4
;((4 5
}((6 7
})) 
}** ø]
mC:\Users\310055\source\repos\UST-Live-01\HealthCare\HealthCare.Api\Migrations\20260619153122_EverythingSet.cs
	namespace 	

HealthCare
 
. 
Api 
. 

Migrations #
{ 
public 

partial 
class 
everythingset &
:' (
	Migration) 2
{		 
	protected 
override 
void 
Up  "
(" #
MigrationBuilder# 3
migrationBuilder4 D
)D E
{ 	
migrationBuilder 
. 
DropForeignKey +
(+ ,
name 
: 
$str @
,@ A
table 
: 
$str -
)- .
;. /
migrationBuilder 
. 
DropForeignKey +
(+ ,
name 
: 
$str 6
,6 7
table 
: 
$str  
)  !
;! "
migrationBuilder 
. 
DropForeignKey +
(+ ,
name 
: 
$str 7
,7 8
table 
: 
$str !
)! "
;" #
migrationBuilder 
. 
	DropIndex &
(& '
name 
: 
$str *
,* +
table 
: 
$str !
)! "
;" #
migrationBuilder 
. 
	DropIndex &
(& '
name 
: 
$str +
,+ ,
table 
: 
$str !
)! "
;" #
migrationBuilder!! 
.!! 
	DropIndex!! &
(!!& '
name"" 
:"" 
$str"" )
,"") *
table## 
:## 
$str##  
)##  !
;##! "
migrationBuilder%% 
.%% 
	DropIndex%% &
(%%& '
name&& 
:&& 
$str&& *
,&&* +
table'' 
:'' 
$str''  
)''  !
;''! "
migrationBuilder)) 
.)) 
DropPrimaryKey)) +
())+ ,
name** 
:** 
$str** /
,**/ 0
table++ 
:++ 
$str++ -
)++- .
;++. /
migrationBuilder-- 
.-- 

DropColumn-- '
(--' (
name.. 
:.. 
$str.. 
,..  
table// 
:// 
$str// !
)//! "
;//" #
migrationBuilder11 
.11 

DropColumn11 '
(11' (
name22 
:22 
$str22 
,22  
table33 
:33 
$str33  
)33  !
;33! "
migrationBuilder55 
.55 
RenameTable55 (
(55( )
name66 
:66 
$str66 ,
,66, -
newName77 
:77 
$str77 )
)77) *
;77* +
migrationBuilder99 
.99 
RenameIndex99 (
(99( )
name:: 
::: 
$str:: 8
,::8 9
table;; 
:;; 
$str;; '
,;;' (
newName<< 
:<< 
$str<< 5
)<<5 6
;<<6 7
migrationBuilder>> 
.>> 
	AddColumn>> &
<>>& '
string>>' -
>>>- .
(>>. /
name?? 
:?? 
$str?? %
,??% &
table@@ 
:@@ 
$str@@ $
,@@$ %
typeAA 
:AA 
$strAA $
,AA$ %
	maxLengthBB 
:BB 
$numBB 
,BB 
nullableCC 
:CC 
falseCC 
,CC  
defaultValueDD 
:DD 
$strDD  
)DD  !
;DD! "
migrationBuilderFF 
.FF 
AddPrimaryKeyFF *
(FF* +
nameGG 
:GG 
$strGG )
,GG) *
tableHH 
:HH 
$strHH '
,HH' (
columnII 
:II 
$strII 
)II 
;II 
migrationBuilderKK 
.KK 
CreateIndexKK (
(KK( )
nameLL 
:LL 
$strLL *
,LL* +
tableMM 
:MM 
$strMM !
,MM! "
columnNN 
:NN 
$strNN  
,NN  !
uniqueOO 
:OO 
trueOO 
,OO 
filterPP 
:PP 
$strPP .
)PP. /
;PP/ 0
migrationBuilderRR 
.RR 
CreateIndexRR (
(RR( )
nameSS 
:SS 
$strSS )
,SS) *
tableTT 
:TT 
$strTT  
,TT  !
columnUU 
:UU 
$strUU  
,UU  !
uniqueVV 
:VV 
trueVV 
,VV 
filterWW 
:WW 
$strWW .
)WW. /
;WW/ 0
migrationBuilderYY 
.YY 
AddForeignKeyYY *
(YY* +
nameZZ 
:ZZ 
$strZZ :
,ZZ: ;
table[[ 
:[[ 
$str[[ '
,[[' (
column\\ 
:\\ 
$str\\ "
,\\" #
principalTable]] 
:]] 
$str]]  )
,]]) *
principalColumn^^ 
:^^  
$str^^! +
,^^+ ,
onDelete__ 
:__ 
ReferentialAction__ +
.__+ ,
Cascade__, 3
)__3 4
;__4 5
}`` 	
	protectedcc 
overridecc 
voidcc 
Downcc  $
(cc$ %
MigrationBuildercc% 5
migrationBuildercc6 F
)ccF G
{dd 	
migrationBuilderee 
.ee 
DropForeignKeyee +
(ee+ ,
nameff 
:ff 
$strff :
,ff: ;
tablegg 
:gg 
$strgg '
)gg' (
;gg( )
migrationBuilderii 
.ii 
	DropIndexii &
(ii& '
namejj 
:jj 
$strjj *
,jj* +
tablekk 
:kk 
$strkk !
)kk! "
;kk" #
migrationBuildermm 
.mm 
	DropIndexmm &
(mm& '
namenn 
:nn 
$strnn )
,nn) *
tableoo 
:oo 
$stroo  
)oo  !
;oo! "
migrationBuilderqq 
.qq 
DropPrimaryKeyqq +
(qq+ ,
namerr 
:rr 
$strrr )
,rr) *
tabless 
:ss 
$strss '
)ss' (
;ss( )
migrationBuilderuu 
.uu 

DropColumnuu '
(uu' (
namevv 
:vv 
$strvv %
,vv% &
tableww 
:ww 
$strww $
)ww$ %
;ww% &
migrationBuilderyy 
.yy 
RenameTableyy (
(yy( )
namezz 
:zz 
$strzz &
,zz& '
newName{{ 
:{{ 
$str{{ /
){{/ 0
;{{0 1
migrationBuilder}} 
.}} 
RenameIndex}} (
(}}( )
name~~ 
:~~ 
$str~~ 2
,~~2 3
table 
: 
$str -
,- .
newName
ÄÄ 
:
ÄÄ 
$str
ÄÄ ;
)
ÄÄ; <
;
ÄÄ< =
migrationBuilder
ÇÇ 
.
ÇÇ 
	AddColumn
ÇÇ &
<
ÇÇ& '
string
ÇÇ' -
>
ÇÇ- .
(
ÇÇ. /
name
ÉÉ 
:
ÉÉ 
$str
ÉÉ 
,
ÉÉ  
table
ÑÑ 
:
ÑÑ 
$str
ÑÑ !
,
ÑÑ! "
type
ÖÖ 
:
ÖÖ 
$str
ÖÖ %
,
ÖÖ% &
nullable
ÜÜ 
:
ÜÜ 
true
ÜÜ 
)
ÜÜ 
;
ÜÜ  
migrationBuilder
àà 
.
àà 
	AddColumn
àà &
<
àà& '
string
àà' -
>
àà- .
(
àà. /
name
ââ 
:
ââ 
$str
ââ 
,
ââ  
table
ää 
:
ää 
$str
ää  
,
ää  !
type
ãã 
:
ãã 
$str
ãã %
,
ãã% &
nullable
åå 
:
åå 
true
åå 
)
åå 
;
åå  
migrationBuilder
éé 
.
éé 
AddPrimaryKey
éé *
(
éé* +
name
èè 
:
èè 
$str
èè /
,
èè/ 0
table
êê 
:
êê 
$str
êê -
,
êê- .
column
ëë 
:
ëë 
$str
ëë 
)
ëë 
;
ëë 
migrationBuilder
ìì 
.
ìì 
CreateIndex
ìì (
(
ìì( )
name
îî 
:
îî 
$str
îî *
,
îî* +
table
ïï 
:
ïï 
$str
ïï !
,
ïï! "
column
ññ 
:
ññ 
$str
ññ  
)
ññ  !
;
ññ! "
migrationBuilder
òò 
.
òò 
CreateIndex
òò (
(
òò( )
name
ôô 
:
ôô 
$str
ôô +
,
ôô+ ,
table
öö 
:
öö 
$str
öö !
,
öö! "
column
õõ 
:
õõ 
$str
õõ !
)
õõ! "
;
õõ" #
migrationBuilder
ùù 
.
ùù 
CreateIndex
ùù (
(
ùù( )
name
ûû 
:
ûû 
$str
ûû )
,
ûû) *
table
üü 
:
üü 
$str
üü  
,
üü  !
column
†† 
:
†† 
$str
††  
)
††  !
;
††! "
migrationBuilder
¢¢ 
.
¢¢ 
CreateIndex
¢¢ (
(
¢¢( )
name
££ 
:
££ 
$str
££ *
,
££* +
table
§§ 
:
§§ 
$str
§§  
,
§§  !
column
•• 
:
•• 
$str
•• !
)
••! "
;
••" #
migrationBuilder
ßß 
.
ßß 
AddForeignKey
ßß *
(
ßß* +
name
®® 
:
®® 
$str
®® @
,
®®@ A
table
©© 
:
©© 
$str
©© -
,
©©- .
column
™™ 
:
™™ 
$str
™™ "
,
™™" #
principalTable
´´ 
:
´´ 
$str
´´  )
,
´´) *
principalColumn
¨¨ 
:
¨¨  
$str
¨¨! +
,
¨¨+ ,
onDelete
≠≠ 
:
≠≠ 
ReferentialAction
≠≠ +
.
≠≠+ ,
Cascade
≠≠, 3
)
≠≠3 4
;
≠≠4 5
migrationBuilder
ØØ 
.
ØØ 
AddForeignKey
ØØ *
(
ØØ* +
name
∞∞ 
:
∞∞ 
$str
∞∞ 6
,
∞∞6 7
table
±± 
:
±± 
$str
±±  
,
±±  !
column
≤≤ 
:
≤≤ 
$str
≤≤ !
,
≤≤! "
principalTable
≥≥ 
:
≥≥ 
$str
≥≥  -
,
≥≥- .
principalColumn
¥¥ 
:
¥¥  
$str
¥¥! %
)
¥¥% &
;
¥¥& '
migrationBuilder
∂∂ 
.
∂∂ 
AddForeignKey
∂∂ *
(
∂∂* +
name
∑∑ 
:
∑∑ 
$str
∑∑ 7
,
∑∑7 8
table
∏∏ 
:
∏∏ 
$str
∏∏ !
,
∏∏! "
column
ππ 
:
ππ 
$str
ππ !
,
ππ! "
principalTable
∫∫ 
:
∫∫ 
$str
∫∫  -
,
∫∫- .
principalColumn
ªª 
:
ªª  
$str
ªª! %
)
ªª% &
;
ªª& '
}
ºº 	
}
ΩΩ 
}ææ ‡“
gC:\Users\310055\source\repos\UST-Live-01\HealthCare\HealthCare.Api\Migrations\20260619031923_ItlCrte.cs
	namespace 	

HealthCare
 
. 
Api 
. 

Migrations #
{ 
public		 

partial		 
class		 
itlcrte		  
:		! "
	Migration		# ,
{

 
	protected 
override 
void 
Up  "
(" #
MigrationBuilder# 3
migrationBuilder4 D
)D E
{ 	
migrationBuilder 
. 
CreateTable (
(( )
name 
: 
$str #
,# $
columns 
: 
table 
=> !
new" %
{ 
Id 
= 
table 
. 
Column %
<% &
string& ,
>, -
(- .
type. 2
:2 3
$str4 C
,C D
nullableE M
:M N
falseO T
)T U
,U V
Name 
= 
table  
.  !
Column! '
<' (
string( .
>. /
(/ 0
type0 4
:4 5
$str6 E
,E F
	maxLengthG P
:P Q
$numR U
,U V
nullableW _
:_ `
truea e
)e f
,f g
NormalizedName "
=# $
table% *
.* +
Column+ 1
<1 2
string2 8
>8 9
(9 :
type: >
:> ?
$str@ O
,O P
	maxLengthQ Z
:Z [
$num\ _
,_ `
nullablea i
:i j
truek o
)o p
,p q
ConcurrencyStamp $
=% &
table' ,
., -
Column- 3
<3 4
string4 :
>: ;
(; <
type< @
:@ A
$strB Q
,Q R
nullableS [
:[ \
true] a
)a b
} 
, 
constraints 
: 
table "
=># %
{ 
table 
. 

PrimaryKey $
($ %
$str% 5
,5 6
x7 8
=>9 ;
x< =
.= >
Id> @
)@ A
;A B
} 
) 
; 
migrationBuilder 
. 
CreateTable (
(( )
name 
: 
$str #
,# $
columns 
: 
table 
=> !
new" %
{ 
Id   
=   
table   
.   
Column   %
<  % &
string  & ,
>  , -
(  - .
type  . 2
:  2 3
$str  4 C
,  C D
nullable  E M
:  M N
false  O T
)  T U
,  U V
UserName!! 
=!! 
table!! $
.!!$ %
Column!!% +
<!!+ ,
string!!, 2
>!!2 3
(!!3 4
type!!4 8
:!!8 9
$str!!: I
,!!I J
	maxLength!!K T
:!!T U
$num!!V Y
,!!Y Z
nullable!![ c
:!!c d
true!!e i
)!!i j
,!!j k
NormalizedUserName"" &
=""' (
table"") .
."". /
Column""/ 5
<""5 6
string""6 <
>""< =
(""= >
type""> B
:""B C
$str""D S
,""S T
	maxLength""U ^
:""^ _
$num""` c
,""c d
nullable""e m
:""m n
true""o s
)""s t
,""t u
Email## 
=## 
table## !
.##! "
Column##" (
<##( )
string##) /
>##/ 0
(##0 1
type##1 5
:##5 6
$str##7 F
,##F G
	maxLength##H Q
:##Q R
$num##S V
,##V W
nullable##X `
:##` a
true##b f
)##f g
,##g h
NormalizedEmail$$ #
=$$$ %
table$$& +
.$$+ ,
Column$$, 2
<$$2 3
string$$3 9
>$$9 :
($$: ;
type$$; ?
:$$? @
$str$$A P
,$$P Q
	maxLength$$R [
:$$[ \
$num$$] `
,$$` a
nullable$$b j
:$$j k
true$$l p
)$$p q
,$$q r
EmailConfirmed%% "
=%%# $
table%%% *
.%%* +
Column%%+ 1
<%%1 2
bool%%2 6
>%%6 7
(%%7 8
type%%8 <
:%%< =
$str%%> C
,%%C D
nullable%%E M
:%%M N
false%%O T
)%%T U
,%%U V
PasswordHash&&  
=&&! "
table&&# (
.&&( )
Column&&) /
<&&/ 0
string&&0 6
>&&6 7
(&&7 8
type&&8 <
:&&< =
$str&&> M
,&&M N
nullable&&O W
:&&W X
true&&Y ]
)&&] ^
,&&^ _
SecurityStamp'' !
=''" #
table''$ )
.'') *
Column''* 0
<''0 1
string''1 7
>''7 8
(''8 9
type''9 =
:''= >
$str''? N
,''N O
nullable''P X
:''X Y
true''Z ^
)''^ _
,''_ `
ConcurrencyStamp(( $
=((% &
table((' ,
.((, -
Column((- 3
<((3 4
string((4 :
>((: ;
(((; <
type((< @
:((@ A
$str((B Q
,((Q R
nullable((S [
:(([ \
true((] a
)((a b
,((b c
PhoneNumber)) 
=))  !
table))" '
.))' (
Column))( .
<)). /
string))/ 5
>))5 6
())6 7
type))7 ;
:)); <
$str))= L
,))L M
nullable))N V
:))V W
true))X \
)))\ ]
,))] ^ 
PhoneNumberConfirmed** (
=**) *
table**+ 0
.**0 1
Column**1 7
<**7 8
bool**8 <
>**< =
(**= >
type**> B
:**B C
$str**D I
,**I J
nullable**K S
:**S T
false**U Z
)**Z [
,**[ \
TwoFactorEnabled++ $
=++% &
table++' ,
.++, -
Column++- 3
<++3 4
bool++4 8
>++8 9
(++9 :
type++: >
:++> ?
$str++@ E
,++E F
nullable++G O
:++O P
false++Q V
)++V W
,++W X

LockoutEnd,, 
=,,  
table,,! &
.,,& '
Column,,' -
<,,- .
DateTimeOffset,,. <
>,,< =
(,,= >
type,,> B
:,,B C
$str,,D T
,,,T U
nullable,,V ^
:,,^ _
true,,` d
),,d e
,,,e f
LockoutEnabled-- "
=--# $
table--% *
.--* +
Column--+ 1
<--1 2
bool--2 6
>--6 7
(--7 8
type--8 <
:--< =
$str--> C
,--C D
nullable--E M
:--M N
false--O T
)--T U
,--U V
AccessFailedCount.. %
=..& '
table..( -
...- .
Column... 4
<..4 5
int..5 8
>..8 9
(..9 :
type..: >
:..> ?
$str..@ E
,..E F
nullable..G O
:..O P
false..Q V
)..V W
}// 
,// 
constraints00 
:00 
table00 "
=>00# %
{11 
table22 
.22 

PrimaryKey22 $
(22$ %
$str22% 5
,225 6
x227 8
=>229 ;
x22< =
.22= >
Id22> @
)22@ A
;22A B
}33 
)33 
;33 
migrationBuilder55 
.55 
CreateTable55 (
(55( )
name66 
:66 
$str66 (
,66( )
columns77 
:77 
table77 
=>77 !
new77" %
{88 
Id99 
=99 
table99 
.99 
Column99 %
<99% &
int99& )
>99) *
(99* +
type99+ /
:99/ 0
$str991 6
,996 7
nullable998 @
:99@ A
false99B G
)99G H
.:: 

Annotation:: #
(::# $
$str::$ 8
,::8 9
$str::: @
)::@ A
,::A B
RoleId;; 
=;; 
table;; "
.;;" #
Column;;# )
<;;) *
string;;* 0
>;;0 1
(;;1 2
type;;2 6
:;;6 7
$str;;8 G
,;;G H
nullable;;I Q
:;;Q R
false;;S X
);;X Y
,;;Y Z
	ClaimType<< 
=<< 
table<<  %
.<<% &
Column<<& ,
<<<, -
string<<- 3
><<3 4
(<<4 5
type<<5 9
:<<9 :
$str<<; J
,<<J K
nullable<<L T
:<<T U
true<<V Z
)<<Z [
,<<[ \

ClaimValue== 
===  
table==! &
.==& '
Column==' -
<==- .
string==. 4
>==4 5
(==5 6
type==6 :
:==: ;
$str==< K
,==K L
nullable==M U
:==U V
true==W [
)==[ \
}>> 
,>> 
constraints?? 
:?? 
table?? "
=>??# %
{@@ 
tableAA 
.AA 

PrimaryKeyAA $
(AA$ %
$strAA% :
,AA: ;
xAA< =
=>AA> @
xAAA B
.AAB C
IdAAC E
)AAE F
;AAF G
tableBB 
.BB 

ForeignKeyBB $
(BB$ %
nameCC 
:CC 
$strCC F
,CCF G
columnDD 
:DD 
xDD  !
=>DD" $
xDD% &
.DD& '
RoleIdDD' -
,DD- .
principalTableEE &
:EE& '
$strEE( 5
,EE5 6
principalColumnFF '
:FF' (
$strFF) -
,FF- .
onDeleteGG  
:GG  !
ReferentialActionGG" 3
.GG3 4
CascadeGG4 ;
)GG; <
;GG< =
}HH 
)HH 
;HH 
migrationBuilderJJ 
.JJ 
CreateTableJJ (
(JJ( )
nameKK 
:KK 
$strKK (
,KK( )
columnsLL 
:LL 
tableLL 
=>LL !
newLL" %
{MM 
IdNN 
=NN 
tableNN 
.NN 
ColumnNN %
<NN% &
intNN& )
>NN) *
(NN* +
typeNN+ /
:NN/ 0
$strNN1 6
,NN6 7
nullableNN8 @
:NN@ A
falseNNB G
)NNG H
.OO 

AnnotationOO #
(OO# $
$strOO$ 8
,OO8 9
$strOO: @
)OO@ A
,OOA B
UserIdPP 
=PP 
tablePP "
.PP" #
ColumnPP# )
<PP) *
stringPP* 0
>PP0 1
(PP1 2
typePP2 6
:PP6 7
$strPP8 G
,PPG H
nullablePPI Q
:PPQ R
falsePPS X
)PPX Y
,PPY Z
	ClaimTypeQQ 
=QQ 
tableQQ  %
.QQ% &
ColumnQQ& ,
<QQ, -
stringQQ- 3
>QQ3 4
(QQ4 5
typeQQ5 9
:QQ9 :
$strQQ; J
,QQJ K
nullableQQL T
:QQT U
trueQQV Z
)QQZ [
,QQ[ \

ClaimValueRR 
=RR  
tableRR! &
.RR& '
ColumnRR' -
<RR- .
stringRR. 4
>RR4 5
(RR5 6
typeRR6 :
:RR: ;
$strRR< K
,RRK L
nullableRRM U
:RRU V
trueRRW [
)RR[ \
}SS 
,SS 
constraintsTT 
:TT 
tableTT "
=>TT# %
{UU 
tableVV 
.VV 

PrimaryKeyVV $
(VV$ %
$strVV% :
,VV: ;
xVV< =
=>VV> @
xVVA B
.VVB C
IdVVC E
)VVE F
;VVF G
tableWW 
.WW 

ForeignKeyWW $
(WW$ %
nameXX 
:XX 
$strXX F
,XXF G
columnYY 
:YY 
xYY  !
=>YY" $
xYY% &
.YY& '
UserIdYY' -
,YY- .
principalTableZZ &
:ZZ& '
$strZZ( 5
,ZZ5 6
principalColumn[[ '
:[[' (
$str[[) -
,[[- .
onDelete\\  
:\\  !
ReferentialAction\\" 3
.\\3 4
Cascade\\4 ;
)\\; <
;\\< =
}]] 
)]] 
;]] 
migrationBuilder__ 
.__ 
CreateTable__ (
(__( )
name`` 
:`` 
$str`` (
,``( )
columnsaa 
:aa 
tableaa 
=>aa !
newaa" %
{bb 
LoginProvidercc !
=cc" #
tablecc$ )
.cc) *
Columncc* 0
<cc0 1
stringcc1 7
>cc7 8
(cc8 9
typecc9 =
:cc= >
$strcc? N
,ccN O
nullableccP X
:ccX Y
falseccZ _
)cc_ `
,cc` a
ProviderKeydd 
=dd  !
tabledd" '
.dd' (
Columndd( .
<dd. /
stringdd/ 5
>dd5 6
(dd6 7
typedd7 ;
:dd; <
$strdd= L
,ddL M
nullableddN V
:ddV W
falseddX ]
)dd] ^
,dd^ _
ProviderDisplayNameee '
=ee( )
tableee* /
.ee/ 0
Columnee0 6
<ee6 7
stringee7 =
>ee= >
(ee> ?
typeee? C
:eeC D
$streeE T
,eeT U
nullableeeV ^
:ee^ _
trueee` d
)eed e
,eee f
UserIdff 
=ff 
tableff "
.ff" #
Columnff# )
<ff) *
stringff* 0
>ff0 1
(ff1 2
typeff2 6
:ff6 7
$strff8 G
,ffG H
nullableffI Q
:ffQ R
falseffS X
)ffX Y
}gg 
,gg 
constraintshh 
:hh 
tablehh "
=>hh# %
{ii 
tablejj 
.jj 

PrimaryKeyjj $
(jj$ %
$strjj% :
,jj: ;
xjj< =
=>jj> @
newjjA D
{jjE F
xjjG H
.jjH I
LoginProviderjjI V
,jjV W
xjjX Y
.jjY Z
ProviderKeyjjZ e
}jjf g
)jjg h
;jjh i
tablekk 
.kk 

ForeignKeykk $
(kk$ %
namell 
:ll 
$strll F
,llF G
columnmm 
:mm 
xmm  !
=>mm" $
xmm% &
.mm& '
UserIdmm' -
,mm- .
principalTablenn &
:nn& '
$strnn( 5
,nn5 6
principalColumnoo '
:oo' (
$stroo) -
,oo- .
onDeletepp  
:pp  !
ReferentialActionpp" 3
.pp3 4
Cascadepp4 ;
)pp; <
;pp< =
}qq 
)qq 
;qq 
migrationBuilderss 
.ss 
CreateTabless (
(ss( )
namett 
:tt 
$strtt '
,tt' (
columnsuu 
:uu 
tableuu 
=>uu !
newuu" %
{vv 
UserIdww 
=ww 
tableww "
.ww" #
Columnww# )
<ww) *
stringww* 0
>ww0 1
(ww1 2
typeww2 6
:ww6 7
$strww8 G
,wwG H
nullablewwI Q
:wwQ R
falsewwS X
)wwX Y
,wwY Z
RoleIdxx 
=xx 
tablexx "
.xx" #
Columnxx# )
<xx) *
stringxx* 0
>xx0 1
(xx1 2
typexx2 6
:xx6 7
$strxx8 G
,xxG H
nullablexxI Q
:xxQ R
falsexxS X
)xxX Y
}yy 
,yy 
constraintszz 
:zz 
tablezz "
=>zz# %
{{{ 
table|| 
.|| 

PrimaryKey|| $
(||$ %
$str||% 9
,||9 :
x||; <
=>||= ?
new||@ C
{||D E
x||F G
.||G H
UserId||H N
,||N O
x||P Q
.||Q R
RoleId||R X
}||Y Z
)||Z [
;||[ \
table}} 
.}} 

ForeignKey}} $
(}}$ %
name~~ 
:~~ 
$str~~ E
,~~E F
column 
: 
x  !
=>" $
x% &
.& '
RoleId' -
,- .
principalTable
ÄÄ &
:
ÄÄ& '
$str
ÄÄ( 5
,
ÄÄ5 6
principalColumn
ÅÅ '
:
ÅÅ' (
$str
ÅÅ) -
,
ÅÅ- .
onDelete
ÇÇ  
:
ÇÇ  !
ReferentialAction
ÇÇ" 3
.
ÇÇ3 4
Cascade
ÇÇ4 ;
)
ÇÇ; <
;
ÇÇ< =
table
ÉÉ 
.
ÉÉ 

ForeignKey
ÉÉ $
(
ÉÉ$ %
name
ÑÑ 
:
ÑÑ 
$str
ÑÑ E
,
ÑÑE F
column
ÖÖ 
:
ÖÖ 
x
ÖÖ  !
=>
ÖÖ" $
x
ÖÖ% &
.
ÖÖ& '
UserId
ÖÖ' -
,
ÖÖ- .
principalTable
ÜÜ &
:
ÜÜ& '
$str
ÜÜ( 5
,
ÜÜ5 6
principalColumn
áá '
:
áá' (
$str
áá) -
,
áá- .
onDelete
àà  
:
àà  !
ReferentialAction
àà" 3
.
àà3 4
Cascade
àà4 ;
)
àà; <
;
àà< =
}
ââ 
)
ââ 
;
ââ 
migrationBuilder
ãã 
.
ãã 
CreateTable
ãã (
(
ãã( )
name
åå 
:
åå 
$str
åå (
,
åå( )
columns
çç 
:
çç 
table
çç 
=>
çç !
new
çç" %
{
éé 
UserId
èè 
=
èè 
table
èè "
.
èè" #
Column
èè# )
<
èè) *
string
èè* 0
>
èè0 1
(
èè1 2
type
èè2 6
:
èè6 7
$str
èè8 G
,
èèG H
nullable
èèI Q
:
èèQ R
false
èèS X
)
èèX Y
,
èèY Z
LoginProvider
êê !
=
êê" #
table
êê$ )
.
êê) *
Column
êê* 0
<
êê0 1
string
êê1 7
>
êê7 8
(
êê8 9
type
êê9 =
:
êê= >
$str
êê? N
,
êêN O
nullable
êêP X
:
êêX Y
false
êêZ _
)
êê_ `
,
êê` a
Name
ëë 
=
ëë 
table
ëë  
.
ëë  !
Column
ëë! '
<
ëë' (
string
ëë( .
>
ëë. /
(
ëë/ 0
type
ëë0 4
:
ëë4 5
$str
ëë6 E
,
ëëE F
nullable
ëëG O
:
ëëO P
false
ëëQ V
)
ëëV W
,
ëëW X
Value
íí 
=
íí 
table
íí !
.
íí! "
Column
íí" (
<
íí( )
string
íí) /
>
íí/ 0
(
íí0 1
type
íí1 5
:
íí5 6
$str
íí7 F
,
ííF G
nullable
ííH P
:
ííP Q
true
ííR V
)
ííV W
}
ìì 
,
ìì 
constraints
îî 
:
îî 
table
îî "
=>
îî# %
{
ïï 
table
ññ 
.
ññ 

PrimaryKey
ññ $
(
ññ$ %
$str
ññ% :
,
ññ: ;
x
ññ< =
=>
ññ> @
new
ññA D
{
ññE F
x
ññG H
.
ññH I
UserId
ññI O
,
ññO P
x
ññQ R
.
ññR S
LoginProvider
ññS `
,
ññ` a
x
ññb c
.
ññc d
Name
ññd h
}
ññi j
)
ññj k
;
ññk l
table
óó 
.
óó 

ForeignKey
óó $
(
óó$ %
name
òò 
:
òò 
$str
òò F
,
òòF G
column
ôô 
:
ôô 
x
ôô  !
=>
ôô" $
x
ôô% &
.
ôô& '
UserId
ôô' -
,
ôô- .
principalTable
öö &
:
öö& '
$str
öö( 5
,
öö5 6
principalColumn
õõ '
:
õõ' (
$str
õõ) -
,
õõ- .
onDelete
úú  
:
úú  !
ReferentialAction
úú" 3
.
úú3 4
Cascade
úú4 ;
)
úú; <
;
úú< =
}
ùù 
)
ùù 
;
ùù 
migrationBuilder
üü 
.
üü 
CreateTable
üü (
(
üü( )
name
†† 
:
†† 
$str
†† 
,
††  
columns
°° 
:
°° 
table
°° 
=>
°° !
new
°°" %
{
¢¢ 
DoctorId
££ 
=
££ 
table
££ $
.
££$ %
Column
££% +
<
££+ ,
int
££, /
>
££/ 0
(
££0 1
type
££1 5
:
££5 6
$str
££7 <
,
££< =
nullable
££> F
:
££F G
false
££H M
)
££M N
.
§§ 

Annotation
§§ #
(
§§# $
$str
§§$ 8
,
§§8 9
$str
§§: @
)
§§@ A
,
§§A B
UserId
•• 
=
•• 
table
•• "
.
••" #
Column
••# )
<
••) *
string
••* 0
>
••0 1
(
••1 2
type
••2 6
:
••6 7
$str
••8 G
,
••G H
nullable
••I Q
:
••Q R
true
••S W
)
••W X
,
••X Y
FullName
¶¶ 
=
¶¶ 
table
¶¶ $
.
¶¶$ %
Column
¶¶% +
<
¶¶+ ,
string
¶¶, 2
>
¶¶2 3
(
¶¶3 4
type
¶¶4 8
:
¶¶8 9
$str
¶¶: I
,
¶¶I J
	maxLength
¶¶K T
:
¶¶T U
$num
¶¶V Y
,
¶¶Y Z
nullable
¶¶[ c
:
¶¶c d
false
¶¶e j
)
¶¶j k
,
¶¶k l
Specialisation
ßß "
=
ßß# $
table
ßß% *
.
ßß* +
Column
ßß+ 1
<
ßß1 2
string
ßß2 8
>
ßß8 9
(
ßß9 :
type
ßß: >
:
ßß> ?
$str
ßß@ N
,
ßßN O
	maxLength
ßßP Y
:
ßßY Z
$num
ßß[ ]
,
ßß] ^
nullable
ßß_ g
:
ßßg h
false
ßßi n
)
ßßn o
,
ßßo p
YearsOfExperience
®® %
=
®®& '
table
®®( -
.
®®- .
Column
®®. 4
<
®®4 5
int
®®5 8
>
®®8 9
(
®®9 :
type
®®: >
:
®®> ?
$str
®®@ E
,
®®E F
nullable
®®G O
:
®®O P
false
®®Q V
)
®®V W
,
®®W X
ConsultationFee
©© #
=
©©$ %
table
©©& +
.
©©+ ,
Column
©©, 2
<
©©2 3
decimal
©©3 :
>
©©: ;
(
©©; <
type
©©< @
:
©©@ A
$str
©©B Q
,
©©Q R
nullable
©©S [
:
©©[ \
false
©©] b
)
©©b c
,
©©c d
IsActive
™™ 
=
™™ 
table
™™ $
.
™™$ %
Column
™™% +
<
™™+ ,
bool
™™, 0
>
™™0 1
(
™™1 2
type
™™2 6
:
™™6 7
$str
™™8 =
,
™™= >
nullable
™™? G
:
™™G H
false
™™I N
)
™™N O
,
™™O P
CreatedDate
´´ 
=
´´  !
table
´´" '
.
´´' (
Column
´´( .
<
´´. /
DateTimeOffset
´´/ =
>
´´= >
(
´´> ?
type
´´? C
:
´´C D
$str
´´E U
,
´´U V
nullable
´´W _
:
´´_ `
false
´´a f
)
´´f g
,
´´g h
UserId1
¨¨ 
=
¨¨ 
table
¨¨ #
.
¨¨# $
Column
¨¨$ *
<
¨¨* +
string
¨¨+ 1
>
¨¨1 2
(
¨¨2 3
type
¨¨3 7
:
¨¨7 8
$str
¨¨9 H
,
¨¨H I
nullable
¨¨J R
:
¨¨R S
true
¨¨T X
)
¨¨X Y
}
≠≠ 
,
≠≠ 
constraints
ÆÆ 
:
ÆÆ 
table
ÆÆ "
=>
ÆÆ# %
{
ØØ 
table
∞∞ 
.
∞∞ 

PrimaryKey
∞∞ $
(
∞∞$ %
$str
∞∞% 1
,
∞∞1 2
x
∞∞3 4
=>
∞∞5 7
x
∞∞8 9
.
∞∞9 :
DoctorId
∞∞: B
)
∞∞B C
;
∞∞C D
table
±± 
.
±± 

ForeignKey
±± $
(
±±$ %
name
≤≤ 
:
≤≤ 
$str
≤≤ =
,
≤≤= >
column
≥≥ 
:
≥≥ 
x
≥≥  !
=>
≥≥" $
x
≥≥% &
.
≥≥& '
UserId
≥≥' -
,
≥≥- .
principalTable
¥¥ &
:
¥¥& '
$str
¥¥( 5
,
¥¥5 6
principalColumn
µµ '
:
µµ' (
$str
µµ) -
,
µµ- .
onDelete
∂∂  
:
∂∂  !
ReferentialAction
∂∂" 3
.
∂∂3 4
Cascade
∂∂4 ;
)
∂∂; <
;
∂∂< =
table
∑∑ 
.
∑∑ 

ForeignKey
∑∑ $
(
∑∑$ %
name
∏∏ 
:
∏∏ 
$str
∏∏ >
,
∏∏> ?
column
ππ 
:
ππ 
x
ππ  !
=>
ππ" $
x
ππ% &
.
ππ& '
UserId1
ππ' .
,
ππ. /
principalTable
∫∫ &
:
∫∫& '
$str
∫∫( 5
,
∫∫5 6
principalColumn
ªª '
:
ªª' (
$str
ªª) -
)
ªª- .
;
ªª. /
}
ºº 
)
ºº 
;
ºº 
migrationBuilder
ææ 
.
ææ 
CreateTable
ææ (
(
ææ( )
name
øø 
:
øø 
$str
øø  
,
øø  !
columns
¿¿ 
:
¿¿ 
table
¿¿ 
=>
¿¿ !
new
¿¿" %
{
¡¡ 
	PatientId
¬¬ 
=
¬¬ 
table
¬¬  %
.
¬¬% &
Column
¬¬& ,
<
¬¬, -
int
¬¬- 0
>
¬¬0 1
(
¬¬1 2
type
¬¬2 6
:
¬¬6 7
$str
¬¬8 =
,
¬¬= >
nullable
¬¬? G
:
¬¬G H
false
¬¬I N
)
¬¬N O
.
√√ 

Annotation
√√ #
(
√√# $
$str
√√$ 8
,
√√8 9
$str
√√: @
)
√√@ A
,
√√A B
UserId
ƒƒ 
=
ƒƒ 
table
ƒƒ "
.
ƒƒ" #
Column
ƒƒ# )
<
ƒƒ) *
string
ƒƒ* 0
>
ƒƒ0 1
(
ƒƒ1 2
type
ƒƒ2 6
:
ƒƒ6 7
$str
ƒƒ8 G
,
ƒƒG H
nullable
ƒƒI Q
:
ƒƒQ R
true
ƒƒS W
)
ƒƒW X
,
ƒƒX Y
FullName
≈≈ 
=
≈≈ 
table
≈≈ $
.
≈≈$ %
Column
≈≈% +
<
≈≈+ ,
string
≈≈, 2
>
≈≈2 3
(
≈≈3 4
type
≈≈4 8
:
≈≈8 9
$str
≈≈: I
,
≈≈I J
	maxLength
≈≈K T
:
≈≈T U
$num
≈≈V Y
,
≈≈Y Z
nullable
≈≈[ c
:
≈≈c d
false
≈≈e j
)
≈≈j k
,
≈≈k l
DateOfBirth
∆∆ 
=
∆∆  !
table
∆∆" '
.
∆∆' (
Column
∆∆( .
<
∆∆. /
DateOnly
∆∆/ 7
>
∆∆7 8
(
∆∆8 9
type
∆∆9 =
:
∆∆= >
$str
∆∆? E
,
∆∆E F
nullable
∆∆G O
:
∆∆O P
false
∆∆Q V
)
∆∆V W
,
∆∆W X
Gender
«« 
=
«« 
table
«« "
.
««" #
Column
««# )
<
««) *
string
««* 0
>
««0 1
(
««1 2
type
««2 6
:
««6 7
$str
««8 F
,
««F G
	maxLength
««H Q
:
««Q R
$num
««S U
,
««U V
nullable
««W _
:
««_ `
false
««a f
)
««f g
,
««g h
PhoneNumber
»» 
=
»»  !
table
»»" '
.
»»' (
Column
»»( .
<
»». /
string
»»/ 5
>
»»5 6
(
»»6 7
type
»»7 ;
:
»»; <
$str
»»= K
,
»»K L
	maxLength
»»M V
:
»»V W
$num
»»X Z
,
»»Z [
nullable
»»\ d
:
»»d e
false
»»f k
)
»»k l
,
»»l m
InsuranceId
…… 
=
……  !
table
……" '
.
……' (
Column
……( .
<
……. /
string
……/ 5
>
……5 6
(
……6 7
type
……7 ;
:
……; <
$str
……= K
,
……K L
	maxLength
……M V
:
……V W
$num
……X Z
,
……Z [
nullable
……\ d
:
……d e
true
……f j
)
……j k
,
……k l
IsActive
   
=
   
table
   $
.
  $ %
Column
  % +
<
  + ,
bool
  , 0
>
  0 1
(
  1 2
type
  2 6
:
  6 7
$str
  8 =
,
  = >
nullable
  ? G
:
  G H
false
  I N
)
  N O
,
  O P
CreatedDate
ÀÀ 
=
ÀÀ  !
table
ÀÀ" '
.
ÀÀ' (
Column
ÀÀ( .
<
ÀÀ. /
DateTimeOffset
ÀÀ/ =
>
ÀÀ= >
(
ÀÀ> ?
type
ÀÀ? C
:
ÀÀC D
$str
ÀÀE U
,
ÀÀU V
nullable
ÀÀW _
:
ÀÀ_ `
false
ÀÀa f
)
ÀÀf g
,
ÀÀg h
UserId1
ÃÃ 
=
ÃÃ 
table
ÃÃ #
.
ÃÃ# $
Column
ÃÃ$ *
<
ÃÃ* +
string
ÃÃ+ 1
>
ÃÃ1 2
(
ÃÃ2 3
type
ÃÃ3 7
:
ÃÃ7 8
$str
ÃÃ9 H
,
ÃÃH I
nullable
ÃÃJ R
:
ÃÃR S
true
ÃÃT X
)
ÃÃX Y
}
ÕÕ 
,
ÕÕ 
constraints
ŒŒ 
:
ŒŒ 
table
ŒŒ "
=>
ŒŒ# %
{
œœ 
table
–– 
.
–– 

PrimaryKey
–– $
(
––$ %
$str
––% 2
,
––2 3
x
––4 5
=>
––6 8
x
––9 :
.
––: ;
	PatientId
––; D
)
––D E
;
––E F
table
—— 
.
—— 

ForeignKey
—— $
(
——$ %
name
““ 
:
““ 
$str
““ >
,
““> ?
column
”” 
:
”” 
x
””  !
=>
””" $
x
””% &
.
””& '
UserId
””' -
,
””- .
principalTable
‘‘ &
:
‘‘& '
$str
‘‘( 5
,
‘‘5 6
principalColumn
’’ '
:
’’' (
$str
’’) -
,
’’- .
onDelete
÷÷  
:
÷÷  !
ReferentialAction
÷÷" 3
.
÷÷3 4
Cascade
÷÷4 ;
)
÷÷; <
;
÷÷< =
table
◊◊ 
.
◊◊ 

ForeignKey
◊◊ $
(
◊◊$ %
name
ÿÿ 
:
ÿÿ 
$str
ÿÿ ?
,
ÿÿ? @
column
ŸŸ 
:
ŸŸ 
x
ŸŸ  !
=>
ŸŸ" $
x
ŸŸ% &
.
ŸŸ& '
UserId1
ŸŸ' .
,
ŸŸ. /
principalTable
⁄⁄ &
:
⁄⁄& '
$str
⁄⁄( 5
,
⁄⁄5 6
principalColumn
€€ '
:
€€' (
$str
€€) -
)
€€- .
;
€€. /
}
‹‹ 
)
‹‹ 
;
‹‹ 
migrationBuilder
ﬁﬁ 
.
ﬁﬁ 
CreateTable
ﬁﬁ (
(
ﬁﬁ( )
name
ﬂﬂ 
:
ﬂﬂ 
$str
ﬂﬂ ,
,
ﬂﬂ, -
columns
‡‡ 
:
‡‡ 
table
‡‡ 
=>
‡‡ !
new
‡‡" %
{
·· 
Id
‚‚ 
=
‚‚ 
table
‚‚ 
.
‚‚ 
Column
‚‚ %
<
‚‚% &
int
‚‚& )
>
‚‚) *
(
‚‚* +
type
‚‚+ /
:
‚‚/ 0
$str
‚‚1 6
,
‚‚6 7
nullable
‚‚8 @
:
‚‚@ A
false
‚‚B G
)
‚‚G H
.
„„ 

Annotation
„„ #
(
„„# $
$str
„„$ 8
,
„„8 9
$str
„„: @
)
„„@ A
,
„„A B
DoctorId
‰‰ 
=
‰‰ 
table
‰‰ $
.
‰‰$ %
Column
‰‰% +
<
‰‰+ ,
int
‰‰, /
>
‰‰/ 0
(
‰‰0 1
type
‰‰1 5
:
‰‰5 6
$str
‰‰7 <
,
‰‰< =
nullable
‰‰> F
:
‰‰F G
false
‰‰H M
)
‰‰M N
,
‰‰N O
TimeSlot
ÂÂ 
=
ÂÂ 
table
ÂÂ $
.
ÂÂ$ %
Column
ÂÂ% +
<
ÂÂ+ ,
string
ÂÂ, 2
>
ÂÂ2 3
(
ÂÂ3 4
type
ÂÂ4 8
:
ÂÂ8 9
$str
ÂÂ: H
,
ÂÂH I
	maxLength
ÂÂJ S
:
ÂÂS T
$num
ÂÂU W
,
ÂÂW X
nullable
ÂÂY a
:
ÂÂa b
false
ÂÂc h
)
ÂÂh i
,
ÂÂi j
CreatedDate
ÊÊ 
=
ÊÊ  !
table
ÊÊ" '
.
ÊÊ' (
Column
ÊÊ( .
<
ÊÊ. /
DateTimeOffset
ÊÊ/ =
>
ÊÊ= >
(
ÊÊ> ?
type
ÊÊ? C
:
ÊÊC D
$str
ÊÊE U
,
ÊÊU V
nullable
ÊÊW _
:
ÊÊ_ `
false
ÊÊa f
)
ÊÊf g
}
ÁÁ 
,
ÁÁ 
constraints
ËË 
:
ËË 
table
ËË "
=>
ËË# %
{
ÈÈ 
table
ÍÍ 
.
ÍÍ 

PrimaryKey
ÍÍ $
(
ÍÍ$ %
$str
ÍÍ% >
,
ÍÍ> ?
x
ÍÍ@ A
=>
ÍÍB D
x
ÍÍE F
.
ÍÍF G
Id
ÍÍG I
)
ÍÍI J
;
ÍÍJ K
table
ÎÎ 
.
ÎÎ 

ForeignKey
ÎÎ $
(
ÎÎ$ %
name
ÏÏ 
:
ÏÏ 
$str
ÏÏ H
,
ÏÏH I
column
ÌÌ 
:
ÌÌ 
x
ÌÌ  !
=>
ÌÌ" $
x
ÌÌ% &
.
ÌÌ& '
DoctorId
ÌÌ' /
,
ÌÌ/ 0
principalTable
ÓÓ &
:
ÓÓ& '
$str
ÓÓ( 1
,
ÓÓ1 2
principalColumn
ÔÔ '
:
ÔÔ' (
$str
ÔÔ) 3
,
ÔÔ3 4
onDelete
  
:
  !
ReferentialAction
" 3
.
3 4
Cascade
4 ;
)
; <
;
< =
}
ÒÒ 
)
ÒÒ 
;
ÒÒ 
migrationBuilder
ÛÛ 
.
ÛÛ 
CreateTable
ÛÛ (
(
ÛÛ( )
name
ÙÙ 
:
ÙÙ 
$str
ÙÙ $
,
ÙÙ$ %
columns
ıı 
:
ıı 
table
ıı 
=>
ıı !
new
ıı" %
{
ˆˆ 
Id
˜˜ 
=
˜˜ 
table
˜˜ 
.
˜˜ 
Column
˜˜ %
<
˜˜% &
int
˜˜& )
>
˜˜) *
(
˜˜* +
type
˜˜+ /
:
˜˜/ 0
$str
˜˜1 6
,
˜˜6 7
nullable
˜˜8 @
:
˜˜@ A
false
˜˜B G
)
˜˜G H
.
¯¯ 

Annotation
¯¯ #
(
¯¯# $
$str
¯¯$ 8
,
¯¯8 9
$str
¯¯: @
)
¯¯@ A
,
¯¯A B
DoctorId
˘˘ 
=
˘˘ 
table
˘˘ $
.
˘˘$ %
Column
˘˘% +
<
˘˘+ ,
int
˘˘, /
>
˘˘/ 0
(
˘˘0 1
type
˘˘1 5
:
˘˘5 6
$str
˘˘7 <
,
˘˘< =
nullable
˘˘> F
:
˘˘F G
false
˘˘H M
)
˘˘M N
,
˘˘N O
	LeaveDate
˙˙ 
=
˙˙ 
table
˙˙  %
.
˙˙% &
Column
˙˙& ,
<
˙˙, -
DateOnly
˙˙- 5
>
˙˙5 6
(
˙˙6 7
type
˙˙7 ;
:
˙˙; <
$str
˙˙= C
,
˙˙C D
nullable
˙˙E M
:
˙˙M N
false
˙˙O T
)
˙˙T U
,
˙˙U V
Reason
˚˚ 
=
˚˚ 
table
˚˚ "
.
˚˚" #
Column
˚˚# )
<
˚˚) *
string
˚˚* 0
>
˚˚0 1
(
˚˚1 2
type
˚˚2 6
:
˚˚6 7
$str
˚˚8 G
,
˚˚G H
	maxLength
˚˚I R
:
˚˚R S
$num
˚˚T W
,
˚˚W X
nullable
˚˚Y a
:
˚˚a b
true
˚˚c g
)
˚˚g h
,
˚˚h i
CreatedDate
¸¸ 
=
¸¸  !
table
¸¸" '
.
¸¸' (
Column
¸¸( .
<
¸¸. /
DateTimeOffset
¸¸/ =
>
¸¸= >
(
¸¸> ?
type
¸¸? C
:
¸¸C D
$str
¸¸E U
,
¸¸U V
nullable
¸¸W _
:
¸¸_ `
false
¸¸a f
)
¸¸f g
}
˝˝ 
,
˝˝ 
constraints
˛˛ 
:
˛˛ 
table
˛˛ "
=>
˛˛# %
{
ˇˇ 
table
ÄÄ 
.
ÄÄ 

PrimaryKey
ÄÄ $
(
ÄÄ$ %
$str
ÄÄ% 6
,
ÄÄ6 7
x
ÄÄ8 9
=>
ÄÄ: <
x
ÄÄ= >
.
ÄÄ> ?
Id
ÄÄ? A
)
ÄÄA B
;
ÄÄB C
table
ÅÅ 
.
ÅÅ 

ForeignKey
ÅÅ $
(
ÅÅ$ %
name
ÇÇ 
:
ÇÇ 
$str
ÇÇ @
,
ÇÇ@ A
column
ÉÉ 
:
ÉÉ 
x
ÉÉ  !
=>
ÉÉ" $
x
ÉÉ% &
.
ÉÉ& '
DoctorId
ÉÉ' /
,
ÉÉ/ 0
principalTable
ÑÑ &
:
ÑÑ& '
$str
ÑÑ( 1
,
ÑÑ1 2
principalColumn
ÖÖ '
:
ÖÖ' (
$str
ÖÖ) 3
,
ÖÖ3 4
onDelete
ÜÜ  
:
ÜÜ  !
ReferentialAction
ÜÜ" 3
.
ÜÜ3 4
Cascade
ÜÜ4 ;
)
ÜÜ; <
;
ÜÜ< =
}
áá 
)
áá 
;
áá 
migrationBuilder
ââ 
.
ââ 
CreateTable
ââ (
(
ââ( )
name
ää 
:
ää 
$str
ää $
,
ää$ %
columns
ãã 
:
ãã 
table
ãã 
=>
ãã !
new
ãã" %
{
åå 
AppointmentId
çç !
=
çç" #
table
çç$ )
.
çç) *
Column
çç* 0
<
çç0 1
int
çç1 4
>
çç4 5
(
çç5 6
type
çç6 :
:
çç: ;
$str
çç< A
,
ççA B
nullable
ççC K
:
ççK L
false
ççM R
)
ççR S
.
éé 

Annotation
éé #
(
éé# $
$str
éé$ 8
,
éé8 9
$str
éé: @
)
éé@ A
,
ééA B
	PatientId
èè 
=
èè 
table
èè  %
.
èè% &
Column
èè& ,
<
èè, -
int
èè- 0
>
èè0 1
(
èè1 2
type
èè2 6
:
èè6 7
$str
èè8 =
,
èè= >
nullable
èè? G
:
èèG H
false
èèI N
)
èèN O
,
èèO P
DoctorId
êê 
=
êê 
table
êê $
.
êê$ %
Column
êê% +
<
êê+ ,
int
êê, /
>
êê/ 0
(
êê0 1
type
êê1 5
:
êê5 6
$str
êê7 <
,
êê< =
nullable
êê> F
:
êêF G
false
êêH M
)
êêM N
,
êêN O
ScheduledDate
ëë !
=
ëë" #
table
ëë$ )
.
ëë) *
Column
ëë* 0
<
ëë0 1
DateOnly
ëë1 9
>
ëë9 :
(
ëë: ;
type
ëë; ?
:
ëë? @
$str
ëëA G
,
ëëG H
nullable
ëëI Q
:
ëëQ R
false
ëëS X
)
ëëX Y
,
ëëY Z
TimeSlot
íí 
=
íí 
table
íí $
.
íí$ %
Column
íí% +
<
íí+ ,
string
íí, 2
>
íí2 3
(
íí3 4
type
íí4 8
:
íí8 9
$str
íí: H
,
ííH I
	maxLength
ííJ S
:
ííS T
$num
ííU W
,
ííW X
nullable
ííY a
:
íía b
false
ííc h
)
ííh i
,
ííi j
Status
ìì 
=
ìì 
table
ìì "
.
ìì" #
Column
ìì# )
<
ìì) *
string
ìì* 0
>
ìì0 1
(
ìì1 2
type
ìì2 6
:
ìì6 7
$str
ìì8 F
,
ììF G
	maxLength
ììH Q
:
ììQ R
$num
ììS U
,
ììU V
nullable
ììW _
:
ìì_ `
false
ììa f
)
ììf g
,
ììg h 
CancellationReason
îî &
=
îî' (
table
îî) .
.
îî. /
Column
îî/ 5
<
îî5 6
string
îî6 <
>
îî< =
(
îî= >
type
îî> B
:
îîB C
$str
îîD S
,
îîS T
	maxLength
îîU ^
:
îî^ _
$num
îî` c
,
îîc d
nullable
îîe m
:
îîm n
true
îîo s
)
îîs t
,
îît u
CreatedDate
ïï 
=
ïï  !
table
ïï" '
.
ïï' (
Column
ïï( .
<
ïï. /
DateTimeOffset
ïï/ =
>
ïï= >
(
ïï> ?
type
ïï? C
:
ïïC D
$str
ïïE U
,
ïïU V
nullable
ïïW _
:
ïï_ `
false
ïïa f
)
ïïf g
}
ññ 
,
ññ 
constraints
óó 
:
óó 
table
óó "
=>
óó# %
{
òò 
table
ôô 
.
ôô 

PrimaryKey
ôô $
(
ôô$ %
$str
ôô% 6
,
ôô6 7
x
ôô8 9
=>
ôô: <
x
ôô= >
.
ôô> ?
AppointmentId
ôô? L
)
ôôL M
;
ôôM N
table
öö 
.
öö 

ForeignKey
öö $
(
öö$ %
name
õõ 
:
õõ 
$str
õõ @
,
õõ@ A
column
úú 
:
úú 
x
úú  !
=>
úú" $
x
úú% &
.
úú& '
DoctorId
úú' /
,
úú/ 0
principalTable
ùù &
:
ùù& '
$str
ùù( 1
,
ùù1 2
principalColumn
ûû '
:
ûû' (
$str
ûû) 3
,
ûû3 4
onDelete
üü  
:
üü  !
ReferentialAction
üü" 3
.
üü3 4
Restrict
üü4 <
)
üü< =
;
üü= >
table
†† 
.
†† 

ForeignKey
†† $
(
††$ %
name
°° 
:
°° 
$str
°° B
,
°°B C
column
¢¢ 
:
¢¢ 
x
¢¢  !
=>
¢¢" $
x
¢¢% &
.
¢¢& '
	PatientId
¢¢' 0
,
¢¢0 1
principalTable
££ &
:
££& '
$str
££( 2
,
££2 3
principalColumn
§§ '
:
§§' (
$str
§§) 4
,
§§4 5
onDelete
••  
:
••  !
ReferentialAction
••" 3
.
••3 4
Restrict
••4 <
)
••< =
;
••= >
}
¶¶ 
)
¶¶ 
;
¶¶ 
migrationBuilder
®® 
.
®® 
CreateTable
®® (
(
®®( )
name
©© 
:
©© 
$str
©© %
,
©©% &
columns
™™ 
:
™™ 
table
™™ 
=>
™™ !
new
™™" %
{
´´ 
RecordId
¨¨ 
=
¨¨ 
table
¨¨ $
.
¨¨$ %
Column
¨¨% +
<
¨¨+ ,
int
¨¨, /
>
¨¨/ 0
(
¨¨0 1
type
¨¨1 5
:
¨¨5 6
$str
¨¨7 <
,
¨¨< =
nullable
¨¨> F
:
¨¨F G
false
¨¨H M
)
¨¨M N
.
≠≠ 

Annotation
≠≠ #
(
≠≠# $
$str
≠≠$ 8
,
≠≠8 9
$str
≠≠: @
)
≠≠@ A
,
≠≠A B
AppointmentId
ÆÆ !
=
ÆÆ" #
table
ÆÆ$ )
.
ÆÆ) *
Column
ÆÆ* 0
<
ÆÆ0 1
int
ÆÆ1 4
>
ÆÆ4 5
(
ÆÆ5 6
type
ÆÆ6 :
:
ÆÆ: ;
$str
ÆÆ< A
,
ÆÆA B
nullable
ÆÆC K
:
ÆÆK L
false
ÆÆM R
)
ÆÆR S
,
ÆÆS T
	PatientId
ØØ 
=
ØØ 
table
ØØ  %
.
ØØ% &
Column
ØØ& ,
<
ØØ, -
int
ØØ- 0
>
ØØ0 1
(
ØØ1 2
type
ØØ2 6
:
ØØ6 7
$str
ØØ8 =
,
ØØ= >
nullable
ØØ? G
:
ØØG H
false
ØØI N
)
ØØN O
,
ØØO P
DoctorId
∞∞ 
=
∞∞ 
table
∞∞ $
.
∞∞$ %
Column
∞∞% +
<
∞∞+ ,
int
∞∞, /
>
∞∞/ 0
(
∞∞0 1
type
∞∞1 5
:
∞∞5 6
$str
∞∞7 <
,
∞∞< =
nullable
∞∞> F
:
∞∞F G
false
∞∞H M
)
∞∞M N
,
∞∞N O
	VisitDate
±± 
=
±± 
table
±±  %
.
±±% &
Column
±±& ,
<
±±, -
DateTime
±±- 5
>
±±5 6
(
±±6 7
type
±±7 ;
:
±±; <
$str
±±= H
,
±±H I
nullable
±±J R
:
±±R S
false
±±T Y
)
±±Y Z
,
±±Z [
	Diagnosis
≤≤ 
=
≤≤ 
table
≤≤  %
.
≤≤% &
Column
≤≤& ,
<
≤≤, -
string
≤≤- 3
>
≤≤3 4
(
≤≤4 5
type
≤≤5 9
:
≤≤9 :
$str
≤≤; J
,
≤≤J K
	maxLength
≤≤L U
:
≤≤U V
$num
≤≤W Z
,
≤≤Z [
nullable
≤≤\ d
:
≤≤d e
false
≤≤f k
)
≤≤k l
,
≤≤l m
Prescription
≥≥  
=
≥≥! "
table
≥≥# (
.
≥≥( )
Column
≥≥) /
<
≥≥/ 0
string
≥≥0 6
>
≥≥6 7
(
≥≥7 8
type
≥≥8 <
:
≥≥< =
$str
≥≥> M
,
≥≥M N
	maxLength
≥≥O X
:
≥≥X Y
$num
≥≥Z ]
,
≥≥] ^
nullable
≥≥_ g
:
≥≥g h
false
≥≥i n
)
≥≥n o
,
≥≥o p
Notes
¥¥ 
=
¥¥ 
table
¥¥ !
.
¥¥! "
Column
¥¥" (
<
¥¥( )
string
¥¥) /
>
¥¥/ 0
(
¥¥0 1
type
¥¥1 5
:
¥¥5 6
$str
¥¥7 G
,
¥¥G H
	maxLength
¥¥I R
:
¥¥R S
$num
¥¥T X
,
¥¥X Y
nullable
¥¥Z b
:
¥¥b c
true
¥¥d h
)
¥¥h i
,
¥¥i j
CreatedDate
µµ 
=
µµ  !
table
µµ" '
.
µµ' (
Column
µµ( .
<
µµ. /
DateTimeOffset
µµ/ =
>
µµ= >
(
µµ> ?
type
µµ? C
:
µµC D
$str
µµE U
,
µµU V
nullable
µµW _
:
µµ_ `
false
µµa f
)
µµf g
}
∂∂ 
,
∂∂ 
constraints
∑∑ 
:
∑∑ 
table
∑∑ "
=>
∑∑# %
{
∏∏ 
table
ππ 
.
ππ 

PrimaryKey
ππ $
(
ππ$ %
$str
ππ% 7
,
ππ7 8
x
ππ9 :
=>
ππ; =
x
ππ> ?
.
ππ? @
RecordId
ππ@ H
)
ππH I
;
ππI J
table
∫∫ 
.
∫∫ 

ForeignKey
∫∫ $
(
∫∫$ %
name
ªª 
:
ªª 
$str
ªª K
,
ªªK L
column
ºº 
:
ºº 
x
ºº  !
=>
ºº" $
x
ºº% &
.
ºº& '
AppointmentId
ºº' 4
,
ºº4 5
principalTable
ΩΩ &
:
ΩΩ& '
$str
ΩΩ( 6
,
ΩΩ6 7
principalColumn
ææ '
:
ææ' (
$str
ææ) 8
,
ææ8 9
onDelete
øø  
:
øø  !
ReferentialAction
øø" 3
.
øø3 4
Restrict
øø4 <
)
øø< =
;
øø= >
table
¿¿ 
.
¿¿ 

ForeignKey
¿¿ $
(
¿¿$ %
name
¡¡ 
:
¡¡ 
$str
¡¡ A
,
¡¡A B
column
¬¬ 
:
¬¬ 
x
¬¬  !
=>
¬¬" $
x
¬¬% &
.
¬¬& '
DoctorId
¬¬' /
,
¬¬/ 0
principalTable
√√ &
:
√√& '
$str
√√( 1
,
√√1 2
principalColumn
ƒƒ '
:
ƒƒ' (
$str
ƒƒ) 3
,
ƒƒ3 4
onDelete
≈≈  
:
≈≈  !
ReferentialAction
≈≈" 3
.
≈≈3 4
Restrict
≈≈4 <
)
≈≈< =
;
≈≈= >
table
∆∆ 
.
∆∆ 

ForeignKey
∆∆ $
(
∆∆$ %
name
«« 
:
«« 
$str
«« C
,
««C D
column
»» 
:
»» 
x
»»  !
=>
»»" $
x
»»% &
.
»»& '
	PatientId
»»' 0
,
»»0 1
principalTable
…… &
:
……& '
$str
……( 2
,
……2 3
principalColumn
   '
:
  ' (
$str
  ) 4
,
  4 5
onDelete
ÀÀ  
:
ÀÀ  !
ReferentialAction
ÀÀ" 3
.
ÀÀ3 4
Restrict
ÀÀ4 <
)
ÀÀ< =
;
ÀÀ= >
}
ÃÃ 
)
ÃÃ 
;
ÃÃ 
migrationBuilder
ŒŒ 
.
ŒŒ 
CreateIndex
ŒŒ (
(
ŒŒ( )
name
œœ 
:
œœ 
$str
œœ 3
,
œœ3 4
table
–– 
:
–– 
$str
–– %
,
––% &
columns
—— 
:
—— 
new
—— 
[
—— 
]
—— 
{
——  
$str
——! +
,
——+ ,
$str
——- <
}
——= >
)
——> ?
;
——? @
migrationBuilder
”” 
.
”” 
CreateIndex
”” (
(
””( )
name
‘‘ 
:
‘‘ 
$str
‘‘ 4
,
‘‘4 5
table
’’ 
:
’’ 
$str
’’ %
,
’’% &
columns
÷÷ 
:
÷÷ 
new
÷÷ 
[
÷÷ 
]
÷÷ 
{
÷÷  
$str
÷÷! ,
,
÷÷, -
$str
÷÷. =
}
÷÷> ?
)
÷÷? @
;
÷÷@ A
migrationBuilder
ÿÿ 
.
ÿÿ 
CreateIndex
ÿÿ (
(
ÿÿ( )
name
ŸŸ 
:
ŸŸ 
$str
ŸŸ 8
,
ŸŸ8 9
table
⁄⁄ 
:
⁄⁄ 
$str
⁄⁄ %
,
⁄⁄% &
columns
€€ 
:
€€ 
new
€€ 
[
€€ 
]
€€ 
{
€€  
$str
€€! +
,
€€+ ,
$str
€€- <
,
€€< =
$str
€€> H
}
€€I J
,
€€J K
unique
‹‹ 
:
‹‹ 
true
‹‹ 
,
‹‹ 
filter
›› 
:
›› 
$str
›› 1
)
››1 2
;
››2 3
migrationBuilder
ﬂﬂ 
.
ﬂﬂ 
CreateIndex
ﬂﬂ (
(
ﬂﬂ( )
name
‡‡ 
:
‡‡ 
$str
‡‡ 2
,
‡‡2 3
table
·· 
:
·· 
$str
·· )
,
··) *
column
‚‚ 
:
‚‚ 
$str
‚‚  
)
‚‚  !
;
‚‚! "
migrationBuilder
‰‰ 
.
‰‰ 
CreateIndex
‰‰ (
(
‰‰( )
name
ÂÂ 
:
ÂÂ 
$str
ÂÂ %
,
ÂÂ% &
table
ÊÊ 
:
ÊÊ 
$str
ÊÊ $
,
ÊÊ$ %
column
ÁÁ 
:
ÁÁ 
$str
ÁÁ (
,
ÁÁ( )
unique
ËË 
:
ËË 
true
ËË 
,
ËË 
filter
ÈÈ 
:
ÈÈ 
$str
ÈÈ 6
)
ÈÈ6 7
;
ÈÈ7 8
migrationBuilder
ÎÎ 
.
ÎÎ 
CreateIndex
ÎÎ (
(
ÎÎ( )
name
ÏÏ 
:
ÏÏ 
$str
ÏÏ 2
,
ÏÏ2 3
table
ÌÌ 
:
ÌÌ 
$str
ÌÌ )
,
ÌÌ) *
column
ÓÓ 
:
ÓÓ 
$str
ÓÓ  
)
ÓÓ  !
;
ÓÓ! "
migrationBuilder
 
.
 
CreateIndex
 (
(
( )
name
ÒÒ 
:
ÒÒ 
$str
ÒÒ 2
,
ÒÒ2 3
table
ÚÚ 
:
ÚÚ 
$str
ÚÚ )
,
ÚÚ) *
column
ÛÛ 
:
ÛÛ 
$str
ÛÛ  
)
ÛÛ  !
;
ÛÛ! "
migrationBuilder
ıı 
.
ıı 
CreateIndex
ıı (
(
ıı( )
name
ˆˆ 
:
ˆˆ 
$str
ˆˆ 1
,
ˆˆ1 2
table
˜˜ 
:
˜˜ 
$str
˜˜ (
,
˜˜( )
column
¯¯ 
:
¯¯ 
$str
¯¯  
)
¯¯  !
;
¯¯! "
migrationBuilder
˙˙ 
.
˙˙ 
CreateIndex
˙˙ (
(
˙˙( )
name
˚˚ 
:
˚˚ 
$str
˚˚ "
,
˚˚" #
table
¸¸ 
:
¸¸ 
$str
¸¸ $
,
¸¸$ %
column
˝˝ 
:
˝˝ 
$str
˝˝ )
)
˝˝) *
;
˝˝* +
migrationBuilder
ˇˇ 
.
ˇˇ 
CreateIndex
ˇˇ (
(
ˇˇ( )
name
ÄÄ 
:
ÄÄ 
$str
ÄÄ %
,
ÄÄ% &
table
ÅÅ 
:
ÅÅ 
$str
ÅÅ $
,
ÅÅ$ %
column
ÇÇ 
:
ÇÇ 
$str
ÇÇ ,
,
ÇÇ, -
unique
ÉÉ 
:
ÉÉ 
true
ÉÉ 
,
ÉÉ 
filter
ÑÑ 
:
ÑÑ 
$str
ÑÑ :
)
ÑÑ: ;
;
ÑÑ; <
migrationBuilder
ÜÜ 
.
ÜÜ 
CreateIndex
ÜÜ (
(
ÜÜ( )
name
áá 
:
áá 
$str
áá 8
,
áá8 9
table
àà 
:
àà 
$str
àà -
,
àà- .
column
ââ 
:
ââ 
$str
ââ "
)
ââ" #
;
ââ# $
migrationBuilder
ãã 
.
ãã 
CreateIndex
ãã (
(
ãã( )
name
åå 
:
åå 
$str
åå 0
,
åå0 1
table
çç 
:
çç 
$str
çç %
,
çç% &
column
éé 
:
éé 
$str
éé "
)
éé" #
;
éé# $
migrationBuilder
êê 
.
êê 
CreateIndex
êê (
(
êê( )
name
ëë 
:
ëë 
$str
ëë 1
,
ëë1 2
table
íí 
:
íí 
$str
íí  
,
íí  !
column
ìì 
:
ìì 
$str
ìì (
)
ìì( )
;
ìì) *
migrationBuilder
ïï 
.
ïï 
CreateIndex
ïï (
(
ïï( )
name
ññ 
:
ññ 
$str
ññ )
,
ññ) *
table
óó 
:
óó 
$str
óó  
,
óó  !
column
òò 
:
òò 
$str
òò  
)
òò  !
;
òò! "
migrationBuilder
öö 
.
öö 
CreateIndex
öö (
(
öö( )
name
õõ 
:
õõ 
$str
õõ *
,
õõ* +
table
úú 
:
úú 
$str
úú  
,
úú  !
column
ùù 
:
ùù 
$str
ùù !
)
ùù! "
;
ùù" #
migrationBuilder
üü 
.
üü 
CreateIndex
üü (
(
üü( )
name
†† 
:
†† 
$str
†† 6
,
††6 7
table
°° 
:
°° 
$str
°° &
,
°°& '
column
¢¢ 
:
¢¢ 
$str
¢¢ '
,
¢¢' (
unique
££ 
:
££ 
true
££ 
)
££ 
;
££ 
migrationBuilder
•• 
.
•• 
CreateIndex
•• (
(
••( )
name
¶¶ 
:
¶¶ 
$str
¶¶ 1
,
¶¶1 2
table
ßß 
:
ßß 
$str
ßß &
,
ßß& '
column
®® 
:
®® 
$str
®® "
)
®®" #
;
®®# $
migrationBuilder
™™ 
.
™™ 
CreateIndex
™™ (
(
™™( )
name
´´ 
:
´´ 
$str
´´ :
,
´´: ;
table
¨¨ 
:
¨¨ 
$str
¨¨ &
,
¨¨& '
columns
≠≠ 
:
≠≠ 
new
≠≠ 
[
≠≠ 
]
≠≠ 
{
≠≠  
$str
≠≠! ,
,
≠≠, -
$str
≠≠. 9
}
≠≠: ;
)
≠≠; <
;
≠≠< =
migrationBuilder
ØØ 
.
ØØ 
CreateIndex
ØØ (
(
ØØ( )
name
∞∞ 
:
∞∞ 
$str
∞∞ *
,
∞∞* +
table
±± 
:
±± 
$str
±± !
,
±±! "
column
≤≤ 
:
≤≤ 
$str
≤≤  
)
≤≤  !
;
≤≤! "
migrationBuilder
¥¥ 
.
¥¥ 
CreateIndex
¥¥ (
(
¥¥( )
name
µµ 
:
µµ 
$str
µµ +
,
µµ+ ,
table
∂∂ 
:
∂∂ 
$str
∂∂ !
,
∂∂! "
column
∑∑ 
:
∑∑ 
$str
∑∑ !
)
∑∑! "
;
∑∑" #
}
∏∏ 	
	protected
ªª 
override
ªª 
void
ªª 
Down
ªª  $
(
ªª$ %
MigrationBuilder
ªª% 5
migrationBuilder
ªª6 F
)
ªªF G
{
ºº 	
migrationBuilder
ΩΩ 
.
ΩΩ 
	DropTable
ΩΩ &
(
ΩΩ& '
name
ææ 
:
ææ 
$str
ææ (
)
ææ( )
;
ææ) *
migrationBuilder
¿¿ 
.
¿¿ 
	DropTable
¿¿ &
(
¿¿& '
name
¡¡ 
:
¡¡ 
$str
¡¡ (
)
¡¡( )
;
¡¡) *
migrationBuilder
√√ 
.
√√ 
	DropTable
√√ &
(
√√& '
name
ƒƒ 
:
ƒƒ 
$str
ƒƒ (
)
ƒƒ( )
;
ƒƒ) *
migrationBuilder
∆∆ 
.
∆∆ 
	DropTable
∆∆ &
(
∆∆& '
name
«« 
:
«« 
$str
«« '
)
««' (
;
««( )
migrationBuilder
…… 
.
…… 
	DropTable
…… &
(
……& '
name
   
:
   
$str
   (
)
  ( )
;
  ) *
migrationBuilder
ÃÃ 
.
ÃÃ 
	DropTable
ÃÃ &
(
ÃÃ& '
name
ÕÕ 
:
ÕÕ 
$str
ÕÕ ,
)
ÕÕ, -
;
ÕÕ- .
migrationBuilder
œœ 
.
œœ 
	DropTable
œœ &
(
œœ& '
name
–– 
:
–– 
$str
–– $
)
––$ %
;
––% &
migrationBuilder
““ 
.
““ 
	DropTable
““ &
(
““& '
name
”” 
:
”” 
$str
”” %
)
””% &
;
””& '
migrationBuilder
’’ 
.
’’ 
	DropTable
’’ &
(
’’& '
name
÷÷ 
:
÷÷ 
$str
÷÷ #
)
÷÷# $
;
÷÷$ %
migrationBuilder
ÿÿ 
.
ÿÿ 
	DropTable
ÿÿ &
(
ÿÿ& '
name
ŸŸ 
:
ŸŸ 
$str
ŸŸ $
)
ŸŸ$ %
;
ŸŸ% &
migrationBuilder
€€ 
.
€€ 
	DropTable
€€ &
(
€€& '
name
‹‹ 
:
‹‹ 
$str
‹‹ 
)
‹‹  
;
‹‹  !
migrationBuilder
ﬁﬁ 
.
ﬁﬁ 
	DropTable
ﬁﬁ &
(
ﬁﬁ& '
name
ﬂﬂ 
:
ﬂﬂ 
$str
ﬂﬂ  
)
ﬂﬂ  !
;
ﬂﬂ! "
migrationBuilder
·· 
.
·· 
	DropTable
·· &
(
··& '
name
‚‚ 
:
‚‚ 
$str
‚‚ #
)
‚‚# $
;
‚‚$ %
}
„„ 	
}
‰‰ 
}ÂÂ Í
gC:\Users\310055\source\repos\UST-Live-01\HealthCare\HealthCare.Api\Middleware\GlobalExceptionHandler.cs
	namespace 	

HealthCare
 
. 
Api 
. 

Middleware #
{ 
public 

class "
GlobalExceptionHandler '
:( )
IExceptionHandler* ;
{ 
private		 
readonly		 
ILogger		  
<		  !"
GlobalExceptionHandler		! 7
>		7 8
_logger		9 @
;		@ A
public "
GlobalExceptionHandler %
(% &
ILogger& -
<- ."
GlobalExceptionHandler. D
>D E
loggerF L
)L M
{ 	
_logger 
= 
logger 
; 
} 	
public 
async 
	ValueTask 
< 
bool #
># $
TryHandleAsync% 3
(3 4
HttpContext4 ?
httpContext@ K
,K L
	ExceptionM V
	exceptionW `
,` a
CancellationTokenb s
cancellationToken	t Ö
)
Ö Ü
{ 	
_logger 
. 
LogError 
( 
	exception &
,& '
$str( P
,P Q
	exceptionR [
.[ \
Message\ c
)c d
;d e
var 
( 

statusCode 
, 
message $
)$ %
=& '
	exception( 1
switch2 8
{ $
PatientNotFoundException (
=>) +
(, -
StatusCodes- 8
.8 9
Status404NotFound9 J
,J K
	exceptionL U
.U V
MessageV ]
)] ^
,^ _#
DoctorNotFoundException '
=>( *
(+ ,
StatusCodes, 7
.7 8
Status404NotFound8 I
,I J
	exceptionK T
.T U
MessageU \
)\ ]
,] ^(
AppointmentNotFoundException ,
=>- /
(0 1
StatusCodes1 <
.< =
Status404NotFound= N
,N O
	exceptionP Y
.Y Z
MessageZ a
)a b
,b c)
HealthRecordNotFoundException -
=>. 0
(1 2
StatusCodes2 =
.= >
Status404NotFound> O
,O P
	exceptionQ Z
.Z [
Message[ b
)b c
,c d%
InvalidOperationException )
=>* ,
(- .
StatusCodes. 9
.9 :
Status400BadRequest: M
,M N
	exceptionO X
.X Y
MessageY `
)` a
,a b
_   
=>   
(   
StatusCodes   !
.  ! "(
Status500InternalServerError  " >
,  > ?
$str  @ W
)  W X
}!! 
;!! 
var## 
response## 
=## 
new## 
ErrorResponse## ,
{$$ 

StatusCode%% 
=%% 

statusCode%% '
,%%' (
Message&& 
=&& 
message&& !
,&&! "
	TimeStamp'' 
='' 
DateTime'' $
.''$ %
UtcNow''% +
,''+ ,
Path(( 
=(( 
httpContext(( "
.((" #
Request((# *
.((* +
Path((+ /
})) 
;)) 
httpContext++ 
.++ 
Response++  
.++  !

StatusCode++! +
=++, -

statusCode++. 8
;++8 9
await-- 
httpContext-- 
.-- 
Response-- &
.--& '
WriteAsJsonAsync--' 7
(--7 8
response--8 @
,--@ A
cancellationToken--B S
)--S T
;--T U
return// 
true// 
;// 
}00 	
}11 
}22 ≤
\C:\Users\310055\source\repos\UST-Live-01\HealthCare\HealthCare.Api\Mapping\MappingProfile.cs
	namespace 	

HealthCare
 
. 
Api 
. 
Mapping  
{		 
public

 

class

 
MappingProfile

 
:

  !
Profile

" )
{ 
public 
MappingProfile 
( 
) 
{ 	
	CreateMap 
< 
CreatePatientDto &
,& '
Patient( /
>/ 0
(0 1
)1 2
;2 3
	CreateMap 
< 
UpdatePatientDto &
,& '
Patient( /
>/ 0
(0 1
)1 2
;2 3
	CreateMap 
< 
Patient 
, 
PatientListDto -
>- .
(. /
)/ 0
;0 1
	CreateMap 
< 
CreateDoctorDto %
,% &
Doctor' -
>- .
(. /
)/ 0
;0 1
	CreateMap 
< 
UpdateDoctorDto %
,% &
Doctor' -
>- .
(. /
)/ 0
;0 1
	CreateMap 
< 
Doctor 
, 
DoctorListDto +
>+ ,
(, -
)- .
;. /
	CreateMap 
<  
CreateAppointmentDto *
,* +
Appointment, 7
>7 8
(8 9
)9 :
;: ;
	CreateMap 
<  
UpdateAppointmentDto *
,* +
Appointment, 7
>7 8
(8 9
)9 :
;: ;
	CreateMap 
< 
AppointmentListDto (
,( )
Appointment* 5
>5 6
(6 7
)7 8
;8 9
	CreateMap 
< !
CreateHealthRecordDto +
,+ ,
HealthRecord- 9
>9 :
(: ;
); <
;< =
	CreateMap 
< !
UpdateHealthRecordDto +
,+ ,
HealthRecord- 9
>9 :
(: ;
); <
;< =
	CreateMap   
<   
HealthRecordListDto   )
,  ) *
HealthRecord  + 7
>  7 8
(  8 9
)  9 :
;  : ;
}!! 	
}"" 
}## —
iC:\Users\310055\source\repos\UST-Live-01\HealthCare\HealthCare.Api\Exceptions\PatientNotFoundException.cs
	namespace 	

HealthCare
 
. 
Api 
. 

Exceptions #
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
(' (
int( +
id, .
). /
: 
base 
( 
$" 
$str -
{- .
id. 0
}0 1
$str1 ;
"; <
)< =
{> ?
}@ A
} 
}		 ‡
nC:\Users\310055\source\repos\UST-Live-01\HealthCare\HealthCare.Api\Exceptions\HealthRecordNotFoundException.cs
	namespace 	

HealthCare
 
. 
Api 
. 

Exceptions #
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
(, -
int- 0
id1 3
)3 4
: 
base 
( 
$" 
$str 3
{3 4
id4 6
}6 7
$str7 A
"A B
)B C
{D E
}F G
}		 
}

 Œ
hC:\Users\310055\source\repos\UST-Live-01\HealthCare\HealthCare.Api\Exceptions\DoctorNotFoundException.cs
	namespace 	

HealthCare
 
. 
Api 
. 

Exceptions #
{ 
public 

class #
DoctorNotFoundException (
:) *
	Exception+ 4
{ 
public #
DoctorNotFoundException &
(& '
int' *
id+ -
)- .
: 
base 
( 
$" 
$str ,
{, -
id- /
}/ 0
$str0 :
": ;
); <
{= >
}? @
} 
}		 ›
mC:\Users\310055\source\repos\UST-Live-01\HealthCare\HealthCare.Api\Exceptions\AppointmentNotFoundException.cs
	namespace 	

HealthCare
 
. 
Api 
. 

Exceptions #
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
(+ ,
int, /
id0 2
)2 3
: 
base 
( 
$" 
$str 0
{0 1
id1 3
}3 4
$str4 >
"> ?
)? @
{A B
}C D
} 
}		 È
cC:\Users\310055\source\repos\UST-Live-01\HealthCare\HealthCare.Api\DTOs\Patient\UpdatePatientDto.cs
	namespace 	

HealthCare
 
. 
Api 
. 
DTOs 
. 
Patient %
{ 
public 

class 
UpdatePatientDto !
{ 
[		 	
Required			 
]		 
[

 	
	MaxLength

	 
(

 
$num

 
)

 
]

 
[ 	
RegularExpression	 
( 
$str +
,+ ,
ErrorMessage- 9
=: ;
$str< d
)d e
]e f
public 
string 
FullName 
{  
get! $
;$ %
set& )
;) *
}+ ,
=- .
null/ 3
!3 4
;4 5
[ 	
Required	 
] 
[ 	
	MaxLength	 
( 
$num 
) 
] 
[ 	
RegularExpression	 
( 
$str *
,* +
ErrorMessage, 8
=9 :
$str; y
)y z
]z {
public 
string 
PhoneNumber !
{" #
get$ '
;' (
set) ,
;, -
}. /
=0 1
null2 6
!6 7
;7 8
[ 	
Required	 
] 
[ 	
	MaxLength	 
( 
$num 
) 
] 
[ 	
EmailAddress	 
] 
public 
string 
Email 
{ 
get !
;! "
set# &
;& '
}( )
=* +
null, 0
!0 1
;1 2
[ 	
Required	 
] 
[ 	
	MaxLength	 
( 
$num 
) 
] 
[ 	
RegularExpression	 
( 
$str 3
,3 4
ErrorMessage5 A
=B C
$strD l
)l m
]m n
public 
string 
Gender 
{ 
get "
;" #
set$ '
;' (
}) *
=+ ,
null- 1
!1 2
;2 3
[ 	
	MaxLength	 
( 
$num 
) 
] 
[ 	
RegularExpression	 
( 
$str ,
,, -
ErrorMessage. :
=; <
$str= a
)a b
]b c
public 
string 
? 
InsuranceId "
{# $
get% (
;( )
set* -
;- .
}/ 0
}   
}!! “
aC:\Users\310055\source\repos\UST-Live-01\HealthCare\HealthCare.Api\DTOs\Patient\PatientListDto.cs
	namespace 	

HealthCare
 
. 
Api 
. 
DTOs 
. 
Patient %
{ 
public 

class 
PatientListDto 
{ 
public 
int 
	PatientId 
{ 
get "
;" #
set$ '
;' (
}) *
public 
string 
FullName 
{  
get! $
;$ %
set& )
;) *
}+ ,
=- .
null/ 3
!3 4
;4 5
public 
string 
Email 
{ 
get !
;! "
set# &
;& '
}( )
=* +
null, 0
!0 1
;1 2
public 
string 
PhoneNumber !
{" #
get$ '
;' (
set) ,
;, -
}. /
=0 1
null2 6
!6 7
;7 8
public		 
string		 
Gender		 
{		 
get		 "
;		" #
set		$ '
;		' (
}		) *
=		+ ,
null		- 1
!		1 2
;		2 3
public

 
string

 
InsuranceId

 !
{

" #
get

$ '
;

' (
set

) ,
;

, -
}

. /
=

0 1
null

2 6
!

6 7
;

7 8
} 
} Û
`C:\Users\310055\source\repos\UST-Live-01\HealthCare\HealthCare.Api\DTOs\Patient\PatientFilter.cs
	namespace 	

HealthCare
 
. 
Api 
. 
DTOs 
. 
Patient %
{ 
public 

class 
PatientFilter 
:  
PaginationParams! 1
{ 
public 
bool 
? 
HasInsurance !
{" #
get$ '
;' (
set) ,
;, -
}. /
public 
string 
? 
FullName 
{  !
get" %
;% &
set' *
;* +
}, -
} 
} ˙%
cC:\Users\310055\source\repos\UST-Live-01\HealthCare\HealthCare.Api\DTOs\Patient\CreatePatientDto.cs
	namespace 	

HealthCare
 
. 
Api 
. 
DTOs 
. 
Patient %
{ 
public 

class 
CreatePatientDto !
{ 
[ 	
Required	 
] 
[ 	
	MaxLength	 
( 
$num 
) 
] 
[		 	
RegularExpression			 
(		 
$str		 +
,		+ ,
ErrorMessage		- 9
=		: ;
$str		< d
)		d e
]		e f
public

 
string

 
FullName

 
{

  
get

! $
;

$ %
set

& )
;

) *
}

+ ,
=

- .
null

/ 3
!

3 4
;

4 5
[ 	
Required	 
] 
[ 	0
$CustomDateOfBirthValidationAttribute	 -
]- .
public 
DateOnly 
? 
DateOfBirth $
{% &
get' *
;* +
set, /
;/ 0
}1 2
[ 	
Required	 
] 
[ 	
	MaxLength	 
( 
$num 
) 
] 
[ 	
RegularExpression	 
( 
$str 3
,3 4
ErrorMessage5 A
=B C
$strD l
)l m
]m n
public 
string 
Gender 
{ 
get "
;" #
set$ '
;' (
}) *
=+ ,
null- 1
!1 2
;2 3
[ 	
Required	 
] 
[ 	
	MaxLength	 
( 
$num 
) 
] 
[ 	
RegularExpression	 
( 
$str *
,* +
ErrorMessage, 8
=9 :
$str; y
)y z
]z {
public 
string 
PhoneNumber !
{" #
get$ '
;' (
set) ,
;, -
}. /
=0 1
null2 6
!6 7
;7 8
[ 	
Required	 
] 
[ 	
	MaxLength	 
( 
$num 
) 
] 
[ 	
EmailAddress	 
] 
public 
string 
Email 
{ 
get !
;! "
set# &
;& '
}( )
=* +
null, 0
!0 1
;1 2
[ 	
Required	 
] 
public   
string   
Password   
{    
get  ! $
;  $ %
set  & )
;  ) *
}  + ,
=  - .
null  / 3
!  3 4
;  4 5
["" 	
	MaxLength""	 
("" 
$num"" 
)"" 
]"" 
[## 	
RegularExpression##	 
(## 
$str## ,
,##, -
ErrorMessage##. :
=##; <
$str##= a
)##a b
]##b c
public$$ 
string$$ 
?$$ 
InsuranceId$$ "
{$$# $
get$$% (
;$$( )
set$$* -
;$$- .
}$$/ 0
}%% 
['' 
AttributeUsage'' 
('' 
AttributeTargets'' $
.''$ %
Property''% -
|''. /
AttributeTargets''0 @
.''@ A
Field''A F
,''F G
AllowMultiple''H U
=''V W
false''X ]
)''] ^
]''^ _
public(( 

class(( 0
$CustomDateOfBirthValidationAttribute(( 5
:((6 7
ValidationAttribute((8 K
{)) 
	protected** 
override** 
ValidationResult** +
?**+ ,
IsValid**- 4
(**4 5
object**5 ;
?**; <
value**= B
,**B C
ValidationContext**D U
validationContext**V g
)**g h
{++ 	
if,, 
(,, 
value,, 
is,, 
DateOnly,, !
dob,," %
&&,,& (
dob,,) ,
>=,,- /
DateOnly,,0 8
.,,8 9
FromDateTime,,9 E
(,,E F
DateTime,,F N
.,,N O
Today,,O T
),,T U
),,U V
{-- 
return.. 
new.. 
ValidationResult.. +
(..+ ,
$str.., P
)..P Q
;..Q R
}// 
return11 
ValidationResult11 #
.11# $
Success11$ +
;11+ ,
}22 	
}33 
}44 ‹
[C:\Users\310055\source\repos\UST-Live-01\HealthCare\HealthCare.Api\DTOs\PaginationParams.cs
	namespace 	

HealthCare
 
. 
Api 
. 
DTOs 
{ 
public 

class 
PaginationParams !
{ 
private 
const 
int 
MaxPageSize %
=& '
$num( +
;+ ,
private 
int 
	_pageSize 
= 
$num  "
;" #
public 
int 

PageNumber 
{ 
get  #
;# $
set% (
;( )
}* +
=, -
$num. /
;/ 0
public

 
int

 
?

 
PageSize

 
{ 	
get 
=> 
	_pageSize 
; 
set 
{ 
if 
( 
value 
. 
HasValue "
)" #
{ 
	_pageSize 
= 
value  %
.% &
Value& +
>, -
MaxPageSize. 9
? 
MaxPageSize %
: 
value 
.  
Value  %
;% &
} 
} 
} 	
public 
int 
EffectivePageSize $
=>% '
	_pageSize( 1
;1 2
} 
} ß
mC:\Users\310055\source\repos\UST-Live-01\HealthCare\HealthCare.Api\DTOs\HealthRecord\UpdateHealthRecordDto.cs
	namespace 	

HealthCare
 
. 
Api 
. 
DTOs 
. 
HealthRecord *
{ 
public 

class !
UpdateHealthRecordDto &
{ 
[ 	
Required	 
] 
[ 	
	MaxLength	 
( 
$num 
) 
] 
[		 	
RegularExpression			 
(		 
$str		 .
,		. /
ErrorMessage		0 <
=		= >
$str		? q
)		q r
]		r s
public

 
string

 
	Diagnosis

 
{

  !
get

" %
;

% &
set

' *
;

* +
}

, -
=

. /
null

0 4
!

4 5
;

5 6
[ 	
Required	 
] 
[ 	
	MaxLength	 
( 
$num 
) 
] 
[ 	
RegularExpression	 
( 
$str .
,. /
ErrorMessage0 <
== >
$str? t
)t u
]u v
public 
string 
Prescription "
{# $
get% (
;( )
set* -
;- .
}/ 0
=1 2
null3 7
!7 8
;8 9
[ 	
	MaxLength	 
( 
$num 
) 
] 
[ 	
RegularExpression	 
( 
$str .
,. /
ErrorMessage0 <
== >
$str? m
)m n
]n o
public 
string 
? 
Notes 
{ 
get "
;" #
set$ '
;' (
}) *
} 
} è
VC:\Users\310055\source\repos\UST-Live-01\HealthCare\HealthCare.Api\DTOs\PagedResult.cs
	namespace 	

HealthCare
 
. 
Api 
. 
DTOs 
{ 
public 

class 
PagedResult 
< 
T 
> 
{ 
public 
IEnumerable 
< 
T 
> 
Items #
{$ %
get& )
;) *
set+ .
;. /
}0 1
=2 3
[4 5
]5 6
;6 7
public 
int 

PageNumber 
{ 
get  #
;# $
set% (
;( )
}* +
public 
int 
PageSize 
{ 
get !
;! "
set# &
;& '
}( )
public 
int 

TotalCount 
{ 
get  #
;# $
set% (
;( )
}* +
public		 
int		 

TotalPages		 
=>		  
(		! "
int		" %
)		% &
Math		& *
.		* +
Ceiling		+ 2
(		2 3

TotalCount		3 =
/		> ?
(		@ A
double		A G
)		G H
PageSize		H P
)		P Q
;		Q R
}

 
} ⁄
kC:\Users\310055\source\repos\UST-Live-01\HealthCare\HealthCare.Api\DTOs\HealthRecord\HealthRecordListDto.cs
	namespace 	

HealthCare
 
. 
Api 
. 
DTOs 
. 
HealthRecord *
{ 
public 

class 
HealthRecordListDto $
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
public 
string 
PatientName !
{" #
get$ '
;' (
set) ,
;, -
}. /
=0 1
null2 6
!6 7
;7 8
public 
string 

DoctorName  
{! "
get# &
;& '
set( +
;+ ,
}- .
=/ 0
null1 5
!5 6
;6 7
public 
DateTime 
	VisitDate !
{" #
get$ '
;' (
set) ,
;, -
}. /
public		 
string		 
	Diagnosis		 
{		  !
get		" %
;		% &
set		' *
;		* +
}		, -
=		. /
null		0 4
!		4 5
;		5 6
public

 
string

 
Prescription

 "
{

# $
get

% (
;

( )
set

* -
;

- .
}

/ 0
=

1 2
null

3 7
!

7 8
;

8 9
public 
string 
? 
Notes 
{ 
get "
;" #
set$ '
;' (
}) *
} 
} ›
jC:\Users\310055\source\repos\UST-Live-01\HealthCare\HealthCare.Api\DTOs\HealthRecord\HealthRecordFilter.cs
	namespace 	

HealthCare
 
. 
Api 
. 
DTOs 
. 
HealthRecord *
{ 
public 

class 
HealthRecordFilter #
:$ %
PaginationParams& 6
{ 
public 
DateOnly 
? 
	VisitDate "
{# $
get% (
;( )
set* -
;- .
}/ 0
} 
} ≈
mC:\Users\310055\source\repos\UST-Live-01\HealthCare\HealthCare.Api\DTOs\HealthRecord\CreateHealthRecordDto.cs
	namespace 	

HealthCare
 
. 
Api 
. 
DTOs 
. 
HealthRecord *
{ 
public 

class !
CreateHealthRecordDto &
{ 
[ 	
Required	 
] 
public 
required 
int 
AppointmentId )
{* +
get, /
;/ 0
set1 4
;4 5
}6 7
[

 	
Required

	 
]

 
public 
required 
int 
	PatientId %
{& '
get( +
;+ ,
set- 0
;0 1
}2 3
[ 	
Required	 
] 
[ 	.
"PastOrTodayDateValidationAttribute	 +
]+ ,
public 
required 
DateTime  
	VisitDate! *
{+ ,
get- 0
;0 1
set2 5
;5 6
}7 8
[ 	
Required	 
] 
[ 	
	MaxLength	 
( 
$num 
) 
] 
[ 	
RegularExpression	 
( 
$str .
,. /
ErrorMessage0 <
== >
$str? q
)q r
]r s
public 
string 
	Diagnosis 
{  !
get" %
;% &
set' *
;* +
}, -
=. /
null0 4
!4 5
;5 6
[ 	
Required	 
] 
[ 	
	MaxLength	 
( 
$num 
) 
] 
[ 	
RegularExpression	 
( 
$str .
,. /
ErrorMessage0 <
== >
$str? t
)t u
]u v
public 
string 
Prescription "
{# $
get% (
;( )
set* -
;- .
}/ 0
=1 2
null3 7
!7 8
;8 9
[ 	
	MaxLength	 
( 
$num 
) 
] 
[ 	
RegularExpression	 
( 
$str .
,. /
ErrorMessage0 <
== >
$str? m
)m n
]n o
public 
string 
? 
Notes 
{ 
get "
;" #
set$ '
;' (
}) *
} 
[   
AttributeUsage   
(   
AttributeTargets   $
.  $ %
Property  % -
|  . /
AttributeTargets  0 @
.  @ A
Field  A F
,  F G
AllowMultiple  H U
=  V W
false  X ]
)  ] ^
]  ^ _
public!! 

class!! .
"PastOrTodayDateValidationAttribute!! 3
:!!4 5
ValidationAttribute!!6 I
{"" 
	protected## 
override## 
ValidationResult## +
?##+ ,
IsValid##- 4
(##4 5
object##5 ;
?##; <
value##= B
,##B C
ValidationContext##D U
validationContext##V g
)##g h
{$$ 	
if%% 
(%% 
value%% 
is%% 
DateTime%% !
	visitDate%%" +
&&%%, .
	visitDate%%/ 8
.%%8 9
Date%%9 =
>%%> ?
DateTime%%@ H
.%%H I
Today%%I N
)%%N O
{&& 
return'' 
new'' 
ValidationResult'' +
(''+ ,
$str'', V
)''V W
;''W X
}(( 
return** 
ValidationResult** #
.**# $
Success**$ +
;**+ ,
}++ 	
},, 
}-- ¸
[C:\Users\310055\source\repos\UST-Live-01\HealthCare\HealthCare.Api\DTOs\ErrorResponseDto.cs
	namespace 	

HealthCare
 
. 
Api 
. 
Models 
{ 
public 

class 
ErrorResponse 
{ 
public 
int 

StatusCode 
{ 
get  #
;# $
set% (
;( )
}* +
public 
string 
? 
Message 
{  
get! $
;$ %
set& )
;) *
}+ ,
public 
string 
? 
Details 
{  
get! $
;$ %
set& )
;) *
}+ ,
public 
DateTime 
	TimeStamp !
{" #
get$ '
;' (
set) ,
;, -
}. /
public		 
string		 
?		 
Path		 
{		 
get		 !
;		! "
set		# &
;		& '
}		( )
} 
} π
aC:\Users\310055\source\repos\UST-Live-01\HealthCare\HealthCare.Api\DTOs\Doctor\UpdateDoctorDto.cs
	namespace 	

HealthCare
 
. 
Api 
. 
DTOs 
. 
Doctor $
{ 
public 

class 
UpdateDoctorDto  
{		 
[

 	
Required

	 
]

 
[ 	
	MaxLength	 
( 
$num 
) 
] 
[ 	
RegularExpression	 
( 
$str +
,+ ,
ErrorMessage- 9
=: ;
$str< d
)d e
]e f
public 
string 
FullName 
{  
get! $
;$ %
set& )
;) *
}+ ,
=- .
null/ 3
!3 4
;4 5
[ 	
Required	 
] 
[ 	
	MaxLength	 
( 
$num 
) 
] 
public 
string 
Specialisation $
{% &
get' *
;* +
set, /
;/ 0
}1 2
=3 4
null5 9
!9 :
;: ;
[ 	
Range	 
( 
$num 
, 
$num 
) 
] 
public 
int 
YearsOfExperience $
{% &
get' *
;* +
set, /
;/ 0
}1 2
} 
} °
_C:\Users\310055\source\repos\UST-Live-01\HealthCare\HealthCare.Api\DTOs\Doctor\DoctorListDto.cs
	namespace 	

HealthCare
 
. 
Api 
. 
DTOs 
. 
Doctor $
{ 
public 

class 
DoctorListDto 
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
public 
string 
FullName 
{  
get! $
;$ %
set& )
;) *
}+ ,
=- .
null/ 3
!3 4
;4 5
public 
string 
Specialisation $
{% &
get' *
;* +
set, /
;/ 0
}1 2
=3 4
null5 9
!9 :
;: ;
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
) *
} 
} ı
^C:\Users\310055\source\repos\UST-Live-01\HealthCare\HealthCare.Api\DTOs\Doctor\DoctorFilter.cs
	namespace 	

HealthCare
 
. 
Api 
. 
DTOs 
. 
Doctor $
{ 
public 

class 
DoctorFilter 
: 
PaginationParams  0
{ 
public 
string 
? 
Specialisation %
{& '
get( +
;+ ,
set- 0
;0 1
}2 3
public 
int 
? 
MinExperience !
{" #
get$ '
;' (
set) ,
;, -
}. /
} 
} Ã
fC:\Users\310055\source\repos\UST-Live-01\HealthCare\HealthCare.Api\DTOs\Doctor\CreateLeaveResultDto.cs
	namespace 	

HealthCare
 
. 
Api 
. 
DTOs 
. 
Doctor $
{ 
public 

class  
CreateLeaveResultDto %
{ 
public 
List 
< 
DateOnly 
> 
SkippedDates *
{+ ,
get- 0
;0 1
set2 5
;5 6
}7 8
=9 :
new; >
(> ?
)? @
;@ A
public 
List 
< 
DateOnly 
> ,
 CreatedWithCancelledAppointments >
{? @
getA D
;D E
setF I
;I J
}K L
=M N
newO R
(R S
)S T
;T U
} 
} ±
`C:\Users\310055\source\repos\UST-Live-01\HealthCare\HealthCare.Api\DTOs\Doctor\CreateLeaveDto.cs
	namespace 	

HealthCare
 
. 
Api 
. 
DTOs 
. 
Doctor $
{ 
public 

class 
CreateLeaveDto 
{ 
public 
required 
DateOnly  
	LeaveDate! *
{+ ,
get- 0
;0 1
set2 5
;5 6
}7 8
[		 	
	MaxLength			 
(		 
$num		 
)		 
]		 
public

 
string

 
?

 
Reason

 
{

 
get

  #
;

# $
set

% (
;

( )
}

* +
} 
} ó
aC:\Users\310055\source\repos\UST-Live-01\HealthCare\HealthCare.Api\DTOs\Doctor\CreateDoctorDto.cs
	namespace 	

HealthCare
 
. 
Api 
. 
DTOs 
. 
Doctor $
{ 
public 

class 
CreateDoctorDto  
{ 
[ 	
Required	 
] 
[ 	
	MaxLength	 
( 
$num 
) 
] 
[		 	
RegularExpression			 
(		 
$str		 +
,		+ ,
ErrorMessage		- 9
=		: ;
$str		< d
)		d e
]		e f
public

 
string

 
FullName

 
{

  
get

! $
;

$ %
set

& )
;

) *
}

+ ,
=

- .
null

/ 3
!

3 4
;

4 5
[ 	
Required	 
] 
[ 	
	MaxLength	 
( 
$num 
) 
] 
public 
string 
Specialisation $
{% &
get' *
;* +
set, /
;/ 0
}1 2
=3 4
null5 9
!9 :
;: ;
[ 	
Required	 
] 
[ 	
	MaxLength	 
( 
$num 
) 
] 
[ 	
EmailAddress	 
] 
public 
string 
Email 
{ 
get !
;! "
set# &
;& '
}( )
=* +
null, 0
!0 1
;1 2
[ 	
Required	 
] 
public 
string 
Password 
{  
get! $
;$ %
set& )
;) *
}+ ,
=- .
null/ 3
!3 4
;4 5
[ 	
Required	 
] 
[ 	
Range	 
( 
$num 
, 
$num 
) 
] 
public 
int 
YearsOfExperience $
{% &
get' *
;* +
set, /
;/ 0
}1 2
[ 	
Required	 
] 
[ 	
Range	 
( 
$num 
, 
$num 
, 
ErrorMessage '
=( )
$str* P
)P Q
]Q R
public 
decimal 
ConsultationFee &
{' (
get) ,
;, -
set. 1
;1 2
}3 4
[   	
Required  	 
]   
public!! 
List!! 
<!! 
string!! 
>!! 
	TimeSlots!! %
{!!& '
get!!( +
;!!+ ,
set!!- 0
;!!0 1
}!!2 3
=!!4 5
new!!6 9
(!!9 :
)!!: ;
;!!; <
}"" 
}## ≈
bC:\Users\310055\source\repos\UST-Live-01\HealthCare\HealthCare.Api\DTOs\Authentication\LoginDto.cs
	namespace 	

HealthCare
 
. 
Api 
. 
DTOs 
. 
Auth "
{ 
public 

class 
LoginDto 
{ 
public 
string 
Email 
{ 
get !
;! "
set# &
;& '
}( )
=* +
string, 2
.2 3
Empty3 8
;8 9
public 
string 
Password 
{  
get! $
;$ %
set& )
;) *
}+ ,
=- .
string/ 5
.5 6
Empty6 ;
;; <
} 
} Ã
kC:\Users\310055\source\repos\UST-Live-01\HealthCare\HealthCare.Api\DTOs\Authentication\ChangePasswordDto.cs
	namespace 	

HealthCare
 
. 
Api 
. 
DTOs 
. 
Auth "
{ 
public 

class 
ChangePasswordDto "
{ 
[ 	
Required	 
] 
public 
string 
CurrentPassword %
{& '
get( +
;+ ,
set- 0
;0 1
}2 3
=4 5
string6 <
.< =
Empty= B
;B C
[

 	
Required

	 
]

 
public 
string 
NewPassword !
{" #
get$ '
;' (
set) ,
;, -
}. /
=0 1
string2 8
.8 9
Empty9 >
;> ?
} 
} Ø
iC:\Users\310055\source\repos\UST-Live-01\HealthCare\HealthCare.Api\DTOs\Authentication\AuthResponseDto.cs
	namespace 	

HealthCare
 
. 
Api 
. 
DTOs 
. 
Auth "
{ 
public 

class 
AuthResponseDto  
{ 
public 
string 
AccessToken !
{" #
get$ '
;' (
set) ,
;, -
}. /
=0 1
string2 8
.8 9
Empty9 >
;> ?
public 
string 
Message 
{ 
get  #
;# $
set% (
;( )
}* +
=, -
string. 4
.4 5
Empty5 :
;: ;
public 
string 
Role 
{ 
get  
;  !
set" %
;% &
}' (
=) *
string+ 1
.1 2
Empty2 7
;7 8
public 
int 
? 
	PatientId 
{ 
get  #
;# $
set% (
;( )
}* +
public		 
int		 
?		 
DoctorId		 
{		 
get		 "
;		" #
set		$ '
;		' (
}		) *
public 
int 
	ExpiresIn 
{ 
get "
;" #
set$ '
;' (
}) *
} 
} ê
kC:\Users\310055\source\repos\UST-Live-01\HealthCare\HealthCare.Api\DTOs\Appointment\UpdateAppointmentDto.cs
	namespace 	

HealthCare
 
. 
Api 
. 
DTOs 
. 
Appointment )
{ 
public 

class  
UpdateAppointmentDto %
{ 
[ 	
Required	 
] 
[ 	
	MaxLength	 
( 
$num 
) 
] 
public		 
string		 
Status		 
{		 
get		 "
;		" #
set		$ '
;		' (
}		) *
=		+ ,
null		- 1
!		1 2
;		2 3
[ 	
	MaxLength	 
( 
$num 
) 
] 
public 
string 
? 
CancellationReason )
{* +
get, /
;/ 0
set1 4
;4 5
}6 7
} 
} Ú
kC:\Users\310055\source\repos\UST-Live-01\HealthCare\HealthCare.Api\DTOs\Appointment\CreateAppointmentDto.cs
	namespace 	

HealthCare
 
. 
Api 
. 
DTOs 
. 
Appointment )
{ 
public 

class  
CreateAppointmentDto %
{ 
public 
required 
int 
DoctorId $
{% &
get' *
;* +
set, /
;/ 0
}1 2
[		 	)
FutureDateValidationAttribute			 &
]		& '
public

 
required

 
DateOnly

  
ScheduledDate

! .
{

/ 0
get

1 4
;

4 5
set

6 9
;

9 :
}

; <
[ 	
Required	 
] 
[ 	
	MaxLength	 
( 
$num 
) 
] 
public 
string 
TimeSlot 
{  
get! $
;$ %
set& )
;) *
}+ ,
=- .
null/ 3
!3 4
;4 5
} 
[ 
AttributeUsage 
( 
AttributeTargets $
.$ %
Property% -
|. /
AttributeTargets0 @
.@ A
FieldA F
,F G
AllowMultipleH U
=V W
falseX ]
)] ^
]^ _
public 

class )
FutureDateValidationAttribute .
:/ 0
ValidationAttribute1 D
{ 
	protected 
override 
ValidationResult +
?+ ,
IsValid- 4
(4 5
object5 ;
?; <
value= B
,B C
ValidationContextD U
validationContextV g
)g h
{ 	
if 
( 
value 
is 
DateOnly !
date" &
&&' )
date* .
<=/ 1
DateOnly2 :
.: ;
FromDateTime; G
(G H
DateTimeH P
.P Q
TodayQ V
)V W
)W X
{ 
return 
new 
ValidationResult +
(+ ,
$str, S
)S T
;T U
} 
return 
ValidationResult #
.# $
Success$ +
;+ ,
} 	
} 
} ò	
kC:\Users\310055\source\repos\UST-Live-01\HealthCare\HealthCare.Api\DTOs\Appointment\AppointmentReportDto.cs
	namespace 	

HealthCare
 
. 
Api 
. 
DTOs 
. 
Appointment )
{ 
public 

class  
AppointmentReportDto %
{ 
public 
DateOnly 
Date 
{ 
get "
;" #
set$ '
;' (
}) *
public 
int 
PendingCount 
{  !
get" %
;% &
set' *
;* +
}, -
public 
int 
ConfirmedCount !
{" #
get$ '
;' (
set) ,
;, -
}. /
public		 
int		 
CancelledCount		 !
{		" #
get		$ '
;		' (
set		) ,
;		, -
}		. /
public 
int 
CompletedCount !
{" #
get$ '
;' (
set) ,
;, -
}. /
} 
} ∞
iC:\Users\310055\source\repos\UST-Live-01\HealthCare\HealthCare.Api\DTOs\Appointment\AppointmentListDto.cs
	namespace 	

HealthCare
 
. 
Api 
. 
DTOs 
. 
Appointment )
{ 
public 

class 
AppointmentListDto #
{ 
public 
int 
AppointmentId  
{! "
get# &
;& '
set( +
;+ ,
}- .
public 
string 
PatientName !
{" #
get$ '
;' (
set) ,
;, -
}. /
=0 1
null2 6
!6 7
;7 8
public 
string 

DoctorName  
{! "
get# &
;& '
set( +
;+ ,
}- .
=/ 0
null1 5
!5 6
;6 7
public 
DateOnly 
ScheduledDate %
{& '
get( +
;+ ,
set- 0
;0 1
}2 3
public		 
string		 
TimeSlot		 
{		  
get		! $
;		$ %
set		& )
;		) *
}		+ ,
=		- .
null		/ 3
!		3 4
;		4 5
public

 
string

 
Status

 
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
) *
=

+ ,
null

- 1
!

1 2
;

2 3
} 
} Ü
hC:\Users\310055\source\repos\UST-Live-01\HealthCare\HealthCare.Api\DTOs\Appointment\AppointmentFilter.cs
	namespace 	

HealthCare
 
. 
Api 
. 
DTOs 
. 
Appointment )
{ 
public 

class 
AppointmentFilter "
:# $
PaginationParams% 5
{ 
public 
string 
? 
Status 
{ 
get  #
;# $
set% (
;( )
}* +
public 
DateOnly 
? 
ScheduledDate &
{' (
get) ,
;, -
set. 1
;1 2
}3 4
} 
} ‹
UC:\Users\310055\source\repos\UST-Live-01\HealthCare\HealthCare.Api\Data\UserSeeder.cs
	namespace 	

HealthCare
 
. 
Api 
. 
Data 
{ 
public 

static 
class 

UserSeeder "
{ 
public 
static 
async 
Task  
SeedAdminAsync! /
(/ 0
UserManager0 ;
<; <
IdentityUser< H
>H I
userManagerJ U
,U V
RoleManagerW b
<b c
IdentityRolec o
>o p
roleManagerq |
,| }
IConfiguration	~ å
config
ç ì
)
ì î
{		 	
var

 

adminEmail

 
=

 
config

 #
[

# $
$str

$ 9
]

9 :
;

: ;
var 
adminPassword 
= 
config  &
[& '
$str' ?
]? @
;@ A
var 
existingAdmin 
= 
await  %
userManager& 1
.1 2
FindByEmailAsync2 B
(B C

adminEmailC M
!M N
)N O
;O P
if 
( 
existingAdmin 
==  
null! %
)% &
{ 
var 
admin 
= 
new 
IdentityUser  ,
{ 
UserName 
= 

adminEmail )
,) *
Email 
= 

adminEmail &
,& '
EmailConfirmed "
=# $
true% )
,) *
} 
; 
var 
result 
= 
await "
userManager# .
.. /
CreateAsync/ :
(: ;
admin; @
,@ A
adminPasswordB O
!O P
)P Q
;Q R
if 
( 
result 
. 
	Succeeded $
)$ %
{ 
await 
userManager %
.% &
AddToRoleAsync& 4
(4 5
admin5 :
,: ;
$str< C
)C D
;D E
} 
else 
{ 
throw   
new   %
InvalidOperationException   7
(  7 8
$str  8 Q
+  R S
string!! 
.!! 
Join!! #
(!!# $
$str!!$ (
,!!( )
result!!* 0
.!!0 1
Errors!!1 7
.!!7 8
Select!!8 >
(!!> ?
e!!? @
=>!!A C
e!!D E
.!!E F
Description!!F Q
)!!Q R
)!!R S
)!!S T
;!!T U
}"" 
}## 
}$$ 	
}&& 
}'' ä
UC:\Users\310055\source\repos\UST-Live-01\HealthCare\HealthCare.Api\Data\RoleSeeder.cs
	namespace 	

HealthCare
 
. 
Api 
. 
Data 
{ 
public 

static 
class 

RoleSeeder "
{ 
public 
static 
async 
Task  
SeedRolesAsync! /
(/ 0
RoleManager0 ;
<; <
IdentityRole< H
>H I
roleManagerJ U
)U V
{ 	
string		 
[		 
]		 
roles		 
=		 
{		 
$str		 &
,		& '
$str		( 1
,		1 2
$str		3 ;
}		< =
;		= >
foreach

 
(

 
var

 
role

 
in

  
roles

! &
)

& '
{ 
if 
( 
! 
await 
roleManager &
.& '
RoleExistsAsync' 6
(6 7
role7 ;
); <
)< =
{ 
await 
roleManager %
.% &
CreateAsync& 1
(1 2
new2 5
IdentityRole6 B
(B C
roleC G
)G H
)H I
;I J
} 
} 
} 	
} 
} ÕN
^C:\Users\310055\source\repos\UST-Live-01\HealthCare\HealthCare.Api\Data\HealthCareDbContext.cs
	namespace 	

HealthCare
 
. 
Api 
. 
Data 
{ 
public 

class 
HealthCareDbContext $
:% &
IdentityDbContext' 8
<8 9
IdentityUser9 E
>E F
{		 
public 
HealthCareDbContext "
(" #
DbContextOptions# 3
<3 4
HealthCareDbContext4 G
>G H
optionsI P
)P Q
:R S
baseT X
(X Y
optionsY `
)` a
{b c
}d e
public 
DbSet 
< 
Patient 
> 
Patients &
=>' )
Set* -
<- .
Patient. 5
>5 6
(6 7
)7 8
;8 9
public 
DbSet 
< 
Doctor 
> 
Doctors $
=>% '
Set( +
<+ ,
Doctor, 2
>2 3
(3 4
)4 5
;5 6
public 
DbSet 
< 
Appointment  
>  !
Appointments" .
=>/ 1
Set2 5
<5 6
Appointment6 A
>A B
(B C
)C D
;D E
public 
DbSet 
< 
HealthRecord !
>! "
HealthRecords# 0
=>1 3
Set4 7
<7 8
HealthRecord8 D
>D E
(E F
)F G
;G H
public 
DbSet 
< 
AvailableSlots #
># $
AvailableSlots% 3
=>4 6
Set7 :
<: ;
AvailableSlots; I
>I J
(J K
)K L
;L M
public 
DbSet 
< 
DoctorLeaves !
>! "
DoctorLeaves# /
=>0 2
Set3 6
<6 7
DoctorLeaves7 C
>C D
(D E
)E F
;F G
	protected 
override 
void 
OnModelCreating  /
(/ 0
ModelBuilder0 <
builder= D
)D E
{ 	
base 
. 
OnModelCreating  
(  !
builder! (
)( )
;) *
builder 
. 
Entity 
< 
Appointment &
>& '
(' (
)( )
. 
HasIndex 
( 
a 
=> 
new "
{# $
a% &
.& '
DoctorId' /
,/ 0
a1 2
.2 3
ScheduledDate3 @
,@ A
aB C
.C D
TimeSlotD L
}M N
)N O
. 
IsUnique 
( 
) 
. 
	HasFilter 
( 
$str 4
)4 5
. 
HasDatabaseName  
(  !
$str! C
)C D
;D E
builder   
.   
Entity   
<   
Appointment   &
>  & '
(  ' (
)  ( )
.!! 
HasIndex!! 
(!! 
a!! 
=>!! 
new!! "
{!!# $
a!!% &
.!!& '
DoctorId!!' /
,!!/ 0
a!!1 2
.!!2 3
ScheduledDate!!3 @
}!!A B
)!!B C
."" 
HasDatabaseName""  
(""  !
$str""! >
)""> ?
;""? @
builder$$ 
.$$ 
Entity$$ 
<$$ 
Appointment$$ &
>$$& '
($$' (
)$$( )
.%% 
HasIndex%% 
(%% 
a%% 
=>%% 
new%% "
{%%# $
a%%% &
.%%& '
	PatientId%%' 0
,%%0 1
a%%2 3
.%%3 4
ScheduledDate%%4 A
}%%B C
)%%C D
.&& 
HasDatabaseName&&  
(&&  !
$str&&! ?
)&&? @
;&&@ A
builder(( 
.(( 
Entity(( 
<(( 
HealthRecord(( '
>((' (
(((( )
)(() *
.)) 
HasIndex)) 
()) 
hr)) 
=>)) 
new))  #
{))$ %
hr))& (
.))( )
	PatientId))) 2
,))2 3
hr))4 6
.))6 7
	VisitDate))7 @
}))A B
)))B C
.** 
HasDatabaseName**  
(**  !
$str**! E
)**E F
;**F G
builder.. 
... 
Entity.. 
<.. 
Patient.. "
>.." #
(..# $
)..$ %
.// 
HasOne// 
(// 
p// 
=>// 
p// 
.// 
User// #
)//# $
.00 
WithOne00 
(00 
)00 
.11 
HasForeignKey11 
<11 
Patient11 &
>11& '
(11' (
p11( )
=>11* ,
p11- .
.11. /
UserId11/ 5
)115 6
.22 
OnDelete22 
(22 
DeleteBehavior22 (
.22( )
Cascade22) 0
)220 1
;221 2
builder44 
.44 
Entity44 
<44 
Doctor44 !
>44! "
(44" #
)44# $
.55 
HasOne55 
(55 
d55 
=>55 
d55 
.55 
User55 #
)55# $
.66 
WithOne66 
(66 
)66 
.77 
HasForeignKey77 
<77 
Doctor77 %
>77% &
(77& '
d77' (
=>77) +
d77, -
.77- .
UserId77. 4
)774 5
.88 
OnDelete88 
(88 
DeleteBehavior88 (
.88( )
Cascade88) 0
)880 1
;881 2
builder:: 
.:: 
Entity:: 
<:: 
Appointment:: &
>::& '
(::' (
)::( )
.;; 
HasOne;; 
(;; 
a;; 
=>;; 
a;; 
.;; 
Patient;; &
);;& '
.<< 
WithMany<< 
(<< 
p<< 
=><< 
p<<  
.<<  !
Appointments<<! -
)<<- .
.== 
HasForeignKey== 
(== 
a==  
=>==! #
a==$ %
.==% &
	PatientId==& /
)==/ 0
.>> 
OnDelete>> 
(>> 
DeleteBehavior>> (
.>>( )
Restrict>>) 1
)>>1 2
;>>2 3
builder@@ 
.@@ 
Entity@@ 
<@@ 
Appointment@@ &
>@@& '
(@@' (
)@@( )
.AA 
HasOneAA 
(AA 
aAA 
=>AA 
aAA 
.AA 
DoctorAA %
)AA% &
.BB 
WithManyBB 
(BB 
dBB 
=>BB 
dBB  
.BB  !
AppointmentsBB! -
)BB- .
.CC 
HasForeignKeyCC 
(CC 
aCC  
=>CC! #
aCC$ %
.CC% &
DoctorIdCC& .
)CC. /
.DD 
OnDeleteDD 
(DD 
DeleteBehaviorDD (
.DD( )
RestrictDD) 1
)DD1 2
;DD2 3
builderFF 
.FF 
EntityFF 
<FF 
HealthRecordFF '
>FF' (
(FF( )
)FF) *
.GG 
HasOneGG 
(GG 
hrGG 
=>GG 
hrGG  
.GG  !
AppointmentGG! ,
)GG, -
.HH 
WithOneHH 
(HH 
aHH 
=>HH 
aHH 
.HH  
HealthRecordHH  ,
)HH, -
.II 
HasForeignKeyII 
<II 
HealthRecordII +
>II+ ,
(II, -
hrII- /
=>II0 2
hrII3 5
.II5 6
AppointmentIdII6 C
)IIC D
.JJ 
OnDeleteJJ 
(JJ 
DeleteBehaviorJJ (
.JJ( )
RestrictJJ) 1
)JJ1 2
;JJ2 3
builderLL 
.LL 
EntityLL 
<LL 
HealthRecordLL '
>LL' (
(LL( )
)LL) *
.MM 
HasOneMM 
(MM 
hrMM 
=>MM 
hrMM  
.MM  !
PatientMM! (
)MM( )
.NN 
WithManyNN 
(NN 
pNN 
=>NN 
pNN  
.NN  !
HealthRecordsNN! .
)NN. /
.OO 
HasForeignKeyOO 
(OO 
hrOO !
=>OO" $
hrOO% '
.OO' (
	PatientIdOO( 1
)OO1 2
.PP 
OnDeletePP 
(PP 
DeleteBehaviorPP (
.PP( )
RestrictPP) 1
)PP1 2
;PP2 3
builderRR 
.RR 
EntityRR 
<RR 
HealthRecordRR '
>RR' (
(RR( )
)RR) *
.SS 
HasOneSS 
(SS 
hrSS 
=>SS 
hrSS  
.SS  !
DoctorSS! '
)SS' (
.TT 
WithManyTT 
(TT 
dTT 
=>TT 
dTT  
.TT  !
HealthRecordsTT! .
)TT. /
.UU 
HasForeignKeyUU 
(UU 
hrUU !
=>UU" $
hrUU% '
.UU' (
DoctorIdUU( 0
)UU0 1
.VV 
OnDeleteVV 
(VV 
DeleteBehaviorVV (
.VV( )
RestrictVV) 1
)VV1 2
;VV2 3
}WW 	
}XX 
}YY £
cC:\Users\310055\source\repos\UST-Live-01\HealthCare\HealthCare.Api\Controllers\PatientController.cs
	namespace 	

HealthCare
 
. 
Api 
. 
Controllers $
{ 
[		 
Route		 

(		
 
$str		 
)		 
]		 
[

 
ApiController

 
]

 
public 

class 
PatientController "
:# $
ControllerBase% 3
{ 
private 
readonly 
IPatientService (
_patientService) 8
;8 9
public 
PatientController  
(  !
IPatientService! 0
patientService1 ?
)? @
{ 	
_patientService 
= 
patientService ,
;, -
} 	
[ 	
HttpGet	 
( 
$str 
) 
] 
[ 	
	Authorize	 
( !
AuthenticationSchemes (
=) *
JwtBearerDefaults+ <
.< = 
AuthenticationScheme= Q
)Q R
]R S
[ 	
	Authorize	 
( 
Roles 
= 
$str $
)$ %
]% &
public 
async 
Task 
< 
IActionResult '
>' (
GetMyProfile) 5
(5 6
)6 7
{ 	
var 
	patientId 
= "
GetPatientIdFromClaims 2
(2 3
)3 4
;4 5
var 
result 
= 
await 
_patientService .
.. /
GetByIdAsync/ ;
(; <
	patientId< E
)E F
;F G
return 
Ok 
( 
result 
) 
; 
} 	
[ 	
HttpPut	 
( 
$str 
) 
] 
[ 	
	Authorize	 
( !
AuthenticationSchemes (
=) *
JwtBearerDefaults+ <
.< = 
AuthenticationScheme= Q
)Q R
]R S
[   	
	Authorize  	 
(   
Roles   
=   
$str   $
)  $ %
]  % &
public!! 
async!! 
Task!! 
<!! 
IActionResult!! '
>!!' (
UpdatePatient!!) 6
(!!6 7
[!!7 8
FromBody!!8 @
]!!@ A
UpdatePatientDto!!B R
dto!!S V
)!!V W
{"" 	
if## 
(## 
!## 

ModelState## 
.## 
IsValid## #
)### $
return$$ 

BadRequest$$ !
($$! "

ModelState$$" ,
)$$, -
;$$- .
var&& 
	patientId&& 
=&& "
GetPatientIdFromClaims&& 2
(&&2 3
)&&3 4
;&&4 5
await'' 
_patientService'' !
.''! "
UpdateAsync''" -
(''- .
	patientId''. 7
,''7 8
dto''9 <
)''< =
;''= >
return(( 
Ok(( 
((( 
)(( 
;(( 
})) 	
private++ 
int++ "
GetPatientIdFromClaims++ *
(++* +
)+++ ,
{,, 	
var-- 
claim-- 
=-- 
User-- 
.-- 
	FindFirst-- &
(--& '
$str--' 2
)--2 3
??.. 
throw.. 
new.. %
InvalidOperationException.. 6
(..6 7
$str..7 \
)..\ ]
;..] ^
return00 
int00 
.00 
Parse00 
(00 
claim00 "
.00" #
Value00# (
)00( )
;00) *
}11 	
}22 
}33  2
hC:\Users\310055\source\repos\UST-Live-01\HealthCare\HealthCare.Api\Controllers\PatientAdminController.cs
	namespace 	

HealthCare
 
. 
Api 
. 
Controllers $
{		 
[

 
Route

 

(


 
$str

 
)

  
]

  !
[ 
ApiController 
] 
public 

class "
PatientAdminController '
:( )
ControllerBase* 8
{ 
private 
readonly 
IPatientService (
_patientService) 8
;8 9
public "
PatientAdminController %
(% &
IPatientService& 5
patientService6 D
)D E
{ 	
_patientService 
= 
patientService ,
;, -
} 	
[ 	
HttpGet	 
( 
$str 
) 
] 
[ 	
	Authorize	 
( !
AuthenticationSchemes (
=) *
JwtBearerDefaults+ <
.< = 
AuthenticationScheme= Q
)Q R
]R S
[ 	
	Authorize	 
( 
Roles 
= 
$str "
)" #
]# $
public 
async 
Task 
< 
IActionResult '
>' (
GetPatientById) 7
(7 8
int8 ;
id< >
)> ?
{ 	
var 
result 
= 
await 
_patientService .
.. /
GetByIdAsync/ ;
(; <
id< >
)> ?
;? @
return 
Ok 
( 
result 
) 
; 
} 	
[ 	
HttpGet	 
( 
$str 
) 
] 
[ 	
	Authorize	 
( !
AuthenticationSchemes (
=) *
JwtBearerDefaults+ <
.< = 
AuthenticationScheme= Q
)Q R
]R S
[   	
	Authorize  	 
(   
Roles   
=   
$str   "
)  " #
]  # $
public!! 
async!! 
Task!! 
<!! 
IActionResult!! '
>!!' (
GetAllPatient!!) 6
(!!6 7
[!!7 8
	FromQuery!!8 A
]!!A B
PatientFilter!!C P
filter!!Q W
)!!W X
{"" 	
if## 
(## 
!## 

ModelState## 
.## 
IsValid## #
)### $
return$$ 

BadRequest$$ !
($$! "

ModelState$$" ,
)$$, -
;$$- .
var&& 
result&& 
=&& 
await&& 
_patientService&& .
.&&. /
GetAllAsync&&/ :
(&&: ;
filter&&; A
)&&A B
;&&B C
return'' 
Ok'' 
('' 
result'' 
)'' 
;'' 
}(( 	
[** 	
HttpPut**	 
(** 
$str** 
)** 
]** 
[++ 	
	Authorize++	 
(++ !
AuthenticationSchemes++ (
=++) *
JwtBearerDefaults+++ <
.++< = 
AuthenticationScheme++= Q
)++Q R
]++R S
[,, 	
	Authorize,,	 
(,, 
Roles,, 
=,, 
$str,, "
),," #
],,# $
public-- 
async-- 
Task-- 
<-- 
IActionResult-- '
>--' (
UpdatePatient--) 6
(--6 7
int--7 :
id--; =
,--= >
[--? @
FromBody--@ H
]--H I
UpdatePatientDto--J Z
dto--[ ^
)--^ _
{.. 	
if// 
(// 
!// 

ModelState// 
.// 
IsValid// #
)//# $
return00 

BadRequest00 !
(00! "

ModelState00" ,
)00, -
;00- .
await22 
_patientService22 !
.22! "
UpdateAsync22" -
(22- .
id22. 0
,220 1
dto222 5
)225 6
;226 7
return33 
Ok33 
(33 
)33 
;33 
}44 	
[66 	
	HttpPatch66	 
(66 
$str66  
)66  !
]66! "
[77 	
	Authorize77	 
(77 !
AuthenticationSchemes77 (
=77) *
JwtBearerDefaults77+ <
.77< = 
AuthenticationScheme77= Q
)77Q R
]77R S
[88 	
	Authorize88	 
(88 
Roles88 
=88 
$str88 "
)88" #
]88# $
public99 
async99 
Task99 
<99 
IActionResult99 '
>99' (
UpdatePatientStatus99) <
(99< =
int99= @
id99A C
,99C D
[99E F
FromBody99F N
]99N O
bool99P T
isActive99U ]
)99] ^
{:: 	
await;; 
_patientService;; !
.;;! "
UpdateStatusAsync;;" 3
(;;3 4
id;;4 6
,;;6 7
isActive;;8 @
);;@ A
;;;A B
return<< 
Ok<< 
(<< 
)<< 
;<< 
}== 	
[?? 	

HttpDelete??	 
(?? 
$str?? 
)?? 
]?? 
[@@ 	
	Authorize@@	 
(@@ !
AuthenticationSchemes@@ (
=@@) *
JwtBearerDefaults@@+ <
.@@< = 
AuthenticationScheme@@= Q
)@@Q R
]@@R S
[AA 	
	AuthorizeAA	 
(AA 
RolesAA 
=AA 
$strAA "
)AA" #
]AA# $
publicBB 
asyncBB 
TaskBB 
<BB 
IActionResultBB '
>BB' (
DeletePatientBB) 6
(BB6 7
intBB7 :
idBB; =
)BB= >
{CC 	
awaitDD 
_patientServiceDD !
.DD! "
DeleteAsyncDD" -
(DD- .
idDD. 0
)DD0 1
;DD1 2
returnEE 
OkEE 
(EE 
)EE 
;EE 
}FF 	
}GG 
}HH ÷,
hC:\Users\310055\source\repos\UST-Live-01\HealthCare\HealthCare.Api\Controllers\HealthRecordController.cs
	namespace 	

HealthCare
 
. 
Api 
. 
Controllers $
{ 
[		 
Route		 

(		
 
$str		 
)		 
]		 
[

 
ApiController

 
]

 
public 

class "
HealthRecordController '
:( )
ControllerBase* 8
{ 
private 
readonly  
IHealthRecordService - 
_healthRecordService. B
;B C
public "
HealthRecordController %
(% & 
IHealthRecordService& :
healthRecordService; N
)N O
{ 	 
_healthRecordService  
=! "
healthRecordService# 6
;6 7
} 	
[ 	
HttpPost	 
( 
$str 
) 
] 
[ 	
	Authorize	 
( !
AuthenticationSchemes (
=) *
JwtBearerDefaults+ <
.< = 
AuthenticationScheme= Q
)Q R
]R S
[ 	
	Authorize	 
( 
Roles 
= 
$str #
)# $
]$ %
public 
async 
Task 
< 
IActionResult '
>' (
CreateHealthRecord) ;
(; <
[< =
FromBody= E
]E F!
CreateHealthRecordDtoG \
dto] `
)` a
{ 	
if 
( 
! 

ModelState 
. 
IsValid #
)# $
return 

BadRequest !
(! "

ModelState" ,
), -
;- .
var 
doctorId 
= !
GetDoctorIdFromClaims 0
(0 1
)1 2
;2 3
await  
_healthRecordService &
.& '
AddAsync' /
(/ 0
doctorId0 8
,8 9
dto: =
)= >
;> ?
return 
Ok 
( 
) 
; 
} 	
[!! 	
HttpGet!!	 
(!! 
$str!! &
)!!& '
]!!' (
["" 	
	Authorize""	 
("" !
AuthenticationSchemes"" (
="") *
JwtBearerDefaults""+ <
.""< = 
AuthenticationScheme""= Q
)""Q R
]""R S
[## 	
	Authorize##	 
(## 
Roles## 
=## 
$str## #
)### $
]##$ %
public$$ 
async$$ 
Task$$ 
<$$ 
IActionResult$$ '
>$$' ((
GetHealthRecordByAppointment$$) E
($$E F
int$$F I
id$$J L
)$$L M
{%% 	
var&& 
result&& 
=&& 
await&&  
_healthRecordService&& 3
.&&3 4(
GetHealthRecordByAppointment&&4 P
(&&P Q
id&&Q S
)&&S T
;&&T U
return'' 
Ok'' 
('' 
result'' 
)'' 
;'' 
}(( 	
[** 	
HttpGet**	 
(** 
$str** 
)** 
]** 
[++ 	
	Authorize++	 
(++ !
AuthenticationSchemes++ (
=++) *
JwtBearerDefaults+++ <
.++< = 
AuthenticationScheme++= Q
)++Q R
]++R S
[,, 	
	Authorize,,	 
(,, 
Roles,, 
=,, 
$str,, $
),,$ %
],,% &
public-- 
async-- 
Task-- 
<-- 
IActionResult-- '
>--' ($
GetHealthRecordByPatient--) A
(--A B
)--B C
{.. 	
var// 
	patientId// 
=// "
GetPatientIdFromClaims// 2
(//2 3
)//3 4
;//4 5
var00 
result00 
=00 
await00  
_healthRecordService00 3
.003 4$
GetHealthRecordByPatient004 L
(00L M
	patientId00M V
)00V W
;00W X
return11 
Ok11 
(11 
result11 
)11 
;11 
}22 	
private44 
int44 "
GetPatientIdFromClaims44 *
(44* +
)44+ ,
{55 	
var66 
claim66 
=66 
User66 
.66 
	FindFirst66 &
(66& '
$str66' 2
)662 3
??77 
throw77 
new77 %
InvalidOperationException77 6
(776 7
$str777 \
)77\ ]
;77] ^
return99 
int99 
.99 
Parse99 
(99 
claim99 "
.99" #
Value99# (
)99( )
;99) *
}:: 	
private<< 
int<< !
GetDoctorIdFromClaims<< )
(<<) *
)<<* +
{== 	
var>> 
claim>> 
=>> 
User>> 
.>> 
	FindFirst>> &
(>>& '
$str>>' 1
)>>1 2
???? 
throw?? 
new?? %
InvalidOperationException?? 6
(??6 7
$str??7 [
)??[ \
;??\ ]
returnAA 
intAA 
.AA 
ParseAA 
(AA 
claimAA "
.AA" #
ValueAA# (
)AA( )
;AA) *
}BB 	
}CC 
}DD Ë
mC:\Users\310055\source\repos\UST-Live-01\HealthCare\HealthCare.Api\Controllers\HealthRecordAdminController.cs
	namespace 	

HealthCare
 
. 
Api 
. 
Controllers $
{ 
[		 
Route		 

(		
 
$str		 
)		 
]		  
[

 
ApiController

 
]

 
public 

class '
HealthRecordAdminController ,
:- .
ControllerBase/ =
{ 
private 
readonly  
IHealthRecordService - 
_healthRecordService. B
;B C
public '
HealthRecordAdminController *
(* + 
IHealthRecordService+ ?
healthRecordService@ S
)S T
{ 	 
_healthRecordService  
=! "
healthRecordService# 6
;6 7
} 	
[ 	

HttpDelete	 
( 
$str 
) 
] 
[ 	
	Authorize	 
( !
AuthenticationSchemes (
=) *
JwtBearerDefaults+ <
.< = 
AuthenticationScheme= Q
)Q R
]R S
[ 	
	Authorize	 
( 
Roles 
= 
$str "
)" #
]# $
public 
async 
Task 
< 
IActionResult '
>' (
DeleteHealthRecord) ;
(; <
int< ?
id@ B
)B C
{ 	
await  
_healthRecordService &
.& '
DeleteAsync' 2
(2 3
id3 5
)5 6
;6 7
return 
Ok 
( 
) 
; 
} 	
} 
} ≤4
bC:\Users\310055\source\repos\UST-Live-01\HealthCare\HealthCare.Api\Controllers\DoctorController.cs
	namespace 	

HealthCare
 
. 
Api 
. 
Controllers $
{ 
[		 
Route		 

(		
 
$str		 
)		 
]		 
[

 
ApiController

 
]

 
public 

class 
DoctorController !
:" #
ControllerBase$ 2
{ 
private 
readonly 
IDoctorService '
_doctorService( 6
;6 7
public 
DoctorController 
(  
IDoctorService  .
doctorService/ <
)< =
{ 	
_doctorService 
= 
doctorService *
;* +
} 	
[ 	
HttpGet	 
( 
$str 
) 
] 
[ 	
	Authorize	 
( !
AuthenticationSchemes (
=) *
JwtBearerDefaults+ <
.< = 
AuthenticationScheme= Q
)Q R
]R S
[ 	
	Authorize	 
( 
Roles 
= 
$str #
)# $
]$ %
public 
async 
Task 
< 
IActionResult '
>' (
GetMyProfile) 5
(5 6
)6 7
{ 	
var 
doctorId 
= !
GetDoctorIdFromClaims 0
(0 1
)1 2
;2 3
var 
result 
= 
await 
_doctorService -
.- .
GetByIdAsync. :
(: ;
doctorId; C
)C D
;D E
return 
Ok 
( 
result 
) 
; 
} 	
[ 	
HttpPut	 
( 
$str 
) 
] 
[ 	
	Authorize	 
( !
AuthenticationSchemes (
=) *
JwtBearerDefaults+ <
.< = 
AuthenticationScheme= Q
)Q R
]R S
[   	
	Authorize  	 
(   
Roles   
=   
$str   #
)  # $
]  $ %
public!! 
async!! 
Task!! 
<!! 
IActionResult!! '
>!!' (
UpdateDoctor!!) 5
(!!5 6
[!!6 7
FromBody!!7 ?
]!!? @
UpdateDoctorDto!!A P
dto!!Q T
)!!T U
{"" 	
if## 
(## 
!## 

ModelState## 
.## 
IsValid## #
)### $
return$$ 

BadRequest$$ !
($$! "

ModelState$$" ,
)$$, -
;$$- .
var&& 
doctorId&& 
=&& !
GetDoctorIdFromClaims&& 0
(&&0 1
)&&1 2
;&&2 3
await'' 
_doctorService''  
.''  !
UpdateAsync''! ,
('', -
doctorId''- 5
,''5 6
dto''7 :
)'': ;
;''; <
return(( 
Ok(( 
((( 
)(( 
;(( 
})) 	
[++ 	
HttpGet++	 
(++ 
$str++ 
)++ 
]++ 
[,, 	
	Authorize,,	 
(,, !
AuthenticationSchemes,, (
=,,) *
JwtBearerDefaults,,+ <
.,,< = 
AuthenticationScheme,,= Q
),,Q R
],,R S
[-- 	
	Authorize--	 
(-- 
Roles-- 
=-- 
$str-- $
)--$ %
]--% &
public.. 
async.. 
Task.. 
<.. 
IActionResult.. '
>..' (
GetAvailableDoctors..) <
(..< =
[..= >
	FromQuery..> G
]..G H
string..I O
specialisation..P ^
,..^ _
[..` a
	FromQuery..a j
]..j k
DateOnly..l t
date..u y
)..y z
{// 	
var00 
result00 
=00 
await00 
_doctorService00 -
.00- .
AvailableDoctors00. >
(00> ?
specialisation00? M
,00M N
date00O S
)00S T
;00T U
return11 
Ok11 
(11 
result11 
)11 
;11 
}22 	
[44 	
HttpPost44	 
(44 
$str44 
)44 
]44 
[55 	
	Authorize55	 
(55 !
AuthenticationSchemes55 (
=55) *
JwtBearerDefaults55+ <
.55< = 
AuthenticationScheme55= Q
)55Q R
]55R S
[66 	
	Authorize66	 
(66 
Roles66 
=66 
$str66 #
)66# $
]66$ %
public77 
async77 
Task77 
<77 
IActionResult77 '
>77' (
AddDoctorLeaves77) 8
(778 9
[779 :
FromBody77: B
]77B C
List77D H
<77H I
CreateLeaveDto77I W
>77W X
leaves77Y _
)77_ `
{88 	
if99 
(99 
!99 

ModelState99 
.99 
IsValid99 #
)99# $
return:: 

BadRequest:: !
(::! "

ModelState::" ,
)::, -
;::- .
var<< 
doctorId<< 
=<< !
GetDoctorIdFromClaims<< 0
(<<0 1
)<<1 2
;<<2 3
var== 
result== 
=== 
await== 
_doctorService== -
.==- .
CreateLeave==. 9
(==9 :
doctorId==: B
,==B C
leaves==D J
)==J K
;==K L
return>> 
Ok>> 
(>> 
result>> 
)>> 
;>> 
}?? 	
privateAA 
intAA !
GetDoctorIdFromClaimsAA )
(AA) *
)AA* +
{BB 	
varCC 
claimCC 
=CC 
UserCC 
.CC 
	FindFirstCC &
(CC& '
$strCC' 1
)CC1 2
??DD 
throwDD 
newDD %
InvalidOperationExceptionDD 6
(DD6 7
$strDD7 [
)DD[ \
;DD\ ]
returnFF 
intFF 
.FF 
ParseFF 
(FF 
claimFF "
.FF" #
ValueFF# (
)FF( )
;FF) *
}GG 	
}HH 
}II µ2
gC:\Users\310055\source\repos\UST-Live-01\HealthCare\HealthCare.Api\Controllers\DoctorAdminController.cs
	namespace 	

HealthCare
 
. 
Api 
. 
Controllers $
{		 
[

 
Route

 

(


 
$str

 
)

 
]

  
[ 
ApiController 
] 
public 

class !
DoctorAdminController &
:' (
ControllerBase) 7
{ 
private 
readonly 
IDoctorService '
_doctorService( 6
;6 7
public !
DoctorAdminController $
($ %
IDoctorService% 3
doctorService4 A
)A B
{ 	
_doctorService 
= 
doctorService *
;* +
} 	
[ 	
HttpGet	 
( 
$str 
) 
] 
[ 	
	Authorize	 
( !
AuthenticationSchemes (
=) *
JwtBearerDefaults+ <
.< = 
AuthenticationScheme= Q
)Q R
]R S
[ 	
	Authorize	 
( 
Roles 
= 
$str "
)" #
]# $
public 
async 
Task 
< 
IActionResult '
>' (
GetDoctorById) 6
(6 7
int7 :
id; =
)= >
{ 	
var 
result 
= 
await 
_doctorService -
.- .
GetByIdAsync. :
(: ;
id; =
)= >
;> ?
return 
Ok 
( 
result 
) 
; 
} 	
[ 	
HttpGet	 
( 
$str 
) 
] 
[ 	
	Authorize	 
( !
AuthenticationSchemes (
=) *
JwtBearerDefaults+ <
.< = 
AuthenticationScheme= Q
)Q R
]R S
[   	
	Authorize  	 
(   
Roles   
=   
$str   "
)  " #
]  # $
public!! 
async!! 
Task!! 
<!! 
IActionResult!! '
>!!' (
GetAllDoctor!!) 5
(!!5 6
[!!6 7
	FromQuery!!7 @
]!!@ A
DoctorFilter!!B N
filter!!O U
)!!U V
{"" 	
if## 
(## 
!## 

ModelState## 
.## 
IsValid## #
)### $
return$$ 

BadRequest$$ !
($$! "

ModelState$$" ,
)$$, -
;$$- .
var&& 
result&& 
=&& 
await&& 
_doctorService&& -
.&&- .
GetAllAsync&&. 9
(&&9 :
filter&&: @
)&&@ A
;&&A B
return'' 
Ok'' 
('' 
result'' 
)'' 
;'' 
}(( 	
[** 	
HttpPut**	 
(** 
$str** 
)** 
]** 
[++ 	
	Authorize++	 
(++ !
AuthenticationSchemes++ (
=++) *
JwtBearerDefaults+++ <
.++< = 
AuthenticationScheme++= Q
)++Q R
]++R S
[,, 	
	Authorize,,	 
(,, 
Roles,, 
=,, 
$str,, "
),," #
],,# $
public-- 
async-- 
Task-- 
<-- 
IActionResult-- '
>--' (
UpdateDoctor--) 5
(--5 6
int--6 9
id--: <
,--< =
[--> ?
FromBody--? G
]--G H
UpdateDoctorDto--I X
dto--Y \
)--\ ]
{.. 	
if// 
(// 
!// 

ModelState// 
.// 
IsValid// #
)//# $
return00 

BadRequest00 !
(00! "

ModelState00" ,
)00, -
;00- .
await22 
_doctorService22  
.22  !
UpdateAsync22! ,
(22, -
id22- /
,22/ 0
dto221 4
)224 5
;225 6
return33 
Ok33 
(33 
)33 
;33 
}44 	
[66 	
	HttpPatch66	 
(66 
$str66  
)66  !
]66! "
[77 	
	Authorize77	 
(77 !
AuthenticationSchemes77 (
=77) *
JwtBearerDefaults77+ <
.77< = 
AuthenticationScheme77= Q
)77Q R
]77R S
[88 	
	Authorize88	 
(88 
Roles88 
=88 
$str88 "
)88" #
]88# $
public99 
async99 
Task99 
<99 
IActionResult99 '
>99' (
UpdateDoctorStatus99) ;
(99; <
int99< ?
id99@ B
,99B C
[99D E
FromBody99E M
]99M N
bool99O S
isActive99T \
)99\ ]
{:: 	
await;; 
_doctorService;;  
.;;  !
UpdateStatusAsync;;! 2
(;;2 3
id;;3 5
,;;5 6
isActive;;7 ?
);;? @
;;;@ A
return<< 
Ok<< 
(<< 
)<< 
;<< 
}== 	
[?? 	

HttpDelete??	 
(?? 
$str?? 
)?? 
]?? 
[@@ 	
	Authorize@@	 
(@@ !
AuthenticationSchemes@@ (
=@@) *
JwtBearerDefaults@@+ <
.@@< = 
AuthenticationScheme@@= Q
)@@Q R
]@@R S
[AA 	
	AuthorizeAA	 
(AA 
RolesAA 
=AA 
$strAA "
)AA" #
]AA# $
publicBB 
asyncBB 
TaskBB 
<BB 
IActionResultBB '
>BB' (
DeleteDoctorBB) 5
(BB5 6
intBB6 9
idBB: <
)BB< =
{CC 	
awaitDD 
_doctorServiceDD  
.DD  !
DeleteAsyncDD! ,
(DD, -
idDD- /
)DD/ 0
;DD0 1
returnEE 
OkEE 
(EE 
)EE 
;EE 
}FF 	
}GG 
}HH ó#
`C:\Users\310055\source\repos\UST-Live-01\HealthCare\HealthCare.Api\Controllers\AuthController.cs
	namespace

 	

HealthCare


 
.

 
Api

 
.

 
Controllers

 $
{ 
[ 
ApiController 
] 
[ 
Route 

(
 
$str 
) 
] 
public 

class 
AuthController 
:  !
ControllerBase" 0
{ 
private 
readonly 
IAuthService %
_authService& 2
;2 3
public 
AuthController 
( 
IAuthService *
authService+ 6
)6 7
{ 	
_authService 
= 
authService &
;& '
} 	
[ 	
HttpPost	 
( 
$str $
)$ %
]% &
[ 	
AllowAnonymous	 
] 
public 
async 
Task 
< 
IActionResult '
>' (
RegisterPatient) 8
(8 9
CreatePatientDto9 I
dtoJ M
)M N
{ 	
await 
_authService 
.  
RegisterPatientAsync 3
(3 4
dto4 7
)7 8
;8 9
return 
Ok 
( 
$str /
)/ 0
;0 1
} 	
[ 	
HttpPost	 
( 
$str #
)# $
]$ %
[   	
	Authorize  	 
(   !
AuthenticationSchemes   (
=  ) *
JwtBearerDefaults  + <
.  < = 
AuthenticationScheme  = Q
)  Q R
]  R S
[!! 	
	Authorize!!	 
(!! 
Roles!! 
=!! 
$str!! "
)!!" #
]!!# $
public"" 
async"" 
Task"" 
<"" 
IActionResult"" '
>""' (
RegisterDoctor"") 7
(""7 8
CreateDoctorDto""8 G
dto""H K
)""K L
{## 	
await$$ 
_authService$$ 
.$$ 
RegisterDoctorAsync$$ 2
($$2 3
dto$$3 6
)$$6 7
;$$7 8
return%% 
Ok%% 
(%% 
$str%% /
)%%/ 0
;%%0 1
}&& 	
[(( 	
HttpPost((	 
((( 
$str(( 
)(( 
](( 
public)) 
async)) 
Task)) 
<)) 
IActionResult)) '
>))' (
Login))) .
()). /
LoginDto))/ 7
dto))8 ;
))); <
{** 	
var++ 
response++ 
=++ 
await++  
_authService++! -
.++- .

LoginAsync++. 8
(++8 9
dto++9 <
)++< =
;++= >
return,, 
Ok,, 
(,, 
response,, 
),, 
;,,  
}-- 	
[// 	
HttpPost//	 
(// 
$str// #
)//# $
]//$ %
[00 	
	Authorize00	 
(00 !
AuthenticationSchemes00 (
=00) *
JwtBearerDefaults00+ <
.00< = 
AuthenticationScheme00= Q
)00Q R
]00R S
public11 
async11 
Task11 
<11 
IActionResult11 '
>11' (
ChangePassword11) 7
(117 8
ChangePasswordDto118 I
dto11J M
)11M N
{22 	
if33 
(33 
!33 

ModelState33 
.33 
IsValid33 #
)33# $
return44 

BadRequest44 !
(44! "

ModelState44" ,
)44, -
;44- .
var66 
userId66 
=66 
User66 
.66 
	FindFirst66 '
(66' (

ClaimTypes66( 2
.662 3
NameIdentifier663 A
)66A B
?66B C
.66C D
Value66D I
;66I J
await88 
_authService88 
.88 
ChangePasswordAsync88 2
(882 3
userId883 9
!889 :
,88: ;
dto88< ?
)88? @
;88@ A
return:: 
Ok:: 
(:: 
$str:: 5
)::5 6
;::6 7
};; 	
}== 
}>> ÍJ
gC:\Users\310055\source\repos\UST-Live-01\HealthCare\HealthCare.Api\Controllers\AppointmentController.cs
	namespace 	

HealthCare
 
. 
Api 
. 
Controllers $
{ 
[		 
Route		 

(		
 
$str		 
)		 
]		 
[

 
ApiController

 
]

 
public 

class !
AppointmentController &
:' (
ControllerBase) 7
{ 
private 
readonly 
IAppointmentService ,
_appointmentService- @
;@ A
public !
AppointmentController $
($ %
IAppointmentService% 8
appointmentService9 K
)K L
{ 	
_appointmentService 
=  !
appointmentService" 4
;4 5
} 	
[ 	
HttpPost	 
( 
$str 
) 
] 
[ 	
	Authorize	 
( !
AuthenticationSchemes (
=) *
JwtBearerDefaults+ <
.< = 
AuthenticationScheme= Q
)Q R
]R S
[ 	
	Authorize	 
( 
Roles 
= 
$str $
)$ %
]% &
public 
async 
Task 
< 
IActionResult '
>' (
BookAppointment) 8
(8 9
[9 :
FromBody: B
]B C 
CreateAppointmentDtoD X
dtoY \
)\ ]
{ 	
if 
( 
! 

ModelState 
. 
IsValid #
)# $
return 

BadRequest !
(! "

ModelState" ,
), -
;- .
var 
	patientId 
= "
GetPatientIdFromClaims 2
(2 3
)3 4
;4 5
await 
_appointmentService %
.% &
AddAsync& .
(. /
dto/ 2
,2 3
	patientId4 =
)= >
;> ?
return 
Ok 
( 
) 
; 
} 	
[!! 	
HttpPut!!	 
(!! 
$str!! 
)!! 
]!!  
["" 	
	Authorize""	 
("" !
AuthenticationSchemes"" (
="") *
JwtBearerDefaults""+ <
.""< = 
AuthenticationScheme""= Q
)""Q R
]""R S
[## 	
	Authorize##	 
(## 
Roles## 
=## 
$str## #
)### $
]##$ %
public$$ 
async$$ 
Task$$ 
<$$ 
IActionResult$$ '
>$$' (#
UpdateAppointmentStatus$$) @
($$@ A
int$$A D
id$$E G
,$$G H
[$$I J
FromBody$$J R
]$$R S 
UpdateAppointmentDto$$T h
dto$$i l
)$$l m
{%% 	
if&& 
(&& 
!&& 

ModelState&& 
.&& 
IsValid&& #
)&&# $
return'' 

BadRequest'' !
(''! "

ModelState''" ,
)'', -
;''- .
await)) 
_appointmentService)) %
.))% &
UpdateStatusAsync))& 7
())7 8
id))8 :
,)): ;
dto))< ?
)))? @
;))@ A
return** 
Ok** 
(** 
)** 
;** 
}++ 	
[-- 	
HttpGet--	 
(-- 
$str-- "
)--" #
]--# $
[.. 	
	Authorize..	 
(.. !
AuthenticationSchemes.. (
=..) *
JwtBearerDefaults..+ <
...< = 
AuthenticationScheme..= Q
)..Q R
]..R S
[// 	
	Authorize//	 
(// 
Roles// 
=// 
$str// #
)//# $
]//$ %
public00 
async00 
Task00 
<00 
IActionResult00 '
>00' (
GetDoctorSchedule00) :
(00: ;
[00; <
	FromQuery00< E
]00E F
DateOnly00G O
date00P T
)00T U
{11 	
var22 
doctorId22 
=22 !
GetDoctorIdFromClaims22 0
(220 1
)221 2
;222 3
var33 
result33 
=33 
await33 
_appointmentService33 2
.332 3
GetDoctorSchedule333 D
(33D E
date33E I
,33I J
doctorId33K S
)33S T
;33T U
return44 
Ok44 
(44 
result44 
)44 
;44 
}55 	
[77 	
HttpGet77	 
(77 
$str77 #
)77# $
]77$ %
[88 	
	Authorize88	 
(88 !
AuthenticationSchemes88 (
=88) *
JwtBearerDefaults88+ <
.88< = 
AuthenticationScheme88= Q
)88Q R
]88R S
[99 	
	Authorize99	 
(99 
Roles99 
=99 
$str99 $
)99$ %
]99% &
public:: 
async:: 
Task:: 
<:: 
IActionResult:: '
>::' (
GetPatientSchedule::) ;
(::; <
[::< =
	FromQuery::= F
]::F G
DateOnly::H P
date::Q U
)::U V
{;; 	
var<< 
	patientId<< 
=<< "
GetPatientIdFromClaims<< 2
(<<2 3
)<<3 4
;<<4 5
var== 
result== 
=== 
await== 
_appointmentService== 2
.==2 3
GetPatientSchedule==3 E
(==E F
date==F J
,==J K
	patientId==L U
)==U V
;==V W
return>> 
Ok>> 
(>> 
result>> 
)>> 
;>> 
}?? 	
[AA 	
HttpGetAA	 
(AA 
$strAA #
)AA# $
]AA$ %
[BB 	
	AuthorizeBB	 
(BB !
AuthenticationSchemesBB (
=BB) *
JwtBearerDefaultsBB+ <
.BB< = 
AuthenticationSchemeBB= Q
)BBQ R
]BBR S
[CC 	
	AuthorizeCC	 
(CC 
RolesCC 
=CC 
$strCC $
)CC$ %
]CC% &
publicDD 
asyncDD 
TaskDD 
<DD 
IActionResultDD '
>DD' (#
GetAppointmentByPatientDD) @
(DD@ A
)DDA B
{EE 	
varFF 
	patientIdFF 
=FF "
GetPatientIdFromClaimsFF 2
(FF2 3
)FF3 4
;FF4 5
varGG 
resultGG 
=GG 
awaitGG 
_appointmentServiceGG 2
.GG2 3#
GetAppointmentByPatientGG3 J
(GGJ K
	patientIdGGK T
)GGT U
;GGU V
returnHH 
OkHH 
(HH 
resultHH 
)HH 
;HH 
}II 	
[KK 	
HttpGetKK	 
(KK 
$strKK "
)KK" #
]KK# $
[LL 	
	AuthorizeLL	 
(LL !
AuthenticationSchemesLL (
=LL) *
JwtBearerDefaultsLL+ <
.LL< = 
AuthenticationSchemeLL= Q
)LLQ R
]LLR S
[MM 	
	AuthorizeMM	 
(MM 
RolesMM 
=MM 
$strMM #
)MM# $
]MM$ %
publicNN 
asyncNN 
TaskNN 
<NN 
IActionResultNN '
>NN' ("
GetAppointmentByDoctorNN) ?
(NN? @
)NN@ A
{OO 	
varPP 
doctorIdPP 
=PP !
GetDoctorIdFromClaimsPP 0
(PP0 1
)PP1 2
;PP2 3
varQQ 
resultQQ 
=QQ 
awaitQQ 
_appointmentServiceQQ 2
.QQ2 3"
GetAppointmentByDoctorQQ3 I
(QQI J
doctorIdQQJ R
)QQR S
;QQS T
returnRR 
OkRR 
(RR 
resultRR 
)RR 
;RR 
}SS 	
privateUU 
intUU "
GetPatientIdFromClaimsUU *
(UU* +
)UU+ ,
{VV 	
varWW 
claimWW 
=WW 
UserWW 
.WW 
	FindFirstWW &
(WW& '
$strWW' 2
)WW2 3
??XX 
throwXX 
newXX %
InvalidOperationExceptionXX 6
(XX6 7
$strXX7 \
)XX\ ]
;XX] ^
returnZZ 
intZZ 
.ZZ 
ParseZZ 
(ZZ 
claimZZ "
.ZZ" #
ValueZZ# (
)ZZ( )
;ZZ) *
}[[ 	
private]] 
int]] !
GetDoctorIdFromClaims]] )
(]]) *
)]]* +
{^^ 	
var__ 
claim__ 
=__ 
User__ 
.__ 
	FindFirst__ &
(__& '
$str__' 1
)__1 2
??`` 
throw`` 
new`` %
InvalidOperationException`` 6
(``6 7
$str``7 [
)``[ \
;``\ ]
returnbb 
intbb 
.bb 
Parsebb 
(bb 
claimbb "
.bb" #
Valuebb# (
)bb( )
;bb) *
}cc 	
}dd 
}ee Ö
lC:\Users\310055\source\repos\UST-Live-01\HealthCare\HealthCare.Api\Controllers\AppointmentAdminController.cs
	namespace 	

HealthCare
 
. 
Api 
. 
Controllers $
{		 
[

 
Route

 

(


 
$str

 #
)

# $
]

$ %
[ 
ApiController 
] 
public 

class &
AppointmentAdminController +
:, -
ControllerBase. <
{ 
private 
readonly 
IAppointmentService ,
_appointmentService- @
;@ A
public &
AppointmentAdminController )
() *
IAppointmentService* =
appointmentService> P
)P Q
{ 	
_appointmentService 
=  !
appointmentService" 4
;4 5
} 	
[ 	
HttpGet	 
( 
$str 
) 
] 
[ 	
	Authorize	 
( !
AuthenticationSchemes (
=) *
JwtBearerDefaults+ <
.< = 
AuthenticationScheme= Q
)Q R
]R S
[ 	
	Authorize	 
( 
Roles 
= 
$str "
)" #
]# $
public 
async 
Task 
< 
IActionResult '
>' (
GetAllAppointment) :
(: ;
[; <
	FromQuery< E
]E F
AppointmentFilterG X
filterY _
)_ `
{ 	
if 
( 
! 

ModelState 
. 
IsValid #
)# $
return 

BadRequest !
(! "

ModelState" ,
), -
;- .
var 
result 
= 
await 
_appointmentService 2
.2 3
GetAllAsync3 >
(> ?
filter? E
)E F
;F G
return 
Ok 
( 
result 
) 
; 
} 	
[!! 	
HttpGet!!	 
(!! 
$str!! 
)!! 
]!! 
["" 	
	Authorize""	 
("" !
AuthenticationSchemes"" (
="") *
JwtBearerDefaults""+ <
.""< = 
AuthenticationScheme""= Q
)""Q R
]""R S
[## 	
	Authorize##	 
(## 
Roles## 
=## 
$str## "
)##" #
]### $
public$$ 
async$$ 
Task$$ 
<$$ 
IActionResult$$ '
>$$' (
GetDailyReport$$) 7
($$7 8
)$$8 9
{%% 	
var&& 
result&& 
=&& 
await&& 
_appointmentService&& 2
.&&2 3
GetDailyReport&&3 A
(&&A B
)&&B C
;&&C D
return'' 
Ok'' 
('' 
result'' 
)'' 
;'' 
}(( 	
})) 
}** 