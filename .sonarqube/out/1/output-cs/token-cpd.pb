⁄2
ÅC:\Users\Pim\Desktop\Semester 6\Individual project\Code\vybes-backend\KrabbelMicroservice\Controllers\ProfileKrabbelController.cs
	namespace 	
KrabbelMicroservice
 
. 
Controllers )
;) *
[ 
ApiController 
] 
[ 
Route 
( 
$str 
) 
] 
public		 
class		 $
ProfileKrabbelController		 %
:		& '

Controller		( 2
{

 
private 
readonly "
IProfileKrabbelService +
_krabbelService, ;
;; <
public 
$
ProfileKrabbelController #
(# $"
IProfileKrabbelService$ :
krabbelService; I
)I J
{ 
_krabbelService 
= 
krabbelService (
;( )
} 
[ 
HttpGet 
] 
public 

IActionResult 
Index 
( 
)  
{ 
List 
< 
ProfileKrabbel 
> 
krabbels %
=& '
_krabbelService( 7
.7 8
GetKrabbels8 C
(C D
)D E
;E F
if 

( 
krabbels 
. 
Any 
( 
) 
) 
{ 	
return 
Ok 
( 
krabbels 
) 
;  
} 	
return 
NotFound 
( 
$str 0
)0 1
;1 2
} 
[ 
HttpGet 
] 
[   
Route   

(  
 
$str   
)   
]   
public!! 

IActionResult!! 
GetKrabbelById!! '
(!!' (
long!!( ,
	krabbelId!!- 6
)!!6 7
{"" 
ProfileKrabbel## 
?## 
profile## 
=##  !
_krabbelService##" 1
.##1 2
GetKrabbelById##2 @
(##@ A
	krabbelId##A J
)##J K
;##K L
if%% 

(%% 
profile%% 
!=%% 
null%% 
)%% 
{&& 	
return'' 
Ok'' 
('' 
profile'' 
)'' 
;'' 
}(( 	
return** 
NotFound** 
(** 
$str** J
+**K L
	krabbelId**M V
)**V W
;**W X
}++ 
[-- 
HttpGet-- 
]-- 
[.. 
Route.. 

(..
 
$str.. 
).. 
].. 
public// 

IActionResult// "
GetKrabbelsByProfileId// /
(/// 0
long//0 4
	profileId//5 >
)//> ?
{00 
List11 
<11 
ProfileKrabbel11 
>11 
krabbels11 %
=11& '
_krabbelService11( 7
.117 8"
GetKrabbelsByProfileId118 N
(11N O
	profileId11O X
)11X Y
;11Y Z
if33 

(33 
krabbels33 
.33 
Any33 
(33 
)33 
)33 
{44 	
return55 
Ok55 
(55 
krabbels55 
)55 
;55  
}66 	
return88 
NotFound88 
(88 
$str88 Q
+88R S
	profileId88T ]
)88] ^
;88^ _
}99 
[;; 
HttpPost;; 
];; 
[<< 
Route<< 

(<<
 
$str<< 
)<< 
]<< 
public== 

IActionResult== 

AddKrabbel== #
(==# $
ProfileKrabbel==$ 2
krabbel==3 :
)==: ;
{>> 
krabbel?? 
.?? 
	CreatedAt?? 
=?? 
DateTime?? $
.??$ %
Now??% (
;??( )
krabbel@@ 
.@@ 
	UpdatedAt@@ 
=@@ 
DateTime@@ $
.@@$ %
Now@@% (
;@@( )
ProfileKrabbelBB 
?BB 
resultBB 
=BB  
_krabbelServiceBB! 0
.BB0 1

AddKrabbelBB1 ;
(BB; <
krabbelBB< C
)BBC D
;BBD E
ifDD 

(DD 
resultDD 
!=DD 
nullDD 
)DD 
{EE 	
returnFF 
OkFF 
(FF 
resultFF 
)FF 
;FF 
}GG 	
returnII 

BadRequestII 
(II 
$strII =
)II= >
;II> ?
}JJ 
[LL 
HttpPutLL 
]LL 
[MM 
RouteMM 

(MM
 
$strMM 
)MM 
]MM 
publicNN 

IActionResultNN 
UpdateKrabbelNN &
(NN& '
ProfileKrabbelNN' 5
krabbelNN6 =
)NN= >
{OO 
ProfileKrabbelPP 
?PP 
resultPP 
=PP  
_krabbelServicePP! 0
.PP0 1
UpdateKrabbelPP1 >
(PP> ?
krabbelPP? F
)PPF G
;PPG H
ifRR 

(RR 
resultRR 
!=RR 
nullRR 
)RR 
{SS 	
returnTT 
OkTT 
(TT 
resultTT 
)TT 
;TT 
}UU 	
returnWW 

BadRequestWW 
(WW 
$strWW =
)WW= >
;WW> ?
}XX 
[ZZ 

HttpDeleteZZ 
]ZZ 
[[[ 
Route[[ 

([[
 
$str[[ 
)[[ 
][[ 
public\\ 

IActionResult\\ 
DeleteKrabbel\\ &
(\\& '
ProfileKrabbel\\' 5
krabbel\\6 =
)\\= >
{]] 
bool^^ 
result^^ 
=^^ 
_krabbelService^^ %
.^^% &
DeleteKrabbel^^& 3
(^^3 4
krabbel^^4 ;
)^^; <
;^^< =
if`` 

(`` 
result`` 
)`` 
{aa 	
returnbb 
Okbb 
(bb 
resultbb 
)bb 
;bb 
}cc 	
returnee 

BadRequestee 
(ee 
$stree =
)ee= >
;ee> ?
}ff 
}gg ©
ÇC:\Users\Pim\Desktop\Semester 6\Individual project\Code\vybes-backend\KrabbelMicroservice\Controllers\WeatherForecastController.cs
	namespace 	
KrabbelMicroservice
 
. 
Controllers )
;) *
[ 
ApiController 
] 
[ 
Route 
( 
$str 
) 
] 
public 
class %
WeatherForecastController &
:' (
ControllerBase) 7
{ 
private		 
static		 
readonly		 
string		 "
[		" #
]		# $
	Summaries		% .
=		/ 0
new		1 4
[		4 5
]		5 6
{

 
$str 
, 
$str 
, 
$str '
,' (
$str) /
,/ 0
$str1 7
,7 8
$str9 ?
,? @
$strA H
,H I
$strJ O
,O P
$strQ ]
,] ^
$str_ j
} 
; 
private 
readonly 
ILogger 
< %
WeatherForecastController 6
>6 7
_logger8 ?
;? @
public 
%
WeatherForecastController $
($ %
ILogger% ,
<, -%
WeatherForecastController- F
>F G
loggerH N
)N O
{ 
_logger 
= 
logger 
; 
} 
[ 
HttpGet 
( 
Name 
= 
$str (
)( )
]) *
public 

IEnumerable 
< 
WeatherForecast &
>& '
Get( +
(+ ,
), -
{ 
return 

Enumerable 
. 
Range 
(  
$num  !
,! "
$num# $
)$ %
.% &
Select& ,
(, -
index- 2
=>3 5
new6 9
WeatherForecast: I
{ 
Date 
= 
DateTime 
.  
Now  #
.# $
AddDays$ +
(+ ,
index, 1
)1 2
,2 3
TemperatureC 
= 
Random %
.% &
Shared& ,
., -
Next- 1
(1 2
-2 3
$num3 5
,5 6
$num7 9
)9 :
,: ;
Summary 
= 
	Summaries #
[# $
Random$ *
.* +
Shared+ 1
.1 2
Next2 6
(6 7
	Summaries7 @
.@ A
LengthA G
)G H
]H I
} 
) 
. 
ToArray 
( 
) 
; 
} 
}   ·
nC:\Users\Pim\Desktop\Semester 6\Individual project\Code\vybes-backend\KrabbelMicroservice\Data\AppDbContext.cs
	namespace 	
KrabbelMicroservice
 
. 
Data "
;" #
public 
class 
AppDbContext 
: 
	DbContext %
{ 
public 

DbSet 
< 
ProfileKrabbel 
>  
ProfileKrabbels! 0
{1 2
get3 6
;6 7
set8 ;
;; <
}= >
=? @
nullA E
!E F
;F G
public

 

AppDbContext

 
(

 
DbContextOptions

 (
options

) 0
)

0 1
:

2 3
base

4 8
(

8 9
options

9 @
)

@ A
{ 
} 
} ‡
ìC:\Users\Pim\Desktop\Semester 6\Individual project\Code\vybes-backend\KrabbelMicroservice\Data\Repositories\Interfaces\IProfileKrabbelRepository.cs
	namespace 	
KrabbelMicroservice
 
. 
Data "
." #
Repositories# /
./ 0

Interfaces0 :
;: ;
public 
	interface %
IProfileKrabbelRepository *
{ 
List 
< 	
ProfileKrabbel	 
> 
GetKrabbels $
($ %
)% &
;& '
ProfileKrabbel		 
?		 
GetKrabbelById		 "
(		" #
long		# '
	krabbelId		( 1
)		1 2
;		2 3
List 
< 	
ProfileKrabbel	 
> "
GetKrabbelsByProfileId /
(/ 0
long0 4
	profileId5 >
)> ?
;? @
ProfileKrabbel 

AddKrabbel 
( 
ProfileKrabbel ,
krabbel- 4
)4 5
;5 6
ProfileKrabbel 
UpdateKrabbel  
(  !
ProfileKrabbel! /
krabbel0 7
)7 8
;8 9
bool 
DeleteKrabbel	 
( 
ProfileKrabbel %
krabbel& -
)- .
;. /
bool 
KrabbelExists	 
( 
long 
	krabbelId %
)% &
;& '
} ⁄$
áC:\Users\Pim\Desktop\Semester 6\Individual project\Code\vybes-backend\KrabbelMicroservice\Data\Repositories\ProfileKrabbelRepository.cs
	namespace 	
KrabbelMicroservice
 
. 
Data "
." #
Repositories# /
;/ 0
public 
class $
ProfileKrabbelRepository %
:& '%
IProfileKrabbelRepository( A
{ 
private		 
readonly		 
AppDbContext		 !

_dbContext		" ,
;		, -
public 
$
ProfileKrabbelRepository #
(# $
AppDbContext$ 0
	dbContext1 :
): ;
{ 

_dbContext 
= 
	dbContext 
; 
} 
public 

bool 
SaveChanges 
( 
) 
{ 
return 
( 

_dbContext 
. 
SaveChanges &
(& '
)' (
>=) +
$num, -
)- .
;. /
} 
public 

List 
< 
ProfileKrabbel 
> 
GetKrabbels  +
(+ ,
), -
{ 
return 

_dbContext 
. 
ProfileKrabbels )
. 
AsNoTracking 
( 
) 
. 
ToList 
( 
) 
; 
} 
public 

ProfileKrabbel 
? 
GetKrabbelById )
() *
long* .
	krabbelId/ 8
)8 9
{ 
return 

_dbContext 
. 
ProfileKrabbels )
.   
AsNoTracking   
(   
)   
.!! 
Where!! 
(!! 
x!! 
=>!! 
x!! 
.!! 
	KrabbelId!! #
==!!$ &
	krabbelId!!' 0
)!!0 1
."" 
FirstOrDefault"" 
("" 
)"" 
;"" 
}## 
public%% 

List%% 
<%% 
ProfileKrabbel%% 
>%% "
GetKrabbelsByProfileId%%  6
(%%6 7
long%%7 ;
	profileId%%< E
)%%E F
{&& 
return'' 

_dbContext'' 
.'' 
ProfileKrabbels'' )
.(( 
AsNoTracking(( 
((( 
)(( 
.)) 
Where)) 
()) 
x)) 
=>)) 
x)) 
.)) 
ToProfileId)) %
==))& (
	profileId))) 2
)))2 3
.** 
ToList** 
(** 
)** 
;** 
}++ 
public-- 

