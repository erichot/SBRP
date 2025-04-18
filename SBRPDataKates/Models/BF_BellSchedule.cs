using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataKates.Models;

[Table("BF_BellSchedule")]
public partial class BF_BellSchedule
{
    [Key]
    public int BellTimeSID { get; set; }

    public bool IsEnabled { get; set; }

    public byte RingTimeHour { get; set; }

    public byte RingTimeMinute { get; set; }

    public short Duration { get; set; }

    public bool WeeklySun { get; set; }

    public bool WeeklyMon { get; set; }

    public bool WeeklyTue { get; set; }

    public bool WeeklyWed { get; set; }

    public bool WeeklyThu { get; set; }

    public bool WeeklyFri { get; set; }

    public bool WeeklySat { get; set; }

    public bool Slave001 { get; set; }

    public bool Slave002 { get; set; }

    public bool Slave003 { get; set; }

    public bool Slave004 { get; set; }

    public bool Slave005 { get; set; }

    public bool Slave006 { get; set; }

    public bool Slave007 { get; set; }

    public bool Slave008 { get; set; }

    public bool Slave009 { get; set; }

    public bool Slave010 { get; set; }

    public bool Slave011 { get; set; }

    public bool Slave012 { get; set; }

    public bool Slave013 { get; set; }

    public bool Slave014 { get; set; }

    public bool Slave015 { get; set; }

    public bool Slave016 { get; set; }

    public bool Slave017 { get; set; }

    public bool Slave018 { get; set; }

    public bool Slave019 { get; set; }

    public bool Slave020 { get; set; }

    public bool Slave021 { get; set; }

    public bool Slave022 { get; set; }

    public bool Slave023 { get; set; }

    public bool Slave024 { get; set; }

    public bool Slave025 { get; set; }

    public bool Slave026 { get; set; }

    public bool Slave027 { get; set; }

    public bool Slave028 { get; set; }

    public bool Slave029 { get; set; }

    public bool Slave030 { get; set; }

    public bool Slave031 { get; set; }

    public bool Slave032 { get; set; }

    public bool Slave033 { get; set; }

    public bool Slave034 { get; set; }

    public bool Slave035 { get; set; }

    public bool Slave036 { get; set; }

    public bool Slave037 { get; set; }

    public bool Slave038 { get; set; }

    public bool Slave039 { get; set; }

    public bool Slave040 { get; set; }

    public bool Slave041 { get; set; }

    public bool Slave042 { get; set; }

    public bool Slave043 { get; set; }

    public bool Slave044 { get; set; }

    public bool Slave045 { get; set; }

    public bool Slave046 { get; set; }

    public bool Slave047 { get; set; }

    public bool Slave048 { get; set; }

    public bool Slave049 { get; set; }

    public bool Slave050 { get; set; }

    public bool Slave051 { get; set; }

    public bool Slave052 { get; set; }

    public bool Slave053 { get; set; }

    public bool Slave054 { get; set; }

    public bool Slave055 { get; set; }

    public bool Slave056 { get; set; }

    public bool Slave057 { get; set; }

    public bool Slave058 { get; set; }

    public bool Slave059 { get; set; }

    public bool Slave060 { get; set; }

    public bool Slave061 { get; set; }

    public bool Slave062 { get; set; }

    public bool Slave063 { get; set; }

    public bool Slave064 { get; set; }

    public bool Slave065 { get; set; }

    public bool Slave066 { get; set; }

    public bool Slave067 { get; set; }

    public bool Slave068 { get; set; }

    public bool Slave069 { get; set; }

    public bool Slave070 { get; set; }

    public bool Slave071 { get; set; }

    public bool Slave072 { get; set; }

    public bool Slave073 { get; set; }

    public bool Slave074 { get; set; }

    public bool Slave075 { get; set; }

    public bool Slave076 { get; set; }

    public bool Slave077 { get; set; }

    public bool Slave078 { get; set; }

    public bool Slave079 { get; set; }

    public bool Slave080 { get; set; }

    public bool Slave081 { get; set; }

    public bool Slave082 { get; set; }

    public bool Slave083 { get; set; }

    public bool Slave084 { get; set; }

    public bool Slave085 { get; set; }

