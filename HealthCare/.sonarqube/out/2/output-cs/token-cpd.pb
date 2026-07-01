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
	interface 
IDoctorService #
{ 
Task 
< 
DoctorListDto 
? 
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
<		 
DoctorListDto		 &
>		& '
>		' (
GetAllAsync		) 4
(		4 5
DoctorFilter		5 A
filter		B H
)		H I
;		I J
Task

 
AddAsync

 
(

 
CreateDoctorDto

 %
dto

& )
)

) *
;

* +
Task 
UpdateAsync 
( 
int 
id 
,  
UpdateDoctorDto! 0
dto1 4
)4 5
;5 6
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
> 
GetSlots #
(# $
int$ '
doctorId( 0
)0 1
;1 2
Task 
UpdateStatusAsync 
( 
int "
id# %
,% &
bool' +
isActive, 4
)4 5
;5 6
Task 
CreateSlots 
( 
int 
id 
,  
List! %
<% &
string& ,
>, -
	timeslots. 7
)7 8
;8 9
Task 
<  
CreateLeaveResultDto !
>! "
CreateLeave# .
(. /
int/ 2
id3 5
,5 6
List7 ;
<; <
CreateLeaveDto< J
>J K
leavesL R
)R S
;S T
Task 
< '
AvailableDoctorsResponseDto (
>( )
AvailableDoctors* :
(: ;
string; A
specialisationB P
,P Q
DateOnlyR Z
date[ _
)_ `
;` a
Task 
< 
DoctorSummaryDto 
> 
GetSummaryAsync .
(. /
)/ 0
;0 1
Task 
< 
DoctorDashboardDto 
>  
GetDashboardAsync! 2
(2 3
int3 6
doctorId7 ?
)? @
;@ A
} 
} ·	
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
} ªo
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
if33 
(33 
filter33 
.33 
HasInsurance33 #
.33# $
HasValue33$ ,
)33, -
{44 
if55 
(55 
filter55 
.55 
HasInsurance55 '
.55' (
Value55( -
)55- .
{66 
	predicate77 
=77 
p77  !
=>77" $
p88 
.88 
InsuranceId88 %
!=88& (
null88) -
;88- .
}99 
else:: 
{;; 
	predicate<< 
=<< 
p<<  !
=><<" $
p== 
.== 
InsuranceId== %
====& (
null==) -
;==- .
}>> 
}?? 
ifBB 
(BB 
!BB 
stringBB 
.BB 
IsNullOrWhiteSpaceBB *
(BB* +
filterBB+ 1
.BB1 2
FullNameBB2 :
)BB: ;
)BB; <
{CC 
varDD 
searchDD 
=DD 
filterDD #
.DD# $
FullNameDD$ ,
.DD, -
TrimDD- 1
(DD1 2
)DD2 3
;DD3 4
ifFF 
(FF 
filterFF 
.FF 
HasInsuranceFF '
.FF' (
HasValueFF( 0
)FF0 1
{GG 
ifHH 
(HH 
filterHH 
.HH 
HasInsuranceHH +
.HH+ ,
ValueHH, 1
)HH1 2
{II 
	predicateJJ !
=JJ" #
pJJ$ %
=>JJ& (
pKK 
.KK 
InsuranceIdKK )
!=KK* ,
nullKK- 1
&&KK2 4
pLL 
.LL 
FullNameLL &
!=LL' )
nullLL* .
&&LL/ 1
EFMM 
.MM 
	FunctionsMM (
.MM( )
LikeMM) -
(MM- .
pMM. /
.MM/ 0
FullNameMM0 8
,MM8 9
$"MM: <
$strMM< =
{MM= >
searchMM> D
}MMD E
$strMME F
"MMF G
)MMG H
;MMH I
}NN 
elseOO 
{PP 
	predicateQQ !
=QQ" #
pQQ$ %
=>QQ& (
pRR 
.RR 
InsuranceIdRR )
==RR* ,
nullRR- 1
&&RR2 4
pSS 
.SS 
FullNameSS &
!=SS' )
nullSS* .
&&SS/ 1
EFTT 
.TT 
	FunctionsTT (
.TT( )
LikeTT) -
(TT- .
pTT. /
.TT/ 0
FullNameTT0 8
,TT8 9
$"TT: <
$strTT< =
{TT= >
searchTT> D
}TTD E
$strTTE F
"TTF G
)TTG H
;TTH I
}UU 
}VV 
elseWW 
{XX 
	predicateYY 
=YY 
pYY  !
=>YY" $
pZZ 
.ZZ 
FullNameZZ "
!=ZZ# %
nullZZ& *
&&ZZ+ -
EF[[ 
.[[ 
	Functions[[ $
.[[$ %
Like[[% )
([[) *
p[[* +
.[[+ ,
FullName[[, 4
,[[4 5
$"[[6 8
$str[[8 9
{[[9 :
search[[: @
}[[@ A
$str[[A B
"[[B C
)[[C D
;[[D E
}\\ 
}]] 
var__ 
pagedResult__ 
=__ 
await__ #
_repository__$ /
.__/ 0
GetAllAsync__0 ;
(__; <
filter`` 
.`` 

PageNumber`` !
,``! "
filteraa 
.aa 
PageSizeaa 
,aa  
	predicatebb 
)cc 
;cc 
returnee 
newee 
PagedResultee "
<ee" #
PatientListDtoee# 1
>ee1 2
{ff 
Itemsgg 
=gg 
_mappergg 
.gg  
Mapgg  #
<gg# $
IEnumerablegg$ /
<gg/ 0
PatientListDtogg0 >
>gg> ?
>gg? @
(gg@ A
pagedResultggA L
.ggL M
ItemsggM R
)ggR S
,ggS T

PageNumberhh 
=hh 
pagedResulthh (
.hh( )

PageNumberhh) 3
,hh3 4
PageSizeii 
=ii 
pagedResultii &
.ii& '
PageSizeii' /
,ii/ 0

TotalCountjj 
=jj 
pagedResultjj (
.jj( )

TotalCountjj) 3
}kk 
;kk 
}ll 	
publicnn 
asyncnn 
Tasknn 
UpdateAsyncnn %
(nn% &
intnn& )
idnn* ,
,nn, -
UpdatePatientDtonn. >
dtonn? B
)nnB C
{oo 	
varpp 
patientpp 
=pp 
awaitpp 
_repositorypp  +
.pp+ ,
GetByIdAsyncpp, 8
(pp8 9
idpp9 ;
)pp; <
;pp< =
ifrr 
(rr 
patientrr 
isrr 
nullrr 
)rr  
throwss 
newss %
InvalidOperationExceptionss 3
(ss3 4
NotFoundMessagess4 C
)ssC D
;ssD E
_mapperuu 
.uu 
Mapuu 
(uu 
dtouu 
,uu 
patientuu $
)uu$ %
;uu% &
awaitww 
_repositoryww 
.ww 
UpdateAsyncww )
(ww) *
patientww* 1
)ww1 2
;ww2 3
awaitxx 
_contextxx 
.xx 
SaveChangesAsyncxx +
(xx+ ,
)xx, -
;xx- .
}yy 	
public{{ 
async{{ 
Task{{ 
UpdateStatusAsync{{ +
({{+ ,
int{{, /
id{{0 2
,{{2 3
bool{{4 8
isActive{{9 A
){{A B
{|| 	
var}} 
patient}} 
=}} 
await}} 
_repository}}  +
.}}+ ,
GetByIdAsync}}, 8
(}}8 9
id}}9 ;
)}}; <
;}}< =
if 
( 
patient 
is 
null 
)  
throw
ÄÄ 
new
ÄÄ '
InvalidOperationException
ÄÄ 3
(
ÄÄ3 4
NotFoundMessage
ÄÄ4 C
)
ÄÄC D
;
ÄÄD E
patient
ÇÇ 
.
ÇÇ 
IsActive
ÇÇ 
=
ÇÇ 
isActive
ÇÇ '
;
ÇÇ' (
await
ÑÑ 
_repository
ÑÑ 
.
ÑÑ 
UpdateAsync
ÑÑ )
(
ÑÑ) *
patient
ÑÑ* 1
)
ÑÑ1 2
;
ÑÑ2 3
await
ÖÖ 
_context
ÖÖ 
.
ÖÖ 
SaveChangesAsync
ÖÖ +
(
ÖÖ+ ,
)
ÖÖ, -
;
ÖÖ- .
}
ÜÜ 	
public
àà 
async
àà 
Task
àà 
DeleteAsync
àà %
(
àà% &
int
àà& )
id
àà* ,
)
àà, -
{
ââ 	
var
ää 
patient
ää 
=
ää 
await
ää 
_repository
ää  +
.
ää+ ,
GetByIdAsync
ää, 8
(
ää8 9
id
ää9 ;
)
ää; <
;
ää< =
if
åå 
(
åå 
patient
åå 
is
åå 
null
åå 
)
åå  
throw
çç 
new
çç '
InvalidOperationException
çç 3
(
çç3 4
NotFoundMessage
çç4 C
)
ççC D
;
ççD E
try
èè 
{
êê 
await
ëë 
_repository
ëë !
.
ëë! "
DeleteAsync
ëë" -
(
ëë- .
id
ëë. 0
)
ëë0 1
;
ëë1 2
await
íí 
_context
íí 
.
íí 
SaveChangesAsync
íí /
(
íí/ 0
)
íí0 1
;
íí1 2
}
ìì 
catch
îî 
(
îî 
DbUpdateException
îî $
ex
îî% '
)
îî' (
{
ïï 
throw
ññ 
new
ññ '
InvalidOperationException
ññ 3
(
ññ3 4
$strññ4 ê
,ññê ë
exññí î
)ññî ï
;ññï ñ
}
óó 
}
òò 	
public
öö 
async
öö 
Task
öö 
<
öö 
int
öö 
>
öö #
GetRecentPatientCount
öö 4
(
öö4 5
)
öö5 6
{
õõ 	
var
úú 
fromDate
úú 
=
úú 
DateTimeOffset
úú )
.
úú) *
UtcNow
úú* 0
.
úú0 1
AddDays
úú1 8
(
úú8 9
-
úú9 :
$num
úú: <
)
úú< =
;
úú= >
return
ûû 
await
ûû 
_context
ûû !
.
ûû! "
Patients
ûû" *
.
üü 

CountAsync
üü 
(
üü 
p
üü 
=>
üü  
p
üü! "
.
üü" #
CreatedDate
üü# .
>=
üü/ 1
fromDate
üü2 :
)
üü: ;
;
üü; <
}
†† 	
public
¢¢ 
async
¢¢ 
Task
¢¢ 
<
¢¢ !
PatientDashboardDto
¢¢ -
>
¢¢- .
GetDashboardAsync
¢¢/ @
(
¢¢@ A
int
¢¢A D
	patientId
¢¢E N
)
¢¢N O
{
££ 	
var
§§ "
upcomingAppointments
§§ $
=
§§% &
await
§§' ,
_context
§§- 5
.
§§5 6
Appointments
§§6 B
.
•• 

CountAsync
•• 
(
•• 
a
•• 
=>
••  
a
¶¶ 
.
¶¶ 
	PatientId
¶¶ 
==
¶¶  "
	patientId
¶¶# ,
&&
¶¶- /
a
ßß 
.
ßß 
ScheduledDate
ßß #
>=
ßß$ &
DateOnly
ßß' /
.
ßß/ 0
FromDateTime
ßß0 <
(
ßß< =
DateTime
ßß= E
.
ßßE F
Today
ßßF K
)
ßßK L
&&
ßßM O
a
®® 
.
®® 
Status
®® 
!=
®® 
$str
®®  +
)
®®+ ,
;
®®, -
var
™™ 
latestRecords
™™ 
=
™™ 
await
™™  %
_context
™™& .
.
™™. /
HealthRecords
™™/ <
.
´´ 

CountAsync
´´ 
(
´´ 
h
´´ 
=>
´´  
h
´´! "
.
´´" #
	PatientId
´´# ,
==
´´- /
	patientId
´´0 9
)
´´9 :
;
´´: ;
return
≠≠ 
new
≠≠ !
PatientDashboardDto
≠≠ *
{
ÆÆ '
UpcomingAppointmentsCount
ØØ )
=
ØØ* +"
upcomingAppointments
ØØ, @
,
ØØ@ A 
LatestRecordsCount
∞∞ "
=
∞∞# $
latestRecords
∞∞% 2
}
±± 
;
±± 
}
≤≤ 	
}
¥¥ 
}µµ Ù0
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
}CC ﬂ[
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
newNN 
	ExceptionNN #
(NN# $
$strNN$ ;
)NN; <
;NN< =
ifQQ 
(QQ 
appointmentQQ 
.QQ 
StatusQQ "
!=QQ# %
$strQQ& 1
)QQ1 2
throwRR 
newRR 
	ExceptionRR #
(RR# $
$strRR$ `
)RR` a
;RRa b
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
}ãã ±È
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
?' (
>( )
GetByIdAsync* 6
(6 7
int7 :
id; =
)= >
{ 	
var 
doctor 
= 
await 
(  
from   
d   
in   
_context   "
.  " #
Doctors  # *
join!! 
u!! 
in!! 
_context!! "
.!!" #
Users!!# (
on"" 
d"" 
."" 
UserId"" 
equals"" 
u""  
.""  !
Id""! #
where## 
d## 
.## 
DoctorId## 
==## 
id## 
select%% 
new%% 
DoctorListDto%%  
{&& 	
DoctorId'' 
='' 
d'' 
.'' 
DoctorId'' !
,''! "
FullName(( 
=(( 
d(( 
.(( 
FullName(( !
,((! "
Email)) 
=)) 
u)) 
.)) 
Email)) 
,)) 
Specialisation** 
=** 
d** 
.** 
Specialisation** -
,**- .
YearsOfExperience++ 
=++ 
d++  !
.++! "
YearsOfExperience++" 3
,++3 4
ConsultationFee,, 
=,, 
d,, 
.,,  
ConsultationFee,,  /
,,,/ 0
IsActive-- 
=-- 
d-- 
.-- 
IsActive-- !
}.. 	
)// 
.// 
FirstOrDefaultAsync// 
(// 
)// 
;// 
return11 
doctor11 
;11 
}22 	
public44 
async44 
Task44 
<44 
PagedResult44 %
<44% &
DoctorListDto44& 3
>443 4
>444 5
GetAllAsync446 A
(44A B
DoctorFilter44B N
filter44O U
)44U V
{55 	

Expression66 
<66 
Func66 
<66 
Doctor66 "
,66" #
bool66$ (
>66( )
>66) *
	predicate66+ 4
=665 6
d667 8
=>669 ;
(77 
string77 
.77 
IsNullOrEmpty77 )
(77) *
filter77* 0
.770 1
Name771 5
)775 6
||777 9
(88 
d88 
.88 
FullName88 #
!=88$ &
null88' +
&&88, .
EF99 
.99 
	Functions99 %
.99% &
Like99& *
(99* +
d99+ ,
.99, -
FullName99- 5
,995 6
$"997 9
$str999 :
{99: ;
filter99; A
.99A B
Name99B F
}99F G
$str99G H
"99H I
)99I J
)99J K
)99K L
&&99M O
(;; 
string;; 
.;; 
IsNullOrEmpty;; )
(;;) *
filter;;* 0
.;;0 1
Specialisation;;1 ?
);;? @
||;;A C
d<< 
.<< 
Specialisation<< (
==<<) +
filter<<, 2
.<<2 3
Specialisation<<3 A
)<<A B
&&<<C E
(>> 
!>> 
filter>> 
.>> 
IsActive>> %
.>>% &
HasValue>>& .
||>>/ 1
d?? 
.?? 
IsActive?? "
==??# %
filter??& ,
.??, -
IsActive??- 5
.??5 6
Value??6 ;
)??; <
;??< =
FuncAA 
<AA 

IQueryableAA 
<AA 
DoctorAA "
>AA" #
,AA# $
IOrderedQueryableAA% 6
<AA6 7
DoctorAA7 =
>AA= >
>AA> ?
orderByAA@ G
=AAH I
qAAJ K
=>AAL N
{BB 
ifDD 
(DD 
!DD 
stringDD 
.DD 
IsNullOrEmptyDD )
(DD) *
filterDD* 0
.DD0 1
ExperienceOrderDD1 @
)DD@ A
)DDA B
{EE 
ifFF 
(FF 
filterFF 
.FF 
ExperienceOrderFF .
==FF/ 1
$strFF2 7
)FF7 8
returnGG 
qGG  
.GG  !
OrderByGG! (
(GG( )
dGG) *
=>GG+ -
dGG. /
.GG/ 0
YearsOfExperienceGG0 A
)GGA B
;GGB C
returnII 
qII 
.II 
OrderByDescendingII .
(II. /
dII/ 0
=>II1 3
dII4 5
.II5 6
YearsOfExperienceII6 G
)IIG H
;IIH I
}JJ 
returnLL 
qLL 
.LL 
OrderByLL  
(LL  !
dLL! "
=>LL# %
dLL& '
.LL' (
DoctorIdLL( 0
)LL0 1
;LL1 2
}MM 
;MM 
varOO 
pagedResultOO 
=OO 
awaitOO #
_repositoryOO$ /
.OO/ 0
GetAllAsyncOO0 ;
(OO; <
filterPP 
.PP 

PageNumberPP !
,PP! "
filterQQ 
.QQ 
PageSizeQQ 
,QQ  
	predicateRR 
,RR 
orderBySS 
)TT 
;TT 
returnVV 
newVV 
PagedResultVV "
<VV" #
DoctorListDtoVV# 0
>VV0 1
{WW 
ItemsXX 
=XX 
_mapperXX 
.XX  
MapXX  #
<XX# $
IEnumerableXX$ /
<XX/ 0
DoctorListDtoXX0 =
>XX= >
>XX> ?
(XX? @
pagedResultXX@ K
.XXK L
ItemsXXL Q
)XXQ R
,XXR S

PageNumberYY 
=YY 
pagedResultYY (
.YY( )

PageNumberYY) 3
,YY3 4
PageSizeZZ 
=ZZ 
pagedResultZZ &
.ZZ& '
PageSizeZZ' /
,ZZ/ 0

TotalCount[[ 
=[[ 
pagedResult[[ (
.[[( )

TotalCount[[) 3
}\\ 
;\\ 
}]] 	
public__ 
async__ 
Task__ 
AddAsync__ "
(__" #
CreateDoctorDto__# 2
dto__3 6
)__6 7
{`` 	
varaa 
doctoraa 
=aa 
_mapperaa  
.aa  !
Mapaa! $
<aa$ %
Doctoraa% +
>aa+ ,
(aa, -
dtoaa- 0
)aa0 1
;aa1 2
awaitbb 
_repositorybb 
.bb 
AddAsyncbb &
(bb& '
doctorbb' -
)bb- .
;bb. /
awaitdd 
_repositorydd 
.dd 
CreateSlotsdd )
(dd) *
doctordd* 0
.dd0 1
DoctorIddd1 9
,dd9 :
dtodd; >
.dd> ?
	TimeSlotsdd? H
)ddH I
;ddI J
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
Taskii 
UpdateAsyncii %
(ii% &
intii& )
idii* ,
,ii, -
UpdateDoctorDtoii. =
dtoii> A
)iiA B
{jj 	
varkk 
doctorkk 
=kk 
awaitkk 
_repositorykk *
.kk* +
GetByIdAsynckk+ 7
(kk7 8
idkk8 :
)kk: ;
;kk; <
ifmm 
(mm 
doctormm 
ismm 
nullmm 
)mm 
thrownn 
newnn %
InvalidOperationExceptionnn 3
(nn3 4$
NotFoundExceptionMessagenn4 L
)nnL M
;nnM N
_mapperpp 
.pp 
Mappp 
(pp 
dtopp 
,pp 
doctorpp #
)pp# $
;pp$ %
awaitrr 
_repositoryrr 
.rr 
UpdateAsyncrr )
(rr) *
doctorrr* 0
)rr0 1
;rr1 2
awaitss 
_contextss 
.ss 
SaveChangesAsyncss +
(ss+ ,
)ss, -
;ss- .
}tt 	
publicvv 
asyncvv 
Taskvv 
UpdateStatusAsyncvv +
(vv+ ,
intvv, /
idvv0 2
,vv2 3
boolvv4 8
isActivevv9 A
)vvA B
{ww 	
varxx 
doctorxx 
=xx 
awaitxx 
_repositoryxx *
.xx* +
GetByIdAsyncxx+ 7
(xx7 8
idxx8 :
)xx: ;
;xx; <
ifzz 
(zz 
doctorzz 
iszz 
nullzz 
)zz 
throw{{ 
new{{ %
InvalidOperationException{{ 3
({{3 4$
NotFoundExceptionMessage{{4 L
){{L M
;{{M N
doctor}} 
.}} 
IsActive}} 
=}} 
isActive}} &
;}}& '
await 
_repository 
. 
UpdateAsync )
() *
doctor* 0
)0 1
;1 2
await
ÄÄ 
_context
ÄÄ 
.
ÄÄ 
SaveChangesAsync
ÄÄ +
(
ÄÄ+ ,
)
ÄÄ, -
;
ÄÄ- .
}
ÅÅ 	
public
ÉÉ 
async
ÉÉ 
Task
ÉÉ 
DeleteAsync
ÉÉ %
(
ÉÉ% &
int
ÉÉ& )
id
ÉÉ* ,
)
ÉÉ, -
{
ÑÑ 	
var
ÖÖ 
doctor
ÖÖ 
=
ÖÖ 
await
ÖÖ 
_repository
ÖÖ *
.
ÖÖ* +
GetByIdAsync
ÖÖ+ 7
(
ÖÖ7 8
id
ÖÖ8 :
)
ÖÖ: ;
;
ÖÖ; <
if
áá 
(
áá 
doctor
áá 
is
áá 
null
áá 
)
áá 
throw
àà 
new
àà '
InvalidOperationException
àà 3
(
àà3 4&
NotFoundExceptionMessage
àà4 L
)
ààL M
;
ààM N
try
ää 
{
ãã 
await
åå 
_repository
åå !
.
åå! "
DeleteAsync
åå" -
(
åå- .
id
åå. 0
)
åå0 1
;
åå1 2
await
çç 
_context
çç 
.
çç 
SaveChangesAsync
çç /
(
çç/ 0
)
çç0 1
;
çç1 2
}
éé 
catch
èè 
(
èè 
DbUpdateException
èè $
ex
èè% '
)
èè' (
{
êê 
throw
ëë 
new
ëë '
InvalidOperationException
ëë 3
(
ëë3 4
$strëë4 è
,ëëè ê
exëëë ì
)ëëì î
;ëëî ï
}
íí 
}
ìì 	
public
ïï 
async
ïï 
Task
ïï 
<
ïï 
List
ïï 
<
ïï 
string
ïï %
>
ïï% &
>
ïï& '
GetSlots
ïï( 0
(
ïï0 1
int
ïï1 4
doctorId
ïï5 =
)
ïï= >
{
ññ 	
var
óó 
slots
óó 
=
óó 
await
óó 
_repository
óó )
.
óó) *
GetSlots
óó* 2
(
óó2 3
doctorId
óó3 ;
)
óó; <
;
óó< =
if
ôô 
(
ôô 
slots
ôô 
.
ôô 
Count
ôô 
==
ôô 
$num
ôô  
)
ôô  !
throw
öö 
new
öö '
InvalidOperationException
öö 3
(
öö3 4
$str
öö4 _
)
öö_ `
;
öö` a
return
úú 
slots
úú 
;
úú 
}
ùù 	
public
üü 
async
üü 
Task
üü 
CreateSlots
üü %
(
üü% &
int
üü& )
id
üü* ,
,
üü, -
List
üü. 2
<
üü2 3
string
üü3 9
>
üü9 :
	timeslots
üü; D
)
üüD E
{
†† 	
await
°° 
_repository
°° 
.
°° 
CreateSlots
°° )
(
°°) *
id
°°* ,
,
°°, -
	timeslots
°°. 7
)
°°7 8
;
°°8 9
await
¢¢ 
_context
¢¢ 
.
¢¢ 
SaveChangesAsync
¢¢ +
(
¢¢+ ,
)
¢¢, -
;
¢¢- .
}
££ 	
private
•• 
async
•• 
Task
•• 
<
•• 
List
•• 
<
••  
string
••  &
>
••& '
>
••' (%
AvailableTimeSlotsCheck
••) @
(
••@ A
DateOnly
••A I
date
••J N
,
••N O
int
••P S
doctorId
••T \
)
••\ ]
{
¶¶ 	
var
ßß 
allSlots
ßß 
=
ßß 
await
ßß  
_repository
ßß! ,
.
ßß, -
GetSlots
ßß- 5
(
ßß5 6
doctorId
ßß6 >
)
ßß> ?
;
ßß? @
var
®® 
bookedSlots
®® 
=
®® 
await
®® #$
_appointmentRepository
®®$ :
.
®®: ;
BookedTimeSlots
®®; J
(
®®J K
date
®®K O
,
®®O P
doctorId
®®Q Y
)
®®Y Z
;
®®Z [
return
©© 
allSlots
©© 
.
©© 
Except
©© "
(
©©" #
bookedSlots
©©# .
)
©©. /
.
©©/ 0
ToList
©©0 6
(
©©6 7
)
©©7 8
;
©©8 9
}
™™ 	
public
¨¨ 
async
¨¨ 
Task
¨¨ 
<
¨¨ "
CreateLeaveResultDto
¨¨ .
>
¨¨. /
CreateLeave
¨¨0 ;
(
¨¨; <
int
¨¨< ?
id
¨¨@ B
,
¨¨B C
List
¨¨D H
<
¨¨H I
CreateLeaveDto
¨¨I W
>
¨¨W X
leaves
¨¨Y _
)
¨¨_ `
{
≠≠ 	
var
ÆÆ 
result
ÆÆ 
=
ÆÆ 
new
ÆÆ "
CreateLeaveResultDto
ÆÆ 1
(
ÆÆ1 2
)
ÆÆ2 3
;
ÆÆ3 4
var
ØØ 
existingLeaves
ØØ 
=
ØØ  
await
ØØ! &
_repository
ØØ' 2
.
ØØ2 3!
GetLeavesByDoctorId
ØØ3 F
(
ØØF G
id
ØØG I
)
ØØI J
;
ØØJ K
var
∞∞  
existingLeaveDates
∞∞ "
=
∞∞# $
existingLeaves
∞∞% 3
.
∞∞3 4
Select
∞∞4 :
(
∞∞: ;
l
∞∞; <
=>
∞∞= ?
l
∞∞@ A
.
∞∞A B
	LeaveDate
∞∞B K
)
∞∞K L
.
∞∞L M
	ToHashSet
∞∞M V
(
∞∞V W
)
∞∞W X
;
∞∞X Y
var
≤≤ 
leavesToCreate
≤≤ 
=
≤≤  
new
≤≤! $
List
≤≤% )
<
≤≤) *
CreateLeaveDto
≤≤* 8
>
≤≤8 9
(
≤≤9 :
)
≤≤: ;
;
≤≤; <
foreach
¥¥ 
(
¥¥ 
var
¥¥ 
leave
¥¥ 
in
¥¥ !
leaves
¥¥" (
)
¥¥( )
{
µµ 
if
∂∂ 
(
∂∂  
existingLeaveDates
∂∂ &
.
∂∂& '
Contains
∂∂' /
(
∂∂/ 0
leave
∂∂0 5
.
∂∂5 6
	LeaveDate
∂∂6 ?
)
∂∂? @
)
∂∂@ A
{
∑∑ 
result
∏∏ 
.
∏∏ 
SkippedDates
∏∏ '
.
∏∏' (
Add
∏∏( +
(
∏∏+ ,
leave
∏∏, 1
.
∏∏1 2
	LeaveDate
∏∏2 ;
)
∏∏; <
;
∏∏< =
continue
ππ 
;
ππ 
}
∫∫ 
var
ºº 
availableSlots
ºº "
=
ºº# $
await
ºº% *%
AvailableTimeSlotsCheck
ºº+ B
(
ººB C
leave
ººC H
.
ººH I
	LeaveDate
ººI R
,
ººR S
id
ººT V
)
ººV W
;
ººW X
var
ΩΩ 
allSlots
ΩΩ 
=
ΩΩ 
await
ΩΩ $
GetSlots
ΩΩ% -
(
ΩΩ- .
id
ΩΩ. 0
)
ΩΩ0 1
;
ΩΩ1 2
if
øø 
(
øø 
availableSlots
øø "
.
øø" #
Count
øø# (
!=
øø) +
allSlots
øø, 4
.
øø4 5
Count
øø5 :
)
øø: ;
{
¿¿ 
await
¡¡ $
_appointmentRepository
¡¡ 0
.
¡¡0 1,
CancelAppointmentsByDoctorDate
¡¡1 O
(
¡¡O P
id
¡¡P R
,
¡¡R S
leave
¡¡T Y
.
¡¡Y Z
	LeaveDate
¡¡Z c
)
¡¡c d
;
¡¡d e
result
¬¬ 
.
¬¬ .
 CreatedWithCancelledAppointments
¬¬ ;
.
¬¬; <
Add
¬¬< ?
(
¬¬? @
leave
¬¬@ E
.
¬¬E F
	LeaveDate
¬¬F O
)
¬¬O P
;
¬¬P Q
}
√√ 
leavesToCreate
≈≈ 
.
≈≈ 
Add
≈≈ "
(
≈≈" #
leave
≈≈# (
)
≈≈( )
;
≈≈) *
}∆∆ 
if
»» 
(
»» 
leavesToCreate
»» 
.
»» 
Count
»» $
>
»»% &
$num
»»' (
)
»»( )
{
…… 
await
   
_repository
   !
.
  ! "
CreateLeaves
  " .
(
  . /
id
  / 1
,
  1 2
leavesToCreate
  3 A
)
  A B
;
  B C
await
ÀÀ 
_context
ÀÀ 
.
ÀÀ 
SaveChangesAsync
ÀÀ /
(
ÀÀ/ 0
)
ÀÀ0 1
;
ÀÀ1 2
}
ÃÃ 
return
ŒŒ 
result
ŒŒ 
;
ŒŒ 
}
œœ 	
public
—— 
async
—— 
Task
—— 
<
—— )
AvailableDoctorsResponseDto
—— 5
>
——5 6
AvailableDoctors
——7 G
(
——G H
string
——H N
specialisation
——O ]
,
——] ^
DateOnly
——_ g
date
——h l
)
——l m
{
““ 	
var
”” 

allDoctors
”” 
=
”” 
await
”” "
_context
””# +
.
””+ ,
Doctors
””, 3
.
‘‘ 
Where
‘‘ 
(
‘‘ 
d
‘‘ 
=>
‘‘ 
d
‘‘ 
.
‘‘ 
Specialisation
‘‘ ,
==
‘‘- /
specialisation
‘‘0 >
)
‘‘> ?
.
’’ 
ToListAsync
’’ 
(
’’ 
)
’’ 
;
’’ 
if
◊◊ 
(
◊◊ 
!
◊◊ 

allDoctors
◊◊ 
.
◊◊ 
Any
◊◊ 
(
◊◊  
)
◊◊  !
)
◊◊! "
{
ÿÿ 
return
ŸŸ 
new
ŸŸ )
AvailableDoctorsResponseDto
ŸŸ 6
{
⁄⁄ 
Doctors
€€ 
=
€€ 
new
€€ !
List
€€" &
<
€€& '
DoctorListDto
€€' 4
>
€€4 5
(
€€5 6
)
€€6 7
,
€€7 8
Message
‹‹ 
=
‹‹ 
$str
‹‹ L
}
›› 
;
›› 
}
ﬁﬁ 
var
‡‡ 
activeDoctors
‡‡ 
=
‡‡ 

allDoctors
‡‡  *
.
‡‡* +
Where
‡‡+ 0
(
‡‡0 1
d
‡‡1 2
=>
‡‡3 5
d
‡‡6 7
.
‡‡7 8
IsActive
‡‡8 @
)
‡‡@ A
.
‡‡A B
ToList
‡‡B H
(
‡‡H I
)
‡‡I J
;
‡‡J K
if
‚‚ 
(
‚‚ 
!
‚‚ 
activeDoctors
‚‚ 
.
‚‚ 
Any
‚‚ "
(
‚‚" #
)
‚‚# $
)
‚‚$ %
{
„„ 
return
‰‰ 
new
‰‰ )
AvailableDoctorsResponseDto
‰‰ 6
{
ÂÂ 
Doctors
ÊÊ 
=
ÊÊ 
new
ÊÊ !
List
ÊÊ" &
<
ÊÊ& '
DoctorListDto
ÊÊ' 4
>
ÊÊ4 5
(
ÊÊ5 6
)
ÊÊ6 7
,
ÊÊ7 8
Message
ÁÁ 
=
ÁÁ 
$str
ÁÁ 4
}
ËË 
;
ËË 
}
ÈÈ 
var
ÎÎ 
availableDoctors
ÎÎ  
=
ÎÎ! "
new
ÎÎ# &
List
ÎÎ' +
<
ÎÎ+ ,
Doctor
ÎÎ, 2
>
ÎÎ2 3
(
ÎÎ3 4
)
ÎÎ4 5
;
ÎÎ5 6
foreach
ÌÌ 
(
ÌÌ 
var
ÌÌ 
doctor
ÌÌ 
in
ÌÌ  "
activeDoctors
ÌÌ# 0
)
ÌÌ0 1
{
ÓÓ 
var
ÔÔ 
	isOnLeave
ÔÔ 
=
ÔÔ 
await
ÔÔ  %
_context
ÔÔ& .
.
ÔÔ. /
DoctorLeaves
ÔÔ/ ;
.
 
AnyAsync
 
(
 
l
 
=>
  "
l
ÒÒ 
.
ÒÒ 
DoctorId
ÒÒ "
==
ÒÒ# %
doctor
ÒÒ& ,
.
ÒÒ, -
DoctorId
ÒÒ- 5
&&
ÒÒ6 8
l
ÚÚ 
.
ÚÚ 
	LeaveDate
ÚÚ #
==
ÚÚ$ &
date
ÚÚ' +
)
ÚÚ+ ,
;
ÚÚ, -
if
ÙÙ 
(
ÙÙ 
!
ÙÙ 
	isOnLeave
ÙÙ 
)
ÙÙ 
{
ıı 
availableDoctors
ˆˆ $
.
ˆˆ$ %
Add
ˆˆ% (
(
ˆˆ( )
doctor
ˆˆ) /
)
ˆˆ/ 0
;
ˆˆ0 1
}
˜˜ 
}
¯¯ 
if
˙˙ 
(
˙˙ 
!
˙˙ 
availableDoctors
˙˙ !
.
˙˙! "
Any
˙˙" %
(
˙˙% &
)
˙˙& '
)
˙˙' (
{
˚˚ 
return
¸¸ 
new
¸¸ )
AvailableDoctorsResponseDto
¸¸ 6
{
˝˝ 
Doctors
˛˛ 
=
˛˛ 
new
˛˛ !
List
˛˛" &
<
˛˛& '
DoctorListDto
˛˛' 4
>
˛˛4 5
(
˛˛5 6
)
˛˛6 7
,
˛˛7 8
Message
ˇˇ 
=
ˇˇ 
$str
ˇˇ 2
}
ÄÄ 
;
ÄÄ 
}
ÅÅ 
var
ÉÉ 
result
ÉÉ 
=
ÉÉ 
_mapper
ÉÉ  
.
ÉÉ  !
Map
ÉÉ! $
<
ÉÉ$ %
List
ÉÉ% )
<
ÉÉ) *
DoctorListDto
ÉÉ* 7
>
ÉÉ7 8
>
ÉÉ8 9
(
ÉÉ9 :
availableDoctors
ÉÉ: J
)
ÉÉJ K
;
ÉÉK L
return
ÖÖ 
new
ÖÖ )
AvailableDoctorsResponseDto
ÖÖ 2
{
ÜÜ 
Doctors
áá 
=
áá 
result
áá  
,
áá  !
Message
àà 
=
àà 
$str
àà 
}
ââ 
;
ââ 
}
ää 	
public
åå 
async
åå 
Task
åå 
<
åå 
DoctorSummaryDto
åå *
>
åå* +
GetSummaryAsync
åå, ;
(
åå; <
)
åå< =
{
çç 	
var
éé 
fromDate
éé 
=
éé 
DateTimeOffset
éé )
.
éé) *
UtcNow
éé* 0
.
éé0 1
AddDays
éé1 8
(
éé8 9
-
éé9 :
$num
éé: <
)
éé< =
;
éé= >
var
èè 
toDate
èè 
=
èè 
DateTimeOffset
èè '
.
èè' (
UtcNow
èè( .
;
èè. /
var
ëë 
result
ëë 
=
ëë 
await
ëë 
_context
ëë '
.
ëë' (
Doctors
ëë( /
.
íí 
Where
íí 
(
íí 
d
íí 
=>
íí 
d
íí 
.
íí 
CreatedDate
íí )
>=
íí* ,
fromDate
íí- 5
&&
íí6 8
d
íí9 :
.
íí: ;
CreatedDate
íí; F
<=
ííG I
toDate
ííJ P
)
ííP Q
.
ìì 
GroupBy
ìì 
(
ìì 
d
ìì 
=>
ìì 
$num
ìì 
)
ìì  
.
îî 
Select
îî 
(
îî 
g
îî 
=>
îî 
new
îî  
DoctorSummaryDto
îî! 1
{
ïï 
TotalDoctors
ññ  
=
ññ! "
g
ññ# $
.
ññ$ %
Count
ññ% *
(
ññ* +
)
ññ+ ,
,
ññ, -
ActiveDoctors
óó !
=
óó" #
g
óó$ %
.
óó% &
Count
óó& +
(
óó+ ,
d
óó, -
=>
óó. 0
d
óó1 2
.
óó2 3
IsActive
óó3 ;
)
óó; <
,
óó< =
InactiveDoctors
òò #
=
òò$ %
g
òò& '
.
òò' (
Count
òò( -
(
òò- .
d
òò. /
=>
òò0 2
!
òò3 4
d
òò4 5
.
òò5 6
IsActive
òò6 >
)
òò> ?
}
ôô 
)
ôô 
.
öö !
FirstOrDefaultAsync
öö $
(
öö$ %
)
öö% &
;
öö& '
return
úú 
result
úú 
??
úú 
new
úú  
DoctorSummaryDto
úú! 1
(
úú1 2
)
úú2 3
;
úú3 4
}
ùù 	
public
üü 
async
üü 
Task
üü 
<
üü  
DoctorDashboardDto
üü ,
>
üü, -
GetDashboardAsync
üü. ?
(
üü? @
int
üü@ C
doctorId
üüD L
)
üüL M
{
†† 	
var
°° 
today
°° 
=
°° 
DateOnly
°°  
.
°°  !
FromDateTime
°°! -
(
°°- .
DateTime
°°. 6
.
°°6 7
Today
°°7 <
)
°°< =
;
°°= >
var
££ "
upcomingAppointments
££ $
=
££% &
await
££' ,
_context
££- 5
.
££5 6
Appointments
££6 B
.
§§ 

CountAsync
§§ 
(
§§ 
a
§§ 
=>
§§  
a
•• 
.
•• 
DoctorId
•• 
==
•• !
doctorId
••" *
&&
••+ -
a
¶¶ 
.
¶¶ 
ScheduledDate
¶¶ #
>=
¶¶$ &
today
¶¶' ,
&&
¶¶- /
a
ßß 
.
ßß 
Status
ßß 
!=
ßß 
$str
ßß  +
)
ßß+ ,
;
ßß, -
var
©© 
patientsTreated
©© 
=
©©  !
await
©©" '
_context
©©( 0
.
©©0 1
Appointments
©©1 =
.
™™ 

CountAsync
™™ 
(
™™ 
a
™™ 
=>
™™  
a
´´ 
.
´´ 
DoctorId
´´ 
==
´´ !
doctorId
´´" *
&&
´´+ -
a
¨¨ 
.
¨¨ 
Status
¨¨ 
==
¨¨ 
$str
¨¨  +
)
¨¨+ ,
;
¨¨, -
var
ÆÆ 
upcomingLeaves
ÆÆ 
=
ÆÆ  
await
ÆÆ! &
_context
ÆÆ' /
.
ÆÆ/ 0
DoctorLeaves
ÆÆ0 <
.
ØØ 

CountAsync
ØØ 
(
ØØ 
l
ØØ 
=>
ØØ  
l
∞∞ 
.
∞∞ 
DoctorId
∞∞ 
==
∞∞ !
doctorId
∞∞" *
&&
∞∞+ -
l
±± 
.
±± 
	LeaveDate
±± 
>=
±±  "
today
±±# (
)
±±( )
;
±±) *
var
≥≥ 
todaysSchedule
≥≥ 
=
≥≥  
await
≥≥! &
_context
≥≥' /
.
≥≥/ 0
Appointments
≥≥0 <
.
¥¥ 
Where
¥¥ 
(
¥¥ 
a
¥¥ 
=>
¥¥ 
a
µµ 
.
µµ 
DoctorId
µµ 
==
µµ !
doctorId
µµ" *
&&
µµ+ -
a
∂∂ 
.
∂∂ 
ScheduledDate
∂∂ #
==
∂∂$ &
today
∂∂' ,
&&
∂∂- /
a
∑∑ 
.
∑∑ 
Status
∑∑ 
!=
∑∑ 
$str
∑∑  +
)
∑∑+ ,
.
∏∏ 
OrderBy
∏∏ 
(
∏∏ 
a
∏∏ 
=>
∏∏ 
a
∏∏ 
.
∏∏  
TimeSlot
∏∏  (
)
∏∏( )
.
ππ 
Select
ππ 
(
ππ 
a
ππ 
=>
ππ 
a
ππ 
.
ππ 
TimeSlot
ππ '
)
ππ' (
.
∫∫ 
ToListAsync
∫∫ 
(
∫∫ 
)
∫∫ 
;
∫∫ 
return
ºº 
new
ºº  
DoctorDashboardDto
ºº )
{
ΩΩ "
UpcomingAppointments
ææ $
=
ææ% &"
upcomingAppointments
ææ' ;
,
ææ; <
PatientsTreated
øø 
=
øø  !
patientsTreated
øø" 1
,
øø1 2
UpcomingLeaves
¿¿ 
=
¿¿  
upcomingLeaves
¿¿! /
,
¿¿/ 0
TodaysSchedule
¡¡ 
=
¡¡  
todaysSchedule
¡¡! /
}
¬¬ 
;
¬¬ 
}
√√ 	
}
ƒƒ 
}≈≈ ËÉ
jC:\Users\310055\source\repos\UST-Live-01\HealthCare\HealthCare.Api\Services\Implementations\AuthService.cs
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
class 
AuthService 
: 
IAuthService +
{ 
private 
readonly 
UserManager $
<$ %
IdentityUser% 1
>1 2
_userManager3 ?
;? @
private 
readonly 
IMapper  
_mapper! (
;( )
private 
readonly 
IPatientRepository +
_patientRepo, 8
;8 9
private 
readonly 
IDoctorRepository *
_doctorRepo+ 6
;6 7
private 
readonly 
IJwtService $
_jwtService% 0
;0 1
private 
readonly 
HealthCareDbContext ,
_context- 5
;5 6
public 
AuthService 
( 
UserManager 
< 
IdentityUser $
>$ %
userManager& 1
,1 2
IMapper 
mapper 
, 
IPatientRepository 
patientRepo *
,* +
IDoctorRepository 

doctorRepo (
,( )
IJwtService 

jwtService "
," #
HealthCareDbContext 
context  '
)' (
{ 	
_userManager   
=   
userManager   &
;  & '
_mapper!! 
=!! 
mapper!! 
;!! 
_patientRepo"" 
="" 
patientRepo"" &
;""& '
_doctorRepo## 
=## 

doctorRepo## $
;##$ %
_jwtService$$ 
=$$ 

jwtService$$ $
;$$$ %
_context%% 
=%% 
context%% 
;%% 
}&& 	
private(( 
async(( 
Task(( 
<(( 
IdentityUser(( '
>((' (#
CreateUserWithRoleAsync(() @
(((@ A
string)) 
email)) 
,)) 
string** 
password** 
,** 
string++ 
role++ 
)++ 
{,, 	
var.. 
existingUser.. 
=.. 
await.. $
_userManager..% 1
...1 2
FindByEmailAsync..2 B
(..B C
email..C H
)..H I
;..I J
if00 
(00 
existingUser00 
!=00 
null00  $
)00$ %
{11 
throw22 
new22 %
InvalidOperationException22 3
(223 4
$str224 J
)22J K
;22K L
}33 
var66 
user66 
=66 
new66 
IdentityUser66 '
{77 
UserName88 
=88 
email88  
,88  !
Email99 
=99 
email99 
}:: 
;:: 
var<< 
result<< 
=<< 
await<< 
_userManager<< +
.<<+ ,
CreateAsync<<, 7
(<<7 8
user<<8 <
,<<< =
password<<> F
)<<F G
;<<G H
if>> 
(>> 
!>> 
result>> 
.>> 
	Succeeded>> !
)>>! "
{?? 
throw@@ 
new@@ %
InvalidOperationException@@ 3
(@@3 4
stringAA 
.AA 
JoinAA 
(AA  
$strAA  $
,AA$ %
resultAA& ,
.AA, -
ErrorsAA- 3
.AA3 4
SelectAA4 :
(AA: ;
eAA; <
=>AA= ?
eAA@ A
.AAA B
DescriptionAAB M
)AAM N
)AAN O
)BB 
;BB 
}CC 
varFF 

roleResultFF 
=FF 
awaitFF "
_userManagerFF# /
.FF/ 0
AddToRoleAsyncFF0 >
(FF> ?
userFF? C
,FFC D
roleFFE I
)FFI J
;FFJ K
ifHH 
(HH 
!HH 

roleResultHH 
.HH 
	SucceededHH %
)HH% &
{II 
throwJJ 
newJJ %
InvalidOperationExceptionJJ 3
(JJ3 4
stringKK 
.KK 
JoinKK 
(KK  
$strKK  $
,KK$ %

roleResultKK& 0
.KK0 1
ErrorsKK1 7
.KK7 8
SelectKK8 >
(KK> ?
eKK? @
=>KKA C
eKKD E
.KKE F
DescriptionKKF Q
)KKQ R
)KKR S
)LL 
;LL 
}MM 
returnOO 
userOO 
;OO 
}PP 	
publicRR 
asyncRR 
TaskRR  
RegisterPatientAsyncRR .
(RR. /
CreatePatientDtoRR/ ?
dtoRR@ C
)RRC D
{SS 	
varTT 
userTT 
=TT 
awaitTT #
CreateUserWithRoleAsyncTT 4
(TT4 5
dtoTT5 8
.TT8 9
EmailTT9 >
,TT> ?
dtoTT@ C
.TTC D
PasswordTTD L
,TTL M
$strTTN W
)TTW X
;TTX Y
varWW 
patientWW 
=WW 
_mapperWW !
.WW! "
MapWW" %
<WW% &
PatientWW& -
>WW- .
(WW. /
dtoWW/ 2
)WW2 3
;WW3 4
patientXX 
.XX 
UserIdXX 
=XX 
userXX !
.XX! "
IdXX" $
;XX$ %
awaitZZ 
_patientRepoZZ 
.ZZ 
AddAsyncZZ '
(ZZ' (
patientZZ( /
)ZZ/ 0
;ZZ0 1
await[[ 
_context[[ 
.[[ 
SaveChangesAsync[[ +
([[+ ,
)[[, -
;[[- .
}\\ 	
public^^ 
async^^ 
Task^^ 
RegisterDoctorAsync^^ -
(^^- .
CreateDoctorDto^^. =
dto^^> A
)^^A B
{__ 	
var`` 
user`` 
=`` 
await`` #
CreateUserWithRoleAsync`` 4
(``4 5
dto``5 8
.``8 9
Email``9 >
,``> ?
dto``@ C
.``C D
Password``D L
,``L M
$str``N V
)``V W
;``W X
varcc 
doctorcc 
=cc 
_mappercc  
.cc  !
Mapcc! $
<cc$ %
Doctorcc% +
>cc+ ,
(cc, -
dtocc- 0
)cc0 1
;cc1 2
doctordd 
.dd 
UserIddd 
=dd 
userdd  
.dd  !
Iddd! #
;dd# $
awaitff 
_doctorRepoff 
.ff 
AddAsyncff &
(ff& '
doctorff' -
)ff- .
;ff. /
awaithh 
_contexthh 
.hh 
SaveChangesAsynchh +
(hh+ ,
)hh, -
;hh- .
awaitjj 
_doctorRepojj 
.jj 
CreateSlotsjj )
(jj) *
doctorjj* 0
.jj0 1
DoctorIdjj1 9
,jj9 :
dtojj; >
.jj> ?
	TimeSlotsjj? H
)jjH I
;jjI J
awaitll 
_contextll 
.ll 
SaveChangesAsyncll +
(ll+ ,
)ll, -
;ll- .
}mm 	
publicoo 
asyncoo 
Taskoo 
<oo 
AuthResponseDtooo )
>oo) *

LoginAsyncoo+ 5
(oo5 6
LoginDtooo6 >
dtooo? B
)ooB C
{pp 	
varrr 
userrr 
=rr 
awaitrr 
_userManagerrr )
.rr) *
FindByEmailAsyncrr* :
(rr: ;
dtorr; >
.rr> ?
Emailrr? D
)rrD E
;rrE F
ifss 
(ss 
userss 
==ss 
nullss 
)ss 
throwtt 
newtt %
InvalidOperationExceptiontt 3
(tt3 4
$strtt4 I
)ttI J
;ttJ K
varww 
isValidww 
=ww 
awaitww 
_userManagerww  ,
.ww, -
CheckPasswordAsyncww- ?
(ww? @
userww@ D
,wwD E
dtowwF I
.wwI J
PasswordwwJ R
)wwR S
;wwS T
ifxx 
(xx 
!xx 
isValidxx 
)xx 
throwyy 
newyy '
UnauthorizedAccessExceptionyy 5
(yy5 6
$stryy6 K
)yyK L
;yyL M
var|| 
roles|| 
=|| 
await|| 
_userManager|| *
.||* +
GetRolesAsync||+ 8
(||8 9
user||9 =
)||= >
;||> ?
if}} 
(}} 
roles}} 
==}} 
null}} 
||}}  
!}}! "
roles}}" '
.}}' (
Any}}( +
(}}+ ,
)}}, -
)}}- .
{~~ 
throw 
new %
InvalidOperationException 3
(3 4
$str4 K
)K L
;L M
}
ÄÄ 
string
ÉÉ 
token
ÉÉ 
;
ÉÉ 
var
ÑÑ 
role
ÑÑ 
=
ÑÑ 
roles
ÑÑ 
[
ÑÑ 
$num
ÑÑ 
]
ÑÑ 
;
ÑÑ  
if
ÖÖ 
(
ÖÖ 
role
ÖÖ 
==
ÖÖ 
$str
ÖÖ !
)
ÖÖ! "
{
ÜÜ 
var
áá 
patient
áá 
=
áá 
await
áá #
_patientRepo
áá$ 0
.
áá0 1
GetByUserIdAsync
áá1 A
(
ááA B
user
ááB F
.
ááF G
Id
ááG I
)
ááI J
;
ááJ K
if
ââ 
(
ââ 
patient
ââ 
==
ââ 
null
ââ #
)
ââ# $
throw
ää 
new
ää '
InvalidOperationException
ää 7
(
ää7 8
$str
ää8 S
)
ääS T
;
ääT U
token
çç 
=
çç 
await
çç 
_jwtService
çç )
.
çç) *
GenerateToken
çç* 7
(
çç7 8
user
çç8 <
,
çç< =
	patientId
çç> G
:
ççG H
patient
ççI P
.
ççP Q
	PatientId
ççQ Z
)
ççZ [
;
çç[ \
}
éé 
else
èè 
if
èè 
(
èè 
role
èè 
==
èè 
$str
èè %
)
èè% &
{
êê 
var
ëë 
doctor
ëë 
=
ëë 
await
ëë "
_doctorRepo
ëë# .
.
ëë. /
GetByUserIdAsync
ëë/ ?
(
ëë? @
user
ëë@ D
.
ëëD E
Id
ëëE G
)
ëëG H
;
ëëH I
if
ìì 
(
ìì 
doctor
ìì 
==
ìì 
null
ìì "
)
ìì" #
throw
îî 
new
îî '
InvalidOperationException
îî 7
(
îî7 8
$str
îî8 R
)
îîR S
;
îîS T
token
óó 
=
óó 
await
óó 
_jwtService
óó )
.
óó) *
GenerateToken
óó* 7
(
óó7 8
user
óó8 <
,
óó< =
doctorId
óó> F
:
óóF G
doctor
óóH N
.
óóN O
DoctorId
óóO W
)
óóW X
;
óóX Y
}
òò 
else
ôô 
if
ôô 
(
ôô 
role
ôô 
==
ôô 
$str
ôô $
)
ôô$ %
{
öö 
token
úú 
=
úú 
await
úú 
_jwtService
úú )
.
úú) *
GenerateToken
úú* 7
(
úú7 8
user
úú8 <
)
úú< =
;
úú= >
}
ùù 
else
ûû 
{
üü 
throw
†† 
new
†† '
InvalidOperationException
†† 3
(
††3 4
$str
††4 C
)
††C D
;
††D E
}
°° 
var
§§ 
response
§§ 
=
§§ 
new
§§ 
AuthResponseDto
§§ .
{
•• 
AccessToken
¶¶ 
=
¶¶ 
token
¶¶ #
,
¶¶# $
Role
ßß 
=
ßß 
role
ßß 
}
®® 
;
®® 
return
™™ 
response
™™ 
;
™™ 
}
´´ 	
public
≠≠ 
async
≠≠ 
Task
≠≠ !
ChangePasswordAsync
≠≠ -
(
≠≠- .
string
≠≠. 4
userId
≠≠5 ;
,
≠≠; <
ChangePasswordDto
≠≠= N
dto
≠≠O R
)
≠≠R S
{
ÆÆ 	
var
ØØ 
user
ØØ 
=
ØØ 
await
ØØ 
_userManager
ØØ )
.
ØØ) *
FindByIdAsync
ØØ* 7
(
ØØ7 8
userId
ØØ8 >
)
ØØ> ?
;
ØØ? @
if
±± 
(
±± 
user
±± 
==
±± 
null
±± 
)
±± 
throw
≤≤ 
new
≤≤ '
InvalidOperationException
≤≤ 3
(
≤≤3 4
$str
≤≤4 D
)
≤≤D E
;
≤≤E F
var
¥¥ 
result
¥¥ 
=
¥¥ 
await
¥¥ 
_userManager
¥¥ +
.
¥¥+ ,!
ChangePasswordAsync
¥¥, ?
(
¥¥? @
user
µµ 
,
µµ 
dto
∂∂ 
.
∂∂ 
CurrentPassword
∂∂ #
,
∂∂# $
dto
∑∑ 
.
∑∑ 
NewPassword
∑∑ 
)
∏∏ 
;
∏∏ 
if
∫∫ 
(
∫∫ 
!
∫∫ 
result
∫∫ 
.
∫∫ 
	Succeeded
∫∫ !
)
∫∫! "
throw
ªª 
new
ªª '
InvalidOperationException
ªª 3
(
ªª3 4
string
ºº 
.
ºº 
Join
ºº 
(
ºº  
$str
ºº  $
,
ºº$ %
result
ºº& ,
.
ºº, -
Errors
ºº- 3
.
ºº3 4
Select
ºº4 :
(
ºº: ;
e
ºº; <
=>
ºº= ?
e
ºº@ A
.
ººA B
Description
ººB M
)
ººM N
)
ººN O
)
ΩΩ 
;
ΩΩ 
}
ææ 	
public
¿¿ 
async
¿¿ 
Task
¿¿ %
UpdatePatientEmailAsync
¿¿ 1
(
¿¿1 2
string
¿¿2 8
userId
¿¿9 ?
,
¿¿? @
string
¿¿A G
newEmail
¿¿H P
)
¿¿P Q
{
¡¡ 	
var
¬¬ 
user
¬¬ 
=
¬¬ 
await
¬¬ 
_userManager
¬¬ )
.
¬¬) *
FindByIdAsync
¬¬* 7
(
¬¬7 8
userId
¬¬8 >
)
¬¬> ?
;
¬¬? @
if
ƒƒ 
(
ƒƒ 
user
ƒƒ 
==
ƒƒ 
null
ƒƒ 
)
ƒƒ 
throw
≈≈ 
new
≈≈ '
InvalidOperationException
≈≈ 3
(
≈≈3 4
$str
≈≈4 D
)
≈≈D E
;
≈≈E F
var
»» 
existingUser
»» 
=
»» 
await
»» $
_userManager
»»% 1
.
»»1 2
FindByEmailAsync
»»2 B
(
»»B C
newEmail
»»C K
)
»»K L
;
»»L M
if
   
(
   
existingUser
   
!=
   
null
    $
&&
  % '
existingUser
  ( 4
.
  4 5
Id
  5 7
!=
  8 :
userId
  ; A
)
  A B
throw
ÀÀ 
new
ÀÀ '
InvalidOperationException
ÀÀ 3
(
ÀÀ3 4
$str
ÀÀ4 J
)
ÀÀJ K
;
ÀÀK L
user
ŒŒ 
.
ŒŒ 
Email
ŒŒ 
=
ŒŒ 
newEmail
ŒŒ !
;
ŒŒ! "
user
œœ 
.
œœ 
UserName
œœ 
=
œœ 
newEmail
œœ $
;
œœ$ %
var
—— 
result
—— 
=
—— 
await
—— 
_userManager
—— +
.
——+ ,
UpdateAsync
——, 7
(
——7 8
user
——8 <
)
——< =
;
——= >
if
”” 
(
”” 
!
”” 
result
”” 
.
”” 
	Succeeded
”” !
)
””! "
{
‘‘ 
throw
’’ 
new
’’ '
InvalidOperationException
’’ 3
(
’’3 4
string
÷÷ 
.
÷÷ 
Join
÷÷ 
(
÷÷  
$str
÷÷  $
,
÷÷$ %
result
÷÷& ,
.
÷÷, -
Errors
÷÷- 3
.
÷÷3 4
Select
÷÷4 :
(
÷÷: ;
e
÷÷; <
=>
÷÷= ?
e
÷÷@ A
.
÷÷A B
Description
÷÷B M
)
÷÷M N
)
÷÷N O
)
◊◊ 
;
◊◊ 
}
ÿÿ 
}
ŸŸ 	
}
€€ 
}‹‹ õ˜
qC:\Users\310055\source\repos\UST-Live-01\HealthCare\HealthCare.Api\Services\Implementations\AppointmentService.cs
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
AppointmentService #
:$ %
IAppointmentService& 9
{ 
private 
readonly "
IAppointmentRepository /
_repository0 ;
;; <
private 
readonly 
IDoctorService '
_doctorService( 6
;6 7
private 
readonly 
HealthCareDbContext ,
_context- 5
;5 6
private 
readonly 
IMapper  
_mapper! (
;( )
public 
AppointmentService !
(! ""
IAppointmentRepository" 8

repository9 C
,C D
IDoctorServiceE S
doctorServiceT a
,a b
HealthCareDbContextc v
contextw ~
,~ 
IMapper
Ä á
mapper
à é
)
é è
{ 	
_repository 
= 

repository $
;$ %
_doctorService 
= 
doctorService *
;* +
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
< 
AppointmentListDto ,
?, -
>- .
GetByIdAsync/ ;
(; <
int< ?
id@ B
)B C
{ 	
var 
appointment 
= 
await #
_repository$ /
./ 0
GetByIdAsync0 <
(< =
id= ?
)? @
;@ A
if   
(   
appointment   
is   
null   #
)  # $
throw!! 
new!! %
InvalidOperationException!! 3
(!!3 4
$str!!4 L
)!!L M
;!!M N
return## 
_mapper## 
.## 
Map## 
<## 
AppointmentListDto## 1
>##1 2
(##2 3
appointment##3 >
)##> ?
;##? @
}$$ 	
public&& 
async&& 
Task&& 
<&& 
PagedResult&& %
<&&% &
AppointmentListDto&&& 8
>&&8 9
>&&9 :
GetAllAsync&&; F
(&&F G
AppointmentFilter&&G X
filter&&Y _
)&&_ `
{'' 	

Expression)) 
<)) 
Func)) 
<)) 
Appointment)) '
,))' (
bool))) -
>))- .
>)). /
?))/ 0
	predicate))1 :