ProfileKrabbel-- 

AddKrabbel-- $
(--$ %
ProfileKrabbel--% 3
krabbel--4 ;
)--; <
{.. 

_dbContext// 
.// 
ProfileKrabbels// "
.//" #
Add//# &
(//& '
krabbel//' .
)//. /
;/// 0
SaveChanges00 
(00 
)00 
;00 
return22 
krabbel22 
;22 
}33 
public55 

ProfileKrabbel55 
?55 
UpdateKrabbel55 (
(55( )
ProfileKrabbel55) 7
krabbel558 ?
)55? @
{66 

_dbContext77 
.77 
ProfileKrabbels77 "
.77" #
Update77# )
(77) *
krabbel77* 1
)771 2
;772 3
SaveChanges88 
(88 
)88 
;88 
return:: 
krabbel:: 
;:: 
};; 
public== 

bool== 
DeleteKrabbel== 
(== 
ProfileKrabbel== ,
krabbel==- 4
)==4 5
{>> 

_dbContext?? 
.?? 
ProfileKrabbels?? "
.??" #
Remove??# )
(??) *
krabbel??* 1
)??1 2
;??2 3
SaveChanges@@ 
(@@ 
)@@ 
;@@ 
returnBB 
trueBB 
;BB 
}CC 
publicEE 