    public bool Slave086 { get; set; }

    public bool Slave087 { get; set; }

    public bool Slave088 { get; set; }

    public bool Slave089 { get; set; }

    public bool Slave090 { get; set; }

    public bool Slave091 { get; set; }

    public bool Slave092 { get; set; }

    public bool Slave093 { get; set; }

    public bool Slave094 { get; set; }

    public bool Slave095 { get; set; }

    public bool Slave096 { get; set; }

    public bool Slave097 { get; set; }

    public bool Slave098 { get; set; }

    public bool Slave099 { get; set; }

    public bool Slave100 { get; set; }

    public bool Slave101 { get; set; }

    public bool Slave102 { get; set; }

    public bool Slave103 { get; set; }

    public bool Slave104 { get; set; }

    public bool Slave105 { get; set; }

    public bool Slave106 { get; set; }

    public bool Slave107 { get; set; }

    public bool Slave108 { get; set; }

    public bool Slave109 { get; set; }

    public bool Slave110 { get; set; }

    public bool Slave111 { get; set; }

    public bool Slave112 { get; set; }

    public bool Slave113 { get; set; }

    public bool Slave114 { get; set; }

    public bool Slave115 { get; set; }

    public bool Slave116 { get; set; }

    public bool Slave117 { get; set; }

    public bool Slave118 { get; set; }

    public bool Slave119 { get; set; }

    public bool Slave120 { get; set; }

    public bool Slave121 { get; set; }

    public bool Slave122 { get; set; }

    public bool Slave123 { get; set; }

    public bool Slave124 { get; set; }

    public bool Slave125 { get; set; }

    public bool Slave126 { get; set; }

    public bool Slave127 { get; set; }

    public bool Slave128 { get; set; }

    public bool Slave129 { get; set; }

    public bool Slave130 { get; set; }

    public bool Slave131 { get; set; }

    public bool Slave132 { get; set; }

    public bool Slave133 { get; set; }

    public bool Slave134 { get; set; }

    public bool Slave135 { get; set; }

    public bool Slave136 { get; set; }

    public bool Slave137 { get; set; }

    public bool Slave138 { get; set; }

    public bool Slave139 { get; set; }

    public bool Slave140 { get; set; }

    public bool Slave141 { get; set; }

    public bool Slave142 { get; set; }

    public bool Slave143 { get; set; }

    public bool Slave144 { get; set; }

    public bool Slave145 { get; set; }

    public bool Slave146 { get; set; }

    public bool Slave147 { get; set; }

    public bool Slave148 { get; set; }

    public bool Slave149 { get; set; }

    public bool Slave150 { get; set; }

    public bool Slave151 { get; set; }

    public bool Slave152 { get; set; }

    public bool Slave153 { get; set; }

    public bool Slave154 { get; set; }

    public bool Slave155 { get; set; }

    public bool Slave156 { get; set; }

    public bool Slave157 { get; set; }

    public bool Slave158 { get; set; }

    public bool Slave159 { get; set; }

    public bool Slave160 { get; set; }

    public bool Slave161 { get; set; }

    public bool Slave162 { get; set; }

    public bool Slave163 { get; set; }

    public bool Slave164 { get; set; }

    public bool Slave165 { get; set; }

    public bool Slave166 { get; set; }

    public bool Slave167 { get; set; }

    public bool Slave168 { get; set; }

    public bool Slave169 { get; set; }

    public bool Slave170 { get; set; }

    public bool Slave171 { get; set; }

    public bool Slave172 { get; set; }

    public bool Slave173 { get; set; }

    public bool Slave174 { get; set; }

    public bool Slave175 { get; set; }

    public bool Slave176 { get; set; }

    public bool Slave177 { get; set; }

    public bool Slave178 { get; set; }

    public bool Slave179 { get; set; }

    public bool Slave180 { get; set; }

    public bool Slave181 { get; set; }

    public bool Slave182 { get; set; }

    public bool Slave183 { get; set; }

    public bool Slave184 { get; set; }

    public bool Slave185 { get; set; }

    public bool Slave186 { get; set; }

    public bool Slave187 { get; set; }

    public bool Slave188 { get; set; }

    public bool Slave189 { get; set; }