=)); <
null))= A
;))A B
if++ 
(++ 
!++ 
string++ 
.++ 
IsNullOrWhiteSpace++ *
(++* +
filter+++ 1
.++1 2
Status++2 8
)++8 9
&&++: <
filter++= C
.++C D
ScheduledDate++D Q
.++Q R
HasValue++R Z
)++Z [
{,, 
	predicate-- 
=-- 
a-- 
=>--  
a.. 
... 
Status.. 
==.. 
filter..  &
...& '
Status..' -
&&... 0
a// 
.// 
ScheduledDate// #
==//$ &
filter//' -
.//- .
ScheduledDate//. ;
.//; <
Value//< A
;//A B
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
.116 7
Status117 =
)11= >
)11> ?
{22 
	predicate33 
=33 
a33 
=>33  
a33! "
.33" #
Status33# )
==33* ,
filter33- 3
.333 4
Status334 :
;33: ;
}44 
else55 
if55 
(55 
filter55 
.55 
ScheduledDate55 )
.55) *
HasValue55* 2
)552 3
{66 
	predicate77 
=77 
a77 
=>77  
a77! "
.77" #
ScheduledDate77# 0
==771 3
filter774 :
.77: ;
ScheduledDate77; H
.77H I
Value77I N
;77N O
}88 
Func:: 
<:: 