boolEE 
KrabbelExistsEE 
(EE 
longEE "
	krabbelIdEE# ,
)EE, -
{FF 
returnGG 

_dbContextGG 
.GG 
ProfileKrabbelsGG )
.GG) *
AnyGG* -
(GG- .
xGG. /
=>GG0 2
xGG3 4
.GG4 5
	KrabbelIdGG5 >
==GG? A
	krabbelIdGGB K
)GGK L
;GGL M
}HH 
}II ê
îC:\Users\Pim\Desktop\Semester 6\Individual project\Code\vybes-backend\KrabbelMicroservice\Migrations\20220518082938_create-profile-krabbel-entity.cs
	namespace 	
KrabbelMicroservice
 
. 

Migrations (
{ 
public		 

partial		 
class		 &
createprofilekrabbelentity		 3
:		4 5
	Migration		6 ?
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
$str '
,' (
columns 
: 
table 
=> !
new" %
{ 
	KrabbelId 
= 
table  %
.% &
Column& ,
<, -
long- 1
>1 2
(2 3
type3 7
:7 8
$str9 A
,A B
nullableC K
:K L
falseM R
)R S
. 

Annotation #
(# $
$str$ 8
,8 9
$str: @
)@ A
,A B
ToProfileId 
=  !
table" '
.' (
Column( .
<. /
long/ 3
>3 4
(4 5
type5 9
:9 :
$str; C
,C D
nullableE M
:M N
falseO T
)T U
,U V
FromProfileId !
=" #
table$ )
.) *
Column* 0
<0 1
long1 5
>5 6
(6 7
type7 ;
:; <
$str= E
,E F
nullableG O
:O P
falseQ V
)V W
,W X
Content 
= 
table #
.# $
Column$ *
<* +
string+ 1
>1 2
(2 3
type3 7
:7 8
$str9 H
,H I
nullableJ R
:R S
falseT Y
)Y Z
,Z [
	CreatedAt 
= 
table  %
.% &
Column& ,
<, -
DateTime- 5
>5 6
(6 7
type7 ;
:; <
$str= H
,H I
nullableJ R
:R S
trueT X
)X Y
,Y Z
	UpdatedAt 
= 
table  %
.% &
Column& ,
<, -
DateTime- 5
>5 6
(6 7
type7 ;
:; <
$str= H
,H I
nullableJ R
:R S
trueT X
)X Y
} 
, 
constraints 
: 
table "
=># %
{ 
table 
. 

PrimaryKey $
($ %
$str% 9
,9 :
x; <
=>= ?
x@ A
.A B
	KrabbelIdB K
)K L
;L M
} 
) 
; 
} 	
	protected!! 
