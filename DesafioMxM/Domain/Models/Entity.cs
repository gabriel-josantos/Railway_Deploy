﻿using System.ComponentModel.DataAnnotations;

namespace DesafioMxM.Domain.Models;

   
    public interface IEntity
    {
        public long Id { get; set; }
    }
    public abstract class Entity : IEntity
    {
        [Key]
        [Required]
        public long Id { get; set; }

    }




