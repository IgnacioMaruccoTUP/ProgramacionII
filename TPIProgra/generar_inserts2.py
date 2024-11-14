import pyodbc
import random
from datetime import datetime, timedelta
from collections import defaultdict

# Conexión a la base de datos
def obtener_horarios_funciones():
    conexion = pyodbc.connect(
        'DRIVER={ODBC Driver 17 for SQL Server};SERVER=DESKTOP-9P35AP4\SQLEXPRESS;DATABASE=db_tp;Trusted_Connection=yes'
    )
    cursor = conexion.cursor()
    cursor.execute("SELECT id_funcion, horario FROM funciones")
    funciones = cursor.fetchall()
    conexion.close()
    print(f"Funciones obtenidas: {len(funciones)}")  # Depuración
    return [(fila[0], fila[1]) for fila in funciones]

# Obtiene los clientes existentes en la base de datos
def obtener_clientes():
    conexion = pyodbc.connect(
        'DRIVER={ODBC Driver 17 for SQL Server};SERVER=DESKTOP-9P35AP4\SQLEXPRESS;DATABASE=db_tp;Trusted_Connection=yes'
    )
    cursor = conexion.cursor()
    cursor.execute("SELECT id_cliente FROM clientes")
    clientes = cursor.fetchall()
    conexion.close()
    return [fila[0] for fila in clientes]  # Devuelve solo los IDs de cliente

# Obtiene los tipos de entrada existentes en la base de datos
def obtener_tipos_entrada():
    conexion = pyodbc.connect(
        'DRIVER={ODBC Driver 17 for SQL Server};SERVER=DESKTOP-9P35AP4\SQLEXPRESS;DATABASE=db_tp;Trusted_Connection=yes'
    )
    cursor = conexion.cursor()
    cursor.execute("SELECT id_tipo_entrada FROM tipos_entrada")
    tipos_entrada = cursor.fetchall()
    conexion.close()
    return [fila[0] for fila in tipos_entrada]  # Devuelve solo los IDs de tipo de entrada

# Obtiene las formas de pago existentes en la base de datos
def obtener_formas_pago():
    conexion = pyodbc.connect(
        'DRIVER={ODBC Driver 17 for SQL Server};SERVER=DESKTOP-9P35AP4\SQLEXPRESS;DATABASE=db_tp;Trusted_Connection=yes'
    )
    cursor = conexion.cursor()
    cursor.execute("SELECT id_forma_pago FROM formas_pago")
    formas_pago = cursor.fetchall()
    conexion.close()
    return [fila[0] for fila in formas_pago]  # Devuelve solo los IDs de forma de pago

# Obtiene las formas de compra existentes en la base de datos
def obtener_formas_compra():
    conexion = pyodbc.connect(
        'DRIVER={ODBC Driver 17 for SQL Server};SERVER=DESKTOP-9P35AP4\SQLEXPRESS;DATABASE=db_tp;Trusted_Connection=yes'
    )
    cursor = conexion.cursor()
    cursor.execute("SELECT id_forma_compra FROM formas_compra")
    formas_compra = cursor.fetchall()
    conexion.close()
    return [fila[0] for fila in formas_compra]  # Devuelve solo los IDs de forma de compra

# Obtiene las promociones existentes en la base de datos
def obtener_promociones():
    conexion = pyodbc.connect(
        'DRIVER={ODBC Driver 17 for SQL Server};SERVER=DESKTOP-9P35AP4\SQLEXPRESS;DATABASE=db_tp;Trusted_Connection=yes'
    )
    cursor = conexion.cursor()
    cursor.execute("SELECT id_promocion FROM promociones")
    promociones = cursor.fetchall()
    conexion.close()
    return [fila[0] for fila in promociones]  # Devuelve solo los IDs de promociones