override!! 
void!! 
Down!!  $
(!!$ %
MigrationBuilder!!% 5
migrationBuilder!!6 F
)!!F G
{"" 	
migrationBuilder## 
.## 
	DropTable## &
(##& '
name$$ 
:$$ 
$str$$ '
)$$' (
;$$( )
}%% 	
}&& 
}'' œ	
uC:\Users\Pim\Desktop\Semester 6\Individual project\Code\vybes-backend\KrabbelMicroservice\Models\Abstracts\Krabbel.cs
	namespace 	
KrabbelMicroservice
 
. 
Models $
.$ %
	Abstracts% .
;. /
public 
abstract 
class 
Krabbel 
{ 
[ 
Key 
] 	
public
 
long 
	KrabbelId 
{  !
get" %
;% &
set' *
;* +
}, -
public		 

long		 
FromProfileId		 
{		 
get		  #
;		# $
set		% (
;		( )
}		* +
public 

string 
Content 
{ 
get 
;  
set! $
;$ %
}& '
public 

DateTime 
? 
	CreatedAt 
{  
get! $
;$ %
set& )
;) *
}+ ,
public 

DateTime 
? 
	UpdatedAt 
{  
get! $
;$ %
set& )
;) *
}+ ,
} ¯
rC:\Users\Pim\Desktop\Semester 6\Individual project\Code\vybes-backend\KrabbelMicroservice\Models\ProfileKrabbel.cs
	namespace 	
