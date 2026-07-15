
iC:\Users\310055\source\repos\UST-Live-01\HealthCare\HealthCare.Api\Services\Interfaces\IPatientService.cs
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
	interface 
IPatientService $
{ 
Task 
< 
PatientListDto 
> 
GetByIdAsync )
() *
int* -
id. 0
)0 1
;1 2
Task		 
<		 
PagedResult		 
<		 
PatientListDto		 '
>		' (
>		( )
GetAllAsync		* 5
(		5 6
PatientFilter		6 C
filter		D J
)		J K
;		K L
Task

 
AddAsync

 
(

 
CreatePatientDto

 &
dto

' *
)

* +
;

+ ,
Task 
UpdateAsync 
( 
int 
id 
,  
UpdatePatientDto! 1
dto2 5
)5 6
;6 7
Task 
DeleteAsync 
( 
int 
id 
)  
;  !
Task 
UpdateStatusAsync 
( 
int "
id# %
,% &
bool' +
isActive, 4
)4 5
;5 6
Task 
< 
int 
> !
GetRecentPatientCount '
(' (
)( )
;) *
Task 
< 
PatientDashboardDto  
>  !
GetDashboardAsync" 3
(3 4
int4 7
	patientId8 A
)A B
;B C
} 
} Å
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
} Ò
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
?		 
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
< '
AvailableDoctorsResponseDto (
>( )
AvailableDoctors* :
(: ;
string; A
specialisationB P
,P Q
DateOnlyR Z
date[ _
)_ `
;` a
Task 
< 
DoctorSummaryDto 
> 
GetSummaryAsync .
(. /
)/ 0
;0 1
Task 
< 
DoctorDashboardDto 
>  
GetDashboardAsync! 2
(2 3
int3 6
doctorId7 ?
)? @
;@ A
} 
} ·	
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
;F G
Task #
UpdatePatientEmailAsync $
($ %
string% +
userId, 2
,2 3
string4 :
newEmail; C
)C D
;D E
} 
} ‹
mC:\Users\310055\source\repos\UST-Live-01\HealthCare\HealthCare.Api\Services\Interfaces\IAppointmentService.cs
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
IAppointmentService (
{ 
Task 
< 
AppointmentListDto 
?  
>  !
GetByIdAsync" .
(. /
int/ 2
id3 5
)5 6
;6 7
Task		 
<		 
PagedResult		 
<		 
AppointmentListDto		 +
>		+ ,
>		, -
GetAllAsync		. 9
(		9 :
AppointmentFilter		: K
filter		L R
)		R S
;		S T
Task

 
UpdateAsync

 
(

 
int

 
id

 
,

   
UpdateAppointmentDto

! 5
dto

6 9
)

9 :
;

: ;
Task 
DeleteAsync 
( 
int 
id 
)  
;  !
Task 
< 
List 
< 
string 
> 
> 
AvailableTimeSlots -
(- .
DateOnly. 6
date7 ;
,; <
int= @
doctorIdA I
)I J
;J K
Task 
< 
bool 
> 
IsAvailable 
( 
DateOnly '
date( ,
,, -
int. 1
doctorId2 :
,: ;
string< B
timeSlotC K
)K L
;L M
Task 
AddAsync 
(  
CreateAppointmentDto *
dto+ .
,. /
int0 3
	patientId4 =
)= >
;> ?
Task 
UpdateStatusAsync 
( 
int "
id# %
,% & 
UpdateAppointmentDto' ;
dto< ?
)? @
;@ A
Task 
< 
List 
<  
AppointmentReportDto &
>& '
>' (
GetDailyReport) 7
(7 8
)8 9
;9 :
Task 
< 
List 
< 
AppointmentListDto $
>$ %
>% &
GetDoctorSchedule' 8
(8 9
DateOnly9 A
dateB F
,F G
intH K
idL N
)N O
;O P
Task 
< 
List 
< 
AppointmentListDto $
>$ %
>% &
GetPatientSchedule' 9
(9 :
DateOnly: B
dateC G
,G H
intI L
idM O
)O P
;P Q
Task 
< 
List 
< 
AppointmentListDto $
>$ %
>% &#
GetAppointmentByPatient' >
(> ?
int? B
idC E
)E F
;F G
Task 
< 
List 
< 
AppointmentListDto $
>$ %
>% &"
GetAppointmentByDoctor' =
(= >
int> A
idB D
)D E
;E F
Task *
CancelAppointmentsByDoctorDate +
(+ ,
int, /
doctorId0 8
,8 9
DateOnly: B
dateC G
)G H
;H I
Task 
< 
List 
<  
AppointmentReportDto &
>& '
>' ( 
GetReportByDateRange) =
(= >
DateOnly> F
	startDateG P
,P Q
DateOnlyR Z
endDate[ b
)b c
;c d
Task 
< !
AppointmentSummaryDto "
>" #
GetSummaryAsync$ 3
(3 4
)4 5
;5 6
} 
} ≤`
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
{00 	
var11 
search11 
=11 
filter11 
.11  
FullName11  (
?11( )
.11) *
Trim11* .
(11. /
)11/ 0
;110 1

Expression33 
<33 
Func33 
<33 
Patient33 #
,33# $
bool33% )
>33) *
>33* +
	predicate33, 5
=336 7
p338 9
=>33: <
(44 
!44 
filter44 
.44 
HasInsurance44 %
.44% &
HasValue44& .
||44/ 1
(55 
filter55 
.55 
HasInsurance55 (
.55( )
Value55) .
?66 
!66 
string66 !
.66! "
IsNullOrEmpty66" /
(66/ 0
p660 1
.661 2
InsuranceId662 =
)66= >
:77 
string77  
.77  !
IsNullOrEmpty77! .
(77. /
p77/ 0
.770 1
InsuranceId771 <
)77< =
)77= >
)77> ?
&&88 
(99 
string99 
.99 
IsNullOrWhiteSpace99 *
(99* +
search99+ 1
)991 2
||993 5
(:: 
p:: 
.:: 
FullName:: 
!=::  "
null::# '
&&::( *
EF;; 
.;; 
	Functions;; !
.;;! "
Like;;" &
(;;& '
p;;' (
.;;( )
FullName;;) 1
,;;1 2
$";;3 5
$str;;5 6
{;;6 7
search;;7 =
};;= >
$str;;> ?
";;? @
);;@ A
);;A B
);;B C
;;;C D
var== 
pagedResult== 
=== 
await== #
_repository==$ /
.==/ 0
GetAllAsync==0 ;
(==; <
filter>> 
.>> 

PageNumber>> !
,>>! "
filter?? 
.?? 
PageSize?? 
,??  
	predicate@@ 
,@@ 
qAA 
=>AA 
qAA 
.AA 
OrderByAA 
(AA 
pAA  
=>AA! #
pAA$ %
.AA% &
	PatientIdAA& /
)AA/ 0
)AA0 1
;AA1 2
returnCC 
newCC 
PagedResultCC "
<CC" #
PatientListDtoCC# 1
>CC1 2
{DD 
ItemsEE 
=EE 
_mapperEE 
.EE  
MapEE  #
<EE# $
IEnumerableEE$ /
<EE/ 0
PatientListDtoEE0 >
>EE> ?
>EE? @
(EE@ A
pagedResultEEA L
.EEL M
ItemsEEM R
)EER S
,EES T

PageNumberFF 
=FF 
pagedResultFF (
.FF( )

PageNumberFF) 3
,FF3 4
PageSizeGG 
=GG 
pagedResultGG &
.GG& '
PageSizeGG' /
,GG/ 0

TotalCountHH 
=HH 
pagedResultHH (
.HH( )

TotalCountHH) 3
}II 
;II 
}JJ 	
publicLL 
asyncLL 
TaskLL 
UpdateAsyncLL %
(LL% &
intLL& )
idLL* ,
,LL, -
UpdatePatientDtoLL. >
dtoLL? B
)LLB C
{MM 	
varNN 
patientNN 
=NN 
awaitNN 
_repositoryNN  +
.NN+ ,
GetByIdAsyncNN, 8
(NN8 9
idNN9 ;
)NN; <
;NN< =
ifPP 
(PP 
patientPP 
isPP 
nullPP 
)PP  
throwQQ 
newQQ %
InvalidOperationExceptionQQ 3
(QQ3 4
NotFoundMessageQQ4 C
)QQC D
;QQD E
_mapperSS 
.SS 
MapSS 
(SS 
dtoSS 
,SS 
patientSS $
)SS$ %
;SS% &
awaitUU 
_repositoryUU 
.UU 
UpdateAsyncUU )
(UU) *
patientUU* 1
)UU1 2
;UU2 3
awaitVV 
_contextVV 
.VV 
SaveChangesAsyncVV +
(VV+ ,
)VV, -
;VV- .
}WW 	
publicYY 
asyncYY 
TaskYY 
UpdateStatusAsyncYY +
(YY+ ,
intYY, /
idYY0 2
,YY2 3
boolYY4 8
isActiveYY9 A
)YYA B
{ZZ 	
var[[ 
patient[[ 
=[[ 
await[[ 
_repository[[  +
.[[+ ,
GetByIdAsync[[, 8
([[8 9
id[[9 ;
)[[; <
;[[< =
if]] 
(]] 
patient]] 
is]] 
null]] 
)]]  
throw^^ 
new^^ %
InvalidOperationException^^ 3
(^^3 4
NotFoundMessage^^4 C
)^^C D
;^^D E
patient`` 
.`` 
IsActive`` 
=`` 
isActive`` '
;``' (
awaitbb 
_repositorybb 
.bb 
UpdateAsyncbb )
(bb) *
patientbb* 1
)bb1 2
;bb2 3
awaitcc 
_contextcc 
.cc 
SaveChangesAsynccc +
(cc+ ,
)cc, -
;cc- .
}dd 	
publicff 
asyncff 
Taskff 
DeleteAsyncff %
(ff% &
intff& )
idff* ,
)ff, -
{gg 	
varhh 
patienthh 
=hh 
awaithh 
_repositoryhh  +
.hh+ ,
GetByIdAsynchh, 8
(hh8 9
idhh9 ;
)hh; <
;hh< =
ifjj 
(jj 
patientjj 
isjj 
nulljj 
)jj  
throwkk 
newkk %
InvalidOperationExceptionkk 3
(kk3 4
NotFoundMessagekk4 C
)kkC D
;kkD E
trymm 
{nn 
awaitoo 
_repositoryoo !
.oo! "
DeleteAsyncoo" -
(oo- .
idoo. 0
)oo0 1
;oo1 2
awaitpp 
_contextpp 
.pp 
SaveChangesAsyncpp /
(pp/ 0
)pp0 1
;pp1 2
}qq 
catchrr 
(rr 
DbUpdateExceptionrr $
exrr% '
)rr' (
{ss 
throwtt 
newtt %
InvalidOperationExceptiontt 3
(tt3 4
$str	tt4 ê
,
ttê ë
ex
ttí î
)
ttî ï
;
ttï ñ
}uu 
}vv 	
publicxx 
asyncxx 
Taskxx 
<xx 
intxx 
>xx !
GetRecentPatientCountxx 4
(xx4 5
)xx5 6
{yy 	
varzz 
fromDatezz 
=zz 
DateTimeOffsetzz )
.zz) *
UtcNowzz* 0
.zz0 1
AddDayszz1 8
(zz8 9
-zz9 :
$numzz: <
)zz< =
;zz= >
return|| 
await|| 
_context|| !
.||! "
Patients||" *
.}} 

CountAsync}} 
(}} 
p}} 
=>}}  
p}}! "
.}}" #
CreatedDate}}# .
>=}}/ 1
fromDate}}2 :
)}}: ;
;}}; <
}~~ 	
public
ÄÄ 
async
ÄÄ 
Task
ÄÄ 
<
ÄÄ !
PatientDashboardDto
ÄÄ -
>
ÄÄ- .
GetDashboardAsync
ÄÄ/ @
(
ÄÄ@ A
int
ÄÄA D
	patientId
ÄÄE N
)
ÄÄN O
{
ÅÅ 	
var
ÇÇ "
upcomingAppointments
ÇÇ $
=
ÇÇ% &
await
ÇÇ' ,
_context
ÇÇ- 5
.
ÇÇ5 6
Appointments
ÇÇ6 B
.
ÉÉ 

CountAsync
ÉÉ 
(
ÉÉ 
a
ÉÉ 
=>
ÉÉ  
a
ÑÑ 
.
ÑÑ 
	PatientId
ÑÑ 
==
ÑÑ  "
	patientId
ÑÑ# ,
&&
ÑÑ- /
a
ÖÖ 
.
ÖÖ 
ScheduledDate
ÖÖ #
>=
ÖÖ$ &
DateOnly
ÖÖ' /
.
ÖÖ/ 0
FromDateTime
ÖÖ0 <
(
ÖÖ< =
DateTime
ÖÖ= E
.
ÖÖE F
Today
ÖÖF K
)
ÖÖK L
&&
ÖÖM O
a
ÜÜ 
.
ÜÜ 
Status
ÜÜ 
!=
ÜÜ 
$str
ÜÜ  +
)
ÜÜ+ ,
;
ÜÜ, -
var
àà 
latestRecords
àà 
=
àà 
await
àà  %
_context
àà& .
.
àà. /
HealthRecords
àà/ <
.
ââ 

CountAsync
ââ 
(
ââ 
h
ââ 
=>
ââ  
h
ââ! "
.
ââ" #
	PatientId
ââ# ,
==
ââ- /
	patientId
ââ0 9
)
ââ9 :
;
ââ: ;
return
ãã 
new
ãã !
PatientDashboardDto
ãã *
{
åå '
UpcomingAppointmentsCount
çç )
=
çç* +"
upcomingAppointments
çç, @
,
çç@ A 
LatestRecordsCount
éé "
=
éé# $
latestRecords
éé% 2
}
èè 
;
èè 
}
êê 	
}
íí 
}ìì Ù0
iC:\Users\310055\source\repos\UST-Live-01\HealthCare\HealthCare.Api\Services\Implementations\JwtService.cs
	namespace 	

HealthCare
 
. 
Api 
. 
Services !
.! "
Implementations" 1
{		 
public

 

class

 

JwtService

 
:

 
IJwtService

 )
{ 
private 
readonly 
IConfiguration '
_config( /
;/ 0
private 
readonly 
UserManager $
<$ %
IdentityUser% 1
>1 2
_userManager3 ?
;? @
public 

JwtService 
( 
IConfiguration (
config) /
,/ 0
UserManager1 <
<< =
IdentityUser= I
>I J
userManagerK V
)V W
{ 	
_config 
= 
config 
; 
_userManager 
= 
userManager &
;& '
} 	
public 
async 
Task 
< 
string  
>  !
GenerateToken" /
(/ 0
IdentityUser0 <
user= A
,A B
intC F
?F G
	patientIdH Q
=R S
nullT X
,X Y
intZ ]
?] ^
doctorId_ g
=h i
nullj n
)n o
{ 	
var 
jwtSettings 
= 
_config %
.% &

GetSection& 0
(0 1
$str1 6
)6 7
;7 8
var 
key 
= 
new  
SymmetricSecurityKey .
(. /
Encoding/ 7
.7 8
UTF88 <
.< =
GetBytes= E
(E F
jwtSettingsF Q
[Q R
$strR W
]W X
!X Y
)Y Z
)Z [
;[ \
var 
credentials 
= 
new !
SigningCredentials" 4
(4 5
key5 8
,8 9
SecurityAlgorithms: L
.L M

HmacSha256M W
)W X
;X Y
var 
roles 
= 
await 
_userManager *
.* +
GetRolesAsync+ 8
(8 9
user9 =
)= >
;> ?
var 
claims 
= 
new 
List !
<! "
Claim" '
>' (
{ 
new 
Claim 
( #
JwtRegisteredClaimNames 1
.1 2
Sub2 5
,5 6
user6 :
.: ;
Id; =
)= >
,> ?
new 
Claim 
( #
JwtRegisteredClaimNames 1
.1 2
Email2 7
,7 8
user9 =
.= >
Email> C
??D F
stringG M
.M N
EmptyN S
)S T
,T U
new   
Claim   
(   #
JwtRegisteredClaimNames   1
.  1 2
Jti  2 5
,  5 6
Guid  6 :
.  : ;
NewGuid  ; B
(  B C
)  C D
.  D E
ToString  E M
(  M N
)  N O
)  O P
,  P Q
new!! 
Claim!! 
(!! 

ClaimTypes!! $
.!!$ %
NameIdentifier!!% 3
,!!3 4
user!!4 8
.!!8 9
Id!!9 ;
)!!; <
}"" 
;"" 
if$$ 
($$ 
	patientId$$ 
.$$ 
HasValue$$ "
)$$" #
{%% 
claims&& 
.&& 
Add&& 
(&& 
new&& 
Claim&& $
(&&$ %
$str&&% 0
,&&0 1
	patientId&&2 ;
.&&; <
Value&&< A
.&&A B
ToString&&B J
(&&J K
)&&K L
)&&L M
)&&M N
;&&N O
}'' 
if)) 
()) 
doctorId)) 
.)) 
HasValue)) !
)))! "
{** 
claims++ 
.++ 
Add++ 
(++ 
new++ 
Claim++ $
(++$ %
$str++% /
,++/ 0
doctorId++1 9
.++9 :
Value++: ?
.++? @
ToString++@ H
(++H I
)++I J
)++J K
)++K L
;++L M
},, 
foreach.. 
(.. 
var.. 
role.. 
in..  
roles..! &
)..& '
{// 
claims00 
.00 
Add00 
(00 
new00 
Claim00 $
(00$ %

ClaimTypes00% /
.00/ 0
Role000 4
,004 5
role006 :
)00: ;
)00; <
;00< =
}11 
var33 
expirationMinutes33 !
=33" #
int33$ '
.33' (
Parse33( -
(33- .
jwtSettings33. 9
[339 :
$str33: X
]33X Y
!33Y Z
)33Z [
;33[ \
var55 
token55 
=55 
new55 
JwtSecurityToken55 ,
(55, -
issuer77 
:77 
jwtSettings77 #
[77# $
$str77$ ,
]77, -
,77- .
audience88 
:88 
jwtSettings88 %
[88% &
$str88& 0
]880 1
,881 2
claims99 
:99 
claims99 
,99 
expires:: 
::: 
DateTime:: !
.::! "
UtcNow::" (
.::( )

AddMinutes::) 3
(::3 4
expirationMinutes::4 E
)::E F
,::F G
signingCredentials;; "
:;;" #
credentials;;$ /
)>> 
;>> 
return@@ 
new@@ #
JwtSecurityTokenHandler@@ .
(@@. /
)@@/ 0
.@@0 1

WriteToken@@1 ;
(@@; <
token@@< A
)@@A B
;@@B C
}AA 	
}BB 
}CC Î°
jC:\Users\310055\source\repos\UST-Live-01\HealthCare\HealthCare.Api\Services\Implementations\AuthService.cs
	namespace 	

HealthCare
 
. 
Api 
. 
Services !
.! "
Implementations" 1
{ 
public 

class 
AuthService 
: 
IAuthService +
{ 
private 
readonly 
UserManager $
<$ %
IdentityUser% 1
>1 2
_userManager3 ?
;? @
private 
readonly 
IMapper  
_mapper! (
;( )
private 
readonly 
IPatientRepository +
_patientRepo, 8
;8 9
private 
readonly 
IDoctorRepository *
_doctorRepo+ 6
;6 7
private 
readonly 
IJwtService $
_jwtService% 0
;0 1
private 
readonly 
ILogger  
<  !
AuthService! ,
>, -
_logger. 5
;5 6
private 
readonly 
HealthCareDbContext ,
_context- 5
;5 6
private 
readonly 
IDistributedCache *
_cache+ 1
;1 2
public 
AuthService 
( 
UserManager 
< 
IdentityUser $
>$ %
userManager& 1
,1 2
IMapper   
mapper   
,   
IPatientRepository!! 
patientRepo!! *
,!!* +
IDoctorRepository"" 

doctorRepo"" (
,""( )
IJwtService## 

jwtService## "
,##" #
ILogger$$ 
<$$ 
AuthService$$ 
>$$  
logger$$! '
,$$' (
IDistributedCache%% 
cache%% #
,%%# $
HealthCareDbContext&& 
context&&  '
)&&' (
{'' 	
_userManager(( 
=(( 
userManager(( &
;((& '
_mapper)) 
=)) 
mapper)) 
;)) 
_patientRepo** 
=** 
patientRepo** &
;**& '
_doctorRepo++ 
=++ 

doctorRepo++ $
;++$ %
_jwtService,, 
=,, 

jwtService,, $
;,,$ %
_context-- 
=-- 
context-- 
;-- 
_cache.. 
=.. 
cache.. 
;.. 
_logger// 
=// 
logger// 
;// 
}00 	
private33 
async33 
Task33 
<33 
IdentityUser33 '
>33' (#
CreateUserWithRoleAsync33) @
(33@ A
string44 
email44 
,44 
string55 
password55 
,55 
string66 
role66 
)66 
{77 	
var99 
existingUser99 
=99 
await99 $
_userManager99% 1
.991 2
FindByEmailAsync992 B
(99B C
email99C H
)99H I
;99I J
if;; 
(;; 
existingUser;; 
!=;; 
null;;  $
);;$ %
{<< 
throw== 
new== %
InvalidOperationException== 3
(==3 4
$str==4 J
)==J K
;==K L
}>> 
varAA 
userAA 
=AA 
newAA 
IdentityUserAA '
{BB 
UserNameCC 
=CC 
emailCC  
,CC  !
EmailDD 
=DD 
emailDD 
}EE 
;EE 
varGG 
resultGG 
=GG 
awaitGG 
_userManagerGG +
.GG+ ,
CreateAsyncGG, 7
(GG7 8
userGG8 <
,GG< =
passwordGG> F
)GGF G
;GGG H
ifII 
(II 
!II 
resultII 
.II 
	SucceededII !
)II! "
{JJ 
throwKK 
newKK %
InvalidOperationExceptionKK 3
(KK3 4
stringLL 
.LL 
JoinLL 
(LL  
$strLL  $
,LL$ %
resultLL& ,
.LL, -
ErrorsLL- 3
.LL3 4
SelectLL4 :
(LL: ;
eLL; <
=>LL= ?
eLL@ A
.LLA B
DescriptionLLB M
)LLM N
)LLN O
)MM 
;MM 
}NN 
varQQ 

roleResultQQ 
=QQ 
awaitQQ "
_userManagerQQ# /
.QQ/ 0
AddToRoleAsyncQQ0 >
(QQ> ?
userQQ? C
,QQC D
roleQQE I
)QQI J
;QQJ K
ifSS 
(SS 
!SS 

roleResultSS 
.SS 
	SucceededSS %
)SS% &
{TT 
throwUU 
newUU %
InvalidOperationExceptionUU 3
(UU3 4
stringVV 
.VV 
JoinVV 
(VV  
$strVV  $
,VV$ %

roleResultVV& 0
.VV0 1
ErrorsVV1 7
.VV7 8
SelectVV8 >
(VV> ?
eVV? @
=>VVA C
eVVD E
.VVE F
DescriptionVVF Q
)VVQ R
)VVR S
)WW 
;WW 
}XX 
returnZZ 
userZZ 
;ZZ 
}[[ 	
public]] 
async]] 
Task]]  
RegisterPatientAsync]] .
(]]. /
CreatePatientDto]]/ ?
dto]]@ C
)]]C D
{^^ 	
var__ 
user__ 
=__ 
await__ #
CreateUserWithRoleAsync__ 4
(__4 5
dto__5 8
.__8 9
Email__9 >
,__> ?
dto__@ C
.__C D
Password__D L
,__L M
$str__N W
)__W X
;__X Y
varbb 
patientbb 
=bb 
_mapperbb !
.bb! "
Mapbb" %
<bb% &
Patientbb& -
>bb- .
(bb. /
dtobb/ 2
)bb2 3
;bb3 4
patientcc 
.cc 
UserIdcc 
=cc 
usercc !
.cc! "
Idcc" $
;cc$ %
awaitee 
_patientRepoee 
.ee 
AddAsyncee '
(ee' (
patientee( /
)ee/ 0
;ee0 1
awaitff 
_contextff 
.ff 
SaveChangesAsyncff +
(ff+ ,
)ff, -
;ff- .
}gg 	
publicii 
asyncii 
Taskii 
RegisterDoctorAsyncii -
(ii- .
CreateDoctorDtoii. =
dtoii> A
)iiA B
{jj 	
varkk 
userkk 
=kk 
awaitkk #
CreateUserWithRoleAsynckk 4
(kk4 5
dtokk5 8
.kk8 9
Emailkk9 >
,kk> ?
dtokk@ C
.kkC D
PasswordkkD L
,kkL M
$strkkN V
)kkV W
;kkW X
varnn 
doctornn 
=nn 
_mappernn  
.nn  !
Mapnn! $
<nn$ %
Doctornn% +
>nn+ ,
(nn, -
dtonn- 0
)nn0 1
;nn1 2
doctoroo 
.oo 
UserIdoo 
=oo 
useroo  
.oo  !
Idoo! #
;oo# $
awaitqq 
_doctorRepoqq 
.qq 
AddAsyncqq &
(qq& '
doctorqq' -
)qq- .
;qq. /
awaitss 
_contextss 
.ss 
SaveChangesAsyncss +
(ss+ ,
)ss, -
;ss- .
awaituu 
_doctorRepouu 
.uu 
CreateSlotsuu )
(uu) *
doctoruu* 0
.uu0 1
DoctorIduu1 9
,uu9 :
dtouu; >
.uu> ?
	TimeSlotsuu? H
)uuH I
;uuI J
awaitww 
_contextww 
.ww 
SaveChangesAsyncww +
(ww+ ,
)ww, -
;ww- .
awaityy 7
+InvalidateAvailabilityCacheBySpecialisationyy =
(yy= >
doctorzz 
.zz 
Specialisationzz (
)zz( )
;zz) *
}{{ 	
private}} 
async}} 
Task}} 7
+InvalidateAvailabilityCacheBySpecialisation}} F
(}}F G
string~~ 	
specialisation~~
 
)~~ 
{ 	
var
ÄÄ 
today
ÄÄ 
=
ÄÄ 
DateOnly
ÄÄ  
.
ÄÄ  !
FromDateTime
ÄÄ! -
(
ÄÄ- .
DateTime
ÄÄ. 6
.
ÄÄ6 7
Today
ÄÄ7 <
)
ÄÄ< =
;
ÄÄ= >
for
ÇÇ 
(
ÇÇ 
int
ÇÇ 
i
ÇÇ 
=
ÇÇ 
$num
ÇÇ 
;
ÇÇ 
i
ÇÇ 
<
ÇÇ 
$num
ÇÇ  "
;
ÇÇ" #
i
ÇÇ$ %
++
ÇÇ% '
)
ÇÇ' (
{
ÉÉ 
var
ÑÑ 
date
ÑÑ 
=
ÑÑ 
today
ÑÑ  
.
ÑÑ  !
AddDays
ÑÑ! (
(
ÑÑ( )
i
ÑÑ) *
)
ÑÑ* +
;
ÑÑ+ ,
var
ÜÜ 
cacheKey
ÜÜ 
=
ÜÜ 
$"
áá 
$str
áá 
{
áá 
specialisation
áá -
}
áá- .
$str
áá. <
{
áá< =
date
áá= A
}
ááA B
"
ááB C
;
ááC D
if
ää 
(
ää 
_logger
ää 
.
ää 
	IsEnabled
ää %
(
ää% &
LogLevel
ää& .
.
ää. /
Information
ää/ :
)
ää: ;
)
ää; <
{
ãã 
_logger
åå 
.
åå 
LogInformation
åå *
(
åå* +
$str
çç 2
,
çç2 3
cacheKey
éé  
)
éé  !
;
éé! "
}
èè 
try
íí 
{
ìì 
await
îî 
_cache
îî  
.
îî  !
RemoveAsync
îî! ,
(
îî, -
cacheKey
îî- 5
)
îî5 6
;
îî6 7
if
ññ 
(
ññ 
_logger
ññ 
.
ññ  
	IsEnabled
ññ  )
(
ññ) *
LogLevel
ññ* 2
.
ññ2 3
Information
ññ3 >
)
ññ> ?
)
ññ? @
{
óó 
_logger
òò 
.
òò  
LogInformation
òò  .
(
òò. /
$str
ôô 1
,
ôô1 2
cacheKey
öö  
)
öö  !
;
öö! "
}
õõ 
}
úú 
catch
ùù 
(
ùù 
	Exception
ùù  
ex
ùù! #
)
ùù# $
{
ûû 
if
üü 
(
üü 
_logger
üü 
.
üü  
	IsEnabled
üü  )
(
üü) *
LogLevel
üü* 2
.
üü2 3
Information
üü3 >
)
üü> ?
)
üü? @
{
†† 
_logger
°° 
.
°°  

LogWarning
°°  *
(
°°* +
ex
¢¢ 
,
¢¢ 
$str
££ :
,
££: ;
cacheKey
§§  
)
§§  !
;
§§! "
}
•• 
}
¶¶ 
}
ßß 
}
®® 	
public
™™ 
async
™™ 
Task
™™ 
<
™™ 
AuthResponseDto
™™ )
>
™™) *

LoginAsync
™™+ 5
(
™™5 6
LoginDto
™™6 >
dto
™™? B
)
™™B C
{
´´ 	
var
≠≠ 
user
≠≠ 
=
≠≠ 
await
≠≠ 
_userManager
≠≠ )
.
≠≠) *
FindByEmailAsync
≠≠* :
(
≠≠: ;
dto
≠≠; >
.
≠≠> ?
Email
≠≠? D
)
≠≠D E
;
≠≠E F
if
ÆÆ 
(
ÆÆ 
user
ÆÆ 
==
ÆÆ 
null
ÆÆ 
)
ÆÆ 
throw
ØØ 
new
ØØ '
InvalidOperationException
ØØ 3
(
ØØ3 4
$str
ØØ4 I
)
ØØI J
;
ØØJ K
var
≤≤ 
isValid
≤≤ 
=
≤≤ 
await
≤≤ 
_userManager
≤≤  ,
.
≤≤, - 
CheckPasswordAsync
≤≤- ?
(
≤≤? @
user
≤≤@ D
,
≤≤D E
dto
≤≤F I
.
≤≤I J
Password
≤≤J R
)
≤≤R S
;
≤≤S T
if
≥≥ 
(
≥≥ 
!
≥≥ 
isValid
≥≥ 
)
≥≥ 
throw
¥¥ 
new
¥¥ )
UnauthorizedAccessException
¥¥ 5
(
¥¥5 6
$str
¥¥6 K
)
¥¥K L
;
¥¥L M
var
∑∑ 
roles
∑∑ 
=
∑∑ 
await
∑∑ 
_userManager
∑∑ *
.
∑∑* +
GetRolesAsync
∑∑+ 8
(
∑∑8 9
user
∑∑9 =
)
∑∑= >
;
∑∑> ?
if
∏∏ 
(
∏∏ 
roles
∏∏ 
==
∏∏ 
null
∏∏ 
||
∏∏  
!
∏∏! "
roles
∏∏" '
.
∏∏' (
Any
∏∏( +
(
∏∏+ ,
)
∏∏, -
)
∏∏- .
{
ππ 
throw
∫∫ 
new
∫∫ '
InvalidOperationException
∫∫ 3
(
∫∫3 4
$str
∫∫4 K
)
∫∫K L
;
∫∫L M
}
ªª 
string
ææ 
token
ææ 
;
ææ 
var
øø 
role
øø 
=
øø 
roles
øø 
[
øø 
$num
øø 
]
øø 
;
øø  
if
¿¿ 
(
¿¿ 
role
¿¿ 
==
¿¿ 
$str
¿¿ !
)
¿¿! "
{
¡¡ 
var
¬¬ 
patient
¬¬ 
=
¬¬ 
await
¬¬ #
_patientRepo
¬¬$ 0
.
¬¬0 1
GetByUserIdAsync
¬¬1 A
(
¬¬A B
user
¬¬B F
.
¬¬F G
Id
¬¬G I
)
¬¬I J
;
¬¬J K
if
ƒƒ 
(
ƒƒ 
patient
ƒƒ 
==
ƒƒ 
null
ƒƒ #
)
ƒƒ# $
throw
≈≈ 
new
≈≈ '
InvalidOperationException
≈≈ 7
(
≈≈7 8
$str
≈≈8 S
)
≈≈S T
;
≈≈T U
token
»» 
=
»» 
await
»» 
_jwtService
»» )
.
»») *
GenerateToken
»»* 7
(
»»7 8
user
»»8 <
,
»»< =
	patientId
»»> G
:
»»G H
patient
»»I P
.
»»P Q
	PatientId
»»Q Z
)
»»Z [
;
»»[ \
}
…… 
else
   
if
   
(
   
role
   
==
   
$str
   %
)
  % &
{
ÀÀ 
var
ÃÃ 
doctor
ÃÃ 
=
ÃÃ 
await
ÃÃ "
_doctorRepo
ÃÃ# .
.
ÃÃ. /
GetByUserIdAsync
ÃÃ/ ?
(
ÃÃ? @
user
ÃÃ@ D
.
ÃÃD E
Id
ÃÃE G
)
ÃÃG H
;
ÃÃH I
if
ŒŒ 
(
ŒŒ 
doctor
ŒŒ 
==
ŒŒ 
null
ŒŒ "
)
ŒŒ" #
throw
œœ 
new
œœ '
InvalidOperationException
œœ 7
(
œœ7 8
$str
œœ8 R
)
œœR S
;
œœS T
token
““ 
=
““ 
await
““ 
_jwtService
““ )
.
““) *
GenerateToken
““* 7
(
““7 8
user
““8 <
,
““< =
doctorId
““> F
:
““F G
doctor
““H N
.
““N O
DoctorId
““O W
)
““W X
;
““X Y
}
”” 
else
‘‘ 
if
‘‘ 
(
‘‘ 
role
‘‘ 
==
‘‘ 
$str
‘‘ $
)
‘‘$ %
{
’’ 
token
◊◊ 
=
◊◊ 
await
◊◊ 
_jwtService
◊◊ )
.
◊◊) *
GenerateToken
◊◊* 7
(
◊◊7 8
user
◊◊8 <
)
◊◊< =
;
◊◊= >
}
ÿÿ 
else
ŸŸ 
{
⁄⁄ 
throw
€€ 
new
€€ '
InvalidOperationException
€€ 3
(
€€3 4
$str
€€4 C
)
€€C D
;
€€D E
}
‹‹ 
var
ﬂﬂ 
response
ﬂﬂ 
=
ﬂﬂ 
new
ﬂﬂ 
AuthResponseDto
ﬂﬂ .
{
‡‡ 
AccessToken
·· 
=
·· 
token
·· #
,
··# $
Role
‚‚ 
=
‚‚ 
role
‚‚ 
}
„„ 
;
„„ 
return
ÂÂ 
response
ÂÂ 
;
ÂÂ 
}
ÊÊ 	
public
ËË 
async
ËË 
Task
ËË !
ChangePasswordAsync
ËË -
(
ËË- .
string
ËË. 4
userId
ËË5 ;
,
ËË; <
ChangePasswordDto
ËË= N
dto
ËËO R
)
ËËR S
{
ÈÈ 	
var
ÍÍ 
user
ÍÍ 
=
ÍÍ 
await
ÍÍ 
_userManager
ÍÍ )
.
ÍÍ) *
FindByIdAsync
ÍÍ* 7
(
ÍÍ7 8
userId
ÍÍ8 >
)
ÍÍ> ?
;
ÍÍ? @
if
ÏÏ 
(
ÏÏ 
user
ÏÏ 
==
ÏÏ 
null
ÏÏ 
)
ÏÏ 
throw
ÌÌ 
new
ÌÌ '
InvalidOperationException
ÌÌ 3
(
ÌÌ3 4
$str
ÌÌ4 D
)
ÌÌD E
;
ÌÌE F
var
ÔÔ 
result
ÔÔ 
=
ÔÔ 
await
ÔÔ 
_userManager
ÔÔ +
.
ÔÔ+ ,!
ChangePasswordAsync
ÔÔ, ?
(
ÔÔ? @
user
 
,
 
dto
ÒÒ 
.
ÒÒ 
CurrentPassword
ÒÒ #
,
ÒÒ# $
dto
ÚÚ 
.
ÚÚ 
NewPassword
ÚÚ 
)
ÛÛ 
;
ÛÛ 
if
ıı 
(
ıı 
!
ıı 
result
ıı 
.
ıı 
	Succeeded
ıı !
)
ıı! "
throw
ˆˆ 
new
ˆˆ '
InvalidOperationException
ˆˆ 3
(
ˆˆ3 4
string
˜˜ 
.
˜˜ 
Join
˜˜ 
(
˜˜  
$str
˜˜  $
,
˜˜$ %
result
˜˜& ,
.
˜˜, -
Errors
˜˜- 3
.
˜˜3 4
Select
˜˜4 :
(
˜˜: ;
e
˜˜; <
=>
˜˜= ?
e
˜˜@ A
.
˜˜A B
Description
˜˜B M
)
˜˜M N
)
˜˜N O
)
¯¯ 
;
¯¯ 
}
˘˘ 	
public
˚˚ 
async
˚˚ 
Task
˚˚ %
UpdatePatientEmailAsync
˚˚ 1
(
˚˚1 2
string
˚˚2 8
userId
˚˚9 ?
,
˚˚? @
string
˚˚A G
newEmail
˚˚H P
)
˚˚P Q
{
¸¸ 	
var
˝˝ 
user
˝˝ 
=
˝˝ 
await
˝˝ 
_userManager
˝˝ )
.
˝˝) *
FindByIdAsync
˝˝* 7
(
˝˝7 8
userId
˝˝8 >
)
˝˝> ?
;
˝˝? @
if
ˇˇ 
(
ˇˇ 
user
ˇˇ 
==
ˇˇ 
null
ˇˇ 
)
ˇˇ 
throw
ÄÄ 
new
ÄÄ '
InvalidOperationException
ÄÄ 3
(
ÄÄ3 4
$str
ÄÄ4 D
)
ÄÄD E
;
ÄÄE F
var
ÉÉ 
existingUser
ÉÉ 
=
ÉÉ 
await
ÉÉ $
_userManager
ÉÉ% 1
.
ÉÉ1 2
FindByEmailAsync
ÉÉ2 B
(
ÉÉB C
newEmail
ÉÉC K
)
ÉÉK L
;
ÉÉL M
if
ÖÖ 
(
ÖÖ 
existingUser
ÖÖ 
!=
ÖÖ 
null
ÖÖ  $
&&
ÖÖ% '
existingUser
ÖÖ( 4
.
ÖÖ4 5
Id
ÖÖ5 7
!=
ÖÖ8 :
userId
ÖÖ; A
)
ÖÖA B
throw
ÜÜ 
new
ÜÜ '
InvalidOperationException
ÜÜ 3
(
ÜÜ3 4
$str
ÜÜ4 J
)
ÜÜJ K
;
ÜÜK L
user
ââ 
.
ââ 
Email
ââ 
=
ââ 
newEmail
ââ !
;
ââ! "
user
ää 
.
ää 
UserName
ää 
=
ää 
newEmail
ää $
;
ää$ %
var
åå 
result
åå 
=
åå 
await
åå 
_userManager
åå +
.
åå+ ,
UpdateAsync
åå, 7
(
åå7 8
user
åå8 <
)
åå< =
;
åå= >
if
éé 
(
éé 
!
éé 
result
éé 
.
éé 
	Succeeded
éé !
)
éé! "
{
èè 
throw
êê 
new
êê '
InvalidOperationException
êê 3
(
êê3 4
string
ëë 
.
ëë 
Join
ëë 
(
ëë  
$str
ëë  $
,
ëë$ %
result
ëë& ,
.
ëë, -
Errors
ëë- 3
.
ëë3 4
Select
ëë4 :
(
ëë: ;
e
ëë; <
=>
ëë= ?
e
ëë@ A
.
ëëA B
Description
ëëB M
)
ëëM N
)
ëëN O
)
íí 
;
íí 
}
ìì 
}
îî 	
}
ññ 
}óó ˙[
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
.88 
PageSize88 
,88  
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
varJJ 
appointmentJJ 
=JJ 
awaitJJ #
_contextJJ$ ,
.JJ, -
AppointmentsJJ- 9
.KK 
FirstOrDefaultAsyncKK $
(KK$ %
aKK% &
=>KK' )
aKK* +
.KK+ ,
AppointmentIdKK, 9
==KK: <
dtoKK= @
.KK@ A
AppointmentIdKKA N
)KKN O
;KKO P
ifMM 
(MM 
appointmentMM 
==MM 
nullMM #
)MM# $
throwNN 
newNN  
KeyNotFoundExceptionNN .
(NN. /
$strNN/ F
)NNF G
;NNG H
ifQQ 
(QQ 
appointmentQQ 
.QQ 
StatusQQ "
!=QQ# %
$strQQ& 1
)QQ1 2
throwRR 
newRR %
InvalidOperationExceptionRR 3
(RR3 4
$strRR4 p
)RRp q
;RRq r
varTT 
recordTT 
=TT 
_mapperTT  
.TT  !
MapTT! $
<TT$ %
HealthRecordTT% 1
>TT1 2
(TT2 3
dtoTT3 6
)TT6 7
;TT7 8
recordVV 
.VV 
DoctorIdVV 
=VV 
doctorIdVV &
;VV& '
recordWW 
.WW 
	PatientIdWW 
=WW 
appointmentWW *
.WW* +
	PatientIdWW+ 4
;WW4 5
recordXX 
.XX 
	VisitDateXX 
=XX 
appointmentXX *
.XX* +
ScheduledDateXX+ 8
.XX8 9

ToDateTimeXX9 C
(XXC D
TimeOnlyXXD L
.XXL M
MinValueXXM U
)XXU V
;XXV W
awaitZZ 
_repositoryZZ 
.ZZ 
AddAsyncZZ &
(ZZ& '
recordZZ' -
)ZZ- .
;ZZ. /
appointment\\ 
.\\ 
Status\\ 
=\\  
$str\\! ,
;\\, -
await^^ 
_context^^ 
.^^ 
SaveChangesAsync^^ +
(^^+ ,
)^^, -
;^^- .
}__ 	
publicaa 
asyncaa 
Taskaa 
UpdateAsyncaa %
(aa% &
intaa& )
idaa* ,
,aa, -!
UpdateHealthRecordDtoaa. C
dtoaaD G
)aaG H
{bb 	
varcc 
recordcc 
=cc 
awaitcc 
_repositorycc *
.cc* +
GetByIdAsynccc+ 7
(cc7 8
idcc8 :
)cc: ;
;cc; <
ifee 
(ee 
recordee 
isee 
nullee 
)ee 
throwff 
newff %
InvalidOperationExceptionff 3
(ff3 4
$strff4 N
)ffN O
;ffO P
_mapperhh 
.hh 
Maphh 
(hh 
dtohh 
,hh 
recordhh #
)hh# $
;hh$ %
awaitii 
_repositoryii 
.ii 
UpdateAsyncii )
(ii) *
recordii* 0
)ii0 1
;ii1 2
awaitjj 
_contextjj 
.jj 
SaveChangesAsyncjj +
(jj+ ,
)jj, -
;jj- .
}kk 	
publicmm 
asyncmm 
Taskmm 
DeleteAsyncmm %
(mm% &
intmm& )
idmm* ,
)mm, -
{nn 	
varoo 
recordoo 
=oo 
awaitoo 
_repositoryoo *
.oo* +
GetByIdAsyncoo+ 7
(oo7 8
idoo8 :
)oo: ;
;oo; <
ifqq 
(qq 
recordqq 
isqq 
nullqq 
)qq 
throwrr 
newrr %
InvalidOperationExceptionrr 3
(rr3 4
$strrr4 N
)rrN O
;rrO P
trytt 
{uu 
awaitvv 
_repositoryvv !
.vv! "
DeleteAsyncvv" -
(vv- .
idvv. 0
)vv0 1
;vv1 2
awaitww 
_contextww 
.ww 
SaveChangesAsyncww /
(ww/ 0
)ww0 1
;ww1 2
}xx 
catchyy 
(yy 
DbUpdateExceptionyy $
exyy% '
)yy' (
{zz 
throw{{ 
new{{ %
InvalidOperationException{{ 3
({{3 4
$str{{4 U
,{{U V
ex{{W Y
){{Y Z
;{{Z [
}|| 
}}} 	
public 
async 
Task 
< 
List 
< 
HealthRecordListDto 2
>2 3
>3 4$
GetHealthRecordByPatient5 M
(M N
intN Q
idR T
)T U
{
ÄÄ 	
var
ÅÅ 
records
ÅÅ 
=
ÅÅ 
await
ÅÅ 
_repository
ÅÅ  +
.
ÅÅ+ ,&
GetHealthRecordByPatient
ÅÅ, D
(
ÅÅD E
id
ÅÅE G
)
ÅÅG H
;
ÅÅH I
return
ÇÇ 
records
ÇÇ 
.
ÇÇ 
Count
ÇÇ  
==
ÇÇ! #
$num
ÇÇ$ %
?
ÇÇ& '
new
ÇÇ( +
List
ÇÇ, 0
<
ÇÇ0 1!
HealthRecordListDto
ÇÇ1 D
>
ÇÇD E
(
ÇÇE F
)
ÇÇF G
:
ÇÇH I
records
ÇÇJ Q
;
ÇÇQ R
}
ÉÉ 	
public
ÖÖ 
async
ÖÖ 
Task
ÖÖ 
<
ÖÖ 
List
ÖÖ 
<
ÖÖ !
HealthRecordListDto
ÖÖ 2
>
ÖÖ2 3
>
ÖÖ3 4*
GetHealthRecordByAppointment
ÖÖ5 Q
(
ÖÖQ R
int
ÖÖR U
id
ÖÖV X
)
ÖÖX Y
{
ÜÜ 	
var
áá 
records
áá 
=
áá 
await
áá 
_repository
áá  +
.
áá+ ,*
GetHealthRecordByAppointment
áá, H
(
ááH I
id
ááI K
)
ááK L
;
ááL M
return
àà 
records
àà 
.
àà 
Count
àà  
==
àà! #
$num
àà$ %
?
àà& '
new
àà( +
List
àà, 0
<
àà0 1!
HealthRecordListDto
àà1 D
>
ààD E
(
ààE F
)
ààF G
:
ààH I
records
ààJ Q
;
ààQ R
}
ââ 	
}
ää 
}ãã €ÿ
lC:\Users\310055\source\repos\UST-Live-01\HealthCare\HealthCare.Api\Services\Implementations\DoctorService.cs
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
class 
DoctorService 
:  
IDoctorService! /
{ 
private 
readonly 
IDoctorRepository *
_repository+ 6
;6 7
private 
readonly "
IAppointmentRepository /"
_appointmentRepository0 F
;F G
private 
readonly 
HealthCareDbContext ,
_context- 5
;5 6
private 
readonly 
IMapper  
_mapper! (
;( )
private 
readonly 
IDistributedCache *
_cache+ 1
;1 2
private 
readonly 
ILogger  
<  !
DoctorService! .
>. /
_logger0 7
;7 8
private 
const 
string $
NotFoundExceptionMessage 5
=6 7
$str8 K
;K L
public 
DoctorService 
( 
IDoctorRepository .

repository/ 9
,9 :"
IAppointmentRepository; Q!
appointmentRepositoryR g
,g h
HealthCareDbContexti |
context	} Ñ
,
Ñ Ö
IMapper
Ü ç
mapper
é î
,
î ï
IDistributedCache
ñ ß
cache
® ≠
,
≠ Æ
ILogger
Ø ∂
<
∂ ∑
DoctorService
∑ ƒ
>
ƒ ≈
logger
∆ Ã
)
Ã Õ
{ 	
_repository 
= 

repository $
;$ %"
_appointmentRepository "
=# $!
appointmentRepository% :
;: ;
_context 
= 
context 
; 
_mapper 
= 
mapper 
; 
_cache   
=   
cache   
;   
_logger!! 
=!! 
logger!! 
;!! 
}"" 	
public$$ 
async$$ 
Task$$ 
<$$ 
DoctorListDto$$ '
?$$' (
>$$( )
GetByIdAsync$$* 6
($$6 7
int$$7 :
id$$; =
)$$= >
{%% 	
var&& 
doctor&& 
=&& 
await&& 
(&&  
from'' 
d'' 
in'' 
_context'' "
.''" #
Doctors''# *
join(( 
u(( 
in(( 
_context(( "
.((" #
Users((# (
on)) 
d)) 
.)) 
UserId)) 
equals)) 
u))  
.))  !
Id))! #
where** 
d** 
.** 
DoctorId** 
==** 
id** 
select,, 
new,, 
DoctorListDto,,  
{-- 	
DoctorId.. 
=.. 
d.. 
... 
DoctorId.. !
,..! "
FullName// 
=// 
d// 
.// 
FullName// !
,//! "
Email00 
=00 
u00 
.00 
Email00 
??00 
string00 %
.00% &
Empty00& +
,00+ ,
Specialisation11 
=11 
d11 
.11 
Specialisation11 -
,11- .
YearsOfExperience22 
=22 
d22  !
.22! "
YearsOfExperience22" 3
,223 4
ConsultationFee33 
=33 
d33 
.33  
ConsultationFee33  /
,33/ 0
IsActive44 
=44 
d44 
.44 
IsActive44 !
}55 	
)66 
.66 
FirstOrDefaultAsync66 
(66 
)66 
;66 
return88 
doctor88 
;88 
}99 	
public;; 
async;; 
Task;; 
<;; 
PagedResult;; %
<;;% &
DoctorListDto;;& 3
>;;3 4
>;;4 5
GetAllAsync;;6 A
(;;A B
DoctorFilter;;B N
filter;;O U
);;U V
{<< 	

Expression== 
<== 
Func== 
<== 
Doctor== "
,==" #
bool==$ (
>==( )
>==) *
	predicate==+ 4
===5 6
d==7 8
=>==9 ;
(>> 
string>> 
.>> 
IsNullOrEmpty>> )
(>>) *
filter>>* 0
.>>0 1
Name>>1 5
)>>5 6
||>>7 9
(?? 
d?? 
.?? 
FullName?? #
!=??$ &
null??' +
&&??, .
EF@@ 
.@@ 
	Functions@@ %
.@@% &
Like@@& *
(@@* +
d@@+ ,
.@@, -
FullName@@- 5
,@@5 6
$"@@7 9
$str@@9 :
{@@: ;
filter@@; A
.@@A B
Name@@B F
}@@F G
$str@@G H
"@@H I
)@@I J
)@@J K
)@@K L
&&@@M O
(BB 
stringBB 
.BB 
IsNullOrEmptyBB )
(BB) *
filterBB* 0
.BB0 1
SpecialisationBB1 ?
)BB? @
||BBA C
dCC 
.CC 
SpecialisationCC (
==CC) +
filterCC, 2
.CC2 3
SpecialisationCC3 A
)CCA B
&&CCC E
(EE 
!EE 
filterEE 
.EE 
IsActiveEE %
.EE% &
HasValueEE& .
||EE/ 1
dFF 
.FF 
IsActiveFF "
==FF# %
filterFF& ,
.FF, -
IsActiveFF- 5
.FF5 6
ValueFF6 ;
)FF; <
;FF< =
FuncHH 
<HH 

IQueryableHH 
<HH 
DoctorHH "
>HH" #
,HH# $
IOrderedQueryableHH% 6
<HH6 7
DoctorHH7 =
>HH= >
>HH> ?
orderByHH@ G
=HHH I
qHHJ K
=>HHL N
{II 
ifKK 
(KK 
!KK 
stringKK 
.KK 
IsNullOrEmptyKK )
(KK) *
filterKK* 0
.KK0 1
ExperienceOrderKK1 @
)KK@ A
)KKA B
{LL 
ifMM 
(MM 
filterMM 
.MM 
ExperienceOrderMM .
==MM/ 1
$strMM2 7
)MM7 8
returnNN 
qNN  
.NN  !
OrderByNN! (
(NN( )
dNN) *
=>NN+ -
dNN. /
.NN/ 0
YearsOfExperienceNN0 A
)NNA B
;NNB C
returnPP 
qPP 
.PP 
OrderByDescendingPP .
(PP. /
dPP/ 0
=>PP1 3
dPP4 5
.PP5 6
YearsOfExperiencePP6 G
)PPG H
;PPH I
}QQ 
returnSS 
qSS 
.SS 
OrderBySS  
(SS  !
dSS! "
=>SS# %
dSS& '
.SS' (
DoctorIdSS( 0
)SS0 1
;SS1 2
}TT 
;TT 
varVV 
pagedResultVV 
=VV 
awaitVV #
_repositoryVV$ /
.VV/ 0
GetAllAsyncVV0 ;
(VV; <
filterWW 
.WW 

PageNumberWW !
,WW! "
filterXX 
.XX 
PageSizeXX 
,XX  
	predicateYY 
,YY 
orderByZZ 
)[[ 
;[[ 
return]] 
new]] 
PagedResult]] "
<]]" #
DoctorListDto]]# 0
>]]0 1
{^^ 
Items__ 
=__ 
_mapper__ 
.__  
Map__  #
<__# $
IEnumerable__$ /
<__/ 0
DoctorListDto__0 =
>__= >
>__> ?
(__? @
pagedResult__@ K
.__K L
Items__L Q
)__Q R
,__R S

PageNumber`` 
=`` 
pagedResult`` (
.``( )

PageNumber``) 3
,``3 4
PageSizeaa 
=aa 
pagedResultaa &
.aa& '
PageSizeaa' /
,aa/ 0

TotalCountbb 
=bb 
pagedResultbb (
.bb( )

TotalCountbb) 3
}cc 
;cc 
}dd 	
publicff 
asyncff 
Taskff 
AddAsyncff "
(ff" #
CreateDoctorDtoff# 2
dtoff3 6
)ff6 7
{gg 	
varhh 
doctorhh 
=hh 
_mapperhh  
.hh  !
Maphh! $
<hh$ %
Doctorhh% +
>hh+ ,
(hh, -
dtohh- 0
)hh0 1
;hh1 2
awaitii 
_repositoryii 
.ii 
AddAsyncii &
(ii& '
doctorii' -
)ii- .
;ii. /
awaitkk 
_repositorykk 
.kk 
CreateSlotskk )
(kk) *
doctorkk* 0
.kk0 1
DoctorIdkk1 9
,kk9 :
dtokk; >
.kk> ?
	TimeSlotskk? H
)kkH I
;kkI J
awaitmm 
_contextmm 
.mm 
SaveChangesAsyncmm +
(mm+ ,
)mm, -
;mm- .
}nn 	
publicpp 
asyncpp 
Taskpp 
UpdateAsyncpp %
(pp% &
intpp& )
idpp* ,
,pp, -
UpdateDoctorDtopp. =
dtopp> A
)ppA B
{qq 	
varrr 
doctorrr 
=rr 
awaitrr 
_repositoryrr *
.rr* +
GetByIdAsyncrr+ 7
(rr7 8
idrr8 :
)rr: ;
;rr; <
iftt 
(tt 
doctortt 
istt 
nulltt 
)tt 
throwuu 
newuu %
InvalidOperationExceptionuu 3
(uu3 4$
NotFoundExceptionMessageuu4 L
)uuL M
;uuM N
_mapperww 
.ww 
Mapww 
(ww 
dtoww 
,ww 
doctorww #
)ww# $
;ww$ %
awaityy 
_repositoryyy 
.yy 
UpdateAsyncyy )
(yy) *
doctoryy* 0
)yy0 1
;yy1 2
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
var 
doctor 
= 
await 
_repository *
.* +
GetByIdAsync+ 7
(7 8
id8 :
): ;
;; <
if
ÅÅ 
(
ÅÅ 
doctor
ÅÅ 
is
ÅÅ 
null
ÅÅ 
)
ÅÅ 
throw
ÇÇ 
new
ÇÇ '
InvalidOperationException
ÇÇ 3
(
ÇÇ3 4&
NotFoundExceptionMessage
ÇÇ4 L
)
ÇÇL M
;
ÇÇM N
doctor
ÑÑ 
.
ÑÑ 
IsActive
ÑÑ 
=
ÑÑ 
isActive
ÑÑ &
;
ÑÑ& '
await
ÜÜ 
_repository
ÜÜ 
.
ÜÜ 
UpdateAsync
ÜÜ )
(
ÜÜ) *
doctor
ÜÜ* 0
)
ÜÜ0 1
;
ÜÜ1 2
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
áá- .
await
ââ 9
+InvalidateAvailabilityCacheBySpecialisation
ââ =
(
ââ= >
doctor
ää 
.
ää 
Specialisation
ää (
)
ää( )
;
ää) *
}
åå 	
public
éé 
async
éé 
Task
éé 
DeleteAsync
éé %
(
éé% &
int
éé& )
id
éé* ,
)
éé, -
{
èè 	
var
êê 
doctor
êê 
=
êê 
await
êê 
_repository
êê *
.
êê* +
GetByIdAsync
êê+ 7
(
êê7 8
id
êê8 :
)
êê: ;
;
êê; <
if
íí 
(
íí 
doctor
íí 
is
íí 
null
íí 
)
íí 
throw
ìì 
new
ìì '
InvalidOperationException
ìì 3
(
ìì3 4&
NotFoundExceptionMessage
ìì4 L
)
ììL M
;
ììM N
try
ïï 
{
ññ 
await
óó 
_repository
óó !
.
óó! "
DeleteAsync
óó" -
(
óó- .
id
óó. 0
)
óó0 1
;
óó1 2
await
òò 
_context
òò 
.
òò 
SaveChangesAsync
òò /
(
òò/ 0
)
òò0 1
;
òò1 2
}
ôô 
catch
öö 
(
öö 
DbUpdateException
öö $
ex
öö% '
)
öö' (
{
õõ 
throw
úú 
new
úú '
InvalidOperationException
úú 3
(
úú3 4
$strúú4 è
,úúè ê
exúúë ì
)úúì î
;úúî ï
}
ùù 
}
ûû 	
public
†† 
async
†† 
Task
†† 
<
†† 
List
†† 
<
†† 
string
†† %
>
††% &
>
††& '
GetSlots
††( 0
(
††0 1
int
††1 4
doctorId
††5 =
)
††= >
{
°° 	
var
¢¢ 
slots
¢¢ 
=
¢¢ 
await
¢¢ 
_repository
¢¢ )
.
¢¢) *
GetSlots
¢¢* 2
(
¢¢2 3
doctorId
¢¢3 ;
)
¢¢; <
;
¢¢< =
if
§§ 
(
§§ 
slots
§§ 
.
§§ 
Count
§§ 
==
§§ 
$num
§§  
)
§§  !
throw
•• 
new
•• '
InvalidOperationException
•• 3
(
••3 4
$str
••4 _
)
••_ `
;
••` a
return
ßß 
slots
ßß 
;
ßß 
}
®® 	
public
™™ 
async
™™ 
Task
™™ 
CreateSlots
™™ %
(
™™% &
int
™™& )
id
™™* ,
,
™™, -
List
™™. 2
<
™™2 3
string
™™3 9
>
™™9 :
	timeslots
™™; D
)
™™D E
{
´´ 	
await
¨¨ 
_repository
¨¨ 
.
¨¨ 
CreateSlots
¨¨ )
(
¨¨) *
id
¨¨* ,
,
¨¨, -
	timeslots
¨¨. 7
)
¨¨7 8
;
¨¨8 9
await
≠≠ 
_context
≠≠ 
.
≠≠ 
SaveChangesAsync
≠≠ +
(
≠≠+ ,
)
≠≠, -
;
≠≠- .
}
ÆÆ 	
private
∞∞ 
async
∞∞ 
Task
∞∞ 
<
∞∞ 
List
∞∞ 
<
∞∞  
string
∞∞  &
>
∞∞& '
>
∞∞' (%
AvailableTimeSlotsCheck
∞∞) @
(
∞∞@ A
DateOnly
∞∞A I
date
∞∞J N
,
∞∞N O
int
∞∞P S
doctorId
∞∞T \
)
∞∞\ ]
{
±± 	
var
≤≤ 
allSlots
≤≤ 
=
≤≤ 
await
≤≤  
_repository
≤≤! ,
.
≤≤, -
GetSlots
≤≤- 5
(
≤≤5 6
doctorId
≤≤6 >
)
≤≤> ?
;
≤≤? @
var
≥≥ 
bookedSlots
≥≥ 
=
≥≥ 
await
≥≥ #$
_appointmentRepository
≥≥$ :
.
≥≥: ;
BookedTimeSlots
≥≥; J
(
≥≥J K
date
≥≥K O
,
≥≥O P
doctorId
≥≥Q Y
)
≥≥Y Z
;
≥≥Z [
return
¥¥ 
allSlots
¥¥ 
.
¥¥ 
Except
¥¥ "
(
¥¥" #
bookedSlots
¥¥# .
)
¥¥. /
.
¥¥/ 0
ToList
¥¥0 6
(
¥¥6 7
)
¥¥7 8
;
¥¥8 9
}
µµ 	
public
∑∑ 
async
∑∑ 
Task
∑∑ 
<
∑∑ "
CreateLeaveResultDto
∑∑ .
>
∑∑. /
CreateLeave
∑∑0 ;
(
∑∑; <
int
∏∏ 
id
∏∏ 

,
∏∏
 
List
ππ 
<
ππ 	
CreateLeaveDto
ππ	 
>
ππ 
leaves
ππ 
)
ππ  
{
∫∫ 	
var
ªª 
result
ªª 
=
ªª 
new
ªª "
CreateLeaveResultDto
ªª 1
(
ªª1 2
)
ªª2 3
;
ªª3 4
var
ΩΩ 
existingLeaves
ΩΩ 
=
ΩΩ  
await
ΩΩ! &
_repository
ΩΩ' 2
.
ΩΩ2 3!
GetLeavesByDoctorId
ΩΩ3 F
(
ΩΩF G
id
ΩΩG I
)
ΩΩI J
;
ΩΩJ K
var
øø  
existingLeaveDates
øø "
=
øø# $
existingLeaves
¿¿ 
.
¿¿ 
Select
¿¿ %
(
¿¿% &
l
¿¿& '
=>
¿¿( *
l
¿¿+ ,
.
¿¿, -
	LeaveDate
¿¿- 6
)
¿¿6 7
.
¡¡ 
	ToHashSet
¡¡ (
(
¡¡( )
)
¡¡) *
;
¡¡* +
var
√√ 
leavesToCreate
√√ 
=
√√  
new
√√! $
List
√√% )
<
√√) *
CreateLeaveDto
√√* 8
>
√√8 9
(
√√9 :
)
√√: ;
;
√√; <
foreach
≈≈ 
(
≈≈ 
var
≈≈ 
leave
≈≈ 
in
≈≈ !
leaves
≈≈" (
)
≈≈( )
{
∆∆ 
await
«« !
ProcessLeaveRequest
«« )
(
««) *
id
»» 
,
»» 
leave
…… 
,
……  
existingLeaveDates
   &
,
  & '
leavesToCreate
ÀÀ "
,
ÀÀ" #
result
ÃÃ 
)
ÃÃ 
;
ÃÃ 
}
ÕÕ 
if
œœ 
(
œœ 
leavesToCreate
œœ 
.
œœ 
Count
œœ $
>
œœ% &
$num
œœ' (
)
œœ( )
{
–– 
await
—— *
SaveLeavesAndInvalidateCache
—— 2
(
——2 3
id
““ 
,
““ 
leavesToCreate
”” "
)
””" #
;
””# $
}
‘‘ 
return
÷÷ 
result
÷÷ 
;
÷÷ 
}
◊◊ 	
private
ŸŸ 
async
ŸŸ 
Task
ŸŸ !
ProcessLeaveRequest
ŸŸ .
(
ŸŸ. /
int
⁄⁄ 
doctorId
⁄⁄ 
,
⁄⁄ 
CreateLeaveDto
€€ 
leave
€€ 
,
€€ 
HashSet
‹‹ 
<
‹‹ 
DateOnly
‹‹ 
>
‹‹  
existingLeaveDates
‹‹ (
,
‹‹( )
List
›› 
<
›› 	
CreateLeaveDto
››	 
>
›› 
leavesToCreate
›› '
,
››' ("
CreateLeaveResultDto
ﬁﬁ 
result
ﬁﬁ 
)
ﬁﬁ  
{
ﬂﬂ 	
if
‡‡ 
(
‡‡  
existingLeaveDates
‡‡ "
.
‡‡" #
Contains
‡‡# +
(
‡‡+ ,
leave
‡‡, 1
.
‡‡1 2
	LeaveDate
‡‡2 ;
)
‡‡; <
)
‡‡< =
{
·· 
result
‚‚ 
.
‚‚ 
SkippedDates
‚‚ #
.
‚‚# $
Add
‚‚$ '
(
‚‚' (
leave
‚‚( -
.
‚‚- .
	LeaveDate
‚‚. 7
)
‚‚7 8
;
‚‚8 9
return
„„ 
;
„„ 
}
‰‰ 
var
ÊÊ 
availableSlots
ÊÊ 
=
ÊÊ  
await
ÁÁ %
AvailableTimeSlotsCheck
ÁÁ -
(
ÁÁ- .
leave
ËË 
.
ËË 
	LeaveDate
ËË #
,
ËË# $
doctorId
ÈÈ 
)
ÈÈ 
;
ÈÈ 
var
ÎÎ 
allSlots
ÎÎ 
=
ÎÎ 
await
ÏÏ 
GetSlots
ÏÏ 
(
ÏÏ 
doctorId
ÏÏ '
)
ÏÏ' (
;
ÏÏ( )
if
ÓÓ 
(
ÓÓ 
availableSlots
ÓÓ 
.
ÓÓ 
Count
ÓÓ $
!=
ÓÓ% '
allSlots
ÓÓ( 0
.
ÓÓ0 1
Count
ÓÓ1 6
)
ÓÓ6 7
{
ÔÔ 
await
 $
_appointmentRepository
 ,
.
ÒÒ ,
CancelAppointmentsByDoctorDate
ÒÒ 3
(
ÒÒ3 4
doctorId
ÚÚ  
,
ÚÚ  !
leave
ÛÛ 
.
ÛÛ 
	LeaveDate
ÛÛ '
)
ÛÛ' (
;
ÛÛ( )
result
ıı 
.
ıı .
 CreatedWithCancelledAppointments
ıı 7
.
ˆˆ 
Add
ˆˆ 
(
ˆˆ 
leave
ˆˆ  
.
ˆˆ  !
	LeaveDate
ˆˆ! *
)
ˆˆ* +
;
ˆˆ+ ,
}
˜˜ 
leavesToCreate
˘˘ 
.
˘˘ 
Add
˘˘ 
(
˘˘ 
leave
˘˘ $
)
˘˘$ %
;
˘˘% &
}
˙˙ 	
private
¸¸ 
async
¸¸ 
Task
¸¸ *
SaveLeavesAndInvalidateCache
¸¸ 7
(
¸¸7 8
int
˝˝ 
doctorId
˝˝ 
,
˝˝ 
List
˛˛ 
<
˛˛ 	
CreateLeaveDto
˛˛	 
>
˛˛ 
leavesToCreate
˛˛ '
)
˛˛' (
{
ˇˇ 	
await
ÄÄ 
_repository
ÄÄ 
.
ÄÄ 
CreateLeaves
ÄÄ *
(
ÄÄ* +
doctorId
ÅÅ 
,
ÅÅ 
leavesToCreate
ÇÇ 
)
ÇÇ 
;
ÇÇ  
await
ÑÑ 
_context
ÑÑ 
.
ÑÑ 
SaveChangesAsync
ÑÑ +
(
ÑÑ+ ,
)
ÑÑ, -
;
ÑÑ- .
var
ÜÜ 
doctor
ÜÜ 
=
ÜÜ 
await
áá 
_context
áá 
.
áá 
Doctors
áá &
.
àà 

FirstAsync
àà 
(
àà  
d
àà  !
=>
àà" $
d
àà% &
.
àà& '
DoctorId
àà' /
==
àà0 2
doctorId
àà3 ;
)
àà; <
;
àà< =
foreach
ää 
(
ää 
var
ää 
leave
ää 
in
ää !
leavesToCreate
ää" 0
)
ää0 1
{
ãã 
await
åå %
RemoveAvailabilityCache
åå -
(
åå- .
doctor
çç 
.
çç 
Specialisation
çç )
,
çç) *
leave
éé 
.
éé 
	LeaveDate
éé #
)
éé# $
;
éé$ %
}
èè 
}
êê 	
private
íí 
async
íí 
Task
íí %
RemoveAvailabilityCache
íí 2
(
íí2 3
string
ìì 

specialisation
ìì 
,
ìì 
DateOnly
îî 
	leaveDate
îî 
)
îî 
{
ïï 	
var
ññ 
cacheKey
ññ 
=
ññ 
$"
óó 
$str
óó 
{
óó 
specialisation
óó )
}
óó) *
$str
óó* 8
{
óó8 9
	leaveDate
óó9 B
}
óóB C
"
óóC D
;
óóD E
if
ôô 
(
ôô 
_logger
ôô 
.
ôô 
	IsEnabled
ôô !
(
ôô! "
LogLevel
ôô" *
.
ôô* +
Information
ôô+ 6
)
ôô6 7
)
ôô7 8
{
öö 
_logger
õõ 
.
õõ 
LogInformation
õõ &
(
õõ& '
$str
úú *
,
úú* +
cacheKey
ùù 
)
ùù 
;
ùù 
}
ûû 
try
†† 
{
°° 
await
¢¢ 
_cache
¢¢ 
.
¢¢ 
RemoveAsync
¢¢ (
(
¢¢( )
cacheKey
¢¢) 1
)
¢¢1 2
;
¢¢2 3
if
§§ 
(
§§ 
_logger
§§ 
.
§§ 
	IsEnabled
§§ %
(
§§% &
LogLevel
§§& .
.
§§. /
Information
§§/ :
)
§§: ;
)
§§; <
{
•• 
_logger
¶¶ 
.
¶¶ 
LogInformation
¶¶ *
(
¶¶* +
$str
ßß -
,
ßß- .
cacheKey
®® 
)
®® 
;
®® 
}
©© 
}
™™ 
catch
´´ 
(
´´ 
	Exception
´´ 
ex
´´ 
)
´´  
{
¨¨ 
if
≠≠ 
(
≠≠ 
_logger
≠≠ 
.
≠≠ 
	IsEnabled
≠≠ %
(
≠≠% &
LogLevel
≠≠& .
.
≠≠. /
Information
≠≠/ :
)
≠≠: ;
)
≠≠; <
{
ÆÆ 
_logger
ØØ 
.
ØØ 

LogWarning
ØØ &
(
ØØ& '
ex
∞∞ 
,
∞∞ 
$str
±± 6
,
±±6 7
cacheKey
≤≤ 
)
≤≤ 
;
≤≤ 
}
≥≥ 
}
¥¥ 
}
µµ 	
public
∑∑ 
async
∑∑ 
Task
∑∑ 
<
∑∑ )
AvailableDoctorsResponseDto
∑∑ 5
>
∑∑5 6
AvailableDoctors
∑∑7 G
(
∑∑G H
string
∏∏ 

specialisation
∏∏ 
,
∏∏ 
DateOnly
ππ 
date
ππ 
)
ππ 
{
∫∫ 	
var
ªª 
cacheKey
ªª 
=
ªª 
$"
ºº 
$str
ºº 
{
ºº 
specialisation
ºº )
}
ºº) *
$str
ºº* 8
{
ºº8 9
date
ºº9 =
}
ºº= >
"
ºº> ?
;
ºº? @
var
ææ 
cachedResponse
ææ 
=
ææ  
await
ææ! &#
GetCachedAvailability
ææ' <
(
ææ< =
cacheKey
ææ= E
)
ææE F
;
ææF G
if
¿¿ 
(
¿¿ 
cachedResponse
¿¿ 
!=
¿¿ !
null
¿¿" &
)
¿¿& '
return
¡¡ 
cachedResponse
¡¡ %
;
¡¡% &
var
√√ 

allDoctors
√√ 
=
√√ 
await
√√ "
_context
√√# +
.
√√+ ,
Doctors
√√, 3
.
ƒƒ 
Where
ƒƒ 
(
ƒƒ 
d
ƒƒ 
=>
ƒƒ 
d
ƒƒ 
.
ƒƒ 
Specialisation
ƒƒ ,
==
ƒƒ- /
specialisation
ƒƒ0 >
)
ƒƒ> ?
.
≈≈ 
ToListAsync
≈≈ 
(
≈≈ 
)
≈≈ 
;
≈≈ 
if
«« 
(
«« 

allDoctors
«« 
.
«« 
Count
««  
==
««! #
$num
««$ %
)
««% &
return
»» !
CreateEmptyResponse
»» *
(
»»* +
$str
…… B
)
……B C
;
……C D
var
ÀÀ 
activeDoctors
ÀÀ 
=
ÀÀ 

allDoctors
ÀÀ  *
.
ÃÃ 
Where
ÃÃ 
(
ÃÃ 
d
ÃÃ 
=>
ÃÃ 
d
ÃÃ 
.
ÃÃ 
IsActive
ÃÃ &
)
ÃÃ& '
.
ÕÕ 
ToList
ÕÕ 
(
ÕÕ 
)
ÕÕ 
;
ÕÕ 
if
œœ 
(
œœ 
activeDoctors
œœ 
.
œœ 
Count
œœ #
==
œœ$ &
$num
œœ' (
)
œœ( )
return
–– !
CreateEmptyResponse
–– *
(
––* +
$str
—— *
)
——* +
;
——+ ,
var
”” 
availableDoctors
””  
=
””! "
await
‘‘ !
GetAvailableDoctors
‘‘ )
(
‘‘) *
activeDoctors
‘‘* 7
,
‘‘7 8
date
‘‘9 =
)
‘‘= >
;
‘‘> ?
var
÷÷ 
response
÷÷ 
=
÷÷ '
BuildAvailabilityResponse
÷÷ 4
(
÷÷4 5
availableDoctors
◊◊  
)
◊◊  !
;
◊◊! "
await
ŸŸ 
CacheAvailability
ŸŸ #
(
ŸŸ# $
cacheKey
ŸŸ$ ,
,
ŸŸ, -
response
ŸŸ. 6
)
ŸŸ6 7
;
ŸŸ7 8
return
€€ 
response
€€ 
;
€€ 
}
‹‹ 	
private
ﬁﬁ 
async
ﬁﬁ 
Task
ﬁﬁ 
<
ﬁﬁ )
AvailableDoctorsResponseDto
ﬁﬁ 6
?
ﬁﬁ6 7
>
ﬁﬁ7 8#
GetCachedAvailability
ﬂﬂ 
(
ﬂﬂ 
string
ﬂﬂ  
cacheKey
ﬂﬂ! )
)
ﬂﬂ) *
{
‡‡ 	
try
·· 
{
‚‚ 
var
„„ 

cachedData
„„ 
=
„„  
await
‰‰ 
_cache
‰‰  
.
‰‰  !
GetStringAsync
‰‰! /
(
‰‰/ 0
cacheKey
‰‰0 8
)
‰‰8 9
;
‰‰9 :
if
ÊÊ 
(
ÊÊ 
string
ÊÊ 
.
ÊÊ 
IsNullOrEmpty
ÊÊ (
(
ÊÊ( )

cachedData
ÊÊ) 3
)
ÊÊ3 4
)
ÊÊ4 5
return
ÁÁ 
null
ÁÁ 
;
ÁÁ  
if
ÈÈ 
(
ÈÈ 
_logger
ÈÈ 
.
ÈÈ 
	IsEnabled
ÈÈ %
(
ÈÈ% &
LogLevel
ÈÈ& .
.
ÈÈ. /
Information
ÈÈ/ :
)
ÈÈ: ;
)
ÈÈ; <
{
ÍÍ 
_logger
ÎÎ 
.
ÎÎ 
LogInformation
ÎÎ *
(
ÎÎ* +
$str
ÏÏ >
,
ÏÏ> ?
cacheKey
ÌÌ 
)
ÌÌ 
;
ÌÌ 
}
ÓÓ 
return
 
JsonSerializer
 %
.
% &
Deserialize
& 1
<
1 2)
AvailableDoctorsResponseDto
ÒÒ /
>
ÒÒ/ 0
(
ÒÒ0 1

cachedData
ÚÚ "
)
ÚÚ" #
;
ÚÚ# $
}
ÛÛ 
catch
ÙÙ 
(
ÙÙ 
	Exception
ÙÙ 
ex
ÙÙ 
)
ÙÙ  
{
ıı 
if
ˆˆ 
(
ˆˆ 
_logger
ˆˆ 
.
ˆˆ 
	IsEnabled
ˆˆ %
(
ˆˆ% &
LogLevel
ˆˆ& .
.
ˆˆ. /
Information
ˆˆ/ :
)
ˆˆ: ;
)
ˆˆ; <
{
˜˜ 
_logger
¯¯ 
.
¯¯ 

LogWarning
¯¯ &
(
¯¯& '
ex
˘˘ 
,
˘˘ 
$str
˙˙ U
,
˙˙U V
cacheKey
˚˚ 
)
˚˚ 
;
˚˚ 
}
¸¸ 
return
˛˛ 
null
˛˛ 
;
˛˛ 
}
ˇˇ 
}
ÄÄ 	
private
ÇÇ 
static
ÇÇ )
AvailableDoctorsResponseDto
ÇÇ 2!
CreateEmptyResponse
ÉÉ 
(
ÉÉ 
string
ÉÉ 
message
ÉÉ &
)
ÉÉ& '
{
ÑÑ 	
return
ÖÖ 
new
ÖÖ )
AvailableDoctorsResponseDto
ÖÖ 2
{
ÜÜ 
Doctors
áá 
=
áá 
new
áá 
List
áá "
<
áá" #
DoctorListDto
áá# 0
>
áá0 1
(
áá1 2
)
áá2 3
,
áá3 4
Message
àà 
=
àà 
message
àà !
}
ââ 
;
ââ 
}
ää 	
private
åå 
async
åå 
Task
åå 
<
åå 
List
åå 
<
åå  
Doctor
åå  &
>
åå& '
>
åå' (!
GetAvailableDoctors
çç 
(
çç 
List
éé 
<
éé 
Doctor
éé 
>
éé 
activeDoctors
éé "
,
éé" #
DateOnly
èè 
date
èè 
)
èè 
{
êê 	
var
ëë 
availableDoctors
ëë  
=
ëë! "
new
íí 
List
íí 
<
íí 
Doctor
íí 
>
íí  
(
íí  !
)
íí! "
;
íí" #
foreach
îî 
(
îî 
var
îî 
doctor
îî 
in
îî  "
activeDoctors
îî# 0
)
îî0 1
{
ïï 
var
ññ 
	isOnLeave
ññ 
=
ññ 
await
óó 
_context
óó "
.
óó" #
DoctorLeaves
óó# /
.
òò 
AnyAsync
òò !
(
òò! "
l
òò" #
=>
òò$ &
l
ôô 
.
ôô 
DoctorId
ôô &
==
ôô' )
doctor
ôô* 0
.
ôô0 1
DoctorId
ôô1 9
&&
ôô: <
l
öö 
.
öö 
	LeaveDate
öö '
==
öö( *
date
öö+ /
)
öö/ 0
;
öö0 1
if
úú 
(
úú 
!
úú 
	isOnLeave
úú 
)
úú 
{
ùù 
availableDoctors
ûû $
.
ûû$ %
Add
ûû% (
(
ûû( )
doctor
ûû) /
)
ûû/ 0
;
ûû0 1
}
üü 
}
†† 
return
¢¢ 
availableDoctors
¢¢ #
;
¢¢# $
}
££ 	
private
•• )
AvailableDoctorsResponseDto
•• +'
BuildAvailabilityResponse
¶¶ 
(
¶¶ 
List
ßß 
<
ßß 
Doctor
ßß 
>
ßß 
availableDoctors
ßß %
)
ßß% &
{
®® 	
var
©© 
result
©© 
=
©© 
_mapper
™™ 
.
™™ 
Map
™™ 
<
™™ 
List
™™  
<
™™  !
DoctorListDto
™™! .
>
™™. /
>
™™/ 0
(
™™0 1
availableDoctors
´´ $
)
´´$ %
;
´´% &
return
≠≠ 
new
≠≠ )
AvailableDoctorsResponseDto
≠≠ 2
{
ÆÆ 
Doctors
ØØ 
=
ØØ 
result
ØØ  
,
ØØ  !
Message
∞∞ 
=
∞∞ 
result
∞∞  
.
∞∞  !
Count
∞∞! &
==
∞∞' )
$num
∞∞* +
?
±± 
$str
±± *
:
≤≤ 
string
≤≤ 
.
≤≤ 
Empty
≤≤ "
}
≥≥ 
;
≥≥ 
}
¥¥ 	
private
∂∂ 
async
∂∂ 
Task
∂∂ 
CacheAvailability
∂∂ ,
(
∂∂, -
string
∑∑ 

cacheKey
∑∑ 
,
∑∑ )
AvailableDoctorsResponseDto
∏∏ 
response
∏∏  (
)
∏∏( )
{
ππ 	
try
∫∫ 
{
ªª 
if
ºº 
(
ºº 
_logger
ºº 
.
ºº 
	IsEnabled
ºº %
(
ºº% &
LogLevel
ºº& .
.
ºº. /
Information
ºº/ :
)
ºº: ;
)
ºº; <
{
ΩΩ 
_logger
ææ 
.
ææ 
LogInformation
ææ *
(
ææ* +
$str
øø K
,
øøK L
cacheKey
¿¿ 
)
¿¿ 
;
¿¿ 
}
¡¡ 
await
√√ 
_cache
√√ 
.
√√ 
SetStringAsync
√√ +
(
√√+ ,
cacheKey
ƒƒ 
,
ƒƒ 
JsonSerializer
≈≈ "
.
≈≈" #
	Serialize
≈≈# ,
(
≈≈, -
response
≈≈- 5
)
≈≈5 6
,
≈≈6 7
new
∆∆ *
DistributedCacheEntryOptions
∆∆ 4
{
«« -
AbsoluteExpirationRelativeToNow
»» 7
=
»»8 9
TimeSpan
…… $
.
……$ %
FromMinutes
……% 0
(
……0 1
$num
……1 2
)
……2 3
}
   
)
   
;
   
}
ÀÀ 
catch
ÃÃ 
(
ÃÃ 
	Exception
ÃÃ 
ex
ÃÃ 
)
ÃÃ  
{
ÕÕ 
if
ŒŒ 
(
ŒŒ 
_logger
ŒŒ 
.
ŒŒ 
	IsEnabled
ŒŒ %
(
ŒŒ% &
LogLevel
ŒŒ& .
.
ŒŒ. /
Information
ŒŒ/ :
)
ŒŒ: ;
)
ŒŒ; <
{
œœ 
_logger
–– 
.
–– 

LogWarning
–– &
(
––& '
ex
—— 
,
—— 
$str
““ D
,
““D E
cacheKey
”” 
)
”” 
;
”” 
}
‘‘ 
}
’’ 
}
÷÷ 	
private
ÿÿ 
async
ÿÿ 
Task
ÿÿ 9
+InvalidateAvailabilityCacheBySpecialisation
ÿÿ F
(
ÿÿF G
string
ŸŸ 

specialisation
ŸŸ 
)
ŸŸ 
{
⁄⁄ 	
var
€€ 
today
€€ 
=
€€ 
DateOnly
€€  
.
€€  !
FromDateTime
€€! -
(
€€- .
DateTime
€€. 6
.
€€6 7
Today
€€7 <
)
€€< =
;
€€= >
for
›› 
(
›› 
int
›› 
i
›› 
=
›› 
$num
›› 
;
›› 
i
›› 
<
›› 
$num
››  "
;
››" #
i
››$ %
++
››% '
)
››' (
{
ﬁﬁ 
var
ﬂﬂ 
date
ﬂﬂ 
=
ﬂﬂ 
today
ﬂﬂ  
.
ﬂﬂ  !
AddDays
ﬂﬂ! (
(
ﬂﬂ( )
i
ﬂﬂ) *
)
ﬂﬂ* +
;
ﬂﬂ+ ,
var
·· 
cacheKey
·· 
=
·· 
$"
‚‚ 
$str
‚‚ 
{
‚‚ 
specialisation
‚‚ -
}
‚‚- .
$str
‚‚. <
{
‚‚< =
date
‚‚= A
}
‚‚A B
"
‚‚B C
;
‚‚C D
if
‰‰ 
(
‰‰ 
_logger
‰‰ 
.
‰‰ 
	IsEnabled
‰‰ %
(
‰‰% &
LogLevel
‰‰& .
.
‰‰. /
Information
‰‰/ :
)
‰‰: ;
)
‰‰; <
{
ÂÂ 
_logger
ÊÊ 
.
ÊÊ 
LogInformation
ÊÊ *
(
ÊÊ* +
$str
ÁÁ .
,
ÁÁ. /
cacheKey
ËË 
)
ËË 
;
ËË 
}
ÈÈ 
try
ÎÎ 
{
ÏÏ 
await
ÌÌ 
_cache
ÌÌ  
.
ÌÌ  !
RemoveAsync
ÌÌ! ,
(
ÌÌ, -
cacheKey
ÌÌ- 5
)
ÌÌ5 6
;
ÌÌ6 7
if
ÔÔ 
(
ÔÔ 
_logger
ÔÔ 
.
ÔÔ  
	IsEnabled
ÔÔ  )
(
ÔÔ) *
LogLevel
ÔÔ* 2
.
ÔÔ2 3
Information
ÔÔ3 >
)
ÔÔ> ?
)
ÔÔ? @
{
 
_logger
ÒÒ 
.
ÒÒ  
LogInformation
ÒÒ  .
(
ÒÒ. /
$str
ÚÚ 1
,
ÚÚ1 2
cacheKey
ÛÛ  
)
ÛÛ  !
;
ÛÛ! "
}
ÙÙ 
}
ıı 
catch
ˆˆ 
(
ˆˆ 
	Exception
ˆˆ  
ex
ˆˆ! #
)
ˆˆ# $
{
˜˜ 
if
¯¯ 
(
¯¯ 
_logger
¯¯ 
.
¯¯  
	IsEnabled
¯¯  )
(
¯¯) *
LogLevel
¯¯* 2
.
¯¯2 3
Information
¯¯3 >
)
¯¯> ?
)
¯¯? @
{
˘˘ 
_logger
˙˙ 
.
˙˙  

LogWarning
˙˙  *
(
˙˙* +
ex
˚˚ 
,
˚˚ 
$str
¸¸ :
,
¸¸: ;
cacheKey
˝˝  
)
˝˝  !
;
˝˝! "
}
˛˛ 
}
ˇˇ 
}
ÄÄ 
}
ÅÅ 	
public
ÉÉ 
async
ÉÉ 
Task
ÉÉ 
<
ÉÉ 
DoctorSummaryDto
ÉÉ *
>
ÉÉ* +
GetSummaryAsync
ÉÉ, ;
(
ÉÉ; <
)
ÉÉ< =
{
ÑÑ 	
var
ÖÖ 
fromDate
ÖÖ 
=
ÖÖ 
DateTimeOffset
ÖÖ )
.
ÖÖ) *
UtcNow
ÖÖ* 0
.
ÖÖ0 1
AddDays
ÖÖ1 8
(
ÖÖ8 9
-
ÖÖ9 :
$num
ÖÖ: <
)
ÖÖ< =
;
ÖÖ= >
var
ÜÜ 
toDate
ÜÜ 
=
ÜÜ 
DateTimeOffset
ÜÜ '
.
ÜÜ' (
UtcNow
ÜÜ( .
;
ÜÜ. /
var
àà 
result
àà 
=
àà 
await
àà 
_context
àà '
.
àà' (
Doctors
àà( /
.
ââ 
Where
ââ 
(
ââ 
d
ââ 
=>
ââ 
d
ââ 
.
ââ 
CreatedDate
ââ )
>=
ââ* ,
fromDate
ââ- 5
&&
ââ6 8
d
ââ9 :
.
ââ: ;
CreatedDate
ââ; F
<=
ââG I
toDate
ââJ P
)
ââP Q
.
ää 
GroupBy
ää 
(
ää 
d
ää 
=>
ää 
$num
ää 
)
ää  
.
ãã 
Select
ãã 
(
ãã 
g
ãã 
=>
ãã 
new
ãã  
DoctorSummaryDto
ãã! 1
{
åå 
TotalDoctors
çç  
=
çç! "
g
çç# $
.
çç$ %
Count
çç% *
(
çç* +
)
çç+ ,
,
çç, -
ActiveDoctors
éé !
=
éé" #
g
éé$ %
.
éé% &
Count
éé& +
(
éé+ ,
d
éé, -
=>
éé. 0
d
éé1 2
.
éé2 3
IsActive
éé3 ;
)
éé; <
,
éé< =
InactiveDoctors
èè #
=
èè$ %
g
èè& '
.
èè' (
Count
èè( -
(
èè- .
d
èè. /
=>
èè0 2
!
èè3 4
d
èè4 5
.
èè5 6
IsActive
èè6 >
)
èè> ?
}
êê 
)
êê 
.
ëë !
FirstOrDefaultAsync
ëë $
(
ëë$ %
)
ëë% &
;
ëë& '
return
ìì 
result
ìì 
??
ìì 
new
ìì  
DoctorSummaryDto
ìì! 1
(
ìì1 2
)
ìì2 3
;
ìì3 4
}
îî 	
public
ññ 
async
ññ 
Task
ññ 
<
ññ  
DoctorDashboardDto
ññ ,
>
ññ, -
GetDashboardAsync
ññ. ?
(
ññ? @
int
ññ@ C
doctorId
ññD L
)
ññL M
{
óó 	
var
òò 
today
òò 
=
òò 
DateOnly
òò  
.
òò  !
FromDateTime
òò! -
(
òò- .
DateTime
òò. 6
.
òò6 7
Today
òò7 <
)
òò< =
;
òò= >
var
öö "
upcomingAppointments
öö $
=
öö% &
await
öö' ,
_context
öö- 5
.
öö5 6
Appointments
öö6 B
.
õõ 

CountAsync
õõ 
(
õõ 
a
õõ 
=>
õõ  
a
úú 
.
úú 
DoctorId
úú 
==
úú !
doctorId
úú" *
&&
úú+ -
a
ùù 
.
ùù 
ScheduledDate
ùù #
>=
ùù$ &
today
ùù' ,
&&
ùù- /
a
ûû 
.
ûû 
Status
ûû 
!=
ûû 
$str
ûû  +
)
ûû+ ,
;
ûû, -
var
†† 
patientsTreated
†† 
=
††  !
await
††" '
_context
††( 0
.
††0 1
Appointments
††1 =
.
°° 

CountAsync
°° 
(
°° 
a
°° 
=>
°°  
a
¢¢ 
.
¢¢ 
DoctorId
¢¢ 
==
¢¢ !
doctorId
¢¢" *
&&
¢¢+ -
a
££ 
.
££ 
Status
££ 
==
££ 
$str
££  +
)
££+ ,
;
££, -
var
•• 
upcomingLeaves
•• 
=
••  
await
••! &
_context
••' /
.
••/ 0
DoctorLeaves
••0 <
.
¶¶ 

CountAsync
¶¶ 
(
¶¶ 
l
¶¶ 
=>
¶¶  
l
ßß 
.
ßß 
DoctorId
ßß 
==
ßß !
doctorId
ßß" *
&&
ßß+ -
l
®® 
.
®® 
	LeaveDate
®® 
>=
®®  "
today
®®# (
)
®®( )
;
®®) *
var
™™ 
todaysSchedule
™™ 
=
™™  
await
™™! &
_context
™™' /
.
™™/ 0
Appointments
™™0 <
.
´´ 
Where
´´ 
(
´´ 
a
´´ 
=>
´´ 
a
¨¨ 
.
¨¨ 
DoctorId
¨¨ 
==
¨¨ !
doctorId
¨¨" *
&&
¨¨+ -
a
≠≠ 
.
≠≠ 
ScheduledDate
≠≠ #
==
≠≠$ &
today
≠≠' ,
&&
≠≠- /
a
ÆÆ 
.
ÆÆ 
Status
ÆÆ 
!=
ÆÆ 
$str
ÆÆ  +
)
ÆÆ+ ,
.
ØØ 
OrderBy
ØØ 
(
ØØ 
a
ØØ 
=>
ØØ 
a
ØØ 
.
ØØ  
TimeSlot
ØØ  (
)
ØØ( )
.
∞∞ 
Select
∞∞ 
(
∞∞ 
a
∞∞ 
=>
∞∞ 
a
∞∞ 
.
∞∞ 
TimeSlot
∞∞ '
)
∞∞' (
.
±± 
ToListAsync
±± 
(
±± 
)
±± 
;
±± 
return
≥≥ 
new
≥≥  
DoctorDashboardDto
≥≥ )
{
¥¥ "
UpcomingAppointments
µµ $
=
µµ% &"
upcomingAppointments
µµ' ;
,
µµ; <
PatientsTreated
∂∂ 
=
∂∂  !
patientsTreated
∂∂" 1
,
∂∂1 2
UpcomingLeaves
∑∑ 
=
∑∑  
upcomingLeaves
∑∑! /
,
∑∑/ 0
TodaysSchedule
∏∏ 
=
∏∏  
todaysSchedule
∏∏! /
}
ππ 
;
ππ 
}
∫∫ 	
}
ªª 
}ºº ê™
qC:\Users\310055\source\repos\UST-Live-01\HealthCare\HealthCare.Api\Services\Implementations\AppointmentService.cs
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
class 
AppointmentService #
:$ %
IAppointmentService& 9
{ 
private 
readonly "
IAppointmentRepository /
_repository0 ;
;; <
private 
readonly 
IDoctorService '
_doctorService( 6
;6 7
private 
readonly 
HealthCareDbContext ,
_context- 5
;5 6
private 
readonly 
IMapper  
_mapper! (
;( )
private 
readonly 
IPublishEndpoint )
_publishEndpoint* :
;: ;
private 
readonly 
ILogger  
<  !
AppointmentService! 3
>3 4
_logger5 <
;< =
private 
readonly 
IDistributedCache *
_cache+ 1
;1 2
public 
AppointmentService !
(! ""
IAppointmentRepository" 8

repository9 C
,C D
IDoctorServiceE S
doctorServiceT a
,a b
HealthCareDbContextc v
contextw ~
,~ 
IMapper
Ä á
mapper
à é
,
é è
IPublishEndpoint
ê †
publishEndpoint
° ∞
,
∞ ±
ILogger
≤ π
<
π ∫ 
AppointmentService
∫ Ã
>
Ã Õ
logger
Œ ‘
,
‘ ’
IDistributedCache
÷ Á
cache
Ë Ì
)
Ì Ó
{ 	
_repository 
= 

repository $
;$ %
_doctorService 
= 
doctorService *
;* +
_context 
= 
context 
; 
_mapper 
= 
mapper 
; 
_publishEndpoint   
=   
publishEndpoint   .
;  . /
_logger!! 
=!! 
logger!! 
;!! 
_cache"" 
="" 
cache"" 
;"" 
}## 	
private%% 
const%% 
string%% &
AppointmentNotFoundMessage%% 7
=%%8 9
$str%%: R
;%%R S
private'' 
const'' 
string'' 
PendingStatus'' *
=''+ ,
$str''- 6
;''6 7
private(( 
const(( 
string(( 
ConfirmedStatus(( ,
=((- .
$str((/ :
;((: ;
private)) 
const)) 
string)) 
CancelledStatus)) ,
=))- .
$str))/ :
;)): ;
private** 
const** 
string** 
CompletedStatus** ,
=**- .
$str**/ :
;**: ;
public,, 
async,, 
Task,, 
<,, 
AppointmentListDto,, ,
?,,, -
>,,- .
GetByIdAsync,,/ ;
(,,; <
int,,< ?
id,,@ B
),,B C
{-- 	
var.. 
appointment.. 
=.. 
await.. #
_repository..$ /
.../ 0
GetByIdAsync..0 <
(..< =
id..= ?
)..? @
;..@ A
if00 
(00 
appointment00 
is00 
null00 #
)00# $
throw11 
new11 %
InvalidOperationException11 3
(113 4&
AppointmentNotFoundMessage114 N
)11N O
;11O P
return33 
_mapper33 
.33 
Map33 
<33 
AppointmentListDto33 1
>331 2
(332 3
appointment333 >
)33> ?
;33? @
}44 	
public66 
async66 
Task66 
<66 
PagedResult66 %
<66% &
AppointmentListDto66& 8
>668 9
>669 :
GetAllAsync66; F
(66F G
AppointmentFilter66G X
filter66Y _
)66_ `
{77 	

Expression99 
<99 
Func99 
<99 
Appointment99 '
,99' (
bool99) -
>99- .
>99. /
?99/ 0
	predicate991 :
