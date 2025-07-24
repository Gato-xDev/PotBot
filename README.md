# PotBot
Increase specific player(s) damage dealt , received and heal on hit by other players.





Players - Players which bonuses will apply
damageMulti - Multiplier applied to the damage a <player> in config is doing to other players IE - 1.2 will increase outgoing damage by 20%
damageMultiActive - if damage multiplier should be used

damageResistance - % of damage resistance for all players in <players> IE - 0.3 will reduce incoming damage by 30% 
damageResistanceActive - if resistance should be used

onHitHeal - # Of HP for player in <players> to heal when hit by other players (Very OP in PVP)
onHitHealActive - if onHitHeal healing should be used


  <players>
    <string>76561198970181914</string>
    <string>76561198143971531</string>
  </players>
  <damageMulti>1</damageMulti>
  <damageMultiActive>true</damageMultiActive>
  <damageResistance>0</damageResistance>
  <damageResistanceActive>true</damageResistanceActive>
  <onHitHeal>0</onHitHeal>
  <onHitHealActive>true</onHitHealActive>