KrabbelMicroservice
 
. 
Models $
;$ %
public 
class 
ProfileKrabbel 
: 
Krabbel %
{ 
public 

long 
ToProfileId 
{ 
get !
;! "
set# &
;& '
}( )
} å
dC:\Users\Pim\Desktop\Semester 6\Individual project\Code\vybes-backend\KrabbelMicroservice\Program.cs
var 
builder 
= 
WebApplication 
. 
CreateBuilder *
(* +
args+ /
)/ 0
;0 1
ConfigureServices		 
(		 
builder		 
.		 
Services		 "
)		" #
;		# $
builder 
. 
Services 
. 
AddControllers 
(  
)  !
;! "
builder 
. 
Services 
. #
AddEndpointsApiExplorer (
(( )
)) *
;* +
builder 
. 
Services 
. 
AddSwaggerGen 
( 
)  
;  !
var 
app 
= 	
builder
 
. 
Build 
( 
) 
; 
if 
( 
app 
. 
Environment 
. 
IsDevelopment !
(! "
)" #
)# $
{ 
app 
. 

UseSwagger 
( 
) 
; 
app 
. 
UseSwaggerUI 
( 
) 
; 
} 
app 
. 
UseHttpsRedirection 
( 
) 
; 
app 
. 
UseAuthorization 
( 
) 
; 
app 
. 
MapControllers 
( 
) 
; 
app!! 
.!! 
Run!! 
(!! 
)!! 	
;!!	 