=99; <
null99= A
;99A B
if;; 
(;; 
!;; 
string;; 
.;; 
IsNullOrWhiteSpace;; *
(;;* +
filter;;+ 1
.;;1 2
Status;;2 8
);;8 9
&&;;: <
filter;;= C
.;;C D
ScheduledDate;;D Q
.;;Q R
HasValue;;R Z
);;Z [
{<< 
	predicate== 
=== 
a== 
=>==  
a>> 
.>> 
Status>> 
==>> 
filter>>  &
.>>& '
Status>>' -
&&>>. 0
a?? 
.?? 
ScheduledDate?? #
==??$ &
filter??' -
.??- .
ScheduledDate??. ;
.??; <
Value??< A
;??A B
}@@ 
elseAA 
ifAA 
(AA 
!AA 
stringAA 
.AA 
IsNullOrWhiteSpaceAA /
(AA/ 0
filterAA0 6
.AA6 7
StatusAA7 =
)AA= >
)AA> ?
{BB 
	predicateCC 
=CC 
aCC 
=>CC  
aCC! "
.CC" #
StatusCC# )
==CC* ,
filterCC- 3
.CC3 4
StatusCC4 :
;CC: ;
}DD 
elseEE 
ifEE 
(EE 
filterEE 
.EE 
ScheduledDateEE )
.EE) *
HasValueEE* 2
)EE2 3
{FF 
	predicateGG 
=GG 
aGG 
=>GG  
aGG! "
.GG" #
ScheduledDateGG# 0
==GG1 3
filterGG4 :
.GG: ;
ScheduledDateGG; H
.GGH I
ValueGGI N
;GGN O
}HH 
FuncJJ 
<JJ 

