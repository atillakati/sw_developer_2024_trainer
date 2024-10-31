using System;
using System.Collections.Generic;
using MongoDB.Bson;
using Wifi.TeilnehmerVerwaltungV4.Core;

namespace Wifi.TeilnehmerVerwaltungV4.Repository.Entities
{
    //internal abstract class TeilnehmerMapper
    //{
    //    public static Teilnehmer MapToDomain(TeilnehmerEntity entity)
    //    {
    //        if (entity == null)
    //        {
    //            return null;
    //        }

    //        return new Teilnehmer
    //        {
    //            Vorname = entity.Vorname,
    //            Nachname = entity.Nachname,
    //            Geburtsdatum = entity.Geburtsdatum,
    //            Plz = entity.Plz,
    //            Ort = entity.Ort,
    //            Id = entity.Id.ToString(),
    //        };
    //    }

    //    public static IEnumerable<Teilnehmer> MapToDomain(IEnumerable<TeilnehmerEntity> entityList)
    //    {
    //        if (entityList == null)
    //        {
    //            return Array.Empty<Teilnehmer>();
    //        }

    //        var teilnehmerList = new List<Teilnehmer>();
    //        foreach (var entity in entityList)    
    //        {
    //            var teilnehmer = MapToDomain(entity);
    //            if (teilnehmer != null)
    //            {
    //                teilnehmerList.Add(teilnehmer);
    //            }
    //        }

    //        return teilnehmerList;
    //    }

    //    public static TeilnehmerEntity MapToEntity(Teilnehmer teilnehmer)
    //    {
    //        ObjectId newObjectId = ObjectId.Empty;

    //        if (teilnehmer == null)
    //        {
    //            return null;
    //        }

    //        if (ObjectId.TryParse(teilnehmer.Id, out newObjectId))
    //        {
    //            return new TeilnehmerEntity
    //            {
    //                Vorname = teilnehmer.Vorname,
    //                Nachname = teilnehmer.Nachname,
    //                Geburtsdatum = teilnehmer.Geburtsdatum,
    //                Plz = teilnehmer.Plz,
    //                Ort = teilnehmer.Ort,
    //                Id = newObjectId
    //            };
    //        }

    //        return null;
    //    }
    //}

    public static class TeilnehmerExtensions
    {
        public static Teilnehmer ToDomain(this TeilnehmerEntity entity)
        {
            if (entity == null)
            {
                return null;
            }

            return new Teilnehmer
            {
                Vorname = entity.Vorname,
                Nachname = entity.Nachname,
                Geburtsdatum = entity.Geburtsdatum,
                Plz = entity.Plz,
                Ort = entity.Ort,
                Id = entity.Id.ToString(),
            };
        }
    
        public static IEnumerable<Teilnehmer> ToDomain(this IEnumerable<TeilnehmerEntity> entityList)
        {
            if (entityList == null)
            {
                return Array.Empty<Teilnehmer>();
            }

            var teilnehmerList = new List<Teilnehmer>();
            foreach (var entity in entityList)
            {
                var teilnehmer = entity.ToDomain();
                if (teilnehmer != null)
                {
                    teilnehmerList.Add(teilnehmer);
                }
            }

            return teilnehmerList;
        }

        public static TeilnehmerEntity ToEntity(this Teilnehmer teilnehmer)
        {
            ObjectId newObjectId = ObjectId.Empty;

            if (teilnehmer == null)
            {
                return null;
            }

            if (ObjectId.TryParse(teilnehmer.Id, out newObjectId))
            {
                return new TeilnehmerEntity
                {
                    Vorname = teilnehmer.Vorname,
                    Nachname = teilnehmer.Nachname,
                    Geburtsdatum = teilnehmer.Geburtsdatum,
                    Plz = teilnehmer.Plz,
                    Ort = teilnehmer.Ort,
                    Id = newObjectId
                };
            }

            return null;
        }
    }
}