IQueryable:: 
<:: 
Appointment:: '
>::' (
,::( )
IOrderedQueryable::* ;
<::; <
Appointment::< G
>::G H
>::H I
orderBy::J Q
=::R S
q;; 
=>;; 
q;; 
.;; 
OrderBy;; 
(;; 
a;;  
=>;;! #
a;;$ %
.;;% &
ScheduledDate;;& 3
);;3 4
;;;4 5
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
,@@ 
orderByAA 
)BB 
;BB 
returnDD 
newDD 
PagedResultDD "
<DD" #
AppointmentListDtoDD# 5
>DD5 6
{EE 
ItemsFF 
=FF 
_mapperFF 
.FF  
MapFF  #
<FF# $
IEnumerableFF$ /
<FF/ 0
AppointmentListDtoFF0 B
>FFB C
>FFC D
(FFD E
pagedResultFFE P
.FFP Q
ItemsFFQ V
)FFV W
,FFW X

PageNumberGG 
=GG 
pagedResultGG (
.GG( )

PageNumberGG) 3
,GG3 4
PageSizeHH 
=HH 
pagedResultHH &
.HH& '
PageSizeHH' /
,HH/ 0

TotalCountII 
=II 
pagedResultII (
.II( )

TotalCountII) 3
}JJ 
;JJ 
}KK 	
publicMM 
asyncMM 
TaskMM 
AddAsyncMM "
(MM" # 
CreateAppointmentDtoMM# 7
dtoMM8 ;
,MM; <
intMM= @
	patientIdMMA J
)MMJ K
{NN 	
ifOO 
(OO 
dtoOO 
.OO 
ScheduledDateOO !
<OO" #
DateOnlyOO$ ,
.OO, -
FromDateTimeOO- 9
(OO9 :
DateTimeOO: B
.OOB C
TodayOOC H
)OOH I
)OOI J
throwPP 
newPP %
InvalidOperationExceptionPP 3
(PP3 4
$strPP4 a
)PPa b
;PPb c
awaitRR 
IsAvailableRR 
(RR 
dtoRR !
.RR! "
ScheduledDateRR" /
,RR/ 0
dtoRR1 4
.RR4 5
DoctorIdRR5 =
,RR= >
dtoRR? B
.RRB C
TimeSlotRRC K
)RRK L
;RRL M
varTT 
appointmentTT 
=TT 
_mapperTT %
.TT% &
MapTT& )
<TT) *
AppointmentTT* 5
>TT5 6
(TT6 7
dtoTT7 :
)TT: ;
;TT; <
appointmentUU 
.UU 
	PatientIdUU !