IQueryableJJ 
<JJ 
AppointmentJJ '
>JJ' (
,JJ( )
IOrderedQueryableJJ* ;
<JJ; <
AppointmentJJ< G
>JJG H
>JJH I
orderByJJJ Q
=JJR S
qKK 
=>KK 
qKK 
.KK 
OrderByKK 
(KK 
aKK  
=>KK! #
aKK$ %
.KK% &
ScheduledDateKK& 3
)KK3 4
;KK4 5
varMM 
pagedResultMM 
=MM 
awaitMM #
_repositoryMM$ /
.MM/ 0
GetAllAsyncMM0 ;
(MM; <
filterNN 
.NN 

PageNumberNN !
,NN! "
filterOO 
.OO 
PageSizeOO 
,OO  
	predicatePP 
,PP 
orderByQQ 
)RR 
;RR 
returnTT 
newTT 
PagedResultTT "
<TT" #
AppointmentListDtoTT# 5
>TT5 6
{UU 
ItemsVV 
=VV 
_mapperVV 
.VV  
MapVV  #
<VV# $
IEnumerableVV$ /
<VV/ 0
AppointmentListDtoVV0 B
>VVB C
>VVC D
(VVD E
pagedResultVVE P
.VVP Q
ItemsVVQ V
)VVV W
,VVW X

PageNumberWW 
=WW 
pagedResultWW (
.WW( )

PageNumberWW) 3
,WW3 4
PageSizeXX 
=XX 
pagedResultXX &
.XX& '
PageSizeXX' /
,XX/ 0

TotalCountYY 
=YY 
pagedResultYY (
.YY( )

TotalCountYY) 3
}ZZ 
;ZZ 
}[[ 	
public]] 
async]] 
Task]] 
AddAsync]] "
(]]" # 
CreateAppointmentDto]]# 7
dto]]8 ;
,]]; <
int]]= @
	patientId]]A J
)]]J K
{^^ 	
if__ 
(__ 
dto__ 
.__ 
ScheduledDate__ !
<__" #
DateOnly__$ ,
.__, -
FromDateTime__- 9
(__9 :
DateTime__: B
.__B C
Today__C H
)__H I
)__I J
throw`` 
new`` %
InvalidOperationException`` 3
(``3 4
$str``4 a
)``a b
;``b c
awaitbb 
IsAvailablebb 
(bb 
dtobb !
.bb! "
ScheduledDatebb" /
,bb/ 0
dtobb1 4
.bb4 5
DoctorIdbb5 =
,bb= >
dtobb? B
.bbB C
TimeSlotbbC K
)bbK L
;bbL M
vardd 
appointmentdd 
=dd 
_mapperdd %
.dd% &
Mapdd& )
<dd) *
Appointmentdd* 5
>dd5 6
(dd6 7
dtodd7 :
)dd: ;
;dd; <
appointmentee 
.ee 
	PatientIdee !
