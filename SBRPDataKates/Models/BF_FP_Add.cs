using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataKates.Models;

[PrimaryKey("FPAddID", "FpId")]
[Table("BF_FP_Add")]
[Index("CardID", Name = "IX_BF_FP_Add")]
public partial class BF_FP_Add
{
    [Key]
    public int FPAddID { get; set; }

    [Key]
    public int FpId { get; set; }

    [StringLength(14)]
    public string CardID { get; set; } = null!;

    public short S_IP001 { get; set; }

    public short S_IP002 { get; set; }

    public short S_IP003 { get; set; }

    public short S_IP004 { get; set; }

    public short S_IP005 { get; set; }

    public short S_IP006 { get; set; }

    public short S_IP007 { get; set; }

    public short S_IP008 { get; set; }

    public short S_IP009 { get; set; }

    public short S_IP010 { get; set; }

    public short S_IP011 { get; set; }

    public short S_IP012 { get; set; }

    public short S_IP013 { get; set; }

    public short S_IP014 { get; set; }

    public short S_IP015 { get; set; }

    public short S_IP016 { get; set; }

    public short S_IP017 { get; set; }

    public short S_IP018 { get; set; }

    public short S_IP019 { get; set; }

    public short S_IP020 { get; set; }

    public short S_IP021 { get; set; }

    public short S_IP022 { get; set; }

    public short S_IP023 { get; set; }

    public short S_IP024 { get; set; }

    public short S_IP025 { get; set; }

    public short S_IP026 { get; set; }

    public short S_IP027 { get; set; }

    public short S_IP028 { get; set; }

    public short S_IP029 { get; set; }

    public short S_IP030 { get; set; }

    public short S_IP031 { get; set; }

    public short S_IP032 { get; set; }

    public short S_IP033 { get; set; }

    public short S_IP034 { get; set; }

    public short S_IP035 { get; set; }

    public short S_IP036 { get; set; }

    public short S_IP037 { get; set; }

    public short S_IP038 { get; set; }

    public short S_IP039 { get; set; }

    public short S_IP040 { get; set; }

    public short S_IP041 { get; set; }

    public short S_IP042 { get; set; }

    public short S_IP043 { get; set; }

    public short S_IP044 { get; set; }

    public short S_IP045 { get; set; }

    public short S_IP046 { get; set; }

    public short S_IP047 { get; set; }

    public short S_IP048 { get; set; }

    public short S_IP049 { get; set; }

    public short S_IP050 { get; set; }

    public short S_IP051 { get; set; }

    public short S_IP052 { get; set; }

    public short S_IP053 { get; set; }

    public short S_IP054 { get; set; }

    public short S_IP055 { get; set; }

    public short S_IP056 { get; set; }

    public short S_IP057 { get; set; }

    public short S_IP058 { get; set; }

    public short S_IP059 { get; set; }

    public short S_IP060 { get; set; }

    public short S_IP061 { get; set; }

    public short S_IP062 { get; set; }

    public short S_IP063 { get; set; }

    public short S_IP064 { get; set; }

    public short S_IP065 { get; set; }

    public short S_IP066 { get; set; }

    public short S_IP067 { get; set; }

    public short S_IP068 { get; set; }

    public short S_IP069 { get; set; }

    public short S_IP070 { get; set; }

    public short S_IP071 { get; set; }

    public short S_IP072 { get; set; }

    public short S_IP073 { get; set; }

    public short S_IP074 { get; set; }

    public short S_IP075 { get; set; }

    public short S_IP076 { get; set; }

    public short S_IP077 { get; set; }

    public short S_IP078 { get; set; }

    public short S_IP079 { get; set; }

    public short S_IP080 { get; set; }

    public short S_IP081 { get; set; }

    public short S_IP082 { get; set; }

    public short S_IP083 { get; set; }

    public short S_IP084 { get; set; }

    public short S_IP085 { get; set; }

    public short S_IP086 { get; set; }

    public short S_IP087 { get; set; }

    public short S_IP088 { get; set; }

    public short S_IP089 { get; set; }

    public short S_IP090 { get; set; }

    public short S_IP091 { get; set; }