    public bool Slave190 { get; set; }

    public bool Slave191 { get; set; }

    public bool Slave192 { get; set; }

    public bool Slave193 { get; set; }

    public bool Slave194 { get; set; }

    public bool Slave195 { get; set; }

    public bool Slave196 { get; set; }

    public bool Slave197 { get; set; }

    public bool Slave198 { get; set; }

    public bool Slave199 { get; set; }

    public bool Slave200 { get; set; }

    public bool Slave201 { get; set; }

    public bool Slave202 { get; set; }

    public bool Slave203 { get; set; }

    public bool Slave204 { get; set; }

    public bool Slave205 { get; set; }

    public bool Slave206 { get; set; }

    public bool Slave207 { get; set; }

    public bool Slave208 { get; set; }

    public bool Slave209 { get; set; }

    public bool Slave210 { get; set; }

    public bool Slave211 { get; set; }

    public bool Slave212 { get; set; }

    public bool Slave213 { get; set; }

    public bool Slave214 { get; set; }

    public bool Slave215 { get; set; }

    public bool Slave216 { get; set; }

    public bool Slave217 { get; set; }

    public bool Slave218 { get; set; }

    public bool Slave219 { get; set; }

    public bool Slave220 { get; set; }

    public bool Slave221 { get; set; }

    public bool Slave222 { get; set; }

    public bool Slave223 { get; set; }

    public bool Slave224 { get; set; }

    public bool Slave225 { get; set; }

    public bool Slave226 { get; set; }

    public bool Slave227 { get; set; }

    public bool Slave228 { get; set; }

    public bool Slave229 { get; set; }

    public bool Slave230 { get; set; }

    public bool Slave231 { get; set; }

    public bool Slave232 { get; set; }

    public bool Slave233 { get; set; }

    public bool Slave234 { get; set; }

    public bool Slave235 { get; set; }

    public bool Slave236 { get; set; }

    public bool Slave237 { get; set; }

    public bool Slave238 { get; set; }

    public bool Slave239 { get; set; }

    public bool Slave240 { get; set; }

    public bool Slave241 { get; set; }

    public bool Slave242 { get; set; }

    public bool Slave243 { get; set; }

    public bool Slave244 { get; set; }

    public bool Slave245 { get; set; }

    public bool Slave246 { get; set; }

    public bool Slave247 { get; set; }

    public bool Slave248 { get; set; }

    public bool Slave249 { get; set; }

    public bool Slave250 { get; set; }

    public bool Slave251 { get; set; }

    public bool Slave252 { get; set; }

    public bool Slave253 { get; set; }

    public bool Slave254 { get; set; }

    public bool Slave255 { get; set; }

    public bool Slave256 { get; set; }

    public bool Slave257 { get; set; }

    public bool Slave258 { get; set; }

    public bool Slave259 { get; set; }

    public bool Slave260 { get; set; }

    public bool Slave261 { get; set; }

    public bool Slave262 { get; set; }

    public bool Slave263 { get; set; }

    public bool Slave264 { get; set; }

    public bool Slave265 { get; set; }

    public bool Slave266 { get; set; }

    public bool Slave267 { get; set; }

    public bool Slave268 { get; set; }

    public bool Slave269 { get; set; }

    public bool Slave270 { get; set; }

    public bool Slave271 { get; set; }

    public bool Slave272 { get; set; }

    public bool Slave273 { get; set; }

    public bool Slave274 { get; set; }

    public bool Slave275 { get; set; }

    public bool Slave276 { get; set; }

    public bool Slave277 { get; set; }

    public bool Slave278 { get; set; }

    public bool Slave279 { get; set; }

    public bool Slave280 { get; set; }

    public bool Slave281 { get; set; }

    public bool Slave282 { get; set; }

    public bool Slave283 { get; set; }

    public bool Slave284 { get; set; }

    public bool Slave285 { get; set; }

    public bool Slave286 { get; set; }

    public bool Slave287 { get; set; }

    public bool Slave288 { get; set; }

    public bool Slave289 { get; set; }

    public bool Slave290 { get; set; }

    public bool Slave291 { get; set; }

    public bool Slave292 { get; set; }