=ee" #
	patientIdee$ -
;ee- .
trygg 
{hh 
awaitii 
_repositoryii !
.ii! "
AddAsyncii" *
(ii* +
appointmentii+ 6
)ii6 7
;ii7 8
awaitjj 
_contextjj 
.jj 
SaveChangesAsyncjj /
(jj/ 0
)jj0 1
;jj1 2
awaitll -
!InvalidateDoctorAvailabilityCachell 7
(ll7 8
appointmentmm 
.mm  
DoctorIdmm  (
,mm( )
appointmentnn 
.nn  
ScheduledDatenn  -
)nn- .
;nn. /
ifpp 
(pp 
_loggerpp 
.pp 
	IsEnabledpp %
(pp% &
LogLevelpp& .
.pp. /
Informationpp/ :
)pp: ;
)pp; <
{qq 
_loggerrr 
.rr 
LogInformationrr *
(rr* +
$str	ss Ä
,
ssÄ Å
appointmenttt 
.tt  
AppointmentIdtt  -
,tt- .
	patientIduu 
,uu 
appointmentvv 
.vv  
DoctorIdvv  (
)vv( )
;vv) *
}ww 
varyy 
patientyy 
=yy 
awaityy #
_contextyy$ ,
.yy, -
Patientsyy- 5
.zz 

FirstAsynczz 
(zz  
pzz  !
=>zz" $
pzz% &
.zz& '
	PatientIdzz' 0
==zz1 3
	patientIdzz4 =
)zz= >
;zz> ?
var|| 
appointmentEvent|| $
=||% &
new||' *"
AppointmentBookedEvent||+ A
{}} 
AppointmentId~~ !
=~~" #
appointment~~$ /
.~~/ 0
AppointmentId~~0 =
,~~= >
PatientName 
=  !
patient" )
.) *
FullName* 2
,2 3
DoctorId
ÄÄ 
=
ÄÄ 
appointment
ÄÄ *
.
ÄÄ* +
DoctorId
ÄÄ+ 3
,
ÄÄ3 4
ScheduledDate
ÅÅ !
=
ÅÅ" #
appointment
ÅÅ$ /
.
ÅÅ/ 0
ScheduledDate
ÅÅ0 =
,
ÅÅ= >
TimeSlot
ÇÇ 
=
ÇÇ 
appointment
ÇÇ *
.
ÇÇ* +
TimeSlot
ÇÇ+ 3
}
ÉÉ 
;
ÉÉ 
if
ÖÖ 
(
ÖÖ 
_logger
ÖÖ 
.
ÖÖ 
	IsEnabled
ÖÖ %
(
ÖÖ% &
LogLevel
ÖÖ& .
.
ÖÖ. /
Information
ÖÖ/ :
)
ÖÖ: ;
)
ÖÖ; <
{
ÜÜ 
_logger
áá 
.
áá 
LogInformation
áá *
(
áá* +
$str
àà V
,
ààV W
appointment
ââ 
.
ââ  
AppointmentId
ââ  -
)
ââ- .
;
ââ. /
}
ää 
await
ãã 
_publishEndpoint
ãã &
.
ãã& '
Publish
ãã' .
(
ãã. /
appointmentEvent
ãã/ ?
)
ãã? @
;
ãã@ A
}
åå 
catch
çç 
(
çç 
DbUpdateException
çç $
ex
çç% '
)
çç' (
{
éé 
throw
èè 
new
èè '
InvalidOperationException
èè 3
(
èè3 4
$str
èè4 U
,
èèU V
ex
èèW Y
)
èèY Z
;
èèZ [
}
êê 
}
ëë 	
public
ìì 
async
ìì 
Task
ìì 
UpdateAsync
ìì %
(
ìì% &
int
ìì& )
id
ìì* ,
,
ìì, -"
UpdateAppointmentDto
ìì. B
dto
ììC F
)
ììF G
{
îî 	
var
ïï 
appointment
ïï 
=
ïï 
await
ïï #
_repository
ïï$ /
.
ïï/ 0
GetByIdAsync
ïï0 <
(
ïï< =
id
ïï= ?
)
ïï? @
;
ïï@ A
if
óó 
(
óó 
appointment
óó 
is
óó 
null
óó #
)
óó# $
throw
òò 
new
òò '
InvalidOperationException
òò 3
(
òò3 4(
AppointmentNotFoundMessage
òò4 N
)
òòN O
;
òòO P
_mapper
öö 
.
öö 
Map
öö 
(
öö 
dto
öö 
,
öö 
appointment
öö (
)
öö( )
;
öö) *
await
õõ 
_repository
õõ 
.
õõ 
UpdateAsync
õõ )
(
õõ) *
appointment
õõ* 5
)
õõ5 6
;
õõ6 7
await
úú 
_context
úú 
.
úú 
SaveChangesAsync
úú +
(
úú+ ,
)
úú, -
;
úú- .
}
ùù 	
public
üü 
async
üü 
Task
üü 
UpdateStatusAsync
üü +
(
üü+ ,
int
üü, /
id
üü0 2
,
üü2 3"
UpdateAppointmentDto
üü4 H
dto
üüI L
)
üüL M
{
†† 	
var
°° 
appointment
°° 
=
°° 
await
°° #
_repository
°°$ /
.
°°/ 0
GetByIdAsync
°°0 <
(
°°< =
id
°°= ?
)
°°? @
;
°°@ A
if
££ 
(
££ 
appointment
££ 
is
££ 
null
££ #
)
££# $
throw
§§ 
new
§§ '
InvalidOperationException
§§ 3
(
§§3 4(
AppointmentNotFoundMessage
§§4 N
)
§§N O
;
§§O P
var
ßß 
validStatuses
ßß 
=
ßß 
new
ßß  #
[
ßß# $
]
ßß$ %
{
®® 
PendingStatus
©© 
,
©© 
ConfirmedStatus
™™ 
,
™™  
CancelledStatus
´´ 
,
´´  
CompletedStatus
¨¨ 
}
≠≠ 
;
≠≠ 
if
∞∞ 
(
∞∞ 
!
∞∞ 
validStatuses
∞∞ 
.
∞∞ 
Contains
∞∞ '
(
∞∞' (
dto
∞∞( +
.
∞∞+ ,
Status
∞∞, 2
,
∞∞2 3
StringComparer
∞∞4 B
.
∞∞B C
OrdinalIgnoreCase
∞∞C T
)
∞∞T U
)
∞∞U V
{
±± 
throw
≤≤ 
new
≤≤ '
InvalidOperationException
≤≤ 3
(
≤≤3 4
$str
≤≤4 J
)
≤≤J K
;
≤≤K L
}
≥≥ 
if
∂∂ 
(
∂∂ 
dto
∂∂ 
.
∂∂ 
Status
∂∂ 
==
∂∂ 
CancelledStatus
∂∂ -
&&
∂∂. 0
string
∂∂1 7
.
∂∂7 8 
IsNullOrWhiteSpace
∂∂8 J
(
∂∂J K
dto
∂∂K N
.
∂∂N O 
CancellationReason
∂∂O a
)
∂∂a b
)
∂∂b c
{
∑∑ 
throw
∏∏ 
new
∏∏ '
InvalidOperationException
∏∏ 3
(
∏∏3 4
$str
∏∏4 n
)
∏∏n o
;
∏∏o p
}
ππ 
appointment
ºº 
.
ºº 
Status
ºº 
=
ºº  
dto
ºº! $
.
ºº$ %
Status
ºº% +
;
ºº+ ,
appointment
ΩΩ 
.
ΩΩ  
CancellationReason
ΩΩ *
=
ΩΩ+ ,
dto
ææ 
.
ææ 
Status
ææ 
==
ææ 
CancelledStatus
ææ .
?
øø 
dto
øø 
.
øø  
CancellationReason
øø -
:
¿¿ 
null
¿¿ 
;
¿¿ 
await
√√ 
_repository
√√ 
.
√√ 
UpdateAsync
√√ )
(
√√) *
appointment
√√* 5
)
√√5 6
;
√√6 7
await
ƒƒ 
_context
ƒƒ 
.
ƒƒ 
SaveChangesAsync
ƒƒ +
(
ƒƒ+ ,
)
ƒƒ, -
;
ƒƒ- .
await
∆∆ /
!InvalidateDoctorAvailabilityCache
∆∆ 3
(
∆∆3 4
appointment
«« 
.
««  
DoctorId
««  (
,
««( )
appointment
»» 
.
»»  
ScheduledDate
»»  -
)
»»- .
;
»». /
}
…… 	
public
ÃÃ 
async
ÃÃ 
Task
ÃÃ 
DeleteAsync
ÃÃ %
(
ÃÃ% &
int
ÃÃ& )
id
ÃÃ* ,
)
ÃÃ, -
{
ÕÕ 	
var
ŒŒ 
appointment
ŒŒ 
=
ŒŒ 
await
ŒŒ #
_repository
ŒŒ$ /
.
ŒŒ/ 0
GetByIdAsync
ŒŒ0 <
(
ŒŒ< =
id
ŒŒ= ?
)
ŒŒ? @
;
ŒŒ@ A
if
–– 
(
–– 
appointment
–– 
is
–– 
null
–– #
)
––# $
throw
—— 
new
—— '
InvalidOperationException
—— 3
(
——3 4(
AppointmentNotFoundMessage
——4 N
)
——N O
;
——O P
try
““ 
{
”” 
await
‘‘ 
_repository
‘‘ !
.
‘‘! "
DeleteAsync
‘‘" -
(
‘‘- .
id
‘‘. 0
)
‘‘0 1
;
‘‘1 2
await
’’ 
_context
’’ 
.
’’ 
SaveChangesAsync
’’ /
(
’’/ 0
)
’’0 1
;
’’1 2
}
÷÷ 
catch
◊◊ 
(
◊◊ 
DbUpdateException
◊◊ $
ex
◊◊% '
)
◊◊' (
{
ÿÿ 
throw
ŸŸ 
new
ŸŸ '
InvalidOperationException
ŸŸ 3
(
ŸŸ3 4
$strŸŸ4 Ñ
,ŸŸÑ Ö
exŸŸÜ à
)ŸŸà â
;ŸŸâ ä
}
⁄⁄ 
}
€€ 	
public
›› 
async
›› 
Task
›› 
<
›› 
List
›› 
<
›› 
string
›› %
>
››% &
>
››& ' 
AvailableTimeSlots
››( :
(
››: ;
DateOnly
››; C
date
››D H
,
››H I
int
››J M
doctorId
››N V
)
››V W
{
ﬁﬁ 	
if
ﬂﬂ 
(
ﬂﬂ 
date
ﬂﬂ 
<
ﬂﬂ 
DateOnly
ﬂﬂ 
.
ﬂﬂ  
FromDateTime
ﬂﬂ  ,
(
ﬂﬂ, -
DateTime
ﬂﬂ- 5
.
ﬂﬂ5 6
Today
ﬂﬂ6 ;
)
ﬂﬂ; <
)
ﬂﬂ< =
throw
‡‡ 
new
‡‡ '
InvalidOperationException
‡‡ 3
(
‡‡3 4
$str
‡‡4 `
)
‡‡` a
;
‡‡a b
var
‚‚ 
allSlots
‚‚ 
=
‚‚ 
await
‚‚  
_doctorService
‚‚! /
.
‚‚/ 0
GetSlots
‚‚0 8
(
‚‚8 9
doctorId
‚‚9 A
)
‚‚A B
;
‚‚B C
var
„„ 
bookedSlots
„„ 
=
„„ 
await
„„ #
_repository
„„$ /
.
„„/ 0
BookedTimeSlots
„„0 ?
(
„„? @
date
„„@ D
,
„„D E
doctorId
„„F N
)
„„N O
;
„„O P
var
ÂÂ 
	freeSlots
ÂÂ 
=
ÂÂ 
allSlots
ÂÂ $
.
ÊÊ 
Where
ÊÊ 
(
ÊÊ 
slot
ÊÊ 
=>
ÊÊ 
!
ÁÁ	 

bookedSlots
ÁÁ
 
.
ÁÁ 
Any
ÁÁ 
(
ÁÁ 
b
ÁÁ 
=>
ÁÁ 
b
ËË 
.
ËË 
Trim
ËË 
(
ËË 
)
ËË 
.
ËË 

StartsWith
ËË  
(
ËË  !
slot
ÈÈ 
.
ÈÈ 
Trim
ÈÈ 
(
ÈÈ 
)
ÈÈ 
.
ÈÈ 
	Substring
ÈÈ &
(
ÈÈ& '
$num
ÈÈ' (
,
ÈÈ( )
$num
ÈÈ* +
)
ÈÈ+ ,
,
ÈÈ, -
StringComparison
ÍÍ !
.
ÍÍ! "
OrdinalIgnoreCase
ÍÍ" 3
)
ÍÍ3 4
)
ÎÎ	 

)
ÏÏ 
.
ÌÌ 
ToList
ÌÌ 
(
ÌÌ 
)
ÌÌ 
;
ÌÌ 
return
 
	freeSlots
 
;
 
}
ÒÒ 	
public
ÛÛ 
async
ÛÛ 
Task
ÛÛ 
<
ÛÛ 
bool
ÛÛ 
>
ÛÛ 
IsAvailable
ÛÛ  +
(
ÛÛ+ ,
DateOnly
ÛÛ, 4
date
ÛÛ5 9
,
ÛÛ9 :
int
ÛÛ; >
doctorId
ÛÛ? G
,
ÛÛG H
string
ÛÛI O
timeSlot
ÛÛP X
)
ÛÛX Y
{
ÙÙ 	
var
ıı 
bookedSlots
ıı 
=
ıı 
await
ıı #
_repository
ıı$ /
.
ıı/ 0
BookedTimeSlots
ıı0 ?
(
ıı? @
date
ıı@ D
,
ııD E
doctorId
ııF N
)
ııN O
;
ııO P
var
˜˜ 
exists
˜˜ 
=
˜˜ 
bookedSlots
˜˜ $
.
˜˜$ %
Any
˜˜% (
(
˜˜( )
b
˜˜) *
=>
˜˜+ -
string
¯¯ 
.
¯¯ 
Equals
¯¯ 
(
¯¯ 
b
˘˘ 
.
˘˘ 
Trim
˘˘ 
(
˘˘ 
)
˘˘ 
,
˘˘ 
timeSlot
˙˙ 
.
˙˙ 
Trim
˙˙ "
(
˙˙" #
)
˙˙# $
,
˙˙$ %
StringComparison
˚˚ %
.
˚˚% &
OrdinalIgnoreCase
˚˚& 7
)
˚˚7 8
)
˚˚8 9
;
˚˚9 :
if
˝˝ 
(
˝˝ 
exists
˝˝ 
)
˝˝ 
throw
˛˛ 
new
˛˛ '
InvalidOperationException
˛˛ 3
(
˛˛3 4
$str
˛˛4 W
)
˛˛W X
;
˛˛X Y
return
ÄÄ 
true
ÄÄ 
;
ÄÄ 
}
ÅÅ 	
public
ÉÉ 
async
ÉÉ 
Task
ÉÉ 
<
ÉÉ 
List
ÉÉ 
<
ÉÉ  
AppointmentListDto
ÉÉ 1
>
ÉÉ1 2
>
ÉÉ2 3
GetDoctorSchedule
ÉÉ4 E
(
ÉÉE F
DateOnly
ÉÉF N
date
ÉÉO S
,
ÉÉS T
int
ÉÉU X
id
ÉÉY [
)
ÉÉ[ \
{
ÑÑ 	
var
ÖÖ 
schedule
ÖÖ 
=
ÖÖ 
await
ÖÖ  
_repository
ÖÖ! ,
.
ÖÖ, -
GetDoctorSchedule
ÖÖ- >
(
ÖÖ> ?
date
ÖÖ? C
,
ÖÖC D
id
ÖÖE G
)
ÖÖG H
;
ÖÖH I
return
ÜÜ 
schedule
ÜÜ 
.
ÜÜ 
Count
ÜÜ !
==
ÜÜ" $
$num
ÜÜ% &
?
ÜÜ' (
new
ÜÜ) ,
List
ÜÜ- 1
<
ÜÜ1 2 
AppointmentListDto
ÜÜ2 D
>
ÜÜD E
(
ÜÜE F
)
ÜÜF G
:
ÜÜH I
schedule
ÜÜJ R
;
ÜÜR S
}
áá 	
public
ââ 
async
ââ 
Task
ââ 
<
ââ 
List
ââ 
<
ââ  
AppointmentListDto
ââ 1
>
ââ1 2
>
ââ2 3 
GetPatientSchedule
ââ4 F
(
ââF G
DateOnly
ââG O
date
ââP T
,
ââT U
int
ââV Y
id
ââZ \
)
ââ\ ]
{
ää 	
var
ãã 
schedule
ãã 
=
ãã 
await
ãã  
_repository
ãã! ,
.
ãã, - 
GetPatientSchedule
ãã- ?
(
ãã? @
date
ãã@ D
,
ããD E
id
ããF H
)
ããH I
;
ããI J
return
åå 
schedule
åå 
.
åå 
Count
åå !
==
åå" $
$num
åå% &
?
åå' (
new
åå) ,
List
åå- 1
<
åå1 2 
AppointmentListDto
åå2 D
>
ååD E
(
ååE F
)
ååF G
:
ååH I
schedule
ååJ R
;
ååR S
}
çç 	
public
èè 
async
èè 
Task
èè 
<
èè 
List
èè 
<
èè  
AppointmentListDto
èè 1
>
èè1 2
>
èè2 3%
GetAppointmentByPatient
èè4 K
(
èèK L
int
èèL O
id
èèP R
)
èèR S
{
êê 	
var
ëë 
appointments
ëë 
=
ëë 
await
ëë $
_repository
ëë% 0
.
ëë0 1%
GetAppointmentByPatient
ëë1 H
(
ëëH I
id
ëëI K
)
ëëK L
;
ëëL M
return
ìì 
appointments
ìì 
.
îî 
Where
îî 
(
îî 
a
îî 
=>
îî 
a
ïï 
.
ïï 
Status
ïï 
==
ïï 
PendingStatus
ïï )
||
ïï* ,
a
ññ 
.
ññ 
Status
ññ 
==
ññ 
ConfirmedStatus
ññ +
)
ññ+ ,
.
óó 
OrderBy
óó 
(
óó 
a
óó 
=>
óó 
a
óó 
.
óó  
ScheduledDate
óó  -
)
óó- .
.
òò 
ToList
òò 
(
òò 
)
òò 
;
òò 
}
ôô 	
public
öö 
async
öö 
Task
öö 
<
öö 
List
öö 
<
öö  
AppointmentListDto
öö 1
>
öö1 2
>
öö2 3$
GetAppointmentByDoctor
öö4 J
(
ööJ K
int
ööK N
id
ööO Q
)
ööQ R
{
õõ 	
var
ùù 
appointments
ùù 
=
ùù 
await
ùù $
_repository
ùù% 0
.
ùù0 1$
GetAppointmentByDoctor
ùù1 G
(
ùùG H
id
ùùH J
)
ùùJ K
;
ùùK L
var
†† 
today
†† 
=
†† 
DateOnly
††  
.
††  !
FromDateTime
††! -
(
††- .
DateTime
††. 6
.
††6 7
Today
††7 <
)
††< =
;
††= >
var
££ 
result
££ 
=
££ 
appointments
££ %
.
§§ 
Where
§§ 
(
§§ 
a
§§ 
=>
§§ 
a
•• 
.
•• 
ScheduledDate
•• #
>=
••$ &
today
••' ,
&&
••- /
(
¶¶ 
a
ßß 
.
ßß 
Status
ßß  
.
ßß  !
Equals
ßß! '
(
ßß' (
PendingStatus
ßß( 5
,
ßß5 6
StringComparison
ßß7 G
.
ßßG H
OrdinalIgnoreCase
ßßH Y
)
ßßY Z
||
ßß[ ]
a
®® 
.
®® 
Status
®®  
.
®®  !
Equals
®®! '
(
®®' (
ConfirmedStatus
®®( 7
,
®®7 8
StringComparison
®®9 I
.
®®I J
OrdinalIgnoreCase
®®J [
)
®®[ \
)
©© 
)
™™ 
.
´´ 
OrderBy
´´ 
(
´´ 
a
´´ 
=>
´´ 
a
´´ 
.
´´  
ScheduledDate
´´  -
)
´´- .
.
¨¨ 
ThenBy
¨¨ 
(
¨¨ 
a
¨¨ 
=>
¨¨ 
a
¨¨ 
.
¨¨ 
TimeSlot
¨¨ '
)
¨¨' (
.
≠≠ 
ToList
≠≠ 
(
≠≠ 
)
≠≠ 
;
≠≠ 
return
ØØ 
result
ØØ 
;
ØØ 
}
∞∞ 	
public
≤≤ 
async
≤≤ 
Task
≤≤ ,
CancelAppointmentsByDoctorDate
≤≤ 8
(
≤≤8 9
int
≤≤9 <
doctorId
≤≤= E
,
≤≤E F
DateOnly
≤≤G O
date
≤≤P T
)
≤≤T U
{
≥≥ 	
await
¥¥ 
_repository
¥¥ 
.
¥¥ ,
CancelAppointmentsByDoctorDate
¥¥ <
(
¥¥< =
doctorId
¥¥= E
,
¥¥E F
date
¥¥G K
)
¥¥K L
;
¥¥L M
await
µµ 
_context
µµ 
.
µµ 
SaveChangesAsync
µµ +
(
µµ+ ,
)
µµ, -
;
µµ- .
}
∂∂ 	
public
∏∏ 
async
∏∏ 
Task
∏∏ 
<
∏∏ 
List
∏∏ 
<
∏∏ "
AppointmentReportDto
∏∏ 3
>
∏∏3 4
>
∏∏4 5
GetDailyReport
∏∏6 D
(
∏∏D E
)
∏∏E F
{
∫∫ 	
var
ºº 
report
ºº 
=
ºº 
await
ºº 
_repository
ºº *
.
ºº* +
GetDailyReport
ºº+ 9
(
ºº9 :
)
ºº: ;
;
ºº; <
return
ææ 
report
ææ 
.
ææ 
Count
ææ 
==
ææ  "
$num
ææ# $
?
ææ% &
new
ææ' *
List
ææ+ /
<
ææ/ 0"
AppointmentReportDto
ææ0 D
>
ææD E
(
ææE F
)
ææF G
:
ææH I
report
ææJ P
;
ææP Q
}
¿¿ 	
public
¬¬ 
async
¬¬ 
Task
¬¬ 
<
¬¬ 
List
¬¬ 
<
¬¬ "
AppointmentReportDto
¬¬ 3
>
¬¬3 4
>
¬¬4 5"
GetReportByDateRange
¬¬6 J
(
¬¬J K
DateOnly
√√ 
	startDate
√√ 
,
√√ 
DateOnly
ƒƒ 
endDate
ƒƒ 
)
ƒƒ 
{
≈≈ 	
var
∆∆ 
report
∆∆ 
=
∆∆ 
await
∆∆ 
_context
∆∆ '
.
∆∆' (
Appointments
∆∆( 4
.
«« 
Include
«« 
(
«« 
a
«« 
=>
«« 
a
«« 
.
««  
Doctor
««  &
)
««& '
.
»» 
Where
»» 
(
»» 
a
»» 
=>
»» 
a
»» 
.
»» 
ScheduledDate
»» +
>=
»», .
	startDate
»»/ 8
&&
»»9 ;
a
…… 
.
…… 
ScheduledDate
…… +
<=
……, .
endDate
……/ 6
)
……6 7
.
   
GroupBy
   
(
   
a
   
=>
   
a
   
.
    
ScheduledDate
    -
)
  - .
.
ÀÀ 
Select
ÀÀ 
(
ÀÀ 
g
ÀÀ 
=>
ÀÀ 
new
ÀÀ  "
AppointmentReportDto
ÀÀ! 5
{
ÃÃ 
Date
ÕÕ 
=
ÕÕ 
g
ÕÕ 
.
ÕÕ 
Key
ÕÕ  
,
ÕÕ  !
PendingCount
œœ  
=
œœ! "
g
œœ# $
.
œœ$ %
Count
œœ% *
(
œœ* +
a
œœ+ ,
=>
œœ- /
a
œœ0 1
.
œœ1 2
Status
œœ2 8
==
œœ9 ;
PendingStatus
œœ< I
)
œœI J
,
œœJ K
ConfirmedCount
–– "
=
––# $
g
––% &
.
––& '
Count
––' ,
(
––, -
a
––- .
=>
––/ 1
a
––2 3
.
––3 4
Status
––4 :
==
––; =
ConfirmedStatus
––> M
)
––M N
,
––N O
CancelledCount
—— "
=
——# $
g
——% &
.
——& '
Count
——' ,
(
——, -
a
——- .
=>
——/ 1
a
——2 3
.
——3 4
Status
——4 :
==
——; =
CancelledStatus
——> M
)
——M N
,
——N O
CompletedCount
““ "
=
““# $
g
““% &
.
““& '
Count
““' ,
(
““, -
a
““- .
=>
““/ 1
a
““2 3
.
““3 4
Status
““4 :
==
““; =
CompletedStatus
““> M
)
““M N
,
““N O
Revenue
‘‘ 
=
‘‘ 
g
‘‘ 
.
’’ 
Where
’’ 
(
’’ 
a
’’  
=>
’’! #
a
’’$ %
.
’’% &
Status
’’& ,
==
’’- /
CompletedStatus
’’0 ?
)
’’? @
.
÷÷ 
Sum
÷÷ 
(
÷÷ 
a
÷÷ 
=>
÷÷ !
(
÷÷" #
decimal
÷÷# *
?
÷÷* +
)
÷÷+ ,
a
÷÷, -
.
÷÷- .
Doctor
÷÷. 4
.
÷÷4 5
ConsultationFee
÷÷5 D
)
÷÷D E
??
÷÷F H
$num
÷÷I J
}
◊◊ 
)
◊◊ 
.
ÿÿ 
OrderBy
ÿÿ 
(
ÿÿ 
r
ÿÿ 
=>
ÿÿ 
r
ÿÿ 
.
ÿÿ  
Date
ÿÿ  $
)
ÿÿ$ %
.
ŸŸ 
ToListAsync
ŸŸ 
(
ŸŸ 
)
ŸŸ 
;
ŸŸ 
return
€€ 
report
€€ 
;
€€ 
}
‹‹ 	
public
ﬁﬁ 
async
ﬁﬁ 
Task
ﬁﬁ 
<
ﬁﬁ #
AppointmentSummaryDto
ﬁﬁ /
>
ﬁﬁ/ 0
GetSummaryAsync
ﬁﬁ1 @
(
ﬁﬁ@ A
)
ﬁﬁA B
{
ﬂﬂ 	
var
‡‡ 
fromDate
‡‡ 
=
‡‡ 
DateOnly
‡‡ #
.
‡‡# $
FromDateTime
‡‡$ 0
(
‡‡0 1
DateTime
‡‡1 9
.
‡‡9 :
Today
‡‡: ?
.
‡‡? @
AddDays
‡‡@ G
(
‡‡G H
-
‡‡H I
$num
‡‡I K
)
‡‡K L
)
‡‡L M
;
‡‡M N
var
·· 
toDate
·· 
=
·· 
DateOnly
·· !
.
··! "
FromDateTime
··" .
(
··. /
DateTime
··/ 7
.
··7 8
Today
··8 =
)
··= >
;
··> ?
var
„„ 
result
„„ 
=
„„ 
await
„„ 
_context
„„ '
.
„„' (
Appointments
„„( 4
.
‰‰ 
Include
‰‰ 
(
‰‰ 
a
‰‰ 
=>
‰‰ 
a
‰‰ 
.
‰‰  
Doctor
‰‰  &
)
‰‰& '
.
ÂÂ 
Where
ÂÂ 
(
ÂÂ 
a
ÂÂ 
=>
ÂÂ 
a
ÂÂ 
.
ÂÂ 
ScheduledDate
ÂÂ +
>=
ÂÂ, .
fromDate
ÂÂ/ 7
&&
ÂÂ8 :
a
ÂÂ; <
.
ÂÂ< =
ScheduledDate
ÂÂ= J
<=
ÂÂK M
toDate
ÂÂN T
)
ÂÂT U
.
ÊÊ 
GroupBy
ÊÊ 
(
ÊÊ 
a
ÊÊ 
=>
ÊÊ 
$num
ÊÊ 
)
ÊÊ  
.
ÁÁ 
Select
ÁÁ 
(
ÁÁ 
g
ÁÁ 
=>
ÁÁ 
new
ÁÁ  #
AppointmentSummaryDto
ÁÁ! 6
{
ËË 
PendingCount
ÈÈ  
=
ÈÈ! "
g
ÈÈ# $
.
ÈÈ$ %
Count
ÈÈ% *
(
ÈÈ* +
a
ÈÈ+ ,
=>
ÈÈ- /
a
ÈÈ0 1
.
ÈÈ1 2
Status
ÈÈ2 8
==
ÈÈ9 ;
PendingStatus
ÈÈ< I
)
ÈÈI J
,
ÈÈJ K
ConfirmedCount
ÍÍ "
=
ÍÍ# $
g
ÍÍ% &
.
ÍÍ& '
Count
ÍÍ' ,
(
ÍÍ, -
a
ÍÍ- .
=>
ÍÍ/ 1
a
ÍÍ2 3
.
ÍÍ3 4
Status
ÍÍ4 :
==
ÍÍ; =
ConfirmedStatus
ÍÍ> M
)
ÍÍM N
,
ÍÍN O
CancelledCount
ÎÎ "
=
ÎÎ# $
g
ÎÎ% &
.
ÎÎ& '
Count
ÎÎ' ,
(
ÎÎ, -
a
ÎÎ- .
=>
ÎÎ/ 1
a
ÎÎ2 3
.
ÎÎ3 4
Status
ÎÎ4 :
==
ÎÎ; =
CancelledStatus
ÎÎ> M
)
ÎÎM N
,
ÎÎN O
CompletedCount
ÏÏ "
=
ÏÏ# $
g
ÏÏ% &
.
ÏÏ& '
Count
ÏÏ' ,
(
ÏÏ, -
a
ÏÏ- .
=>
ÏÏ/ 1
a
ÏÏ2 3
.
ÏÏ3 4
Status
ÏÏ4 :
==
ÏÏ; =
CompletedStatus
ÏÏ> M
)
ÏÏM N
,
ÏÏN O
TotalRevenue
ÓÓ  
=
ÓÓ! "
g
ÓÓ# $
.
ÔÔ 
Where
ÔÔ 
(
ÔÔ 
a
ÔÔ  
=>
ÔÔ! #
a
ÔÔ$ %
.
ÔÔ% &
Status
ÔÔ& ,
==
ÔÔ- /
CompletedStatus
ÔÔ0 ?
)
ÔÔ? @
.
 
Sum
 
(
 
a
 
=>
 !
a
" #
.
# $
Doctor
$ *
.
* +
ConsultationFee
+ :
)
: ;
}
ÒÒ 
)
ÒÒ 
.
ÚÚ !
FirstOrDefaultAsync
ÚÚ $
(
ÚÚ$ %
)
ÚÚ% &
;
ÚÚ& '
return
ÙÙ 
result
ÙÙ 
??
ÙÙ 
new
ÙÙ  #
AppointmentSummaryDto
ÙÙ! 6
(
ÙÙ6 7
)
ÙÙ7 8
;
ÙÙ8 9
}
ıı 	
private
˜˜ 
async
˜˜ 
Task
˜˜ /
!InvalidateDoctorAvailabilityCache
˜˜ <
(
˜˜< =
int
¯¯ 
doctorId
¯¯ 
,
¯¯ 
DateOnly
˘˘ 
date
˘˘ 
)
˘˘ 
{
˙˙ 	
var
˝˝ 
doctor
˝˝ 
=
˝˝ 
await
˝˝ 
_context
˝˝ '
.
˝˝' (
Doctors
˝˝( /
.
˛˛ !
FirstOrDefaultAsync
˛˛ $
(
˛˛$ %
d
˛˛% &
=>
˛˛' )
d
˛˛* +
.
˛˛+ ,
DoctorId
˛˛, 4
==
˛˛5 7
doctorId
˛˛8 @
)
˛˛@ A
;
˛˛A B
if
ÄÄ 
(
ÄÄ 
doctor
ÄÄ 
is
ÄÄ 
null
ÄÄ 
)
ÄÄ 
return
ÅÅ 
;
ÅÅ 
var
ÉÉ 
cacheKey
ÉÉ 
=
ÉÉ 
$"
ÑÑ 
$str
ÑÑ 
{
ÑÑ 
doctor
ÑÑ !
.
ÑÑ! "
Specialisation
ÑÑ" 0
}
ÑÑ0 1
$str
ÑÑ1 ?
{
ÑÑ? @
date
ÑÑ@ D
}
ÑÑD E
"
ÑÑE F
;
ÑÑF G
if
áá 
(
áá 
_logger
áá 
.
áá 
	IsEnabled
áá !
(
áá! "
LogLevel
áá" *
.
áá* +
Information
áá+ 6
)
áá6 7
)
áá7 8
{
àà 
_logger
ââ 
.
ââ 
LogInformation
ââ &
(
ââ& '
$str
ää .
,
ää. /
cacheKey
ãã 
)
ãã 
;
ãã 
}
åå 
await
èè 
_cache
èè 
.
èè 
RemoveAsync
èè $
(
èè$ %
cacheKey
èè% -
)
èè- .
;
èè. /
}
êê 	
}
ëë 
}íí ¬
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
class		 "
HealthRecordRepository		 '
:		( )

Repository		* 4
<		4 5
HealthRecord		5 A
>		A B
,		B C#
IHealthRecordRepository		D [
{

 
public "
HealthRecordRepository %
(% &
HealthCareDbContext& 9
context: A
)A B
:C D
baseE I
(I J
contextJ Q
)Q R
{S T
}U V
public 
async 
Task 
< 
List 
< 
HealthRecordListDto 2
>2 3
>3 4$
GetHealthRecordByPatient5 M
(M N
intN Q
idR T
)T U
=>V X
await 
_dbSet 
. 
Where 
( 
hr 
=> 
hr 
.  
	PatientId  )
==* ,
id- /
)/ 0
. 
Select 
( 
hr 
=> 
new !
HealthRecordListDto" 5
{ 
RecordId 
= 
hr !
.! "
RecordId" *
,* +
PatientName 
=  !
hr" $
.$ %
Patient% ,
., -
FullName- 5
,5 6

DoctorName 
=  
hr! #
.# $
Doctor$ *
.* +
FullName+ 3
,3 4
	VisitDate 
= 
hr  "
." #
	VisitDate# ,
,, -
	Diagnosis 
= 
hr  "
." #
	Diagnosis# ,
,, -
Prescription  
=! "
hr# %
.% &
Prescription& 2
,2 3
Notes 
= 
hr 
. 
Notes $
} 
) 
. 
ToListAsync 
( 
) 
; 
public 
async 
Task 
< 
List 
< 
HealthRecordListDto 2
>2 3
>3 4(
GetHealthRecordByAppointment5 Q
(Q R
intR U
idV X
)X Y
=>Z \
await 
_dbSet 
. 
Where 
( 
hr 
=> 
hr 
.  
AppointmentId  -
==. 0
id1 3
)3 4
. 
Select 
( 
hr 
=> 
new !
HealthRecordListDto" 5
{   
RecordId!! 
=!! 
hr!! !
.!!! "
RecordId!!" *
,!!* +
PatientName"" 
=""  !
hr""" $
.""$ %
Patient""% ,
."", -
FullName""- 5
,""5 6

DoctorName## 
=##  
hr##! #
.### $
Doctor##$ *
.##* +
FullName##+ 3
,##3 4
	VisitDate$$ 
=$$ 
hr$$  "
.$$" #
	VisitDate$$# ,
,$$, -
	Diagnosis%% 
=%% 
hr%%  "
.%%" #
	Diagnosis%%# ,
,%%, -
Prescription&&  
=&&! "
hr&&# %
.&&% &
Prescription&&& 2
,&&2 3
Notes'' 
='' 
hr'' 
.'' 
Notes'' $
}(( 
)(( 
.)) 
ToListAsync)) 
()) 
))) 
;)) 
}** 
}++ ¶9
sC:\Users\310055\source\repos\UST-Live-01\HealthCare\HealthCare.Api\Repositories\Implementations\DoctorRepository.cs
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
class		 
DoctorRepository		 !
:		" #

Repository		$ .
<		. /
Doctor		/ 5
>		5 6
,		6 7
IDoctorRepository		8 I
{

 
public 
DoctorRepository 
(  
HealthCareDbContext  3
context4 ;
); <
:= >
base? C
(C D
contextD K
)K L
{M N
}O P
public 
async 
Task 
< 
Doctor  
?  !
>! "
GetByUserIdAsync# 3
(3 4
string4 :
userId; A
)A B
{ 	
return 
await 
_context !
.! "
Doctors" )
. 
FirstOrDefaultAsync $
($ %
p% &
=>' )
p* +
.+ ,
UserId, 2
==3 5
userId6 <
)< =
;= >
} 	
public 
async 
Task 
< 
List 
< 
string %
>% &
>& '
GetSlots( 0
(0 1
int1 4
doctorId5 =
)= >
=>? A
await 
_context 
. 
AvailableSlots )
. 
Where 
( 
s 
=> 
s 
. 
DoctorId &
==' )
doctorId* 2
)2 3
. 
Select 
( 
s 
=> 
s 
. 
TimeSlot '
)' (
. 
ToListAsync 
( 
) 
; 
public 
async 
Task 
CreateSlots %
(% &
int& )
doctorId* 2
,2 3
List4 8
<8 9
string9 ?
>? @
	timeslotsA J
)J K
{ 	
var 
slots 
= 
	timeslots !
.! "
Select" (
(( )
t) *
=>+ -
new. 1
AvailableSlots2 @
{ 
DoctorId 
= 
doctorId #
,# $
TimeSlot 
= 
t 
} 
) 
; 
await!! 
_context!! 
.!! 
AvailableSlots!! )
.!!) *
AddRangeAsync!!* 7
(!!7 8
slots!!8 =
)!!= >
;!!> ?
}"" 	
public$$ 
async$$ 
Task$$ 
<$$ 
List$$ 
<$$ 
DoctorLeaves$$ +
>$$+ ,
>$$, -
GetLeavesByDoctorId$$. A
($$A B
int$$B E
doctorId$$F N
)$$N O
=>$$P R
await%% 
_context%% 
.%% 
DoctorLeaves%% '
.&& 
Where&& 
(&& 
l&& 
=>&& 
l&& 
.&& 
DoctorId&& &
==&&' )
doctorId&&* 2
)&&2 3
.'' 
ToListAsync'' 
('' 
)'' 
;'' 
public)) 
async)) 
Task)) 
CreateLeaves)) &
())& '
int))' *
doctorId))+ 3
,))3 4
List))5 9
<))9 :
CreateLeaveDto)): H
>))H I
leaves))J P
)))P Q
{** 	
var++ 
entities++ 
=++ 
leaves++ !
.++! "
Select++" (
(++( )
l++) *
=>+++ -
new++. 1
DoctorLeaves++2 >
{,, 
DoctorId-- 
=-- 
doctorId-- #
,--# $
	LeaveDate.. 
=.. 
l.. 
... 
	LeaveDate.. '
,..' (
Reason// 
=// 
l// 
.// 
Reason// !
}00 
)00 
;00 
await22 
_context22 
.22 
DoctorLeaves22 '
.22' (
AddRangeAsync22( 5
(225 6
entities226 >
)22> ?
;22? @
}33 	
public55 
async55 
Task55 
<55 
List55 
<55 
DoctorListDto55 ,
>55, -
>55- .
AvailableDoctors55/ ?
(55? @
string55@ F
specialisation55G U
,55U V
DateOnly55W _
date55` d
)55d e
{66 	
return77 
await77 
_dbSet77 
.88 
Where88 
(88 
d88 
=>88 
d88 
.88 
Specialisation88 ,
==88- /
specialisation880 >
&&88? A
d88B C
.88C D
IsActive88D L
)88L M
.99 
Where99 
(99 
d99 
=>99 
!99 
d99 
.99 
Leaves99 %
.99% &
Any99& )
(99) *
l99* +
=>99, .
l99/ 0
.990 1
	LeaveDate991 :
==99; =
date99> B
)99B C
)99C D
.:: 
Where:: 
(:: 
d:: 
=>:: 
d:: 
.:: 
AvailableSlots:: ,
.;; 
Select;; 
(;; 
s;; 
=>;;  
s;;! "
.;;" #
TimeSlot;;# +
);;+ ,
.<< 
Except<< 
(<< 
d<< 
.<< 
Appointments<< *
.== 
Where== 
(== 
a==  
=>==! #
a==$ %
.==% &
ScheduledDate==& 3
====4 6
date==7 ;
&&==< >
a==? @
.==@ A
Status==A G
!===H J
$str==K V
)==V W
.>> 
Select>> 
(>>  
a>>  !
=>>>" $
a>>% &
.>>& '
TimeSlot>>' /
)>>/ 0
)>>0 1
.?? 
Any?? 
(?? 
)?? 
)?? 
.@@ 
Select@@ 
(@@ 
d@@ 
=>@@ 
new@@  
DoctorListDto@@! .
{AA 
DoctorIdBB 
=BB 
dBB  
.BB  !
DoctorIdBB! )
,BB) *
FullNameCC 
=CC 
dCC  
.CC  !
FullNameCC! )
,CC) *
SpecialisationDD "
=DD# $
dDD% &
.DD& '
SpecialisationDD' 5
,DD5 6
ConsultationFeeEE #
=EE$ %
dEE& '
.EE' (
ConsultationFeeEE( 7
,EE7 8
IsActiveFF 
=FF 
dFF  
.FF  !
IsActiveFF! )
}GG 
)GG 
.HH 
ToListAsyncHH 
(HH 
)HH 
;HH 
}II 	
}JJ 
}KK æh
xC:\Users\310055\source\repos\UST-Live-01\HealthCare\HealthCare.Api\Repositories\Implementations\AppointmentRepository.cs
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
class		 !
AppointmentRepository		 &
:		' (

Repository		) 3
<		3 4
Appointment		4 ?
>		? @
,		@ A"
IAppointmentRepository		B X
{

 
private 
const 
string 
	Cancelled &
=' (
$str) 4
;4 5
public !
AppointmentRepository $
($ %
HealthCareDbContext% 8
context9 @
)@ A
:B C
baseD H
(H I
contextI P
)P Q
{R S
}T U
public 
async 
Task 
< 
List 
< 
string %
>% &
>& '
BookedTimeSlots( 7
(7 8
DateOnly8 @
dateA E
,E F
intG J
doctorIdK S
)S T
=>U W
await 
_dbSet 
. 
Where 
( 
a 
=> 
a 
. 
ScheduledDate +
==, .
date/ 3
&& 
a 
. 
DoctorId &
==' )
doctorId* 2
&& 
a 
. 
Status $
!=% '
	Cancelled( 1
)1 2
. 
Select 
( 
a 
=> 
a 
. 
TimeSlot '
)' (
. 
ToListAsync 
( 
) 
; 
public 
async 
Task 
< 
bool 
> 
IsAvailable  +
(+ ,
DateOnly, 4
date5 9
,9 :
int; >
doctorId? G
,G H
stringI O
timeSlotP X
)X Y
{ 	
var 
exists 
= 
await 
_dbSet %
.% &
AnyAsync& .
(. /
a/ 0
=>1 3
a 
. 
ScheduledDate 
== 
date #
&& 
a 
. 
DoctorId 
== 
doctorId %
&& 
a 
. 
Status 
!= 
	Cancelled $
&& 
a 
. 
TimeSlot 
. 
Contains "
(" #
timeSlot# +
)+ ,
&& 
a 
. 
TimeSlot 
. 
Contains "
(" #
timeSlot# +
.+ ,
	Substring, 5
(5 6
$num6 7
,7 8
$num9 :
): ;
); <
) 	
;	 

return!! 
!!! 
exists!! 
;!! 
}"" 	
public$$ 
async$$ 
Task$$ 
<$$ 
List$$ 
<$$  
AppointmentReportDto$$ 3
>$$3 4
>$$4 5
GetDailyReport$$6 D
($$D E
)$$E F
=>$$G I
await%% 
_dbSet%% 
.&& 
Where&& 
(&& 
a&& 
=>&& 
a&& 
.&& 
ScheduledDate&& +
>=&&, .
DateOnly&&/ 7
.&&7 8
FromDateTime&&8 D
(&&D E
DateTime&&E M
.&&M N
Today&&N S
.&&S T
AddDays&&T [
(&&[ \
-&&\ ]
$num&&] _
)&&_ `
)&&` a
)&&a b
.'' 
GroupBy'' 
('' 
a'' 
=>'' 
a'' 
.''  
ScheduledDate''  -
)''- .
.(( 
Select(( 
((( 
g(( 
=>(( 
new((   
AppointmentReportDto((! 5
{)) 
Date** 
=** 
g** 
.** 
Key**  
,**  !
PendingCount++  
=++! "
g++# $
.++$ %
Count++% *
(++* +
a+++ ,
=>++- /
a++0 1
.++1 2
Status++2 8
==++9 ;
$str++< E
)++E F
,++F G
ConfirmedCount,, "
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
,,,J K
CancelledCount-- "
=--# $
g--% &
.--& '
Count--' ,
(--, -
a--- .
=>--/ 1
a--2 3
.--3 4
Status--4 :
==--; =
	Cancelled--> G
)--G H
,--H I
CompletedCount.. "
=..# $
g..% &
...& '
Count..' ,
(.., -
a..- .
=>../ 1
a..2 3
...3 4
Status..4 :
==..; =
$str..> I
)..I J
}// 
)// 
.00 
OrderBy00 
(00 
r00 
=>00 
r00 
.00  
Date00  $
)00$ %
.11 
ToListAsync11 
(11 
)11 
;11 
public33 
async33 
Task33 
<33 
List33 
<33 
AppointmentListDto33 1
>331 2
>332 3
GetDoctorSchedule334 E
(33E F
DateOnly33F N
date33O S
,33S T
int33U X
id33Y [
)33[ \
=>33] _
await44 
_dbSet44 
.55 
Where55 
(55 
a55 
=>55 
a55 
.55 
ScheduledDate55 +
==55, .
date55/ 3
&&554 6
a557 8
.558 9
DoctorId559 A
==55B D
id55E G
)55G H
.66 
Select66 
(66 
a66 
=>66 
new66  
AppointmentListDto66! 3
{77 
AppointmentId88 !
=88" #
a88$ %
.88% &
AppointmentId88& 3
,883 4
PatientName99 
=99  !
a99" #
.99# $
Patient99$ +
.99+ ,
FullName99, 4
,994 5

DoctorName:: 
=::  
a::! "
.::" #
Doctor::# )
.::) *
FullName::* 2
,::2 3
ScheduledDate;; !
=;;" #
a;;$ %
.;;% &
ScheduledDate;;& 3
,;;3 4
TimeSlot<< 
=<< 
a<<  
.<<  !
TimeSlot<<! )
,<<) *
Status== 
=== 
a== 
.== 
Status== %
}>> 
)>> 
.?? 
ToListAsync?? 
(?? 
)?? 
;?? 
publicAA 
asyncAA 
TaskAA 
<AA 
ListAA 
<AA 
AppointmentListDtoAA 1
>AA1 2
>AA2 3
GetPatientScheduleAA4 F
(AAF G
DateOnlyAAG O
dateAAP T
,AAT U
intAAV Y
idAAZ \
)AA\ ]
=>AA^ `
awaitBB 
_dbSetBB 
.CC 
WhereCC 
(CC 
aCC 
=>CC 
aCC 
.CC 
ScheduledDateCC +
==CC, .
dateCC/ 3
&&CC4 6
aCC7 8
.CC8 9
	PatientIdCC9 B
==CCC E
idCCF H
)CCH I
.DD 
SelectDD 
(DD 
aDD 
=>DD 
newDD  
AppointmentListDtoDD! 3
{EE 
AppointmentIdFF !
=FF" #
aFF$ %
.FF% &
AppointmentIdFF& 3
,FF3 4
PatientNameGG 
=GG  !
aGG" #
.GG# $
PatientGG$ +
.GG+ ,
FullNameGG, 4
,GG4 5

DoctorNameHH 
=HH  
aHH! "
.HH" #
DoctorHH# )
.HH) *
FullNameHH* 2
,HH2 3
ScheduledDateII !
=II" #
aII$ %
.II% &
ScheduledDateII& 3
,II3 4
TimeSlotJJ 
=JJ 
aJJ  
.JJ  !
TimeSlotJJ! )
,JJ) *
StatusKK 
=KK 
aKK 
.KK 
StatusKK %
}LL 
)LL 
.MM 
ToListAsyncMM 
(MM 
)MM 
;MM 
publicOO 
asyncOO 
TaskOO 
<OO 
ListOO 
<OO 
AppointmentListDtoOO 1
>OO1 2
>OO2 3#
GetAppointmentByPatientOO4 K
(OOK L
intOOL O
idOOP R
)OOR S
=>OOT V
awaitPP 	
_dbSetPP
 
.QQ 	
WhereQQ	 
(QQ 
aQQ 
=>QQ 
aQQ 
.QQ 
	PatientIdQQ 
==QQ  "
idQQ# %
)QQ% &
.RR 	
SelectRR	 
(RR 
aRR 
=>RR 
newRR 
AppointmentListDtoRR +
{SS 	
AppointmentIdTT 
=TT 
aTT 
.TT 
AppointmentIdTT +
,TT+ ,
PatientNameUU 
=UU 
aUU 
.UU 
PatientUU #
.UU# $
FullNameUU$ ,
,UU, -

DoctorNameVV 
=VV 
aVV 
.VV 
DoctorVV !
.VV! "
FullNameVV" *
,VV* +
ScheduledDateWW 
=WW 
aWW 
.WW 
ScheduledDateWW +
,WW+ ,
TimeSlotXX 
=XX 
aXX 
.XX 
TimeSlotXX !
,XX! "
StatusYY 
=YY 
aYY 
.YY 
StatusYY 
}ZZ 	
)ZZ	 

.[[ 	
ToListAsync[[	 
([[ 
)[[ 
;[[ 
public]] 
async]] 
Task]] 
<]] 
List]] 
<]] 
AppointmentListDto]] 1
>]]1 2
>]]2 3"
GetAppointmentByDoctor]]4 J
(]]J K
int]]K N
id]]O Q
)]]Q R
=>]]S U
await^^ 
_dbSet^^ 
.__ 
Where__ 
(__ 
a__ 
=>__ 
a__ 
.__ 
DoctorId__ &
==__' )
id__* ,
&&__- /
a__0 1
.__1 2
ScheduledDate__2 ?
>=__@ B
DateOnly__C K
.__K L
FromDateTime__L X
(__X Y
DateTime__Y a
.__a b
Today__b g
)__g h
)__h i
.`` 
Select`` 
(`` 
a`` 
=>`` 
new``  
AppointmentListDto``! 3
{aa 
AppointmentIdbb !
=bb" #
abb$ %
.bb% &
AppointmentIdbb& 3
,bb3 4
	PatientIdcc 
=cc 
acc  !
.cc! "
	PatientIdcc" +
,cc+ ,
PatientNamedd 
=dd  !
add" #
.dd# $
Patientdd$ +
.dd+ ,
FullNamedd, 4
,dd4 5

DoctorNameee 
=ee  
aee! "
.ee" #
Doctoree# )
.ee) *
FullNameee* 2
,ee2 3
ScheduledDateff !
=ff" #
aff$ %
.ff% &
ScheduledDateff& 3
,ff3 4
TimeSlotgg 
=gg 
agg  
.gg  !
TimeSlotgg! )
,gg) *
Statushh 
=hh 
ahh 
.hh 
Statushh %
}ii 
)ii 
.jj 
ToListAsyncjj 
(jj 
)jj 
;jj 
publicll 
asyncll 
Taskll *
CancelAppointmentsByDoctorDatell 8
(ll8 9
intll9 <
doctorIdll= E
,llE F
DateOnlyllG O
datellP T
)llT U
{mm 	
varnn 
appointmentsnn 
=nn 
awaitnn $
_dbSetnn% +
.oo 
Whereoo 
(oo 
aoo 
=>oo 
aoo 
.oo 
DoctorIdoo &
==oo' )
doctorIdoo* 2
&&pp 
app 
.pp 
ScheduledDatepp +
==pp, .
datepp/ 3
&&qq 
aqq 
.qq 
Statusqq $
!=qq% '
	Cancelledqq( 1
)qq1 2
.rr 
ToListAsyncrr 
(rr 
)rr 
;rr 
foreachtt 
(tt 
vartt 
appointmenttt $
intt% '
appointmentstt( 4
)tt4 5
{uu 
appointmentvv 
.vv 
Statusvv "
=vv# $
	Cancelledvv% .
;vv. /
appointmentww 
.ww 
CancellationReasonww .
=ww/ 0
$strww1 B
;wwB C
}xx 
}yy 	
}zz 
}{{ Óû
MC:\Users\310055\source\repos\UST-Live-01\HealthCare\HealthCare.Api\Program.cs
Log 
. 
Logger 

= 
new 
LoggerConfiguration $
($ %
)% &
. 
WriteTo 
. 
Console 
( 
) 
. !
CreateBootstrapLogger ,
(, -
)- .
;. /
Log 
. 
Information 
( 
$str 1
)1 2
;2 3
var 
builder 
= 
WebApplication 
. 
CreateBuilder *
(* +
args+ /
)/ 0
;0 1
builder 
. 
Services 
. 

AddSerilog 
( 
( 
services 
, 
Configuration 
) 
=>  
Configuration	 
. 
ReadFrom 
.  
Configuration  -
(- .
builder. 5
.5 6
Configuration6 C
)C D
. 	
ReadFrom	 
. 
Services 
( 
services #
)# $
. 	
Enrich	 
. 
FromLogContext 
( 
)  
)   
;   
builder## 
.## 
Services## 
.## 
AddProblemDetails## "
(##" #
)### $
;##$ %
builder$$ 
.$$ 
Services$$ 
.$$ 
AddExceptionHandler$$ $
<$$$ %"
GlobalExceptionHandler$$% ;
>$$; <
($$< =
)$$= >
;$$> ?
builder%% 
.%% 
Services%% 
.%% 
AddControllers%% 
(%%  
)%%  !
.&& 
AddJsonOptions&& 
(&& 
options&& 
=>&& 
{'' 
options(( 
.(( !
JsonSerializerOptions(( %
.((% & 
PropertyNamingPolicy((& :
=((; <
System)) 
.)) 
Text)) 
.)) 
Json)) 
.)) 
JsonNamingPolicy)) -
.))- .
	CamelCase)). 7
;))7 8
}** 
)** 
;** 
builder,, 
.,, 
Services,, 
.,, 
AddAutoMapper,, 
(,, 
cfg,, "
=>,,# %
{-- 
cfg.. 
... 

AddProfile.. 
<.. 
MappingProfile.. !
>..! "
(.." #
)..# $
;..$ %
}// 
)// 
;// 
builder11 
.11 
Services11 
.11 
AddDbContext11 
<11 
HealthCareDbContext11 1
>111 2
(112 3
options113 :
=>11; =
options22 
.22 
UseSqlServer22 
(22 
builder22  
.22  !
Configuration22! .
.22. /
GetConnectionString22/ B
(22B C
$str22C [
)22[ \
)22\ ]
)33 
;33 
builder55 
.55 
Services55 
.55 
AddIdentity55 
<55 
IdentityUser55 )
,55) *
IdentityRole55+ 7
>557 8
(558 9
options559 @
=>55A C
{66 
options77 
.77 
User77 
.77 
RequireUniqueEmail77 #
=77$ %
true77& *
;77* +
options88 
.88 
Password88 
.88 
RequireDigit88 !
=88" #
true88$ (
;88( )
options99 
.99 
Password99 
.99 
RequireUppercase99 %
=99& '
true99( ,
;99, -
options:: 
.:: 
Password:: 
.:: "
RequireNonAlphanumeric:: +
=::, -
true::. 2
;::2 3
options;; 
.;; 
Password;; 
.;; 
RequiredLength;; #
=;;$ %
$num;;& '
;;;' (
}<< 
)<< 
.<< $
AddEntityFrameworkStores<< 
<<< 
HealthCareDbContext<< /
><</ 0
(<<0 1
)<<1 2
.<<2 3$
AddDefaultTokenProviders<<3 K
(<<K L
)<<L M
;<<M N
builder>> 
.>> 
Services>> 
.>> 
AddAuthentication>> "
(>>" #
JwtBearerDefaults>># 4
.>>4 5 
AuthenticationScheme>>5 I
)>>I J
.?? 
AddJwtBearer?? 
(?? 
option?? 
=>?? 
{@@ 
varAA 
jwtAA 
=AA 
builderAA 
.AA 
ConfigurationAA #
.AA# $

GetSectionAA$ .
(AA. /
$strAA/ 4
)AA4 5
;AA5 6
optionBB 

.BB
 %
TokenValidationParametersBB $
=BB% &
newBB' *%
TokenValidationParametersBB+ D
{CC 
ValidateIssuerDD 
=DD 
trueDD 
,DD 
ValidIssuerEE 
=EE 
jwtEE 
[EE 
$strEE "
]EE" #
,EE# $
ValidateAudienceFF 
=FF 
trueFF 
,FF  
ValidAudienceGG 
=GG 
jwtGG 
[GG 
$strGG &
]GG& '
,GG' (
ValidateLifetimeHH 
=HH 
trueHH 
,HH  $
ValidateIssuerSigningKeyII  
=II! "
trueII# '
,II' (
IssuerSigningKeyJJ 
=JJ 
newJJ  
SymmetricSecurityKeyJJ 3
(JJ3 4
EncodingJJ4 <
.JJ< =
UTF8JJ= A
.JJA B
GetBytesJJB J
(JJJ K
jwtJJK N
[JJN O
$strJJO T
]JJT U
!JJU V
)JJV W
)JJW X
,JJX Y
RoleClaimTypeLL 
=LL 

ClaimTypesLL "
.LL" #
RoleLL# '
,LL' (
NameClaimTypeMM 
=MM 

ClaimTypesMM "
.MM" #
NameIdentifierMM# 1
,MM1 2
	ClockSkewOO 
=OO 
TimeSpanOO 
.OO 
ZeroOO !
}PP 
;PP 
optionQQ 

.QQ
 
EventsQQ 
=QQ 
newQQ 
JwtBearerEventsQQ '
{RR "
OnAuthenticationFailedSS 
=SS  
contextSS! (
=>SS) +
{TT 	
ConsoleUU 
.UU 
	WriteLineUU 
(UU 
$"UU  
$strUU  +
{UU+ ,
contextUU, 3
.UU3 4
	ExceptionUU4 =
.UU= >
MessageUU> E
}UUE F
"UUF G
)UUG H
;UUH I
returnVV 
TaskVV 
.VV 
CompletedTaskVV %
;VV% &
}WW 	
}XX 
;XX 
}YY 
)YY 
;YY 
builder\\ 
.\\ 
Services\\ 
.\\ 
	AddScoped\\ 
(\\ 
typeof\\ !
(\\! "
IRepository\\" -
<\\- .
>\\. /
)\\/ 0
,\\0 1
typeof\\2 8
(\\8 9

Repository\\9 C
<\\C D
>\\D E
)\\E F
)\\F G
;\\G H
builder]] 
.]] 
Services]] 
.]] 
	AddScoped]] 
<]] 
IPatientRepository]] -
,]]- .
PatientRepository]]/ @
>]]@ A
(]]A B
)]]B C
;]]C D
builder^^ 
.^^ 
Services^^ 
.^^ 
	AddScoped^^ 
<^^ 
IDoctorRepository^^ ,
,^^, -
DoctorRepository^^. >
>^^> ?
(^^? @
)^^@ A
;^^A B
builder__ 
.__ 
Services__ 
.__ 
	AddScoped__ 
<__ "
IAppointmentRepository__ 1
,__1 2!
AppointmentRepository__3 H
>__H I
(__I J
)__J K
;__K L
builder`` 
.`` 
Services`` 
.`` 
	AddScoped`` 
<`` #
IHealthRecordRepository`` 2
,``2 3"
HealthRecordRepository``4 J
>``J K
(``K L
)``L M
;``M N
buildercc 
.cc 
Servicescc 
.cc 
	AddScopedcc 
<cc 
IJwtServicecc &
,cc& '

JwtServicecc( 2
>cc2 3
(cc3 4
)cc4 5
;cc5 6
builderdd 
.dd 
Servicesdd 
.dd 
	AddScopeddd 
<dd 
IAuthServicedd '
,dd' (
AuthServicedd) 4
>dd4 5
(dd5 6
)dd6 7
;dd7 8
builderee 
.ee 
Servicesee 
.ee 
	AddScopedee 
<ee 
IPatientServiceee *
,ee* +
PatientServiceee, :
>ee: ;
(ee; <
)ee< =
;ee= >
builderff 
.ff 
Servicesff 
.ff 
	AddScopedff 
<ff 
IDoctorServiceff )
,ff) *
DoctorServiceff+ 8
>ff8 9
(ff9 :
)ff: ;
;ff; <
buildergg 
.gg 
Servicesgg 
.gg 
	AddScopedgg 
<gg 
IAppointmentServicegg .
,gg. /
AppointmentServicegg0 B
>ggB C
(ggC D
)ggD E
;ggE F
builderhh 
.hh 
Serviceshh 
.hh 
	AddScopedhh 
<hh  
IHealthRecordServicehh /
,hh/ 0
HealthRecordServicehh1 D
>hhD E
(hhE F
)hhF G
;hhG H
builderii 
.ii 
Servicesii 
.ii 
AddMassTransitii 
(ii  
xii  !
=>ii" $
{jj 
xkk 
.kk 
AddConsumerkk 
<kk %
AppointmentBookedConsumerkk +
>kk+ ,
(kk, -
)kk- .
;kk. /
xmm 
.mm 
UsingRabbitMqmm 
(mm 
(mm 
contextmm 
,mm 
cfgmm !
)mm! "
=>mm# %
{nn 
cfgoo 
.oo 
Hostoo 
(oo 
builderpp 
.pp 
Configurationpp !
[pp! "
$strpp" 5
]pp5 6
,pp6 7
ushortqq 
.qq 
Parseqq 
(qq 
builderqq  
.qq  !
Configurationqq! .
[qq. /
$strqq/ >
]qq> ?
!qq? @
)qq@ A
,qqA B
builderrr 
.rr 
Configurationrr !
[rr! "
$strrr" 8
]rr8 9
,rr9 :
hss 
=>ss 
{tt 
huu 
.uu 
Usernameuu 
(uu 
buildervv 
.vv 
Configurationvv )
[vv) *
$strvv* =
]vv= >
!vv> ?
)vv? @
;vv@ A
hxx 
.xx 
Passwordxx 
(xx 
builderyy 
.yy 
Configurationyy )
[yy) *
$stryy* =
]yy= >
!yy> ?
)yy? @
;yy@ A
}zz 
)zz 
;zz 
cfg|| 
.|| 
ReceiveEndpoint|| 
(|| 
builder}} 
.}} 
Configuration}} !
[}}! "
$str}}" <
]}}< =
!}}= >
,}}> ?
e~~ 
=>~~ 
{ 
e
ÅÅ 
.
ÅÅ 
ConfigureConsumer
ÅÅ #
<
ÅÅ# $'
AppointmentBookedConsumer
ÇÇ -
>
ÇÇ- .
(
ÇÇ. /
context
ÉÉ 
)
ÉÉ  
;
ÉÉ  !
}
ÑÑ 
)
ÑÑ 
;
ÑÑ 
}
ÖÖ 
)
ÖÖ 
;
ÖÖ 
}ÜÜ 
)
ÜÜ 
;
ÜÜ 
builderáá 
.
áá 
Services
áá 
.
áá 
	Configure
áá 
<
áá 
GarnetOptions
áá (
>
áá( )
(
áá) *
builder
áá* 1
.
áá1 2
Configuration
áá2 ?
.
áá? @

GetSection
áá@ J
(
ááJ K
$str
ááK S
)
ááS T
)
ááT U
;
ááU V
builderàà 
.
àà 
Services
àà 
.
àà (
AddStackExchangeRedisCache
àà +
(
àà+ ,
option
àà, 2
=>
àà3 5
{ââ 
var
ää 
garnetOptions
ää 
=
ää 
builder
ää 
.
ää  
Configuration
ää  -
.
ää- .

GetSection
ää. 8
(
ää8 9
$str
ää9 A
)
ääA B
.
ääB C
Get
ääC F
<
ääF G
GarnetOptions
ääG T
>
ääT U
(
ääU V
)
ääV W
??
ääX Z
new
ää[ ^
GarnetOptions
ää_ l
(
ääl m
)
ääm n
;
ään o
option
ãã 

.
ãã
 
Configuration
ãã 
=
ãã 
garnetOptions
ãã (
.
ãã( )
ConnectionString
ãã) 9
;
ãã9 :
option
åå 

.
åå
 
InstanceName
åå 
=
åå 
garnetOptions
åå '
.
åå' (
InstanceName
åå( 4
;
åå4 5
}çç 
)
çç 
;
çç 
varèè 
allowedOrigins
èè 
=
èè 
builder
èè 
.
èè 
Configuration
èè *
.
êê 

GetSection
êê 
(
êê 
$str
êê %
)
êê% &
.
ëë 
Get
ëë 
<
ëë 	
string
ëë	 
[
ëë 
]
ëë 
>
ëë 
(
ëë 
)
ëë 
;
ëë 
builderìì 
.
ìì 
Services
ìì 
.
ìì 
AddCors
ìì 
(
ìì 
options
ìì  
=>
ìì! #
{îî 
options
ïï 
.
ïï 
	AddPolicy
ïï 
(
ïï 
$str
ïï '
,
ïï' (
policy
ïï) /
=>
ïï0 2
{
ññ 
policy
óó 
.
óó 
WithOrigins
óó 
(
óó 
allowedOrigins
óó )
??
óó* ,
Array
óó- 2
.
óó2 3
Empty
óó3 8
<
óó8 9
string
óó9 ?
>
óó? @
(
óó@ A
)
óóA B
)
óóB C
.
òò 
AllowAnyHeader
òò 
(
òò 
)
òò 
.
ôô 
AllowAnyMethod
ôô 
(
ôô 
)
ôô 
;
ôô  
}
öö 
)
öö 
;
öö 
}õõ 
)
õõ 
;
õõ 
builderúú 
.
úú 
Services
úú 
.
úú %
AddEndpointsApiExplorer
úú (
(
úú( )
)
úú) *
;
úú* +
builderûû 
.
ûû 
Services
ûû 
.
ûû 
AddSwaggerGen
ûû 
(
ûû 
options
ûû &
=>
ûû' )
{üü 
options
†† 
.
†† 

SwaggerDoc
†† 
(
†† 
$str
†† 
,
†† 
new
††  
OpenApiInfo
††! ,
{
°° 
Title
¢¢ 
=
¢¢ 
$str
¢¢ 
,
¢¢  
Version
££ 
=
££ 
$str
££ 
}
§§ 
)
§§ 
;
§§ 
options
¶¶ 
.
¶¶ #
AddSecurityDefinition
¶¶ !
(
¶¶! "
$str
¶¶" *
,
¶¶* +
new
¶¶, /#
OpenApiSecurityScheme
¶¶0 E
{
ßß 
Type
®® 
=
®®  
SecuritySchemeType
®® !
.
®®! "
Http
®®" &
,
®®& '
Scheme
©© 
=
©© 
$str
©© 
,
©© 
BearerFormat
™™ 
=
™™ 
$str
™™ 
,
™™ 
Description
´´ 
=
´´ 
$str
´´ A
}
¨¨ 
)
¨¨ 
;
¨¨ 
options
ÆÆ 
.
ÆÆ $
AddSecurityRequirement
ÆÆ "
(
ÆÆ" #
document
ÆÆ# +
=>
ÆÆ, .
new
ÆÆ/ 2(
OpenApiSecurityRequirement
ÆÆ3 M
{
ØØ 
[
∞∞ 	
new
∞∞	 ,
OpenApiSecuritySchemeReference
∞∞ +
(
∞∞+ ,
$str
∞∞, 4
,
∞∞4 5
document
∞∞6 >
)
∞∞> ?
]
∞∞? @
=
∞∞A B
[
∞∞C D
]
∞∞D E
}
±± 
)
±± 
;
±± 
}≤≤ 
)
≤≤ 
;
≤≤ 
var¥¥ 
app
¥¥ 
=
¥¥ 	
builder
¥¥
 
.
¥¥ 
Build
¥¥ 
(
¥¥ 
)
¥¥ 
;
¥¥ 
appµµ 
.
µµ &
UseSerilogRequestLogging
µµ 
(
µµ 
)
µµ 
;
µµ 
app∂∂ 
.
∂∂ !
UseExceptionHandler
∂∂ 
(
∂∂ 
)
∂∂ 
;
∂∂ 
using∏∏ 
(
∏∏ 
var
∏∏ 

scope
∏∏ 
=
∏∏ 
app
∏∏ 
.
∏∏ 
Services
∏∏ 
.
∏∏  
CreateScope
∏∏  +
(
∏∏+ ,
)
∏∏, -
)
∏∏- .
{ππ 
var
∫∫ 
services
∫∫ 
=
∫∫ 
scope
∫∫ 
.
∫∫ 
ServiceProvider
∫∫ (
;
∫∫( )
var
ªª 
roleManager
ªª 
=
ªª 
scope
ªª 
.
ªª 
ServiceProvider
ªª +
.
ªª+ , 
GetRequiredService
ªª, >
<
ªª> ?
RoleManager
ªª? J
<
ªªJ K
IdentityRole
ªªK W
>
ªªW X
>
ªªX Y
(
ªªY Z
)
ªªZ [
;
ªª[ \
var
ºº 
userManager
ºº 
=
ºº 
services
ºº 
.
ºº  
GetRequiredService
ºº 1
<
ºº1 2
UserManager
ºº2 =
<
ºº= >
IdentityUser
ºº> J
>
ººJ K
>
ººK L
(
ººL M
)
ººM N
;
ººN O
var
ΩΩ 
config
ΩΩ 
=
ΩΩ 
services
ΩΩ 
.
ΩΩ  
GetRequiredService
ΩΩ ,
<
ΩΩ, -
IConfiguration
ΩΩ- ;
>
ΩΩ; <
(
ΩΩ< =
)
ΩΩ= >
;
ΩΩ> ?
await
øø 	

RoleSeeder
øø
 
.
øø 
SeedRolesAsync
øø #
(
øø# $
roleManager
øø$ /
)
øø/ 0
;
øø0 1
await
¿¿ 	

UserSeeder
¿¿
 
.
¿¿ 
SeedAdminAsync
¿¿ #
(
¿¿# $
userManager
¿¿$ /
,
¿¿/ 0
roleManager
¿¿1 <
,
¿¿< =
config
¿¿> D
)
¿¿D E
;
¿¿E F
}¡¡ 
ifƒƒ 
(
ƒƒ 
app
ƒƒ 
.
ƒƒ 
Environment
ƒƒ 
.
ƒƒ 
IsDevelopment
ƒƒ !
(
ƒƒ! "
)
ƒƒ" #
)
ƒƒ# $
{≈≈ 
app
∆∆ 
.
∆∆ 

UseSwagger
∆∆ 
(
∆∆ 
)
∆∆ 
;
∆∆ 
app
«« 
.
«« 
UseSwaggerUI
«« 
(
«« 
)
«« 
;
«« 
}»» 
app   
.
   !
UseHttpsRedirection
   
(
   
)
   
;
   
appÀÀ 
.
ÀÀ 

UseRouting
ÀÀ 
(
ÀÀ 
)
ÀÀ 
;
ÀÀ 
appÃÃ 
.
ÃÃ 
UseCors
ÃÃ 
(
ÃÃ 
$str
ÃÃ 
)
ÃÃ 
;
ÃÃ 
appÕÕ 
.
ÕÕ 
UseAuthentication
ÕÕ 
(
ÕÕ 
)
ÕÕ 
;
ÕÕ 
appŒŒ 
.
ŒŒ 
UseAuthorization
ŒŒ 
(
ŒŒ 
)
ŒŒ 
;
ŒŒ 
app–– 
.
–– 
MapControllers
–– 
(
–– 
)
–– 
;
–– 
await““ 
app
““ 	
.
““	 

RunAsync
““
 
(
““ 
)
““ 
;
““ ê
[C:\Users\310055\source\repos\UST-Live-01\HealthCare\HealthCare.Api\Options\GarnetOptions.cs
	namespace 	

HealthCare
 
. 
Api 
. 
Options  
{ 
public 

class 
GarnetOptions 
{ 
public 
string 
ConnectionString &
{' (
get) ,
;, -
set. 1
;1 2
}3 4
=5 6
$str7 G
;G H
public 
string 
InstanceName "
{# $
get% (
;( )
set* -
;- .
}/ 0
=1 2
string3 9
.9 :
Empty: ?
;? @
} 
}		 Ö 
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
public$$ 
string$$ 
Email$$ 
{$$ 
get$$ !
;$$! "
set$$# &
;$$& '
}$$( )
=$$* +
null$$, 0
!$$0 1
;$$1 2
public&& 
DateTimeOffset&& 
CreatedDate&& )
{&&* +
get&&, /
;&&/ 0
set&&1 4
;&&4 5
}&&6 7
=&&8 9
DateTimeOffset&&: H
.&&H I
UtcNow&&I O
;&&O P
[)) 	

ForeignKey))	 
()) 
nameof)) 
()) 
UserId)) !
)))! "
)))" #
]))# $
public** 
IdentityUser** 
?** 
User** !
{**" #
get**$ '
;**' (
set**) ,
;**, -
}**. /
public,, 
ICollection,, 
<,, 
Appointment,, &
>,,& '
Appointments,,( 4
{,,5 6
get,,7 :
;,,: ;
set,,< ?
;,,? @
},,A B
=,,C D
[,,E F
],,F G
;,,G H
public-- 
ICollection-- 
<-- 
HealthRecord-- '
>--' (
HealthRecords--) 6
{--7 8
get--9 <
;--< =
set--> A
;--A B
}--C D
=--E F
[--G H
]--H I
;--I J
}.. 
}// è
YC:\Users\310055\source\repos\UST-Live-01\HealthCare\HealthCare.Api\Models\Notification.cs
	namespace 	

HealthCare
 
. 
Api 
. 
Models 
{ 
public 

class 
Notification 
{ 
[ 	
Key	 
] 
public 
int 
NotificationId !
{" #
get$ '
;' (
set) ,
;, -
}. /
public

 
int

 
DoctorId

 
{

 
get

 !
;

! "
set

# &
;

& '
}

( )
[ 	
Required	 
] 
public 
string 
Message 
{ 
get  #
;# $
set% (
;( )
}* +
=, -
string. 4
.4 5
Empty5 :
;: ;
public 
bool 
IsRead 
{ 
get  
;  !
set" %
;% &
}' (
=) *
false+ 0
;0 1
public 
DateTime 
CreatedDate #
{$ %
get& )
;) *
set+ .
;. /
}0 1
= 
DateTime 
. 
UtcNow 
; 
} 
} ü
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
} ¶"
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
=$$8 9
DateTimeOffset$$: H
.$$H I
UtcNow$$I O
;$$O P
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
} ∆
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
}** ò
vC:\Users\310055\source\repos\UST-Live-01\HealthCare\HealthCare.Api\Migrations\20260713151720_Notificationtableadded.cs
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
class "
Notificationtableadded /
:0 1
	Migration2 ;
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
. 
RenameColumn )
() *
name 
: 
$str 
, 
table 
: 
$str &
,& '
newName 
: 
$str #
)# $
;$ %
} 	
	protected 
override 
void 
Down  $
($ %
MigrationBuilder% 5
migrationBuilder6 F
)F G
{ 	
migrationBuilder 
. 
RenameColumn )
() *
name 
: 
$str  
,  !
table 
: 
$str &
,& '
newName 
: 
$str !
)! "
;" #
} 	
} 
} ò
vC:\Users\310055\source\repos\UST-Live-01\HealthCare\HealthCare.Api\Migrations\20260708044037_AddedNotificationTable.cs
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
class "
AddedNotificationTable /
:0 1
	Migration2 ;
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
. 
RenameColumn )
() *
name 
: 
$str  
,  !
table 
: 
$str &
,& '
newName 
: 
$str !
)! "
;" #
} 	
	protected 
override 
void 
Down  $
($ %
MigrationBuilder% 5
migrationBuilder6 F
)F G
{ 	
migrationBuilder 
. 
RenameColumn )
() *
name 
: 
$str 
, 
table 
: 
$str &
,& '
newName 
: 
$str #
)# $
;$ %
} 	
} 
} À
tC:\Users\310055\source\repos\UST-Live-01\HealthCare\HealthCare.Api\Migrations\20260707163123_AddNotificationTable.cs
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
class		  
AddNotificationTable		 -
:		. /
	Migration		0 9
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
$str %
,% &
columns 
: 
table 
=> !
new" %
{ 
NotificationId "
=# $
table% *
.* +
Column+ 1
<1 2
int2 5
>5 6
(6 7
type7 ;
:; <
$str= B
,B C
nullableD L
:L M
falseN S
)S T
. 

Annotation #
(# $
$str$ 8
,8 9
$str: @
)@ A
,A B
DoctorId 
= 
table $
.$ %
Column% +
<+ ,
int, /
>/ 0
(0 1
type1 5
:5 6
$str7 <
,< =
nullable> F
:F G
falseH M
)M N
,N O
Message 
= 
table #
.# $
Column$ *
<* +
string+ 1
>1 2
(2 3
type3 7
:7 8
$str9 H
,H I
nullableJ R
:R S
falseT Y
)Y Z
,Z [
IsRead 
= 
table "
." #
Column# )
<) *
bool* .
>. /
(/ 0
type0 4
:4 5
$str6 ;
,; <
nullable= E
:E F
falseG L
)L M
,M N
CreatedDate 
=  !
table" '
.' (
Column( .
<. /
DateTime/ 7
>7 8
(8 9
type9 =
:= >
$str? J
,J K
nullableL T
:T U
falseV [
)[ \
} 
, 
constraints 
: 
table "
=># %
{ 
table 
. 

PrimaryKey $
($ %
$str% 7
,7 8
x9 :
=>; =
x> ?
.? @
NotificationId@ N
)N O
;O P
} 
) 
; 
} 	
	protected   
override   
void   
Down    $
(  $ %
MigrationBuilder  % 5
migrationBuilder  6 F
)  F G
{!! 	
migrationBuilder"" 
."" 
	DropTable"" &
(""& '
name## 
:## 
$str## %
)##% &
;##& '
}$$ 	
}%% 
}&& ≤
rC:\Users\310055\source\repos\UST-Live-01\HealthCare\HealthCare.Api\Migrations\20260624105126_RemovePatientEmail.cs
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
class 
RemovePatientEmail +
:, -
	Migration. 7
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
} 	
	protected 
override 
void 
Down  $
($ %
MigrationBuilder% 5
migrationBuilder6 F
)F G
{ 	
} 	
} 
} õ
oC:\Users\310055\source\repos\UST-Live-01\HealthCare\HealthCare.Api\Migrations\20260624104651_AddPatientEmail.cs
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
class 
AddPatientEmail (
:) *
	Migration+ 4
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
. 

DropColumn '
(' (
name 
: 
$str %
,% &
table 
: 
$str $
)$ %
;% &
migrationBuilder 
. 
	AddColumn &
<& '
string' -
>- .
(. /
name 
: 
$str 
, 
table 
: 
$str !
,! "
type 
: 
$str %
,% &
nullable 
: 
false 
,  
defaultValue 
: 
$str  
)  !
;! "
} 	
	protected 
override 
void 
Down  $
($ %
MigrationBuilder% 5
migrationBuilder6 F
)F G
{ 	
migrationBuilder 
. 

DropColumn '
(' (
name 
: 
$str 
, 
table 
: 
$str !
)! "
;" #
migrationBuilder   
.   
	AddColumn   &
<  & '
string  ' -
>  - .
(  . /
name!! 
:!! 
$str!! %
,!!% &
table"" 
:"" 
$str"" $
,""$ %
type## 
:## 
$str## $
,##$ %
	maxLength$$ 
:$$ 
$num$$ 
,$$ 
nullable%% 
:%% 
false%% 
,%%  
defaultValue&& 
:&& 
$str&&  
)&&  !
;&&! "
}'' 	
}(( 
})) ø]
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
}ææ —
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
}		 Í
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
InvalidOperationException )
=>* ,
(- .
StatusCodes. 9
.9 :
Status400BadRequest: M
,M N
	exceptionO X
.X Y
MessageY `
)` a
,a b
_ 
=> 
( 
StatusCodes !
.! "(
Status500InternalServerError" >
,> ?
$str@ W
)W X
} 
; 
var!! 
response!! 
=!! 
new!! 
ErrorResponse!! ,
{"" 

StatusCode## 
=## 

statusCode## '
,##' (
Message$$ 
=$$ 
message$$ !
,$$! "
	TimeStamp%% 
=%% 
DateTime%% $
.%%$ %
UtcNow%%% +
,%%+ ,
Path&& 
=&& 
httpContext&& "
.&&" #
Request&&# *
.&&* +
Path&&+ /
}'' 
;'' 
httpContext)) 
.)) 
Response))  
.))  !

StatusCode))! +
=)), -

statusCode)). 8
;))8 9
await++ 
httpContext++ 
.++ 
Response++ &
.++& '
WriteAsJsonAsync++' 7
(++7 8
response++8 @
,++@ A
cancellationToken++B S
)++S T
;++T U
return-- 
true-- 
;-- 
}.. 	
}// 
}00 ˝
iC:\Users\310055\source\repos\UST-Live-01\HealthCare\HealthCare.Api\Messaging\AppointmentBookedConsumer.cs
	namespace 	

HealthCare
 
. 
Api 
. 
	Consumers "
{ 
public 

class %
AppointmentBookedConsumer *
:+ ,
	IConsumer		 
<		 "
AppointmentBookedEvent		 (
>		( )
{

 
private 
readonly 
HealthCareDbContext ,
_context- 5
;5 6
private 
readonly 
ILogger  
<  !%
AppointmentBookedConsumer! :
>: ;
_logger< C
;C D
public %
AppointmentBookedConsumer (
(( )
HealthCareDbContext 
context  '
,' (
ILogger 
< %
AppointmentBookedConsumer -
>- .
logger/ 5
)5 6
{ 	
_context 
= 
context 
; 
_logger 
= 
logger 
; 
} 	
public 
async 
Task 
Consume !
(! "
ConsumeContext 
< "
AppointmentBookedEvent 1
>1 2
context3 :
): ;
{ 	
var 
message 
= 
context !
.! "
Message" )
;) *
var 
notification 
= 
new "
Notification# /
{ 
DoctorId 
= 
message "
." #
DoctorId# +
,+ ,
Message 
= 
$" 
$str 0
{0 1
message1 8
.8 9
PatientName9 D
}D E
$strE F
"F G
+H I
$"   
$str   
{   
message   "
.  " #
ScheduledDate  # 0
}  0 1
$str  1 5
{  5 6
message  6 =
.  = >
TimeSlot  > F
}  F G
"  G H
,  H I
IsRead!! 
=!! 
false!! 
}"" 
;"" 
_context$$ 
.$$ 
Notifications$$ "
.$$" #
Add$$# &
($$& '
notification$$' 3
)$$3 4
;$$4 5
await&& 
_context&& 
.&& 
SaveChangesAsync&& +
(&&+ ,
)&&, -
;&&- .
if)) 
()) 
_logger)) 
.)) 
	IsEnabled)) !
())! "
LogLevel))" *
.))* +
Information))+ 6
)))6 7
)))7 8
{** 
_logger++ 
.++ 
LogInformation++ &
(++& '
$str,, B
,,,B C
message-- 
.-- 
DoctorId-- $
)--$ %
;--% &
}.. 
}00 	
}11 
}22 ©
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
. 
	ForMember 
( 
dest 
=>  "
dest# '
.' (
Specialisation( 6
,6 7
opt 
=> 
opt 
. 
MapFrom "
(" #
src# &
=>' )
src* -
.- .
Specialisation. <
.< =
ToString= E
(E F
)F G
)G H
)H I
;I J
	CreateMap 
< 
Doctor 
, 
DoctorListDto +
>+ ,
(, -
)- .
. 
	ForMember 
( 
dest 
=> 
dest 
. 
DoctorId %
,% &
opt	 
=> 
opt 
. 
MapFrom 
( 
src 
=>  "
src# &
.& '
DoctorId' /
)/ 0
)0 1
. 
	ForMember 
( 
dest 
=> 
dest 
. 
Email "
," #
opt	 
=> 
opt 
. 
MapFrom 
( 
src 
=>  "
src 
. 
User 
!= 
null 
? 
src 
. 
User 
. 
Email !
: 
string 
. 
Empty 
)  
)  !
;! "
	CreateMap"" 
<""  
CreateAppointmentDto"" *
,""* +
Appointment"", 7
>""7 8
(""8 9
)""9 :
;"": ;
	CreateMap## 
<##  
UpdateAppointmentDto## *
,##* +
Appointment##, 7
>##7 8
(##8 9
)##9 :
;##: ;
	CreateMap$$ 
<$$ 
AppointmentListDto$$ (
,$$( )
Appointment$$* 5
>$$5 6
($$6 7
)$$7 8
;$$8 9
	CreateMap'' 
<'' !
CreateHealthRecordDto'' +
,''+ ,
HealthRecord''- 9
>''9 :
('': ;
)''; <
;''< =
	CreateMap(( 
<(( !
UpdateHealthRecordDto(( +
,((+ ,
HealthRecord((- 9
>((9 :
(((: ;
)((; <
;((< =
	CreateMap)) 
<)) 
HealthRecordListDto)) )
,))) *
HealthRecord))+ 7
>))7 8
())8 9
)))9 :
;)): ;
}** 	
}++ 
},, ‡“
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
}ÂÂ ‡
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
}		 ï

cC:\Users\310055\source\repos\UST-Live-01\HealthCare\HealthCare.Api\Events\AppointmentBookedEvent.cs
	namespace 	

HealthCare
 
. 
Api 
. 
Events 
{ 
public 

class "
AppointmentBookedEvent '
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
public 
string 
PatientName !
{" #
get$ '
;' (
set) ,
;, -
}. /
=0 1
string2 8
.8 9
Empty9 >
;> ?
public		 
int		 
DoctorId		 
{		 
get		 !
;		! "
set		# &
;		& '
}		( )
public 
DateOnly 
ScheduledDate %
{& '
get( +
;+ ,
set- 0
;0 1
}2 3
public 
string 
TimeSlot 
{  
get! $
;$ %
set& )
;) *
}+ ,
=- .
string/ 5
.5 6
Empty6 ;
;; <
} 
} ‹
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
} ÕP
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
;F G
public 
DbSet 
< 
Notification !
>! "
Notifications# 0
=>1 3
Set 
< 
Notification 
> 
( 
) 
; 
	protected 
override 
void 
OnModelCreating  /
(/ 0
ModelBuilder0 <
builder= D
)D E
{ 	
base 
. 
OnModelCreating  
(  !
builder! (
)( )
;) *
builder 
. 
Entity 
< 
Appointment &
>& '
(' (
)( )
. 
HasIndex 
( 
a 
=> 
new "
{# $
a% &
.& '
DoctorId' /
,/ 0
a1 2
.2 3
ScheduledDate3 @
,@ A
aB C
.C D
TimeSlotD L
}M N
)N O
. 
IsUnique 
( 
) 
. 
	HasFilter 
( 
$str 4
)4 5
. 
HasDatabaseName  
(  !
$str! C
)C D
;D E
builder!! 
.!! 
Entity!! 
<!! 
Appointment!! &
>!!& '
(!!' (
)!!( )
."" 
HasIndex"" 
("" 
a"" 
=>"" 
new"" "
{""# $
a""% &
.""& '
DoctorId""' /
,""/ 0
a""1 2
.""2 3
ScheduledDate""3 @
}""A B
)""B C
.## 
HasDatabaseName##  
(##  !
$str##! >
)##> ?
;##? @
builder%% 
.%% 
Entity%% 
<%% 
Appointment%% &
>%%& '
(%%' (
)%%( )
.&& 
HasIndex&& 
(&& 
a&& 
=>&& 
new&& "
{&&# $
a&&% &
.&&& '
	PatientId&&' 0
,&&0 1
a&&2 3
.&&3 4
ScheduledDate&&4 A
}&&B C
)&&C D
.'' 
HasDatabaseName''  
(''  !
$str''! ?
)''? @
;''@ A
builder)) 
.)) 
Entity)) 
<)) 
HealthRecord)) '
>))' (
())( )
)))) *
.** 
HasIndex** 
(** 
hr** 
=>** 
new**  #
{**$ %
hr**& (
.**( )
	PatientId**) 2
,**2 3
hr**4 6
.**6 7
	VisitDate**7 @
}**A B
)**B C
.++ 
HasDatabaseName++  
(++  !
$str++! E
)++E F
;++F G
builder-- 
.-- 
Entity-- 
<-- 
Patient-- "
>--" #
(--# $
)--$ %
... 
HasOne.. 
(.. 
p.. 
=>.. 
p.. 
... 
User.. #
)..# $
.// 
WithOne// 
(// 
)// 
.00 
HasForeignKey00 
<00 
Patient00 &
>00& '
(00' (
p00( )
=>00* ,
p00- .
.00. /
UserId00/ 5
)005 6
.11 
OnDelete11 
(11 
DeleteBehavior11 (
.11( )
Cascade11) 0
)110 1
;111 2
builder33 
.33 
Entity33 
<33 
Doctor33 !
>33! "
(33" #
)33# $
.44 
HasOne44 
(44 
d44 
=>44 
d44 
.44 
User44 #
)44# $
.55 
WithOne55 
(55 
)55 
.66 
HasForeignKey66 
<66 
Doctor66 %
>66% &
(66& '
d66' (
=>66) +
d66, -
.66- .
UserId66. 4
)664 5
.77 
OnDelete77 
(77 
DeleteBehavior77 (
.77( )
Cascade77) 0
)770 1
;771 2
builder99 
.99 
Entity99 
<99 
Appointment99 &
>99& '
(99' (
)99( )
.:: 
HasOne:: 
(:: 
a:: 
=>:: 
a:: 
.:: 
Patient:: &
)::& '
.;; 
WithMany;; 
(;; 
p;; 
=>;; 
p;;  
.;;  !
Appointments;;! -
);;- .
.<< 
HasForeignKey<< 
(<< 
a<<  
=><<! #
a<<$ %
.<<% &
	PatientId<<& /
)<</ 0
.== 
OnDelete== 
(== 
DeleteBehavior== (
.==( )
Restrict==) 1
)==1 2
;==2 3
builder?? 
.?? 
Entity?? 
<?? 
Appointment?? &
>??& '
(??' (
)??( )
.@@ 
HasOne@@ 
(@@ 
a@@ 
=>@@ 
a@@ 
.@@ 
Doctor@@ %
)@@% &
.AA 
WithManyAA 
(AA 
dAA 
=>AA 
dAA  
.AA  !
AppointmentsAA! -
)AA- .
.BB 
HasForeignKeyBB 
(BB 
aBB  
=>BB! #
aBB$ %
.BB% &
DoctorIdBB& .
)BB. /
.CC 
OnDeleteCC 
(CC 
DeleteBehaviorCC (
.CC( )
RestrictCC) 1
)CC1 2
;CC2 3
builderEE 
.EE 
EntityEE 
<EE 
HealthRecordEE '
>EE' (
(EE( )
)EE) *
.FF 
HasOneFF 
(FF 
hrFF 
=>FF 
hrFF  
.FF  !
AppointmentFF! ,
)FF, -
.GG 
WithOneGG 
(GG 
aGG 
=>GG 
aGG 
.GG  
HealthRecordGG  ,
)GG, -
.HH 
HasForeignKeyHH 
<HH 
HealthRecordHH +
>HH+ ,
(HH, -
hrHH- /
=>HH0 2
hrHH3 5
.HH5 6
AppointmentIdHH6 C
)HHC D
.II 
OnDeleteII 
(II 
DeleteBehaviorII (
.II( )
RestrictII) 1
)II1 2
;II2 3
builderKK 
.KK 
EntityKK 
<KK 
HealthRecordKK '
>KK' (
(KK( )
)KK) *
.LL 
HasOneLL 
(LL 
hrLL 
=>LL 
hrLL  
.LL  !
PatientLL! (
)LL( )
.MM 
WithManyMM 
(MM 
pMM 
=>MM 
pMM  
.MM  !
HealthRecordsMM! .
)MM. /
.NN 
HasForeignKeyNN 
(NN 
hrNN !
=>NN" $
hrNN% '
.NN' (
	PatientIdNN( 1
)NN1 2
.OO 
OnDeleteOO 
(OO 
DeleteBehaviorOO (
.OO( )
RestrictOO) 1
)OO1 2
;OO2 3
builderQQ 
.QQ 
EntityQQ 
<QQ 
HealthRecordQQ '
>QQ' (
(QQ( )
)QQ) *
.RR 
HasOneRR 
(RR 
hrRR 
=>RR 
hrRR  
.RR  !
DoctorRR! '
)RR' (
.SS 
WithManySS 
(SS 
dSS 
=>SS 
dSS  
.SS  !
HealthRecordsSS! .
)SS. /
.TT 
HasForeignKeyTT 
(TT 
hrTT !
=>TT" $
hrTT% '
.TT' (
DoctorIdTT( 0
)TT0 1
.UU 
OnDeleteUU 
(UU 
DeleteBehaviorUU (
.UU( )
RestrictUU) 1
)UU1 2
;UU2 3
}VV 	
}WW 
}XX ∑*
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
public 
PatientController  
(  !
IPatientService! 0
patientService1 ?
)? @
{ 	
_patientService 
= 
patientService ,
;, -
} 	
[ 	
HttpGet	 
( 
$str 
) 
] 
[ 	
	Authorize	 
( !
AuthenticationSchemes (
=) *
JwtBearerDefaults+ <
.< = 
AuthenticationScheme= Q
)Q R
]R S
[ 	
	Authorize	 
( 
Roles 
= 
$str $
)$ %
]% &
public 
async 
Task 
< 
IActionResult '
>' (
GetMyProfile) 5
(5 6
)6 7
{ 	
var 
	patientId 
= "
GetPatientIdFromClaims 2
(2 3
)3 4
;4 5
var 
result 
= 
await 
_patientService .
.. /
GetByIdAsync/ ;
(; <
	patientId< E
)E F
;F G
return 
Ok 
( 
result 
) 
; 
} 	
[   	
HttpPut  	 
(   
$str   
)   
]   
[!! 	
	Authorize!!	 
(!! !
AuthenticationSchemes!! (
=!!) *
JwtBearerDefaults!!+ <
.!!< = 
AuthenticationScheme!!= Q
)!!Q R
]!!R S
["" 	
	Authorize""	 
("" 
Roles"" 
="" 
$str"" $
)""$ %
]""% &
public## 
async## 
Task## 
<## 
IActionResult## '
>##' (
UpdatePatient##) 6
(##6 7
[##7 8
FromBody##8 @
]##@ A
UpdatePatientDto##B R
dto##S V
)##V W
{$$ 	
if%% 
(%% 
!%% 

ModelState%% 
.%% 
IsValid%% #
)%%# $
return&& 

BadRequest&& !
(&&! "

ModelState&&" ,
)&&, -
;&&- .
var(( 
	patientId(( 
=(( "
GetPatientIdFromClaims(( 2
(((2 3
)((3 4
;((4 5
await)) 
_patientService)) !
.))! "
UpdateAsync))" -
())- .
	patientId)). 7
,))7 8
dto))9 <
)))< =
;))= >
return** 
Ok** 
(** 
new** 
{** 
message** "
=**# $
$str**% K
}**K L
)**L M
;**M N
}++ 	
private.. 
int.. "
GetPatientIdFromClaims.. *
(..* +
)..+ ,
{// 	
var00 
claim00 
=00 
User00 
.00 
Claims00 #
.00# $
FirstOrDefault00$ 2
(002 3
c003 4
=>005 7
c008 9
.009 :
Type00: >
==00? A
$str00B M
)00M N
;00N O
if22 
(22 
claim22 
==22 
null22 
)22 
throw33 
new33 %
InvalidOperationException33 3
(333 4
$str334 Y
)33Y Z
;33Z [
return55 
int55 
.55 
Parse55 
(55 
claim55 "
.55" #
Value55# (
)55( )
;55) *
}66 	
[88 	
HttpGet88	 
(88 
$str88 
)88 
]88 
[99 	
	Authorize99	 
(99 !
AuthenticationSchemes99 (
=99) *
JwtBearerDefaults99+ <
.99< = 
AuthenticationScheme99= Q
)99Q R
]99R S
[:: 	
	Authorize::	 
(:: 
Roles:: 
=:: 
$str:: $
)::$ %
]::% &
public;; 
async;; 
Task;; 
<;; 
IActionResult;; '
>;;' (
GetDashboard;;) 5
(;;5 6
);;6 7
{<< 	
var== 
	patientId== 
=== "
GetPatientIdFromClaims== 2
(==2 3
)==3 4
;==4 5
var?? 
data?? 
=?? 
await?? 
_patientService?? ,
.??, -
GetDashboardAsync??- >
(??> ?
	patientId??? H
)??H I
;??I J
returnAA 
OkAA 
(AA 
dataAA 
)AA 
;AA 
}BB 	
}CC 
}DD å@
hC:\Users\310055\source\repos\UST-Live-01\HealthCare\HealthCare.Api\Controllers\PatientAdminController.cs
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
$str		 
)		  
]		  !
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
PatientAdminController '
:( )
ControllerBase* 8
{ 
private 
readonly 
IPatientService (
_patientService) 8
;8 9
public "
PatientAdminController %
(% &
IPatientService& 5
patientService6 D
,D E
IAuthServiceF R
authServiceS ^
)^ _
{ 	
_patientService 
= 
patientService ,
;, -
} 	
[ 	
HttpGet	 
( 
$str 
) 
] 
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
>' (
GetPatientById) 7
(7 8
int8 ;
id< >
)> ?
{ 	
var 
result 
= 
await 
_patientService .
.. /
GetByIdAsync/ ;
(; <
id< >
)> ?
;? @
return 
Ok 
( 
result 
) 
; 
} 	
[ 	
HttpGet	 
( 
$str 
) 
] 
[ 	
	Authorize	 
( !
AuthenticationSchemes (
=) *
JwtBearerDefaults+ <
.< = 
AuthenticationScheme= Q
)Q R
]R S
[ 	
	Authorize	 
( 
Roles 
= 
$str "
)" #
]# $
public   
async   
Task   
<   
IActionResult   '
>  ' (
GetAllPatient  ) 6
(  6 7
[  7 8
	FromQuery  8 A
]  A B
PatientFilter  C P
filter  Q W
)  W X
{!! 	
if"" 
("" 
!"" 

ModelState"" 
."" 
IsValid"" #
)""# $
return## 

BadRequest## !
(##! "

ModelState##" ,
)##, -
;##- .
var%% 
result%% 
=%% 
await%% 
_patientService%% .
.%%. /
GetAllAsync%%/ :
(%%: ;
filter%%; A
)%%A B
;%%B C
return&& 
Ok&& 
(&& 
result&& 
)&& 
;&& 
}'' 	
[)) 	
HttpPut))	 
()) 
$str)) 
))) 
])) 
[** 	
	Authorize**	 
(** !
AuthenticationSchemes** (
=**) *
JwtBearerDefaults**+ <
.**< = 
AuthenticationScheme**= Q
)**Q R
]**R S
[++ 	
	Authorize++	 
(++ 
Roles++ 
=++ 
$str++ "
)++" #
]++# $
public,, 
async,, 
Task,, 
<,, 
IActionResult,, '
>,,' (
UpdatePatient,,) 6
(,,6 7
int,,7 :
id,,; =
,,,= >
[,,? @
FromBody,,@ H
],,H I
UpdatePatientDto,,J Z
dto,,[ ^
),,^ _
{-- 	
if.. 
(.. 
!.. 

ModelState.. 
... 
IsValid.. #
)..# $
return// 

BadRequest// !
(//! "

ModelState//" ,
)//, -
;//- .
var11 
patient11 
=11 
await11 
_patientService11  /
.11/ 0
GetByIdAsync110 <
(11< =
id11= ?
)11? @
;11@ A
if33 
(33 
patient33 
==33 
null33 
)33  
return44 
NotFound44 
(44  
$str44  3
)443 4
;444 5
await66 
_patientService66 !
.66! "
UpdateAsync66" -
(66- .
id66. 0
,660 1
dto662 5
)665 6
;666 7
return88 
Ok88 
(88 
new88 
{88 
message88 #
=88$ %
$str88& D
}88E F
)88F G
;88G H
}99 	
[;; 	
	HttpPatch;;	 
(;; 
$str;;  
);;  !
];;! "
[<< 	
	Authorize<<	 
(<< !
AuthenticationSchemes<< (
=<<) *
JwtBearerDefaults<<+ <
.<<< = 
AuthenticationScheme<<= Q
)<<Q R
]<<R S
[== 	
	Authorize==	 
(== 
Roles== 
=== 
$str== "
)==" #
]==# $
public>> 
async>> 
Task>> 
<>> 
IActionResult>> '
>>>' (
UpdatePatientStatus>>) <
(>>< =
int>>= @
id>>A C
,>>C D
[>>E F
FromBody>>F N
]>>N O
bool>>P T
isActive>>U ]
)>>] ^
{?? 	
await@@ 
_patientService@@ !
.@@! "
UpdateStatusAsync@@" 3
(@@3 4
id@@4 6
,@@6 7
isActive@@8 @
)@@@ A
;@@A B
returnAA 
OkAA 
(AA 
newAA 
{AA 
messageAA #
=AA$ %
$strAA& K
}AAL M
)AAM N
;AAN O
}BB 	
[DD 	

HttpDeleteDD	 
(DD 
$strDD 
)DD 
]DD 
[EE 	
	AuthorizeEE	 
(EE !
AuthenticationSchemesEE (
=EE) *
JwtBearerDefaultsEE+ <
.EE< = 
AuthenticationSchemeEE= Q
)EEQ R
]EER S
[FF 	
	AuthorizeFF	 
(FF 
RolesFF 
=FF 
$strFF "
)FF" #
]FF# $
publicGG 
asyncGG 
TaskGG 
<GG 
IActionResultGG '
>GG' (
DeletePatientGG) 6
(GG6 7
intGG7 :
idGG; =
)GG= >
{HH 	
awaitII 
_patientServiceII !
.II! "
DeleteAsyncII" -
(II- .
idII. 0
)II0 1
;II1 2
returnJJ 
OkJJ 
(JJ 
newJJ 
{JJ 
messageJJ #
=JJ$ %
$strJJ& D
}JJE F
)JJF G
;JJG H
}KK 	
[NN 	
HttpGetNN	 
(NN 
$strNN 
)NN  
]NN  !
[OO 	
	AuthorizeOO	 
(OO !
AuthenticationSchemesOO (
=OO) *
JwtBearerDefaultsOO+ <
.OO< = 
AuthenticationSchemeOO= Q
)OOQ R
]OOR S
[PP 	
	AuthorizePP	 
(PP 
RolesPP 
=PP 
$strPP "
)PP" #
]PP# $
publicQQ 
asyncQQ 
TaskQQ 
<QQ 
IActionResultQQ '
>QQ' (!
GetRecentPatientCountQQ) >
(QQ> ?
)QQ? @
{RR 	
varSS 
resultSS 
=SS 
awaitSS 
_patientServiceSS .
.SS. /!
GetRecentPatientCountSS/ D
(SSD E
)SSE F
;SSF G
returnTT 
OkTT 
(TT 
resultTT 
)TT 
;TT 
}UU 	
}VV 
}WW ™5
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
( 
new 
{ 
message "
=# $
$str% H
}H I
)I J
;J K
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
}22 	
[44 	
HttpGet44	 
(44 
$str44 "
)44" #
]44# $
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
>77' (
GetRecordsByPatient77) <
(77< =
int77= @
id77A C
)77C D
{88 	
var99 
result99 
=99 
await99  
_healthRecordService99 3
.993 4$
GetHealthRecordByPatient994 L
(99L M
id99M O
)99O P
;99P Q
return:: 
Ok:: 
(:: 
result:: 
):: 
;:: 
};; 	
private== 
int== "
GetPatientIdFromClaims== *
(==* +
)==+ ,
{>> 	
var?? 
claim?? 
=?? 
User?? 
.?? 
	FindFirst?? &
(??& '
$str??' 2
)??2 3
??@@ 
throw@@ 
new@@ %
InvalidOperationException@@ 6
(@@6 7
$str@@7 \
)@@\ ]
;@@] ^
returnBB 
intBB 
.BB 
ParseBB 
(BB 
claimBB "
.BB" #
ValueBB# (
)BB( )
;BB) *
}CC 	
privateEE 
intEE !
GetDoctorIdFromClaimsEE )
(EE) *
)EE* +
{FF 	
varGG 
claimGG 
=GG 
UserGG 
.GG 
	FindFirstGG &
(GG& '
$strGG' 1
)GG1 2
??HH 
throwHH 
newHH %
InvalidOperationExceptionHH 6
(HH6 7
$strHH7 [
)HH[ \
;HH\ ]
returnJJ 
intJJ 
.JJ 
ParseJJ 
(JJ 
claimJJ "
.JJ" #
ValueJJ# (
)JJ( )
;JJ) *
}KK 	
}LL 
}MM ˆ=
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
((( 
new(( 
{(( 
message(( "
=((# $
$str((% J
}((J K
)((K L
;((L M
})) 	
[++ 	
HttpPost++	 
(++ 
$str++ 
)++ 
]++ 
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
$str-- #
)--# $
]--$ %
public.. 
async.. 
Task.. 
<.. 
IActionResult.. '
>..' (
AddDoctorLeaves..) 8
(..8 9
[..9 :
FromBody..: B
]..B C
List..D H
<..H I
CreateLeaveDto..I W
>..W X
leaves..Y _
).._ `
{// 	
if00 
(00 
!00 

ModelState00 
.00 
IsValid00 #
)00# $
return11 

BadRequest11 !
(11! "

ModelState11" ,
)11, -
;11- .
var33 
doctorId33 
=33 !
GetDoctorIdFromClaims33 0
(330 1
)331 2
;332 3
await44 
_doctorService44  
.44  !
CreateLeave44! ,
(44, -
doctorId44- 5
,445 6
leaves447 =
)44= >
;44> ?
return55 
Ok55 
(55 
new55 
{55 
message55 "
=55# $
$str55% @
}55@ A
)55A B
;55B C
}66 	
[88 	
HttpGet88	 
(88 
$str88 
)88 
]88 
[99 	
	Authorize99	 
(99 !
AuthenticationSchemes99 (
=99) *
JwtBearerDefaults99+ <
.99< = 
AuthenticationScheme99= Q
)99Q R
]99R S
[:: 	
	Authorize::	 
(:: 
Roles:: 
=:: 
$str:: $
)::$ %
]::% &
public;; 
async;; 
Task;; 
<;; 
IActionResult;; '
>;;' (
GetAvailableDoctors;;) <
(;;< =
[;;= >
	FromQuery;;> G
];;G H
string;;I O
specialisation;;P ^
,;;^ _
[;;` a
	FromQuery;;a j
];;j k
DateOnly;;l t
date;;u y
);;y z
{<< 	
var== 
result== 
=== 
await== 
_doctorService== -
.==- .
AvailableDoctors==. >
(==> ?
specialisation==? M
,==M N
date==O S
)==S T
;==T U
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
[II 	
HttpGetII	 
(II 
$strII 
)II 
]II 
[JJ 	
	AuthorizeJJ	 
(JJ !
AuthenticationSchemesJJ (
=JJ) *
JwtBearerDefaultsJJ+ <
.JJ< = 
AuthenticationSchemeJJ= Q
)JJQ R
]JJR S
[KK 	
	AuthorizeKK	 
(KK 
RolesKK 
=KK 
$strKK #
)KK# $
]KK$ %
publicLL 
asyncLL 
TaskLL 
<LL 
IActionResultLL '
>LL' (
GetDashboardLL) 5
(LL5 6
)LL6 7
{MM 	
varNN 
doctorIdNN 
=NN !
GetDoctorIdFromClaimsNN 0
(NN0 1
)NN1 2
;NN2 3
varPP 
dataPP 
=PP 
awaitPP 
_doctorServicePP +
.PP+ ,
GetDashboardAsyncPP, =
(PP= >
doctorIdPP> F
)PPF G
;PPG H
returnRR 
OkRR 
(RR 
dataRR 
)RR 
;RR 
}SS 	
}TT 
}UU á;
gC:\Users\310055\source\repos\UST-Live-01\HealthCare\HealthCare.Api\Controllers\DoctorAdminController.cs
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
class !
DoctorAdminController &
:' (
ControllerBase) 7
{ 
private 
readonly 
IDoctorService '
_doctorService( 6
;6 7
public !
DoctorAdminController $
($ %
IDoctorService% 3
doctorService4 A
)A B
{ 	
_doctorService 
= 
doctorService *
;* +
} 	
[ 	
HttpGet	 
( 
$str 
) 
] 
public 
async 
Task 
< 
IActionResult '
>' (
GetDoctorById) 6
(6 7
int7 :
id; =
)= >
{ 	
var 
result 
= 
await 
_doctorService -
.- .
GetByIdAsync. :
(: ;
id; =
)= >
;> ?
if 
( 
result 
== 
null 
) 
{ 
return 
NotFound 
(  
)  !
;! "
} 
return 
Ok 
( 
result 
) 
; 
} 	
["" 	
HttpGet""	 
("" 
$str"" 
)"" 
]"" 
[## 	
	Authorize##	 
(## !
AuthenticationSchemes## (
=##) *
JwtBearerDefaults##+ <
.##< = 
AuthenticationScheme##= Q
)##Q R
]##R S
[$$ 	
	Authorize$$	 
($$ 
Roles$$ 
=$$ 
$str$$ "
)$$" #
]$$# $
public%% 
async%% 
Task%% 
<%% 
IActionResult%% '
>%%' (
GetAllDoctor%%) 5
(%%5 6
[%%6 7
	FromQuery%%7 @
]%%@ A
DoctorFilter%%B N
filter%%O U
)%%U V
{&& 	
if'' 
('' 
!'' 

ModelState'' 
.'' 
IsValid'' #
)''# $
return(( 

BadRequest(( !
(((! "

ModelState((" ,
)((, -
;((- .
var** 
result** 
=** 
await** 
_doctorService** -
.**- .
GetAllAsync**. 9
(**9 :
filter**: @
)**@ A
;**A B
return++ 
Ok++ 
(++ 
result++ 
)++ 
;++ 
},, 	
[.. 	
HttpPut..	 
(.. 
$str.. 
).. 
].. 
[// 	
	Authorize//	 
(// !
AuthenticationSchemes// (
=//) *
JwtBearerDefaults//+ <
.//< = 
AuthenticationScheme//= Q
)//Q R
]//R S
[00 	
	Authorize00	 
(00 
Roles00 
=00 
$str00 "
)00" #
]00# $
public11 
async11 
Task11 
<11 
IActionResult11 '
>11' (
UpdateDoctor11) 5
(115 6
int116 9
id11: <
,11< =
[11> ?
FromBody11? G
]11G H
UpdateDoctorDto11I X
dto11Y \
)11\ ]
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
;44- .
await66 
_doctorService66  
.66  !
UpdateAsync66! ,
(66, -
id66- /
,66/ 0
dto661 4
)664 5
;665 6
return77 
Ok77 
(77 
new77 
{77 
message77 #
=77$ %
$str77& C
}77D E
)77E F
;77F G
}88 	
[:: 	
	HttpPatch::	 
(:: 
$str::  
)::  !
]::! "
[;; 	
	Authorize;;	 
(;; !
AuthenticationSchemes;; (
=;;) *
JwtBearerDefaults;;+ <
.;;< = 
AuthenticationScheme;;= Q
);;Q R
];;R S
[<< 	
	Authorize<<	 
(<< 
Roles<< 
=<< 
$str<< "
)<<" #
]<<# $
public== 
async== 
Task== 
<== 
IActionResult== '
>==' (
UpdateDoctorStatus==) ;
(==; <
int==< ?
id==@ B
,==B C
[==D E
FromBody==E M
]==M N
bool==O S
isActive==T \
)==\ ]
{>> 	
await?? 
_doctorService??  
.??  !
UpdateStatusAsync??! 2
(??2 3
id??3 5
,??5 6
isActive??7 ?
)??? @
;??@ A
return@@ 
Ok@@ 
(@@ 
new@@ 
{@@ 
message@@ #
=@@$ %
$str@@& J
}@@K L
)@@L M
;@@M N
}AA 	
[CC 	

HttpDeleteCC	 
(CC 
$strCC 
)CC 
]CC 
[DD 	
	AuthorizeDD	 
(DD !
AuthenticationSchemesDD (
=DD) *
JwtBearerDefaultsDD+ <
.DD< = 
AuthenticationSchemeDD= Q
)DDQ R
]DDR S
[EE 	
	AuthorizeEE	 
(EE 
RolesEE 
=EE 
$strEE "
)EE" #
]EE# $
publicFF 
asyncFF 
TaskFF 
<FF 
IActionResultFF '
>FF' (
DeleteDoctorFF) 5
(FF5 6
intFF6 9
idFF: <
)FF< =
{GG 	
awaitHH 
_doctorServiceHH  
.HH  !
DeleteAsyncHH! ,
(HH, -
idHH- /
)HH/ 0
;HH0 1
returnII 
OkII 
(II 
newII 
{II 
messageII #
=II$ %
$strII& C
}IID E
)IIE F
;IIF G
}JJ 	
[LL 	
HttpGetLL	 
(LL 
$strLL 
)LL 
]LL 
[MM 	
	AuthorizeMM	 
(MM !
AuthenticationSchemesMM (
=MM) *
JwtBearerDefaultsMM+ <
.MM< = 
AuthenticationSchemeMM= Q
)MMQ R
]MMR S
[NN 	
	AuthorizeNN	 
(NN 
RolesNN 
=NN 
$strNN "
)NN" #
]NN# $
publicOO 
asyncOO 
TaskOO 
<OO 
IActionResultOO '
>OO' (

GetSummaryOO) 3
(OO3 4
)OO4 5
{PP 	
varQQ 
resultQQ 
=QQ 
awaitQQ 
_doctorServiceQQ -
.QQ- .
GetSummaryAsyncQQ. =
(QQ= >
)QQ> ?
;QQ? @
returnRR 
OkRR 
(RR 
resultRR 
)RR 
;RR 
}SS 	
}TT 
}UU ñ5
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
{ 	
try 
{ 
await 
_authService "
." # 
RegisterPatientAsync# 7
(7 8
dto8 ;
); <
;< =
return 
Ok 
( 
new 
{ 
message  '
=( )
$str* C
}D E
)E F
;F G
}   
catch!! 
(!! %
InvalidOperationException!! ,
ex!!- /
)!!/ 0
{"" 
return## 

BadRequest## !
(##! "
new##" %
{##& '
message##( /
=##0 1
ex##2 4
.##4 5
Message##5 <
}##= >
)##> ?
;##? @
}$$ 
catch%% 
(%% 
	Exception%% 
ex%% 
)%%  
{&& 
return'' 

StatusCode'' !
(''! "
$num''" %
,''% &
new''' *
{''+ ,
message''- 4
=''5 6
ex''7 9
.''9 :
Message'': A
}''B C
)''C D
;''D E
}(( 
})) 	
[,, 	
HttpPost,,	 
(,, 
$str,, #
),,# $
],,$ %
[-- 	
	Authorize--	 
(-- !
AuthenticationSchemes-- (
=--) *
JwtBearerDefaults--+ <
.--< = 
AuthenticationScheme--= Q
)--Q R
]--R S
[.. 	
	Authorize..	 
(.. 
Roles.. 
=.. 
$str.. "
).." #
]..# $
public// 
async// 
Task// 
<// 
IActionResult// '
>//' (
RegisterDoctor//) 7
(//7 8
CreateDoctorDto//8 G
dto//H K
)//K L
{00 	
try11 
{22 
await33 
_authService33 "
.33" #
RegisterDoctorAsync33# 6
(336 7
dto337 :
)33: ;
;33; <
return55 
Ok55 
(55 
new55 
{55 
message55  '
=55( )
$str55* C
}55D E
)55E F
;55F G
}66 
catch77 
(77 %
InvalidOperationException77 ,
ex77- /
)77/ 0
{88 
return99 

BadRequest99 !
(99! "
ex99" $
.99$ %
Message99% ,
)99, -
;99- .
}:: 
catch;; 
(;; 
	Exception;; 
);; 
{<< 
return== 

StatusCode== !
(==! "
$num==" %
,==% &
$str==' =
)=== >
;==> ?
}>> 
}?? 	
[BB 	
HttpPostBB	 
(BB 
$strBB 
)BB 
]BB 
publicCC 
asyncCC 
TaskCC 
<CC 
IActionResultCC '
>CC' (
LoginCC) .
(CC. /
LoginDtoCC/ 7
dtoCC8 ;
)CC; <
{DD 	
tryEE 
{FF 
varGG 
responseGG 
=GG 
awaitGG $
_authServiceGG% 1
.GG1 2

LoginAsyncGG2 <
(GG< =
dtoGG= @
)GG@ A
;GGA B
returnHH 
OkHH 
(HH 
responseHH "
)HH" #
;HH# $
}II 
catchJJ 
(JJ '
UnauthorizedAccessExceptionJJ .
)JJ. /
{KK 
returnLL 
UnauthorizedLL #
(LL# $
$strLL$ ?
)LL? @
;LL@ A
}MM 
catchNN 
(NN %
InvalidOperationExceptionNN ,
exNN- /
)NN/ 0
{OO 
returnPP 

BadRequestPP !
(PP! "
exPP" $
.PP$ %
MessagePP% ,
)PP, -
;PP- .
}QQ 
catchRR 
(RR 
	ExceptionRR 
)RR 
{SS 
returnTT 

StatusCodeTT !
(TT! "
$numTT" %
,TT% &
$strTT' =
)TT= >
;TT> ?
}UU 
}VV 	
[XX 	
HttpPostXX	 
(XX 
$strXX #
)XX# $
]XX$ %
[YY 	
	AuthorizeYY	 
(YY !
AuthenticationSchemesYY (
=YY) *
JwtBearerDefaultsYY+ <
.YY< = 
AuthenticationSchemeYY= Q
)YYQ R
]YYR S
publicZZ 
asyncZZ 
TaskZZ 
<ZZ 
IActionResultZZ '
>ZZ' (
ChangePasswordZZ) 7
(ZZ7 8
ChangePasswordDtoZZ8 I
dtoZZJ M
)ZZM N
{[[ 	
if\\ 
(\\ 
!\\ 

ModelState\\ 
.\\ 
IsValid\\ #
)\\# $
return]] 

BadRequest]] !
(]]! "

ModelState]]" ,
)]], -
;]]- .
var__ 
userId__ 
=__ 
User__ 
.__ 
	FindFirst__ '
(__' (

ClaimTypes__( 2
.__2 3
NameIdentifier__3 A
)__A B
?__B C
.__C D
Value__D I
;__I J
awaitaa 
_authServiceaa 
.aa 
ChangePasswordAsyncaa 2
(aa2 3
userIdaa3 9
!aa9 :
,aa: ;
dtoaa< ?
)aa? @
;aa@ A
returncc 
Okcc 
(cc 
$strcc 5
)cc5 6
;cc6 7
}dd 	
}ff 
}gg ÊU
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
( 
new 
{ 
message "
=# $
$str% G
}G H
)H I
;I J
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
(** 
new** 
{** 
message** "
=**# $
$str**% N
}**N O
)**O P
;**P Q
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
[ee 	
HttpGetee	 
(ee 
$stree 
)ee 
]ee 
[ff 	
	Authorizeff	 
(ff !
AuthenticationSchemesff (
=ff) *
JwtBearerDefaultsff+ <
.ff< = 
AuthenticationSchemeff= Q
)ffQ R
]ffR S
[gg 	
	Authorizegg	 
(gg 
Rolesgg 
=gg 
$strgg $
)gg$ %
]gg% &
publichh 
asynchh 
Taskhh 
<hh 
IActionResulthh '
>hh' (
GetAvailableSlotshh) :
(hh: ;
[ii 
	FromQueryii 
]ii 
DateOnlyii 
dateii 
,ii 
[jj 
	FromQueryjj 
]jj 
intjj 
doctorIdjj 
)jj 
{kk 	
varll 
slotsll 
=ll 
awaitll 
_appointmentServicell 1
.ll1 2
AvailableTimeSlotsll2 D
(llD E
datellE I
,llI J
doctorIdllK S
)llS T
;llT U
returnmm 
Okmm 
(mm 
slotsmm 
)mm 
;mm 
}nn 	
}oo 
}pp ø+
lC:\Users\310055\source\repos\UST-Live-01\HealthCare\HealthCare.Api\Controllers\AppointmentAdminController.cs
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
$str		 #
)		# $
]		$ %
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
class &
AppointmentAdminController +
:, -
ControllerBase. <
{ 
private 
readonly 
IAppointmentService ,
_appointmentService- @
;@ A
public &
AppointmentAdminController )
() *
IAppointmentService* =
appointmentService> P
)P Q
{ 	
_appointmentService 
=  !
appointmentService" 4
;4 5
} 	
[ 	
HttpGet	 
( 
$str 
) 
] 
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
GetAllAppointment) :
(: ;
[; <
	FromQuery< E
]E F
AppointmentFilterG X
filterY _
)_ `
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
var 
result 
= 
await 
_appointmentService 2
.2 3
GetAllAsync3 >
(> ?
filter? E
)E F
;F G
return 
Ok 
( 
result 
) 
; 
} 	
[   	
HttpGet  	 
(   
$str   
)    
]    !
[!! 	
	Authorize!!	 
(!! !
AuthenticationSchemes!! (
=!!) *
JwtBearerDefaults!!+ <
.!!< = 
AuthenticationScheme!!= Q
)!!Q R
]!!R S
["" 	
	Authorize""	 
("" 
Roles"" 
="" 
$str"" "
)""" #
]""# $
public## 
async## 
Task## 
<## 
IActionResult## '
>##' (
GetDailyReport##) 7
(##7 8
)##8 9
{$$ 	
var%% 
result%% 
=%% 
await%% 
_appointmentService%% 2
.%%2 3
GetDailyReport%%3 A
(%%A B
)%%B C
;%%C D
return&& 
Ok&& 
(&& 
result&& 
)&& 
;&& 
}'' 	
[)) 	
HttpGet))	 
()) 
$str)) 
))) 
])) 
[** 	
	Authorize**	 
(** !
AuthenticationSchemes** (
=**) *
JwtBearerDefaults**+ <
.**< = 
AuthenticationScheme**= Q
)**Q R
]**R S
[++ 	
	Authorize++	 
(++ 
Roles++ 
=++ 
$str++ "
)++" #
]++# $
public,, 
async,, 
Task,, 
<,, 
IActionResult,, '
>,,' (
	GetReport,,) 2