    public short S_IP092 { get; set; }

    public short S_IP093 { get; set; }

    public short S_IP094 { get; set; }

    public short S_IP095 { get; set; }

    public short S_IP096 { get; set; }

    public short S_IP097 { get; set; }

    public short S_IP098 { get; set; }

    public short S_IP099 { get; set; }

    public short S_IP100 { get; set; }

    public short S_IP101 { get; set; }

    public short S_IP102 { get; set; }

    public short S_IP103 { get; set; }

    public short S_IP104 { get; set; }

    public short S_IP105 { get; set; }

    public short S_IP106 { get; set; }

    public short S_IP107 { get; set; }

    public short S_IP108 { get; set; }

    public short S_IP109 { get; set; }

    public short S_IP110 { get; set; }

    public short S_IP111 { get; set; }

    public short S_IP112 { get; set; }

    public short S_IP113 { get; set; }

    public short S_IP114 { get; set; }

    public short S_IP115 { get; set; }

    public short S_IP116 { get; set; }

    public short S_IP117 { get; set; }

    public short S_IP118 { get; set; }

    public short S_IP119 { get; set; }

    public short S_IP120 { get; set; }

    public short S_IP121 { get; set; }

    public short S_IP122 { get; set; }

    public short S_IP123 { get; set; }

    public short S_IP124 { get; set; }

    public short S_IP125 { get; set; }

    public short S_IP126 { get; set; }

    public short S_IP127 { get; set; }

    public short S_IP128 { get; set; }

    public short S_IP129 { get; set; }

    public short S_IP130 { get; set; }

    public short S_IP131 { get; set; }

    public short S_IP132 { get; set; }

    public short S_IP133 { get; set; }

    public short S_IP134 { get; set; }

    public short S_IP135 { get; set; }

    public short S_IP136 { get; set; }

    public short S_IP137 { get; set; }

    public short S_IP138 { get; set; }

    public short S_IP139 { get; set; }

    public short S_IP140 { get; set; }

    public short S_IP141 { get; set; }

    public short S_IP142 { get; set; }

    public short S_IP143 { get; set; }

    public short S_IP144 { get; set; }

    public short S_IP145 { get; set; }

    public short S_IP146 { get; set; }

    public short S_IP147 { get; set; }

    public short S_IP148 { get; set; }

    public short S_IP149 { get; set; }

    public short S_IP150 { get; set; }

    public short S_IP151 { get; set; }

    public short S_IP152 { get; set; }

    public short S_IP153 { get; set; }

    public short S_IP154 { get; set; }

    public short S_IP155 { get; set; }

    public short S_IP156 { get; set; }

    public short S_IP157 { get; set; }

    public short S_IP158 { get; set; }

    public short S_IP159 { get; set; }

    public short S_IP160 { get; set; }

    public short S_IP161 { get; set; }

    public short S_IP162 { get; set; }

    public short S_IP163 { get; set; }

    public short S_IP164 { get; set; }

    public short S_IP165 { get; set; }

    public short S_IP166 { get; set; }

    public short S_IP167 { get; set; }

    public short S_IP168 { get; set; }

    public short S_IP169 { get; set; }

    public short S_IP170 { get; set; }

    public short S_IP171 { get; set; }

    public short S_IP172 { get; set; }

    public short S_IP173 { get; set; }

    public short S_IP174 { get; set; }

    public short S_IP175 { get; set; }

    public short S_IP176 { get; set; }

    public short S_IP177 { get; set; }

    public short S_IP178 { get; set; }

    public short S_IP179 { get; set; }

    public short S_IP180 { get; set; }

    public short S_IP181 { get; set; }

    public short S_IP182 { get; set; }

    public short S_IP183 { get; set; }

    public short S_IP184 { get; set; }

    public short S_IP185 { get; set; }

    public short S_IP186 { get; set; }

    public short S_IP187 { get; set; }

    public short S_IP188 { get; set; }

    public short S_IP189 { get; set; }

    public short S_IP190 { get; set; }

    public short S_IP191 { get; set; }

    public short S_IP192 { get; set; }

    public short S_IP193 { get; set; }