    public bool Slave293 { get; set; }

    public bool Slave294 { get; set; }

    public bool Slave295 { get; set; }

    public bool Slave296 { get; set; }

    public bool Slave297 { get; set; }

    public bool Slave298 { get; set; }

    public bool Slave299 { get; set; }

    public bool Slave300 { get; set; }

    public bool Slave301 { get; set; }

    public bool Slave302 { get; set; }

    public bool Slave303 { get; set; }

    public bool Slave304 { get; set; }

    public bool Slave305 { get; set; }

    public bool Slave306 { get; set; }

    public bool Slave307 { get; set; }

    public bool Slave308 { get; set; }

    public bool Slave309 { get; set; }

    public bool Slave310 { get; set; }

    public bool Slave311 { get; set; }

    public bool Slave312 { get; set; }

    public bool Slave313 { get; set; }

    public bool Slave314 { get; set; }

    public bool Slave315 { get; set; }

    public bool Slave316 { get; set; }

    public bool Slave317 { get; set; }

    public bool Slave318 { get; set; }

    public bool Slave319 { get; set; }

    public bool Slave320 { get; set; }

    public bool Slave321 { get; set; }

    public bool Slave322 { get; set; }

    public bool Slave323 { get; set; }

    public bool Slave324 { get; set; }

    public bool Slave325 { get; set; }

    public bool Slave326 { get; set; }

    public bool Slave327 { get; set; }

    public bool Slave328 { get; set; }

    public bool Slave329 { get; set; }

    public bool Slave330 { get; set; }

    public bool Slave331 { get; set; }

    public bool Slave332 { get; set; }

    public bool Slave333 { get; set; }

    public bool Slave334 { get; set; }

    public bool Slave335 { get; set; }

    public bool Slave336 { get; set; }

    public bool Slave337 { get; set; }

    public bool Slave338 { get; set; }

    public bool Slave339 { get; set; }

    public bool Slave340 { get; set; }

    public bool Slave341 { get; set; }

    public bool Slave342 { get; set; }

    public bool Slave343 { get; set; }

    public bool Slave344 { get; set; }

    public bool Slave345 { get; set; }

    public bool Slave346 { get; set; }

    public bool Slave347 { get; set; }

    public bool Slave348 { get; set; }

    public bool Slave349 { get; set; }

    public bool Slave350 { get; set; }

    public bool Slave351 { get; set; }

    public bool Slave352 { get; set; }

    public bool Slave353 { get; set; }

    public bool Slave354 { get; set; }

    public bool Slave355 { get; set; }

    public bool Slave356 { get; set; }

    public bool Slave357 { get; set; }

    public bool Slave358 { get; set; }

    public bool Slave359 { get; set; }

    public bool Slave360 { get; set; }

    public bool Slave361 { get; set; }

    public bool Slave362 { get; set; }

    public bool Slave363 { get; set; }

    public bool Slave364 { get; set; }

    public bool Slave365 { get; set; }

    public bool Slave366 { get; set; }

    public bool Slave367 { get; set; }

    public bool Slave368 { get; set; }

    public bool Slave369 { get; set; }

    public bool Slave370 { get; set; }

    public bool Slave371 { get; set; }

    public bool Slave372 { get; set; }

    public bool Slave373 { get; set; }

    public bool Slave374 { get; set; }

    public bool Slave375 { get; set; }

    public bool Slave376 { get; set; }

    public bool Slave377 { get; set; }

    public bool Slave378 { get; set; }

    public bool Slave379 { get; set; }

    public bool Slave380 { get; set; }

    public bool Slave381 { get; set; }

    public bool Slave382 { get; set; }

    public bool Slave383 { get; set; }

    public bool Slave384 { get; set; }

    public bool Slave385 { get; set; }

    public bool Slave386 { get; set; }

    public bool Slave387 { get; set; }

    public bool Slave388 { get; set; }

    public bool Slave389 { get; set; }

    public bool Slave390 { get; set; }

    public bool Slave391 { get; set; }

    public bool Slave392 { get; set; }

    public bool Slave393 { get; set; }

    public bool Slave394 { get; set; }

    public bool Slave395 { get; set; }

    public bool Slave396 { get; set; }