(,,2 3
[-- 	
	FromQuery--	 
]-- 
DateOnly-- 
	startDate-- &
,--& '
[.. 	
	FromQuery..	 
].. 
DateOnly.. 
endDate.. $
)..$ %
{// 	
if00 
(00 
	startDate00 
>00 
endDate00 #
)00# $
return11 

BadRequest11 !
(11! "
$str11" O
)11O P
;11P Q
var33 
result33 
=33 
await33 
_appointmentService33 2
.332 3 
GetReportByDateRange333 G
(33G H
	startDate33H Q
,33Q R
endDate33S Z
)33Z [
;33[ \
return55 
Ok55 
(55 
result55 
)55 
;55 
}66 	
[88 	
HttpGet88	 
(88 
$str88 
)88 
]88 
[99 	
	Authorize99	 
(99 !
AuthenticationSchemes99 (
=99) *
JwtBearerDefaults99+ <
.99< = 
AuthenticationScheme99= Q
)99Q R
]99R S
[:: 	
	Authorize::	 
(:: 
Roles:: 
=:: 
$str:: "
)::" #
]::# $
public;; 
async;; 
Task;; 
<;; 
IActionResult;; '
>;;' (

GetSummary;;) 3
(;;3 4
);;4 5
{<< 	
var== 
result== 
=== 
await== 
_appointmentService== 2
.==2 3
GetSummaryAsync==3 B
(==B C
)==C D
;==D E
return>> 
Ok>> 
(>> 
result>> 
)>> 
;>> 
}?? 	
}BB 
}CC º"
sC:\Users\310055\source\repos\UST-Live-01\HealthCare\HealthCare.Api\BackgroundServices\NotificationCleanupService.cs
	namespace 	