    public short S_IP194 { get; set; }

    public short S_IP195 { get; set; }

    public short S_IP196 { get; set; }

    public short S_IP197 { get; set; }

    public short S_IP198 { get; set; }

    public short S_IP199 { get; set; }

    public short S_IP200 { get; set; }

    public short S_IP201 { get; set; }

    public short S_IP202 { get; set; }

    public short S_IP203 { get; set; }

    public short S_IP204 { get; set; }

    public short S_IP205 { get; set; }

    public short S_IP206 { get; set; }

    public short S_IP207 { get; set; }

    public short S_IP208 { get; set; }

    public short S_IP209 { get; set; }

    public short S_IP210 { get; set; }

    public short S_IP211 { get; set; }

    public short S_IP212 { get; set; }

    public short S_IP213 { get; set; }

    public short S_IP214 { get; set; }

    public short S_IP215 { get; set; }

    public short S_IP216 { get; set; }

    public short S_IP217 { get; set; }

    public short S_IP218 { get; set; }

    public short S_IP219 { get; set; }

    public short S_IP220 { get; set; }

    public short S_IP221 { get; set; }

    public short S_IP222 { get; set; }

    public short S_IP223 { get; set; }

    public short S_IP224 { get; set; }

    public short S_IP225 { get; set; }

    public short S_IP226 { get; set; }

    public short S_IP227 { get; set; }

    public short S_IP228 { get; set; }

    public short S_IP229 { get; set; }

    public short S_IP230 { get; set; }

    public short S_IP231 { get; set; }

    public short S_IP232 { get; set; }

    public short S_IP233 { get; set; }

    public short S_IP234 { get; set; }

    public short S_IP235 { get; set; }

    public short S_IP236 { get; set; }

    public short S_IP237 { get; set; }

    public short S_IP238 { get; set; }

    public short S_IP239 { get; set; }

    public short S_IP240 { get; set; }

    public short S_IP241 { get; set; }

    public short S_IP242 { get; set; }

    public short S_IP243 { get; set; }

    public short S_IP244 { get; set; }

    public short S_IP245 { get; set; }

    public short S_IP246 { get; set; }

    public short S_IP247 { get; set; }

    public short S_IP248 { get; set; }

    public short S_IP249 { get; set; }

    public short S_IP250 { get; set; }

    public short S_IP251 { get; set; }

    public short S_IP252 { get; set; }

    public short S_IP253 { get; set; }

    public short S_IP254 { get; set; }

    public short S_IP255 { get; set; }

    public short S_IP256 { get; set; }

    public short S_IP257 { get; set; }

    public short S_IP258 { get; set; }

    public short S_IP259 { get; set; }

    public short S_IP260 { get; set; }

    public short S_IP261 { get; set; }

    public short S_IP262 { get; set; }

    public short S_IP263 { get; set; }

    public short S_IP264 { get; set; }

    public short S_IP265 { get; set; }

    public short S_IP266 { get; set; }

    public short S_IP267 { get; set; }

    public short S_IP268 { get; set; }

    public short S_IP269 { get; set; }

    public short S_IP270 { get; set; }

    public short S_IP271 { get; set; }

    public short S_IP272 { get; set; }

    public short S_IP273 { get; set; }

    public short S_IP274 { get; set; }

    public short S_IP275 { get; set; }

    public short S_IP276 { get; set; }

    public short S_IP277 { get; set; }

    public short S_IP278 { get; set; }

    public short S_IP279 { get; set; }

    public short S_IP280 { get; set; }

    public short S_IP281 { get; set; }

    public short S_IP282 { get; set; }

    public short S_IP283 { get; set; }

    public short S_IP284 { get; set; }

    public short S_IP285 { get; set; }

    public short S_IP286 { get; set; }

    public short S_IP287 { get; set; }

    public short S_IP288 { get; set; }

    public short S_IP289 { get; set; }

    public short S_IP290 { get; set; }

    public short S_IP291 { get; set; }

    public short S_IP292 { get; set; }

    public short S_IP293 { get; set; }

    public short S_IP294 { get; set; }

    public short S_IP295 { get; set; }

