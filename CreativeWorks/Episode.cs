﻿#region License
// Copyright (c) 2022 1010Tires.com
//
// Permission is hereby granted, free of charge, to any person
// obtaining a copy of this software and associated documentation
// files (the "Software"), to deal in the Software without
// restriction, including without limitation the rights to use,
// copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the
// Software is furnished to do so, subject to the following
// conditions:
//
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES
// OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT
// HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY,
// WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
// FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
// OTHER DEALINGS IN THE SOFTWARE.
#endregion

using MXTires.Microdata.Intangible.Quantities;
using MXTires.Microdata.Organizations.PerformingGroups;
using MXTires.Microdata.Validators;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace MXTires.Microdata.CreativeWorks
{
    /// <summary>
    /// A media episode (e.g. TV, radio, video game) which can be part of a series or season.
    /// </summary>
    public class Episode : CreativeWork
    {
        /// <summary>
        /// Person - An actor, e.g. in tv, radio, movie, video games etc. Actors can be associated with individual items or with a series, episode, clip. Supersedes <see cref="Actors"/>.
        /// </summary>
        [JsonProperty("actor")]
        public Person Actor
        {
            get;
            set;
        }

        /// <summary>
        /// An actor, e.g. in tv, radio, movie, video games etc. Actors can be associated with individual items or with a series, episode, clip. Supersedes by <see cref="Actor"/>.
        /// </summary>
        [JsonProperty("actors")]
        public IList<Person> Actors { get; set; }


        /// <summary>
        /// Person - A director of e.g. tv, radio, movie, video games etc. content. Directors can be associated with individual items or with a series, episode, clip. Supersedes <see cref="Directors"/>.
        /// </summary>
        [JsonProperty("director")]
        public Person Director
        {
            get;
            set;
        }

        /// <summary>
        /// A director of e.g. tv, radio, movie, video games etc. content. Directors can be associated with individual items or with a series, episode, clip. Supersedes by <see cref="Actor"/>.
        /// </summary>
        [JsonProperty("directors")]
        public IList<Person> Directors { get; set; }

        /// <summary>
        /// The duration of the item(movie, audio recording, event, etc.) in ISO 8601 date format.
        /// </summary>
        [JsonProperty("duration")]
        public Duration Duration { get; set; }

        /// <summary>
        /// Integer or Text - Position of the episode within an ordered group of episodes.
        /// </summary>
        [JsonProperty("episodeNumber")]
        public Int32? EpisodeNumber
        {
            get;
            set;
        }

        Thing musicBy;
        /// <summary>
        /// MusicGroup  or Person - The composer of the soundtrack.
        /// </summary>
        /// <value>MusicGroup  or Person - The composer of the soundtrack.</value>
        [JsonProperty("musicBy")]
        public Thing MusicBy
        {
            get
            {
                return musicBy;
            }
            set
            {
                var validator = new TypeValidator(typeof(MusicGroup), typeof(Person));
                validator.Validate(value);
                musicBy = value;
            }
        }

        /// <summary>
        /// CreativeWorkSeason - The season to which this episode belongs.
        /// </summary>
        [JsonProperty("partOfSeason")]
        public CreativeWorkSeason PartOfSeason
        {
            get;
            set;
        }

        /// <summary>
        /// CreativeWorkSeries - The series to which this episode or season belongs. Supersedes partOfTVSeries.
        /// </summary>
        [JsonProperty("partOfSeries")]
        public CreativeWorkSeries PartOfSeries
        {
            get;
            set;
        }

        /// <summary>
        /// Organization - The production company or studio responsible for the item e.g. series, video game, episode etc.
        /// </summary>
        [JsonProperty("productionCompany")]
        public Organization ProductionCompany
        {
            get;
            set;
        }

        /// <summary>
        /// VideoObject - The trailer of a movie or tv/radio series, season, episode, etc.
        /// </summary>
        [JsonProperty("trailer")]
        public VideoObject Trailer
        {
            get;
            set;
        }

        /// <summary>
        /// A flag to signal that the publication is accessible for free.
        /// </summary>
        [JsonProperty("isAccessibleForFree")]
        public Boolean? IsAccessibleForFree { get; set; }

    }
}