HealthCare
 
. 
Api 
. 
BackgroundServices +
{ 
public 

class &
NotificationCleanupService +
:, -
BackgroundService. ?
{ 
private 
readonly 
ILogger  
<  !&
NotificationCleanupService! ;
>; <
_logger= D
;D E
private		 
readonly		  
IServiceScopeFactory		 -
_scopeFactory		. ;
;		; <
public &
NotificationCleanupService )
() *
ILogger 
< &
NotificationCleanupService .
>. /
logger0 6
,6 7 
IServiceScopeFactory  
scopeFactory! -
)- .
{ 	
_logger 
= 
logger 
; 
_scopeFactory 
= 
scopeFactory (
;( )
} 	
	protected 
override 
async  
Task! %
ExecuteAsync& 2
(2 3
CancellationToken3 D
stoppingTokenE R
)R S
{ 	
_logger 
. 
LogInformation "
(" #
$str# H
)H I
;I J
while 
( 
! 
stoppingToken !
.! "#
IsCancellationRequested" 9
)9 :
{ 
try 
{ 
await 
Task 
. 
Delay $
($ %
TimeSpan% -
.- .
	FromHours. 7
(7 8
$num8 9
)9 :
,: ;
stoppingToken< I
)I J
;J K
if 
( 
stoppingToken %
.% &#
IsCancellationRequested& =
)= >
break 
; 
await   #
CleanupOldNotifications   1
(  1 2
stoppingToken  2 ?
)  ? @
;  @ A
}!! 
catch"" 
("" &
OperationCanceledException"" 1
)""1 2
{## 
break$$ 
;$$ 
}%% 
}&& 
_logger(( 
.(( 
LogInformation(( "
(((" #
$str((# H
)((H I
;((I J
})) 	
private++ 
async++ 
Task++ #
CleanupOldNotifications++ 2
(++2 3
CancellationToken++3 D
ct++E G
)++G H
{,, 	
using-- 
(-- 
var-- 
scope-- 
=-- 
_scopeFactory-- ,
.--, -
CreateScope--- 8
(--8 9
)--9 :
)--: ;
{.. 
var// 
	dbContext// 
=// 
scope//  %
.//% &
ServiceProvider//& 5
.00 
GetRequiredService00 '
<00' (
HealthCareDbContext00( ;
>00; <
(00< =
)00= >
;00> ?
var22 
cutoff22 
=22 
DateTime22 %
.22% &
UtcNow22& ,
.22, -
AddDays22- 4
(224 5
-225 6
$num226 8
)228 9
;229 :
var44 
deletedCount44  
=44! "
await44# (
	dbContext44) 2
.442 3
Notifications443 @
.55 
Where55 
(55 
n55 
=>55 
n55  !
.55! "
CreatedDate55" -
<55. /
cutoff550 6
)556 7
.66 
ExecuteDeleteAsync66 '
(66' (
ct66( *
)66* +
;66+ ,
if88 
(88 
deletedCount88  
>88! "
$num88# $
&&88% '
_logger88( /
.88/ 0
	IsEnabled880 9
(889 :
LogLevel88: B
.88B C
Information88C N
)88N O
)88O P
_logger99 
.99 
LogInformation99 *
(99* +
$str:: Y
,::Y Z
deletedCount;; $
,;;$ %
cutoff;;& ,
);;, -
;;;- .
}<< 
}== 	
}>> 
}?? 