    public short S_IP296 { get; set; }

    public short S_IP297 { get; set; }

    public short S_IP298 { get; set; }

    public short S_IP299 { get; set; }

    public short S_IP300 { get; set; }

    public short S_IP301 { get; set; }

    public short S_IP302 { get; set; }

    public short S_IP303 { get; set; }

    public short S_IP304 { get; set; }

    public short S_IP305 { get; set; }

    public short S_IP306 { get; set; }

    public short S_IP307 { get; set; }

    public short S_IP308 { get; set; }

    public short S_IP309 { get; set; }

    public short S_IP310 { get; set; }

    public short S_IP311 { get; set; }

    public short S_IP312 { get; set; }

    public short S_IP313 { get; set; }

    public short S_IP314 { get; set; }

    public short S_IP315 { get; set; }

    public short S_IP316 { get; set; }

    public short S_IP317 { get; set; }

    public short S_IP318 { get; set; }

    public short S_IP319 { get; set; }

    public short S_IP320 { get; set; }

    public short S_IP321 { get; set; }

    public short S_IP322 { get; set; }

    public short S_IP323 { get; set; }

    public short S_IP324 { get; set; }

    public short S_IP325 { get; set; }

    public short S_IP326 { get; set; }

    public short S_IP327 { get; set; }

    public short S_IP328 { get; set; }

    public short S_IP329 { get; set; }

    public short S_IP330 { get; set; }

    public short S_IP331 { get; set; }

    public short S_IP332 { get; set; }

    public short S_IP333 { get; set; }

    public short S_IP334 { get; set; }

    public short S_IP335 { get; set; }

    public short S_IP336 { get; set; }

    public short S_IP337 { get; set; }

    public short S_IP338 { get; set; }

    public short S_IP339 { get; set; }

    public short S_IP340 { get; set; }

    public short S_IP341 { get; set; }

    public short S_IP342 { get; set; }

    public short S_IP343 { get; set; }

    public short S_IP344 { get; set; }

    public short S_IP345 { get; set; }

    public short S_IP346 { get; set; }

    public short S_IP347 { get; set; }

    public short S_IP348 { get; set; }

    public short S_IP349 { get; set; }

    public short S_IP350 { get; set; }

    public short S_IP351 { get; set; }

    public short S_IP352 { get; set; }

    public short S_IP353 { get; set; }

    public short S_IP354 { get; set; }

    public short S_IP355 { get; set; }

    public short S_IP356 { get; set; }

    public short S_IP357 { get; set; }

    public short S_IP358 { get; set; }

    public short S_IP359 { get; set; }

    public short S_IP360 { get; set; }

    public short S_IP361 { get; set; }

    public short S_IP362 { get; set; }

    public short S_IP363 { get; set; }

    public short S_IP364 { get; set; }

    public short S_IP365 { get; set; }

    public short S_IP366 { get; set; }

    public short S_IP367 { get; set; }

    public short S_IP368 { get; set; }

    public short S_IP369 { get; set; }

    public short S_IP370 { get; set; }

    public short S_IP371 { get; set; }

    public short S_IP372 { get; set; }

    public short S_IP373 { get; set; }

    public short S_IP374 { get; set; }

    public short S_IP375 { get; set; }

    public short S_IP376 { get; set; }

    public short S_IP377 { get; set; }

    public short S_IP378 { get; set; }

    public short S_IP379 { get; set; }

    public short S_IP380 { get; set; }

    public short S_IP381 { get; set; }

    public short S_IP382 { get; set; }

    public short S_IP383 { get; set; }

    public short S_IP384 { get; set; }

    public short S_IP385 { get; set; }

    public short S_IP386 { get; set; }

    public short S_IP387 { get; set; }

    public short S_IP388 { get; set; }

    public short S_IP389 { get; set; }

    public short S_IP390 { get; set; }

    public short S_IP391 { get; set; }

    public short S_IP392 { get; set; }

    public short S_IP393 { get; set; }

    public short S_IP394 { get; set; }

    public short S_IP395 { get; set; }

    public short S_IP396 { get; set; }

    public short S_IP397 { get; set; }

    public short S_IP398 { get; set; }

