﻿using System;

namespace kOS
{
    public class BodyTarget : SpecialValue
    {
        private readonly ExecutionContext context;

        public BodyTarget(String name, ExecutionContext context) : this(VesselUtils.GetBodyByName(name), context) { }

        public BodyTarget(CelestialBody target, ExecutionContext context)
        {
            this.context = context;
            Target = target;
        }

        public CelestialBody Target { get; set; }

        public double GetDistance()
        {
            return Vector3d.Distance(context.Vessel.GetWorldPos3D(), Target.position) - Target.Radius;
        }

        public override object GetSuffix(string suffixName)
        {
            if (Target == null) throw new kOSException("BODY structure appears to be empty!");

            switch (suffixName)
            {
                case "NAME":
                    return Target.name;
                case "DESCRIPTION":
                    return Target.bodyDescription;
                case "MASS":
                    return Target.Mass;
                case "POSITION":
                    return new Vector(Target.position);
                case "ALTITUDE":
                    return Target.orbit.altitude;
                case "APOAPSIS":
                    return Target.orbit.ApA;
                case "PERIAPSIS":
                    return Target.orbit.PeA;
                case "RADIUS":
                    return Target.Radius;
                case "G":
                    return Target.GeeASL;
                case "MU":
                    return Target.gravParameter;
                case "ATM":
                    return new BodyAtmosphere(Target);
                case "VELOCITY":
                    return new Vector(Target.orbit.GetVel());
                case "DISTANCE":
                    return (float)GetDistance();
                case "BODY":
                    return new BodyTarget(Target.orbit.referenceBody, context);
            }

            return base.GetSuffix(suffixName);
        }

        public override string ToString()
        {
 	        if (Target != null)
            {
                return "BODY(\"" + Target.name + "\")";
            }

            return base.ToString();
        }
    }


}
