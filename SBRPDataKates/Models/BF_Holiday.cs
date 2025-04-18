using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataKates.Models;

[Table("BF_Holiday")]
public partial class BF_Holiday
{
    [Key]
    public int DoorHoliID { get; set; }

    public byte DoorID { get; set; }

    public byte HoliMonth { get; set; }

    public byte HoliDay { get; set; }

    public byte HoliType { get; set; }

    [StringLength(20)]
    public string? Description { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime TimeAddNew { get; set; }

    public int UserAddNewSID { get; set; }

    public short Slave001 { get; set; }

    public short Slave002 { get; set; }

    public short Slave003 { get; set; }

    public short Slave004 { get; set; }

    public short Slave005 { get; set; }

    public short Slave006 { get; set; }

    public short Slave007 { get; set; }

    public short Slave008 { get; set; }

    public short Slave009 { get; set; }

    public short Slave010 { get; set; }

    public short Slave011 { get; set; }

    public short Slave012 { get; set; }

    public short Slave013 { get; set; }

    public short Slave014 { get; set; }

    public short Slave015 { get; set; }

    public short Slave016 { get; set; }

    public short Slave017 { get; set; }

    public short Slave018 { get; set; }

    public short Slave019 { get; set; }

    public short Slave020 { get; set; }

    public short Slave021 { get; set; }

    public short Slave022 { get; set; }

    public short Slave023 { get; set; }

    public short Slave024 { get; set; }

    public short Slave025 { get; set; }

    public short Slave026 { get; set; }

    public short Slave027 { get; set; }

    public short Slave028 { get; set; }

    public short Slave029 { get; set; }

    public short Slave030 { get; set; }

    public short Slave031 { get; set; }

    public short Slave032 { get; set; }

    public short Slave033 { get; set; }

    public short Slave034 { get; set; }

    public short Slave035 { get; set; }

    public short Slave036 { get; set; }

    public short Slave037 { get; set; }

    public short Slave038 { get; set; }

    public short Slave039 { get; set; }

    public short Slave040 { get; set; }

    public short Slave041 { get; set; }

    public short Slave042 { get; set; }

    public short Slave043 { get; set; }

    public short Slave044 { get; set; }

    public short Slave045 { get; set; }

    public short Slave046 { get; set; }

    public short Slave047 { get; set; }

    public short Slave048 { get; set; }

    public short Slave049 { get; set; }

    public short Slave050 { get; set; }

    public short Slave051 { get; set; }

    public short Slave052 { get; set; }

    public short Slave053 { get; set; }

    public short Slave054 { get; set; }

    public short Slave055 { get; set; }

    public short Slave056 { get; set; }

    public short Slave057 { get; set; }

    public short Slave058 { get; set; }

    public short Slave059 { get; set; }

    public short Slave060 { get; set; }

    public short Slave061 { get; set; }

    public short Slave062 { get; set; }

    public short Slave063 { get; set; }

    public short Slave064 { get; set; }

    public short Slave065 { get; set; }

    public short Slave066 { get; set; }

    public short Slave067 { get; set; }

    public short Slave068 { get; set; }

    public short Slave069 { get; set; }

    public short Slave070 { get; set; }

    public short Slave071 { get; set; }

    public short Slave072 { get; set; }

    public short Slave073 { get; set; }

    public short Slave074 { get; set; }

    public short Slave075 { get; set; }

    public short Slave076 { get; set; }

    public short Slave077 { get; set; }

    public short Slave078 { get; set; }

    public short Slave079 { get; set; }

    public short Slave080 { get; set; }

    public short Slave081 { get; set; }

    public short Slave082 { get; set; }

    public short Slave083 { get; set; }

    public short Slave084 { get; set; }

    public short Slave085 { get; set; }

    public short Slave086 { get; set; }

    public short Slave087 { get; set; }

    public short Slave088 { get; set; }

    public short Slave089 { get; set; }

    public short Slave090 { get; set; }

    public short Slave091 { get; set; }

    public short Slave092 { get; set; }

    public short Slave093 { get; set; }

    public short Slave094 { get; set; }

    public short Slave095 { get; set; }

    public short Slave096 { get; set; }

    public short Slave097 { get; set; }

    public short Slave098 { get; set; }

    public short Slave099 { get; set; }

    public short Slave100 { get; set; }

    public short Slave101 { get; set; }

    public short Slave102 { get; set; }

    public short Slave103 { get; set; }

    public short Slave104 { get; set; }

    public short Slave105 { get; set; }

    public short Slave106 { get; set; }

    public short Slave107 { get; set; }

    public short Slave108 { get; set; }

    public short Slave109 { get; set; }

    public short Slave110 { get; set; }

    public short Slave111 { get; set; }

    public short Slave112 { get; set; }

    public short Slave113 { get; set; }

    public short Slave114 { get; set; }

    public short Slave115 { get; set; }

    public short Slave116 { get; set; }

    public short Slave117 { get; set; }

    public short Slave118 { get; set; }

    public short Slave119 { get; set; }

    public short Slave120 { get; set; }

    public short Slave121 { get; set; }

    public short Slave122 { get; set; }

    public short Slave123 { get; set; }

    public short Slave124 { get; set; }

    public short Slave125 { get; set; }

    public short Slave126 { get; set; }

    public short Slave127 { get; set; }

    public short Slave128 { get; set; }

    public short Slave129 { get; set; }

    public short Slave130 { get; set; }

    public short Slave131 { get; set; }

    public short Slave132 { get; set; }

    public short Slave133 { get; set; }

    public short Slave134 { get; set; }

    public short Slave135 { get; set; }

    public short Slave136 { get; set; }

    public short Slave137 { get; set; }

    public short Slave138 { get; set; }

    public short Slave139 { get; set; }

    public short Slave140 { get; set; }

    public short Slave141 { get; set; }

    public short Slave142 { get; set; }

    public short Slave143 { get; set; }

    public short Slave144 { get; set; }

    public short Slave145 { get; set; }

    public short Slave146 { get; set; }

    public short Slave147 { get; set; }

    public short Slave148 { get; set; }

    public short Slave149 { get; set; }

    public short Slave150 { get; set; }

    public short Slave151 { get; set; }

    public short Slave152 { get; set; }

    public short Slave153 { get; set; }

    public short Slave154 { get; set; }

    public short Slave155 { get; set; }

    public short Slave156 { get; set; }

    public short Slave157 { get; set; }

    public short Slave158 { get; set; }

    public short Slave159 { get; set; }

    public short Slave160 { get; set; }

    public short Slave161 { get; set; }

    public short Slave162 { get; set; }

    public short Slave163 { get; set; }

    public short Slave164 { get; set; }

    public short Slave165 { get; set; }

    public short Slave166 { get; set; }

    public short Slave167 { get; set; }

    public short Slave168 { get; set; }

    public short Slave169 { get; set; }

    public short Slave170 { get; set; }

    public short Slave171 { get; set; }

    public short Slave172 { get; set; }

    public short Slave173 { get; set; }

    public short Slave174 { get; set; }

    public short Slave175 { get; set; }

    public short Slave176 { get; set; }

    public short Slave177 { get; set; }

    public short Slave178 { get; set; }

    public short Slave179 { get; set; }

    public short Slave180 { get; set; }

    public short Slave181 { get; set; }

    public short Slave182 { get; set; }

    public short Slave183 { get; set; }

    public short Slave184 { get; set; }

    public short Slave185 { get; set; }

    public short Slave186 { get; set; }

    public short Slave187 { get; set; }

    public short Slave188 { get; set; }

    public short Slave189 { get; set; }

    public short Slave190 { get; set; }

    public short Slave191 { get; set; }

    public short Slave192 { get; set; }

    public short Slave193 { get; set; }

    public short Slave194 { get; set; }

    public short Slave195 { get; set; }

    public short Slave196 { get; set; }

    public short Slave197 { get; set; }

    public short Slave198 { get; set; }

    public short Slave199 { get; set; }

    public short Slave200 { get; set; }

    public short Slave201 { get; set; }

    public short Slave202 { get; set; }

    public short Slave203 { get; set; }

    public short Slave204 { get; set; }

    public short Slave205 { get; set; }

    public short Slave206 { get; set; }

    public short Slave207 { get; set; }

    public short Slave208 { get; set; }

    public short Slave209 { get; set; }

    public short Slave210 { get; set; }

    public short Slave211 { get; set; }

    public short Slave212 { get; set; }

    public short Slave213 { get; set; }

    public short Slave214 { get; set; }

    public short Slave215 { get; set; }

    public short Slave216 { get; set; }

    public short Slave217 { get; set; }

    public short Slave218 { get; set; }

    public short Slave219 { get; set; }

    public short Slave220 { get; set; }

    public short Slave221 { get; set; }

    public short Slave222 { get; set; }

    public short Slave223 { get; set; }

    public short Slave224 { get; set; }

    public short Slave225 { get; set; }

    public short Slave226 { get; set; }

    public short Slave227 { get; set; }

    public short Slave228 { get; set; }

    public short Slave229 { get; set; }

    public short Slave230 { get; set; }

    public short Slave231 { get; set; }

    public short Slave232 { get; set; }

    public short Slave233 { get; set; }

    public short Slave234 { get; set; }

    public short Slave235 { get; set; }

    public short Slave236 { get; set; }

    public short Slave237 { get; set; }

    public short Slave238 { get; set; }

    public short Slave239 { get; set; }

    public short Slave240 { get; set; }

    public short Slave241 { get; set; }

    public short Slave242 { get; set; }

    public short Slave243 { get; set; }

    public short Slave244 { get; set; }

    public short Slave245 { get; set; }

    public short Slave246 { get; set; }

    public short Slave247 { get; set; }

    public short Slave248 { get; set; }

    public short Slave249 { get; set; }

    public short Slave250 { get; set; }

    public short Slave251 { get; set; }

    public short Slave252 { get; set; }

    public short Slave253 { get; set; }

    public short Slave254 { get; set; }

    public short Slave255 { get; set; }

    public short Slave256 { get; set; }

    public short Slave257 { get; set; }

    public short Slave258 { get; set; }

    public short Slave259 { get; set; }

    public short Slave260 { get; set; }

    public short Slave261 { get; set; }

    public short Slave262 { get; set; }

    public short Slave263 { get; set; }

    public short Slave264 { get; set; }

    public short Slave265 { get; set; }

    public short Slave266 { get; set; }

    public short Slave267 { get; set; }

    public short Slave268 { get; set; }

    public short Slave269 { get; set; }

    public short Slave270 { get; set; }

    public short Slave271 { get; set; }

    public short Slave272 { get; set; }

    public short Slave273 { get; set; }

    public short Slave274 { get; set; }

    public short Slave275 { get; set; }

    public short Slave276 { get; set; }

    public short Slave277 { get; set; }

    public short Slave278 { get; set; }

    public short Slave279 { get; set; }

    public short Slave280 { get; set; }

    public short Slave281 { get; set; }

    public short Slave282 { get; set; }

    public short Slave283 { get; set; }

    public short Slave284 { get; set; }

    public short Slave285 { get; set; }

    public short Slave286 { get; set; }

    public short Slave287 { get; set; }

    public short Slave288 { get; set; }

    public short Slave289 { get; set; }

    public short Slave290 { get; set; }

    public short Slave291 { get; set; }

    public short Slave292 { get; set; }

    public short Slave293 { get; set; }

    public short Slave294 { get; set; }

    public short Slave295 { get; set; }

    public short Slave296 { get; set; }

    public short Slave297 { get; set; }

    public short Slave298 { get; set; }

    public short Slave299 { get; set; }

    public short Slave300 { get; set; }

    public short Slave301 { get; set; }

    public short Slave302 { get; set; }

    public short Slave303 { get; set; }

    public short Slave304 { get; set; }

    public short Slave305 { get; set; }

    public short Slave306 { get; set; }

    public short Slave307 { get; set; }

    public short Slave308 { get; set; }

    public short Slave309 { get; set; }

    public short Slave310 { get; set; }

    public short Slave311 { get; set; }

    public short Slave312 { get; set; }

    public short Slave313 { get; set; }

    public short Slave314 { get; set; }

    public short Slave315 { get; set; }

    public short Slave316 { get; set; }

    public short Slave317 { get; set; }

    public short Slave318 { get; set; }

    public short Slave319 { get; set; }

    public short Slave320 { get; set; }

    public short Slave321 { get; set; }

    public short Slave322 { get; set; }

    public short Slave323 { get; set; }

    public short Slave324 { get; set; }

    public short Slave325 { get; set; }

    public short Slave326 { get; set; }

    public short Slave327 { get; set; }

    public short Slave328 { get; set; }

    public short Slave329 { get; set; }

    public short Slave330 { get; set; }

    public short Slave331 { get; set; }

    public short Slave332 { get; set; }

    public short Slave333 { get; set; }

    public short Slave334 { get; set; }

    public short Slave335 { get; set; }

    public short Slave336 { get; set; }

    public short Slave337 { get; set; }

    public short Slave338 { get; set; }

    public short Slave339 { get; set; }

    public short Slave340 { get; set; }

    public short Slave341 { get; set; }

    public short Slave342 { get; set; }

    public short Slave343 { get; set; }

    public short Slave344 { get; set; }

    public short Slave345 { get; set; }

    public short Slave346 { get; set; }

    public short Slave347 { get; set; }

    public short Slave348 { get; set; }

    public short Slave349 { get; set; }

    public short Slave350 { get; set; }

    public short Slave351 { get; set; }

    public short Slave352 { get; set; }

    public short Slave353 { get; set; }

    public short Slave354 { get; set; }

    public short Slave355 { get; set; }

    public short Slave356 { get; set; }

    public short Slave357 { get; set; }

    public short Slave358 { get; set; }

    public short Slave359 { get; set; }

    public short Slave360 { get; set; }

    public short Slave361 { get; set; }

    public short Slave362 { get; set; }

    public short Slave363 { get; set; }

    public short Slave364 { get; set; }

    public short Slave365 { get; set; }

    public short Slave366 { get; set; }

    public short Slave367 { get; set; }

    public short Slave368 { get; set; }

    public short Slave369 { get; set; }

    public short Slave370 { get; set; }

    public short Slave371 { get; set; }

    public short Slave372 { get; set; }

    public short Slave373 { get; set; }

    public short Slave374 { get; set; }

    public short Slave375 { get; set; }

    public short Slave376 { get; set; }

    public short Slave377 { get; set; }

    public short Slave378 { get; set; }

    public short Slave379 { get; set; }

    public short Slave380 { get; set; }

    public short Slave381 { get; set; }

    public short Slave382 { get; set; }

    public short Slave383 { get; set; }

    public short Slave384 { get; set; }

    public short Slave385 { get; set; }

    public short Slave386 { get; set; }

    public short Slave387 { get; set; }

    public short Slave388 { get; set; }

    public short Slave389 { get; set; }

    public short Slave390 { get; set; }

    public short Slave391 { get; set; }

    public short Slave392 { get; set; }

    public short Slave393 { get; set; }

    public short Slave394 { get; set; }

    public short Slave395 { get; set; }

    public short Slave396 { get; set; }

    public short Slave397 { get; set; }

    public short Slave398 { get; set; }

    public short Slave399 { get; set; }

    public short Slave400 { get; set; }

    public short Slave401 { get; set; }

    public short Slave402 { get; set; }

    public short Slave403 { get; set; }

    public short Slave404 { get; set; }

    public short Slave405 { get; set; }

    public short Slave406 { get; set; }

    public short Slave407 { get; set; }

    public short Slave408 { get; set; }

    public short Slave409 { get; set; }

    public short Slave410 { get; set; }

    public short Slave411 { get; set; }

    public short Slave412 { get; set; }

    public short Slave413 { get; set; }

    public short Slave414 { get; set; }

    public short Slave415 { get; set; }

    public short Slave416 { get; set; }

    public short Slave417 { get; set; }

    public short Slave418 { get; set; }

    public short Slave419 { get; set; }

    public short Slave420 { get; set; }

    public short Slave421 { get; set; }

    public short Slave422 { get; set; }

    public short Slave423 { get; set; }

    public short Slave424 { get; set; }

    public short Slave425 { get; set; }

    public short Slave426 { get; set; }

    public short Slave427 { get; set; }

    public short Slave428 { get; set; }

    public short Slave429 { get; set; }

    public short Slave430 { get; set; }

    public short Slave431 { get; set; }

    public short Slave432 { get; set; }

    public short Slave433 { get; set; }

    public short Slave434 { get; set; }

    public short Slave435 { get; set; }

    public short Slave436 { get; set; }

    public short Slave437 { get; set; }

    public short Slave438 { get; set; }

    public short Slave439 { get; set; }

    public short Slave440 { get; set; }

    public short Slave441 { get; set; }

    public short Slave442 { get; set; }

    public short Slave443 { get; set; }

    public short Slave444 { get; set; }

    public short Slave445 { get; set; }

    public short Slave446 { get; set; }

    public short Slave447 { get; set; }

    public short Slave448 { get; set; }

    public short Slave449 { get; set; }

    public short Slave450 { get; set; }

    public short Slave451 { get; set; }

    public short Slave452 { get; set; }

    public short Slave453 { get; set; }

    public short Slave454 { get; set; }

    public short Slave455 { get; set; }

    public short Slave456 { get; set; }

    public short Slave457 { get; set; }

    public short Slave458 { get; set; }

    public short Slave459 { get; set; }

    public short Slave460 { get; set; }

    public short Slave461 { get; set; }

    public short Slave462 { get; set; }

    public short Slave463 { get; set; }

    public short Slave464 { get; set; }

    public short Slave465 { get; set; }

    public short Slave466 { get; set; }

    public short Slave467 { get; set; }

    public short Slave468 { get; set; }

    public short Slave469 { get; set; }

    public short Slave470 { get; set; }

    public short Slave471 { get; set; }

    public short Slave472 { get; set; }

    public short Slave473 { get; set; }

    public short Slave474 { get; set; }

    public short Slave475 { get; set; }

    public short Slave476 { get; set; }

    public short Slave477 { get; set; }

    public short Slave478 { get; set; }

    public short Slave479 { get; set; }

    public short Slave480 { get; set; }

    public short Slave481 { get; set; }

    public short Slave482 { get; set; }

    public short Slave483 { get; set; }

    public short Slave484 { get; set; }

    public short Slave485 { get; set; }

    public short Slave486 { get; set; }

    public short Slave487 { get; set; }

    public short Slave488 { get; set; }

    public short Slave489 { get; set; }

    public short Slave490 { get; set; }

    public short Slave491 { get; set; }

    public short Slave492 { get; set; }

    public short Slave493 { get; set; }

    public short Slave494 { get; set; }

    public short Slave495 { get; set; }

    public short Slave496 { get; set; }

    public short Slave497 { get; set; }

    public short Slave498 { get; set; }

    public short Slave499 { get; set; }

    public short Slave500 { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? TimeModifyLast { get; set; }

    public int? UserModifyLastSID { get; set; }
}