# Obtiene los IDs de butacas existentes en la base de datos
def obtener_butacas():
    conexion = pyodbc.connect(
        'DRIVER={ODBC Driver 17 for SQL Server};SERVER=DESKTOP-9P35AP4\SQLEXPRESS;DATABASE=db_tp;Trusted_Connection=yes'
    )
    cursor = conexion.cursor()
    cursor.execute("SELECT id_butaca, fila, columna FROM butacas")
    butacas = cursor.fetchall()
    conexion.close()
    return butacas  # Devuelve solo los IDs de butaca, fila y columna

def es_central(butaca):
    fila, columna = butaca[1], butaca[2]
    # Define your central seat criteria, e.g., middle rows and columns
    return (fila in {3, 4, 5} and columna in {5, 6, 7})  # Example condition for central seats


def generar_entradas_por_funcion(funciones, capacidad_total):
    entradas_por_dia = defaultdict(list)  
    for funcion in funciones:
        min_entradas = int(capacidad_total * 0.1) #Minimo entradas generadas
        max_entradas = int(capacidad_total * 0.8)  #Maximo entradas generadas
        
        # Randomly determine how many entries to generate for this function
        num_entradas = random.randint(min_entradas, max_entradas)
        
        # Probability to decide if the function will have entries on that day
        if random.random() < 1:  
            for _ in range(num_entradas):
                id_funcion = funcion[0]
                horario_funcion = funcion[1]
                dia = horario_funcion.date()
                
                # Preferential selection for central butacas
                if random.random() < 0.7:  # 70% chance of choosing a central seat
                    central_butacas = [b for b in butacas if es_central(b)]
                    if central_butacas:
                        id_butaca = random.choice(central_butacas)[0]
                    else:
                        id_butaca = random.choice(butacas)[0]  # Fallback if no central seats
                else:
                    id_butaca = random.choice(butacas)[0]  # 30% chance for any seat
                
                id_promocion = random.choice(promociones)
                id_tipo_entrada = random.choice(tipos_entrada)
                precio = random.uniform(6000.0, 9000.0)
                entradas_por_dia[dia].append((id_butaca, id_funcion, id_promocion, id_tipo_entrada, precio))
    
    print(f"Total entradas generadas por día: {sum(len(v) for v in entradas_por_dia.values())}")  
    return entradas_por_dia