    public bool Slave397 { get; set; }

    public bool Slave398 { get; set; }

    public bool Slave399 { get; set; }

    public bool Slave400 { get; set; }

    public bool Slave401 { get; set; }

    public bool Slave402 { get; set; }

    public bool Slave403 { get; set; }

    public bool Slave404 { get; set; }

    public bool Slave405 { get; set; }

    public bool Slave406 { get; set; }

    public bool Slave407 { get; set; }

    public bool Slave408 { get; set; }

    public bool Slave409 { get; set; }

    public bool Slave410 { get; set; }

    public bool Slave411 { get; set; }

    public bool Slave412 { get; set; }

    public bool Slave413 { get; set; }

    public bool Slave414 { get; set; }

    public bool Slave415 { get; set; }

    public bool Slave416 { get; set; }

    public bool Slave417 { get; set; }

    public bool Slave418 { get; set; }

    public bool Slave419 { get; set; }

    public bool Slave420 { get; set; }

    public bool Slave421 { get; set; }

    public bool Slave422 { get; set; }

    public bool Slave423 { get; set; }

    public bool Slave424 { get; set; }

    public bool Slave425 { get; set; }

    public bool Slave426 { get; set; }

    public bool Slave427 { get; set; }

    public bool Slave428 { get; set; }

    public bool Slave429 { get; set; }

    public bool Slave430 { get; set; }

    public bool Slave431 { get; set; }

    public bool Slave432 { get; set; }

    public bool Slave433 { get; set; }

    public bool Slave434 { get; set; }

    public bool Slave435 { get; set; }

    public bool Slave436 { get; set; }

    public bool Slave437 { get; set; }

    public bool Slave438 { get; set; }

    public bool Slave439 { get; set; }

    public bool Slave440 { get; set; }

    public bool Slave441 { get; set; }

    public bool Slave442 { get; set; }

    public bool Slave443 { get; set; }

    public bool Slave444 { get; set; }

    public bool Slave445 { get; set; }

    public bool Slave446 { get; set; }

    public bool Slave447 { get; set; }

    public bool Slave448 { get; set; }

    public bool Slave449 { get; set; }

    public bool Slave450 { get; set; }

    public bool Slave451 { get; set; }

    public bool Slave452 { get; set; }

    public bool Slave453 { get; set; }

    public bool Slave454 { get; set; }

    public bool Slave455 { get; set; }

    public bool Slave456 { get; set; }

    public bool Slave457 { get; set; }

    public bool Slave458 { get; set; }

    public bool Slave459 { get; set; }

    public bool Slave460 { get; set; }

    public bool Slave461 { get; set; }

    public bool Slave462 { get; set; }

    public bool Slave463 { get; set; }

    public bool Slave464 { get; set; }

    public bool Slave465 { get; set; }

    public bool Slave466 { get; set; }

    public bool Slave467 { get; set; }

    public bool Slave468 { get; set; }

    public bool Slave469 { get; set; }

    public bool Slave470 { get; set; }

    public bool Slave471 { get; set; }

    public bool Slave472 { get; set; }

    public bool Slave473 { get; set; }

    public bool Slave474 { get; set; }

    public bool Slave475 { get; set; }

    public bool Slave476 { get; set; }

    public bool Slave477 { get; set; }

    public bool Slave478 { get; set; }

    public bool Slave479 { get; set; }

    public bool Slave480 { get; set; }

    public bool Slave481 { get; set; }

    public bool Slave482 { get; set; }

    public bool Slave483 { get; set; }

    public bool Slave484 { get; set; }

    public bool Slave485 { get; set; }

    public bool Slave486 { get; set; }

    public bool Slave487 { get; set; }

    public bool Slave488 { get; set; }

    public bool Slave489 { get; set; }

    public bool Slave490 { get; set; }

    public bool Slave491 { get; set; }

    public bool Slave492 { get; set; }

    public bool Slave493 { get; set; }

    public bool Slave494 { get; set; }

    public bool Slave495 { get; set; }

    public bool Slave496 { get; set; }

    public bool Slave497 { get; set; }

    public bool Slave498 { get; set; }

    public bool Slave499 { get; set; }

    public bool Slave500 { get; set; }
}