void## 
ConfigureServices## 
(## 
IServiceCollection## )
services##* 2
)##2 3
{$$ 
services%% 
.%% 
AddDbContext%% 
<%% 
AppDbContext%% &
>%%& '
(%%' (
options%%( /
=>%%0 2
{&& 
options'' 
.'' 
UseSqlServer'' 
('' 
builder'' $
.''$ %
Configuration''% 2
[''2 3
$str''3 S
]''S T
,''T U"
sqlServerOptionsAction(( "
:((" #

sqlOptions(($ .
=>((/ 1
{((2 3

sqlOptions((4 >
.((> ? 
EnableRetryOnFailure((? S
(((S T
)((T U
;((U V
}((W X
)((X Y
;((Y Z
})) 
,)) 
ServiceLifetime)) 
.)) 
	Transient))  
)))  !
;))! "
services++ 
.++ 
AddTransient++ 
<++ "
IProfileKrabbelService++ 0
,++0 1!
ProfileKrabbelService++2 G
>++G H
(++H I
)++I J
;++J K
services,, 
.,, 
AddTransient,, 
<,, %
IProfileKrabbelRepository,, 3
,,,3 4$
ProfileKrabbelRepository,,5 M
>,,M N
(,,N O
),,O P
;,,P Q
}-- «

áC:\Users\Pim\Desktop\Semester 6\Individual project\Code\vybes-backend\KrabbelMicroservice\Services\Interfaces\IProfileKrabbelService.cs
	namespace 	
KrabbelMicroservice
 
. 
Services &
.& '

Interfaces' 1
;1 2
public 
	interface "
IProfileKrabbelService '
{ 
List 
< 	
ProfileKrabbel	 
> 
GetKrabbels $
($ %
)% &
;& '
ProfileKrabbel		 
?		 
GetKrabbelById		 "
(		" #
long		# '
	krabbelId		( 1
)		1 2
;		2 3
List 
< 	
ProfileKrabbel	 
> "
GetKrabbelsByProfileId /
(/ 0
long0 4
	profileId5 >
)> ?
;? @
ProfileKrabbel 
? 

AddKrabbel 
( 
ProfileKrabbel -
krabbel. 5
)5 6
;6 7
ProfileKrabbel 
? 
UpdateKrabbel !
(! "
ProfileKrabbel" 0
krabbel1 8
)8 9
;9 :
bool 
DeleteKrabbel	 
( 
ProfileKrabbel %
krabbel& -
)- .
;. /
} ‘
{C:\Users\Pim\Desktop\Semester 6\Individual project\Code\vybes-backend\KrabbelMicroservice\Services\ProfileKrabbelService.cs
	namespace 	
KrabbelMicroservice
 
. 
Services &
;& '
public 
class !
ProfileKrabbelService "
:# $"
IProfileKrabbelService% ;
{ 
private		 
readonly		 %
IProfileKrabbelRepository		 .
_krabbelRepository		/ A
;		A B
public 
!
ProfileKrabbelService  
(  !%
IProfileKrabbelRepository! :
krabbelRepository; L
)L M
{ 
_krabbelRepository 
= 
krabbelRepository .
;. /
} 
public 

List 
< 
ProfileKrabbel 
> 
GetKrabbels  +
(+ ,
), -
{ 
return 
_krabbelRepository !
.! "
GetKrabbels" -
(- .
). /
;/ 0
} 
public 

ProfileKrabbel 
? 
GetKrabbelById )
() *
long* .
	krabbelId/ 8
)8 9
{ 
if 

( 
	krabbelId 
!= 
$num 
) 
{ 	
return 
_krabbelRepository %
.% &
GetKrabbelById& 4
(4 5
	krabbelId5 >
)> ?
;? @
} 	
return 
null 
; 
} 
public   

List   
<   
ProfileKrabbel   
>   "
GetKrabbelsByProfileId    6
(  6 7
long  7 ;
	profileId  < E
)  E F
{!! 
return"" 
_krabbelRepository"" !
.""! ""
GetKrabbelsByProfileId""" 8
(""8 9
	profileId""9 B
)""B C
;""C D
}## 
public%% 

ProfileKrabbel%% 
?%% 

AddKrabbel%% %
(%%% &
ProfileKrabbel%%& 4
krabbel%%5 <
)%%< =
{&& 
krabbel'' 
.'' 
	CreatedAt'' 
='' 
DateTime'' $
.''$ %
Now''% (
;''( )
krabbel(( 
.(( 
	UpdatedAt(( 
=(( 
DateTime(( $
.(($ %
Now((% (
;((( )
return.. 
_krabbelRepository.. %
...% &

AddKrabbel..& 0
(..0 1
krabbel..1 8
)..8 9
;..9 :
}22 
public44 

ProfileKrabbel44 
?44 
UpdateKrabbel44 (
(44( )
ProfileKrabbel44) 7
krabbel448 ?
)44? @
{55 
krabbel66 
.66 
	UpdatedAt66 
=66 
DateTime66 $
.66$ %
Now66% (
;66( )
return<< 
_krabbelRepository<< %
.<<% &
UpdateKrabbel<<& 3
(<<3 4
krabbel<<4 ;
)<<; <
;<<< =
}@@ 
publicBB 

boolBB 
DeleteKrabbelBB 
(BB 
ProfileKrabbelBB ,
krabbelBB- 4
)BB4 5
{CC 
boolDD 
profileIdExistsDD 
=DD 
_krabbelRepositoryDD 1
.DD1 2
KrabbelExistsDD2 ?
(DD? @
krabbelDD@ G
.DDG H
	KrabbelIdDDH Q
)DDQ R
;DDR S
ifFF 

(FF 
profileIdExistsFF 
)FF 
{GG 	
returnHH 
_krabbelRepositoryHH %
.HH% &
DeleteKrabbelHH& 3
(HH3 4
krabbelHH4 ;
)HH; <
;HH< =
}II 	
returnKK 
falseKK 
;KK 
}LL 
}MM ˜
lC:\Users\Pim\Desktop\Semester 6\Individual project\Code\vybes-backend\KrabbelMicroservice\WeatherForecast.cs
	namespace 	
KrabbelMicroservice
 
; 
public 
class 
WeatherForecast 
{ 
public 

DateTime 
Date 
{ 
get 
; 
set  #
;# $
}% &
public 

int 
TemperatureC 
{ 
get !
;! "
set# &
;& '
}( )
public		 

int		 
TemperatureF		 
=>		 
$num		 !
+		" #
(		$ %
int		% (
)		( )
(		* +
TemperatureC		+ 7
/		8 9
$num		: @
)		@ A
;		A B
public 

string 
? 
Summary 
{ 
get  
;  !
set" %
;% &
}' (
} 