    public short S_IP399 { get; set; }

    public short S_IP400 { get; set; }

    public short S_IP401 { get; set; }

    public short S_IP402 { get; set; }

    public short S_IP403 { get; set; }

    public short S_IP404 { get; set; }

    public short S_IP405 { get; set; }

    public short S_IP406 { get; set; }

    public short S_IP407 { get; set; }

    public short S_IP408 { get; set; }

    public short S_IP409 { get; set; }

    public short S_IP410 { get; set; }

    public short S_IP411 { get; set; }

    public short S_IP412 { get; set; }

    public short S_IP413 { get; set; }

    public short S_IP414 { get; set; }

    public short S_IP415 { get; set; }

    public short S_IP416 { get; set; }

    public short S_IP417 { get; set; }

    public short S_IP418 { get; set; }

    public short S_IP419 { get; set; }

    public short S_IP420 { get; set; }

    public short S_IP421 { get; set; }

    public short S_IP422 { get; set; }

    public short S_IP423 { get; set; }

    public short S_IP424 { get; set; }

    public short S_IP425 { get; set; }

    public short S_IP426 { get; set; }

    public short S_IP427 { get; set; }

    public short S_IP428 { get; set; }

    public short S_IP429 { get; set; }

    public short S_IP430 { get; set; }

    public short S_IP431 { get; set; }

    public short S_IP432 { get; set; }

    public short S_IP433 { get; set; }

    public short S_IP434 { get; set; }

    public short S_IP435 { get; set; }

    public short S_IP436 { get; set; }

    public short S_IP437 { get; set; }

    public short S_IP438 { get; set; }

    public short S_IP439 { get; set; }

    public short S_IP440 { get; set; }

    public short S_IP441 { get; set; }

    public short S_IP442 { get; set; }

    public short S_IP443 { get; set; }

    public short S_IP444 { get; set; }

    public short S_IP445 { get; set; }

    public short S_IP446 { get; set; }

    public short S_IP447 { get; set; }

    public short S_IP448 { get; set; }

    public short S_IP449 { get; set; }

    public short S_IP450 { get; set; }

    public short S_IP451 { get; set; }

    public short S_IP452 { get; set; }

    public short S_IP453 { get; set; }

    public short S_IP454 { get; set; }

    public short S_IP455 { get; set; }

    public short S_IP456 { get; set; }

    public short S_IP457 { get; set; }

    public short S_IP458 { get; set; }

    public short S_IP459 { get; set; }

    public short S_IP460 { get; set; }

    public short S_IP461 { get; set; }

    public short S_IP462 { get; set; }

    public short S_IP463 { get; set; }

    public short S_IP464 { get; set; }

    public short S_IP465 { get; set; }

    public short S_IP466 { get; set; }

    public short S_IP467 { get; set; }

    public short S_IP468 { get; set; }

    public short S_IP469 { get; set; }

    public short S_IP470 { get; set; }

    public short S_IP471 { get; set; }

    public short S_IP472 { get; set; }

    public short S_IP473 { get; set; }

    public short S_IP474 { get; set; }

    public short S_IP475 { get; set; }

    public short S_IP476 { get; set; }

    public short S_IP477 { get; set; }

    public short S_IP478 { get; set; }

    public short S_IP479 { get; set; }

    public short S_IP480 { get; set; }

    public short S_IP481 { get; set; }

    public short S_IP482 { get; set; }

    public short S_IP483 { get; set; }

    public short S_IP484 { get; set; }

    public short S_IP485 { get; set; }

    public short S_IP486 { get; set; }

    public short S_IP487 { get; set; }

    public short S_IP488 { get; set; }

    public short S_IP489 { get; set; }

    public short S_IP490 { get; set; }

    public short S_IP491 { get; set; }

    public short S_IP492 { get; set; }

    public short S_IP493 { get; set; }

    public short S_IP494 { get; set; }

    public short S_IP495 { get; set; }

    public short S_IP496 { get; set; }

    public short S_IP497 { get; set; }

    public short S_IP498 { get; set; }

    public short S_IP499 { get; set; }

    public short S_IP500 { get; set; }
}