def distribuir_entradas_en_reservas(entradas_por_dia, clientes, formas_pago, formas_compra, promociones):
    reservas = []
    entradas = []
    entradas_unicas = set()  # Para rastrear combinaciones únicas
    id_reserva = 1

    for dia, entradas_dia in entradas_por_dia.items():
        max_reservas_por_dia = random.randint(10, 20)  
        num_reservas = random.randint(5, max_reservas_por_dia)  # Al menos 3 reservas
        
        for _ in range(num_reservas):
            id_forma_pago = random.choice(formas_pago)
            id_cliente = random.choice(clientes)
            id_forma_compra = random.choice(formas_compra)

            # Fecha de la función en el día actual
            fecha_funcion = dia

            # Establecer la fecha de emisión como un día antes de la fecha de la función
            fecha_emision = fecha_funcion - timedelta(days=random.randint(1, 7))  # Entre 1 a 7 días antes

            # La fecha de pago debe ser entre la fecha de emisión y el día anterior a la fecha de la función
            max_fecha_pago = fecha_funcion - timedelta(days=1)  # Debe ser antes de la fecha de la función
            fecha_pago = fecha_emision + timedelta(days=random.randint(0, (max_fecha_pago - fecha_emision).days))

            # Validación para asegurar que fecha_pago no sea posterior a fecha_funcion
            if fecha_pago > fecha_funcion:
                print(f"Error: fecha_pago {fecha_pago} es posterior a fecha_funcion {fecha_funcion}")
                continue  # Salir de este bucle para no agregar la reserva

            # Estado de pago con 80% de probabilidad de ser 1 y 20% de ser 0
            estado_pago = random.choices([0, 1], weights=[20, 80])[0]
            # Crear la reserva asegurando que las fechas cumplen las condiciones
            reservas.append((id_forma_pago, id_cliente, id_forma_compra, fecha_emision, fecha_pago, estado_pago))

            # Seleccionar entradas para esta reserva
            num_entradas_reserva = random.randint(1, max(1, len(entradas_dia) // num_reservas))  # Al menos 1 entrada
            if num_entradas_reserva > len(entradas_dia):
                num_entradas_reserva = len(entradas_dia)
                
            entradas_seleccionadas = [entradas_dia.pop(0) for _ in range(num_entradas_reserva)]
            
            for entrada in entradas_seleccionadas:
                id_butaca, id_funcion, _, id_tipo_entrada, precio = entrada
                id_promocion = random.choice(promociones)
                
                # Verificar si la combinación ya fue utilizada
                if (id_butaca, id_funcion) not in entradas_unicas:
                    entradas.append((id_butaca, id_funcion, id_reserva, id_promocion, id_tipo_entrada, precio))
                    entradas_unicas.add((id_butaca, id_funcion))

            id_reserva += 1

    return reservas, entradas





def insertar_datos(reservas, entradas):
    conexion = pyodbc.connect(
        'DRIVER={ODBC Driver 17 for SQL Server};SERVER=DESKTOP-9P35AP4\SQLEXPRESS;DATABASE=db_tp;Trusted_Connection=yes'
    )
    cursor = conexion.cursor()

    last_ids_reserva = []  # List to hold the last inserted IDs for reservas

    if reservas:
        # Create a temporary table to hold the output IDs
        cursor.execute("""CREATE TABLE #TempReservas (id_reserva INT)""")

        try:
            # Insert the reservations and capture the IDs into the temporary table
            cursor.executemany("""INSERT INTO reservas (id_forma_pago, id_cliente, id_forma_compra, fecha_emision, fecha_pago, estado_pago) OUTPUT INSERTED.id_reserva INTO #TempReservas VALUES (?, ?, ?, ?, ?, ?)""", reservas)

            # Retrieve the last inserted IDs
            cursor.execute("SELECT id_reserva FROM #TempReservas")
            last_ids_reserva = [row[0] for row in cursor.fetchall()]
        except Exception as e:
            print(f"Error inserting reservas: {e}")
        finally:
            # Drop the temporary table
            cursor.execute("DROP TABLE #TempReservas")

    if entradas:
        # Prepare the entradas data for insertion
        entradas_datos = []
        for i, entrada in enumerate(entradas):
            id_butaca, id_funcion, _, id_promocion, id_tipo_entrada, precio = entrada
            # Use the corresponding reserva ID from last_ids_reserva
            id_reserva = last_ids_reserva[i % len(last_ids_reserva)] if last_ids_reserva else None
            entradas_datos.append((id_butaca, id_funcion, id_reserva, id_promocion, id_tipo_entrada, precio))

        try:
            # Insert entradas
            cursor.executemany("""INSERT INTO entradas (id_butaca, id_funcion, id_reserva, id_promocion, id_tipo_entrada, precio) VALUES (?, ?, ?, ?, ?, ?)""", entradas_datos)
        except Exception as e:
            print(f"Error inserting entradas: {e}")

    try:
        conexion.commit()
    except Exception as e:
        print(f"Error committing transaction: {e}")
    finally:
        cursor.close()
        conexion.close()
        print("Datos insertados correctamente.")


# Ejecución del script
if __name__ == "__main__":
    funciones = obtener_horarios_funciones()
    clientes = obtener_clientes()
    tipos_entrada = obtener_tipos_entrada()
    formas_pago = obtener_formas_pago()
    formas_compra = obtener_formas_compra()
    promociones = obtener_promociones()
    butacas = obtener_butacas()

    # Define total capacity, assuming a static value for this example.
    total_capacity = 100  # Adjust as necessary for your theater's total capacity

    entradas_por_funcion = generar_entradas_por_funcion(funciones, total_capacity)
    reservas, entradas = distribuir_entradas_en_reservas(entradas_por_funcion, clientes, formas_pago, formas_compra, promociones)
    insertar_datos(reservas, entradas)
