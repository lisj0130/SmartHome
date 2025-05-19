export default function Lights({ lampStates }) {
    return (
        <>
            {/* Ljusk�llor */}
            <ambientLight intensity={1} /> {/* Mjuk ljusk�lla */}

            <pointLight // Taklampa, id = 1
                color="#fff8dc"             // varmvit f�rg
                intensity={lampStates[1] ? 30 : 0}               // starkt ljus
                position={[0, 2, 0]}        // takposition i mitten av rummet
                distance={60}               // hur l�ngt ljuset n�r
                decay={1.5}                   // realistiskt ljusavtagande
                castShadow
            />

            <pointLight // golvlampa, id = 2
                color="white"       // mjukt varmt ljus, du kan ocks� anv�nda hex t.ex. "#ffdca3"
                intensity={lampStates[2] ? 10 : 0}           // styrka p� ljuset
                position={[-8.8, 3.2, -8.5]} // placera lite ovanf�r lampans bas
                distance={15}           // hur l�ngt ljuset n�r
                decay={1.5}               // ljusets avtagande (2 = realistiskt)
            />

            <pointLight  // dekorationslampa, id = 3
                color="white"       // mjukt varmt ljus, du kan ocks� anv�nda hex t.ex. "#ffdca3"
                intensity={lampStates[3] ? 5 : 0}           // styrka p� ljuset
                position={[9, 2, 5]} // placera lite ovanf�r lampans bas
                distance={15}           // hur l�ngt ljuset n�r
                decay={1.5}               // ljusets avtagande (2 = realistiskt)
            />
        </>
    );
}
