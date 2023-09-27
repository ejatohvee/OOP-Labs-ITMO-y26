using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Deflectors;

 public interface IDeflector
 {
     ShipState TakeDamage(IEnumerable<Obstacles.Obstacle> damageSources);
 }