=UU" #
	patientIdUU$ -
;UU- .
tryWW 
{XX 
awaitYY 
_repositoryYY !
.YY! "
AddAsyncYY" *
(YY* +
appointmentYY+ 6
)YY6 7
;YY7 8
awaitZZ 
_contextZZ 
.ZZ 
SaveChangesAsyncZZ /
(ZZ/ 0
)ZZ0 1
;ZZ1 2
}[[ 
catch\\ 
(\\ 
DbUpdateException\\ $
ex\\% '
)\\' (
{]] 
throw^^ 
new^^ %
InvalidOperationException^^ 3
(^^3 4
$str^^4 U
,^^U V
ex^^W Y
)^^Y Z
;^^Z [
}__ 
}`` 	
publicbb 
asyncbb 
Taskbb 
UpdateAsyncbb %
(bb% &
intbb& )
idbb* ,
,bb, - 
UpdateAppointmentDtobb. B
dtobbC F
)bbF G
{cc 	
vardd 
appointmentdd 
=dd 
awaitdd #
_repositorydd$ /
.dd/ 0
GetByIdAsyncdd0 <
(dd< =
iddd= ?
)dd? @
;dd@ A
ifff 
(ff 
appointmentff 
isff 
nullff #
)ff# $
throwgg 
newgg %
InvalidOperationExceptiongg 3
(gg3 4
$strgg4 L
)ggL M
;ggM N
_mapperii 
.ii 
Mapii 
(ii 
dtoii 
,ii 
appointmentii (
)ii( )
;ii) *
awaitjj 
_repositoryjj 
.jj 
UpdateAsyncjj )
(jj) *
appointmentjj* 5
)jj5 6
;jj6 7
awaitkk 
_contextkk 
.kk 
SaveChangesAsynckk +
(kk+ ,
)kk, -
;kk- .
}ll 	
publicnn 
asyncnn 
Tasknn 
UpdateStatusAsyncnn +
(nn+ ,
intnn, /
idnn0 2
,nn2 3 
UpdateAppointmentDtonn4 H
dtonnI L
)nnL M
{oo 	
varpp 
appointmentpp 
=pp 
awaitpp #
_repositorypp$ /
.pp/ 0
GetByIdAsyncpp0 <
(pp< =
idpp= ?
)pp? @
;pp@ A
ifrr 
(rr 
appointmentrr 
isrr 
nullrr #
)rr# $
throwss 
newss %
InvalidOperationExceptionss 3
(ss3 4
$strss4 L
)ssL M
;ssM N
varvv 
validStatusesvv 
=vv 
newvv  #
[vv# $
]vv$ %
{vv& '
$strvv( 1
,vv1 2
$strvv3 >
,vv> ?
$strvv@ K
,vvK L
$strvvM X
}vvY Z
;vvZ [
ifyy 
(yy 
!yy 
validStatusesyy 
.yy 
Containsyy '
(yy' (
dtoyy( +
.yy+ ,
Statusyy, 2
,yy2 3
StringCompareryy4 B
.yyB C
OrdinalIgnoreCaseyyC T
)yyT U
)yyU V
{zz 
throw{{ 
new{{ %
InvalidOperationException{{ 3
({{3 4
$str{{4 J
){{J K
;{{K L
}|| 
if 
( 
dto 
. 
Status 
== 
$str )
&&* ,
string- 3
.3 4
IsNullOrWhiteSpace4 F
(F G
dtoG J
.J K
CancellationReasonK ]
)] ^
)^ _
{
ÄÄ 
throw
ÅÅ 
new
ÅÅ '
InvalidOperationException
ÅÅ 3
(
ÅÅ3 4
$str
ÅÅ4 n
)
ÅÅn o
;
ÅÅo p
}
ÇÇ 
appointment
ÖÖ 
.
ÖÖ 
Status
ÖÖ 
=
ÖÖ  
dto
ÖÖ! $
.
ÖÖ$ %
Status
ÖÖ% +
;
ÖÖ+ ,
appointment
ÜÜ 
.
ÜÜ  
CancellationReason
ÜÜ *
=
ÜÜ+ ,
dto
ÜÜ- 0
.
ÜÜ0 1
Status
ÜÜ1 7
==
ÜÜ8 :
$str
ÜÜ; F
?
áá 
dto
áá 
.
áá  
CancellationReason
áá (
:
àà 
null
àà 
;
àà 
await
ää 
_repository
ää 
.
ää 
UpdateAsync
ää )
(
ää) *
appointment
ää* 5
)
ää5 6
;
ää6 7
await
ãã 
_context
ãã 
.
ãã 
SaveChangesAsync
ãã +
(
ãã+ ,
)
ãã, -
;
ãã- .
}
åå 	
public
èè 
async
èè 
Task
èè 
DeleteAsync
èè %
(
èè% &
int
èè& )
id
èè* ,
)
èè, -
{
êê 	
var
ëë 
appointment
ëë 
=
ëë 
await
ëë #
_repository
ëë$ /
.
ëë/ 0
GetByIdAsync
ëë0 <
(
ëë< =
id
ëë= ?
)
ëë? @
;
ëë@ A
if
ìì 
(
ìì 
appointment
ìì 
is
ìì 
null
ìì #
)
ìì# $
throw
îî 
new
îî '
InvalidOperationException
îî 3
(
îî3 4
$str
îî4 L
)
îîL M
;
îîM N
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
$strúú4 Ñ
,úúÑ Ö
exúúÜ à
)úúà â
;úúâ ä
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
††& ' 
AvailableTimeSlots
††( :
(
††: ;
DateOnly
††; C
date
††D H
,
††H I
int
††J M
doctorId
††N V
)
††V W
{
°° 	
if
¢¢ 
(
¢¢ 
date
¢¢ 
<
¢¢ 
DateOnly
¢¢ 
.
¢¢  
FromDateTime
¢¢  ,
(
¢¢, -
DateTime
¢¢- 5
.
¢¢5 6
Today
¢¢6 ;
)
¢¢; <
)
¢¢< =
throw
££ 
new
££ '
InvalidOperationException
££ 3
(
££3 4
$str
££4 `
)
££` a
;
££a b
var
•• 
allSlots
•• 
=
•• 
await
••  
_doctorService
••! /
.
••/ 0
GetSlots
••0 8
(
••8 9
doctorId
••9 A
)
••A B
;
••B C
var
¶¶ 
bookedSlots
¶¶ 
=
¶¶ 
await
¶¶ #
_repository
¶¶$ /
.
¶¶/ 0
BookedTimeSlots
¶¶0 ?
(
¶¶? @
date
¶¶@ D
,
¶¶D E
doctorId
¶¶F N
)
¶¶N O
;
¶¶O P
var
®® 
	freeSlots
®® 
=
®® 
allSlots
®® $
.
©© 
Where
©© 

(
©©
 
slot
©© 
=>
©© 
!
™™ 	
bookedSlots
™™	 
.
™™ 
Any
™™ 
(
™™ 
b
™™ 
=>
™™ 
b
´´ 
.
´´ 
Trim
´´ 
(
´´ 
)
´´ 
.
´´ 
ToLower
´´ 
(
´´ 
)
´´ 
.
´´ 

StartsWith
´´ )
(
´´) *
slot
´´* .
.
´´. /
Trim
´´/ 3
(
´´3 4
)
´´4 5
.
´´5 6
ToLower
´´6 =
(
´´= >
)
´´> ?
.
´´? @
	Substring
´´@ I
(
´´I J
$num
´´J K
,
´´K L
$num
´´M N
)
´´N O
)
´´O P
)
¨¨ 	
)
≠≠ 
.
ÆÆ 
ToList
ÆÆ 
(
ÆÆ 
)
ÆÆ 
;
ÆÆ 
return
∞∞ 
	freeSlots
∞∞ 
;
∞∞ 
}
±± 	
public
≥≥ 
async
≥≥ 
Task
≥≥ 
<
≥≥ 
bool
≥≥ 
>
≥≥ 
IsAvailable
≥≥  +
(
≥≥+ ,
DateOnly
≥≥, 4
date
≥≥5 9
,
≥≥9 :
int
≥≥; >
doctorId
≥≥? G
,
≥≥G H
string
≥≥I O
timeSlot
≥≥P X
)
≥≥X Y
{
¥¥ 	
var
µµ 
bookedSlots
µµ 
=
µµ 
await
µµ #
_repository
µµ$ /
.
µµ/ 0
BookedTimeSlots
µµ0 ?
(
µµ? @
date
µµ@ D
,
µµD E
doctorId
µµF N
)
µµN O
;
µµO P
var
∑∑ 

normalized
∑∑ 
=
∑∑ 
timeSlot
∑∑ %
.
∑∑% &
Trim
∑∑& *
(
∑∑* +
)
∑∑+ ,
.
∑∑, -
ToLower
∑∑- 4
(
∑∑4 5
)
∑∑5 6
;
∑∑6 7
var
ππ 
exists
ππ 
=
ππ 
bookedSlots
ππ $
.
ππ$ %
Any
ππ% (
(
ππ( )
b
ππ) *
=>
ππ+ -
b
∫∫ 
.
∫∫ 
Trim
∫∫ 
(
∫∫ 
)
∫∫ 
.
∫∫ 
ToLower
∫∫  
(
∫∫  !
)
∫∫! "
.
∫∫" #

StartsWith
∫∫# -
(
∫∫- .

normalized
∫∫. 8
.
∫∫8 9
	Substring
∫∫9 B
(
∫∫B C
$num
∫∫C D
,
∫∫D E
$num
∫∫F G
)
∫∫G H
)
∫∫H I
)
ªª 
;
ªª 
if
ΩΩ 
(
ΩΩ 
exists
ΩΩ 
)
ΩΩ 
throw
ææ 
new
ææ '
InvalidOperationException
ææ 3
(
ææ3 4
$str
ææ4 W
)
ææW X
;
ææX Y
return
¿¿ 
true
¿¿ 
;
¿¿ 
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
√√  
AppointmentListDto
√√ 1
>
√√1 2
>
√√2 3
GetDoctorSchedule
√√4 E
(
√√E F
DateOnly
√√F N
date
√√O S
,
√√S T
int
√√U X
id
√√Y [
)
√√[ \
{
ƒƒ 	
var
≈≈ 
schedule
≈≈ 
=
≈≈ 
await
≈≈  
_repository
≈≈! ,
.
≈≈, -
GetDoctorSchedule
≈≈- >
(
≈≈> ?
date
≈≈? C
,
≈≈C D
id
≈≈E G
)
≈≈G H
;
≈≈H I
return
∆∆ 
schedule
∆∆ 
.
∆∆ 
Count
∆∆ !
==
∆∆" $
$num
∆∆% &
?
∆∆' (
new
∆∆) ,
List
∆∆- 1
<
∆∆1 2 
AppointmentListDto
∆∆2 D
>
∆∆D E
(
∆∆E F
)
∆∆F G
:
∆∆H I
schedule
∆∆J R
;
∆∆R S
}
«« 	
public
…… 
async
…… 
Task
…… 
<
…… 
List
…… 
<
……  
AppointmentListDto
…… 1
>
……1 2
>
……2 3 
GetPatientSchedule
……4 F
(
……F G
DateOnly
……G O
date
……P T
,
……T U
int
……V Y
id
……Z \
)
……\ ]
{
   	
var
ÀÀ 
schedule
ÀÀ 
=
ÀÀ 
await
ÀÀ  
_repository
ÀÀ! ,
.
ÀÀ, - 
GetPatientSchedule
ÀÀ- ?
(
ÀÀ? @
date
ÀÀ@ D
,
ÀÀD E
id
ÀÀF H
)
ÀÀH I
;
ÀÀI J
return
ÃÃ 
schedule
ÃÃ 
.
ÃÃ 
Count
ÃÃ !
==
ÃÃ" $
$num
ÃÃ% &
?
ÃÃ' (
new
ÃÃ) ,
List
ÃÃ- 1
<
ÃÃ1 2 
AppointmentListDto
ÃÃ2 D
>
ÃÃD E
(
ÃÃE F
)
ÃÃF G
:
ÃÃH I
schedule
ÃÃJ R
;
ÃÃR S
}
ÕÕ 	
public
œœ 
async
œœ 
Task
œœ 
<
œœ 
List
œœ 
<
œœ  
AppointmentListDto
œœ 1
>
œœ1 2
>
œœ2 3%
GetAppointmentByPatient
œœ4 K
(
œœK L
int
œœL O
id
œœP R
)
œœR S
{
–– 	
var
—— 
appointments
—— 
=
—— 
await
—— $
_repository
——% 0
.
——0 1%
GetAppointmentByPatient
——1 H
(
——H I
id
——I K
)
——K L
;
——L M
return
”” 
appointments
”” 
.
‘‘ 
Where
‘‘ 
(
‘‘ 
a
‘‘ 
=>
‘‘ 
a
‘‘ 
.
‘‘ 
Status
‘‘ $
==
‘‘% '
$str
‘‘( 1
||
‘‘2 4
a
‘‘5 6
.
‘‘6 7
Status
‘‘7 =
==
‘‘> @
$str
‘‘A L
)
‘‘L M
.
’’ 
OrderBy
’’ 
(
’’ 
a
’’ 
=>
’’ 
a
’’ 
.
’’  
ScheduledDate
’’  -
)
’’- .
.
÷÷ 
ToList
÷÷ 
(
÷÷ 
)
÷÷ 
;
÷÷ 
}
◊◊ 	
public
ÿÿ 
async
ÿÿ 
Task
ÿÿ 
<
ÿÿ 
List
ÿÿ 
<
ÿÿ  
AppointmentListDto
ÿÿ 1
>
ÿÿ1 2
>
ÿÿ2 3$
GetAppointmentByDoctor
ÿÿ4 J
(
ÿÿJ K
int
ÿÿK N
id
ÿÿO Q
)
ÿÿQ R
{
ŸŸ 	
var
€€ 
appointments
€€ 
=
€€ 
await
€€ $
_repository
€€% 0
.
€€0 1$
GetAppointmentByDoctor
€€1 G
(
€€G H
id
€€H J
)
€€J K
;
€€K L
var
ﬁﬁ 
today
ﬁﬁ 
=
ﬁﬁ 
DateOnly
ﬁﬁ  
.
ﬁﬁ  !
FromDateTime
ﬁﬁ! -
(
ﬁﬁ- .
DateTime
ﬁﬁ. 6
.
ﬁﬁ6 7
Today
ﬁﬁ7 <
)
ﬁﬁ< =
;
ﬁﬁ= >
var
·· 
result
·· 
=
·· 
appointments
·· %
.
‚‚ 
Where
‚‚ 
(
‚‚ 
a
‚‚ 
=>
‚‚ 
a
„„ 
.
„„ 
ScheduledDate
„„ #
>=
„„$ &
today
„„' ,
&&
„„- /
(
‰‰ 
a
ÂÂ 
.
ÂÂ 
Status
ÂÂ  
.
ÂÂ  !
Equals
ÂÂ! '
(
ÂÂ' (
$str
ÂÂ( 1
,
ÂÂ1 2
StringComparison
ÂÂ3 C
.
ÂÂC D
OrdinalIgnoreCase
ÂÂD U
)
ÂÂU V
||
ÂÂW Y
a
ÊÊ 
.
ÊÊ 
Status
ÊÊ  
.
ÊÊ  !
Equals
ÊÊ! '
(
ÊÊ' (
$str
ÊÊ( 3
,
ÊÊ3 4
StringComparison
ÊÊ5 E
.
ÊÊE F
OrdinalIgnoreCase
ÊÊF W
)
ÊÊW X
)
ÁÁ 
)
ËË 
.
ÈÈ 
OrderBy
ÈÈ 
(
ÈÈ 
a
ÈÈ 
=>
ÈÈ 
a
ÈÈ 
.
ÈÈ  
ScheduledDate
ÈÈ  -
)
ÈÈ- .
.
ÍÍ 
ThenBy
ÍÍ 
(
ÍÍ 
a
ÍÍ 
=>
ÍÍ 
a
ÍÍ 
.
ÍÍ 
TimeSlot
ÍÍ '
)
ÍÍ' (
.
ÎÎ 
ToList
ÎÎ 
(
ÎÎ 
)
ÎÎ 
;
ÎÎ 
return
ÌÌ 
result
ÌÌ 
;
ÌÌ 
}
ÓÓ 	
public
 
async
 
Task
 ,
CancelAppointmentsByDoctorDate
 8
(
8 9
int
9 <
doctorId
= E
,
E F
DateOnly
G O
date
P T
)
T U
{
ÒÒ 	
await
ÚÚ 
_repository
ÚÚ 
.
ÚÚ ,
CancelAppointmentsByDoctorDate
ÚÚ <
(
ÚÚ< =
doctorId
ÚÚ= E
,
ÚÚE F
date
ÚÚG K
)
ÚÚK L
;
ÚÚL M
await
ÛÛ 
_context
ÛÛ 
.
ÛÛ 
SaveChangesAsync
ÛÛ +
(
ÛÛ+ ,
)
ÛÛ, -
;
ÛÛ- .
}
ÙÙ 	
public
ˆˆ 
async
ˆˆ 
Task
ˆˆ 
<
ˆˆ 
List
ˆˆ 
<
ˆˆ "
AppointmentReportDto
ˆˆ 3
>
ˆˆ3 4
>
ˆˆ4 5
GetDailyReport
ˆˆ6 D
(
ˆˆD E
)
ˆˆE F
{
¯¯ 	
var
˙˙ 
report
˙˙ 
=
˙˙ 
await
˙˙ 
_repository
˙˙ *
.
˙˙* +
GetDailyReport
˙˙+ 9
(
˙˙9 :
)
˙˙: ;
;
˙˙; <
return
¸¸ 
report
¸¸ 
.
¸¸ 
Count
¸¸ 
==
¸¸  "
$num
¸¸# $
?
¸¸% &
new
¸¸' *
List
¸¸+ /
<
¸¸/ 0"
AppointmentReportDto
¸¸0 D
>
¸¸D E
(
¸¸E F
)
¸¸F G
:
¸¸H I
report
¸¸J P
;
¸¸P Q
}
˛˛ 	
public
ÄÄ 
async
ÄÄ 
Task
ÄÄ 
<
ÄÄ 
List
ÄÄ 
<
ÄÄ "
AppointmentReportDto
ÄÄ 3
>
ÄÄ3 4
>
ÄÄ4 5"
GetReportByDateRange
ÄÄ6 J
(
ÄÄJ K
DateOnly
ÅÅ 
	startDate
ÅÅ 
,
ÅÅ 
DateOnly
ÇÇ 
endDate
ÇÇ 
)
ÇÇ 
{
ÉÉ 	
var
ÑÑ 
report
ÑÑ 
=
ÑÑ 
await
ÑÑ 
_context
ÑÑ '
.
ÑÑ' (
Appointments
ÑÑ( 4
.
ÖÖ 
Include
ÖÖ 
(
ÖÖ 
a
ÖÖ 
=>
ÖÖ 
a
ÖÖ 
.
ÖÖ  
Doctor
ÖÖ  &
)
ÖÖ& '
.
ÜÜ 
Where
ÜÜ 
(
ÜÜ 
a
ÜÜ 
=>
ÜÜ 
a
ÜÜ 
.
ÜÜ 
ScheduledDate
ÜÜ +
>=
ÜÜ, .
	startDate
ÜÜ/ 8
&&
ÜÜ9 ;
a
áá 
.
áá 
ScheduledDate
áá +
<=
áá, .
endDate
áá/ 6
)
áá6 7
.
àà 
GroupBy
àà 
(
àà 
a
àà 
=>
àà 
a
àà 
.
àà  
ScheduledDate
àà  -
)
àà- .
.
ââ 
Select
ââ 
(
ââ 
g
ââ 
=>
ââ 
new
ââ  "
AppointmentReportDto
ââ! 5
{
ää 
Date
ãã 
=
ãã 
g
ãã 
.
ãã 
Key
ãã  
,
ãã  !
PendingCount
çç  
=
çç! "
g
çç# $
.
çç$ %
Count
çç% *
(
çç* +
a
çç+ ,
=>
çç- /
a
çç0 1
.
çç1 2
Status
çç2 8
==
çç9 ;
$str
çç< E
)
ççE F
,
ççF G
ConfirmedCount
éé "
=
éé# $
g
éé% &
.
éé& '
Count
éé' ,
(
éé, -
a
éé- .
=>
éé/ 1
a
éé2 3
.
éé3 4
Status
éé4 :
==
éé; =
$str
éé> I
)
ééI J
,
ééJ K
CancelledCount
èè "
=
èè# $
g
èè% &
.
èè& '
Count
èè' ,
(
èè, -
a
èè- .
=>
èè/ 1
a
èè2 3
.
èè3 4
Status
èè4 :
==
èè; =
$str
èè> I
)
èèI J
,
èèJ K
CompletedCount
êê "
=
êê# $
g
êê% &
.
êê& '
Count
êê' ,
(
êê, -
a
êê- .
=>
êê/ 1
a
êê2 3
.
êê3 4
Status
êê4 :
==
êê; =
$str
êê> I
)
êêI J
,
êêJ K
Revenue
íí 
=
íí 
g
íí 
.
ìì 
Where
ìì 
(
ìì 
a
ìì  
=>
ìì! #
a
ìì$ %
.
ìì% &
Status
ìì& ,
==
ìì- /
$str
ìì0 ;
)
ìì; <
.
îî 
Sum
îî 
(
îî 
a
îî 
=>
îî !
(
îî" #
decimal
îî# *
?
îî* +
)
îî+ ,
a
îî, -
.
îî- .
Doctor
îî. 4
.
îî4 5
ConsultationFee
îî5 D
)
îîD E
??
îîF H
$num
îîI J
}
ïï 
)
ïï 
.
ññ 
OrderBy
ññ 
(
ññ 
r
ññ 
=>
ññ 
r
ññ 
.
ññ  
Date
ññ  $
)
ññ$ %
.
óó 
ToListAsync
óó 
(
óó 
)
óó 
;
óó 
return
ôô 
report
ôô 
;
ôô 
}
öö 	
public
úú 
async
úú 
Task
úú 
<
úú #
AppointmentSummaryDto
úú /
>
úú/ 0
GetSummaryAsync
úú1 @
(
úú@ A
)
úúA B
{
ùù 	
var
ûû 
fromDate
ûû 
=
ûû 
DateOnly
ûû #
.
ûû# $
FromDateTime
ûû$ 0
(
ûû0 1
DateTime
ûû1 9
.
ûû9 :
Today
ûû: ?
.
ûû? @
AddDays
ûû@ G
(
ûûG H
-
ûûH I
$num
ûûI K
)
ûûK L
)
ûûL M
;
ûûM N
var
üü 
toDate
üü 
=
üü 
DateOnly
üü !
.
üü! "
FromDateTime
üü" .
(
üü. /
DateTime
üü/ 7
.
üü7 8
Today
üü8 =
)
üü= >
;
üü> ?
var
°° 
result
°° 
=
°° 
await
°° 
_context
°° '
.
°°' (
Appointments
°°( 4
.
¢¢ 
Include
¢¢ 
(
¢¢ 
a
¢¢ 
=>
¢¢ 
a
¢¢ 
.
¢¢  
Doctor
¢¢  &
)
¢¢& '
.
££ 
Where
££ 
(
££ 
a
££ 
=>
££ 
a
££ 
.
££ 
ScheduledDate
££ +
>=
££, .
fromDate
££/ 7
&&
££8 :
a
££; <
.
££< =
ScheduledDate
££= J
<=
££K M
toDate
££N T
)
££T U
.
§§ 
GroupBy
§§ 
(
§§ 
a
§§ 
=>
§§ 
$num
§§ 
)
§§  
.
•• 
Select
•• 
(
•• 
g
•• 
=>
•• 
new
••  #
AppointmentSummaryDto
••! 6
{
¶¶ 
PendingCount
ßß  
=
ßß! "
g
ßß# $
.
ßß$ %
Count
ßß% *
(
ßß* +
a
ßß+ ,
=>
ßß- /
a
ßß0 1
.
ßß1 2
Status
ßß2 8
==
ßß9 ;
$str
ßß< E
)
ßßE F
,
ßßF G
ConfirmedCount
®® "
=
®®# $
g
®®% &
.
®®& '
Count
®®' ,
(
®®, -
a
®®- .
=>
®®/ 1
a
®®2 3
.
®®3 4
Status
®®4 :
==
®®; =
$str
®®> I
)
®®I J
,
®®J K
CancelledCount
©© "
=
©©# $
g
©©% &
.
©©& '
Count
©©' ,
(
©©, -
a
©©- .
=>
©©/ 1
a
©©2 3
.
©©3 4
Status
©©4 :
==
©©; =
$str
©©> I
)
©©I J
,
©©J K
CompletedCount
™™ "
=
™™# $
g
™™% &
.
™™& '
Count
™™' ,
(
™™, -
a
™™- .
=>
™™/ 1
a
™™2 3
.
™™3 4
Status
™™4 :
==
™™; =
$str
™™> I
)
™™I J
,
™™J K
TotalRevenue
¨¨  
=
¨¨! "
g
¨¨# $
.
≠≠ 
Where
≠≠ 
(
≠≠ 
a
≠≠  
=>
≠≠! #
a
≠≠$ %
.
≠≠% &
Status
≠≠& ,
==
≠≠- /
$str
≠≠0 ;
)
≠≠; <
.
ÆÆ 
Sum
ÆÆ 
(
ÆÆ 
a
ÆÆ 
=>
ÆÆ !
a
ÆÆ" #
.
ÆÆ# $
Doctor
ÆÆ$ *
.
ÆÆ* +
ConsultationFee
ÆÆ+ :
)
ÆÆ: ;
}
ØØ 
)
ØØ 
.
∞∞ !
FirstOrDefaultAsync
∞∞ $
(
∞∞$ %
)
∞∞% &
;
∞∞& '
return
≤≤ 
result
≤≤ 
??
≤≤ 
new
≤≤  #
AppointmentSummaryDto
≤≤! 6
(
≤≤6 7
)
≤≤7 8
;
≤≤8 9
}
≥≥ 	
}
¥¥ 
}µµ ¬
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
a 
. 
ScheduledDate 
== 
date #
&& 
a 
. 
DoctorId 
== 
doctorId %
&& 
a 
. 
Status 
!= 
	Cancelled $
&& 
a 
. 
TimeSlot 
. 
Contains "
(" #
timeSlot# +
)+ ,
&& 
a 
. 
TimeSlot 
. 
Contains "
(" #
timeSlot# +
.+ ,
	Substring, 5
(5 6
$num6 7
,7 8
$num9 :
): ;
); <
) 	
;	 

return"" 
!"" 
exists"" 
;"" 
}## 	
public%% 
async%% 
Task%% 
<%% 
List%% 
<%%  
AppointmentReportDto%% 3
>%%3 4
>%%4 5
GetDailyReport%%6 D
(%%D E
)%%E F
=>%%G I
await&& 
_dbSet&& 
.'' 
Where'' 
('' 
a'' 
=>'' 
a'' 
.'' 
ScheduledDate'' +
>='', .
DateOnly''/ 7
.''7 8
FromDateTime''8 D
(''D E
DateTime''E M
.''M N
Today''N S
.''S T
AddDays''T [
(''[ \
-''\ ]
$num''] _
)''_ `
)''` a
)''a b
.(( 
GroupBy(( 
((( 
a(( 
=>(( 
a(( 
.((  
ScheduledDate((  -
)((- .
.)) 
Select)) 
()) 
g)) 
=>)) 
new))   
AppointmentReportDto))! 5
{** 
Date++ 
=++ 
g++ 
.++ 
Key++  
,++  !
PendingCount,,  
=,,! "
g,,# $
.,,$ %
Count,,% *
(,,* +
a,,+ ,
=>,,- /
a,,0 1
.,,1 2
Status,,2 8
==,,9 ;
$str,,< E
),,E F
,,,F G
ConfirmedCount-- "
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
==--; =
$str--> I
)--I J
,--J K
CancelledCount.. "
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
==..; =
	Cancelled..> G
)..G H
,..H I
CompletedCount// "
=//# $
g//% &
.//& '
Count//' ,
(//, -
a//- .
=>/// 1
a//2 3
.//3 4
Status//4 :
==//; =
$str//> I
)//I J
}00 
)00 
.11 
OrderBy11 
(11 
r11 
=>11 
r11 
.11  
Date11  $
)11$ %
.22 
ToListAsync22 
(22 
)22 
;22 
public44 
async44 
Task44 
<44 
List44 
<44 
AppointmentListDto44 1
>441 2
>442 3
GetDoctorSchedule444 E
(44E F
DateOnly44F N
date44O S
,44S T
int44U X
id44Y [
)44[ \
=>44] _
await55 
_dbSet55 
.66 
Where66 
(66 
a66 
=>66 
a66 
.66 
ScheduledDate66 +
==66, .
date66/ 3
&&664 6
a667 8
.668 9
DoctorId669 A
==66B D
id66E G
)66G H
.77 
Select77 
(77 
a77 
=>77 
new77  
AppointmentListDto77! 3
{88 
AppointmentId99 !
=99" #
a99$ %
.99% &
AppointmentId99& 3
,993 4
PatientName:: 
=::  !
a::" #
.::# $
Patient::$ +
.::+ ,
FullName::, 4
,::4 5

DoctorName;; 
=;;  
a;;! "
.;;" #
Doctor;;# )
.;;) *
FullName;;* 2
,;;2 3
ScheduledDate<< !
=<<" #
a<<$ %
.<<% &
ScheduledDate<<& 3
,<<3 4
TimeSlot== 
=== 
a==  
.==  !
TimeSlot==! )
,==) *
Status>> 
=>> 
a>> 
.>> 
Status>> %
}?? 
)?? 
.@@ 
ToListAsync@@ 
(@@ 
)@@ 
;@@ 
publicBB 
asyncBB 
TaskBB 
<BB 
ListBB 
<BB 
AppointmentListDtoBB 1
>BB1 2
>BB2 3
GetPatientScheduleBB4 F
(BBF G
DateOnlyBBG O
dateBBP T
,BBT U
intBBV Y
idBBZ \
)BB\ ]
=>BB^ `
awaitCC 
_dbSetCC 
.DD 
WhereDD 
(DD 
aDD 
=>DD 
aDD 
.DD 
ScheduledDateDD +
==DD, .
dateDD/ 3
&&DD4 6
aDD7 8
.DD8 9
	PatientIdDD9 B
==DDC E
idDDF H
)DDH I
.EE 
SelectEE 
(EE 
aEE 
=>EE 
newEE  
AppointmentListDtoEE! 3
{FF 
AppointmentIdGG !
=GG" #
aGG$ %
.GG% &
AppointmentIdGG& 3
,GG3 4
PatientNameHH 
=HH  !
aHH" #
.HH# $
PatientHH$ +
.HH+ ,
FullNameHH, 4
,HH4 5

DoctorNameII 
=II  
aII! "
.II" #
DoctorII# )
.II) *
FullNameII* 2
,II2 3
ScheduledDateJJ !
=JJ" #
aJJ$ %
.JJ% &
ScheduledDateJJ& 3
,JJ3 4
TimeSlotKK 
=KK 
aKK  
.KK  !
TimeSlotKK! )
,KK) *
StatusLL 
=LL 
aLL 
.LL 
StatusLL %
}MM 
)MM 
.NN 
ToListAsyncNN 
(NN 
)NN 
;NN 
publicPP 
asyncPP 
TaskPP 
<PP 
ListPP 
<PP 
AppointmentListDtoPP 1
>PP1 2
>PP2 3#
GetAppointmentByPatientPP4 K
(PPK L
intPPL O
idPPP R
)PPR S
=>PPT V
awaitQQ 	
_dbSetQQ
 
.RR 	
WhereRR	 
(RR 
aRR 
=>RR 
aRR 
.RR 
	PatientIdRR 
==RR  "
idRR# %
)RR% &
.SS 	
SelectSS	 
(SS 
aSS 
=>SS 
newSS 
AppointmentListDtoSS +
{TT 	
AppointmentIdUU 
=UU 
aUU 
.UU 
AppointmentIdUU +
,UU+ ,
PatientNameVV 
=VV 
aVV 
.VV 
PatientVV #
.VV# $
FullNameVV$ ,
,VV, -

DoctorNameWW 
=WW 
aWW 
.WW 
DoctorWW !
.WW! "
FullNameWW" *
,WW* +
ScheduledDateXX 
=XX 
aXX 
.XX 
ScheduledDateXX +
,XX+ ,
TimeSlotYY 
=YY 
aYY 
.YY 
TimeSlotYY !
,YY! "
StatusZZ 
=ZZ 
aZZ 
.ZZ 
StatusZZ 
}[[ 	
)[[	 

.\\ 	
ToListAsync\\	 
(\\ 
)\\ 
;\\ 
public^^ 
async^^ 
Task^^ 
<^^ 
List^^ 
<^^ 
AppointmentListDto^^ 1
>^^1 2
>^^2 3"
GetAppointmentByDoctor^^4 J
(^^J K
int^^K N
id^^O Q
)^^Q R
=>^^S U
await__ 
_dbSet__ 
.`` 
Where`` 
(`` 
a`` 
=>`` 
a`` 
.`` 
DoctorId`` &
==``' )
id``* ,
&&``- /
a``0 1
.``1 2
ScheduledDate``2 ?
>=``@ B
DateOnly``C K
.``K L
FromDateTime``L X
(``X Y
DateTime``Y a
.``a b
Today``b g
)``g h
)``h i
.aa 
Selectaa 
(aa 
aaa 
=>aa 
newaa  
AppointmentListDtoaa! 3
{bb 
AppointmentIdcc !
=cc" #
acc$ %
.cc% &
AppointmentIdcc& 3
,cc3 4
	PatientIddd 
=dd 
add  !
.dd! "
	PatientIddd" +
,dd+ ,
PatientNameee 
=ee  !
aee" #
.ee# $
Patientee$ +
.ee+ ,
FullNameee, 4
,ee4 5

DoctorNameff 
=ff  
aff! "
.ff" #
Doctorff# )
.ff) *
FullNameff* 2
,ff2 3
ScheduledDategg !
=gg" #
agg$ %
.gg% &
ScheduledDategg& 3
,gg3 4
TimeSlothh 
=hh 
ahh  
.hh  !
TimeSlothh! )
,hh) *
Statusii 
=ii 
aii 
.ii 
Statusii %
}jj 
)jj 
.kk 
ToListAsynckk 
(kk 
)kk 
;kk 
publicmm 
asyncmm 
Taskmm *
CancelAppointmentsByDoctorDatemm 8
(mm8 9
intmm9 <
doctorIdmm= E
,mmE F
DateOnlymmG O
datemmP T
)mmT U
{nn 	
varoo 
appointmentsoo 
=oo 
awaitoo $
_dbSetoo% +
.pp 
Wherepp 
(pp 
app 
=>pp 
app 
.pp 
DoctorIdpp &
==pp' )
doctorIdpp* 2
&&qq 
aqq 
.qq 
ScheduledDateqq +
==qq, .
dateqq/ 3
&&rr 
arr 
.rr 
Statusrr $
!=rr% '
	Cancelledrr( 1
)rr1 2
.ss 
ToListAsyncss 
(ss 
)ss 
;ss 
foreachuu 
(uu 
varuu 
appointmentuu $
inuu% '
appointmentsuu( 4
)uu4 5
{vv 
appointmentww 
.ww 
Statusww "
=ww# $
	Cancelledww% .
;ww. /
appointmentxx 
.xx 
CancellationReasonxx .
=xx/ 0
$strxx1 B
;xxB C
}yy 
}zz 	
}{{ 
}|| ≥q
MC:\Users\310055\source\repos\UST-Live-01\HealthCare\HealthCare.Api\Program.cs
var 
builder 
= 
WebApplication 
. 
CreateBuilder *
(* +
args+ /
)/ 0
;0 1
builder 
. 
Services 
. 
AddProblemDetails "
(" #
)# $
;$ %
builder 
. 
Services 
. 
AddExceptionHandler $
<$ %"
GlobalExceptionHandler% ;
>; <
(< =
)= >
;> ?
builder 
. 
Services 
. 
AddControllers 
(  
)  !
. 
AddJsonOptions 
( 
options 
=> 
{ 
options 
. !
JsonSerializerOptions %
.% & 
PropertyNamingPolicy& :
=; <
System 
. 
Text 
. 
Json 
. 
JsonNamingPolicy -
.- .
	CamelCase. 7
;7 8
} 
) 
; 
builder 
. 
Services 
. 
AddAutoMapper 
( 
cfg "
=># %
{ 
cfg 
. 

AddProfile 
< 
MappingProfile !
>! "
(" #
)# $
;$ %
}   
)   
;   
builder"" 
."" 
Services"" 
."" 
AddDbContext"" 
<"" 
HealthCareDbContext"" 1
>""1 2
(""2 3
options""3 :
=>""; =
options## 
.## 
UseSqlServer## 
(## 
builder##  
.##  !
Configuration##! .
.##. /
GetConnectionString##/ B
(##B C
$str##C [
)##[ \
)##\ ]
)$$ 
;$$ 
builder&& 
.&& 
Services&& 
.&& 
AddIdentity&& 
<&& 
IdentityUser&& )
,&&) *
IdentityRole&&+ 7
>&&7 8
(&&8 9
options&&9 @
=>&&A C
{'' 
options(( 
.(( 
User(( 
.(( 
RequireUniqueEmail(( #
=(($ %
true((& *
;((* +
options)) 
.)) 
Password)) 
.)) 
RequireDigit)) !
=))" #
true))$ (
;))( )
options** 
.** 
Password** 
.** 
RequireUppercase** %
=**& '
true**( ,
;**, -
options++ 
.++ 
Password++ 
.++ "
RequireNonAlphanumeric++ +
=++, -
true++. 2
;++2 3
options,, 
.,, 
Password,, 
.,, 
RequiredLength,, #
=,,$ %
$num,,& '
;,,' (
}-- 
)-- 
.-- $
AddEntityFrameworkStores-- 
<-- 
HealthCareDbContext-- /
>--/ 0
(--0 1
)--1 2
.--2 3$
AddDefaultTokenProviders--3 K
(--K L
)--L M
;--M N
builder// 
.// 
Services// 
.// 
AddAuthentication// "
(//" #
JwtBearerDefaults//# 4
.//4 5 
AuthenticationScheme//5 I
)//I J
.00 
AddJwtBearer00 
(00 
option00 
=>00 
{11 
var22 
jwt22 
=22 
builder22 
.22 
Configuration22 #
.22# $

GetSection22$ .
(22. /
$str22/ 4
)224 5
;225 6
option33 

.33
 %
TokenValidationParameters33 $
=33% &
new33' *%
TokenValidationParameters33+ D
{44 
ValidateIssuer55 
=55 
true55 
,55 
ValidIssuer66 
=66 
jwt66 
[66 
$str66 "
]66" #
,66# $
ValidateAudience77 
=77 
true77 
,77  
ValidAudience88 
=88 
jwt88 
[88 
$str88 &
]88& '
,88' (
ValidateLifetime99 
=99 
true99 
,99  $
ValidateIssuerSigningKey::  
=::! "
true::# '
,::' (
IssuerSigningKey;; 
=;; 
new;;  
SymmetricSecurityKey;; 3
(;;3 4
Encoding;;4 <
.;;< =
UTF8;;= A
.;;A B
GetBytes;;B J
(;;J K
jwt;;K N
[;;N O
$str;;O T
];;T U
!;;U V
);;V W
);;W X
,;;X Y
RoleClaimType== 
=== 

ClaimTypes== "
.==" #
Role==# '
,==' (
NameClaimType>> 
=>> 

ClaimTypes>> "
.>>" #
NameIdentifier>># 1
,>>1 2
	ClockSkew@@ 
=@@ 
TimeSpan@@ 
.@@ 
Zero@@ !
}AA 
;AA 
optionBB 

.BB
 
EventsBB 
=BB 
newBB 
JwtBearerEventsBB '
{CC "
OnAuthenticationFailedDD 
=DD  
contextDD! (
=>DD) +
{EE 	
ConsoleFF 
.FF 
	WriteLineFF 
(FF 
$"FF  
$strFF  +
{FF+ ,
contextFF, 3
.FF3 4
	ExceptionFF4 =
.FF= >
MessageFF> E
}FFE F
"FFF G
)FFG H
;FFH I
returnGG 
TaskGG 
.GG 
CompletedTaskGG %
;GG% &
}HH 	
}II 
;II 
}JJ 
)JJ 
;JJ 
builderMM 
.MM 
ServicesMM 
.MM 
	AddScopedMM 
(MM 
typeofMM !
(MM! "
IRepositoryMM" -
<MM- .
>MM. /
)MM/ 0
,MM0 1
typeofMM2 8
(MM8 9

RepositoryMM9 C
<MMC D
>MMD E
)MME F
)MMF G
;MMG H
builderNN 
.NN 
ServicesNN 
.NN 
	AddScopedNN 
<NN 
IPatientRepositoryNN -
,NN- .
PatientRepositoryNN/ @
>NN@ A
(NNA B
)NNB C
;NNC D
builderOO 
.OO 
ServicesOO 
.OO 
	AddScopedOO 
<OO 
IDoctorRepositoryOO ,
,OO, -
DoctorRepositoryOO. >
>OO> ?
(OO? @
)OO@ A
;OOA B
builderPP 
.PP 
ServicesPP 
.PP 
	AddScopedPP 
<PP "
IAppointmentRepositoryPP 1
,PP1 2!
AppointmentRepositoryPP3 H
>PPH I
(PPI J
)PPJ K
;PPK L
builderQQ 
.QQ 
ServicesQQ 
.QQ 
	AddScopedQQ 
<QQ #
IHealthRecordRepositoryQQ 2
,QQ2 3"
HealthRecordRepositoryQQ4 J
>QQJ K
(QQK L
)QQL M
;QQM N
builderTT 
.TT 
ServicesTT 
.TT 
	AddScopedTT 
<TT 
IJwtServiceTT &
,TT& '

JwtServiceTT( 2
>TT2 3
(TT3 4
)TT4 5
;TT5 6
builderUU 
.UU 
ServicesUU 
.UU 
	AddScopedUU 
<UU 
IAuthServiceUU '
,UU' (
AuthServiceUU) 4
>UU4 5
(UU5 6
)UU6 7
;UU7 8
builderVV 
.VV 
ServicesVV 
.VV 
	AddScopedVV 
<VV 
IPatientServiceVV *
,VV* +
PatientServiceVV, :
>VV: ;
(VV; <
)VV< =
;VV= >
builderWW 
.WW 
ServicesWW 
.WW 
	AddScopedWW 
<WW 
IDoctorServiceWW )
,WW) *
DoctorServiceWW+ 8
>WW8 9
(WW9 :
)WW: ;
;WW; <
builderXX 
.XX 
ServicesXX 
.XX 
	AddScopedXX 
<XX 
IAppointmentServiceXX .
,XX. /
AppointmentServiceXX0 B
>XXB C
(XXC D
)XXD E
;XXE F
builderYY 
.YY 
ServicesYY 
.YY 
	AddScopedYY 
<YY  
IHealthRecordServiceYY /
,YY/ 0
HealthRecordServiceYY1 D
>YYD E
(YYE F
)YYF G
;YYG H
builder[[ 
.[[ 
Services[[ 
.[[ 
AddCors[[ 
([[ 
options[[  
=>[[! #
{\\ 
options]] 
.]] 
	AddPolicy]] 
(]] 
$str]] '
,]]' (
policy]]) /
=>]]0 2
{^^ 
policy__ 
.__ 
WithOrigins__ 
(__ 
$str__ 3
,__3 4
$str__5 M
)__M N
.`` 
AllowAnyHeader`` 
(`` 
)`` 
.aa 
AllowAnyMethodaa 
(aa 
)aa 
;aa 
}bb 
)bb 
;bb 
}cc 
)cc 
;cc 
builderdd 
.dd 
Servicesdd 
.dd #
AddEndpointsApiExplorerdd (
(dd( )
)dd) *
;dd* +
builderff 
.ff 
Servicesff 
.ff 
AddSwaggerGenff 
(ff 
optionsff &
=>ff' )
{gg 
optionshh 
.hh 

SwaggerDochh 
(hh 
$strhh 
,hh 
newhh  
OpenApiInfohh! ,
{ii 
Titlejj 
=jj 
$strjj 
,jj  
Versionkk 
=kk 
$strkk 
}ll 
)ll 
;ll 
optionsnn 
.nn !
AddSecurityDefinitionnn !
(nn! "
$strnn" *
,nn* +
newnn, /!
OpenApiSecuritySchemenn0 E
{oo 
Typepp 
=pp 
SecuritySchemeTypepp !
.pp! "
Httppp" &
,pp& '
Schemeqq 
=qq 
$strqq 
,qq 
BearerFormatrr 
=rr 
$strrr 
,rr 
Descriptionss 
=ss 
$strss A
}tt 
)tt 
;tt 
optionsvv 
.vv "
AddSecurityRequirementvv "
(vv" #
documentvv# +
=>vv, .
newvv/ 2&
OpenApiSecurityRequirementvv3 M
{ww 
[xx 	
newxx	 *
OpenApiSecuritySchemeReferencexx +
(xx+ ,
$strxx, 4
,xx4 5
documentxx6 >
)xx> ?
]xx? @
=xxA B
[xxC D
]xxD E
}yy 
)yy 
;yy 
}zz 
)zz 
;zz 
var|| 
app|| 
=|| 	
builder||
 
.|| 
Build|| 
(|| 
)|| 
;|| 
app}} 
.}} 
UseExceptionHandler}} 
(}} 
)}} 
;}} 
using 
( 
var 

scope 
= 
app 
. 
Services 
.  
CreateScope  +
(+ ,
), -
)- .
{ÄÄ 
var
ÅÅ 
services
ÅÅ 
=
ÅÅ 
scope
ÅÅ 
.
ÅÅ 
ServiceProvider
ÅÅ (
;
ÅÅ( )
var
ÇÇ 
roleManager
ÇÇ 
=
ÇÇ 
scope
ÇÇ 
.
ÇÇ 
ServiceProvider
ÇÇ +
.
ÇÇ+ , 
GetRequiredService
ÇÇ, >
<
ÇÇ> ?
RoleManager
ÇÇ? J
<
ÇÇJ K
IdentityRole
ÇÇK W
>
ÇÇW X
>
ÇÇX Y
(
ÇÇY Z
)
ÇÇZ [
;
ÇÇ[ \
var
ÉÉ 
userManager
ÉÉ 
=
ÉÉ 
services
ÉÉ 
.
ÉÉ  
GetRequiredService
ÉÉ 1
<
ÉÉ1 2
UserManager
ÉÉ2 =
<
ÉÉ= >
IdentityUser
ÉÉ> J
>
ÉÉJ K
>
ÉÉK L
(
ÉÉL M
)
ÉÉM N
;
ÉÉN O
var
ÑÑ 
config
ÑÑ 
=
ÑÑ 
services
ÑÑ 
.
ÑÑ  
GetRequiredService
ÑÑ ,
<
ÑÑ, -
IConfiguration
ÑÑ- ;
>
ÑÑ; <
(
ÑÑ< =
)
ÑÑ= >
;
ÑÑ> ?
await
ÜÜ 	

RoleSeeder
ÜÜ
 
.
ÜÜ 
SeedRolesAsync
ÜÜ #
(
ÜÜ# $
roleManager
ÜÜ$ /
)
ÜÜ/ 0
;
ÜÜ0 1
await
áá 	

UserSeeder
áá
 
.
áá 
SeedAdminAsync
áá #
(
áá# $
userManager
áá$ /
,
áá/ 0
roleManager
áá1 <
,
áá< =
config
áá> D
)
ááD E
;
ááE F
}àà 
ifãã 
(
ãã 
app
ãã 
.
ãã 
Environment
ãã 
.
ãã 
IsDevelopment
ãã !
(
ãã! "
)
ãã" #
)
ãã# $
{åå 
app
çç 
.
çç 

UseSwagger
çç 
(
çç 
)
çç 
;
çç 
app
éé 
.
éé 
UseSwaggerUI
éé 
(
éé 
)
éé 
;
éé 
}èè 
appëë 
.
ëë !
UseHttpsRedirection
ëë 
(
ëë 
)
ëë 
;
ëë 
appíí 
.
íí 

UseRouting
íí 
(
íí 
)
íí 
;
íí 
appìì 
.
ìì 
UseCors
ìì 
(
ìì 
$str
ìì 
)
ìì 
;
ìì 
appîî 
.
îî 
UseAuthentication
îî 
(
îî 
)
îî 
;
îî 
appïï 
.
ïï 
UseAuthorization
ïï 
(
ïï 
)
ïï 
;
ïï 
appóó 
.
óó 
MapControllers
óó 
(
óó 
)
óó 
;
óó 
awaitôô 
app
ôô 	
.
ôô	 

RunAsync
ôô
 
(
ôô 
)
ôô 
;
ôô Ö 
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
}// ü
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
}** ≤
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
}00 Å
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
. 
	ForMember 
( 
dest 
=> 
dest 
. 
Email !
,! "
opt 
=> 
opt 
. 
MapFrom 
( 
src 
=> !
src" %
.% &
User& *
.* +
Email+ 0
)0 1
)1 2
;2 3
	CreateMap   
<    
CreateAppointmentDto   *
,  * +
Appointment  , 7
>  7 8
(  8 9
)  9 :
;  : ;
	CreateMap!! 
<!!  
UpdateAppointmentDto!! *
,!!* +
Appointment!!, 7
>!!7 8
(!!8 9
)!!9 :
;!!: ;
	CreateMap"" 
<"" 
AppointmentListDto"" (
,""( )
Appointment""* 5
>""5 6
(""6 7
)""7 8
;""8 9
	CreateMap%% 
<%% !
CreateHealthRecordDto%% +
,%%+ ,
HealthRecord%%- 9
>%%9 :
(%%: ;
)%%; <
;%%< =
	CreateMap&& 
<&& !
UpdateHealthRecordDto&& +
,&&+ ,
HealthRecord&&- 9
>&&9 :
(&&: ;
)&&; <
;&&< =
	CreateMap'' 
<'' 
HealthRecordListDto'' )
,'') *
HealthRecord''+ 7
>''7 8
(''8 9
)''9 :
;'': ;
}(( 	
})) 
}** —
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
}		 ‹
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
builder 
. 
Entity 
< 
Appointment &
>& '
(' (
)( )
. 
HasIndex 
( 
a 
=> 
new "
{# $
a% &
.& '
DoctorId' /
,/ 0
a1 2
.2 3
ScheduledDate3 @
,@ A
aB C
.C D
TimeSlotD L
}M N
)N O
. 
IsUnique 
( 
) 
. 
	HasFilter 
( 
$str 4
)4 5
. 
HasDatabaseName  
(  !
$str! C
)C D
;D E
builder 
. 
Entity 
< 
Appointment &
>& '
(' (
)( )
.   
HasIndex   
(   
a   
=>   
new   "
{  # $
a  % &
.  & '
DoctorId  ' /
,  / 0
a  1 2
.  2 3
ScheduledDate  3 @
}  A B
)  B C
.!! 
HasDatabaseName!!  
(!!  !
$str!!! >
)!!> ?
;!!? @
builder## 
.## 
Entity## 
<## 
Appointment## &
>##& '
(##' (
)##( )
.$$ 
HasIndex$$ 
($$ 
a$$ 
=>$$ 
new$$ "
{$$# $
a$$% &
.$$& '
	PatientId$$' 0
,$$0 1
a$$2 3
.$$3 4
ScheduledDate$$4 A
}$$B C
)$$C D
.%% 
HasDatabaseName%%  
(%%  !
$str%%! ?
)%%? @
;%%@ A
builder'' 
.'' 
Entity'' 
<'' 
HealthRecord'' '
>''' (
(''( )
)'') *
.(( 
HasIndex(( 
((( 
hr(( 
=>(( 
new((  #
{(($ %
hr((& (
.((( )
	PatientId(() 2
,((2 3
hr((4 6
.((6 7
	VisitDate((7 @
}((A B
)((B C
.)) 
HasDatabaseName))  
())  !
$str))! E
)))E F
;))F G
builder++ 
.++ 
Entity++ 
<++ 
Patient++ "
>++" #
(++# $
)++$ %
.,, 
HasOne,, 
(,, 
p,, 
=>,, 
p,, 
.,, 
User,, #
),,# $
.-- 
WithOne-- 
(-- 
)-- 
... 
HasForeignKey.. 
<.. 
Patient.. &
>..& '
(..' (
p..( )
=>..* ,
p..- .
.... /
UserId../ 5
)..5 6
.// 
OnDelete// 
(// 
DeleteBehavior// (
.//( )
Cascade//) 0
)//0 1
;//1 2
builder11 
.11 
Entity11 
<11 
Doctor11 !
>11! "
(11" #
)11# $
.22 
HasOne22 
(22 
d22 
=>22 
d22 
.22 
User22 #
)22# $
.33 
WithOne33 
(33 
)33 
.44 
HasForeignKey44 
<44 
Doctor44 %
>44% &
(44& '
d44' (
=>44) +
d44, -
.44- .
UserId44. 4
)444 5
.55 
OnDelete55 
(55 
DeleteBehavior55 (
.55( )
Cascade55) 0
)550 1
;551 2
builder77 
.77 
Entity77 
<77 
Appointment77 &
>77& '
(77' (
)77( )
.88 
HasOne88 
(88 
a88 
=>88 
a88 
.88 
Patient88 &
)88& '
.99 
WithMany99 
(99 
p99 
=>99 
p99  
.99  !
Appointments99! -
)99- .
.:: 
HasForeignKey:: 
(:: 
a::  
=>::! #
a::$ %
.::% &
	PatientId::& /
)::/ 0
.;; 
OnDelete;; 
(;; 
DeleteBehavior;; (
.;;( )
Restrict;;) 1
);;1 2
;;;2 3
builder== 
.== 
Entity== 
<== 
Appointment== &
>==& '
(==' (
)==( )
.>> 
HasOne>> 
(>> 
a>> 
=>>> 
a>> 
.>> 
Doctor>> %
)>>% &
.?? 
WithMany?? 
(?? 
d?? 
=>?? 
d??  
.??  !
Appointments??! -
)??- .
.@@ 
HasForeignKey@@ 
(@@ 
a@@  
=>@@! #
a@@$ %
.@@% &
DoctorId@@& .
)@@. /
.AA 
OnDeleteAA 
(AA 
DeleteBehaviorAA (
.AA( )
RestrictAA) 1
)AA1 2
;AA2 3
builderCC 
.CC 
EntityCC 
<CC 
HealthRecordCC '
>CC' (
(CC( )
)CC) *
.DD 
HasOneDD 
(DD 
hrDD 
=>DD 
hrDD  
.DD  !
AppointmentDD! ,
)DD, -
.EE 
WithOneEE 
(EE 
aEE 
=>EE 
aEE 
.EE  
HealthRecordEE  ,
)EE, -
.FF 
HasForeignKeyFF 
<FF 
HealthRecordFF +
>FF+ ,
(FF, -
hrFF- /
=>FF0 2
hrFF3 5
.FF5 6
AppointmentIdFF6 C
)FFC D
.GG 
OnDeleteGG 
(GG 
DeleteBehaviorGG (
.GG( )
RestrictGG) 1
)GG1 2
;GG2 3
builderII 
.II 
EntityII 
<II 
HealthRecordII '
>II' (
(II( )
)II) *
.JJ 
HasOneJJ 
(JJ 
hrJJ 
=>JJ 
hrJJ  
.JJ  !
PatientJJ! (
)JJ( )
.KK 
WithManyKK 
(KK 
pKK 
=>KK 
pKK  
.KK  !
HealthRecordsKK! .
)KK. /
.LL 
HasForeignKeyLL 
(LL 
hrLL !
=>LL" $
hrLL% '
.LL' (
	PatientIdLL( 1
)LL1 2
.MM 
OnDeleteMM 
(MM 
DeleteBehaviorMM (
.MM( )
RestrictMM) 1
)MM1 2
;MM2 3
builderOO 
.OO 
EntityOO 
<OO 
HealthRecordOO '
>OO' (
(OO( )
)OO) *
.PP 
HasOnePP 
(PP 
hrPP 
=>PP 
hrPP  
.PP  !
DoctorPP! '
)PP' (
.QQ 
WithManyQQ 
(QQ 
dQQ 
=>QQ 
dQQ  
.QQ  !
HealthRecordsQQ! .
)QQ. /
.RR 
HasForeignKeyRR 
(RR 
hrRR !
=>RR" $
hrRR% '
.RR' (
DoctorIdRR( 0
)RR0 1
.SS 
OnDeleteSS 
(SS 
DeleteBehaviorSS (
.SS( )
RestrictSS) 1
)SS1 2
;SS2 3
}TT 	
}UU 
}VV ∑*
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
}DD ÀA
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
;8 9
private 
readonly 
IAuthService %
_authService& 2
;2 3
public "
PatientAdminController %
(% &
IPatientService& 5
patientService6 D
,D E
IAuthServiceF R
authServiceS ^
)^ _
{ 	
_patientService 
= 
patientService ,
;, -
_authService 
= 
authService &
;& '
} 	
[ 	
HttpGet	 
( 
$str 
) 
] 
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
$str "
)" #
]# $
public 
async 
Task 
< 
IActionResult '
>' (
GetPatientById) 7
(7 8
int8 ;
id< >
)> ?
{ 	
var 
result 
= 
await 
_patientService .
.. /
GetByIdAsync/ ;
(; <
id< >
)> ?
;? @
return 
Ok 
( 
result 
) 
; 
} 	
[ 	
HttpGet	 
( 
$str 
) 
] 
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
>""' (
GetAllPatient"") 6
(""6 7
[""7 8
	FromQuery""8 A
]""A B
PatientFilter""C P
filter""Q W
)""W X
{## 	
if$$ 
($$ 
!$$ 

ModelState$$ 
.$$ 
IsValid$$ #
)$$# $
return%% 

BadRequest%% !
(%%! "

ModelState%%" ,
)%%, -
;%%- .
var'' 
result'' 
='' 
await'' 
_patientService'' .
.''. /
GetAllAsync''/ :
('': ;
filter''; A
)''A B
;''B C
return(( 
Ok(( 
((( 
result(( 
)(( 
;(( 
})) 	
[++ 	
HttpPut++	 
(++ 
$str++ 
)++ 
]++ 
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
$str-- "
)--" #
]--# $
public.. 
async.. 
Task.. 
<.. 
IActionResult.. '
>..' (
UpdatePatient..) 6
(..6 7
int..7 :
id..; =
,..= >
[..? @
FromBody..@ H
]..H I
UpdatePatientDto..J Z
dto..[ ^
)..^ _
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
var33 
patient33 
=33 
await33 
_patientService33  /
.33/ 0
GetByIdAsync330 <
(33< =
id33= ?
)33? @
;33@ A
if55 
(55 
patient55 
==55 
null55 
)55  
return66 
NotFound66 
(66  
$str66  3
)663 4
;664 5
await88 
_patientService88 !
.88! "
UpdateAsync88" -
(88- .
id88. 0
,880 1
dto882 5
)885 6
;886 7
return:: 
Ok:: 
(:: 
new:: 
{:: 
message:: #
=::$ %
$str::& D
}::E F
)::F G
;::G H
};; 	
[== 	
	HttpPatch==	 
(== 
$str==  
)==  !
]==! "
[>> 	
	Authorize>>	 
(>> !
AuthenticationSchemes>> (
=>>) *
JwtBearerDefaults>>+ <
.>>< = 
AuthenticationScheme>>= Q
)>>Q R
]>>R S
[?? 	
	Authorize??	 
(?? 
Roles?? 
=?? 
$str?? "
)??" #
]??# $
public@@ 
async@@ 
Task@@ 
<@@ 
IActionResult@@ '
>@@' (
UpdatePatientStatus@@) <
(@@< =
int@@= @
id@@A C
,@@C D
[@@E F
FromBody@@F N
]@@N O
bool@@P T
isActive@@U ]
)@@] ^
{AA 	
awaitBB 
_patientServiceBB !
.BB! "
UpdateStatusAsyncBB" 3
(BB3 4
idBB4 6
,BB6 7
isActiveBB8 @
)BB@ A
;BBA B
returnCC 
OkCC 
(CC 
newCC 
{CC 
messageCC #
=CC$ %
$strCC& K
}CCL M
)CCM N
;CCN O
}DD 	
[FF 	

HttpDeleteFF	 
(FF 
$strFF 
)FF 
]FF 
[GG 	
	AuthorizeGG	 
(GG !
AuthenticationSchemesGG (
=GG) *
JwtBearerDefaultsGG+ <
.GG< = 
AuthenticationSchemeGG= Q
)GGQ R
]GGR S
[HH 	
	AuthorizeHH	 
(HH 
RolesHH 
=HH 
$strHH "
)HH" #
]HH# $
publicII 
asyncII 
TaskII 
<II 
IActionResultII '
>II' (
DeletePatientII) 6
(II6 7
intII7 :
idII; =
)II= >
{JJ 	
awaitKK 
_patientServiceKK !
.KK! "
DeleteAsyncKK" -
(KK- .
idKK. 0
)KK0 1
;KK1 2
returnLL 
OkLL 
(LL 
newLL 
{LL 
messageLL #
=LL$ %
$strLL& D
}LLE F
)LLF G
;LLG H
}MM 	
[PP 	
HttpGetPP	 
(PP 
$strPP 
)PP  
]PP  !
[QQ 	
	AuthorizeQQ	 
(QQ !
AuthenticationSchemesQQ (
=QQ) *
JwtBearerDefaultsQQ+ <
.QQ< = 
AuthenticationSchemeQQ= Q
)QQQ R
]QQR S
[RR 	
	AuthorizeRR	 
(RR 
RolesRR 
=RR 
$strRR "
)RR" #
]RR# $
publicSS 
asyncSS 
TaskSS 
<SS 
IActionResultSS '
>SS' (!
GetRecentPatientCountSS) >
(SS> ?
)SS? @
{TT 	
varUU 
resultUU 
=UU 
awaitUU 
_patientServiceUU .
.UU. /!
GetRecentPatientCountUU/ D
(UUD E
)UUE F
;UUF G
returnVV 
OkVV 
(VV 
resultVV 
)VV 
;VV 
}WW 	
}XX 
}YY ™5
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
}MM ™>
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
;332 3
var44 
result44 
=44 
await44 
_doctorService44 -
.44- .
CreateLeave44. 9
(449 :
doctorId44: B
,44B C
leaves44D J
)44J K
;44K L
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
}CC 